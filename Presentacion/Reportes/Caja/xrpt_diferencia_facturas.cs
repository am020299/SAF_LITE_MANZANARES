using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Windows.Forms;

namespace Presentacion.Reportes.Caja
{
    public partial class xrpt_diferencia_facturas:DevExpress.XtraReports.UI.XtraReport
    {
        public xrpt_diferencia_facturas(BindingSource Recurso)
        {
            InitializeComponent();
            this.DataSource = Recurso;
        }

    }
}
