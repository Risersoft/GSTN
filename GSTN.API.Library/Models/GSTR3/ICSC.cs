using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GSTN.API.GSTR3
{
    public class ICSC
    {
        [Required]
        [Display(Name = "Tax")]
        [MaxLength(15)]
        public double tax { get; set; }

        [Required]
        [Display(Name = "Penality")]
        [MaxLength(15)]
        public double pen { get; set; }

        [Required]
        [Display(Name = "Interest")]
        [MaxLength(15)]
        public double @int { get; set; }

        [Required]
        [Display(Name = "Fees")]
        [MaxLength(15)]
        public double fee { get; set; }

        [Required]
        [Display(Name = "Others")]
        [MaxLength(15)]
        public double oth { get; set; }
    }
}