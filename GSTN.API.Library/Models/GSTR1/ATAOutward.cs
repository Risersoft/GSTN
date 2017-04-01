using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace GSTN.API.GSTR1
{
   

    public class AtAOutward:AtOutward
    {
        [Required]
        [Display(Name = "Original CounterParty Gstin or Name")]
        [MaxLength(50)]
        public string ocpty { get; set; }

        [Required]
        [Display(Name = "Original/Revised document number")]
        public string odoc_num { get; set; }

        [Required]
        [Display(Name = "Original/Revised transaction date")]
        [RegularExpression("^((0[1-9]|[12][0-9]|3[01])[-](0[1-9]|1[012])[-]((19|20)\\d\\d))*$")]
        public string odoc_dt { get; set; }
    }

 
}