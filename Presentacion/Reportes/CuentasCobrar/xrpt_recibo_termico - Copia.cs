using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Windows.Forms;

namespace Presentacion.Reportes.CuentasCobrar
{
    public partial class xrpt_recibo_termico:DevExpress.XtraReports.UI.XtraReport
    {
        public xrpt_recibo_termico(BindingSource source)
        {
            InitializeComponent();
            this.DataSource=source;
        }

    }
}
