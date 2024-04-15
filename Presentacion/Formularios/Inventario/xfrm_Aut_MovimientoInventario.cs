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
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraBars;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.Parameters;
using Presentacion.Formularios.Catalogos;

namespace Presentacion.Formularios.Inventario
{
    public partial class xfrm_Aut_MovimientoInventario : DevExpress.XtraEditors.XtraForm
    {
        string usuario;
        string cargo;
        public xfrm_Aut_MovimientoInventario()
        {
            InitializeComponent();
            usuario = Clases.UsuarioLogueado.vNickName;
            cargo = Clases.UsuarioLogueado.vPuestoCargo;
        }

        private void xfrm_MovimientoInventario_Load(object sender, EventArgs e)
        {
            dtp_desde.DateTime = DateTime.Now.AddDays(-30);
            dtp_hasta.DateTime = DateTime.Now;
            bindingSourceMovimientos.DataSource = Negocio.ClasesCN.InventarioCN.MovimientoInventario_Select_Autorizacion(false, dtp_desde.DateTime, dtp_hasta.DateTime).Where(x => x.autorizado == false);
            //bindingSourceHistorico.DataSource = Negocio.ClasesCN.InventarioCN.MovimientoInventario_Select(true);
            viewPrincipal_FocusedRowChanged(null, null);
        }

        private void xfrm_MovimientoInventario_Activated(object sender, EventArgs e)
        {
            //   xfrm_MovimientoInventario_Load(null, null);
        }

        private void viewPrincipal_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage != tabMovimientos) return;

