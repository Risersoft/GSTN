using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSTN.API.GSTR2
{

    public class GSTR2Total
    {

        [Required]
        [Display(Name = "GSTIN of the Tax Payer")]
        [MaxLength(15)]
        [MinLength(15)]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string gstin { get; set; }

        [Required]
        [Display(Name = "Finalcial Period")]
        [MaxLength(10)]
        [MinLength(3)]
        [RegularExpression("^[0-9]+$")]
        public string fp { get; set; }

        [Required]
        [Display(Name = "Gross Turn Over")]
        public int gt { get; set; }

        [Required]
        [Display(Name = "Total Tax Liability")]
        public int ttl { get; set; }

        public List<B2bInward> b2b { get; set; }


        public List<B2bAInward> b2ba { get; set; }


        public List<ImpG> imp_g { get; set; }


        public List<ImpGA> imp_ga { get; set; }

        public List<ImpS> imp_s { get; set; }

        public List<ImpSA> imp_sa { get; set; }

        public List<CdnInward> cdn { get; set; }

        public List<CdnAInward> cdna { get; set; }

        public List<NilRatedInward> nil_supplies { get; set; }


        public List<IsdRcd> isd_rcd { get; set; }


        public List<TdsCredit> tds_credit { get; set; }


        public List<TcsData> tcs_data { get; set; }


        public List<ItcRcd> itc_rcd { get; set; }


        public List<Txli> txi { get; set; }

        public List<TxliA> atxi { get; set; }

        public List<Txpd> txpd { get; set; }


        public List<ItcRvsl> itc_rvsl { get; set; }

    
    }
}
