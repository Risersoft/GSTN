using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GSTN.API.GSTR3
{
    public class RevInv
    {
        [Required]
        [Display(Name = "Identifer if Goods or Services")]
        [RegularExpression("^[a-zA-z]+$")]
        public string ty { get; set; }

        //[Required]
        //[Display(Name = "Month")]
        //public string mon { get; set; }

        [Required]
        [Display(Name = "State code")]
        public string state_cd { get; set; }

        //[Required]
        //[Display(Name = "Document type")]
        //public string doc_ty { get; set; }                  ------------changed by docty----------------

        [Required]
        [Display(Name = "Document for which rectification is done")]
        [MaxLength(1)]
        public string docty { get; set; }

        //[Required]
        //[Display(Name = "Supplier Invoice Number")]
        //[RegularExpression("^[a-zA-Z0-9]+$")]
        //public string num { get; set; }                       -----------------deleted-----------

        //[Required]
        //[Display(Name = "Supplier Invoice Date")]
        //[RegularExpression("^((0[1-9]|[12][0-9]|3[01])[-](0[1-9]|1[012])[-]((19|20)\\d\\d))*$")]
        //public string dt { get; set; }                      -----------------deleted-----------

        //[Required]
        //[Display(Name = "Differential Value")]
        //public int diff_val { get; set; }          -----------------changed by val-------------------

        [Required]
        [Display(Name = "Differential value on which tax is to be paid based on upward modification or to be reversed based on downward modification (but subject to confirmation of counter-party)")]
        public double val { get; set; }

        [Required]
        [Display(Name = "IGST payable or reversable on Differential value")]
        public double iamt { get; set; }

        [Required]
        [Display(Name = "CGST payable or reversable on Differential value")]
        public double camt { get; set; }

        [Required]
        [Display(Name = "CESS  payable or reversable on Differential value")]
        public double csamt { get; set; }

        [Required]
        [Display(Name = "SGST payable or reversable on Differential value")]
        public double samt { get; set; }

        //[Required]
        //[Display(Name = "Additional Tax Amount as per invoice")]
        //public int aamt { get; set; }                                   -----------------deleted-----------

        
    }
}