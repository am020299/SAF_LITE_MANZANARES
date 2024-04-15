using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Windows.Forms;

namespace Presentacion.Reportes.Compras
{
    public partial class OrdenCompra : DevExpress.XtraReports.UI.XtraReport
    {
        //public int vEstado = 0;
        public OrdenCompra(BindingSource source)
        {
            InitializeComponent();
            this.DataSource = source;
            //this.vEstado = vEstado;
        }



    }
}
