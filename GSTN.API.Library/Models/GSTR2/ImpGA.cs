using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Risersoft.API.GSTN.GSTR2
{
    public class ImpGA
    {

        [Required]
        [Display(Name = "Bill of Entry Number")]
        [MaxLength(50)]
        public int boe_num { get; set; }

        [Required]
        [Display(Name = "Original Bill of Entry Number")]
        [MaxLength(50)]
        public int oboe_num { get; set; }   

        [Required]
        [Display(Name = "Bill of Entry Date")]
        [RegularExpression("^((0[1-9]|[12][0-9]|3[01])[-](0[1-9]|1[012])[-]((19|20)\\d\\d))*$")]
        public string boe_dt { get; set; }


        [Required]
        [Display(Name = "Original Bill of Entry Date")]
        [RegularExpression("^((0[1-9]|[12][0-9]|3[01])[-](0[1-9]|1[012])[-]((19|20)\\d\\d))*$")]
        public string oboe_dt { get; set; } 



        [Required]
        [Display(Name = "Port Code")]
        public string port_code { get; set; }

        [Required]
        [Display(Name = "Bill of Entry Value")]
        public double boe_val { get; set; }

        [Required]
        [Display(Name = "itms")]
        public List<ImpGItm> itms { get; set; }


        [Display(Name = "Invoice Check sum value")]
        [MaxLength(15)]
        public string chksum { get; set; }

    }
}
