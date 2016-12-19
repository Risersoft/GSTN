using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
//some porperties of this class is more than with schema
namespace GSTN.API.GSTR2
{
    public class CdnAInward
    {

        [Required]
        [Display(Name = "Counter party GSTIN")]
        [MaxLength(15)]
        [MinLength(15)]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string cgstin { get; set; }

        [Required]
        [Display(Name = "Supply Type of invoices")]
        [MaxLength(5)]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string typ { get; set; }

        [Required]
        [Display(Name = "Receipient Name (in case of B2C)")]
        [MaxLength(90)]
        public string cname { get; set; }

        [Required]
        [Display(Name = "Note type")]
        [MaxLength(1)]
        [MinLength(1)]
        public string ty { get; set; }

        [Required]
        [Display(Name = "Debit/Credit Note number")]
        [MaxLength(50)]
        public string nt_num { get; set; }

        [Required]
        [Display(Name = "Credit date")]
        [RegularExpression("^((0[1-9]|[12][0-9]|3[01])[-](0[1-9]|1[012])[-]((19|20)\\d\\d))*$")]
        public string nt_dt { get; set; }

        [Required]
        [Display(Name = "Original Debit/Credit note number")]
        [MaxLength(50)]
        public string ont_num { get; set; }

        [Required]
        [Display(Name = "Original Debit/Credit date")]
        [RegularExpression("^((0[1-9]|[12][0-9]|3[01])[-](0[1-9]|1[012])[-]((19|20)\\d\\d))*$")]
        public string ont_dt { get; set; }

        [Required]
        [Display(Name = "rsn")]
        public string rsn { get; set; }

        [Required]
        [Display(Name = "val")]
        public double val { get; set; }

        [Required]
        [Display(Name = "irt")]
        public double irt { get; set; }

        [Required]
        [Display(Name = "iamt")]
        public double iamt { get; set; }

        [Required]
        [Display(Name = "crt")]
        public double crt { get; set; }

        [Required]
        [Display(Name = "camt")]
        public double camt { get; set; }

        [Required]
        [Display(Name = "srt")]
        public double srt { get; set; }

        [Required]
        [Display(Name = "samt")]
        public double samt { get; set; }

        [Required]
        [Display(Name = "elg")]
        public string elg { get; set; }

        [Required]
        [Display(Name = "itc")]
        public Itc itc { get; set; }

        [Required]
        [Display(Name = "Invoice Check sum value")]
        [MaxLength(15)]
        public string chksum { get; set; }
    }

   
}