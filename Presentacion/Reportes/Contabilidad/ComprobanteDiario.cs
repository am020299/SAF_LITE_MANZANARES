using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Windows.Forms;

namespace Presentacion.Reportes.Contabilidad
{
    public partial class ComprobanteDiario:DevExpress.XtraReports.UI.XtraReport
    {
        public ComprobanteDiario(BindingSource DataSource)
        {
            InitializeComponent();
            this.DataSource=DataSource;
        }

    }
}
