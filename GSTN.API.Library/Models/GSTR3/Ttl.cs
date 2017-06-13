using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Risersoft.API.GSTN.GSTR3
{
    public class Ttl
    {
        [Required]
        [Display(Name = "Identifer if Goods or Services")]
        [RegularExpression("^[a-zA-z]+$")]
        public string ty { get; set; }

        [Required]
        [Display(Name = "Month to which invoice/debit note/credit note pertains")]
        public string mon { get; set; }

        [Required]
        [Display(Name = "Invoice Value")]
        public double val { get; set; }

        [Required]
        [Display(Name = "CGST liability on Total value of Inward supply of goods on which reverse charge is applicable")]
        public double camt { get; set; }

        [Required]
        [Display(Name = "SGST liability on Total value of Inward supply of goods on which reverse charge is applicable")]
        public double samt { get; set; }

        [Required]
        [Display(Name = "IGST liability on Total value of Inward supply of goods on which reverse charge is applicable")]
        public double iamt { get; set; }

        //[Required]
        //[Display(Name = "Additional Tax liability on Total value of Inward supply of goods on which reverse charge is applicable")]
        //public int aamt { get; set; }                                      --------------deleted-----------------

        [Required]
        [Display(Name = "Cess on total tax liab")]
        public double csamt { get; set; }
    }
}