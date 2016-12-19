using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

//class properties does not match to schema like 'ttl_inv','ttl_tax','ttl_igst','ttl_sgst','ttl_cgst'

namespace GSTN.API.GSTR2
{
    public class CptySum
    {

        [Required]
        [Display(Name = "CTIN of the taxpayer")]
        [MaxLength(15)]
        [MinLength(15)]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string ctin { get; set; }

        [Required]
        [Display(Name = "Invoice Check sum value")]
        public string checksum { get; set; }

        [Required]
        [Display(Name = "ttl_value")]
        public double ttl_value { get; set; }

        [Required]
        [Display(Name = "tax_pd")]
        public double tax_pd { get; set; }

        [Required]
        [Display(Name = "itc_av")]
        public double itc_av { get; set; }
    }

    public class SecSum
    {

        [Required]
        [Display(Name = "Return Section")]
        public string SecNm { get; set; }

        [Required]
        [Display(Name = "Invoice Check sum value")]
        public string checksum { get; set; }

        [Required]
        [Display(Name = "ttl_value")]
        public double ttl_value { get; set; }

        [Required]
        [Display(Name = "tax_pd")]
        public double tax_pd { get; set; }

        [Required]
        [Display(Name = "itc_av")]
        public double itc_av { get; set; }

        [Required]
        [Display(Name = "cpty_sum")]
        public List<CptySum> cpty_sum { get; set; }
    }

    public class GSTR2SummaryInfo
    {

        [Required]
        [Display(Name = "GSTIN of the taxpayer")]
        [MaxLength(15)]
        [MinLength(15)]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string gstin { get; set; }

        [Required]
        [Display(Name = "Return Period")]
        public string ret_pd { get; set; }

        [Required]
        [Display(Name = "Invoice Check sum value")]
        public string checksum { get; set; }

        [Required]
        [Display(Name = "ttl_value")]
        public double ttl_value { get; set; }

        [Required]
        [Display(Name = "tax_pd")]
        public double tax_pd { get; set; }

        [Required]
        [Display(Name = "itc_av")]
        public double itc_av { get; set; }

        [Required]
        [Display(Name = "sec_sum")]
        public List<SecSum> sec_sum { get; set; }
    }
    public class SummaryInward
    {
        public List<GSTR2SummaryInfo> GSTR2Summary { get; set; }
    }
}