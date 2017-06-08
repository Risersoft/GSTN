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
using GSTN.API;
using GSTN.API.GSTR2;
namespace GSTN.API
{

	public class GSTR2ApiClient : GSTNReturnsClient
	{

		//action_required=“Y|N“
		public GSTR2ApiClient(IGSTNAuthProvider provider, string gstin, string ret_period) : base(provider, "/taxpayerapi/v0.2/returns/gstr2", gstin,ret_period)
		{
		}


		//API call for getting all B2B invoices for a return period.
		public GSTNResult<List<B2bInward>> GetB2B(string action_required)
		{
            var dic = new Dictionary<string, string>();
            dic.Add("gstin", this.gstin);
            dic.Add("ret_period", this.ret_period);
            dic.Add("action", "B2B");
            if (!string.IsNullOrEmpty(action_required)) dic.Add("action_required", action_required);
            this.PrepareQueryString(dic);
            var info = this.Get<ResponseDataInfo>();
			var output = this.Decrypt<GSTR2Total>(info.Data);
			var model = this.BuildResult<List<B2bInward>>(info, output.b2b);
			return model;
		}
		//API call  for getting all B2B amended invoices for a return period.
		public GSTNResult<List<B2bAInward>> GetB2BA(string action_required)
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
			var output = this.Decrypt<GSTR2Total>(info.Data);
			var model = this.BuildResult<List<B2bAInward>>(info, output.b2ba);
			return model;
		}


