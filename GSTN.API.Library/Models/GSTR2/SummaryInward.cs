using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

//class properties does not match to schema like 'ttl_inv','ttl_tax','ttl_igst','ttl_sgst','ttl_cgst'
// in excel file not mention ctin while use return section
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
        [MaxLength(15)]
        public string checksum { get; set; }

        [Required]
        [Display(Name = "ttl_value")]
        public double ttl_val { get; set; }

        [Required]
        [Display(Name = "Total Tax paid IGST")]
        public double ttl_txpd_igst { get; set; }

        [Required]
        [Display(Name = "Total Tax paid SGST")]
        public double ttl_txpd_sgst { get; set; }

        [Required]
        [Display(Name = "Total Tax paid CGST")]
        public double ttl_txpd_cgst { get; set; }

        [Required]
        [Display(Name = "Total Tax paid CESS")]
        public double ttl_txpd_cess { get; set; }

        [Required]
        [Display(Name = "ITC Availed IGST")]
        public double ttl_itcavld_igst { get; set; }

        [Required]
        [Display(Name = "ITC Availed SGST")]
        public double ttl_itcavld_sgst { get; set; }

        [Required]
        [Display(Name = "ITC Availed CGST")]
        public double ttl_itcavld_cgst { get; set; }

        [Required]
        [Display(Name = "ITC Availed CESS")]
        public double ttl_itcavld_cess { get; set; }
    }

    public class SecSum
    {

        [Required]
        [Display(Name = "Return Section")]
        [MaxLength(15)]
        public string section_name { get; set; }

        [Required]
        [Display(Name = "Invoice Check sum value")]
        [MaxLength(15)]
        public string checksum { get; set; }

        [Required]
        [Display(Name = "ttl_value")]
        public double ttl_val { get; set; }

        [Required]
        [Display(Name = "Total Tax paid IGST")]
        public double ttl_txpd_igst { get; set; }

        [Required]
        [Display(Name = "Total Tax paid SGST")]
        public double ttl_txpd_sgst { get; set; }

        [Required]
        [Display(Name = "Total Tax paid CGST")]
        public double ttl_txpd_cgst { get; set; }

        [Required]
        [Display(Name = "Total Tax paid CESS")]
        public double ttl_txpd_cess { get; set; }

        [Required]
        [Display(Name = "ITC Availed IGST")]
        public double ttl_itcavld_igst { get; set; }

        [Required]
        [Display(Name = "ITC Availed SGST")]
        public double ttl_itcavld_sgst { get; set; }

        [Required]
        [Display(Name = "ITC Availed CGST")]
        public double ttl_itcavld_cgst { get; set; }

        [Required]
        [Display(Name = "ITC Availed CESS")]
        public double ttl_itcavld_cess { get; set; }

        [Required]
        [Display(Name = "cpty_sum")]
        public List<CptySum> cpty_sum { get; set; }
    }

    public class SummaryInward
    {

        [Required]
        [Display(Name = "GSTIN of the taxpayer")]
        [MaxLength(15)]
        [MinLength(15)]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string gstin { get; set; }

        [Required]
        [Display(Name = "Return Period")]
        [RegularExpression("^((0[1-9]|1[012])((19|20)\\d\\d))*$")]
        public string ret_period { get; set; }

        [Required]
        [Display(Name = "Invoice Check sum value")]
        [MaxLength(15)]
        public string checksum { get; set; }

       [Required]
        [Display(Name = "sec_sum")]
        public List<SecSum> sec_sum { get; set; }
    }

}