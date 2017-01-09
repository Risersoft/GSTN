using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GSTN.API
{
   public class MxApiClient:GSTNApiClientBase

    {
        string base_url;
        public MxApiClient(string path) : base("")
		{
            base_url = path;
        }
      

        protected internal override void BuildHeaders(HttpClient client)
        {
            string str1 = Convert.ToBase64String(Encoding.UTF8.GetBytes("gstn:open"));
            client.DefaultRequestHeaders.Add("Authorization","Basic " + str1);
        }
        //API call for converting Json to CSV
        public GSTNResult<string> Json2CSV(string json, string returnkey, string tablename)
        {
            string str1 =base_url+ "/json2csv";
            this.PrepareQueryString(str1,new Dictionary<string, string> {
                {
                    "returnkey",
                    returnkey
                },
                {
                    "tablename",
                    tablename
                }
            });
            var info = this.Post<string, string>(json);
            return info;

        }
        //API call for converting Json to CSV
        public GSTNResult<string> CSV2Json(string csv, string returnkey, string tablename)
        {
            string str1 = base_url + "/csv2json";
            this.PrepareQueryString(str1,new Dictionary<string, string> {
                {
                    "returnkey",
                    returnkey
                },
                {
                    "tablename",
                    tablename
                }
            });
            var info = this.Post<string, string>(csv);
            return info;

        }
    }
}
