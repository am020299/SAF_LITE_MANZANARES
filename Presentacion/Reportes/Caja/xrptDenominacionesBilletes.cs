using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Presentacion.Reportes.Caja
{
    public partial class xrptDenominacionesBilletes : DevExpress.XtraReports.UI.XtraReport
    {
        public xrptDenominacionesBilletes()
        {
            InitializeComponent();
           
        }

        private void xrptNuevosClientes_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            DateTime fecha_inicial = DateTime.Parse(fecha_ini.Value.ToString()).Date;
            DateTime fecha_final = DateTime.Parse(fecha_fin.Value.ToString()).AddDays(1).AddSeconds(-1).Date;
            this.DataSource = Negocio.ClasesCN.CatalogosCN.RPTDenominaciones_Billetes(DateTime.Parse(fecha_inicial.ToString()), DateTime.Parse(fecha_final.ToString()));
            //objectDataSource2.DataSource = Negocio.ClasesCN.CatalogosCN.RPTDenominaciones_Billetes_1000_500(DateTime.Parse(fecha_ini.Value.ToString()), DateTime.Parse(fecha_fin.Value.ToString()));
            //objectDataSource3.DataSource = Negocio.ClasesCN.CatalogosCN.RPTDenominaciones_Billetes_200_100_50_20_10(DateTime.Parse(fecha_ini.Value.ToString()), DateTime.Parse(fecha_fin.Value.ToString()));
            //objectDataSource4.DataSource = Negocio.ClasesCN.CatalogosCN.RPTDenominaciones_Billetes_100_50_Dol(DateTime.Parse(fecha_ini.Value.ToString()), DateTime.Parse(fecha_fin.Value.ToString()));
            //objectDataSource5.DataSource = Negocio.ClasesCN.CatalogosCN.RPTDenominaciones_Billetes_20_10_5_1_Dol(DateTime.Parse(fecha_ini.Value.ToString()), DateTime.Parse(fecha_fin.Value.ToString()));


        }
    }
}
