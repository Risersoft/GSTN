using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Risersoft.API.GSTN.GSTR3
{
    public class JobWork
    {
        [Required]
        [Display(Name = "Output tax added/reduced due to  mismatched")]
        [MaxLength(10)]
        public string desc { get; set; }

        [Required]
        [Display(Name = "IGST Amount")]
        public double iamt { get; set; }

        [Required]
        [Display(Name = "IGST Interest")]
        public double i_int { get; set; }

        [Required]
        [Display(Name = "CGST Amount")]
        public double camt { get; set; }

        [Required]
        [Display(Name = "CGST Interest")]
        public double c_int { get; set; }

        [Required]
        [Display(Name = "SGST Amount")]
        public double samt { get; set; }




        [Required]
        [Display(Name = "SGST Interest")]
        public double s_int { get; set; }





        [Required]
        [Display(Name = "CESS Amount")]
        public double csamt { get; set; }






        [Required]
        [Display(Name = "CESS Interest")]
        public double cs_int { get; set; }
    }
}