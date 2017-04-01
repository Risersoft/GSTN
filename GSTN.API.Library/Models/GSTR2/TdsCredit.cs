using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace GSTN.API.GSTR2
{
    public class TdsInvoice
    {

        [Required]
        [Display(Name = "GSTIN/UID of the Receiver taxpayer/UN,Govt Bodies")]
        [MaxLength(15)]
        [MinLength(15)]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string ctin { get; set; }

        [Required]
        [Display(Name = "Invoice/Document detail number")]
        [MaxLength(10)]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string i_num { get; set; }

        [Required]
        [Display(Name = "Invoice/Document detail date")]
        [RegularExpression("^((0[1-9]|[12][0-9]|3[01])[-](0[1-9]|1[012])[-]((19|20)\\d\\d))*$")]
        public string i_dt { get; set; }

        [Required]
        [Display(Name = "Invoice Value")]
        public double i_val { get; set; }

        [Required]
        [Display(Name = "Date of payment of tax")]
        [RegularExpression("^((0[1-9]|[12][0-9]|3[01])[-](0[1-9]|1[012])[-]((19|20)\\d\\d))*$")]
        public string pay_dt { get; set; }

        [Required]
        [Display(Name = "Value on which TDS is to be deducted")]
        public double tds_val { get; set; }

        [Required]
        [Display(Name = "IGST Rate as per invoice")]
        public int irt { get; set; }

        [Required]
        [Display(Name = "IGST Amount as per invoice")]
        public int iamt { get; set; }

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
        [Display(Name = "Checksum Value")]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string chksum { get; set; }
    }

    public class TdsCredit
    {

        [Required]
        [Display(Name = "TIN of the deductor")]
        [MaxLength(15)]
        [MinLength(15)]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string ctin { get; set; }


        [Display(Name = "TDS Invoces")]
        public List<TdsInvoice> tds_invoices { get; set; }
    }

}