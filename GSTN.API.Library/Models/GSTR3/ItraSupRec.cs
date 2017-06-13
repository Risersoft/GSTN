using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Risersoft.API.GSTN.GSTR3
{
    public class ItraSupRec
    {
        [Required]
        [Display(Name = "Identifer if Goods or Services")]
        [RegularExpression("^[a-zA-z]+$")]
        public string ty { get; set; }

        [Required]
        [Display(Name = "Rate of tax applicable on Inter-state Supplies received during the period ")]
        public double txrt { get; set; }

        [Required]
        [Display(Name = "Value of Intra-state Supplies received")]
        public double val { get; set; }

        [Required]
        [Display(Name = "CGST  on Value of Inter-state Supplies received")]
        public double camt { get; set; }

        [Required]
        [Display(Name = "SGST  on Value of Inter-state Supplies received")]
        public double samt { get; set; }

        //[Required]
        //[Display(Name = "ITC of CGST available in the current month")]
        //public int tc_c { get; set; }                            ------------changed by itc_c ------------

        [Required]
        [Display(Name = "ITC on CGST available for the payable on Value of Intra-state Supplies received")]
        public double itc_c { get; set; }

        //[Required]
        //[Display(Name = "ITC of SGST available in the current month")]
        //public int tc_s { get; set; }                         -------------changed by tc_s--------------------

        [Required]
        [Display(Name = "ITC on SGST available for the payable on Value of Intra-state Supplies received")]
        public double itc_s { get; set; }

        [Required]
        [Display(Name = "CESS on Value of Inter-state Supplies received")]
        public double cess { get; set; }

        [Required]
        [Display(Name = "ITC of CESS available  for the payable on Value of Intra-state Supplies received")]
        public double itc_cs { get; set; }
    }
}