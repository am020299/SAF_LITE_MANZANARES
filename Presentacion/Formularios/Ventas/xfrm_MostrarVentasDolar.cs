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
using DevExpress.Utils;
using DevExpress.XtraReports.UI;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting.Drawing;
using DevExpress.XtraPrinting;

namespace Presentacion.Formularios.Ventas
{
    public partial class xfrm_MostrarVentasDolar : DevExpress.XtraEditors.XtraForm
    {
        private int _vTipoVenta;
        public xfrm_MostrarVentasDolar(int xTipoVenta)
        {
            vTipoVenta = xTipoVenta;
            InitializeComponent();
         
        }
        public int vTipoVenta { get => _vTipoVenta; set => _vTipoVenta = value; }        
  

        private void xfrm_MostrarVentas_Load(object sender, EventArgs e)
        {
            viewVentas.OptionsView.ShowFooter= false;
            bool cargar_total_venta = Negocio.ClasesCN.RolesPermisosCN.Permisos(Clases.UsuarioLogueado.vID_Empleado, 11113);
            if (cargar_total_venta || Clases.UsuarioLogueado.admin)
                viewVentas.OptionsView.ShowFooter = true;

            repositoryItemLookUpEdit_Producto.DataSource = Negocio.ClasesCN.CatalogosCN.Producto_Cargar();
            repositoryItemLookUpEdit_Bodega.DataSource = Negocio.ClasesCN.CatalogosCN.Bodega_Cargar();
            repositoryItemLookUpEdit_UnidadMedida.DataSource = Negocio.ClasesCN.CatalogosCN.UnidadMedida_Cargar();
            if (vTipoVenta == 0)
            {
                bindingSourceCompras.DataSource = Negocio.ClasesCN.VentasCN.Ventas_Select(vTipoVenta).Where(o => o.activo == true && o.estado == 1 && o.moneda == 2);
                viewVentas.Columns[1].Caption = "N° COTIZACION";
                viewVentas.Columns[8].Visible = false;
                toggleSwitch1.Visible = true;
            }   
            else
            {
                bindingSourceCompras.DataSource = Negocio.ClasesCN.VentasCN.Ventas_Select(vTipoVenta).Where(o => o.moneda == 2);
                toggleSwitch1.Visible = false;
            }
                
        }
        private void xfrm_MostrarVentas_Activated(object sender, EventArgs e)
        {
            xfrm_MostrarVentas_Load(null, null);
        }

