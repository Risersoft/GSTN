using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSTN.API.GSTR1
{
  public  class B2CSAOutward:B2csOutward

    {
        [Display(Name = "Checksum Value")]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string chksum { get; set; }

        [Required]
        [Display(Name = "Month")]
        [RegularExpression("^[a-zA-z0-9]+$")]
        public string omon { get; set; }

        [Required]
        [Display(Name = "Line Item Type i.e. Goods/Services")]
        [RegularExpression("^[a-zA-z]+$")]
        public string oty { get; set; }

        [Required]
        [Display(Name = "HSN/SAC Value")]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string ohsn_sc { get; set; }

        [Required]
        [Display(Name = "Supply State Code")]
        public string osupst_cd { get; set; }
    }
}
