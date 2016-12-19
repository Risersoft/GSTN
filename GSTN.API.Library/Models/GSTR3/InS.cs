using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSTN.API.GSTR3
{

    public class IntrSupRec
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
        [Display(Name = "ITC of IGST available in the current month")]
        public double tc_i { get; set; }

        [Required]
        [Display(Name = "Additional Tax Amount as per invoice")]
        public double aamt { get; set; }
    }

    public class ItraSupRec
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

        [Required]
        [Display(Name = "ITC of CGST available in the current month")]
        public double tc_c { get; set; }

        [Required]
        [Display(Name = "ITC of SGST available in the current month")]
        public double tc_s { get; set; }
    }

    public class Imp
    {

        [Required]
        [Display(Name = "Identifer if Goods or Services")]
        [RegularExpression("^[a-zA-z]+$")]
        public string ty { get; set; }

        [Required]
        [Display(Name = "Assessable Value")]
        public double aval { get; set; }

        [Required]
        [Display(Name = "IGST Amount as per invoice")]
        public double iamt { get; set; }

        [Required]
        [Display(Name = "ITC of IGST available in the current month")]
        public double tc_i { get; set; }
    }

    public class RevInv2
    {

        [Required]
        [Display(Name = "Original or Revised Month")]
        public string mon { get; set; }

        [Required]
        [Display(Name = "GSTIN")]
        [MaxLength(15)]
        [MinLength(15)]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string gstin { get; set; }

        [Required]
        [Display(Name = "State code")]
        public string state_cd { get; set; }

        [Required]
        [Display(Name = "Identifer if Goods or Services")]
        [RegularExpression("^[a-zA-z]+$")]
        public string ty { get; set; }

        [Required]
        [Display(Name = "Sub type identifier like Goods-inputs ,Capital Goods,Services")]
        [RegularExpression("^[a-zA-z]+$")]
        public string sub_ty { get; set; }

        [Required]
        [Display(Name = "HSN or SAC of Goods or Services as per Invoice line items")]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string hsn_sc { get; set; }

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
        [Display(Name = "IGST payable or reversable on Differential value")]
        public double iamt { get; set; }

        [Required]
        [Display(Name = "CGST payable or reversable on Differential value")]
        public double camt { get; set; }

        [Required]
        [Display(Name = "SGST payable or reversable on Differential value")]
        public double samt { get; set; }

        [Required]
        [Display(Name = "ITC of IGST available in the current month")]
        public double tc_i { get; set; }

        [Required]
        [Display(Name = "Additional Tax payable or reversable on Differential value")]
        public double aamt { get; set; }

        [Required]
        [Display(Name = "ITC of CGST available in the current month")]
        public double tc_c { get; set; }

        [Required]
        [Display(Name = "ITC of SGST available in the current month")]
        public double tc_s { get; set; }
    }

    public class Ttl2
    {

        [Required]
        [Display(Name = "Identifer if Goods or Services")]
        [RegularExpression("^[a-zA-z]+$")]
        public string ty { get; set; }

        [Required]
        [Display(Name = "Month to which invoice/debit note/credit note pertains")]
        public string mon { get; set; }

        [Required]
        [Display(Name = "Invoice Value")]
        public double val { get; set; }

        [Required]
        [Display(Name = "CGST liability on Total value of Inward supply of goods on which reverse charge is applicable")]
        public double camt { get; set; }

        [Required]
        [Display(Name = "SGST liability on Total value of Inward supply of goods on which reverse charge is applicable")]
        public double samt { get; set; }

        [Required]
        [Display(Name = "IGST liability on Total value of Inward supply of goods on which reverse charge is applicable")]
        public double iamt { get; set; }

        [Required]
        [Display(Name = "Additional Tax liability on Total value of Inward supply of goods on which reverse charge is applicable")]
        public double aamt { get; set; }
    }

    public class ItcRev
    {

        [Required]
        [Display(Name = "Description of goods sold")]
        [RegularExpression("^[a-zA-Z0-9\\s]+$")]
        public string desc { get; set; }

        [Required]
        [Display(Name = "Reason Code for issuing Debit/Credit Note")]
        [RegularExpression("^[a-zA-Z0-9\\s]+$")]
        public string rsn { get; set; }

        [Required]
        [Display(Name = "Amount of ITC reversal of IGST")]
        public double iamt { get; set; }

        [Required]
        [Display(Name = "Interest applicable on IGST ITC reversed")]
        public double iint { get; set; }

        [Required]
        [Display(Name = "Amount of CTC reversal of IGST")]
        public double camt { get; set; }

        [Required]
        [Display(Name = "Interest applicable on CGST ITC reversed")]
        public double cint { get; set; }

        [Required]
        [Display(Name = "Amount of STC reversal of IGST")]
        public double samt { get; set; }

        [Required]
        [Display(Name = "Interest applicable on SGST ITC reversed")]
        public double sint { get; set; }
    }


    public class InS
    {

        [Required]
        [Display(Name = "Inter-State supplies received")]
        public List<IntrSupRec> intr_sup_rec { get; set; }

        [Required]
        [Display(Name = "Intra-State supplies received")]
        public List<ItraSupRec> itra_sup_rec { get; set; }

        [Required]
        [Display(Name = "Imports")]
        public Imp imp { get; set; }

        [Required]
        [Display(Name = "Revision of Invoices")]
        public List<RevInv2> rev_inv { get; set; }

        [Required]
        [Display(Name = "Total Tax liability on inward supplies on reverse charge")]
        public List<Ttl2> ttl { get; set; }

        [Required]
        [Display(Name = "ITC Reversal")]
        public List<ItcRev> itc_rev { get; set; }
    }

}
