using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace GSTN.API.GSTR2
{
    public class ImpGItm
    {

        [Required]
        [Display(Name = "Serial no")]
        public int Num { get; set; }

        [Required]
        [Display(Name = "HSN of Goods as per Invoice line items")]
        [MaxLength(10)]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string hsn_sc { get; set; }

        [Required]
        [Display(Name = "Taxable value of Goods/Service as per invoice")]
        public double txval { get; set; }

        [Required]
        [Display(Name = "IGST Rate as per Bill of Entry")]
        public double irt { get; set; }

        [Required]
        [Display(Name = "IGST Amount as per Bill of Entry")]
        public double iamt { get; set; }
        [Required]
        [Display(Name = "CESS rate")]
        public double csrt { get; set; }
        [Required]
        [Display(Name = "CESS amount")]
        public double csamt { get; set; }

        [Required]
        [Display(Name = "Eligibility of Total Tax available as ITC")]
        public string elg { get; set; }

        [Required]
        [Display(Name = "Total Input Tax Credit available based on the bill of entry uploaded(IGST)")]
        public double tx_i { get; set; }

        [Required]
        [Display(Name = "Total Input Tax Credit available for claim this month based on the bill of entry uploaded")]
        public double tc_i { get; set; }

        [Required]
        [Display(Name = "Total CESS available as ITC ")]
        public double tx_cs { get; set; }

        [Required]
        [Display(Name = "ITC available as CESS this month")]
        public double tc_cs { get; set; }
    }

    public class ImpG
    {

        [Required]
        [Display(Name = "Bill of Entry Number")]
        [MaxLength(50)]
        public int boe_num { get; set; }

        [Required]
        [Display(Name = "Bill of Entry Date")]
        [RegularExpression("^((0[1-9]|[12][0-9]|3[01])[-](0[1-9]|1[012])[-]((19|20)\\d\\d))*$")]
        public string boe_dt { get; set; }

        [Required]
        [Display(Name = "Port Code")]
        public string port_code { get; set; }

        [Required]
        [Display(Name = "Bill of Entry Value")]
        public double boe_val { get; set; }

        [Required]
        [Display(Name = "Bill Item Details")]
        public List<ImpGItm> itms { get; set; }


        [Display(Name = "Invoice Check sum value")]
        [MaxLength(15)]
        public string chksum { get; set; }
    }


}