using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Presentacion.Reportes.Catalogos
{
    public partial class xrptNuevosClientes : DevExpress.XtraReports.UI.XtraReport
    {
        public xrptNuevosClientes()
        {
            InitializeComponent();
           
        }

        private void xrptNuevosClientes_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.DataSource = Negocio.ClasesCN.CatalogosCN.RPTCliente_Cargar(DateTime.Parse(fecha_ini.Value.ToString()), DateTime.Parse(fecha_fin.Value.ToString()));

        }
    }
}
