using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Windows.Forms;

namespace Presentacion.Reportes.Inventario
{
    public partial class TrasladoBodega : DevExpress.XtraReports.UI.XtraReport
    {
        public TrasladoBodega(BindingSource source)
        {
            InitializeComponent();
            this.DataSource = source;
        }

    }
}
