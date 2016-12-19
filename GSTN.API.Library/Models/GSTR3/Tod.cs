using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSTN.API.GSTR3
{
    public class Tod
    {

        [Required]
        [Display(Name = "Gross Turnover of the taxpayer in the previous FY")]
        public double gt { get; set; }

        [Required]
        [Display(Name = "Export Turnover")]
        public double et { get; set; }

        [Required]
        [Display(Name = "Nil rated and Exempted Domestic Turnover")]
        public double nil_edt { get; set; }

        [Required]
        [Display(Name = "Non GST Turnover")]
        public double ngt { get; set; }

        [Required]
        [Display(Name = "Net Taxable Turnover")]
        public double ntt { get; set; }
    }
}
