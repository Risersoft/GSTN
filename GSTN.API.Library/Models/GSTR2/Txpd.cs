using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace Risersoft.API.GSTN.GSTR2
{
    public class Txpd
    {

        [Required]
        [Display(Name = "Invoice Number")]
        [MaxLength(10)]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string i_num { get; set; }

        [Required]
        [Display(Name = "Invoice date")]
        [RegularExpression("^((0[1-9]|[12][0-9]|3[01])[-](0[1-9]|1[012])[-]((19|20)\\d\\d))*$")]
        public string i_dt { get; set; }

        [Required]
        [Display(Name = "Document Number")]
        [MaxLength(50)]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string doc_num { get; set; }

        [Required]
        [Display(Name = "Document Date")]
        [RegularExpression("^((0[1-9]|[12][0-9]|3[01])[-](0[1-9]|1[012])[-]((19|20)\\d\\d))*$")]
        public string doc_dt { get; set; }


        [Required]
        [Display(Name = "IGST Rate")]
        public double irt { get; set; }

        [Required]
        [Display(Name = "IGST Amount")]
        public double iamt { get; set; }

        [Required]
        [Display(Name = "CGST Rate")]
        public double crt { get; set; }

        [Required]
        [Display(Name = "CGST Amount")]
        public double camt { get; set; }

        [Required]
        [Display(Name = "SGST Rate")]
        public double srt { get; set; }

        [Required]
        [Display(Name = "SGST Amount")]
        public double samt { get; set; }

        [Required]
        [Display(Name = "CESS Rate as per invoice")]
        public double csrt { get; set; }

        [Required]
        [Display(Name = "CESS Amount as per invoice")]
        public double csamt { get; set; }

        [Required]
        [Display(Name = "Invoice Check sum value")]
        [MaxLength(15)]
        public string chksum { get; set; }
    }


}