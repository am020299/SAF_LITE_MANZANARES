using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Windows.Forms;

namespace Presentacion.Reportes.CuentasCobrar
{
    public partial class xrpt_lista_cxc : DevExpress.XtraReports.UI.XtraReport
    {
        public xrpt_lista_cxc(BindingSource source)
        {
            InitializeComponent();

            this.DataSource = source;
        }

    }
}