        private void viewVentas_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                //dockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Visible;
                dockPanel1.Text = "Detalle de Factura [Nº" + viewVentas.GetFocusedRowCellDisplayText("numero") + "]";
                gridVentaDetalle.DataSource = Negocio.ClasesCN.VentasCN.VentasDetalle_Select(Convert.ToInt32(viewVentas.GetFocusedRowCellValue("id")));
                bindingSourceReport.DataSource= Negocio.ClasesCN.VentasCN.Venta_Reporte(Convert.ToInt32(viewVentas.GetFocusedRowCellValue("id")));
            }
            catch (Exception)
            {

            }
        }

        private void viewVentas_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                return;

            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hitInfo = viewVentas.CalcHitInfo(e.Location);
            if (hitInfo.InDataRow)
            {
                if (vTipoVenta == 1)
                {
                    //viewCompras.FocusedRowHandle = hitInfo.RowHandle;
                    int moneda = Convert.ToInt32(viewDetalle.GetFocusedRowCellValue("moneda"));
                    if(moneda == 2)
                    {
                        bbiImprimirCordoba.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    }
                    else
                    {
                        bbiImprimirCordoba.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    }
                    radialMenu1.ShowPopup(Control.MousePosition);
                }
                else
                {
                    radialMenu2.ShowPopup(Control.MousePosition);
                }
            }
        }
        public IVentas iVentas { get; set; }

        void Opciones(int i)
        {
            radialMenu1.HidePopup();
            radialMenu2.HidePopup();
            switch (i)
            {
                case 1: //Ver Factura
                    try
                    {
                        var form = new xfrm_NuevaVenta(vTipoVenta);
                        form.Text = "VER FACTURA";
                        form.viewDetalle.OptionsBehavior.Editable = false;
                        form.btnGuardar.Enabled = false;
                        form.btnGuardar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        form.btnGuardar.Enabled = false;
                        form.btnGuardarImprimir.Enabled = false;
                        form.bindingSourceProducto.DataSource = Negocio.ClasesCN.InventarioCN.Kardex_SelectVentaEXC();
                        form.MdiParent = this.MdiParent;
                        iVentas = form;
                        bool resultOK = iVentas.getVenta(Negocio.ClasesCN.VentasCN.getVentas().Where(x => x.id == Convert.ToInt32(viewVentas.GetFocusedRowCellValue("id"))).ToList());
                        iVentas.getDetalleVenta(Negocio.ClasesCN.VentasCN.getVentasDetalle(Convert.ToInt32(viewVentas.GetFocusedRowCellValue("id"))));
                        if (!resultOK) return;
                        form.Show();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    break;

                case 2: //Editar Factura
                    try
                    {
                        var form = new xfrm_NuevaVenta(vTipoVenta);
                        form.Text = "EDITAR FACTURA";
                        //form.viewDetalle.OptionsBehavior.Editable = false;
                        //form.btnGuardar.Enabled = false;
                        //form.btnGuardarImprimir.Enabled = false;
                        form.bindingSourceProducto.DataSource = Negocio.ClasesCN.InventarioCN.Kardex_SelectVentaEXC();
                        form.MdiParent = this.MdiParent;
                        iVentas = form;
                        bool resultOK = iVentas.getVenta(Negocio.ClasesCN.VentasCN.getVentas().Where(x => x.id == Convert.ToInt32(viewVentas.GetFocusedRowCellValue("id"))).ToList());
                        iVentas.getDetalleVenta(Negocio.ClasesCN.VentasCN.getVentasDetalle(Convert.ToInt32(viewVentas.GetFocusedRowCellValue("id"))));
                        if (!resultOK) return;
                        form.Show();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    break;

                case 3: //Duplicar Factura
                    try
                    {
                        int idCotizacion = Convert.ToInt32(viewVentas.GetFocusedRowCellValue("id"));
                        var form = new xfrm_duplicar_facturas(1, idCotizacion, false);
                        form.MdiParent = this.MdiParent;
                        form.Show();
                        //var form = new xfrm_NuevaVenta(vTipoVenta);
                        //form.Text = "DUPLICAR FACTURA";
                        ////form.viewDetalle.OptionsBehavior.Editable = false;
                        ////form.btnGuardar.Enabled = false;
                        ////form.btnGuardarImprimir.Enabled = false;
                        //form.bindingSourceProducto.DataSource = Negocio.ClasesCN.InventarioCN.Kardex_SelectVentaEXC();
                        //form.MdiParent = this.MdiParent;
                        //iVentas = form;
                        //bool resultOK = iVentas.getVenta(Negocio.ClasesCN.VentasCN.getVentas().Where(x => x.id == Convert.ToInt32(viewVentas.GetFocusedRowCellValue("id"))).ToList());
                        //iVentas.getDetalleVenta(Negocio.ClasesCN.VentasCN.getVentasDetalle(Convert.ToInt32(viewVentas.GetFocusedRowCellValue("id"))));
                        //form.txtNumeroFactura.Text = string.Empty;
                        //if (!resultOK) return;
                        //form.Show();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    break;

                case 4: //Convertir en Factura
                    try
                    {
                        //ESTO TENGO QUE REVISARLO
                        int idCotizacion = Convert.ToInt32(viewVentas.GetFocusedRowCellValue("id"));
                        var form = new xfrm_convertir_cotizacion_factura(1, idCotizacion,false);
                        form.MdiParent = this.MdiParent;
                        form.Show();
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("Error: " + ex.GetBaseException().Message, "Error al convertir cotización en factura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;

                case 5: //Ver Cotización
                    try
                    {
                        var form = new xfrm_NuevaVenta(vTipoVenta);
                        form.Text = "VER COTIZACIÓN";
                        form.viewDetalle.OptionsBehavior.Editable = false;
                        form.btnGuardar.Enabled = false;
                        form.btnGuardarImprimir.Enabled = false;
                        //form.txtDescuentoPorcentaje.Enabled = false;
                        //form.txtDescuentoMonto.Enabled = false;
                        form.bindingSourceProducto.DataSource = Negocio.ClasesCN.InventarioCN.Kardex_SelectVentaEXC();
                        form.MdiParent = this.MdiParent;
                        iVentas = form;
                        bool resultOK = iVentas.getVenta(Negocio.ClasesCN.VentasCN.getVentas().Where(x => x.id == Convert.ToInt32(viewVentas.GetFocusedRowCellValue("id"))).ToList());
                        iVentas.getDetalleVenta(Negocio.ClasesCN.VentasCN.getVentasDetalle(Convert.ToInt32(viewVentas.GetFocusedRowCellValue("id"))));
                        if (!resultOK) return;
                        form.Show();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    break;

                case 6: //Editar Cotización
                    try
                    {
                       
                        int idCotizacion = Convert.ToInt32(viewVentas.GetFocusedRowCellValue("id"));
                        var form = new xfrm_convertir_cotizacion_factura(0, idCotizacion,true);
                        form.Text = "EDITAR COTIZACIÓN";
                        form.MdiParent = this.MdiParent;
                        form.Show();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    break;

                case 7: //Duplicar Cotización
                    try
                    {
                        var form = new xfrm_NuevaVenta(vTipoVenta);
                        form.Text = "DUPLICAR COTIZACIÓN";
                        //form.viewDetalle.OptionsBehavior.Editable = false;
                        //form.btnGuardar.Enabled = false;
                        //form.btnGuardarImprimir.Enabled = false;
                        form.bindingSourceProducto.DataSource = Negocio.ClasesCN.InventarioCN.Kardex_SelectVenta();
                        form.MdiParent = this.MdiParent;
                        iVentas = form;
                        bool resultOK = iVentas.getVenta(Negocio.ClasesCN.VentasCN.getVentas().Where(x => x.id == Convert.ToInt32(viewVentas.GetFocusedRowCellValue("id"))).ToList());
                        iVentas.getDetalleVenta(Negocio.ClasesCN.VentasCN.getVentasDetalle(Convert.ToInt32(viewVentas.GetFocusedRowCellValue("id"))));
                        form.txtNumeroFactura.Text = string.Empty;
                        if (!resultOK) return;
                        form.Show();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    break;
            }
        }

        private void bbiVerOrden_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Opciones(1);
        }

        private void bbiEditarFactura_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Opciones(2);
        }

        private void bbiDuplicarFactura_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Opciones(3);
        }

        private void bbiEliminarFactura_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            radialMenu1.HidePopup();
            int vEmpleado = Clases.UsuarioLogueado.vID_Empleado;
            bool tiene_permiso = Presentacion.Clases.UsuarioLogueado.PermisoEspecial(vEmpleado, 134);

            if (Clases.UsuarioLogueado.saberAdminM())
            {
                labelControl1.Text = "¿Eliminar la Factura [Nº " + viewVentas.GetFocusedRowCellDisplayText("numero") + "]?";
                flyoutPanel1.ShowBeakForm();
            }
            else
            {
                var Permisos = Negocio.ClasesCN.RolesPermisosCN.Cargar_Permisos(0).Where(p => p.id_rol == 134).FirstOrDefault();
                Presentacion.Formularios.Catalogos.xfrm_autorizacion frm = new Catalogos.xfrm_autorizacion("ELIMINAR FACTURA [Nº " + viewVentas.GetFocusedRowCellDisplayText("numero") + "]?");
                frm.numero_permiso = Permisos.id_rol ?? 0;
                frm.permiso = Permisos.descripcion.ToUpper();
                frm.ShowDialog();
                if (frm.Autorizado)
                {
                    labelControl1.Text = "¿Eliminar la Factura [Nº " + viewVentas.GetFocusedRowCellDisplayText("numero") + "]?";
                    flyoutPanel1.ShowBeakForm();
                }
                else
                {
                    XtraMessageBox.Show($"Usted no tiene autorizacion de {frm.permiso.ToUpper()}", "Información");
                }
            }
        //labelControl1.Text = "¿Eliminar la Factura [Nº " + viewVentas.GetFocusedRowCellDisplayText("numero")+"]?";
        //flyoutPanel1.ShowBeakForm();
    }

        private void bbiEliminarCotizacion_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            radialMenu2.HidePopup();
            labelControl1.Text = "¿Eliminar la Cotización [Nº " + viewVentas.GetFocusedRowCellDisplayText("numero") + "]?";
            flyoutPanel1.ShowBeakForm();
        }

        private Point GetFocusedRowPoint()
        {
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridViewInfo info = viewVentas.GetViewInfo() as DevExpress.XtraGrid.Views.Grid.ViewInfo.GridViewInfo;
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridRowInfo GridRowInfo = info.GetGridRowInfo(viewVentas.FocusedRowHandle);
             

            if ((object.Equals(GridRowInfo, null/* TODO Change to default(_) if this is not a reference type */)))
                return new Point();
            return new Point(GridRowInfo.Bounds.X, GridRowInfo.Bounds.Y);
        }

        private void flyoutPanel1_ButtonClick(object sender, FlyoutPanelButtonClickEventArgs e)
        {
            string tag = e.Button.Tag.ToString();
            
            switch (tag)
            {
                case "aceptar":

                    string vObservacion = "";
                    var repuesta = XtraMessageBox.Show("¿Desea agregar una observación personalizada?", "Anulación de factura", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    var form = new xfrm_Agrega_Observacion();

                    (sender as FlyoutPanel).HidePopup();
                    int idDocumento = Negocio.ClasesCN.VentasCN.ExisteAbonoFactura(Convert.ToInt32(viewVentas.GetFocusedRowCellValue("id")));
                    if (idDocumento < 0)
                    {
                        if (repuesta == DialogResult.Yes)
                        {
                            form.ShowDialog();
                            if (form.vObservacion.ToString() == "")
                            {
                                vObservacion = "ANULACION DE FACTURA [Nº " + viewVentas.GetFocusedRowCellDisplayText("numero") + "]";
                            }
                            else
                            {
                                vObservacion = form.vObservacion.ToUpper() + " [Nº " + viewVentas.GetFocusedRowCellDisplayText("numero") + "]";
                            }
                        }
                        else
                        {
                            vObservacion = "ANULACION DE FACTURA [Nº " + viewVentas.GetFocusedRowCellDisplayText("numero") + "]";
                        }

                        var eliminarOK = Negocio.ClasesCN.VentasCN.Venta_Devolucion(Convert.ToInt32(viewVentas.GetFocusedRowCellValue("id")), DateTime.Now, vObservacion, Clases.UsuarioLogueado.vID_Empleado, vTipoVenta);
                        if (eliminarOK.Item1)
                        {
                            XtraMessageBox.Show("Factura "+ "[Nº " + viewVentas.GetFocusedRowCellDisplayText("numero") + "]" + " anulada correctamente!!!", "Anulación de factura", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            flyoutPanel2.ShowPopup();
                            xfrm_MostrarVentas_Activated(null, null);
                        }
                    }
                    else if (idDocumento > 0)
                    {
                        int DocumentoELIMINAR = Negocio.ClasesCN.CuentasCobrarCN.DocumentosCuentasCobrar_Eliminar(idDocumento, Clases.UsuarioLogueado.vID_Empleado, 1);
                        if (DocumentoELIMINAR > 0)
                        {
                            if (repuesta == DialogResult.Yes)
                            {
                                form.ShowDialog();
                                if (form.vObservacion.ToString() == "")
                                {
                                    vObservacion = "ANULACION DE FACTURA [Nº " + viewVentas.GetFocusedRowCellDisplayText("numero") + "]";
                                }
                                else
                                {
                                    vObservacion = form.vObservacion.ToUpper() + " [Nº " + viewVentas.GetFocusedRowCellDisplayText("numero") + "]";
                                }
                            }
                            else
                            {
                                vObservacion = "ANULACION DE FACTURA [Nº " + viewVentas.GetFocusedRowCellDisplayText("numero") + "]";
                            }

                            var eliminarOK = Negocio.ClasesCN.VentasCN.Venta_Devolucion(Convert.ToInt32(viewVentas.GetFocusedRowCellValue("id")), DateTime.Now, "", Clases.UsuarioLogueado.vID_Empleado, vTipoVenta);
                            if (eliminarOK.Item1)
                            {
                                XtraMessageBox.Show("Factura " + "[Nº " + viewVentas.GetFocusedRowCellDisplayText("numero") + "]" + " anulada correctamente!!!", "Anulación de factura", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                flyoutPanel2.ShowPopup();
                                xfrm_MostrarVentas_Activated(null, null);
                            }
                        }
                    }
                    else if (idDocumento == 0)
                    {
                        Clases.MyMessageBox.MessageFont = new Font(Clases.MyMessageBox.MessageFont.FontFamily, 18);
                        Clases.MyMessageBox.Show("Lo sentimos, la orden de venta [Nº " + viewVentas.GetFocusedRowCellDisplayText("numero") + "] ya no se puede eliminar, porque actualmete hay documentos por aplicar", "Venta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case "cancelar":
                    (sender as FlyoutPanel).HidePopup();
                    break;
            }
        }

        private void bbiConvertirFactura_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Opciones(4);
        }

        private void bbiVerCotizacion_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bindingSourceReport.DataSource = Negocio.ClasesCN.VentasCN.Venta_Reporte(Convert.ToInt32(viewVentas.GetFocusedRowCellValue("id")));
            var report = new Reportes.Ventas.Cotizacion1(bindingSourceReport);
            report.Parameters[1].Value= 1;
            report.ShowPreviewDialog();
            report.Dispose();
        }
        private void bbi_cotizacion_cordoba_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bindingSourceReport.DataSource = Negocio.ClasesCN.VentasCN.Venta_Reporte(Convert.ToInt32(viewVentas.GetFocusedRowCellValue("id")));
            var report = new Reportes.Ventas.Cotizacion1(bindingSourceReport);
            report.Parameters[1].Value = 2;
            report.ShowPreviewDialog();
            report.Dispose();
        }
        private void bbiEditarCotizacion_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Opciones(6);
        }

        private void bbiDuplicarCotizacion_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Opciones(7);
        }

        // Create a watermark with the specified text.
        private Watermark CreateTextWatermark(string text)
        {
            Watermark textWatermark = new Watermark();

            textWatermark.Text = text;
            textWatermark.TextDirection = DirectionMode.ForwardDiagonal;
            textWatermark.Font = new Font(textWatermark.Font.FontFamily, 28, FontStyle.Bold);
            textWatermark.ForeColor = Color.Red;
            textWatermark.TextTransparency = 100;
            textWatermark.ShowBehind = false;

            return textWatermark;
        }

        private void bbiImprimir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool esCambio = Convert.ToBoolean(viewVentas.GetFocusedRowCellValue("esCambio"));
            

            if(!esCambio)
            {
                var report = new Reportes.Ventas.FacturaTermica(bindingSourceReport);
                int vEmpleado = Clases.UsuarioLogueado.vID_Empleado;
                int estado = Convert.ToInt32(viewVentas.GetFocusedRowCellValue("estado"));
                bool tiene_permiso = Presentacion.Clases.UsuarioLogueado.PermisoEspecial(vEmpleado, 138);

                if (estado == 0)
                {
                    for (int i = 0; i < report.Pages.Count; i++)
                    {
                        Page myPage = report.Pages[i];
                        myPage.AssignWatermark(CreateTextWatermark("FACTURA ANULADA"));
                    }
                }

                if (tiene_permiso)
                {
                    report.Parameters[0].Visible = true;
                    report.Parameters[1].Visible = true;
                    report.ShowPreviewDialog();
                    report.Dispose();
                }
                else
                {
                    report.Parameters[0].Visible = false;
                    report.Parameters[1].Visible = false;
                    report.ShowPreviewDialog();
                    report.Dispose();
                }
            }
            else
            {
                var report = new Reportes.Ventas.FacturaTermicaCordobasDev(bindingSourceReport);
                int vEmpleado = Clases.UsuarioLogueado.vID_Empleado;
                int estado = Convert.ToInt32(viewVentas.GetFocusedRowCellValue("estado"));
                bool tiene_permiso = Presentacion.Clases.UsuarioLogueado.PermisoEspecial(vEmpleado, 138);

                if (estado == 0)
                {
                    for (int i = 0; i < report.Pages.Count; i++)
                    {
                        Page myPage = report.Pages[i];
                        myPage.AssignWatermark(CreateTextWatermark("FACTURA ANULADA"));
                    }
                }

                if (tiene_permiso)
                {
                    //report.Parameters[0].Visible = true;
                    //report.Parameters[1].Visible = true;
                    report.ShowPreviewDialog();
                    report.Dispose();
                }
                else
                {
                    report.Parameters[0].Visible = false;
                    report.Parameters[1].Visible = false;
                    report.ShowPreviewDialog();
                    report.Dispose();
                }
            }

            
            
        }

        private void bbiImprimirFactura_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var report = new Reportes.Ventas.Factura(bindingSourceReport);
            int vEmpleado = Clases.UsuarioLogueado.vID_Empleado;
            int estado = Convert.ToInt32(viewVentas.GetFocusedRowCellValue("estado"));
            bool tiene_permiso = Presentacion.Clases.UsuarioLogueado.PermisoEspecial(vEmpleado, 138);

            if (estado == 0)
            {
                report.Watermark.Font = new System.Drawing.Font("Verdana", 60F, System.Drawing.FontStyle.Bold);
                report.Watermark.Text = "FACTURA ANULADA";
                report.Watermark.TextTransparency = 100;
            }

            if (tiene_permiso)
            {
                report.Parameters[0].Visible = true;
                report.ShowPreviewDialog();
                report.Dispose();
            }
            else
            {
                report.Parameters[0].Visible = false;
                report.ShowPreviewDialog();
                report.Dispose();
            }
        }

        private void radialMenu1_Popup(object sender, EventArgs e)
        {
            //int estado = 0;
            int estado = Convert.ToInt32(viewVentas.GetFocusedRowCellValue("estado"));
            //if (estado == 2)
            //{
            //    bbiEliminarFactura.Enabled = false;
            //}
            //else
            //{
            //    bbiEliminarFactura.Enabled = true;
            //}

            if (estado == 0 && vTipoVenta == 1)
            {
                bbiEliminarFactura.Enabled = false;
                bbiDuplicarFactura.Enabled = true;
                //bbiImprimir.Enabled = false;
                //bbiImprimirFactura.Enabled = false;
            }
            else
            {
                bbiDuplicarFactura.Enabled = false;
                bbiEliminarFactura.Enabled = true;
                bbiImprimir.Enabled = true;
                bbiImprimirFactura.Enabled = true;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Opciones(4);
        }

        private void viewVentas_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.RowHandle >= 0)
            {
                int estado_factura = Convert.ToInt32(view.GetRowCellValue(e.RowHandle, "estado"));

                if (estado_factura == 0)
                {
                    e.Appearance.BackColor = Color.LightPink;
                    e.Appearance.Font = new Font("Tahoma", 9.75F, FontStyle.Bold, GraphicsUnit.Point, (byte)(0));
                }
            }
        }

        private void toggleSwitch1_Toggled(object sender, EventArgs e)
        {
            if (toggleSwitch1.IsOn)
            {
                bindingSourceCompras.DataSource = Negocio.ClasesCN.VentasCN.Ventas_Select(vTipoVenta).Where(o => o.activo == true && o.moneda == 2);
            }
            else
            {
                bindingSourceCompras.DataSource = Negocio.ClasesCN.VentasCN.Ventas_Select(vTipoVenta).Where(o => o.activo == true && o.estado == 1 && o.moneda == 2);
            }
        }

        private void bbiImprimirCordoba_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool esCambio = Convert.ToBoolean(viewVentas.GetFocusedRowCellValue("esCambio"));


            if (!esCambio)
            {
                var report = new Reportes.Ventas.FacturaTermicaCordobas(bindingSourceReport);
                int vEmpleado = Clases.UsuarioLogueado.vID_Empleado;
                int estado = Convert.ToInt32(viewVentas.GetFocusedRowCellValue("estado"));
                bool tiene_permiso = Presentacion.Clases.UsuarioLogueado.PermisoEspecial(vEmpleado, 138);

                if (estado == 0)
                {
                    for (int i = 0; i < report.Pages.Count; i++)
                    {
                        Page myPage = report.Pages[i];
                        myPage.AssignWatermark(CreateTextWatermark("FACTURA ANULADA"));
                    }
                }

                if (tiene_permiso)
                {
                    report.Parameters[0].Visible = true;
                    report.Parameters[1].Visible = true;
                    report.ShowPreviewDialog();
                    report.Dispose();
                }
                else
                {
                    report.Parameters[0].Visible = false;
                    report.Parameters[1].Visible = false;
                    report.ShowPreviewDialog();
                    report.Dispose();
                }
            }
            else
            {
                var report = new Reportes.Ventas.FacturaTermicaCordobasDev(bindingSourceReport);
                int vEmpleado = Clases.UsuarioLogueado.vID_Empleado;
                int estado = Convert.ToInt32(viewVentas.GetFocusedRowCellValue("estado"));
                bool tiene_permiso = Presentacion.Clases.UsuarioLogueado.PermisoEspecial(vEmpleado, 138);

                if (estado == 0)
                {
                    for (int i = 0; i < report.Pages.Count; i++)
                    {
                        Page myPage = report.Pages[i];
                        myPage.AssignWatermark(CreateTextWatermark("FACTURA ANULADA"));
                    }
                }

                if (tiene_permiso)
                {
                    //report.Parameters[0].Visible = true;
                    //report.Parameters[1].Visible = true;
                    report.ShowPreviewDialog();
                    report.Dispose();
                }
                else
                {
                    report.Parameters[0].Visible = false;
                    report.Parameters[1].Visible = false;
                    report.ShowPreviewDialog();
                    report.Dispose();
                }
            }
        }
    }
}