using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Risersoft.API.GSTN;
using Risersoft.API.GSTN.GSTR1;
using Risersoft.API.GSTN.Auth;
using Newtonsoft.Json;

namespace Risersoft.API.GSTN
{

    public class GSTNDSClient : GSTNApiClientBase
    {
        IGSTNAuthProvider provider;

        public GSTNDSClient(IGSTNAuthProvider provider, string gstin) : base("/taxpayerapi/v0.2/registerdsc", gstin)
        {
            this.provider = provider;
        }

        protected internal override void BuildHeaders(HttpClient client)
        {
            client.DefaultRequestHeaders.Add("clientid", GSTNConstants.client_id);
            client.DefaultRequestHeaders.Add("client-secret", GSTNConstants.client_secret);
            client.DefaultRequestHeaders.Add("ip-usr", GSTNConstants.publicip);
            client.DefaultRequestHeaders.Add("state-cd", "11");
            client.DefaultRequestHeaders.Add("txn", System.Guid.NewGuid().ToString().Replace("-", ""));
            client.DefaultRequestHeaders.Add("username", provider.Username);
            client.DefaultRequestHeaders.Add("auth-token", provider.AuthToken);
        }

        public GSTNResult<string> RegisterDSC(string pannum, string sign)
        {
            RegisterDSCModel model = new RegisterDSCModel
            {
                data = pannum,
                sign = sign
            };

            var output = this.Post<RegisterDSCModel, string>(model);

            return output;

        }

    }
}
