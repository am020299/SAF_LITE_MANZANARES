using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Presentacion.Reportes.Ventas
{
    public partial class xrpt_cliente_frecuentesV2 : DevExpress.XtraReports.UI.XtraReport
    {
        DateTime fechaIni, fechaFin;
        public xrpt_cliente_frecuentesV2(DateTime vFechaInicio, DateTime vFechaFinal)
        {
            InitializeComponent();
            this.fechaIni = vFechaInicio;
            this.fechaFin = vFechaFinal;
        }

        private void xrpt_cliente_frecuentes_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            xrLabelFECHA.Text =  fechaIni.ToString("dd/MM/yyyy") +" AL "+fechaFin.Date.ToString("dd/MM/yyyy");
        }
    }
}
