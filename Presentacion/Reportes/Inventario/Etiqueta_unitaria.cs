using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Windows.Forms;

namespace Presentacion.Reportes.Inventario
{
    public partial class Etiqueta_unitaria : DevExpress.XtraReports.UI.XtraReport
    {
        public Etiqueta_unitaria(BindingSource source)
        {
            InitializeComponent();
            this.DataSource = source;
        }

    }
}
