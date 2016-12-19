using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace GSTN.API.GSTR1
{
    public class TxpOutward
    {

        [Required]
        [Display(Name = "Flag for action")]
        public string flag { get; set; }

        [Required]
        [Display(Name = "Invoice Number")]
        public string num { get; set; }

        [Required]
        [Display(Name = "Supplier Document Number")]
        public string doc_num { get; set; }

        [Required]
        [Display(Name = "Supplier Document Date")]
        public string doc_dt { get; set; }

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


        [Display(Name = "Checksum value")]
        public string chksum { get; set; }
    }

 
}