using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Risersoft.API.GSTN.GSTR3
{
    public class Tpm
    {
        [Required]
        [Display(Name = "IGST payable")]
        public double i_py { get; set; }

        [Required]
        [Display(Name = "CGST payable")]
        public double c_py { get; set; }

        [Required]
        [Display(Name = "SGST payable")]
        public double s_py { get; set; }

        [Required]
        [Display(Name = "CESS payable")]
        public double cs_py { get; set; }

        [Required]
        [Display(Name = "List of Paid Through Cash")]
        public List<Pdcash> pdcash { get; set; }

        [Required]
        [Display(Name = "List of Paid Through Credit")]
        public List<Pdcr> pdcr { get; set; }
    }
}