using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace Risersoft.API.GSTN.GSTR1
{
    public class CdnInv
    {

        [Required]
        [Display(Name = "Credit/debit note type")]
        public string ntty { get; set; }

        [Required]
        [Display(Name = "flag denoting whether Invoice is accepted-A, rejected-R, Modified-M or No Action-N")]
        public string flag { get; set; }

        [Required]
        [Display(Name = "Invoice Uploader")]
        public string updby { get; set; }

        [Required]
        [Display(Name = "Debit Note/Credit Note No.")]
        [MaxLength(10)]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string nt_num { get; set; }

        [Required]
        [Display(Name = "Credit/Debit date")]
        [RegularExpression("^((0[1-9]|[12][0-9]|3[01])[-](0[1-9]|1[012])[-]((19|20)\\d\\d))*$")]
        public string nt_dt { get; set; }

        [Required]
        [Display(Name = "Reason Code for issuing Debit/Credit Note")]
        [MaxLength(30)]
        public string rsn { get; set; }

        [Required]
        [Display(Name = "Reverse Charge")]
        public string rchrg { get; set; }

        [Required]
        [Display(Name = "Original invoice number")]
        [MaxLength(50)]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string inum { get; set; }

        [Required]
        [Display(Name = "Invoice date")]
        [RegularExpression("^((0[1-9]|[12][0-9]|3[01])[-](0[1-9]|1[012])[-]((19|20)\\d\\d))*$")]
        public string idt { get; set; }

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


        [Required]
        [Display(Name = "Cess Rate as per invoice")]
        public double csrt { get; set; }

        [Required]
        [Display(Name = "Cess Amount as per invoice")]
        public double csamt { get; set; }

        [Required]
        [Display(Name = "Ecom gstin")]
        [MaxLength(15)]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string etin { get; set; }



        [Display(Name = "Checksum Value")]
        [MaxLength(15)]
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
        public string gstin { get; set; }

        //[Required]                                                   ---------Not mandatory---------------------
        [Display(Name = "Counter party GSTIN")]
        [MaxLength(15)]
        [MinLength(15)]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string ctin { get; set; }


        [Display(Name = "from which time taxpayer want Invoices")]
        [RegularExpression("^((0[1-9]|[12][0-9]|3[01])[-](0[1-9]|1[012])[-]((19|20)\\d\\d))*$")]
        public string from_time { get; set; }

        [Required]
        [Display(Name = "GSTR2 filing status of counter party")]
        [MaxLength(1)]
        [RegularExpression("^[a-zA-Z]+$")]
        public string cfs { get; set; }

        [Required]
        [Display(Name = "Credit/Debit Notes Details")]
        public List<CdnInv> cdn { get; set; }
    }
}