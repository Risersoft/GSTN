using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Risersoft.API.GSTN.Ledger
{
    public class Igst
    {

        [Display(Name = "from igst")]
        [Required]
        public int fr_igst { get; set; }

        [Display(Name = "from Cgst")]
        [Required]
        public int fr_cgst { get; set; }

        [Display(Name = "from Sgst")]
        [Required]
        public int fr_sgst { get; set; }
    }

    public class Cgst
    {

        [Display(Name = "from igst")]
        [Required]
        public int fr_igst { get; set; }

        [Display(Name = "from Cgst")]
        [Required]
        public int fr_cgst { get; set; }
    }

    public class Sgst
    {

        [Display(Name = "from igst")]
        [Required]
        public int fr_igst { get; set; }

        [Display(Name = "from Sgst")]
        [Required]
        public int fr_sgst { get; set; }
    }

    public class Utilization
    {

        [Display(Name = "igst")]
        [Required]
        public Igst igst { get; set; }

        [Display(Name = "cgst")]
        [Required]
        public Cgst cgst { get; set; }

        [Display(Name = "sgst")]
        [Required]
        public Sgst sgst { get; set; }
    }

    public class UtilizeITCModel
    {

        [Display(Name = "GSTIN of the Taxpayer")]
        [MinLength(15)]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        [Required]
        public string gstin { get; set; }

        [Display(Name = "Return Liability")]
        [RegularExpression("^[a-zA-Z0-9\\s]+$")]
        [Required]
        public string liab_typ { get; set; }

        [Display(Name = "Return Period")]
        [RegularExpression("^((0[1-9]|1[012])((19|20|30)\\d\\d))*$")]
        [Required]
        public string ret_prd { get; set; }

        [Display(Name = "description about type of itc")]
        [RegularExpression("^[a-zA-Z0-9\\s]+$")]
        [Required]
        public string itc_typ { get; set; }

        [Display(Name = "Liability Period")]
        [RegularExpression("^((0[1-9]|1[012])((19|20|30)\\d\\d))*$")]
        [Required]
        public string liab_prd { get; set; }

        [Display(Name = "liab")]
        [Required]
        public Utilization Liab { get; set; }
    }
}
