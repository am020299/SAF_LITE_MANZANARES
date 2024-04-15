using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using Presentacion.Formularios.Moneda;
using Presentacion.Formularios.Contabilidad;
using Presentacion.Clases;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraReports.UI;
using Presentacion.Formularios.Ventas;
using Presentacion.Reportes.Caja;
using Presentacion.Reportes.Ventas;
using DevExpress.XtraReports.Parameters;

namespace Presentacion.Formularios.Principal
{
    public partial class xfrm_Principal:DevExpress.XtraBars.Ribbon.RibbonForm
    {
        string nombre, usuario;
        int id_empleado;
        int vContador = 6;
        long id_logueado;
        decimal tipo_cambio_dia = 0, tipo_cambio_mensual=0,tipo_Mensual_compra=0;
        public xfrm_Principal( )
        {
            InitializeComponent();
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = Properties.Settings.Default["ProyectoSkin"].ToString();
            this.nombre = Clases.UsuarioLogueado.vNombreCompleto;
            this.usuario = Clases.UsuarioLogueado.vNickName;
            this.id_empleado = Clases.UsuarioLogueado.vID_Empleado;
            this.id_logueado = Clases.UsuarioLogueado.vID_logueado;
        }
        private DateTime _vFechaInicial;
        private DateTime _vFechaFinal;

        public DateTime vFechaInicial { get => _vFechaInicial; set => _vFechaInicial = value; }
        public DateTime vFechaFinal { get => _vFechaFinal; set => _vFechaFinal = value; }

        #region METODOS VARIOS
        private int h, m, s;
        private string am_pm, dateStr;
        private bool ExistForm(XtraForm form)
        {
            foreach(var child in MdiChildren)
            {
                if(child.Name == form.Name && child.Text == form.Text)
                {
                    child.Activate();
                    return true;
                }
            }
            return false;
        }

        private string getDateTime(string dateAllStr)
        {
            try
            {
                h = Convert.ToInt32(dateAllStr.Substring(dateAllStr.Length - 13,2));
                m = Convert.ToInt32(dateAllStr.Substring(dateAllStr.Length - 10,2));
                s = Convert.ToInt32(dateAllStr.Substring(dateAllStr.Length - 7,2));
                am_pm = dateAllStr.Substring(dateAllStr.Length - 5,5);

            }
            catch(Exception ex) { XtraMessageBox.Show(ex.Message.ToString()); }

            return h.ToString().PadLeft(2,'0') + ":" + m.ToString().PadLeft(2,'0') + ":" + s.ToString().PadLeft(2,'0') + am_pm;
        }

        public void ObtenerFechaHora( )
        {
            try
            {
                var vNombreEquipo = Environment.MachineName;

                DateTime DateTime_Local = DateTime.Now; // Obtener fecha del servidor
                string vFH_Local = string.Format("{0} - {1}", DateTime_Local.ToLongDateString(), DateTime_Local.ToString("hh:mm:ss t.\\m."));

                dateStr = vFH_Local.Substring(0,vFH_Local.Length - 16);
                string vHoraLocal = getDateTime(vFH_Local);

                this.barStaticItemFechaHora.Caption = dateStr + " - " + vHoraLocal;
            }
            catch(Exception) { }
        }

        private bool ObtenerTipoCambioDia( )
        {
            tipo_cambio_dia = Negocio.ClasesCN.DatosRequeridosCN.Obtener_tipo_cambio_hoy();
            tipo_cambio_mensual = Negocio.ClasesCN.DatosRequeridosCN.obtener_tipo_cambio_mensual();
            tipo_Mensual_compra = Negocio.ClasesCN.DatosRequeridosCN.obtener_tipo_cambio_mensual_Compra();
            if(tipo_cambio_dia > 0)
            {
                return true;
            }
            else
                return false;
        }

        private bool Consultar_Si_Hay_Datos_Empresa( )
        {
            return Negocio.ClasesCN.DatosRequeridosCN.Datos_Empresa();
        }

