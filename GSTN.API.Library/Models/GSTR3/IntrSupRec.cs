using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GSTN.API.GSTR3
{
    public class IntrSupRec
    {
        [Required]
        [Display(Name = "Identifer if Goods or Services")]
        [RegularExpression("^[a-zA-z]+$")]
        public string ty { get; set; }

        [Required]
        [Display(Name = "State code")]
        public string state_cd { get; set; }

        [Required]
        [Display(Name = "Rate of Tax")]
        public double txrt { get; set; }

        [Required]
        [Display(Name = "taxable vlaue")]
        public double val { get; set; }

        [Required]
        [Display(Name = "IGST Amount as per invoice")]
        public double iamt { get; set; }

        //[Required]
        //[Display(Name = "ITC of IGST available in the current month")]
        //public int tc_i { get; set; }                               ---------------changed by itc_i------------

        [Required]
        [Display(Name = "ITC of IGST available in the current month")]
        public double itc_i { get; set; }

        [Required]
        [Display(Name = "CESS amount as per invoice")]
        public double cess { get; set; }

        [Required]
        [Display(Name = "ITC of CESS available in the current month ")]
        public double itc_cs { get; set; }
    }
}