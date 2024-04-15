using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Windows.Forms;
//using System.Activities.Expressions;

namespace Presentacion.Reportes.Ventas
{
    public partial class FacturaTermicaPrestamos : DevExpress.XtraReports.UI.XtraReport
    {
        BindingSource _source;
        public FacturaTermicaPrestamos(BindingSource source)
        {
            InitializeComponent();
            this.DataSource = source;
        }

        private void FacturaTermica_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

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
