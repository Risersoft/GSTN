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
using Newtonsoft.Json;
using GSTN.API;
namespace GSTN.API
{

	public class GSTNReturnsClient : GSTNApiClientBase
	{
		IGSTNAuthProvider provider;
        public string LastJson;
		//action_required=“Y|N“
		public GSTNReturnsClient(IGSTNAuthProvider AuthProvider, string path) : base(path)
		{
			provider = AuthProvider;
		}

		protected internal override void BuildHeaders(HttpClient client)
		{
			client.DefaultRequestHeaders.Add("clientid", GSTNConstants.client_id);
			client.DefaultRequestHeaders.Add("client-secret", GSTNConstants.client_secret);
			client.DefaultRequestHeaders.Add("ip-usr", "12.8.91.80");
			client.DefaultRequestHeaders.Add("state-cd", "11");
			client.DefaultRequestHeaders.Add("txn", "LAPN24235325555");
			client.DefaultRequestHeaders.Add("username", provider.Username);
			client.DefaultRequestHeaders.Add("auth-token", provider.AuthToken);
		}
		protected internal T Decrypt<T>(ResponseDataInfo output)
		{
			T model = default(T);
			if (output != null) {
				byte[] decryptREK = EncryptionUtils.Decrypt(output.rek, provider.DecryptedKey);
				byte[] jsonData = EncryptionUtils.Decrypt(output.data, decryptREK);
				string json = Encoding.UTF8.GetString(jsonData);
				byte[] decodeJson = Convert.FromBase64String(json);
				string finalJson = Encoding.UTF8.GetString(decodeJson);
				model = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(finalJson);
                LastJson = finalJson;
			}
			return model;
		}
		protected internal UnsignedDataInfo Encrypt<T>(T input)
		{
			UnsignedDataInfo info = new UnsignedDataInfo();
			if (input != null) {
				string finalJson = JsonConvert.SerializeObject(input);
				byte[] encodeJson = Encoding.UTF8.GetBytes(finalJson);
				string json = Convert.ToBase64String(encodeJson);
				byte[] jsonData = Encoding.UTF8.GetBytes(json);
				info.data = EncryptionUtils.Encrypt(jsonData, provider.DecryptedKey);
				info.hMAC = EncryptionUtils.GenerateHMAC(json, provider.DecryptedKey);
			}
			return info;
		}
		protected virtual GSTNResult<TOutput> BuildResult<TOutput>(GSTNResult<ResponseDataInfo> response, TOutput data)
		{
			//This function can be used to convert simple API result to ResultInfo based API result
			GSTNResult<TOutput> resultInfo = new GSTNResult<TOutput>();
			resultInfo.HttpStatusCode = response.HttpStatusCode;
			if (resultInfo.HttpStatusCode == (int)HttpStatusCode.OK) {
				resultInfo.Data = data;
			}
			return resultInfo;
		}
		protected internal virtual GSTNResult<FileInfo> SignFile(UnsignedDataInfo data, string sign, string st, string sid)
		{
			SignedDataInfo model = new SignedDataInfo {
				action = "RETSUBMIT",
				sign = sign,
				st = st,
				sid = sid
			};
			model.data = data.data;
			var info = this.Put<SignedDataInfo, ResponseDataInfo>(model);
			var output = this.Decrypt<FileInfo>(info.Data);
			var model2 = this.BuildResult<FileInfo>(info, output);
			return model2;

		}
	}
}
