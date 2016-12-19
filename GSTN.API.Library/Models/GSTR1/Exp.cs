using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace GSTN.API.GSTR1
{
   
    public class ExpInv
    {

        [Required]
        [Display(Name = "Invoice number")]
        public string num { get; set; }

        [Required]
        [Display(Name = "Export Invoice date")]
        [RegularExpression("^((0[1-9]|[12][0-9]|3[01])[-](0[1-9]|1[012])[-]((19|20)\\d\\d))*$")]
        public string dt { get; set; }

        [Required]
        [Display(Name = "Supplier Invoice Value")]
        public double val { get; set; }

        [Required]
        [Display(Name = "Shipping Bill No. or Bill of Export No.")]
        public string sbnum { get; set; }

        [Required]
        [Display(Name = "Shipping Bill Date. or Bill of Export Date")]
        [RegularExpression("^((0[1-9]|[12][0-9]|3[01])[-](0[1-9]|1[012])[-]((19|20)\\d\\d))*$")]
        public string sbdt { get; set; }
        [Required]
        public List<Itm> itms { get; set; }


        [Display(Name = "Checksum Value")]
        public string chksum { get; set; }
    }

    public class Exp
    {
        [Display(Name = "Supplies exported types i.e WithPay,WithoutPay")]
        [Required]
        public string ex_tp { get; set; }

        [Required]
        public List<ExpInv> inv { get; set; }
    }
    
}