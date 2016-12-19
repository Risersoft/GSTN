using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace GSTN.API.GSTR1
{
    public class ItmDet
    {

        [Required]
        [Display(Name = "Identifier if Goods or Services")]
        public string ty { get; set; }

        [Required]
        [Display(Name = "HSN or SAC of Goods or Services as per Invoice line items")]
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
    }

    public class Itm
    {
        [Required]
        [Display(Name = "Serial no")]
        public int num { get; set; }
        [Required]
        [Display(Name = "Item Details")]
        public ItmDet itm_det { get; set; }
    }

    public class B2BInv
    {

        [Required]
        [Display(Name = "Supplier Invoice Number")]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string inum { get; set; }

        [Required]
        [Display(Name = "Supplier Invoice Date")]
        [RegularExpression("^((0[1-9]|[12][0-9]|3[01])[-](0[1-9]|1[012])[-]((19|20)\\d\\d))*$")]
        public string idt { get; set; }

        [Required]
        [Display(Name = "Supplier Invoice Value")]
        public double val { get; set; }

        [Required]
        [Display(Name = "Place of supply")]
        public string pos { get; set; }

        [Required]
        [Display(Name = "Reverse Charge")]
        public string rchrg { get; set; }

       
        [Required]
        [Display(Name = "Provisional assessment")]
        public string pro_ass { get; set; }
        [Required]
        public List<Itm> itms { get; set; }


        [Display(Name = "Checksum Value")]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string chksum { get; set; }
    }

    public class B2bOutward
    {

        [Required]
        [Display(Name = "GSTIN/UID of the Receiver taxpayer/UN,Govt Bodies")]
        [MaxLength(15)]
        [MinLength(15)]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string ctin { get; set; }
        [Required]
        public List<B2BInv> inv { get; set; }
    }
    
}