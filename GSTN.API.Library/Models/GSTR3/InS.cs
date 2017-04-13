using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GSTN.API.GSTR3
{
    public class InS
    {
        [Required]
        [Display(Name = "Inter-State supplies received")]
        public List<IntrSupRec> inter { get; set; }

        [Required]
        [Display(Name = "Intra-State supplies received")]
        public List<ItraSupRec> intra { get; set; }

        [Required]
        [Display(Name = "Imports")]
        public Imp imp { get; set; }

        [Required]
        [Display(Name = "Revision of Invoices")]
        public List<RevInv2> revrec { get; set; }

        [Required]
        [Display(Name = "Total Tax liability on inward supplies on reverse charge")]
        public List<Ttl> tx_liab { get; set; }

        [Required]
        [Display(Name = "ITC Reversal")]
        public List<ItcRev> itc_rev { get; set; }

        [Required]
        [Display(Name = "Job Work")]
        public List<JobWork> jb_wrk { get; set; }
    }

}
