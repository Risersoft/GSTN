using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace Risersoft.API.GSTN.GSTR1
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
        [Display(Name = "Nature of Supply Type")]
        [MaxLength(8)]
        public string sply_ty { get; set; }
    }

    public class NilSupply
    {

        [Required]
        [Display(Name = "Identifier if Goods or Services")]
        [MaxLength(1)]
        [RegularExpression("^[G/S]")]
        public string itm_ty { get; set; }

        [Required]
        [Display(Name = "Nil Data")]
        public List<NilSupplyData> nil_data { get; set; }

    }

    public class NilRatedOutward
    {

        [Required]
        [Display(Name = "List of nil supplies")]
        public List<NilSupply> nil_supplies { get; set; }

        [Required]
        [Display(Name = "Checksum of Nil DATA")]
        [MaxLength(15)]
        public string chksum { get; set; }
    }
}