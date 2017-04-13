using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GSTN.API.GSTR3
{
    public class RfClm2
    {

        [Required]
        [Display(Name = "Minor Head details")]
        public ICSC igrfclm { get; set; }

        [Required]
        [Display(Name = "Minor Head details")]
        public ICSC cgrfclm { get; set; }

        [Required]
        [Display(Name = "Minor Head details")]
        public ICSC sgrfclm { get; set; }

        [Required]
        [Display(Name = "Minor Head details")]
        public ICSC csrfclm { get; set; }

        [Required]
        [Display(Name = "Bank account Number")]
        [MaxLength(16)]
        public double bnk_num { get; set; }

       
    }
}