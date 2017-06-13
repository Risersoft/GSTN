using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Risersoft.API.GSTN.GSTR3
{
    public class Tod
    {

        [Required]
        [Display(Name = "Gross Turnover")]
        public double gr_to { get; set; }

        [Required]
        [Display(Name = "Export Turnover")]
        public double exp_to { get; set; }


        [Required]
        [Display(Name = "Nil rated and Exempted Domestic Turnover")]
        public double nil_to { get; set; }

        [Required]
        [Display(Name = "Non GST Turnover")]
        public double non_to { get; set; }

        [Required]
        [Display(Name = "Net Taxable Turnover")]
        public double net_to { get; set; }
    }
}