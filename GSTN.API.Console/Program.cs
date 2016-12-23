using GSTN.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSTN.API.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            string gstin = "05BDIPA7164F1ZT";
            string fp = "072016";
            System.Console.WriteLine("Press any key to start GSTR1");
            System.Console.ReadKey(false);
            TestGSTR1(gstin, fp);

            System.Console.WriteLine("Press any key to start GSTR2");
            System.Console.ReadKey(false);
            TestGSTR2(gstin, fp);

            System.Console.WriteLine("Press any key to start GSTR3");
            System.Console.ReadKey(false);
            TestGSTR3(gstin, fp);
            
            System.Console.WriteLine("Press any key to start Ledger");
            System.Console.ReadKey(false);
            TestLedger(gstin, "19-08-2016", "20-09-2016");

            System.Console.WriteLine("Press any key to end this program");
            System.Console.ReadKey(false);
        }
        private static void TestGSTR1(string gstin,string fp)
        {
            GSTNAuthClient client = new GSTNAuthClient();
            var result = client.RequestOTP(GSTNConstants.testUser);
            var result2 = client.RequestToken(GSTNConstants.testUser, GSTNConstants.otp);

            GSTR1.GSTR1Total model = new GSTR1.GSTR1Total();
            GSTR1ApiClient client2 = new GSTR1ApiClient(client);
            model.b2b = client2.GetB2B(gstin, fp, "Y").Data;
            model.b2cl = client2.GetB2CL(gstin, fp, "01").Data;
            var result3 = client2.Save(model);

            var model2 = client2.GetSummary(gstin, fp).Data;
            var result4 = client2.File(model2, "xx", "DSC", "kjdkjdkdkdkdkd");
        }
        private static void TestGSTR2(string gstin, string fp)
        {
            GSTNAuthClient client = new GSTNAuthClient();
            var result = client.RequestOTP(GSTNConstants.testUser);
            var result2 = client.RequestToken(GSTNConstants.testUser, GSTNConstants.otp);

            GSTR2.GSTR2Total model = new GSTR2.GSTR2Total();
            GSTR2ApiClient client2 = new GSTR2ApiClient(client);
            model.b2b = client2.GetB2B(gstin, fp, "Y").Data;
            model.imp_g = client2.GetImpG(gstin, fp).Data;
            var result3 = client2.Save(model);

            var model2 = client2.GetSummary(gstin, fp).Data;
            var result4 = client2.File(model2, "xx", "DSC", "kjdkjdkdkdkdkd");
        }
        private static void TestGSTR3(string gstin, string fp)
        {
            GSTNAuthClient client = new GSTNAuthClient();
            var result = client.RequestOTP(GSTNConstants.testUser);
            var result2 = client.RequestToken(GSTNConstants.testUser, GSTNConstants.otp);

            GSTR3.GSTR3Total model = new GSTR3.GSTR3Total();
            GSTR3ApiClient client2 = new GSTR3ApiClient(client);
            var info = client2.Generate(gstin, fp).Data;
            model = client2.GetDetails(gstin, fp).Data;
            GSTR3.GSTR3SaveModel model2 = new GSTR3.GSTR3SaveModel();
            model2.rf_clm = model.rf_clm;
            var result3 = client2.Save(model2);
            var result4 = client2.File(model, "xx", "DSC", "kjdkjdkdkdkdkd");
        }
        private static void TestLedger(string gstin, string fr_dt,string to_dt)
        {
            GSTNAuthClient client = new GSTNAuthClient();
            var result = client.RequestOTP(GSTNConstants.testUser);
            var result2 = client.RequestToken(GSTNConstants.testUser, GSTNConstants.otp);

            LedgerApiClient client2 = new LedgerApiClient(client);
            var info = client2.GetCashDtl(gstin, fr_dt,to_dt).Data;
        }
    }
}
