using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Windows.Forms;

namespace Presentacion.Reportes.Autorizacion
{
    public partial class xrpt_autorizacion : DevExpress.XtraReports.UI.XtraReport
    {
        public xrpt_autorizacion()
        {
            InitializeComponent();
            //this.DataSource = source;
        }

        private void xrpt_autorizacion_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.DataSource = Negocio.ClasesCN.CatalogosCN.RPTAutorizacion(DateTime.Parse(parameter1.Value.ToString()), DateTime.Parse(parameter2.Value.ToString()), Convert.ToInt32(parameter3.Value.ToString()));
        }
    }
}
