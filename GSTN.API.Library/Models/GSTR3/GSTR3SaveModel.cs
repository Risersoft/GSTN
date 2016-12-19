using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSTN.API.GSTR3
{
    public class GSTR3SaveModel
    {

        [Required]
        [Display(Name = "Supplier GSTIN")]
        [MaxLength(15)]
        [MinLength(15)]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string gstin { get; set; }

        [Required]
        [Display(Name = "Name of Taxpayer")]
        [RegularExpression("^[a-zA-Z0-9\\s]+$")]
        public string name { get; set; }

        [Required]
        [Display(Name = "Address of Taxpayer")]
        public string add { get; set; }

        [Required]
        [Display(Name = "Finalcial Period")]
        [MaxLength(10)]
        [MinLength(3)]
        [RegularExpression("^[0-9]+$")]
        public string fp_fm { get; set; }

        [Required]
        [Display(Name = "Financial Year")]
        [RegularExpression("^[0-9\\-]+$")]
        public string fp_fy { get; set; }

        [Required]
        [Display(Name = "Turn Over Details")]
        public Tod tod { get; set; }

        [Required]
        [Display(Name = "Total Tax Liability")]
        public List<Ttl3> ttl { get; set; }

        [Required]
        [Display(Name = "Refund Claim")]
        public RfClm rf_clm { get; set; }
    }

}
