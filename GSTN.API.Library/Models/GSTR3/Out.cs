using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GSTN.API.GSTR3
{


    public class Out
    {
        [Required]
        [Display(Name = "Inter-state supplies to Registered taxpayers")]
        public List<IntrSupConReg> inter { get; set; }

        [Required]
        [Display(Name = "Intra-State Supplies to Registered taxpayers")]
        public List<IntraSupConReg> intra { get; set; }

        [Required]
        [Display(Name = "Inter-State Supplies to Consumers")]
        public List<IntrSupConReg> inter_c { get; set; }

        [Required]
        [Display(Name = "Intra-State Supplies to Consumers")]
        public List<IntraSupConReg> intra_c { get; set; }

        [Required]
        [Display(Name = "Exports")]
        public List<Exp> exp { get; set; }

        [Required]
        [Display(Name = "Revision of invoices")]
        public List<RevInv> revsup { get; set; }

        [Required]
        [Display(Name = "Total Tax Liability on Outward supplies")]
        public List<Ttl2> ttxliab { get; set; }
    }
}