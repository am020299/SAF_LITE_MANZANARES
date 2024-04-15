using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Windows.Forms;

namespace Presentacion.Reportes.Ventas
{
    public partial class xrpt_productos_mas_vendidos : DevExpress.XtraReports.UI.XtraReport
    {
        public xrpt_productos_mas_vendidos(BindingSource source)
        {
            InitializeComponent();
            this.DataSource = source;
        }

    }
}
