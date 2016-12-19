using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace GSTN.API.GSTR2
{
    public class ItcRcd
    {

        [Required]
        [Display(Name = "Invoice number")]
        public string i_num { get; set; }

        [Required]
        [Display(Name = "Invoice date")]
        [RegularExpression("^((0[1-9]|[12][0-9]|3[01])[-](0[1-9]|1[012])[-]((19|20)\\d\\d))*$")]
        public string i_dt { get; set; }

        [Required]
        [Display(Name = "Earlier IGST")]
        public double o_ig { get; set; }

        [Required]
        [Display(Name = "This month IGST")]
        public double n_ig { get; set; }

        [Required]
        [Display(Name = "Earlier CGST")]
        public double o_cg { get; set; }

        [Required]
        [Display(Name = "This month CGST")]
        public double n_cg { get; set; }

        [Required]
        [Display(Name = "Earlier SGST")]
        public double o_sg { get; set; }

        [Required]
        [Display(Name = "This month SGST")]
        public double n_sg { get; set; }


        [Display(Name = "Checksum Value")]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string chksum { get; set; }
    }

  

}