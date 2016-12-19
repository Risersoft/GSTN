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
        public string ctin { get; set; }

        [Required]
        [Display(Name = "Merchant ID")]
        [MaxLength(20)]
        public string mid { get; set; }

        [Required]
        [Display(Name = "Gross Value of Supplies")]
        public double sup_val { get; set; }

        [Required]
        [Display(Name = "Taxable Value on which TCS has been deducted")]
        public double tx_val { get; set; }

        [Required]
        [Display(Name = "IGST Rate as per invoice")]
        public double tcs_irt { get; set; }

        [Required]
        [Display(Name = "IGST Amount as per invoice")]
        public double tcs_iamt { get; set; }

        [Required]
        [Display(Name = "CGST Rate as per invoice")]
        public double tcs_crt { get; set; }

        [Required]
        [Display(Name = "CGST Amount as per invoice")]
        public double tcs_camt { get; set; }

        [Required]
        [Display(Name = "SGST Rate as per invoice")]
        public double tcs_srt { get; set; }

        [Required]
        [Display(Name = "SGST Amount as per invoice")]
        public double tcs_samt { get; set; }


        [Display(Name = "Invoice Check sum value")]
        [MaxLength(15)]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string chksum { get; set; }
    }

   
}