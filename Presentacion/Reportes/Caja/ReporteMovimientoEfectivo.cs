using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Windows.Forms;

namespace Presentacion.Reportes.Caja
{
    public partial class ReporteMovimientoEfectivo : DevExpress.XtraReports.UI.XtraReport
    {
        public ReporteMovimientoEfectivo(BindingSource source)
        {
            InitializeComponent();
            this.DataSource = source;
        }

    }
}
