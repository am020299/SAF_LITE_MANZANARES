using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Windows.Forms;

namespace Presentacion.Reportes.Ventas
{
    public partial class Prestamo : DevExpress.XtraReports.UI.XtraReport
    {
        public Prestamo(BindingSource source)
        {
            InitializeComponent();
            this.DataSource = source;
        }

    }
}
