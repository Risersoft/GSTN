using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Risersoft.API.GSTN.GSTR3
{
    public class Pdcr
    {
        [Required]
        [Display(Name = "Debit no")]
        public double debitno { get; set; }

        [Required]
        [Display(Name = "IGST paid using igst")]
        public double i_pdi { get; set; }

        [Required]
        [Display(Name = "IGST paid using Cgst")]
        public double i_pdc { get; set; }

        [Required]
        [Display(Name = "IGST paid using Sgst")]
        public double i_ds { get; set; }

        [Required]
        [Display(Name = "CGST paid using igst")]
        public double c_pdi { get; set; }

        [Required]
        [Display(Name = "CGST paid using cgst")]
        public double c_pdc { get; set; }

        [Required]
        [Display(Name = "SGST paid using igst ")]
        public double s_pdi { get; set; }

        [Required]
        [Display(Name = "SGST paid using sgst ")]
        public double s_pds { get; set; }

        [Required]
        [Display(Name = "Cess paid using cess")]
        public double cs_pdcs { get; set; }

    }
}