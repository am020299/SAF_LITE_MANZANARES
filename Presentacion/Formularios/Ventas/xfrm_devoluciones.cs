using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Formularios.Ventas
{
    public partial class xfrm_devoluciones : DevExpress.XtraEditors.XtraForm
    {
        public xfrm_devoluciones()
        {
            InitializeComponent();
        }

        private void xfrm_devoluciones_Load(object sender, EventArgs e)
        {
            CargarDataSources();
            HabilitarDeshabilitarControles(false);
            CargarDatosIniciales();
        }

        private void bbiCerrar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        DataTable dt, dtMod, dtModSalida;
        private DataTable getTable()
        {
            dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("descripcion", typeof(string));
            dt.Columns.Add("cantidad", typeof(decimal));
            dt.Columns.Add("precio", typeof(decimal));

            return dt;
        }

        private DataTable getTableMod()
        {
            dtMod = new DataTable();
            dtMod.Columns.Add("id", typeof(int));
            dtMod.Columns.Add("descripcion", typeof(string));
            dtMod.Columns.Add("cantidad", typeof(decimal));
            dtMod.Columns.Add("precio", typeof(decimal));

            return dtMod;
        }

        private DataTable getTableModSalida()
        {
            dtModSalida = new DataTable();
            dtModSalida.Columns.Add("id", typeof(int));
            dtModSalida.Columns.Add("descripcion", typeof(string));
            dtModSalida.Columns.Add("cantidad", typeof(decimal));
            dtModSalida.Columns.Add("precio", typeof(decimal));

            return dtModSalida;
        }

        void CargarDataSources()
        {
            srch_facturas.Properties.DataSource = Negocio.ClasesCN.VentasCN.Ventas_Select_Devoluciones(1).Where(o => o.activo == true && o.estado == 2 && o.moneda == 2 && o.dias == 0);
            srch_cliente.Properties.DataSource = Negocio.ClasesCN.CatalogosCN.Cliente_Cargar();
            srch_vendedor.Properties.DataSource = Negocio.ClasesCN.CatalogosCN.Empleado_Cargar();
            srch_terminos.Properties.DataSource = Negocio.ClasesCN.ParametrosCN.Terminos_Select();
            repositoryItemSearchLookUpEditProductoMod.DataSource = repositoryItemSearchLookUpEditProducto.DataSource = Negocio.ClasesCN.CatalogosCN.Producto_Cargar();
            gridControlDetalle.DataSource = getTable();
            gridControlDetalleMod.DataSource = getTableMod();
            gridControlDetalleModSalida.DataSource = getTableModSalida();
        }

        void HabilitarDeshabilitarControles(bool condicion)
        {
            srch_cliente.Enabled = condicion;
            srch_terminos.Enabled = condicion;
            srch_vendedor.Enabled = condicion;
            dateFecha.Enabled = condicion;
            dateFechaEstimada.Enabled = condicion;
            gridControlDetalleModSalida.Enabled = condicion;
        }

        void CargarDatosIniciales()
        {
            srch_facturas.EditValue = null;
            srch_cliente.EditValue = null;
            srch_terminos.EditValue = null;
            srch_vendedor.EditValue = null;
            dateFecha.EditValue = DateTime.Now;
            dateFechaEstimada.EditValue = DateTime.Now;
            memo_Observaciones.EditValue = string.Empty;
            txt_saldo_favor.EditValue = "0.00";
            txt_saldo_pagar.EditValue = "0.00";
            dt.Clear();
            dtMod.Clear();
            dtModSalida.Clear();
        }

        private void bbiSalida_Click(object sender, EventArgs e)
        {
            List<int> listaProd = new List<int>();

            for (int i = 0; i < gridViewDetalle.RowCount; i++)
            {
                int id_producto = Convert.ToInt32(gridViewDetalle.GetRowCellValue(i, "id"));
                if (gridViewDetalle.IsRowSelected(i))
                {
                    listaProd.Add(id_producto);
                }
            }

            foreach (var x in listaProd)
            {
                int id_venta = Convert.ToInt32(srch_facturas.EditValue);
                var queryDetalleVenta = Negocio.ClasesCN.VentasCN.VentasDetalle_Select(id_venta).Where(y => y.id_producto == x);
                if (queryDetalleVenta != null)
                {
                    foreach (var list in queryDetalleVenta)
                    {
                        if (!ProductoExiste(list.id_producto))
                        {
                            gridViewDetalleMod.AddNewRow();
                            gridViewDetalleMod.SetRowCellValue(gridViewDetalleMod.FocusedRowHandle, "id", list.id_producto);
                            gridViewDetalleMod.SetRowCellValue(gridViewDetalleMod.FocusedRowHandle, "descripcion", list.descripcion);
                            gridViewDetalleMod.SetRowCellValue(gridViewDetalleMod.FocusedRowHandle, "cantidad", list.cantidad);
                            gridViewDetalleMod.SetRowCellValue(gridViewDetalleMod.FocusedRowHandle, "precio", list.precio1);
                            gridViewDetalleMod.CloseEditor();
                            gridViewDetalleMod.UpdateCurrentRow();
                        }
                    }
                }
            }

            ActualizarSaldos();
        }

        void ActualizarSaldos()
        {

            gridViewDetalleMod.CloseEditor();
            gridViewDetalleMod.UpdateCurrentRow();
            ////gridViewDetalleModSalida.CloseEditor();
            //gridViewDetalleModSalida.UpdateCurrentRow();

            if(gridViewDetalleMod.RowCount == 0 && gridViewDetalleModSalida.RowCount == 0)
            {
                txt_saldo_pagar.EditValue = "0.00";
                txt_saldo_favor.EditValue = "0.00";

                gridControlDetalleModSalida.Enabled = false;
            }
            else if(gridViewDetalleMod.RowCount > 0 && gridViewDetalleModSalida.RowCount == 0)
            {
                decimal saldoFavor = Convert.ToDecimal(gridViewDetalleMod.Columns["total"].SummaryItem.SummaryValue);
                txt_saldo_pagar.EditValue = "0.00";
                txt_saldo_favor.EditValue = Convert.ToDecimal(saldoFavor).ToString("n2");

                gridControlDetalleModSalida.Enabled = true;
            }
            else if (gridViewDetalleMod.RowCount > 0 && gridViewDetalleModSalida.RowCount > 0)
            {
                decimal saldoFavor = Convert.ToDecimal(gridViewDetalleMod.Columns["total"].SummaryItem.SummaryValue);
                decimal saldoPagar = Convert.ToDecimal(gridViewDetalleModSalida.Columns["total"].SummaryItem.SummaryValue);

                if(saldoFavor > saldoPagar)
                {
                    txt_saldo_favor.EditValue = Convert.ToDecimal(saldoFavor - saldoPagar).ToString("n2");
                    txt_saldo_pagar.EditValue = "0.00";
                }
                else if(saldoPagar > saldoFavor)
                {
                    txt_saldo_favor.EditValue = "0.00";
                    txt_saldo_pagar.EditValue = Convert.ToDecimal(saldoPagar - saldoFavor).ToString("n2");
                }
                else
                {
                    txt_saldo_pagar.EditValue = "0.00";
                    txt_saldo_favor.EditValue = "0.00";
                }
            }
        }

        bool ProductoExiste(int vIdProducto)
        {
            bool retorno = false;
            for (int i = 0; i < gridViewDetalleMod.RowCount; i++)
            {
                int Producto = Convert.ToInt32(gridViewDetalleMod.GetRowCellValue(i, "id"));
                if (vIdProducto == Producto) { retorno = true; break; }
            }
            return retorno;
        }

        private void bbi_limpiar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CargarDataSources();
            HabilitarDeshabilitarControles(false);
            CargarDatosIniciales();
        }

        private void bbi_Guardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Validar())
            {
                int contador = 0;
                if(gridViewDetalleModSalida.RowCount > 0)
                {
                    for (int i = 0; i < gridViewDetalleModSalida.RowCount; i++)
                    {
                        int id_producto = Convert.ToInt32(gridViewDetalleModSalida.GetRowCellValue(i, "id"));
                        decimal cantidad = Convert.ToDecimal(gridViewDetalleModSalida.GetRowCellValue(i, "cantidad"));

                        var queryKardex = Negocio.ClasesCN.InventarioCN.Kardex_SelectVentaEXC().Where(x => x.id_bodega == 4 && int.Parse(x.ubicacion) == 0 && x.moneda == 2 && x.id == id_producto).FirstOrDefault();
                        if (queryKardex.stock > cantidad)
                        {
                            contador++;
                        }
                        else
                        {
                            Clases.MyMessageBox.MessageFont = new Font(Clases.MyMessageBox.MessageFont.FontFamily, 18, FontStyle.Bold);
                            Clases.MyMessageBox.Show(("El producto " + queryKardex.descripcion + " no posee suficiente stock (" + queryKardex.stock + ") en la bodega. Por favor verifique cantidades e intente nuevamente.").ToUpper(), "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                    if (contador == gridViewDetalleModSalida.RowCount)
                    {
                        GuardarDevolucion();
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    GuardarDevolucion();
                }
            }
        }

        private void repositoryItemSearchLookUpEditProductoModSalida_EditValueChanged(object sender, EventArgs e)
        {
            SearchLookUpEdit editor = (sender as SearchLookUpEdit);

            bool existe = false;
            decimal precioNuevo = 0.00M;
            int id_producto = Convert.ToInt32(editor.EditValue);
            int id_venta = Convert.ToInt32(srch_facturas.EditValue);

            for(int i = 0; i < gridViewDetalle.RowCount; i++)
            {
                int idProdMod = Convert.ToInt32(gridViewDetalle.GetRowCellValue(i, "id"));
                decimal precioMod = Convert.ToDecimal(gridViewDetalle.GetRowCellValue(i, "precio"));
                if(idProdMod == id_producto)
                {
                    existe = true;
                    precioNuevo = precioMod;
                    break;
                }
            }

            var queryProducto = Negocio.ClasesCN.CatalogosCN.Producto_Cargar_Fila(id_producto).FirstOrDefault();
            var queryPrecio = Negocio.ClasesCN.InventarioCN.Kardex_SelectVentaEXC_Devolucion(id_venta).Where(x => x.id_bodega == 4 && int.Parse(x.ubicacion) == 0 && x.moneda == 2 && x.id == id_producto).FirstOrDefault();
            if (queryProducto != null)
            {
                gridViewDetalleModSalida.SetRowCellValue(gridViewDetalleModSalida.FocusedRowHandle, "id", queryProducto.id);
                gridViewDetalleModSalida.SetRowCellValue(gridViewDetalleModSalida.FocusedRowHandle, "descripcion", queryProducto.descripcion);
                gridViewDetalleModSalida.SetRowCellValue(gridViewDetalleModSalida.FocusedRowHandle, "cantidad", 1);
                if (existe)
                {
                    gridViewDetalleModSalida.SetRowCellValue(gridViewDetalleModSalida.FocusedRowHandle, "precio", precioNuevo);
                }
                else
                {
                    gridViewDetalleModSalida.SetRowCellValue(gridViewDetalleModSalida.FocusedRowHandle, "precio", queryPrecio.precio1);
                }
            }
        }

        private void gridViewDetalleMod_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            GridView view = sender as GridView;

            var vCantidad = view.GetFocusedRowCellValue("cantidad").Equals(DBNull.Value) ? "" : Convert.ToString(view.GetFocusedRowCellValue("cantidad"));
            if (string.IsNullOrEmpty(vCantidad))
            {
                e.Valid = false;
                view.SetColumnError(gridColumn4, "Campo requerido"); view.FocusedColumn = gridColumn4;
            }
        }

        private void gridViewDetalleMod_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            GridView view = sender as GridView;
            int id_producto = view.GetFocusedRowCellValue("id").Equals(DBNull.Value) ? 0 : Convert.ToInt32(view.GetFocusedRowCellValue("id"));
            decimal cantidadOrig = 0;
            for (int i = 0; i < gridViewDetalle.RowCount; i++)
            {
                if (gridViewDetalle.IsRowSelected(i))
                {
                    int id_productoOrig = Convert.ToInt32(gridViewDetalle.GetRowCellValue(i, "id"));

                    if (id_producto == id_productoOrig)
                    {
                        cantidadOrig = Convert.ToDecimal(gridViewDetalle.GetRowCellValue(i, "cantidad"));
                    }
                }
            }

            switch (view.FocusedColumn.FieldName)
            {
                case "cantidad":
                    if (Convert.ToDecimal(e.Value) <= 0.00M || Convert.ToDecimal(e.Value) > cantidadOrig)
                    {
                        e.Valid = false;
                    }
                    break;
            }
        }

        private void gridViewDetalleMod_InvalidValueException(object sender, DevExpress.XtraEditors.Controls.InvalidValueExceptionEventArgs e)
        {
            GridView view = sender as GridView;

            switch (view.FocusedColumn.FieldName)
            {
                case "cantidad":
                    e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
                    e.WindowCaption = "Error en el valor ingresado";
                    e.ErrorText = "Cantidad no puede ser menor/igual a 0 o mayor al valor de la factura original";
                    break;
            }
        }

        private void gridViewDetalleModSalida_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            GridView view = sender as GridView;

            var vCantidad = view.GetFocusedRowCellValue("cantidad").Equals(DBNull.Value) ? "" : Convert.ToString(view.GetFocusedRowCellValue("cantidad"));
            if (string.IsNullOrEmpty(vCantidad))
            {
                e.Valid = false;
                view.SetColumnError(gridColumn4, "Campo requerido"); view.FocusedColumn = gridColumn4;
            }

            ActualizarSaldos();
        }

        private void gridViewDetalleModSalida_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            GridView view = sender as GridView;

            switch (view.FocusedColumn.FieldName)
            {
                case "cantidad":
                    if (Convert.ToDecimal(e.Value) <= 0.00M)
                    {
                        e.Valid = false;
                    }
                    break;
            }
        }

        private void gridViewDetalleModSalida_InvalidValueException(object sender, DevExpress.XtraEditors.Controls.InvalidValueExceptionEventArgs e)
        {
            GridView view = sender as GridView;

            switch (view.FocusedColumn.FieldName)
            {
                case "cantidad":
                    e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
                    e.WindowCaption = "Error en el valor ingresado";
                    e.ErrorText = "Cantidad no puede ser menor/igual a 0";
                    break;
            }
        }

        private void gridViewDetalleMod_KeyDown(object sender, KeyEventArgs e)
        {
            GridView view = sender as GridView;

            if(e.KeyCode == Keys.Delete)
            {
                int id_producto = Convert.ToInt32(view.GetFocusedRowCellValue("id"));
                for(int i = 0; i < gridViewDetalle.RowCount; i++)
                {
                    int id_productoOrig = Convert.ToInt32(gridViewDetalle.GetRowCellValue(i, "id"));
                    if(id_productoOrig == id_producto)
                    {
                        gridViewDetalle.UnselectRow(i);
                    }
                }

                view.DeleteRow(view.FocusedRowHandle);
            }

            ActualizarSaldos();
        }

        private void gridViewDetalleModSalida_KeyDown(object sender, KeyEventArgs e)
        {
            GridView view = sender as GridView;

            if (e.KeyCode == Keys.Delete)
            {
                view.DeleteRow(view.FocusedRowHandle);
            }

            ActualizarSaldos();
        }

        private void srch_facturas_EditValueChanged(object sender, EventArgs e)
        {
            DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(typeof(Presentacion.Formularios.Principal.WaitForm1));
            int id_venta = Convert.ToInt32(srch_facturas.EditValue);
            var queryVenta = Negocio.ClasesCN.VentasCN.getVentas().Where(x => x.id == id_venta).FirstOrDefault();
            if (queryVenta != null)
            {
                srch_cliente.EditValue = queryVenta.id_cliente;
                srch_terminos.EditValue = queryVenta.id_termino;
                srch_vendedor.EditValue = queryVenta.id_empleado;
                dateFecha.EditValue = queryVenta.fecha;
                dateFechaEstimada.EditValue = queryVenta.fecha_maxima;
                memo_Observaciones.EditValue = queryVenta.observacion;

                var queryDetalleVenta = Negocio.ClasesCN.VentasCN.VentasDetalle_Select(id_venta);
                if (queryDetalleVenta != null)
                {
                    dt.Clear();
                    foreach (var list in queryDetalleVenta)
                    {
                        gridViewDetalle.AddNewRow();
                        gridViewDetalle.SetRowCellValue(gridViewDetalle.FocusedRowHandle, "id", list.id_producto);
                        gridViewDetalle.SetRowCellValue(gridViewDetalle.FocusedRowHandle, "descripcion", list.descripcion);
                        gridViewDetalle.SetRowCellValue(gridViewDetalle.FocusedRowHandle, "cantidad", list.cantidad);
                        gridViewDetalle.SetRowCellValue(gridViewDetalle.FocusedRowHandle, "precio", list.precio1);
                        gridViewDetalle.UpdateCurrentRow();
                        gridViewDetalle.BestFitColumns();
                        gridViewDetalle.MoveFirst();
                    }
                }
            }

            repositoryItemSearchLookUpEditProductoModSalida.DataSource = Negocio.ClasesCN.InventarioCN.Kardex_SelectVentaEXC_Devolucion(id_venta).Where(x => x.id_bodega == 4 && int.Parse(x.ubicacion) == 0 && x.moneda == 2).ToList();
            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm();
        }

        bool Validar()
        {
            bool retorno = false;

            gridViewDetalle.UpdateCurrentRow();
            gridViewDetalleMod.UpdateCurrentRow();
            gridViewDetalleModSalida.UpdateCurrentRow();
            if (gridViewDetalleMod.RowCount == 0)
            {
                Clases.MyMessageBox.MessageFont = Clases.MyMessageBox.MessageFont = new Font(Clases.MyMessageBox.MessageFont.FontFamily, 18, FontStyle.Bold);
                Clases.MyMessageBox.Show("No hay detalles en la tabla de Entrante", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                gridViewDetalle.Focus();
            }
            else
            {
                if (gridViewDetalleMod.RowCount > 0 && gridViewDetalleModSalida.RowCount > 0)
                {
                    decimal sumaMod = Convert.ToDecimal(gridViewDetalleMod.Columns["cantidad"].SummaryItem.SummaryValue);
                    decimal sumaModSalida = Convert.ToDecimal(gridViewDetalleModSalida.Columns["cantidad"].SummaryItem.SummaryValue);

                    if (sumaMod == sumaModSalida)
                    {
                        retorno = true;
                    }
                    else
                    {
                        Clases.MyMessageBox.MessageFont = Clases.MyMessageBox.MessageFont = new Font(Clases.MyMessageBox.MessageFont.FontFamily, 18, FontStyle.Bold);
                        Clases.MyMessageBox.Show("Cantidades entre los productos Entrantes y Salientes no coinciden. Verifique la informacion y vuelva a intentar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    if (gridViewDetalleMod.RowCount > 0)
                    {
                        retorno = true;
                    }
                }
            }

            return retorno;
        }

        void GuardarDevolucion()
        {
            int id_venta = Convert.ToInt32(srch_facturas.EditValue);
            int id_empleado = Clases.UsuarioLogueado.vID_Empleado;
            string persona_referencia = string.Empty;
            if(Clases.UsuarioLogueado.admin)
            {
                persona_referencia = "ADMINISTRADOR";
            }
            else
            {
                persona_referencia = Negocio.ClasesCN.CatalogosCN.Empleado_Cargar().Where(x => x.id == id_empleado).FirstOrDefault().nombre.ToUpper();
            }
            
            string observaciones = Convert.ToString(memo_Observaciones.Text);

            Clases.MyMessageBox.MessageFont = Clases.MyMessageBox.MessageFont = new Font(Clases.MyMessageBox.MessageFont.FontFamily, 18, FontStyle.Bold);
            if (Clases.MyMessageBox.Show($"¿Esta completamente seguro de guardar este Cambio del Cliente?", "Informacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            string numeroDocumento = Negocio.ClasesCN.InventarioCN.RetornarNumeroDocumentoCambioClientes();
            var queryDevolucionEntrada = Negocio.ClasesCN.InventarioCN.DevolucionEntrada(id_venta, observaciones, id_empleado, persona_referencia, gridViewDetalleMod, numeroDocumento);
            var queryDevolucionSalida = Negocio.ClasesCN.InventarioCN.DevolucionSalida(id_venta, observaciones, id_empleado, persona_referencia, gridViewDetalleModSalida, numeroDocumento);
            var queryDevolucionCambio = Negocio.ClasesCN.InventarioCN.SaldoFactura(id_venta, observaciones, id_empleado, persona_referencia, gridViewDetalleMod, gridViewDetalleModSalida, 1);
            if(queryDevolucionEntrada > 0)
            {
                Clases.MyMessageBox.MessageFont = Clases.MyMessageBox.MessageFont = new Font(Clases.MyMessageBox.MessageFont.FontFamily, 18, FontStyle.Bold);
                Clases.MyMessageBox.Show($"Cambio de Productos de Cliente. Realizado correctamente.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                BindingSource source = new BindingSource();
                source.DataSource = Negocio.ClasesCN.InventarioCN.ReporteDevoluciones(id_venta).ToList();
                var Reporte = new Reportes.Inventario.xrpt_cambioClientes(source);
                Reporte.Parameters[0].Value = Convert.ToDecimal(txt_saldo_favor.Text).ToString("n2");
                Reporte.Parameters[1].Value = Convert.ToDecimal(txt_saldo_pagar.Text).ToString("n2");
                Reporte.ShowPreviewDialog();


                bbi_limpiar_ItemClick(null, null);
            }
        }
    }
}