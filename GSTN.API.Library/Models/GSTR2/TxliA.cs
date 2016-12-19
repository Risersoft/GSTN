using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSTN.API.GSTR2
{
    public class TxliA
    {

        [Required]
        [Display(Name = "Original - GSTIN of the Receiver/UID of UN bodies/ Govt. Department ID of Government")]
        [MaxLength(15)]
        [MinLength(15)]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string ogstin { get; set; }

        [Required]
        [Display(Name = "Original Name of Recepient")]
        [MaxLength(30)]
        public string orname { get; set; }

        [Required]
        [Display(Name = "Original  Supplier Document Number")]
        [MaxLength(10)]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string odnum { get; set; }

        [Required]
        [Display(Name = "Original  Supplier Document Date")]
        [RegularExpression("^((0[1-9]|[12][0-9]|3[01])[-](0[1-9]|1[012])[-]((19|20)\\d\\d))*$")]
        public string otdt { get; set; }

        [Required]
        [Display(Name = "GSTIN/UID of the Receiver taxpayer/UN, Govt Bodies")]
        [MaxLength(15)]
        [MinLength(15)]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string rtin { get; set; }

        [Required]
        [Display(Name = "Name of customer")]
        [MaxLength(30)]
        public string rname { get; set; }

        [Required]
        [Display(Name = "Recipient State Code")]
        public int st_cd { get; set; }

        [Required]
        [Display(Name = "Supplier Document Number")]
        [MaxLength(10)]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string dnum { get; set; }

        [Required]
        [Display(Name = "Supplier Document Date")]
        [RegularExpression("^((0[1-9]|[12][0-9]|3[01])[-](0[1-9]|1[012])[-]((19|20)\\d\\d))*$")]
        public string dt { get; set; }

        [Required]
        [Display(Name = "itms")]
        public List<TxliItm> itms { get; set; }


        [Display(Name = "Invoice Check sum value")]
        [MaxLength(15)]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string chksum { get; set; }
    }

}
