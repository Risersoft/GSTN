using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace GSTN.API.GSTR2
{


    public class B2bAInv:B2bInv
    {


        [Required]
        [Display(Name = "Original invoice no")]
        [MaxLength(50)]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string onum { get; set; }

        [Required]
        [Display(Name = "Original date")]
        [RegularExpression("^((0[1-9]|[12][0-9]|3[01])[-](0[1-9]|1[012])[-]((19|20)\\d\\d))*$")]
        public string odt { get; set; }

    }

    public class B2bAInward
    {

        [Required]
        [Display(Name = "GSTIN/UID of the Receiver taxpayer/UN, Govt Bodies")]
        public string ctin { get; set; }

        [Required]
        [Display(Name = "inv")]
        public List<B2bAInv> inv { get; set; }
    }


}