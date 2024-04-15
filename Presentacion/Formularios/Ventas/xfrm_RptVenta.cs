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
using System.Data.Entity.SqlServer;
using DevExpress.XtraReports.Parameters;

namespace Presentacion.Formularios.Ventas
{
    public partial class xfrm_RptVenta : DevExpress.XtraEditors.XtraForm
    {
        public xfrm_RptVenta()
        {
            InitializeComponent();
        }
        private DateTime _vFechaInicial;
        private DateTime _vFechaFinal;

        public DateTime vFechaInicial { get => _vFechaInicial; set => _vFechaInicial = value; }
        public DateTime vFechaFinal { get => _vFechaFinal; set => _vFechaFinal = value; }

        private void xfrm_RptVenta_Load(object sender, EventArgs e)
        {
            CargarDatosIniciales();
            radioGroup1.EditValue = "4";
        }
        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                switch (radioGroup1.EditValue.ToString())
                {
                    case "1":
                        dateInicio.Enabled = true;
                        dateFin.Enabled = false;
                        layoutAño.Visibility = layoutMes.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                        layoutFechaInicio.Visibility = layoutFechaFin.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                        vFechaInicial = Convert.ToDateTime(dateInicio.EditValue);
                        vFechaFinal = Convert.ToDateTime(dateInicio.EditValue);
                        dateInicio.Focus();
                        break;

                    case "2":
                        cbAño.Enabled = true;
                        cbMes.Enabled = true;
                        layoutAño.Visibility = layoutMes.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                        layoutFechaInicio.Visibility = layoutFechaFin.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                        cbMes.Focus();
                        vFechaInicial = new DateTime(int.Parse(cbAño.Text), cbMes.SelectedIndex + 1, 1);
                        vFechaFinal = vFechaInicial.AddMonths(1).AddDays(-1);
                        break;

                    case "3":
                        cbAño.Enabled = true;
                        cbMes.Enabled = false;
                        layoutAño.Visibility = layoutMes.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                        layoutFechaInicio.Visibility = layoutFechaFin.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                        cbAño.Focus();
                        vFechaInicial = new DateTime(int.Parse(cbAño.Text), 1, 1);
                        vFechaFinal = new DateTime(int.Parse(cbAño.Text), 12, 31);
                        break;

                    case "4":
                        dateInicio.Enabled = true;
                        dateFin.Enabled = true;
                        layoutAño.Visibility = layoutMes.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                        layoutFechaInicio.Visibility = layoutFechaFin.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                        dateInicio.Focus();
                        vFechaInicial = Convert.ToDateTime(dateInicio.EditValue);
                        vFechaFinal = Convert.ToDateTime(dateFin.EditValue);
                        break;
                }
            }
            catch (Exception) { _vFechaInicial = vFechaFinal = DateTime.Now; }
        }

        void CargarDatosIniciales()
        {
            try
            {
                DateTime vMin = Negocio.ClasesCN.VentasCN.getVentas().Min(x => x.fecha);
                DateTime vMax = Negocio.ClasesCN.VentasCN.getVentas().Max(x => x.fecha);
                dateInicio.Properties.MinValue = vMin;
                dateInicio.Properties.MaxValue = vMax;
                dateFin.Properties.MinValue = vMin;
                dateFin.Properties.MaxValue = vMax;
                dateInicio.EditValue = DateTime.Now;
                dateFin.EditValue = DateTime.Now;
                cbMes.SelectedIndex = DateTime.Now.Month - 1;
                var query = Negocio.ClasesCN.VentasCN.getVentas().OrderByDescending(x => x.fecha).Select(x => x.fecha.Year).Distinct().ToList();
                foreach (var list in query)
                {
                    cbAño.Properties.Items.Add(list.ToString());
                }
                cbAño.SelectedIndex = 0;
            }
            catch (Exception) { }
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {

            XtraReport reporte = new XtraReport();
            reporte.CreateDocument();

            source.DataSource = Negocio.ClasesCN.VentasCN.VentasPorFechas(1, vFechaInicial, vFechaFinal).Where(x => x.moneda == 1);
            if (source.Count == 0) return;

            var reportDetalle = new Reportes.Ventas.DetalleResumenVtasporFecha(source);
            reportDetalle.Parameters[0].Value = vFechaInicial;
            reportDetalle.Parameters[1].Value = _vFechaFinal;
            reportDetalle.Parameters[2].Value = 1;
            reportDetalle.CreateDocument();
            reporte.Pages.AddRange(reportDetalle.Pages);

            var report = new Reportes.Ventas.VentasPorFecha(source);
            report.Parameters[0].Value = vFechaInicial;
            report.Parameters[1].Value = _vFechaFinal;
            report.CreateDocument();
            reporte.Pages.AddRange(report.Pages);

            if(reporte.Pages.Count > 0)
            {
                reporte.ShowPreview();
            }
        }

        private void btnVentasPorGanancia_Click(object sender, EventArgs e)
        {
            source.DataSource = Negocio.ClasesCN.VentasCN.VentasPorFechas(1, vFechaInicial, vFechaFinal);
            if (source.Count == 0) return;
            var report = new Reportes.Ventas.VentasPorFechaGanancia(source);
            report.Parameters[0].Value = vFechaInicial;
            report.Parameters[1].Value = _vFechaFinal;
            report.Parameters[2].Description = "PORCENTAJE(%): ";
            report.Parameters[3].Description = "VENDEDOR: ";
            DynamicListLookUpSettings rptSettings = new DynamicListLookUpSettings();
            rptSettings.DataSource = Negocio.ClasesCN.CatalogosCN.Empleado_Cargar();
            rptSettings.DisplayMember = "nombre";
            rptSettings.ValueMember = "id";
            report.Parameters[3].LookUpSettings = rptSettings;
            report.ShowPreview();
        }

        private void btn_productos_factura_Click(object sender, EventArgs e)
        {
            DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(typeof(Presentacion.Formularios.Principal.WaitForm1));
            source.DataSource = Negocio.ClasesCN.VentasCN.Ventas_Reportes(vFechaInicial, vFechaFinal);
            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm();
            if (source.Count == 0) return;
            xtraTabControl1.Visible = xtraTabPage1.PageVisible = true;
            xtraTabPage2.PageVisible = false;
            pivotGridControl_Producto_Factura.DataSource = source;
            pivotGridField4.ValueFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            pivotGridField4.ValueFormat.FormatString = "MMMM yyyy";
        }

        private void exportarExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Clases.Exportar().Exportar_Pivote_A_Excel(pivotGridControl_Producto_Factura);
        }

        private void btnClienteFrecuente_Click(object sender, EventArgs e)
        {
            DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(typeof(Principal.WaitForm1));

            var report = new Reportes.Ventas.xrpt_cliente_frecuentes(vFechaInicial, vFechaFinal);
            report.DataSource = Negocio.ClasesCN.VentasCN.Cliete_Frecuencia_select(vFechaInicial, vFechaFinal);

            if (report.RowCount == 0)
            {
                DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm();
                return;
            }
            report.ShowPreview();

            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm();
        }

        private void btnVentasDolares_Click(object sender, EventArgs e)
        {
            XtraReport reporte = new XtraReport();
            reporte.CreateDocument();

            source.DataSource = Negocio.ClasesCN.VentasCN.VentasPorFechas(1, vFechaInicial, vFechaFinal).Where(x => x.moneda == 2);
            if (source.Count == 0) return;

            var reportDetalle = new Reportes.Ventas.DetalleResumenVtasporFecha(source);
            reportDetalle.Parameters[0].Value = vFechaInicial;
            reportDetalle.Parameters[1].Value = _vFechaFinal;
            reportDetalle.Parameters[2].Value = 2;
            reportDetalle.CreateDocument();
            reporte.Pages.AddRange(reportDetalle.Pages);

            var report = new Reportes.Ventas.VentasPorFecha(source);
            report.Parameters[0].Value = vFechaInicial;
            report.Parameters[1].Value = _vFechaFinal;
            report.CreateDocument();
            reporte.Pages.AddRange(report.Pages);

            if (reporte.Pages.Count > 0)
            {
                reporte.ShowPreview();
            }
        }
    }
}