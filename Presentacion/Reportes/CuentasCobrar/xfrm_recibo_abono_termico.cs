using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Windows.Forms;

namespace Presentacion.Reportes.CuentasCobrar
{
    public partial class xfrm_recibo_abono_termico : DevExpress.XtraReports.UI.XtraReport
    {
        public xfrm_recibo_abono_termico(BindingSource source)
        {
            InitializeComponent();
            this.DataSource=source;
        }

        private void xfrm_recibo_abono_BeforePrint(object sender,System.Drawing.Printing.PrintEventArgs e)
        {

        }
    }
}
