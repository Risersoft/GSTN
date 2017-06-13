using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Risersoft.API.GSTN.GSTR3
{
    public class RfClm : RfClm2
    {

        [Required]
        [Display(Name = "Gstin of the taxpayer")]
        [MaxLength(10)]
        public string gstin { get; set; }

        [Required]
        [Display(Name = "Return period")]
        [MaxLength(10)]
        public string ret_period { get; set; }

        [Required]
        [Display(Name = "Debit Number")]
        [MaxLength(16)]
        public double debitno { get; set; }
    }
}