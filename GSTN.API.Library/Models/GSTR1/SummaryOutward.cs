using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace GSTN.API.GSTR1
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
        [Display(Name = "total tax amount")]
        public double ttl_inv { get; set; }

        [Required]
        [Display(Name = "total tax amount")]
        public double ttl_tax { get; set; }

        [Required]
        [Display(Name = "total IGST amount")]
        public double ttl_igst { get; set; }

        [Required]
        [Display(Name = "total SGST amount")]
        public double ttl_sgst { get; set; }

        [Required]
        [Display(Name = "total CGST amount")]
        public double ttl_cgst { get; set; }
    }

    public class SecSum
    {

        [Required]
        [Display(Name = "Return Section")]
        public string sec_nm { get; set; }

        [Required]
        [Display(Name = "Invoice Check sum value")]
        public string checksum { get; set; }

        [Required]
        [Display(Name = "total tax amount")]
        public double ttl_inv { get; set; }

        [Required]
        [Display(Name = "total tax amount")]
        public double ttl_tax { get; set; }

        [Required]
        [Display(Name = "total IGST amount")]
        public double ttl_igst { get; set; }

        [Required]
        [Display(Name = "total SGST amount")]
        public double ttl_sgst { get; set; }

        [Required]
        [Display(Name = "total CGST amount")]
        public double ttl_cgst { get; set; }


        [Display(Name = "cpty_sum")]
        public List<CptySum> counter_party_summary { get; set; }
    }

    public class GSTR1SummaryInfo
    {

        [Required]
        [Display(Name = "GSTIN of the taxpayer")]
        [MaxLength(15)]
        [MinLength(15)]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string gstin { get; set; }

        [Required]
        [Display(Name = "Return Period")]
        public string RetPd { get; set; }

        [Required]
        [Display(Name = "Invoice Check sum value")]
        public string checksum { get; set; }

        [Required]
        [Display(Name = "total tax amount")]
        public double ttl_inv { get; set; }

        [Required]
        [Display(Name = "total tax amount")]
        public double ttl_tax { get; set; }

        [Required]
        [Display(Name = "total IGST amount")]
        public double ttl_igst { get; set; }

        [Required]
        [Display(Name = "total SGST amount")]
        public double ttl_sgst { get; set; }

        [Required]
        [Display(Name = "total CGST amount")]
        public double ttl_cgst { get; set; }


        [Display(Name = "sec_sum")]
        public List<SecSum> section_summary { get; set; }
    }
    public class SummaryOutward
    {
        public List<GSTR1SummaryInfo> GSTR1Summary { get; set; }
    }
}