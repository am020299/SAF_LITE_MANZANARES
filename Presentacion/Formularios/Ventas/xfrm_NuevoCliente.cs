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
using Negocio.ClasesCN;

namespace Presentacion.Formularios.Ventas
{
    public partial class xfrm_NuevoCliente : DevExpress.XtraEditors.XtraForm
    {
        public int IDempleado;
        private List<Entidades.Cliente_Cargar_Result> clientes_Activos = new List<Entidades.Cliente_Cargar_Result>();
        int contador = 0;
        public xfrm_NuevoCliente()
        {
            InitializeComponent();
            IDempleado = Clases.UsuarioLogueado.vID_Empleado;
            clientes_Activos= Negocio.ClasesCN.CatalogosCN.Cliente_Cargar().ToList();
            //precioEspecial();
        }

        DXErrorProvider dxError = new DXErrorProvider();
        private void bbiGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dxError.ClearErrors(); dxError.Dispose();
            if (validar())
            {
                //foreach (var list in Negocio.ClasesCN.CatalogosCN.Cliente_Cargar())
                //{
                //    if (txtNombre.Text.Trim() == list.nombre.Trim())
                //    {
                //        dxError.SetError(txtNombre, "Lo sentimos, este registro ya existe");
                //        txtNombre.Focus();
                //        return;
                //    }
                //}
                int vPrecio = 1;
                try { vPrecio = int.Parse(lookUpEdit_Precio.EditValue.ToString()); } catch (Exception) { vPrecio = 1; }
                int Ok = Negocio.ClasesCN.CatalogosCN.Cliente_Guardar(txtCodigo.Text, txtRuc.Text, txtNombre.Text.Trim(), txtTelefono.Text, txtCelular.Text, txtDireccion.Text, txtCorreo.Text, Convert.ToInt32(search_sectores.EditValue ?? 0), vPrecio,txt_repre.Text,txt_repre2.Text,txt_repre3.Text,"","","",Clases.UsuarioLogueado.vID_Empleado, null, txt_Departamento.Text, Convert.ToBoolean(ck_esMercado.EditValue));
                if (Ok > 0) { this.Close(); }
            }
         
            //precioEspecial();
        }
        bool validar()
        {
            bool valor = false;
            if (txtNombre.Text == string.Empty || txtRuc.Text == string.Empty || txtCelular.Text == string.Empty)
            {
                if (txtNombre.Text == string.Empty)
                    dxErrorProvider_nombre.SetError(txtNombre, "Campo Requerido");
                if (txtRuc.Text == string.Empty)
                    dxErrorProvider_ruc.SetError(txtRuc, "Campo Requerido");
                if (txtCelular.Text == string.Empty)
                    dxErrorProvider_celular.SetError(txtCelular, "Campo Requerido");
            }
            else
            {
                valor = true;
                dxErrorProvider_nombre.ClearErrors();
                dxErrorProvider_celular.ClearErrors();
                dxErrorProvider_ruc.ClearErrors();
            }
               


            return valor;

        }
        private void xfrm_NuevoCliente_Load(object sender,EventArgs e)
        {
            binding_sectores.DataSource=Negocio.ClasesCN.CatalogosCN.Sectores_cargar().ToList();
        //    binding_representes.DataSource = Negocio.ClasesCN.CatalogosCN.Representantes_Cargar();
            search_sectores.Properties.DataSource=binding_sectores;
            lookUpEdit_Precio.Properties.DataSource = Negocio.ClasesCN.CatalogosCN.getPrecio();
            precioEspecial();
            cargar_cliente();
        }
        public void cargar_cliente()
        {
         
            foreach (var x in clientes_Activos)
            {
                txtNombre.Properties.Items.Add(x.nombre);
            }
            foreach (var x in clientes_Activos.Where(o => o.ruc != string.Empty))
            {
                txtRuc.Properties.Items.Add(x.ruc);
            }
            foreach (var x in clientes_Activos.Where(o => o.celular != string.Empty))
            {
                txtCelular.Properties.Items.Add(x.celular);
            }
            foreach (var x in clientes_Activos.Where(o => o.telefono != string.Empty))
            {
                txtTelefono.Properties.Items.Add(x.telefono);
            }
        }
        public void precioEspecial()
        {
            //Valido si el usuario tiene los permisos de ver el precio
            Clases.UsuarioLogueado.precioEspecial(lookUpEdit_Precio, null, IDempleado);
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            //if (txtNombre.Text.Trim() != string.Empty)
            //    txtNombre.ShowPopup();
        }

