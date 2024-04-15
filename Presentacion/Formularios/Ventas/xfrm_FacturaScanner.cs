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
//using LicenseSpot.Framework;

namespace Presentacion.Formularios.Ventas
{
    public partial class xfrm_FacturaScanner : DevExpress.XtraEditors.XtraForm, IVentas, IProducto
    {
        private decimal _vTipoCambio;
        public int _vIdCliente;

        //private ExtendedLicense license;
        public xfrm_FacturaScanner()
        {
            InitializeComponent();
            dateFecha.EditValue = DateTime.Now;
            dateFechaEstimada.EditValue = DateTime.Now;
        }
        public decimal vTipoCambio { get => _vTipoCambio; set => _vTipoCambio = value; }

        public int vIdCliente { get => _vIdCliente; set => _vIdCliente = value; }

        private void xfrm_NuevaVenta_Load(object sender, EventArgs e)
        {
            try
            {
                getTable();
                lookUpEdit_Terminos.EditValue = Negocio.ClasesCN.ParametrosCN.Terminos_Select().Min(x => x.id);
                lookUpEdit_Cliente.EditValue= Negocio.ClasesCN.CatalogosCN.Cliente_Cargar().Min(x => x.id);
                lookUpEdit_Vendedor.EditValue = Clases.UsuarioLogueado.vID_Empleado;
                lookUpEdit_Bodega.EditValue = Negocio.ClasesCN.CatalogosCN.Bodega_Cargar().Min(x => x.id);
                vTipoCambio = Negocio.ClasesCN.DatosRequeridosCN.Obtener_tipo_cambio_hoy();
                colBodega.Visible = toggleSwitch1.IsOn;
                layoutControlItemMostrar.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
            catch (Exception) { }
        }

        private void xfrm_NuevaVenta_Activated(object sender, EventArgs e)
        {
            bindingSourceCliente.DataSource = Negocio.ClasesCN.CatalogosCN.Cliente_Cargar();
            lookUpEdit_Terminos.Properties.DataSource = Negocio.ClasesCN.ParametrosCN.Terminos_Select();
            lookUpEdit_Bodega.Properties.DataSource = Negocio.ClasesCN.CatalogosCN.Bodega_Cargar();
            lookUpEdit_Vendedor.Properties.DataSource = Negocio.ClasesCN.CatalogosCN.Empleado_Cargar().ToList();
            repositoryItemLookUpEdit_UnidadMedida.DataSource = Negocio.ClasesCN.CatalogosCN.UnidadMedida_Cargar();
            gridVenta.Focus();
            viewDetalle.Focus();
            viewDetalle.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle;
            SendKeys.Send("{ENTER}");
            SendKeys.Send("{ESC}");
        }

        private void xfrm_NuevaVenta_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (viewDetalle.OptionsBehavior.Editable)
                if (viewDetalle.RowCount > 0)
                    e.Cancel = true;
        }

        private void getTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("codigo", typeof(string));
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

