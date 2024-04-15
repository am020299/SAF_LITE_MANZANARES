using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Windows.Forms;

namespace Presentacion.Reportes.CuentasCobrar
{
    public partial class xrpt_nota_debito_credito:DevExpress.XtraReports.UI.XtraReport
    {
        public xrpt_nota_debito_credito(BindingSource source)
        {
            InitializeComponent();
            this.DataSource=source;
        }

        private void xrpt_nota_debito_credito_BeforePrint(object sender,System.Drawing.Printing.PrintEventArgs e)
        {

        }
    }
}
