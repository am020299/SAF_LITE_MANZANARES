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
    public partial class XtraSaldoClientesDolarSinUsar : DevExpress.XtraEditors.XtraForm
    {
        public XtraSaldoClientesDolarSinUsar()
        {
            InitializeComponent();
            dateEditTRF.DateTime = DateTime.Now.AddDays(-1);
            dateEdit1.DateTime = DateTime.Now;
        }

        private void btnCargarTRF_Click(object sender, EventArgs e)
        {
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (dateEditTRF.DateTime > dateEdit1.DateTime)
            {
                XtraMessageBox.Show("La fecha de inicio no puede ser mayor a la fecha de fin", "Error al seleccionar las fechas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
	        {
                transferenciasrangoSELECTResultBindingSource.DataSource = Negocio.ClasesCN.CajaCN.SaldoFavorClientes_Select(dateEditTRF.DateTime, dateEdit1.DateTime).Where(x => x.moneda == 2 && x.estadoSaldo == "SALDO SIN USAR");
                gridView1.BestFitColumns();
            }
        }
    }
}