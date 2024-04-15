using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Windows.Forms;

namespace Presentacion.Reportes.Inventario
{
    public partial class InventarioPorDinero : DevExpress.XtraReports.UI.XtraReport
    {
        public InventarioPorDinero()
        {
            InitializeComponent();
        }

        private void InventarioPorDinero_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.DataSource = Negocio.ClasesCN.InventarioCN.InventarioPorDinero_SelectBodega(int.Parse(parameter1.Value.ToString()));
        }
    }
}
