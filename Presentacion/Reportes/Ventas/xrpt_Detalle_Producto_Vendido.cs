using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Windows.Forms;

namespace Presentacion.Reportes.Ventas
{
    public partial class xrpt_Detalle_Producto_Vendido : DevExpress.XtraReports.UI.XtraReport
    {
        public xrpt_Detalle_Producto_Vendido(BindingSource source)
        {
            InitializeComponent();
            this.DataSource = source;
        }
    }
}
