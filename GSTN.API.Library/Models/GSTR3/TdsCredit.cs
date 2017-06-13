using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Risersoft.API.GSTN.GSTR3
{
    public class TdsCredit
    {
        [Required]
        [Display(Name = "GSTIN of the TDS deducter")]
        [MaxLength(15)]
        public string gstin { get; set; }

        [Required]
        [Display(Name = "IGST_Rate of TDS")]
        public double irt { get; set; }

        [Required]
        [Display(Name = "IGST_Tax Amount of TDS")]
        public double itx { get; set; }

        [Required]
        [Display(Name = "CGST_Rate of TDS")]
        public double crt { get; set; }

        [Required]
        [Display(Name = "CGST_Tax Amount of TDS")]
        public double ctx { get; set; }


        [Required]
        [Display(Name = "SGST_Rate of TDS")]
        public int srt { get; set; }

        [Required]
        [Display(Name = "SGST_Tax Amount of TDS")]
        public double stx { get; set; }

        [Required]
        [Display(Name = "CESS_Rate of TDS")]
        public int csrt { get; set; }

        [Required]
        [Display(Name = "CESS_Tax Amount of TDS")]
        public double cstx { get; set; }
    }
}