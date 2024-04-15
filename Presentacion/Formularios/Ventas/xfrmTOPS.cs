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

namespace Presentacion.Formularios.Ventas
{
    public partial class xfrmTOPS:DevExpress.XtraEditors.XtraForm
    {
        public xfrmTOPS( )
        {
            InitializeComponent();
        }
        private void radioGroup1_SelectedIndexChanged(object sender,EventArgs e)
        {
            try
            {
                switch(radioGroup1.EditValue.ToString())
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

        private DateTime _vFechaInicial;
        private DateTime _vFechaFinal;

        public DateTime vFechaInicial { get => _vFechaInicial; set => _vFechaInicial = value; }
        public DateTime vFechaFinal { get => _vFechaFinal; set => _vFechaFinal = value; }
        void CargarDatosIniciales( )
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
                foreach(var list in query)
                {
                    cbAño.Properties.Items.Add(list.ToString());
                }
                cbAño.SelectedIndex = 0;
            }
            catch(Exception) { }
        }
        private void xfrmTOPS_Load(object sender,EventArgs e)
        {
            CargarDatosIniciales();
            radioGroup1.EditValue = "1";
        }

        private void simpleButton2_Click(object sender,EventArgs e)
        {

        }

        private void simpleButton3_Click(object sender,EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender,EventArgs e)
        {

        }
    }
}