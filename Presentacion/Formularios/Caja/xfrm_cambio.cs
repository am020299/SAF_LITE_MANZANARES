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
using DevExpress.XtraEditors.DXErrorProvider;
using Presentacion.Formularios.Ventas;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Tile;
using DevExpress.XtraReports.UI;

namespace Presentacion.Formularios.Caja
{
    public partial class xfrm_cambio : DevExpress.XtraEditors.XtraForm
    {
        private int _vTipoVenta;
        private decimal _vTipoCambio;
        public int _vIdCliente;
        DataTable dt;
        decimal sub_total, descuento_total, iva, total;
        private decimal vExist = 0.00M;
        decimal suma_total_factura = 0;
        decimal suma_total_devolucion = 0;
        decimal diferencia = 0;
        public xfrm_cambio()
        {
            InitializeComponent();
            dateFecha.EditValue = DateTime.Now;
            dateFechaEstimada.EditValue = DateTime.Now;
        }
        public decimal vTipoCambio { get => _vTipoCambio; set => _vTipoCambio = value; }
        private void calculos_diferencia_entregar()
        {
            try
            {
                suma_total_factura = 0;
                suma_total_devolucion = 0;
                diferencia = 0;
                sub_total = 0; descuento_total = 0; iva = 0; total = 0;
                for (int i = 0; i < viewDetalle.RowCount; i++)
                {
                    decimal precio = Convert.ToDecimal(viewDetalle.GetRowCellValue(i, "precio1"));
                    decimal cantidad = Convert.ToDecimal(viewDetalle.GetRowCellValue(i, "cantidad"));
                    decimal descuento = Convert.ToDecimal(viewDetalle.GetRowCellValue(i, "descuento"));
                    decimal impuesto = Convert.ToDecimal(viewDetalle.GetRowCellValue(i, "impuesto"));
                    sub_total += (Math.Round((precio * cantidad), 2, MidpointRounding.AwayFromZero));
                    //descuento_total += ((precio * cantidad) * (descuento / 100));
                    //iva += (((precio * cantidad) - ((precio * cantidad) * (descuento / 100))) * (impuesto / 100));
                }
                suma_total_factura = (sub_total - descuento_total + iva);
                for (int i = 0; i < viewDetalle_Ajuste.RowCount; i++)
                {
                    decimal precio = Convert.ToDecimal(viewDetalle_Ajuste.GetRowCellValue(i, "precio"));
                    decimal cantidad = Convert.ToDecimal(viewDetalle_Ajuste.GetRowCellValue(i, "cantidad"));
                    suma_total_devolucion += (Math.Round((precio * cantidad), 2, MidpointRounding.AwayFromZero));
                }
                if (viewDetalle.RowCount > 0 && viewDetalle_Ajuste.RowCount > 0)
                {
                    if ((suma_total_factura > suma_total_devolucion) || (suma_total_factura == suma_total_devolucion))
                    {
                        diferencia = suma_total_factura - suma_total_devolucion;
                        gridFormaPago.Enabled = true;
                        txt_diferencia.EditValue = (suma_total_factura - suma_total_devolucion).ToString("n2");
                        txt_diferencia_dolar.EditValue = (Math.Round((suma_total_factura - suma_total_devolucion) / vTipoCambio, 2, MidpointRounding.AwayFromZero)).ToString("n2");
                    }
                    else
                    {
                        gridFormaPago.Enabled = false;
                        txt_diferencia.EditValue = txt_diferencia_dolar.EditValue = 0.00;
                        diferencia = 0;
                    }
                }
                else
                    gridFormaPago.Enabled = false;

                bindingSourceDetalleFormaPago.DataSource = null;
                bindingSourceDetalleFormaPago.DataSource = getTable_forma_pago();
                txt_total_recibir.EditValue = txt_diferencia_faltante.EditValue = 0.00;
                bbi_guardar.Enabled = false;
            }
            catch (Exception)
            { }
        }
        public bool getVenta(List<Entidades.Venta> xVenta)
        {
            var query = xVenta.FirstOrDefault();
            if (query != null)
            {
                txtNumeroFactura.Text = query.numero;
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
   
        bool ProductoExiste(int vIdProducto, int vIdBodega, GridView view)
        {
            bool retorno = false;
            for (int i = 0; i < view.RowCount; i++)
            {
                int focus = view.FocusedRowHandle;
                if (i == focus) continue;
                int Producto = Convert.ToInt32(view.GetRowCellValue(i, "id_producto"));
                int Bodega = Convert.ToInt32(view.GetRowCellValue(i, "id_bodega"));
                if (vIdProducto == Producto && vIdBodega == Bodega) { retorno = true; break; }
            }
            return retorno;
        }
        private DataTable getTable_forma_pago()
        {
            DataTable dtf = new DataTable();
            dtf.Columns.Add("id_forma_pago", typeof(int));
            dtf.Columns.Add("monto", typeof(decimal));
            dtf.Columns.Add("moneda", typeof(int));
            dtf.Columns.Add("tipo_cambio", typeof(decimal));
            return dtf;
        }
        private DataTable getTable()
        {
            dt = new DataTable();
            dt.Columns.Add("id_bodega", typeof(int));
            dt.Columns.Add("id_producto", typeof(int));
            dt.Columns.Add("descripcion", typeof(string));
            dt.Columns.Add("cantidad", typeof(decimal));
            dt.Columns.Add("id_unidad_medida", typeof(int));
            dt.Columns.Add("tipo_precio", typeof(int));
            dt.Columns.Add("precio1", typeof(decimal));
            dt.Columns.Add("descuento", typeof(decimal));
            dt.Columns.Add("impuesto", typeof(decimal));

            return dt;
        }
        private DataTable getTable_ajuste()
        {
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("id_bodega", typeof(int));
            dt2.Columns.Add("id_producto", typeof(int));
            dt2.Columns.Add("descripcion", typeof(string));
            dt2.Columns.Add("cantidad", typeof(decimal));
            dt2.Columns.Add("precio", typeof(decimal));
            dt2.Columns.Add("id_unidad_medida", typeof(int));

            return dt2;
        }
        private void cargar_forma_pago()
        {
            bindingSourceDetalleFormaPago.DataSource = null;
            bindingSourceDetalleFormaPago.DataSource = getTable_forma_pago();
            bindingSourceFormaPago.DataSource = Negocio.ClasesCN.VentasCN.FormaPago_Select();
            repositoryItemLookUpEdit_Moneda.DataSource = Negocio.ClasesCN.CatalogosCN.getMoneda();
        }
        private void cargar_datos_factura()
        {
            bindingSourceCliente.DataSource = Negocio.ClasesCN.CatalogosCN.Cliente_Cargar();
            lookUpEdit_Terminos.Properties.DataSource = Negocio.ClasesCN.ParametrosCN.Terminos_Select();
            lookUpEdit_Terminos.EditValue = Negocio.ClasesCN.ParametrosCN.Terminos_Select().Min(x => x.id);
            lookUpEdit_Vendedor.Properties.DataSource = Negocio.ClasesCN.CatalogosCN.Empleado_Cargar().ToList();
            lookUpEdit_Vendedor.EditValue = Clases.UsuarioLogueado.vID_Empleado;
            bindingSourceDetalle_fp.DataSource = getTable();
            repositoryItemLookUpEdit_Bodega.DataSource = repositoryItemLookUpEdit_Bodega_ajuste.DataSource = lookUpEdit_Bodega.Properties.DataSource = Negocio.ClasesCN.CatalogosCN.Bodega_Cargar();
            lookUpEdit_Bodega.EditValue = Negocio.ClasesCN.CatalogosCN.Bodega_Cargar().Min(x => x.id);
            bindingSourceProducto.DataSource = Negocio.ClasesCN.InventarioCN.Kardex_SelectVenta().Where(x => x.id_bodega == int.Parse(lookUpEdit_Bodega.EditValue.ToString())).ToList();
            repositoryItemLookUpEdit_UnidadMedida.DataSource = repositoryItemLookUpEdit_UnidadMedida_ajuste.DataSource = Negocio.ClasesCN.CatalogosCN.UnidadMedida_Cargar();
            layoutControlItemMostrar.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            vTipoCambio = Negocio.ClasesCN.DatosRequeridosCN.obtener_tipo_cambio_mensual();
            txt_tipo_cambio_mes.EditValue = vTipoCambio;
            colBodega.Visible = toggleSwitch1.IsOn;
        }
        private void cargar_datos_ajustes()
        {
            lookUpEdit_Ajuste.Properties.DataSource = Negocio.ClasesCN.CatalogosCN.TipoAjuste().Where(o=>o.tipo_movimiento==1).ToList();
            bindingSourceDetalle.DataSource = getTable_ajuste();
            repositorio_search_producto.DataSource = Negocio.ClasesCN.CatalogosCN.Producto_Cargar();
        }
        private void calculo_total()
        {
            sub_total = 0; descuento_total = 0; iva = 0; total = 0;
            for (int i = 0; i < viewDetalle.RowCount; i++)
            {
                decimal precio = Convert.ToDecimal(viewDetalle.GetRowCellValue(i, "precio1"));
                decimal cantidad = Convert.ToDecimal(viewDetalle.GetRowCellValue(i, "cantidad"));
                decimal descuento = Convert.ToDecimal(viewDetalle.GetRowCellValue(i, "descuento"));
                decimal impuesto = Convert.ToDecimal(viewDetalle.GetRowCellValue(i, "impuesto"));
                sub_total += (precio * cantidad);
                descuento_total += ((precio * cantidad) * (descuento / 100));
                iva += (((precio * cantidad) - ((precio * cantidad) * (descuento / 100))) * (impuesto / 100));
            }
            total = (sub_total - descuento_total + iva);
            total = total * vTipoCambio;
            //txt_total.Text = total.ToString("n2");
            //total = 0;
            //total= dt.AsEnumerable().Sum(row => row.Field<decimal>("total"));//  Decimal.Round(Convert.ToDecimal(viewDetalle.Columns["total"].SummaryItem.SummaryValue), 2);
            //total = total * vTipoCambio;
            //txt_total.Text = total.ToString("n2");

        }
        private void xfrm_cambio_Load(object sender, EventArgs e)
        {
            cargar_datos_factura();
            cargar_datos_ajustes();
            cargar_forma_pago();
        }
        private void xfrm_cambio_Activated(object sender, EventArgs e)
        {}
        private void toggleSwitch1_Toggled(object sender, EventArgs e)
        {
            colBodega.Visible = toggleSwitch1.IsOn;
        }
        private void lookUpEdit_Cliente_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Tag.ToString() == "2")
            {
                int count = Negocio.ClasesCN.CatalogosCN.getCliente().Count;
                var form = new xfrm_NuevoCliente();
                form.ShowDialog();
                int count_nuevo = Negocio.ClasesCN.CatalogosCN.getCliente().Count;
                bindingSourceCliente.DataSource = Negocio.ClasesCN.CatalogosCN.Cliente_Cargar();
                if (count != count_nuevo)
                {
                    int max = Negocio.ClasesCN.CatalogosCN.getCliente().Max(x => x.id);
                    lookUpEdit_Cliente.EditValue = max;
                }
            }
        }
        private void lookUpEdit_Cliente_EditValueChanged(object sender, EventArgs e)
        {}
        private void lookUpEdit_Bodega_EditValueChanged(object sender, EventArgs e)
        {
            if (viewDetalle.RowCount == 0)
            {
                //if (vTipoVenta == 1)
                bindingSourceProducto.DataSource = Negocio.ClasesCN.InventarioCN.Kardex_SelectVenta().Where(x => x.id_bodega == int.Parse(lookUpEdit_Bodega.EditValue.ToString())).ToList();
                //else
                //    bindingSourceProducto.DataSource = Negocio.ClasesCN.CatalogosCN.Producto_Cargar().ToList();
                repositoryItemSearchLookUpEdit1View.BestFitColumns();
            }
        }
        private void repositoryItemLookUpEdit_Bodega_EditValueChanged(object sender, EventArgs e)
        {
            object value = (sender as LookUpEdit).EditValue;

            var vIdProducto = viewDetalle.GetFocusedRowCellValue("id_producto").Equals(DBNull.Value) ? 0 : Convert.ToInt32(viewDetalle.GetFocusedRowCellValue("id_producto"));
            if (vIdProducto == 0)
            {
                //repositoryItemLookUpEdit_Producto.DataSource = Negocio.ClasesCN.InventarioCN.Kardex_SelectVenta().Where(x => x.id_bodega == int.Parse(value.ToString())).ToList();
                bindingSourceProducto.DataSource = Negocio.ClasesCN.InventarioCN.Kardex_SelectVenta().Where(x => x.id_bodega == int.Parse(value.ToString())).ToList();
            }
            else
            {
                //repositoryItemLookUpEdit_Producto.DataSource = Negocio.ClasesCN.InventarioCN.Kardex_SelectVenta().Where(x => x.id_bodega == int.Parse(value.ToString())).ToList();
                bindingSourceProducto.DataSource = Negocio.ClasesCN.InventarioCN.Kardex_SelectVenta().Where(x => x.id_bodega == int.Parse(value.ToString())).ToList();
                var query = Negocio.ClasesCN.InventarioCN.Kardex_SelectVenta().Where(x => x.id_bodega == int.Parse(value.ToString()) && x.id == vIdProducto).FirstOrDefault();
                if (query == null)
                {
                    viewDetalle.SetFocusedRowCellValue("id_producto", null);
                    viewDetalle.SetFocusedRowCellValue("descripcion", "");
                }
            }
            lookUpEdit_Bodega.EditValue = value;
        }
        private void repositorio_cmbx_precios_EditValueChanged(object sender, EventArgs e)
        {
            ImageComboBoxEdit edit = (ImageComboBoxEdit)sender;
            object editValue = edit.EditValue;
            int tipo = Convert.ToInt32(editValue);
            int id_producto = Convert.ToInt32(viewDetalle.GetFocusedRowCellValue("id_producto"));
            decimal precio = Negocio.ClasesCN.InventarioCN.Precio_De_Producto(tipo, id_producto);
            var query = Negocio.ClasesCN.CatalogosCN.Producto_Cargar_Fila(id_producto).FirstOrDefault();
            int moneda = Convert.ToInt32(query.moneda);
            if (moneda == 2)
                precio = precio * Convert.ToDecimal(txt_tipo_cambio_mes.EditValue);
            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle, "precio1", precio);
        }

