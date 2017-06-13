using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Risersoft.API.GSTN.GSTR3
{
    public class GSTR3_Submit
    {
        [Required]
        [Display(Name = "Gstin of the taxpayer")]
        [MaxLength(15)]
        public string Gstin { get; set; }

        [Required]
        [Display(Name = "Return period")]
        [MaxLength(10)]
        public string RetPeriod { get; set; }
    }
}