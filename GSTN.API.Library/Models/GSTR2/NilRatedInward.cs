using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
//class properties does not match with schema
namespace GSTN.API.GSTR2
{
    public class NilSupplyData
    {

        [Required]
        [Display(Name = "HSN/SAC of Goods/Services as per Invoice line items")]
        public string hsn_sc { get; set; }

        [Required]
        [Display(Name = "Value of supplies received from Compounding Dealer")]
        public double cpddr { get; set; }

        [Required]
        [Display(Name = "Value of supplies received from Unregistered dealer")]
        public double uredr { get; set; }

        [Required]
        [Display(Name = "Value of exempted supplies received ")]
        public double exptdsply { get; set; }

        [Required]
        [Display(Name = "Total Non GST outward supplies")]
        public double ngsply { get; set; }

        [Required]
        [Display(Name = "Nil Rated Supply")]
        public double nilsply { get; set; }
    }

    public class NilRatedInward
    {

        [Required]
        [Display(Name = "Supply Type")]
        public string sply_ty { get; set; }

        [Required]
        [Display(Name = "Nil Data")]
        public List<NilSupplyData> nil { get; set; }

        [Display(Name = "Checksum Value")]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string chksum { get; set; }
    }
}