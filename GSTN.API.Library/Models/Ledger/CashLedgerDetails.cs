using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Risersoft.API.GSTN.Ledger
{
    public class TaxEntry
    {

        [Display(Name = "TAX")]
        [Required]
        public int tx { get; set; }

        [Display(Name = "intrest")]
        [Required]
        public int intr { get; set; }

        [Display(Name = "penality")]
        [Required]
        public int pen { get; set; }

        [Display(Name = "fees")]
        [Required]
        public int fee { get; set; }

        [Display(Name = "others")]
        [Required]
        public int oth { get; set; }

        [Display(Name = "total")]
        [Required]
        public int tot { get; set; }
    }

    public class CashTr
        {

            [Display(Name = "Date of transaction")]
            [RegularExpression("^((0[1-9]|[12][0-9]|3[01])[/](0[1-9]|1[012])[/]((19|20)\\d\\d))*$")]
            [Required]
            public string dt { get; set; }

            [Display(Name = "Description of transaction")]
            [Required]
            public string tr_name { get; set; }

            [Display(Name = "Debit No / CIN Number")]
            [Required]
            public string db_no { get; set; }

            [Display(Name = "balance")]
            [Required]
            public int bal { get; set; }

            [Display(Name = "Credit or Debit  Transaction type")]
            [Required]
            public string tr_typ { get; set; }

            [Display(Name = "igst")]
            [Required]
            public TaxEntry igst { get; set; }

            [Display(Name = "cgst")]
            [Required]
            public TaxEntry cgst { get; set; }

            [Display(Name = "sgst")]
            [Required]
            public TaxEntry sgst { get; set; }
        }

        public class CashLedgerDetails
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
