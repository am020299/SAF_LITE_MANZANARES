using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Presentacion.Reportes.Ventas
{
    public partial class XtraCambioPrecioCLiente : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraCambioPrecioCLiente()
        {
            InitializeComponent();
        }

        private void XtraCambioPrecioCLiente_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            
            this.DataSource = Negocio.ClasesCN.VentasCN.getDetectarCambioPrecioCliente(Convert.ToDateTime(FechaParametro.Value));
        }
    }
}
