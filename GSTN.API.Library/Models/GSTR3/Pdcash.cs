using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GSTN.API.GSTR3
{
    public class Pdcash
    {
        [Required]
        [Display(Name = "Debit No")]
        public double debitno { get; set; }

        [Required]
        [Display(Name = "Igst paid")]
        public double ipd { get; set; }

        [Required]
        [Display(Name = "Cgst paid")]
        public double cpd { get; set; }

        [Required]
        [Display(Name = "Sgst paid ")]
        public double spd { get; set; }

        [Required]
        [Display(Name = "Cess paid")]
        public double cspd { get; set; }
    }
}