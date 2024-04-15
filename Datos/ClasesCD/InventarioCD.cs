using DevExpress.XtraEditors;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using DevExpress.XtraGrid.Views.Grid;

namespace Datos.ClasesCD
{
    public class InventarioCD
    {

        public List<Movimiento_Por_Producto_Result> Movimiento_por_producto(int id_producto, int id_bodega, int id_lote, string ubicacion)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Movimiento_Por_Producto(id_producto, id_bodega, id_lote, ubicacion).ToList();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lo sentimos, ocurrio el siguiente error: " + ex.Message + ". Comunicarse con soporte técnico", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // DAR BUENA REVISADA YA QUE SE USA PARA VENTAS
        public decimal Precio_De_Producto(int tp, int id_producto)
        {
            try
            {
                using (var db = new Entities())
                {
                    var x = (db.PRECIOS_SELECT(id_producto).Where(o => o.tipo == tp)).FirstOrDefault();
                    return Convert.ToDecimal(x.Precios);
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        // REVISAR METODO QUE SOLO SE USA UNA VEZ PERO NO SE IMPLEMNTA
        public string Precio_De_Producto_letras(int tp, int id_producto)
        {
            try
            {
                using (var db = new Entities())
                {
                    var x = (db.PRECIOS_SELECT(id_producto).Where(o => o.tipo == tp)).FirstOrDefault();
                    return Convert.ToString(x.Nombre);
                }
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        public List<Kardex_SELECT_Result> Kardex_Select()
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Kardex_SELECT().ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public int Estado_Movimiento(int id_movimiento)
        {
            try
            {
                using (Entities db = new Entities())
                {
                    return db.MovimientoInventario.Where(ID => ID.id == id_movimiento).FirstOrDefault().estado ?? -1;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return -1;
            }
        }

        public int Revierte_Movimiento(int id_movimiento_invetario)
        {
            try
            {
                using (Entities db = new Entities())
                {
                    return db.Revertir_Movimiento_Inventario(id_movimiento_invetario);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }

        }

        public List<MovimientoInventario_SELECT_Result> MovimientoInventario_Select(bool xCerrado, DateTime desde, DateTime hasta)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.MovimientoInventario_SELECT(xCerrado, desde, hasta).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<MovimientoDevolucionSelect_Result> MovimientoDevolucionSelect(bool xCerrado, DateTime desde, DateTime hasta)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.MovimientoDevolucionSelect(xCerrado, desde, hasta).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<MovimientoDevolucionSelect_ProdDañado_Result> MovimientoDevolucionSelect_ProdDañado(bool xCerrado, DateTime desde, DateTime hasta)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.MovimientoDevolucionSelect_ProdDañado(xCerrado, desde, hasta).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<MovimientoInventario_SELECT_Autorizacion_Result> MovimientoInventario_Select_Autorizacion(bool xCerrado, DateTime desde, DateTime hasta)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.MovimientoInventario_SELECT_Autorizacion(xCerrado, desde, hasta).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        public List<MovimientoInventarioDetalle_SELECT_Result> MovimientoInventarioDetalle_Select(int xIdMovimiento)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.MovimientoInventarioDetalle_SELECT(xIdMovimiento).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<MovimientoDevolucionDetalleSelect_Result> MovimientoDevolucionDetalleSelect(int id_venta)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.MovimientoDevolucionDetalleSelect(id_venta).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<MovimientoDevolucionDetalleSelect_ProductoDañado_Result> MovimientoDevolucionDetalleSelect_ProductoDañado(int id_venta)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.MovimientoDevolucionDetalleSelect_ProductoDañado(id_venta).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<MovimientoInventarioDetalle_SELECT_Autorizacion_Result> MovimientoInventarioDetalle_Select_Autorizacion(int xIdMovimiento)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.MovimientoInventarioDetalle_SELECT_Autorizacion(xIdMovimiento).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        public int AnularMov_Autorizacion(int xIdMovimiento)
        {
            using (var db = new Entities())
            {
                using (var dbTrans = db.Database.BeginTransaction())
                {
                    try
                    {
                        MovimientoInventario_Autorizacion mva = db.MovimientoInventario_Autorizacion.Find(xIdMovimiento);
                        mva.activo = false;
                        db.SaveChanges();

                        dbTrans.Commit();
                        return 1;
                    }
                    catch (Exception)
                    {
                        dbTrans.Rollback();
                        return 0;
                    }

                }


            }
        }

        public int ActualizarObservacionTraslados(int idMovimiento, string xObservacion)
        {
            using (var db = new Entities())
            {
                using (var dbTrans = db.Database.BeginTransaction())
                {
                    try
                    {
                        MovimientoInventario mi = db.MovimientoInventario.Find(idMovimiento);
                        mi.observacion = xObservacion;
                        db.SaveChanges();

                        dbTrans.Commit();
                        return 1;
                    }
                    catch (Exception ex)
                    {
                        dbTrans.Rollback();
                        return 0;
                    }
                }
            }
        }

        public List<Movimientos_de_inventarios_detallados_por_rango_fecha_Result> Movimiento_detallado_por_rango(DateTime desde, DateTime Hasta)
        {
            try
            {
                using (var db = new Entities())
                {

                    return db.Movimientos_de_inventarios_detallados_por_rango_fecha(desde.Date, Hasta.Date).ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return null;

            }
        }

        public Tuple<bool, int, string> MovimientoInventario_Guardar(int xIdTipoAjuste, DateTime xFecha, string xNumeroReferencia, string xObservacion, int xIdEmpleado, string xPersonaReferencia, int xTipo, int xIdReferencia, DevExpress.XtraGrid.Views.Grid.GridView view, int id_bodega)
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
                        var movOK = db.MovimientoInventario_INSERT(xIdTipoAjuste, xFecha, xNumeroReferencia, xObservacion, xIdEmpleado, xPersonaReferencia, xTipo, xIdReferencia).FirstOrDefault();
                        if (movOK != null)
                        {
                            vIdMov = movOK.id;
                            vNumero = movOK.numero_documento;

                            int Ok = 0;
                            for (int i = 0; i < view.RowCount; i++)
                            {
                                int vIdBodega = id_bodega;// Convert.ToInt32(view.GetRowCellValue(i, "id_bodega"));
                                int vIdProducto = Convert.ToInt32(view.GetRowCellValue(i, "id_producto"));
                                decimal vCantidad = Convert.ToDecimal(view.GetRowCellValue(i, "cantidad"));
                                decimal vCosto = db.Producto.Where(x => x.id == vIdProducto).Select(x => x.costo).FirstOrDefault().Value;
                                string vUbicacion = Convert.ToString(view.GetRowCellValue(i, "ubicacion"));/* (db.Kardex.Where(x => x.id_producto == vIdProducto && x.id_bodega == vIdBodega).Select(x => x.ubicacion).FirstOrDefault() != null) ? db.Kardex.Where(x => x.id_producto == vIdProducto && x.id_bodega == vIdBodega).Select(x => x.ubicacion).FirstOrDefault() : "";*/
                                int lote_id = Convert.ToInt32(view.GetRowCellValue(i, "id_lote"));

                                //Console.WriteLine(vIdBodega.ToString(),vIdProducto,vCantidad,vCosto,vUbicacion,lote_id.ToString());
                                int detalleOK = db.MovimientoInventarioDetalle_INSERT(vIdMov, vIdBodega, vIdProducto, vCantidad, vCosto, vUbicacion, lote_id);
                                if (detalleOK > 0) Ok++;
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
                        XtraMessageBox.Show("Lo sentimos, ocurrio el siguiente error: " + ex, "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        vRetorno = false;
                    }
                }
            }

            return Tuple.Create(vRetorno, vIdMov, vNumero);
        }

        public Tuple<bool, int, string> AjusteInventario_Guardar(int xIdTipoAjuste, DateTime xFecha, string xNumeroReferencia, string xObservacion, int xIdEmpleado, string xPersonaReferencia, int xTipo, int xIdReferencia, DevExpress.XtraGrid.Views.Grid.GridView view, int id_bodega)
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
                        var movOK = db.Ajustes_Inventario_Insert(xIdTipoAjuste, xFecha, xNumeroReferencia, xObservacion, xIdEmpleado, xPersonaReferencia, xTipo, xIdReferencia).FirstOrDefault();
                        if (movOK != null)
                        {
                            vIdMov = movOK.id;
                            vNumero = movOK.numero_documento;

                            int Ok = 0;
                            for (int i = 0; i < view.RowCount; i++)
                            {
                                int vIdBodega = id_bodega;// Convert.ToInt32(view.GetRowCellValue(i, "id_bodega"));
                                int vIdProducto = Convert.ToInt32(view.GetRowCellValue(i, "id_producto"));
                                decimal vCantidad = Convert.ToDecimal(view.GetRowCellValue(i, "cantidad"));
                                decimal vCosto = db.Producto.Where(x => x.id == vIdProducto).Select(x => x.costo).FirstOrDefault().Value;
                                string vUbicacion = Convert.ToString(view.GetRowCellValue(i, "ubicacion"));/* (db.Kardex.Where(x => x.id_producto == vIdProducto && x.id_bodega == vIdBodega).Select(x => x.ubicacion).FirstOrDefault() != null) ? db.Kardex.Where(x => x.id_producto == vIdProducto && x.id_bodega == vIdBodega).Select(x => x.ubicacion).FirstOrDefault() : "";*/
                                int lote_id = Convert.ToInt32(view.GetRowCellValue(i, "id_lote"));

                                //Console.WriteLine(vIdBodega.ToString(),vIdProducto,vCantidad,vCosto,vUbicacion,lote_id.ToString());
                                int detalleOK = db.MovimientoInventarioDetalle_INSERT(vIdMov, vIdBodega, vIdProducto, vCantidad, vCosto, vUbicacion, lote_id);
                                if (detalleOK > 0) Ok++;
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
                        XtraMessageBox.Show("Lo sentimos, ocurrio el siguiente error: " + ex, "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        vRetorno = false;
                    }
                }
            }

            return Tuple.Create(vRetorno, vIdMov, vNumero);
        }

        public List<ReporteDevoluciones_Result> ReporteDevoluciones(int id_venta)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.ReporteDevoluciones(id_venta).ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<ReporteDevoluciones_ProductoDañado_Result> ReporteDevoluciones_ProductoDañado(int id_venta)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.ReporteDevoluciones_ProductoDañado(id_venta).ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public int SaldoFactura(int id_venta, string observaciones, int id_empleado, string persona_referencia, GridView gridViewDetalleMod, GridView gridViewDetalleModSalida, int mov_generado)
        {
            int retorno = 0;

            using (var db = new Entities())
            {
                using (var dbTrans = db.Database.BeginTransaction())
                {
                    try
                    {
                        if (gridViewDetalleMod.RowCount > 0 && gridViewDetalleModSalida.RowCount == 0)
                        {
                            var queryVenta = db.Venta.Find(id_venta);

                            SaldoFavorCliente sfc = new SaldoFavorCliente();
                            sfc.id_venta = id_venta;
                            sfc.monto = Convert.ToDecimal(gridViewDetalleMod.Columns["total"].SummaryItem.SummaryValue);
                            sfc.id_cliente = queryVenta.id_cliente;
                            sfc.moneda = Convert.ToInt32(queryVenta.moneda);
                            sfc.estado = 1;
                            sfc.activo = true;
                            sfc.fecha_registro = DateTime.Now;
                            sfc.id_venta_usada = 0;
                            sfc.mov_generado = mov_generado;
                            db.SaldoFavorCliente.Add(sfc);
                            db.SaveChanges();

                            retorno = 1;
                        }
                        else if (gridViewDetalleMod.RowCount > 0 && gridViewDetalleModSalida.RowCount > 0)
                        {
                            decimal totalEntrante = Convert.ToDecimal(gridViewDetalleMod.Columns["total"].SummaryItem.SummaryValue);
                            decimal totalSalida = Convert.ToDecimal(gridViewDetalleModSalida.Columns["total"].SummaryItem.SummaryValue);

                            if(totalEntrante > totalSalida)
                            {
                                var queryVenta = db.Venta.Find(id_venta);

                                SaldoFavorCliente sfc = new SaldoFavorCliente();
                                sfc.id_venta = id_venta;
                                sfc.monto = totalEntrante - totalSalida;
                                sfc.id_cliente = queryVenta.id_cliente;
                                sfc.moneda = Convert.ToInt32(queryVenta.moneda);
                                sfc.estado = 1;
                                sfc.activo = true;
                                sfc.fecha_registro = DateTime.Now;
                                sfc.id_venta_usada = 0;
                                sfc.mov_generado = mov_generado;
                                db.SaldoFavorCliente.Add(sfc);

                                retorno = 1;
                            }
                            else if(totalSalida > totalEntrante)
                            {
                                var queryVenta = db.Venta.Find(id_venta);

                                var VentaOk = db.Venta_GUARDAR(id_empleado, 0, queryVenta.id_cliente, DateTime.Now, DateTime.Now, queryVenta.tipo_cambio, observaciones, 1, queryVenta.id_termino, id_empleado, queryVenta.nombre_representante, queryVenta.moneda, 0, queryVenta.tipo_precio, queryVenta.Cambio_Precio_Cliente, 0, 0).FirstOrDefault();
                                if(VentaOk != null)
                                {
                                    int Ok = 0;
                                    for (int i = 0; i < gridViewDetalleModSalida.RowCount; i++)
                                    {
                                        int id_bodega = 1;
                                        int id_producto = Convert.ToInt32(gridViewDetalleModSalida.GetRowCellValue(i, "id"));
                                        int id_lote = 412;
                                        decimal cantidad = Convert.ToDecimal(gridViewDetalleModSalida.GetRowCellValue(i, "cantidad"));
                                        decimal precio = Convert.ToDecimal(gridViewDetalleModSalida.GetRowCellValue(i, "precio"));
                                        decimal descuento = 0;
                                        decimal impuesto = 0;
                                        decimal total = totalSalida - totalEntrante;
                                        string ubicacion = "0";
                                        string descripcion = db.Producto_CARGAR_FILA(id_producto).FirstOrDefault().descripcion;

                                        int detalleOK = db.VentaDetalle_INSERTAR(VentaOk.id, id_bodega, id_producto, cantidad, precio, descuento, impuesto, total, id_lote, ubicacion, descripcion);

                                        if (detalleOK > 0) Ok++;
                                        else break;
                                    }

                                    if(mov_generado == 1)
                                    {
                                        var queryDevoluciones = db.Devoluciones.Where(x => x.id_venta == id_venta);
                                        foreach (var list in queryDevoluciones)
                                        {
                                            list.id_venta_nueva = VentaOk.id;
                                            db.SaveChanges();
                                        }
                                    }
                                    else if(mov_generado == 2)
                                    {
                                        var queryDevoluciones = db.DevolucionesProductoDañado.Where(x => x.id_venta == id_venta);
                                        foreach (var list in queryDevoluciones)
                                        {
                                            list.id_venta_nueva = VentaOk.id;
                                            db.SaveChanges();
                                        }
                                    }
                                    

                                    if(Ok == gridViewDetalleModSalida.RowCount)
                                    {
                                        retorno = 1;
                                    }
                                }
                            }
                        }

                        if (retorno == 1) { db.SaveChanges(); dbTrans.Commit(); }
                        else { dbTrans.Rollback(); }
                    }
                    catch (Exception ex)
                    {
                        dbTrans.Rollback();
                        retorno = -1;
                    }
                }
            }

            return retorno;
        }

        public int DevolucionSalida(int id_venta, string observaciones, int id_empleado, string persona_referencia, GridView gridViewDetalleMod, string numeroDocumento)
        {
            int retorno = 0;
            int conteo = 0;
            string vNumero = "";
            int vIdMov = 0;

            if (gridViewDetalleMod.RowCount > 0)
            {
                using (var db = new Entities())
                {
                    using (var dbTrans = db.Database.BeginTransaction())
                    {
                        try
                        {
                            var queryVenta = db.Venta.Find(id_venta);
                            queryVenta.observacion = observaciones;

                            Devoluciones dev = new Devoluciones();
                            dev.id_venta = id_venta;
                            dev.id_movimiento = 0;
                            dev.activo = true;
                            dev.fecha_registro = DateTime.Now;
                            dev.esEntrada = false;
                            dev.id_venta_nueva = 0;
                            dev.numero_documento = numeroDocumento;
                            db.Devoluciones.Add(dev);
                            db.SaveChanges();

                            Devoluciones devOk = db.Devoluciones.OrderByDescending(x => x.id).FirstOrDefault();
                            int id_dev = devOk.id;

                            for (int i = 0; i < gridViewDetalleMod.RowCount; i++)
                            {
                                DevolucionesDetalle devdet = new DevolucionesDetalle();
                                devdet.id_devolucion = id_dev;
                                devdet.id_bodega = 4;
                                devdet.id_producto = Convert.ToInt32(gridViewDetalleMod.GetRowCellValue(i, "id"));
                                devdet.cantidad = Convert.ToDecimal(gridViewDetalleMod.GetRowCellValue(i, "cantidad"));
                                devdet.precio = Convert.ToDecimal(gridViewDetalleMod.GetRowCellValue(i, "precio"));
                                devdet.total = Convert.ToDecimal(gridViewDetalleMod.GetRowCellValue(i, "total"));
                                devdet.activo = true;
                                devdet.fecha_registro = DateTime.Now;
                                devdet.id_lote = 412;
                                devdet.ubicacion = 0.ToString();
                                devdet.esEntrada = false;
                                db.DevolucionesDetalle.Add(devdet);
                                db.SaveChanges();
                                conteo++;
                            }

                            var movOk = db.Ajustes_Inventario_Insert_Devolucion(13, DateTime.Now, "", observaciones, id_empleado, persona_referencia, 4, 0).FirstOrDefault();
                            if (movOk != null)
                            {
                                vIdMov = movOk.id;
                                vNumero = movOk.numero_documento;

                                var ActualizarMovDevolucion = db.Devoluciones.Find(id_dev);
                                ActualizarMovDevolucion.id_movimiento = movOk.id;
                                db.SaveChanges();

                                int ok = 0;
                                for (int i = 0; i < gridViewDetalleMod.RowCount; i++)
                                {
                                    int id_bodega = 4;
                                    int id_producto = Convert.ToInt32(gridViewDetalleMod.GetRowCellValue(i, "id"));
                                    decimal cantidad = Convert.ToDecimal(gridViewDetalleMod.GetRowCellValue(i, "cantidad"));
                                    decimal precio = Convert.ToDecimal(gridViewDetalleMod.GetRowCellValue(i, "precio"));
                                    decimal total = Convert.ToDecimal(gridViewDetalleMod.GetRowCellValue(i, "total"));
                                    decimal costo = db.Producto.Where(x => x.id == id_producto).Select(x => x.costo).FirstOrDefault().Value;
                                    string ubicacion = "0";
                                    int id_lote = 412;

                                    int detalleOK = db.MovimientoInventarioDetalle_INSERT(vIdMov, id_bodega, id_producto, cantidad, costo, ubicacion, id_lote);
                                    if (detalleOK > 0) ok++;
                                    else break;
                                }

                                if (ok == gridViewDetalleMod.RowCount && conteo == gridViewDetalleMod.RowCount)
                                {
                                    retorno = 1;
                                }

                                if (retorno == 1) { db.SaveChanges(); dbTrans.Commit(); }
                                else { dbTrans.Rollback(); }
                            }
                        }
                        catch (Exception ex)
                        {
                            dbTrans.Rollback();
                            retorno = -1;
                        }
                    }
                }
            }
            return retorno;
        }

        public int DevolucionSalidaProdDañado(int id_venta, string observaciones, int id_empleado, string persona_referencia, GridView gridViewDetalleMod, string numeroDocumento)
        {
            int retorno = 0;
            int conteo = 0;
            string vNumero = "";
            int vIdMov = 0;

            if (gridViewDetalleMod.RowCount > 0)
            {
                using (var db = new Entities())
                {
                    using (var dbTrans = db.Database.BeginTransaction())
                    {
                        try
                        {
                            var queryVenta = db.Venta.Find(id_venta);
                            queryVenta.observacion = observaciones;

                            DevolucionesProductoDañado dev = new DevolucionesProductoDañado();
                            dev.id_venta = id_venta;
                            dev.id_movimiento = 0;
                            dev.activo = true;
                            dev.fecha_registro = DateTime.Now;
                            dev.esEntrada = false;
                            dev.numero_documento = numeroDocumento;
                            db.DevolucionesProductoDañado.Add(dev);
                            db.SaveChanges();

                            DevolucionesProductoDañado devOk = db.DevolucionesProductoDañado.OrderByDescending(x => x.id).FirstOrDefault();
                            int id_dev = devOk.id;

                            for (int i = 0; i < gridViewDetalleMod.RowCount; i++)
                            {
                                DevolucionesProductoDañadoDetalle devdet = new DevolucionesProductoDañadoDetalle();
                                devdet.id_devolucion = id_dev;
                                devdet.id_bodega = 4;
                                devdet.id_producto = Convert.ToInt32(gridViewDetalleMod.GetRowCellValue(i, "id"));
                                devdet.cantidad = Convert.ToDecimal(gridViewDetalleMod.GetRowCellValue(i, "cantidad"));
                                devdet.precio = Convert.ToDecimal(gridViewDetalleMod.GetRowCellValue(i, "precio"));
                                devdet.total = Convert.ToDecimal(gridViewDetalleMod.GetRowCellValue(i, "total"));
                                devdet.activo = true;
                                devdet.fecha_registro = DateTime.Now;
                                devdet.id_lote = 412;
                                devdet.ubicacion = 0.ToString();
                                devdet.esEntrada = false;
                                db.DevolucionesProductoDañadoDetalle.Add(devdet);
                                db.SaveChanges();
                                conteo++;
                            }

                            var movOk = db.Ajustes_Inventario_Insert_Devolucion(15, DateTime.Now, "", observaciones, id_empleado, persona_referencia, 4, 0).FirstOrDefault();
                            if (movOk != null)
                            {
                                vIdMov = movOk.id;
                                vNumero = movOk.numero_documento;

                                var ActualizarMovDevolucion = db.DevolucionesProductoDañado.Find(id_dev);
                                ActualizarMovDevolucion.id_movimiento = movOk.id;
                                db.SaveChanges();

                                int ok = 0;
                                for (int i = 0; i < gridViewDetalleMod.RowCount; i++)
                                {
                                    int id_bodega = 4;
                                    int id_producto = Convert.ToInt32(gridViewDetalleMod.GetRowCellValue(i, "id"));
                                    decimal cantidad = Convert.ToDecimal(gridViewDetalleMod.GetRowCellValue(i, "cantidad"));
                                    decimal precio = Convert.ToDecimal(gridViewDetalleMod.GetRowCellValue(i, "precio"));
                                    decimal total = Convert.ToDecimal(gridViewDetalleMod.GetRowCellValue(i, "total"));
                                    decimal costo = db.Producto.Where(x => x.id == id_producto).Select(x => x.costo).FirstOrDefault().Value;
                                    string ubicacion = "0";
                                    int id_lote = 412;

                                    int detalleOK = db.MovimientoInventarioDetalle_INSERT(vIdMov, id_bodega, id_producto, cantidad, costo, ubicacion, id_lote);
                                    if (detalleOK > 0) ok++;
                                    else break;
                                }

                                if (ok == gridViewDetalleMod.RowCount && conteo == gridViewDetalleMod.RowCount)
                                {
                                    retorno = 1;
                                }

                                if (retorno == 1) { db.SaveChanges(); dbTrans.Commit(); }
                                else { dbTrans.Rollback(); }
                            }
                        }
                        catch (Exception ex)
                        {
                            dbTrans.Rollback();
                            retorno = -1;
                        }
                    }
                }
            }
            return retorno;
        }

        public string RetornarNumeroDocumentoCambioClientes()
        {
            string numero_documento = "";

            using(var db = new Entities())
            {
                using (var dbTrans = db.Database.BeginTransaction())
                {
                    try
                    {
                        var queryConsecutivos = db.Consecutivos.Where(x => x.tipo == 18).FirstOrDefault();
                        int numero = queryConsecutivos.numero + 1;
                        int digitos = Convert.ToString(numero).Length;
                        string documentoDev = "";

                        switch (digitos)
                        {
                            case 1:
                                documentoDev = "CC-000000" + numero;
                                break;
                            case 2:
                                documentoDev = "CC-00000" + numero;
                                break;
                            case 3:
                                documentoDev = "CC-0000" + numero;
                                break;
                            case 4:
                                documentoDev = "CC-000" + numero;
                                break;
                            case 5:
                                documentoDev = "CC-00" + numero;
                                break;
                            case 6:
                                documentoDev = "CC-0" + numero;
                                break;
                            case 7:
                                documentoDev = "CC-" + numero;
                                break;
                        }

                        numero_documento = documentoDev;
                        var queryActualizar = db.Consecutivos.Find(queryConsecutivos.id);
                        queryActualizar.numero = numero;
                        db.SaveChanges();
                        dbTrans.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbTrans.Rollback();
                        numero_documento = "";
                    }
                }
            }

            return numero_documento;
        }

        public string RetornarNumeroDocumentoProductoFallado()
        {
            string numero_documento = "";

            using (var db = new Entities())
            {
                using (var dbTrans = db.Database.BeginTransaction())
                {
                    try
                    {
                        var queryConsecutivos = db.Consecutivos.Where(x => x.tipo == 19).FirstOrDefault();
                        int numero = queryConsecutivos.numero + 1;
                        int digitos = Convert.ToString(numero).Length;
                        string documentoDev = "";

                        switch (digitos)
                        {
                            case 1:
                                documentoDev = "PFC-00000" + numero;
                                break;
                            case 2:
                                documentoDev = "PFC-0000" + numero;
                                break;
                            case 3:
                                documentoDev = "PFC-000" + numero;
                                break;
                            case 4:
                                documentoDev = "PFC-00" + numero;
                                break;
                            case 5:
                                documentoDev = "PFC-0" + numero;
                                break;
                            case 6:
                                documentoDev = "PFC-" + numero;
                                break;
                        }

                        numero_documento = documentoDev;
                        var queryActualizar = db.Consecutivos.Find(queryConsecutivos.id);
                        queryActualizar.numero = numero;
                        db.SaveChanges();
                        dbTrans.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbTrans.Rollback();
                        numero_documento = "";
                    }
                }
            }

            return numero_documento;
        }

        public int DevolucionEntrada(int id_venta, string observaciones, int id_empleado, string persona_referencia, GridView gridViewDetalleMod, string numeroDocumento)
        {
            
            int retorno = 0;
            int conteo = 0;
            string vNumero = "";
            int vIdMov = 0;
            
            if (gridViewDetalleMod.RowCount > 0)
            {
                using (var db = new Entities())
                {
                    using (var dbTrans = db.Database.BeginTransaction())
                    {
                        try
                        {
                            var queryVenta = db.Venta.Find(id_venta);
                            queryVenta.observacion = observaciones;

                            Devoluciones dev = new Devoluciones();
                            dev.id_venta = id_venta;
                            dev.id_movimiento = 0;
                            dev.activo = true;
                            dev.fecha_registro = DateTime.Now;
                            dev.esEntrada = true;
                            dev.id_venta_nueva = 0;
                            dev.numero_documento = numeroDocumento;
                            db.Devoluciones.Add(dev);
                            db.SaveChanges();

                            Devoluciones devOk = db.Devoluciones.OrderByDescending(x => x.id).FirstOrDefault();
                            int id_dev = devOk.id;

                            for (int i = 0; i < gridViewDetalleMod.RowCount; i++)
                            {
                                DevolucionesDetalle devdet = new DevolucionesDetalle();
                                devdet.id_devolucion = id_dev;
                                devdet.id_bodega = 4;
                                devdet.id_producto = Convert.ToInt32(gridViewDetalleMod.GetRowCellValue(i, "id"));
                                devdet.cantidad = Convert.ToDecimal(gridViewDetalleMod.GetRowCellValue(i, "cantidad"));
                                devdet.precio = Convert.ToDecimal(gridViewDetalleMod.GetRowCellValue(i, "precio"));
                                devdet.total = Convert.ToDecimal(gridViewDetalleMod.GetRowCellValue(i, "total"));
                                devdet.activo = true;
                                devdet.fecha_registro = DateTime.Now;
                                devdet.id_lote = 412;
                                devdet.ubicacion = 0.ToString();
                                devdet.esEntrada = true;
                                db.DevolucionesDetalle.Add(devdet);
                                db.SaveChanges();
                                conteo++;
                            }

                            var movOk = db.Ajustes_Inventario_Insert_Devolucion(12, DateTime.Now, "", observaciones, id_empleado, persona_referencia, 4, 0).FirstOrDefault();
                            if (movOk != null)
                            {
                                vIdMov = movOk.id;
                                vNumero = movOk.numero_documento;

                                var ActualizarMovDevolucion = db.Devoluciones.Find(id_dev);
                                ActualizarMovDevolucion.id_movimiento = movOk.id;
                                db.SaveChanges();

                                int ok = 0;
                                for (int i = 0; i < gridViewDetalleMod.RowCount; i++)
                                {
                                    int id_bodega = 4;
                                    int id_producto = Convert.ToInt32(gridViewDetalleMod.GetRowCellValue(i, "id"));
                                    decimal cantidad = Convert.ToDecimal(gridViewDetalleMod.GetRowCellValue(i, "cantidad"));
                                    decimal precio = Convert.ToDecimal(gridViewDetalleMod.GetRowCellValue(i, "precio"));
                                    decimal total = Convert.ToDecimal(gridViewDetalleMod.GetRowCellValue(i, "total"));
                                    decimal costo = db.Producto.Where(x => x.id == id_producto).Select(x => x.costo).FirstOrDefault().Value;
                                    string ubicacion = "0";
                                    int id_lote = 412;

                                    int detalleOK = db.MovimientoInventarioDetalle_INSERT(vIdMov, id_bodega, id_producto, cantidad, costo, ubicacion, id_lote);
                                    if (detalleOK > 0) ok++;
                                    else break;
                                }

                                if (ok == gridViewDetalleMod.RowCount && conteo == gridViewDetalleMod.RowCount)
                                {
                                    retorno = 1;
                                }

                                if (retorno == 1) { db.SaveChanges(); dbTrans.Commit(); }
                                else { dbTrans.Rollback(); }
                            }
                        }
                        catch (Exception ex)
                        {
                            dbTrans.Rollback();
                            retorno = -1;
                        }
                    }
                }
            }
            return retorno;
        }

        public int DevolucionEntradaProdDañado(int id_venta, string observaciones, int id_empleado, string persona_referencia, GridView gridViewDetalleMod, string numeroDocumento)
        {

            int retorno = 0;
            int conteo = 0;
            string vNumero = "";
            int vIdMov = 0;

            if (gridViewDetalleMod.RowCount > 0)
            {
                using (var db = new Entities())
                {
                    using (var dbTrans = db.Database.BeginTransaction())
                    {
                        try
                        {
                            var queryVenta = db.Venta.Find(id_venta);
                            queryVenta.observacion = observaciones;

                            DevolucionesProductoDañado dev = new DevolucionesProductoDañado();
                            dev.id_venta = id_venta;
                            dev.id_movimiento = 0;
                            dev.activo = true;
                            dev.fecha_registro = DateTime.Now;
                            dev.esEntrada = true;
                            dev.numero_documento = numeroDocumento;
                            db.DevolucionesProductoDañado.Add(dev);
                            db.SaveChanges();

                            DevolucionesProductoDañado devOk = db.DevolucionesProductoDañado.OrderByDescending(x => x.id).FirstOrDefault();
                            int id_dev = devOk.id;

                            for (int i = 0; i < gridViewDetalleMod.RowCount; i++)
                            {
                                DevolucionesProductoDañadoDetalle devdet = new DevolucionesProductoDañadoDetalle();
                                devdet.id_devolucion = id_dev;
                                devdet.id_bodega = 8;
                                devdet.id_producto = Convert.ToInt32(gridViewDetalleMod.GetRowCellValue(i, "id"));
                                devdet.cantidad = Convert.ToDecimal(gridViewDetalleMod.GetRowCellValue(i, "cantidad"));
                                devdet.precio = Convert.ToDecimal(gridViewDetalleMod.GetRowCellValue(i, "precio"));
                                devdet.total = Convert.ToDecimal(gridViewDetalleMod.GetRowCellValue(i, "total"));
                                devdet.activo = true;
                                devdet.fecha_registro = DateTime.Now;
                                devdet.id_lote = 412;
                                devdet.ubicacion = 0.ToString();
                                devdet.esEntrada = true;
                                db.DevolucionesProductoDañadoDetalle.Add(devdet);
                                db.SaveChanges();
                                conteo++;
                            }

                            var movOk = db.Ajustes_Inventario_Insert_Devolucion(14, DateTime.Now, "", observaciones, id_empleado, persona_referencia, 4, 0).FirstOrDefault();
                            if (movOk != null)
                            {
                                vIdMov = movOk.id;
                                vNumero = movOk.numero_documento;

                                var ActualizarMovDevolucion = db.DevolucionesProductoDañado.Find(id_dev);
                                ActualizarMovDevolucion.id_movimiento = movOk.id;
                                db.SaveChanges();

                                int ok = 0;
                                for (int i = 0; i < gridViewDetalleMod.RowCount; i++)
                                {
                                    int id_bodega = 8;
                                    int id_producto = Convert.ToInt32(gridViewDetalleMod.GetRowCellValue(i, "id"));
                                    decimal cantidad = Convert.ToDecimal(gridViewDetalleMod.GetRowCellValue(i, "cantidad"));
                                    decimal precio = Convert.ToDecimal(gridViewDetalleMod.GetRowCellValue(i, "precio"));
                                    decimal total = Convert.ToDecimal(gridViewDetalleMod.GetRowCellValue(i, "total"));
                                    decimal costo = db.Producto.Where(x => x.id == id_producto).Select(x => x.costo).FirstOrDefault().Value;
                                    string ubicacion = "0";
                                    int id_lote = 412;

                                    int detalleOK = db.MovimientoInventarioDetalle_INSERT(vIdMov, id_bodega, id_producto, cantidad, costo, ubicacion, id_lote);
                                    if (detalleOK > 0) ok++;
                                    else break;
                                }

                                if (ok == gridViewDetalleMod.RowCount && conteo == gridViewDetalleMod.RowCount)
                                {
                                    retorno = 1;
                                }

                                if (retorno == 1) { db.SaveChanges(); dbTrans.Commit(); }
                                else { dbTrans.Rollback(); }
                            }
                        }
                        catch (Exception ex)
                        {
                            dbTrans.Rollback();
                            retorno = -1;
                        }
                    }
                }
            }
            return retorno;
        }

        public Tuple<bool, int, string> AjusteInventario_Guardar_Autorizacion(int xIdTipoAjuste, DateTime xFecha, string xNumeroReferencia, string xObservacion, int xIdEmpleado, string xPersonaReferencia, int xTipo, int xIdReferencia, DevExpress.XtraGrid.Views.Grid.GridView view, int id_bodega)
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
                        var movOK = db.Ajustes_Inventario_Insert_Autorizacion(xIdTipoAjuste, xFecha, xNumeroReferencia, xObservacion, xIdEmpleado, xPersonaReferencia, xTipo, xIdReferencia).FirstOrDefault();
                        if (movOK != null)
                        {
                            vIdMov = movOK.id;
                            vNumero = movOK.numero_documento;

                            int Ok = 0;
                            for (int i = 0; i < view.RowCount; i++)
                            {
                                int vIdBodega = id_bodega;// Convert.ToInt32(view.GetRowCellValue(i, "id_bodega"));
                                int vIdProducto = Convert.ToInt32(view.GetRowCellValue(i, "id_producto"));
                                decimal vCantidad = Convert.ToDecimal(view.GetRowCellValue(i, "cantidad"));
                                decimal vCosto = db.Producto.Where(x => x.id == vIdProducto).Select(x => x.costo).FirstOrDefault().Value;
                                string vUbicacion = Convert.ToString(view.GetRowCellValue(i, "ubicacion"));/* (db.Kardex.Where(x => x.id_producto == vIdProducto && x.id_bodega == vIdBodega).Select(x => x.ubicacion).FirstOrDefault() != null) ? db.Kardex.Where(x => x.id_producto == vIdProducto && x.id_bodega == vIdBodega).Select(x => x.ubicacion).FirstOrDefault() : "";*/
                                int lote_id = Convert.ToInt32(view.GetRowCellValue(i, "id_lote"));

                                //Console.WriteLine(vIdBodega.ToString(),vIdProducto,vCantidad,vCosto,vUbicacion,lote_id.ToString());
                                int detalleOK = db.MovimientoInventarioDetalle_INSERT_Autorizacion(vIdMov, vIdBodega, vIdProducto, vCantidad, vCosto, vUbicacion, lote_id);
                                if (detalleOK > 0) Ok++;
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
                        XtraMessageBox.Show("Lo sentimos, ocurrio el siguiente error: " + ex, "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        vRetorno = false;
                    }
                }
            }

            return Tuple.Create(vRetorno, vIdMov, vNumero);
        }

        public Tuple<bool, int, string> AjusteInventario_Guardar_Autorizado(int xIdTipoAjuste, DateTime xFecha, string xNumeroReferencia, string xObservacion, int xIdEmpleado, string xPersonaReferencia, int xTipo, int xIdReferencia, DevExpress.XtraGrid.Views.Grid.GridView view, int id_bodega, string xNumeroDoc)
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
                        var queryMv = db.MovimientoInventario_Autorizacion.Where(x => x.numero_documento == xNumeroDoc).FirstOrDefault();
                        var queryMvD = db.MovimientoInventarioDetalle_Autorizacion.Where(x => x.id_movimiento == queryMv.id);
                        var movOK = db.Ajustes_Inventario_Insert(xIdTipoAjuste, xFecha, xNumeroReferencia, xObservacion, xIdEmpleado, xPersonaReferencia, xTipo, xIdReferencia).FirstOrDefault();
                        if (movOK != null)
                        {
                            vIdMov = movOK.id;
                            vNumero = movOK.numero_documento;

                            int Ok = 0;
                            foreach (var list in queryMvD)
                            {
                                int vIdBodega = id_bodega;// Convert.ToInt32(view.GetRowCellValue(i, "id_bodega"));
                                int vIdProducto = list.id_producto;
                                decimal vCantidad = list.cantidad;
                                decimal vCosto = db.Producto.Where(x => x.id == vIdProducto).Select(x => x.costo).FirstOrDefault().Value;
                                string vUbicacion = list.ubicacion;
                                int lote_id = Convert.ToInt32(list.id_lote);

                                //Console.WriteLine(vIdBodega.ToString(),vIdProducto,vCantidad,vCosto,vUbicacion,lote_id.ToString());
                                int detalleOK = db.MovimientoInventarioDetalle_INSERT(vIdMov, vIdBodega, vIdProducto, vCantidad, vCosto, vUbicacion, lote_id);
                                if (detalleOK > 0) Ok++;
                                else break;
                            }

                            if (Ok == queryMvD.Count())
                            {
                                vRetorno = true;

                                MovimientoInventario_Autorizacion mva = db.MovimientoInventario_Autorizacion.Find(queryMv.id);
                                mva.autorizado = true;
                                db.SaveChanges();
                            }

                        }
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

            return Tuple.Create(vRetorno, vIdMov, vNumero);
        }

        public List<Kardex_SELECT_VENTA_Result> Kardex_SelectVenta()
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Kardex_SELECT_VENTA().ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Kardex_SELECT_VENTAEXC_Result> Kardex_SelectVentaEXC()
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Kardex_SELECT_VENTAEXC().ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Kardex_SELECT_VENTAEXC_Devoluciones_Result> Kardex_SelectVentaEXC_Devolucion(int id_venta)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Kardex_SELECT_VENTAEXC_Devoluciones(id_venta).ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<Kardex_SELECTFILA_Result> Kardex_SelectFila(int xIdProducto, int xIdBodega)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Kardex_SELECTFILA(xIdProducto, xIdBodega).ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<Producto_Select_Fila_por_Lote_Result> Producto_Select_Fila_Lote(int id_producto, int id_bodega, int Vid_Lote)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Producto_Select_Fila_por_Lote(id_producto, Vid_Lote, id_bodega).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<Kardex_SELECTFILA_COD_Result> Kardex_SelectFila_COD(string xCodProducto, int xIdBodega)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Kardex_SELECTFILA_COD(xCodProducto, xIdBodega).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public int Kardex_ModificarUbicacion(int xIdProducto, int xIdBodega, string xUbicacion)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Kardex_MODIFICARUBICACION(xIdProducto, xIdBodega, xUbicacion);
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public Tuple<bool, int, string> TrasladoBodega_Guardar(int xBodega1, int xBodega2, DateTime xFecha, string xNumeroReferencia, string xObservacion, int xIdEmpleado, string xPersonaReferencia, DevExpress.XtraGrid.Views.Grid.GridView view_desde, DevExpress.XtraGrid.Views.Grid.GridView view_hasta)
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
                        int vIdAjuste = db.AjustesModulos.Where(x => x.activo == true && x.tipo == 3).FirstOrDefault().id_ajuste; //Ajuste Modulo Traslado=3
                        var movOK = db.MovimientoInventario_INSERT(vIdAjuste, xFecha, xNumeroReferencia, xObservacion, xIdEmpleado, xPersonaReferencia, 3, 0).FirstOrDefault();
                        if (movOK != null)
                        {
                            vIdMov = movOK.id;
                            vNumero = movOK.numero_documento;

                            int Ok_salidas = 0;
                            int Ok_Entrada = 0;
                            for (int i = 0; i < view_desde.RowCount; i++)
                            {
                                int vIdProducto_salida = Convert.ToInt32(view_desde.GetRowCellValue(i, "id_producto"));
                                decimal vCantidad_salida = Convert.ToDecimal(view_desde.GetRowCellValue(i, "cantidad"));
                                decimal vCosto_1 = db.Producto.Where(x => x.id == vIdProducto_salida).Select(x => x.costo).FirstOrDefault().Value;
                                string vUbicacion1 = Convert.ToString(view_desde.GetRowCellValue(i, "ubicacion"));
                                int id_lote_salida = view_desde.GetRowCellValue(i, "id_lote").Equals(DBNull.Value) ? -1 : Convert.ToInt32(view_desde.GetRowCellValue(i, "id_lote"));

                                int detalleOK1 = db.MovimientoInventarioDetalle_INSERT_TRASLADO(vIdMov, xBodega1, vIdProducto_salida, (vCantidad_salida), vCosto_1, vUbicacion1, id_lote_salida);
                                if (detalleOK1 > 0) Ok_salidas++;
                                else break;
                            }
                            for (int i = 0; i < view_hasta.RowCount; i++)
                            {
                                int vIdProducto_entrada = Convert.ToInt32(view_hasta.GetRowCellValue(i, "id"));
                                decimal vCantidad_entrada = Convert.ToDecimal(view_hasta.GetRowCellValue(i, "cantidad_hasta"));
                                decimal vCosto_1 = db.Producto.Where(x => x.id == vIdProducto_entrada).Select(x => x.costo).FirstOrDefault().Value;
                                string vUbicacion2 = Convert.ToString(view_hasta.GetRowCellValue(i, "ubicacion_hasta"));
                                int id_lote_entrada = view_hasta.GetRowCellValue(i, "id_lote_hasta").Equals(DBNull.Value) ? -1 : Convert.ToInt32(view_hasta.GetRowCellValue(i, "id_lote_hasta"));


                                int detalle_entradaOK = db.MovimientoInventarioDetalle_INSERT_TRASLADO_ENTRADA(vIdMov, xBodega2, vIdProducto_entrada, (vCantidad_entrada), vCosto_1, vUbicacion2, id_lote_entrada);
                                if (detalle_entradaOK > 0) Ok_Entrada++;
                                else break;
                            }
                            if (Ok_salidas == view_desde.RowCount && Ok_Entrada == view_hasta.RowCount) vRetorno = true;
                        }
                        if (vRetorno)
                        {
                            db.SaveChanges(); dbTrans.Commit();
                        }
                        else
                        {
                            dbTrans.Rollback();
                        }
                    }
                    catch (Exception ex)
                    {
                        dbTrans.Rollback();
                        XtraMessageBox.Show("Lo sentimos, ocurrio el siguiente error: " + ex.Message, "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        vRetorno = false;
                    }
                }
            }

            return Tuple.Create(vRetorno, vIdMov, vNumero);
        }

        public List<Traslado_REPORTE_Result> Traslado_Reporte(int xId, int xIdBodega)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Traslado_REPORTE(xId, xIdBodega).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Tuple<int, string> Traslado_ObtenerBodega(int xIdMovimiento, int xMenorMayor)
        {
            try
            {
                using (var db = new Entities())
                {
                    var query = db.Traslado_OBTENERBODEGA(xIdMovimiento, xMenorMayor).FirstOrDefault();
                    if (query != null)
                    {
                        return Tuple.Create(query.id_bodega, query.nombre);
                    }
                    else
                    {
                        return Tuple.Create(0, "");
                    }
                }
            }
            catch (Exception)
            {
                return Tuple.Create(0, "");
            }
        }

        #region PROCEDIMIENTOS PARA REPORTES
        public List<Ajuste_REPORTE_Result> Reporte_Ajuste(int id)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Ajuste_REPORTE(id).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Ajuste_REPORTE_Autorizacion_Result> Reporte_Ajuste_Autorizacion(int id)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Ajuste_REPORTE_Autorizacion(id).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<InventarioPorDinero_Result> InventarioPorDinero()
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.InventarioPorDinero().ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<InventarioPorDinero_SELECTBODEGA_Result> InventarioPorDinero_SelectBodega(int xIdBodega)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.InventarioPorDinero_SELECTBODEGA(xIdBodega).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<ListadoProducto_Result> ListadoProducto(decimal xCantidad)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.ListadoProducto(xCantidad).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        //   public List<Consulta_Inventario_Result> Consulta_Inventario( )
        //{
        //    try
        //    {
        //        using(Entities db = new Entities())
        //        {
        //            return db.Consulta_Inventario().ToList();
        //        }
        //    }
        //    catch(Exception ex)
        //    {

        //        throw;
        //    }
        //}
        public DataTable Consulta_Inventario_por_Sub_Grupo(int id_subgrupo)
        {
            Entities db = new Entities();
            using (var cnn = new SqlConnection(db.Database.Connection.ConnectionString))
            {
                var Parametros = new DynamicParameters();
                Parametros.Add("@id_subgrupo", id_subgrupo, DbType.Int32, ParameterDirection.Input);
                cnn.Open();
                var obs = cnn.Query(sql: "INVENTARIO.Consulta_Invetario_Por_SubGrupo", param: Parametros,
                        commandType: CommandType.StoredProcedure);

                var dt = ToDataTable(obs);
                return dt;
            }

        }
        public DataTable Consulta_Inventario_dinamica(bool todo)
        {
            Entities db = new Entities();
            using (var cnn = new SqlConnection(db.Database.Connection.ConnectionString))
            {
                var Parametros = new DynamicParameters();

                cnn.Open();
                if (todo)
                {
                    var obs = cnn.Query(sql: "INVENTARIO.Consulta_Inventario",
                       commandType: CommandType.StoredProcedure);
                    var dt = ToDataTable(obs);
                    return dt;
                }
                else
                {
                    var obs = cnn.Query(sql: "INVENTARIO.Consulta_Inventario_Solo_Tienda",
                      commandType: CommandType.StoredProcedure);
                    var dt = ToDataTable(obs);
                    return dt;
                }
            }
        }

        public DataTable Consulta_Inventario_dinamica_Especial(bool todo)
        {
            Entities db = new Entities();
            using (var cnn = new SqlConnection(db.Database.Connection.ConnectionString))
            {
                var Parametros = new DynamicParameters();

                cnn.Open();
                if (todo)
                {
                    var obs = cnn.Query(sql: "INVENTARIO.Consulta_Inventario_Especial",
                       commandType: CommandType.StoredProcedure);
                    var dt = ToDataTable(obs);
                    return dt;
                }
                else
                {
                    var obs = cnn.Query(sql: "INVENTARIO.Consulta_Inventario_Especial",
                      commandType: CommandType.StoredProcedure);
                    var dt = ToDataTable(obs);
                    return dt;
                }
            }
        }

        private DataTable ToDataTable(IEnumerable<dynamic> items)
        {
            if (items == null) return null;
            var data = items.ToArray();
            if (data.Length == 0) return null;

            var dt = new DataTable();
            foreach (var pair in ((IDictionary<string, object>)data[0]))
            {
                dt.Columns.Add(pair.Key, (pair.Value ?? string.Empty).GetType());
            }
            foreach (var d in data)
            {
                dt.Rows.Add(((IDictionary<string, object>)d).Values.ToArray());
            }
            return dt;
        }

        public List<Ajsutes_Select_Rango_Result> Ajustes_Select_Rango_fechas(DateTime Desde, DateTime Hasta)
        {
            try
            {
                using (Entities db = new Entities())
                {
                    return db.Ajsutes_Select_Rango(Desde.Date, Hasta.Date).ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return null;
            }
        }

        public List<Ajsutes_Select_Rango_Aut_Result> Ajustes_Select_Rango_Aut_fechas(DateTime Desde, DateTime Hasta)
        {
            try
            {
                using (Entities db = new Entities())
                {
                    return db.Ajsutes_Select_Rango_Aut(Desde.Date, Hasta.Date).ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return null;
            }
        }
        public List<Traslados_Select_Rango_Result> Traslados_Select_Rango(DateTime Desde, DateTime Hasta)
        {
            try
            {
                using (Entities db = new Entities())
                {
                    return db.Traslados_Select_Rango(Desde.Date, Hasta.Date).ToList();
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
