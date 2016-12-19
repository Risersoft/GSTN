using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace GSTN.API.GSTR2
{
    public class ImpSItm
    {

        [Required]
        [Display(Name = "Serial no")]
        public int Num { get; set; }

        [Required]
        [Display(Name = "SAC of Goods as per Invoice line items")]
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
        [Display(Name = "Eligibility of Total Tax available as ITC")]
        public string elg { get; set; }

        [Required]
        [Display(Name = "Total ITC admissible")]
        public double tia { get; set; }

        [Required]
        [Display(Name = "ITC admissible this month")]
        public double iam { get; set; }
    }

    public class ImpS
    {

        [Required]
        [Display(Name = "Invoice number")]
        [MaxLength(10)]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string i_num { get; set; }

        [Required]
        [Display(Name = "Invoice date")]
        [RegularExpression("^((0[1-9]|[12][0-9]|3[01])[-](0[1-9]|1[012])[-]((19|20)\\d\\d))*$")]
        public string i_dt { get; set; }

        [Required]
        [Display(Name = "Invoice Value")]
        public double i_val { get; set; }

        [Required]
        [Display(Name = "itms")]
        public List<ImpSItm> itms { get; set; }


        [Display(Name = "Invoice Check sum value")]
        [MaxLength(15)]
        public string chksum { get; set; }
    }


}