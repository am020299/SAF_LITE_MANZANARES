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
using ED;
using Presentacion.Clases;

namespace Presentacion.Formularios.Mantenimiento
{
    public partial class xfrm_cambiar_contraseña : DevExpress.XtraEditors.XtraForm
    {
        int id_empleado;
        string usuario,clave;
        bool existe;
        public xfrm_cambiar_contraseña()
        {
            InitializeComponent();
            id_empleado = Clases.UsuarioLogueado.vID_Empleado;
            usuario = Clases.UsuarioLogueado.vNickName;
            clave = new E_D().D(Clases.UsuarioLogueado.vClave);
        }
        private void Cargar_Datos()
        {
            txt_usuario.Text = usuario;
        }

        private bool validar()
        {
            if (txt_contraseña_nueva.Text == string.Empty || txt_contraseña_vieja.Text == string.Empty || txt_usuario.Text == string.Empty)
            {
                if (txt_contraseña_nueva.Text == string.Empty)
                    txt_contraseña_nueva.Focus();
                if (txt_contraseña_vieja.Text == string.Empty)
                    txt_contraseña_vieja.Focus();
                if (txt_usuario.Text == string.Empty)
                    txt_usuario.Focus();
                return false;
            }
            else
                return true;
        }
        private void Actualizar()
        {
            string cg = new E_D().E(txt_contraseña_nueva.Text);
            if (Negocio.ClasesCN.MantenimientoCN.Actualizar_Regristro(id_empleado,txt_usuario.Text,cg)>0)
            {
                UsuarioLogueado.Establecer_Usuario_Logueado(txt_usuario.Text);
                XtraMessageBox.Show("Datos Actualizados", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
        private void textEditEmpleadoUsuario_TextChanged(object sender, EventArgs e)
        {
            existe = false;
            if (txt_usuario.Text!= string.Empty)
            {
                if (txt_usuario.Text != usuario.ToUpper())
                {
                    foreach(var r in  Negocio.ClasesCN.LoginsCN.Obtener_Datos_de_Usuario().Where(U=>U.usuario==txt_usuario.Text.Trim()).ToList())
                    {
                        if (r.usuario != string.Empty)
                            existe = true;
                        else
                            existe = false;
                    }
                    if (existe == true)
                    {
                        txt_usuario.Focus();
                        dxErrorProvider1.SetError(txt_usuario, "Nickname de Usuario ya existe; Registrar otro");
                    }
                    else
                        dxErrorProvider1.ClearErrors();
                }
                else
                    dxErrorProvider1.ClearErrors();
            }
            else
                dxErrorProvider1.ClearErrors();
        }

        private void xfrm_cambiar_contraseña_Load(object sender, EventArgs e)
        {
            Cargar_Datos();
        }

        private void lblOjo_MouseDown(object sender, MouseEventArgs e)
        {
            this.txt_contraseña_nueva.Properties.UseSystemPasswordChar = false;
        }

        private void lblOjo_MouseUp(object sender, MouseEventArgs e)
        {
            this.txt_contraseña_nueva.Properties.UseSystemPasswordChar = true;
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (validar())
            {
                DialogResult preg = XtraMessageBox.Show("¿Desea actualizar estos registros?","Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (preg == DialogResult.Yes)
                    Actualizar();
            }
        }
        private void txt_contraseña_nueva_KeyPress(object sender, KeyPressEventArgs e)
        {
            string cadena = "" + (Char)32;
            try
            {
                if (cadena.Contains(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            catch (Exception) { }
        }

        private void txt_contraseña_nueva_Leave(object sender, EventArgs e)
        {
            //if (!string.IsNullOrEmpty(txt_contraseña_nueva.Text))
            //{
            //    if (!string.IsNullOrEmpty(txt_contraseña_nueva.Text))
            //    {
            //        dxErrorProvider1.ClearErrors(); dxErrorProvider1.Dispose();
            //        if (txt_contraseña_nueva.Text.Length < 6)
            //        {
            //            //txt_contraseña_nueva.Focus();
            //            //txt_contraseña_nueva.SelectAll();
            //            dxErrorProvider1.SetError(txt_contraseña_nueva, "Clave tiene que ser mayor o igual a 6 digitos");
            //            barButtonItem1.Enabled = false;
            //        }
            //        else
            //            barButtonItem1.Enabled = true;
            //    }
            //}
            //else
            //{
            //    txt_contraseña_nueva.Text = string.Empty; barButtonItem1.Enabled = true;
            //}
        }

        private void txt_contraseña_nueva_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_contraseña_nueva.Text))
            {
                dxErrorProvider1.ClearErrors(); dxErrorProvider1.Dispose();
                if (txt_contraseña_nueva.Text.Length < 6)
                {
                    //txt_contraseña_nueva.Focus();
                    //txt_contraseña_nueva.SelectAll();
                    dxErrorProvider1.SetError(txt_contraseña_nueva, "Clave tiene que ser mayor o igual a 6 digitos");
                    barButtonItem1.Enabled = false;
                }
                else
                    barButtonItem1.Enabled = true;
            }
            else
            {
                txt_contraseña_nueva.Text = string.Empty; barButtonItem1.Enabled = true;
                dxErrorProvider1.ClearErrors(); dxErrorProvider1.Dispose();
            }
        }

        private void txt_contraseña_vieja_TextChanged(object sender, EventArgs e)
        {
            if(txt_contraseña_vieja.Text!= string.Empty)
            {
                if (txt_contraseña_vieja.Text.Trim() == clave)
                {
                    txt_contraseña_nueva.Enabled = true;
                    txt_contraseña_nueva.Focus();
                }
                else
                {
                    txt_contraseña_nueva.Text = string.Empty;
                    txt_contraseña_nueva.Enabled = false;
                }
            }
            else
            {
                txt_contraseña_nueva.Text = string.Empty;
                txt_contraseña_nueva.Enabled = false;
            }
        }
    }
}