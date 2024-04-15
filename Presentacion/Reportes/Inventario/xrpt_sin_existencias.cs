using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Windows.Forms;

namespace Presentacion.Reportes.Inventario
{
    public partial class xrpt_sin_existencias:DevExpress.XtraReports.UI.XtraReport
    {
        public xrpt_sin_existencias(BindingSource Recurso)
        {
            InitializeComponent();
            this.DataSource = Recurso;
        }

    }
}
