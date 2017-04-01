using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSTN.API.GSTR2
{
    public class ImpSAItm : ImpSItm
    {
        [Required]
        [Display(Name = "Original Invoice Number")]
        [MaxLength(10)]
        public string oinum { get; set; }

        [Required]
        [Display(Name = "Original Invoice Date")]
        [RegularExpression("^((0[1-9]|[12][0-9]|3[01])[-](0[1-9]|1[012])[-]((19|20)\\d\\d))*$")]
        public string oidt { get; set; }



    }
    public class ImpSA
    {

        [Required]
        [Display(Name = "Invoice number")]
        [MaxLength(10)]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string inum { get; set; }

        [Required]
        [Display(Name = "Invoice date")]
        [RegularExpression("^((0[1-9]|[12][0-9]|3[01])[-](0[1-9]|1[012])[-]((19|20)\\d\\d))*$")]
        public string idt { get; set; }

        [Required]
        [Display(Name = "Invoice Value")]
        public double ival { get; set; }

        [Required]
        [Display(Name = "itms")]
        public List<ImpSAItm> itms { get; set; }


        [Display(Name = "Invoice Check sum value")]
        [MaxLength(15)]
        public string chksum { get; set; }
    }
}
