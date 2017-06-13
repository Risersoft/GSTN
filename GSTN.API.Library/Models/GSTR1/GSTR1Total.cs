using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Risersoft.API.GSTN.GSTR1
{
    public class GSTR1Total
    {

        [Display(Name = "GSTIN of the Tax Payer")]
        [Required]
        [MaxLength(15)]
        [MinLength(15)]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string gstin { get; set; }

        [Required]
        [Display(Name = "Financial Period")]
        [MaxLength(10)]
        [MinLength(3)]
        [RegularExpression("^[0-9]+$")]
        public string fp { get; set; }

        [Required]
        [Display(Name = "Gross Turnover of the taxpayer in the previous FY")]
        public double gt { get; set; }
        public List<B2bOutward> b2b { get; set; }
        public List<B2bAOutward> b2ba { get; set; }
        public List<B2clOutward> b2cl { get; set; }
        public List<B2clAOutward> b2cla { get; set; }
        public List<B2csOutward> b2cs { get; set; }
        public List<B2CSAOutward> b2csa { get; set; }
        public NilRatedOutward nil { get; set; }
        public List<Exp> exp { get; set; }
        public List<ExpA> expa { get; set; }
        public List<CDNAOutward> cdna { get; set; }
        public List<AtOutward> at { get; set; }
        public List<AtAOutward> ata { get; set; }
        public List<CdnOutward> cdn { get; set; }
        public List<TxpOutward> txpd { get; set; }
        public List<EComOutward> ecom_invocies { get; set; }

    }
}
