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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraReports.UI;
using Presentacion.Formularios.Catalogos;

namespace Presentacion.Formularios.Compras
{
    public partial class xfrm_NuevaCompra : DevExpress.XtraEditors.XtraForm, ICompras
    {
        private int vTemp;
        private int _vIdCompra;
        public xfrm_NuevaCompra(int xTemp)
        {
            vTemp = xTemp;
            InitializeComponent();
            dateFecha.EditValue = DateTime.Now;
            dateFechaEstimada.EditValue = DateTime.Now;
        }
        public int vIdCompra { get => _vIdCompra; set => _vIdCompra = value; }
        private void xfrm_NuevaCompra_Load(object sender, EventArgs e)
        {
            lookUpEdit_Proveedor.Properties.DataSource = Negocio.ClasesCN.CatalogosCN.Proveedores_Select();
            bindingSourceDetalle.DataSource = getTable();
            repositoryItemLookUpEdit_Producto.DataSource = repositoryItemSearchLookUpEdit_Producto.DataSource = Negocio.ClasesCN.CatalogosCN.Producto_Cargar().Where(x => x.habilitado == true);
            repository_Lote.DataSource = Negocio.ClasesCN.CatalogosCN.Lotes_Cargar().ToList();

            //int idEmpleado = Clases.UsuarioLogueado.vID_Empleado;
            //var Permisos = Negocio.ClasesCN.RolesPermisosCN.Cargar_Permisos(idEmpleado).Where(p => p.id_rol == 11158).FirstOrDefault();
            //if(Permisos.asignado == 1)
            //{

            //}
            //else
            //{

            //}

        }

        private void xfrm_NuevaCompra_Activated(object sender, EventArgs e)
        {
            lookUpEdit_Proveedor.Properties.DataSource = Negocio.ClasesCN.CatalogosCN.Proveedores_Select();
            repositoryItemLookUpEdit_Producto.DataSource = repositoryItemSearchLookUpEdit_Producto.DataSource = Negocio.ClasesCN.CatalogosCN.Producto_Cargar().Where(x => x.habilitado == true);
            repository_Lote.DataSource = Negocio.ClasesCN.CatalogosCN.Lotes_Cargar().ToList();
        }

        private void xfrm_NuevaCompra_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (viewDetalle.OptionsBehavior.Editable)
                if (viewDetalle.RowCount > 0)
                    e.Cancel = true;
        }

        private DataTable getTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("descripcion", typeof(string));
            dt.Columns.Add("cantidad", typeof(decimal));
            dt.Columns.Add("precio1", typeof(decimal));
            dt.Columns.Add("precio_nuevo", typeof(decimal));
            dt.Columns.Add("impuesto", typeof(decimal));
            dt.Columns.Add("id_lote", typeof(int));
            dt.Columns.Add("ubicacion", typeof(string));
            //dt.Columns.Add("total", typeof(decimal));

