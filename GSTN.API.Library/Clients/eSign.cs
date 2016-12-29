using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;

namespace GSTN.API
{
    public class eSign
    {
        Response objResponse;
        private string Timestamp;

        public Response GetOTP(string AadhaarNumber, string TransactionID)
        {
            try
            {
                objResponse = new Response();
                if (IsvalidateAadarNumber(AadhaarNumber, ref objResponse))
                {
                    if (string.IsNullOrWhiteSpace(TransactionID))
                    {
                        objResponse.ErrorMessage = "Empty Unique Transaction Id";
                        objResponse.ResponseStatus = Response.Status.Failure;
                        return objResponse;
                    }
                    if (string.IsNullOrWhiteSpace(eSignSettings.ASPID))
                    {
                        objResponse.ErrorMessage = "AspId is empty";
                        objResponse.ResponseStatus = Response.Status.Failure;
                        return objResponse;
                    }
                    if (string.IsNullOrWhiteSpace(eSignSettings.OTPURL))
                    {
                        objResponse.ErrorMessage = "OTP URL is empty";
                        objResponse.ResponseStatus = Response.Status.Failure;
                        return objResponse;
                    }
                    if (string.IsNullOrWhiteSpace(eSignSettings.PfxPath))
                    {
                        objResponse.ErrorMessage = "Asp signing pfx file path is empty";
                        objResponse.ResponseStatus = Response.Status.Failure;
                        return objResponse;
                    }
                    if (string.IsNullOrWhiteSpace(eSignSettings.PfxPassword))
                    {
                        objResponse.ErrorMessage = "Asp signing password file path is empty";
                        objResponse.ResponseStatus = Response.Status.Failure;
                        return objResponse;
                    }
                    string RawXml = GenrateRawXml(eSignSettings.ASPID, AadhaarNumber, TransactionID);
                    string siginedxml = SignXML(RawXml);
                    string otprsp = Common.HttpsWebClientSendSMS(eSignSettings.OTPURL, HttpUtility.UrlEncode(siginedxml));
                    XmlDocument ResponseXML = new XmlDocument();
                    if (string.IsNullOrEmpty(otprsp))
                    {
                        objResponse.ErrorMessage = "Null Response";
                        objResponse.ResponseStatus = Response.Status.Failure;
                        return objResponse;
                    }
                    else
                    {
                        ResponseXML.LoadXml(otprsp.Trim());
                        XmlNode OTPResp = ResponseXML.SelectSingleNode("OTPResp");
                        if (OTPResp.Attributes["status"].Value.Trim() == "1")
                        {
                            objResponse.ResponseStatus = Response.Status.Success;
                            return objResponse;
                        }
                        else
                        {
                            objResponse.ErrorCode = OTPResp.Attributes["errCode"].Value.Trim();
                            objResponse.ErrorMessage = OTPResp.Attributes["errMsg"].Value.Trim();
                            objResponse.ResponseStatus = Response.Status.Failure;
                            return objResponse;
                        }
                    }
                }
                else
                {
                    return objResponse;
                }
            }
            catch (Exception ex)
            {
                objResponse.ErrorMessage = ex.Message;
                objResponse.ResponseStatus = Response.Status.Failure;
                return objResponse;
            }
        }


