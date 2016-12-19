using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace GSTN.API.GSTR1
{
    public class B2csOutward
    {
        [Required]
        [Display(Name = "Identifer if Goods or Services")]
        [RegularExpression("^[a-zA-z]+$")]
        public string ty { get; set; }
        [Required]
        [Display(Name = "HSN or SAC of Goods or Services as per Invoice line items")]
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
        [Display(Name = "Provisional assessment")]
        public string pro_ass { get; set; }
    }

}