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
using DevExpress.XtraGrid.Views.Tile;
using DevExpress.XtraGrid.Views.Tile.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraReports.UI;

namespace Presentacion.Formularios.Ventas
{
    public partial class xfrm_FacturaTactil : DevExpress.XtraEditors.XtraForm, IVentas
    {
        public xfrm_FacturaTactil()
        {
            InitializeComponent();
        }

        private void xfrm_FacturaTactil_Load(object sender, EventArgs e)
        {
            getTable();
            repositoryItemLookUpEdit_Producto.DataSource = Negocio.ClasesCN.CatalogosCN.Producto_Cargar();
            CargarCategoria();
            CargarProducto();
            CargarBodega();
            lookUpEdit_Cliente.Properties.DataSource = Negocio.ClasesCN.CatalogosCN.Cliente_Cargar();
            lookUpEdit_Terminos.Properties.DataSource = Negocio.ClasesCN.ParametrosCN.Terminos_Select();
            dateFecha.EditValue = DateTime.Now;
            dateFechaEstimada.EditValue = DateTime.Now;
        }

        private void xfrm_FacturaTactil_Activated(object sender, EventArgs e)
        {
            repositoryItemLookUpEdit_Producto.DataSource = Negocio.ClasesCN.CatalogosCN.Producto_Cargar();
            CargarCategoria();
            CargarProducto();
            CargarBodega();
            lookUpEdit_Cliente.Properties.DataSource = Negocio.ClasesCN.CatalogosCN.Cliente_Cargar();
            lookUpEdit_Terminos.Properties.DataSource = Negocio.ClasesCN.ParametrosCN.Terminos_Select();
            int v = tileViewBodega.RowCount;
        }

        private void xfrm_FacturaTactil_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (viewDetalle.OptionsBehavior.Editable)
                if (viewDetalle.RowCount > 0)
                    e.Cancel = true;
        }

        private void lookUpEdit_Cliente_EditValueChanged(object sender, EventArgs e)
        {
            txt_Tel.Text = string.Empty;
            txt_Ruc.Text = string.Empty;
            txt_Dir.Text = string.Empty;
            var query = Negocio.ClasesCN.CatalogosCN.Proveedores_Select().Where(x => x.id == Convert.ToInt32(lookUpEdit_Cliente.EditValue)).FirstOrDefault();
            if (query != null)
            {
                txt_Tel.Text = query.telefono;
                txt_Ruc.Text = query.ruc;
                txt_Dir.Text = query.direccion;
            }
        }

        DataTable dt = new DataTable();
        private void getTable()
        {
            //DataTable dt = new DataTable();
            dt.Columns.Add("id_bodega", typeof(int));
            dt.Columns.Add("id_producto", typeof(int));
            dt.Columns.Add("descripcion", typeof(string));
            dt.Columns.Add("cantidad", typeof(decimal));
            dt.Columns.Add("id_unidad_medida", typeof(int));
            dt.Columns.Add("precio1", typeof(decimal));
            dt.Columns.Add("descuento", typeof(decimal));
            dt.Columns.Add("impuesto", typeof(decimal));

            bindingSourceDetalle.DataSource = dt;
        }

        void CargarBodega()
        {
            bindingSourceBodega.DataSource = repositoryItemLookUpEdit_Bodega.DataSource = Negocio.ClasesCN.CatalogosCN.Bodega_Cargar();
        }

        DataTable getCategoria()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id");
            dt.Columns.Add("nombre");
            DataRow row = dt.NewRow();

            row["id"] = 0;
            row["nombre"] = "TODAS";
            dt.Rows.Add(row);
            row = dt.NewRow();

            foreach (var cat in Negocio.ClasesCN.CatalogosCN.Categoria_Cargar())
            {
                row["id"] = cat.id;
                row["nombre"] = cat.nombre;
                dt.Rows.Add(row);
                row = dt.NewRow();
            }

