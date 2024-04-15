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
    public partial class xfrm_Agrega_Observacion : DevExpress.XtraEditors.XtraForm
    {
        public string vObservacion;
        public xfrm_Agrega_Observacion()
        {
            InitializeComponent();
        }        

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            vObservacion = Convert.ToString(txtObservacion.EditValue);
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            vObservacion = "";
            this.Close();
        }
    }
}