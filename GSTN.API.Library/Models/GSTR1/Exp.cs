using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace Risersoft.API.GSTN.GSTR1
{

    public class ExpInv
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
        [Display(Name = "Shipping Bill No. or Bill of Export No.")]
        [MaxLength(30)]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public int sbnum { get; set; }

        [Required]
        [Display(Name = "Shipping Bill Date. or Bill of Export Date")]
        [RegularExpression("^((0[1-9]|[12][0-9]|3[01])[-](0[1-9]|1[012])[-]((19|20)\\d\\d))*$")]
        public string sbdt { get; set; }
        [Required]
        [Display(Name = "Item Details")]
        public List<B2Bitem> itms { get; set; }

        [Required]
        [Display(Name = "Port Code")]
        [MaxLength(25)]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string sbpcode { get; set; }

        [Required]
        [Display(Name = "Provisional Assesment")]
        [MaxLength(1)]
        [RegularExpression("^[a-zA-Z]+$")]
        public string prs { get; set; }

        [Required]
        [Display(Name = "Order Number")]
        [MaxLength(30)]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string od_num { get; set; }

        [Required]
        [Display(Name = "Order Date")]
        [RegularExpression("^((0[1-9]|[12][0-9]|3[01])[-](0[1-9]|1[012])[-]((19|20)\\d\\d))*$")]
        public string od_dt { get; set; }

        [Display(Name = "Checksum Value")]
        [MaxLength(15)]
        public string chksum { get; set; }
    }

    public class Exp
    {
        [Display(Name = "Supplies exported types i.e WithPay,WithoutPay")]
        [Required]
        [MaxLength(5)]
        public string ex_tp { get; set; }

        [Required]
        [Display(Name = "Invoice Details")]
        public List<ExpInv> inv { get; set; }
    }

}