        private void lookUpEdit_Cliente_EditValueChanged(object sender, EventArgs e)
        {
            txt_Tel.Text = string.Empty;
            txt_Ruc.Text = string.Empty;
            txt_Dir.Text = string.Empty;
            var query = Negocio.ClasesCN.CatalogosCN.Cliente_Cargar().Where(x => x.id == Convert.ToInt32(lookUpEdit_Cliente.EditValue)).FirstOrDefault();
            if (query != null)
            {
                txt_Tel.Text = query.celular;
                txt_Ruc.Text = query.ruc;
                txt_Dir.Text = query.direccion;
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
            else if (lookUpEdit_Terminos.EditValue == null)
            {
                dXError.SetError(lookUpEdit_Terminos, "Campo requerido");
                lookUpEdit_Terminos.Focus();
            }
            else if (lookUpEdit_Vendedor.EditValue == null)
            {
                dXError.SetError(lookUpEdit_Vendedor, "Campo requerido");
                lookUpEdit_Vendedor.Focus();
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
            int vEmpleado = Clases.UsuarioLogueado.vID_Empleado;
            int vNumeroFactura = 0;// Convert.ToInt32(txtNumeroFactura.Text ?? "0.00");
            int vCliente = Convert.ToInt32(lookUpEdit_Cliente.EditValue);
            DateTime vFecha = Convert.ToDateTime(dateFecha.EditValue);
            DateTime vFechaEstimada = Convert.ToDateTime(dateFechaEstimada.EditValue);
            string vObservacion = txtObservacion.Text.Trim();
            string vPersonaReferencia = lookUpEdit_Cliente.Text;
            int vIdTermino = Convert.ToInt32(lookUpEdit_Terminos.EditValue);
            int vVendedor = Clases.UsuarioLogueado.vID_Empleado;
            try { vVendedor = Convert.ToInt32(lookUpEdit_Vendedor.EditValue); } catch (Exception) { vVendedor = Clases.UsuarioLogueado.vID_Empleado; }


            var VentaOK = Negocio.ClasesCN.VentasCN.Venta_Guardar(vEmpleado, vVendedor, vNumeroFactura, vCliente, vFecha, vFechaEstimada, vTipoCambio, vObservacion, 1, vIdTermino, vPersonaReferencia, viewDetalle, viewPago,"N/A",2,0,3,66,0.00M, 0.00M);
            if (VentaOK.Item1)
            {
                txtNumeroFactura.Text = VentaOK.Item3;
                Clases.MyMessageBox.Show("Guardada Correctamente", "Venta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (Opcion == 1)
                {
                    btnLimpiar_ItemClick(null, null);
                }
                else if (Opcion == 2)
                {
                    BindingSource source = new BindingSource();
                    source.DataSource = Negocio.ClasesCN.VentasCN.Venta_Reporte(VentaOK.Item2);
                    BindingSource source2 = new BindingSource();
                    source2.DataSource = Negocio.ClasesCN.VentasCN.FormaPago_SelectVenta(VentaOK.Item2);
                    //var report = new Reportes.Ventas.Factura(source);
                    //report.ShowPreviewDialog();
                    btnLimpiar_ItemClick(null, null);
                    //---------
                    XtraReport report = new XtraReport();
                    report.CreateDocument();
                    string[] arrCopias = { "Cliente Original", "1ra Copia" };
                    foreach (string list in arrCopias)
                    {
                        XtraReport myReport = new Reportes.Ventas.FacturaTermica(source);
                        myReport.CreateDocument();
                        report.Pages.AddRange(myReport.Pages);
                    }
                    report.Print("POS-58-Series");
                }
            }
        }

        private void btnGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                viewDetalle.CloseEditor();
                viewDetalle.UpdateCurrentRow();
                if (!Validar()) return;
                int vDias = Negocio.ClasesCN.ParametrosCN.getTerminos().Where(x => x.id == int.Parse(lookUpEdit_Terminos.EditValue.ToString())).FirstOrDefault().dias;
                if (vDias <= 0) 
                {
                    //Clases.MyMessageBox.MessageFont = new Font(Clases.MyMessageBox.MessageFont.FontFamily, 24);
                    //if (Clases.MyMessageBox.Show("¿Desea Guardar esta Orden?", "Venta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
                    //var form = new xfrm_FormaPagoVenta();
                    //form.vTotal = Decimal.Round(Convert.ToDecimal(viewDetalle.Columns["total"].SummaryItem.SummaryValue), 2);
                    //form.iVentas = this;
                    //form.ShowDialog();
                    //if (viewPago == null) return;
                    //if (viewPago.RowCount > 0)
                    viewPago = new GridView();
                    GuardarOrden(1);
                }
                else
                {
                    Clases.MyMessageBox.MessageFont = new Font(Clases.MyMessageBox.MessageFont.FontFamily, 24);
                    if (Clases.MyMessageBox.Show("¿Desea Guardar esta Orden?", "Venta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
                    viewPago = new GridView();
                    GuardarOrden(1);
                }
            }
            catch (Exception) { }

            //this.LoadLicense();
            //if (this.license.Validate()) XtraMessageBox.Show("VALID");
            //else XtraMessageBox.Show("IN-VALID");
        }

        //private void LoadLicense()
        //{
        //    this.license = ExtendedLicenseManager.GetLicense(typeof(xfrm_FacturaScanner), this, "<RSAKeyValue><Modulus>ppjTVBp9km/KpdR/r5DSQn4j6xwlchHzYi5EksZQaPHUF4bG2dq5TETZU0L4J1fTIMBe7fBlizEd5rBnwZAPpvjqjbr8Wuvvek7ZfbkuVJ5u6b6CBosypOjAEzU5n12jjlg31VglgFSyFZ9jNXS69qR90MqIx9YExuY8aux7g+ixZvDoWbQehXok/C/GaekMviRr9NhJNF2hPWJZfaONsV+aGbXJTZmvI9S1kMMDofKsjo9NtNrwsNPblGXAaagt3Io9F+M4FyKr1vLO7p5n33y2ZLITBOMb+eqUFgLXydqQCgU3tiECMI4zf2fpx/cA64HrYmRjCrUDB+fSWh50bw==</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>");
        //}

        private void btnGuardarImprimir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                viewDetalle.CloseEditor();
                viewDetalle.UpdateCurrentRow();
                if (!Validar()) return;
                int vDias = Negocio.ClasesCN.ParametrosCN.getTerminos().Where(x => x.id == int.Parse(lookUpEdit_Terminos.EditValue.ToString())).FirstOrDefault().dias;
                if (vDias <= 0) 
                {
                    //Clases.MyMessageBox.MessageFont = new Font(Clases.MyMessageBox.MessageFont.FontFamily, 24);
                    //if (Clases.MyMessageBox.Show("¿Desea Guardar esta Orden?", "Venta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
                    //var form = new xfrm_FormaPagoVenta();
                    //form.vTotal = Decimal.Round(Convert.ToDecimal(viewDetalle.Columns["total"].SummaryItem.SummaryValue), 2);
                    //form.iVentas = this;
                    //form.ShowDialog();
                    //if (viewPago == null) return;
                    //if (viewPago.RowCount > 0)
                    viewPago = new GridView();
                    GuardarOrden(2);
                }
                else
                {
                    Clases.MyMessageBox.MessageFont = new Font(Clases.MyMessageBox.MessageFont.FontFamily, 24);
                    if (Clases.MyMessageBox.Show("¿Desea Guardar esta Orden?", "Venta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
                    viewPago = new GridView();
                    GuardarOrden(2);
                }
            }
            catch (Exception) { }

            //ExtendedLicenseManager.SaveNewFile(this.license.Activate("5187-9FBF-620D-4B77-9D23-D39A-B46B"));
            //XtraMessageBox.Show("ACTIVATED");
            //this.LoadLicense();
        }

        private void btnLimpiar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            lookUpEdit_Terminos.EditValue = Negocio.ClasesCN.ParametrosCN.Terminos_Select().Min(x => x.id);
            lookUpEdit_Cliente.EditValue = Negocio.ClasesCN.CatalogosCN.Cliente_Cargar().Min(x => x.id);
            lookUpEdit_Vendedor.EditValue = Clases.UsuarioLogueado.vID_Empleado;
            lookUpEdit_Bodega.EditValue = Negocio.ClasesCN.CatalogosCN.Bodega_Cargar().Min(x => x.id);
            txtNumeroFactura.Text = string.Empty;
            txtObservacion.Text = string.Empty;
            dateFecha.EditValue = DateTime.Now;
            dateFechaEstimada.EditValue = DateTime.Now;
            listDetalle.Clear();
            RefrescarDetalle();
            viewPago = null;
            viewDetalle.Focus();
            SendKeys.Send("{ESC}");
            lookUpEdit_Bodega.Enabled = true;
            txtDescuentoMonto.EditValue = null;
            txtDescuentoPorcentaje.EditValue = null;
            gridVenta.Focus();
            viewDetalle.Focus();
            viewDetalle.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle;
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

        private GridView viewPago;
        public bool FormaPago(GridView view)
        {
            viewPago = view;
            if (viewPago.RowCount > 0) return true;
            else return false;
        }

        private void lookUpEdit_Cliente_Properties_ButtonClick(object sender, ButtonPressedEventArgs e)
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

        private void toggleSwitch1_Toggled(object sender, EventArgs e)
        {
            colBodega.Visible = toggleSwitch1.IsOn;
            //colBodega.OptionsColumn.AllowFocus = toggleSwitch1.IsOn;
        }

        private void txtDescuentoPorcentaje_Validated(object sender, EventArgs e)
        {
            try
            {
                var monto = viewDetalle.Columns["precio1"].SummaryItem.SummaryValue;
                for (int i = 0; i < viewDetalle.RowCount; i++)
                {
                    viewDetalle.SetRowCellValue(i, "descuento", txtDescuentoPorcentaje.EditValue);
                    viewDetalle.UpdateCurrentRow();
                }
                if (monto == null) txtDescuentoMonto.EditValue = 0.00M;
                else
                {
                    txtDescuentoMonto.EditValue = viewDetalle.Columns["descuento"].SummaryItem.SummaryValue;
                }
                RefrescarDetalle();
            }
            catch (Exception)
            {

            }
        }

        private void txtDescuentoPorcentaje_KeyPress(object sender, KeyPressEventArgs e)
        {
            string cadena = "1234567890." + (Char)8;

            if (!cadena.Contains(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtDescuentoMonto_Validated(object sender, EventArgs e)
        {
            try
            {
                var monto = viewDetalle.Columns["precio1"].SummaryItem.SummaryValue;
                var vDescuento = txtDescuentoMonto.EditValue;
                txtDescuentoPorcentaje.EditValue = (decimal.Parse(vDescuento.ToString()) / decimal.Parse(monto.ToString())) * 100;
                txtDescuentoPorcentaje_Validated(null, null);
            }
            catch (Exception) { }
        }

        private void txtDescuentoPorcentaje_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                viewDetalle.UpdateCurrentRow();
                viewDetalle.Focus();
            }
        }

        private void viewDetalle_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            GridView view = sender as GridView;
            if (view.FocusedRowHandle == DevExpress.XtraGrid.GridControl.NewItemRowHandle) FilaEditable(false);
            else FilaEditable(true);
        }

        private void FilaEditable(bool condicion)
        {
            try
            {
                colBarcode.OptionsColumn.AllowEdit = !condicion;
                //colBodega.OptionsColumn.AllowFocus = condicion;
                colDescuento.OptionsColumn.AllowFocus = condicion;
                colImpuesto.OptionsColumn.AllowFocus = condicion;
                colPrecio.OptionsColumn.AllowFocus = condicion;
                colCantidad.OptionsColumn.AllowFocus = condicion;
                //colID.OptionsColumn.AllowFocus = condicion;
            }
            catch (Exception)
            {
            }
        }

        List<ListaDetalle> listDetalle = new List<ListaDetalle>();
        void RefrescarDetalle()
        {
            List<ListaDetalle> listDetalleMostrar = new List<ListaDetalle>(listDetalle);
            bindingSourceDetalle.DataSource = listDetalleMostrar;
            viewDetalle.Focus();
            viewDetalle.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle;
            if (viewDetalle.RowCount > 0) { lookUpEdit_Bodega.Enabled = false; }
            else { lookUpEdit_Bodega.Enabled = true; }
        }

        //Evento RowUpdate para saber cual es nueva y cual es vieja
        //int visibleIndex = viewDetalle.GetVisibleIndex(e.RowHandle);
        //int dataControllerRowIndex = viewDetalle.DataController.GetControllerRowHandle(visibleIndex);
        //if (viewDetalle.DataController.GetListSourceRowIndex(dataControllerRowIndex) == DevExpress.XtraGrid.GridControl.InvalidRowHandle)
        //{
        //    Console.WriteLine(">>>>>>> NUEVA");
        //}
        //else { Console.WriteLine(">>>>>>> VIEJA"); }

        private void viewDetalle_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column == colBarcode)
                {
                    //Console.WriteLine("\n>>>>>>> AGREGAR");
                    InsertarDetalle(viewDetalle.GetFocusedRowCellValue("codigo").ToString());

                    //Console.WriteLine("\n>>>>>>> LISTA <<<<<<<");
                    //foreach (var list in listDetalle.ToList())
                    //{
                    //    Console.WriteLine("\nCodigo:" + list.codigo + " Bodega:" + list.id_bodega + " Producto:" + list.id_producto + " Descripcion:" + list.descripcion + " Cantidad:" + list.cantidad);
                    //}
                }
            }
            catch (Exception) { }
        }

