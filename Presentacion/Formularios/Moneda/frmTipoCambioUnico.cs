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
using System.Globalization;
using Entidades;
using System.Data.Entity.Core.Objects;
using System.Data.Entity;

namespace Presentacion.Formularios.Moneda
{

    public partial class frmTipoCambioUnico : DevExpress.XtraEditors. XtraForm

    {
        public frmTipoCambioUnico()
        {
            InitializeComponent();
        }
        private string tipo_cambio()
        {
            return Convert.ToString(Negocio.ClasesCN.DatosRequeridosCN.Obtner_Tipo_Cambio_Mensual());
        }
        private string tipo_cambio_compra( )
        {
            return Convert.ToString(Negocio.ClasesCN.DatosRequeridosCN.Obtner_Tipo_Cambio_Mensual_compra());
        }
        private void frmTipoCambioUnico_Load(object sender, EventArgs e)
        {
           
            txtTipoCambio_venta.Focus();
            txtTipoCambio_venta.EditValue = tipo_cambio();
            txt_compra.EditValue = tipo_cambio_compra();
            txtTipoCambio_venta.Enabled = txt_compra.Enabled = bbi_editar.Checked;

        }
        private void bbi_guardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        
        }

        private void bbi_editar_CheckedChanged(object sender,EventArgs e)
        {
            txtTipoCambio_venta.Enabled = txt_compra.Enabled = bbi_editar.Checked;
        }

        private void simpleButton1_Click(object sender,EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtTipoCambio_venta.Text))
            {
                if(XtraMessageBox.Show("¿Desea agregar este tipo de cambio?","Información",MessageBoxButtons.YesNo,MessageBoxIcon.Question) != DialogResult.Yes) { return; }
                decimal monto = Convert.ToDecimal(txtTipoCambio_venta.EditValue);
                decimal monto_compra= Convert.ToDecimal(txt_compra.EditValue);
                if(Negocio.ClasesCN.DatosRequeridosCN.AgregaCambioMensual(monto) > 0 && Negocio.ClasesCN.DatosRequeridosCN.AgregaCambioMensual_compra(monto_compra) > 0)
                {
                    XtraMessageBox.Show("Tipo de Cambio Agregado Correctamente","Información",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    //lblMes.Text = "1 USD = C$ " + tipo_cambio();
                    this.Dispose();
                    this.Close();
                }
            }
            else
            {
                XtraMessageBox.Show("Ingrese el tipo de cambio","Información",MessageBoxButtons.OK,MessageBoxIcon.Information);
                txtTipoCambio_venta.Focus();
            }
        }
    }
}