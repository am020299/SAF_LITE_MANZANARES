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
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraReports.UI;
using DevExpress.XtraGrid;
using Presentacion.Formularios.Catalogos;
using DevExpress.XtraGrid.Views.Base;
using Presentacion.Reportes.Caja;

namespace Presentacion.Formularios.Caja
{
    public partial class xfrm_arqueo_detalle : DevExpress.XtraEditors.XtraForm
    {
        int id_arqueo = 0;
        public xfrm_arqueo_detalle()
        {
            InitializeComponent();

            txt_venta_dolares.Properties.Mask.EditMask = "n2";
            txt_venta_dolares.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            txt_venta_dolares.Properties.Mask.UseMaskAsDisplayFormat = true;

            txt_venta_cordobizada.Properties.Mask.EditMask = "n2";
            txt_venta_cordobizada.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            txt_venta_cordobizada.Properties.Mask.UseMaskAsDisplayFormat = true;

            txt_venta_cordobas.Properties.Mask.EditMask = "n2";
            txt_venta_cordobas.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            txt_venta_cordobas.Properties.Mask.UseMaskAsDisplayFormat = true;


            txt_venta_total.Properties.Mask.EditMask = "n2";
            txt_venta_total.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            txt_venta_total.Properties.Mask.UseMaskAsDisplayFormat = true;


            txt_venta_esperada.Properties.Mask.EditMask = "n2";
            txt_venta_esperada.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            txt_venta_esperada.Properties.Mask.UseMaskAsDisplayFormat = true;


            txt_diferencia_en_caja.Properties.Mask.EditMask = "n2";
            txt_diferencia_en_caja.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            txt_diferencia_en_caja.Properties.Mask.UseMaskAsDisplayFormat = true;

            txt_total_cordobas_iniciales.Properties.Mask.EditMask = "n2";
            txt_total_cordobas_iniciales.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            txt_total_cordobas_iniciales.Properties.Mask.UseMaskAsDisplayFormat = true;

            txt_total_caja_inicial.Properties.Mask.EditMask = "n2";
            txt_total_caja_inicial.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            txt_total_caja_inicial.Properties.Mask.UseMaskAsDisplayFormat = true;

            txt_total_dolares_inicial.Properties.Mask.EditMask = "n2";
            txt_total_dolares_inicial.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            txt_total_dolares_inicial.Properties.Mask.UseMaskAsDisplayFormat = true;

            txt_dolares_cordobizados_inicial.Properties.Mask.EditMask = "n2";
            txt_dolares_cordobizados_inicial.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            txt_dolares_cordobizados_inicial.Properties.Mask.UseMaskAsDisplayFormat = true;

            txt_cordobas_finales.Properties.Mask.EditMask = "n2";
            txt_cordobas_finales.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            txt_cordobas_finales.Properties.Mask.UseMaskAsDisplayFormat = true;

            txt_total_caja_final.Properties.Mask.EditMask = "n2";
            txt_total_caja_final.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            txt_total_caja_final.Properties.Mask.UseMaskAsDisplayFormat = true;

            txt_dolares_final.Properties.Mask.EditMask = "n2";
            txt_dolares_final.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            txt_dolares_final.Properties.Mask.UseMaskAsDisplayFormat = true;

            txt_dolares_cordobizados_final.Properties.Mask.EditMask = "n2";
            txt_dolares_cordobizados_final.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            txt_dolares_cordobizados_final.Properties.Mask.UseMaskAsDisplayFormat = true;

            txt_cheques_finales_suma.Properties.Mask.EditMask = "n2";
            txt_cheques_finales_suma.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            txt_cheques_finales_suma.Properties.Mask.UseMaskAsDisplayFormat = true;
        }
        private bool Es_Entero(object valor)
        {
            try
            {
                int d = 0;
                if (int.TryParse(valor.ToString(), out d))
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        private bool es_decimal(object valor)
        {
            try
            {
                decimal d = 0;
                if (decimal.TryParse(valor.ToString(), out d))
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private void cargar()
        {
            decimal suma_cheque_cordobas = 0.00M, suma_vales_cordobas = 0.00M, suma_vouchers_cordobas = 0.00M, suma_cheques_dolares = 0.00M, suma_vales_dolares = 0.00M, suma_vouchers_dolares = 0.00M;


            var D = Negocio.ClasesCN.CajaCN.Buscar_Arqueo_Fecha(dt_fecha_arqueo.DateTime, Clases.UsuarioLogueado.vID_Empleado);


            if (D == null)
            {
                txt_tc.Text = Negocio.ClasesCN.DatosRequeridosCN.obtener_tipo_cambio_mensual().ToString();
                // var Arqueo_blanco=Negocio.ClasesCN.CajaCN.Arqueo_en_blanco().ToList();
                binding_inicial_cordobas.DataSource = Negocio.ClasesCN.CajaCN.Arqueo_en_blanco().Where(S => S.tipo_moneda == 1 && S.tipo_denominacion != 3).ToList();
                binding_inicial_dolares.DataSource = Negocio.ClasesCN.CajaCN.Arqueo_en_blanco().Where(S => S.tipo_moneda == 2 && S.tipo_denominacion != 3).ToList();
                binding_final_cordobas.DataSource = Negocio.ClasesCN.CajaCN.Arqueo_en_blanco().Where(T => T.tipo_moneda == 1).ToList();
                binding_final_dolares.DataSource = Negocio.ClasesCN.CajaCN.Arqueo_en_blanco().Where(T => T.tipo_moneda == 2).ToList();

                txt_total_caja_inicial.EditValue = 0.00M;
                txt_total_caja_final.EditValue = 0.00M;
                txt_total_cordobas_iniciales.EditValue = 0.00M;
                txt_total_dolares_inicial.EditValue = 0.00M;
                txt_total_caja_final.EditValue = 0.00M;
                txt_cordobas_finales.EditValue = 0.00M;
                txt_dolares_cordobizados_final.EditValue = 0.00M;
                txt_dolares_cordobizados_inicial.EditValue = 0.00;
                txt_dolares_final.EditValue = 0.00M;
                id_arqueo = 0;
            }
            else
            {

                if (D.id_registro > 0)
                {
                    id_arqueo = D.id_registro;
                    if (D.estado_arqueo == 2)
                    {
                        gview_caja_inicial_cordobas.OptionsBehavior.ReadOnly = true;
                        gview_caja_inicial_dolares.OptionsBehavior.ReadOnly = true;
                        gview_caja_final_dolares.OptionsBehavior.ReadOnly = true;
                        gview_caja_final_cordobas.OptionsBehavior.ReadOnly = true;

                    }
                    else
                    {
                        gview_caja_inicial_cordobas.OptionsBehavior.ReadOnly = false;
                        gview_caja_inicial_dolares.OptionsBehavior.ReadOnly = false;
                        gview_caja_final_dolares.OptionsBehavior.ReadOnly = false;
                        gview_caja_final_cordobas.OptionsBehavior.ReadOnly = false;
                    }


                    txt_tc.Text = D.tipo_camibio.Value.ToString();
                    binding_inicial_cordobas.DataSource = Negocio.ClasesCN.CajaCN.Cargar_Arqueo_por_ID(id_arqueo).Where(S => S.tipo_moneda == 1 && S.tipo_arqueo == 1).ToList();
                    binding_inicial_dolares.DataSource = Negocio.ClasesCN.CajaCN.Cargar_Arqueo_por_ID(id_arqueo).Where(S => S.tipo_moneda == 2 && S.tipo_arqueo == 1).ToList();
                    binding_final_cordobas.DataSource = Negocio.ClasesCN.CajaCN.Cargar_Arqueo_por_ID(id_arqueo).Where(T => T.tipo_moneda == 1 && T.tipo_arqueo == 2).ToList();
                    binding_final_dolares.DataSource = Negocio.ClasesCN.CajaCN.Cargar_Arqueo_por_ID(id_arqueo).Where(T => T.tipo_moneda == 2 && T.tipo_arqueo == 2).ToList();



                    grid_caja_inicial_cordobas.ForceInitialize();
                    grid_inicial_dolares.ForceInitialize();
                    grid_caja_final_cordobas.ForceInitialize();
                    grid_caja_final_dolares.ForceInitialize();

                    var suma_total_cordobas = Convert.ToDecimal(gview_caja_inicial_cordobas.Columns["total"].SummaryItem.SummaryValue);
                    txt_total_cordobas_iniciales.EditValue = suma_total_cordobas;
                    txt_total_caja_inicial.EditValue = suma_total_cordobas + Convert.ToDecimal(txt_dolares_cordobizados_inicial.EditValue ?? 0);


                    var suma_total_dolares = Convert.ToDecimal(gview_caja_inicial_dolares.Columns["total"].SummaryItem.SummaryValue);
                    txt_total_dolares_inicial.EditValue = suma_total_dolares;
                    txt_dolares_cordobizados_inicial.EditValue = Convert.ToDecimal(txt_total_dolares_inicial.EditValue ?? 0) * Convert.ToDecimal(txt_tc.EditValue ?? 0);
                    txt_total_caja_inicial.EditValue = Convert.ToDecimal(txt_dolares_cordobizados_inicial.EditValue ?? 0) + Convert.ToDecimal(txt_total_cordobas_iniciales.EditValue ?? 0);


                    var suma_total_cordobas_final = Convert.ToDecimal(gview_caja_final_cordobas.Columns["total1"].SummaryItem.SummaryValue);
                    txt_cordobas_finales.EditValue = suma_total_cordobas_final;
                    txt_total_caja_final.EditValue = suma_total_cordobas_final + Convert.ToDecimal(txt_dolares_cordobizados_final.EditValue ?? 0);

                    var suma_total_dolares_final = Convert.ToDecimal(gview_caja_final_dolares.Columns["total1"].SummaryItem.SummaryValue);//LE cmbié a total1 para la columna total
                    txt_dolares_final.EditValue = suma_total_dolares_final;
                    txt_dolares_cordobizados_final.EditValue = Convert.ToDecimal(txt_dolares_final.EditValue ?? 0) * Convert.ToDecimal(txt_tc.EditValue ?? 0);
                    txt_total_caja_final.EditValue = Convert.ToDecimal(txt_dolares_cordobizados_final.EditValue ?? 0) + Convert.ToDecimal(txt_cordobas_finales.EditValue ?? 0);

                    suma_cheque_cordobas = Convert.ToDecimal(gview_caja_final_cordobas.Columns["cantidad"].Summary[0].SummaryValue);
                    suma_vales_cordobas = Convert.ToDecimal(gview_caja_final_cordobas.Columns["cantidad"].Summary[1].SummaryValue);
                    suma_vouchers_cordobas = Convert.ToDecimal(gview_caja_final_cordobas.Columns["cantidad"].Summary[2].SummaryValue);
                    suma_vales_dolares = Convert.ToDecimal(gview_caja_final_dolares.Columns["cantidad"].Summary[1].SummaryValue) * Convert.ToDecimal(txt_tc.EditValue ?? 0);
                    suma_vouchers_dolares = Convert.ToDecimal(gview_caja_final_dolares.Columns["cantidad"].Summary[2].SummaryValue) * Convert.ToDecimal(txt_tc.EditValue ?? 0);

                    suma_cheques_dolares = Convert.ToDecimal(gview_caja_final_dolares.Columns["cantidad"].Summary[0].SummaryValue) * Convert.ToDecimal(txt_tc.EditValue ?? 0);

                    txt_cheques_finales_suma.EditValue = suma_cheque_cordobas + suma_cheques_dolares;

                }
                else
                {
                    txt_tc.Text = Negocio.ClasesCN.DatosRequeridosCN.obtener_tipo_cambio_mensual().ToString();
                    // var Arqueo_blanco=Negocio.ClasesCN.CajaCN.Arqueo_en_blanco().ToList();
                    binding_inicial_cordobas.DataSource = Negocio.ClasesCN.CajaCN.Arqueo_en_blanco().Where(S => S.tipo_moneda == 1 && S.tipo_denominacion != 3 && S.tipo_denominacion != 4 && S.tipo_denominacion != 5 && S.tipo_denominacion != 6).ToList();
                    binding_inicial_dolares.DataSource = Negocio.ClasesCN.CajaCN.Arqueo_en_blanco().Where(S => S.tipo_moneda == 2 && S.tipo_denominacion != 3 && S.tipo_denominacion != 4 && S.tipo_denominacion != 5 && S.tipo_denominacion != 6).ToList();
                    binding_final_cordobas.DataSource = Negocio.ClasesCN.CajaCN.Arqueo_en_blanco().Where(T => T.tipo_moneda == 1).ToList();
                    binding_final_dolares.DataSource = Negocio.ClasesCN.CajaCN.Arqueo_en_blanco().Where(T => T.tipo_moneda == 2).ToList();

                    txt_total_caja_inicial.EditValue = 0.00M;
                    txt_total_caja_final.EditValue = 0.00M;
                    txt_total_cordobas_iniciales.EditValue = 0.00M;
                    txt_total_dolares_inicial.EditValue = 0.00M;
                    txt_total_caja_final.EditValue = 0.00M;
                    txt_cordobas_finales.EditValue = 0.00M;
                    txt_dolares_cordobizados_final.EditValue = 0.00M;
                    txt_dolares_cordobizados_inicial.EditValue = 0.00;
                    txt_dolares_final.EditValue = 0.00M;
                    txt_cheques_finales_suma.EditValue = 0.00M;
                    id_arqueo = 0;
                    gview_caja_inicial_cordobas.Focus();

                }
            }

            var movimientoCajas = Negocio.ClasesCN.CajaCN.MOVIMIENTO_CAJA_MOSTRAR_EMPLEADO(dt_fecha_arqueo.DateTime.Date, Clases.UsuarioLogueado.vID_Empleado);
            var movimientoCajas_Cordoba = Negocio.ClasesCN.CajaCN.MOVIMIENTO_CAJA_MOSTRAR_CORDOBAS_EMPLEADO(dt_fecha_arqueo.DateTime.Date, Clases.UsuarioLogueado.vID_Empleado);

            txt_venta_dolares.EditValue = movimientoCajas.Where(R => R.tipo_documento == 6).Sum(F => F.ingreso);
            txt_venta_cordobizada.EditValue = movimientoCajas.Where(R => R.tipo_documento == 6).Sum(F => F.ingreso) * Convert.ToDecimal(txt_tc.EditValue ?? 0);
            txt_venta_cordobas.EditValue = movimientoCajas_Cordoba.Sum(F => F.ingreso);
            txt_venta_total.EditValue = Convert.ToDecimal(txt_venta_cordobizada.EditValue ?? 0) + Convert.ToDecimal(txt_venta_cordobas.EditValue ?? 0);
            txt_venta_esperada.EditValue = Convert.ToDecimal(txt_total_caja_final.EditValue ?? 0) - Convert.ToDecimal(txt_total_caja_inicial.EditValue ?? 0);
            txt_diferencia_en_caja.EditValue = Convert.ToDecimal(txt_venta_esperada.EditValue ?? 0) - Convert.ToDecimal(txt_venta_total.EditValue ?? 0)  + suma_vales_cordobas + suma_vouchers_cordobas + suma_vouchers_dolares + suma_vales_dolares;

        }

        private void cargarAdmin()
        {
            decimal suma_cheque_cordobas = 0.00M, suma_vales_cordobas = 0.00M, suma_vouchers_cordobas = 0.00M, suma_cheques_dolares = 0.00M, suma_vales_dolares = 0.00M, suma_vouchers_dolares = 0.00M;
            decimal tipoC = 0;
            int contadorCierre = 0;

            var D = Negocio.ClasesCN.CajaCN.Buscar_Arqueo_Fecha_Validar(dt_fecha_arqueo.DateTime);


            if (D.Count == 0)
            {
                txt_tc.Text = Negocio.ClasesCN.DatosRequeridosCN.obtener_tipo_cambio_mensual().ToString();
                // var Arqueo_blanco=Negocio.ClasesCN.CajaCN.Arqueo_en_blanco().ToList();
                binding_inicial_cordobas.DataSource = Negocio.ClasesCN.CajaCN.Arqueo_en_blanco().Where(S => S.tipo_moneda == 1 && S.tipo_denominacion != 3).ToList();
                binding_inicial_dolares.DataSource = Negocio.ClasesCN.CajaCN.Arqueo_en_blanco().Where(S => S.tipo_moneda == 2 && S.tipo_denominacion != 3).ToList();
                binding_final_cordobas.DataSource = Negocio.ClasesCN.CajaCN.Arqueo_en_blanco().Where(T => T.tipo_moneda == 1).ToList();
                binding_final_dolares.DataSource = Negocio.ClasesCN.CajaCN.Arqueo_en_blanco().Where(T => T.tipo_moneda == 2).ToList();

                txt_total_caja_inicial.EditValue = 0.00M;
                txt_total_caja_final.EditValue = 0.00M;
                txt_total_cordobas_iniciales.EditValue = 0.00M;
                txt_total_dolares_inicial.EditValue = 0.00M;
                txt_total_caja_final.EditValue = 0.00M;
                txt_cordobas_finales.EditValue = 0.00M;
                txt_dolares_cordobizados_final.EditValue = 0.00M;
                txt_dolares_cordobizados_inicial.EditValue = 0.00;
                txt_dolares_final.EditValue = 0.00M;
                id_arqueo = 0;
            }
            else
            {

                if (D.Count > 0)
                {
                    //id_arqueo = D.id_registro;

                    foreach (var list in D)
                    {
                        if (list.estado_arqueo == 2)
                        {
                            contadorCierre++;
                        }
                        else
                        {
                            continue;
                        }
                    }

                    if (contadorCierre == 2)
                    {
                        gview_caja_inicial_cordobas.OptionsBehavior.ReadOnly = true;
                        gview_caja_inicial_dolares.OptionsBehavior.ReadOnly = true;
                        gview_caja_final_dolares.OptionsBehavior.ReadOnly = true;
                        gview_caja_final_cordobas.OptionsBehavior.ReadOnly = true;

                    }
                    else
                    {
                        gview_caja_inicial_cordobas.OptionsBehavior.ReadOnly = false;
                        gview_caja_inicial_dolares.OptionsBehavior.ReadOnly = false;
                        gview_caja_final_dolares.OptionsBehavior.ReadOnly = false;
                        gview_caja_final_cordobas.OptionsBehavior.ReadOnly = false;
                    }

                    foreach (var list in D)
                    {
                        tipoC = Convert.ToDecimal(list.tipo_camibio);
                    }

                    txt_tc.Text = tipoC.ToString();
                    binding_inicial_cordobas.DataSource = Negocio.ClasesCN.CajaCN.Cargar_Arqueo_por_Fecha(dt_fecha_arqueo.DateTime).Where(S => S.tipo_moneda == 1 && S.tipo_arqueo == 1).ToList();
                    binding_inicial_dolares.DataSource = Negocio.ClasesCN.CajaCN.Cargar_Arqueo_por_Fecha(dt_fecha_arqueo.DateTime).Where(S => S.tipo_moneda == 2 && S.tipo_arqueo == 1).ToList();
                    binding_final_cordobas.DataSource = Negocio.ClasesCN.CajaCN.Cargar_Arqueo_por_Fecha(dt_fecha_arqueo.DateTime).Where(T => T.tipo_moneda == 1 && T.tipo_arqueo == 2).ToList();
                    binding_final_dolares.DataSource = Negocio.ClasesCN.CajaCN.Cargar_Arqueo_por_Fecha(dt_fecha_arqueo.DateTime).Where(T => T.tipo_moneda == 2 && T.tipo_arqueo == 2).ToList();



                    grid_caja_inicial_cordobas.ForceInitialize();
                    grid_inicial_dolares.ForceInitialize();
                    grid_caja_final_cordobas.ForceInitialize();
                    grid_caja_final_dolares.ForceInitialize();

                    var suma_total_cordobas = Convert.ToDecimal(gview_caja_inicial_cordobas.Columns["total"].SummaryItem.SummaryValue);
                    txt_total_cordobas_iniciales.EditValue = suma_total_cordobas;
                    txt_total_caja_inicial.EditValue = suma_total_cordobas + Convert.ToDecimal(txt_dolares_cordobizados_inicial.EditValue ?? 0);


                    var suma_total_dolares = Convert.ToDecimal(gview_caja_inicial_dolares.Columns["total"].SummaryItem.SummaryValue);
                    txt_total_dolares_inicial.EditValue = suma_total_dolares;
                    txt_dolares_cordobizados_inicial.EditValue = Convert.ToDecimal(txt_total_dolares_inicial.EditValue ?? 0) * Convert.ToDecimal(txt_tc.EditValue ?? 0);
                    txt_total_caja_inicial.EditValue = Convert.ToDecimal(txt_dolares_cordobizados_inicial.EditValue ?? 0) + Convert.ToDecimal(txt_total_cordobas_iniciales.EditValue ?? 0);


                    var suma_total_cordobas_final = Convert.ToDecimal(gview_caja_final_cordobas.Columns["total1"].SummaryItem.SummaryValue);
                    txt_cordobas_finales.EditValue = suma_total_cordobas_final;
                    txt_total_caja_final.EditValue = suma_total_cordobas_final + Convert.ToDecimal(txt_dolares_cordobizados_final.EditValue ?? 0);

                    var suma_total_dolares_final = Convert.ToDecimal(gview_caja_final_dolares.Columns["total1"].SummaryItem.SummaryValue);//LE cmbié a total1 para la columna total
                    txt_dolares_final.EditValue = suma_total_dolares_final;
                    txt_dolares_cordobizados_final.EditValue = Convert.ToDecimal(txt_dolares_final.EditValue ?? 0) * Convert.ToDecimal(txt_tc.EditValue ?? 0);
                    txt_total_caja_final.EditValue = Convert.ToDecimal(txt_dolares_cordobizados_final.EditValue ?? 0) + Convert.ToDecimal(txt_cordobas_finales.EditValue ?? 0);

                    suma_cheque_cordobas = Convert.ToDecimal(gview_caja_final_cordobas.Columns["cantidad"].Summary[0].SummaryValue);
                    suma_vales_cordobas = Convert.ToDecimal(gview_caja_final_cordobas.Columns["cantidad"].Summary[1].SummaryValue);
                    suma_vouchers_cordobas = Convert.ToDecimal(gview_caja_final_cordobas.Columns["cantidad"].Summary[2].SummaryValue);
                    suma_vales_dolares = Convert.ToDecimal(gview_caja_final_dolares.Columns["cantidad"].Summary[1].SummaryValue) * Convert.ToDecimal(txt_tc.EditValue ?? 0);
                    suma_vouchers_dolares = Convert.ToDecimal(gview_caja_final_dolares.Columns["cantidad"].Summary[2].SummaryValue) * Convert.ToDecimal(txt_tc.EditValue ?? 0);

                    suma_cheques_dolares = Convert.ToDecimal(gview_caja_final_dolares.Columns["cantidad"].Summary[0].SummaryValue) * Convert.ToDecimal(txt_tc.EditValue ?? 0);

                    txt_cheques_finales_suma.EditValue = suma_cheque_cordobas + suma_cheques_dolares;

                }
                else
                {
                    txt_tc.Text = Negocio.ClasesCN.DatosRequeridosCN.obtener_tipo_cambio_mensual().ToString();
                    // var Arqueo_blanco=Negocio.ClasesCN.CajaCN.Arqueo_en_blanco().ToList();
                    binding_inicial_cordobas.DataSource = Negocio.ClasesCN.CajaCN.Arqueo_en_blanco().Where(S => S.tipo_moneda == 1 && S.tipo_denominacion != 3 && S.tipo_denominacion != 4 && S.tipo_denominacion != 5 && S.tipo_denominacion != 6).ToList();
                    binding_inicial_dolares.DataSource = Negocio.ClasesCN.CajaCN.Arqueo_en_blanco().Where(S => S.tipo_moneda == 2 && S.tipo_denominacion != 3 && S.tipo_denominacion != 4 && S.tipo_denominacion != 5 && S.tipo_denominacion != 6).ToList();
                    binding_final_cordobas.DataSource = Negocio.ClasesCN.CajaCN.Arqueo_en_blanco().Where(T => T.tipo_moneda == 1).ToList();
                    binding_final_dolares.DataSource = Negocio.ClasesCN.CajaCN.Arqueo_en_blanco().Where(T => T.tipo_moneda == 2).ToList();

                    txt_total_caja_inicial.EditValue = 0.00M;
                    txt_total_caja_final.EditValue = 0.00M;
                    txt_total_cordobas_iniciales.EditValue = 0.00M;
                    txt_total_dolares_inicial.EditValue = 0.00M;
                    txt_total_caja_final.EditValue = 0.00M;
                    txt_cordobas_finales.EditValue = 0.00M;
                    txt_dolares_cordobizados_final.EditValue = 0.00M;
                    txt_dolares_cordobizados_inicial.EditValue = 0.00;
                    txt_dolares_final.EditValue = 0.00M;
                    txt_cheques_finales_suma.EditValue = 0.00M;
                    id_arqueo = 0;
                    gview_caja_inicial_cordobas.Focus();

                }
            }

            var movimientoCajas = Negocio.ClasesCN.CajaCN.MOVIMIENTO_CAJA_MOSTRAR(dt_fecha_arqueo.DateTime.Date);
            var movimientoCajas_Cordoba = Negocio.ClasesCN.CajaCN.MOVIMIENTO_CAJA_MOSTRAR_CORDOBAS(dt_fecha_arqueo.DateTime.Date);

            txt_venta_dolares.EditValue = movimientoCajas.Where(R => R.tipo_documento == 6).Sum(F => F.ingreso);
            txt_venta_cordobizada.EditValue = movimientoCajas.Where(R => R.tipo_documento == 6).Sum(F => F.ingreso) * Convert.ToDecimal(txt_tc.EditValue ?? 0);
            txt_venta_cordobas.EditValue = movimientoCajas_Cordoba.Sum(F => F.ingreso);
            txt_venta_total.EditValue = Convert.ToDecimal(txt_venta_cordobizada.EditValue ?? 0) + Convert.ToDecimal(txt_venta_cordobas.EditValue ?? 0);
            txt_venta_esperada.EditValue = Convert.ToDecimal(txt_total_caja_final.EditValue ?? 0) - Convert.ToDecimal(txt_total_caja_inicial.EditValue ?? 0);
            txt_cheques_finales_suma.EditValue = suma_cheque_cordobas + suma_cheques_dolares;
            txt_diferencia_en_caja.EditValue = Convert.ToDecimal(txt_venta_esperada.EditValue ?? 0) - Convert.ToDecimal(txt_venta_total.EditValue ?? 0) + suma_vales_cordobas + suma_vouchers_cordobas + suma_vouchers_dolares + suma_vales_dolares;

        }

        private void xfrm_arqueo_detalle_Load(object sender, EventArgs e)
        {
            try
            {
                dt_fecha_arqueo.DateTime = DateTime.Now.Date;

                var empleados = Negocio.ClasesCN.CatalogosCN.Empleado_Cargar_Arqueo().ToList();
                look_empleados.Properties.DataSource = empleados;
                look_empleados.EditValue = Clases.UsuarioLogueado.vID_Empleado;
                var Permisos = Negocio.ClasesCN.RolesPermisosCN.Cargar_Permisos(Clases.UsuarioLogueado.vID_Empleado).ToList();//.Any(T=>T.id_rol==100 && T.asignado==1)
                var valor = Permisos.Any(T => T.id_rol == 100 && T.asignado == 1);
                var valorConsolidado = Permisos.Any(T => T.id_rol == 11133 && T.asignado == 1);
                var valorReabrir = Permisos.Any(T => T.id_rol == 11134 && T.asignado == 1);
                var valorArqueoEmpleado = Permisos.Any(T => T.id_rol == 11135 && T.asignado == 1);
                //  bbi_imprimir.Enabled = Negocio.ClasesCN.RolesPermisosCN.Consultar_Usuario_Admin(Clases.UsuarioLogueado.vID_Empleado)==0? Permisos.Any(P => P.id_rol == 116 && P.asignado == 1):true;
                bbi_cerrar.Enabled = Negocio.ClasesCN.RolesPermisosCN.Consultar_Usuario_Admin(Clases.UsuarioLogueado.vID_Empleado) == 0 ? Permisos.Any(P => P.id_rol == 117 && P.asignado == 1) : true;
                if (valor && Negocio.ClasesCN.RolesPermisosCN.Consultar_Usuario_Admin(Clases.UsuarioLogueado.vID_Empleado) == 0)
                {
                    panel_detalles_generales.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

                }
                else
                {
                    panel_detalles_generales.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                }
                if (Negocio.ClasesCN.RolesPermisosCN.Consultar_Usuario_Admin(Clases.UsuarioLogueado.vID_Empleado) == 2)
                {
                    panel_detalles_generales.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                }
                if (Clases.UsuarioLogueado.admin || valorConsolidado)
                {
                    cargarAdmin();
                    bbi_imprimir.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    bbi_imprimir_arqueo_consolidado.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    
                    
                    look_empleados.ReadOnly = false;
                    panel_detalles_generales.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                }
                else
                {
                    cargar();
                    look_empleados.ReadOnly = true;
                    
                    bbi_imprimir_empleado.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                }

                if (Clases.UsuarioLogueado.admin || valorReabrir)
                {
                    bbi_reabrir.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                }
                else
                {
                    bbi_reabrir.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }

                if (Clases.UsuarioLogueado.admin || valorArqueoEmpleado)
                {
                    bbi_imprimir_empleado.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                }
                else
                {
                    bbi_imprimir_empleado.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void gview_caja_inicial_cordobas_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            GridView view = sender as GridView;

            decimal cantidad = view.GetFocusedRowCellValue("cantidad").Equals(DBNull.Value) ? 0 : Convert.ToDecimal(view.GetFocusedRowCellValue("cantidad"));
            decimal denoominacion = view.GetFocusedRowCellValue("denominaciones").Equals(DBNull.Value) ? 0 : Convert.ToDecimal(view.GetFocusedRowCellValue("denominaciones"));
            view.SetFocusedRowCellValue("total", (cantidad * denoominacion));
            view.UpdateCurrentRow();
            view.UpdateSummary();
            var suma_total_cordobas = Convert.ToDecimal(view.Columns["total"].SummaryItem.SummaryValue);
            txt_total_cordobas_iniciales.EditValue = suma_total_cordobas;
            txt_total_caja_inicial.EditValue = suma_total_cordobas + Convert.ToDecimal(txt_dolares_cordobizados_inicial.EditValue ?? 0);

        }

        private void gview_caja_inicial_dolares_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            GridView view = sender as GridView;

            decimal cantidad = view.GetFocusedRowCellValue("cantidad").Equals(DBNull.Value) ? 0 : Convert.ToDecimal(view.GetFocusedRowCellValue("cantidad"));
            decimal denoominacion = view.GetFocusedRowCellValue("denominaciones").Equals(DBNull.Value) ? 0 : Convert.ToDecimal(view.GetFocusedRowCellValue("denominaciones"));
            view.SetFocusedRowCellValue("total", (cantidad * denoominacion));
            view.UpdateCurrentRow();
            view.UpdateSummary();
            var suma_total_dolares = Convert.ToDecimal(view.Columns["total"].SummaryItem.SummaryValue);
            txt_total_dolares_inicial.EditValue = suma_total_dolares;
            txt_dolares_cordobizados_inicial.EditValue = Convert.ToDecimal(txt_total_dolares_inicial.EditValue ?? 0) * Convert.ToDecimal(txt_tc.EditValue ?? 0);
            txt_total_caja_inicial.EditValue = Convert.ToDecimal(txt_dolares_cordobizados_inicial.EditValue ?? 0) + Convert.ToDecimal(txt_total_cordobas_iniciales.EditValue ?? 0);
        }

        private void grid_inicial_dolares_Click(object sender, EventArgs e)
        {

        }

        private void gview_caja_final_cordobas_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            GridView view = sender as GridView;

            decimal cantidad = view.GetFocusedRowCellValue("cantidad").Equals(DBNull.Value) ? 0 : Convert.ToDecimal(view.GetFocusedRowCellValue("cantidad"));
            decimal denoominacion = view.GetFocusedRowCellValue("denominaciones").Equals(DBNull.Value) ? 0 : Convert.ToDecimal(view.GetFocusedRowCellValue("denominaciones"));
            view.SetFocusedRowCellValue(col_total_inicial_cordobas, (cantidad * denoominacion));
            view.UpdateCurrentRow();
            view.UpdateSummary();
            var suma_total_cordobas = Convert.ToDecimal(view.Columns["total1"].SummaryItem.SummaryValue);
            var suma_cheques_cordobas = Convert.ToDecimal(view.Columns["cantidad"].Summary[0].SummaryValue);
            var suma_vales_cordobas = Convert.ToDecimal(view.Columns["cantidad"].Summary[1].SummaryValue);
            var suma_vouchers_cordobas = Convert.ToDecimal(view.Columns["cantidad"].Summary[2].SummaryValue);
            var suma_transferencia_cordobas = Convert.ToDecimal(gview_caja_final_cordobas.Columns["cantidad"].Summary[3].SummaryValue);
            //sumarTransferenciaCordobas();

            var suma_vales_dolares = Convert.ToDecimal(gview_caja_final_dolares.Columns["cantidad"].Summary[1].SummaryValue) * Convert.ToDecimal(txt_tc.EditValue ?? 0);
            var suma_vouchers_dolares = Convert.ToDecimal(gview_caja_final_dolares.Columns["cantidad"].Summary[2].SummaryValue) * Convert.ToDecimal(txt_tc.EditValue ?? 0);
            var suma_cheque_dolares = Convert.ToDecimal(gview_caja_final_dolares.Columns["cantidad"].Summary[0].SummaryValue) * Convert.ToDecimal(txt_tc.EditValue ?? 0);
            var suma_transferencia_dolares = Convert.ToDecimal(gview_caja_final_dolares.Columns["cantidad"].Summary[3].SummaryValue) * Convert.ToDecimal(txt_tc.EditValue ?? 0);

            txt_cordobas_finales.EditValue = suma_total_cordobas;
            // txt_total_caja_final.EditValue = suma_total_cordobas + Convert.ToDecimal(txt_dolares_cordobizados_final.EditValue ?? 0);

            txt_cheques_finales_suma.EditValue = suma_cheques_cordobas + suma_cheque_dolares;


            txt_total_caja_final.EditValue = suma_total_cordobas + Convert.ToDecimal(txt_dolares_cordobizados_final.EditValue ?? 0) + Convert.ToDecimal(txt_cheques_finales_suma.EditValue ?? 0) + suma_vouchers_cordobas + suma_transferencia_cordobas + suma_vales_cordobas + suma_vales_dolares + suma_vouchers_dolares + suma_transferencia_dolares;

        }

        private void gview_caja_final_dolares_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            GridView view = sender as GridView;

            decimal cantidad = view.GetFocusedRowCellValue("cantidad").Equals(DBNull.Value) ? 0 : Convert.ToDecimal(view.GetFocusedRowCellValue("cantidad"));
            decimal denoominacion = view.GetFocusedRowCellValue("denominaciones").Equals(DBNull.Value) ? 0 : Convert.ToDecimal(view.GetFocusedRowCellValue("denominaciones"));
            view.SetFocusedRowCellValue(col_total_inicial_cordobas, (cantidad * denoominacion));
            view.UpdateCurrentRow();
            view.UpdateSummary();


            var suma_total_dolares = Convert.ToDecimal(view.Columns["total1"].SummaryItem.SummaryValue);
            var suma_cheques_dolares = Convert.ToDecimal(view.Columns["cantidad"].Summary[0].SummaryValue) * Convert.ToDecimal(txt_tc.EditValue ?? 0);
            var suma_cheque_cordobas = Convert.ToDecimal(gview_caja_final_cordobas.Columns["cantidad"].Summary[0].SummaryValue);
            var suma_vales_cordobas = Convert.ToDecimal(gview_caja_final_cordobas.Columns["cantidad"].Summary[1].SummaryValue);
            var suma_vouchers_cordobas = Convert.ToDecimal(gview_caja_final_cordobas.Columns["cantidad"].Summary[2].SummaryValue);
            var suma_transferencia_cordobas = Convert.ToDecimal(gview_caja_final_cordobas.Columns["cantidad"].Summary[3].SummaryValue);


            var suma_vales_dolares = Convert.ToDecimal(gview_caja_final_dolares.Columns["cantidad"].Summary[1].SummaryValue) * Convert.ToDecimal(txt_tc.EditValue ?? 0);
            var suma_vouchers_dolares = Convert.ToDecimal(gview_caja_final_dolares.Columns["cantidad"].Summary[2].SummaryValue) * Convert.ToDecimal(txt_tc.EditValue ?? 0);
            var suma_transferencia_dolares = Convert.ToDecimal(gview_caja_final_dolares.Columns["cantidad"].Summary[3].SummaryValue) * Convert.ToDecimal(txt_tc.EditValue ?? 0);

            txt_dolares_final.EditValue = suma_total_dolares;
            txt_dolares_cordobizados_final.EditValue = Convert.ToDecimal(txt_dolares_final.EditValue ?? 0) * Convert.ToDecimal(txt_tc.EditValue ?? 0);
            txt_cheques_finales_suma.EditValue = suma_cheque_cordobas + suma_cheques_dolares;

            txt_total_caja_final.EditValue = Convert.ToDecimal(txt_dolares_cordobizados_final.EditValue ?? 0) + Convert.ToDecimal(txt_cordobas_finales.EditValue ?? 0) + Convert.ToDecimal(txt_cheques_finales_suma.EditValue ?? 0) + suma_vouchers_cordobas + suma_vales_cordobas + suma_transferencia_cordobas + suma_vales_dolares + suma_vouchers_dolares + suma_transferencia_dolares;

        }




        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                gview_caja_final_cordobas.CloseEditor();
                gview_caja_final_cordobas.UpdateCurrentRow();
                gview_caja_inicial_dolares.CloseEditor();
                gview_caja_inicial_dolares.UpdateCurrentRow();
                gview_caja_final_cordobas.CloseEditor();
                gview_caja_final_cordobas.UpdateCurrentRow();
                gview_caja_final_dolares.CloseEditor();
                gview_caja_final_dolares.UpdateCurrentRow();

                int contador = Negocio.ClasesCN.CajaCN.Buscar_Arqueo_Fecha_General(dt_fecha_arqueo.DateTime);

                var D = Negocio.ClasesCN.CajaCN.Buscar_Arqueo_Fecha(dt_fecha_arqueo.DateTime, Clases.UsuarioLogueado.vID_Empleado);
                if (D.id_registro == 0)
                {
                    if (contador >= 0 && contador < 2)
                    {
                        Clases.MyMessageBox.MessageFont = new Font(Clases.MyMessageBox.MessageFont.FontFamily, 16);
                        if (Clases.MyMessageBox.Show($"¿Esta completamente seguro de guardar este arqueo?", "Caja", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
                        if (Negocio.ClasesCN.CajaCN.Arqueo_Guardar(dt_fecha_arqueo.DateTime.Date, Convert.ToInt32(look_empleados.EditValue ?? 0), 1, Convert.ToDecimal(txt_tc.EditValue ?? 0), gview_caja_inicial_cordobas, gview_caja_inicial_dolares, gview_caja_final_cordobas, gview_caja_final_dolares, D.id_registro))
                        {
                            Clases.MyMessageBox.Show($"Arqueo de la fecha {dt_fecha_arqueo.DateTime.Date.ToShortDateString()} guardado correctamente", "Caja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            var Permisos = Negocio.ClasesCN.RolesPermisosCN.Cargar_Permisos(Clases.UsuarioLogueado.vID_Empleado).ToList();//.Any(T=>T.id_rol==100 && T.asignado==1)
                            var valorConsolidado = Permisos.Any(T => T.id_rol == 11133 && T.asignado == 1);
                            if (Clases.UsuarioLogueado.admin || valorConsolidado)
                            {
                                cargarAdmin();
                            }
                            else
                            {
                                cargar();
                            }
                        }
                    }
                    else
                    {
                        Clases.MyMessageBox.MessageFont = new Font(Clases.MyMessageBox.MessageFont.FontFamily, 16);
                        Clases.MyMessageBox.Show($"Lo sentimos, ya existen dos arqueos con fecha {dt_fecha_arqueo.DateTime.Date.ToShortDateString()}", "Caja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        var Permisos = Negocio.ClasesCN.RolesPermisosCN.Cargar_Permisos(Clases.UsuarioLogueado.vID_Empleado).ToList();//.Any(T=>T.id_rol==100 && T.asignado==1)
                        var valorConsolidado = Permisos.Any(T => T.id_rol == 11133 && T.asignado == 1);
                        if (Clases.UsuarioLogueado.admin || valorConsolidado)
                        {
                            cargarAdmin();
                        }
                        else
                        {
                            cargar();
                        }
                        return;
                    }
                }
                else
                {
                    if (D.estado_arqueo == 1)
                    {
                        Clases.MyMessageBox.MessageFont = new Font(Clases.MyMessageBox.MessageFont.FontFamily, 16);
                        if (Clases.MyMessageBox.Show($"¿Esta completamente seguro de actualizar los datos de este arqueo?", "Caja", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
                        if (Negocio.ClasesCN.CajaCN.Arqueo_Guardar(dt_fecha_arqueo.DateTime.Date, Convert.ToInt32(look_empleados.EditValue ?? 0), 1, Convert.ToDecimal(txt_tc.EditValue ?? 0), gview_caja_inicial_cordobas, gview_caja_inicial_dolares, gview_caja_final_cordobas, gview_caja_final_dolares, D.id_registro))
                        {
                            Clases.MyMessageBox.Show($"Arqueo de la fecha {dt_fecha_arqueo.DateTime.Date.ToShortDateString()} guardado correctamente", "Caja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            var Permisos = Negocio.ClasesCN.RolesPermisosCN.Cargar_Permisos(Clases.UsuarioLogueado.vID_Empleado).ToList();//.Any(T=>T.id_rol==100 && T.asignado==1)
                            var valorConsolidado = Permisos.Any(T => T.id_rol == 11133 && T.asignado == 1);
                            if (Clases.UsuarioLogueado.admin || valorConsolidado)
                            {
                                cargarAdmin();
                            }
                            else
                            {
                                cargar();
                            }
                        }
                    }
                    else if (D.estado_arqueo == 2)
                    {
                        Clases.MyMessageBox.MessageFont = new Font(Clases.MyMessageBox.MessageFont.FontFamily, 16);
                        Clases.MyMessageBox.Show($"Lo sentimos el arqueo de la fecha {dt_fecha_arqueo.DateTime.Date.ToShortDateString()} ya fue cerrado", "Caja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        var Permisos = Negocio.ClasesCN.RolesPermisosCN.Cargar_Permisos(Clases.UsuarioLogueado.vID_Empleado).ToList();//.Any(T=>T.id_rol==100 && T.asignado==1)
                        var valorConsolidado = Permisos.Any(T => T.id_rol == 11133 && T.asignado == 1);
                        if (Clases.UsuarioLogueado.admin || valorConsolidado)
                        {
                            cargarAdmin();
                        }
                        else
                        {
                            cargar();
                        }
                    }
                }


            }
            catch (Exception)
            {

                throw;
            }
        }

        private void gview_caja_inicial_cordobas_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            GridView view = sender as GridView;

            try
            {
                switch (view.FocusedColumn.FieldName)
                {
                    case "cantidad":
                        int id_deno = view.GetFocusedRowCellValue("id_denominacion").Equals(DBNull.Value) ? 0 : Convert.ToInt32(view.GetFocusedRowCellValue("id_denominacion"));

                        if (id_deno != 32)
                        {
                            if (Es_Entero(e.Value))
                            {
                                if (Convert.ToInt32(e.Value) >= 0)
                                    e.Valid = true;
                                else
                                    e.Valid = false;

                            }
                            else
                                e.Valid = false;
                        }
                        else
                        {
                            if (Es_Entero(e.Value) || es_decimal(e.Value))
                            {
                                if (Convert.ToDecimal(e.Value) >= 0)
                                    e.Valid = true;
                                else
                                    e.Valid = false;

                            }
                            else
                                e.Valid = false;
                        }



                        break;
                }
            }
            catch (Exception ex)
            {
                e.Valid = false;
            }
        }

        private void gview_caja_inicial_cordobas_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {

            e.ExceptionMode = ExceptionMode.NoAction;
            e.WindowCaption = "Error en el valor ingresado";
            e.ErrorText = "Error en el valor ingresado";
        }

        private void gview_caja_inicial_cordobas_InvalidValueException(object sender, InvalidValueExceptionEventArgs e)
        {
            GridView view = sender as GridView;

            switch (view.FocusedColumn.FieldName)
            {
                case "cantidad":
                    int id_deno = view.GetFocusedRowCellValue("id_denominacion").Equals(DBNull.Value) ? 0 : Convert.ToInt32(view.GetFocusedRowCellValue("id_denominacion"));

                    if (id_deno != 32)
                    {
                        if (!Es_Entero(e.Value))
                        {
                            e.ExceptionMode = ExceptionMode.DisplayError;
                            e.WindowCaption = "Error en el valor ingresado";
                            e.ErrorText = "Solo se permiten Enteros Positivos en esta Celda";

                        }


                    }
                    else
                    {
                        if (!(Es_Entero(e.Value) || es_decimal(e.Value)))
                        {

                            e.ExceptionMode = ExceptionMode.DisplayError;
                            e.WindowCaption = "Error en el valor ingresado";
                            e.ErrorText = "Solo se permiten Valores Positivos en esta Celda";
                        }

                    }


                    break;

            }
        }

        private void txt_cordobas_finales_EditValueChanged(object sender, EventArgs e)
        {
        }
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            Clases.MyMessageBox.MessageFont = new Font(Clases.MyMessageBox.MessageFont.FontFamily, 16);
            if (Negocio.ClasesCN.CajaCN.CONSULTAR_SI_HAY_FACTURAS_SIN_RECIBO() == false)
            {
                if (Clases.MyMessageBox.Show($"¿Esta completamente seguro de realizar el cierre de la fecha {dt_fecha_arqueo.DateTime.Date.ToShortDateString()}?", "Caja", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
                {
                    int cierre = Negocio.ClasesCN.CajaCN.CIERRE_CAJA_GUARDAR(dt_fecha_arqueo.DateTime.Date, 0, Convert.ToInt32(look_empleados.EditValue));
                    if (cierre > 0)
                    {
                        Clases.MyMessageBox.Show($"Se cerro Caja correctamente para el dia {dt_fecha_arqueo.DateTime.Date.ToShortDateString()}", "Caja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        var Permisos = Negocio.ClasesCN.RolesPermisosCN.Cargar_Permisos(Clases.UsuarioLogueado.vID_Empleado).ToList();//.Any(T=>T.id_rol==100 && T.asignado==1)
                        var valorConsolidado = Permisos.Any(T => T.id_rol == 11133 && T.asignado == 1);
                        if (Clases.UsuarioLogueado.admin || valorConsolidado)
                        {
                            cargarAdmin();
                        }
                        else
                        {
                            cargar();
                        }
                    }

                }


            }
            else
            {
                Clases.MyMessageBox.Show($"Aún hay facturas sin cancelar, por favor verifique los datos e intente nuevamente", "Caja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dt_fecha_arqueo_EditValueChanged(object sender, EventArgs e)
        {
            if (dt_fecha_arqueo.EditValue != null)
            {
                var Permisos = Negocio.ClasesCN.RolesPermisosCN.Cargar_Permisos(Clases.UsuarioLogueado.vID_Empleado).ToList();//.Any(T=>T.id_rol==100 && T.asignado==1)
                var valorConsolidado = Permisos.Any(T => T.id_rol == 11133 && T.asignado == 1);
                if (Clases.UsuarioLogueado.admin || valorConsolidado)
                {
                    cargarAdmin();
                }
                else
                {
                    cargar();
                }
            }

        }

        private void txt_total_caja_final_EditValueChanged(object sender, EventArgs e)
        {
            txt_venta_esperada.EditValue = Convert.ToDecimal(txt_total_caja_final.EditValue ?? 0) - Convert.ToDecimal(txt_total_caja_inicial.EditValue ?? 0);
            txt_diferencia_en_caja.EditValue = Convert.ToDecimal(txt_venta_esperada.EditValue ?? 0) - Convert.ToDecimal(txt_venta_total.EditValue ?? 0);
        }

        private void txt_total_caja_inicial_EditValueChanged(object sender, EventArgs e)
        {
            txt_venta_esperada.EditValue = Convert.ToDecimal(txt_total_caja_final.EditValue ?? 0) - Convert.ToDecimal(txt_total_caja_inicial.EditValue ?? 0);
            txt_diferencia_en_caja.EditValue = Convert.ToDecimal(txt_venta_esperada.EditValue ?? 0) - Convert.ToDecimal(txt_venta_total.EditValue ?? 0);
        }

        private void txt_venta_esperada_EditValueChanged(object sender, EventArgs e)
        {
            txt_venta_esperada.EditValue = Convert.ToDecimal(txt_total_caja_final.EditValue ?? 0) - Convert.ToDecimal(txt_total_caja_inicial.EditValue ?? 0);
            txt_diferencia_en_caja.EditValue = Convert.ToDecimal(txt_venta_esperada.EditValue ?? 0) - Convert.ToDecimal(txt_venta_total.EditValue ?? 0);
        }

        private void xfrm_arqueo_detalle_Activated(object sender, EventArgs e)
        {
            var Permisos = Negocio.ClasesCN.RolesPermisosCN.Cargar_Permisos(Clases.UsuarioLogueado.vID_Empleado).ToList();//.Any(T=>T.id_rol==100 && T.asignado==1)
            var valorConsolidado = Permisos.Any(T => T.id_rol == 11133 && T.asignado == 1);
            if (Clases.UsuarioLogueado.admin || valorConsolidado)
            {
                cargarAdmin();
            }
            else
            {
                cargar();
            }
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var Permisos = Negocio.ClasesCN.RolesPermisosCN.Cargar_Permisos(0).Where(p => p.id_rol == 116).FirstOrDefault();
            xfrm_autorizacion frm = new xfrm_autorizacion("GENERAR REPORTE DE ARQUEO");
            frm.numero_permiso = Permisos.id_rol ?? 0;
            frm.permiso = Permisos.descripcion.ToUpper();
            frm.ShowDialog();
            if (frm.Autorizado)
            {

                var PermisosCon = Negocio.ClasesCN.RolesPermisosCN.Cargar_Permisos(Clases.UsuarioLogueado.vID_Empleado).ToList();//.Any(T=>T.id_rol==100 && T.asignado==1)
                var valorConsolidado = PermisosCon.Any(T => T.id_rol == 11133 && T.asignado == 1);
                if (Clases.UsuarioLogueado.admin || valorConsolidado)
                {
                    var recursoG = Negocio.ClasesCN.CajaCN.Reporte_Arqueo_General(dt_fecha_arqueo.DateTime);
                    var reportG = new Reportes.Caja.xrpt_arqueo_caja_detallado_consolidado();
                    reportG.DataSource = recursoG;

                    BindingSource datosReporte2 = new BindingSource();
                    BindingSource datosReporte3 = new BindingSource();
                    datosReporte2.DataSource = Negocio.ClasesCN.CajaCN.TRANSFERENCIA_SELECT(dt_fecha_arqueo.DateTime, 0);
                    datosReporte3.DataSource = null;
                    XtraReportTrasnferenciasCaja reporte2 = new XtraReportTrasnferenciasCaja(datosReporte2, dt_fecha_arqueo.DateTime, 0);
                    if (datosReporte2.Count == 0 && datosReporte3.Count == 0)
                    {
                        reportG.CreateDocument();
                        reportG.ShowPreviewDialog();
                    }
                    else if (datosReporte2.Count != 0 && datosReporte3.Count == 0)
                    {
                        reportG.CreateDocument();
                        reporte2.CreateDocument();
                        reportG.ModifyDocument(x => x.AddPages(reporte2.Pages));
                        reportG.ShowPreviewDialog();
                    }
                    else if (datosReporte2.Count == 0 && datosReporte3.Count != 0)
                    {
                        reportG.CreateDocument();
                        reportG.ShowPreviewDialog();
                    }
                    else if (datosReporte2.Count != 0 && datosReporte3.Count != 0)
                    {
                        reportG.CreateDocument();
                        reporte2.CreateDocument();
                        reportG.ModifyDocument(x => x.AddPages(reporte2.Pages));
                        reportG.ShowPreviewDialog();
                    }
                }
                else
                {
                    int id = Negocio.ClasesCN.CajaCN.Buscar_Arqueo_Fecha(dt_fecha_arqueo.DateTime, Clases.UsuarioLogueado.vID_Empleado).id_registro;
                    var recurso = Negocio.ClasesCN.CajaCN.Reporte_Arqueo_Emmpleado(id, Clases.UsuarioLogueado.vID_Empleado);
                    var report = new Reportes.Caja.xrpt_arqueo_caja_detallado();
                    report.DataSource = recurso;

                    BindingSource datosReporte2 = new BindingSource();
                    BindingSource datosReporte3 = new BindingSource();
                    datosReporte2.DataSource = Negocio.ClasesCN.CajaCN.TRANSFERENCIA_SELECT_Empleado(dt_fecha_arqueo.DateTime, 0, Clases.UsuarioLogueado.vID_Empleado);
                    datosReporte3.DataSource = null;
                    XtraReportTrasnferenciasCaja reporte2 = new XtraReportTrasnferenciasCaja(datosReporte2, dt_fecha_arqueo.DateTime, 0);
                    if (datosReporte2.Count == 0 && datosReporte3.Count == 0)
                    {
                        report.CreateDocument();
                        report.ShowPreviewDialog();
                    }
                    else if (datosReporte2.Count != 0 && datosReporte3.Count == 0)
                    {
                        report.CreateDocument();
                        //reporte2.CreateDocument();
                        //report.ModifyDocument(x => x.AddPages(reporte2.Pages));
                        report.ShowPreviewDialog();
                    }
                    else if (datosReporte2.Count == 0 && datosReporte3.Count != 0)
                    {
                        report.CreateDocument();
                        report.ShowPreviewDialog();
                    }
                    else if (datosReporte2.Count != 0 && datosReporte3.Count != 0)
                    {
                        report.CreateDocument();
                        //reporte2.CreateDocument();
                        //report.ModifyDocument(x => x.AddPages(reporte2.Pages));
                        report.ShowPreviewDialog();
                    }
                }



            }
            else
            {

                XtraMessageBox.Show($"Usted no tiene autorizacion de {frm.permiso.ToUpper()}", "Información");
            }
        }

        private void txt_venta_total_EditValueChanged(object sender, EventArgs e)
        {
            txt_venta_esperada.EditValue = Convert.ToDecimal(txt_total_caja_final.EditValue ?? 0) - Convert.ToDecimal(txt_total_caja_inicial.EditValue ?? 0);
            txt_diferencia_en_caja.EditValue = Convert.ToDecimal(txt_venta_esperada.EditValue ?? 0) - Convert.ToDecimal(txt_venta_total.EditValue ?? 0);
        }
        decimal valor_cheques_cordobas, suma_de_lo_demas_Cordobas, suma_vouchers_cordobas, suma_vales_cordobas, suma_transferencia_cordobas, valor_saldos_cordobas;

        private void gview_caja_inicial_cordobas_CustomRowFilter(object sender, DevExpress.XtraGrid.Views.Base.RowFilterEventArgs e)
        {
            //    ColumnView view = sender as ColumnView;
            //    string deno = view.GetListSourceRowCellValue(e.ListSourceRow, "descripcion").ToString();
            //    if (deno.Contains("C$ TRANSFERENCIA"))
            //    {
            //        e.Visible = true;
            //        e.Handled = true;
            //    }

        }

        private void gview_caja_final_cordobas_ShowingEditor(object sender, CancelEventArgs e)
        {
            GridView View = sender as GridView;
            string cellValue = View.GetRowCellValue(View.FocusedRowHandle, col_final_cordobas).ToString();
            if (cellValue == "C$ TRANSFERENCIA")
                e.Cancel = true;
        }

        private void gview_caja_final_dolares_ShowingEditor(object sender, CancelEventArgs e)
        {
            GridView View = sender as GridView;
            string cellValue = View.GetRowCellValue(View.FocusedRowHandle, col_final_cordobas).ToString();
            if (cellValue == "$ TRANSFERENCIA")
                e.Cancel = true;
        }

        decimal valor_cheques_dolares, suma_lo_demas_final, suma_vouchers_dolares, suma_vales_dolares, suma_tranferencia_dolares, valor_saldos_dolares;

        private void bbi_imprimir_empleado_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var Permisos = Negocio.ClasesCN.RolesPermisosCN.Cargar_Permisos(0).Where(p => p.id_rol == 116).FirstOrDefault();
            xfrm_autorizacion frm = new xfrm_autorizacion("GENERAR REPORTE DE ARQUEO");
            frm.numero_permiso = Permisos.id_rol ?? 0;
            frm.permiso = Permisos.descripcion.ToUpper();
            frm.ShowDialog();
            if (frm.Autorizado)
            {
                int idEmpleado = Convert.ToInt32(look_empleados.EditValue);
                int id = Negocio.ClasesCN.CajaCN.Buscar_Arqueo_Fecha(dt_fecha_arqueo.DateTime, idEmpleado).id_registro;
                var recurso = Negocio.ClasesCN.CajaCN.Reporte_Arqueo_Emmpleado(id, idEmpleado);
                var report = new Reportes.Caja.xrpt_arqueo_caja_detallado();
                report.DataSource = recurso;

                BindingSource datosReporte2 = new BindingSource();
                BindingSource datosReporte3 = new BindingSource();
                datosReporte2.DataSource = Negocio.ClasesCN.CajaCN.TRANSFERENCIA_SELECT_Empleado(dt_fecha_arqueo.DateTime, 0, Clases.UsuarioLogueado.vID_Empleado);
                datosReporte3.DataSource = null;
                XtraReportTrasnferenciasCaja reporte2 = new XtraReportTrasnferenciasCaja(datosReporte2, dt_fecha_arqueo.DateTime, 0);
                if (datosReporte2.Count == 0 && datosReporte3.Count == 0)
                {
                    report.CreateDocument();
                    report.ShowPreviewDialog();
                }
                else if (datosReporte2.Count != 0 && datosReporte3.Count == 0)
                {
                    report.CreateDocument();
                    //reporte2.CreateDocument();
                    //report.ModifyDocument(x => x.AddPages(reporte2.Pages));
                    report.ShowPreviewDialog();
                }
                else if (datosReporte2.Count == 0 && datosReporte3.Count != 0)
                {
                    report.CreateDocument();
                    report.ShowPreviewDialog();
                }
                else if (datosReporte2.Count != 0 && datosReporte3.Count != 0)
                {
                    report.CreateDocument();
                    //reporte2.CreateDocument();
                    //report.ModifyDocument(x => x.AddPages(reporte2.Pages));
                    report.ShowPreviewDialog();
                }
            }
            else
            {
                XtraMessageBox.Show($"Usted no tiene autorizacion de {frm.permiso.ToUpper()}", "Información");
            }

        }

        private void bbi_actualizar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DateTime fecha_arqueo = dt_fecha_arqueo.DateTime;

            var Permisos = Negocio.ClasesCN.RolesPermisosCN.Cargar_Permisos(0).Where(p => p.id_rol == 11134).FirstOrDefault();
            xfrm_autorizacion frm = new xfrm_autorizacion("GENERAR REPORTE DE ARQUEO");
            frm.numero_permiso = Permisos.id_rol ?? 0;
            frm.permiso = Permisos.descripcion.ToUpper();
            frm.ShowDialog();
            if (frm.Autorizado)
            {
                var query = Negocio.ClasesCN.CajaCN.REABRIR_ARQUEO_CAJA(fecha_arqueo);

                if (query > 0)
                {
                    Clases.MyMessageBox.Show($"Se volvio a ReAbrir Caja correctamente para el dia {dt_fecha_arqueo.DateTime.Date.ToShortDateString()}", "Caja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    var PermisosA = Negocio.ClasesCN.RolesPermisosCN.Cargar_Permisos(Clases.UsuarioLogueado.vID_Empleado).ToList();//.Any(T=>T.id_rol==100 && T.asignado==1)
                    var valorConsolidado = PermisosA.Any(T => T.id_rol == 11133 && T.asignado == 1);
                    if (Clases.UsuarioLogueado.admin || valorConsolidado)
                    {
                        cargarAdmin();
                    }
                    else
                    {
                        cargar();
                    }
                }
                else
                {
                    Clases.MyMessageBox.Show($"No se ha cerrado ningun Arqueo para la fecha {dt_fecha_arqueo.DateTime.Date.ToShortDateString()}", "Caja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }


        }

        private void bbi_imprimir_arqueo_consolidado_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var Permisos = Negocio.ClasesCN.RolesPermisosCN.Cargar_Permisos(0).Where(p => p.id_rol == 11133).FirstOrDefault();
            xfrm_autorizacion frm = new xfrm_autorizacion("GENERAR REPORTE DE ARQUEO CONSOLIDADO");
            frm.numero_permiso = Permisos.id_rol ?? 0;
            frm.permiso = Permisos.descripcion.ToUpper();
            frm.ShowDialog();
            if (frm.Autorizado)
            {
                var recursoG = Negocio.ClasesCN.CajaCN.Reporte_Arqueo_General(dt_fecha_arqueo.DateTime);
                var reportG = new Reportes.Caja.xrpt_arqueo_caja_detallado_consolidado();
                reportG.DataSource = recursoG;

                BindingSource datosReporte2 = new BindingSource();
                BindingSource datosReporte3 = new BindingSource();
                //datosReporte2.DataSource = Negocio.ClasesCN.CajaCN.TRANSFERENCIA_SELECT(dt_fecha_arqueo.DateTime, 0);
                datosReporte2.DataSource = Negocio.ClasesCN.CajaCN.TRANSFERENCIA_rango_SELECT(dt_fecha_arqueo.DateTime, dt_fecha_arqueo.DateTime, 0);
                datosReporte3.DataSource = null;
                //XtraReportTrasnferenciasCaja reporte2 = new XtraReportTrasnferenciasCaja(datosReporte2, dt_fecha_arqueo.DateTime, 0);
                XtraReportTrasnferenciasArqueo reporte2 = new XtraReportTrasnferenciasArqueo(datosReporte2, dt_fecha_arqueo.DateTime, dt_fecha_arqueo.DateTime);
                reporte2.Parameters[1].Value = dt_fecha_arqueo.DateTime;
                reporte2.Parameters[2].Value = dt_fecha_arqueo.DateTime;
                if (datosReporte2.Count == 0 && datosReporte3.Count == 0)
                {
                    reportG.CreateDocument();
                    reportG.ShowPreviewDialog();
                }
                else if (datosReporte2.Count != 0 && datosReporte3.Count == 0)
                {
                    reportG.CreateDocument();
                    reporte2.CreateDocument();
                    reportG.ModifyDocument(x => x.AddPages(reporte2.Pages));
                    reportG.ShowPreviewDialog();
                }
                else if (datosReporte2.Count == 0 && datosReporte3.Count != 0)
                {
                    reportG.CreateDocument();
                    reportG.ShowPreviewDialog();
                }
                else if (datosReporte2.Count != 0 && datosReporte3.Count != 0)
                {
                    reportG.CreateDocument();
                    reporte2.CreateDocument();
                    reportG.ModifyDocument(x => x.AddPages(reporte2.Pages));
                    reportG.ShowPreviewDialog();
                }
            }
        }

        private void gview_caja_final_dolares_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            //try
            //{


            //    GridView view =sender as GridView;
            //    int id_summary=Convert.ToInt32((e.Item as GridSummaryItem).Tag);

            //    if(e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Start)
            //    {
            //        valor_cheques_dolares = 0;
            //        suma_lo_demas_final = 0;
            //                    }

            //    if(e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Calculate)
            //    {
            //        switch(id_summary)
            //        {
            //            case 1:
            //                int tipo_denominacion = Convert.ToInt32(view.GetRowCellValue(e.RowHandle,"tipo_denominacion"));
            //                if(tipo_denominacion == 3)
            //                    valor_cheques_dolares += Convert.ToDecimal(e.FieldValue);
            //                break;
            //            case 2:
            //                tipo_denominacion = Convert.ToInt32(view.GetRowCellValue(e.RowHandle,"tipo_denominacion"));
            //                if(tipo_denominacion != 3)
            //                    suma_lo_demas_final += Convert.ToDecimal(e.FieldValue);
            //                break;


            //        }
            //    }
            //    if(e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize)
            //    {
            //        switch(id_summary)
            //        {
            //            case 1:
            //                e.TotalValue = valor_cheques_dolares;
            //                break;
            //            case 2:
            //                e.TotalValue = suma_lo_demas_final;
            //                break;


            //        }
            //    }



            //}
            //catch(Exception)
            //{

            //    throw;
            //}
            try
            {

                GridView view = sender as GridView;
                int id_summary = Convert.ToInt32((e.Item as GridSummaryItem).Tag);

                if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Start)
                {
                    valor_cheques_dolares = 0;
                    suma_lo_demas_final = 0;
                    suma_vales_dolares = 0;
                    suma_vouchers_dolares = 0;
                    valor_saldos_dolares = 0;
                    //suma_tranferencia_dolares = 0;
                }

                if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Calculate)
                {
                    switch (id_summary)
                    {
                        case 1:
                            int tipo_denominacion = Convert.ToInt32(view.GetRowCellValue(e.RowHandle, "tipo_denominacion"));
                            if (tipo_denominacion == 3)//CKS dOLARES
                            {
                                valor_cheques_dolares += sumarChequesDolar();
                                view.SetRowCellValue(e.RowHandle, view.Columns["cantidad"], sumarChequesDolar().ToString("n2"));
                            }
                                //valor_cheques_dolares += Convert.ToDecimal(e.FieldValue);
                            break;
                        case 2:
                            tipo_denominacion = Convert.ToInt32(view.GetRowCellValue(e.RowHandle, "tipo_denominacion"));
                            if (tipo_denominacion == 1)//Dolares
                                suma_lo_demas_final += Convert.ToDecimal(e.FieldValue);
                            break;
                        case 3:
                            tipo_denominacion = Convert.ToInt32(view.GetRowCellValue(e.RowHandle, "tipo_denominacion"));
                            if (tipo_denominacion == 4)///VALES Dolares
                                suma_vales_dolares += Convert.ToDecimal(e.FieldValue);
                            break;
                        case 4:
                            tipo_denominacion = Convert.ToInt32(view.GetRowCellValue(e.RowHandle, "tipo_denominacion"));
                            if (tipo_denominacion == 5)///VOUCHERS  dolares
                                suma_vouchers_dolares += Convert.ToDecimal(e.FieldValue);
                            break;

                        case 5:
                            tipo_denominacion = Convert.ToInt32(view.GetRowCellValue(e.RowHandle, "tipo_denominacion"));
                            if (tipo_denominacion == 6)// TRANSFERECIA dolares
                            {
                                //suma_tranferencia_dolares += Convert.ToDecimal(e.FieldValue);
                                suma_tranferencia_dolares += sumarTransferenciaDolar();
                                view.SetRowCellValue(e.RowHandle, view.Columns["cantidad"], sumarTransferenciaDolar().ToString("n2"));
                            }
                            //suma_tranferencia_dolares += Convert.ToDecimal(e.FieldValue);
                            break;
                        case 6:
                            tipo_denominacion = Convert.ToInt32(view.GetRowCellValue(e.RowHandle, "tipo_denominacion"));
                            if (tipo_denominacion == 1005)// Cheque dolares
                            {
                                //suma_tranferencia_dolares += Convert.ToDecimal(e.FieldValue);
                                valor_cheques_dolares += sumarChequesDolar();
                                view.SetRowCellValue(e.RowHandle, view.Columns["cantidad"], sumarChequesDolar().ToString("n2"));
                            }
                            break;
                        case 7:
                            tipo_denominacion = Convert.ToInt32(view.GetRowCellValue(e.RowHandle, "tipo_denominacion"));
                            if(tipo_denominacion == 7)
                            {
                                valor_saldos_dolares += sumarSaldosDolar();
                                view.SetRowCellValue(e.RowHandle, view.Columns["cantidad"], sumarSaldosDolar().ToString("n2"));
                            }
                            break;

                    }
                }
                if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize)
                {
                    switch (id_summary)
                    {
                        case 1:
                            e.TotalValue = valor_cheques_dolares;
                            break;
                        case 2:
                            e.TotalValue = suma_lo_demas_final;
                            break;
                        case 3:
                            e.TotalValue = suma_vales_dolares;
                            break;
                        case 4:
                            e.TotalValue = suma_vouchers_dolares;
                            break;
                        case 5:
                            e.TotalValue = sumarTransferenciaDolar();
                            break;
                        case 6:
                            e.TotalValue = sumarSaldosDolar();
                            break;

                    }
                }
            }
            catch (Exception)
            {

                throw;
            }


        }

        private void gview_caja_final_cordobas_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            try
            {

                GridView view = sender as GridView;
                int id_summary = Convert.ToInt32((e.Item as GridSummaryItem).Tag);

                if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Start)
                {
                    valor_cheques_cordobas = 0;
                    suma_de_lo_demas_Cordobas = 0;
                    suma_vales_cordobas = 0;
                    suma_vouchers_cordobas = 0;
                    valor_saldos_cordobas = 0;
                }


                if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Calculate)
                {
                    switch (id_summary)
                    {
                        case 1:
                            int tipo_denominacion = Convert.ToInt32(view.GetRowCellValue(e.RowHandle, "tipo_denominacion"));
                            if (tipo_denominacion == 3)//CKS
                            {
                                valor_cheques_cordobas += sumarChequesCordobas();
                                view.SetRowCellValue(e.RowHandle, view.Columns["cantidad"], sumarChequesCordobas().ToString("n2"));
                            }
                                //valor_cheques_cordobas += Convert.ToDecimal(e.FieldValue);
                            break;
                        case 2:
                            tipo_denominacion = Convert.ToInt32(view.GetRowCellValue(e.RowHandle, "tipo_denominacion"));
                            if (tipo_denominacion == 1)//CORDOBAS
                                suma_de_lo_demas_Cordobas += Convert.ToDecimal(e.FieldValue);
                            break;
                        case 3:
                            tipo_denominacion = Convert.ToInt32(view.GetRowCellValue(e.RowHandle, "tipo_denominacion"));
                            if (tipo_denominacion == 4)///VALES
                                suma_vales_cordobas += Convert.ToDecimal(e.FieldValue);
                            break;
                        case 4:
                            tipo_denominacion = Convert.ToInt32(view.GetRowCellValue(e.RowHandle, "tipo_denominacion"));
                            if (tipo_denominacion == 5)///VOUCHERS
                                suma_vouchers_cordobas += Convert.ToDecimal(e.FieldValue);
                            break;
                        case 5:
                            tipo_denominacion = Convert.ToInt32(view.GetRowCellValue(e.RowHandle, "tipo_denominacion"));
                            if (tipo_denominacion == 6)//TRANSFERENCIA
                            {
                                suma_transferencia_cordobas += sumarTransferenciaCordobas();
                                //string cellValue = view.GetRowCellValue(e.RowHandle, view.Columns["cantidad"]).ToString();
                                view.SetRowCellValue(e.RowHandle, view.Columns["cantidad"], sumarTransferenciaCordobas().ToString("n2"));
                            }
                            break;
                        case 6:
                            tipo_denominacion = Convert.ToInt32(view.GetRowCellValue(e.RowHandle, "tipo_denominacion"));
                            if (tipo_denominacion == 7)//Saldos
                            {
                                valor_saldos_cordobas += sumarSaldosCordobas();
                                view.SetRowCellValue(e.RowHandle, view.Columns["cantidad"], sumarSaldosCordobas().ToString("n2"));
                            }
                            break;

                    }
                }
                if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize)
                {
                    switch (id_summary)
                    {
                        case 1:
                            e.TotalValue = valor_cheques_cordobas;
                            break;
                        case 2:
                            e.TotalValue = suma_de_lo_demas_Cordobas;
                            break;
                        case 3:
                            e.TotalValue = suma_vales_cordobas;
                            break;
                        case 4:
                            e.TotalValue = suma_vouchers_cordobas;
                            break;
                        case 5:
                            e.TotalValue = sumarTransferenciaCordobas();
                            break;
                        case 6:
                            e.TotalValue = sumarSaldosCordobas();
                            break;

                    }
                }
            }
            catch (Exception)
            {

                throw;
            }


        }
        public decimal sumarTransferenciaCordobas()
        {
            var Permisos = Negocio.ClasesCN.RolesPermisosCN.Cargar_Permisos(Clases.UsuarioLogueado.vID_Empleado).ToList();//.Any(T=>T.id_rol==100 && T.asignado==1)
            var valorConsolidado = Permisos.Any(T => T.id_rol == 11133 && T.asignado == 1);
            if (Clases.UsuarioLogueado.admin || valorConsolidado)
            {
                var valor_Transf = Negocio.ClasesCN.CajaCN.TRANSFERENCIA_SELECT(dt_fecha_arqueo.DateTime, 1);
                decimal suma_transferencia_cordobas = 0;

                foreach (var item in valor_Transf)
                {
                    suma_transferencia_cordobas += Convert.ToDecimal(item.MONTO);
                }
                return suma_transferencia_cordobas;
            }
            else
            {
                var valor_Transf = Negocio.ClasesCN.CajaCN.TRANSFERENCIA_SELECT_Empleado(dt_fecha_arqueo.DateTime, 1, Clases.UsuarioLogueado.vID_Empleado);
                decimal suma_transferencia_cordobas = 0;

                foreach (var item in valor_Transf)
                {
                    suma_transferencia_cordobas += Convert.ToDecimal(item.MONTO);
                }
                return suma_transferencia_cordobas;
            }
        }

        public decimal sumarChequesCordobas()
        {
            var Permisos = Negocio.ClasesCN.RolesPermisosCN.Cargar_Permisos(Clases.UsuarioLogueado.vID_Empleado).ToList();//.Any(T=>T.id_rol==100 && T.asignado==1)
            var valorConsolidado = Permisos.Any(T => T.id_rol == 11133 && T.asignado == 1);
            if (Clases.UsuarioLogueado.admin || valorConsolidado)
            {
                var valor_Transf = Negocio.ClasesCN.CajaCN.MOVIMIENTO_CAJA_MOSTRAR(dt_fecha_arqueo.DateTime.Date).Where(R => R.tipo_documento == 6 && R.id_forma_pago == 1006);
                decimal suma_cheque_cordobas = 0;

                foreach (var item in valor_Transf)
                {
                    suma_cheque_cordobas += Convert.ToDecimal(item.ingreso);
                }
                return suma_cheque_cordobas;
            }
            else
            {
                var valor_Transf = Negocio.ClasesCN.CajaCN.MOVIMIENTO_CAJA_MOSTRAR_EMPLEADO(dt_fecha_arqueo.DateTime.Date, Clases.UsuarioLogueado.vID_Empleado).Where(R => R.tipo_documento == 6 && R.id_forma_pago == 1006);
                decimal suma_cheque_cordobas = 0;

                foreach (var item in valor_Transf)
                {
                    suma_cheque_cordobas += Convert.ToDecimal(item.ingreso);
                }
                return suma_cheque_cordobas;
            }
        }

        public decimal sumarSaldosCordobas()
        {
            var Permisos = Negocio.ClasesCN.RolesPermisosCN.Cargar_Permisos(Clases.UsuarioLogueado.vID_Empleado).ToList();//.Any(T=>T.id_rol==100 && T.asignado==1)
            var valorConsolidado = Permisos.Any(T => T.id_rol == 11133 && T.asignado == 1);
            if (Clases.UsuarioLogueado.admin || valorConsolidado)
            {
                var valor_Transf = Negocio.ClasesCN.CajaCN.MOVIMIENTO_CAJA_MOSTRAR(dt_fecha_arqueo.DateTime.Date).Where(R => R.tipo_documento == 6 && R.id_forma_pago == 1008);
                decimal suma_cheque_cordobas = 0;

                foreach (var item in valor_Transf)
                {
                    suma_cheque_cordobas += Convert.ToDecimal(item.ingreso);
                }
                return suma_cheque_cordobas;
            }
            else
            {
                var valor_Transf = Negocio.ClasesCN.CajaCN.MOVIMIENTO_CAJA_MOSTRAR_EMPLEADO(dt_fecha_arqueo.DateTime.Date, Clases.UsuarioLogueado.vID_Empleado).Where(R => R.tipo_documento == 6 && R.id_forma_pago == 1008);
                decimal suma_cheque_cordobas = 0;

                foreach (var item in valor_Transf)
                {
                    suma_cheque_cordobas += Convert.ToDecimal(item.ingreso);
                }
                return suma_cheque_cordobas;
            }
        }

        public decimal sumarTransferenciaDolar()
        {

            var Permisos = Negocio.ClasesCN.RolesPermisosCN.Cargar_Permisos(Clases.UsuarioLogueado.vID_Empleado).ToList();//.Any(T=>T.id_rol==100 && T.asignado==1)
            var valorConsolidado = Permisos.Any(T => T.id_rol == 11133 && T.asignado == 1);
            if (Clases.UsuarioLogueado.admin || valorConsolidado)
            {
                var valor_Transf = Negocio.ClasesCN.CajaCN.TRANSFERENCIA_SELECT(dt_fecha_arqueo.DateTime, 2);
                decimal suma_transferencia_dolares = 0;

                foreach (var item in valor_Transf)
                {
                    suma_transferencia_dolares += Convert.ToDecimal(item.MONTO);
                }
                return suma_transferencia_dolares;
            }
            else
            {
                var valor_Transf = Negocio.ClasesCN.CajaCN.TRANSFERENCIA_SELECT_Empleado(dt_fecha_arqueo.DateTime, 2, Clases.UsuarioLogueado.vID_Empleado);
                decimal suma_transferencia_dolares = 0;

                foreach (var item in valor_Transf)
                {
                    suma_transferencia_dolares += Convert.ToDecimal(item.MONTO);
                }
                return suma_transferencia_dolares;
            }
        }

        public decimal sumarChequesDolar()
        {
            var Permisos = Negocio.ClasesCN.RolesPermisosCN.Cargar_Permisos(Clases.UsuarioLogueado.vID_Empleado).ToList();//.Any(T=>T.id_rol==100 && T.asignado==1)
            var valorConsolidado = Permisos.Any(T => T.id_rol == 11133 && T.asignado == 1);
            if (Clases.UsuarioLogueado.admin || valorConsolidado)
            {
                var valor_Transf = Negocio.ClasesCN.CajaCN.MOVIMIENTO_CAJA_MOSTRAR(dt_fecha_arqueo.DateTime.Date).Where(R => R.tipo_documento == 6 && R.id_forma_pago == 1005);
                decimal suma_cheque_cordobas = 0;

                foreach (var item in valor_Transf)
                {
                    suma_cheque_cordobas += Convert.ToDecimal(item.ingreso);
                }
                return suma_cheque_cordobas;
            }
            else
            {
                var valor_Transf = Negocio.ClasesCN.CajaCN.MOVIMIENTO_CAJA_MOSTRAR_EMPLEADO(dt_fecha_arqueo.DateTime.Date, Clases.UsuarioLogueado.vID_Empleado).Where(R => R.tipo_documento == 6 && R.id_forma_pago == 1005);
                decimal suma_cheque_cordobas = 0;

                foreach (var item in valor_Transf)
                {
                    suma_cheque_cordobas += Convert.ToDecimal(item.ingreso);
                }
                return suma_cheque_cordobas;
            }
        }

        public decimal sumarSaldosDolar()
        {
            var Permisos = Negocio.ClasesCN.RolesPermisosCN.Cargar_Permisos(Clases.UsuarioLogueado.vID_Empleado).ToList();//.Any(T=>T.id_rol==100 && T.asignado==1)
            var valorConsolidado = Permisos.Any(T => T.id_rol == 11133 && T.asignado == 1);
            if (Clases.UsuarioLogueado.admin || valorConsolidado)
            {
                var valor_Transf = Negocio.ClasesCN.CajaCN.MOVIMIENTO_CAJA_MOSTRAR(dt_fecha_arqueo.DateTime.Date).Where(R => R.tipo_documento == 6 && R.id_forma_pago == 1007);
                decimal suma_cheque_cordobas = 0;

                foreach (var item in valor_Transf)
                {
                    suma_cheque_cordobas += Convert.ToDecimal(item.ingreso);
                }
                return suma_cheque_cordobas;
            }
            else
            {
                var valor_Transf = Negocio.ClasesCN.CajaCN.MOVIMIENTO_CAJA_MOSTRAR_EMPLEADO(dt_fecha_arqueo.DateTime.Date, Clases.UsuarioLogueado.vID_Empleado).Where(R => R.tipo_documento == 6 && R.id_forma_pago == 1007);
                decimal suma_cheque_cordobas = 0;

                foreach (var item in valor_Transf)
                {
                    suma_cheque_cordobas += Convert.ToDecimal(item.ingreso);
                }
                return suma_cheque_cordobas;
            }
        }

    }
}