using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace GSTN.API.GSTR1
{
    public class CdnInv
    {

        [Required]
        [Display(Name = "Note Type")]
        public string ntty { get; set; }

        [Required]
        [Display(Name = "Debit Note/Credit Note No.")]
        public string ntnum { get; set; }

        [Required]
        [Display(Name = "Credit/Debit date")]
        public string cddt { get; set; }

        [Required]
        [Display(Name = "Reason Code for issuing Debit/Credit Note")]
        public string rsn { get; set; }

        [Required]
        [Display(Name = "Original invoice number")]
        public string num { get; set; }

        [Required]
        [Display(Name = "Invoice date")]
        public string dt { get; set; }

        [Required]
        [Display(Name = "Differential Value for which Dr./ Cr. note is issued")]
        public double val { get; set; }

        [Required]
        [Display(Name = "IGST Rate as per invoice")]
        public double irt { get; set; }

        [Required]
        [Display(Name = "IGST Amount as per invoice")]
        public double iamt { get; set; }

        [Required]
        [Display(Name = "CGST Rate as per invoice")]
        public double crt { get; set; }

        [Required]
        [Display(Name = "CGST Amount as per invoice")]
        public double camt { get; set; }

        [Required]
        [Display(Name = "SGST Rate as per invoice")]
        public double srt { get; set; }

        [Required]
        [Display(Name = "SGST Amount as per invoice")]
        public double samt { get; set; }


        [Display(Name = "Checksum Value")]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string chksum { get; set; }
    }

    public class CdnOutward
    {

        [Required]
        [Display(Name = "Counter party GSTIN")]
        [MaxLength(15)]
        [MinLength(15)]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string cgstin { get; set; }

        [Required]
        [Display(Name = "Type of invoices")]
        public string typ { get; set; }

        [Required]
        [Display(Name = "Name of the Receiver taxpayer")]
        public string cname { get; set; }

        [Required]
        public List<CdnInv> cdn { get; set; }
    }

    
}