            try
            {
                //if (viewPrincipal.RowCount == 0) return;
                int vId = Convert.ToInt32(viewPrincipal.GetFocusedRowCellValue("id"));
                string vNumero = viewPrincipal.GetFocusedRowCellValue("numero_documento").ToString();
                string vDocumento = viewPrincipal.GetFocusedRowCellValue("tipo_documento").ToString();
                if (Clases.UsuarioLogueado.saberAdminM())
                {
                    bindingSourceDetalle.DataSource = Negocio.ClasesCN.InventarioCN.MovimientoInventarioDetalle_Select_Autorizacion(vId);
                }
                else
                {
                    bindingSourceDetalle.DataSource = Negocio.ClasesCN.InventarioCN.MovimientoInventarioDetalle_Select_Autorizacion(vId).Where(o => !o.bodega.Contains("BODEGA ESPECIAL"));
                }

                dockPanel1.Text = "Detalle de Movimiento " + vDocumento + "[Nº" + vNumero + "] ";
            }
            catch (Exception)
            {
                bindingSourceDetalle.DataSource = null;
            }
        }

        private void viewHistorico_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage != tabHistorico) return;

            try
            {
                if (viewHistorico.RowCount == 0) return;
                int vId = Convert.ToInt32(viewHistorico.GetFocusedRowCellValue("id"));
                string vNumero = viewHistorico.GetFocusedRowCellValue("numero_documento").ToString();
                string vDocumento = viewHistorico.GetFocusedRowCellValue("tipo_documento").ToString();
                bindingSourceDetalle.DataSource = Negocio.ClasesCN.InventarioCN.MovimientoInventarioDetalle_Select_Autorizacion(vId);
                dockPanel1.Text = "Detalle de Movimiento " + vDocumento + "[Nº" + vNumero + "] ";
            }
            catch (Exception)
            {
                bindingSourceDetalle.DataSource = null;
            }
        }

        private void xtraTabControl1_Click(object sender, EventArgs e)
        {
            viewPrincipal_FocusedRowChanged(null, null);
            viewHistorico_FocusedRowChanged(null, null);
        }

        PopupMenu menu;
        private void viewPrincipal_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    GridHitInfo hi = viewPrincipal.CalcHitInfo(e.Location);
                    object text = "";
                    object text1 = "";
                    object text2 = "";
                    if (hi.InRowCell)
                    {
                        int tipo = (int)viewPrincipal.GetRowCellValue(hi.RowHandle, colTipo);
                        if (tipo == 1)
                        {
                            text = "Ver Orden de Compra";

                            if (barManager1 == null)
                            {
                                barManager1 = new BarManager();
                                barManager1.Form = this;
                            }
                            if (menu == null)
                                menu = new PopupMenu(barManager1);
                            menu.ItemLinks.Clear();
                            BarButtonItem itemCompra = new BarButtonItem(barManager1, text.ToString());
                            itemCompra.ImageOptions.ImageIndex = 0;
                            itemCompra.ItemClick += new ItemClickEventHandler(itemCompra_Click);
                            menu.AddItems(new BarItem[] { itemCompra });
                            menu.ShowPopup(Cursor.Position);
                        }
                        if (tipo == 2)
                        {
                            text = "Ver Orden de Venta";

                            if (barManager1 == null)
                            {
                                barManager1 = new BarManager();
                                barManager1.Form = this;
                            }
                            if (menu == null)
                                menu = new PopupMenu(barManager1);
                            menu.ItemLinks.Clear();
                            BarButtonItem itemVenta = new BarButtonItem(barManager1, text.ToString());
                            itemVenta.ImageOptions.ImageIndex = 1;
                            itemVenta.ItemClick += new ItemClickEventHandler(itemVenta_Click);
                            menu.AddItems(new BarItem[] { itemVenta });
                            menu.ShowPopup(Cursor.Position);
                        }

                        if (tipo == 3)
                        {
                            var query = Negocio.ClasesCN.ParametrosCN.getAjustesModulos(3);
                            if (query > 0)
                            {
                                int vIdTipoAjuste = (int)viewPrincipal.GetRowCellValue(hi.RowHandle, colIdTipoAjuste);
                                if (query == vIdTipoAjuste)
                                {
                                    text = "Ver Orden de Traslado";

                                    if (barManager1 == null)
                                    {
                                        barManager1 = new BarManager();
                                        barManager1.Form = this;
                                    }
                                    if (menu == null)
                                        menu = new PopupMenu(barManager1);
                                    menu.ItemLinks.Clear();
                                    BarButtonItem itemTraslado = new BarButtonItem(barManager1, text.ToString());
                                    itemTraslado.ImageOptions.ImageIndex = 2;
                                    itemTraslado.ItemClick += new ItemClickEventHandler(itemTraslado_Click);
                                    menu.AddItems(new BarItem[] { itemTraslado });
                                    menu.ShowPopup(Cursor.Position);
                                }
                            }
                        }
                        if (tipo == 4)
                        {
                            text = "Ver Ajuste";
                            text1 = "Autorizar Movimiento";
                            text2 = "Anular Movimiento";

                            if (barManager1 == null)
                            {
                                barManager1 = new BarManager();
                                barManager1.Form = this;
                            }
                            if (menu == null)
                                menu = new PopupMenu(barManager1);
                            menu.ItemLinks.Clear();
                            BarButtonItem itemajuste = new BarButtonItem(barManager1, text.ToString());
                            BarButtonItem itemAutorizar = new BarButtonItem(barManager1, text1.ToString());
                            BarButtonItem itemAnular = new BarButtonItem(barManager1, text2.ToString());
                            itemajuste.ImageOptions.ImageIndex = 3;
                            itemajuste.ItemClick += new ItemClickEventHandler(itemAjuste_Click);
                            itemAutorizar.ImageOptions.ImageIndex = 4;
                            itemAutorizar.ItemClick += new ItemClickEventHandler(itemAutorizar_Click);
                            itemAnular.ImageOptions.ImageIndex = 5;
                            itemAnular.ItemClick += new ItemClickEventHandler(itemAnular_Click);
                            menu.AddItems(new BarItem[] { itemajuste });
                            menu.AddItems(new BarItem[] { itemAutorizar });
                            menu.AddItems(new BarItem[] { itemAnular });
                            menu.ShowPopup(Cursor.Position);
                        }
                    }
                }
            }
            catch (Exception) { }
        }

        private void viewHistorico_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    GridHitInfo hi = viewHistorico.CalcHitInfo(e.Location);
                    object text = "";
                    if (hi.InRowCell)
                    {
                        int tipo = (int)viewHistorico.GetRowCellValue(hi.RowHandle, colTipo);
                        if (tipo == 1)
                        {
                            text = "Ver Orden de Compra";

                            if (barManager1 == null)
                            {
                                barManager1 = new BarManager();
                                barManager1.Form = this;
                            }
                            if (menu == null)
                                menu = new PopupMenu(barManager1);
                            menu.ItemLinks.Clear();
                            BarButtonItem itemCompra = new BarButtonItem(barManager1, text.ToString());
                            itemCompra.ImageOptions.ImageIndex = 0;
                            itemCompra.ItemClick += new ItemClickEventHandler(itemCompraH_Click);
                            menu.AddItems(new BarItem[] { itemCompra });
                            menu.ShowPopup(Cursor.Position);
                        }
                        if (tipo == 2)
                        {
                            text = "Ver Orden de Venta";

                            if (barManager1 == null)
                            {
                                barManager1 = new BarManager();
                                barManager1.Form = this;
                            }
                            if (menu == null)
                                menu = new PopupMenu(barManager1);
                            menu.ItemLinks.Clear();
                            BarButtonItem itemVenta = new BarButtonItem(barManager1, text.ToString());
                            itemVenta.ImageOptions.ImageIndex = 1;
                            itemVenta.ItemClick += new ItemClickEventHandler(itemVentaH_Click);
                            menu.AddItems(new BarItem[] { itemVenta });
                            menu.ShowPopup(Cursor.Position);
                        }
                        if (tipo == 3)
                        {
                            var query = Negocio.ClasesCN.ParametrosCN.getAjustesModulos(3);
                            if (query > 0)
                            {
                                int vIdTipoAjuste = (int)viewHistorico.GetRowCellValue(hi.RowHandle, colIdTipoAjusteH);
                                if (query == vIdTipoAjuste)
                                {
                                    text = "Ver Orden de Traslado";

                                    if (barManager1 == null)
                                    {
                                        barManager1 = new BarManager();
                                        barManager1.Form = this;
                                    }
                                    if (menu == null)
                                        menu = new PopupMenu(barManager1);
                                    menu.ItemLinks.Clear();
                                    BarButtonItem itemTraslado = new BarButtonItem(barManager1, text.ToString());
                                    itemTraslado.ImageOptions.ImageIndex = 2;
                                    itemTraslado.ItemClick += new ItemClickEventHandler(itemTrasladoH_Click);
                                    menu.AddItems(new BarItem[] { itemTraslado });
                                    menu.ShowPopup(Cursor.Position);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception) { }
        }

        public Ventas.IVentas iVentas { get; set; }
        void itemVenta_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Venta: " + viewPrincipal.GetFocusedRowCellDisplayText("id_referencia"));
            var form = new Ventas.xfrm_NuevaVenta(2);
            form.Text = "VER FACTURA";
            form.viewDetalle.OptionsBehavior.Editable = false;
            form.btnGuardar.Enabled = false;
            form.btnGuardarImprimir.Enabled = false;
            form.lookUpEdit_Cliente.Enabled = false;
            form.dateFecha.Enabled = false;
            form.dateFechaEstimada.Enabled = false;
            form.lookUpEdit_Terminos.Enabled = false;
            //form.txtDescuentoPorcentaje.Enabled = false;
            //form.txtDescuentoMonto.Enabled = false;
            form.bindingSourceProducto.DataSource = Negocio.ClasesCN.InventarioCN.Kardex_SelectVenta();
            //form.MdiParent = this.MdiParent;
            iVentas = form;
            bool resultOK = iVentas.getVenta(Negocio.ClasesCN.VentasCN.getVentas().Where(x => x.id == Convert.ToInt32(viewPrincipal.GetFocusedRowCellDisplayText("id_referencia"))).ToList());
            iVentas.getDetalleVenta(Negocio.ClasesCN.VentasCN.getVentasDetalle(Convert.ToInt32(viewPrincipal.GetFocusedRowCellDisplayText("id_referencia"))));
            if (!resultOK) return;
            form.ShowDialog();
        }

        void itemVentaH_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Venta: " + viewPrincipal.GetFocusedRowCellDisplayText("id_referencia"));
            var form = new Ventas.xfrm_NuevaVenta(2);
            form.Text = "VER FACTURA";
            form.viewDetalle.OptionsBehavior.Editable = false;
            form.btnGuardar.Enabled = false;
            form.btnGuardarImprimir.Enabled = false;
            form.lookUpEdit_Cliente.Enabled = false;
            //form.txtDescuentoPorcentaje.Enabled = false;
            //form.txtDescuentoMonto.Enabled = false;
            form.dateFecha.Enabled = false;
            form.dateFechaEstimada.Enabled = false;
            form.lookUpEdit_Terminos.Enabled = false;
            form.bindingSourceProducto.DataSource = Negocio.ClasesCN.InventarioCN.Kardex_SelectVenta();
            //form.MdiParent = this.MdiParent;
            iVentas = form;
            bool resultOK = iVentas.getVenta(Negocio.ClasesCN.VentasCN.getVentas().Where(x => x.id == Convert.ToInt32(viewHistorico.GetFocusedRowCellDisplayText("id_referencia"))).ToList());
            iVentas.getDetalleVenta(Negocio.ClasesCN.VentasCN.getVentasDetalle(Convert.ToInt32(viewHistorico.GetFocusedRowCellDisplayText("id_referencia"))));
            if (!resultOK) return;
            form.ShowDialog();
        }

        public Compras.ICompras iCompras { get; set; }
        void itemCompra_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Compra: " + viewPrincipal.GetFocusedRowCellDisplayText("id_referencia"));
            var form = new Compras.xfrm_NuevaCompra(0);
            form.Text = "VER ORDEN DE COMPRA";
            form.viewDetalle.OptionsBehavior.Editable = false;
            form.btnGuardar.Enabled = false;
            form.btnGuardarImprimir.Enabled = false;
            //form.MdiParent = this.MdiParent;
            iCompras = form;
            bool resultOK = iCompras.getCompras(Negocio.ClasesCN.ComprasCN.getCompras().Where(x => x.id == Convert.ToInt32(viewPrincipal.GetFocusedRowCellDisplayText("id_referencia"))).ToList());
            iCompras.getDetalleCompra(Negocio.ClasesCN.ComprasCN.getComprasDetalle(Convert.ToInt32(viewPrincipal.GetFocusedRowCellDisplayText("id_referencia"))));
            if (!resultOK) return;
            form.ShowDialog();
        }

        void itemCompraH_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Compra: " + viewPrincipal.GetFocusedRowCellDisplayText("id_referencia"));
            var form = new Compras.xfrm_NuevaCompra(0);
            form.Text = "VER ORDEN DE COMPRA";
            form.viewDetalle.OptionsBehavior.Editable = false;
            form.btnGuardar.Enabled = false;
            form.btnGuardarImprimir.Enabled = false;
            //form.MdiParent = this.MdiParent;
            iCompras = form;
            bool resultOK = iCompras.getCompras(Negocio.ClasesCN.ComprasCN.getCompras().Where(x => x.id == Convert.ToInt32(viewHistorico.GetFocusedRowCellDisplayText("id_referencia"))).ToList());
            iCompras.getDetalleCompra(Negocio.ClasesCN.ComprasCN.getComprasDetalle(Convert.ToInt32(viewHistorico.GetFocusedRowCellDisplayText("id_referencia"))));
            if (!resultOK) return;
            form.ShowDialog();
        }

        void itemTraslado_Click(object sender, EventArgs e)
        {
            BindingSource source = new BindingSource();
            int vMov = Convert.ToInt32(viewPrincipal.GetFocusedRowCellDisplayText("id"));
            var deBodega = Negocio.ClasesCN.InventarioCN.Traslado_ObtenerBodega(vMov, 0);
            var haciaBodega = Negocio.ClasesCN.InventarioCN.Traslado_ObtenerBodega(vMov, 1);
            source.DataSource = Negocio.ClasesCN.InventarioCN.Traslado_Reporte(vMov, haciaBodega.Item1);
            var report = new Reportes.Inventario.xrpt_traslado_bodega(source);
            report.Parameters[0].Value = deBodega.Item2;
            report.ShowPreviewDialog();
        }

        void itemTrasladoH_Click(object sender, EventArgs e)
        {
            BindingSource source = new BindingSource();
            int vMov = Convert.ToInt32(viewHistorico.GetFocusedRowCellDisplayText("id"));
            var deBodega = Negocio.ClasesCN.InventarioCN.Traslado_ObtenerBodega(vMov, 0);
            var haciaBodega = Negocio.ClasesCN.InventarioCN.Traslado_ObtenerBodega(vMov, 1);
            source.DataSource = Negocio.ClasesCN.InventarioCN.Traslado_Reporte(vMov, haciaBodega.Item1);
            var report = new Reportes.Inventario.xrpt_traslado_bodega(source);
            report.Parameters[0].Value = deBodega.Item2;
            report.ShowPreviewDialog();
        }
        void itemAjuste_Click(object sender, EventArgs e)
        {
            BindingSource source = new BindingSource();
            int vMov = Convert.ToInt32(viewPrincipal.GetFocusedRowCellDisplayText("id"));

            if (Clases.UsuarioLogueado.saberAdminM())
            {
                source.DataSource = Negocio.ClasesCN.InventarioCN.Reporte_Ajuste_Autorizacion(vMov);
            }
            else
            {
                source.DataSource = Negocio.ClasesCN.InventarioCN.Reporte_Ajuste_Autorizacion(vMov).Where(x => !x.bodega.Contains("BODEGA ESPECIAL"));
            }


            var report = new Reportes.Inventario.xrpt_ajuste(source);
            report.ShowPreviewDialog();
        }

        void itemAutorizar_Click(object sender, EventArgs e)
        {
            int idMovA = Convert.ToInt32(viewPrincipal.GetFocusedRowCellDisplayText("id"));
            int vIdEmpleado = Clases.UsuarioLogueado.vID_Empleado;
            var query = Negocio.ClasesCN.InventarioCN.MovimientoInventario_Select_Autorizacion(false, dtp_desde.DateTime, dtp_hasta.DateTime).Where(x => x.id == idMovA).FirstOrDefault();
            var queryD = Negocio.ClasesCN.InventarioCN.MovimientoInventarioDetalle_Select_Autorizacion(query.id).FirstOrDefault();
            var queryB = Negocio.ClasesCN.CatalogosCN.Bodega_Cargar().Where(x => x.nombre == queryD.bodega).FirstOrDefault();
            var Permisos = Negocio.ClasesCN.RolesPermisosCN.Cargar_Permisos(0).Where(p => p.id_rol == 12).FirstOrDefault();
            xfrm_autorizacion frm = new xfrm_autorizacion("AUTORIZACION DE AJUSTES DE INVENTARIO");
            if(vIdEmpleado == 7)
            {
                frm.txt_usuario.Text = "MARLING";
            }
            frm.numero_permiso = Permisos.id_rol ?? 0;
            frm.permiso = Permisos.descripcion.ToUpper();
            frm.teConcepto.Text = query.observacion;
            frm.ShowDialog();
            if (frm.Autorizado)
            {
                if (Clases.MyMessageBox.Show("¿Desea Autorizar el Ajuste?", "Ajuste de Inventario", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
                
                int vEmpleado = Clases.UsuarioLogueado.vID_Empleado;
                int vAjuste = query.id_tipo_ajuste;
                DateTime vFecha = query.fecha_documento;
                string vNumeroReferencia = "";
                string vObservacion = query.observacion;
                string vPersonaReferencia = query.persona_referencia;
                string vNumeroDoc = query.numero_documento;
                int vTipo = 4;

                var MovOK = Negocio.ClasesCN.InventarioCN.AjusteInventario_Guardar_Autorizado(vAjuste, vFecha, vNumeroReferencia, vObservacion, vEmpleado, vPersonaReferencia, vTipo, 0, viewDetalle, queryB.id, vNumeroDoc);//Convert.ToInt32(look_lote.EditValue??0));
                if (MovOK.Item1)
                {
                    //txtNumeroFactura.Text = MovOK.Item3;
                    Clases.MyMessageBox.Show("Guardada Correctamente", "Inventario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BindingSource source = new BindingSource();
                    int vMov = MovOK.Item2;
                    source.DataSource = Negocio.ClasesCN.InventarioCN.Reporte_Ajuste(vMov);
                    var report = new Reportes.Inventario.xrpt_ajuste(source);
                    report.ShowPreviewDialog();
                    bindingSourceMovimientos.DataSource = Negocio.ClasesCN.InventarioCN.MovimientoInventario_Select_Autorizacion(false, dtp_desde.DateTime, dtp_hasta.DateTime).Where(x => x.autorizado == false);
                    viewPrincipal_FocusedRowChanged(null, null);
                }
            }
            else
            {
                XtraMessageBox.Show($"Usted no tiene autorizacion de {frm.permiso.ToUpper()}", "Información");
            }
        }

        void itemAnular_Click(object sender, EventArgs e)
        {
            int idMovA = Convert.ToInt32(viewPrincipal.GetFocusedRowCellDisplayText("id"));
            string concepto = Convert.ToString(viewPrincipal.GetFocusedRowCellValue("numero_documento"));
            var Permisos = Negocio.ClasesCN.RolesPermisosCN.Cargar_Permisos(0).Where(p => p.id_rol == 12).FirstOrDefault();
            xfrm_autorizacion frm = new xfrm_autorizacion("ANULACION DE AUTORIZACION DE AJUSTES DE INVENTARIO");
            frm.numero_permiso = Permisos.id_rol ?? 0;
            frm.permiso = Permisos.descripcion.ToUpper();
            frm.teConcepto.Text = "ANULACION DE DOCUMENTO N° " + concepto;
            frm.ShowDialog();
            if (frm.Autorizado)
            {
                if (Clases.MyMessageBox.Show("¿Desea Anular el Ajuste?", "Ajuste de Inventario", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

                var query = Negocio.ClasesCN.InventarioCN.AnularMov_Autorizacion(idMovA);
                if (query > 0)
                {
                    Clases.MyMessageBox.Show("Anulado Correctamente", "Inventario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bindingSourceMovimientos.DataSource = Negocio.ClasesCN.InventarioCN.MovimientoInventario_Select_Autorizacion(false, dtp_desde.DateTime, dtp_hasta.DateTime).Where(x => x.autorizado == false);
                    viewPrincipal_FocusedRowChanged(null, null);
                }
            }
            else
            {
                XtraMessageBox.Show($"Usted no tiene autorizacion de {frm.permiso.ToUpper()}", "Información");
            }


        }

        void itemAjusteH_Click(object sender, EventArgs e)
        {
            BindingSource source = new BindingSource();
            int vMov = Convert.ToInt32(viewPrincipal.GetFocusedRowCellDisplayText("id"));
            if (Clases.UsuarioLogueado.saberAdminM())
            {
                source.DataSource = Negocio.ClasesCN.InventarioCN.Reporte_Ajuste_Autorizacion(vMov);
            }
            else
            {
                source.DataSource = Negocio.ClasesCN.InventarioCN.Reporte_Ajuste_Autorizacion(vMov).Where(x => !x.bodega.Contains("BODEGA ESPECIAL"));
            }

            var report = new Reportes.Inventario.xrpt_ajuste(source);
            report.ShowPreviewDialog();
        }

        private void bbi_buscar_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                bindingSourceMovimientos.DataSource = Negocio.ClasesCN.InventarioCN.MovimientoInventario_Select_Autorizacion(false, dtp_desde.DateTime, dtp_hasta.DateTime).Where(x => x.autorizado == false);
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void gridPrincipal_Click(object sender, EventArgs e)
        {

        }
        private void bbi_reporte_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                var Consulta = Negocio.ClasesCN.InventarioCN.MovimientoInventario_Select_Autorizacion(false, dtp_desde.DateTime, dtp_hasta.DateTime);
                string[] Tipo_Movimientos = Consulta.Select(C => C.tipo_ajuste).Distinct().ToArray();
                var Reporte = new Reportes.Inventario.xrpt_movimientos_inventario();
                string[] Tipos_Movimientos = Consulta.Select(X => X.tipo_ajuste).Distinct().ToArray();

                Reporte.DataSource = Consulta.Select(E => new { E.empresa_nombre, E.empresa_ruc, E.empresa_direccion, E.empresa_eslogan, E.empresa_telefono }).Distinct().ToList();
                Reporte.Tipo_Movimientos = Tipos_Movimientos;
                Reporte.Tipo_Movimiento.Visible = true;
                Reporte.DetailReport.DataSource = Consulta;
                Reporte.DetailReport2.DataSource = Consulta;
                Reporte.Cerrado.Value = false;
                Reporte.Desde.Value = dtp_desde.DateTime.Date;
                Reporte.Hasta.Value = dtp_hasta.DateTime.Date;
                Reporte.Tipo_Movimiento.Value = Consulta.Count() > 0 ? Consulta.FirstOrDefault().tipo_ajuste : string.Empty;
                DynamicListLookUpSettings tipo_movimientoSettings = new DynamicListLookUpSettings();
                tipo_movimientoSettings.DataSource = Consulta;
                tipo_movimientoSettings.DisplayMember = "tipo_ajuste";
                tipo_movimientoSettings.ValueMember = "tipo_ajuste";
                Reporte.Tipo_Movimiento.LookUpSettings = tipo_movimientoSettings;
                Reporte.RequestParameters = false;
                Reporte.ShowPreview();
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void gridPrincipal_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    GridHitInfo hi = viewPrincipal.CalcHitInfo(e.Location);
                    object text = "";
                    object text1 = "";
                    object text2 = "";
                    if (hi.InRowCell)
                    {
                        int tipo = (int)viewPrincipal.GetRowCellValue(hi.RowHandle, colTipo);
                        if (tipo == 1)
                        {
                            text = "Ver Orden de Compra";

                            if (barManager1 == null)
                            {
                                barManager1 = new BarManager();
                                barManager1.Form = this;
                            }
                            if (menu == null)
                                menu = new PopupMenu(barManager1);
                            menu.ItemLinks.Clear();
                            BarButtonItem itemCompra = new BarButtonItem(barManager1, text.ToString());
                            itemCompra.ImageOptions.ImageIndex = 0;
                            itemCompra.ItemClick += new ItemClickEventHandler(itemCompra_Click);
                            menu.AddItems(new BarItem[] { itemCompra });
                            menu.ShowPopup(Cursor.Position);
                        }
                        if (tipo == 2)
                        {
                            text = "Ver Orden de Venta";

                            if (barManager1 == null)
                            {
                                barManager1 = new BarManager();
                                barManager1.Form = this;
                            }
                            if (menu == null)
                                menu = new PopupMenu(barManager1);
                            menu.ItemLinks.Clear();
                            BarButtonItem itemVenta = new BarButtonItem(barManager1, text.ToString());
                            itemVenta.ImageOptions.ImageIndex = 1;
                            itemVenta.ItemClick += new ItemClickEventHandler(itemVenta_Click);
                            menu.AddItems(new BarItem[] { itemVenta });
                            menu.ShowPopup(Cursor.Position);
                        }

                        if (tipo == 3)
                        {
                            var query = Negocio.ClasesCN.ParametrosCN.getAjustesModulos(3);
                            if (query > 0)
                            {
                                int vIdTipoAjuste = (int)viewPrincipal.GetRowCellValue(hi.RowHandle, colIdTipoAjuste);
                                if (query == vIdTipoAjuste)
                                {
                                    text = "Ver Orden de Traslado";

                                    if (barManager1 == null)
                                    {
                                        barManager1 = new BarManager();
                                        barManager1.Form = this;
                                    }
                                    if (menu == null)
                                        menu = new PopupMenu(barManager1);
                                    menu.ItemLinks.Clear();
                                    BarButtonItem itemTraslado = new BarButtonItem(barManager1, text.ToString());
                                    itemTraslado.ImageOptions.ImageIndex = 2;
                                    itemTraslado.ItemClick += new ItemClickEventHandler(itemTraslado_Click);
                                    menu.AddItems(new BarItem[] { itemTraslado });
                                    menu.ShowPopup(Cursor.Position);
                                }
                            }
                        }
                        if (tipo == 4)
                        {
                            text = "Ver Ajuste";
                            text1 = "Autorizar Movimiento";
                            text2 = "Anular Movimiento";

                            if (barManager1 == null)
                            {
                                barManager1 = new BarManager();
                                barManager1.Form = this;
                            }
                            if (menu == null)
                                menu = new PopupMenu(barManager1);
                            menu.ItemLinks.Clear();
                            BarButtonItem itemajuste = new BarButtonItem(barManager1, text.ToString());
                            BarButtonItem itemAutorizar = new BarButtonItem(barManager1, text1.ToString());
                            BarButtonItem itemAnular = new BarButtonItem(barManager1, text2.ToString());
                            itemajuste.ImageOptions.ImageIndex = 3;
                            itemajuste.ItemClick += new ItemClickEventHandler(itemAjuste_Click);
                            itemAutorizar.ImageOptions.ImageIndex = 4;
                            itemAutorizar.ItemClick += new ItemClickEventHandler(itemAutorizar_Click);
                            itemAnular.ImageOptions.ImageIndex = 5;
                            itemAnular.ItemClick += new ItemClickEventHandler(itemAnular_Click);
                            menu.AddItems(new BarItem[] { itemajuste });
                            menu.AddItems(new BarItem[] { itemAutorizar });
                            menu.AddItems(new BarItem[] { itemAnular });
                            menu.ShowPopup(Cursor.Position);
                        }
                    }
                }
            }
            catch (Exception) { }
        }

        private void dtp_desde_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}