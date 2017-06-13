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
using Risersoft.API.GSTN;
namespace Risersoft.API.GSTN
{

    public class GSTNReturnsClient : GSTNApiClientBase
    {
        IGSTNAuthProvider provider;
        public string LastJson;
        protected internal string ret_period;

        //action_required=“Y|N“
        public GSTNReturnsClient(IGSTNAuthProvider AuthProvider, string path, string gstin, string ret_period) : base(path, gstin)
        {
            this.ret_period = ret_period;
            provider = AuthProvider;
        }

        protected internal override void BuildHeaders(HttpClient client)
        {
            client.DefaultRequestHeaders.Add("clientid", GSTNConstants.client_id);
            client.DefaultRequestHeaders.Add("client-secret", GSTNConstants.client_secret);
            client.DefaultRequestHeaders.Add("ip-usr", GSTNConstants.publicip);
            client.DefaultRequestHeaders.Add("state-cd", this.gstin.Substring(0, 2));
            client.DefaultRequestHeaders.Add("gstin", this.gstin);
            if (!string.IsNullOrEmpty(this.ret_period)) client.DefaultRequestHeaders.Add("ret_period", this.ret_period);
            client.DefaultRequestHeaders.Add("txn", System.Guid.NewGuid().ToString().Replace("-", ""));
            client.DefaultRequestHeaders.Add("username", provider.Username);
            client.DefaultRequestHeaders.Add("auth-token", provider.AuthToken);
        }
        protected internal T Decrypt<T>(ResponseDataInfo output)
        {
            T model = default(T);
            if (output != null)
            {
                byte[] decryptREK = EncryptionUtils.AesDecrypt(output.rek, provider.DecryptedKey);
                byte[] jsonData = EncryptionUtils.AesDecrypt(output.data, decryptREK);
                string testHmac = EncryptionUtils.GenerateHMAC(jsonData, decryptREK);
                System.Console.WriteLine("HMAC Match:" + (output.hmac==testHmac));
                string base64Payload = UTF8Encoding.UTF8.GetString(jsonData);
                byte[] decodeJson = Convert.FromBase64String(base64Payload);
                string finalJson = Encoding.UTF8.GetString(decodeJson);
                model = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(finalJson);
                LastJson = finalJson;
            }
            return model;
        }
        protected internal UnsignedDataInfo Encrypt<T>(T input)
        {
            UnsignedDataInfo info = new UnsignedDataInfo();
            if (input != null)
            {
                string finalJson = JsonConvert.SerializeObject(input, Newtonsoft.Json.Formatting.Indented,
                            new JsonSerializerSettings
                            {
                                NullValueHandling = NullValueHandling.Ignore
                            }) ;
                byte[] encodeJson = UTF8Encoding.UTF8.GetBytes(finalJson);
                string base64Payload = Convert.ToBase64String(encodeJson);
                byte[] jsonData = UTF8Encoding.UTF8.GetBytes(base64Payload);
                info.data = EncryptionUtils.AesEncrypt(jsonData, provider.DecryptedKey);
                info.hmac = EncryptionUtils.GenerateHMAC(jsonData, provider.DecryptedKey);
            }
            return info;
        }
        protected virtual GSTNResult<TOutput> BuildResult<TOutput>(GSTNResult<ResponseDataInfo> response, TOutput data)
        {
            //This function can be used to convert simple API result to ResultInfo based API result
            GSTNResult<TOutput> resultInfo = new GSTNResult<TOutput>();
            resultInfo.HttpStatusCode = response.HttpStatusCode;
            if (resultInfo.HttpStatusCode == (int)HttpStatusCode.OK)
            {
                resultInfo.Data = data;
            }
            return resultInfo;
        }
        protected internal virtual GSTNResult<FileInfo> SignFile(UnsignedDataInfo data, string sign, string st, string sid)
        {
            SignedDataInfo model = new SignedDataInfo
            {
                action = "RETFILE",
                sign = sign,
                st = st,
                sid = sid
            };
            model.data = data.data;
            var info = this.Post<SignedDataInfo, ResponseDataInfo>(model);
            var output = this.Decrypt<FileInfo>(info.Data);
            var model2 = this.BuildResult<FileInfo>(info, output);
            System.Console.WriteLine("Obtained Result:" + model2.Data.ack_num + System.Environment.NewLine);
            return model2;

        }
        public GSTNResult<SaveInfo> Submit(string ret_prd)
        {
            this.PrepareQueryString(new Dictionary<string, string> {
            {"gstin",gstin},
            {"action","RETSUBMIT"},
            {"ret_period",ret_prd},
            });
            GenerateRequestInfo model = new GenerateRequestInfo()
            {
                gstin = gstin,
                ret_period = ret_prd
            };
            var info = this.Post<GenerateRequestInfo, ResponseDataInfo>(model);
            var output = this.Decrypt<SaveInfo>(info.Data);
            var model2 = this.BuildResult<SaveInfo>(info, output);
            System.Console.WriteLine("Obtained Result:" + model2.Data.reference_id + System.Environment.NewLine);
            return model2;

        }
        //This API Is To Get status of return
        public GSTNResult<StatusInfo> GetStatus(string ret_prd, string reference_id)
        {
            this.PrepareQueryString(new Dictionary<string, string> {
            {"gstin",gstin},
            {"action","RETSTATUS"},
            {"ret_period",ret_prd},
            {"trans_id" ,reference_id}
            });
            var info = this.Get<ResponseDataInfo>();
            var output = this.Decrypt<StatusInfo>(info.Data);
            var model = this.BuildResult<StatusInfo>(info, output);
            return model;

        }

    }
}
