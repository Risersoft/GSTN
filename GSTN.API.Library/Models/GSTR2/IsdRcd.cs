using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace Risersoft.API.GSTN.GSTR2
{
    public class IsdRcd
    {

        [Required]
        [Display(Name = "Supplier GSTIN_ISD")]
        [MaxLength(15)]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string gstin_isd { get; set; }

        [Required]
        [Display(Name = "Invoice/Document detail number")]
        [MaxLength(50)]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string i_num { get; set; }

        [Required]
        [Display(Name = "Invoice/Document detail date")]
        [RegularExpression("^((0[1-9]|[12][0-9]|3[01])[-](0[1-9]|1[012])[-]((19|20)\\d\\d))*$")]
        public string i_dt { get; set; }

        [Required]
        [Display(Name = "ISD Credit (IGST)")]
        public int ig_crr { get; set; }

        [Required]
        [Display(Name = "ISD Credit (CGST)")]
        public double cg_cr { get; set; }

        [Required]
        [Display(Name = "ISD Credit (SGST)")]
        public double sg_cr { get; set; }


        [Display(Name = "Invoice Check sum value")]
        [MaxLength(15)]
        public string chksum { get; set; }
    }



}