        private void txtRuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (txtRuc.Text.Trim() != string.Empty)
            //    txtRuc.ShowPopup();
        }

        private void txtTelefono_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (txtTelefono.Text.Trim() != string.Empty)
            //    txtTelefono.ShowPopup();
        }

        private void txtCelular_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (txtCelular.Text.Trim() != string.Empty)
            //    txtCelular.ShowPopup();
        }

        private void txtNombre_Leave(object sender, EventArgs e)
        {
            if (txtNombre.Text.Trim() != string.Empty)
            {
                contador = clientes_Activos.Where(o => o.nombre == txtNombre.Text.Trim()).Count();
                if (contador > 0)
                {
                    dxErrorProvider_nombre.SetError(txtNombre, "Registro ya Existe");
                    bbiGuardar.Enabled = false;
                }
                else
                {
                    dxErrorProvider_nombre.ClearErrors();
                    bbiGuardar.Enabled = true;
                }
                    
            }
            else
            {
                dxErrorProvider_nombre.ClearErrors();
                bbiGuardar.Enabled = true;
            }
        }

        private void txtRuc_Leave(object sender, EventArgs e)
        {
            if (txtRuc.Text.Trim() != string.Empty)
            {
                contador = clientes_Activos.Where(o=>o.ruc!=string.Empty && o.ruc == txtRuc.Text.Trim()).Count();
                if (contador > 0)
                {
                    dxErrorProvider_ruc.SetError(txtRuc, "Registro ya Existe");
                    bbiGuardar.Enabled = false;
                }
                else
                {
                    dxErrorProvider_ruc.ClearErrors();
                    bbiGuardar.Enabled = true;
                }
                   
            }
            else
            {
                dxErrorProvider_ruc.ClearErrors();
                bbiGuardar.Enabled = true;
            }

        }

        private void txtCelular_Leave(object sender, EventArgs e)
        {
            if (txtCelular.Text.Trim() != string.Empty)
            {
                contador = clientes_Activos.Where(o => o.celular != string.Empty && o.celular == txtCelular.Text.Trim()).Count();
                if (contador > 0)
                {
                    dxErrorProvider_celular.SetError(txtCelular, "Registro ya Existe");
                    bbiGuardar.Enabled = false;
                }
                else
                {
                    dxErrorProvider_celular.ClearErrors();
                    bbiGuardar.Enabled = true;
                }
                   
            }
            else
            {
                dxErrorProvider_celular.ClearErrors();
                bbiGuardar.Enabled = true;
            }
        }

        private void txtTelefono_Leave(object sender, EventArgs e)
        {
            if (txtTelefono.Text.Trim() != string.Empty)
            {
                contador = clientes_Activos.Where(o => o.telefono != string.Empty && o.telefono== txtTelefono.Text.Trim()).Count();
                if (contador > 0)
                {
                    dxErrorProvider_telefono.SetError(txtTelefono, "Registro ya Existe");
                    bbiGuardar.Enabled = false;
                }
                else
                {
                    dxErrorProvider_telefono.ClearErrors();
                    bbiGuardar.Enabled = true;
                }

            }
            else
            {
                dxErrorProvider_telefono.ClearErrors();
                bbiGuardar.Enabled = true;
            }
        }
    }
}