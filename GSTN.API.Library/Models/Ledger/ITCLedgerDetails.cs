using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GSTN.API.Ledger
{

        
        public class ITCLedgerDetails
        {

            [Display(Name = "GSTIN of the taxpayer")]
            [MinLength(15)]
            [RegularExpression("^[a-zA-Z0-9]+$")]
            [Required]
            public string gstin { get; set; }

            [Display(Name = "from date")]
            [RegularExpression("^((0[1-9]|[12][0-9]|3[01])[-](0[1-9]|1[012])[-]((19|20)\\d\\d))*$")]
            [Required]
            public string fr_dt { get; set; }

            [Display(Name = "to date")]
            [RegularExpression("^((0[1-9]|[12][0-9]|3[01])[-](0[1-9]|1[012])[-]((19|20)\\d\\d))*$")]
            [Required]
            public string to_dt { get; set; }

            [Display(Name = "Transaction details")]
            [Required]
            public List<CashTr> tr { get; set; }
        }

}
