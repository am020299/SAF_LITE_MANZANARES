using DevExpress.XtraEditors;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Datos.ClasesCD
{
    public class CajaCD
    {
        #region SALDO INICIAL
        public int SALDO_INICIAL_GUARDAR(DateTime fecha, decimal saldo, int id_empleado, decimal tc)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.SaldoInicial_GUARDAR(fecha, saldo, id_empleado, tc);
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public int SALDO_INICIAL_ELIMINAR(int id_cierre, int id_empleado)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.SaldoInicial_Eliminar(id_cierre, id_empleado);
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public int SALDO_INICIAL_EDITAR(int id_cierre, DateTime fecha, decimal saldo, int id_empleado, decimal tc)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.SaldoInicial_Editar(id_cierre, fecha, saldo, id_empleado, tc);
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public List<SaldoInicial_Mostrar_Result> SALDO_INICIAL_MOSTRAR()
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.SaldoInicial_Mostrar().ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion
        #region VALIDACION SALDO INICIAL
        public bool SI_EXISTE_YA_UNA_FECHA_INGRESADA(DateTime fecha)
        {
            try
            {
                using (var db = new Entities())
                {
                    if (db.CierraCaja.Where(o => o.estado == 1 || o.estado == 2).Any(o => o.fecha_ejecucion == fecha))
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        public decimal SALDO_INICIAL_DIA(DateTime fecha)
        {
            try
            {
                using (var db = new Entities())
                {
                    decimal saldo_inicial = Convert.ToDecimal(db.CierraCaja.Where(o => o.estado != 0 && o.fecha_ejecucion == fecha).FirstOrDefault().saldo_inicial);
                    return saldo_inicial;
                }
            }
            catch (Exception)
            {
                return 0;// ERROR
            }
        }
        #endregion
        #region MOVIMIENTO DE CAJA
        public int MOVIMIENTO_CAJA_GUARDAR(DateTime fecha, string concepto, string persona, int tipo_movimiento, int id_documento, int tipo_documento, string numero_referencia, int id_usuario, decimal tipo_cambio, DevExpress.XtraGrid.Views.Grid.GridView view_pago, int N_Transferencia, DateTime fecha_deposito)
        {
            int vRetorno = 0;
            using (var db = new Entities())
            {
                using (var dbTrans = db.Database.BeginTransaction())
                {
                    try
                    {
                        int id_tipo_documento = db.TiposDocumentosCx.Where(x => x.estado == 1 && x.numero_documento == tipo_documento).FirstOrDefault().id_tipo_documento;
                        var z = db.MovimientoCaja_Guardar(fecha, concepto, persona, tipo_movimiento, id_documento, id_tipo_documento, numero_referencia, id_usuario).FirstOrDefault();
                        int id_mov = Convert.ToInt32(z.id_movimiento);
                        int pagoOK = 0;
                        for (int i = 0; i < view_pago.RowCount; i++)
                        {
                            int vIdFormaPago = Convert.ToInt32(view_pago.GetRowCellValue(i, "id_forma_pago"));
                            if (vIdFormaPago > 0)
                            {
                                decimal vMonto = Convert.ToDecimal(view_pago.GetRowCellValue(i, "monto"));
                                int FormaPagoOK = db.MovimientoCaja_Guardar_Detalle(id_mov, tipo_movimiento, tipo_cambio, vMonto, vIdFormaPago, N_Transferencia, fecha_deposito, "");
                                if (FormaPagoOK > 0) pagoOK++;
                            }
                        }

                        if (pagoOK == view_pago.RowCount) { vRetorno = id_mov; db.SaveChanges(); dbTrans.Commit(); }
                        else { dbTrans.Rollback(); }
                    }
                    catch (Exception ex)
                    {
                        dbTrans.Rollback();
                        XtraMessageBox.Show("Lo sentimos, ocurrio el siguiente error: " + ex.Message, "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        vRetorno = 0;
                    }

                }
            }

            return vRetorno;
        }
        public int MOVIMIENTO_CAJA_GUARDAR_DETALLE(int id_movimiento, int tipo_movimiento, decimal tipo_cambio, decimal cantidad, int id_forma, int N_Transferencia, DateTime fecha_deposito)
        {
            try
            {
                using (var db = new Entities())
                {
                    //tipo movimiento 1 entrada 0 salida moneda --1 cordoba 2 dolar --1 tarjeta 2 efectivo
                    return db.MovimientoCaja_Guardar_Detalle(id_movimiento, tipo_movimiento, tipo_cambio, cantidad, id_forma, N_Transferencia, fecha_deposito,"");
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public int MOVIMIENTO_CAJA_ELIMINAR(int id_usuario, int id_movimiento)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.MovimientoCaja_Eliminar(id_usuario, id_movimiento);
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public List<Transferencias_SELECT_Result> TRANSFERENCIAS_SELECT(DateTime fecha, int formapago)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Transferencias_SELECT(fecha,formapago).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Transferencias_SELECT_Empleado_Result> TRANSFERENCIAS_SELECT_Empleado(DateTime fecha, int formapago, int idEmpleado)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Transferencias_SELECT_Empleado(fecha, formapago, idEmpleado).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Transferencias_rango_SELECT_Result> TRANSFERENCIAS_rango_SELECT(DateTime fechaDesde, DateTime fechaHasta, int formapago)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Transferencias_rango_SELECT(fechaDesde, fechaHasta, formapago).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<SaldoFavorClientes_Select_Result> SaldoFavorClientes_Select(DateTime fechaDesde, DateTime fechaHasta)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.SaldoFavorClientes_Select(fechaDesde, fechaHasta).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Cheques_rango_SELECT_Result> CHEQUES_rango_SELECT(DateTime fechaDesde, DateTime fechaHasta, int formapago)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Cheques_rango_SELECT(fechaDesde, fechaHasta, formapago).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<cargarTodasTransferencias_Result> cargarTodasTransferencias()
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.cargarTodasTransferencias().ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        public List<MovimientoCaja_Mostrar_Result> MOVIMIENTO_CAJA_MOSTRAR(DateTime fecha)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.MovimientoCaja_Mostrar(fecha).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<MovimientoCaja_Mostrar_Empleado_Result> MOVIMIENTO_CAJA_MOSTRAR_EMPLEADO(DateTime fecha, int idEmpleado)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.MovimientoCaja_Mostrar_Empleado(fecha, idEmpleado).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<MovimientoCaja_Mostrar_Cordobas_Result> MOVIMIENTO_CAJA_MOSTRAR_CORDOBAS(DateTime Fecha)
        {

            try
            {
                using(var db = new Entities())
                {
                    return db.MovimientoCaja_Mostrar_Cordobas(Fecha).ToList();
                }
            }
            catch(Exception)
            {
                return null;
            }
        }

        public List<MovimientoCaja_Mostrar_Cordobas_Empleados_Result> MOVIMIENTO_CAJA_MOSTRAR_CORDOBAS_EMPLEADO(DateTime Fecha, int idEmpleado)
        {

            try
            {
                using (var db = new Entities())
                {
                    return db.MovimientoCaja_Mostrar_Cordobas_Empleados(Fecha, idEmpleado).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion
        #region ARQUEO CAJA
        public List<Arqueo_En_Blanco_Select_Result> Arqueo_en_blanco()
        {
            try
            {
                using(Entities db = new Entities())
                {
                    return db.Arqueo_En_Blanco_Select().ToList();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return null;
            }
        }

        public List<cargarTodasCheques_Result> cargarTodosCheques()
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.cargarTodasCheques().ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Arqueos Buscar_Arqueo_Fecha(DateTime Fecha, int id_empleado)
        {
            try
            {
                using(Entities db= new Entities())
                {
                    if(db.Arqueos.Count() > 0)
                    {
                        var X= db.Arqueo_Obetener_ID(Fecha.Date, id_empleado).ToList();
                        int id_arqueo=X.Count()>0?X.FirstOrDefault().Value:0;
                        return db.Arqueos.Where(A => A.id_registro == id_arqueo && A.id_empleado_registro == id_empleado).Count()>0? db.Arqueos.Where(A => A.id_registro == id_arqueo && A.id_empleado_registro == id_empleado).FirstOrDefault():new Arqueos();

                    }
                    else
                    {
                        return new Arqueos();
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return null;
            }
        }

        public int Buscar_Arqueo_Fecha_General(DateTime Fecha)
        {
            try
            {
                using (Entities db = new Entities())
                {
                    if (db.Arqueos.Count() > 0)
                    {
                        var X = db.Arqueo_Obetener_ID_GeneralDia(Fecha.Date).ToList();
                        return X.Count;

                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return 0;
            }
        }

        public List<Arqueo_Obetener_ID_GeneralDia_Result> Buscar_Arqueo_Fecha_Validar(DateTime Fecha)
        {
            try
            {
                using (Entities db = new Entities())
                {
                    if (db.Arqueos.Count() > 0)
                    {
                        return db.Arqueo_Obetener_ID_GeneralDia(Fecha.Date).ToList();
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return null;
            }
        }

        public List<Arqueo_reporte_select_Result> Reporte_Arqueo(int id)
        {
            try
            {
                using(Entities db= new Entities())
                {
                    return db.Arqueo_reporte_select(id).ToList();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Arqueo_reporte_select_Result>();
            }
        }

        public List<Arqueo_reporte_select_Empleado_Result> Reporte_Arqueo_Empleado(int id, int idEmpleado)
        {
            try
            {
                using (Entities db = new Entities())
                {
                    return db.Arqueo_reporte_select_Empleado(id, idEmpleado).ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Arqueo_reporte_select_Empleado_Result>();
            }
        }

        public List<Arqueo_reporte_select_General_Result> Reporte_Arqueo_General(DateTime fecha)
        {
            try
            {
                using (Entities db = new Entities())
                {
                    return db.Arqueo_reporte_select_General(fecha).ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Arqueo_reporte_select_General_Result>();
            }
        }

        public List<Arqueo_Select_Por_ID_Result> Cargar_Arqueo_por_ID(int id_arqueo)
        {
            try
            {
                using(var db= new Entities())
                {
                    return db.Arqueo_Select_Por_ID(id_arqueo).ToList();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
                
            }
        }

        public List<Arqueo_Select_Por_Fecha_Result> Cargar_Arqueo_por_Fecha(DateTime fecha)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Arqueo_Select_Por_Fecha(fecha).ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;

            }
        }

        public bool Arqueo_Guardar(DateTime fecha_arqueo,int empleado,int estado_arqueo, decimal tipo_cambio,DevExpress.XtraGrid.Views.Grid.GridView view_cordobas_inicial,DevExpress.XtraGrid.Views.Grid.GridView view_dolares_inicial,DevExpress.XtraGrid.Views.Grid.GridView view_cordobas_final,DevExpress.XtraGrid.Views.Grid.GridView view_dolares_final, int id_arqueo_)
        {
           
                bool retorno=false;
               // int numero_arqueo=0;
                int id_arqueo_id=0;
                using(Entities db= new Entities())
                {
                 using(var trans=db.Database.BeginTransaction())
                 {
                    try
                    {
                        int inicial_cordobas=0;
                        int inicial_dolares=0;
                        int final_dolares=0;
                        int final_cordobas=0;
                        if(id_arqueo_ == 0)
                        {
                            db.ArqueoInsert(fecha_arqueo,empleado,estado_arqueo,tipo_cambio,0);
                            id_arqueo_id = db.Arqueos.Max(C => C.id_registro);
                        }
                        else
                        {
                            id_arqueo_id = id_arqueo_;
                        }
                        if(id_arqueo_id > 0)
                        {
                            for(int i = 0;i < view_cordobas_inicial.RowCount;i++)
                            {
                                int id_denominacion = Convert.ToInt32(view_cordobas_inicial.GetRowCellValue(i, "id_denominacion"));
                                decimal cantidad = Convert.ToDecimal(view_cordobas_inicial.GetRowCellValue(i, "cantidad"));
                                decimal total = Convert.ToDecimal(view_cordobas_inicial.GetRowCellValue(i, "total"));
                                var AD=db.Arqueo_detalle_Insert(id_arqueo_id,id_denominacion,cantidad,total,1);

                                if(AD > 0)
                                    inicial_cordobas++;
                                else
                                    break;
                            }
                            for(int i = 0;i < view_dolares_inicial.RowCount;i++)
                            {
                                int id_denominacion = Convert.ToInt32(view_dolares_inicial.GetRowCellValue(i, "id_denominacion"));
                                decimal cantidad = Convert.ToDecimal(view_dolares_inicial.GetRowCellValue(i, "cantidad"));
                                decimal total = Convert.ToDecimal(view_dolares_inicial.GetRowCellValue(i, "total"));
                                var AD=db.Arqueo_detalle_Insert(id_arqueo_id,id_denominacion,cantidad,total,1);

                                if(AD > 0)
                                    inicial_dolares++;
                                else
                                    break;
                            }
                            for(int i = 0;i <  view_dolares_final.RowCount;i++)
                            {
                                int id_denominacion = Convert.ToInt32(view_dolares_final.GetRowCellValue(i, "id_denominacion"));
                                decimal cantidad = Convert.ToDecimal(view_dolares_final.GetRowCellValue(i, "cantidad"));
                                decimal total = Convert.ToDecimal(view_dolares_final.GetRowCellValue(i, "total1"));
                                var AD=db.Arqueo_detalle_Insert(id_arqueo_id,id_denominacion,cantidad,total,2);

                                if(AD > 0)
                                    final_dolares++;
                                else
                                    break;
                            }
                            for(int i = 0;i < view_cordobas_final.RowCount;i++)
                            {
                                int id_denominacion = Convert.ToInt32(view_cordobas_final.GetRowCellValue(i, "id_denominacion"));
                                decimal cantidad = Convert.ToDecimal(view_cordobas_final.GetRowCellValue(i, "cantidad"));
                                decimal total = Convert.ToDecimal(view_cordobas_final.GetRowCellValue(i, "total1"));
                                var AD=db.Arqueo_detalle_Insert(id_arqueo_id,id_denominacion,cantidad,total,2);

                                if(AD > 0)
                                    final_cordobas++;
                                else
                                    break;
                            }

                        }

                        if(inicial_cordobas == view_cordobas_inicial.RowCount && inicial_dolares == view_dolares_inicial.RowCount && final_cordobas == view_cordobas_final.RowCount && final_dolares == view_dolares_final.RowCount)
                        {
                            retorno = true;
                        }
                        if(retorno)
                        {
                            db.SaveChanges();
                            trans.Commit();
                        }
                        else
                        {
                            trans.Rollback();
                        }
                    }
                    catch(Exception ex)
                    {
                        trans.Rollback();
                        XtraMessageBox.Show("Lo sentimos, ocurrio el siguiente error: " + ex.Message,"Mensaje del sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        retorno = false;
                    }
                 }
             
                }
            return retorno;
        }
       

        #endregion
        #region CIERRE DE CAJA
        public int CIERRE_CAJA_GUARDAR(DateTime fecha, decimal saldo, int id_empleado)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.CierreCaja_Guardar(fecha, saldo, id_empleado);
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int REABRIR_ARQUEO_CAJA(DateTime fecha)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Reabrir_Arqueos(fecha);
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        #endregion
        #region VALIDACION CIERRE DE CAJA
        public int VALIDAR_CIERRE_DE_CAJA(DateTime fecha)
        {
            try
            {
                using (var db = new Entities())
                {
                    //decimal= 
                    if (db.CierraCaja.Where(o => o.estado == 1).Any(o => o.fecha_ejecucion == fecha))
                    {
                        int facturas_sin_generar_recibo = (db.Venta.Where(o => o.fecha == fecha && o.id_termino == 1 && o.estado == 1 && o.activo == true).Count());
                        if (facturas_sin_generar_recibo > 0)
                            return 3;// HAY FACTURAS PENDIENTE PARA RECIBO
                        else
                            return 1;// HAY FECHA PARA CIERRE
                    }
                    else
                        return 2;//NO HAY FECHA PARA CIERRE
                }
            }
            catch (Exception)
            {
                return 0;// ERROR
            }
        }
        public bool CONSULTAR_SI_FECHA_ESTA_CERRADA(DateTime fecha)
        {
            try
            {
                using (var db = new Entities())
                {
                    //decimal= 
                    if (db.Arqueos.Where(o => o.estado_arqueo == 2).Any(o => o.fecha_arqueo.Value.Year== fecha.Year && o.fecha_arqueo.Value.Month==fecha.Month && o.fecha_arqueo.Value.Day==fecha.Day))
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                return false;// ERROR
            }
        }
        public bool CONSULTAR_SI_HAY_FACTURAS_SIN_RECIBO()
        {
            try
            {
                using (var db = new Entities())
                {
                    int contador = Convert.ToInt32(db.Venta.Where(o=>o.activo== true && (o.estado==1 || o.estado==3) && o.tipo==1).Count());
                    //decimal= 
                   if(contador>0)
                        return true;
                  else 
                        return false;
                }
            }
            catch (Exception)
            {
                return false;// ERROR
            }
        }
        #endregion
        #region DATOS INGRESO EGRESO
        public int numero_recibo(int tipo_movimiento)
        {
            try
            {
                using (var db = new Entities())
                {
                    return Convert.ToInt32(db.MovimientoCaja.Where(o => o.tipo_movimiento == tipo_movimiento).Max(o => o.numero));
                }
            }
            catch (Exception)
            {
                return 0;// ERROR
            }
        }
        public List<PersonaReferencia> Personas_Referencias()
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.PersonaReferencia.ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        public decimal saldo_disponible_del_dia(DateTime fecha)
        {
            try
            {
                using (var db = new Entities())
                {
                    decimal saldo_inicial = Convert.ToDecimal(db.CierraCaja.Where(o => o.fecha_ejecucion == fecha && o.estado != 0).FirstOrDefault().saldo_inicial);
                    decimal saldo_movimiento = Convert.ToDecimal(db.MovimientoCaja_Mostrar(fecha).Sum(o => o.ingreso - o.egreso));
                    return saldo_inicial + saldo_movimiento;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public decimal saldo_inicial_del_dia(DateTime fecha)
        {
            try
            {
                using (var db = new Entities())
                {
                    return Convert.ToDecimal(db.CierraCaja.Where(o => o.fecha_ejecucion == fecha && o.estado != 0).FirstOrDefault().saldo_inicial);
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }
        #endregion
        #region  REPORTE
        public List<Reporte_Recibo_Result> Reporte_de_recibo(int id_mov)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Reporte_Recibo(id_mov).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        public List<Reporte_Movimiento_Por_Dia_Result> Reporte_de_Movimiento(DateTime fecha)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Reporte_Movimiento_Por_Dia(fecha).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        public List<Reporte_Movimiento_Por_Dia_Detallado_Result> Reporte_de_Movimiento_Detallado(DateTime fecha)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Reporte_Movimiento_Por_Dia_Detallado(fecha).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        public List<Reporte_Movimiento_Egresos_Result> Reporte_de_Egresos(DateTime fecha_inicio, DateTime fecha_fin)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Reporte_Movimiento_Egresos(fecha_inicio, fecha_fin).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

        int ADS=0;
        

        #region VENTA DEVOLUCION PAGO

        public Tuple<bool, int, int, string> VENTA_DEVOLUCION_PAGO(int xIdEmpleado, int xVendedor, int xNumero, int xIdCliente, DateTime xFecha, DateTime xFechaMaxima, decimal xTipoCambio, string xObservacion, int xTipo, int xIdTermino, string xPersonaReferencia, int id_tipo_ajuste, DevExpress.XtraGrid.Views.Grid.GridView view, DevExpress.XtraGrid.Views.Grid.GridView view_ajuste, DevExpress.XtraGrid.Views.Grid.GridView viewPago,int id_lote,int id_reprresentante,int moneda, int persona_autoriza,int xPrecio, int vCambioPrecioCliente)
        {
            ADS.ToString().ToLower().Contains("");
            bool vRetorno = false;
            string vNumero = "";
            int vIdVenta = 0;
            int id_ajuste_generado = 0;
            using (var db = new Entities())
            {
                using (var dbTrans = db.Database.BeginTransaction())
                {
                    try
                    {
                        var ventaOK = db.Venta_GUARDAR(xIdEmpleado, xNumero, xIdCliente, xFecha, xFechaMaxima, xTipoCambio, xObservacion, xTipo, xIdTermino, xVendedor,"",moneda,persona_autoriza,xPrecio, vCambioPrecioCliente,0.00M,0.00M).FirstOrDefault();///---------------------------------GUARDAR FACTURA*************************//////////////
                        if (ventaOK != null)
                        {
                            vIdVenta = ventaOK.id;
                            vNumero = ventaOK.numero;
                            int vIdAjuste = db.AjustesModulos.Where(x => x.activo == true && x.tipo == 2).FirstOrDefault().id_ajuste;///ID AJUSTE PARA SALIDA DE BODEGA
                            //int vIdAjuste_DEV = id_tipo_ajuste;///ID AJUSTE PARA ENTRADA DE BODEGA
                            var query_venta = db.Venta.Where(o => o.id == vIdVenta).FirstOrDefault();
                            var nombre_cliente = db.Cliente.Where(o => o.id == query_venta.id_cliente).FirstOrDefault();
                            var id_tipo = db.TiposDocumentosCx.Where(o => o.numero_documento == 6).FirstOrDefault();
                            var movOK = db.MovimientoInventario_INSERT(vIdAjuste, xFecha, vNumero, xObservacion, xIdEmpleado, xPersonaReferencia, 2, vIdVenta).FirstOrDefault();///---------------------------------GUARDAR SALIDA DE BODEGA*************************//////////////
                            var movOK_DEV = db.MovimientoInventario_INSERT(id_tipo_ajuste, xFecha, vNumero, xObservacion, xIdEmpleado, xPersonaReferencia, 4, vIdVenta).FirstOrDefault();///---------------------------------GUARDAR ENTRADA DE BODEGA*************************//////////////
                            var mov_caja = db.MovimientoCaja_Guardar(DateTime.Now, xObservacion + " AJUSTE DE INVENTARIO N° " + movOK_DEV.numero_documento, nombre_cliente.nombre, 1, vIdVenta, id_tipo.id_tipo_documento, query_venta.numero, xIdEmpleado).FirstOrDefault();///---------------------------------GUARDAR MOVIMIENTO DE CAJA*************************//////////////
                            int id_mov_caja = Convert.ToInt32(mov_caja.id_movimiento);
                            id_ajuste_generado = movOK_DEV.id;
                            int Ok = 0;
                            decimal vSumTotal = 0.00M, vSumImpuesto = 0.00M, vSumDescuento = 0.00M, vSumSubTotal = 0.00M;
                            for (int i = 0; i < view.RowCount; i++)
                            {
                                int vIdBodega = Convert.ToInt32(view.GetRowCellValue(i, "id_bodega"));
                                int vIdProducto = Convert.ToInt32(view.GetRowCellValue(i, "id_producto"));
                                int vid_lote = Convert.ToInt32(view.GetRowCellValue(i,"id_lote"));
                                decimal vCantidad = Convert.ToDecimal(view.GetRowCellValue(i, "cantidad"));
                                decimal vPrecio = Convert.ToDecimal(view.GetRowCellValue(i, "precio1"));
                                decimal vDescuento = Convert.ToDecimal(view.GetRowCellValue(i, "descuento"));
                                decimal vImpuesto = Convert.ToDecimal(view.GetRowCellValue(i, "impuesto"));
                                decimal vTotal = Convert.ToDecimal(view.GetRowCellValue(i, "total"));             
                                decimal vCosto = db.Producto.Where(x => x.id == vIdProducto).Select(x => x.costo).FirstOrDefault().Value;
                                string vUbicacion = Convert.ToString(view.GetRowCellValue(i, "ubicacion"));

                                vSumTotal += vTotal;
                                vSumSubTotal += (vCantidad * vPrecio);
                                vSumDescuento += ((vCantidad * vPrecio) * (vDescuento / 100));
                                vSumImpuesto += ((vCantidad * vPrecio) * (1 - (vDescuento / 100))) * (vImpuesto / 100);

                                int detalleOK = db.VentaDetalle_INSERTAR(vIdVenta, vIdBodega, vIdProducto, vCantidad, vPrecio, vDescuento, vImpuesto, vTotal,vid_lote,vUbicacion,null);///---------------------------------GUARDAR DETALLES DE FACTURA*************************//////////////
                              int detalleMovOK = db.MovimientoInventarioDetalle_INSERT(movOK.id, vIdBodega, vIdProducto, vCantidad, vCosto, vUbicacion,id_lote);/// agregado id_lote--------------------------------GUARDAR DETALLES DE SALIDA DE INVENTARIO*************************//////////////
                                if (detalleOK > 0 && detalleMovOK > 0) Ok++;
                                else break;
                            }
                            int devOK = 0;
                            for (int i = 0; i < view_ajuste.RowCount; i++)//---------------------------------------------------------------------GUARDAR DETALLES ENTRADA DE BODEGA------///////////////////////////////
                            {
                                int vIdBodega = Convert.ToInt32(view_ajuste.GetRowCellValue(i, "id_bodega"));
                                int vIdProducto = Convert.ToInt32(view_ajuste.GetRowCellValue(i, "id_producto"));
                                decimal vCantidad = Convert.ToDecimal(view_ajuste.GetRowCellValue(i, "cantidad"));
                                decimal vCosto = db.Producto.Where(x => x.id == vIdProducto).Select(x => x.costo).FirstOrDefault().Value;
                                string vUbicacion = (db.Kardex.Where(x => x.id_producto == vIdProducto && x.id_bodega == vIdBodega).Select(x => x.ubicacion).FirstOrDefault() != null) ? db.Kardex.Where(x => x.id_producto == vIdProducto && x.id_bodega == vIdBodega).Select(x => x.ubicacion).FirstOrDefault() : "";                             
                                int detalleDEVOK = db.MovimientoInventarioDetalle_INSERT_DEVOLUCION(movOK_DEV.id, vIdBodega,  vIdProducto, vCantidad, vCosto, vUbicacion,id_lote);//agregado id_lote
                                if (detalleDEVOK > 0) devOK++;
                                else break;
                            }

                            int pagoOK = 0;
                            for (int i = 0; i < viewPago.RowCount; i++)///---------------------------------GUARDAR DETALLES DE FORMA DE PAGO(MOVIMIENTO DE CAJA)*************************//////////////
                            {
                                int vIdFormaPago = Convert.ToInt32(viewPago.GetRowCellValue(i, "id_forma_pago"));
                                decimal vMonto = Convert.ToDecimal(viewPago.GetRowCellValue(i, "monto"));
                                decimal tc = Convert.ToDecimal(viewPago.GetRowCellValue(i, "tipo_cambio"));
                                int FormaPagoOK = db.MovimientoCaja_Guardar_Detalle(mov_caja.id_movimiento, 1, tc, vMonto, vIdFormaPago, null, null,"");
                                if (FormaPagoOK > 0) pagoOK++;
                                else break;
                            }

                            if (db.Terminos.Where(x => x.id == xIdTermino).FirstOrDefault().dias > 0)///---------------------------------GUARDAR DOCUMENTO POR COBRAR*************************//////////////
                            {
                                bool okCxC = db.DocumentosCuentasCobrar_Insert(6, xIdCliente, int.Parse(vNumero.Replace("V", "")), xFecha, vSumTotal, vSumSubTotal, vSumDescuento, vSumImpuesto, xIdEmpleado, "FACTURA DE CREDITO " + vNumero, xVendedor, 0.00M, false, xIdTermino, 1, vIdVenta).FirstOrDefault().HasValue;
                            }
                            //*****************VENTA, SALIDA DE BODEGA, ENTRADA DE BODEGA, PAGO*************************************************////////////////////////////////*************


                            //if (okCxC && Ok == view.RowCount && pagoOK == viewPago.RowCount) vRetorno = true;
                            //else 
                            if (Ok == view.RowCount && pagoOK == viewPago.RowCount && devOK == view_ajuste.RowCount) vRetorno = true;
                        }
                        if (vRetorno) { db.SaveChanges(); dbTrans.Commit(); }
                        else { dbTrans.Rollback(); }
                    }
                    catch (Exception ex)
                    {
                        dbTrans.Rollback();
                        XtraMessageBox.Show("Lo sentimos, ocurrio el siguiente error: " + ex.Message, "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        vRetorno = false;
                    }
                }
            }
            return Tuple.Create(vRetorno, vIdVenta, id_ajuste_generado, vNumero);
        }

        public List<Diferencia_recibir_venta_como_publicidad_Result> Diferencia_Precios(DateTime desde,DateTime Hasta)
        {
            try
            {
                using(var db= new Entities())
                {
                    return db.Diferencia_recibir_venta_como_publicidad(desde.Date,Hasta.Date).ToList();
                }
            }
            catch(Exception ex)
            {
                
                Console.WriteLine(ex.Message.ToString());
                return null;
            }    
           
        }
       public List<MovimientoCajaDetalle> getMovimientoCajaDetalle()
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.MovimientoCajaDetalle.ToList();
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message.ToString());
                return null;
            }
        }
        #endregion

    }
}
