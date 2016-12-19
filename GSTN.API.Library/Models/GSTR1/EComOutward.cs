using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace GSTN.API.GSTR1
{
    public class EComItm:Itm
    {

        [Required]
        [Display(Name = "Nature of supply")]
        public string sup_type { get; set; }

    }

    public class EComInv
    {

        [Required]
        [Display(Name = "Invoice type")]
        public string flag { get; set; }

        [Required]
        [Display(Name = "Tax Period")]
        public string txprd { get; set; }

        [Required]
        [Display(Name = "Merchant ID issued by e-commerce portal")]
        [MaxLength(20)]
        public string mid { get; set; }

        [Required]
        [Display(Name = "Gross Value of supplies")]
        public double grsval { get; set; }

        [Required]
        [Display(Name = "GSTIN/UID of the Receiver taxpayer/UN,Govt Bodies")]
        [MaxLength(15)]
        [MinLength(15)]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string ctin { get; set; }

        [Required]
        [Display(Name = "itms")]
        public List<EComItm> itms { get; set; }


        [Display(Name = "Checksum Value")]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string chksum { get; set; }
    }

    public class EComOutward
    {

        [Required]
        public string ecom_ty { get; set; }

        [Required]
        public List<EComInv> eInvoices { get; set; }
    }
    

}