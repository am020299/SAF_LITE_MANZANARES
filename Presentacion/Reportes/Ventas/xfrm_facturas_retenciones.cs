using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace Presentacion.Reportes.Ventas
{
    public partial class xfrm_facturas_retenciones : DevExpress.XtraReports.UI.XtraReport
    {
        public xfrm_facturas_retenciones()
        {
            InitializeComponent();
        }

        private void xfrm_facturas_retenciones_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.DataSource = Negocio.ClasesCN.CatalogosCN.FacturasConRetenciones(DateTime.Parse(fecha_ini.Value.ToString()), DateTime.Parse(fecha_fin.Value.ToString()));
        }
    }
}
