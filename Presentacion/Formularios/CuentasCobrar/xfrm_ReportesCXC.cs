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
    public partial class xfrm_ReportesCXC:DevExpress.XtraEditors.XtraForm
    {
        public xfrm_ReportesCXC( )
        {
            InitializeComponent();
        }
        private DateTime _vFechaInicial;
        private DateTime _vFechaFinal;

        public DateTime vFechaInicial { get => _vFechaInicial; set => _vFechaInicial = value; }
        public DateTime vFechaFinal { get => _vFechaFinal; set => _vFechaFinal = value; }
        private void radio_tipo_busqueda_SelectedIndexChanged(object sender,EventArgs e)
        {
            try
            {
                switch(radio_tipo_busqueda.EditValue.ToString())
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
                        vFechaInicial = new DateTime(int.Parse(cbAño.Text),cbMes.SelectedIndex + 1,1);
                        vFechaFinal = vFechaInicial.AddMonths(1).AddDays(-1);
                        break;

                    case "3":
                        cbAño.Enabled = true;
                        cbMes.Enabled = false;
                        layoutAño.Visibility = layoutMes.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                        layoutFechaInicio.Visibility = layoutFechaFin.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                        cbAño.Focus();
                        vFechaInicial = new DateTime(int.Parse(cbAño.Text),1,1);
                        vFechaFinal = new DateTime(int.Parse(cbAño.Text),12,31);
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
            catch(Exception) { _vFechaInicial = vFechaFinal = DateTime.Now; }
        }
        void CargarDatosIniciales( )
        {
            try
            {
                DateTime vMin = Negocio.ClasesCN.CuentasCobrarCN.DocumentosCuentasCobrar_Select().Min(x => x.fecha_doc).Value.Date;
                DateTime vMax =  Negocio.ClasesCN.CuentasCobrarCN.DocumentosCuentasCobrar_Select().Max(x => x.fecha_doc).Value.Date;
                dateInicio.Properties.MinValue = vMin;
                dateInicio.Properties.MaxValue = vMax;
                dateFin.Properties.MinValue = vMin;
                dateFin.Properties.MaxValue = vMax;
                dateInicio.EditValue = DateTime.Now;
                dateFin.EditValue = DateTime.Now;
                cbMes.SelectedIndex = DateTime.Now.Month - 1;
                var query =Negocio.ClasesCN.CuentasCobrarCN.DocumentosCuentasCobrar_Select().OrderByDescending(x => x.fecha_doc).Select(x => x.fecha_doc.Value.Year).Distinct().ToList();
                foreach(var list in query)
                {
                    cbAño.Properties.Items.Add(list.ToString());
                }
                cbAño.SelectedIndex = 0;
            }
            catch(Exception) { }
        }
    private void simpleButton1_Click(object sender,EventArgs e)
        {
            BindingSource source = new BindingSource();
            source.DataSource = Negocio.ClasesCN.CuentasCobrarCN.Documentos_CuentasCobrar_Select_Rango(vFechaInicial,vFechaFinal);
            if(source.Count == 0)
                
                return;
            var report = new Reportes.CuentasCobrar.xrpt_DocumentosRangoFechas(source);
            report.Parameters[0].Value = vFechaInicial;
            report.Parameters[1].Value = _vFechaFinal;
            report.Parameters[0].Visible=false;
            report.Parameters[1].Visible=false;
            report.ShowPreview();
        }

        private void xfrm_ReportesCXC_Load(object sender,EventArgs e)
        {
            CargarDatosIniciales();
            radio_tipo_busqueda.EditValue = "1";
        }
    }
}