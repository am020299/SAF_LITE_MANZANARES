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
using Presentacion.Reportes.Caja;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.Parameters;

namespace Presentacion.Formularios.Caja
{
    public partial class XtraChequeReporte : DevExpress.XtraEditors.XtraForm
    {
        public XtraChequeReporte()
        {
            InitializeComponent();
            dateEditTRF.DateTime = DateTime.Now.AddDays(-1);
            dateEdit1.DateTime = DateTime.Now;
        }

        private void btnCargarTRF_Click(object sender, EventArgs e)
        {
            if (dateEditTRF.DateTime > dateEdit1.DateTime)
            {
                XtraMessageBox.Show("La fecha de inicio no puede ser mayor a la fecha de fin", "Error al seleccionar las fechas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                //string[] transferencias = { "a", "w" };
                source.DataSource = Negocio.ClasesCN.CajaCN.CHEQUES_rango_SELECT(dateEditTRF.DateTime, dateEdit1.DateTime, 0);
                if (source.Count == 0) return;
                var report = new Reportes.Caja.XtraReportCheques(source, dateEditTRF.DateTime, dateEdit1.DateTime);
                DynamicListLookUpSettings rptSettings = new DynamicListLookUpSettings();
                rptSettings.DataSource = Negocio.ClasesCN.CajaCN.cargarTodosCheques();

                rptSettings.DisplayMember = "descripcion";
                rptSettings.ValueMember = "id";
                report.Parameters[0].LookUpSettings = rptSettings;
                report.Parameters[1].Value = dateEditTRF.DateTime;
                report.Parameters[2].Value = dateEdit1.DateTime;
                report.ShowPreview(); 
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (dateEditTRF.DateTime > dateEdit1.DateTime)
            {
                XtraMessageBox.Show("La fecha de inicio no puede ser mayor a la fecha de fin", "Error al seleccionar las fechas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
	        {
                transferenciasrangoSELECTResultBindingSource.DataSource = Negocio.ClasesCN.CajaCN.CHEQUES_rango_SELECT(dateEditTRF.DateTime, dateEdit1.DateTime, 0);
                gridView1.BestFitColumns();
            }
        }
    }
}