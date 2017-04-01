using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace GSTN.API.GSTR1
{



    public class ATmDet
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

        [Required]
        [Display(Name = "Amount of Advance received")]
        public int ad_amt { get; set; }
    }
    public class ATitemdtl
    {

        [Required]
        [Display(Name = "Item Details")]
        public ATmDet itm_det { get; set; }

        //in excel file 'status' prameter name exists

        //[Required]
        //[Display(Name = "Status of invoice")]
        //public int status { get; set; }
    }
    public class AtOutward
    {

        [Required]
        [Display(Name = "GSTIN of the taxpayer")]
        [MaxLength(15)]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string gstin { get; set; }

        [Required]
        [Display(Name = "Return Period")]
        [RegularExpression("^((0[1-9]|1[012])((19|20)\\d\\d))*$")]
        public string ret_pd { get; set; }

        [Required]
        [Display(Name = "Invoice type")]
        [MaxLength(3)]
        public string typ { get; set; }

        [Required]
        [Display(Name = "Counter party GSTIN or name")]
        [MaxLength(50)]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string cpty { get; set; }

        [Required]
        [Display(Name = "Recipient State Code")]
        [MaxLength(2)]
        public string state_cd { get; set; }

        [Required]
        [Display(Name = "Supplier Document Number")]
        [MaxLength(50)]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string doc_num { get; set; }

        [Required]
        [Display(Name = "Supplier Document Date")]
        [RegularExpression("^((0[1-9]|[12][0-9]|3[01])[-](0[1-9]|1[012])[-]((19|20)\\d\\d))*$")]
        public string doc_dt { get; set; }

        [Required]
        [Display(Name = "Item Details")]
        public List<ATitemdtl> itms { get; set; }


        [Display(Name = "Invoice Check sum value")]
        [MaxLength(15)]
        public string Chksum { get; set; }
    }


}