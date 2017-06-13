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
namespace Risersoft.API.GSTN
{

    public class GSTR1ApiClient : GSTNReturnsClient
    {

        //action_required=“Y|N“
        public GSTR1ApiClient(IGSTNAuthProvider provider,string gstin, string ret_period) : base(provider, "/taxpayerapi/v0.2/returns/gstr1",gstin,ret_period)
        {
        }

        //API call for getting all B2B invoices for a return period.
        public GSTNResult<List<B2bOutward>> GetB2B(string action_required)
        {
            var dic = new Dictionary<string, string>();
            dic.Add("gstin", this.gstin);
            dic.Add("ret_period", this.ret_period);
            dic.Add("action", "B2B");
            if (!string.IsNullOrEmpty(action_required)) dic.Add("action_required",action_required);
            this.PrepareQueryString(dic);
            var info = this.Get<ResponseDataInfo>();
            var output = this.Decrypt<GSTR1Total>(info.Data);
            var model = this.BuildResult<List<B2bOutward>>(info, output.b2b);
            return model;
        }
        //API call  for getting all B2B amended invoices for a return period.
        public GSTNResult<List<B2bAOutward>> GetB2BA(string action_required)
        {
            this.PrepareQueryString(new Dictionary<string, string> {
                {
                    "gstin",
                    gstin
                },
                {
                    "action",
                    "B2BA"
                },
                {
                    "ret_period",
                   this.ret_period
                },
                {
                    "action_required",
                    action_required
                }
            });
            var info = this.Get<ResponseDataInfo>();
            var output = this.Decrypt<GSTR1Total>(info.Data);
            var model = this.BuildResult<List<B2bAOutward>>(info, output.b2ba);
            return model;

        }
        //API call  for getting all B2C Large invoices for a return period.
        public GSTNResult<List<B2clOutward>> GetB2CL(string state_cd)
        {
            this.PrepareQueryString(new Dictionary<string, string> {
                {
                    "gstin",
                    gstin
                },
                {
                    "action",
                    "B2CL"
                },
                {
                    "ret_period",
                    this.ret_period
                },
                {
                    "state_cd",
                    state_cd
                }
            });
            var info = this.Get<ResponseDataInfo>();
            var output = this.Decrypt<GSTR1Total>(info.Data);
            var model = this.BuildResult<List<B2clOutward>>(info, output.b2cl);
            return model;

        }
        //API call  for getting all B2C Large invoices with amendments for a return period.
        public GSTNResult<List<B2clAOutward>> GetB2CLA(string state_cd)
        {
            this.PrepareQueryString(new Dictionary<string, string> {
                {
                    "gstin",
                    gstin
                },
                {
                    "action",
                    "B2CL"
                },
                {
                    "ret_period",
                   this.ret_period
                },
                {
                    "state_cd",
                    state_cd
                }
            });
            var info = this.Get<ResponseDataInfo>();
            var output = this.Decrypt<GSTR1Total>(info.Data);
            var model = this.BuildResult<List<B2clAOutward>>(info, output.b2cla);
            return model;

        }
        //API call for getting all B2C HSN data for a return period.
        public GSTNResult<List<B2csOutward>> GetB2Cs(string state_cd)
        {
            this.PrepareQueryString(new Dictionary<string, string> {
                {
                    "gstin",
                    gstin
                },
                {
                    "action",
                    "B2CL"
                },
                {
                    "ret_period",
                   this.ret_period
                },
                {
                    "state_cd",
                    state_cd
                }
            });
            var info = this.Get<ResponseDataInfo>();
            var output = this.Decrypt<GSTR1Total>(info.Data);
            var model = this.BuildResult<List<B2csOutward>>(info, output.b2cs);
            return model;

        }
        //API call for getting all B2CA HSN data for a return period.
        public GSTNResult<List<B2CSAOutward>> GetB2CsA(string state_cd)
        {
            this.PrepareQueryString(new Dictionary<string, string> {
                {
                    "gstin",
                    gstin
                },
                {
                    "action",
                    "B2CL"
                },
                {
                    "ret_period",
                  this.ret_period
                },
                {
                    "state_cd",
                    state_cd
                }
            });
            var info = this.Get<ResponseDataInfo>();
            var output = this.Decrypt<GSTR1Total>(info.Data);
            var model = this.BuildResult<List<B2CSAOutward>>(info, output.b2csa);
            return model;

        }

        //API call  CDN for getting all Credit/Debit notes for a return period.
        public GSTNResult<List<CdnOutward>> GetCDN(string action_required)
        {
            this.PrepareQueryString(new Dictionary<string, string> {
                {
                    "gstin",
                    gstin
                },
                {
                    "action",
                    "CDN"
                },
                {
                    "ret_period",
                   this.ret_period
                },
                {
                    "action_required",
                    action_required
                }
            });
            var info = this.Get<ResponseDataInfo>();
            var output = this.Decrypt<GSTR1Total>(info.Data);
            var model = this.BuildResult<List<CdnOutward>>(info, output.cdn);
            return model;

        }

        //API call  CDNA for getting all amended Credit/Debit notes for a return period.
        public GSTNResult<List<CDNAOutward>> GetCDNA(string action_required)
        {
            this.PrepareQueryString(new Dictionary<string, string> {
                {
                    "gstin",
                    gstin
                },
                {
                    "action",
                    "CDNA"
                },
                {
                    "ret_period",
                   this.ret_period
                },
                {
                    "action_required",
                    action_required
                }
            });
            var info = this.Get<ResponseDataInfo>();
            var output = this.Decrypt<GSTR1Total>(info.Data);
            var model = this.BuildResult<List<CDNAOutward>>(info, output.cdna);
            return model;

        }

