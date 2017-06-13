using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Risersoft.API.GSTN.GSTR3
{
    public class RevInv2:RevInv
    {
      
        //[Required]
        //[Display(Name = "GSTIN")]
        //[MaxLength(15)]
        //[MinLength(15)]
        //[RegularExpression("^[a-zA-Z0-9]+$")]
        //public string gstin { get; set; }                   ------------------deleted-------------------

        //[Required]
        //[Display(Name = "Sub type identifier like Goods-inputs ,Capital Goods,Services")]
        //[RegularExpression("^[a-zA-z]+$")]
        //public string sub_ty { get; set; }                         ----------------deleted-----------------

        //[Required]
        //[Display(Name = "HSN or SAC of Goods or Services as per Invoice line items")]
        //[RegularExpression("^[a-zA-Z0-9]+$")]
        //public string hsn_sc { get; set; }                         -------------------deleted-----------

        [Required]
        [Display(Name = "ITC available in IGST")]
        public double tc_i { get; set; }

        [Required]
        [Display(Name = "ITC available in CGST")]
        public double tc_c { get; set; }

        [Required]
        [Display(Name = "ITC available in SGST")]
        public double tc_s { get; set; }

        [Required]
        [Display(Name = "ITC available in CESS")]
        public double tc_cs { get; set; }
    }
}