        private void Importar_Tipo_Cambio( )
        {
            Clases.MyMessageBox.MessageFont = new Font(Clases.MyMessageBox.MessageFont.FontFamily,28);
            Clases.MyMessageBox.Show("No hay Tipo Cambio para el mes en curso; Importar el archivo en excel","SAFNISA",MessageBoxButtons.OK,MessageBoxIcon.Information);
            frmTipoCambio fr = new frmTipoCambio();
            fr.ShowDialog();
            tipo_cambio_dia = Negocio.ClasesCN.DatosRequeridosCN.Obtener_tipo_cambio_hoy();
            IniciarTimers();
            this.barStaticItemUsuario.Caption = "Usuario: " + usuario;
            this.barStaticItem_nombre_completo.Caption = "Nombre: " + nombre;
            this.barStaticItem_tipo_cambio.Caption = "Tipo Cambio Día: C$ " + Convert.ToString(tipo_cambio_dia)+" Tipo Cambio VENTA: C$"+ Convert.ToString(tipo_cambio_mensual) + " Tipo Cambio COMPRA: C$" + Convert.ToString(tipo_Mensual_compra);
        }

        private void Formulario_Datos_Empresa( )
        {
            xfrm_DatosEmpresa fr = new xfrm_DatosEmpresa();
            fr.ShowDialog();
            if(ObtenerTipoCambioDia())
            {

                IniciarTimers();
                this.barStaticItemUsuario.Caption = "Usuario: " + usuario;
                this.barStaticItem_nombre_completo.Caption = "Nombre: " + nombre;
                this.barStaticItem_tipo_cambio.Caption = "Tipo Cambio Día: C$ " + Convert.ToString(tipo_cambio_dia) + " Tipo Cambio VENTA: C$" + Convert.ToString(tipo_cambio_mensual) + " Tipo Cambio COMPRA: C$" + Convert.ToString(tipo_Mensual_compra);
            }
            else
                Importar_Tipo_Cambio();
        }

        private void IniciarTimers( )
        {
            ObtenerFechaHora();
            //timer_UsuarioActivo.Interval = 1000;
            //timer_UsuarioActivo.Start();
            //this.timer_UsuarioActivo.Interval = 10000;
            //this.timer_UsuarioActivo.Start();
            //----------------------------------------
            //this.timer_TT.Interval = 10000;
            //this.timer_TT.Start();
            //----------------------------------------
            this.timer1.Interval = 1000;
            this.timer1.Start();
            this.timer_UsuarioActivo.Interval = 15000;
            this.timer_UsuarioActivo.Start();
            //----------------------------------------
            this.timer_MensajeCierre.Interval = 1000;
        }

        private void xfrm_Principal_Load(object sender,EventArgs e)
        {
            //backstageViewControl1.Ribbon.ShowApplicationButtonContentControl();
            Buscar_Permisos_Roles_Sin_Guardar();
            Consultar_Permisos();
            if (Consultar_Si_Hay_Datos_Empresa() == false)
            {
                //if (ObtenerTipoCambioDia())
                {

                    IniciarTimers();
                    this.barStaticItemUsuario.Caption = "Usuario: " + usuario;
                    this.barStaticItem_nombre_completo.Caption = "Nombre: " + nombre;
                    this.barStaticItem_tipo_cambio.Caption = "Tipo Cambio Compra: C$ " + Convert.ToString(tipo_Mensual_compra.ToString("n2")) + " Tipo Cambio Mensual: C$" + Convert.ToString(tipo_cambio_mensual.ToString("n2"));
                    //if (Clases.UsuarioLogueado.saberAdminM())
                    //{
                    //    barButtonItem2.Visibility = BarItemVisibility.Always;
                    //}
                    //else
                    //{
                    //    barButtonItem2.Visibility = BarItemVisibility.Never;
                    //}
                }
                //else
                //    Importar_Tipo_Cambio();
            }
            else
                Formulario_Datos_Empresa();
        }

        private void xfrm_Principal_FormClosing(object sender,FormClosingEventArgs e)
        {
            if(vExit == 1)
            {
                Properties.Settings.Default["ProyectoSkin"] = DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName;
                Properties.Settings.Default.Save();
                //this.Dispose();
            }
            else
            {
                Clases.MyMessageBox.MessageFont = new Font(Clases.MyMessageBox.MessageFont.FontFamily,28);
                if(Clases.MyMessageBox.Show("¿Desea Salir Del Sistema?","SAFNISA",MessageBoxButtons.YesNo,MessageBoxIcon.Question) != DialogResult.Yes) { e.Cancel = true; return; }
                Negocio.ClasesCN.LoginsCN.Terminar_inicio_sesion(id_empleado);
                Properties.Settings.Default["ProyectoSkin"] = DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName;
                Properties.Settings.Default.Save();
                this.Dispose();
                this.Close();
                //Presentacion.Formularios.Login.xfrm_Login fr = new Login.xfrm_Login();
                //fr.Show();
            }
        }

        private void timer1_Tick(object sender,EventArgs e)

