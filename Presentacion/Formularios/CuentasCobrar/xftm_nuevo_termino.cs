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
    public partial class xftm_nuevo_termino:DevExpress.XtraEditors.XtraForm
    {
        public xftm_nuevo_termino( )
        {
            InitializeComponent();
        }
        DXErrorProvider dxError = new DXErrorProvider();
        private void bbi_guardar_ItemClick(object sender,DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dxError.ClearErrors(); dxError.Dispose();
            if(!string.IsNullOrEmpty(txt_dias.Text.Replace(" ","")) ||  !string.IsNullOrEmpty(txt_descripcion.Text.Replace(" ","")))
            {
                int Ok = Negocio.ClasesCN.ParametrosCN.Terminos_Guardar(txt_descripcion.Text.Trim(),int.Parse( txt_dias.Text));
                if(Ok>0)
                {
                    this.Close();
                }
            }

        }

        private void xftm_nuevo_termino_Load(object sender,EventArgs e)
        {

        }
    }
}