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
using GSTN.API;
using GSTN.API.Auth;
namespace GSTN.API
{
	public class GSTNAuthClient : GSTNApiClientBase, IGSTNAuthProvider
	{

		TokenResponseModel token;
		public string AuthToken { get; set; }
		public byte[] DecryptedKey { get; set; }
		public string username { get; set; }
		string IGSTNAuthProvider.Username {
			get { return username; }
			set { username = value; }
		}
		public GSTNAuthClient() : base("/taxpayerapi/v0.1/authenticate")
		{
		}
		protected internal override void BuildHeaders(HttpClient client)
		{
			client.DefaultRequestHeaders.Add("clientid", GSTNConstants.client_id);
			client.DefaultRequestHeaders.Add("client-secret", GSTNConstants.client_secret);
			client.DefaultRequestHeaders.Add("ip-usr", "12.8.91.80");
			client.DefaultRequestHeaders.Add("state-cd", "11");
			client.DefaultRequestHeaders.Add("txn", "LAPN24235325555");
		}


		public GSTNResult<OTPResponseModel> RequestOTP(string username)
		{
			OTPRequestModel model = new OTPRequestModel {
				action = "OTPREQUEST",
				username = username
			};
			model.appkey = EncryptionUtils.EncryptTextWithPublicKey(GSTNConstants.appKey);
			var output = this.Post<OTPRequestModel, OTPResponseModel>(model);
			return output;
		}
		public GSTNResult<TokenResponseModel> RequestToken(string username, string otp)
		{
			TokenRequestModel model = new TokenRequestModel {
				action = "AUTHTOKEN",
				username = username
			};
			model.appkey = EncryptionUtils.EncryptTextWithPublicKey(GSTNConstants.appKey);
			model.otp = EncryptionUtils.Encrypt(otp, GSTNConstants.appKey);
			var output = this.Post<TokenRequestModel, TokenResponseModel>(model);

			this.username = username;
			token = output.Data;
			this.AuthToken = token.auth_token;
			var AppKeyBytes = Encoding.UTF8.GetBytes(GSTNConstants.appKey);
			this.DecryptedKey = EncryptionUtils.Decrypt(token.sek, AppKeyBytes);
			var Decipher = System.Text.Encoding.UTF8.GetString(DecryptedKey);

			return output;

		}

		//TODO: Auto extension of token.
	}
}
namespace GSTN.API
{
	public interface IGSTNAuthProvider
	{
		string Username { get; set; }
		string AuthToken { get; set; }
		byte[] DecryptedKey { get; set; }
	}
}
