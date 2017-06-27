using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Risersoft.API.GSTN
{
    public class GSTNConstants
    {
        public static byte[] appKey = null;
        public static string base_url = "http://devapi.gstsystem.co.in";
        public static string base_path = ".";
        public static string client_id = "";
        public static string client_secret = "";
        public static string publicip = "";

        public static byte[] GetAppKeyBytes()
        {
            if (appKey == null)
            {
                appKey = EncryptionUtils.CreateAesKeyBC();
            }
            return appKey;

        }
        public static string GetAppKeyEncoded()
        {
            if (appKey == null)
            {
                appKey = EncryptionUtils.CreateAesKeyBC();
            }
            return Convert.ToBase64String(appKey);

        }

    }
}