            return dt;
        }

        private void lookUpEdit_Proveedor_EditValueChanged(object sender, EventArgs e)
        {
            txt_Tel.Text = string.Empty;
            txt_Ruc.Text = string.Empty;
            txt_Dir.Text = string.Empty;
            var query = Negocio.ClasesCN.CatalogosCN.Proveedores_Select().Where(x => x.id == Convert.ToInt32(lookUpEdit_Proveedor.EditValue)).FirstOrDefault();
            if (query != null)
            {
                txt_Tel.Text = query.telefono;
                txt_Ruc.Text = query.ruc;
                txt_Dir.Text = query.direccion;
            }
        }

        #region METODOS VIEW
        private void repositoryItemLookUpEdit_Producto_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                object value = (sender as LookUpEdit).EditValue;
                var query = Negocio.ClasesCN.CatalogosCN.Producto_Cargar_Fila(int.Parse(value.ToString())).Where(x => x.habilitado == true).FirstOrDefault();
                if (query != null)
                {
                    viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle, "cantidad", 1);
                    viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle, "descripcion", query.descripcion);
                    viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle, "precio1", query.costo);
                    viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle, "precio_nuevo", query.costo);
                    viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle, "impuesto", query.impuesto);
                }
            }
            catch (Exception) { }
        }

        private void repositoryItemSearchLookUpEdit_Producto_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                object value = (sender as SearchLookUpEdit).EditValue;
                var query = Negocio.ClasesCN.CatalogosCN.Producto_Cargar_Fila(int.Parse(value.ToString())).Where(x => x.habilitado == true).FirstOrDefault();
                if (query != null)
                {
                    viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle, "cantidad", 1);
                    viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle, "descripcion", query.descripcion);
                    viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle, "precio1", query.costo);
                    viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle, "precio_nuevo", query.costo);
                    viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle, "impuesto", query.impuesto);
                }
            }
            catch (Exception) { }
        }

        bool ProductoExiste(int vId, GridView view)
        {
            bool retorno = false;
            for (int i = 0; i < view.RowCount; i++)
            {
                int vIdProducto = Convert.ToInt32(view.GetRowCellValue(i, "id"));
                if (vId == vIdProducto) { retorno = true; break; }
            }
            return retorno;
        }

        private void viewDetalle_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            GridView view = sender as GridView;
            
            switch (view.FocusedColumn.FieldName)
            {
                case "cantidad":
                    if ((Convert.ToInt32(e.Value) <= 0) || (Convert.ToInt32(e.Value) > 1000000))
                        e.Valid = false;
                    break;

                case "precio_nuevo":
                    if ((Convert.ToInt32(e.Value) < 0))
                        e.Valid = false;
                    break;

                case "impuesto":
                    if ((Convert.ToInt32(e.Value) < 0))
                        e.Valid = false;
                    break;

                //case "id":
                //    if (ProductoExiste(Convert.ToInt32(e.Value), view))
                //        e.Valid = false;
                //    break;
            }
        }

        private void viewDetalle_InvalidValueException(object sender, DevExpress.XtraEditors.Controls.InvalidValueExceptionEventArgs e)
        {
            GridView view = sender as GridView;

            switch (view.FocusedColumn.FieldName)
            {
                case "cantidad":
                    e.ExceptionMode = ExceptionMode.DisplayError;
                    e.WindowCaption = "Error en el valor ingresado";
                    e.ErrorText = "Cantidad no puede ser menor/igual a 0 o mayor a 1,000,000";
                    //view.HideEditor();
                    break;

                case "precio_nuevo":
                    e.ExceptionMode = ExceptionMode.DisplayError;
                    e.WindowCaption = "Error en el valor ingresado";
                    e.ErrorText = "Precio no puede ser menor a 0";
                    //view.HideEditor();
                    break;

                case "impuesto":
                    e.ExceptionMode = ExceptionMode.DisplayError;
                    e.WindowCaption = "Error en el valor ingresado";
                    e.ErrorText = "Impuesto no puede ser menor a 0";
                    //view.HideEditor();
                    break;

                //case "id":
                //    e.ExceptionMode = ExceptionMode.DisplayError;
                //    e.WindowCaption = "Error en el valor ingresado";
                //    e.ErrorText = "Codigo ya esta agregado";
                //    //view.HideEditor();
                    //break;
            }
        }

        private void viewDetalle_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            GridView view = sender as GridView;

            try
            {
                var vIdProducto = view.GetFocusedRowCellValue("id").Equals(DBNull.Value) ? 0 : Convert.ToInt32(view.GetFocusedRowCellValue("id"));
                if (vIdProducto == 0) { e.Valid = false; view.SetColumnError(colID, "Campo requerido"); view.FocusedColumn = colID; }

                var vCantidad = view.GetFocusedRowCellValue("cantidad").Equals(DBNull.Value) ? "" : Convert.ToString(view.GetFocusedRowCellValue("cantidad"));
                if (string.IsNullOrEmpty(vCantidad)) { e.Valid = false; view.SetColumnError(colCantidad, "Campo requerido"); view.FocusedColumn = colCantidad; }

                var vPrecio = view.GetFocusedRowCellValue("precio_nuevo").Equals(DBNull.Value) ? "" : Convert.ToString(view.GetFocusedRowCellValue("precio_nuevo"));
                if (string.IsNullOrEmpty(vCantidad)) { e.Valid = false; view.SetColumnError(colPrecio, "Campo requerido"); view.FocusedColumn = colPrecio; }

                var vImpuesto = view.GetFocusedRowCellValue("impuesto").Equals(DBNull.Value) ? "" : Convert.ToString(view.GetFocusedRowCellValue("impuesto"));
                if (string.IsNullOrEmpty(vCantidad)) { e.Valid = false; view.SetColumnError(colImpuesto, "Campo requerido"); view.FocusedColumn = colImpuesto; }
            }
            catch (Exception)
            {
                e.Valid = false;
            }
        }

        private void viewDetalle_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
            e.WindowCaption = "Error en el valor ingresado";
            e.ErrorText = "Campo requerido";
        }

        private void viewDetalle_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete)
                {
                    GridView view = sender as GridView;
                    //if (XtraMessageBox.Show("Desea Eliminar Este Registro?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
                    view.DeleteRow(view.FocusedRowHandle);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error :" + ex.Message);
            }
        }

        #endregion
        DXErrorProvider dXError = new DXErrorProvider();
        
        bool Validar()
        {
            bool retorno = false;

            dXError.ClearErrors(); dXError.Dispose();
            if (string.IsNullOrEmpty(txtNumeroFactura.Text.Trim().Replace(" ", "")))
            {
                dXError.SetError(txtNumeroFactura, "Campo requerido");
                txtNumeroFactura.Focus();
            }
            else if (lookUpEdit_Proveedor.EditValue == null)
            {
                dXError.SetError(lookUpEdit_Proveedor, "Campo requerido");
                lookUpEdit_Proveedor.Focus();
            }
            else if (dateFecha.Text.Length <= 0 || dateFechaEstimada.Text.Length <= 0)
            {
                dXError.SetError(dateFecha, "Campo requerido");
                dXError.SetError(dateFechaEstimada, "Campo requerido");
                dateFecha.Focus();
            }
            else if (viewDetalle.RowCount == 0)
            {
                XtraMessageBox.Show("No hay detalles que guardar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                viewDetalle.Focus();
            }
            else { retorno = true; }


            return retorno;
        }

        void GuardarOrden(int Opcion)
        {
            if (vTemp == 0)
            {
                if (!Validar()) return;
                Clases.MyMessageBox.MessageFont = new Font(Clases.MyMessageBox.MessageFont.FontFamily, 24);
                var cantidad = viewDetalle.Columns["cantidad"].SummaryItem.SummaryValue;
                if (Clases.MyMessageBox.Show("¿Desea guardar esta orden de compra con cantidad:"+cantidad+"?", "Orden de Compra", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
                string vNumeroFactura = txtNumeroFactura.Text.Trim();
                int vProveedor = Convert.ToInt32(lookUpEdit_Proveedor.EditValue);
                DateTime vFecha = Convert.ToDateTime(dateFecha.EditValue);
                DateTime vFechaEstimada = Convert.ToDateTime(dateFechaEstimada.EditValue);
                string vObservacion = txtObservacion.Text.Trim();
                var CompraOK = Negocio.ClasesCN.ComprasCN.Compra_Guardar(vNumeroFactura, vProveedor, vFecha, vFechaEstimada, vObservacion, viewDetalle);
                if (CompraOK.Item1)
                {
                    Clases.MyMessageBox.Show("Orden de Compra Guardada Correctamente", "Orden de Compra", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (Opcion == 1)
                    {
                        btnLimpiar_ItemClick(null, null);
                    }
                    else if (Opcion == 2)
                    {
                        BindingSource source = new BindingSource();
                        source.DataSource = Negocio.ClasesCN.ComprasCN.Compras_Reporte(CompraOK.Item2);
                        var report = new Reportes.Compras.OrdenCompra(source);
                        report.ShowPreviewDialog();
                        report.Dispose();
                        //var report = new Reportes.Compras.OrdenCompra(1);
                        //report.DataSource = Negocio.ClasesCN.ComprasCN.Compras_Reporte(CompraOK.Item2);
                        //report.ShowPreviewDialog();
                        btnLimpiar_ItemClick(null, null);
                    }
                }
            }
            else if (vTemp == 1)
            {
                if (!Validar()) return;
                Clases.MyMessageBox.MessageFont = new Font(Clases.MyMessageBox.MessageFont.FontFamily, 24);
                if (Clases.MyMessageBox.Show("Desea Editar esta Orden de Compra?", "Orden de Compra", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
                string vNumeroFactura = txtNumeroFactura.Text.Trim();
                int vProveedor = Convert.ToInt32(lookUpEdit_Proveedor.EditValue);
                DateTime vFecha = Convert.ToDateTime(dateFecha.EditValue);
                DateTime vFechaEstimada = Convert.ToDateTime(dateFechaEstimada.EditValue);
                string vObservacion = txtObservacion.Text.Trim();
                bool CompraOK = Negocio.ClasesCN.ComprasCN.Compra_Modificar(vIdCompra, vNumeroFactura, vProveedor, vFecha, vFechaEstimada, vObservacion, viewDetalle);
                if (CompraOK)
                {
                    Clases.MyMessageBox.Show("Orden de Compra Editada Correctamente", "Orden de Compra", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (Opcion == 1)
                    {
                        btnLimpiar_ItemClick(null, null);
                    }
                    else if (Opcion == 2)
                    {
                        //Reporte
                        btnLimpiar_ItemClick(null, null);
                    }
                }
            }
        }

        private void btnGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GuardarOrden(1);
        }

        private void btnGuardarImprimir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GuardarOrden(2);
        }
        
        private void btnLimpiar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            lookUpEdit_Proveedor.EditValue = null;
            txtNumeroFactura.Text = string.Empty;
            txtObservacion.Text = string.Empty;
            dateFecha.EditValue = DateTime.Now;
            dateFechaEstimada.EditValue = DateTime.Now;
            gridCompra.DataSource = null;
            bindingSourceDetalle.DataSource = null;
            bindingSourceDetalle.DataSource = getTable();
            gridCompra.DataSource = bindingSourceDetalle;
            SendKeys.Send("{ESC}");
        }
        
        public bool getCompras(List<Entidades.Compras> xCompras)
        {
            var query = xCompras.FirstOrDefault();
            if (query != null)
            {
                vIdCompra = query.id;
                txtNumeroFactura.Text = query.numero_factura;
                lookUpEdit_Proveedor.EditValue = query.id_proveedor;
                dateFecha.EditValue = query.fecha;
                dateFechaEstimada.EditValue = query.fecha_estimada;
                txtObservacion.Text = query.observacion;

                return true;
            }
            else { return false; }
        }

        public void getDetalleCompra(DataTable xDetalleCompra)
        {
            gridCompra.DataSource = xDetalleCompra;
        }

        private void barLargeButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            repositoryItemLookUpEdit_Producto.DataSource = repositoryItemSearchLookUpEdit_Producto.DataSource = Negocio.ClasesCN.CatalogosCN.Producto_Cargar().Where(x => x.habilitado == true);
            repository_Lote.DataSource = Negocio.ClasesCN.CatalogosCN.Lotes_Cargar().ToList();
        }
    }
}