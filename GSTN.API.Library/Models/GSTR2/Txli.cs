using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
namespace Risersoft.API.GSTN.GSTR2
{
    public class TxliItm
    {

        [Required]
        [Display(Name = "Identifier if Goods or Services")]
        public string ty { get; set; }

        [Required]
        [Display(Name = "HSN or SAC of Goods or Services")]
        public string hsn_sc { get; set; }

        [Required]
        [Display(Name = "Taxable value of Goods or Service")]
        public double txval { get; set; }

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
        [Display(Name = "Cess Rate as per invoice")]
        public double csrt { get; set; }

        [Required]
        [Display(Name = "Cess Amount as per invoice")]
        public double csamt { get; set; }
    }

    public class Txli
    {
        [Required]
        [Display(Name = "Counter party")]
        [MaxLength(30)]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string cpty { get; set; }

        [Required]
        [Display(Name = "Registration Type")]
        public string reg_type { get; set; }

        [Required]
        [Display(Name = "Placeof supply State Code")]
        [MaxLength(2)]
        public int state_cd { get; set; }

        [Required]
        [Display(Name = "Supplier Document Number")]
        public string dnum { get; set; }

        [Required]
        [Display(Name = "Supplier Document Date")]
        public string dt { get; set; }

        [Required]
        [Display(Name = "Item Details")]
        public List<TxliItm> itms { get; set; }

        [Required]
        [Display(Name = "Checksum Value")]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string chksum { get; set; }
    }


}