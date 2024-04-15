using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Windows.Forms;

namespace Presentacion.Reportes.Inventario
{
    public partial class ListadoDeProductoPorBodega : DevExpress.XtraReports.UI.XtraReport
    {
        public ListadoDeProductoPorBodega()
        {
            InitializeComponent();
        }

        private void ListadoDeProductoPorBodega_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                this.DataSource = Negocio.ClasesCN.InventarioCN.InventarioPorDinero_SelectBodega(int.Parse(parameter1.Value.ToString()));
                if ((bool)parameter2.Value == false)
                {
                    xrTableCell3.Text = "";
                    xrTableCell7.Visible = false;
                    xrTableCell3.Borders = (DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom);//(DevExpress.XtraPrinting.BorderSide)
                    xrTableCell2.Borders = (DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom | DevExpress.XtraPrinting.BorderSide.Left);//(DevExpress.XtraPrinting.BorderSide)
                                                                                                                                                                          //xrTableCell6.Borders = (DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom | DevExpress.XtraPrinting.BorderSide.Right);//(DevExpress.XtraPrinting.BorderSide)
                }
                else
                {
                    xrTableCell3.Text = "UBICACIÓN";
                    xrTableCell7.Visible = true;
                    xrTableCell3.Borders = DevExpress.XtraPrinting.BorderSide.All;
                    xrTableCell2.Borders = DevExpress.XtraPrinting.BorderSide.All;
                    xrTableCell6.Borders = DevExpress.XtraPrinting.BorderSide.All;
                }
            }
            catch (Exception) { }
        }
    }
}
