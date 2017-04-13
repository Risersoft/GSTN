using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GSTN.API.GSTR3
{
    public class IntrSupConReg
    {
        [Required]
        [Display(Name = "Identifer if Goods or Services")]
        [RegularExpression("^[a-zA-z]+$")]
        public string ty { get; set; }

        [Required]
        [Display(Name = "State Code")]
        public string state_cd { get; set; }

        //[Required]
        //[Display(Name = "Rate of Tax")]
        //public int txrt { get; set;}                 ---------------changed by tx_r-----------                     


        [Required]
        [Display(Name = "Rate of Tax")]
        public double tx_r { get; set; }

        //[Required]
        //[Display(Name = "Invoice Value")]
        //public int val { get; set; }                      ------- changed by txval----------------

        [Required]
        [Display(Name = "taxable vlaue")]
        public double txval { get; set; }

        [Required]
        [Display(Name = "IGST on Total Taxable value of Inter-state supply of goods to Consumers")]
        public double iamt { get; set; }

        //[Required]
        //[Display(Name = "Add.Tax_Amount as per invoice")]
        //public int aamt { get; set; }                     -----------------deleted--------------------

        [Required]
        [Display(Name = "CESS on Value of Intra-State Supply of goods to Registered taxpayers")]
        public double cess { get; set; }
    }
}