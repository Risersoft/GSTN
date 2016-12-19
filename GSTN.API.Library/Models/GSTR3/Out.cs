using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSTN.API.GSTR3
{
    public class IntrSupReg
    {

        [Required]
        [Display(Name = "Identifer if Goods or Services")]
        [RegularExpression("^[a-zA-z]+$")]
        public string ty { get; set; }

        [Required]
        [Display(Name = "State code")]
        public string state_cd { get; set; }

        [Required]
        [Display(Name = "Rate of Tax")]
        public double txrt { get; set; }

        [Required]
        [Display(Name = "Invoice Value")]
        public double val { get; set; }

        [Required]
        [Display(Name = "IGST Amount as per invoice")]
        public double iamt { get; set; }

        [Required]
        [Display(Name = "Additional tax Amount as per invoice")]
        public double aamt { get; set; }
    }
    public class ItraSupReg
    {

        [Required]
        [Display(Name = "Identifer if Goods or Services")]
        [RegularExpression("^[a-zA-z]+$")]
        public string ty { get; set; }

        [Required]
        [Display(Name = "Rate of tax")]
        public double txrt { get; set; }

        [Required]
        [Display(Name = "Invoice Value")]
        public double val { get; set; }

        [Required]
        [Display(Name = "CGST Amount as per invoice")]
        public double camt { get; set; }

        [Required]
        [Display(Name = "SGST Amount as per invoice")]
        public double samt { get; set; }
    }
    public class IntrSupCon
    {

        [Required]
        [Display(Name = "Identifer if Goods or Services")]
        [RegularExpression("^[a-zA-z]+$")]
        public string ty { get; set; }

        [Required]
        [Display(Name = "State Code")]
        public string state_cd { get; set; }

        [Required]
        [Display(Name = "Rate of Tax")]
        public double txrt { get; set; }

        [Required]
        [Display(Name = "Invoice Value")]
        public double val { get; set; }

        [Required]
        [Display(Name = "IGST Amount as per invoice")]
        public double iamt { get; set; }

        [Required]
        [Display(Name = "Add.Tax_Amount as per invoice")]
        public double aamt { get; set; }
    }
    public class IntraSupCon
    {

        [Required]
        [Display(Name = "Identifer if Goods or Services")]
        [RegularExpression("^[a-zA-z]+$")]
        public string ty { get; set; }

        [Required]
        [Display(Name = "Rate of Tax")]
        public double txrt { get; set; }

        [Required]
        [Display(Name = "Invoice Value")]
        public double val { get; set; }

        [Required]
        [Display(Name = "CGST Amount as per invoice")]
        public double camt { get; set; }

        [Required]
        [Display(Name = "SGST Amount as per invoice")]
        public double samt { get; set; }
    }
    public class Exp
    {

        [Required]
        [Display(Name = "Identifer if Goods or Services")]
        [RegularExpression("^[a-zA-z]+$")]
        public string ty { get; set; }

        [Required]
        [Display(Name = "Taxable value of Goods or Service as per invoice")]
        public double txval { get; set; }

        [Required]
        [Display(Name = "IGST Amount as per invoice")]
        public double iamt { get; set; }

        [Required]
        [Display(Name = "CGST Amount as per invoice")]
        public double camt { get; set; }

        [Required]
        [Display(Name = "SGST Amount as per invoice")]
        public double samt { get; set; }

        [Required]
        [Display(Name = "Description like Goods or Serivces with or without payment of GST")]
        public string ex_ty { get; set; }
    }
    public class RevInv
    {

        [Required]
        [Display(Name = "Identifer if Goods or Services")]
        [RegularExpression("^[a-zA-z]+$")]
        public string ty { get; set; }

        [Required]
        [Display(Name = "Month")]
        public string mon { get; set; }

        [Required]
        [Display(Name = "State code")]
        public string state_cd { get; set; }

        [Required]
        [Display(Name = "Document type")]
        public string doc_ty { get; set; }

        [Required]
        [Display(Name = "Supplier Invoice Number")]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string num { get; set; }

        [Required]
        [Display(Name = "Supplier Invoice Date")]
        [RegularExpression("^((0[1-9]|[12][0-9]|3[01])[-](0[1-9]|1[012])[-]((19|20)\\d\\d))*$")]
        public string dt { get; set; }

        [Required]
        [Display(Name = "Differential Value")]
        public double diff_val { get; set; }

        [Required]
        [Display(Name = "IGST Amount as per invoice")]
        public double iamt { get; set; }

        [Required]
        [Display(Name = "CGST Amount as per invoice")]
        public double camt { get; set; }

        [Required]
        [Display(Name = "SGST Amount as per invoice")]
        public double samt { get; set; }

        [Required]
        [Display(Name = "Additional Tax Amount as per invoice")]
        public double aamt { get; set; }
    }
    public class Ttl
    {

        [Required]
        [Display(Name = "Identifer if Goods or Services")]
        [RegularExpression("^[a-zA-z]+$")]
        public string ty { get; set; }

        [Required]
        [Display(Name = "Month")]
        public string mon { get; set; }

        [Required]
        [Display(Name = "Invoice Value")]
        public object val { get; set; }

        [Required]
        [Display(Name = "IGST Amount as per invoice")]
        public double iamt { get; set; }

        [Required]
        [Display(Name = "CGST Amount as per invoice")]
        public double camt { get; set; }

        [Required]
        [Display(Name = "SGST Amount as per invoice")]
        public double samt { get; set; }

        [Required]
        [Display(Name = "Additional Tax Amount as per invoice")]
        public double aamt { get; set; }
    }

    public class Out
    {

        [Required]
        [Display(Name = "Inter-state supplies to Registered taxpayers")]
        public List<IntrSupReg> intr_sup_reg { get; set; }

        [Required]
        [Display(Name = "Intra-State Supplies to Registered taxpayers")]
        public List<ItraSupReg> itra_sup_reg { get; set; }

        [Required]
        [Display(Name = "Inter-State Supplies to Consumers")]
        public List<IntrSupCon> intr_sup_con { get; set; }

        [Required]
        [Display(Name = "Intra-State Supplies to Consumers")]
        public List<IntraSupCon> intra_sup_con { get; set; }

        [Required]
        [Display(Name = "Exports")]
        public List<Exp> exp { get; set; }

        [Required]
        [Display(Name = "Revision of Invoices")]
        public List<RevInv> rev_inv { get; set; }

        [Required]
        [Display(Name = "Total Tax Liability on Outward supplies")]
        public List<Ttl> ttl { get; set; }
    }

}
