using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Windows.Forms;

namespace Presentacion.Reportes.Inventario
{
    public partial class xrpt_ajuste_MCarta : DevExpress.XtraReports.UI.XtraReport
    {
        public xrpt_ajuste_MCarta(BindingSource source)
        {
            InitializeComponent();
            this.DataSource = source;
        }

    }
}