        {
            try
            {
                s = s + 1;

                if(s == 60)
                {
                    m = m + 1;
                    s = 0;
                }
                if(m == 60)
                {
                    h = h + 1;
                    m = 0;
                }
                if(h == 24 && m == 59 && s == 59)
                {
                    ObtenerFechaHora();
                }

                this.barStaticItemFechaHora.Caption = dateStr + " - " + h.ToString().PadLeft(2,'0') + ":" + m.ToString().PadLeft(2,'0') + ":" + s.ToString().PadLeft(2,'0') + am_pm;
             
            }
            catch(Exception) { }
        }

        private void backstageViewButtonItem_InfoEmpresa_ItemClick(object sender,DevExpress.XtraBars.Ribbon.BackstageViewItemEventArgs e)
        {
            xfrm_DatosEmpresa empresa = new xfrm_DatosEmpresa();
            empresa.ShowDialog();
        }

        private void barButtonItem_CerrarTodas_ItemClick(object sender,ItemClickEventArgs e)
        {
            for(int i = xtraTabbedMdiManager1.Pages.Count - 1;i >= 0;i--)
            {
                xtraTabbedMdiManager1.Pages[i].MdiChild.Close();
            }
        }

        private int vExit;

        private void backstageViewButtonItemSalir_ItemClick(object sender,DevExpress.XtraBars.Ribbon.BackstageViewItemEventArgs e)
        {
            Clases.MyMessageBox.MessageFont = new Font(Clases.MyMessageBox.MessageFont.FontFamily,28);
            if(Clases.MyMessageBox.Show("¿Desea Salir Del Sistema?","SAFNISA",MessageBoxButtons.YesNo,MessageBoxIcon.Question) != DialogResult.Yes) return;
            vExit = 1;
            Application.Exit();
        }

        private void Ubicar_Y_Mostrar_Panel_De_Mensaje_De_Error( )
        {
            try
            {
                foreach(XtraForm xfrm in this.MdiChildren)
                    xfrm.Close();

                int vAlto_frmPrincipal = (this.Height / 2);
                int vAncho_frmPrincipal = (this.Width / 2);

                int vAlto_panel2 = this.panel3.Height;
                int vAncho_panel2 = (this.panel3.Width / 2);

                this.panel3.Visible = true;
                this.panel3.Location = new Point((vAncho_frmPrincipal - vAncho_panel2),(vAlto_frmPrincipal - vAlto_panel2));

                vContador = vContador - 1;

                this.lbl_Mensaje2.Text = string.Format("La aplicación se cerrará en {0} segundos ...",vContador);

                if(vContador == 0)
                {
                    this.timer_MensajeCierre.Stop();
                    GC.Collect();
                    this.Dispose();
                    this.Close();
                    this.panel3.Visible = false;
                    Application.Exit();
                }
            }
            catch(Exception) { }
        }

        private void timer_MensajeCierre_Tick(object sender,EventArgs e)
        {
            Ubicar_Y_Mostrar_Panel_De_Mensaje_De_Error();
        }

