using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Presentacion.Reportes.Ventas
{
    public partial class DetalleResumenVtasporFecha : DevExpress.XtraReports.UI.XtraReport
    {
        public DetalleResumenVtasporFecha(BindingSource source)
        {
            InitializeComponent();
            this.DataSource = source;
        }

    }
}
