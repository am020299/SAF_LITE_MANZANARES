using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Windows.Forms;

namespace Presentacion.Reportes.Caja
{
    public partial class ReporteDeEgresos : DevExpress.XtraReports.UI.XtraReport
    {
        public ReporteDeEgresos(BindingSource source)
        {
            InitializeComponent();
            this.DataSource = source;
        }

    }
}
