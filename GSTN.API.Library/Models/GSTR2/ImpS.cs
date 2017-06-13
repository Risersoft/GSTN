using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace Risersoft.API.GSTN.GSTR2
{
    public class ImpSItm
    {

        [Required]
        [Display(Name = "Serial no")]
        public int num { get; set; }

        [Required]
        [Display(Name = "SAC code")]
        [MaxLength(10)]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string sac { get; set; }

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
        [Display(Name = "Total ITC admissible")]
        public int tx_i { get; set; }

        [Required]
        [Display(Name = "ITC admissible this month")]
        public double tc_i { get; set; }

        [Required]
        [Display(Name = "Total CESS available as ITC ")]
        public double tx_cs { get; set; }

        [Required]
        [Display(Name = "ITC available as CESS this month")]
        public double tc_cs { get; set; }
    }

    public class ImpS
    {

        [Required]
        [Display(Name = "Invoice number")]
        [MaxLength(10)]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string inum { get; set; }

        [Required]
        [Display(Name = "Invoice date")]
        [RegularExpression("^((0[1-9]|[12][0-9]|3[01])[-](0[1-9]|1[012])[-]((19|20)\\d\\d))*$")]
        public string idt { get; set; }

        [Required]
        [Display(Name = "Invoice Value")]
        public double ival { get; set; }

        [Required]
        [Display(Name = "Item Details")]
        public List<ImpSItm> itms { get; set; }


        [Display(Name = "Invoice Check sum value")]
        [MaxLength(15)]
        public string chksum { get; set; }
    }


}