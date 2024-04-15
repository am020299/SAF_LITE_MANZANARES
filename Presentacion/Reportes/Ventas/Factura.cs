using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Windows.Forms;

namespace Presentacion.Reportes.Ventas
{
    public partial class Factura : DevExpress.XtraReports.UI.XtraReport
    {
        public Factura(BindingSource source)
        {
            InitializeComponent();
            this.DataSource = source;
        }

        private void Factura_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (Parameters[0].Value.Equals(true))
            {
                xrTableCellPrecio.Visible = false;
                xrTableCellPreciobd.Visible = false;
                xrTableCelltotaltxt.Visible = false;
                xrTableCelltotalbd.Visible = false;
                xrTableCelltotalSum.Visible = false;
            }
            else
            {
                xrTableCellPrecio.Visible = true;
                xrTableCellPreciobd.Visible = true;
                xrTableCelltotaltxt.Visible = true;
                xrTableCelltotalbd.Visible = true;
                xrTableCelltotalSum.Visible = true;
            }
        }
    }
}
