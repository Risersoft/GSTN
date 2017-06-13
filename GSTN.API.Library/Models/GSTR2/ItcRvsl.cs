using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace Risersoft.API.GSTN.GSTR2
{
    public class ItcRvsl
    {

        [Required]
        [Display(Name = "Reason for ITC Reversal")]
        [MaxLength(10)]
        public string rsn { get; set; }

        [Required]
        [Display(Name = "detail of ITC to be reversed")]
        [MaxLength(30)]
        public string des { get; set; }

        [Required]
        [Display(Name = "IGST Reversal Amount")]
        public double iamt { get; set; }

        [Required]
        [Display(Name = "IGST Interest applicable due to Reversal")]
        public double iint { get; set; }

        [Required]
        [Display(Name = "CGST Reversal Amount")]
        public double camt { get; set; }

        [Required]
        [Display(Name = "CGST Interest applicable due to Reversal")]
        public double cint { get; set; }

        [Required]
        [Display(Name = "SGST Reversal Amount")]
        public double samt { get; set; }

        [Required]
        [Display(Name = "SGST Interest applicable due to Reversal")]
        public double sint { get; set; }


        [Display(Name = "Checksum Value")]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string chksum { get; set; }
    }


}