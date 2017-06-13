using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Risersoft.API.GSTN.GSTR1
{
    public class B2CSAOutward : B2csOutward

    {
        
        [Required]
        [Display(Name = "Original Month")]
        [RegularExpression("^((0[1-9]|1[012])((19|20)\\d\\d))*$")]
        public string omon { get; set; }

        [Required]
        [Display(Name = "Line Item Type i.e. Goods/Services")]
        [MaxLength(1)]
        [RegularExpression("^[G/S]")]
        public string oty { get; set; }

        [Required]
        [Display(Name = "Original HSN/SAC Value")]
        [MaxLength(10)]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string ohsn_sc { get; set; }

        [Required]
        [Display(Name = "Supply State Code")]
        [MaxLength(2)]
        public string osupst_cd { get; set; }
    }
}
