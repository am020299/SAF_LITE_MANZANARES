using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Windows.Forms;

namespace Presentacion.Reportes.CuentasCobrar
{
    public partial class xrpt_DocumentosRangoFechas:DevExpress.XtraReports.UI.XtraReport
    {
        public xrpt_DocumentosRangoFechas(BindingSource source)
        {
            InitializeComponent();
            this.DataSource=source;
        }

    }
}
