using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSTN.API.GSTR1
{
   public class CDNAInv:CdnInv
    {
        //TODO: Should match with CDNInv.cddt
        [Required]
        [Display(Name = "Credit/Debit date")]
        public string nt_dt { get; set; }

        [Required]
        [Display(Name = "Oringal Credit/debit note number")]
        public string ont_num { get; set; }

        [Required]
        [Display(Name = "Orignal Credit/Debit date")]
        public string ont_dt { get; set; }
    }
   public class CDNAOutward

    {
        [Required]
        [Display(Name = "Counter party GSTIN")]
        [MaxLength(15)]
        [MinLength(15)]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string cgstin { get; set; }

        [Required]
        [Display(Name = "Type of invoices")]
        public string typ { get; set; }

        [Required]
        [Display(Name = "Name of the Receiver taxpayer")]
        public string cname { get; set; }

        [Required]
        public List<CDNAInv> cdn { get; set; }
    }
}
