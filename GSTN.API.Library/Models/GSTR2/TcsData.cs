using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace GSTN.API.GSTR2
{
    public class TcsData
    {

        [Required]
        [Display(Name = "GSTIN of E-commerce portal")]
        [MaxLength(15)]
        [MinLength(15)]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string etin { get; set; }

        [Required]
        [Display(Name = "Merchant ID allocated by e-commerce portal")]
        [MaxLength(20)]
        public string m_id { get; set; }

        [Required]
        [Display(Name = "Gross Value of Supplies")]
        public double sup_val { get; set; }

        [Required]
        [Display(Name = "Taxable Value on which TCS has been deducted")]
        public double tx_val { get; set; }

        [Required]
        [Display(Name = "TCS_IGST rate")]
        public double irt { get; set; }

        [Required]
        [Display(Name = "TCS_IGST amount")]
        public int iamt { get; set; }

        [Required]
        [Display(Name = "TCS_CGST rate")]
        public double crt { get; set; }

        [Required]
        [Display(Name = "TCS_CGST amount")]
        public double camt { get; set; }

        [Required]
        [Display(Name = "TCS_SGST rate")]
        public double srt { get; set; }

        [Required]
        [Display(Name = "TCS_SGST amount")]
        public double samt { get; set; }

        [Required]
        [Display(Name = "TCS_Cess rate")]
        public double csrt { get; set; }

        [Required]
        [Display(Name = "TCS_Cess amount")]
        public double csamt { get; set; }


        [Display(Name = "Invoice Check sum value")]
        [MaxLength(15)]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string chksum { get; set; }
    }


}