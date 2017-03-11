using eSignASPLib;
using eSignASPLib.DTO;
using GSTN.API;
using Microsoft.VisualBasic;
using Org.BouncyCastle.Bcpg.OpenPgp.Examples;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GSTN.API.Console
{
    class Program
    {
        static eSign eSignObj;
        static void Main(string[] args)
        {
            string gstin = "", fp = "",filename="";

            if ((args != null) && (System.IO.File.Exists(args[0])))
            {
                filename = args[0];
            } else
            {
                System.Console.Write("Enter input filename [Press Enter for None]:");
                filename = System.Console.ReadLine();
            }


            if (!String.IsNullOrEmpty(filename) && (System.IO.File.Exists(filename)))
            {
                var fileContents = File.ReadAllText(filename);
                string[] arr = Strings.Split(fileContents,Constants.vbCrLf);
                GSTNConstants.client_id = arr[0];
                GSTNConstants.client_secret = arr[1];
                GSTNConstants.userid = arr[2];
                gstin = arr[3];
                fp = arr[4];

            } else { 
            System.Console.Write("Enter ClientId:");
            GSTNConstants.client_id = System.Console.ReadLine();

            System.Console.Write("Enter Client Secret:");
            GSTNConstants.client_secret = System.Console.ReadLine();

            System.Console.Write("Enter UserID:");
            GSTNConstants.userid = System.Console.ReadLine();

            System.Console.Write("Enter GSTIN:");
            gstin = System.Console.ReadLine();

            System.Console.Write("Enter FP:");
            fp = System.Console.ReadLine();
            }

            try
            {
                GSTNConstants.publicip = new WebClient().DownloadString("http://ipinfo.io/ip").Trim();
            }
            catch
            {
                GSTNConstants.publicip = "11.10.1.1";
            }


            System.Console.WriteLine("1=GSTR1, 2=GSTR2, 3=GSTR3, 4=Ledger, 5=File with eSign, 6=CSV conversion, 7=PGP, 8=File With DSC");
            string selection = System.Console.ReadLine();

            switch (selection)
            {
                case "1":
                    TestGSTR1(gstin, fp);
                    break;
                case "2":
                    TestGSTR2(gstin, fp);
                    break;
                case "3":
                    TestGSTR3(gstin, fp);
                    break;
                case "4":
                    TestLedger(gstin, "19-08-2016", "20-09-2016");
                    break;
                case "5":
                    System.Console.Write("Enter path to license file:");
                    string path = System.Console.ReadLine();
                    System.Console.Write("Enter your Aadhar Num:");
                    string aadhaarnum = System.Console.ReadLine();
                    string transactionid = GetUIDAIOtp(path, aadhaarnum);
                    System.Console.Write("Enter OTP:");
                    string otp = System.Console.ReadLine();
                    FileGSTR1WithESign(gstin, fp, aadhaarnum, transactionid, otp);
                    break;
                case "6":
                    TestCSV(gstin, fp);
                    break;
                case "7":
                    TestPGP("the quick brown fox jumped over the lazy dog");
                    break;
                case "8":
                    System.Console.Write("Enter your PAN:");
                    string pan = System.Console.ReadLine();
                    FileGSTR1WithDSC(gstin, fp, pan);
                    break;
            }

            System.Console.WriteLine("Press any key to end this program");
            System.Console.ReadKey(false);
        }

        private static void TestPGP(string message)
        {
            string pwd = "mypassword";
            System.IO.Directory.CreateDirectory(@"D:\Keys");
            PGPSnippet.KeyGeneration.PGPKeyGenerator.GenerateKey("GSTNUser", pwd, @"D:\Keys\");
            System.Console.WriteLine("Keys Generated Successfully");

            String encoded = DetachedSignatureProcessor.CreateSignature(message, @"D:\Keys\PGPPrivateKey.asc", "signature.asc", pwd.ToCharArray(), true);
            System.Console.WriteLine("Obtained Signature = " + encoded);
            bool verified = DetachedSignatureProcessor.VerifySignature(message,  encoded, @"D:\Keys\PGPPublicKey.asc");
            if (verified)
            {
                System.Console.WriteLine("signature verified.");
            }
            else
            {
                System.Console.WriteLine("signature verification failed.");
            }


        }
        private static string GetUIDAIOtp(string path, string aadhaarnum)
        {
            eSignObj = new eSign(path);    //Get your own license file from e-Mudhra
            Settings.PfxPath = "resources\\Docsigntest.pfx";
            Settings.PfxPassword = "emudhra";
            Settings.UIDAICertificatePath = "resources\\uidai_auth_prod.cer";
            Settings.AuthMode = AuthMode.OTP;
            string guid = System.Guid.NewGuid().ToString();
            Response OTPResponse = eSignObj.GetOTP(aadhaarnum, guid);
            return guid;
        }
        private static void FileGSTR1WithESign(string gstin, string fp,string aadhaarnum, string transactionId, string Otp)
        {
            GSTNAuthClient client = GetAuth(gstin);
            GSTR1ApiClient client2 = new GSTR1ApiClient(client,gstin,fp);
            var model2 = client2.GetSummary( fp).Data;
            
            //https://groups.google.com/forum/#!searchin/gst-suvidha-provider-gsp-discussion-group/authorized|sort:relevance/gst-suvidha-provider-gsp-discussion-group/9-_Mk7LatDs/eQ6_1kHTBAAJ
            //https://groups.google.com/forum/#!searchin/gst-suvidha-provider-gsp-discussion-group/authorized|sort:relevance/gst-suvidha-provider-gsp-discussion-group/acd-F7XPYz4/7z83KM4IBgAJ

            var json2 = Convert.ToBase64String(Encoding.UTF8.GetBytes(client2.LastJson));
            var json3 = EncryptionUtils.sha256_hash(json2);

            AuthMetaDetails MetaDetails = new AuthMetaDetails();
            MetaDetails.fdc = "NA";
            MetaDetails.udc = "NA";//Unique device code. 
            MetaDetails.pip = "NA";
            MetaDetails.lot = "P";
            MetaDetails.lov = "560103";
            MetaDetails.idc = "NA";

            var json4 = eSignObj.SignText(aadhaarnum, Otp, transactionId, json3, MetaDetails);
            var result4 = client2.File(model2, json4.SignedText, "Esign", aadhaarnum);

        }
        private static void FileGSTR1WithDSC(string gstin, string fp, string pan)
        {
            GSTNAuthClient client = GetAuth(gstin);
            GSTR1ApiClient client2 = new GSTR1ApiClient(client,gstin,fp);
            var model2 = client2.GetSummary( fp).Data;

            var json2 = Convert.ToBase64String(Encoding.UTF8.GetBytes(client2.LastJson));
            var json3 = EncryptionUtils.sha256_hash(json2);

            var cert = DSCUtils.getCertificate();

            var json4 =Encoding.Unicode.GetString(DSCUtils.Sign(  json3, cert));
            var result4 = client2.File(model2, json4, "DSC", pan);

        }

        private static GSTNAuthClient GetAuth(string gstin)
        {

            GSTNAuthClient client = new GSTNAuthClient(gstin);
            var result = client.RequestOTP(GSTNConstants.userid);

            System.Console.Write("Enter OTP:");
            string otp = System.Console.ReadLine();

            var result2 = client.RequestToken(GSTNConstants.userid, otp);
            return client;
        }

        private static void TestGSTR1(string gstin,string fp)
        {
            GSTNAuthClient client = GetAuth(gstin);

            GSTR1.GSTR1Total model = new GSTR1.GSTR1Total();
            GSTR1ApiClient client2 = new GSTR1ApiClient(client,gstin,fp);
            model.b2b = client2.GetB2B( "").Data;
            model.b2cl = client2.GetB2CL(  "01").Data;
            var result3 = client2.Save(model);

        }
        private static void TestGSTR2(string gstin, string fp)
        {
            GSTNAuthClient client = GetAuth(gstin);
            GSTR2.GSTR2Total model = new GSTR2.GSTR2Total();
            GSTR2ApiClient client2 = new GSTR2ApiClient(client,gstin,fp);
            model.b2b = client2.GetB2B( "Y").Data;
            model.imp_g = client2.GetImpG( fp).Data;
            var result3 = client2.Save(model);

            var model2 = client2.GetSummary( fp).Data;
        }
        private static void TestGSTR3(string gstin, string fp)
        {
            GSTNAuthClient client = GetAuth(gstin);
            GSTR3.GSTR3Total model = new GSTR3.GSTR3Total();
            GSTR3ApiClient client2 = new GSTR3ApiClient(client,gstin,fp);
            var info = client2.Generate( fp).Data;
            model = client2.GetDetails( fp).Data;
            GSTR3.GSTR3SaveModel model2 = new GSTR3.GSTR3SaveModel();
            model2.rf_clm = model.rf_clm;
            var result3 = client2.Save(model2);
        }
        private static void TestLedger(string gstin, string fr_dt,string to_dt)
        {
            GSTNAuthClient client = GetAuth(gstin);
            LedgerApiClient client2 = new LedgerApiClient(client,gstin);
            var info = client2.GetCashDtl(gstin, fr_dt,to_dt).Data;
        }
        private static string TestCSV(string gstin, string fp)
        {
            GSTNAuthClient client = GetAuth(gstin);
            GSTR1.GSTR1Total model = new GSTR1.GSTR1Total();
            GSTR1ApiClient client2 = new GSTR1ApiClient(client,gstin,fp);
            model.b2b = client2.GetB2B( "Y").Data;

            var client3 = new MxApiClient("http://www.maximprise.com/api/gst");
            string str1 = client3.Json2CSV(client2.LastJson, "gstr1", "b2b").Data;
            return str1;
        }
    }
}
