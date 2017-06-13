using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Risersoft.API.GSTN.GSTR3
{
    public class ItcCredit
    {
        [Required]
        [Display(Name = "Identifer if Goods Input , Capital Goods or Services")]
        [MaxLength(10)]
        public string ty { get; set; }

        [Required]
        [Display(Name = "IGST_Rate")]
        public double irt { get; set; }

        [Required]
        [Display(Name = "IGST_Tax Amount")]
        public double itx { get; set; }

        [Required]
        [Display(Name = "CGST_Rate")]
        public double crt { get; set; }

        [Required]
        [Display(Name = "CGST_Tax Amount")]
        public double ctx { get; set; }


        [Required]
        [Display(Name = "SGST_Rate")]
        public int srt { get; set; }

        [Required]
        [Display(Name = "SGST_Tax Amount")]
        public double stx { get; set; }

        [Required]
        [Display(Name = "CESS_Rate")]
        public int csrt { get; set; }

        [Required]
        [Display(Name = "CESS_Tax Amount")]
        public double cstx { get; set; }
    }
}