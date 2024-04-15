using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Windows.Forms;

namespace Presentacion.Reportes.Ventas
{
    public partial class FormaPagoVenta : DevExpress.XtraReports.UI.XtraReport
    {
        public FormaPagoVenta(BindingSource source)
        {
            InitializeComponent();
            this.DataSource = source;
        }
    }
}
