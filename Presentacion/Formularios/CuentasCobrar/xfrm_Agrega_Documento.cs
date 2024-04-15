using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using Presentacion.Clases;
using Presentacion.Formularios.Ventas;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Presentacion.Formularios.CuentasCobrar
{
    public partial class xfrm_Agrega_Documento:DevExpress.XtraEditors.XtraForm//, IDocumentoCuentasCobrar
    {
        public xfrm_Agrega_Documento( )
        {

            InitializeComponent();
        }
        public xfrm_Agrega_Documento(int id_cliente)
        {

            InitializeComponent();
            this.id_cliente=id_cliente;
        }
        bool haycontabillidad=Convert.ToBoolean(Negocio.ClasesCN.CuentasCobrarCN.ModuloSistema_Select().Where(X=>X.numero_modulo==2).FirstOrDefault().isActivo);
        int id_cliente=0;
        int id_documento=0;
        #region Cargar Listados
        private void Cargar_Listados( )
        {
            var Clientes=Negocio.ClasesCN.CatalogosCN.Cliente_Cargar().ToList();
            search_clientes.Properties.DataSource=Clientes;
            var TiposDocs=Negocio.ClasesCN.CuentasCobrarCN.TiposDocumentosCxc().ToList();
            search_tipo_documento.Properties.DataSource=TiposDocs;
            var Cobradores=Negocio.ClasesCN.CatalogosCN.Empleado_Cargar().ToList();
            search_cobrador.Properties.DataSource=Cobradores;
            var terminos=Negocio.ClasesCN.ParametrosCN.Terminos_Select().Where(C=>C.id!=1).ToList();
            look_terminos.Properties.DataSource=terminos;
        }
        #endregion
       private void xfrm_Agrega_Documento_Load(object sender,EventArgs e)
        {
            Cargar_Listados();

            date_Fecha_doc.EditValue=DateTime.Now.Date;
            search_clientes.EditValue=id_cliente;

            ///col_saldo_documento_cliente.Summary
        }
        private void txt_numero_doc_EditValueChanged(object sender,EventArgs e)
        {
            txt_numero_doc.Text=string.Concat(txt_numero_doc.Text.Where(char.IsLetterOrDigit));
        }
        private void search_tipo_documento_EditValueChanged(object sender,EventArgs e)
        {
            try
            {
                if(search_tipo_documento.EditValue !=null)
                {
                    txt_numero_doc.EditValue=Negocio.ClasesCN.CuentasCobrarCN.Verfica_maximo_documento(Convert.ToInt32(search_tipo_documento.EditValue))+1;
                    int tipo_doc=Convert.ToInt32(search_tipo_documento.EditValue);
                    if(tipo_doc==1)
                    {
                        date_Fecha_doc.Enabled=true;
                        search_cobrador.Enabled=true;
                        look_terminos.Enabled=true;
                        txt_concepto.Enabled=true;
                        txt_subtotal.Enabled=true;
                        txt_descuento.Enabled=true;
                        txt_impuesto.Enabled=true;
                        txt_retenciones.Enabled=true;
                        txt_monto_total.Enabled=true;
                        txt_numero_doc.Enabled=true;
                        txt_porcentaje_descuento.Enabled=true;
                        txt_porcentaje_impuesto.Enabled=true;
                        txt_retencion_porcentaje.Enabled=true;
                        txt_retenciones.EditValue=0.00m;
                        ly_fecha_vencimiento.Visibility=DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                        lydescuento.Visibility=DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                        ly_descuento_porcentaje.Visibility=DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                        ly_retenciones.Visibility=DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                        lyretenciones_porcentaje.Visibility= DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                        ly_impuesto.Visibility=DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                        ly_impuestoporcentaje.Visibility=DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                        lySubtotal.Visibility=DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                        ly_monto_total.Visibility=DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

                    }
                    else if(tipo_doc==5)
                    {
                        date_Fecha_doc.Enabled=true;
                        search_cobrador.Enabled=true;
                        look_terminos.Enabled=false;
                        txt_concepto.Enabled=true;
                        txt_subtotal.Enabled=true;
                        txt_descuento.Enabled=true;
                        txt_impuesto.Enabled=true;
                        txt_retenciones.Enabled=true;
                        txt_monto_total.Enabled=true;
                        txt_numero_doc.Enabled=true;
                        txt_retencion_porcentaje.Enabled=true;
                        txt_descuento.EditValue=0.00m;
                        txt_impuesto.EditValue=0.00m;
                        ly_fecha_vencimiento.Visibility=DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                        lydescuento.Visibility=DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                        ly_descuento_porcentaje.Visibility= DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                        lyretenciones_porcentaje.Visibility= DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                        ly_retenciones.Visibility=DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                        ly_impuesto.Visibility=DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                        ly_impuestoporcentaje.Visibility=DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                        lySubtotal.Visibility=DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                        ly_monto_total.Visibility=DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

                    }
                    else
                    {
                        date_Fecha_doc.Enabled=true;
                        search_cobrador.Enabled=true;
                        look_terminos.Enabled=false;
                        txt_concepto.Enabled=true;
                        txt_subtotal.Enabled=true;
                        txt_descuento.Enabled=true;
                        txt_impuesto.Enabled=true;
                        txt_retenciones.Enabled=true;
                        txt_monto_total.Enabled=true;
                        txt_numero_doc.Enabled=true;
                        ly_fecha_vencimiento.Visibility=DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                        lydescuento.Visibility=DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                        ly_descuento_porcentaje.Visibility= DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                        lyretenciones_porcentaje.Visibility= DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                        ly_retenciones.Visibility=DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                        ly_impuesto.Visibility=DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                        ly_impuestoporcentaje.Visibility=DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                        lySubtotal.Visibility=DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                        txt_descuento.EditValue=0.00m;
                        txt_retenciones.EditValue=0.00m;
                        txt_impuesto.EditValue=0.00m;
                    }

                }

            }
            catch(Exception ex)
            {
                XtraMessageBox.Show($"Lo sentimos ha ocurrido el siguiente error.{Environment.NewLine}Error:{ex.Message}.","Mensaje del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void look_terminos_EditValueChanged(object sender,EventArgs e)
        {
            try
            {
                if((look_terminos.EditValue!=null && Convert.ToInt32(look_terminos.EditValue??0)!=0) && date_Fecha_doc.EditValue!=null)
                {
                    DateTime FEcha_Vencimiento=date_Fecha_doc.DateTime.AddDays(Negocio.ClasesCN.ParametrosCN.Terminos_Select().Where(X=>X.id==(int)look_terminos.EditValue).FirstOrDefault().dias);
                    date_fecha_vencimiento.DateTime=FEcha_Vencimiento.Date;
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show($"Lo sentimos ha ocurrido el siguiente error.{Environment.NewLine}Error:{ex.Message}.","Mensaje del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void search_clientes_EditValueChanged(object sender,EventArgs e)
        {
            try
            {
                if(search_clientes.EditValue!=null)
                {
                    binding_documentos_cliente.DataSource=Negocio.ClasesCN.CuentasCobrarCN.DocumentosCuentasCobrar_Por_cliente(Convert.ToInt32(search_clientes.EditValue))
                        .Select(
                        X =>
                        new
                        {
                            X.id_documento,
                            X.numero_documento,
                            X.nombre_documento,
                            X.id_cliente,
                            X.numero_doc,
                            X.fecha_doc,
                            X.subtotal_doc,
                            X.monto_descuento_doc,
                            X.monto_impuesto_doc,
                            X.retenciones,
                            X.monto_doc,
                            X.saldo,
                            X.concepto,
                            X.dias,
                            X.nombre,
                            X.codigo,
                            fecha_vencimiento = X.fecha_vencimiento.HasValue==false ? null : X.fecha_vencimiento,
                            X.estatus_documento,
                            estatus_letras = X.estatus_documento==1 ? "VENCIDO" : X.estatus_documento==2 ? "CANCELADO" : X.estatus_documento==3 ? "PENDIENTE" : X.estatus_documento==4 ? "APLICADO" : X.estatus_documento==5 ? "NO APLICADO" : "N/A"
                        }
                        )
                        .ToList();
                    grid_docs_cliente.DataSource=binding_documentos_cliente;
                    grupo_detalles.Text="DETALLES "+search_clientes.Text.ToUpper();
                    btn_nuevo_documento.Enabled=btn_guardar.Enabled=true;
                    // btn_cancelar_documentos_ItemClick(null,null);
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show($"Lo sentimos ha ocurrido el siguiente error.{Environment.NewLine}Error:{ex.Message}.","Mensaje del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        decimal saldo_vencido=0.00m,pendiente=0.00m,aplicados=0.00m,no_aplicados=0.00m;
        private void gview_doc_cliente_MouseUp(object sender,MouseEventArgs e)
        {
            if(e.Button != MouseButtons.Right)
                return;
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hitInfo = gview_doc_cliente.CalcHitInfo(e.Location);
            if(hitInfo.InDataRow)
            {
                int id_documento= Convert.ToInt32(gview_doc_cliente.GetRowCellValue(hitInfo.RowHandle,col_id_documento_cliente));
                int tipo_documento =Convert.ToInt32(gview_doc_cliente.GetRowCellValue(hitInfo.RowHandle,col_numero_documento_cliente));
                decimal saldo_documento=Convert.ToDecimal(gview_doc_cliente.GetRowCellValue(hitInfo.RowHandle,col_saldo_documento_cliente));
                btn_anular_documentos.Enabled=btn_modificar_documento.Enabled=!Negocio.ClasesCN.CuentasCobrarCN.Documento_ya_Aplicado(id_documento);
                btn_guardar.Visibility=DevExpress.XtraBars.BarItemVisibility.Never;
                if(tipo_documento!=6 && tipo_documento!=1)
                {
                    brs_imprimir.Visibility=DevExpress.XtraBars.BarItemVisibility.Always;
                }
                else
                {
                    brs_imprimir.Visibility=DevExpress.XtraBars.BarItemVisibility.Never;
                }
                if((tipo_documento==2 || tipo_documento==4 || tipo_documento==5) && saldo_documento>0)
                {
                    bbi_aplicar.Visibility=DevExpress.XtraBars.BarItemVisibility.Always;
                }
                else
                {
                    bbi_aplicar.Visibility=DevExpress.XtraBars.BarItemVisibility.Never;
                }
                radialMenu1.ShowPopup(Control.MousePosition);

            }
        }
        private void btn_nuevo_documento_ItemClick(object sender,DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                btn_cancelar_documentos.Enabled=search_tipo_documento.Enabled=btn_guardar.Enabled=true;
                btn_guardar.Tag=1;
                search_tipo_documento.Focus();
                radialMenu1.HidePopup();


            }
            catch(Exception ex)
            {

                XtraMessageBox.Show($"Lo sentimos ha ocurrido el siguiente error.{Environment.NewLine}Error:{ex.Message}.","Mensaje del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void Cancelar( )
        {
            try
            {
                search_tipo_documento.EditValue=null;
                search_tipo_documento.Enabled=false;
                date_Fecha_doc.DateTime=DateTime.Now.Date;
                date_Fecha_doc.Enabled=false;
                search_cobrador.Enabled=false;
                search_cobrador.EditValue=null;
                look_terminos.EditValue=null;
                look_terminos.Enabled=false;
                txt_numero_doc.Enabled=false;
                txt_numero_doc.EditValue=0.00m;
                txt_concepto.EditValue=string.Empty;
                txt_concepto.Enabled=false;
                txt_subtotal.Enabled=false;
                txt_subtotal.EditValue=0.00m;
                txt_descuento.EditValue=0.00m;
                txt_descuento.Enabled=false;
                txt_impuesto.Enabled=false;
                txt_impuesto.EditValue=0.00m;
                txt_retenciones.EditValue=0.00m;
                txt_retenciones.Enabled=false;
                txt_monto_total.EditValue=0.00m;
                txt_monto_total.Enabled=false;
                txt_porcentaje_descuento.EditValue=0.00m;
                txt_porcentaje_impuesto.EditValue=0.00m;
                txt_retencion_porcentaje.EditValue=0.00m;
                btn_cancelar_documentos.Enabled=false;
                btn_guardar.Enabled=false;

                btn_guardar.Tag=1;
                id_documento=0;
                radialMenu1.HidePopup();
            }
            catch(Exception ex)
            {

                XtraMessageBox.Show($"Lo sentimos ha ocurrido el siguiente error.{Environment.NewLine}Error:{ex.Message}.","Mensaje del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void btn_cancelar_documentos_ItemClick(object sender,DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {

                Cancelar();

            }
            catch(Exception ex)
            {

                XtraMessageBox.Show($"Lo sentimos ha ocurrido el siguiente error.{Environment.NewLine}Error:{ex.Message}.","Mensaje del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void date_Fecha_doc_EditValueChanged(object sender,EventArgs e)
        {
            if(date_Fecha_doc.EditValue!=null && look_terminos.EditValue!=null && Convert.ToInt32(look_terminos.EditValue??0)!=0)
            {
                DateTime FEcha_Vencimiento=date_Fecha_doc.DateTime.AddDays(Negocio.ClasesCN.ParametrosCN.Terminos_Select().Where(X=>X.id==(int)look_terminos.EditValue).FirstOrDefault().dias);
                date_fecha_vencimiento.DateTime=FEcha_Vencimiento.Date;
            }
        }
        private void txt_subtotal_KeyPress(object sender,KeyPressEventArgs e)
        {
            if(e.KeyChar==(char) Keys.Enter || e.KeyChar==(char) Keys.Tab)
            {
                txt_descuento.Focus();
            }
        }
        private void txt_subtotal_EditValueChanged(object sender,EventArgs e)
        {
            try
            {
                txt_monto_total.EditValue=Convert.ToDecimal(txt_subtotal.EditValue??0)-Convert.ToDecimal(txt_descuento.EditValue??0)+Convert.ToDecimal(txt_impuesto.EditValue??0)-Convert.ToDecimal(txt_retenciones.EditValue??0);
                if(Convert.ToDecimal(txt_subtotal.EditValue??0)>0)
                {
                    txt_descuento.EditValue=Math.Round(Convert.ToDecimal(txt_subtotal.EditValue??0)*(Convert.ToDecimal(txt_porcentaje_descuento.EditValue??0)/100),2,MidpointRounding.AwayFromZero);

                }
                if(Convert.ToDecimal(txt_porcentaje_impuesto.EditValue??0)>=0.00m || Convert.ToDecimal(txt_porcentaje_impuesto.EditValue??0)<=100.00m)
                {

                    txt_impuesto.EditValue=Math.Round((Convert.ToDecimal(txt_subtotal.EditValue??0)-Convert.ToDecimal(txt_descuento.EditValue??0))*(Convert.ToDecimal(txt_porcentaje_impuesto.EditValue??0)/100),2,MidpointRounding.AwayFromZero);
                }
                if(Convert.ToDecimal(txt_retencion_porcentaje.EditValue??0)>=0.00m &&  Convert.ToDecimal(txt_porcentaje_impuesto.EditValue??0)<=100.00m)
                {

                    txt_retenciones.EditValue=Math.Round((Convert.ToDecimal(txt_subtotal.EditValue??0)-Convert.ToDecimal(txt_descuento.EditValue??0))*(Convert.ToDecimal(txt_retencion_porcentaje.EditValue??0)/100),2,MidpointRounding.AwayFromZero);
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show($"Lo sentimos ha ocurrido el siguiente error.{Environment.NewLine}Error:{ex.Message}.","Mensaje del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void txt_descuento_EditValueChanged(object sender,EventArgs e)
        {
            txt_monto_total.EditValue=Convert.ToDecimal(txt_subtotal.EditValue??0)-Convert.ToDecimal(txt_descuento.EditValue??0)+Convert.ToDecimal(txt_impuesto.EditValue??0)-Convert.ToDecimal(txt_retenciones.EditValue??0);
            if(Convert.ToDecimal(txt_subtotal.EditValue??0)>0)
            {
                var vDescuento = txt_descuento.EditValue??0;
                txt_porcentaje_descuento.EditValue = Math.Round((((Convert.ToDecimal(vDescuento.ToString()) /(Convert.ToDecimal(txt_subtotal.EditValue??-1))))*100),2,MidpointRounding.AwayFromZero);

                txt_impuesto.EditValue=Math.Round((Convert.ToDecimal(txt_subtotal.EditValue??0)-Convert.ToDecimal(txt_descuento.EditValue??0))*(Convert.ToDecimal(txt_porcentaje_impuesto.EditValue??0)/100),2,MidpointRounding.AwayFromZero);
            }
        }
        private void txt_impuesto_EditValueChanged(object sender,EventArgs e)
        {
            txt_monto_total.EditValue=Convert.ToDecimal(txt_subtotal.EditValue??0)-Convert.ToDecimal(txt_descuento.EditValue??0)+Convert.ToDecimal(txt_impuesto.EditValue??0)-Convert.ToDecimal(txt_retenciones.EditValue??0);
            if(Convert.ToDecimal(txt_subtotal.EditValue??0)>0)
            {
                var vImpuesto = txt_impuesto.EditValue??0;
                txt_porcentaje_impuesto.EditValue = Math.Round((((Convert.ToDecimal(vImpuesto.ToString()) /(Convert.ToDecimal(txt_subtotal.EditValue??-1)-(Convert.ToDecimal(txt_descuento.EditValue??0)))))*100),2,MidpointRounding.AwayFromZero);
            }
        }
        private void txt_retenciones_EditValueChanged(object sender,EventArgs e)
        {
            txt_monto_total.EditValue=Convert.ToDecimal(txt_subtotal.EditValue??0)-Convert.ToDecimal(txt_descuento.EditValue??0)+Convert.ToDecimal(txt_impuesto.EditValue??0)-Convert.ToDecimal(txt_retenciones.EditValue??0);
            if(Convert.ToDecimal(txt_subtotal.EditValue??0)>0)
            {
                var v_retenciones = txt_retenciones.EditValue??0;
                txt_retencion_porcentaje.EditValue = Math.Round((((Convert.ToDecimal(v_retenciones.ToString()) /(Convert.ToDecimal(txt_subtotal.EditValue??0)-(Convert.ToDecimal(txt_descuento.EditValue)))))*100),2,MidpointRounding.AwayFromZero);
            }
        }
        private bool Documento_Valido( )
        {
            dxErrorProvider1.ClearErrors();
            bool retorno=false;

            if(Convert.ToInt32(search_tipo_documento.EditValue)==-1 ||search_tipo_documento.EditValue==null)
            {
                dxErrorProvider1.SetError(search_tipo_documento,"Tipo de documento Obligatorio");
                radialMenu1.HidePopup();
                return retorno;
            }
            else
            {
                if((int) search_tipo_documento.EditValue==1)
                {
                    if(date_Fecha_doc.EditValue==null)
                    {
                        dxErrorProvider1.SetError(date_Fecha_doc,"Fecha del  documento Obligatorio");
                        radialMenu1.HidePopup();
                        return retorno;
                    }
                    else if(Convert.ToInt32(search_cobrador.EditValue)==-1 || search_cobrador.EditValue==null)
                    {
                        dxErrorProvider1.SetError(search_cobrador,"Debe de Seleccionar cobrador");
                        radialMenu1.HidePopup();
                        return retorno;
                    }
                    else if(look_terminos.EditValue==null || Convert.ToInt32(look_terminos.EditValue)==-1)
                    {
                        dxErrorProvider1.SetError(look_terminos,"Terminos Documento Obligatorio");
                        radialMenu1.HidePopup();
                        return retorno;
                    }
                    else if(Convert.ToString(txt_numero_doc.EditValue)==String.Empty || txt_numero_doc.EditValue==null || Convert.ToString(txt_numero_doc.EditValue)=="0")
                    {
                        dxErrorProvider1.SetError(txt_numero_doc,"Numero de  Documento Obligatorio");
                        radialMenu1.HidePopup();
                        return retorno;

                    }
                    else if(txt_concepto.Text.Trim()==string.Empty || txt_concepto.EditValue==null)
                    {
                        dxErrorProvider1.SetError(txt_concepto,"Concepto de  Documento Obligatorio");
                        radialMenu1.HidePopup();
                        return retorno;

                    }
                    else if(Convert.ToInt32(txt_subtotal.EditValue)<=0 || txt_subtotal.EditValue==null)

                    {
                        dxErrorProvider1.SetError(txt_subtotal,"Debe de colocar monto de  Documento Obligatorio");
                        radialMenu1.HidePopup();
                        return retorno;

                    }
                    else if(Negocio.ClasesCN.CuentasCobrarCN.Existe_numero_documento(Convert.ToInt32(txt_numero_doc.Text),Convert.ToInt32(search_tipo_documento.EditValue??0)) && id_documento==0)
                    {
                        dxErrorProvider1.SetError(txt_numero_doc,"Ya Existe este numero de documento");
                        radialMenu1.HidePopup();
                        return retorno;
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    if(date_Fecha_doc.EditValue==null)
                    {
                        dxErrorProvider1.SetError(date_Fecha_doc,"Fecha del  documento Obligatorio");
                        radialMenu1.HidePopup();
                        return retorno;
                    }
                    else if(Convert.ToInt32(search_cobrador.EditValue)==-1 || search_cobrador.EditValue==null)
                    {

                        dxErrorProvider1.SetError(search_cobrador,"Debe de Seleccionar cobrador");
                        radialMenu1.HidePopup();
                        return retorno;
                    }
                    else if(Convert.ToString(txt_numero_doc.EditValue)==String.Empty || txt_numero_doc.EditValue==null || Convert.ToString(txt_numero_doc.EditValue)=="0")
                    {

                        dxErrorProvider1.SetError(txt_numero_doc,"Numero de  Documento Obligatorio");
                        radialMenu1.HidePopup();
                        return retorno;

                    }
                    else if(txt_concepto.Text.Trim()==string.Empty || txt_concepto.EditValue==null)
                    {
                        dxErrorProvider1.SetError(txt_concepto,"Concepto de  Documento Obligatorio");
                        radialMenu1.HidePopup();
                        return retorno;

                    }
                    else if(Convert.ToInt32(txt_subtotal.EditValue)<=0 || txt_subtotal.EditValue==null)

                    {
                        dxErrorProvider1.SetError(txt_subtotal,"Debe de colocar monto de  Documento Obligatorio");
                        radialMenu1.HidePopup();
                        return retorno;
                    }
                    else if(Convert.ToInt32(txt_monto_total.EditValue)<=0 || txt_monto_total.EditValue==null)

                    {
                        dxErrorProvider1.SetError(txt_monto_total,"Total no puede ser negativo ni 0");
                        radialMenu1.HidePopup();
                        return retorno;
                    }
                    else if(Negocio.ClasesCN.CuentasCobrarCN.Existe_numero_documento(Convert.ToInt32(txt_numero_doc.Text),Convert.ToInt32(search_tipo_documento.EditValue??0)) && id_documento==0)
                    {
                        dxErrorProvider1.SetError(txt_numero_doc,"Ya Existe este numero de documento");
                        radialMenu1.HidePopup();
                        return retorno;
                    }
                    else { return true; }
                }
            }
        }
        public  void Mostrar_soporte(int tipo_documento,int id_documento_cobrar,bool termico)
        {
            BindingSource Origen_Datos = new BindingSource();
            Origen_Datos.Clear();
            try
            {
                DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(typeof(Formularios.Principal.WaitForm1));
                switch(tipo_documento)
                {
                    case 1:
                        break;
                    case 2:
                        if(!termico)
                        {
                            Origen_Datos.DataSource=Negocio.ClasesCN.CuentasCobrarCN.Documentos_Fila_Select(id_documento_cobrar).ToList();
                            var Reporte=new Reportes.CuentasCobrar.xrpt_nota_debito_credito(Origen_Datos);
                            Reporte.Cantidad_Letras.Value=Clases.numeros_a_letras.ToCardinal(Convert.ToDecimal(txt_monto_total.EditValue??0)==0 ? Convert.ToDecimal(gview_doc_cliente.GetRowCellValue(gview_doc_cliente.FocusedRowHandle,col_monto_documento_cliente)) : Convert.ToDecimal(txt_monto_total.EditValue??0));
                            Reporte.Parameters[1].Visible=false;
                            Reporte.Parameters[0].Visible=false;
                            Reporte.id_documento.Value=id_documento_cobrar;
                            Reporte.tipo_nota.Value="CREDITO";
                            Reporte.Parameters[2].Visible=false;
                            Reporte.Saldo.Value=Convert.ToDecimal(txt_saldo_vencido.EditValue??0)+Convert.ToDecimal(txt_pendientes.EditValue??0);
                            Reporte.ShowPreview();
                        }
                        else
                        {
                            Origen_Datos.DataSource=Negocio.ClasesCN.CuentasCobrarCN.Documentos_Fila_Select(id_documento_cobrar).ToList();
                            var Reporte=new Reportes.CuentasCobrar.xrpt_notas_debito_credito_termico (Origen_Datos);
                            Reporte.Cantidad_Letras.Value=Clases.numeros_a_letras.ToCardinal(Convert.ToDecimal(txt_monto_total.EditValue??0)==0 ? Convert.ToDecimal(gview_doc_cliente.GetRowCellValue(gview_doc_cliente.FocusedRowHandle,col_monto_documento_cliente)) : Convert.ToDecimal(txt_monto_total.EditValue??0));
                            Reporte.Parameters[1].Visible=false;
                            Reporte.Parameters[0].Visible=false;
                            Reporte.id_documento.Value=id_documento_cobrar;
                            Reporte.tipo_nota.Value="CREDITO";
                            Reporte.Parameters[2].Visible=false;
                            Reporte.Saldo.Value=Convert.ToDecimal(txt_saldo_vencido.EditValue??0)+Convert.ToDecimal(txt_pendientes.EditValue??0);
                            Reporte.ShowPreview();
                        }
                        break;
                    case 3:
                        if(!termico)
                        {
                            Origen_Datos.DataSource=Negocio.ClasesCN.CuentasCobrarCN.Documentos_Fila_Select(id_documento_cobrar).ToList();
                            var Reporte=new Reportes.CuentasCobrar.xrpt_nota_debito_credito(Origen_Datos);
                            Reporte.Cantidad_Letras.Value=Clases.numeros_a_letras.ToCardinal(Convert.ToDecimal(txt_monto_total.EditValue??0)==0 ? Convert.ToDecimal(gview_doc_cliente.GetRowCellValue(gview_doc_cliente.FocusedRowHandle,col_monto_documento_cliente)) : Convert.ToDecimal(txt_monto_total.EditValue??0));
                            Reporte.Parameters[1].Visible=false;
                            Reporte.Parameters[0].Visible=false;
                            Reporte.id_documento.Value=id_documento_cobrar;
                            Reporte.tipo_nota.Value="DEBITO";
                            Reporte.Parameters[2].Visible=false;
                            Reporte.Saldo.Value=Convert.ToDecimal(txt_saldo_vencido.EditValue??0)+Convert.ToDecimal(txt_pendientes.EditValue??0);
                            Reporte.ShowPreview();
                        }
                        else
                        {
                            Origen_Datos.DataSource=Negocio.ClasesCN.CuentasCobrarCN.Documentos_Fila_Select(id_documento_cobrar).ToList();
                            var Reporte=new Reportes.CuentasCobrar.xrpt_notas_debito_credito_termico(Origen_Datos);
                            Reporte.Cantidad_Letras.Value=Clases.numeros_a_letras.ToCardinal(Convert.ToDecimal(txt_monto_total.EditValue??0)==0 ? Convert.ToDecimal(gview_doc_cliente.GetRowCellValue(gview_doc_cliente.FocusedRowHandle,col_monto_documento_cliente)) : Convert.ToDecimal(txt_monto_total.EditValue??0));
                            Reporte.Parameters[1].Visible=false;
                            Reporte.Parameters[0].Visible=false;
                            Reporte.id_documento.Value=id_documento_cobrar;
                            Reporte.tipo_nota.Value="DEBITO";
                            Reporte.Parameters[2].Visible=false;
                            Reporte.Saldo.Value=Convert.ToDecimal(txt_saldo_vencido.EditValue??0)+Convert.ToDecimal(txt_pendientes.EditValue??0);
                            Reporte.ShowPreview();
                        }
                        break;
                    case 4:
                    case 5:
                        if(termico)
                        {
                            Origen_Datos.DataSource=Negocio.ClasesCN.CuentasCobrarCN.Documentos_Fila_Select(id_documento_cobrar).ToList();
                            var Reporte=new Reportes.CuentasCobrar.xrpt_recibo_termico(Origen_Datos);
                            Reporte.Parameters[1].Value=Clases.numeros_a_letras.ToCardinal(Convert.ToDecimal(txt_monto_total.EditValue??0)==0 ? Convert.ToDecimal(gview_doc_cliente.GetRowCellValue(gview_doc_cliente.FocusedRowHandle,col_monto_documento_cliente)) : Convert.ToDecimal(txt_monto_total.EditValue??0));
                            Reporte.Parameters[1].Visible=false;
                            Reporte.Parameters[0].Visible=false;
                            Reporte.Parameters[0].Value=id_documento_cobrar;
                            Reporte.Saldo.Value=Convert.ToDecimal(txt_saldo_vencido.EditValue??0)+Convert.ToDecimal(txt_pendientes.EditValue??0);
                            Reporte.ShowPreview();
                        }
                        else
                        {
                            Origen_Datos.DataSource=Negocio.ClasesCN.CuentasCobrarCN.Documentos_Fila_Select(id_documento_cobrar).ToList();
                            var Reporte=new Reportes.CuentasCobrar.xfrm_recibo_abono(Origen_Datos);
                            Reporte.Parameters[1].Value=Clases.numeros_a_letras.ToCardinal(Convert.ToDecimal(txt_monto_total.EditValue??0)==0 ? Convert.ToDecimal(gview_doc_cliente.GetRowCellValue(gview_doc_cliente.FocusedRowHandle,col_monto_documento_cliente)) : Convert.ToDecimal(txt_monto_total.EditValue??0));
                            Reporte.Parameters[1].Visible=false;
                            Reporte.Parameters[0].Visible=false;
                            Reporte.Parameters[0].Value=id_documento_cobrar;
                            Reporte.Saldo.Value=Convert.ToDecimal(txt_saldo_vencido.EditValue??0)+Convert.ToDecimal(txt_pendientes.EditValue??0);
                            Reporte.ShowPreview();
                        }
                        break;
                    case 6:
                        break;
                    default:
                        break;
                }
                DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm();
            }
            catch(Exception)
            {
                DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm();
                throw;
            }
        }
        private void btn_guardar_ItemClick(object sender,DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if(Documento_Valido())
                {
                    if((int) btn_guardar.Tag==1)
                    {
                        if(XtraMessageBox.Show($"¿Esta seguro de agregar el documento {search_tipo_documento.Text.Trim()} a {search_clientes.Text.Trim()} por valor de {txt_monto_total.Text} con fecha {date_Fecha_doc.DateTime.Date.ToShortDateString()}?","Mensaje del Sistema",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
                        {
                            var R=Negocio.ClasesCN.CuentasCobrarCN.DocumentosCuentasCobrar_Insert(Convert.ToInt32(search_tipo_documento.EditValue??0),Convert.ToInt32(search_clientes.EditValue??0),Convert.ToInt32(txt_numero_doc.EditValue??0),Convert.ToDateTime(date_Fecha_doc.DateTime.Date),Convert.ToDecimal(txt_monto_total.EditValue??0),Convert.ToDecimal(txt_subtotal.EditValue??0),Convert.ToDecimal(txt_descuento.EditValue??0),Convert.ToDecimal(txt_impuesto.EditValue??0),Clases.UsuarioLogueado.vID_Empleado,txt_concepto.Text.Trim(),Convert.ToInt32(search_cobrador.EditValue??0),Convert.ToDecimal(txt_retenciones.EditValue??0),haycontabillidad,Convert.ToInt32(look_terminos.EditValue??0),3,0);
                            if(R>0)
                            {
                                if(Convert.ToInt32(search_tipo_documento.EditValue)==2 || Convert.ToInt32(search_tipo_documento.EditValue)==4 || Convert.ToInt32(search_tipo_documento.EditValue)==5)
                                {


                                    if(XtraMessageBox.Show($"Se ha agregado el documento a {search_clientes.Text} de manera Exitosa{Environment.NewLine}¿Desea aplicarlo ahora?","Mensaje del sistema",MessageBoxButtons.YesNo,MessageBoxIcon.Information)==DialogResult.Yes)
                                    {
                                        xfrm_aplicacion_documentos Aplicar= new xfrm_aplicacion_documentos(Convert.ToInt32(search_clientes.EditValue),Convert.ToInt32(R));
                                        Aplicar.ShowDialog();
                                        if(XtraMessageBox.Show($"¿Desea imprimir el soporte?","Mensaje del sistema",MessageBoxButtons.YesNo,MessageBoxIcon.Information)==DialogResult.Yes)
                                        {
                                            //#! Para imprimir soporte Termico el tercer parametro debe de ser True
                                            Mostrar_soporte(Convert.ToInt32(search_tipo_documento.EditValue),R,true);
                                            //Mostrar_soporte(Convert.ToInt32(search_tipo_documento.EditValue), R, false);
                                        }
                                        Cancelar();
                                    }
                                }
                                else
                                {
                                    MyMessageBox.Show($"Se ha Agregado  el documento a {search_clientes.Text} de manera Exitosa","Mensaje del sistema",MessageBoxButtons.OK,MessageBoxIcon.Information);
                                    Cancelar();
                                }

                                Cargar_Listados();
                                date_Fecha_doc.EditValue=DateTime.Now.Date;
                                search_clientes.Focus();
                                Cancelar();
                                search_clientes_EditValueChanged(null,null);

                            }
                        }
                    }
                    else if((int) btn_guardar.Tag==2)
                    {

                        if(MyMessageBox.Show($"¿Esta seguro de Modificar el documento {search_tipo_documento.Text.Trim()} a {search_clientes.Text.Trim()} por valor de {txt_monto_total.Text} con fecha {date_Fecha_doc.DateTime.Date.ToShortDateString()}?","Mensaje del Sistema",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
                        {
                            var R=Negocio.ClasesCN.CuentasCobrarCN.DocumentosCuentasCobrar_Update(Convert.ToInt32(search_tipo_documento.EditValue??0),Convert.ToInt32(search_clientes.EditValue??0),Convert.ToInt32(txt_numero_doc.EditValue??0),Convert.ToDateTime(date_Fecha_doc.DateTime.Date),Convert.ToDecimal(txt_monto_total.EditValue??0),Convert.ToDecimal(txt_subtotal.EditValue??0),Convert.ToDecimal(txt_descuento.EditValue??0),Convert.ToDecimal(txt_impuesto.EditValue??0),Clases.UsuarioLogueado.vID_Empleado,txt_concepto.Text.Trim(),Convert.ToInt32(search_cobrador.EditValue??0),Convert.ToDecimal(txt_retenciones.EditValue??0),haycontabillidad,Convert.ToInt32(look_terminos.EditValue??0),3,id_documento);
                            if(R>0)
                            {
                                MyMessageBox.Show($"Se ha modificado correctamente el documento a {search_clientes.Text} de manera Exitosa","Mensaje del sistema",MessageBoxButtons.OK,MessageBoxIcon.Information);
                                Cargar_Listados();
                                Cancelar();

                                date_Fecha_doc.EditValue=DateTime.Now.Date;
                                search_clientes.Focus();
                                Cancelar();
                                id_documento=0;
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show($"Lo sentimos ha ocurrido el siguiente error.{Environment.NewLine}Error:{ex.Message}.","Mensaje del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void btn_modificar_documento_ItemClick(object sender,DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                radialMenu1.HidePopup();
                id_documento= Convert.ToInt32(gview_doc_cliente.GetRowCellValue(gview_doc_cliente.FocusedRowHandle,col_id_documento_cliente));
                var Doc= Negocio.ClasesCN.CuentasCobrarCN.DocumentosCuentasCobrar_Select(id_documento);
                search_tipo_documento.EditValue=Doc.tipo_documento;
                date_Fecha_doc.DateTime=Doc.fecha_doc.Value.Date;
                search_cobrador.EditValue=Doc.id_cobrador;
                look_terminos.EditValue=Doc.id_termino;
                txt_numero_doc.EditValue=Doc.numero_doc;
                txt_concepto.EditValue=Doc.concepto.ToUpper();
                txt_subtotal.EditValue=Doc.subtotal_doc;
                txt_descuento.EditValue=Doc.monto_descuento_doc;
                txt_impuesto.EditValue=Doc.monto_impuesto_doc;
                txt_retenciones.EditValue=Doc.retenciones;
                search_tipo_documento.Enabled=true;
                btn_cancelar_documentos.Enabled=true;
                btn_guardar.Enabled=true;
                btn_guardar.Tag=2;
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show($"Lo sentimos ha ocurrido el siguiente error.{Environment.NewLine}Error:{ex.Message}.","Mensaje del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void btn_anular_documentos_ItemClick(object sender,DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {

                id_documento= Convert.ToInt32(gview_doc_cliente.GetRowCellValue(gview_doc_cliente.FocusedRowHandle,col_id_documento_cliente));

                DialogResult Pregunta= XtraMessageBox.Show($"¿Esta seguro de Anular el documento a {search_clientes.Text.Trim()}?","Mensaje del Sistema",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if(Pregunta==DialogResult.Yes)
                {
                    int Resultado= Negocio.ClasesCN.CuentasCobrarCN.DocumentosCuentasCobrar_Eliminar(id_documento,Clases.UsuarioLogueado.vID_Empleado,3);
                    if(Resultado>0)
                    {
                        XtraMessageBox.Show($"Se ha Anulado correctamente el documento a {search_clientes.Text} de manera Exitosa","Mensaje del sistema",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        Cargar_Listados();
                        date_Fecha_doc.EditValue=DateTime.Now.Date;
                        search_clientes.Focus();
                        search_clientes_EditValueChanged(null,null);
                        id_documento=0;
                    }
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show($"Lo sentimos ha ocurrido el siguiente error.{Environment.NewLine}Error:{ex.Message}.","Mensaje del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void xfrm_Agrega_Documento_Activated(object sender,EventArgs e)
        {
            Cargar_Listados();
            search_clientes_EditValueChanged(null,null);
        }
        private void search_clientes_Properties_ButtonClick(object sender,DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if(e.Button.Tag.ToString() == "2")
            {
                int count = Negocio.ClasesCN.CatalogosCN.getCliente().Count;
                var form = new xfrm_NuevoCliente();
                form.ShowDialog();
                int count_nuevo = Negocio.ClasesCN.CatalogosCN.getCliente().Count;
                search_clientes.Properties.DataSource=Negocio.ClasesCN.CatalogosCN.Cliente_Cargar();
                if(count != count_nuevo)
                {
                    int max = Negocio.ClasesCN.CatalogosCN.getCliente().Max(x => x.id);
                    search_clientes.EditValue = max;
                }

            }
        }
        private void search_cobrador_Properties_ButtonClick(object sender,DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if(e.Button.Tag.ToString() == "2")
            {
                int count = Negocio.ClasesCN.CatalogosCN.Empleado_Cargar().Count;
                var form = new xtraform_NuevoCobrador();
                form.ShowDialog();
                int count_nuevo =Negocio.ClasesCN.CatalogosCN.Empleado_Cargar().Count;
                search_cobrador.Properties.DataSource=Negocio.ClasesCN.CatalogosCN.Empleado_Cargar();
                if(count != count_nuevo)
                {
                    int max = Negocio.ClasesCN.CatalogosCN.Empleado_Cargar().Max(x => x.id);
                    search_cobrador.EditValue = max;
                }

            }
        }
        private void look_terminos_Properties_ButtonClick(object sender,DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if(e.Button.Tag.ToString() == "2")
            {
                int count = Negocio.ClasesCN.ParametrosCN.Terminos_Select() .Count;
                var form = new xftm_nuevo_termino();
                form.ShowDialog();
                int count_nuevo = Negocio.ClasesCN.ParametrosCN.Terminos_Select() .Count;
                look_terminos.Properties.DataSource= Negocio.ClasesCN.ParametrosCN.Terminos_Select();
                if(count != count_nuevo)
                {
                    int max = Negocio.ClasesCN.ParametrosCN.Terminos_Select().Max(x => x.id);
                    look_terminos.EditValue = max;
                }
            }
        }
        private void txt_porcentaje_descuento_EditValueChanged(object sender,EventArgs e)
        {
            if(Convert.ToDecimal(txt_porcentaje_descuento.EditValue)>=0.00m || Convert.ToDecimal(txt_porcentaje_descuento.EditValue)<=100.00m)
            {
                txt_descuento.EditValue=Math.Round(Convert.ToDecimal(txt_subtotal.EditValue??0)*(Convert.ToDecimal(txt_porcentaje_descuento.EditValue??0)/100),2,MidpointRounding.AwayFromZero);
            }

        }
        private void txt_porcentaje_impuesto_EditValueChanged(object sender,EventArgs e)
        {
            if(Convert.ToDecimal(txt_porcentaje_impuesto.EditValue)>=0.00m &&  Convert.ToDecimal(txt_porcentaje_impuesto.EditValue)<=100.00m)
            {

                txt_impuesto.EditValue=Math.Round((Convert.ToDecimal(txt_subtotal.EditValue??0)-Convert.ToDecimal(txt_descuento.EditValue??0))*(Convert.ToDecimal(txt_porcentaje_impuesto.EditValue??0)/100),2,MidpointRounding.AwayFromZero);
            }
        }
        private void txt_retencion_porcentaje_EditValueChanged(object sender,EventArgs e)
        {
            if(Convert.ToDecimal(txt_retencion_porcentaje.EditValue)>=0.00m &&  Convert.ToDecimal(txt_retencion_porcentaje.EditValue)<=100.00m)
            {

                txt_retenciones.EditValue=Math.Round((Convert.ToDecimal(txt_subtotal.EditValue??0)-Convert.ToDecimal(txt_descuento.EditValue??0))*(Convert.ToDecimal(txt_retencion_porcentaje.EditValue??0)/100),2,MidpointRounding.AwayFromZero);
            }
        }
        private void bbi_media_carta_ItemClick(object sender,DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                Mostrar_soporte((int)gview_doc_cliente.GetFocusedRowCellValue(col_numero_documento_cliente),(int) gview_doc_cliente.GetFocusedRowCellValue(col_id_documento_cliente),false);
            }
            catch(Exception ex)
            {

                throw;
            }
        }
       private void bbi_terminco_ItemClick(object sender,DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                Mostrar_soporte((int) gview_doc_cliente.GetFocusedRowCellValue(col_numero_documento_cliente),(int) gview_doc_cliente.GetFocusedRowCellValue(col_id_documento_cliente),true);
            }
            catch(Exception ex)
            {
               throw;
            }
        }
        private void bbi_aplicar_ItemClick(object sender,DevExpress.XtraBars.ItemClickEventArgs e)
        {

            xfrm_aplicacion_documentos Aplicar= new xfrm_aplicacion_documentos(Convert.ToInt32(search_clientes.EditValue),Convert.ToInt32(gview_doc_cliente.GetFocusedRowCellValue(col_id_documento_cliente)));
            Aplicar.ShowDialog();
            search_clientes_EditValueChanged(null,null);
        }
        private void xfrm_Agrega_Documento_Deactivate(object sender,EventArgs e)
        {
        }
        private void barButtonItem1_ItemClick(object sender,DevExpress.XtraBars.ItemClickEventArgs e)
        {
            brs_imprimir.Visibility=DevExpress.XtraBars.BarItemVisibility.Never;
            bbi_aplicar.Visibility=DevExpress.XtraBars.BarItemVisibility.Never;
            radialMenu1.ShowPopup(Control.MousePosition);
        }
        private void gview_doc_cliente_RowStyle(object sender,RowStyleEventArgs e)
        {
            try
            {
                GridView View = sender as GridView;
                if(e.RowHandle >= 0)
                {
                    int estatus = Convert.ToInt32(View.GetRowCellValue(e.RowHandle, View.Columns["estatus_documento"])) ;
                    if(estatus ==1)
                    {
                        e.Appearance.BackColor = Color.Pink;
                        e.Appearance.Font = new Font("Tahoma",9.75F,FontStyle.Regular,GraphicsUnit.Point,((byte) (0)));
                    }
                }

            }
            catch(Exception ex)
            {
                XtraMessageBox.Show($"Lo sentimos ha ocurrido el siguiente error.{Environment.NewLine}Error:{ex.Message}.","Mensaje del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void gview_doc_cliente_CustomSummaryCalculate(object sender,DevExpress.Data.CustomSummaryEventArgs e)
        {
            GridView view = sender as GridView;
            int idsumatoria= Convert.ToInt32((e.Item as GridSummaryItem).Tag);

            if(e.SummaryProcess==DevExpress.Data.CustomSummaryProcess.Start)
            {
                saldo_vencido=0.00m;
                pendiente=0.00m;
                aplicados=0.00m;
                no_aplicados=0.00m;
            }

            if(e.SummaryProcess==DevExpress.Data.CustomSummaryProcess.Calculate)
            {
                bool sumarvencido=Convert.ToInt32(view.GetRowCellValue(e.RowHandle,col_estatus_documentoo_numeros))==1;
                bool sumarpendiente=Convert.ToInt32(view.GetRowCellValue(e.RowHandle,col_estatus_documentoo_numeros))==3;
                bool sumaraplicados=Convert.ToInt32(view.GetRowCellValue(e.RowHandle,col_estatus_documentoo_numeros))==4;
                bool sumarnoaplicados=Convert.ToInt32(view.GetRowCellValue(e.RowHandle,col_estatus_documentoo_numeros))==5;
                switch(idsumatoria)
                {
                    case 1:
                        if(sumarvencido)
                        {
                            saldo_vencido+=(decimal) e.FieldValue;
                        }
                        break;
                    case 2:
                        if(sumarpendiente)
                        {
                            pendiente+=(decimal) e.FieldValue;
                        }
                        break;
                    case 3:
                        if(sumaraplicados)
                        {
                            aplicados+=(decimal) e.FieldValue;
                        }
                        break;
                    case 4:
                        if(sumarnoaplicados)
                        {
                            no_aplicados+=(decimal) e.FieldValue;
                        }
                        break;

                    default:
                        break;
                }
            }

            if(e.SummaryProcess==DevExpress.Data.CustomSummaryProcess.Finalize)
            {
                switch(idsumatoria)
                {
                    case 1:
                        e.TotalValue=saldo_vencido;
                        txt_saldo_vencido.Text=e.TotalValue.ToString();
                        break;
                    case 2:
                        e.TotalValue=pendiente;
                        txt_pendientes.Text=e.TotalValue.ToString();
                        break;
                    case 3:
                        e.TotalValue=aplicados;
                        txt_aplicados.Text=e.TotalValue.ToString();
                        break;
                    case 4:
                        e.TotalValue=no_aplicados;
                        txt_sin_aplicar.Text=e.TotalValue.ToString();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}