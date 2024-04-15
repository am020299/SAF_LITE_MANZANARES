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
using DevExpress.XtraEditors.DXErrorProvider;

namespace Presentacion.Formularios.CuentasCobrar
{
    public partial class xtraform_NuevoCobrador:DevExpress.XtraEditors.XtraForm
    {
        public xtraform_NuevoCobrador( )
        {
            InitializeComponent();
        }
        DXErrorProvider dxError = new DXErrorProvider();
        private void bbi_guardar_ItemClick(object sender,DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dxError.ClearErrors(); dxError.Dispose();
            if(!string.IsNullOrEmpty(txtNombre.Text.Replace(" ","")) ||  !string.IsNullOrEmpty(txt_cargo.Text.Replace(" ","")))
            {
                int Ok = Negocio.ClasesCN.CatalogosCN.Empleado_Guardar(txtNombre.Text.ToUpper().Trim(),"",txt_cedula.Text.ToUpper().Trim(),txt_cargo.Text.ToUpper().Trim(),string.Empty,string.Empty,txtTelefono.Text.Trim(),txtCorreo.Text.Trim(),string.Empty,null);
                if(Ok > 0) { this.Close(); }
            }
            else
            {
                dxError.SetError(txtNombre,"Campo Requerido");
                txtNombre.Focus();
            }
        }
    }
}