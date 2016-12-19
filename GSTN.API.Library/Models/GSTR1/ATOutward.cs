using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace GSTN.API.GSTR1
{
   

    public class AtOutward
    {

        [Required]
        [Display(Name = "flag for action")]
        public string flag { get; set; }

        [Required]
        [Display(Name = "GSTIN/UID of the Receiver taxpayer/UN,Govt Bodies")]
        [MaxLength(15)]
        [MinLength(15)]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string ctin { get; set; }

        [Required]
        [Display(Name = "Name of Recipient")]
        [RegularExpression("^[a-zA-Z0-9._\\s]+$")]
        public string cname { get; set; }

        [Required]
        [Display(Name = "Recipient State Code")]
        public string supst_cd { get; set; }

        [Required]
        [Display(Name = "Supplier Document Number")]
        public string doc_num { get; set; }

        [Required]
        [Display(Name = "Supplier Document Date")]
        [RegularExpression("^((0[1-9]|[12][0-9]|3[01])[-](0[1-9]|1[012])[-]((19|20)\\d\\d))*$")]
        public string doc_dt { get; set; }

        [Required]
        [Display(Name = "Amount of Advance received")]
        public double adamt { get; set; }

        [Required]
        [Display(Name = "Item Details")]
        public List<Itm> itms { get; set; }


        [Display(Name = "Invoice Check sum value")]
        public string Chksum { get; set; }
    }

 
}