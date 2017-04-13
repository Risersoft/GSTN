using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GSTN.API.GSTR3
{
    public class IntraSupConReg
    {
        [Required]
        [Display(Name = "Identifer if Goods or Services")]
        [RegularExpression("^[a-zA-z]+$")]
        public string ty { get; set; }

        //[Required]
        //[Display(Name = "Rate of Tax")]
        //public int txrt { get; set;}                 ---------------changed by tx_r-----------                     


        [Required]
        [Display(Name = "Goods Tax Rate ")]
        public double tx_r { get; set; }



        //[Required]
        //[Display(Name = "Invoice Value")]
        //public int val { get; set; }                      ------- changed by txval----------------

        [Required]
        [Display(Name = "Value of Intra-State Supply of goods to consumers")]
        public double txval { get; set; }

        [Required]
        [Display(Name = "CGST on Value of Intra-State Supply of goods to consumers")]
        public double camt { get; set; }

        [Required]
        [Display(Name = "SGST on Value of Intra-State Supply of goods to consumers")]
        public double samt { get; set; }

        [Required]
        [Display(Name = "CESS on Value of Intra-State Supply of goods to consumers")]
        public double cess { get; set; }
    }
}