using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace GSTN.API.GSTR1
{

    public class B2BAInv:B2BInv
    {

        [Required]
        [Display(Name = "Original invoice number")]
        public string onum { get; set; }

        [Required]
        [Display(Name = "Original invoice date")]
        public string odt { get; set; }
    }

    public class B2bAOutward
    {

        [Required]
        [Display(Name = "GSTIN/UID of the Receiver taxpayer/UN,Govt Bodies")]
        [MaxLength(15)]
        [MinLength(15)]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string ctin { get; set; }
        [Required]
        public List<B2BAInv> inv { get; set; }
    }

}