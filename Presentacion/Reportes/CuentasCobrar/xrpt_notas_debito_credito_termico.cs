using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Windows.Forms;

namespace Presentacion.Reportes.CuentasCobrar
{
    public partial class xrpt_notas_debito_credito_termico:DevExpress.XtraReports.UI.XtraReport
    {
        public xrpt_notas_debito_credito_termico(BindingSource source)
        {
            InitializeComponent();
            this.DataSource=source;
        }

    }
}
