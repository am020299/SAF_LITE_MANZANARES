using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;

namespace Presentacion.Formularios.CuentasCobrar
{
    public partial class xfrm_lista_cxc : DevExpress.XtraEditors.XtraForm
    {
        Int32 estado;
        public xfrm_lista_cxc()
        {
            InitializeComponent();
        }

        private void xfrm_lista_cxc_Load(object sender, EventArgs e)
        {
            combo_estado.SelectedIndex = 0;
            //DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(typeof(Principal.WaitForm1));
            //carga_datos();
            //DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm();
        }

        public void carga_datos()
        {
            binding_datos.DataSource = Negocio.ClasesCN.CuentasCobrarCN.cxc_clientes(estado);
            grid_datos.DataSource = binding_datos;
            view_datos.BestFitColumns();
        }

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_estado.SelectedIndex==0)
            {
                estado = 1;
            }
            else
            {
                estado = 2;
            }

            //DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(typeof(Principal.WaitForm1));
            carga_datos();
            //DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm();
        }

        private void bbi_cargar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(typeof(Principal.WaitForm1));
            carga_datos();
            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm();
        }

        private void bbi_exportar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (view_datos.RowCount>0) {
                Clases.Exportar ex = new Clases.Exportar();
                ex.Exportar_Grid_A_Excel(grid_datos);
            }
        }

        public void carga_reporte()
        {
            binding_datos.DataSource = Negocio.ClasesCN.CuentasCobrarCN.cxc_clientes(estado);

            Reportes.CuentasCobrar.xrpt_lista_cxc report = new Reportes.CuentasCobrar.xrpt_lista_cxc(binding_datos);
            report.Parameters[0].Value = DateTime.Today.Date;
            report.Parameters[0].Visible = false;
            report.ShowPreview();
        }

        private void bbi_reporte_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(typeof(Principal.WaitForm1));
            carga_reporte();
            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm();
        }
    }
}