        //API call  NIL for getting  liabilities such as 'Nil Rated’, ‘Exempted’, and ‘Non GST’ supplies for a return period
        public GSTNResult<NilRatedOutward> GetNilRated(string ret_prd)
        {
            this.PrepareQueryString(new Dictionary<string, string> {
                {
                    "gstin",
                    gstin
                },
                {
                    "action",
                    "NIL"
                },
                {
                    "ret_period",
                    ret_prd
                }
            });
            var info = this.Get<ResponseDataInfo>();
            var output = this.Decrypt<GSTR1Total>(info.Data);
            var model = this.BuildResult<NilRatedOutward>(info, output.nil);
            return model;

        }
        //API call  for getting invoices related to supplies exported  for a return period.
        public GSTNResult<List<Exp>> GetExp(string ret_prd)
        {
            this.PrepareQueryString(new Dictionary<string, string> {
                {
                    "gstin",
                    gstin
                },
                {
                    "action",
                    "EXP"
                },
                {
                    "ret_period",
                    ret_prd
                }
            });
            var info = this.Get<ResponseDataInfo>();
            var output = this.Decrypt<GSTR1Total>(info.Data);
            var model = this.BuildResult<List<Exp>>(info, output.exp);
            return model;

        }

        //API call  for getting amended invoices related to supplies exported  for a return period.
        public GSTNResult<List<ExpA>> GetExpA(string ret_prd)
        {
            this.PrepareQueryString(new Dictionary<string, string> {
                {
                    "gstin",
                    gstin
                },
                {
                    "action",
                    "EXPA"
                },
                {
                    "ret_period",
                    ret_prd
                }
            });
            var info = this.Get<ResponseDataInfo>();
            var output = this.Decrypt<GSTR1Total>(info.Data);
            var model = this.BuildResult<List<ExpA>>(info, output.expa);
            return model;

        }

        //API call  for getting advance tax details for a return period.
        public GSTNResult<List<AtOutward>> GetAT(string ret_prd)
        {
            this.PrepareQueryString(new Dictionary<string, string> {
                {
                    "gstin",
                    gstin
                },
                {
                    "action",
                    "AT"
                },
                {
                    "ret_period",
                    ret_prd
                }
            });
            var info = this.Get<ResponseDataInfo>();
            var output = this.Decrypt<GSTR1Total>(info.Data);
            var model = this.BuildResult<List<AtOutward>>(info, output.at);
            return model;

        }

        //API call  for getting amended advance tax details for a return period.
        public GSTNResult<List<AtAOutward>> GetATA(string ret_prd)
        {
            this.PrepareQueryString(new Dictionary<string, string> {
                {
                    "gstin",
                    gstin
                },
                {
                    "action",
                    "ATA"
                },
                {
                    "ret_period",
                    ret_prd
                }
            });
            var info = this.Get<ResponseDataInfo>();
            var output = this.Decrypt<GSTR1Total>(info.Data);
            var model = this.BuildResult<List<AtAOutward>>(info, output.ata);
            return model;

        }

        //API call  for getting tax paid details for a return period.
        public GSTNResult<List<TxpOutward>> GetTXPD(string ret_prd)
        {
            this.PrepareQueryString(new Dictionary<string, string> {
                {
                    "gstin",
                    gstin
                },
                {
                    "action",
                    "TXP"
                },
                {
                    "ret_period",
                    ret_prd
                }
            });
            var info = this.Get<ResponseDataInfo>();
            var output = this.Decrypt<GSTR1Total>(info.Data);
            var model = this.BuildResult<List<TxpOutward>>(info, output.txpd);
            return model;

        }

        //API call  for getting details of e-commerce supply for a return period
        public GSTNResult<List<EComOutward>> GetECOM(string ret_prd)
        {
            this.PrepareQueryString(new Dictionary<string, string> {
                {
                    "gstin",
                    gstin
                },
                {
                    "action",
                    "ECOM"
                },
                {
                    "ret_period",
                    ret_prd
                }
            });
            var info = this.Get<ResponseDataInfo>();
            var output = this.Decrypt<GSTR1Total>(info.Data);
            var model = this.BuildResult<List<EComOutward>>(info, output.ecom_invocies);
            return model;

        }

        //This API Is To Get the table wise summary Of GSTR1 data
        public GSTNResult<SummaryOutward> GetSummary(string ret_prd)
        {
            this.PrepareQueryString(new Dictionary<string, string> {
                {
                    "gstin",
                    gstin
                },
                {
                    "action",
                    "RETSUM"
                },
                {
                    "ret_period",
                    ret_prd
                }
            });
            var info = this.Get<ResponseDataInfo>();
            var output = this.Decrypt<SummaryOutward>(info.Data);
            var model = this.BuildResult<SummaryOutward>(info, output);
            return model;

        }
        //This API Is used To save entire GSTR1 invoices
        public GSTNResult<SaveInfo> Save(GSTR1Total data)
        {
            var model = this.Encrypt(data);
            model.action = "RETSAVE";
            var info = this.Put<UnsignedDataInfo, ResponseDataInfo>(model);
            var output = this.Decrypt<SaveInfo>(info.Data);
            var model2 = this.BuildResult<SaveInfo>(info, output);
            return model2;
        }
        //This API Is used To submit GSTR1 return
        public GSTNResult<FileInfo> File(SummaryOutward data, string sign, string st, string sid)
        {
            var model = this.Encrypt(data);
            var model2 = this.SignFile(model, sign, st, sid);
            return model2;
        }



    }
}
