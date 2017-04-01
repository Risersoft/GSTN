using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSTN.API.GSTR1
{
    public class CDNAInv : CdnInv
    {

        [Required]
        [Display(Name = "Oringal Credit/debit note number")]
        [MaxLength(10)]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public int ont_num { get; set; }

        [Required]
        [Display(Name = "Orignal Credit/Debit date")]
        [RegularExpression("^((0[1-9]|[12][0-9]|3[01])[-](0[1-9]|1[012])[-]((19|20)\\d\\d))*$")]
        public string ont_dt { get; set; }
    }
    public class CDNAOutward

    {

        //[Required]                                 ---------Not mandatory---------------------
        [Display(Name = "Counter party GSTIN")]
        [MaxLength(15)]
        [MinLength(15)]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string ctin { get; set; }

        [Required]
        [Display(Name = "GSTIN of the taxpayer")]
        [MaxLength(15)]
        [MinLength(15)]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string gstin { get; set; }

        [Required]
        [Display(Name = "GSTR2 filing status of counter party")]
        [MaxLength(1)]
        [RegularExpression("^[a-zA-Z]+$")]
        public string cfs { get; set; }

        [Required]
        public List<CDNAInv> cdn { get; set; }
    }
}
