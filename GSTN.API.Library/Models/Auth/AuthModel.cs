using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Risersoft.API.GSTN.Auth
{
    public class OTPRequestModel
    {
        public string action { get; set; }
        public string app_key { get; set; }
        public string username { get; set; }
    }
    public class TokenRequestModel:OTPRequestModel
    {
        public string otp { get; set; }
    }

    public class OTPResponseModel
    {
        public string status_cd { get; set; }
    }
    public class TokenResponseModel : OTPResponseModel
    {
        public string auth_token { get; set; }
        public int expiry { get; set; }
        public string sek { get; set; }
    }
    public class RefreshTokenModel : OTPRequestModel
    {
        public string auth_token { get; set; }
    }
}
