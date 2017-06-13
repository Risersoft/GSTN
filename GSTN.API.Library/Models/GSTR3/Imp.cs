using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Risersoft.API.GSTN.GSTR3
{
    public class Imp
    {
        [Required]
        [Display(Name = "Identifer if Goods or Services")]
        [RegularExpression("^[a-zA-z]+$")]
        public string ty { get; set; }

        [Required]
        [Display(Name = "Assessable value of Imports")]
        public double aval { get; set; }

        [Required]
        [Display(Name = "IGST on imports")]
        public double iamt { get; set; }

        //[Required]
        //[Display(Name = "ITC of IGST available in the current month")]
        //public int tc_i { get; set; }                              --------------changed by itc_i---------------

        [Required]
        [Display(Name = "ITC on IGST available for IGST paid on Imports")]
        public int itc_i { get; set; }

        [Required]
        [Display(Name = "CESS on Imports")]
        public int csamt { get; set; }

        [Required]
        [Display(Name = "ITC of CESS available for IGST paid on Imports")]
        public int itc_cs { get; set; }
    }
}