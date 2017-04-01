using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace GSTN.API.GSTR2
{
    public class ItcRcd
    {
        [Required]
        [Display(Name = "Supplier tin")]
        [MaxLength(15)]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string stin { get; set; }
        [Required]
        [Display(Name = "document type")]
        public string typ { get; set; }

        [Required]
        [Display(Name = "Invoice number")]
        public string inv_doc_num { get; set; }

        [Required]
        [Display(Name = "Original Invoice/Document date")]
        [RegularExpression("^((0[1-9]|[12][0-9]|3[01])[-](0[1-9]|1[012])[-]((19|20)\\d\\d))*$")]
        public string inv_doc_dt { get; set; }

        [Required]
        [Display(Name = "Earlier IGST")]
        public int o_ig { get; set; }

        [Required]
        [Display(Name = "This month IGST")]
        public int n_ig { get; set; }

        [Required]
        [Display(Name = "Earlier CGST")]
        public int o_cg { get; set; }

        [Required]
        [Display(Name = "This month CGST")]
        public int n_cg { get; set; }

        [Required]
        [Display(Name = "Earlier SGST")]
        public int o_sg { get; set; }

        [Required]
        [Display(Name = "This month SGST")]
        public int n_sg { get; set; }

        [Required]
        [Display(Name = "Earlier CESS")]
        public int o_cs { get; set; }

        [Required]
        [Display(Name = "This month CESS")]
        public int n_cs { get; set; }


        [Display(Name = "Checksum Value")]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string chksum { get; set; }
    }



}