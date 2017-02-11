using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GSTN.API
{
    public class DSCUtils
    {
        public static X509Certificate2 getCertificate(string subject)
        {
            // Access Personal (MY) certificate store of current user

            X509Store my = new X509Store(StoreName.My, StoreLocation.CurrentUser);

            my.Open(OpenFlags.ReadOnly);

            // Find the certificate we’ll use to sign

            X509Certificate2 cert2 = null;

            foreach (X509Certificate2 cert in my.Certificates)

            {

                if (cert.Subject.Contains(subject))

                {

                    // We found it.

                    // Get its associated CSP and private key

                    cert2 = cert;

                }

            }
            return cert2;
        }
        public static X509Certificate2 getCertificate()
        {
            //Prompt the user with the list of certificates on the local store.
            //The user have to select the certificate he wants to use for signing.
            //Note: All certificates form the USB device are automatically copied to the local store as soon the device is plugged in.
            X509Store store = new X509Store(StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadOnly);
            X509CertificateCollection certificates = X509Certificate2UI.SelectFromCollection(store.Certificates,
                                                                                            "Select Certificate",
                                                                                            "Select Certificate for encrypting return",
                                                                                            X509SelectionFlag.SingleSelection
                                                                                            );
            store.Close();
            X509Certificate2 certificate = null;
            if (certificates.Count != 0)
            {
                //The selected certificate
                certificate = (X509Certificate2)certificates[0];
            }
            return certificate;
        }
        public static byte[] Sign(string text, X509Certificate2 cert)

        {

            // Access Personal (MY) certificate store of current user

            X509Store my = new X509Store(StoreName.My, StoreLocation.CurrentUser);

            my.Open(OpenFlags.ReadOnly);

            // Find the certificate we’ll use to sign

            RSACryptoServiceProvider csp = (RSACryptoServiceProvider)cert.PrivateKey;

          
            if (csp == null)

            {

                throw new Exception("No valid cert was found");

            }

            // Hash the data

            SHA1Managed sha1 = new SHA1Managed();

            UnicodeEncoding encoding = new UnicodeEncoding();

            byte[] data = encoding.GetBytes(text);

            byte[] hash = sha1.ComputeHash(data);

            // Sign the hash

            return csp.SignHash(hash, CryptoConfig.MapNameToOID("SHA1"));

        }

     public   static bool Verify(string text, byte[] signature, string certPath)

        {

            // Load the certificate we’ll use to verify the signature from a file

            X509Certificate2 cert = new X509Certificate2(certPath);

            // Note:

            // If we want to use the client cert in an ASP.NET app, we may use something like this instead:

            // X509Certificate2 cert = new X509Certificate2(Request.ClientCertificate.Certificate);

            // Get its associated CSP and public key

            RSACryptoServiceProvider csp = (RSACryptoServiceProvider)cert.PublicKey.Key;

            // Hash the data

            SHA1Managed sha1 = new SHA1Managed();

            UnicodeEncoding encoding = new UnicodeEncoding();

            byte[] data = encoding.GetBytes(text);

            byte[] hash = sha1.ComputeHash(data);

            // Verify the signature with the hash

            return csp.VerifyHash(hash, CryptoConfig.MapNameToOID("SHA1"), signature);

        }
    }
}
//http://www.a2zmenu.com/blogs/csharp/how-to-fetch-certificate-details-from-c-sharp-code.aspx
//http://stackoverflow.com/questions/15137816/how-to-get-information-from-a-security-token-with-c-sharp