        public Response SignText(string Aadhaarnum, string AuthenticationValue, string UniqueTransactionId, string TextToBeSigned, AuthMetaDetails MetaDetails)
        {
            objResponse = new Response();
            try
            {
                if (!IsvalidateAadarNumber(Aadhaarnum, ref objResponse))
                {
                    return objResponse;
                }
                if (!IsValidTransactionID(UniqueTransactionId, ref objResponse))
                {
                    return objResponse;
                }
                if (string.IsNullOrWhiteSpace(eSignSettings.ASPID))
                {
                    objResponse.ErrorMessage = "Invalid ASPID";
                    objResponse.ResponseStatus = Response.Status.Failure;
                    return objResponse;
                }
                if (string.IsNullOrWhiteSpace(eSignSettings.EsignURL))
                {
                    objResponse.ErrorMessage = "Invalid eAuth url";
                    objResponse.ResponseStatus = Response.Status.Failure;
                    return objResponse;
                }
                if (string.IsNullOrWhiteSpace(eSignSettings.PfxPassword))
                {
                    objResponse.ErrorMessage = "Invalid PFX password";
                    objResponse.ResponseStatus = Response.Status.Failure;
                    return objResponse;
                }
                if (string.IsNullOrWhiteSpace(eSignSettings.PfxPath))
                {
                    objResponse.ErrorMessage = "Invalid PFX path";
                    objResponse.ResponseStatus = Response.Status.Failure;
                    return objResponse;
                }
                else if (File.Exists(eSignSettings.PfxPath))
                {
                    try
                    {
                        X509Certificate2 Cert = new X509Certificate2();
                        Cert = new X509Certificate2(eSignSettings.PfxPath, eSignSettings.PfxPassword, X509KeyStorageFlags.Exportable);
                    }
                    catch (Exception ex)
                    {
                        objResponse.ErrorMessage = "Invalid PFX path" + ex.Message;
                        objResponse.ResponseStatus = Response.Status.Failure;
                        return objResponse;
                    }
                }
                else
                {
                    objResponse.ErrorMessage = "Pfx file not present in PFX path:" + eSignSettings.PfxPath;
                    objResponse.ResponseStatus = Response.Status.Failure;
                    return objResponse;
                }
                if (string.IsNullOrWhiteSpace(eSignSettings.UIDAICertificatePath))
                {
                    objResponse.ErrorMessage = "UIDAI Certificate Path";
                    objResponse.ResponseStatus = Response.Status.Failure;
                    return objResponse;
                }
                else if (File.Exists(eSignSettings.UIDAICertificatePath))
                {
                    try
                    {
                        File.ReadAllText(eSignSettings.UIDAICertificatePath);
                    }
                    catch (Exception ex)
                    {
                        objResponse.ErrorMessage = "UIDAI Certificate Path" + ex.Message;
                        objResponse.ResponseStatus = Response.Status.Failure;
                        return objResponse;
                    }
                }
                else
                {
                    objResponse.ErrorMessage = "UIDAI Certificate Path file not present in Path:" + eSignSettings.UIDAICertificatePath;
                    objResponse.ResponseStatus = Response.Status.Failure;
                    return objResponse;
                }
                if (!string.IsNullOrWhiteSpace(TextToBeSigned))
                {
                    try
                    {
                        byte[] sdoc = eSignText(TextToBeSigned, AuthenticationValue, Aadhaarnum, UniqueTransactionId, MetaDetails, new SignatureAppearance(), ref objResponse, "", "", "");
                        if (objResponse.ResponseStatus == Response.Status.Success)
                        {
                            objResponse.ResponseStatus = Response.Status.Success;
                            return objResponse;
                        }
                        else
                        {
                            objResponse.ResponseStatus = Response.Status.Failure;
                            return objResponse;
                        }
                    }
                    catch (Exception ex)
                    {
                        objResponse.ErrorMessage = ex.Message;
                        objResponse.ResponseStatus = Response.Status.Failure;
                        return objResponse;
                    }
                }
                else
                {
                    objResponse.ErrorMessage = "Text to be signed is empty" + eSignSettings.UIDAICertificatePath;
                    objResponse.ResponseStatus = Response.Status.Failure;
                    return objResponse;
                }
            }
            catch (Exception ex)
            {
                objResponse.ErrorMessage = ex.Message;
                objResponse.ResponseStatus = Response.Status.Failure;
                return objResponse;
            }
        }

        public Response SignTextwithAuthXML(string Aadhaarnum, string UniqueTransactionId, string TextToBeSigned, string AuthXml, string TimeStamp)
        {
            objResponse = new Response();
            try
            {
                if (!IsvalidateAadarNumber(Aadhaarnum, ref objResponse))
                {
                    return objResponse;
                }
                if (!IsValidTransactionID(UniqueTransactionId, ref objResponse))
                {
                    return objResponse;
                }
                if (string.IsNullOrWhiteSpace(eSignSettings.ASPID))
                {
                    objResponse.ErrorMessage = "Invalid ASPID";
                    objResponse.ResponseStatus = Response.Status.Failure;
                    return objResponse;
                }
                if (string.IsNullOrWhiteSpace(eSignSettings.EsignURL))
                {
                    objResponse.ErrorMessage = "Invalid eSign URL";
                    objResponse.ResponseStatus = Response.Status.Failure;
                    return objResponse;
                }
                if (string.IsNullOrWhiteSpace(eSignSettings.PfxPassword))
                {
                    objResponse.ErrorMessage = "Invalid PFX password";
                    objResponse.ResponseStatus = Response.Status.Failure;
                    return objResponse;
                }
                if (string.IsNullOrWhiteSpace(eSignSettings.PfxPath))
                {
                    objResponse.ErrorMessage = "Invalid PFX path";
                    objResponse.ResponseStatus = Response.Status.Failure;
                    return objResponse;
                }
                else if (File.Exists(eSignSettings.PfxPath))
                {
                    try
                    {
                        X509Certificate2 Cert = new X509Certificate2();
                        Cert = new X509Certificate2(eSignSettings.PfxPath, eSignSettings.PfxPassword, X509KeyStorageFlags.Exportable);
                    }
                    catch (Exception ex)
                    {
                        objResponse.ErrorMessage = "Invalid PFX path" + ex.Message;
                        objResponse.ResponseStatus = Response.Status.Failure;
                        return objResponse;
                    }
                }
                else
                {
                    objResponse.ErrorMessage = "Pfx file not present in PFX path:" + eSignSettings.PfxPath;
                    objResponse.ResponseStatus = Response.Status.Failure;
                    return objResponse;
                }
                if (string.IsNullOrWhiteSpace(eSignSettings.UIDAICertificatePath))
                {
                    objResponse.ErrorMessage = "UIDAI Certificate Path";
                    objResponse.ResponseStatus = Response.Status.Failure;
                    return objResponse;
                }
                else if (File.Exists(eSignSettings.UIDAICertificatePath))
                {
                    try
                    {
                        File.ReadAllText(eSignSettings.UIDAICertificatePath);
                    }
                    catch (Exception ex)
                    {
                        objResponse.ErrorMessage = "UIDAI Certificate Path" + ex.Message;
                        objResponse.ResponseStatus = Response.Status.Failure;
                        return objResponse;
                    }
                }
                else
                {
                    objResponse.ErrorMessage = "UIDAI Certificate Path file not present in Path:" + eSignSettings.UIDAICertificatePath;
                    objResponse.ResponseStatus = Response.Status.Failure;
                    return objResponse;
                }
                if (!string.IsNullOrWhiteSpace(TextToBeSigned))
                {
                    try
                    {
                        byte[] sdoc = eSignText(TextToBeSigned, "", Aadhaarnum, UniqueTransactionId, new AuthMetaDetails(), new SignatureAppearance(), ref objResponse, AuthXml, TimeStamp, "");
                        if (objResponse.ResponseStatus == Response.Status.Success)
                        {
                            objResponse.ResponseStatus = Response.Status.Success;
                            return objResponse;
                        }
                        else
                        {
                            objResponse.ResponseStatus = Response.Status.Failure;
                            return objResponse;
                        }
                    }
                    catch (Exception ex)
                    {
                        objResponse.ErrorMessage = ex.Message;
                        objResponse.ResponseStatus = Response.Status.Failure;
                        return objResponse;
                    }
                }
                else
                {
                    objResponse.ErrorMessage = "Text to be signed is empty" + eSignSettings.UIDAICertificatePath;
                    objResponse.ResponseStatus = Response.Status.Failure;
                    return objResponse;
                }
            }
            catch (Exception ex)
            {
                objResponse.ErrorMessage = ex.Message;
                objResponse.ResponseStatus = Response.Status.Failure;
                return objResponse;
            }
        }