        private void timer_UsuarioActivo_Tick(object sender,EventArgs e)
        {
            try
            {
                Consultar_Permisos();
                tipo_cambio_dia = Negocio.ClasesCN.DatosRequeridosCN.Obtener_tipo_cambio_hoy();
                tipo_cambio_mensual = Negocio.ClasesCN.DatosRequeridosCN.obtener_tipo_cambio_mensual();
                tipo_Mensual_compra = Negocio.ClasesCN.DatosRequeridosCN.obtener_tipo_cambio_mensual_Compra();
                this.barStaticItem_tipo_cambio.Caption = "Tipo Cambio Compra: C$ " + Convert.ToString(tipo_Mensual_compra.ToString("n2")) + " Tipo Cambio Mensual: C$" + Convert.ToString(tipo_cambio_mensual.ToString("n2"));

                if (Negocio.ClasesCN.LoginsCN.Consultar_id_Logueado(id_empleado, id_logueado) == false)
                {
                    timer_MensajeCierre.Start();
                }
            }
            catch(Exception)
            {
                XtraMessageBox.Show("Error al cerrar la sesión activa...","NetSoftNic",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        #endregion

        #region CATALOGOS

        private void bbiCatalogos_ItemClick(object sender,ItemClickEventArgs e)
        {
            try
            {
                var form = new Catalogos.xfrm_Catalogos();
                if(ExistForm(form)) return;
                form.MdiParent = this;
                form.Show();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void bbiImportarCatalogos_ItemClick(object sender,ItemClickEventArgs e)
        {
            try
            {
                var form = new Catalogos.xfrm_ImportarCatalogos();
                if(ExistForm(form)) return;
                form.MdiParent = this;
                form.Show();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region COMPRAS

        private void bbiMostrarCompras_ItemClick(object sender,ItemClickEventArgs e)
        {
            try
            {
                var form = new Compras.xfrm_MostrarCompra();
                if(ExistForm(form)) return;
                form.MdiParent = this;
                form.Show();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void bbiNuevaCompra_ItemClick(object sender,ItemClickEventArgs e)
        {
            try
            {
                var form = new Compras.xfrm_NuevaCompra(0);
                if(ExistForm(form)) return;
                form.MdiParent = this;
                form.Show();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region VENTAS

        private void bbiMostrarVentas_ItemClick(object sender,ItemClickEventArgs e)
        {
            try
            {
                var form = new Ventas.xfrm_MostrarVentas(1);
                if(ExistForm(form)) return;
                form.MdiParent = this;
                form.Show();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void bbiNuevaVentaNormal_ItemClick(object sender,ItemClickEventArgs e)
        {
            try
            {
                var form = new Ventas.xfrm_NuevaVenta(1);
                if(ExistForm(form)) return;
                form.MdiParent = this;
                form.Show();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void bbiNuevaVentaTactil_ItemClick(object sender,ItemClickEventArgs e)
        {
            try
            {
                var form = new Ventas.xfrm_FacturaTactil();
                if(ExistForm(form)) return;
                form.MdiParent = this;
                form.Show();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void bbiCotizacion_ItemClick(object sender,ItemClickEventArgs e)
        {
            try
            {
                var form = new Ventas.xfrm_MostrarVentas(0);
                form.Text = "COTIZACIONES CORDOBAS";
                if(ExistForm(form)) return;
                form.MdiParent = this;
                form.Show();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void bbiNuevaCotizacion_ItemClick(object sender,ItemClickEventArgs e)
        {
            try
            {
                var form = new Ventas.xfrm_NuevaVenta(0);
                form.Text = "NUEVA COTIZACIÓN";
                form.layout_control_numero.Text = "NUMERO COTIZACION";
                form.txtNumeroFactura.Enabled = false;
                if(ExistForm(form)) return;
                form.MdiParent = this;
                form.Show();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        private void bbi_factura_scanner_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                var form = new Ventas.xfrm_FacturaScanner();
                if (ExistForm(form)) return;
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region CAJA
        private void bbi_ingreso_egreso_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                var form = new Caja.xfrm_ingreso_egreso();
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void bbi_facturar_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                var form = new Ventas.xfrm_facturas_sin_cencelar();
                if (ExistForm(form)) return;
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void bbi_movimiento_caja_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                var form = new Caja.xfrm_movimiento_efectivo();
                if (ExistForm(form)) return;
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void bbi_tipo_cambio_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                var form = new Moneda.frmTipoCambioUnico();
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region CONTABILIDAD
        private void bbi_CatalogoCuentas_ItemClick(object sender,ItemClickEventArgs e)
        {
            try
            {
                var form = new Contabilidad.xfrm_ver_cuentas_contables();
                if(ExistForm(form)) return;
                form.MdiParent = this;
                form.Show();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void bbi_CrearAsientos_ItemClick(object sender,ItemClickEventArgs e)
        {
            try
            {
                Contabilidad.xfrm_NuevoAsientoContable form = new Contabilidad.xfrm_NuevoAsientoContable();

                IComprobantes comprobantes= form as IComprobantes;
                if(comprobantes != null)
                {
                    comprobantes.isNuevo=true;
                    form.Text=$"NUEVO ASIENTO CONTABLE";
                    if(ExistForm(form)) return;
                    form.MdiParent = this;
                    form.Show();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void bbi_BuscarAsientos_ItemClick(object sender,ItemClickEventArgs e)
        {
            try
            {
                var form = new Contabilidad.xfrm_buscarComprobantes();
                if(ExistForm(form)) return;
                form.MdiParent = this;
                form.Show();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region INVENTARIO

        private void bbiMovimientoInventario_ItemClick(object sender,ItemClickEventArgs e)
        {
            try
            {
                var form = new Inventario.xfrm_MovimientoInventario();
                if(ExistForm(form)) return;
                form.MdiParent = this;
                form.Show();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void bbiKardex_ItemClick(object sender,ItemClickEventArgs e)
        {
            try
            {
                var form = new Inventario.xfrm_Kardex();
                if(ExistForm(form)) return;
                form.MdiParent = this;
                form.Show();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void bbiAjustesInventario_ItemClick(object sender,ItemClickEventArgs e)
        {
            try
            {
                var form = new Inventario.xfrm_AjusteInventario();
                if(ExistForm(form)) return;
                form.MdiParent = this;
                form.Show();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void bbiTrasladosBodega_ItemClick(object sender,ItemClickEventArgs e)
        {
            try
            {
                var form = new Inventario.xfrm_TrasladosBodega();
                if(ExistForm(form)) return;
                form.MdiParent = this;
                form.Show();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region MANTENIMIENTO
        private void bbi_permisos_ItemClick(object sender,ItemClickEventArgs e)
        {
            try
            {
                var form = new Mantenimiento.xfrm_asignar_permisos();
                if(ExistForm(form)) return;
                form.MdiParent = this;
                form.Show();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        private void bbi_usuarios_logueados_ItemClick(object sender,ItemClickEventArgs e)
        {
            try
            {
                var form = new Mantenimiento.xfrm_usuarios_logueados();
                if (ExistForm(form)) return;
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void bbi_mantenimiento_sistema_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                var form = new Mantenimiento.xfrm_mantenimiento();
                form.Show();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void bbi_cambiar_usuario_contraseña_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                var form = new Mantenimiento.xfrm_cambiar_contraseña();
                form.Show();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region CUENTAS POR COBRAR
        private void bbi_pendientes_de_pago_ItemClick(object sender,ItemClickEventArgs e)
        {
            try
            {
                var form = new CuentasCobrar.xfrm_CuentasCobrar();
                if(ExistForm(form)) return;
                form.MdiParent = this;
                form.Show();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }



        private void btn_nuevo_documento_ItemClick(object sender,ItemClickEventArgs e)
        {
            try
            {
                var form = new CuentasCobrar.xfrm_Agrega_Documento();
                if(ExistForm(form)) return;
                form.MdiParent = this;
                form.Show();
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }

  

        private void btn_aplicacion_documentos_ItemClick(object sender,ItemClickEventArgs e)
        {
            try
            {
                var form = new CuentasCobrar.xfrm_aplicacion_documentos();
                if(ExistForm(form)) return;
                form.MdiParent = this;
                form.Show();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void bbi_reporte_detallado_ItemClick(object sender,ItemClickEventArgs e)
        {
            try
            {
                var form = new Inventario.xfrm_movimiento_inventario_detallado();
                if(ExistForm(form)) return;
                form.MdiParent = this;
                form.Show();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void bbi_arqueo_Caja_ItemClick(object sender,ItemClickEventArgs e)
        {
            try
            {
                var form = new Caja.xfrm_arqueo_detalle();
                if(ExistForm(form)) return;
                form.MdiParent = this;
                form.Show();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void bbi_historico_clientes_ItemClick(object sender,ItemClickEventArgs e)
        {

            try
            {
                var form = new Formularios.Catalogos.xfrm_Historico_clientes();
                if(ExistForm(form)) return;
                form.MdiParent = this;
                form.Show();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void bbi_consulta_inventario_ItemClick(object sender,ItemClickEventArgs e)
        {

            try
            {
                var form = new Formularios.Inventario.xfrm_consulta_Inventario();
                if(ExistForm(form)) return;
                form.MdiParent = this;
                form.Show();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void bbi_Consulta_deAjustes_ItemClick(object sender,ItemClickEventArgs e)
        {
            try
            {
                var form = new Formularios.Inventario.xfrm_consulta_ajustes_Inventario();
                if(ExistForm(form)) return;
                form.MdiParent = this;
                form.Show();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void bbi_consulta_traslados_ItemClick(object sender,ItemClickEventArgs e)
        {
            try
            {
                var form = new Formularios.Inventario.xfrm_Consulta_Traslados();
                if(ExistForm(form)) return;
                form.MdiParent = this;
                form.Show();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void bbi_existencias_ItemClick(object sender,ItemClickEventArgs e)
        {
            try
            {
                var form = new Formularios.Inventario.consulta_existencias();
                if(ExistForm(form)) return;
                form.MdiParent = this;
                form.Show();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void bbi_verificar_catalogo_ItemClick(object sender,ItemClickEventArgs e)
        {
            try
            {
                var form = new Formularios.Catalogos.xfrm_verficar_Excel_importar();
                if(ExistForm(form)) return;
                form.MdiParent = this;
                form.Show();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void bbi_consulta_baja_existencia_ItemClick(object sender,ItemClickEventArgs e)
        {

        }

        private void bbi_reporte_diferencia_ItemClick(object sender,ItemClickEventArgs e)
        {
            try
            {
                var form = new Caja.xrpt_reporte_diferencia();
                if(ExistForm(form)) return;
                form.MdiParent = this;
                form.Show();
            }
            catch(Exception ex)
            {
                throw ex;
            }


        }

        private void reporte_de_subgrupo_ItemClick(object sender,ItemClickEventArgs e)
        {
            try
            {
                var form = new Inventario.xfrm_grupos_subgrupos();
                if(ExistForm(form)) return;
                form.MdiParent = this;
                form.Show();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void btn_productosMasVendidos_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                var form = new Ventas.xfrm_productos_mas_vendidos();
                if (ExistForm(form)) return;
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                var form = new Caja.XtraTransferenciaReporte();
                if (ExistForm(form)) return;
                form.MdiParent = this;
                form.Show();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

      
        private void btnRptCambioPrecioCliente_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraCambioPrecioCLiente reporte = new XtraCambioPrecioCLiente();
            var query = Negocio.ClasesCN.VentasCN.getDetectarCambioPrecioCliente(DateTime.Now.Date);
            reporte.DataSource = query;
            reporte.Parameters[0].Value = DateTime.Now;
            reporte.ShowPreview();
        }
        

        private void btn_Reporteria_cxc_ItemClick(object sender,ItemClickEventArgs e)
        {

            try
            {
                var form = new CuentasCobrar.xfrm_ReportesCXC();
                if(ExistForm(form)) return;
                form.MdiParent = this;
                form.Show();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }        

        private void bbi_Antiguedad_de_Saldos_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                var form = new CuentasCobrar.xfrm_antiguendad_de_saldos();
                if (ExistForm(form)) return;
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void bbi_reporte_autorizacion_ItemClick(object sender, ItemClickEventArgs e)
        {
            //BindingSource source = new BindingSource();
            //source.DataSource = Negocio.ClasesCN.RolesPermisosCN.Reporte_Autorizacion(DateTime.Now.Date, DateTime.Now.Date,0);
            //if (source.Count == 0) return;
            var report = new Reportes.Autorizacion.xrpt_autorizacion();
            report.Parameters[0].Value = DateTime.Now.Date;
            report.Parameters[1].Value = DateTime.Now.Date;
            DynamicListLookUpSettings rptSettings = new DynamicListLookUpSettings();
            rptSettings.DataSource = Negocio.ClasesCN.RolesPermisosCN.Cargar_Empleados_Autoriza();
            rptSettings.DisplayMember = "nombre";
            rptSettings.ValueMember = "id";
            report.Parameters[2].LookUpSettings = rptSettings;
            report.ShowPreview();
        }

        private void bbi_reporte_clientes_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                //BindingSource source = new BindingSource();
                //source.DataSource = Negocio.ClasesCN.CatalogosCN.RPTCliente_Cargar(vFechaInicial, vFechaFinal);
                var report = new Presentacion.Reportes.Catalogos.xrptNuevosClientes();
                report.fecha_ini.Value = DateTime.Now.AddMonths(-1);
                report.fecha_fin.Value = DateTime.Now;
                report.ShowPreview();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void bbi_lista_precios_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                var form = new Catalogos.xfrmListaPrecios();
                if (ExistForm(form)) return;
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void bbi_cantidad_billetes_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                //BindingSource source = new BindingSource();
                //source.DataSource = Negocio.ClasesCN.CatalogosCN.RPTCliente_Cargar(vFechaInicial, vFechaFinal);
                var report = new Reportes.Caja.xrptDenominacionesBilletes();
                report.fecha_ini.Value = DateTime.Now.AddDays(-15);
                report.fecha_fin.Value = DateTime.Now;
                report.ShowPreview();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void bbi_autorizar_mov_inv_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                var form = new Inventario.xfrm_Aut_MovimientoInventario();
                if (ExistForm(form)) return;
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void bbi_consulta_ajuste_aut_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                var form = new Formularios.Inventario.xfrm_consulta_ajustes_Inventario_Aut();
                if (ExistForm(form)) return;
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void bbi_nuevaRemision_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                var form = new Ventas.xfrm_NuevaRemision(2);
                if (ExistForm(form)) return;
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void bbi_MostrarRemisiones_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                var form = new Ventas.xfrm_MostrarRemisiones(0);
                if (ExistForm(form)) return;
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void bbi_consulta_inventarioTienda_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                var form = new Inventario.xfrm_KardexConsultaTienda();
                if (ExistForm(form)) return;
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void bbi_facturas_retencion_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                var report = new Reportes.Ventas.xfrm_facturas_retenciones();
                report.Parameters[0].Value = DateTime.Now.AddMonths(-1);
                report.Parameters[1].Value = DateTime.Now;
                report.ShowPreview();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void bbiNuevoPrestamo_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                var form = new Ventas.xfrm_NuevoPrestamo(3);
                if (ExistForm(form)) return;
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void bbiMostrarPrestamos_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                var form = new Ventas.xfrm_MostrarPrestamos(3);
                if (ExistForm(form)) return;
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void bbiListaPreciosCordoba_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                var form = new Catalogos.xfrmListaPreciosCordoba();
                if (ExistForm(form)) return;
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void bbiVentasSubGrupo_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                var form = new Ventas.xfrm_ventasSubGrupo();
                if (ExistForm(form)) return;
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void bbi_reimprimirFacturasDolar_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                var form = new Ventas.xfrm_MostrarVentasDolar(1);
                if (ExistForm(form)) return;
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void bbi_cotizacionDolar_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                var form = new Ventas.xfrm_MostrarVentasDolar(0);
                form.Text = "COTIZACIONES DOLARES";
                if (ExistForm(form)) return;
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void bbi_MostrarRemisionesDolar_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                var form = new Ventas.xfrm_MostrarRemisionesDolares(0);
                if (ExistForm(form)) return;
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void bbiMostrarPrestamosDolar_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                var form = new Ventas.xfrm_MostrarPrestamosDolares(3);
                if (ExistForm(form)) return;
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void bbi_reimprimirVoucher_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                var form = new CuentasCobrar.xfrm_ReimprimirVouchersCxc();
                if (ExistForm(form)) return;
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void bbi_CancelarFacturaDolar_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                var form = new CuentasCobrar.xfrm_aplicacion_documentosDolares();
                if (ExistForm(form)) return;
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void bbi_PendientesCancelarDolar_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                var form = new CuentasCobrar.xfrm_CuentasCobrarDolares();
                if (ExistForm(form)) return;
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void bbi_ReporteCheques_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                var form = new Caja.XtraChequeReporte();
                if (ExistForm(form)) return;
                form.MdiParent = this;
                form.Show();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void bbi_DevolucionFacturas_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                xfrm_devoluciones form = new xfrm_devoluciones();
                //if (ExistForm(form)) return;
                //form.MdiParent = this;
                form.ShowDialog();
                form.Dispose();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void bbi_FacturasPrecioDistintos_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                var form = new Catalogos.xfrm_Historico_clientesV2();
                if (ExistForm(form)) return;
                form.MdiParent = this;
                form.Show();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void bbi_EntradaInv_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                var form = new Compras.xfrm_MostrarEntradas();
                if (ExistForm(form)) return;
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void bbi_FacturaPreciosDistintosCordobas_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                var form = new Catalogos.xfrm_Historico_clientesV3();
                if (ExistForm(form)) return;
                form.MdiParent = this;
                form.Show();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void bbi_DevolucionFacturasCor_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                xfrm_devolucionesCordobas form = new xfrm_devolucionesCordobas();
                //if (ExistForm(form)) return;
                //form.MdiParent = this;
                form.ShowDialog();
                form.Dispose();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void bbiMostrarDevoluciones_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                var form = new Inventario.xfrm_MostrarDevoluciones();
                if (ExistForm(form)) return;
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void bbiMostrarDevolucionesCor_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                var form = new Inventario.xfrm_MostrarDevolucionesCordobas();
                if (ExistForm(form)) return;
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void bbiSaldoFavorCliente_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                var form = new Caja.XtraSaldoClientesDolar();
                if (ExistForm(form)) return;
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void bbiSaldoFavorClienteCordobas_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                var form = new Caja.XtraSaldoClientesCordobas();
                if (ExistForm(form)) return;
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void bbiSaldoSinUsarClienteCordoba_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                var form = new Caja.XtraSaldoClientesCordobasSinUsar();
                if (ExistForm(form)) return;
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void bbiSaldoSinUsarClientes_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                var form = new Caja.XtraSaldoClientesDolarSinUsar();
                if (ExistForm(form)) return;
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void bbi_devolucionProdD_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                xfrm_devolucionesProductoDañado form = new xfrm_devolucionesProductoDañado();
                //if (ExistForm(form)) return;
                //form.MdiParent = this;
                form.ShowDialog();
                form.Dispose();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void bbi_DevolucionProdDCord_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                xfrm_devolucionesProductoDañadoCordobas form = new xfrm_devolucionesProductoDañadoCordobas();
                //if (ExistForm(form)) return;
                //form.MdiParent = this;
                form.ShowDialog();
                form.Dispose();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void bbi_MostrarDevProdD_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                var form = new Inventario.xfrm_MostrarDevolucionesProdDañado();
                if (ExistForm(form)) return;
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void bbi_MostrarDevProdDCordobas_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                var form = new Inventario.xfrm_MostrarDevolucionesProdDañadoCordobas();
                if (ExistForm(form)) return;
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void bbi_ConsultaInventario_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                var form = new Formularios.Inventario.xfrm_consulta_InventarioEspecial();
                if (ExistForm(form)) return;
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void bbi_MovProductoCompras_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                var form = new Formularios.Inventario.xfrm_MovProdDet();
                //if (ExistForm(form)) return;
                //form.MdiParent = this;
                form.ShowDialog();
                form.Dispose();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void bbi_listado_cxc_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                var form = new CuentasCobrar.xfrm_lista_cxc();
                if (ExistForm(form)) return;
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion

        #region PERMISOS
        void Consultar_Permisos()
        {
            int tu = Saber_Si_Usuario_Es_Admin();
           
            if (tu == 0)///USUARIO NORMAL
            {
                int contador_grupos_habilitados;
                foreach (RibbonPage rp in ribbon.Pages)
                {
                    contador_grupos_habilitados = 0;
                    foreach (RibbonPageGroup rpg in rp.Groups)
                    {
                        rpg.Visible = false;
                        foreach (BarItemLink link in rpg.ItemLinks)
                        {
                            link.Visible= false;
                            int numero_grupo = Convert.ToInt32(link.Item.Tag);
                            if (Negocio.ClasesCN.RolesPermisosCN.Permisos(id_empleado, numero_grupo))
                            {
                                contador_grupos_habilitados += 1;
                                link.Visible = true;
                                rpg.Visible = true;
                            }                                
                        }
                       
                    }
                    if (contador_grupos_habilitados == 0)
                        rp.Visible = false;
                    else
                        rp.Visible =  true;
                }
                int id_back = Convert.ToInt32(Ribbon.Tag);
                backstageViewTabItemConfiguracion.Visible = backstageViewButtonItem_InfoEmpresa.Visible = false;
                if (Negocio.ClasesCN.RolesPermisosCN.Permisos(id_empleado, id_back))
                    backstageViewTabItemConfiguracion.Visible = backstageViewButtonItem_InfoEmpresa.Visible = true;
            }
            else if (tu == 2)////SUPER ADMIN
            {
                //foreach (RibbonPage rp in ribbon.Pages)
                //{
                //    foreach(RibbonPageGroup rpg in rp.Groups)
                //    {
                //        rpg.Visible = true;
                //        if(rpg.Name == "group_cuentas_cobrar")
                //        {
                //            rpg.Visible = false;
                //        }
                //    //}
                //    if(rp.Name == "ribbonPageContabilidad")
                //    {
                //        rp.Visible = false;
                //    }
                //    rp.Visible = true;

                //    }
                //}
                foreach (RibbonPage rp in ribbon.Pages)
                {
                    foreach (RibbonPageGroup rpg in rp.Groups)
                        rpg.Visible = true;
                    rp.Visible = true;
                }
            }
        }
        private void Buscar_Permisos_Roles_Sin_Guardar()
        {
            foreach (RibbonPage rp in ribbon.Pages)
            {
                foreach (RibbonPageGroup rpg in rp.Groups)
                {
                    foreach (BarItemLink link in rpg.ItemLinks)
                    {
                        int numero_rol = Convert.ToInt32(rpg.Tag);
                        string nombre_rol = Convert.ToString(rpg.Text);
                        int numero_permiso = Convert.ToInt32(link.Item.Tag);
                        string nombre_permiso = Convert.ToString(link.Item.Caption);
                        Negocio.ClasesCN.RolesPermisosCN.Consultar_Roles_Permisos(numero_rol,numero_permiso,nombre_rol,nombre_permiso);
                    }
                }
            }
        }
        private int Saber_Si_Usuario_Es_Admin()
        {
            return Negocio.ClasesCN.RolesPermisosCN.Consultar_Usuario_Admin(id_empleado);
        }
        #endregion

        #region REPORTES
        
        private void bbiRptInventario_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                var form = new Inventario.xfrm_RptInventario();
                if (ExistForm(form)) return;
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void bbiRptVentas_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                var form = new Ventas.xfrm_RptVenta();
                if (ExistForm(form)) return;
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion


    }
}