            return dt;
        }

        void CargarCategoria()
        {
            bindingSourceCategoria.DataSource = getCategoria();
        }

        void CargarProducto()
        {
            try
            {
                int vCategoria = Convert.ToInt32(tileViewCategoria.GetFocusedRowCellValue("id"));
                int vBodega = Convert.ToInt32(tileViewBodega.GetFocusedRowCellValue("id"));

                if (vBodega == 0 && vCategoria == 0) { bindingSourceProducto.DataSource = Negocio.ClasesCN.InventarioCN.Kardex_SelectVenta().Where(x => x.id_bodega == 1).ToList(); }
                if (vBodega == 0 && vCategoria != 0) { bindingSourceProducto.DataSource = Negocio.ClasesCN.InventarioCN.Kardex_SelectVenta().Where(x => x.id_bodega == 1 && x.id_categoria == vCategoria).ToList(); }
                if (vBodega != 0 && vCategoria == 0) { bindingSourceProducto.DataSource = Negocio.ClasesCN.InventarioCN.Kardex_SelectVenta().Where(x => x.id_bodega == vBodega).ToList(); }
                if (vBodega != 0 && vCategoria != 0) { bindingSourceProducto.DataSource = Negocio.ClasesCN.InventarioCN.Kardex_SelectVenta().Where(x => x.id_bodega == vBodega && x.id_categoria == vCategoria).ToList(); }
            }
            catch (Exception)
            {

            }
        }

        private void tileViewBodega_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            CargarProducto();
        }

        private void tileViewCategoria_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            CargarProducto();
        }

        private void tileViewProductos_ItemClick(object sender, DevExpress.XtraGrid.Views.Tile.TileViewItemClickEventArgs e)
        {
            TileView view = sender as TileView;
            //Obtener texto en donde de clic del cuadrito
            /*Point pt = view.GridControl.PointToClient(Control.MousePosition);
            TileViewHitInfo hitInfo = view.CalcHitInfo(pt);
            if (hitInfo.ItemInfo != null)
            {
                TileItemElementViewInfo elementInfo = hitInfo.ItemInfo.Elements.FirstOrDefault(t => t.EntireElementBounds.Contains(pt));
                if (elementInfo != null)
                {
                    string text = elementInfo.Element.Text;
                    XtraMessageBox.Show(text);
                }
            }*/
            try
            {
                int vIdProducto = Convert.ToInt32(view.GetFocusedRowCellValue("id") ?? 0);
                int vIdBodega = Convert.ToInt32(tileViewBodega.GetFocusedRowCellValue("id"));
                decimal vStock = Convert.ToDecimal(view.GetFocusedRowCellValue("stock") ?? 0.00M);

                if (vStock <= 0.00M) return;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if ((int)dt.Rows[i][1] == vIdProducto && (int)dt.Rows[i][0] == vIdBodega)
                    {
                        decimal vCantidad = (decimal)dt.Rows[i][3];
                        if (vCantidad == vStock) { viewDetalle.FocusedRowHandle = i; return; }
                        dt.Rows[i][3] = vCantidad + 1;
                        viewDetalle.FocusedRowHandle = i;
                        return;
                    }
                }

                /*var query = Negocio.ClasesCN.CatalogosCN.Producto_Cargar().Where(x => x.id == vIdProducto).FirstOrDefault();
                DataRow row = dt.NewRow();
                if (query != null) 
                {
                    row["id_bodega"] = Convert.ToInt32(tileViewBodega.GetFocusedRowCellValue("id"));
                    row["id_producto"] = query.id;
                    row["descripcion"] = query.descripcion;
                    row["cantidad"] = 1.00;
                    row["id_unidad_medida"] = query.id_unidad_medida;
                    row["precio1"] = query.precio1;
                    row["descuento"] = query.descuento;
                    row["impuesto"] = query.impuesto;
                    dt.Rows.Add(row);
                    row = dt.NewRow();
                }
                bindingSourceDetalle.DataSource = dt;
                viewDetalle.MoveLast();
                viewDetalle.BestFitColumns();*/


                #region Otra
                var query = Negocio.ClasesCN.CatalogosCN.Producto_Cargar_Fila(vIdProducto).FirstOrDefault();
                if (query != null)
                {
                    viewDetalle.AddNewRow();
                    int rowHandler = viewDetalle.GetRowHandle(viewDetalle.DataRowCount);

                    if (viewDetalle.IsNewItemRow(rowHandler))
                    {
                        viewDetalle.SetRowCellValue(rowHandler, "id_bodega", Convert.ToInt32(tileViewBodega.GetFocusedRowCellValue("id")));
                        viewDetalle.SetRowCellValue(rowHandler, "id_producto", query.id);
                        viewDetalle.SetRowCellValue(rowHandler, "descripcion", query.descripcion);
                        viewDetalle.SetRowCellValue(rowHandler, "cantidad", 1.00M);
                        viewDetalle.SetRowCellValue(rowHandler, "id_unidad_medida", query.id_unidad_medida);
                        viewDetalle.SetRowCellValue(rowHandler, "precio1", query.precio1);
                        viewDetalle.SetRowCellValue(rowHandler, "descuento", query.descuento);
                        viewDetalle.SetRowCellValue(rowHandler, "impuesto", query.impuesto);
                    }
                }
                #endregion
                viewDetalle.MoveLast();
                viewDetalle.BestFitColumns();
            }
            catch (Exception) { }
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

                case "descuento":
                    if ((Convert.ToInt32(e.Value) < 0))
                        e.Valid = false;
                    break;

                case "impuesto":
                    if ((Convert.ToInt32(e.Value) < 0))
                        e.Valid = false;
                    break;

                case "precio1":
                    if ((Convert.ToInt32(e.Value) < 0))
                        e.Valid = false;
                    break;
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
                    e.ErrorText = "Cantidad no puede ser menor a 0 o mayor a 1,000,000";
                    //view.HideEditor();
                    break;

                case "descuento":
                    e.ExceptionMode = ExceptionMode.DisplayError;
                    e.WindowCaption = "Error en el valor ingresado";
                    e.ErrorText = "Descuento no puede ser menor a 0";
                    //view.HideEditor();
                    break;

                case "impuesto":
                    e.ExceptionMode = ExceptionMode.DisplayError;
                    e.WindowCaption = "Error en el valor ingresado";
                    e.ErrorText = "Impuesto no puede ser menor a 0";
                    //view.HideEditor();
                    break;

                case "precio1":
                    e.ExceptionMode = ExceptionMode.DisplayError;
                    e.WindowCaption = "Error en el valor ingresado";
                    e.ErrorText = "Precio no puede ser menor a 0";
                    //view.HideEditor();
                    break;
            }
        }

        private void viewDetalle_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            GridView view = sender as GridView;

            try
            {
                var vIdBodega = view.GetFocusedRowCellValue("id_bodega").Equals(DBNull.Value) ? 0 : Convert.ToInt32(view.GetFocusedRowCellValue("id_bodega"));
                if (vIdBodega == 0) { e.Valid = false; view.SetColumnError(colBodega, "Campo requerido"); view.FocusedColumn = colBodega; }

                var vIdProducto = view.GetFocusedRowCellValue("id_producto").Equals(DBNull.Value) ? 0 : Convert.ToInt32(view.GetFocusedRowCellValue("id_producto"));
                if (vIdProducto == 0) { e.Valid = false; view.SetColumnError(colID, "Campo requerido"); view.FocusedColumn = colID; }

                var vCantidad = view.GetFocusedRowCellValue("cantidad").Equals(DBNull.Value) ? "" : Convert.ToString(view.GetFocusedRowCellValue("cantidad"));
                if (string.IsNullOrEmpty(vCantidad)) { e.Valid = false; view.SetColumnError(colCantidad, "Campo requerido"); view.FocusedColumn = colCantidad; }
                else
                {
                    var query = Negocio.ClasesCN.InventarioCN.Kardex_SelectFila(vIdProducto, vIdBodega).FirstOrDefault().saldo_actual;

                    if (Convert.ToDecimal(vCantidad) > query) { e.Valid = false; view.SetColumnError(colCantidad, "Cantidad no puede ser mayor a existencia"); view.FocusedColumn = colCantidad; }
                }

                var vPrecio = view.GetFocusedRowCellValue("precio1").Equals(DBNull.Value) ? "" : Convert.ToString(view.GetFocusedRowCellValue("precio1"));
                if (string.IsNullOrEmpty(vPrecio)) { e.Valid = false; view.SetColumnError(colPrecio, "Campo requerido"); view.FocusedColumn = colPrecio; }

                var vImpuesto = view.GetFocusedRowCellValue("impuesto").Equals(DBNull.Value) ? "" : Convert.ToString(view.GetFocusedRowCellValue("impuesto"));
                if (string.IsNullOrEmpty(vImpuesto)) { e.Valid = false; view.SetColumnError(colImpuesto, "Campo requerido"); view.FocusedColumn = colImpuesto; }

                var vDescuento = view.GetFocusedRowCellValue("descuento").Equals(DBNull.Value) ? "" : Convert.ToString(view.GetFocusedRowCellValue("descuento"));
                if (string.IsNullOrEmpty(vDescuento)) { e.Valid = false; view.SetColumnError(colDescuento, "Campo requerido"); view.FocusedColumn = colDescuento; }
            }
            catch (Exception)
            {
                e.Valid = false;
            }
        }

        private void viewDetalle_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
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
                    if (view.RowCount <= 0) return;
                    dt.Rows.RemoveAt(view.FocusedRowHandle);
                    bindingSourceDetalle.DataSource = dt;
                    viewDetalle.MoveLast();
                    viewDetalle.BestFitColumns();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error :" + ex.Message);
            }
        }

        private void btnQuitarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                if (viewDetalle.RowCount <= 0) return;
                dt.Rows.RemoveAt(viewDetalle.FocusedRowHandle);
                bindingSourceDetalle.DataSource = dt;
                viewDetalle.MoveLast();
                viewDetalle.BestFitColumns();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error :" + ex.Message);
            }
        }

        DXErrorProvider dXError = new DXErrorProvider();
        bool Validar()
        {
            bool retorno = false;

            dXError.ClearErrors(); dXError.Dispose();
            /*if (string.IsNullOrEmpty(txtNumeroFactura.Text.Trim().Replace(" ", "")))
            {
                dXError.SetError(txtNumeroFactura, "Campo requerido");
                txtNumeroFactura.Focus();
            }
            else */
            if (lookUpEdit_Cliente.EditValue == null)
            {
                dXError.SetError(lookUpEdit_Cliente, "Campo requerido");
                lookUpEdit_Cliente.Focus();
            }
            if (lookUpEdit_Terminos.EditValue == null)
            {
                dXError.SetError(lookUpEdit_Terminos, "Campo requerido");
                lookUpEdit_Terminos.Focus();
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
            if (!Validar()) return;
            Clases.MyMessageBox.MessageFont = new Font(Clases.MyMessageBox.MessageFont.FontFamily, 24);
            if (Clases.MyMessageBox.Show("¿Desea Guardar esta Orden?", "Venta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            int vEmpleado = Clases.UsuarioLogueado.vID_Empleado;
            int vNumeroFactura = 0;// Convert.ToInt32(txtNumeroFactura.Text ?? "0.00");
            int vCliente = Convert.ToInt32(lookUpEdit_Cliente.EditValue);
            DateTime vFecha = Convert.ToDateTime(dateFecha.EditValue);
            DateTime vFechaEstimada = Convert.ToDateTime(dateFechaEstimada.EditValue);
            decimal vTipoCambio = 0.00M;
            string vObservacion = txtObservacion.Text.Trim();
            string vPersonaReferencia = lookUpEdit_Cliente.Text;
            int vIdTermino = Convert.ToInt32(lookUpEdit_Terminos.EditValue);

            var VentaOK = Negocio.ClasesCN.VentasCN.Venta_Guardar(vEmpleado, vEmpleado, vNumeroFactura, vCliente, vFecha, vFechaEstimada, vTipoCambio, vObservacion, 1, vIdTermino, vPersonaReferencia, viewDetalle, viewPago,"N/A",2,0,0,67, 0.00M, 0.00M);
            if (VentaOK.Item1)
            {
                //txtNumeroFactura.Text = VentaOK.Item3;
                Clases.MyMessageBox.Show("Guardada Correctamente", "Venta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (Opcion == 1)
                {
                    //btnLimpiar_ItemClick(null, null);
                    Limpiar();
                }
                else if (Opcion == 2)
                {
                    BindingSource source = new BindingSource();
                    source.DataSource = Negocio.ClasesCN.VentasCN.Venta_Reporte(VentaOK.Item2);
                    var report = new Reportes.Ventas.Factura(source);
                    report.ShowPreviewDialog();
                    //btnLimpiar_ItemClick(null, null);
                    Limpiar();
                }
            }
        }

        void Limpiar()
        {
            lookUpEdit_Cliente.EditValue = null;
            lookUpEdit_Terminos.EditValue = null;
            //txtNumeroFactura.Text = string.Empty;
            txtObservacion.Text = string.Empty;
            dateFecha.EditValue = DateTime.Now;
            dateFechaEstimada.EditValue = DateTime.Now;
            dt.Clear();
            bindingSourceDetalle.DataSource = dt;
        }

        private void btntGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //viewDetalle.CloseEditor();
                //viewDetalle.UpdateCurrentRow();
                //var form = new xfrm_FormaPagoVenta();
                //form.vTotal = Convert.ToDecimal(viewDetalle.Columns["total"].SummaryItem.SummaryValue);
                //form.iforma = this;
                //form.ShowDialog();
                //if (viewPago == null) return;
                //if (viewPago.RowCount > 0) GuardarOrden(1);
            }
            catch (Exception) { }
        }

        public bool getVenta(List<Entidades.Venta> xVenta)
        {
            var query = xVenta.FirstOrDefault();
            if (query != null)
            {
                //txtNumeroFactura.Text = query.numero;
                lookUpEdit_Cliente.EditValue = query.id_cliente;
                dateFecha.EditValue = query.fecha;
                dateFechaEstimada.EditValue = query.fecha_maxima;
                txtObservacion.Text = query.observacion;
                lookUpEdit_Terminos.EditValue = query.id_termino;

                return true;
            }
            else { return false; }
        }

        public void getDetalleVenta(DataTable xDetalleVenta)
        {
            gridVenta.DataSource = xDetalleVenta;
        }

        private GridView viewPago;
        public bool FormaPago(GridView view)
        {
            viewPago = view;
            if (viewPago.RowCount > 0) return true;
            else return false;
        }
    }
}