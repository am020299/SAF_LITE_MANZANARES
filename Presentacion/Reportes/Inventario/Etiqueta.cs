using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Windows.Forms;
namespace Presentacion.Reportes.Inventario
{
    public partial class Etiqueta : DevExpress.XtraReports.UI.XtraReport
    {
        public Etiqueta(BindingSource source)
        {
            InitializeComponent();
            this.DataSource = source;
        }

    }
}
