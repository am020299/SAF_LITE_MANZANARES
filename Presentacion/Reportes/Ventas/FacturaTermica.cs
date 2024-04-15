using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Windows.Forms;
//using System.Activities.Expressions;

namespace Presentacion.Reportes.Ventas
{
    public partial class FacturaTermica : DevExpress.XtraReports.UI.XtraReport
    {
        BindingSource _source;
        public FacturaTermica(BindingSource source)
        {
            InitializeComponent();
            this.DataSource = source;
        }

        private void FacturaTermica_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //this.xrSubreport1.ReportSource = new FormaPagoVenta(_source);
            if (Parameters[0].Value.Equals(true))
            {
                xrLabelPrecio.Visible = false;
                xrTableCellTotal.Visible = false;
                xrLabelTotal.Visible = false;
                xrRichTextMonedaFactura.Visible = false;
            }
            else
            {
                xrLabelPrecio.Visible = true;
                xrTableCellTotal.Visible = true;
                xrLabelTotal.Visible = true;
                xrRichTextMonedaFactura.Visible = true;
            }

            if(Parameters[1].Value.Equals(true))
            {
                xrLabel9.Visible = false;
            }
            else
            {
                xrLabel9.Visible = true;
            }
           
        }

        private void ReportFooter_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
        }
    }
}
