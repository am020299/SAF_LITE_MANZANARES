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
using DevExpress.XtraGrid.Views.Tile;

namespace Presentacion.Formularios.Ventas
{
    public partial class xfrm_factura_caja : DevExpress.XtraEditors.XtraForm,IFormaPago
    {
        decimal sub_total, descuento_total,  total_factura, total_recibir,total_recibir_dolares;
        private decimal vTipoCambio,vTipo_cambio_compra;
        private int tipo_moneda_factura;
        public xfrm_factura_caja()
        {
            InitializeComponent();
            txt_cambio_cordobas.Properties.Mask.EditMask = "n2";
            txt_cambio_cordobas.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            txt_cambio_cordobas.Properties.Mask.UseMaskAsDisplayFormat = true;

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
        private void calculos()
        {
            if(tipo_moneda_factura == 2)
            {

                sub_total = 0; descuento_total = 0; total_factura = 0;
                for(int i = 0;i < gridView_factura.RowCount;i++)
                {
                    decimal precio = Convert.ToDecimal(gridView_factura.GetRowCellValue(i, "precio1"));
                    decimal cantidad = Convert.ToDecimal(gridView_factura.GetRowCellValue(i, "cantidad"));
                    decimal descuento = Convert.ToDecimal(gridView_factura.GetRowCellValue(i, "descuento"));
                    decimal impuesto = Convert.ToDecimal(gridView_factura.GetRowCellValue(i, "impuesto"));
                    sub_total += (Math.Round((precio * cantidad),2,MidpointRounding.AwayFromZero));
                    descuento_total += (Math.Round(((precio * cantidad) * (descuento / 100)),4,MidpointRounding.AwayFromZero));

                }

                total_factura = (Math.Round((sub_total - descuento_total) * vTipoCambio,4,MidpointRounding.AwayFromZero));
                txt_sub_total.Text = sub_total.ToString();
                txt_descuento.Text = descuento_total.ToString();
                txt_total.Text = (sub_total - descuento_total).ToString("n2");
                txt_total_cordoba.EditValue = total_factura.ToString("n2");
                calculos_pago_recibir();
            }
            else
            {
                sub_total = 0; descuento_total = 0; total_factura = 0;
                for(int i = 0;i < gridView_factura.RowCount;i++)
                {
                    decimal precio = Convert.ToDecimal(gridView_factura.GetRowCellValue(i, "precio1"));
                    decimal cantidad = Convert.ToDecimal(gridView_factura.GetRowCellValue(i, "cantidad"));
                    decimal descuento = Convert.ToDecimal(gridView_factura.GetRowCellValue(i, "descuento"));
                    decimal impuesto = Convert.ToDecimal(gridView_factura.GetRowCellValue(i, "impuesto"));
                    sub_total += (Math.Round(((precio / vTipo_cambio_compra) * cantidad),4,MidpointRounding.AwayFromZero));
                    descuento_total += (Math.Round(((precio /vTipo_cambio_compra * cantidad) * (descuento / 100)),4,MidpointRounding.AwayFromZero));

                }

                total_factura = (Math.Round((sub_total - descuento_total) * Convert.ToDecimal(txt_tc_COMPRA.EditValue ?? 1),4,MidpointRounding.AwayFromZero));
                txt_sub_total.Text = sub_total.ToString();
                txt_descuento.Text = descuento_total.ToString();
                txt_total.Text = (sub_total - descuento_total).ToString("n2");
                txt_total_cordoba.EditValue = total_factura.ToString("n2");
                calculos_pago_recibir_cordobas();

            }
        }
        private void calculos_pago_recibir( )
        {
            try
            {
                decimal total_calculo = 0;
                decimal dolares_cordobizados=0;
                txt_diferencia_cordobas.EditValue = 0;
                txt_diferencia_dolares.EditValue = 0;
                decimal Tipo_cambio_Venta=Convert.ToDecimal(txt_tipo_cambio_VENTA.EditValue??1);
                decimal Tipo_Cambio_Compra=Convert.ToDecimal(txt_tc_COMPRA.EditValue??1);

                bool hay_dolares=false;
                bool hay_cordobas=false;

                for(int i = 0;i < viewDetalleFormaPago.RowCount;i++)
                {
                    int tipo_moneda = Convert.ToInt32(viewDetalleFormaPago.GetRowCellValue(i, "moneda")??0);
                    decimal cantidad = Convert.ToDecimal(viewDetalleFormaPago.GetRowCellValue(i, "monto")??0);

                    if(tipo_moneda == 2)
                    {
                        hay_dolares = true;
                        total_calculo += (Math.Round(cantidad * vTipoCambio,4,MidpointRounding.AwayFromZero));
                        dolares_cordobizados += (Math.Round(cantidad * vTipoCambio,4,MidpointRounding.AwayFromZero));
                        txt_dolares_cordobizados.Text = dolares_cordobizados.ToString();
                    }
                    else
                    {
                        hay_cordobas = true;
                        total_calculo += cantidad;
                        txt_dolares_cordobizados.Text = dolares_cordobizados.ToString();
                    }
                }
                total_recibir = total_calculo;
                total_recibir_dolares =(total_calculo / Tipo_cambio_Venta);

                txt_total_recibir.Text = total_recibir.ToString();
                if(total_recibir > Convert.ToDecimal(txt_total_cordoba.EditValue ?? 0))
                {
                    if(hay_dolares && hay_cordobas)
                    {
                        txt_cambio_dolares.EditValue = (total_recibir_dolares - Convert.ToDecimal(txt_total.EditValue ?? 0));
                        txt_cambio_cordobas.EditValue = (total_recibir - Convert.ToDecimal(txt_total_cordoba.EditValue ?? 0));//(Convert.ToDecimal(txt_cambio_dolares.EditValue ?? 0) * Tipo_Cambio_Compra).ToString("n2");

                    }
                    else if(hay_dolares && !hay_cordobas && radioGroup1.SelectedIndex == 0)
                    {
                        txt_cambio_dolares.EditValue = (total_recibir_dolares - Convert.ToDecimal(txt_total.EditValue ?? 0));
                        txt_cambio_cordobas.EditValue = (Convert.ToDecimal(txt_cambio_dolares.EditValue ?? 0) * Tipo_Cambio_Compra);
                    }
                    else if(hay_dolares && !hay_cordobas && radioGroup1.SelectedIndex == 1)
                    {
                        txt_cambio_dolares.EditValue = (total_recibir_dolares - Convert.ToDecimal(txt_total.EditValue ?? 0));
                        txt_cambio_cordobas.EditValue = (Convert.ToDecimal(txt_cambio_dolares.EditValue ?? 0) * Tipo_Cambio_Compra);
                    }
                    else if(!hay_dolares && hay_cordobas && radioGroup1.SelectedIndex == 0)
                    {
                        txt_cambio_dolares.EditValue = (total_recibir_dolares - Convert.ToDecimal(txt_total.EditValue ?? 0));
                        txt_cambio_cordobas.EditValue = (Convert.ToDecimal(txt_cambio_dolares.EditValue ?? 0) * Tipo_Cambio_Compra);
                    }
                    else if(!hay_dolares && hay_cordobas && radioGroup1.SelectedIndex == 1)
                    {
                        txt_cambio_dolares.EditValue = (total_recibir_dolares - Convert.ToDecimal(txt_total.EditValue ?? 0));
                        txt_cambio_cordobas.EditValue = (total_recibir - Convert.ToDecimal(txt_total_cordoba.EditValue ?? 0));
                    }

                }
                else
                {
                    txt_cambio_cordobas.EditValue = 0.00;
                    txt_cambio_dolares.EditValue = 0.00;
                    txt_diferencia_cordobas.EditValue = (Convert.ToDecimal(txt_total_cordoba.EditValue ?? 0) - total_recibir);
                    txt_diferencia_dolares.EditValue = ((Convert.ToDecimal(txt_total.EditValue ?? 0) - total_recibir_dolares));
                }
                if(( Math.Round(Convert.ToDecimal(txt_diferencia_cordobas.EditValue ?? 0),2,MidpointRounding.AwayFromZero) == 0) && (Math.Round( Convert.ToDecimal(txt_diferencia_dolares.EditValue ?? 0),2,MidpointRounding.AwayFromZero) == 0))
                {
                    bbi_guardar.Enabled = true;
                      
                }
                else
                {
                    bbi_guardar.Enabled = false;
                }



            }
            catch(Exception)
            {
                
            }
        }
        private void calculos_pago_recibir_cordobas( )
        {
            try
            {
                decimal total_calculo = 0;
                decimal dolares_cordobizados=0;
                txt_diferencia_cordobas.EditValue = 0;
                txt_diferencia_dolares.EditValue = 0;
   
                decimal Tipo_Cambio_Compra=Convert.ToDecimal(txt_tc_COMPRA.EditValue??1);

              //  bool hay_dolares=false;
                //bool hay_cordobas=false;

                for(int i = 0;i < viewDetalleFormaPago.RowCount;i++)
                {
                    int tipo_moneda = Convert.ToInt32(viewDetalleFormaPago.GetRowCellValue(i, "moneda")??0);
                    decimal cantidad = Convert.ToDecimal(viewDetalleFormaPago.GetRowCellValue(i, "monto")??0);

                    if(tipo_moneda == 2)
                    {
                       // hay_dolares = true;
                        total_calculo += (Math.Round(cantidad * vTipo_cambio_compra,4,MidpointRounding.AwayFromZero));
                        dolares_cordobizados += (Math.Round(cantidad * vTipo_cambio_compra,4,MidpointRounding.AwayFromZero));
                        txt_dolares_cordobizados.Text = dolares_cordobizados.ToString("n2");
                    }
                    else
                    {
                       // hay_cordobas = true;
                        total_calculo += cantidad;
                        txt_dolares_cordobizados.Text = dolares_cordobizados.ToString("n2");
                    }
                }
                total_recibir = total_calculo;
                total_recibir_dolares = total_calculo / vTipo_cambio_compra;

                txt_total_recibir.Text = total_recibir.ToString();
                if(total_recibir > Convert.ToDecimal(txt_total_cordoba.EditValue ?? 0))
                {
                    txt_cambio_dolares.EditValue = (total_recibir_dolares - Convert.ToDecimal(txt_total.EditValue ?? 0)).ToString();
                    txt_cambio_cordobas.EditValue = (total_recibir - Convert.ToDecimal(txt_total_cordoba.EditValue ?? 0)).ToString();
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
                    txt_cambio_cordobas.EditValue = 0.00.ToString();
                    txt_cambio_dolares.EditValue = 0.00.ToString();
                    txt_diferencia_cordobas.EditValue = (Convert.ToDecimal(txt_total_cordoba.EditValue ?? 0) - total_recibir);
                    txt_diferencia_dolares.EditValue = ((Convert.ToDecimal(txt_total_cordoba.EditValue ?? 0) - total_recibir) / vTipo_cambio_compra);
                }
                if((Convert.ToDecimal(txt_diferencia_cordobas.EditValue ?? 0) == 0) && (Convert.ToDecimal(txt_diferencia_dolares.EditValue ?? 0) == 0))
                {
                    bbi_guardar.Enabled = true;

                }
                else
                {
                    bbi_guardar.Enabled = false;
                }
            }
            catch(Exception)
            {

            }
        }
        private DataTable getTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id_forma_pago", typeof(int));
            dt.Columns.Add("monto", typeof(decimal));
            dt.Columns.Add("moneda", typeof(int));
            dt.Columns.Add("tipo_cambio", typeof(decimal));
            return dt;
        }
        private void cargar_forma_pago()
        {
            bindingSourceDetalle.DataSource = null;
            bindingSourceDetalle.DataSource = getTable();           
            bindingSourceFormaPago.DataSource = Negocio.ClasesCN.VentasCN.FormaPago_Select();
        }
        private void xfrm_factura_caja_Load(object sender, EventArgs e)
        {
            repositorio_bodega.DataSource = Negocio.ClasesCN.CatalogosCN.Bodega_Cargar().ToList();
            srch_facturas.Properties.DataSource= Negocio.ClasesCN.VentasCN.Ventas_Select(1).Where(o =>o.activo == true && (o.estado ==1 || o.estado==3)).ToList();
            repositoryItemLookUpEdit_Moneda.DataSource = Negocio.ClasesCN.CatalogosCN.getMoneda();
            cargar_forma_pago();
        }
        private GridView viewPago;
        public bool FormaPago(GridView view)
        {
            viewPago = view;
            if (viewPago.RowCount > 0) return true;
            else return false;
        }
        private void bbi_guardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView_factura.RowCount > 0 && viewDetalleFormaPago.RowCount>0)
            {
                if (Clases.MyMessageBox.Show("¿Desea pagar esta Factura?", "Venta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
                int id_factura = Convert.ToInt32(srch_facturas.EditValue);
                int id_empleado = Clases.UsuarioLogueado.vID_Empleado;
                decimal valor_vuelto=0;
                bool hay_dolares=false;
                bool hay_cordobas=false;
                int tipo_vuelto_dar=-1;
                for(int i = 0;i < viewDetalleFormaPago.RowCount;i++)
                {
                   int tipo_moneda = Convert.ToInt32(viewDetalleFormaPago.GetRowCellValue(i, "moneda"));

                    if(tipo_moneda == 1)
                        hay_cordobas = true;
                    else if (tipo_moneda==2)
                        hay_dolares = true;
                }

                if(tipo_moneda_factura == 2)
                {

                    if(hay_dolares && hay_cordobas)
                    {
                        valor_vuelto = radioGroup1.SelectedIndex == 0 ? Convert.ToDecimal(txt_cambio_dolares.EditValue ?? 0) : Convert.ToDecimal(txt_cambio_cordobas.EditValue ?? 0);
                        tipo_vuelto_dar = radioGroup1.SelectedIndex;
                    }
                    else if(hay_dolares && !hay_cordobas && radioGroup1.SelectedIndex == 1)
                    {
                        valor_vuelto = Convert.ToDecimal(txt_cambio_dolares.EditValue ?? 0);
                        tipo_vuelto_dar = 0;
                    }
                    else if(hay_dolares && !hay_cordobas && radioGroup1.SelectedIndex == 0)
                    {
                        valor_vuelto = Convert.ToDecimal(txt_cambio_dolares.EditValue ?? 0);
                        tipo_vuelto_dar = 0;
                    }
                    else if(!hay_dolares && hay_cordobas && radioGroup1.SelectedIndex == 0)
                    {
                        valor_vuelto = Convert.ToDecimal(txt_cambio_dolares.EditValue ?? 0) * Convert.ToDecimal(txt_tipo_cambio_VENTA.EditValue ?? 0);
                        tipo_vuelto_dar = 1;
                    }
                    else if(!hay_dolares && hay_cordobas && radioGroup1.SelectedIndex == 1)
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
                if(tipo_vuelto_dar != -1)
                {
                    int id_retorno = Negocio.ClasesCN.VentasCN.FORMA_PAGO_VENTA_GUARDAR(id_factura, id_empleado, gridView_factura, viewDetalleFormaPago,1,tipo_vuelto_dar,valor_vuelto,fecha.DateTime.Date,0,0);


                    if(id_retorno > 0)
                    {
                        XtraMessageBox.Show("Factura pagada correctamente","Venta",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        srch_facturas.EditValue = null;
                        srch_facturas.Properties.DataSource = Negocio.ClasesCN.VentasCN.Ventas_Select(1).Where(o => o.estado == 1 || o.estado == 3).ToList();
                        BindingSource source = new BindingSource();

                        source.DataSource = Negocio.ClasesCN.VentasCN.Venta_Reporte(id_factura); 
                        var report = new Reportes.Ventas.FacturaTermica(source);
                        report.ShowPreviewDialog();
                        report.Dispose();


                    }
                }
            }
        }
        private void tileViewFormaPago_ItemClick(object sender, DevExpress.XtraGrid.Views.Tile.TileViewItemClickEventArgs e)
        {
            TileView view = sender as TileView;
            try
            {
                if(srch_facturas.EditValue!= null)
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
                            viewDetalleFormaPago.SetRowCellValue(rowHandler, "monto",0.00M);
                            viewDetalleFormaPago.SetRowCellValue(rowHandler, "moneda", query.moneda);
                            if(tipo_moneda_factura == 1)
                            {
                                if(query.moneda == 1) viewDetalleFormaPago.SetRowCellValue(rowHandler,"tipo_cambio",vTipoCambio);
                                else viewDetalleFormaPago.SetRowCellValue(rowHandler,"tipo_cambio",vTipo_cambio_compra);
                            }
                            else if (tipo_moneda_factura==2)
                            {
                                if(query.moneda == 1) viewDetalleFormaPago.SetRowCellValue(rowHandler,"tipo_cambio",vTipoCambio);
                                else viewDetalleFormaPago.SetRowCellValue(rowHandler,"tipo_cambio",vTipoCambio);
                            }
                            viewDetalleFormaPago.FocusedRowHandle = rowHandler;
                        }
                    }
                    viewDetalleFormaPago.Focus();
                }
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
                if(tipo_moneda_factura == 2)
                    calculos_pago_recibir();
                else
                    calculos_pago_recibir_cordobas();
            }
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

        private void radioGroup1_SelectedIndexChanged(object sender,EventArgs e)
        {
            if(tipo_moneda_factura == 2)
                calculos_pago_recibir();
            else
                calculos_pago_recibir_cordobas();
        }

        private void viewDetalleFormaPago_RowUpdated(object sender, RowObjectEventArgs e)
        {
            if(tipo_moneda_factura == 2)
                calculos_pago_recibir();
            else
                calculos_pago_recibir_cordobas();
        }

        private void txt_total_recibir_EditValueChanged(object sender,EventArgs e)
        {

        }

        private void bbi_actualizar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            srch_facturas.Properties.DataSource = Negocio.ClasesCN.VentasCN.Ventas_Select(1).Where(o => o.estado == 1).ToList();
        }
        private void xfrm_factura_caja_Activated(object sender, EventArgs e)
        {
            srch_facturas.Properties.DataSource = Negocio.ClasesCN.VentasCN.Ventas_Select(1).Where(o => o.estado ==1 || o.estado == 3).ToList();
        }
        private void srch_facturas_EditValueChanged(object sender, EventArgs e)
        {
            radioGroup1.Enabled = true;
            if(srch_facturas.EditValue!= null)
            {
               
                int id_factura = Convert.ToInt32(srch_facturas.EditValue);
                foreach (var r in Negocio.ClasesCN.VentasCN.Ventas_Select_por_ID(id_factura))
                {
                    txt_cliente.Text = r.cliente;
                    txt_vendedor.Text = r.empleado;
                    fecha.Text = Convert.ToDateTime(r.fecha).ToShortDateString();
                    txt_tipo_cambio_VENTA.Text = r.tipo_cambio.ToString();
                    vTipo_cambio_compra = Negocio.ClasesCN.DatosRequeridosCN.Obtner_Tipo_Cambio_Mensual_compra();
                    txt_tc_COMPRA.EditValue = vTipo_cambio_compra;
                    txtObservacion.Text = r.observacion;
                    tipo_moneda_factura=Negocio.ClasesCN.VentasCN.moneda_facatura(id_factura);
                    
                }
                gridControl_factura.DataSource = Negocio.ClasesCN.VentasCN.VentasDetalle_Select(id_factura).ToList();
                vTipoCambio = Convert.ToDecimal(txt_tipo_cambio_VENTA.EditValue);

                calculos();
                bindingSourceDetalle.DataSource = getTable();
                if(tipo_moneda_factura == 2)
                {
                    radioGroup1.Enabled = true;
                    radioGroup1.SelectedIndex = 0;
                }
                else
                {
                    radioGroup1.SelectedIndex = 1;
                    radioGroup1.Enabled = false;
                }
                //calculos_pago_recibir();
            }
            else
            {
                 bindingSourceDetalle.DataSource = getTable();
                txt_cliente.Text = txtObservacion.Text = string.Empty;
                txt_vendedor.Text = string.Empty;
                fecha.Text = string.Empty;
                txt_tipo_cambio_VENTA.Text =0.ToString();
                txt_tc_COMPRA.Text = 0.ToString();
                gridControl_factura.DataSource = null;
                calculos();
                //calculos_pago_recibir();
            }
        }
    }
}