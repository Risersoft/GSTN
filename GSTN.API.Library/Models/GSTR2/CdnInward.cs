using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
namespace GSTN.API.GSTR2
{


    public class CdnInv
    {
        [Required]
        [Display(Name = "flag for accepting or rejecting a invoice")]
        [MaxLength(1)]
        public string flag { get; set; }

        [Required]
        [Display(Name = "Note type")]
        [MaxLength(1)]
        [MinLength(1)]
        public string ntty { get; set; }

        [Required]
        [Display(Name = "Debit/Credit Note number")]
        [MaxLength(50)]
        public int nt_num { get; set; }

        [Required]
        [Display(Name = "Credit date")]
        [RegularExpression("^((0[1-9]|[12][0-9]|3[01])[-](0[1-9]|1[012])[-]((19|20)\\d\\d))*$")]
        public string nt_dt { get; set; }

        [Required]
        [Display(Name = "Invoice Number")]
        [MaxLength(50)]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string inum { get; set; }

        [Required]
        [Display(Name = "Invoice Date")]
        [RegularExpression("^((0[1-9]|[12][0-9]|3[01])[-](0[1-9]|1[012])[-]((19|20)\\d\\d))*$")]
        public string idt { get; set; }

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
        public int crt { get; set; }

        [Required]
        [Display(Name = "camt")]
        public int camt { get; set; }

        [Required]
        [Display(Name = "srt")]
        public int srt { get; set; }

        [Required]
        [Display(Name = "samt")]
        public int samt { get; set; }
        [Required]
        [Display(Name = "CESS Rate as per invoice")]
        public int csrt { get; set; }


        [Required]
        [Display(Name = "CESS Amount as per invoice")]
        public int csamt { get; set; }

        [Required]
        [Display(Name = "Invoice Uploader")]
        public string updby { get; set; }

        [Required]
        [Display(Name = "Reverse Charge")]
        public string rchrg { get; set; }
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

    public class CdnInward
    {

        [Required]
        [Display(Name = "Counter party GSTIN")]
        [MaxLength(15)]
        [MinLength(15)]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string ctin { get; set; }

        [Required]
        [Display(Name = "counter party Filing Status")]
        public string cfs { get; set; }

        [Required]
        [Display(Name = "Credit/Debit Notes")]
        public List<CdnInv> cdn { get; set; }
    }



}