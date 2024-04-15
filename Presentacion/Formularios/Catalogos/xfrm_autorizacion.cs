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
using Presentacion.Clases_Variadas;
using System.Diagnostics;

namespace Presentacion.Formularios.Catalogos
{
    public partial class xfrm_autorizacion : DevExpress.XtraEditors.XtraForm
    {

        bool _Permiso_Completo = false;
        string modulo;
        string numero_generado;
        public xfrm_autorizacion(string observacion_modulo)
        {
            InitializeComponent();
            this.modulo = observacion_modulo;
        }

        //public xfrm_autorizacion(bool Permiso_Completo)
        //{
        //    this._Permiso_Completo = Permiso_Completo;
        //    InitializeComponent();
        //}

        public bool Autorizado { get; set; }
        public string permiso { get; set; }
        public string Nombre_Empleado_Autorizador { get; set; }
        public int numero_permiso { get; set; }
        public int id_autorizador { get; set; }
        DXErrorProvider Error = new DXErrorProvider();


        public bool Autorizar(int numero_permiso, string permiso)
        {
            Error.ClearErrors();
            this.Autorizado = false;
            Clases.MyMessageBox.MessageFont = new Font(Clases.MyMessageBox.MessageFont.FontFamily, 12);

            if (txt_usuario.EditValue == null)
            {
                Error.SetError(txt_usuario, "Nombre de usuario es requerido");
            }
            else if (txt_clave.EditValue == null)
            {
                Error.SetError(txt_clave, "Nombre de usuario es requerido");
            }
            else
            {
                var usuario = Negocio.ClasesCN.RolesPermisosCN.Empleado_por_usuario_Select(txt_usuario.EditValue.ToString());
                if (usuario != null)
                {
                    if (Negocio.ClasesCN.LoginsCN.contador_usuario_contraseña(txt_usuario.EditValue.ToString(), new ED.E_D().E(txt_clave.EditValue.ToString())) > 0)
                    {
                        //TODO: Crear permiso en la base de datos con número: 11111 y nombre "Autorizar cambio de precio de venta"
                        if (Negocio.ClasesCN.RolesPermisosCN.Permisos(usuario.id, numero_permiso) || Negocio.ClasesCN.RolesPermisosCN.Permisos(usuario.id, 11111) || Clases.UsuarioLogueado.admin)//11111 es el permiso: AUTORIZACIONES ESPECIALES, o debería ser ese
                        {
                            Negocio.ClasesCN.RolesPermisosCN.registrarAutorizacion(Clases.UsuarioLogueado.vID_Empleado, usuario.id, modulo, teConcepto.Text, "");
                            Clases.MyMessageBox.Show($"Se ha Autorizado correctamente {permiso.ToLower()}. ", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.id_autorizador = usuario.id;
                            this.Nombre_Empleado_Autorizador = usuario.nombre.ToUpper();
                            this.Autorizado = true;
                            this.Close();
                        }
                        else
                        {
                            if (txt_token.Text != string.Empty && numero_generado == txt_token.Text)
                            {
                                Negocio.ClasesCN.RolesPermisosCN.registrarAutorizacion(Clases.UsuarioLogueado.vID_Empleado, usuario.id, modulo, teConcepto.Text, numero_generado);
                                Clases.MyMessageBox.Show($"Se ha Autorizado correctamente {permiso.ToLower()}. ", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.id_autorizador = usuario.id;
                                this.Nombre_Empleado_Autorizador = usuario.nombre.ToUpper();
                                this.Autorizado = true;
                                this.Close();
                            }
                            else
                            {
                                XtraMessageBox.Show("CODIGO INGRESADO NO ES VALIDO; FAVOR VERIFICAR", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txt_clave.Focus();
                            }
                        }
                    }
                    else
                    {
                        Clases.MyMessageBox.Show("Contraseña Incorrecta para el usuario,Verifique e intente nuevamente", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txt_clave.Focus();
                    }
                }
                else
                {
                    Clases.MyMessageBox.Show("Usuario no existe, verifique y vuelva a intentarlo", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_usuario.Focus();
                }
            }
            return Autorizado;
        }

        public bool Autorizacion_completa(int numero_permiso, string permiso)
        {
            Error.ClearErrors();
            this.Autorizado = false;
            Clases.MyMessageBox.MessageFont = new Font(Clases.MyMessageBox.MessageFont.FontFamily, 12);

            if (txt_usuario.EditValue == null)
            {
                Error.SetError(txt_usuario, "Nombre de usuario es requerido");
            }
            else if (txt_clave.EditValue == null)
            {
                Error.SetError(txt_clave, "La contraseña es requerida");
            }
            else if (teConcepto.Text == string.Empty)
            {
                Error.SetError(teConcepto, "Ingrese motivo de autorizacion");
            }
            else
            {
                var usuario = Negocio.ClasesCN.RolesPermisosCN.Empleado_por_usuario_Select(txt_usuario.EditValue.ToString());
                if (usuario != null)
                {
                    if (Negocio.ClasesCN.LoginsCN.contador_usuario_contraseña(txt_usuario.EditValue.ToString(), new ED.E_D().E(txt_clave.EditValue.ToString())) > 0)
                    {
                        Clases.MyMessageBox.Show($"Se ha Autorizado correctamente {permiso.ToLower()}. ", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.id_autorizador = usuario.id;
                        this.Nombre_Empleado_Autorizador = usuario.nombre.ToUpper();
                        this.Autorizado = true;
                        this.Close();
                    }
                    else
                    {
                        Clases.MyMessageBox.Show("Contraseña Incorrecta para el usuario,Verifique e intente nuevamente", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txt_clave.Focus();
                    }
                }
                else
                {
                    Clases.MyMessageBox.Show("Usuario no existe, verifique y vuelva a intentarlo", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_usuario.Focus();
                }
            }
            return Autorizado;
        }


        public int Id_autorizador()
        {
            return id_autorizador;
        }

        private void btn_autorizar_Click(object sender, EventArgs e)
        {
            if (_Permiso_Completo)
            {
                Autorizacion_completa(this.numero_permiso, this.permiso);
                lbl_permiso.Text = permiso;
            }
            else
            {
                Autorizar(this.numero_permiso, this.permiso);
                lbl_permiso.Text = permiso;
            }

        }
        Stopwatch osw = new Stopwatch();
        private void xfrm_autorizacion_Load(object sender, EventArgs e)
        {
            lbl_permiso.Text = permiso;
            int idUsuario = Clases.UsuarioLogueado.vID_Empleado;
            if(idUsuario == 7 && modulo == "AUTORIZACION DE AJUSTES DE INVENTARIO")
            {
                txt_usuario.Enabled = false;
                txt_clave.Focus();
            }
            else
            {
                txt_usuario.Focus();
            }
            
            if (Clases.UsuarioLogueado.admin)
                btn_generar.Enabled = true;
        }

        private void btn_generar_Click(object sender, EventArgs e)
        {
            try
            {

                if (txt_usuario.EditValue == null)
                {
                    Error.SetError(txt_usuario, "Nombre de usuario es requerido");
                }
                else if (txt_clave.EditValue == null)
                {
                    Error.SetError(txt_clave, "Nombre de usuario es requerido");
                }
                else if (teConcepto.EditValue == null)
                {
                    Error.SetError(teConcepto, "Campo Requerido");
                }
                else
                {
                    osw.Start();
                    timer1.Enabled = true;
                    Error.ClearErrors();
                    Random rnd = new Random();
                    int num = rnd.Next(111111, 999999);
                    numero_generado = num.ToString();
                    var Lista = Negocio.ClasesCN.ParametrosCN.Correos_Documentos_Enviar_Select().ToList();
                    foreach (var x in Lista)
                    {
                        Enviar_Correos ec = new Enviar_Correos();
                        ec.Enviar_correo_codigo(x.direccion_correo, "AUTORIZACION DE " + modulo, teConcepto.Text + "\n" + "|| CODIGO GENERADO: " + numero_generado + "\n" + " || SOLICITADO POR: " + Clases.UsuarioLogueado.vNombreCompleto);
                    }
                    XtraMessageBox.Show("Codigo Generado correctamente, espere confirmación", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btn_generar.Enabled = false;
                }
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Correo no se pudo enviar; contacte con soporte tecnico", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Error);
                osw.Reset();
                timer1.Enabled = false;
                numero_generado = string.Empty;
            }
        }
        public int currentCount = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan ts = new TimeSpan(0,0,0,0,(int)osw.ElapsedMilliseconds);
            txt_min.Text = ts.Minutes.ToString();
            txt_segundo.Text = ts.Seconds.ToString();

            if (ts.Minutes.ToString() == "20")
            {
                btn_generar.Enabled = true;
                osw.Reset();
                timer1.Enabled =false;
                txt_min.Text ="00".ToString();
                txt_segundo.Text ="00".ToString();
                numero_generado = string.Empty;
                XtraMessageBox.Show("Tiempo agotado para ingresar código generado; favor volver a generarlo", "INFORMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void txt_usuario_Leave(object sender, EventArgs e)
        {
            if (!Clases.UsuarioLogueado.admin)
            {
                var usuario = Negocio.ClasesCN.RolesPermisosCN.Empleado_por_usuario_Select(txt_usuario.EditValue.ToString());
                if (!Negocio.ClasesCN.RolesPermisosCN.Permisos(usuario.id, numero_permiso) || !Negocio.ClasesCN.RolesPermisosCN.Permisos(usuario.id, 11111))
                    btn_generar.Enabled = true;
                else
                    btn_generar.Enabled = false;
            }
        }
    }
}