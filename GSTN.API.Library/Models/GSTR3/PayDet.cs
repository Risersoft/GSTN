using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSTN.API.GSTR3
{
    public class Tctp
    {

        [Required]
        [Display(Name = "Total tax liability for the tax period arisiong out of GSTR-1 and GSTR-2")]
        public double pay { get; set; }

        [Required]
        [Display(Name = "Tax Paid from Cash ledger")]
        public double csh_dbno { get; set; }

        [Required]
        [Display(Name = "IGST paid using  Cash balance")]
        public double csh_iamt { get; set; }

        [Required]
        [Display(Name = "CGST paid using  Cash balance")]
        public double csh_camt { get; set; }

        [Required]
        [Display(Name = "SGST paid using  Cash balance")]
        public double csh_samt { get; set; }

        [Required]
        [Display(Name = "Addtional Tax paid using  Cash balance")]
        public double csh_aamt { get; set; }

        [Required]
        [Display(Name = "Tax Paid from ITC ledger")]
        public double itc_dbno { get; set; }

        [Required]
        [Display(Name = "IGST paid using  ITC balance")]
        public double itc_iamt { get; set; }

        [Required]
        [Display(Name = "CGST paid using  ITC balance")]
        public double itc_camt { get; set; }

        [Required]
        [Display(Name = "SGST paid using  ITC balance")]
        public double itc_samt { get; set; }

        [Required]
        [Display(Name = "Addtional Tax paid using  ITC balance")]
        public double itc_aamt { get; set; }
    }

    public class Tptp
    {

        [Required]
        [Display(Name = "Total tax liability for the tax period arisiong out of GSTR-1 and GSTR-2")]
        public double pay { get; set; }

        [Required]
        [Display(Name = "Tax Paid from Cash ledger")]
        public double csh_dbno { get; set; }

        [Required]
        [Display(Name = "IGST paid using  Cash balance")]
        public double csh_iamt { get; set; }

        [Required]
        [Display(Name = "CGST paid using  Cash balance")]
        public double csh_camt { get; set; }

        [Required]
        [Display(Name = "SGST paid using  Cash balance")]
        public double csh_samt { get; set; }


        [Required]
        [Display(Name = "Addtional Tax paid using  Cash balance")]
        public double csh_aamt { get; set; }

        [Required]
        [Display(Name = "Tax Paid from ITC ledger")]
        public double itc_dbno { get; set; }

        [Required]
        [Display(Name = "IGST paid using  ITC balance")]
        public double itc_iamt { get; set; }

        [Required]
        [Display(Name = "CGST paid using  ITC balance")]
        public double itc_camt { get; set; }

        [Required]
        [Display(Name = "SGST paid using  ITC balance")]
        public double itc_samt { get; set; }

        [Required]
        [Display(Name = "Addtional Tax paid using  ITC balance")]
        public double itc_aamt { get; set; }
    }

    public class Txli
    {

        [Required]
        [Display(Name = "Total tax liability for the tax period arisiong out of GSTR-1 and GSTR-2")]
        public double pay { get; set; }

        [Required]
        [Display(Name = "Tax Paid from Cash ledger")]
        public double csh_dbno { get; set; }

        [Required]
        [Display(Name = "IGST paid using  Cash balance")]
        public double csh_iamt { get; set; }

        [Required]
        [Display(Name = "CGST paid using  Cash balance")]
        public double csh_camt { get; set; }

        [Required]
        [Display(Name = "SGST paid using  Cash balance")]
        public double csh_samt { get; set; }


        [Required]
        [Display(Name = "Addtional Tax paid using  Cash balance")]
        public double csh_aamt { get; set; }

        [Required]
        [Display(Name = "Tax Paid from ITC ledger")]
        public double itc_dbno { get; set; }

        [Required]
        [Display(Name = "IGST paid using  ITC balance")]
        public double itc_iamt { get; set; }

        [Required]
        [Display(Name = "CGST paid using  ITC balance")]
        public double itc_camt { get; set; }

        [Required]
        [Display(Name = "SGST paid using  ITC balance")]
        public double itc_samt { get; set; }

        [Required]
        [Display(Name = "Addtional Tax paid using  ITC balance")]
        public double itc_aamt { get; set; }
    }

    public class Intr
    {

        [Required]
        [Display(Name = "Total tax liability for the tax period arisiong out of GSTR-1 and GSTR-2")]
        public double pay { get; set; }

        [Required]
        [Display(Name = "Tax Paid from Cash ledger")]
        public double csh_dbno { get; set; }

        [Required]
        [Display(Name = "IGST paid using  Cash balance")]
        public double csh_iamt { get; set; }

        [Required]
        [Display(Name = "CGST paid using  Cash balance")]
        public double csh_camt { get; set; }

        [Required]
        [Display(Name = "SGST paid using  Cash balance")]
        public double csh_samt { get; set; }

        [Required]
        [Display(Name = "Addtional Tax paid using  Cash balance")]
        public double csh_aamt { get; set; }

        [Required]
        [Display(Name = "Tax Paid from ITC ledger")]
        public double itc_dbno { get; set; }

        [Required]
        [Display(Name = "IGST paid using  ITC balance")]
        public double itc_iamt { get; set; }

        [Required]
        [Display(Name = "CGST paid using  ITC balance")]
        public double itc_camt { get; set; }

        [Required]
        [Display(Name = "SGST paid using  ITC balance")]
        public double itc_samt { get; set; }

        [Required]
        [Display(Name = "Addtional Tax paid using  ITC balance")]
        public double itc_aamt { get; set; }
    }

    public class Lfee
    {

        [Required]
        [Display(Name = "Total tax liability for the tax period arisiong out of GSTR-1 and GSTR-2")]
        public double pay { get; set; }

        [Required]
        [Display(Name = "Tax Paid from Cash ledger")]
        public double csh_dbno { get; set; }

        [Required]
        [Display(Name = "IGST paid using  Cash balance")]
        public double csh_iamt { get; set; }

        [Required]
        [Display(Name = "CGST paid using  Cash balance")]
        public double csh_camt { get; set; }

        [Required]
        [Display(Name = "SGST paid using  Cash balance")]
        public double csh_samt { get; set; }

        [Required]
        [Display(Name = "Addtional Tax paid using  Cash balance")]
        public double csh_aamt { get; set; }

        [Required]
        [Display(Name = "Tax Paid from ITC ledger")]
        public double itc_dbno { get; set; }

        [Required]
        [Display(Name = "IGST paid using  ITC balance")]
        public double itc_iamt { get; set; }

        [Required]
        [Display(Name = "CGST paid using  ITC balance")]
        public double itc_camt { get; set; }

        [Required]
        [Display(Name = "SGST paid using  ITC balance")]
        public double itc_samt { get; set; }

        [Required]
        [Display(Name = "Addtional Tax paid using  ITC balance")]
        public double itc_aamt { get; set; }
    }

    public class Pnlty
    {

        [Required]
        [Display(Name = "Total tax liability for the tax period arisiong out of GSTR-1 and GSTR-2")]
        public double pay { get; set; }

        [Required]
        [Display(Name = "Tax Paid from Cash ledger")]
        public double csh_dbno { get; set; }

        [Required]
        [Display(Name = "IGST paid using  Cash balance")]
        public double csh_iamt { get; set; }

        [Required]
        [Display(Name = "CGST paid using  Cash balance")]
        public double csh_camt { get; set; }

        [Required]
        [Display(Name = "SGST paid using  Cash balance")]
        public double csh_samt { get; set; }

        [Required]
        [Display(Name = "Addtional Tax paid using  Cash balance")]
        public double csh_aamt { get; set; }

        [Required]
        [Display(Name = "Tax Paid from ITC ledger")]
        public double itc_dbno { get; set; }

        [Required]
        [Display(Name = "IGST paid using  ITC balance")]
        public double itc_iamt { get; set; }

        [Required]
        [Display(Name = "CGST paid using  ITC balance")]
        public double itc_camt { get; set; }

        [Required]
        [Display(Name = "SGST paid using  ITC balance")]
        public double itc_samt { get; set; }

        [Required]
        [Display(Name = "Addtional Tax paid using  ITC balance")]
        public double itc_aamt { get; set; }
    }

    public class Othrs
    {

        [Required]
        [Display(Name = "Total tax liability for the tax period arisiong out of GSTR-1 and GSTR-2")]
        public double pay { get; set; }

        [Required]
        [Display(Name = "Tax Paid from Cash ledger")]
        public double csh_dbno { get; set; }

        [Required]
        [Display(Name = "IGST paid using  Cash balance")]
        public double csh_iamt { get; set; }

        [Required]
        [Display(Name = "CGST paid using  Cash balance")]
        public double csh_camt { get; set; }

        [Required]
        [Display(Name = "SGST paid using  Cash balance")]
        public double csh_samt { get; set; }

        [Required]
        [Display(Name = "Addtional Tax paid using  Cash balance")]
        public double csh_aamt { get; set; }

        [Required]
        [Display(Name = "Tax Paid from ITC ledger")]
        public double itc_dbno { get; set; }

        [Required]
        [Display(Name = "IGST paid using  ITC balance")]
        public double itc_iamt { get; set; }

        [Required]
        [Display(Name = "CGST paid using  ITC balance")]
        public double itc_camt { get; set; }

        [Required]
        [Display(Name = "SGST paid using  ITC balance")]
        public double itc_samt { get; set; }

        [Required]
        [Display(Name = "Addtional Tax paid using  ITC balance")]
        public double itc_aamt { get; set; }
    }




    public class PayDet
    {

        [Required]
        [Display(Name = "tctp")]
        public Tctp tctp { get; set; }

        [Required]
        [Display(Name = "tptp")]
        public Tptp tptp { get; set; }

        [Required]
        [Display(Name = "txli")]
        public Txli txli { get; set; }

        [Required]
        [Display(Name = "Interest")]
        public Intr intr { get; set; }

        [Required]
        [Display(Name = "Late fee")]
        public Lfee lfee { get; set; }

        [Required]
        [Display(Name = "Penalty")]
        public Pnlty pnlty { get; set; }

        [Required]
        [Display(Name = "Others")]
        public Othrs othrs { get; set; }
    }
}
