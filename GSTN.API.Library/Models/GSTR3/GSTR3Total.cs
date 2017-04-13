using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;


namespace GSTN.API.GSTR3
{
    public class GSTR3Total
    {

        [Required]
        [Display(Name = "Supplier GSTIN")]
        [MaxLength(15)]
        [MinLength(15)]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string gstin { get; set; }



        [Required]
        [Display(Name = "Return Period")]
        [RegularExpression("^((0[1-9]|1[012])((19|20)\\d\\d))*$")]
        public string ret_period { get; set; }


        [Required]
        [Display(Name = "Turn Over Details")]
        public Tod tod { get; set; }

        [Required]
        [Display(Name = "Outward Supplies")]
        public Out osup { get; set; }

        [Required]
        [Display(Name = "Inward Supplies")]
        public InS isup { get; set; }

        [Required]
        [Display(Name = "Total Tax Liability")]
        public Ttl ttxl { get; set; }

        [Required]
        [Display(Name = "TCS Credit")]
        public TcsCredit tcs_cr { get; set; }

        [Required]
        [Display(Name = "TDS Credit")]
        public TdsCredit tds_cr { get; set; }

        [Required]
        [Display(Name = "ITC Credit")]
        public ItcCredit itc_cr { get; set; }

        [Required]
        [Display(Name = "Tax Paid")]
        public Tpm tpm { get; set; }

        [Required]
        [Display(Name = "Refund Claim")]
        public RfClm rf_clm { get; set; }
    }
}