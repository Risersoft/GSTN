using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSTN.API.GSTR3
{

    public class RfdTc
    {

        [Required]
        [Display(Name = "CGST Refund")]
        public double itc_camt { get; set; }

        [Required]
        [Display(Name = "SGST Refund")]
        public double itc_samt { get; set; }

        [Required]
        [Display(Name = "IGST Refund")]
        public double itc_iamt { get; set; }
    }

    public class ExTpRfd
    {

        [Required]
        [Display(Name = "CGST Refund")]
        public double ex_rf_camt { get; set; }

        [Required]
        [Display(Name = "SGST Refund")]
        public double ex_rf_samt { get; set; }

        [Required]
        [Display(Name = "IGST Refund")]
        public double ex_rf_iamt { get; set; }
    }

    public class ExTpAdj
    {

        [Required]
        [Display(Name = "CGST Refund")]
        public double ex_cl_camt { get; set; }

        [Required]
        [Display(Name = "SGST Refund")]
        public double ex_cl_samt { get; set; }

        [Required]
        [Display(Name = "IGST Refund")]
        public double ex_cl_iamt { get; set; }
    }

    public class ExTp
    {

        [Required]
        [Display(Name = "ex_tp_rfd")]
        public ExTpRfd ex_tp_rfd { get; set; }

        [Required]
        [Display(Name = "ex_tp_adj")]
        public ExTpAdj ex_tp_adj { get; set; }
    }

    public class RfdCl
    {

        [Required]
        [Display(Name = "CGST Refund")]
        public double rf_cl_camt { get; set; }

        [Required]
        [Display(Name = "SGST Refund")]
        public double rf_cl_samt { get; set; }

        [Required]
        [Display(Name = "IGST Refund")]
        public double rf_cl_iamt { get; set; }
    }

    public class BnkNum
    {

        [Required]
        [Display(Name = "CGST Refund")]
        public double b_camt { get; set; }

        [Required]
        [Display(Name = "SGST Refund")]
        public double b_samt { get; set; }

        [Required]
        [Display(Name = "IGST Refund")]
        public double b_iamt { get; set; }
    }


    public class RfClm
    {

        [Required]
        [Display(Name = "rfd_tc")]
        public RfdTc rfd_tc { get; set; }

        [Required]
        [Display(Name = "ex_tp")]
        public ExTp ex_tp { get; set; }

        [Required]
        [Display(Name = "rfd_cl")]
        public RfdCl rfd_cl { get; set; }

        [Required]
        [Display(Name = "bnk_num")]
        public BnkNum bnk_num { get; set; }
    }

}
