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
        [Display(Name = "cess Rate as per invoice")]
        public double csrt { get; set; }

        [Required]
        [Display(Name = "cess Amount as per invoice")]
        public double csamt { get; set; }
    }

    public class B2Bitem
    {
        [Required]
        [Display(Name = "Serial no")]
        public int num { get; set; }
        [Required]
        [Display(Name = "Item Details")]
        public ItmDet itm_det { get; set; }

        //in excel file 'status' prameter name exists

        //[Required]
        //[Display(Name = "Status of invoice")]
        //public int status { get; set; }
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
        public string prs { get; set; }


        [Display(Name = "EcomOperator")]
        [MaxLength(15)]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string etin { get; set; }

        [Required]
        [Display(Name = "Uploaded by")]
        public string updby { get; set; }

        [Required]
        [Display(Name = "Invoice Status")]
        public string flag { get; set; }

        [Required]
        [Display(Name = "Items")]
        public List<B2Bitem> itms { get; set; }


        [Display(Name = "Checksum Value")]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string chksum { get; set; }
    }

    public class B2bOutward
    {

        [Required]
        [Display(Name = "Counter party GSTIN")]
        [MaxLength(15)]
        [MinLength(15)]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string ctin { get; set; }

        [Required]
        [Display(Name = "GSTR2 filing status of counter party")]
        [RegularExpression("^[a-zA-Z]+$")]
        public string cfs { get; set; }

        [Required]
        [Display(Name = "Invoice Details")]
        public List<B2BInv> inv { get; set; }
    }

}