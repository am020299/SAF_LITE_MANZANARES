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

namespace Presentacion.Formularios.Caja
{
    public partial class xrpt_reporte_diferencia:DevExpress.XtraEditors.XtraForm
    {
        public xrpt_reporte_diferencia( )
        {
            InitializeComponent();
        }

        private void xrpt_reporte_diferencia_Load(object sender,EventArgs e)
        {
            dateEdit1.DateTime = DateTime.Now.Date;
            dateEdit2.DateTime = DateTime.Now.Date;
        }

        private void simpleButton1_Click(object sender,EventArgs e)
        {
            bindingSource1.DataSource = Negocio.ClasesCN.CajaCN.Diferencia_Precios(dateEdit1.DateTime,dateEdit2.DateTime).ToList();
            var REporte= new Reportes.Caja.xrpt_diferencia_facturas(bindingSource1);
            REporte.ShowPreview();
        }
    }
}