        public void InsertarDetalle(string xCodigo)
        {
            viewDetalle.CloseEditor();
            viewDetalle.UpdateCurrentRow();
            string vCodigo = xCodigo;
            int vBodega = Convert.ToInt32(lookUpEdit_Bodega.EditValue);

            if (string.IsNullOrEmpty(vCodigo.Replace(" ", "")) || vBodega <= 0) return;

            var query = Negocio.ClasesCN.InventarioCN.Kardex_SelectFila_COD(vCodigo, vBodega).FirstOrDefault();
            if (query == null)
            {
                RefrescarDetalle();
                Clases.MyMessageBox.MessageFont = new Font(Clases.MyMessageBox.MessageFont.FontFamily, 24);
                if (Clases.MyMessageBox.Show("No se encuentra el codigo '" + vCodigo.ToUpper() + "'.\n¿Desea buscar el producto?", "Venta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    btnBuscarProducto_Click(null, null);
                }
                return;
            }

            int vIdProducto = query.id_producto;
            decimal? vStock = query.saldo_actual;

            if (vStock <= 0.00M) return;


            foreach (var list in listDetalle.Where(x => x.id_producto == vIdProducto && x.id_bodega == vBodega).ToList())
            {
                decimal vCantidad = list.cantidad;
                if (vCantidad == vStock) { RefrescarDetalle(); return; }
                list.cantidad = vCantidad + 1;
                RefrescarDetalle();
                return;
            }

            ListaDetalle detalle = new ListaDetalle()
            {
                codigo = query.codigo,
                id_bodega = vBodega,
                id_producto = vIdProducto,
                descripcion = query.producto,
                cantidad = 1.00M,
                id_unidad_medida = (int)query.id_unidad_medida,
                precio1 = query.precio1,
                descuento = (decimal)query.descuento,
                impuesto = (decimal)query.impuesto
            };
            listDetalle.Add(detalle);
            RefrescarDetalle();
        }

        private void viewDetalle_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete)
                {
                    GridView view = sender as GridView;
                    //if (XtraMessageBox.Show("Desea Eliminar Este Registro?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
                    int id_producto = Convert.ToInt32(view.GetFocusedRowCellValue("id_producto"));
                    listDetalle.RemoveAll(x => x.id_producto == id_producto);
                    RefrescarDetalle();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error :" + ex.Message);
            }
        }