        DXErrorProvider dXError = new DXErrorProvider();
        private void repositoryItemSearchLookUpEdit_Producto_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                object value = (sender as SearchLookUpEdit).EditValue;
                var query = Negocio.ClasesCN.CatalogosCN.Producto_Cargar_Fila(int.Parse(value.ToString())).FirstOrDefault();
                if (query != null)
                {
                    int moneda = Convert.ToInt32(query.moneda);
                    viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle, "tipo_precio", 4);
                    viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle, "cantidad", 1.00);
                    viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle, "id_unidad_medida", query.id_unidad_medida);
                    viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle, "descripcion", query.descripcion);
                    decimal precio = Convert.ToDecimal(query.precio4);
                    if (moneda == 2)
                        precio = precio * Convert.ToDecimal(txt_tipo_cambio_mes.EditValue);
                    viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle, "precio1", precio);
                    viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle, "descuento", query.descuento);
                    viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle, "impuesto", query.impuesto);
                }
            }
            catch (Exception) { }
        }
        private void viewDetalle_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            try
            {
                bindingSourceProducto.DataSource = Negocio.ClasesCN.InventarioCN.Kardex_SelectVenta().Where(x => x.id_bodega == int.Parse(lookUpEdit_Bodega.EditValue.ToString())).ToList();
                viewDetalle.SetFocusedRowCellValue("id_bodega", lookUpEdit_Bodega.EditValue);
            }
            catch (Exception)
            {
                viewDetalle.SetFocusedRowCellValue("id_bodega", Negocio.ClasesCN.CatalogosCN.Bodega_Cargar().Min(x => x.id));
            }
        }
        private void viewDetalle_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            GridView view = sender as GridView;

            try
            {
                switch (view.FocusedColumn.FieldName)
                {
                    case "cantidad":
                        int bodega = view.GetFocusedRowCellValue("id_bodega").Equals(DBNull.Value) ? 0 : Convert.ToInt32(view.GetFocusedRowCellValue("id_bodega"));
                        int producto = view.GetFocusedRowCellValue("id_producto").Equals(DBNull.Value) ? 0 : Convert.ToInt32(view.GetFocusedRowCellValue("id_producto"));
                        var query = Negocio.ClasesCN.InventarioCN.Kardex_SelectFila(producto, bodega).FirstOrDefault();
                        vExist = decimal.Parse(query.saldo_actual.ToString());
                        if (query.tipo_producto == true)
                        {
                            if ((Convert.ToDecimal(e.Value) <= 0.00m) || (Convert.ToDecimal(e.Value) > query.saldo_actual))
                                e.Valid = false;
                        }
                        break;
                    case "descuento":
                        if ((Convert.ToDecimal(e.Value) <= 0.00m))
                            e.Valid = false;
                        break;

                    case "impuesto":
                        if ((Convert.ToDecimal(e.Value) <= 0.00m))
                            e.Valid = false;
                        break;

                    case "precio1":
                        if ((Convert.ToDecimal(e.Value) <= 0.00m))
                            e.Valid = false;
                        break;

                        //case "id_producto":
                        //    if (ProductoExiste(Convert.ToInt32(e.Value), view))
                        //        e.Valid = false;
                        //    break;
                }
            }
            catch (Exception) { e.Valid = false; }
        }
        private void viewDetalle_InvalidValueException(object sender, DevExpress.XtraEditors.Controls.InvalidValueExceptionEventArgs e)
        {
            GridView view = sender as GridView;

            switch (view.FocusedColumn.FieldName)
            {
                case "cantidad":
                    e.ExceptionMode = ExceptionMode.DisplayError;
                    e.WindowCaption = "Error en el valor ingresado";
                    e.ErrorText = "Cantidad no puede ser menor/igual a 0 o mayor a " + String.Format("{0:n2}", vExist);
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
                    e.ErrorText = "Precio no puede ser menor o igual a 0";
                    //view.HideEditor();
                    break;

                case "id_producto":
                    e.ExceptionMode = ExceptionMode.DisplayError;
                    e.WindowCaption = "Error en el valor ingresado";
                    e.ErrorText = "Codigo ya esta agregado";
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
                    int bodega = view.GetFocusedRowCellValue("id_bodega").Equals(DBNull.Value) ? 0 : Convert.ToInt32(view.GetFocusedRowCellValue("id_bodega"));
                    int producto = view.GetFocusedRowCellValue("id_producto").Equals(DBNull.Value) ? 0 : Convert.ToInt32(view.GetFocusedRowCellValue("id_producto"));
                    var query = Negocio.ClasesCN.InventarioCN.Kardex_SelectFila(producto, bodega).FirstOrDefault();

                    if (Convert.ToDecimal(vCantidad) > query.saldo_actual  && query.tipo_producto == true) { e.Valid = false; view.SetColumnError(colCantidad, "Cantidad no puede ser mayor a " + String.Format("{0:n2}", query.saldo_actual)); view.FocusedColumn = colCantidad; }
                }

                var query_costo = Negocio.ClasesCN.CatalogosCN.Producto_Cargar_Fila(vIdProducto).FirstOrDefault().costo;
                var vPrecio = view.GetFocusedRowCellValue("precio1").Equals(DBNull.Value) ? "" : Convert.ToString(view.GetFocusedRowCellValue("precio1"));
                if (string.IsNullOrEmpty(vPrecio)) { e.Valid = false; view.SetColumnError(colPrecio, "Campo requerido"); view.FocusedColumn = colPrecio; }
                else { if (Convert.ToDecimal(vPrecio) < query_costo) { e.Valid = false; view.SetColumnError(colPrecio, "Precio no puede ser menor al costo (" + String.Format("{0:n2}", query_costo) + ")"); view.FocusedColumn = colPrecio; } }
                //else { if (Convert.ToDecimal(vPrecio) <= 0.00M) { e.Valid = false; view.SetColumnError(colPrecio, "Precio no puede ser menor o igual 0"); view.FocusedColumn = colPrecio; } }

                var vImpuesto = view.GetFocusedRowCellValue("impuesto").Equals(DBNull.Value) ? "" : Convert.ToString(view.GetFocusedRowCellValue("impuesto"));
                if (string.IsNullOrEmpty(vImpuesto)) { e.Valid = false; view.SetColumnError(colImpuesto, "Campo requerido"); view.FocusedColumn = colImpuesto; }

                var vDescuento = view.GetFocusedRowCellValue("descuento").Equals(DBNull.Value) ? "" : Convert.ToString(view.GetFocusedRowCellValue("descuento"));
                if (string.IsNullOrEmpty(vDescuento)) { e.Valid = false; view.SetColumnError(colDescuento, "Campo requerido"); view.FocusedColumn = colDescuento; }

                if (ProductoExiste(vIdProducto, vIdBodega, view)) { e.Valid = false; view.SetColumnError(colID, "Codigo ya esta agregado"); view.FocusedColumn = colID; }
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
                    view.DeleteRow(view.FocusedRowHandle);

                    if (viewDetalle.RowCount > 0) { lookUpEdit_Bodega.Enabled = false; layoutControlItemMostrar.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always; }
                    else { lookUpEdit_Bodega.Enabled = true; layoutControlItemMostrar.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never; }
                    calculos_diferencia_entregar();
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error :" + ex.Message);
            }
        }
        private void viewDetalle_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            try
            {
                //viewDetalle.SetFocusedRowCellValue("id_bodega", lookUpEdit_Bodega.EditValue);
                if (viewDetalle.RowCount > 0) { lookUpEdit_Bodega.Enabled = false; layoutControlItemMostrar.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always; }
                else { lookUpEdit_Bodega.Enabled = true; layoutControlItemMostrar.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never; }
                calculos_diferencia_entregar();
            }
            catch (Exception) { }
        }

        //***********************************************************FIN VALIDACION DE FACTURA**************************************************
        //***************************************************************************************************************************************
        private void repositorio_search_producto_EditValueChanged(object sender, EventArgs e)
        {
            object value = (sender as SearchLookUpEdit).EditValue;
            var query = Negocio.ClasesCN.CatalogosCN.Producto_Cargar_Fila(int.Parse(value.ToString())).FirstOrDefault();
            if (query != null)
            {
                int moneda = Convert.ToInt32(query.moneda);
                viewDetalle_Ajuste.SetRowCellValue(viewDetalle_Ajuste.FocusedRowHandle, "cantidad", 1.00M);
                viewDetalle_Ajuste.SetRowCellValue(viewDetalle_Ajuste.FocusedRowHandle, "id_unidad_medida", query.id_unidad_medida);
                viewDetalle_Ajuste.SetRowCellValue(viewDetalle_Ajuste.FocusedRowHandle, "descripcion", query.descripcion);
                decimal precio = Convert.ToDecimal(query.precio4);
                if (moneda == 2)
                    precio = precio * Convert.ToDecimal(txt_tipo_cambio_mes.EditValue);
                viewDetalle_Ajuste.SetRowCellValue(viewDetalle_Ajuste.FocusedRowHandle, "precio", precio);
                viewDetalle_Ajuste.SetRowCellValue(viewDetalle_Ajuste.FocusedRowHandle, "cantidad", 1);
            }
        }
        private void viewDetalle_Ajuste_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete)
                {
                    GridView view = sender as GridView;          
                    view.DeleteRow(view.FocusedRowHandle);
                    calculos_diferencia_entregar();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error :" + ex.Message);
            }
        }
        private void viewDetalle_Ajuste_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            calculos_diferencia_entregar();
        }
        private void viewDetalle_Ajuste_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
            e.WindowCaption = "Error en el valor ingresado";
            e.ErrorText = "Campo requerido";
        }
        //-------------*******************************************************FIN VALIDACION AJUSTE***********************************************-----
        //----------------------**********************************************************************************************-------------------
        private void viewDetalleFormaPago_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            calculos_pago_recibir();
        }
        private void viewDetalleFormaPago_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
        {
            GridView view = sender as GridView;
            try
            {
                switch (view.FocusedColumn.FieldName)
                {
                    case "monto":
                        if ((Convert.ToDecimal(e.Value) < 0))
                            e.Valid = false;
                        break;
                }
            }
            catch (Exception)
            {
                e.Valid = false;
            }
        }
        private void viewDetalleFormaPago_KeyDown(object sender, KeyEventArgs e)
        {
            if (viewDetalleFormaPago.RowCount == 0) return;
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                viewDetalleFormaPago.CloseEditor();
                viewDetalleFormaPago.UpdateCurrentRow();
                SendKeys.Send("{ESC}");
            }

            if (e.KeyCode == Keys.Delete)
            {
                viewDetalleFormaPago.DeleteRow(viewDetalleFormaPago.FocusedRowHandle);
                calculos_pago_recibir();
            }
        }
        private void calculos_pago_recibir()
        {
            decimal total_calculo = 0;
            for (int i = 0; i < viewDetalleFormaPago.RowCount; i++)
            {
                int tipo_moneda = Convert.ToInt32(viewDetalleFormaPago.GetRowCellValue(i, "moneda"));
                decimal cantidad = Convert.ToDecimal(viewDetalleFormaPago.GetRowCellValue(i, "monto"));
                if (tipo_moneda == 2)
                    total_calculo += (Math.Round(cantidad * vTipoCambio, 2, MidpointRounding.AwayFromZero));
                else
                    total_calculo += cantidad;
            }
            //total_recibir = total_calculo;
            txt_total_recibir.Text = total_calculo.ToString("n2");
            if (diferencia != total_calculo)
            {
                bbi_guardar.Enabled = false;
                txt_diferencia_faltante.EditValue = (diferencia - total_calculo).ToString("n2");
            }  
            else if (diferencia == total_calculo)
            {
                bbi_guardar.Enabled = true;
                txt_diferencia_faltante.EditValue = 0.00;
            }          
        }

        private void tileViewFormaPago_ItemClick(object sender, DevExpress.XtraGrid.Views.Tile.TileViewItemClickEventArgs e)
        {
            TileView view = sender as TileView;
            try
            {
                int vIdFormaPago = view.GetFocusedRowCellValue("id").Equals(DBNull.Value) ? 0 : Convert.ToInt32(view.GetFocusedRowCellValue("id"));
                for (int i = 0; i < viewDetalleFormaPago.RowCount; i++)
                {
                    if ((int)viewDetalleFormaPago.GetRowCellValue(i, "id_forma_pago") == vIdFormaPago)
                    {
                        viewDetalleFormaPago.FocusedRowHandle = i;
                        viewDetalleFormaPago.Focus();
                        return;
                    }
                }

                var query = Negocio.ClasesCN.VentasCN.FormaPago_Select().Where(x => x.id == vIdFormaPago).FirstOrDefault();
                if (query != null)
                {
                    viewDetalleFormaPago.AddNewRow();
                    int rowHandler = viewDetalleFormaPago.GetRowHandle(viewDetalleFormaPago.DataRowCount);

                    if (viewDetalleFormaPago.IsNewItemRow(rowHandler))
                    {
                        viewDetalleFormaPago.SetRowCellValue(rowHandler, "id_forma_pago", vIdFormaPago);
                        viewDetalleFormaPago.SetRowCellValue(rowHandler, "monto", 0.00M);
                        viewDetalleFormaPago.SetRowCellValue(rowHandler, "moneda", query.moneda);
                        if (query.moneda == 1) viewDetalleFormaPago.SetRowCellValue(rowHandler, "tipo_cambio", vTipoCambio);
                        else viewDetalleFormaPago.SetRowCellValue(rowHandler, "tipo_cambio", vTipoCambio);
                        viewDetalleFormaPago.FocusedRowHandle = rowHandler;
                    }
                }
                viewDetalleFormaPago.Focus();
            }
            catch (Exception) { }
        }

        private void bbi_limpiar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            lookUpEdit_Cliente.EditValue = null;
            txtNumeroFactura.Text = string.Empty;
            txtObservacion.Text = string.Empty;
            dateFecha.EditValue = DateTime.Now;
            dateFechaEstimada.EditValue = DateTime.Now;
            gridVenta.DataSource = null;
            bindingSourceDetalle_fp.DataSource = null;
            bindingSourceDetalle_fp.DataSource = getTable();
            gridVenta.DataSource = bindingSourceDetalle_fp;
            //bindingSourceProducto.DataSource = null;
            lookUpEdit_Bodega_EditValueChanged(null, null);
            viewDetalle.Focus();
            SendKeys.Send("{ESC}");
            lookUpEdit_Cliente.Focus();
            lookUpEdit_Bodega.Enabled = true;
            layoutControlItemMostrar.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            toggleSwitch1.IsOn = false;

            bindingSourceDetalle.DataSource = null;
            bindingSourceDetalle.DataSource = getTable_ajuste();

            bindingSourceDetalleFormaPago.DataSource = null;
            bindingSourceDetalleFormaPago.DataSource = getTable_forma_pago();
            txt_total_recibir.EditValue = txt_diferencia_faltante.EditValue = 0.00;
            bbi_guardar.Enabled = false;

        }
        private void bbi_guardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {  
                if (!validar()) return;
                int vDias = Negocio.ClasesCN.ParametrosCN.getTerminos().Where(x => x.id == int.Parse(lookUpEdit_Terminos.EditValue.ToString())).FirstOrDefault().dias;
                Clases.MyMessageBox.MessageFont = new Font(Clases.MyMessageBox.MessageFont.FontFamily, 24);
                if (Clases.MyMessageBox.Show("¿Desea Guardar esta Orden?", "Venta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
                GuardarOrden();
            }
            catch (Exception) { }
        }
        void GuardarOrden()
        {
            int vEmpleado = Clases.UsuarioLogueado.vID_Empleado;
            int vNumeroFactura = Convert.ToInt32(txtNumeroFactura.EditValue);
            int vCliente = Convert.ToInt32(lookUpEdit_Cliente.EditValue);
            int vid_tipo_ajuste = Convert.ToInt32(lookUpEdit_Ajuste.EditValue);
            string vPersonaReferencia = lookUpEdit_Cliente.Text;
            DateTime vFecha = Convert.ToDateTime(dateFecha.EditValue);
            DateTime vFechaEstimada = Convert.ToDateTime(dateFechaEstimada.EditValue);
            string vObservacion = txtObservacion.Text.Trim();
            int vIdTermino = Convert.ToInt32(lookUpEdit_Terminos.EditValue);
            int vVendedor = Clases.UsuarioLogueado.vID_Empleado;
            try { vVendedor = Convert.ToInt32(lookUpEdit_Vendedor.EditValue); } catch (Exception) { vVendedor = Clases.UsuarioLogueado.vID_Empleado; }

            DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(typeof(Presentacion.Formularios.Principal.WaitForm1));
            //var VentaOK = Negocio.ClasesCN.CajaCN.VENTA_DEVOLUCION_PAGO(vEmpleado, vVendedor, vNumeroFactura, vCliente, vFecha, vFechaEstimada, vTipoCambio, vObservacion, 1, vIdTermino, vPersonaReferencia, vid_tipo_ajuste, viewDetalle, viewDetalle_Ajuste, viewDetalleFormaPago);
            //if (VentaOK.Item1)
            //{
            //    Clases.MyMessageBox.Show("Guardada Correctamente", "Venta", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    bbi_limpiar_ItemClick(null, null);
            //    BindingSource source = new BindingSource();
            //    source.DataSource = Negocio.ClasesCN.VentasCN.Venta_Reporte(VentaOK.Item2);
            //    var report = new Reportes.Ventas.FacturaTermica(source);
            //    report.ShowPreviewDialog();
            //    report.Dispose();

            //    BindingSource sourcedev = new BindingSource();
            //    sourcedev.DataSource = Negocio.ClasesCN.InventarioCN.Reporte_Ajuste(VentaOK.Item3);
            //    var reportdev = new Reportes.Inventario.xrpt_ajuste(sourcedev);
            //    reportdev.ShowPreviewDialog();
            //}
            //DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm();

        }
        private bool validar()
        {
            bool retorno = false;

            dXError.ClearErrors(); dXError.Dispose();
            if (string.IsNullOrEmpty(txtNumeroFactura.Text.Trim().Replace(" ", "")))
            {
                dXError.SetError(txtNumeroFactura, "Campo requerido");
                txtNumeroFactura.Focus();
            }
            //else 
            else if (lookUpEdit_Cliente.EditValue == null)
            {
                dXError.SetError(lookUpEdit_Cliente, "Campo requerido");
                lookUpEdit_Cliente.Focus();
            }
            else if (lookUpEdit_Ajuste.EditValue == null)
            {
                dXError.SetError(lookUpEdit_Ajuste, "Campo requerido");
                lookUpEdit_Ajuste.Focus();
            }
            else if (lookUpEdit_Terminos.EditValue == null)
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
            else if (txtObservacion.Text.Trim()== string.Empty)
            {
                dXError.SetError(txtObservacion, "Campo requerido");
                txtObservacion.Focus();
            }
            else if (viewDetalle.RowCount == 0)
            {
                XtraMessageBox.Show("No hay detalles que guardar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                viewDetalle.Focus();
            }
            else { retorno = true; }
            return retorno;
        }
    
    }
}