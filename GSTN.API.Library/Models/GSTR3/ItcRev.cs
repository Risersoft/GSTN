using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GSTN.API.GSTR3
{
    public class ItcRev
    {
        //[Required]
        //[Display(Name = "Description of goods sold")]
        //[RegularExpression("^[a-zA-Z0-9\\s]+$")]
        //public string desc { get; set; }                                    ---------deleted-------------

        [Required]
        [Display(Name = "Identifer if Goods or Services")]
        [MaxLength(30)]
        public string ty { get; set; }

        [Required]
        [Display(Name = "Document for which rectification is done")]
        [MaxLength(10)]
        public string docty { get; set; }

        [Required]
        [Display(Name = "IGST Amount as per invoice")]
        public double val { get; set; }

        //[Required]
        //[Display(Name = "Reason Code for issuing Debit/Credit Note")]
        //[RegularExpression("^[a-zA-Z0-9\\s]+$")]
        //public string rsn { get; set; }                            ---------------deleted-----------

        [Required]
        [Display(Name = "Amount of ITC reversal of IGST")]
        public double iamt { get; set; }

        [Required]
        [Display(Name = " ITC reversed on IGST")]
        public double iigst { get; set; }

        //[Required]
        //[Display(Name = "Interest applicable on IGST ITC reversed")]
        //public int iint { get; set; }                         -------------------deleted----------------

        [Required]
        [Display(Name = "Amount of CTC reversal of IGST")]
        public double camt { get; set; }

        [Required]
        [Display(Name = " ITC reversed on cgst")]
        public double icgst { get; set; }

        //[Required]
        //[Display(Name = "Interest applicable on CGST ITC reversed")]
        //public int cint { get; set; }                         -------------------deleted------------


        [Required]
        [Display(Name = " Cess Amount")]
        public double csamt { get; set; }

        [Required]
        [Display(Name = "  ITC reversed on cess")]
        public double icess { get; set; }

        [Required]
        [Display(Name = "Amount of ITC reversal of SGST ")]
        public double samt { get; set; }

        //[Required]
        //[Display(Name = "Interest applicable on SGST ITC reversed")]
        //public int sint { get; set; }                      --------------------deleted--------------

        [Required]
        [Display(Name = " ITC reversed on sgst")]
        public int isgst { get; set; }
    }
}