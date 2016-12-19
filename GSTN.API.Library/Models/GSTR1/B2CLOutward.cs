using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace GSTN.API.GSTR1
{
    

    public class B2CLInv
    {
        [Required]
        [Display(Name = "Counterparty Name")]
        [MaxLength(100)]
        [RegularExpression("^[a-zA-Z._\\s]+$")]
        public string cname { get; set; }

        [Required]
        [Display(Name = "Supplier Invoice Number")]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string inum { get; set; }

        [Required]
        [Display(Name = "Revised Supplier Invoice Date")]
        [RegularExpression("^((0[1-9]|[12][0-9]|3[01])[-](0[1-9]|1[012])[-]((19|20)\\d\\d))*$")]
        public string idt { get; set; }

        [Required]
        [Display(Name = "Revised Supplier Invoice Value")]
        public double val { get; set; }

        [Required]
        [Display(Name = "Place of supply")]
        public string pos { get; set; }

        [Required]
        [Display(Name = "Reverse Charge")]
        public string rchrg { get; set; }

        [Required]
        [Display(Name = "Provisional assessment")]
        public string pro_ass { get; set; }

      
        [Required]
        public List<Itm> itms { get; set; }

        [Display(Name = "Checksum Value")]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string chksum { get; set; }
    }

    public class B2clOutward
    {

        [Required]
        [Display(Name = "Receipient State Code")]
        public string state_cd { get; set; }

        [Required]
        public List<B2CLInv> inv { get; set; }
    }


}