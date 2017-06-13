using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Risersoft.API.GSTN.GSTR3
{
    public class Exp
    {
        [Required]
        [Display(Name = "Identifer if Goods or Services")]
        [RegularExpression("^[a-zA-z]+$")]
        public string ty { get; set; }

        [Required]
        [Display(Name = "Taxable value of Goods or Service as per invoice")]
        public double txval { get; set; }

        [Required]
        [Display(Name = "IGST paid for Export of services")]
        public double iamt { get; set; }

        [Required]
        [Display(Name = "CGST paid for Export of services")]
        public double camt { get; set; }

        [Required]
        [Display(Name = "SGST paid for Export of services")]
        public double samt { get; set; }

        //[Required]
        //[Display(Name = "Description like Goods or Serivces with or without payment of GST")]
        //public string ex_ty { get; set; }                                 -----------------deleted---------

        [Required]
        [Display(Name = "Export of services with/without payment of GST indicator")]
        [MaxLength(5)]
        public string ex_tp { get; set; }

        [Required]
        [Display(Name = "CESS paid for Export of services")]
        public double cess { get; set; }
    }
}