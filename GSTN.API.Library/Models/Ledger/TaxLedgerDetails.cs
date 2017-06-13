using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Risersoft.API.GSTN.Ledger
{

       


        public class TrDtl
        {

            [Display(Name = "Transaction date")]
            [RegularExpression("^((0[1-9]|[12][0-9]|3[01])[/](0[1-9]|1[012])[/]((19|20|30)\\d\\d))*$")]
            [Required]
            public string dt { get; set; }

            [Display(Name = "Transaction description")]
            [RegularExpression("^[a-zA-Z0-9\\s]+$")]
            [Required]
            public string desc { get; set; }

            [Display(Name = "Reference number")]
            [RegularExpression("^[a-zA-Z0-9]+$")]
            [Required]
            public string ref_no { get; set; }

            [Display(Name = "IGST")]
            [Required]
            public TaxEntry igst { get; set; }

            [Display(Name = "cgst")]
            [Required]
            public TaxEntry cgst { get; set; }

            [Display(Name = "sgst")]
            [Required]
            public TaxEntry sgst { get; set; }
        }

        public class Tr
        {

            [Display(Name = "Transaction Type")]
            [RegularExpression("^[a-zA-Z0-9\\s]+$")]
            [Required]
            public string tr_typ { get; set; }

            [Display(Name = "Liability Period")]
            [RegularExpression("^((0[1-9]|1[012])((19|20|30)\\d\\d))*$")]
            [Required]
            public string liab_prd { get; set; }

            [Display(Name = "Transaction details")]
            [Required]
            public List<TrDtl> tr_dtl { get; set; }
        }



        public class TotPay
        {

            [Display(Name = "IGST")]
            [Required]
            public TaxEntry igst { get; set; }

            [Display(Name = "CGST")]
            [Required]
            public TaxEntry cgst { get; set; }

            [Display(Name = "SGST")]
            [Required]
            public TaxEntry sgst { get; set; }
        }

        public class Liab
        {

            [Display(Name = "List of Transactions")]
            [Required]
            public List<Tr> Tr { get; set; }

            [Display(Name = "total payment of liabilities")]
            [Required]
            public TotPay tot_pay { get; set; }
        }
    
    
        public class PymntCash
        {

            [Display(Name = "List of Transactions")]
            [Required]
            public List<Tr> tr { get; set; }

            [Display(Name = "total  payment paid through cash")]
            [Required]
            public  TotPay tot_cash { get; set; }
        }



        public class PymntITC
        {

            [Display(Name = "List of Transactions")]
            [Required]
            public List<Tr> tr { get; set; }

            [Display(Name = "total  payment paid through ITC")]
            [Required]
            public TotPay tot_itc { get; set; }
        }

      

        public class Pymnt
        {

            [Display(Name = "payment through cash")]
            [Required]
            public PymntCash pymnt_cash { get; set; }

            [Display(Name = "payment through itc")]
            [Required]
            public PymntITC pymnt_ITC { get; set; }

            [Display(Name = "total liabilities paid")]
            [Required]
            public TotPay to_liab_paid { get; set; }
        }


        public class AmtOverdue
        {

            [Display(Name = "amount over due date")]
            [RegularExpression("^((0[1-9]|[12][0-9]|3[01])[/](0[1-9]|1[012])[/]((19|20|30)\\d\\d))*$")]
            [Required]
            public string dt { get; set; }

            [Display(Name = "Reference number")]
            [RegularExpression("^[a-zA-Z0-9]+$")]
            [Required]
            public string ref_no { get; set; }

            [Display(Name = "description")]
            [RegularExpression("^[a-zA-Z0-9\\s]+$")]
            [Required]
            public string Desc { get; set; }

            [Display(Name = "IGST")]
            [Required]
            public TaxEntry igst { get; set; }

            [Display(Name = "CGST")]
            [Required]
            public TaxEntry cgst { get; set; }

            [Display(Name = "SGST")]
            [Required]
            public TaxEntry sgst { get; set; }
        }

        public class TaxLedgerDetails
        {

            [Display(Name = "GSTIN")]
            [MaxLength(15)]
            [MinLength(15)]
            [RegularExpression("^[a-zA-Z0-9]+$")]
            [Required]
            public string gstin { get; set; }

            [Display(Name = "Return Period")]
            [RegularExpression("^((0[1-9]|1[012])((19|20|30)\\d\\d))*$")]
            [Required]
            public string rt_period { get; set; }

            [Display(Name = "liab")]
            [Required]
            public Liab liab { get; set; }

            [Display(Name = "payment through CASH/ITC")]
            [Required]
            public Pymnt pymnt { get; set; }

            [Display(Name = "amount over due")]
            [Required]
            public AmtOverdue amt_overdue { get; set; }
        }

    }

