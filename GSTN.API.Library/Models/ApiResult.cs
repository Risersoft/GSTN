using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSTN.API
{
    public class PutInfo
    {
        public string trans_id { get; set; }
    }
    public class PostInfo
    {
        public string stscd { get; set; }
        public string db_no { get; set; }
    }
    public class GenerateRequestInfo
    {
        public string gstin { get; set; }
        public string ret_period { get; set; }
    }
    public class GenerateResponseInfo
    {
        public string status { get; set; }
        public string trans_id { get; set; }
    }
    public class FileInfo
    {
        public string status { get; set; }
        public string ack_num { get; set; }
    }

    public class ErrorDetails
    {
        public string code { get; set; }
        public string desc { get; set; }
    }

    public class ErrorInfo
    {
        public string status_cd { get; set; }
        public ErrorDetails error { get; set; }
    }
    public class ResponseDataInfo
    {
        public string data { get; set; }
        public string status_cD { get; set; }
        public string rek { get; set; }
        public string hmac { get; set; }
    }
    public class UnsignedDataInfo
    {
        public string data { get; set; }
        public string action { get; set; }
        public string hMAC {get; set;}
    }
    public class SignedDataInfo
    {
        public string data { get; set; }
        public string action { get; set; }
        public string sign { get; set; }
        public string st { get; set; }
        public string sid { get; set; }
    }
    public class GSTNResult<T>
    {
        public int HttpStatusCode { get; set; }

        public T Data { get; set; }

        public string Message { get; set; }

        public string Status { get; set; }

        public ErrorInfo Error { get; set; }
    }
}
