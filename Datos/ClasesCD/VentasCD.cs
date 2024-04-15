using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Datos.ClasesCD
{
    public class VentasCD
    {
        public int FORMA_PAGO_VENTA_GUARDAR(int id_venta, int id_empleado, GridView view, GridView viewPago, int tipo_documento, int tipo_vuelto, decimal cantidad_vuelto, DateTime fecha, int N_Transferencia, int id_saldo)
        {
            int vRetorno = 0;
            using (var db = new Entities())
            {
                using (var dbTrans = db.Database.BeginTransaction())
                {
                    try
                    {
                        int pagoOK = 0;

                        var id_tipo_dolares = db.TiposDocumentosCx.Where(o => o.numero_documento == 8).FirstOrDefault();

                        if (tipo_documento == 1)
                        {
                            var query_venta = db.Venta.Where(o => o.id == id_venta).FirstOrDefault();
                            var nombre_cliente = db.Cliente.Where(o => o.id == query_venta.id_cliente).FirstOrDefault();
                            var id_tipo = db.TiposDocumentosCx.Where(o => o.numero_documento == 6).FirstOrDefault();
                            if (!db.MovimientoCaja.Any(o => o.id_tipo_documento == id_tipo.id_tipo_documento && o.id_documento == id_venta))
                            {
                                var mov_caja = db.MovimientoCaja_Guardar(fecha.Date, "FACTURA " + query_venta.numero, nombre_cliente.nombre, 1, id_venta, query_venta.moneda == 2 ? id_tipo.id_tipo_documento : id_tipo_dolares.id_tipo_documento, query_venta.numero, id_empleado).FirstOrDefault();
                                int id_mov_caja = Convert.ToInt32(mov_caja.id_movimiento);
                                for (int i = 0; i < viewPago.RowCount; i++)
                                {
                                    int vIdFormaPago = Convert.ToInt32(viewPago.GetRowCellValue(i, "id_forma_pago"));
                                    int tipo_moneda = Convert.ToInt32(viewPago.GetRowCellValue(i, "moneda"));
                                    decimal vMonto = Convert.ToDecimal(viewPago.GetRowCellValue(i, "monto"));
                                    decimal tc = Convert.ToDecimal(viewPago.GetRowCellValue(i, "tipo_cambio"));
                                    int transferencia = Convert.ToInt32(viewPago.GetRowCellValue(i, "n_transferencia"));
                                    DateTime fecha_deposito = Convert.ToDateTime(viewPago.GetRowCellValue(i, "fecha_deposito"));
                                    string banco = Convert.ToString(viewPago.GetRowCellValue(i, "banco"));

                                    if (query_venta.moneda == 2)
                                    {
                                        if (tipo_vuelto == 0 && tipo_moneda == 2 && transferencia <= 1)
                                        {
                                            vMonto = vMonto - cantidad_vuelto;
                                            cantidad_vuelto = 0;
                                        }
                                        else if (tipo_vuelto == 1 && tipo_moneda == 1)
                                        {
                                            vMonto = vMonto - cantidad_vuelto;
                                            cantidad_vuelto = 0;
                                        }
                                    }
                                    else
                                    {
                                        if (tipo_vuelto == 1 && tipo_moneda == 1 && transferencia <= 1)
                                        {
                                            vMonto = vMonto - cantidad_vuelto;
                                            cantidad_vuelto = 0;
                                        }
                                        else if (tipo_vuelto == 1 && tipo_moneda == 2 && vMonto > 0)
                                        {
                                            vMonto = vMonto - (cantidad_vuelto / tc);
                                            // if (vMonto>0)
                                            cantidad_vuelto = 0;
                                        }
                                    }
                                    int FormaPagoOK = db.MovimientoCaja_Guardar_Detalle(id_mov_caja, 1, tc, vMonto, vIdFormaPago, transferencia, fecha_deposito, banco);
                                    if (FormaPagoOK > 0) pagoOK++;
                                    else break;

                                    if (id_saldo > 0)
                                    {
                                        SaldoFavorCliente sfc = db.SaldoFavorCliente.Find(id_saldo);
                                        sfc.estado = 2;
                                        sfc.id_venta_usada = id_venta;
                                    }
                                }

                                {
                                    if (pagoOK == viewPago.RowCount)
                                        vRetorno = id_mov_caja;
                                    else
                                        vRetorno = 0;
                                }

                                if (vRetorno == id_mov_caja) { db.SaveChanges(); dbTrans.Commit(); }
                                else { dbTrans.Rollback(); }
                            }
                        }
                        else if (tipo_documento == 2)
                        {
                            var query_abono = db.Abonos_Caja.Where(o => o.id == id_venta).FirstOrDefault();
                            var query_cuenta_cobrar = db.DocumentosCuentasCobrar.Where(o => o.id_documento == query_abono.id_documento).FirstOrDefault();
                            var nombre_cliente = db.Cliente.Where(o => o.id == query_abono.id_cliente).FirstOrDefault();
                            var id_tipo = db.TiposDocumentosCx.Where(o => o.numero_documento == 7).FirstOrDefault();

                            Abonos_Caja ac = db.Abonos_Caja.Find(id_venta);
                            ac.estado = 2;
                            db.SaveChanges();

                            if (!db.MovimientoCaja.Any(o => o.id_tipo_documento == id_tipo.id_tipo_documento && o.id_documento == id_venta))
                            {
                                var mov_caja = db.MovimientoCaja_Guardar(fecha.Date, query_abono.observacion, nombre_cliente.nombre, 1, id_venta, id_tipo.id_tipo_documento, query_cuenta_cobrar.numero_doc.ToString(), id_empleado).FirstOrDefault();
                                int id_mov_caja = Convert.ToInt32(mov_caja.id_movimiento);
                                for (int i = 0; i < viewPago.RowCount; i++)
                                {
                                    int vIdFormaPago = Convert.ToInt32(viewPago.GetRowCellValue(i, "id_forma_pago"));
                                    int tipo_moneda = Convert.ToInt32(viewPago.GetRowCellValue(i, "moneda"));
                                    decimal vMonto = Convert.ToDecimal(viewPago.GetRowCellValue(i, "monto"));
                                    decimal tc = Convert.ToDecimal(viewPago.GetRowCellValue(i, "tipo_cambio"));
                                    int transferencia = Convert.ToInt32(viewPago.GetRowCellValue(i, "n_transferencia"));
                                    DateTime fecha_deposito = Convert.ToDateTime(viewPago.GetRowCellValue(i, "fecha_deposito"));
                                    string banco = Convert.ToString(viewPago.GetRowCellValue(i, "banco"));

                                    if (tipo_vuelto == 0 && tipo_moneda == 2 && transferencia <= 1)
                                    {
                                        vMonto = vMonto - cantidad_vuelto;
                                        cantidad_vuelto = 0;
                                    }
                                    else if (tipo_vuelto == 1 && tipo_moneda == 1)
                                    {
                                        vMonto = vMonto - cantidad_vuelto;
                                        cantidad_vuelto = 0;
                                    }
                                    int FormaPagoOK = db.MovimientoCaja_Guardar_Detalle(id_mov_caja, 1, tc, vMonto, vIdFormaPago, transferencia, fecha_deposito, banco);
                                    if (FormaPagoOK > 0) pagoOK++;
                                    else break;
                                }

                                {
                                    if (pagoOK == viewPago.RowCount)
                                        vRetorno = id_mov_caja;
                                    else
                                        vRetorno = 0;
                                }

                                if (vRetorno == id_mov_caja) { db.SaveChanges(); dbTrans.Commit(); }
                                else { dbTrans.Rollback(); }
                            }
                        }

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

        public List<TotalVentasDetalleProducto_Result> TotalVentasDetalleProducto(int id_producto, DateTime fecha_ini, DateTime fecha_fin)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.TotalVentasDetalleProducto(id_producto, fecha_ini, fecha_fin).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Tuple<bool, int, string> Venta_Guardar(int xIdEmpleado, int xVendedor, int xNumero, int xIdCliente, DateTime xFecha, DateTime xFechaMaxima, decimal xTipoCambio, string xObservacion, int xTipo, int xIdTermino, string xPersonaReferencia, DevExpress.XtraGrid.Views.Grid.GridView view, DevExpress.XtraGrid.Views.Grid.GridView viewPago, string representante, int moneda, int persona_autoriza, int xPrecio, int vCambioPrecioCliente, decimal retencion1, decimal retencion2)
        {
            bool vRetorno = false;
            string vNumero = "";
            int vIdVenta = 0;
            using (var db = new Entities())
            {
                using (var dbTrans = db.Database.BeginTransaction())
                {
                    try
                    {
                        var ventaOK = db.Venta_GUARDAR(xIdEmpleado, xNumero, xIdCliente, xFecha, xFechaMaxima, xTipoCambio, xObservacion, xTipo, xIdTermino, xVendedor, representante, moneda, persona_autoriza, xPrecio, vCambioPrecioCliente,retencion1,retencion2).FirstOrDefault();
                        if (ventaOK != null)
                        {
                            vIdVenta = ventaOK.id;
                            vNumero = ventaOK.numero;


                            if (xTipo > 0)
                            {


                                int Ok = 0;
                                int ok_inventario = 0;
                                decimal vSumTotal = 0.00M, vSumImpuesto = 0.00M, vSumDescuento = 0.00M, vSumSubTotal = 0.00M;
                                for (int i = 0; i < view.RowCount; i++)
                                {
                                    int vIdBodega = Convert.ToInt32(view.GetRowCellValue(i, "id_bodega"));
                                    int vIdProducto = Convert.ToInt32(view.GetRowCellValue(i, "id_producto"));
                                    int vid_lote = Convert.ToInt32(view.GetRowCellValue(i, "id_lote"));
                                    decimal vCantidad = Convert.ToDecimal(view.GetRowCellValue(i, "cantidad"));
                                    decimal vPrecio = Convert.ToDecimal(view.GetRowCellValue(i, "precio1"));
                                    decimal vDescuento = Convert.ToDecimal(view.GetRowCellValue(i, "descuento"));
                                    decimal vImpuesto = Convert.ToDecimal(view.GetRowCellValue(i, "impuesto"));
                                    decimal vTotal = Convert.ToDecimal(view.GetRowCellValue(i, "total"));
                                    string vUbicacion = Convert.ToString(view.GetRowCellValue(i, "ubicacion"));
                                    string vdescripcion = Convert.ToString(view.GetRowCellValue(i, "descripcion"));

                                    vSumTotal += vTotal;
                                    vSumSubTotal += (vCantidad * vPrecio);
                                    vSumDescuento += ((vCantidad * vPrecio) * (vDescuento / 100));
                                    vSumImpuesto += ((vCantidad * vPrecio) * (1 - (vDescuento / 100))) * (vImpuesto / 100);

                                    int detalleOK = db.VentaDetalle_INSERTAR(vIdVenta, vIdBodega, vIdProducto, vCantidad, vPrecio, vDescuento, vImpuesto, vTotal, vid_lote, vUbicacion, vdescripcion);

                                    if (detalleOK > 0) Ok++;
                                    else break;
                                }

                                var query_venta = db.Venta.Where(o => o.id == vIdVenta).FirstOrDefault();
                                var nombre_cliente = db.Cliente.Where(o => o.id == query_venta.id_cliente).FirstOrDefault();
                                var id_tipo = db.TiposDocumentosCx.Where(o => o.numero_documento == 6).FirstOrDefault();
                                var id_tipo_dolares = db.TiposDocumentosCx.Where(o => o.numero_documento == 8).FirstOrDefault();
                                int vIdAjuste = db.AjustesModulos.Where(x => x.activo == true && x.tipo == 2).FirstOrDefault().id_ajuste;

                                if (db.Terminos.Where(x => x.id == xIdTermino).FirstOrDefault().dias == 0)
                                {
                                    var movOK = db.MovimientoInventario_INSERT(vIdAjuste, query_venta.fecha, query_venta.numero, query_venta.observacion, query_venta.vendedor, nombre_cliente.nombre, 2, vIdVenta).FirstOrDefault();
                                    for (int i = 0; i < view.RowCount; i++)
                                    {
                                        int vIdBodega = Convert.ToInt32(view.GetRowCellValue(i, "id_bodega"));
                                        int vIdProducto = Convert.ToInt32(view.GetRowCellValue(i, "id_producto"));
                                        int Vid_Lote = Convert.ToInt32(view.GetRowCellValue(i, "id_lote"));
                                        decimal vCantidad = Convert.ToDecimal(view.GetRowCellValue(i, "cantidad"));
                                        decimal vPrecio = Convert.ToDecimal(view.GetRowCellValue(i, "precio1"));
                                        decimal vDescuento = Convert.ToDecimal(view.GetRowCellValue(i, "descuento"));
                                        decimal vImpuesto = Convert.ToDecimal(view.GetRowCellValue(i, "impuesto"));
                                        decimal vTotal = Convert.ToDecimal(view.GetRowCellValue(i, "total"));
                                        decimal vCosto = db.Producto.Where(x => x.id == vIdProducto).Select(x => x.costo).FirstOrDefault().Value;
                                        string vUbicacion = Convert.ToString(view.GetRowCellValue(i, "ubicacion"));
                                        //(db.Kardex.Where(x => x.id_producto == vIdProducto && x.id_bodega == vIdBodega && x.id_lote==Vid_Lote).Select(x => x.ubicacion).FirstOrDefault() != null) ? db.Kardex.Where(x => x.id_producto == vIdProducto && x.id_bodega == vIdBodega).Select(x => x.ubicacion).FirstOrDefault() : "";

                                        int detalleMovOK = db.MovimientoInventarioDetalle_INSERT(movOK.id, vIdBodega, vIdProducto, vCantidad, vCosto, vUbicacion, Vid_Lote);
                                        if (detalleMovOK > 0) ok_inventario++;
                                        else break;
                                    }
                                    //if(Ok == view.RowCount && pagoOK == viewPago.RowCount)
                                    //    vRetorno = id_mov_caja;
                                    //else
                                    //    vRetorno = 0;
                                }




                                int pagoOK = 0;
                                for (int i = 0; i < viewPago.RowCount; i++)
                                {
                                    int vIdFormaPago = Convert.ToInt32(viewPago.GetRowCellValue(i, "id_forma_pago"));
                                    decimal vMonto = Convert.ToDecimal(viewPago.GetRowCellValue(i, "monto"));
                                    int FormaPagoOK = db.FormaPagoVenta_INSERTAR(vIdVenta, vIdFormaPago, vMonto);
                                    if (FormaPagoOK > 0) pagoOK++;
                                }

                                if (db.Terminos.Where(x => x.id == xIdTermino).FirstOrDefault().dias > 0)
                                {
                                    bool okCxC = db.DocumentosCuentasCobrar_Insert(6, xIdCliente, int.Parse(vNumero.Replace("V", "")), xFecha, vSumTotal, vSumSubTotal, vSumDescuento, vSumImpuesto, xIdEmpleado, "FACTURA DE CREDITO " + vNumero, xVendedor, 0.00M, false, xIdTermino, 1, vIdVenta).FirstOrDefault().HasValue;
                                    var movOK = db.MovimientoInventario_INSERT(vIdAjuste, xFecha, vNumero, xObservacion, xIdEmpleado, xPersonaReferencia, 2, vIdVenta).FirstOrDefault();
                                    int Ok1 = 0;
                                    for (int i = 0; i < view.RowCount; i++)
                                    {
                                        int vIdBodega = Convert.ToInt32(view.GetRowCellValue(i, "id_bodega"));
                                        int vIdProducto = Convert.ToInt32(view.GetRowCellValue(i, "id_producto"));
                                        int vid_lote = Convert.ToInt32(view.GetRowCellValue(i, "id_lote"));
                                        decimal vCantidad = Convert.ToDecimal(view.GetRowCellValue(i, "cantidad"));
                                        decimal vPrecio = Convert.ToDecimal(view.GetRowCellValue(i, "precio1"));
                                        decimal vDescuento = Convert.ToDecimal(view.GetRowCellValue(i, "descuento"));
                                        decimal vImpuesto = Convert.ToDecimal(view.GetRowCellValue(i, "impuesto"));
                                        decimal vTotal = Convert.ToDecimal(view.GetRowCellValue(i, "total"));
                                        string vUbicacion = Convert.ToString(view.GetRowCellValue(i, "ubicacion"));
                                        var VCosto = db.Producto.Where(D => D.id == vIdProducto).FirstOrDefault().costo;

                                        int detalleMovOK = db.MovimientoInventarioDetalle_INSERT(movOK.id, vIdBodega, vIdProducto, vCantidad, VCosto, vUbicacion, vid_lote);
                                        if (detalleMovOK > 0) Ok1++;
                                        else break;
                                    }
                                    if (okCxC && Ok == view.RowCount && pagoOK == viewPago.RowCount) vRetorno = true;
                                }
                                else
                                if (Ok == view.RowCount && ok_inventario == view.RowCount && pagoOK == viewPago.RowCount) vRetorno = true;
                            }
                            else
                            {
                                int Ok = 0;
                                for (int i = 0; i < view.RowCount; i++)
                                {
                                    int vIdBodega = Convert.ToInt32(view.GetRowCellValue(i, "id_bodega"));
                                    int vIdProducto = Convert.ToInt32(view.GetRowCellValue(i, "id_producto"));
                                    int vid_lote = Convert.ToInt32(view.GetRowCellValue(i, "id_lote"));
                                    decimal vCantidad = Convert.ToDecimal(view.GetRowCellValue(i, "cantidad"));
                                    decimal vPrecio = Convert.ToDecimal(view.GetRowCellValue(i, "precio1"));
                                    decimal vDescuento = Convert.ToDecimal(view.GetRowCellValue(i, "descuento"));
                                    decimal vImpuesto = Convert.ToDecimal(view.GetRowCellValue(i, "impuesto"));
                                    decimal vTotal = Convert.ToDecimal(view.GetRowCellValue(i, "total"));
                                    decimal vCosto = db.Producto.Where(x => x.id == vIdProducto).Select(x => x.costo).FirstOrDefault().Value;
                                    string vUbicacion = Convert.ToString(view.GetRowCellValue(i, "ubicacion"));
                                    string vdescripcion = Convert.ToString(view.GetRowCellValue(i, "descripcion"));
                                    int detalleOK = db.VentaDetalle_INSERTAR(vIdVenta, vIdBodega, vIdProducto, vCantidad, vPrecio, vDescuento, vImpuesto, vTotal, vid_lote, vUbicacion, vdescripcion);
                                    if (detalleOK > 0) Ok++;
                                    else break;
                                }

                                int pagoOK = 0;
                                for (int i = 0; i < viewPago.RowCount; i++)
                                {
                                    int vIdFormaPago = Convert.ToInt32(viewPago.GetRowCellValue(i, "id_forma_pago"));
                                    int vMonto = Convert.ToInt32(viewPago.GetRowCellValue(i, "monto"));
                                    int FormaPagoOK = db.FormaPagoVenta_INSERTAR(vIdVenta, vIdFormaPago, vMonto);
                                    if (FormaPagoOK > 0) pagoOK++;
                                }

                                if (Ok == view.RowCount && pagoOK == viewPago.RowCount) vRetorno = true;
                            }
                        }
                        if (vRetorno) { db.SaveChanges(); dbTrans.Commit(); }
                        else { dbTrans.Rollback(); }
                    }
                    catch (Exception ex)
                    {
                        dbTrans.Rollback();
                        XtraMessageBox.Show("Lo sentimos, ocurrio el siguiente error: " + ex.
                            GetBaseException().Message, "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        vRetorno = false;
                    }
                }
            }

            return Tuple.Create(vRetorno, vIdVenta, vNumero);
        }


        public Tuple<bool, int, string> Remision_Guardar(int xIdEmpleado, int xVendedor, int xNumero, int xIdCliente, DateTime xFecha, DateTime xFechaMaxima, decimal xTipoCambio, string xObservacion, int xTipo, int xIdTermino, string xPersonaReferencia, DevExpress.XtraGrid.Views.Grid.GridView view, DevExpress.XtraGrid.Views.Grid.GridView viewPago, string representante, int moneda, int persona_autoriza, int xPrecio, int vCambioPrecioCliente)
        {
            bool vRetorno = false;
            string vNumero = "";
            int vIdVenta = 0;
            using (var db = new Entities())
            {
                using (var dbTrans = db.Database.BeginTransaction())
                {
                    try
                    {
                        var ventaOK = db.Venta_GUARDAR(xIdEmpleado, xNumero, xIdCliente, xFecha, xFechaMaxima, xTipoCambio, xObservacion, xTipo, xIdTermino, xVendedor, representante, moneda, persona_autoriza, xPrecio, vCambioPrecioCliente,0.00M,0.00M).FirstOrDefault();
                        if (ventaOK != null)
                        {
                            vIdVenta = ventaOK.id;
                            vNumero = ventaOK.numero;

                            int Ok = 0;
                            for (int i = 0; i < view.RowCount; i++)
                            {
                                int vIdBodega = Convert.ToInt32(view.GetRowCellValue(i, "id_bodega"));
                                int vIdProducto = Convert.ToInt32(view.GetRowCellValue(i, "id_producto"));
                                int vid_lote = Convert.ToInt32(view.GetRowCellValue(i, "id_lote"));
                                decimal vCantidad = Convert.ToDecimal(view.GetRowCellValue(i, "cantidad"));
                                decimal vPrecio = Convert.ToDecimal(view.GetRowCellValue(i, "precio1"));
                                decimal vDescuento = Convert.ToDecimal(view.GetRowCellValue(i, "descuento"));
                                decimal vImpuesto = Convert.ToDecimal(view.GetRowCellValue(i, "impuesto"));
                                decimal vTotal = Convert.ToDecimal(view.GetRowCellValue(i, "total"));
                                decimal vCosto = db.Producto.Where(x => x.id == vIdProducto).Select(x => x.costo).FirstOrDefault().Value;
                                string vUbicacion = Convert.ToString(view.GetRowCellValue(i, "ubicacion"));
                                string vdescripcion = Convert.ToString(view.GetRowCellValue(i, "descripcion"));
                                int detalleOK = db.VentaDetalle_INSERTAR(vIdVenta, vIdBodega, vIdProducto, vCantidad, vPrecio, vDescuento, vImpuesto, vTotal, vid_lote, vUbicacion, vdescripcion);
                                int remisionOK = db.Kardex_INSERT_Comprometidos(vIdProducto, vIdBodega, vUbicacion, vCantidad, vid_lote);
                                if (detalleOK > 0 && remisionOK > 0) Ok++;
                                else break;
                            }

                            if (Ok == view.RowCount) vRetorno = true;
                        }
                        if (vRetorno) { db.SaveChanges(); dbTrans.Commit(); }
                        else { dbTrans.Rollback(); }
                    }
                    catch (Exception ex)
                    {
                        dbTrans.Rollback();
                        XtraMessageBox.Show("Lo sentimos, ocurrio el siguiente error: " + ex.
                            GetBaseException().Message, "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        vRetorno = false;
                    }
                }
            }

            return Tuple.Create(vRetorno, vIdVenta, vNumero);
        }

        public Tuple<bool, int, string> Prestamo_Guardar(int xIdEmpleado, int xVendedor, int xNumero, int xIdCliente, DateTime xFecha, DateTime xFechaMaxima, decimal xTipoCambio, string xObservacion, int xTipo, int xIdTermino, string xPersonaReferencia, DevExpress.XtraGrid.Views.Grid.GridView view, DevExpress.XtraGrid.Views.Grid.GridView viewPago, string representante, int moneda, int persona_autoriza, int xPrecio, int vCambioPrecioCliente)
        {
            bool vRetorno = false;
            string vNumero = "";
            int vIdVenta = 0;
            using (var db = new Entities())
            {
                using (var dbTrans = db.Database.BeginTransaction())
                {
                    try
                    {
                        var ventaOK = db.Prestamos_GUARDAR(xIdEmpleado, xNumero, xIdCliente, xFecha, xFecha.AddDays(5), xFecha.AddDays(10), xTipoCambio, xObservacion, xTipo, xIdTermino, xVendedor, representante, moneda, persona_autoriza, xPrecio, vCambioPrecioCliente, 0.00M, 0.00M).FirstOrDefault();
                        if (ventaOK != null)
                        {
                            vIdVenta = ventaOK.id;
                            vNumero = ventaOK.numero;

                            int Ok = 0;
                            for (int i = 0; i < view.RowCount; i++)
                            {
                                int vIdBodega = Convert.ToInt32(view.GetRowCellValue(i, "id_bodega"));
                                int vIdProducto = Convert.ToInt32(view.GetRowCellValue(i, "id_producto"));
                                int vid_lote = Convert.ToInt32(view.GetRowCellValue(i, "id_lote"));
                                decimal vCantidad = Convert.ToDecimal(view.GetRowCellValue(i, "cantidad"));
                                decimal vPrecio = Convert.ToDecimal(view.GetRowCellValue(i, "precio1"));
                                decimal vDescuento = Convert.ToDecimal(view.GetRowCellValue(i, "descuento"));
                                decimal vImpuesto = Convert.ToDecimal(view.GetRowCellValue(i, "impuesto"));
                                decimal vTotal = Convert.ToDecimal(view.GetRowCellValue(i, "total"));
                                decimal vCosto = db.Producto.Where(x => x.id == vIdProducto).Select(x => x.costo).FirstOrDefault().Value;
                                string vUbicacion = Convert.ToString(view.GetRowCellValue(i, "ubicacion"));
                                string vdescripcion = Convert.ToString(view.GetRowCellValue(i, "descripcion"));
                                int detalleOK = db.PrestamosDetalle_INSERTAR(vIdVenta, vIdBodega, vIdProducto, vCantidad, vPrecio, vDescuento, vImpuesto, vTotal, vid_lote, vUbicacion, vdescripcion);
                                int remisionOK = db.Kardex_INSERT_Prestamos(vIdProducto, vIdBodega, vUbicacion, vCantidad, vid_lote);
                                if (detalleOK > 0 && remisionOK > 0) Ok++;
                                else break;
                            }

                            if (Ok == view.RowCount) vRetorno = true;
                        }
                        if (vRetorno) { db.SaveChanges(); dbTrans.Commit(); }
                        else { dbTrans.Rollback(); }
                    }
                    catch (Exception ex)
                    {
                        dbTrans.Rollback();
                        XtraMessageBox.Show("Lo sentimos, ocurrio el siguiente error: " + ex.
                            GetBaseException().Message, "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        vRetorno = false;
                    }
                }
            }

            return Tuple.Create(vRetorno, vIdVenta, vNumero);
        }
        public Tuple<bool, int> Cotizacion_Actualizar(int id_cotizacion, int xIdEmpleado, int xVendedor, int xIdCliente, DateTime xFecha, DateTime xFechaMaxima, decimal xTipoCambio, string xObservacion, string xPersonaReferencia, DevExpress.XtraGrid.Views.Grid.GridView view, string representante, int moneda, int persona_autoriza, int xPrecio, int vCambioPrecioCliente)
        {
            bool vRetorno = false;
            using (var db = new Entities())
            {
                using (var dbTrans = db.Database.BeginTransaction())
                {
                    try
                    {
                        int Ok = 0;
                        Venta v = db.Venta.Find(id_cotizacion);
                        v.id_empleado = xIdEmpleado;
                        v.id_cliente = xIdCliente;
                        v.fecha = xFecha;
                        v.fecha_maxima = xFechaMaxima;
                        v.tipo_cambio = xTipoCambio;
                        v.observacion = xObservacion;
                        v.vendedor = xVendedor;
                        v.nombre_representante = representante;
                        v.moneda = moneda;
                        v.id_empleado_autoriza = persona_autoriza;
                        v.tipo_precio = xPrecio;
                        v.Cambio_Precio_Cliente = vCambioPrecioCliente;
                        db.SaveChanges();

                        foreach (var x in db.VentaDetalle.Where(o => o.id_venta == id_cotizacion && o.activo == true).ToList())
                        {
                            x.activo = false;
                            db.SaveChanges();
                        }




                        decimal vSumTotal = 0.00M, vSumImpuesto = 0.00M, vSumDescuento = 0.00M, vSumSubTotal = 0.00M;
                        for (int i = 0; i < view.RowCount; i++)
                        {
                            int vIdBodega = Convert.ToInt32(view.GetRowCellValue(i, "id_bodega"));
                            int vIdProducto = Convert.ToInt32(view.GetRowCellValue(i, "id_producto"));
                            int vid_lote = Convert.ToInt32(view.GetRowCellValue(i, "id_lote"));
                            decimal vCantidad = Convert.ToDecimal(view.GetRowCellValue(i, "cantidad"));
                            decimal vPrecio = Convert.ToDecimal(view.GetRowCellValue(i, "precio1"));
                            decimal vDescuento = Convert.ToDecimal(view.GetRowCellValue(i, "descuento"));
                            decimal vImpuesto = Convert.ToDecimal(view.GetRowCellValue(i, "impuesto"));
                            decimal vTotal = Convert.ToDecimal(view.GetRowCellValue(i, "total"));
                            string vUbicacion = Convert.ToString(view.GetRowCellValue(i, "ubicacion"));
                            string vdescripcion = Convert.ToString(view.GetRowCellValue(i, "descripcion"));

                            vSumTotal += vTotal;
                            vSumSubTotal += (vCantidad * vPrecio);
                            vSumDescuento += ((vCantidad * vPrecio) * (vDescuento / 100));
                            vSumImpuesto += ((vCantidad * vPrecio) * (1 - (vDescuento / 100))) * (vImpuesto / 100);

                            int detalleOK = db.VentaDetalle_INSERTAR(id_cotizacion, vIdBodega, vIdProducto, vCantidad, vPrecio, vDescuento, vImpuesto, vTotal, vid_lote, vUbicacion, vdescripcion);

                            if (detalleOK > 0) Ok++;
                            else break;
                        }
                        if (Ok == view.RowCount) vRetorno = true;
                        if (vRetorno) { db.SaveChanges(); dbTrans.Commit(); }
                        else { dbTrans.Rollback(); }
                    }
                    catch (Exception ex)
                    {
                        dbTrans.Rollback();
                        XtraMessageBox.Show("Lo sentimos, ocurrio el siguiente error: " + ex.
                            GetBaseException().Message, "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        vRetorno = false;
                    }
                }
            }

            return Tuple.Create(vRetorno, id_cotizacion);
        }

        public Tuple<bool, int> Remision_Actualizar(int id_cotizacion, int xIdEmpleado, int xVendedor, int xIdCliente, DateTime xFecha, DateTime xFechaMaxima, decimal xTipoCambio, string xObservacion, string xPersonaReferencia, DevExpress.XtraGrid.Views.Grid.GridView view, string representante, int moneda, int persona_autoriza, int xPrecio, int vCambioPrecioCliente)
        {
            bool vRetorno = false;
            using (var db = new Entities())
            {
                using (var dbTrans = db.Database.BeginTransaction())
                {
                    try
                    {
                        int Ok = 0;
                        int OkAct = 0;
                        Venta v = db.Venta.Find(id_cotizacion);
                        v.id_empleado = xIdEmpleado;
                        v.id_cliente = xIdCliente;
                        v.fecha = xFecha;
                        v.fecha_maxima = xFechaMaxima;
                        v.tipo_cambio = xTipoCambio;
                        v.observacion = xObservacion;
                        v.vendedor = xVendedor;
                        v.nombre_representante = representante;
                        v.moneda = moneda;
                        v.id_empleado_autoriza = persona_autoriza;
                        v.tipo_precio = xPrecio;
                        v.Cambio_Precio_Cliente = vCambioPrecioCliente;
                        v.retencion_1 = 0.00M;
                        v.retencion_2 = 0.00M;
                        db.SaveChanges();

                        decimal vSumTotal = 0.00M, vSumImpuesto = 0.00M, vSumDescuento = 0.00M, vSumSubTotal = 0.00M;
                        for (int i = 0; i < view.RowCount; i++)
                        {
                            int vIdBodega = Convert.ToInt32(view.GetRowCellValue(i, "id_bodega"));
                            int vIdProducto = Convert.ToInt32(view.GetRowCellValue(i, "id_producto"));
                            int vid_lote = Convert.ToInt32(view.GetRowCellValue(i, "id_lote"));
                            decimal vCantidad = Convert.ToDecimal(view.GetRowCellValue(i, "cantidad"));
                            decimal vPrecio = Convert.ToDecimal(view.GetRowCellValue(i, "precio1"));
                            decimal vDescuento = Convert.ToDecimal(view.GetRowCellValue(i, "descuento"));
                            decimal vImpuesto = Convert.ToDecimal(view.GetRowCellValue(i, "impuesto"));
                            decimal vTotal = Convert.ToDecimal(view.GetRowCellValue(i, "total"));
                            string vUbicacion = Convert.ToString(view.GetRowCellValue(i, "ubicacion"));
                            string vdescripcion = Convert.ToString(view.GetRowCellValue(i, "descripcion"));

                            vSumTotal += vTotal;
                            vSumSubTotal += (vCantidad * vPrecio);
                            vSumDescuento += ((vCantidad * vPrecio) * (vDescuento / 100));
                            vSumImpuesto += ((vCantidad * vPrecio) * (1 - (vDescuento / 100))) * (vImpuesto / 100);

                            int actualiarComprometidos = db.Kardex_ACTUALIZAR_Comprometidos(vIdProducto, vIdBodega, vUbicacion, vCantidad, id_cotizacion, vid_lote);
                            if (actualiarComprometidos > 0) OkAct++;
                            else break;
                        }

                        foreach (var x in db.VentaDetalle.Where(o => o.id_venta == id_cotizacion && o.activo == true).ToList())
                        {
                            x.activo = false;
                            db.SaveChanges();
                        }

                        vSumTotal = 0.00M; vSumImpuesto = 0.00M; vSumDescuento = 0.00M; vSumSubTotal = 0.00M;
                        for (int i = 0; i < view.RowCount; i++)
                        {
                            int vIdBodega = Convert.ToInt32(view.GetRowCellValue(i, "id_bodega"));
                            int vIdProducto = Convert.ToInt32(view.GetRowCellValue(i, "id_producto"));
                            int vid_lote = Convert.ToInt32(view.GetRowCellValue(i, "id_lote"));
                            decimal vCantidad = Convert.ToDecimal(view.GetRowCellValue(i, "cantidad"));
                            decimal vPrecio = Convert.ToDecimal(view.GetRowCellValue(i, "precio1"));
                            decimal vDescuento = Convert.ToDecimal(view.GetRowCellValue(i, "descuento"));
                            decimal vImpuesto = Convert.ToDecimal(view.GetRowCellValue(i, "impuesto"));
                            decimal vTotal = Convert.ToDecimal(view.GetRowCellValue(i, "total"));
                            string vUbicacion = Convert.ToString(view.GetRowCellValue(i, "ubicacion"));
                            string vdescripcion = Convert.ToString(view.GetRowCellValue(i, "descripcion"));

                            vSumTotal += vTotal;
                            vSumSubTotal += (vCantidad * vPrecio);
                            vSumDescuento += ((vCantidad * vPrecio) * (vDescuento / 100));
                            vSumImpuesto += ((vCantidad * vPrecio) * (1 - (vDescuento / 100))) * (vImpuesto / 100);

                            int detalleOK = db.VentaDetalle_INSERTAR(id_cotizacion, vIdBodega, vIdProducto, vCantidad, vPrecio, vDescuento, vImpuesto, vTotal, vid_lote, vUbicacion, vdescripcion);

                            if (detalleOK > 0) Ok++;
                            else break;
                        }
                        if (Ok == view.RowCount) vRetorno = true;
                        if (vRetorno) { db.SaveChanges(); dbTrans.Commit(); }
                        else { dbTrans.Rollback(); }
                    }
                    catch (Exception ex)
                    {
                        dbTrans.Rollback();
                        XtraMessageBox.Show("Lo sentimos, ocurrio el siguiente error: " + ex.
                            GetBaseException().Message, "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        vRetorno = false;
                    }
                }
            }

            return Tuple.Create(vRetorno, id_cotizacion);
        }

        public Tuple<bool, int> Prestamo_Actualizar(int id_cotizacion, int xIdEmpleado, int xVendedor, int xIdCliente, DateTime xFecha, DateTime xFechaMaxima, decimal xTipoCambio, string xObservacion, string xPersonaReferencia, DevExpress.XtraGrid.Views.Grid.GridView view, string representante, int moneda, int persona_autoriza, int xPrecio, int vCambioPrecioCliente)
        {
            bool vRetorno = false;
            using (var db = new Entities())
            {
                using (var dbTrans = db.Database.BeginTransaction())
                {
                    try
                    {
                        int Ok = 0;
                        int OkAct = 0;
                        Prestamos v = db.Prestamos.Find(id_cotizacion);
                        v.id_empleado = xIdEmpleado;
                        v.id_cliente = xIdCliente;
                        v.fecha = xFecha;
                        v.fecha_estimada = xFecha.AddDays(5);
                        v.fecha_maxima = xFecha.AddDays(10);
                        v.tipo_cambio = xTipoCambio;
                        v.observacion = xObservacion;
                        v.vendedor = xVendedor;
                        v.nombre_representante = representante;
                        v.moneda = moneda;
                        v.id_empleado_autoriza = persona_autoriza;
                        v.tipo_precio = xPrecio;
                        v.Cambio_Precio_Cliente = vCambioPrecioCliente;
                        v.retencion_1 = 0.00M;
                        v.retencion_2 = 0.00M;
                        db.SaveChanges();

                        decimal vSumTotal = 0.00M, vSumImpuesto = 0.00M, vSumDescuento = 0.00M, vSumSubTotal = 0.00M;
                        for (int i = 0; i < view.RowCount; i++)
                        {
                            int vIdBodega = Convert.ToInt32(view.GetRowCellValue(i, "id_bodega"));
                            int vIdProducto = Convert.ToInt32(view.GetRowCellValue(i, "id_producto"));
                            int vid_lote = Convert.ToInt32(view.GetRowCellValue(i, "id_lote"));
                            decimal vCantidad = Convert.ToDecimal(view.GetRowCellValue(i, "cantidad"));
                            decimal vPrecio = Convert.ToDecimal(view.GetRowCellValue(i, "precio1"));
                            decimal vDescuento = Convert.ToDecimal(view.GetRowCellValue(i, "descuento"));
                            decimal vImpuesto = Convert.ToDecimal(view.GetRowCellValue(i, "impuesto"));
                            decimal vTotal = Convert.ToDecimal(view.GetRowCellValue(i, "total"));
                            string vUbicacion = Convert.ToString(view.GetRowCellValue(i, "ubicacion"));
                            string vdescripcion = Convert.ToString(view.GetRowCellValue(i, "descripcion"));

                            vSumTotal += vTotal;
                            vSumSubTotal += (vCantidad * vPrecio);
                            vSumDescuento += ((vCantidad * vPrecio) * (vDescuento / 100));
                            vSumImpuesto += ((vCantidad * vPrecio) * (1 - (vDescuento / 100))) * (vImpuesto / 100);

                            int actualiarComprometidos = db.Kardex_ACTUALIZAR_Prestamos(vIdProducto, vIdBodega, vUbicacion, vCantidad, id_cotizacion, vid_lote);
                            if (actualiarComprometidos > 0) OkAct++;
                            else break;
                        }

                        foreach (var x in db.Prestamos_Detalle.Where(o => o.id_venta == id_cotizacion && o.activo == true).ToList())
                        {
                            x.activo = false;
                            db.SaveChanges();
                        }

                        vSumTotal = 0.00M; vSumImpuesto = 0.00M; vSumDescuento = 0.00M; vSumSubTotal = 0.00M;
                        for (int i = 0; i < view.RowCount; i++)
                        {
                            int vIdBodega = Convert.ToInt32(view.GetRowCellValue(i, "id_bodega"));
                            int vIdProducto = Convert.ToInt32(view.GetRowCellValue(i, "id_producto"));
                            int vid_lote = Convert.ToInt32(view.GetRowCellValue(i, "id_lote"));
                            decimal vCantidad = Convert.ToDecimal(view.GetRowCellValue(i, "cantidad"));
                            decimal vPrecio = Convert.ToDecimal(view.GetRowCellValue(i, "precio1"));
                            decimal vDescuento = Convert.ToDecimal(view.GetRowCellValue(i, "descuento"));
                            decimal vImpuesto = Convert.ToDecimal(view.GetRowCellValue(i, "impuesto"));
                            decimal vTotal = Convert.ToDecimal(view.GetRowCellValue(i, "total"));
                            string vUbicacion = Convert.ToString(view.GetRowCellValue(i, "ubicacion"));
                            string vdescripcion = Convert.ToString(view.GetRowCellValue(i, "descripcion"));

                            vSumTotal += vTotal;
                            vSumSubTotal += (vCantidad * vPrecio);
                            vSumDescuento += ((vCantidad * vPrecio) * (vDescuento / 100));
                            vSumImpuesto += ((vCantidad * vPrecio) * (1 - (vDescuento / 100))) * (vImpuesto / 100);

                            int detalleOK = db.PrestamosDetalle_INSERTAR(id_cotizacion, vIdBodega, vIdProducto, vCantidad, vPrecio, vDescuento, vImpuesto, vTotal, vid_lote, vUbicacion, vdescripcion);

                            if (detalleOK > 0) Ok++;
                            else break;
                        }
                        if (Ok == view.RowCount) vRetorno = true;
                        if (vRetorno) { db.SaveChanges(); dbTrans.Commit(); }
                        else { dbTrans.Rollback(); }
                    }
                    catch (Exception ex)
                    {
                        dbTrans.Rollback();
                        XtraMessageBox.Show("Lo sentimos, ocurrio el siguiente error: " + ex.
                            GetBaseException().Message, "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        vRetorno = false;
                    }
                }
            }

            return Tuple.Create(vRetorno, id_cotizacion);
        }

        public Tuple<bool, int, string> Venta_GuardarRemision(int xIdEmpleado, int xVendedor, int xNumero, int xIdCliente, DateTime xFecha, DateTime xFechaMaxima, decimal xTipoCambio, string xObservacion, int xTipo, int xIdTermino, string xPersonaReferencia, DevExpress.XtraGrid.Views.Grid.GridView view, DevExpress.XtraGrid.Views.Grid.GridView viewPago, string representante, int moneda, int persona_autoriza, int xPrecio, int vCambioPrecioCliente, decimal retencion1, decimal retencion2)
        {
            bool vRetorno = false;
            string vNumero = "";
            int vIdVenta = 0;
            using (var db = new Entities())
            {
                using (var dbTrans = db.Database.BeginTransaction())
                {
                    try
                    {
                        var ventaOK = db.Venta_GUARDAR(xIdEmpleado, xNumero, xIdCliente, xFecha, xFechaMaxima, xTipoCambio, xObservacion, xTipo, xIdTermino, xVendedor, representante, moneda, persona_autoriza, xPrecio, vCambioPrecioCliente,retencion1,retencion2).FirstOrDefault();
                        if (ventaOK != null)
                        {
                            vIdVenta = ventaOK.id;
                            vNumero = ventaOK.numero;


                            if (xTipo > 0)
                            {
                                int Ok = 0;
                                int ok_inventario = 0;
                                decimal vSumTotal = 0.00M, vSumImpuesto = 0.00M, vSumDescuento = 0.00M, vSumSubTotal = 0.00M;
                                for (int i = 0; i < view.RowCount; i++)
                                {
                                    int vIdBodega = Convert.ToInt32(view.GetRowCellValue(i, "id_bodega"));
                                    int vIdProducto = Convert.ToInt32(view.GetRowCellValue(i, "id_producto"));
                                    int vid_lote = Convert.ToInt32(view.GetRowCellValue(i, "id_lote"));
                                    decimal vCantidad = Convert.ToDecimal(view.GetRowCellValue(i, "cantidad"));
                                    decimal vPrecio = Convert.ToDecimal(view.GetRowCellValue(i, "precio1"));
                                    decimal vDescuento = Convert.ToDecimal(view.GetRowCellValue(i, "descuento"));
                                    decimal vImpuesto = Convert.ToDecimal(view.GetRowCellValue(i, "impuesto"));
                                    decimal vTotal = Convert.ToDecimal(view.GetRowCellValue(i, "total"));
                                    string vUbicacion = Convert.ToString(view.GetRowCellValue(i, "ubicacion"));
                                    string vdescripcion = Convert.ToString(view.GetRowCellValue(i, "descripcion"));

                                    vSumTotal += vTotal;
                                    vSumSubTotal += (vCantidad * vPrecio);
                                    vSumDescuento += ((vCantidad * vPrecio) * (vDescuento / 100));
                                    vSumImpuesto += ((vCantidad * vPrecio) * (1 - (vDescuento / 100))) * (vImpuesto / 100);

                                    int detalleOK = db.VentaDetalle_INSERTAR(vIdVenta, vIdBodega, vIdProducto, vCantidad, vPrecio, vDescuento, vImpuesto, vTotal, vid_lote, vUbicacion, vdescripcion);

                                    if (detalleOK > 0) Ok++;
                                    else break;
                                }

                                var query_venta = db.Venta.Where(o => o.id == vIdVenta).FirstOrDefault();
                                var nombre_cliente = db.Cliente.Where(o => o.id == query_venta.id_cliente).FirstOrDefault();
                                var id_tipo = db.TiposDocumentosCx.Where(o => o.numero_documento == 6).FirstOrDefault();
                                var id_tipo_dolares = db.TiposDocumentosCx.Where(o => o.numero_documento == 8).FirstOrDefault();
                                int vIdAjuste = db.AjustesModulos.Where(x => x.activo == true && x.tipo == 2).FirstOrDefault().id_ajuste;

                                if (db.Terminos.Where(x => x.id == xIdTermino).FirstOrDefault().dias == 0)
                                {
                                    var movOK = db.MovimientoInventario_INSERT(vIdAjuste, query_venta.fecha, query_venta.numero, query_venta.observacion, query_venta.vendedor, nombre_cliente.nombre, 2, vIdVenta).FirstOrDefault();
                                    for (int i = 0; i < view.RowCount; i++)
                                    {
                                        int vIdBodega = Convert.ToInt32(view.GetRowCellValue(i, "id_bodega"));
                                        int vIdProducto = Convert.ToInt32(view.GetRowCellValue(i, "id_producto"));
                                        int Vid_Lote = Convert.ToInt32(view.GetRowCellValue(i, "id_lote"));
                                        decimal vCantidad = Convert.ToDecimal(view.GetRowCellValue(i, "cantidad"));
                                        decimal vPrecio = Convert.ToDecimal(view.GetRowCellValue(i, "precio1"));
                                        decimal vDescuento = Convert.ToDecimal(view.GetRowCellValue(i, "descuento"));
                                        decimal vImpuesto = Convert.ToDecimal(view.GetRowCellValue(i, "impuesto"));
                                        decimal vTotal = Convert.ToDecimal(view.GetRowCellValue(i, "total"));
                                        decimal vCosto = db.Producto.Where(x => x.id == vIdProducto).Select(x => x.costo).FirstOrDefault().Value;
                                        string vUbicacion = Convert.ToString(view.GetRowCellValue(i, "ubicacion"));
                                        //(db.Kardex.Where(x => x.id_producto == vIdProducto && x.id_bodega == vIdBodega && x.id_lote==Vid_Lote).Select(x => x.ubicacion).FirstOrDefault() != null) ? db.Kardex.Where(x => x.id_producto == vIdProducto && x.id_bodega == vIdBodega).Select(x => x.ubicacion).FirstOrDefault() : "";

                                        int detalleComprometidosActualizarOk = db.Kardex_Actualizar_Comprometidos_DF(vIdBodega, vIdProducto, Vid_Lote, vCantidad, vUbicacion);
                                        int detalleMovOK = db.MovimientoInventarioDetalle_INSERT(movOK.id, vIdBodega, vIdProducto, vCantidad, vCosto, vUbicacion, Vid_Lote);
                                        if (detalleMovOK > 0 && detalleComprometidosActualizarOk > 0) ok_inventario++;
                                        else break;
                                    }
                                    //if(Ok == view.RowCount && pagoOK == viewPago.RowCount)
                                    //    vRetorno = id_mov_caja;
                                    //else
                                    //    vRetorno = 0;
                                }

                                int pagoOK = 0;
                                for (int i = 0; i < viewPago.RowCount; i++)
                                {
                                    int vIdFormaPago = Convert.ToInt32(viewPago.GetRowCellValue(i, "id_forma_pago"));
                                    decimal vMonto = Convert.ToDecimal(viewPago.GetRowCellValue(i, "monto"));
                                    int FormaPagoOK = db.FormaPagoVenta_INSERTAR(vIdVenta, vIdFormaPago, vMonto);
                                    if (FormaPagoOK > 0) pagoOK++;
                                }

                                if (db.Terminos.Where(x => x.id == xIdTermino).FirstOrDefault().dias > 0)
                                {
                                    bool okCxC = db.DocumentosCuentasCobrar_Insert(6, xIdCliente, int.Parse(vNumero.Replace("V", "")), xFecha, vSumTotal, vSumSubTotal, vSumDescuento, vSumImpuesto, xIdEmpleado, "FACTURA DE CREDITO " + vNumero, xVendedor, 0.00M, false, xIdTermino, 1, vIdVenta).FirstOrDefault().HasValue;
                                    var movOK = db.MovimientoInventario_INSERT(vIdAjuste, xFecha, vNumero, xObservacion, xIdEmpleado, xPersonaReferencia, 2, vIdVenta).FirstOrDefault();
                                    int Ok1 = 0;
                                    for (int i = 0; i < view.RowCount; i++)
                                    {
                                        int vIdBodega = Convert.ToInt32(view.GetRowCellValue(i, "id_bodega"));
                                        int vIdProducto = Convert.ToInt32(view.GetRowCellValue(i, "id_producto"));
                                        int vid_lote = Convert.ToInt32(view.GetRowCellValue(i, "id_lote"));
                                        decimal vCantidad = Convert.ToDecimal(view.GetRowCellValue(i, "cantidad"));
                                        decimal vPrecio = Convert.ToDecimal(view.GetRowCellValue(i, "precio1"));
                                        decimal vDescuento = Convert.ToDecimal(view.GetRowCellValue(i, "descuento"));
                                        decimal vImpuesto = Convert.ToDecimal(view.GetRowCellValue(i, "impuesto"));
                                        decimal vTotal = Convert.ToDecimal(view.GetRowCellValue(i, "total"));
                                        string vUbicacion = Convert.ToString(view.GetRowCellValue(i, "ubicacion"));
                                        var VCosto = db.Producto.Where(D => D.id == vIdProducto).FirstOrDefault().costo;

                                        int detalleComprometidosActualizarOk = db.Kardex_Actualizar_Comprometidos_DF(vIdBodega, vIdProducto, vid_lote, vCantidad, vUbicacion);
                                        int detalleMovOK = db.MovimientoInventarioDetalle_INSERT(movOK.id, vIdBodega, vIdProducto, vCantidad, VCosto, vUbicacion, vid_lote);
                                        if (detalleMovOK > 0 && detalleComprometidosActualizarOk > 0) Ok1++;
                                        else break;
                                    }
                                    if (okCxC && Ok == view.RowCount && pagoOK == viewPago.RowCount) vRetorno = true;
                                }
                                else

                                if (Ok == view.RowCount && ok_inventario == view.RowCount && pagoOK == viewPago.RowCount) vRetorno = true;
                            }
                            else
                            {
                                int Ok = 0;
                                for (int i = 0; i < view.RowCount; i++)
                                {
                                    int vIdBodega = Convert.ToInt32(view.GetRowCellValue(i, "id_bodega"));
                                    int vIdProducto = Convert.ToInt32(view.GetRowCellValue(i, "id_producto"));
                                    int vid_lote = Convert.ToInt32(view.GetRowCellValue(i, "id_lote"));
                                    decimal vCantidad = Convert.ToDecimal(view.GetRowCellValue(i, "cantidad"));
                                    decimal vPrecio = Convert.ToDecimal(view.GetRowCellValue(i, "precio1"));
                                    decimal vDescuento = Convert.ToDecimal(view.GetRowCellValue(i, "descuento"));
                                    decimal vImpuesto = Convert.ToDecimal(view.GetRowCellValue(i, "impuesto"));
                                    decimal vTotal = Convert.ToDecimal(view.GetRowCellValue(i, "total"));
                                    decimal vCosto = db.Producto.Where(x => x.id == vIdProducto).Select(x => x.costo).FirstOrDefault().Value;
                                    string vUbicacion = Convert.ToString(view.GetRowCellValue(i, "ubicacion"));
                                    string vdescripcion = Convert.ToString(view.GetRowCellValue(i, "descripcion"));
                                    int detalleOK = db.VentaDetalle_INSERTAR(vIdVenta, vIdBodega, vIdProducto, vCantidad, vPrecio, vDescuento, vImpuesto, vTotal, vid_lote, vUbicacion, vdescripcion);
                                    if (detalleOK > 0) Ok++;
                                    else break;
                                }

                                int pagoOK = 0;
                                for (int i = 0; i < viewPago.RowCount; i++)
                                {
                                    int vIdFormaPago = Convert.ToInt32(viewPago.GetRowCellValue(i, "id_forma_pago"));
                                    int vMonto = Convert.ToInt32(viewPago.GetRowCellValue(i, "monto"));
                                    int FormaPagoOK = db.FormaPagoVenta_INSERTAR(vIdVenta, vIdFormaPago, vMonto);
                                    if (FormaPagoOK > 0) pagoOK++;
                                }

                                if (Ok == view.RowCount && pagoOK == viewPago.RowCount) vRetorno = true;
                            }
                        }
                        if (vRetorno) { db.SaveChanges(); dbTrans.Commit(); }
                        else { dbTrans.Rollback(); }
                    }
                    catch (Exception ex)
                    {
                        dbTrans.Rollback();
                        XtraMessageBox.Show("Lo sentimos, ocurrio el siguiente error: " + ex.
                            GetBaseException().Message, "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        vRetorno = false;
                    }
                }
            }

            return Tuple.Create(vRetorno, vIdVenta, vNumero);
        }

        public Tuple<bool, int, string> Venta_GuardarPrestamo(int xIdEmpleado, int xVendedor, int xNumero, int xIdCliente, DateTime xFecha, DateTime xFechaMaxima, decimal xTipoCambio, string xObservacion, int xTipo, int xIdTermino, string xPersonaReferencia, DevExpress.XtraGrid.Views.Grid.GridView view, DevExpress.XtraGrid.Views.Grid.GridView viewPago, string representante, int moneda, int persona_autoriza, int xPrecio, int vCambioPrecioCliente, decimal retencion1, decimal retencion2)
        {
            bool vRetorno = false;
            string vNumero = "";
            int vIdVenta = 0;
            using (var db = new Entities())
            {
                using (var dbTrans = db.Database.BeginTransaction())
                {
                    try
                    {
                        var ventaOK = db.Venta_GUARDAR(xIdEmpleado, xNumero, xIdCliente, xFecha, xFechaMaxima, xTipoCambio, xObservacion, xTipo, xIdTermino, xVendedor, representante, moneda, persona_autoriza, xPrecio, vCambioPrecioCliente, retencion1, retencion2).FirstOrDefault();
                        if (ventaOK != null)
                        {
                            vIdVenta = ventaOK.id;
                            vNumero = ventaOK.numero;
                            if (xTipo > 0)
                            {
                                int Ok = 0;
                                int ok_inventario = 0;
                                decimal vSumTotal = 0.00M, vSumImpuesto = 0.00M, vSumDescuento = 0.00M, vSumSubTotal = 0.00M;
                                for (int i = 0; i < view.RowCount; i++)
                                {
                                    int vIdBodega = Convert.ToInt32(view.GetRowCellValue(i, "id_bodega"));
                                    int vIdProducto = Convert.ToInt32(view.GetRowCellValue(i, "id_producto"));
                                    int vid_lote = Convert.ToInt32(view.GetRowCellValue(i, "id_lote"));
                                    decimal vCantidad = Convert.ToDecimal(view.GetRowCellValue(i, "cantidad"));
                                    decimal vPrecio = Convert.ToDecimal(view.GetRowCellValue(i, "precio1"));
                                    decimal vDescuento = Convert.ToDecimal(view.GetRowCellValue(i, "descuento"));
                                    decimal vImpuesto = Convert.ToDecimal(view.GetRowCellValue(i, "impuesto"));
                                    decimal vTotal = Convert.ToDecimal(view.GetRowCellValue(i, "total"));
                                    string vUbicacion = Convert.ToString(view.GetRowCellValue(i, "ubicacion"));
                                    string vdescripcion = Convert.ToString(view.GetRowCellValue(i, "descripcion"));

                                    vSumTotal += vTotal;
                                    vSumSubTotal += (vCantidad * vPrecio);
                                    vSumDescuento += ((vCantidad * vPrecio) * (vDescuento / 100));
                                    vSumImpuesto += ((vCantidad * vPrecio) * (1 - (vDescuento / 100))) * (vImpuesto / 100);

                                    int detalleOK = db.VentaDetalle_INSERTAR(vIdVenta, vIdBodega, vIdProducto, vCantidad, vPrecio, vDescuento, vImpuesto, vTotal, vid_lote, vUbicacion, vdescripcion);

                                    if (detalleOK > 0) Ok++;
                                    else break;
                                }

                                var query_venta = db.Venta.Where(o => o.id == vIdVenta).FirstOrDefault();
                                var nombre_cliente = db.Cliente.Where(o => o.id == query_venta.id_cliente).FirstOrDefault();
                                var id_tipo = db.TiposDocumentosCx.Where(o => o.numero_documento == 6).FirstOrDefault();
                                var id_tipo_dolares = db.TiposDocumentosCx.Where(o => o.numero_documento == 8).FirstOrDefault();
                                int vIdAjuste = db.AjustesModulos.Where(x => x.activo == true && x.tipo == 2).FirstOrDefault().id_ajuste;

                                if (db.Terminos.Where(x => x.id == xIdTermino).FirstOrDefault().dias == 0)
                                {
                                    var movOK = db.MovimientoInventario_INSERT(vIdAjuste, query_venta.fecha, query_venta.numero, query_venta.observacion, query_venta.vendedor, nombre_cliente.nombre, 2, vIdVenta).FirstOrDefault();
                                    for (int i = 0; i < view.RowCount; i++)
                                    {
                                        int vIdBodega = Convert.ToInt32(view.GetRowCellValue(i, "id_bodega"));
                                        int vIdProducto = Convert.ToInt32(view.GetRowCellValue(i, "id_producto"));
                                        int Vid_Lote = Convert.ToInt32(view.GetRowCellValue(i, "id_lote"));
                                        decimal vCantidad = Convert.ToDecimal(view.GetRowCellValue(i, "cantidad"));
                                        decimal vPrecio = Convert.ToDecimal(view.GetRowCellValue(i, "precio1"));
                                        decimal vDescuento = Convert.ToDecimal(view.GetRowCellValue(i, "descuento"));
                                        decimal vImpuesto = Convert.ToDecimal(view.GetRowCellValue(i, "impuesto"));
                                        decimal vTotal = Convert.ToDecimal(view.GetRowCellValue(i, "total"));
                                        decimal vCosto = db.Producto.Where(x => x.id == vIdProducto).Select(x => x.costo).FirstOrDefault().Value;
                                        string vUbicacion = Convert.ToString(view.GetRowCellValue(i, "ubicacion"));
                                        //(db.Kardex.Where(x => x.id_producto == vIdProducto && x.id_bodega == vIdBodega && x.id_lote==Vid_Lote).Select(x => x.ubicacion).FirstOrDefault() != null) ? db.Kardex.Where(x => x.id_producto == vIdProducto && x.id_bodega == vIdBodega).Select(x => x.ubicacion).FirstOrDefault() : "";

                                        int detalleMovOK = db.MovimientoInventarioDetalle_INSERT(movOK.id, vIdBodega, vIdProducto, vCantidad, vCosto, vUbicacion, Vid_Lote);
                                        int detallePrestamosActualizarOk = db.Kardex_Actualizar_Prestamos_DF(vIdBodega, vIdProducto, Vid_Lote, vCantidad, Convert.ToInt32(vUbicacion));
                                        if (detalleMovOK > 0 && detallePrestamosActualizarOk > 0) ok_inventario++;
                                        else break;
                                    }
                                    //if(Ok == view.RowCount && pagoOK == viewPago.RowCount)
                                    //    vRetorno = id_mov_caja;
                                    //else
                                    //    vRetorno = 0;
                                }
                                int pagoOK = 0;
                                for (int i = 0; i < viewPago.RowCount; i++)
                                {
                                    int vIdFormaPago = Convert.ToInt32(viewPago.GetRowCellValue(i, "id_forma_pago"));
                                    decimal vMonto = Convert.ToDecimal(viewPago.GetRowCellValue(i, "monto"));
                                    int FormaPagoOK = db.FormaPagoVenta_INSERTAR(vIdVenta, vIdFormaPago, vMonto);
                                    if (FormaPagoOK > 0) pagoOK++;
                                }

                                if (db.Terminos.Where(x => x.id == xIdTermino).FirstOrDefault().dias > 0)
                                {
                                    bool okCxC = db.DocumentosCuentasCobrar_Insert(6, xIdCliente, int.Parse(vNumero.Replace("V", "")), xFecha, vSumTotal, vSumSubTotal, vSumDescuento, vSumImpuesto, xIdEmpleado, "FACTURA DE CREDITO " + vNumero, xVendedor, 0.00M, false, xIdTermino, 1, vIdVenta).FirstOrDefault().HasValue;
                                    var movOK = db.MovimientoInventario_INSERT(vIdAjuste, xFecha, vNumero, xObservacion, xIdEmpleado, xPersonaReferencia, 2, vIdVenta).FirstOrDefault();
                                    int Ok1 = 0;
                                    for (int i = 0; i < view.RowCount; i++)
                                    {
                                        int vIdBodega = Convert.ToInt32(view.GetRowCellValue(i, "id_bodega"));
                                        int vIdProducto = Convert.ToInt32(view.GetRowCellValue(i, "id_producto"));
                                        int vid_lote = Convert.ToInt32(view.GetRowCellValue(i, "id_lote"));
                                        decimal vCantidad = Convert.ToDecimal(view.GetRowCellValue(i, "cantidad"));
                                        decimal vPrecio = Convert.ToDecimal(view.GetRowCellValue(i, "precio1"));
                                        decimal vDescuento = Convert.ToDecimal(view.GetRowCellValue(i, "descuento"));
                                        decimal vImpuesto = Convert.ToDecimal(view.GetRowCellValue(i, "impuesto"));
                                        decimal vTotal = Convert.ToDecimal(view.GetRowCellValue(i, "total"));
                                        string vUbicacion = Convert.ToString(view.GetRowCellValue(i, "ubicacion"));
                                        var VCosto = db.Producto.Where(D => D.id == vIdProducto).FirstOrDefault().costo;

                                        int detalleMovOK = db.MovimientoInventarioDetalle_INSERT(movOK.id, vIdBodega, vIdProducto, vCantidad, VCosto, vUbicacion, vid_lote);
                                        if (detalleMovOK > 0) Ok1++;
                                        else break;
                                    }
                                    if (okCxC && Ok == view.RowCount && pagoOK == viewPago.RowCount) vRetorno = true;
                                }
                                else
                                if (Ok == view.RowCount && ok_inventario == view.RowCount && pagoOK == viewPago.RowCount) vRetorno = true;
                            }
                            else
                            {
                                int Ok = 0;
                                for (int i = 0; i < view.RowCount; i++)
                                {
                                    int vIdBodega = Convert.ToInt32(view.GetRowCellValue(i, "id_bodega"));
                                    int vIdProducto = Convert.ToInt32(view.GetRowCellValue(i, "id_producto"));
                                    int vid_lote = Convert.ToInt32(view.GetRowCellValue(i, "id_lote"));
                                    decimal vCantidad = Convert.ToDecimal(view.GetRowCellValue(i, "cantidad"));
                                    decimal vPrecio = Convert.ToDecimal(view.GetRowCellValue(i, "precio1"));
                                    decimal vDescuento = Convert.ToDecimal(view.GetRowCellValue(i, "descuento"));
                                    decimal vImpuesto = Convert.ToDecimal(view.GetRowCellValue(i, "impuesto"));
                                    decimal vTotal = Convert.ToDecimal(view.GetRowCellValue(i, "total"));
                                    decimal vCosto = db.Producto.Where(x => x.id == vIdProducto).Select(x => x.costo).FirstOrDefault().Value;
                                    string vUbicacion = Convert.ToString(view.GetRowCellValue(i, "ubicacion"));
                                    string vdescripcion = Convert.ToString(view.GetRowCellValue(i, "descripcion"));
                                    int detalleOK = db.VentaDetalle_INSERTAR(vIdVenta, vIdBodega, vIdProducto, vCantidad, vPrecio, vDescuento, vImpuesto, vTotal, vid_lote, vUbicacion, vdescripcion);
                                    if (detalleOK > 0) Ok++;
                                    else break;
                                }

                                int pagoOK = 0;
                                for (int i = 0; i < viewPago.RowCount; i++)
                                {
                                    int vIdFormaPago = Convert.ToInt32(viewPago.GetRowCellValue(i, "id_forma_pago"));
                                    int vMonto = Convert.ToInt32(viewPago.GetRowCellValue(i, "monto"));
                                    int FormaPagoOK = db.FormaPagoVenta_INSERTAR(vIdVenta, vIdFormaPago, vMonto);
                                    if (FormaPagoOK > 0) pagoOK++;
                                }

                                if (Ok == view.RowCount && pagoOK == viewPago.RowCount) vRetorno = true;
                            }
                        }
                        if (vRetorno) { db.SaveChanges(); dbTrans.Commit(); }
                        else { dbTrans.Rollback(); }
                    }
                    catch (Exception ex)
                    {
                        dbTrans.Rollback();
                        XtraMessageBox.Show("Lo sentimos, ocurrio el siguiente error: " + ex.
                            GetBaseException().Message, "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        vRetorno = false;
                    }
                }
            }

            return Tuple.Create(vRetorno, vIdVenta, vNumero);
        }

        public Tuple<bool> Venta_DevolverPrestamos(int xIdPrestamo,int xIdEmpleado, int xVendedor, int xNumero, int xIdCliente, DateTime xFecha, DateTime xFechaMaxima, decimal xTipoCambio, string xObservacion, int xTipo, int xIdTermino, string xPersonaReferencia, DevExpress.XtraGrid.Views.Grid.GridView view, DevExpress.XtraGrid.Views.Grid.GridView viewPago, string representante, int moneda, int persona_autoriza, int xPrecio, int vCambioPrecioCliente, decimal retencion1, decimal retencion2)
        {
            bool vRetorno = false;
            using (var db = new Entities())
            {
                using (var dbTrans = db.Database.BeginTransaction())
                {
                    try
                    {
                        int ok_inventario = 0;
                        for (int i = 0; i < view.RowCount; i++)
                        {
                            int vIdBodega = Convert.ToInt32(view.GetRowCellValue(i, "id_bodega"));
                            int vIdProducto = Convert.ToInt32(view.GetRowCellValue(i, "id_producto"));
                            int Vid_Lote = Convert.ToInt32(view.GetRowCellValue(i, "id_lote"));
                            decimal vCantidad = Convert.ToDecimal(view.GetRowCellValue(i, "cantidad"));
                            decimal vPrecio = Convert.ToDecimal(view.GetRowCellValue(i, "precio1"));
                            decimal vDescuento = Convert.ToDecimal(view.GetRowCellValue(i, "descuento"));
                            decimal vImpuesto = Convert.ToDecimal(view.GetRowCellValue(i, "impuesto"));
                            decimal vTotal = Convert.ToDecimal(view.GetRowCellValue(i, "total"));
                            decimal vCosto = db.Producto.Where(x => x.id == vIdProducto).Select(x => x.costo).FirstOrDefault().Value;
                            string vUbicacion = Convert.ToString(view.GetRowCellValue(i, "ubicacion"));
                            //(db.Kardex.Where(x => x.id_producto == vIdProducto && x.id_bodega == vIdBodega && x.id_lote==Vid_Lote).Select(x => x.ubicacion).FirstOrDefault() != null) ? db.Kardex.Where(x => x.id_producto == vIdProducto && x.id_bodega == vIdBodega).Select(x => x.ubicacion).FirstOrDefault() : "";

                            int detallePrestamosActualizarOk = db.Kardex_Actualizar_Prestamos_DF(vIdBodega, vIdProducto, Vid_Lote, vCantidad, Convert.ToInt32(vUbicacion));
                            if (detallePrestamosActualizarOk > 0) ok_inventario++;
                            else break;
                        }

                        if(ok_inventario == view.RowCount)
                        {
                            Prestamos p = db.Prestamos.Find(xIdPrestamo);
                            p.estado = 2;
                            db.SaveChanges();

                            vRetorno = true;

                        }

                        if (vRetorno) { db.SaveChanges(); dbTrans.Commit(); }
                        else { dbTrans.Rollback(); }
                    }
                    catch (Exception ex)
                    {
                        dbTrans.Rollback();
                        XtraMessageBox.Show("Lo sentimos, ocurrio el siguiente error: " + ex.GetBaseException().Message, "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        vRetorno = false;
                    }
                }
            }
            return Tuple.Create(vRetorno);
        }

        public void DesactivarCotizacion(int idCotizacion)
        {
            using (var db = new Entities())
            {
                using (var transaccion = db.Database.BeginTransaction())
                {
                    try
                    {
                        Venta v = db.Venta.Find(idCotizacion);
                        v.estado = 0;
                        v.activo = false;
                        db.SaveChanges();
                        transaccion.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaccion.Rollback();
                    }
                }
            }
        }

        public void PasarPrestamoAFacturado(int idCotizacion)
        {
            using (var db = new Entities())
            {
                using (var transaccion = db.Database.BeginTransaction())
                {
                    try
                    {
                        Prestamos v = db.Prestamos.Find(idCotizacion);
                        v.estado = 3;
                        db.SaveChanges();
                        transaccion.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaccion.Rollback();
                    }
                }
            }
        }

        public Tuple<bool, int, string> Venta_Devolucion(int xIdVenta, DateTime xFecha, string xObservacion, int xIdEmpleado, int xTipoVenta)
        {
            bool vRetorno = false;
            string vNumero = "";
            int vIdMov = 0;
            using (var db = new Entities())
            {
                using (var dbTrans = db.Database.BeginTransaction())
                {
                    try
                    {
                        if (db.Ventas_ELIMINAR(xIdVenta, xIdEmpleado) > 0)
                        {
                            if (xTipoVenta > 0)
                            {
                                var queryVenta = db.Venta.Where(x => x.id == xIdVenta).FirstOrDefault();
                                var querMovCaja = db.MovimientoCaja.Where(x => x.id_documento == xIdVenta && x.numero_referencia == queryVenta.numero).FirstOrDefault();
                                int vIdAjuste = db.AjustesModulos.Where(x => x.activo == true && x.tipo == 4).FirstOrDefault().id_ajuste; //Ajuste Modulo Devolucion=4                                

                                if (querMovCaja != null)
                                {
                                    // Cambiar estado movimiento de efectivo (si existe) de la venta
                                    var movEfectivoOk = db.MovimientoCaja_Eliminar(xIdEmpleado, querMovCaja.id_movimiento);
                                }

                                var movOK = db.MovimientoInventario_INSERT(vIdAjuste, xFecha, queryVenta.numero, xObservacion, xIdEmpleado, queryVenta.Cliente.nombre, 2, xIdVenta).FirstOrDefault();
                                if (movOK != null)
                                {
                                    vIdMov = movOK.id;
                                    vNumero = movOK.numero_documento;

                                    int Ok = 0;
                                    foreach (var list in db.VentaDetalle.Where(x => x.id_venta == xIdVenta && x.activo == true).ToList())
                                    {
                                        decimal vCosto = db.Producto.Where(x => x.id == list.id_producto).Select(x => x.costo).FirstOrDefault().Value;
                                        string vUbicacion = (db.Kardex.Where(x => x.id_producto == list.id_producto && x.id_bodega == list.id_bodega).Select(x => x.ubicacion).FirstOrDefault() != null) ? db.Kardex.Where(x => x.id_producto == list.id_producto && x.id_bodega == list.id_bodega).Select(x => x.ubicacion).FirstOrDefault() : "";
                                        int detalleOK = db.MovimientoInventarioDetalle_INSERT_DEVOLUCION(vIdMov, list.id_bodega, list.id_producto, list.cantidad, vCosto, vUbicacion, list.id_lote);
                                        if (detalleOK > 0) Ok++;
                                        else break;
                                    }
                                    if (Ok == db.VentaDetalle.Where(x => x.id_venta == xIdVenta && x.activo == true).ToList().Count) vRetorno = true;
                                }
                            }
                            else
                            {
                                vRetorno = true;
                            }
                            if (vRetorno) { db.SaveChanges(); dbTrans.Commit(); }
                            else { dbTrans.Rollback(); }
                        }
                    }
                    catch (Exception ex)
                    {
                        dbTrans.Rollback();
                        XtraMessageBox.Show("Lo sentimos, ocurrio el siguiente error: " + ex, "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        vRetorno = false;
                    }
                }
            }
            return Tuple.Create(vRetorno, vIdMov, vNumero);
        }

        public Tuple<bool, int> Remision_Devolucion(int xIdVenta, DateTime xFecha, string xObservacion, int xIdEmpleado, int xTipoVenta)
        {
            bool vRetorno = false;
            using (var db = new Entities())
            {
                using (var dbTrans = db.Database.BeginTransaction())
                {
                    try
                    {
                        int OkAct = 0;

                        Venta v = db.Venta.Find(xIdVenta);
                        v.activo = false;
                        db.SaveChanges();

                        foreach (var list in db.VentaDetalle.Where(x => x.id_venta == xIdVenta && x.activo == true).ToList())
                        {
                            int vIdBodega = Convert.ToInt32(list.id_bodega);
                            int vIdProducto = Convert.ToInt32(list.id_producto);
                            int vid_lote = Convert.ToInt32(list.id_lote);
                            decimal vCantidad = Convert.ToDecimal(list.cantidad);
                            string vUbicacion = Convert.ToString(list.ubicacion);

                            int actualiarComprometidos = db.Kardex_Eliminar_Comprometidos(vIdProducto, vIdBodega, vUbicacion, vCantidad, xIdVenta, vid_lote);
                            if (actualiarComprometidos > 0) OkAct++;
                            else break;
                        }

                        //Esta parte de codigo no va en el caso de anulacion de remision, ya que no es necesario volver a anular el detalle de la venta, sin eso, el reporte cuando la remision este anulada no carga correctamente
                        //foreach (var x in db.VentaDetalle.Where(o => o.id_venta == xIdVenta && o.activo == true).ToList())
                        //{
                        //    x.activo = false;
                        //    db.SaveChanges();
                        //}

                        vRetorno = true;

                        if (vRetorno) { db.SaveChanges(); dbTrans.Commit(); }
                        else { dbTrans.Rollback(); }
                    }
                    catch (Exception ex)
                    {
                        dbTrans.Rollback();
                        XtraMessageBox.Show("Lo sentimos, ocurrio el siguiente error: " + ex, "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        vRetorno = false;
                    }
                }
            }
            return Tuple.Create(vRetorno, xIdVenta);
        }
        public List<Venta> getVentas()
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Venta.ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Prestamos> getPrestamos()
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Prestamos.ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Ventas_SELECT_Result> Ventas_Select(int xTipo)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Ventas_SELECT(xTipo).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Ventas_SELECT_Devoluciones_Result> Ventas_Select_Devoluciones(int xTipo)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Ventas_SELECT_Devoluciones(xTipo).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Ventas_SELECT_DevolucionesProductoDañado_Result> Ventas_SELECT_DevolucionesProductoDañado(int xTipo)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Ventas_SELECT_DevolucionesProductoDañado(xTipo).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Ventas_SELECT_REMISION_Result> Ventas_Select_Remision(int xTipo)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Ventas_SELECT_REMISION(xTipo).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Ventas_SELECT_PRESTAMOS_Result> Ventas_Select_Prestamos(int xTipo)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Ventas_SELECT_PRESTAMOS(xTipo).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        public List<Ventas_SELECT_SIN_CANCELAR_Result> Ventas_Sin_Cancelar()
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Ventas_SELECT_SIN_CANCELAR(0).ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<Ventas_SELECT_Por_ID_Result> Ventas_Select_por_ID(int id)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Ventas_SELECT_Por_ID(id).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        public int moneda_facatura(int id)
        {
            try
            {
                using (Entities db = new Entities())
                {
                    return Convert.ToInt32(db.Venta.Where(F => F.id == id).FirstOrDefault().moneda);

                }
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public List<VentasDetalle_SELECT_Result> VentasDetalle_Select(int xIdVenta)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.VentasDetalle_SELECT(xIdVenta).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<PrestamoDetalle_SELECT_Result> PrestamoDetalle_SELECT(int xIdVenta)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.PrestamoDetalle_SELECT(xIdVenta).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        public List<VentaDetalles_Select_Todas_Result> Detalles_Todos()
        {
            try
            {
                using (Entities db = new Entities())
                {
                    return db.VentaDetalles_Select_Todas().ToList();
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public DataTable getVentasDetalle(int xIdVenta)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("id_bodega", typeof(int));
                dt.Columns.Add("id_producto", typeof(int));
                dt.Columns.Add("codigo_producto", typeof(string));
                //dt.Columns.Add("codigo_producto", typeof(string));
                dt.Columns.Add("descripcion", typeof(string));
                dt.Columns.Add("cantidad", typeof(decimal));
                dt.Columns.Add("id_unidad_medida", typeof(int));
                dt.Columns.Add("precio1", typeof(decimal));
                dt.Columns.Add("descuento", typeof(decimal));
                dt.Columns.Add("impuesto", typeof(decimal));
                dt.Columns.Add("id_lote", typeof(int));
                DataRow row = dt.NewRow();

                using (var db = new Entities())
                {
                    foreach (var list in db.VentasDetalle_SELECT(xIdVenta).ToList())
                    {
                        row["id_bodega"] = list.id_bodega;
                        row["id_producto"] = list.id_producto;
                        row["descripcion"] = list.descripcion;
                        row["codigo_producto"] = list.codigo;
                        //row["codigo_producto"] = list.codigo;
                        row["cantidad"] = list.cantidad;
                        row["id_unidad_medida"] = list.id_unidad_medida;
                        row["precio1"] = list.precio1;
                        row["descuento"] = list.descuento;
                        row["impuesto"] = list.impuesto;
                        row["id_lote"] = list.id_lote;
                        dt.Rows.Add(row);
                        row = dt.NewRow();
                    }
                }
                return dt;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataTable getPrestamoDetalle(int xIdVenta)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("id_bodega", typeof(int));
                dt.Columns.Add("id_producto", typeof(int));
                dt.Columns.Add("codigo_producto", typeof(string));
                //dt.Columns.Add("codigo_producto", typeof(string));
                dt.Columns.Add("descripcion", typeof(string));
                dt.Columns.Add("cantidad", typeof(decimal));
                dt.Columns.Add("id_unidad_medida", typeof(int));
                dt.Columns.Add("precio1", typeof(decimal));
                dt.Columns.Add("descuento", typeof(decimal));
                dt.Columns.Add("impuesto", typeof(decimal));
                dt.Columns.Add("id_lote", typeof(int));
                DataRow row = dt.NewRow();

                using (var db = new Entities())
                {
                    foreach (var list in db.PrestamoDetalle_SELECT(xIdVenta).ToList())
                    {
                        row["id_bodega"] = list.id_bodega;
                        row["id_producto"] = list.id_producto;
                        row["descripcion"] = list.descripcion;
                        row["codigo_producto"] = list.codigo;
                        //row["codigo_producto"] = list.codigo;
                        row["cantidad"] = list.cantidad;
                        row["id_unidad_medida"] = list.id_unidad_medida;
                        row["precio1"] = list.precio1;
                        row["descuento"] = list.descuento;
                        row["impuesto"] = list.impuesto;
                        row["id_lote"] = list.id_lote;
                        dt.Rows.Add(row);
                        row = dt.NewRow();
                    }
                }
                return dt;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Detalle_Cotizacion> Cargar_Detalle_Cotizacion(int xIdVenta)
        {
            try
            {
                List<Detalle_Cotizacion> lista = new List<Detalle_Cotizacion>();
                using (var db = new Entities())
                {
                    foreach (var list in db.VentasDetalle_SELECT(xIdVenta).ToList())
                    {
                        lista.Add(new Detalle_Cotizacion
                        {
                            id_bodega = Convert.ToInt32(list.id_bodega),
                            id_producto = list.id_producto,
                            codigo_producto = list.codigo,
                            descripcion = list.descripcion,
                            cantidad = list.cantidad,
                            precio1 = list.precio1,
                            id_unidad_medida = Convert.ToInt32(list.id_unidad_medida),
                            descuento = list.descuento,
                            impuesto = list.impuesto
                        ,
                            ubicacion = list.ubicacion
                        ,
                            id_lote = Convert.ToInt32(list.id_lote),
                            moneda = Convert.ToInt32(list.moneda)
                        });
                    }
                }
                return lista;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Detalle_Prestamo> Cargar_Detalle_Prestamo(int xIdVenta)
        {
            try
            {
                List<Detalle_Prestamo> lista = new List<Detalle_Prestamo>();
                using (var db = new Entities())
                {
                    foreach (var list in db.PrestamoDetalle_SELECT(xIdVenta).ToList())
                    {
                        lista.Add(new Detalle_Prestamo
                        {
                            id_bodega = Convert.ToInt32(list.id_bodega),
                            id_producto = list.id_producto,
                            codigo_producto = list.codigo,
                            descripcion = list.descripcion,
                            cantidad = list.cantidad,
                            precio1 = list.precio1,
                            id_unidad_medida = Convert.ToInt32(list.id_unidad_medida),
                            descuento = list.descuento,
                            impuesto = list.impuesto
                        ,
                            ubicacion = list.ubicacion
                        ,
                            id_lote = Convert.ToInt32(list.id_lote),
                            moneda = Convert.ToInt32(list.moneda)
                        });
                    }
                }
                return lista;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public int Venta_Eliminar(int xId, int xIdUsuario/*,int xTipoVenta*/)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Ventas_ELIMINAR(xId, xIdUsuario);
                    //if(db.Ventas_ELIMINAR(xId, xIdUsuario) > 0)
                    //{
                    //    if(xTipoVenta == 1)
                    //    {

                    //    }
                    //}
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public List<Venta_REPORTE_Result> Venta_Reporte(int xId)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Venta_REPORTE(xId).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Venta_Prestamo_REPORTE_Result> Venta_Prestamo_REPORTE(int xId)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Venta_Prestamo_REPORTE(xId).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<FormaPago_SELECTVENTA_Result> FormaPago_SelectVenta(int xIdVenta)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.FormaPago_SELECTVENTA(xIdVenta).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<FormaPago> getFormaPago()
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.FormaPago.ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<FormaPago_SELECT_Result> FormaPago_Select()
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.FormaPago_SELECT().ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public int FormaPago_Insertar(string xDescripcion, string xDescripcionCorta, int xMoneda, byte[] xImagen, bool efectivo)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.FormaPago_GUARDAR(xDescripcion, xDescripcionCorta, xMoneda, xImagen, efectivo);
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int FormaPago_Modificar(int xId, string xDescripcion, string xDescripcionCorta, int xMoneda, bool efectivo, byte[] xImagen, int xIdUsuario)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.FormaPago_MODIFICAR(xId, xDescripcion, xDescripcionCorta, xMoneda, efectivo, xImagen, xIdUsuario);
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int FormaPago_Eliminar(int xId, int xIdUsuario)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.FormaPago_ELIMINAR(xId, xIdUsuario);
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public List<FormaPagoVenta> getFormaPagoVenta()
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.FormaPagoVenta.ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public int ExisteAbonoFactura(int xIdVenta)
        {
            try
            {
                using (var db = new Entities())
                {
                    var dc_query = db.DocumentosCuentasCobrar.Where(x => x.id_factura == xIdVenta).FirstOrDefault();
                    if (dc_query != null) // Si hay documentos
                    {
                        var ac_query = db.AplicacionDocumentos.Where(x => x.id_documento_a_aplicar == dc_query.id_documento && x.estado == 1).FirstOrDefault();
                        if (ac_query != null) return 0; // Si hay documentos a aplicar retorna 0
                        else return dc_query.id_documento; // Sino retorna el id del documeto
                    }
                    else return -1; // Si no hay documentos retorna -1
                }
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public int devolverMoneda(int xIdVenta)
        {
            try
            {
                using (var db = new Entities())
                {
                    var moneda = db.Venta.Where(x => x.id == xIdVenta).FirstOrDefault();
                    return Convert.ToInt32(moneda.moneda);
                }
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public List<deteccionCambioPrecioCliente_Result> getDetectarCambioPrecioCliente(DateTime fecha)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.deteccionCambioPrecioCliente(fecha).ToList();
                }
            }
            catch (Exception s)
            {

                XtraMessageBox.Show("" + s);
                return null;
            }
        }

        public List<Cliente> getPrecioCliente()
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Cliente.ToList();
                }
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show("Lo sentimos, ocurrio el siguiente error: " + ex.Message, "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }



        #region CONSULTA DE REPORTES

        public List<VentasPorFecha_Result> VentasPorFechas(int xTipo, DateTime xFechaInicial, DateTime xFechaFin)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.VentasPorFecha(xTipo, xFechaInicial, xFechaFin).ToList();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lo sentimos, ocurrio el siguiente error: " + ex.Message, "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public List<reportes_de_ventas_Result> Ventas_Reportes(DateTime xFechaInicial, DateTime xFechaFin)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.reportes_de_ventas(xFechaInicial, xFechaFin).ToList();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lo sentimos, ocurrio el siguiente error: " + ex.Message, "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        //REVISAR ESTAS CONSULTAS
        /// <summary>
        /// Retorna un TOP 10 de Clientes y Productos, para cada cliente trae los 10 productos mas llevados por esos clientes 
        /// </summary>
        /// <param name="desde">Fecha inicio de la Busqueda</param>
        /// <param name="Hasta">Fecha Final de la Busqueda</param>
        ///// <returns>Lista TOP_10_PRODUCTOS_POR_CLIENTES_RANGO_Result</returns>
        //public List<TOP_10_PRODUCTOS_POR_CLIENTES_RANGO_Result>Top10ProductosPorClientes (DateTime desde,DateTime Hasta)
        //{
        //    try
        //    {
        //        using(Entities db= new Entities())
        //        {
        //            return db.TOP_10_PRODUCTOS_POR_CLIENTES_RANGO(desde.Date,Hasta.Date).ToList();
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        Console.WriteLine(ex.Message.ToString());
        //        return null;
        //    }
        //}
        ///// <summary>
        ///// Retorna un TOP 10 de clientes que mas compran en el periodo dado.
        ///// </summary>
        ///// <param name="desde">Fecha inicio de la Busqueda</param>
        ///// <param name="Hasta">Fecha finl de la busqueda</param>
        ///// <param name="moneda">Tipo de moneda 1 Para cordobas, 2 para Dolares</param>
        ///// <returns></returns>
        //public List<TOP_10_CLIENTES_VENTAS_POR_RANGO_MONEDA_Result> Top10ClientesPorRangoMoneda(DateTime desde,DateTime Hasta,int moneda)
        //{
        //    try
        //    {
        //        using(Entities db= new Entities())
        //        {
        //            return db.TOP_10_CLIENTES_VENTAS_POR_RANGO_MONEDA(desde.Date,Hasta.Date,moneda).ToList();
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        Console.WriteLine(ex.Message.ToString());
        //        return null;
        //    }
        //}
        ///// <summary>
        ///// Retorna TOP 10 de los productos mas vendidos en un rango dado de un grupo especifico.
        ///// </summary>
        ///// <param name="desde">Fecha inicio de la Busqueda</param>
        ///// <param name="Hasta">Fecha finl de la busqueda</param>
        ///// <param name="id_grupo">Id de la tabla Categorias</param>
        ///// <returns></returns>
        //public List<TOP_10_PRODUCTOS_MAS_VENDIDOS_POR_RANGO_Result> Top10ProductosMasVendidos_Rango(DateTime desde,DateTime Hasta,int id_grupo)
        //{
        //    try
        //    {
        //        using(Entities db = new Entities())
        //        {
        //          return  db.TOP_10_PRODUCTOS_MAS_VENDIDOS_POR_RANGO(desde,Hasta,id_grupo).ToList();
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        return null;
        //    }
        //}
        public List<productos_mas_vendidos_Result> Top10ProductosMasVendidos_Rango(int top, DateTime desde, DateTime Hasta)
        {
            try
            {
                using (Entities db = new Entities())
                {
                    return db.productos_mas_vendidos(top, desde, Hasta).ToList();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lo sentimos, ocurrio el siguiente error: " + ex.Message, "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public List<Productos_Mas_vendidos_Rango_Result> Productos_mas_Vendidos_Rango(DateTime desde, DateTime Hasta)
        {
            try
            {
                using (Entities db = new Entities())
                {
                    return db.Productos_Mas_vendidos_Rango(desde, Hasta).ToList();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lo sentimos, ocurrio el siguiente error: " + ex.Message, "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public List<Detalle_Producto_mas_vendido_Result> Detalle_producto_vendido(DateTime desde, DateTime Hasta, int xId_producto)
        {
            try
            {
                using (Entities db = new Entities())
                {
                    return db.Detalle_Producto_mas_vendido(desde, Hasta, xId_producto).ToList();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lo sentimos, ocurrio el siguiente error: " + ex, "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public List<ClientesMasFrecuentes_Result> Cliete_Frecuencia_select(DateTime xfecha_ini, DateTime xfecha_fin)
        {
            try
            {
                using (Entities db = new Entities())
                {
                    db.Database.CommandTimeout = 120;
                    return db.ClientesMasFrecuentes(xfecha_ini, xfecha_fin).ToList();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lo sentimos, ocurrio el siguiente error: " + ex.Message, "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public List<ClientesMasFrecuentesV2_Result> Cliete_Frecuencia_selectV2(DateTime xfecha_ini, DateTime xfecha_fin)
        {
            try
            {
                using (Entities db = new Entities())
                {
                    db.Database.CommandTimeout = 120;
                    return db.ClientesMasFrecuentesV2(xfecha_ini, xfecha_fin).ToList();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lo sentimos, ocurrio el siguiente error: " + ex.Message, "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public List<VentasPorSubGrupo_Result> Ventas_SubGrupo(DateTime fecha_ini, DateTime fecha_fin)
        {
            try
            {
                using (Entities db = new Entities())
                {
                    return db.VentasPorSubGrupo(fecha_ini, fecha_fin).ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion
    }
}
