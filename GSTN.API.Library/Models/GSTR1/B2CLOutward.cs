using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace GSTN.API.GSTR1
{

    public class B2CLInv
    {
        [Required]
        [Display(Name = "Counterparty Name")]
        [MaxLength(100)]
        [RegularExpression("^[a-zA-Z._\\s]+$")]
        public string cname { get; set; }

        [Required]
        [Display(Name = "Supplier Invoice Number")]
        [MaxLength(50)]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string inum { get; set; }

        [Required]
        [Display(Name = "Revised Supplier Invoice Date")]
        [RegularExpression("^((0[1-9]|[12][0-9]|3[01])[-](0[1-9]|1[012])[-]((19|20)\\d\\d))*$")]
        public string idt { get; set; }

        [Required]
        [Display(Name = "Revised Supplier Invoice Value")]
        public double val { get; set; }

        [Required]
        [Display(Name = "Place of supply")]
        [MaxLength(2)]
        public string pos { get; set; }

        [Required]
        [Display(Name = "Provisional assessment")]
        [MaxLength(1)]
        public string prs { get; set; }

        [Required]
        [Display(Name = "EcomOperator")]
        [MaxLength(15)]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string etin { get; set; }

        [Required]
        public List<B2CLitem> itms { get; set; }

        [Display(Name = "Checksum Value")]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string chksum { get; set; }
    }
    public class B2CLItmDet
    {

        [Required]
        [Display(Name = "Identifier if Goods or Services")]
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
        [Display(Name = "cess Rate as per invoice")]
        public double cssrt { get; set; }

        [Required]
        [Display(Name = "cess Amount as per invoice")]
        public double csamt { get; set; }
    }
    public class B2CLitem
    {
        [Required]
        [Display(Name = "Serial no")]
        public int num { get; set; }
        [Required]
        [Display(Name = "Item Details")]
        public B2CLItmDet itm_det { get; set; }

        //in excel file 'status' prameter name exists

        //[Required]
        //[Display(Name = "Status of invoice")]
        //public int status { get; set; }
    }
    public class B2clOutward
    {

        [Required]
        [Display(Name = "Receipient State Code")]
        [MaxLength(2)]
        public string state_cd { get; set; }

        [Required]
        [Display(Name = "Invoice Details")]
        public List<B2CLInv> inv { get; set; }
    }


}