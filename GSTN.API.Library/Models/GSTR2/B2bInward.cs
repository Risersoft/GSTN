using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace GSTN.API.GSTR2
{
    public class ItmDet
    {

        [Required]
        [Display(Name = "Identifier if Goods or Services")]
        [MaxLength(1)]
        [MinLength(1)]
        [RegularExpression("^(G|S)+$")]
        public string ty { get; set; }

        [Required]
        [Display(Name = "HSN or SAC of Goods or Services as per Invoice line items")]
        [MaxLength(10)]
        public string hsn_sc { get; set; }

        [Required]
        [Display(Name = "Taxable value of Goods or Service as per invoice")]
        public double txval { get; set; }

        [Required]
        [Display(Name = "IGST Rate as per invoice")]
        public double irt { get; set; }

        [Required]
        [Display(Name = "IGST Amount as per invoice")]
        public double iamt { get; set; }

        [Required]
        [Display(Name = "CGST Rate as per invoice")]
        public double crt { get; set; }

        [Required]
        [Display(Name = "CGST Amount as per invoice")]
        public double camt { get; set; }

        [Required]
        [Display(Name = "SGST Rate as per invoice")]
        public double srt { get; set; }

        [Required]
        [Display(Name = "SGST Amount as per invoice")]
        public double samt { get; set; }

        [Required]
        [Display(Name = "Eligiblity of Total Tax available as ITC")]
        [MaxLength(20)]
        public string elg { get; set; }
    }

    public class Itc
    {

        [Required]
        [Display(Name = "Total Tax available as ITC CGST Amount")]
        public double tx_c { get; set; }

        [Required]
        [Display(Name = "Total Tax available as ITC IGST Amount")]
        public double tx_i { get; set; }

        [Required]
        [Display(Name = "Total Tax available as ITC SGST Amount")]
        public double tx_s { get; set; }

        [Required]
        [Display(Name = "Total Input Tax Credit available for claim this month based on the Invoices uploaded(CGST Amount)")]
        public double tc_c { get; set; }

        [Required]
        [Display(Name = "Total Input Tax Credit available for claim this month based on the Invoices uploaded(IGST Amount)")]
        public double tc_i { get; set; }

        [Required]
        [Display(Name = "Total Input Tax Credit available for claim this month based on the Invoices uploaded(SGST Amount)")]
        public double tc_s { get; set; }
    }

    public class Itm
    {

        [Required]
        [Display(Name = "Serial no")]
        public int num { get; set; }

        [Required]
        [Display(Name = "itm_det")]
        public ItmDet itm_det { get; set; }

        [Required]
        [Display(Name = "itc")]
        public Itc itc { get; set; }

        [Required]
        [Display(Name = "Status of invoice")]
        [MaxLength(1)]
        [MinLength(1)]
        [RegularExpression("^(A|M|D)+$")]
        public string status { get; set; }
    }

    public class B2bInv
    {

        [Required]
        [Display(Name = "Supplier Invoice Number")]
        [MaxLength(50)]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string inum { get; set; }

        [Required]
        [Display(Name = "Supplier Invoice Date")]
        [RegularExpression("^((0[1-9]|[12][0-9]|3[01])[-](0[1-9]|1[012])[-]((19|20)\\d\\d))*$")]
        public string idt { get; set; }

        [Required]
        [Display(Name = "Supplier Invoice Value")]
        public double val { get; set; }

        [Required]
        [Display(Name = "Place of supply")]
        [MaxLength(5)]
        public string pos { get; set; }

        [Required]
        [Display(Name = "itms")]
        public List<Itm> itms { get; set; }

        [Required]
        [Display(Name = "Invoice Check sum value")]
        [MaxLength(15)]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string chksum { get; set; }
    }

    public class B2bInward
    {

        [Required]
        [Display(Name = "GSTIN/UID of the Receiver taxpayer/UN, Govt Bodies")]
        public string ctin { get; set; }

        [Required]
        [Display(Name = "inv")]
        public List<B2bInv> inv { get; set; }
    }


}