        public Response SignTextwithPreKYC(string Aadhaarnum, string UniqueTransactionId, string TextToBeSigned, string EkycXml)
        {
            objResponse = new Response();
            try
            {
                if (!IsvalidateAadarNumber(Aadhaarnum, ref objResponse))
                {
                    return objResponse;
                }
                if (!IsValidTransactionID(UniqueTransactionId, ref objResponse))
                {
                    return objResponse;
                }
                if (string.IsNullOrWhiteSpace(eSignSettings.ASPID))
                {
                    objResponse.ErrorMessage = "Invalid ASPID";
                    objResponse.ResponseStatus = Response.Status.Failure;
                    return objResponse;
                }
                if (string.IsNullOrWhiteSpace(eSignSettings.EsignURL))
                {
                    objResponse.ErrorMessage = "Invalid eAuth url";
                    objResponse.ResponseStatus = Response.Status.Failure;
                    return objResponse;
                }
                if (string.IsNullOrWhiteSpace(eSignSettings.PfxPassword))
                {
                    objResponse.ErrorMessage = "Invalid PFX password";
                    objResponse.ResponseStatus = Response.Status.Failure;
                    return objResponse;
                }
                if (string.IsNullOrWhiteSpace(eSignSettings.PfxPath))
                {
                    objResponse.ErrorMessage = "Invalid PFX path";
                    objResponse.ResponseStatus = Response.Status.Failure;
                    return objResponse;
                }
                else if (File.Exists(eSignSettings.PfxPath))
                {
                    try
                    {
                        X509Certificate2 Cert = new X509Certificate2();
                        Cert = new X509Certificate2(eSignSettings.PfxPath, eSignSettings.PfxPassword, X509KeyStorageFlags.Exportable);
                    }
                    catch (Exception ex)
                    {
                        objResponse.ErrorMessage = "Invalid PFX path" + ex.Message;
                        objResponse.ResponseStatus = Response.Status.Failure;
                        return objResponse;
                    }
                }
                else
                {
                    objResponse.ErrorMessage = "Pfx file not present in PFX path:" + eSignSettings.PfxPath;
                    objResponse.ResponseStatus = Response.Status.Failure;
                    return objResponse;
                }
                if (string.IsNullOrWhiteSpace(eSignSettings.UIDAICertificatePath))
                {
                    objResponse.ErrorMessage = "UIDAI Certificate Path";
                    objResponse.ResponseStatus = Response.Status.Failure;
                    return objResponse;
                }
                else if (File.Exists(eSignSettings.UIDAICertificatePath))
                {
                    try
                    {
                        File.ReadAllText(eSignSettings.UIDAICertificatePath);
                    }
                    catch (Exception ex)
                    {
                        objResponse.ErrorMessage = "UIDAI Certificate Path" + ex.Message;
                        objResponse.ResponseStatus = Response.Status.Failure;
                        return objResponse;
                    }
                }
                else
                {
                    objResponse.ErrorMessage = "UIDAI Certificate Path file not present in Path:" + eSignSettings.UIDAICertificatePath;
                    objResponse.ResponseStatus = Response.Status.Failure;
                    return objResponse;
                }
                if (!string.IsNullOrWhiteSpace(TextToBeSigned))
                {
                    try
                    {
                        byte[] sdoc = eSignText(TextToBeSigned, "", Aadhaarnum, UniqueTransactionId, new AuthMetaDetails(), new SignatureAppearance(), ref objResponse, "", "", EkycXml);
                        if (objResponse.ResponseStatus == Response.Status.Success)
                        {
                            objResponse.ResponseStatus = Response.Status.Success;
                            return objResponse;
                        }
                        else
                        {
                            objResponse.ResponseStatus = Response.Status.Failure;
                            return objResponse;
                        }
                    }
                    catch (Exception ex)
                    {
                        objResponse.ErrorMessage = ex.Message;
                        objResponse.ResponseStatus = Response.Status.Failure;
                        return objResponse;
                    }
                }
                else
                {
                    objResponse.ErrorMessage = "Text to be signed is empty" + eSignSettings.UIDAICertificatePath;
                    objResponse.ResponseStatus = Response.Status.Failure;
                    return objResponse;
                }
            }
            catch (Exception ex)
            {
                objResponse.ErrorMessage = ex.Message;
                objResponse.ResponseStatus = Response.Status.Failure;
                return objResponse;
            }
        }

