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
        public int irt { get; set; }

        [Required]
        [Display(Name = "IGST Amount as per invoice")]
        public int iamt { get; set; }

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
        [Display(Name = "CESS Rate as per invoice")]
        public double csrt { get; set; }

        [Required]
        [Display(Name = "Eligiblity of Total Tax available as ITC")]
        [MaxLength(20)]
        public string elg { get; set; }
        [Required]
        [Display(Name = "CESS Amount as per invoice")]
        public double csamt { get; set; }
    }

    public class Itc
    {

        [Required]
        [Display(Name = "Total Tax available as ITC CGST Amount")]
        public int tx_c { get; set; }

        [Required]
        [Display(Name = "Total Tax available as ITC IGST Amount")]
        public int tx_i { get; set; }

        [Required]
        [Display(Name = "Total Tax available as ITC SGST Amount")]
        public int tx_s { get; set; }

        [Required]
        [Display(Name = "Total Tax available as ITC CESS Amount")]
        public int tx_cs { get; set; }

        [Required]
        [Display(Name = "Total Input Tax Credit available for claim this month based on the Invoices uploaded(CGST Amount)")]
        public int tc_c { get; set; }

        [Required]
        [Display(Name = "Total Input Tax Credit available for claim this month based on the Invoices uploaded(IGST Amount)")]
        public int tc_i { get; set; }

        [Required]
        [Display(Name = "Total Input Tax Credit available for claim this month based on the Invoices uploaded(SGST Amount)")]
        public int tc_s { get; set; }

        [Required]
        [Display(Name = "Total Input Tax Credit available for claim this month based on the Invoices uploaded(SGST Amount)")]
        public int tc_cs { get; set; }
    }

    public class Itm
    {

        [Required]
        [Display(Name = "Serial no")]
        public int num { get; set; }

        [Required]
        [Display(Name = "item Details")]
        public ItmDet itm_det { get; set; }

        [Required]
        [Display(Name = "itc")]
        public Itc itc { get; set; }

    }

    public class B2bInv
    {
        [Required]
        [Display(Name = "flag for accepting or rejecting a invoice")]
        public string flag { get; set; }

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
        [Display(Name = "Reverse Charge")]
        public string rchrg { get; set; }


        [Required]
        [Display(Name = "Invoice Uploader")]
        public string updby { get; set; }

        [Required]
        [Display(Name = "items")]
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
        [Display(Name = "counter party Filing Status")]
        public string cfs { get; set; }

        [Required]
        [Display(Name = "Invoice Details")]
        public List<B2bInv> inv { get; set; }
    }


}