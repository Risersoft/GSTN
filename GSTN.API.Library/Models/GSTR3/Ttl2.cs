using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GSTN.API.GSTR3
{
    public class Ttl2
    {
        [Required]
        [Display(Name = "Identifer if Goods or Services")]
        [RegularExpression("^[a-zA-z]+$")]
        public string ty { get; set; }

        [Required]
        [Display(Name = "Month to which invoice/debit note/credit note pertains")]
        public string mon { get; set; }

        [Required]
        [Display(Name = "Total value of Outward supply of Goods for the tax period")]
        public double txval { get; set; }

        [Required]
        [Display(Name = "IGST on Total value of Outward supply of Goods for the tax period")]
        public double camt { get; set; }

        [Required]
        [Display(Name = "IGST on Total value of Outward supply of Goods for the tax period")]
        public double samt { get; set; }

        [Required]
        [Display(Name = "IGST on Total value of Outward supply of Goods for the tax period")]
        public double iamt { get; set; }

        //[Required]
        //[Display(Name = "Additional Tax liability on Total value of Inward supply of goods on which reverse charge is applicable")]
        //public int aamt { get; set; }                                      --------------deleted-----------------

        [Required]
        [Display(Name = "CESS on Total value of Outward supply of Goods for the tax period")]
        public double cess { get; set; }
    }
}