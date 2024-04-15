using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using System.Reflection;
using DPFP;
using DPFP.Capture;
using System.IO;
using Presentacion.Formularios.Principal;
using Entidades;
using ED;
using Presentacion.Clases;
using System.Threading;
using DevExpress.Utils;

namespace Presentacion.Formularios.Login
{
    public partial class xfrm_Login : XtraForm, DPFP.Capture.EventHandler
    {
        Image icon_invalido = (Properties.Resources.invalido_jpg);
        Image icon_valido = (Properties.Resources.valido_jpg);
        public DPFP.Capture.Capture captura;
        public DPFP.Processing.Enrollment enroll;
        int vINTERVALO_TIMER_HUELLA = 3000;
        bool vUsoScanner;// = false;, es_empleado
        protected internal bool vHayScanner;
        bool login_por_huella;
        int vIdEmpleado_Huella, vEstadoHuella;
        int  vContador;//, Cantidad_intentos_login = 0;// Presentacion.Properties.Settings.Default.NumeroIntentos;  
       private delegate void delegadoCedula(string ced);
        public DPFP.Template template;
        private DPFP.Verification.Verification verificador;
        List   <Entidades.Login_Empleado_Cargar> Listado_de_Empleados = new  List<Login_Empleado_Cargar>();
        public xfrm_Login()
        {
            // Negocio.ClasesCN.Datos_requeridosCN.Primer_Consulta();
            InitializeComponent();
            labelControl1.Parent = pictureEdit1;
            labelControl1.BackColor = TransparencyKey;
            //BackColor = Color.FromArgb(235, 236, 239);
            //TransparencyKey = BackColor;
        }
        private void xfrm_Login_Load(object sender, EventArgs e)
        {
            try
            {
                if (HayConexion())
                {
                    //    Thread.Sleep(1500);
                    Listado_de_Empleados = Negocio.ClasesCN.LoginsCN.Obtener_Datos_de_Usuario();
                    timer_validacion.Enabled = false;
                    dxErrorProvider.SetIconAlignment(txt_Usuario, ErrorIconAlignment.MiddleRight);
                    dxErrorProvider.SetIconAlignment(txt_Clave, ErrorIconAlignment.MiddleRight);
                    DXErrorProvider.GetErrorIcon += new GetErrorIconEventHandler(DXErrorProvider_GetErrorIcon);
                    Init();
                    IniciarCaptura();
                    this.timer_MensajeHuella.Interval = vINTERVALO_TIMER_HUELLA;
                    txt_Usuario.Select();
                    txt_Usuario.Focus();
                    Enviar_Mensaje_tooltip_Usuario("Ingrese Usuario");

                    vUsoScanner = false;
                    login_por_huella = false;
                }
                else
                {
                    XtraMessageBox.Show("No hay comunicación con la base de datos...\n\nComuníquese con el Administrador del Sistema.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Dispose();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error al iniciar el Login...\n\nComuníquese con el Administrador del Sistema.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GC.Collect();
                Application.Exit();
            }

        }
        private void xfrm_Login_KeyDown(object sender, KeyEventArgs e)
        {
            if(login_por_huella== false)
            {
                if (e.KeyCode == Keys.F12)
                {
                    txt_Usuario.Leave -= new System.EventHandler(txt_Usuario_Leave);
                    txt_Clave.Leave -= new System.EventHandler(txt_Clave_Leave);
                    dxErrorProvider.ClearErrors();
                    lbl_MsgError.ResetText();
                    txt_Clave.ResetText();
                    txt_Usuario.ResetText();

                    txt_Usuario.Focus();
                    ActiveControl = txt_Usuario;
                    txt_Usuario.Select();
                    txt_Clave.Leave += new System.EventHandler(txt_Clave_Leave);
                    txt_Usuario.Leave += new System.EventHandler(txt_Usuario_Leave);
                    Enviar_Mensaje_tooltip_Usuario("Ingrese Usuario");
                    Enviar_Mensaje_tooltip_Contraseña("Ingrese Contraseña");
                    txt_Usuario.Properties.AppearanceFocused.ForeColor = txt_Clave.Properties.AppearanceFocused.ForeColor = Color.Black;
                    picture_1.Visible = false;
                    picture_2.Visible = false;
                    //GC.Collect();
                }
                else if (e.KeyCode == Keys.Escape)
                {

                    txt_Usuario.ResetText();
                    txt_Clave.ResetText();
                    dxErrorProvider.ClearErrors();
                    //GC.Collect();
                    //-----------
                    Application.Exit();

                }
            }
        }
        #region FUNCIONES
        public bool HayConexion()
        {
            return Negocio.ClasesCN.LoginsCN.HayConexion();
        }
        void Ubicar_LabelControl(LabelControl LABEL)
        {
            try
            {
                int anchoForm = Size.Width;
                //int altoForm = Size.Height;
                int anchoLabel = LABEL.Size.Width;
                //int altoLabel = lbl_MsgError.Size.Height;
                int X = (anchoForm - anchoLabel) / 2;
                //int Y = (altoForm - altoLabel) / 2;
                LABEL.Location = new Point(X, LABEL.Location.Y);
            }
            catch (Exception) { }
        }     
        ///*********************************FINGER***************************//////
        public void PararCaptura()
        {
            try
            {
                if (captura != null)
                {
                    captura.StopCapture();
                }
            }
            catch (DPFP.Error.SDKException)
            {
                Ejecutar(() => { Mostrar_Mensaje("CAPTURA NO DETENIDA...", Color.Red); });
                //string vMENSAJE = UsuarioLogueado_Manager.vPROYECTO + " - Login\n\n¡Excepción capturada!\n\nNo se detuvo la captura...\n\n" + ex.Message + "\n\n" + ex.InnerException + "\n\n→ Formulario: " + Name + "\n→ Método: " + MethodBase.GetCurrentMethod().Name + "\n→ Línea de Error: " + new EnviarMensajeWT().ErrorLine(ex) + "\n→ IP = " + UsuarioLogueado_Manager.vIP + "\n→ Equipo = " + UsuarioLogueado_Manager.vEQUIPO + "\n→ Usuario = " + UsuarioLogueado_Manager.vNombreCompleto;
                //Task.Factory.StartNew(() => new EnviarMensajeWT().Enviar_Notificacion(vMENSAJE));

                GC.Collect();
            }
        }
        public void OnSampleQuality(object Capture, string ReaderSerialNumber, CaptureFeedback CaptureFeedback) { }
        public void OnFingerGone(object Capture, string ReaderSerialNumber) { }
        public void OnFingerTouch(object Capture, string ReaderSerialNumber)
        {

        }
        public void OnReaderConnect(object Capture, string ReaderSerialNumber)
        {
            try
            {
                vHayScanner = true;
                Ejecutar(() => { FingerConectado(); });
                Ejecutar(() => { pic_Huella.Image = Properties.Resources.finger_conectado; });
            }
            catch (DPFP.Error.SDKException)
            {

                //string vMENSAJE = UsuarioLogueado_Manager.vPROYECTO + " - Login\n\n¡Excepción capturada!\n\n" + ex.Message + "\n\n" + ex.InnerException + "\n\n→ Formulario: " + Name + "\n→ Método: " + MethodBase.GetCurrentMethod().Name + "\n→ Línea de Error: " + new EnviarMensajeWT().ErrorLine(ex) + "\n→ IP = " + UsuarioLogueado_Manager.vIP + "\n→ Equipo = " + UsuarioLogueado_Manager.vEQUIPO + "\n→ Usuario = " + UsuarioLogueado_Manager.vNombreCompleto;
                //Task.Factory.StartNew(() => new EnviarMensajeWT().Enviar_Notificacion(vMENSAJE));

                GC.Collect();
            }
        }
        public void OnReaderDisconnect(object Capture, string ReaderSerialNumber)
        {
            try
            {
                vHayScanner = false;
                Ejecutar(() => { FingerDesconectado(); });
                Ejecutar(() => { pic_Huella.Image = Properties.Resources.finger_desconectado; });
            }
            catch (DPFP.Error.SDKException )
            {

                //string vMENSAJE = UsuarioLogueado_Manager.vPROYECTO + " - Login\n\n¡Excepción capturada!\n\n" + ex.Message + "\n\n" + ex.InnerException + "\n\n→ Formulario: " + Name + "\n→ Método: " + MethodBase.GetCurrentMethod().Name + "\n→ Línea de Error: " + new EnviarMensajeWT().ErrorLine(ex) + "\n→ IP = " + UsuarioLogueado_Manager.vIP + "\n→ Equipo = " + UsuarioLogueado_Manager.vEQUIPO + "\n→ Usuario = " + UsuarioLogueado_Manager.vNombreCompleto;
                //Task.Factory.StartNew(() => new EnviarMensajeWT().Enviar_Notificacion(vMENSAJE));

                GC.Collect();
            }
        }
        public DPFP.FeatureSet ExtrarCaracteristica(DPFP.Sample sample, DPFP.Processing.DataPurpose purpose)
        {
            DPFP.Processing.FeatureExtraction ex = new DPFP.Processing.FeatureExtraction();
            DPFP.Capture.CaptureFeedback ali = CaptureFeedback.None;
            DPFP.FeatureSet carac = new FeatureSet();
            ex.CreateFeatureSet(sample, purpose, ref ali, ref carac);

            if (ali == DPFP.Capture.CaptureFeedback.Good)
            {
                return carac;
            }
            else
            {
                return null;
            }
        }
        public void OnComplete(object Capture, string ReaderSerialNumber, Sample Sample)
        {
            try
            {
                DPFP.FeatureSet caracteristicas = ExtrarCaracteristica(Sample, DPFP.Processing.DataPurpose.Verification);
                if (caracteristicas != null)
                {
                    DPFP.Verification.Verification.Result result = new DPFP.Verification.Verification.Result();

                    bool existe_huella = false;

                    foreach (var f in Negocio.ClasesCN.LoginsCN.Lista_Huella())
                    {
                        if (f.finger == 1)
                        {
                            MemoryStream ms = new MemoryStream(f.huella);
                            template.DeSerialize(ms.ToArray());
                            verificador.Verify(caracteristicas, template, ref result);
                            if (result.Verified)
                            {
                                vIdEmpleado_Huella = (int)f.id_empleado;
                                vEstadoHuella = (int)f.estado;
                                if (vIdEmpleado_Huella != 0)
                                    existe_huella = true;
                            }
                        }
                    }
                    if (existe_huella)
                    {
                        if (vEstadoHuella == 0)
                        {
                            Ejecutar(() => { pic_Huella.Image = Properties.Resources.finger_huella_no_reconocida; });
                            Ejecutar(() => { Mostrar_Mensaje("REGISTRO DE HUELLA INACTIVO", Color.DarkRed); });
                            Ejecutar(() => { Detener_E_Iniciar_Timer_MensajeHuella(); });
                        }
                        else
                        {
                            login_por_huella = true;
                            CargarCedula("");
                            Ejecutar(() => { pic_Huella.Image = Properties.Resources.Finger_Huella_Reconocida; });
                        }
                    }
                    else
                    {
                        Ejecutar(( ) => { pic_Huella.Image = Properties.Resources.finger_huella_no_reconocida; });
                        Ejecutar(() => { Mostrar_Mensaje("NO HAY REGISTRO DE HUELLA", Color.DarkRed); });
                        Ejecutar(() => { Detener_E_Iniciar_Timer_MensajeHuella(); });
                    }
                }

            }
            catch (Exception)
            {
                ///  XtraMessageBox.Show(string.Format("Ha ocurrido un error {0}",ex.Message),"Error del sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        void Mostrar_Mensaje(string MENSAJE, Color COLOR)
        {
            try
            {
                lbl_MensajeHuella.ResetText();
                lbl_MensajeHuella.Text = MENSAJE;
                lbl_MensajeHuella.Properties.AppearanceDisabled.ForeColor = COLOR;
                lbl_MensajeHuella.Visible = true;
                //lbl_MensajeHuella.Location = new Point(((this.Size.Width - lbl_MensajeHuella.Size.Width) / 2), (lbl_MensajeHuella.Location.Y));
            }
            catch (Exception) { }
        }
        private void Ejecutar(Action a)
        {
            try
            {
                BeginInvoke(new Action(a));
            }
            catch (InvalidOperationException) { }
        }
        public virtual void Init()
        {
            try
            {
                captura = new DPFP.Capture.Capture();

                if (captura != null)
                {
                    captura.EventHandler = this;
                    verificador = new DPFP.Verification.Verification();
                    template = new Template();
                }
                else
                {
                    Ejecutar(() => { Mostrar_Mensaje("CAPTURA NO INICIADA...", Color.Red); });
                }
            }
            catch (DPFP.Error.SDKException )
            {
                Ejecutar(() => { Mostrar_Mensaje("CAPTURA NO INICIADA...", Color.Red); });
                //string vMENSAJE = UsuarioLogueado_Manager.vPROYECTO + " - Login\n\n¡Excepción capturada!\n\nNo se inició la captura...\n\n" + ex.Message + "\n\n" + ex.InnerException + "\n\n→ Formulario: " + Name + "\n→ Método: " + MethodBase.GetCurrentMethod().Name + "\n→ Línea de Error: " + new EnviarMensajeWT().ErrorLine(ex) + "\n→ IP = " + UsuarioLogueado_Manager.vIP + "\n→ Equipo = " + UsuarioLogueado_Manager.vEQUIPO + "\n→ Usuario = " + UsuarioLogueado_Manager.vNombreCompleto;
                //Task.Factory.StartNew(() => new EnviarMensajeWT().Enviar_Notificacion(vMENSAJE));
                GC.Collect();
            }
        }
        public void IniciarCaptura()
        {
            if (captura != null)
            {
                try
                {
                    captura.StartCapture();
                }
                catch (DPFP.Error.SDKException)
                {
                    Ejecutar(() => { Mostrar_Mensaje("CAPTURA NO INICIADA...", Color.Red); });
                    //string vMENSAJE = UsuarioLogueado_Manager.vPROYECTO + " - Login\n\n¡Excepción capturada!\n\nNo se inició la captura...\n\n" + ex.Message + "\n\n" + ex.InnerException + "\n\n→ Formulario: " + Name + "\n→ Método: " + MethodBase.GetCurrentMethod().Name + "\n→ Línea de Error: " + new EnviarMensajeWT().ErrorLine(ex) + "\n→ IP = " + UsuarioLogueado_Manager.vIP + "\n→ Equipo = " + UsuarioLogueado_Manager.vEQUIPO + "\n→ Usuario = " + UsuarioLogueado_Manager.vNombreCompleto;
                    // Task.Factory.StartNew(() => new EnviarMensajeWT().Enviar_Notificacion(vMENSAJE));
                    GC.Collect();
                }
            }
        }
        void FingerConectado()
        {
            try
            {
                Mostrar_Mensaje("» ESCÁNER DE HUELLAS ACTIVO «", Color.DarkBlue);
                pic_Huella.Image = Properties.Resources.finger_conectado;

                Set_Estado_Finger("Dispositivo Activo");

            }
            catch (Exception) { }
        }
        public void Set_Estado_Finger(string mensaje)
        {
            try
            {
                pic_Huella.ToolTip = mensaje;
                pic_Huella.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
                pic_Huella.ToolTipTitle = "Escáner de Huellas";
                pic_Huella.Show();
            }
            catch (Exception) { }
        }
        void FingerDesconectado()
        {
            try
            {
                Mostrar_Mensaje("ESCÁNER DE HUELLAS NO ENCONTRADO...", Color.DarkRed);
                pic_Huella.Image = Properties.Resources.finger_desconectado;
                //--------------------------------------------------
                Set_Estado_Finger("Dispositivo No Encontrado");

            }
            catch (Exception) { }
        }
        void Detener_E_Iniciar_Timer_MensajeHuella()
        {
            try
            {
                this.timer_MensajeHuella.Stop();

                this.timer_MensajeHuella.Start();
            }
            catch (Exception) { }
        }
        void LimpiarHuella()
        {
            try
            {
                if (vHayScanner)
                {
                    Ejecutar(() => { FingerConectado(); });
                    Ejecutar(() => { pic_Huella.Image = Properties.Resources.finger_conectado; });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void CargarCedula(string CEDULA)
        {
            try
            {
                if (pic_Huella.InvokeRequired)
                {
                    delegadoCedula deleg = new delegadoCedula(CargarCedula);
                    this.Invoke(deleg, new object[] { CEDULA });
                }
                else
                {
                    if (string.IsNullOrEmpty("123"))
                        Ejecutar(() => { Mostrar_Mensaje("NO SE PUDO OBTENER EL DATO DEL EMPLEADO...", Color.DarkRed); });

                    else
                    {
                        vUsoScanner = true;
                        if (Negocio.ClasesCN.LoginsCN.Consultar_Usuario_Logueado(vIdEmpleado_Huella) == true)
                        {
                            Ejecutar(() => { pic_Huella.Image = Properties.Resources.Finger_Huella_Reconocida; });
                            Hacer_Login_Por_Huella();
                        }
                        else
                            Hacer_Login_Por_Huella();
                        vUsoScanner = false;
                    }
                }
            }
            catch (Exception)
            {
                Ejecutar(() => { Mostrar_Mensaje("ERROR AL PASAR EL DATO DEL EMPLEADO...", Color.DarkRed); });
            }
        }
        void Hacer_Login_Por_Huella()
        {
            try
            {   
                if (HayConexion() == true)
                {
                    foreach (var r in Negocio.ClasesCN.LoginsCN.Cargar_Datos_Usuarios(vIdEmpleado_Huella).ToList())
                    {
                        txt_Usuario.Text = r.usuario;
                        txt_Clave.Text = new E_D().D(r.clave);  
                    }
                    if (Validar_Datos() == true)
                    {
                        txt_Clave.Focus();
                        picture_2.Visible = true;
                        picture_2.Image = Presentacion.Properties.Resources.valido_jpg;
                        txt_Clave.Properties.AppearanceFocused.ForeColor = Color.MediumSeaGreen;
                        txt_Clave.Properties.Appearance.ForeColor = Color.MediumSeaGreen;
                        PararCaptura();
                        timer_validacion.Enabled = true;
                    }
                }
                else
                {
                    XtraMessageBox.Show("No hay conexión con la Base de Datos en estos momentos." + "\n\n" + "Comuníquese con el Administrador del Sistema.", "SAFNISA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txt_Usuario.Focus();
                }
            }
            catch (Exception )
            {
                XtraMessageBox.Show("Error al intentar hacer Login...\n\nComuníquese con el Administrador del Sistema.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GC.Collect();
            }
        }
        ///******************************************************************//////
        ///*********************************USUARIO PASWWORD***************************////
        private void Enviar_Mensaje_tooltip_Usuario(string Msj)
        {
            txt_Usuario.ToolTip = Msj;
            txt_Usuario.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            txt_Usuario.ToolTipTitle = "Login";

            picture_1.ToolTip = Msj;
            picture_1.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            picture_1.ToolTipTitle = "Login";
        }
        private void Enviar_Mensaje_tooltip_Contraseña(string Msj)
        {
            txt_Clave.ToolTip = Msj;
            txt_Clave.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            txt_Clave.ToolTipTitle = "Login";
            txt_Clave.Show();

            picture_2.ToolTip = Msj;
            picture_2.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            picture_2.ToolTipTitle = "Login";
        }
        void DXErrorProvider_GetErrorIcon(GetErrorIconEventArgs e)
        {
            if (e.ErrorType == ErrorType.User1)
            {
                e.ErrorIcon = icon_valido;
            }
            else if (e.ErrorType == ErrorType.User2)
            {
                e.ErrorIcon = icon_invalido;
            }
        }
        public bool Validar_Datos()
        {
            bool bool_UsuarioValido = false;
            string vNickName = this.txt_Usuario.Text.Trim().ToLower();
            string vClave = new E_D().E(txt_Clave.Text.Trim());
            int resultado =Listado_de_Empleados.Where(T=>T.usuario.ToLower()==vNickName.ToLower() && T.clave==vClave).Count(); // Negocio.ClasesCN.LoginsCN.contador_usuario_contraseña(vNickName, vClave);
            if (resultado == 0)
            {
                bool_UsuarioValido = false;
                Enviar_Mensaje_tooltip_Contraseña("Ingrese una Contraseña Valida");
                txt_Clave.Properties.AppearanceFocused.ForeColor = Color.Red;
                picture_2.Visible = true;
                picture_2.Image = Presentacion.Properties.Resources.invalido_jpg;
                this.txt_Clave.Focus();
                this.txt_Clave.SelectAll();
            }
            else
            {
                picture_2.Visible = true;
                picture_2.Image = Presentacion.Properties.Resources.valido_jpg;
                int id_empleado=UsuarioLogueado.Establecer_Usuario_Logueado(vNickName);
                if(Negocio.ClasesCN.LoginsCN.Consultar_Usuario_Logueado(id_empleado) == true)
                {
                    bool_UsuarioValido = true;
                    Negocio.ClasesCN.LoginsCN.Terminar_inicio_sesion(id_empleado);
                    long id_loguedo = Negocio.ClasesCN.LoginsCN.Grabar_inicio_sesion(id_empleado);
                    UsuarioLogueado.Establecer_id_Logueado(id_loguedo);
                }
                else
                {
                    bool_UsuarioValido = true;
                    long id_loguedo = Negocio.ClasesCN.LoginsCN.Grabar_inicio_sesion(id_empleado);
                    UsuarioLogueado.Establecer_id_Logueado(id_loguedo);
                }
            }
            return bool_UsuarioValido;
        }
        ///******************************************************************//////
        #endregion
        #region VALIDACIONES
        private void timer_Mensaje_1_Tick(object sender, EventArgs e)
        {
            try
            {

                //Thread.Sleep(5000);
                timer_Mensaje_1.Interval = 1000;
                vContador = vContador - 1;
                lbl_MsgError.ForeColor = Color.White;
                lbl_MsgError.Text = string.Format("Se cerrará la aplicación en {0}...", vContador);
                Ubicar_LabelControl(lbl_MsgError);

                if (vContador == 0)
                {
                    timer_Mensaje_1.Stop();
                    PararCaptura();
                    Dispose();
                    Application.Exit();
                }
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Error al mostrar el mensaje...\n\nComuníquese con el Administrador del Sistema.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GC.Collect();
            }
        }
        private void timer_MensajeHuella_Tick(object sender, EventArgs e)
        {
            try
            {
                if (timer_MensajeHuella.Interval == vINTERVALO_TIMER_HUELLA)
                {
                    LimpiarHuella();
                }
            }
            catch (Exception) { }

        }
        ///*********************************FINGER***************************//////
        ///******************************************************************//////
        ///*********************************USUARIO PASWWORD***************************////
        private void timer_validacion_Tick(object sender, EventArgs e)
        {       
            //timer_validacion.Interval = 5000;
            this.Dispose();
            this.Close();
            DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(typeof(Presentacion.Formularios.Principal.WaitForm1));
            xfrm_Principal Principal = new xfrm_Principal();
            Principal.Show();
            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm();
        }
        private void txt_Usuario_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txt_Usuario.Text.Trim()))
            {
                //dxErrorProvider.SetError(txt_Usuario, "Es necesario indicar el Nombre de Usuario para iniciar Sesión", ErrorType.User2);
                //dxErrorProvider.RefreshControl(txt_Usuario);
                picture_1.Visible = true;
                picture_1.Image = Presentacion.Properties.Resources.invalido_jpg;
                Enviar_Mensaje_tooltip_Usuario("Es necesario indicar el Nombre de Usuario para iniciar Sesión");
                txt_Usuario.Focus();

            }
            else
            {
                bool v =Listado_de_Empleados.Any(E=>E.usuario.ToLower()==this.txt_Usuario.Text.ToLower().Trim());//  Negocio.ClasesCN.LoginsCN.si_existe_usuario(this.txt_Usuario.Text.Trim());
                if (v == true)
                {
                    int usuario =Listado_de_Empleados.Where(E=>E.usuario.ToLower()==txt_Usuario.Text.ToLower().Trim()).Count();//   Negocio.ClasesCN.LoginsCN.contador_usuario(this.txt_Usuario.Text.Trim());
                    if (usuario == 0)
                    {
                        picture_1.Visible = true;
                        picture_1.Image = Presentacion.Properties.Resources.invalido_jpg;
                        txt_Usuario.Properties.AppearanceFocused.ForeColor = Color.Red;
                        Enviar_Mensaje_tooltip_Usuario("Ingrese un Usuario Activo");
                        //dxErrorProvider.SetError(txt_Usuario, "Usuario no activo; Comunicarse con soporte técnico", ErrorType.User2);
                        txt_Usuario.Focus();
                    }
                    else
                    {
                        picture_1.Visible = true;
                        picture_1.Image = Presentacion.Properties.Resources.valido;
                        txt_Usuario.Properties.Appearance.ForeColor = Color.MediumSeaGreen;
                        txt_Usuario.Properties.AppearanceFocused.ForeColor = Color.MediumSeaGreen;
                        Enviar_Mensaje_tooltip_Usuario("Usuario Activo");
                        //dxErrorProvider.ClearErrors();
                        txt_Clave.Focus();
                    }
                }
                else if (v == false)
                {
                    picture_1.Visible = true;
                    picture_1.Image = Presentacion.Properties.Resources.invalido_jpg;
                    txt_Usuario.Properties.AppearanceFocused.ForeColor = Color.Red;
                    Enviar_Mensaje_tooltip_Usuario("Ingrese un Usuario Correcto");
                    //dxErrorProvider.SetError(txt_Usuario, "Es necesario indicar un Nombre de Usuario Válido para iniciar Sesión", ErrorType.User2);
                    txt_Usuario.Focus();
                }
            }
        }
        private void txt_Usuario_Enter(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txt_Usuario.Text.Trim()))
                {
                    txt_Usuario.DeselectAll();
                }
                else
                {
                    txt_Usuario.SelectAll();
                }
            }
            catch (Exception) { }
        }
        private void txt_Usuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                new ClaseValidacionCampos().Numeros_Y_Letras(e);
            }
            catch (Exception) { }
        }
        private void txt_Clave_Leave(object sender, EventArgs e)
        {

            //try
            //{
            //    if (string.IsNullOrEmpty(txt_Clave.Text.Trim()))
            //    {
            //        dxErrorProvider.SetError(txt_Clave, "Es necesario indicar la Contraseña del Usuario para iniciar Sesión", ErrorType.User2);
            //        dxErrorProvider.RefreshControl(txt_Clave);
            //        //----------------------------------------
            //        txt_Clave.Focus();
            //    }
            //    else if (!string.IsNullOrEmpty(txt_Clave.Text.Trim()))
            //    {
            //        //if(Negocio.ClasesCN.Servidor_ActivoCN.Hay_Conexion())
            //        //{

            //            if(Password_Correcta())
            //            {
            //                //if(Negocio.ClasesCN.UsuariosCN.Hay_Sesiones_Abiertas(usuarioL).Item1)
            //                //{
            //                //    if(XtraMessageBox.Show("No puede loguearse porque este Usuario tiene " + Negocio.ClasesCN.UsuariosCN.Hay_Sesiones_Abiertas(usuarioL).Item2.ToString() + " sesión abierta.\n\n¿Desea terminar la sesión existente?","Login",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            //                //    {

            //                //        Negocio.ClasesCN.UsuariosCN.Terminar_Sesiones_Abiertas(usuarioL.id_usuario);
            //                //        Hacer_Login(usuarioL);


            //                //    }
            //                //    else
            //                //    {
            //                //        txt_Clave.Focus();
            //                //    }
            //                //}
            //                //else
            //                //{

            //                //    Hacer_Login(usuarioL);

            //                //}
            //            }
            //            else
            //            {
            //                dxErrorProvider.SetError(txt_Clave,"La Contraseña para el Usuario indicado es incorrecta",ErrorType.User2);
            //                dxErrorProvider.RefreshControl(txt_Clave);
            //                txt_Clave.Focus();
            //                txt_Clave.SelectAll();

            //                if(!userAdmin)
            //                    Contador += 1;
            //                if(Contador < Cantidad_intentos_login)
            //                {
            //                    if(Contador != 1)
            //                    {
            //                        if(!userAdmin)
            //                        {
            //                            lbl_HasAgotado.Visible = false;
            //                            lbl_MsgError.Visible = true;
            //                            lbl_MsgError.ResetText();
            //                            lbl_MsgError.ForeColor = Color.Black;

            //                            lbl_MsgError.Text = string.Format("Intento Nº{0} incorrecto. Le queda {1} intento.",Contador,(Cantidad_intentos_login - Contador));
            //                            Ubicar_LabelControl(lbl_MsgError);
            //                        }
            //                    }
            //                    else
            //                    {
            //                        if(!userAdmin)
            //                        {
            //                            lbl_HasAgotado.Visible = false;
            //                            lbl_MsgError.Visible = true;
            //                            lbl_MsgError.ResetText();
            //                            lbl_MsgError.ForeColor = Color.Black;
            //                            lbl_MsgError.Text = string.Format("Intento Nº{0} incorrecto. Le quedan {1} intentos.",Contador,(3 - Contador));
            //                            Ubicar_LabelControl(lbl_MsgError);
            //                        }
            //                    }
            //                }
            //                else
            //                {
            //                    txt_Usuario.ResetText();
            //                    txt_Clave.ResetText();
            //                    txt_Usuario.Enabled = false;
            //                    txt_Clave.Enabled = false;
            //                    dxErrorProvider.ClearErrors();

            //                    vContador = 3;

            //                    lbl_HasAgotado.Text=string.Format("Ha agotado los {0} intentos de inicio de sesión",Cantidad_intentos_login);
            //                    lbl_HasAgotado.Visible = true;
            //                    lbl_MsgError.ResetText();
            //                    lbl_MsgError.Visible = true;
            //                    lbl_MsgError.ForeColor = Color.White;
            //                    lbl_MsgError.Text = string.Format("Se desactivará el Usuario y se cerrará la aplicación en {0}...",vContador);
            //                    Ubicar_LabelControl(lbl_MsgError);


            //                    try
            //                    {

            //                    int resultado = 0;// Negocio.ClasesCN.UsuariosCN.Desactiva_Usuario(usuarioL.id_usuario);

            //                        if(resultado == 0)
            //                        {
            //                           // XtraMessageBox.Show("Error al desactivar el Usuario...","Login",MessageBoxButtons.OK,MessageBoxIcon.Error);

            //                        }
            //                    }
            //                    catch(Exception ex)
            //                    {
            //                        XtraMessageBox.Show("Error al desactivar el Usuario..." + "\n\n" + ex.Message + "\n\n" + ex.Source,"Login",MessageBoxButtons.OK,MessageBoxIcon.Error);
            //                    }
            //                    timer_Mensaje_1.Start();
            //                }

            //            }
            //        }
            //        else
            //        {
            //            XtraMessageBox.Show("No hay comunicación con la base de datos...\n\nComuníquese con el Administrador del Sistema.","Login",MessageBoxButtons.OK,MessageBoxIcon.Error);
            //            return;
            //        }

            //    //}

            //}

            //catch (Exception ex)
            //{
            //    XtraMessageBox.Show("Error al validar la contraseña del Usuario: '" +(this.IsDisposed?string.Empty:txt_Usuario.Text.Trim()) + "'...\n\nComuníquese con el Administrador del Sistema.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //    //string vMENSAJE = UsuarioLogueado_Manager.vPROYECTO + " - Login\n\n¡Excepción capturada!\n\nError al validar la contraseña del Usuario: '" + txt_Usuario.Text.Trim() + "'...\n\n" + ex.Message + "\n\n→ Formulario: " + Name + "\n→ Método: " + MethodBase.GetCurrentMethod().Name + "\n→ Línea de Error: " + new EnviarMensajeWT().ErrorLine(ex) + "\n→ IP = " + UsuarioLogueado_Manager.vIP + "\n→ Equipo = " + UsuarioLogueado_Manager.vEQUIPO + "\n→ Usuario = " + UsuarioLogueado_Manager.vNombreCompleto;
            //    //Task.Factory.StartNew(() => new EnviarMensajeWT().Enviar_Notificacion(vMENSAJE));

            //    GC.Collect();
            //}
        }
        private void txt_Clave_TextChanged(object sender, EventArgs e)
        {

        }
        private void txt_Clave_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == Convert.ToChar(Keys.Enter) || e.KeyChar == Convert.ToChar(Keys.Return))
                {
                    if(string.IsNullOrEmpty(this.txt_Clave.Text.Trim()))
                    {
                        Enviar_Mensaje_tooltip_Contraseña("Ingrese Contraseña");
                        picture_2.Visible = true;
                        picture_2.Image = Presentacion.Properties.Resources.invalido_jpg;
                        txt_Clave.Focus();
                    }
                    else
                    {
                        if(HayConexion())
                        {
                            if (Validar_Datos() == true)
                            {
                                picture_2.Visible = true;
                                picture_2.Image = Presentacion.Properties.Resources.valido_jpg;
                                txt_Clave.Properties.AppearanceFocused.ForeColor = Color.MediumSeaGreen;
                                txt_Clave.Properties.Appearance.ForeColor = Color.MediumSeaGreen;
                                timer_validacion.Enabled =true;
                            }
                        }
                        else
                        {
                            XtraMessageBox.Show("No hay conexión con la Base de Datos en estos momentos." + "\n\n" + "Comuníquese con el Administrador del Sistema.", "SAFNISA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.txt_Usuario.Focus();
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }
        private void txt_Clave_Enter(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.txt_Clave.Text.Trim()))
                    this.txt_Clave.DeselectAll();
                else
                    this.txt_Clave.SelectAll();
            }
            catch (Exception)
            {
            }
        }
        ///******************************************************************//////
        #endregion

    }
}