        private void viewDetalle_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            GridView view = sender as GridView;
            try
            {
                if (view.FocusedRowHandle == DevExpress.XtraGrid.GridControl.NewItemRowHandle) e.Valid = true;
                else
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
                        var query = Negocio.ClasesCN.InventarioCN.Kardex_SelectFila(producto, bodega).FirstOrDefault().saldo_actual;

                        if (Convert.ToDecimal(vCantidad) > query) { e.Valid = false; view.SetColumnError(colCantidad, "Cantidad no puede ser mayor a " + String.Format("{0:n2}", query)); view.FocusedColumn = colCantidad; }
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
                }
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

        private decimal vExist = 0.00M;
        private void viewDetalle_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
        {
            GridView view = sender as GridView;

            try
            {
                switch (view.FocusedColumn.FieldName)
                {
                    case "cantidad":
                        int bodega = view.GetFocusedRowCellValue("id_bodega").Equals(DBNull.Value) ? 0 : Convert.ToInt32(view.GetFocusedRowCellValue("id_bodega"));
                        int producto = view.GetFocusedRowCellValue("id_producto").Equals(DBNull.Value) ? 0 : Convert.ToInt32(view.GetFocusedRowCellValue("id_producto"));
                        var query = Negocio.ClasesCN.InventarioCN.Kardex_SelectFila(producto, bodega).FirstOrDefault().saldo_actual;
                        vExist = decimal.Parse(query.ToString());
                        if ((Convert.ToInt32(e.Value) <= 0) || (Convert.ToDecimal(e.Value) > query))
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
                        if ((Convert.ToInt32(e.Value) <= 0))
                            e.Valid = false;
                        break;
                }
            }
            catch (Exception) { e.Valid = false; }
        }

        private void viewDetalle_InvalidValueException(object sender, InvalidValueExceptionEventArgs e)
        {
            GridView view = sender as GridView;

            switch (view.FocusedColumn.FieldName)
            {
                case "cantidad":
                    e.ExceptionMode = ExceptionMode.DisplayError;
                    e.WindowCaption = "Error en el valor ingresado";
                    e.ErrorText = "Cantidad no puede ser menor/igual a 0 o mayor a " + String.Format("{0:n2}", vExist);
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
                    e.ErrorText = "Impuesto no puede ser menor o igual a 0";
                    //view.HideEditor();
                    break;
            }
        }
        
        private void xfrm_FacturaScanner_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {
                btnBuscarProducto_Click(null, null);
            }
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            var form = new xfrm_BuscarProducto();
            form.vIdBodega = Convert.ToInt32(lookUpEdit_Bodega.EditValue);
            form.IProd = this;
            form.ShowDialog();
            viewDetalle.Focus();
            viewDetalle.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle;
        }

        private void viewDetalle_RowUpdated(object sender, RowObjectEventArgs e)
        {
            RefrescarDetalle();
        }
    }
}