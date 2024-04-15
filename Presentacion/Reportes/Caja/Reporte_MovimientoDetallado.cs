using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Windows.Forms;

namespace Presentacion.Reportes.Caja
{
    public partial class Reporte_MovimientoDetallado : DevExpress.XtraReports.UI.XtraReport
    {
        public Reporte_MovimientoDetallado(BindingSource source)
        {
            InitializeComponent();
            this.DataSource = source;
        }

    }
}
