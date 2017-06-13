using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Risersoft.API.GSTN.Ledger
{

       
        public class UtilizeCashModel
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

            [Display(Name = "Liability Period")]
            [RegularExpression("^((0[1-9]|1[012])((19|20|30)\\d\\d))*$")]
            [Required]
            public string liab_prd { get; set; }

            [Display(Name = "liab")]
            [Required]
            public TotPay liab { get; set; }
        }

}
