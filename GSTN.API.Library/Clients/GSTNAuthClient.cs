using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Text;
using Risersoft.API.GSTN;
using Risersoft.API.GSTN.Auth;
namespace Risersoft.API.GSTN
{
	public class GSTNAuthClient : GSTNApiClientBase, IGSTNAuthProvider
	{

		TokenResponseModel token;
		public string AuthToken { get; set; }
		public byte[] DecryptedKey { get; set; }
		public string userid { get; set; }
		string IGSTNAuthProvider.Username {
			get { return userid; }
			set { userid = value; }
		}
		public GSTNAuthClient(string gstin, string userid) : base("/taxpayerapi/v0.2/authenticate",gstin)
		{
            this.userid = userid;
		}
		protected internal override void BuildHeaders(HttpClient client)
		{
			client.DefaultRequestHeaders.Add("clientid", GSTNConstants.client_id);
			client.DefaultRequestHeaders.Add("client-secret", GSTNConstants.client_secret);
			client.DefaultRequestHeaders.Add("ip-usr", GSTNConstants.publicip);
			client.DefaultRequestHeaders.Add("state-cd", this.gstin.Substring(0,2));
			client.DefaultRequestHeaders.Add("txn", "LAPN24235325555");

        }


		public GSTNResult<OTPResponseModel> RequestOTP()
		{
			OTPRequestModel model = new OTPRequestModel {
				action = "OTPREQUEST",
				username = userid,
                app_key = EncryptionUtils.RsaEncrypt(GSTNConstants.GetAppKeyBytes())
        };
			var output = this.Post<OTPRequestModel, OTPResponseModel>(model);
			return output;
		}
		public GSTNResult<TokenResponseModel> RequestToken(string otp)
		{
			TokenRequestModel model = new TokenRequestModel {
				action = "AUTHTOKEN",
				username = userid
			};
			model.app_key = EncryptionUtils.RsaEncrypt(GSTNConstants.GetAppKeyBytes());
            byte[] dataToEncrypt = UTF8Encoding.UTF8.GetBytes(otp);
            model.otp = EncryptionUtils.AesEncrypt(dataToEncrypt, GSTNConstants.GetAppKeyBytes());
			var output = this.Post<TokenRequestModel, TokenResponseModel>(model);

			this.userid = userid;
			token = output.Data;
			this.AuthToken = token.auth_token;
			this.DecryptedKey = EncryptionUtils.AesDecrypt(token.sek, GSTNConstants.GetAppKeyBytes());
			var Decipher = System.Text.Encoding.UTF8.GetString(DecryptedKey);

			return output;

		}

        public GSTNResult<TokenResponseModel> RefreshToken()
        {
            RefreshTokenModel model = new RefreshTokenModel
            {
                action = "REFRESHTOKEN",
                username = userid
            };
            model.app_key = EncryptionUtils.AesEncrypt(GSTNConstants.GetAppKeyBytes(), this.DecryptedKey);
            model.auth_token = this.AuthToken;
            var output = this.Post<RefreshTokenModel, TokenResponseModel>(model);

            token = output.Data;
            this.AuthToken = token.auth_token;
            this.DecryptedKey = EncryptionUtils.AesDecrypt(token.sek, GSTNConstants.GetAppKeyBytes());
            var Decipher = System.Text.Encoding.UTF8.GetString(DecryptedKey);

            return output;

        }

    }
}
namespace Risersoft.API.GSTN
{
	public interface IGSTNAuthProvider
	{
		string Username { get; set; }
		string AuthToken { get; set; }
		byte[] DecryptedKey { get; set; }
	}
}
