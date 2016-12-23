
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using GSTN.API;
using GSTN.API.Ledger;

namespace GSTN.API
{
    public class LedgerApiClient : GSTNReturnsClient
    {

        //action_required=“Y|N“
        public LedgerApiClient(IGSTNAuthProvider provider) : base(provider, "/taxpayerapi/v0.1/returns/ledgers")
        {
        }

        //This API call is for getting cash ledger details for the specified period
        public GSTNResult<CashLedgerDetails> GetCashDtl(string gstin, string fr_dt, string to_dt)
        {
            this.PrepareQueryString(new Dictionary<string, string> {
            {
                "gstin",
                gstin
            },
            {
                "action",
                "CASHDTL"
            },
            {
                "fr_dt",
                fr_dt
            },
            {
                "to_dt",
                to_dt
            }
        });
            var info = this.Get<ResponseDataInfo>();
            var output = this.Decrypt<CashLedgerDetails>(info.Data);
            var model = this.BuildResult<CashLedgerDetails>(info, output);
            return model;
        }
        //This API call is for getting ITC ledger details for the specified period
        public GSTNResult<ITCLedgerDetails> GetItcDtl(string gstin, string fr_dt, string to_dt)
        {
            this.PrepareQueryString(new Dictionary<string, string> {
            {
                "gstin",
                gstin
            },
            {
                "action",
                "ITCDTL"
            },
            {
                "fr_dt",
                fr_dt
            },
            {
                "to_dt",
                to_dt
            }
        });
            var info = this.Get<ResponseDataInfo>();
            var output = this.Decrypt<ITCLedgerDetails>(info.Data);
            var model = this.BuildResult<ITCLedgerDetails>(info, output);
            return model;
        }
        //This API call is for getting Tax Liability ledger details for the specified period
        public GSTNResult<TaxLedgerDetails> GetTaxDtl(string gstin, string fr_dt, string to_dt)
        {
            this.PrepareQueryString(new Dictionary<string, string> {
            {
                "gstin",
                gstin
            },
            {
                "action",
                "TAX"
            },
            {
                "fr_dt",
                fr_dt
            },
            {
                "to_dt",
                to_dt
            }
        });
            var info = this.Get<ResponseDataInfo>();
            var output = this.Decrypt<TaxLedgerDetails>(info.Data);
            var model = this.BuildResult<TaxLedgerDetails>(info, output);
            return model;
        }
        //This API call is for getting summary of cash ledger details for the specified period
        public GSTNResult<LedgerSummary> GetCashSum(string gstin, string fr_dt, string to_dt)
        {
            this.PrepareQueryString(new Dictionary<string, string> {
            {
                "gstin",
                gstin
            },
            {
                "action",
                "CASHSUM"
            },
            {
                "fr_dt",
                fr_dt
            },
            {
                "to_dt",
                to_dt
            }
        });
            var info = this.Get<ResponseDataInfo>();
            var output = this.Decrypt<LedgerSummary>(info.Data);
            var model = this.BuildResult<LedgerSummary>(info, output);
            return model;
        }
        //This API call is for getting summary of ITC ledger details for the specified period
        public GSTNResult<LedgerSummary> GetItcSum(string gstin, string fr_dt, string to_dt)
        {
            this.PrepareQueryString(new Dictionary<string, string> {
            {
                "gstin",
                gstin
            },
            {
                "action",
                "ITCSUM"
            },
            {
                "fr_dt",
                fr_dt
            },
            {
                "to_dt",
                to_dt
            }
        });
            var info = this.Get<ResponseDataInfo>();
            var output = this.Decrypt<LedgerSummary>(info.Data);
            var model = this.BuildResult<LedgerSummary>(info, output);
            return model;
        }

        //This API call is to utilize the remaining cash for paying the liability
        public GSTNResult<PostInfo> UtilizeCash(UtilizeCashModel data)
        {
            var model = this.Encrypt(data);
            model.action = "UTLCSH";
            var info = this.Post<UnsignedDataInfo, ResponseDataInfo>(model);
            var output = this.Decrypt<PostInfo>(info.Data);
            var model2 = this.BuildResult<PostInfo>(info, output);
            return model2;
        }


        //This API call is to utilize ITC for paying the liability
        public GSTNResult<PostInfo> UtilizeITC(UtilizeITCModel data)
        {
            var model = this.Encrypt(data);
            model.action = "UTLITC";
            var info = this.Post<UnsignedDataInfo, ResponseDataInfo>(model);
            var output = this.Decrypt<PostInfo>(info.Data);
            var model2 = this.BuildResult<PostInfo>(info, output);
            return model2;
        }

    }
}