		//API call  CDN for getting all Credit/Debit notes for a return period.
		public GSTNResult<List<CdnInward>> GetCDN(string action_required)
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
			var output = this.Decrypt<GSTR2Total>(info.Data);
			var model = this.BuildResult<List<CdnInward>>(info, output.cdn);
			return model;
		}

		//API call  CDNA for getting all amended Credit/Debit notes for a return period.
		public GSTNResult<List<CdnAInward>> GetCDNA(string action_required)
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
			var output = this.Decrypt<GSTR2Total>(info.Data);
			var model = this.BuildResult<List<CdnAInward>>(info, output.cdna);
			return model;
		}

		//API call  NIL for getting  liabilities such as 'Nil Rated’, ‘Exempted’, and ‘Non GST’ supplies for a return period
		public GSTNResult<List<NilRatedInward>> GetNilRated(string ret_prd)
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
			var output = this.Decrypt<GSTR2Total>(info.Data);
			var model = this.BuildResult<List<NilRatedInward>>(info, output.nil_supplies);
			return model;
		}



		//API Call For getting invoices  related To Import Of Goods/Capital Goods For a Return period
		public GSTNResult<List<ImpG>> GetImpG(string ret_prd)
		{
			this.PrepareQueryString(new Dictionary<string, string> {
				{
					"gstin",
					gstin
				},
				{
					"action",
					"IMPG"
				},
				{
					"ret_period",
					ret_prd
				}
			});
			var info = this.Get<ResponseDataInfo>();
			var output = this.Decrypt<GSTR2Total>(info.Data);
			var model = this.BuildResult<List<ImpG>>(info, output.imp_g);
			return model;
		}
		//API Call For getting invoices  related To Amended Import Of Goods/Capital Goods For a Return period
		public GSTNResult<List<ImpGA>> GetImpGA(string ret_prd)
		{
			this.PrepareQueryString(new Dictionary<string, string> {
				{
					"gstin",
					gstin
				},
				{
					"action",
					"IMPGA"
				},
				{
					"ret_period",
					ret_prd
				}
			});
			var info = this.Get<ResponseDataInfo>();
			var output = this.Decrypt<GSTR2Total>(info.Data);
			var model = this.BuildResult<List<ImpGA>>(info, output.imp_ga);
			return model;
		}



		//API Call For getting invoices  related To Import Of Services For a Return period
		public GSTNResult<List<ImpS>> GetImpS(string ret_prd)
		{
			this.PrepareQueryString(new Dictionary<string, string> {
				{
					"gstin",
					gstin
				},
				{
					"action",
					"IMPS"
				},
				{
					"ret_period",
					ret_prd
				}
			});
			var info = this.Get<ResponseDataInfo>();
			var output = this.Decrypt<GSTR2Total>(info.Data);
			var model = this.BuildResult<List<ImpS>>(info, output.imp_s);
			return model;
		}
		//API Call For getting invoices  related To Amended Import Of Services For a Return period
		public GSTNResult<List<ImpSA>> GetImpSA(string ret_prd)
		{
			this.PrepareQueryString(new Dictionary<string, string> {
				{
					"gstin",
					gstin
				},
				{
					"action",
					"IMPSA"
				},
				{
					"ret_period",
					ret_prd
				}
			});
			var info = this.Get<ResponseDataInfo>();
			var output = this.Decrypt<GSTR2Total>(info.Data);
			var model = this.BuildResult<List<ImpSA>>(info, output.imp_sa);
			return model;
		}


		//API Call For getting invoices related To ISD credit received
		//status_filter={UPLOADED/RECEIVED}
		public GSTNResult<List<IsdRcd>> GetISDCredit(string status_filter)
		{
			this.PrepareQueryString(new Dictionary<string, string> {
				{
					"gstin",
					gstin
				},
				{
					"action",
					"ISD"
				},
				{
					"ret_period",
					this.ret_period
				},
				{
					"status_filter",
					status_filter
				}
			});
			var info = this.Get<ResponseDataInfo>();
			var output = this.Decrypt<GSTR2Total>(info.Data);
			var model = this.BuildResult<List<IsdRcd>>(info, output.isd_rcd);
			return model;
		}

		//API Call For getting invoices related To TDS credit received
		//status_filter=“ACCEPTED|REJECTED“
		public GSTNResult<List<TdsCredit>> GetTDSCredit(string status_filter)
		{
			this.PrepareQueryString(new Dictionary<string, string> {
				{
					"gstin",
					gstin
				},
				{
					"action",
					"ISD"
				},
				{
					"ret_period",
					this.ret_period
				},
				{
					"status_filter",
					status_filter
				}
			});
			var info = this.Get<ResponseDataInfo>();
			var output = this.Decrypt<GSTR2Total>(info.Data);
			var model = this.BuildResult<List<TdsCredit>>(info, output.tds_credit);
			return model;
		}


		//API Call For getting invoices related To TCS credit
		public GSTNResult<List<TcsData>> GetTCSCredit(string ret_prd)
		{
			this.PrepareQueryString(new Dictionary<string, string> {
				{
					"gstin",
					gstin
				},
				{
					"action",
					"TCS"
				},
				{
					"ret_period",
					ret_prd
				}
			});
			var info = this.Get<ResponseDataInfo>();
			var output = this.Decrypt<GSTR2Total>(info.Data);
			var model = this.BuildResult<List<TcsData>>(info, output.tcs_data);
			return model;

		}
		//API Call For saving  invoices related To ITC received
		public GSTNResult<List<ItcRcd>> GetITCReceived(string ret_prd)
		{
			this.PrepareQueryString(new Dictionary<string, string> {
				{
					"gstin",
					gstin
				},
				{
					"action",
					"ITC"
				},
				{
					"ret_period",
					ret_prd
				}
			});
			var info = this.Get<ResponseDataInfo>();
			var output = this.Decrypt<GSTR2Total>(info.Data);
			var model = this.BuildResult<List<ItcRcd>>(info, output.itc_rcd);
			return model;

		}
		//API Call For getting Item details related To Tax liability under reverse charge
		public GSTNResult<List<Txli>> GetTXLI(string ret_prd)
		{
			this.PrepareQueryString(new Dictionary<string, string> {
				{
					"gstin",
					gstin
				},
				{
					"action",
					"TXLI"
				},
				{
					"ret_period",
					ret_prd
				}
			});
			var info = this.Get<ResponseDataInfo>();
			var output = this.Decrypt<GSTR2Total>(info.Data);
			var model = this.BuildResult<List<Txli>>(info, output.txi);
			return model;

		}

		//API Call For getting amended Item details related To Tax liability under reverse charge
		public GSTNResult<List<TxliA>> GetATXLI(string ret_prd)
		{
			this.PrepareQueryString(new Dictionary<string, string> {
				{
					"gstin",
					gstin
				},
				{
					"action",
					"ATXLI"
				},
				{
					"ret_period",
					ret_prd
				}
			});
			var info = this.Get<ResponseDataInfo>();
			var output = this.Decrypt<GSTR2Total>(info.Data);
			var model = this.BuildResult<List<TxliA>>(info, output.atxi);
			return model;

		}

		//API Call For getting invoice details related To Tax paid under reverse charge
		public GSTNResult<List<Txpd>> GetTXPD(string ret_prd)
		{
			this.PrepareQueryString(new Dictionary<string, string> {
				{
					"gstin",
					gstin
				},
				{
					"action",
					"TXPD"
				},
				{
					"ret_period",
					ret_prd
				}
			});
			var info = this.Get<ResponseDataInfo>();
			var output = this.Decrypt<GSTR2Total>(info.Data);
			var model = this.BuildResult<List<Txpd>>(info, output.txpd);
			return model;

		}

		//API Call For getting item details related To ITC reversal
		public GSTNResult<List<ItcRvsl>> GetITCRVSL(string ret_prd)
		{
			this.PrepareQueryString(new Dictionary<string, string> {
				{
					"gstin",
					gstin
				},
				{
					"action",
					"ITCRVSL"
				},
				{
					"ret_period",
					ret_prd
				}
			});
			var info = this.Get<ResponseDataInfo>();
			var output = this.Decrypt<GSTR2Total>(info.Data);
			var model = this.BuildResult<List<ItcRvsl>>(info, output.itc_rvsl);
			return model;

		}

		//This API Is To Get the table wise summary Of GSTR2 data
		public GSTNResult<SummaryInward> GetSummary(string ret_prd)
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
			var output = this.Decrypt<SummaryInward>(info.Data);
			//https://groups.google.com/d/msg/gst-suvidha-provider-gsp-discussion-group/BVMrgu9_qlA/of-VDWceBAAJ
			var model = this.BuildResult<SummaryInward>(info, output);
			return model;
		}
		//This API Is used To save entire GSTR2 invoices
		public GSTNResult<SaveInfo> Save(GSTR2Total data)
		{
			var model = this.Encrypt(data);
			model.action = "RETSAVE";
			var info = this.Put<UnsignedDataInfo, ResponseDataInfo>(model);
			var output = this.Decrypt<SaveInfo>(info.Data);
			var model2 = this.BuildResult<SaveInfo>(info, output);
			return model2;
		}
		//This API Is used To submit GSTR2 return
		public GSTNResult<FileInfo> File(SummaryInward data, string sign, string st, string sid)
		{
			var model = this.Encrypt(data);
			var model2 = this.SignFile(model, sign, st, sid);
			return model2;
		}



	}
}
