using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSTN.API.GSTR2
{
    public class ImpGAItm:ImpGItm
            {
        [Required]
        [Display(Name = "Original Bill of Entry Number")]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string oboe_num { get; set; }

        [Required]
        [Display(Name = "Original Bill of Entry Date")]
        [RegularExpression("^((0[1-9]|[12][0-9]|3[01])[-](0[1-9]|1[012])[-]((19|20)\\d\\d))*$")]
        public string oboe_dt { get; set; }



    }
  public  class ImpGA
    {

        [Required]
        [Display(Name = "Bill of Entry Number")]
        [MaxLength(50)]
        public string boe_num { get; set; }

        [Required]
        [Display(Name = "Bill of Entry Date")]
        [RegularExpression("^((0[1-9]|[12][0-9]|3[01])[-](0[1-9]|1[012])[-]((19|20)\\d\\d))*$")]
        public string boe_dt { get; set; }

        [Required]
        [Display(Name = "Bill of Entry Value")]
        public double boe_val { get; set; }

        [Required]
        [Display(Name = "itms")]
        public List<ImpGAItm> itms { get; set; }


        [Display(Name = "Invoice Check sum value")]
        [MaxLength(15)]
        public string chksum { get; set; }

    }
}
