using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Presentacion.Reportes.Caja
{
    public partial class xrpt_arqueo_caja_detallado:DevExpress.XtraReports.UI.XtraReport
    {
        public xrpt_arqueo_caja_detallado( )
        {
            InitializeComponent();
        }

        private void xrpt_arqueo_caja_detallado_BeforePrint(object sender,System.Drawing.Printing.PrintEventArgs e)
        {
          
        }
    }
}