        private byte[] eSignText(string TextToBeSigned, string AuthenticationValue, string AadarNumber, string TransactionID, AuthMetaDetails MetaDetails, SignatureAppearance userAppearance, ref Response objResponse, string AuthXml, string TimeStamp, string EkycXml)
        {
            StringBuilder straddhar = new StringBuilder();
            this.Timestamp = string.IsNullOrWhiteSpace(TimeStamp) ? DateTime.Now.AddMinutes(5).ToString("yyyy-MM-ddTHH:mm:ss") : TimeStamp;
            string hashdocument = null;
            hashdocument = Common.sha256_hash(TextToBeSigned);
            string AADHARXML = "";

            if (string.IsNullOrWhiteSpace(EkycXml))
            {
                if (string.IsNullOrWhiteSpace(AuthXml))
                {
                    AADHARXML = GetAadhaarXML(AuthenticationValue, AadarNumber, TransactionID, Timestamp, MetaDetails);
                }
                else
                {
                    AADHARXML = AuthXml;
                }
            }
            string RequestXML = GenerateXML(AADHARXML, AadarNumber, hashdocument, eSignSettings.ASPID, Timestamp, TransactionID, EkycXml);
            string ResponseXML = string.Empty;
            if (!string.IsNullOrEmpty(eSignSettings.EsignURL) && !string.IsNullOrEmpty(RequestXML))
            {
                if (!string.IsNullOrEmpty(eSignSettings.EsignURL))
                {
                    try
                    {
                        ResponseXML = Common.HttpsWebClientSendSMS(eSignSettings.EsignURL, HttpUtility.UrlEncode(RequestXML));
                        XmlDocument ResponseXMLdoc = new XmlDocument();
                        if (string.IsNullOrWhiteSpace(ResponseXML))
                        {
                            objResponse.ErrorMessage = "Null Response";
                            objResponse.ResponseStatus = Response.Status.Failure;
                            return null;
                        }
                        else
                        {
                            ResponseXMLdoc.LoadXml(ResponseXML.Trim());
                            XmlNode Esignresp = ResponseXMLdoc.SelectSingleNode("EsignResp");
                            if (Esignresp.Attributes["status"].Value.Trim() != "1")
                            {
                                objResponse.ErrorCode = Esignresp.Attributes["errCode"].Value.Trim();
                                objResponse.ErrorMessage = Esignresp.Attributes["errMsg"].Value.Trim();
                                objResponse.ResponseStatus = Response.Status.Failure;
                                return null;
                            }
                            else if (Esignresp.Attributes["status"].Value.Trim() == "1")
                            {
                                    XmlDocument ResponseXMLDoc = new XmlDocument();
                                    if (!string.IsNullOrEmpty(ResponseXML.ToString()))
                                    {
                                        ResponseXMLDoc.LoadXml(ResponseXML.ToString().Trim());
                                    }
                                    XmlNode Usercertificate = ResponseXMLDoc.SelectSingleNode("//UserX509Certificate");
                                    String userCertificate = string.Empty;

                                    if (Usercertificate != null)
                                        userCertificate = Usercertificate.InnerText;

                                    if (!string.IsNullOrEmpty(userCertificate))
                                    {
                                        X509Certificate2 certificate = new X509Certificate2();
                                        certificate.Import(Common.convertStringToByteArray(userCertificate));
                                        XmlNode Signedhash = ResponseXMLDoc.SelectSingleNode("//DocSignature");
                                        objResponse.SiginedText = Signedhash.InnerText;
                                    }
                                    objResponse.ResponseStatus = Response.Status.Success;
                                    return null;
                            }
                            else
                            {
                                objResponse.ErrorCode = Esignresp.Attributes["errCode"].Value.Trim();
                                objResponse.ErrorMessage = Esignresp.Attributes["errMsg"].Value.Trim();
                                objResponse.ResponseStatus = Response.Status.Failure;
                                return null;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                else
                {
                    objResponse.ErrorMessage = "Empty Esign url";
                    objResponse.ResponseStatus = Response.Status.Failure;
                    return null;
                }
            }
            else
            {
                objResponse.ErrorMessage = "Empty request xml";
                objResponse.ResponseStatus = Response.Status.Failure;
                return null;
            }
        }

        private bool IsvalidateAadarNumber(string AadarNumber, ref Response objResponse)
        {
            Regex regex;
            try
            {
                regex = new Regex("^[0-9]{12}$");
                if (!regex.IsMatch(AadarNumber))
                {
                    objResponse.ResponseStatus = Response.Status.Failure;
                    objResponse.ErrorMessage = "Invalid Aadar";
                }
                return regex.IsMatch(AadarNumber);
            }
            catch
            {
                objResponse.ResponseStatus = Response.Status.Failure;
                objResponse.ErrorMessage = "Invalid Aadar";
                return false;
            }
            finally
            {
                regex = null;
            }
        }

        private string SignXML(string XMLValue)
        {
            string SignedXML = string.Empty;
            X509Certificate2 Cert = new System.Security.Cryptography.X509Certificates.X509Certificate2();

            CryptoConfig.AddAlgorithm(typeof(Security.Cryptography.RSAPKCS1SHA256SignatureDescription), "http://www.w3.org/2001/04/xmldsig-more#rsa-sha256");
            Cert = new X509Certificate2(eSignSettings.PfxPath, eSignSettings.PfxPassword, X509KeyStorageFlags.Exportable);

            XmlDocument Document = new XmlDocument();
            Document.LoadXml(XMLValue);

            // Export private key from cert.PrivateKey and import into a PROV_RSA_AES provider:
            var exportedKeyMaterial = Cert.PrivateKey.ToXmlString( /* includePrivateParameters = */ true);
            var key = new RSACryptoServiceProvider();
            key.PersistKeyInCsp = false;
            key.FromXmlString(exportedKeyMaterial);

            SignedXml signedXml = new SignedXml(Document);
            signedXml.SigningKey = key;

            // Add a signing reference, the uri is empty and so the whole document
            // is signed.
            Reference reference = new Reference();
            reference.AddTransform(new XmlDsigEnvelopedSignatureTransform());
            reference.Uri = "";
            signedXml.AddReference(reference);

            // Add the certificate as key info, because of this the certificate
            // with the public key will be added in the signature part.
            KeyInfo keyInfo = new KeyInfo();
            keyInfo.AddClause(new KeyInfoX509Data(Cert));
            signedXml.KeyInfo = keyInfo;

            // Generate the signature.
            signedXml.ComputeSignature();

            // Get the XML representation of the signature and save
            // it to an XmlElement object.
            XmlElement xmlDigitalSignature = signedXml.GetXml();

            Document.DocumentElement.AppendChild(
            Document.ImportNode(xmlDigitalSignature, true));

            SignedXML = Document.OuterXml;
            return SignedXML;
        }

        private string GenrateRawXml(string ASPID, string AadarNumber, string TransactionID)
        {
            return "<?xml version =\"1.0\" encoding=\"UTF-8\" standalone=\"no\"?><OTP ver=\"1.0\" ts=\"" + DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss") + "\" txn=\"" + TransactionID + "\" aspId=\"" + ASPID + "\" uid=\"" + AadarNumber + "\"></OTP>";
        }

        private string GetCertExpiry()
        {
            string Certificate = eSignSettings.UIDAICertificatePath;
            X509Certificate cert = X509Certificate.CreateFromCertFile(Certificate);
            return (Convert.ToDateTime(cert.GetExpirationDateString())).ToString("yyyyMMdd");
        }

        private byte[] getNewSessionKey()
        {
            using (Rijndael myAes = RijndaelManaged.Create("Rijndael"))
            {
                myAes.KeySize = 256;
                myAes.GenerateKey();
                return myAes.Key;
            }
        }

        private string GetPIDXML(string AuthenticationValue, string TimeStamp)
        {
            StringBuilder pidxml = new StringBuilder();
            pidxml.Append("<Pid xmlns=\"http://www.uidai.gov.in/authentication/uid-auth-request-data/1.0\" ts=\"" + TimeStamp + "\" ver=\"1.0\">");
            switch (eSignSettings.AuthMode)
            {
                case AuthMode.OTP:
                    pidxml.Append("<Pv otp=\"" + AuthenticationValue + "\"/>");
                    break;
                case AuthMode.FP:
                    pidxml.Append("<Bios><Bio type=\"FMR\" posh=\"UNKNOWN\">" + AuthenticationValue + "</Bio></Bios>");
                    break;
                case AuthMode.IRIS:
                    pidxml.Append("<Bios><Bio type=\"IIR\" posh=\"UNKNOWN\">" + AuthenticationValue + "</Bio></Bios>");
                    break;
            }
            pidxml.Append("</Pid>");
            return pidxml.ToString();
        }

        private string encryptWithPublicKey(byte[] stringToEncrypt)
        {
            string UIDAICertData = ReadUIDAICertData();
            UIDAICertData = UIDAICertData.Replace("-----BEGIN CERTIFICATE-----", string.Empty).Replace("-----END CERTIFICATE-----", string.Empty);
            byte[] CertData = Convert.FromBase64String(UIDAICertData);
            X509Certificate2 certificate = new X509Certificate2(CertData);
            byte[] cipherbytes = Convert.FromBase64String(Convert.ToBase64String(stringToEncrypt));
            RSACryptoServiceProvider rsa = (RSACryptoServiceProvider)certificate.PublicKey.Key;
            byte[] cipher = rsa.Encrypt(cipherbytes, false);
            return Convert.ToBase64String(cipher);
        }

        private string ReadUIDAICertData()
        {
            if (File.Exists(eSignSettings.UIDAICertificatePath))
            {
                return File.ReadAllText(eSignSettings.UIDAICertificatePath);
            }
            return null;
        }

        private byte[] SignDocument(string Response)
        {
            string SignedXMLfile = string.Empty;
            XmlDocument ResponseXML = new XmlDocument();
            if (!string.IsNullOrEmpty(Response))
            {
                ResponseXML.LoadXml(Response.Trim());
            }
            XmlNode Usercertificate = ResponseXML.SelectSingleNode("//UserX509Certificate");
            String userCertificate = string.Empty;

            if (Usercertificate != null)
                userCertificate = Usercertificate.InnerText;

            if (!string.IsNullOrEmpty(userCertificate))
            {
                X509Certificate2 certificate = new X509Certificate2();
                certificate.Import(Common.convertStringToByteArray(userCertificate));
                XmlNode Signedhash = ResponseXML.SelectSingleNode("//DocSignature");
                String signedHash = Signedhash.InnerText;
                X509Certificate2 SignedPkcs7certificate = new X509Certificate2();
                SignedPkcs7certificate.Import(Org.BouncyCastle.Utilities.Encoders.Base64.Decode(signedHash));
                return Org.BouncyCastle.Utilities.Encoders.Base64.Decode(signedHash);
            }
            return null;
        }

        private bool IsValidAuthMetaDetails(AuthMetaDetails metaDetails, ref Response objResponse)
        {
            if ((!Regex.Match(metaDetails.udc, "^[a-zA-Z0-9:]{1,20}$").Success))
            {
                objResponse.ErrorMessage = "Invalid udc value please set it as an alphanumeric value";
                objResponse.ResponseStatus = Response.Status.Failure;
                return false;
            }
            if (string.IsNullOrWhiteSpace(metaDetails.fdc))
            {
                objResponse.ErrorMessage = "Invalid fdc value please set it as NC for Biometric or NA for non - Biometric";
                objResponse.ResponseStatus = Response.Status.Failure;
                return false;
            }
            if (string.IsNullOrWhiteSpace(metaDetails.idc))
            {
                objResponse.ErrorMessage = "Invalid Auth-Meta-Detail idc value";
                objResponse.ResponseStatus = Response.Status.Failure;
                return false;
            }
            if (string.IsNullOrWhiteSpace(metaDetails.lot))
            {
                objResponse.ErrorMessage = "Invalid Auth-Meta-Detail lot value";
                objResponse.ResponseStatus = Response.Status.Failure;
                return false;
            }
            else if (metaDetails.lot != "P" && metaDetails.lot != "G")
            {
                objResponse.ErrorMessage = "Invalid Auth-Meta-Detail lot value";
                objResponse.ResponseStatus = Response.Status.Failure;
                return false;
            }
            if (string.IsNullOrWhiteSpace(metaDetails.lov))
            {
                objResponse.ErrorMessage = "Invalid Auth-Meta-Detail lov value";
                objResponse.ResponseStatus = Response.Status.Failure;
                return false;
            }
            else if (metaDetails.lot == "P" && (!Regex.Match(metaDetails.lov, "^[1-9][0-9]{5}$").Success))
            {
                objResponse.ErrorMessage = "Invalid lov value please set it to a 6 digit pincode number if lot value is P or to a geo-code value if lot value is G";
                objResponse.ResponseStatus = Response.Status.Failure;
                return false;
            }
            else if (metaDetails.lot == "G" && (!Regex.Match(metaDetails.lov, "^[0-9]{10}\\.{1}[0-9]{4}[,]{1}[0-9]{10}\\.{1}[0-9]{4}[,]{1}[0-9]{4}\\.{1}[0-9]{2}$").Success))
            {
                objResponse.ErrorMessage = "Invalid lov value please set it to a 6 digit pincode number if lot value is P or to a geo-code value if lot value is G";
                objResponse.ResponseStatus = Response.Status.Failure;
                return false;
            }
            return true;
        }

        private bool IsValidTransactionID(string transactionID, ref Response objresp)
        {
            if (string.IsNullOrWhiteSpace(transactionID))
            {
                objresp.ErrorMessage = "Invalid Unique Transaction Id";
                objresp.ResponseStatus = Response.Status.Failure;
                return false;
            }
            if (transactionID.Length > 50)
            {
                objresp.ErrorMessage = "Invalid Transaction ID";
                objresp.ResponseStatus = Response.Status.Failure;
                return false;
            }
            return true;
        }

        private string GetAadhaarXML(string AuthenticationValue, string AADHAARNUMBER, string TransactionID, string TimeStamp, AuthMetaDetails MetaDetails)
        {
            string PIDXML = GetPIDXML(AuthenticationValue, TimeStamp);
            StringBuilder aadhaar = new StringBuilder();
            byte[] SessionKey = getNewSessionKey();
            string Base64UIDAIPublicKeyEncryption = encryptWithPublicKey(SessionKey);
            string BASE64SessionKeyAesEncrytionPkcs7Ecb = Convert.ToBase64String(Encryption.EncryptDataAES(Common.convertStringToByteArray(PIDXML), SessionKey));
            string Base64SessionKeyAesEncrytionPkcs7EcbSHA256Hash = Convert.ToBase64String(Encryption.EncryptDataAES(Common.Generatehash256(PIDXML), SessionKey));
            string UIDAICerEXpairyDate = GetCertExpiry();

            aadhaar.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            aadhaar.Append("<Auth xmlns=\"http://www.uidai.gov.in/authentication/uid-auth-request/1.0\" uid=\"" + AADHAARNUMBER + "\" tid=\"public\" ac=\"\" sa=\"\" ver=\"1.6\" txn=\"" + TransactionID + "\" lk=\"\">");
            aadhaar.Append("<Meta fdc=\"" + MetaDetails.fdc + "\" idc=\"" + MetaDetails.idc + "\" lot=\"" + MetaDetails.lot + "\" lov=\"" + MetaDetails.lov + "\" pip=\"" + MetaDetails.pip + "\" udc=\"" + MetaDetails.udc + "\"/>");
            aadhaar.Append("<Skey ci=\"" + UIDAICerEXpairyDate + "\">" + Base64UIDAIPublicKeyEncryption + "</Skey>");
            aadhaar.Append("<Data type=\"X\">" + BASE64SessionKeyAesEncrytionPkcs7Ecb + "</Data>");
            aadhaar.Append("<Hmac>" + Base64SessionKeyAesEncrytionPkcs7EcbSHA256Hash + "</Hmac>");
            aadhaar.Append("</Auth>");
            return aadhaar.ToString();
        }

        private string GenerateXML(string AADHARXML, string AadhaarNumber, string hashdocument, string ASPID, string TimeStamp, string TransactionID, string KYCResXML)
        {
            StringBuilder straddhar = new StringBuilder();
            string BASE64AadhaarXML = Convert.ToBase64String(Common.convertStringToByteArray(AADHARXML));
            string preverified = "";
            if (KYCResXML == "" || KYCResXML == string.Empty)
                preverified = "n";
            else
                preverified = "y";
            straddhar.Append("<Esign ver=\"1.6\" sc=\"Y\" uid=\"" + AadhaarNumber + "\" aspId=\"" + ASPID + "\" AuthMode=\"" + ((int)eSignSettings.AuthMode).ToString() + "\" responseSigType=\"pkcs7\" preVerified=\"" + preverified + "\"  ts=\"" + TimeStamp + "\" txn=\"" + TransactionID + "\"><Docs>");
            straddhar.Append("<InputHash id=\"1\" hashAlgorithm=\"SHA256\">" + hashdocument + "</InputHash>");
            if (KYCResXML == "")
                straddhar.Append("</Docs><AuthHash>" + Common.sha256_hash(BASE64AadhaarXML) + "</AuthHash>");
            else
                straddhar.Append("</Docs><KycRes>" + KYCResXML + "</KycRes>");
            straddhar.Append("</Esign>");
            string Request = SignXML(straddhar.ToString());
            string baseesign = Convert.ToBase64String(Common.convertStringToByteArray(Request.ToString()));
            return "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"no\"?><Request><EsignXml>" + baseesign + "</EsignXml><Aadhaar>" + BASE64AadhaarXML + "</Aadhaar></Request>";
        }
    }

    internal class Common
    {
        #region HttpsWebClientSendSMS
        /// <summary>
        ///
        /// </summary>
        /// <param name="URI"></param>
        /// <param name="queryString"></param>
        /// <returns></returns>
        public static string HttpsWebClientSendSMS(string URI, string queryString)
        {
            string result = string.Empty;
            WebClient webclient = null;
            try
            {
                webclient = new WebClient();
                webclient.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                result = webclient.UploadString(URI, queryString);
                return (result);
            }
            catch (WebException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                webclient = null;
            }
        }
        #endregion

        #region File To Bytes
        /// <summary>
        /// Converts the file to bynary stream
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static Byte[] FileToBytes(String filePath)
        {
            byte[] buffer;
            FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            try
            {
                int length = (int)fileStream.Length;
                buffer = new byte[length];
                int count;
                int sum = 0;
                while ((count = fileStream.Read(buffer, sum, length - sum)) > 0)
                    sum += count;
            }
            finally
            {
                fileStream.Close();
            }
            return buffer;
        }
        #endregion

        #region Sha256_hash
        public static string sha256_hash(string value)
        {
            StringBuilder Sb = new StringBuilder();

            using (SHA256 hash = SHA256Managed.Create())
            {
                Byte[] result = hash.ComputeHash(Encoding.UTF8.GetBytes(value));

                foreach (Byte b in result)
                    Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();
        }
        #endregion

        #region Generatehash256
        /// <summary>
        /// Generate Hash value from given string value
        /// </summary>
        /// <param name="text"></param>
        /// <returns>A managed SHA 256 hash value</returns>
        public static byte[] Generatehash256(string text)
        {
            byte[] message = Encoding.UTF8.GetBytes(text);

            UnicodeEncoding UE = new UnicodeEncoding();
            byte[] hashValue;
            SHA256Managed hashString = new SHA256Managed();
            hashValue = hashString.ComputeHash(message);
            return hashValue;
        }
        #endregion

        public static byte[] convertStringToByteArray(string str)
        {
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            return encoding.GetBytes(str);
        }
    }

    internal static class Encryption
    {
        public static byte[] EncryptDataAES(byte[] toEncrypt, byte[] key)
        {
            IBufferedCipher cipher = CipherUtilities.GetCipher("AES/ECB/PKCS7");

            //byte[] encryptedData;
            byte[] iv = { (byte) 0x00, (byte) 0x00, (byte) 0x00, (byte) 0x00,
                                                        (byte) 0x00, (byte) 0x00, (byte) 0x00, (byte) 0x00,
                                                        (byte) 0x00, (byte) 0x00, (byte) 0x00, (byte) 0x00,
                                                        (byte) 0x00, (byte) 0x00, (byte) 0x00, (byte) 0x00 };

            cipher.Init(true, new KeyParameter(key));

            int outputSize = cipher.GetOutputSize(toEncrypt.Length);

            byte[] tempOP = new byte[outputSize];
            int processLen = cipher.ProcessBytes(toEncrypt, 0, toEncrypt.Length, tempOP, 0);
            int outputLen = cipher.DoFinal(tempOP, processLen);

            byte[] result = new byte[processLen + outputLen];
            System.Array.Copy(tempOP, 0, result, 0, result.Length);
            return result;
        }
    }

    public class Response
    {
        public enum Status { Success, Failure }
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public Status ResponseStatus { get; set; }
        public string SiginedText { get; set; }
    }

    public class eSignSettings
    {
        public static string ASPID { get; set; }
        public static string PfxPath { get; set; }
        public static string PfxPassword { get; set; }
        public static string OTPURL { get; set; }
        public static string UIDAICertificatePath { get; set; }
        public static string EsignURL { get; set; }
        public static AuthMode AuthMode { get; set; }
    }
    
    public class AuthMetaDetails
    {
        /*
         * @param fdc
            (mandatory) Fingerprint device code. This is a unique code provided for
            the fingerprint sensor-extractor combination. AUAs will have access to this code
            through UIDAI portal. This is an alpha-numeric string of maximum length 10.
            o While using fingerprint authentication, this code is mandatory and should
            be provided. If the code is unknown or device is not certified yet, use “NC”.
            o For non fingerprint authentication (when not using “bio” type “FMR” or
            “FIR”), use the value “NA”
         * @param idc
            (mandatory) Iris device code. This is a unique code provided for the iris
            sensor-extractor combination. AUAs will have access to this code through UIDAI
            portal. This is an alpha-numeric string of maximum length 10.
            o While using iris authentication, this code is mandatory and should be
            provided. If the code is unknown or device is not certified yet, use “NC”.
            o For non iris authentication, use the value “NA”
         * @param lot
            (mandatory) Location type. Valid values are “G” and “P”.
            o G – stands for geo coding in lat, long format
            o P – stands for postal pin code
         * @param lov
            (mandatory) Location Value.
            o If “lot” value is “G” then, this “lov” attribute must carry actual “lat,long,alt”
            of the location. Can be derived using GPS or using alternate method.
            Lat/Long should be in positive or negative decimal format (ISO 6709).
            Altitude is optional and may be populated if available.
            o If “lot” value is “P” then, this “lov” attribute must have a valid 6-digit
            postal pin code.
         * @param pip
            (mandatory) Public IP address of the device. If the device is connected to
            Internet and has a public IP, then this must be populated with that IP address. If
            the device has a private IP and is behind a router/proxy/etc, then public IP
            address of the router/proxy/etc should be set. If no public IP is available, leave it
            as “NA”.
         * @param udc
            (mandatory) Unique Device Code. This is a unique code for the
            authentication device assigned within the AUA domain. This is an alpha-numeric
            string of maximum length 20.
            o This allows better reporting and tracking of devices as well as help
            resolve issues at the device level.
            o It is highly recommended that AUAs define a unique codification scheme
            for all their devices.
            o Suggested format is “[vendorcode][date of deployment][serial number]”
         */
        public string fdc;
        public string idc;
        public string lot;
        public string lov;
        public string pip;
        public string udc;
    }

    public class SignatureAppearance
    {
        public string SignedBy { get; set; }
        public string Location { get; set; }
        public string Reason { get; set; }
        public int pageNumber { get; set; }
    }

    public enum AuthMode { OTP = 1, FP = 2, IRIS = 3 }
}


