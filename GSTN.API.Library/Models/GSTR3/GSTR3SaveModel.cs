using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Risersoft.API.GSTN.GSTR3

{
    public class GSTR3SaveModel
    {
        [Required]
        [Display(Name = "Supplier GSTIN")]
        [MaxLength(15)]
        [MinLength(15)]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string gstin { get; set; }

        [Required]
        [Display(Name = "Return Period")]
        [RegularExpression("^((0[1-9]|1[012])((19|20)\\d\\d))*$")]
        public string ret_period { get; set; }


        [Required]
        [Display(Name = "Refund Claim")]
        public RfClm2 rf_clm { get; set; }
    }
}