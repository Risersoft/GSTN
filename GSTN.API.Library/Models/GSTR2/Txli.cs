using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
namespace GSTN.API.GSTR2
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
    }

    public class Txli
    {

        [Required]
        [Display(Name = "GSTIN of unregistered supplier")]
        public string rtin { get; set; }

        [Required]
        [Display(Name = "Name of Unregistered supplier")]
        public string rname { get; set; }

        [Required]
        [Display(Name = "State Code")]
        public int st_cd { get; set; }

        [Required]
        [Display(Name = "Document No.")]
        public string dnum { get; set; }

        [Required]
        [Display(Name = "Document Date")]
        public string dt { get; set; }

        [Required]
        public List<TxliItm> itms { get; set; }

        [Required]
        [Display(Name = "Checksum Value")]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string chksum { get; set; }
    }


}