using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace GSTN.API.GSTR3
{
  
    public class Ttl3
    {

        [Required]
        [Display(Name = "Identifer if Goods or Services")]
        [RegularExpression("^[a-zA-z]+$")]
        public string ty { get; set; }

        [Required]
        [Display(Name = "Month to which invoice/debit note/credit note pertains")]
        public string mon { get; set; }

        [Required]
        [Display(Name = "Total value of Outward supply of Goods for the tax period")]
        public long val { get; set; }

        [Required]
        [Display(Name = "Total CGST liability for the tax period")]
        public double camt { get; set; }

        [Required]
        [Display(Name = "Total SGST liability for the tax period")]
        public double samt { get; set; }

        [Required]
        [Display(Name = "Total IGST liability for the tax period")]
        public double iamt { get; set; }

        [Required]
        [Display(Name = "Total Additional tax  liability for the tax period")]
        public double aamt { get; set; }
    }

    public class TdsRcd
    {

        [Required]
        [Display(Name = "GSTIN/ GDI/of TDS deductor")]
        public string gstin { get; set; }

        [Required]
        [Display(Name = "IGST_Rate of TDS")]
        public double irt { get; set; }

        [Required]
        [Display(Name = "IGST_Tax Amount of TDS")]
        public double itx { get; set; }

        [Required]
        [Display(Name = "CGST_Rate of TDS")]
        public double crt { get; set; }

        [Required]
        [Display(Name = "CGST_Tax Amount of TDS")]
        public double ctx { get; set; }

        [Required]
        [Display(Name = "SGST_Rate of TDS")]
        public double srt { get; set; }

        [Required]
        [Display(Name = "SGST_Tax Amount of TDS")]
        public double stx { get; set; }
    }

    public class ItcRcd
    {

        [Required]
        [Display(Name = "Identifer if Goods Input , Capital Goods or Services")]
        [RegularExpression("^[a-zA-z]+$")]
        public string desc { get; set; }

        [Required]
        [Display(Name = "IGST_Rate of TDS")]
        public double irt { get; set; }

        [Required]
        [Display(Name = "IGST_Tax Amount of TDS")]
        public double itx { get; set; }

        [Required]
        [Display(Name = "CGST_Rate of TDS")]
        public double crt { get; set; }

        [Required]
        [Display(Name = "CGST_Tax Amount of TDS")]
        public double ctx { get; set; }

        [Required]
        [Display(Name = "SGST_Rate of TDS")]
        public double srt { get; set; }

        [Required]
        [Display(Name = "SGST_Tax Amount of TDS")]
        public double stx { get; set; }
    }

    public class GSTR3Total
    {

        [Required]
        [Display(Name = "Supplier GSTIN")]
        [MaxLength(15)]
        [MinLength(15)]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string gstin { get; set; }

        [Required]
        [Display(Name = "Name of Taxpayer")]
        [RegularExpression("^[a-zA-Z0-9\\s]+$")]
        public string name { get; set; }

        [Required]
        [Display(Name = "Address of Taxpayer")]
        public string add { get; set; }

        [Required]
        [Display(Name = "Finalcial Period")]
        [MaxLength(10)]
        [MinLength(3)]
        [RegularExpression("^[0-9]+$")]
        public string fp_fm { get; set; }

        [Required]
        [Display(Name = "Financial Year")]
        [RegularExpression("^[0-9\\-]+$")]
        public string fp_fy { get; set; }

        [Required]
        [Display(Name = "Turn Over Details")]
        public Tod tod { get; set; }

        [Required]
        [Display(Name = "Outward Supplies")]
        public List<Out> out_s { get; set; }

        [Required]
        [Display(Name = "Inward Supplies")]
        public InS in_s { get; set; }

        [Required]
        [Display(Name = "Total Tax Liability")]
        public List<Ttl3> ttl { get; set; }

        [Required]
        [Display(Name = "TDS Credit")]
        public List<TdsRcd> tds_rcd { get; set; }

        [Required]
        [Display(Name = "ITC Credit")]
        public List<ItcRcd> itc_rcd { get; set; }

        [Required]
        [Display(Name = "Tax Paid")]
        public PayDet pay_det { get; set; }

        [Required]
        [Display(Name = "Refund Claim")]
        public RfClm rf_clm { get; set; }
    }
}