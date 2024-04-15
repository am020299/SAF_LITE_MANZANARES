using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Tile;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Presentacion.Formularios.Ventas
{
    public partial class xfrm_caja_factura_2 : DevExpress.XtraEditors.XtraForm
    {
        decimal sub_total, descuento_total, total_factura, total_recibir, total_recibir_dolares;
        private decimal vTipoCambio, vTipo_cambio_compra;
        private int tipo_moneda_factura;
        int tdc;
        int id_saldo;
        public xfrm_caja_factura_2(int tipo_documento)
        {
            InitializeComponent();
            this.tdc = tipo_documento;
            txt_cambio_cordobas.Properties.Mask.EditMask = "n2";
            txt_cambio_cordobas.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            txt_cambio_cordobas.Properties.Mask.UseMaskAsDisplayFormat = true;

            txt_total.Properties.Mask.EditMask = "n2";
            txt_total.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            txt_total.Properties.Mask.UseMaskAsDisplayFormat = true;

            txt_total_cordoba.Properties.Mask.EditMask = "n2";
            txt_total_cordoba.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            txt_total_cordoba.Properties.Mask.UseMaskAsDisplayFormat = true;

            txt_cambio_dolares.Properties.Mask.EditMask = "n2";
            txt_cambio_dolares.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            txt_cambio_dolares.Properties.Mask.UseMaskAsDisplayFormat = true;

            txt_diferencia_cordobas.Properties.Mask.EditMask = "n2";
            txt_diferencia_cordobas.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            txt_diferencia_cordobas.Properties.Mask.UseMaskAsDisplayFormat = true;

            txt_diferencia_dolares.Properties.Mask.EditMask = "n2";
            txt_diferencia_dolares.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            txt_diferencia_dolares.Properties.Mask.UseMaskAsDisplayFormat = true;

            txt_total_recibir.Properties.Mask.EditMask = "n2";
            txt_total_recibir.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            txt_total_recibir.Properties.Mask.UseMaskAsDisplayFormat = true;

            txt_dolares_cordobizados.Properties.Mask.EditMask = "n2";
            txt_dolares_cordobizados.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            txt_dolares_cordobizados.Properties.Mask.UseMaskAsDisplayFormat = true;

        }

        public int id_factura { get; set; }
        public int tipo_documento { get; set; }
        private DataTable getTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id_forma_pago", typeof(int));
            dt.Columns.Add("monto", typeof(decimal));
            dt.Columns.Add("moneda", typeof(int));
            dt.Columns.Add("tipo_cambio", typeof(decimal));
            dt.Columns.Add("n_transferencia", typeof(decimal));
            dt.Columns.Add("fecha_deposito", typeof(DateTime));
            dt.Columns.Add("banco", typeof(string));
            dt.Columns.Add("id_saldo_orig", typeof(int));
            return dt;
        }
        private void cargar_forma_pago()
        {
            bindingSourceDetalle.DataSource = null;
            bindingSourceDetalle.DataSource = getTable();
            bindingSourceFormaPago.DataSource = Negocio.ClasesCN.VentasCN.FormaPago_Select();
            repositoryItemLookUpEdit_FormaPago.DataSource = bindingSourceFormaPago;
        }
        private void xfrm_caja_factura_2_Load(object sender, EventArgs e)
        {
            // MessageBox.Show(id_factura.ToString());

            repositorio_bodega.DataSource = Negocio.ClasesCN.CatalogosCN.Bodega_Cargar().ToList();
            srch_facturas.Properties.DataSource = Negocio.ClasesCN.VentasCN.Ventas_Sin_Cancelar();//.Where(o => o.activo == true && (o.estado == 1 || o.estado == 3)).ToList();

            if (tdc == 1)
                srch_facturas.EditValue = id_factura;
            else
            {
                foreach (var r in Negocio.ClasesCN.VentasCN.Ventas_Sin_Cancelar().Where(o => o.id == id_factura && o.tipo_documento == 2))
                {
                    fecha.Text = Convert.ToDateTime(r.fecha).ToShortDateString();
                    txt_tipo_cambio_VENTA.EditValue = Negocio.ClasesCN.DatosRequeridosCN.Obtner_Tipo_Cambio_Mensual();
                    vTipo_cambio_compra = Negocio.ClasesCN.DatosRequeridosCN.Obtner_Tipo_Cambio_Mensual_compra();
                    txt_tc_COMPRA.EditValue = vTipo_cambio_compra;
                    tipo_moneda_factura = Convert.ToInt32(r.moneda);
                    total_factura = Convert.ToDecimal(r.total);
                }
                vTipoCambio = Convert.ToDecimal(txt_tipo_cambio_VENTA.EditValue);
                calculos();
                bindingSourceDetalle.DataSource = getTable();
                //if (tipo_moneda_factura == 2)
                //{
                //    radioGroup1.Enabled = true;
                //    radioGroup1.SelectedIndex = 0;
                //}
                //else
                //{
                //    radioGroup1.SelectedIndex = 1;
                //    radioGroup1.Enabled = false;
                //}
            }
            repositoryItemLookUpEdit_Moneda.DataSource = Negocio.ClasesCN.CatalogosCN.getMoneda();
            repositoryItemLookUpEditBanco.DataSource = Negocio.ClasesCN.CatalogosCN.getBanco();
            //repositoryItemSearchLookUpEditSaldos.DataSource = Negocio.ClasesCN.CajaCN.SaldoFavorClientes_Select(DateTime.Now.AddYears(-1), DateTime.Now).Where(x => x.estadoSaldo == "SALDO SIN USAR");
            layoutControlItemTRF.Enabled = false;
            cargar_forma_pago();

        }
        //////////////
        private void calculos()
        {
            var id_venta = Negocio.ClasesCN.VentasCN.Ventas_Sin_Cancelar().Where(o => o.id == id_factura).FirstOrDefault();
            decimal monto_con_retenciones = 0;

            if (tipo_moneda_factura == 2)
            {
                if (tdc == 1)
                {
                    sub_total = 0; descuento_total = 0; total_factura = 0;
                    for (int i = 0; i < gridView_factura.RowCount; i++)
                    {
                        decimal precio = Convert.ToDecimal(gridView_factura.GetRowCellValue(i, "precio1"));
                        decimal cantidad = Convert.ToDecimal(gridView_factura.GetRowCellValue(i, "cantidad"));
                        decimal descuento = Convert.ToDecimal(gridView_factura.GetRowCellValue(i, "descuento"));
                        decimal impuesto = Convert.ToDecimal(gridView_factura.GetRowCellValue(i, "impuesto"));
                        decimal total = Convert.ToDecimal(gridView_factura.GetRowCellValue(i, "total"));
                        sub_total += (Math.Round((total), 2, MidpointRounding.AwayFromZero));
                        descuento_total += (Math.Round(((total) * (descuento / 100)), 4, MidpointRounding.AwayFromZero));

                    }
                    total_factura = (Math.Round((sub_total - descuento_total) * vTipoCambio, 4, MidpointRounding.AwayFromZero));
                    txt_total.EditValue = (sub_total - descuento_total - id_venta.retencion_1 - id_venta.retencion_2);
                    txt_total_cordoba.EditValue = total_factura - (id_venta.retencion_1 * vTipoCambio) - (id_venta.retencion_2 * vTipoCambio);
                }
                else
                {
                    monto_con_retenciones = Convert.ToDecimal(total_factura - id_venta.retencion_1 - id_venta.retencion_2);
                    txt_total.EditValue = total_factura - id_venta.retencion_1 - id_venta.retencion_2;
                    txt_total_cordoba.EditValue = (monto_con_retenciones * vTipoCambio).ToString("n2");
                }
                calculos_pago_recibir();
            }
            else
            {
                if (tdc == 1)
                {
                    sub_total = 0; descuento_total = 0; total_factura = 0;
                    for (int i = 0; i < gridView_factura.RowCount; i++)
                    {
                        decimal precio = Convert.ToDecimal(gridView_factura.GetRowCellValue(i, "precio1"));
                        decimal cantidad = Convert.ToDecimal(gridView_factura.GetRowCellValue(i, "cantidad"));
                        decimal descuento = Convert.ToDecimal(gridView_factura.GetRowCellValue(i, "descuento"));
                        decimal impuesto = Convert.ToDecimal(gridView_factura.GetRowCellValue(i, "impuesto"));
                        sub_total += (Math.Round(((precio / vTipo_cambio_compra) * cantidad), 4, MidpointRounding.AwayFromZero));
                        descuento_total += (Math.Round(((precio / vTipo_cambio_compra * cantidad) * (descuento / 100)), 4, MidpointRounding.AwayFromZero));

                    }

                    total_factura = (Math.Round((sub_total - descuento_total) * Convert.ToDecimal(txt_tc_COMPRA.EditValue ?? 1), 4, MidpointRounding.AwayFromZero));
                    txt_total.EditValue = (sub_total - descuento_total - id_venta.retencion_1 - id_venta.retencion_2);
                    txt_total_cordoba.EditValue = total_factura - (id_venta.retencion_1 * vTipoCambio) - (id_venta.retencion_2 * vTipoCambio);
                }
                else
                {
                    monto_con_retenciones = Convert.ToDecimal(total_factura - id_venta.retencion_1 - id_venta.retencion_2);
                    txt_total_cordoba.EditValue = total_factura - id_venta.retencion_1 - id_venta.retencion_2;
                    txt_total.EditValue = (monto_con_retenciones / vTipoCambio).ToString("n2");
                }
                calculos_pago_recibir_cordobas();

            }
        }
        private void calculos_pago_recibir()
        {
            try
            {
                decimal total_calculo = 0;
                decimal dolares_cordobizados = 0;
                txt_diferencia_cordobas.EditValue = 0;
                txt_diferencia_dolares.EditValue = 0;
                decimal Tipo_cambio_Venta = Convert.ToDecimal(txt_tipo_cambio_VENTA.EditValue ?? 1);
                decimal Tipo_Cambio_Compra = Convert.ToDecimal(txt_tc_COMPRA.EditValue ?? 1);

                bool hay_dolares = false;
                bool hay_cordobas = false;
                //int rowHandler = viewDetalleFormaPago.GetRowHandle(viewDetalleFormaPago.DataRowCount);
                for (int i = 0; i < viewDetalleFormaPago.RowCount; i++)
                {
                    int tipo_moneda = Convert.ToInt32(viewDetalleFormaPago.GetRowCellValue(i, "moneda") ?? 0);
                    decimal cantidad = Convert.ToDecimal(viewDetalleFormaPago.GetRowCellValue(i, "monto") ?? 0);

                    if (tipo_moneda == 2)
                    {
                        hay_dolares = true;
                        total_calculo += (Math.Round(cantidad * vTipoCambio, 4, MidpointRounding.AwayFromZero));
                        dolares_cordobizados += (Math.Round(cantidad * vTipoCambio, 4, MidpointRounding.AwayFromZero));
                        txt_dolares_cordobizados.EditValue = dolares_cordobizados;
                    }
                    else
                    {
                        hay_cordobas = true;
                        total_calculo += cantidad;
                        txt_dolares_cordobizados.EditValue = dolares_cordobizados;
                    }

                    if ((new[] { 3, 5, 8, 1006, 1008 }.Contains(Convert.ToInt32(viewDetalleFormaPago.GetRowCellValue(i, "id_forma_pago")))) && cantidad > Convert.ToDecimal(txt_total_cordoba.Text))
                    {
                        viewDetalleFormaPago.SetRowCellValue(i, "monto", Convert.ToDecimal(txt_total_cordoba.Text));
                    }
                    else if ((new[] { 4, 6, 7, 1005, 1007 }.Contains(Convert.ToInt32(viewDetalleFormaPago.GetRowCellValue(i, "id_forma_pago")))) && cantidad > Convert.ToDecimal(txt_total.Text))
                    {
                        viewDetalleFormaPago.SetRowCellValue(i, "monto", Convert.ToDecimal(txt_total.Text));
                    }

                }
                total_recibir = total_calculo;
                total_recibir_dolares = (total_calculo / Tipo_cambio_Venta);

                txt_total_recibir.EditValue = total_recibir.ToString("n2"); ;
                if (Convert.ToDecimal(txt_total_recibir.EditValue ?? 0) > Convert.ToDecimal(txt_total_cordoba.EditValue ?? 0))
                {
                    if (hay_dolares && hay_cordobas)
                    {
                        txt_cambio_dolares.EditValue = (total_recibir_dolares - Convert.ToDecimal(txt_total.EditValue ?? 0));
                        txt_cambio_cordobas.EditValue = (Convert.ToDecimal(txt_total_recibir.EditValue ?? 0) - Convert.ToDecimal(txt_total_cordoba.EditValue ?? 0));//(Convert.ToDecimal(txt_cambio_dolares.EditValue ?? 0) * Tipo_Cambio_Compra).ToString("n2");

                    }
                    else if (hay_dolares && !hay_cordobas && radioGroup1.SelectedIndex == 0)
                    {
                        txt_cambio_dolares.EditValue = (total_recibir_dolares - Convert.ToDecimal(txt_total.EditValue ?? 0));
                        txt_cambio_cordobas.EditValue = (Convert.ToDecimal(txt_cambio_dolares.EditValue ?? 0) * Tipo_Cambio_Compra);
                    }
                    else if (hay_dolares && !hay_cordobas && radioGroup1.SelectedIndex == 1)
                    {
                        txt_cambio_dolares.EditValue = (total_recibir_dolares - Convert.ToDecimal(txt_total.EditValue ?? 0));
                        txt_cambio_cordobas.EditValue = (Convert.ToDecimal(txt_cambio_dolares.EditValue ?? 0) * Tipo_Cambio_Compra);
                    }
                    else if (!hay_dolares && hay_cordobas && radioGroup1.SelectedIndex == 0)
                    {
                        txt_cambio_dolares.EditValue = (total_recibir_dolares - Convert.ToDecimal(txt_total.EditValue ?? 0));
                        txt_cambio_cordobas.EditValue = (Convert.ToDecimal(txt_cambio_dolares.EditValue ?? 0) * Tipo_Cambio_Compra);
                    }
                    else if (!hay_dolares && hay_cordobas && radioGroup1.SelectedIndex == 1)
                    {
                        txt_cambio_dolares.EditValue = (total_recibir_dolares - Convert.ToDecimal(txt_total.EditValue ?? 0));
                        txt_cambio_cordobas.EditValue = (Convert.ToDecimal(txt_total_recibir.EditValue ?? 0) - Convert.ToDecimal(txt_total_cordoba.EditValue ?? 0));
                    }

                }
                else
                {
                    txt_cambio_cordobas.EditValue = 0.00;
                    txt_cambio_dolares.EditValue = 0.00;
                    txt_diferencia_cordobas.EditValue = (Convert.ToDecimal(txt_total_cordoba.EditValue ?? 0) - Convert.ToDecimal(txt_total_recibir.EditValue ?? 0));
                    txt_diferencia_dolares.EditValue = ((Convert.ToDecimal(txt_total.EditValue ?? 0) - total_recibir_dolares));
                }
                if ((Math.Round(Convert.ToDecimal(txt_diferencia_cordobas.EditValue ?? 0), 2, MidpointRounding.AwayFromZero) == 0) && (Math.Round(Convert.ToDecimal(txt_diferencia_dolares.EditValue ?? 0), 2, MidpointRounding.AwayFromZero) == 0))
                {
                    bbi_guardar.Enabled = true;

                }
                else
                {
                    bbi_guardar.Enabled = false;
                }
            }
            catch (Exception)
            {

            }
        }
        private void calculos_pago_recibir_cordobas()
        {
            try
            {

                decimal total_calculo = 0;
                decimal dolares_cordobizados = 0;
                txt_diferencia_cordobas.EditValue = 0;
                txt_diferencia_dolares.EditValue = 0;

                decimal Tipo_Cambio_Compra = Convert.ToDecimal(txt_tc_COMPRA.EditValue ?? 1);

                //  bool hay_dolares=false;
                //bool hay_cordobas=false;

                for (int i = 0; i < viewDetalleFormaPago.RowCount; i++)
                {
                    int tipo_moneda = Convert.ToInt32(viewDetalleFormaPago.GetRowCellValue(i, "moneda") ?? 0);
                    decimal cantidad = Convert.ToDecimal(viewDetalleFormaPago.GetRowCellValue(i, "monto") ?? 0);

                    if (tipo_moneda == 2)
                    {
                        // hay_dolares = true;
                        total_calculo += (Math.Round(cantidad * vTipo_cambio_compra, 4, MidpointRounding.AwayFromZero));
                        dolares_cordobizados += (Math.Round(cantidad * vTipo_cambio_compra, 4, MidpointRounding.AwayFromZero));
                        txt_dolares_cordobizados.EditValue = dolares_cordobizados;

                    }
                    else
                    {
                        // hay_cordobas = true;
                        total_calculo += cantidad;
                        txt_dolares_cordobizados.EditValue = dolares_cordobizados;
                    }
                }
                total_recibir = total_calculo;
                total_recibir_dolares = total_calculo / vTipo_cambio_compra;

                txt_total_recibir.EditValue = total_recibir;
                if (total_recibir > Convert.ToDecimal(txt_total_cordoba.EditValue ?? 0))
                {
                    txt_cambio_dolares.EditValue = (total_recibir_dolares - Convert.ToDecimal(txt_total.EditValue ?? 0));
                    txt_cambio_cordobas.EditValue = (total_recibir - Convert.ToDecimal(txt_total_cordoba.EditValue ?? 0));
                    //if(hay_dolares && hay_cordobas)
                    //{
                    //    txt_cambio_dolares.EditValue = (total_recibir_dolares - Convert.ToDecimal(txt_total.EditValue ?? 0)).ToString("n2");
                    //    txt_cambio_cordobas.EditValue = (total_recibir-Convert.ToDecimal(txt_total_cordoba.EditValue??0)).ToString("n2");

                    //}
                    //else if(hay_dolares && !hay_cordobas && radioGroup1.SelectedIndex == 1)
                    //{
                    //    txt_cambio_dolares.EditValue = (total_recibir_dolares - Convert.ToDecimal(txt_total.EditValue ?? 0)).ToString("n2");
                    //    txt_cambio_cordobas.EditValue = (total_recibir-Convert.ToDecimal(txt_total_cordoba.EditValue??0)).ToString("n2");
                    //}
                    //else if(hay_dolares && !hay_cordobas && radioGroup1.SelectedIndex == 0)
                    //{
                    //    txt_cambio_dolares.EditValue = (total_recibir_dolares - Convert.ToDecimal(txt_total.EditValue ?? 0)).ToString("n2");
                    //    txt_cambio_cordobas.EditValue = (total_recibir - Convert.ToDecimal(txt_total_cordoba.EditValue ?? 0)).ToString("n2");
                    //    // txt_cambio_cordobas.EditValue = (Convert.ToDecimal(txt_cambio_dolares.EditValue ?? 0) * Tipo_Cambio_Compra).ToString("n2");
                    //}
                    //else if(!hay_dolares && hay_cordobas && radioGroup1.SelectedIndex == 0)
                    //{
                    //    txt_cambio_dolares.EditValue = (total_recibir_dolares - Convert.ToDecimal(txt_total.EditValue ?? 0)).ToString("n2");
                    //    txt_cambio_cordobas.EditValue = (total_recibir - Convert.ToDecimal(txt_total_cordoba.EditValue ?? 0)).ToString("n2");
                    //}
                    //else if(!hay_dolares && hay_cordobas && radioGroup1.SelectedIndex == 1)
                    //{
                    //    txt_cambio_dolares.EditValue = (total_recibir_dolares - Convert.ToDecimal(txt_total.EditValue ?? 0)).ToString("n2");
                    //    txt_cambio_cordobas.EditValue = (total_recibir - Convert.ToDecimal(txt_total_cordoba.EditValue ?? 0)).ToString("n2");
                    //}
                }
                else
                {
                    txt_cambio_cordobas.EditValue = 0.00M;
                    txt_cambio_dolares.EditValue = 0.00M;
                    txt_diferencia_cordobas.EditValue = (Convert.ToDecimal(txt_total_cordoba.EditValue ?? 0) - total_recibir);
                    txt_diferencia_dolares.EditValue = ((Convert.ToDecimal(txt_total_cordoba.EditValue ?? 0) - total_recibir) / vTipo_cambio_compra);
                }
                if ((Math.Round(Convert.ToDecimal(txt_diferencia_cordobas.EditValue ?? 0), 2) == 0) && (Math.Round(Convert.ToDecimal(txt_diferencia_dolares.EditValue ?? 0), 2) == 0))
                {
                    bbi_guardar.Enabled = true;

                }
                else
                {
                    bbi_guardar.Enabled = false;
                }

            }
            catch (Exception)
            {

            }
        }

        private GridView viewPago;
        public bool FormaPago(GridView view)
        {
            viewPago = view;
            if (viewPago.RowCount > 0) return true;
            else return false;
        }
        private void tileViewFormaPago_ItemClick(object sender, DevExpress.XtraGrid.Views.Tile.TileViewItemClickEventArgs e)
        {

            TileView view = sender as TileView;
            try
            {
                //if (srch_facturas.EditValue != null)
                //{
                int vIdFormaPago = view.GetFocusedRowCellValue("id").Equals(DBNull.Value) ? 0 : Convert.ToInt32(view.GetFocusedRowCellValue("id"));
                //for (int i = 0; i < viewDetalleFormaPago.RowCount; i++)
                //{
                //    if ((int)viewDetalleFormaPago.GetRowCellValue(i, "id_forma_pago") == vIdFormaPago)
                //    {
                //        viewDetalleFormaPago.FocusedRowHandle = i;
                //        viewDetalleFormaPago.Focus();
                //        return;
                //    }
                //}
                var query = Negocio.ClasesCN.VentasCN.FormaPago_Select().Where(x => x.id == vIdFormaPago).FirstOrDefault();
                if (query != null)
                {
                    viewDetalleFormaPago.AddNewRow();

                    int rowHandler = viewDetalleFormaPago.GetRowHandle(viewDetalleFormaPago.DataRowCount);
                    if (viewDetalleFormaPago.IsNewItemRow(rowHandler))
                    {
                        //valoresEnCeroEfectivos();

                        viewDetalleFormaPago.SetRowCellValue(rowHandler, "id_forma_pago", vIdFormaPago);
                        viewDetalleFormaPago.SetRowCellValue(rowHandler, "monto", 0.00M);
                        viewDetalleFormaPago.SetRowCellValue(rowHandler, "moneda", query.moneda);
                        if ((new[] { 1, 2 }.Contains(Convert.ToInt32(viewDetalleFormaPago.GetRowCellValue(rowHandler, "id_forma_pago")))))
                        {
                            colTransf.Visible = false;
                            gridColumn7.Visible = false;
                            colBanco.Visible = false;
                            colSaldoFavor.Visible = false;
                            viewDetalleFormaPago.SetRowCellValue(rowHandler, "fecha_deposito", DateTime.Now);
                            viewDetalleFormaPago.SetRowCellValue(rowHandler, "n_transferencia", 0);
                        }

                        if ((new[] { 5, 6, 7, 8 }.Contains(Convert.ToInt32(viewDetalleFormaPago.GetRowCellValue(rowHandler, "id_forma_pago")))))
                        {
                            colTransf.Visible = true;
                            gridColumn7.Visible = true;
                            colBanco.Visible = false;
                            colSaldoFavor.Visible = false;
                            viewDetalleFormaPago.SetRowCellValue(rowHandler, "fecha_deposito", DateTime.Now);
                            viewDetalleFormaPago.SetRowCellValue(rowHandler, "n_transferencia", 0);
                        }

                        if ((new[] { 1005, 1006 }.Contains(Convert.ToInt32(viewDetalleFormaPago.GetRowCellValue(rowHandler, "id_forma_pago")))))
                        {
                            colTransf.Visible = true;
                            gridColumn7.Visible = true;
                            colBanco.Visible = true;
                            viewDetalleFormaPago.SetRowCellValue(rowHandler, "fecha_deposito", DateTime.Now);
                            viewDetalleFormaPago.SetRowCellValue(rowHandler, "n_transferencia", 0);
                        }

                        if ((new[] { 1007, 1008 }.Contains(Convert.ToInt32(viewDetalleFormaPago.GetRowCellValue(rowHandler, "id_forma_pago")))))
                        {
                            colTransf.Visible = false;
                            gridColumn7.Visible = false;
                            colBanco.Visible = false;
                            colSaldoFavor.Visible = true;
                            if (Convert.ToInt32(viewDetalleFormaPago.GetRowCellValue(rowHandler, "id_forma_pago")) == 1007)
                            {
                                var queryVenta = Negocio.ClasesCN.VentasCN.getVentas().Where(o => o.id == id_factura).FirstOrDefault();
                                repositoryItemSearchLookUpEditSaldos.DataSource = Negocio.ClasesCN.CajaCN.SaldoFavorClientes_Select(DateTime.Now.AddYears(-1), DateTime.Now).Where(x => x.estadoSaldo == "SALDO SIN USAR" && x.moneda == 2 && x.id_cliente == queryVenta.id_cliente).Select(L => new { id_saldo = L.id_saldo, cliente = L.CLIENTE, factura = L.N_FACTURA, monto = L.MONTO }).ToList();
                            }
                            else if (Convert.ToInt32(viewDetalleFormaPago.GetRowCellValue(rowHandler, "id_forma_pago")) == 1008)
                            {
                                var queryVenta = Negocio.ClasesCN.VentasCN.getVentas().Where(o => o.id == id_factura).FirstOrDefault();
                                repositoryItemSearchLookUpEditSaldos.DataSource = Negocio.ClasesCN.CajaCN.SaldoFavorClientes_Select(DateTime.Now.AddYears(-1), DateTime.Now).Where(x => x.estadoSaldo == "SALDO SIN USAR" && x.moneda == 1 && x.id_cliente == queryVenta.id_cliente).Select(L => new { id_saldo = L.id_saldo, cliente = L.CLIENTE ,factura = L.N_FACTURA, monto = L.MONTO }).ToList();
                            }
                            viewDetalleFormaPago.SetRowCellValue(rowHandler, "fecha_deposito", DateTime.Now);
                            viewDetalleFormaPago.SetRowCellValue(rowHandler, "n_transferencia", 0);
                        }

                        if (tipo_moneda_factura == 1)
                        {
                            if (query.moneda == 1) viewDetalleFormaPago.SetRowCellValue(rowHandler, "tipo_cambio", vTipoCambio);
                            else viewDetalleFormaPago.SetRowCellValue(rowHandler, "tipo_cambio", vTipo_cambio_compra);
                        }
                        else if (tipo_moneda_factura == 2)
                        {
                            if (query.moneda == 1) viewDetalleFormaPago.SetRowCellValue(rowHandler, "tipo_cambio", vTipoCambio);
                            else viewDetalleFormaPago.SetRowCellValue(rowHandler, "tipo_cambio", vTipoCambio);
                        }
                        viewDetalleFormaPago.FocusedRowHandle = rowHandler;
                    }
                }
                viewDetalleFormaPago.Focus();
                //}
            }
            catch (Exception) { }
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
                if (tipo_moneda_factura == 2)
                    calculos_pago_recibir();
                else
                    calculos_pago_recibir_cordobas();
            }
        }
        private void viewDetalleFormaPago_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
        {
            GridView view = sender as GridView;
            ColumnView columns = sender as ColumnView;
            try
            {
                switch (view.FocusedColumn.FieldName)
                {
                    case "monto":
                        if ((Convert.ToDecimal(e.Value) < 0))
                            e.Valid = false;
                        break;
                }

                GridColumn column = (e as EditFormValidateEditorEventArgs)?.Column ?? view.FocusedColumn;
                if (column.Name != "n_transferencia") return;
                if ((Convert.ToInt32(e.Value) <= 0))
                    e.Valid = false;
            }
            catch (Exception)
            {
                e.Valid = false;
            }
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tipo_moneda_factura == 2)
                calculos_pago_recibir();
            else
                calculos_pago_recibir_cordobas();
        }

        private void viewDetalleFormaPago_ShowingEditor(object sender, System.ComponentModel.CancelEventArgs e)
        {
            GridView view = sender as GridView;

            if (view != null && view.FocusedRowHandle != DevExpress.XtraGrid.GridControl.NewItemRowHandle)
            {
                // Obtén el valor del parámetro o condición según tu lógica
                int id_forma_pago = Convert.ToInt32(view.GetRowCellValue(view.FocusedRowHandle, "id_forma_pago"));
                if (new List<int> { 1007, 1008 }.Contains(id_forma_pago))
                {
                    string nombreColumnaActual = view.FocusedColumn.FieldName;
                    // Aplica la lógica a columnas específicas
                    if (new List<string> { "monto" }.Contains(nombreColumnaActual))
                    {
                        // Cancela la edición si no se cumplen las condiciones
                        e.Cancel = true;
                    }
                    else
                    {
                        e.Cancel = false;
                    }
                }
                else if (new List<int> { 1, 2, 5, 6, 7, 8, 1005, 1006 }.Contains(id_forma_pago))
                {
                    string nombreColumnaActual = view.FocusedColumn.FieldName;
                    // Aplica la lógica a columnas específicas
                    if (new List<string> { "id_saldo" }.Contains(nombreColumnaActual))
                    {
                        // Cancela la edición si no se cumplen las condiciones
                        e.Cancel = true;
                    }
                    else
                    {
                        e.Cancel = false;
                    }
                }
            }
        }

        private void xfrm_caja_factura_2_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void repositoryItemSearchLookUpEditSaldos_EditValueChanged(object sender, EventArgs e)
        {
            SearchLookUpEdit editor = sender as SearchLookUpEdit;
            id_saldo = Convert.ToInt32(editor.EditValue);

            var querySaldo = Negocio.ClasesCN.CajaCN.SaldoFavorClientes_Select(DateTime.Now.AddYears(-1), DateTime.Now).Where(x => x.estadoSaldo == "SALDO SIN USAR" && x.id_saldo == id_saldo).FirstOrDefault();
            viewDetalleFormaPago.SetRowCellValue(viewDetalleFormaPago.FocusedRowHandle, "monto", querySaldo.MONTO);
        }

        private void viewDetalleFormaPago_RowUpdated(object sender, RowObjectEventArgs e)
        {

            if (tipo_moneda_factura == 2)
                calculos_pago_recibir();
            else
                calculos_pago_recibir_cordobas();

        }

        private void viewDetalleFormaPago_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (viewDetalleFormaPago.RowCount == 0) return;
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                viewDetalleFormaPago.CloseEditor();
                viewDetalleFormaPago.UpdateCurrentRow();

                if (tipo_moneda_factura == 2)
                    calculos_pago_recibir();
                else
                    calculos_pago_recibir_cordobas();

                SendKeys.Send("{ESC}");
            }
            if (e.KeyCode == Keys.Delete)
            {
                viewDetalleFormaPago.DeleteRow(viewDetalleFormaPago.FocusedRowHandle);
                if (tipo_moneda_factura == 2)
                    calculos_pago_recibir();
                else
                    calculos_pago_recibir_cordobas();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < viewDetalleFormaPago.RowCount; i++)
            {
                viewDetalleFormaPago.SetRowCellValue(i, "monto", 0.00M);

            }
            this.viewDetalleFormaPago_RowUpdated(null, null);
            gridDetalleFormaPago.DataSource = null;
            gridDetalleFormaPago.DataSource = getTable();
        }
        private void srch_facturas_EditValueChanged(object sender, EventArgs e)
        {
            radioGroup1.Enabled = true;
            if (srch_facturas.EditValue != null)
            {

                //int id_factura = Convert.ToInt32(srch_facturas.EditValue);
                foreach (var r in Negocio.ClasesCN.VentasCN.Ventas_Select_por_ID(id_factura))
                {
                    //   txt_cliente.Text = r.cliente;
                    // txt_vendedor.Text = r.empleado;
                    fecha.Text = Convert.ToDateTime(r.fecha).ToShortDateString();
                    txt_tipo_cambio_VENTA.EditValue = r.tipo_cambio;
                    vTipo_cambio_compra = Negocio.ClasesCN.DatosRequeridosCN.Obtner_Tipo_Cambio_Mensual_compra();
                    txt_tc_COMPRA.EditValue = vTipo_cambio_compra;
                    // txtObservacion.Text = r.observacion;
                    tipo_moneda_factura = Negocio.ClasesCN.VentasCN.moneda_facatura(id_factura);

                }
                gridControl_factura.DataSource = Negocio.ClasesCN.VentasCN.VentasDetalle_Select(id_factura).ToList();
                vTipoCambio = Convert.ToDecimal(txt_tipo_cambio_VENTA.EditValue);

                calculos();
                bindingSourceDetalle.DataSource = getTable();
                //if (tipo_moneda_factura == 2)
                //{
                //    radioGroup1.Enabled = true;
                //    radioGroup1.SelectedIndex = 0;
                //}
                //else
                //{
                //    radioGroup1.SelectedIndex = 1;
                //    radioGroup1.Enabled = false;
                //}
                //calculos_pago_recibir();
            }
            else
            {
                bindingSourceDetalle.DataSource = getTable();
                // txt_cliente.Text = txtObservacion.Text = string.Empty;
                //txt_vendedor.Text = string.Empty;
                //fecha.Text = string.Empty;
                txt_tipo_cambio_VENTA.EditValue = 0.00M;
                txt_tc_COMPRA.EditValue = 0.00M;
                gridControl_factura.DataSource = null;
                calculos();
                //calculos_pago_recibir();
            }
        }
        private void bbi_guardar_Click(object sender, EventArgs e)
        {

            int Transferencia = 0;

            List<int> listTransfe = new List<int>();

            if (viewDetalleFormaPago.RowCount > 0)//gridView_factura.RowCount > 0 &&
            {
                //EL bool verifica que no se guarde transferencias repetidas, no debe permitir que otra compra tenga el mimsmo numero que una anterior
                bool duplicado = false;// Negocio.ClasesCN.CajaCN.getMovimientoCajaDetalle().Where(x => x.N_Transferencia > 0 && x.id_forma_pago == 3 && x.id_forma_pago == 4).Select(x => x.N_Transferencia).Distinct().Count() != Negocio.ClasesCN.CajaCN.getMovimientoCajaDetalle().Where(x => x.N_Transferencia > 0 && x.id_forma_pago == 3 && x.id_forma_pago == 4).Select(x => x.N_Transferencia).Count();
                if (duplicado)
                {
                    XtraMessageBox.Show("HAY DUPLICADOS");
                    return;
                }
                else
                {
                    //int suma = 0;
                    //XtraMessageBox.Show("NO HAY DUPLICADOS");
                    for (int i = 0; i < viewDetalleFormaPago.RowCount; i++)
                    {

                        if (string.IsNullOrEmpty(viewDetalleFormaPago.GetRowCellValue(i, "n_transferencia").ToString()) && (new[] { 5, 6, 7, 8, 1005, 1006 }.Contains(Convert.ToInt32(viewDetalleFormaPago.GetRowCellValue(i, "id_forma_pago")))))
                        {
                            //Cuando esta vacio y forma de pago es transferencia
                            XtraMessageBox.Show("Complete los campos de numnero de referencia", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        string fecha_deposito = viewDetalleFormaPago.GetRowCellValue(i, "fecha_deposito").ToString();
                        if (fecha_deposito == null && (new[] { 5, 6, 7, 8 }.Contains(Convert.ToInt32(viewDetalleFormaPago.GetRowCellValue(i, "id_forma_pago")))))
                        {
                            //Cuando esta vacio y forma de pago es transferencia
                            XtraMessageBox.Show("Complete los campos de fecha deposito", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        string banco = viewDetalleFormaPago.GetRowCellValue(i, "banco").ToString();
                        if (string.IsNullOrEmpty(banco) && (new[] { 1005, 1006 }.Contains(Convert.ToInt32(viewDetalleFormaPago.GetRowCellValue(i, "id_forma_pago")))))
                        {
                            //Cuando esta vacio y forma de pago es transferencia
                            XtraMessageBox.Show("Complete el campo de banco", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        if (id_saldo == 0 && (new[] { 1007, 1008 }.Contains(Convert.ToInt32(viewDetalleFormaPago.GetRowCellValue(i, "id_forma_pago")))))
                        {
                            //Cuando esta vacio y forma de pago es transferencia
                            XtraMessageBox.Show("Seleccione una factura para aplicar el saldo por favor.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                    }
                }
                if (Clases.MyMessageBox.Show("¿Desea pagar esta Factura?", "Venta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
                //int id_factura =id_factura //Convert.ToInt32(srch_facturas.EditValue);
                int id_empleado = Clases.UsuarioLogueado.vID_Empleado;


                decimal valor_vuelto = 0;
                bool hay_dolares = false;
                bool hay_cordobas = false;
                int tipo_vuelto_dar = -1;
                for (int i = 0; i < viewDetalleFormaPago.RowCount; i++)
                {
                    int tipo_moneda = Convert.ToInt32(viewDetalleFormaPago.GetRowCellValue(i, "moneda"));

                    if (tipo_moneda == 1)
                        hay_cordobas = true;
                    else if (tipo_moneda == 2)
                        hay_dolares = true;
                }

                if (tipo_moneda_factura == 2)
                {

                    if (hay_dolares && hay_cordobas)
                    {
                        valor_vuelto = radioGroup1.SelectedIndex == 0 ? Convert.ToDecimal(txt_cambio_dolares.EditValue ?? 0) : Convert.ToDecimal(txt_cambio_cordobas.EditValue ?? 0);
                        tipo_vuelto_dar = radioGroup1.SelectedIndex;
                    }
                    else if (hay_dolares && !hay_cordobas && radioGroup1.SelectedIndex == 1)
                    {
                        valor_vuelto = Convert.ToDecimal(txt_cambio_dolares.EditValue ?? 0);
                        tipo_vuelto_dar = 0;
                    }
                    else if (hay_dolares && !hay_cordobas && radioGroup1.SelectedIndex == 0)
                    {
                        valor_vuelto = Convert.ToDecimal(txt_cambio_dolares.EditValue ?? 0);
                        tipo_vuelto_dar = 0;
                    }
                    else if (!hay_dolares && hay_cordobas && radioGroup1.SelectedIndex == 0)
                    {
                        valor_vuelto = Convert.ToDecimal(txt_cambio_dolares.EditValue ?? 0) * Convert.ToDecimal(txt_tipo_cambio_VENTA.EditValue ?? 0);
                        tipo_vuelto_dar = 1;
                    }
                    else if (!hay_dolares && hay_cordobas && radioGroup1.SelectedIndex == 1)
                    {
                        valor_vuelto = Convert.ToDecimal(txt_cambio_dolares.EditValue ?? 0) * Convert.ToDecimal(txt_tipo_cambio_VENTA.EditValue ?? 0);
                        tipo_vuelto_dar = 1;
                    }
                }
                else
                {
                    valor_vuelto = Convert.ToDecimal(txt_cambio_cordobas.EditValue ?? 0);
                    tipo_vuelto_dar = 1;
                }
                if (tipo_vuelto_dar != -1)
                {
                    int id_retorno = Negocio.ClasesCN.VentasCN.FORMA_PAGO_VENTA_GUARDAR(id_factura, id_empleado, gridView_factura, viewDetalleFormaPago, tdc, tipo_vuelto_dar, valor_vuelto, fecha.DateTime.Date, Transferencia, id_saldo);

                    if (id_retorno > 0)
                    {
                        XtraMessageBox.Show("Factura pagada correctamente", "Venta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        XtraMessageBox.Show("Factura ya ha sido cancelada por otro usuario; Presionar el Botón actualizar", "Venta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
            }

        }
    }
}