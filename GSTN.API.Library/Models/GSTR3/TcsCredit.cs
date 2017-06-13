using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Risersoft.API.GSTN.GSTR3
{
    public class TcsCredit
    {
        [Required]
        [Display(Name = "GSTIN of the Ecommerce")]
        [MaxLength(15)]
        public string gstin_ec { get; set; }

        [Required]
        [Display(Name = "IGST_Rate of TCS")]
        public double irt { get; set; }

        [Required]
        [Display(Name = "IGST_Tax Amount of TCS")]
        public double itx { get; set; }

        [Required]
        [Display(Name = "CGST_Rate of TCS")]
        public double crt { get; set; }

        [Required]
        [Display(Name = "CGST_Tax Amount of TCS")]
        public double ctx { get; set; }


        [Required]
        [Display(Name = "SGST_Rate of TCS")]
        public int srt { get; set; }

        [Required]
        [Display(Name = "SGST_Tax Amount of TCS")]
        public double stx { get; set; }

        [Required]
        [Display(Name = "CESS_Rate of TCS")]
        public int csrt { get; set; }

        [Required]
        [Display(Name = "CESS_Tax Amount of TCS")]
        public double cstx { get; set; }
    }
}