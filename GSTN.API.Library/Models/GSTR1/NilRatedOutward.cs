using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace GSTN.API.GSTR1
{
    public class NilSupplyData
    {

        [Required]
        [Display(Name = "Total Nil rated outward supplies")]
        public double nil_amt { get; set; }

        [Required]
        [Display(Name = "Total Exempted outward supplies")]
        public double expt_amt { get; set; }

        [Required]
        [Display(Name = "Total Non GST outward supplies")]
        public double ngsup_amt { get; set; }

        [Required]
        [Display(Name = "Identifier if Goods or Services")]
        [RegularExpression("^[G/S]")]
        public string itm_ty { get; set; }
    }

    public class NilSupply
    {

        [Required]
        [Display(Name = "Supply Type")]
        [MaxLength(50)]
        public string sply_ty { get; set; }

        [Required]
        public List<NilSupplyData> nil_data { get; set; }
    }

    public class NilRatedOutward
    {

        [Required]
        public List<NilSupply> nil_supplies { get; set; }

        [Required]
        public string chksum { get; set; }
    }
}