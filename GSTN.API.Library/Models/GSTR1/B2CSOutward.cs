using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace GSTN.API.GSTR1
{
    public class B2csOutward
    {

        [Required]
        [Display(Name = "Invoice Check sum value")]
        [MaxLength(15)]
        public string chksum { get; set; }

        [Required]
        [Display(Name = "Recipient state code")]
        [MaxLength(2)]
        [RegularExpression("^[a-zA-z]+$")]

        public string state_cd { get; set; }      
        [Required]
        [Display(Name = "Identifer if Goods or Services")]
        [MaxLength(1)]
        [RegularExpression("^[G/S]")]
        public string ty { get; set; }
        [Required]
        [Display(Name = "HSN or SAC of Goods or Services as per Invoice line items")]
        [MaxLength(10)]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string hsn_sc { get; set; }
        [Required]
        [Display(Name = "Taxable value of Goods or Service as per invoice")]
        public double txval { get; set; }
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
        [Display(Name = "GSTIN of the taxpayer")]
        [MaxLength(15)]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public double gstin { get; set; }

        [Required]
        [Display(Name = "Return Period")]
        [RegularExpression("^((0[1-9]|1[012])((19|20)\\d\\d))*$")]
        public double ret_pd { get; set; }

        [Required]
        [Display(Name = "Provisional assessment")]
        public string prs { get; set; }

        [Required]
        [Display(Name = "EcomOperator")]
        [MaxLength(15)]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string etin { get; set; }

        [Required]
        [Display(Name = "Cess Amount as per invoice")]
        public double csamt { get; set; }

        [Required]
        [Display(Name = "Cess Rate as per invoice")]
        public double csrt { get; set; }

        [Required]
        [Display(Name = "Type")]
        [MaxLength(2)]
        public string typ { get; set; }
    }

}