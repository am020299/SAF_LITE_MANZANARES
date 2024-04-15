using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Presentacion.Reportes.Inventario
{
    public partial class xrpt_cambioClientes : DevExpress.XtraReports.UI.XtraReport
    {
        public xrpt_cambioClientes(BindingSource source)
        {
            InitializeComponent();
            this.DataSource = source;
        }

    }
}
