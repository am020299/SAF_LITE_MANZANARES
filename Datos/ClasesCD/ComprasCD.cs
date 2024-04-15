using DevExpress.XtraEditors;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Datos.ClasesCD
{
    public class ComprasCD
    {
        public Tuple<bool, int, string> Compra_Guardar(string xNumero, int xIdProveedor, DateTime xFecha, DateTime xFechaEstimada, string xObservacion, DevExpress.XtraGrid.Views.Grid.GridView view)
        {
            bool vRetorno = false;
            string vNumero = "";
            int vIdCompra = 0;
            using (var db = new Entities())
            {
                using (var dbTrans = db.Database.BeginTransaction())
                {
                    try
                    {
                        var compraOK = db.Compra_GUARDAR(xNumero, xIdProveedor, xFecha, xFechaEstimada, xObservacion).FirstOrDefault();
                        if (compraOK != null)
                        {
                            vIdCompra = compraOK.id;
                            vNumero = compraOK.numero_factura;

                            int Ok = 0;
                            for (int i = 0; i < view.RowCount; i++)
                            {
                                int vIdProducto = Convert.ToInt32(view.GetRowCellValue(i, "id"));
                                decimal vCantidad = Convert.ToDecimal(view.GetRowCellValue(i, "cantidad"));
                                decimal vPrecio = Convert.ToDecimal(view.GetRowCellValue(i, "precio_nuevo"));
                                decimal vImpuesto = Convert.ToDecimal(view.GetRowCellValue(i, "impuesto"));
                                decimal vTotal = Convert.ToDecimal(view.GetRowCellValue(i, "total"));
                                int vIdLote = Convert.ToInt32(view.GetRowCellValue(i, "id_lote"));
                                string vUbicacion = Convert.ToString(view.GetRowCellValue(i, "ubicacion"));

                                int detalleOK = db.CompraDetalle_INSERTAR(vIdCompra, vIdProducto, vCantidad, vPrecio, vImpuesto, vTotal, vIdLote, vUbicacion);
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
                        XtraMessageBox.Show("Lo sentimos, ocurrio el siguiente error: " + ex.Message, "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        vRetorno = false;
                    }
                }
            }

            return Tuple.Create(vRetorno, vIdCompra, vNumero);
        }

        public List<Compras_SELECT_PRODUCTO_Result> Compras_Select_PRODUCTO(int id_producto, DateTime fecha_ini, DateTime fecha_fin)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Compras_SELECT_PRODUCTO(id_producto, fecha_ini, fecha_fin).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Compra_Modificar(int xId, string xNumero, int xIdProveedor, DateTime xFecha, DateTime xFechaEstimada, string xObservacion, DevExpress.XtraGrid.Views.Grid.GridView view)
        {
            bool vRetorno = false;
            using (var db = new Entities())
            {
                using (var dbTrans = db.Database.BeginTransaction())
                {
                    try
                    {
                        int compraOK = db.Compra_MODIFICAR(xId, xNumero, xIdProveedor, xFecha, xFechaEstimada, xObservacion);
                        if (compraOK > 0)
                        {
                            int Ok = 0;
                            for (int i = 0; i < view.RowCount; i++)
                            {
                                int vIdProducto = Convert.ToInt32(view.GetRowCellValue(i, "id"));
                                decimal vCantidad = Convert.ToDecimal(view.GetRowCellValue(i, "cantidad"));
                                decimal vPrecio = Convert.ToDecimal(view.GetRowCellValue(i, "precio_nuevo"));
                                decimal vImpuesto = Convert.ToDecimal(view.GetRowCellValue(i, "impuesto"));
                                decimal vTotal = Convert.ToDecimal(view.GetRowCellValue(i, "total"));
                                int vIdLote = Convert.ToInt32(view.GetRowCellValue(i, "id_lote"));
                                string vUbicacion = Convert.ToString(view.GetRowCellValue(i, "ubicacion"));

                                int detalleOK = db.CompraDetalle_INSERTAR(xId, vIdProducto, vCantidad, vPrecio, vImpuesto, vTotal, vIdLote, vUbicacion);
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
                        XtraMessageBox.Show("Lo sentimos, ocurrio el siguiente error: " + ex.Message, "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        vRetorno = false;
                    }
                }
            }

            return vRetorno;
        }

        public List<Compras_SELECT_Result> Compras_Select()
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Compras_SELECT().ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Compras> getCompras()
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Compras.ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataTable  getComprasDetalle(int xIdCompra)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("id", typeof(int));
                dt.Columns.Add("descripcion", typeof(string));
                dt.Columns.Add("cantidad", typeof(decimal));
                dt.Columns.Add("precio1", typeof(decimal));
                dt.Columns.Add("precio_nuevo", typeof(decimal));
                dt.Columns.Add("impuesto", typeof(decimal));
                dt.Columns.Add("id_unidad_medida", typeof(int));
                dt.Columns.Add("id_bodega", typeof(int));
                dt.Columns.Add("ubicacion", typeof(string));
                dt.Columns.Add("id_lote",typeof(int));

                DataRow row = dt.NewRow();

                using (var db = new Entities())
                {
                    var query = db.ComprasDetalle.OrderBy(o=>o.id).Select(x => new { x.id_compra, x.activo, x.Producto.id,x.Producto.Marca.nombre, x.Producto.descripcion, x.cantidad, x.Producto.costo, precio_nuevo = x.precio, x.impuesto, x.Producto.id_unidad_medida,x.id_lote,x.ubicacion}).Where(x => x.id_compra == xIdCompra && x.activo == true).ToList();
                    foreach(var list in query)
                    {
                        row["id"] = list.id;
                        row["descripcion"] =list.descripcion;
                        row["cantidad"] = list.cantidad??0;
                        row["precio1"] = list.costo??0;
                        row["precio_nuevo"] = list.precio_nuevo ?? 0; ;
                        row["impuesto"] = list.impuesto??0;
                        row["id_unidad_medida"] = list.id_unidad_medida;
                        row["id_bodega"] = 0;
                        row["ubicacion"] = list.ubicacion;
                        row["id_lote"] = list.id_lote??0;
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
        public int Compra_Eliminar(int xId, int xIdUsuario)
        {
            try
            {
                using (var db  = new Entities())
                {
                    return db.Compras_ELIMINAR(xId, xIdUsuario);
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public Tuple<bool, int, string> Compra_Recibir(int xIdCompra, int xIdUsuario, bool xActualizarCosto, DateTime xFecha, string xNumeroReferencia, string xObservacion, int xIdEmpleado, string xPersonaReferencia, DevExpress.XtraGrid.Views.Grid.GridView view)
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
                        if (db.Compra_RECIBIR(xIdCompra, xIdUsuario) > 0)
                        {
                            int vIdAjuste = db.AjustesModulos.Where(x => x.activo == true && x.tipo == 1).FirstOrDefault().id_ajuste; //Ajuste Modulo Compra=1
                            if (vIdAjuste > 0)
                            {
                                var movOK = db.MovimientoInventario_INSERT(vIdAjuste, xFecha, xNumeroReferencia, xObservacion, xIdEmpleado, xPersonaReferencia, 1, xIdCompra).FirstOrDefault();
                                if (movOK != null)
                                {
                                    vIdMov = movOK.id;
                                    vNumero = movOK.numero_documento;

                                    int Ok = 0;
                                    for (int i = 0; i < view.RowCount; i++)
                                    {
                                        int vIdBodega = Convert.ToInt32(view.GetRowCellValue(i, "id_bodega"));
                                        int vIdProducto = Convert.ToInt32(view.GetRowCellValue(i, "id"));
                                        decimal vCantidad = Convert.ToDecimal(view.GetRowCellValue(i, "cantidad"));
                                        decimal vCosto = Convert.ToDecimal(view.GetRowCellValue(i, "precio_nuevo"));
                                        int id_lote =Convert.ToInt32(view.GetRowCellValue(i,"id_lote"));//ID_LOTE
                                        if (!xActualizarCosto) vCosto = db.Producto.Where(x => x.id == vIdProducto).Select(x => x.costo).FirstOrDefault().Value;
                                        string vUbicacion = view.GetRowCellValue(i, "ubicacion").Equals(DBNull.Value) ? "" : Convert.ToString(view.GetRowCellValue(i, "ubicacion")).ToUpper().Trim();

                                        int detalleOK = db.MovimientoInventarioDetalle_INSERT(vIdMov, vIdBodega, vIdProducto, vCantidad, vCosto, vUbicacion,id_lote);
                                        if (detalleOK > 0) Ok++;
                                        else break;
                                    }
                                    if (Ok == view.RowCount) vRetorno = true;
                                }
                            }
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

            return Tuple.Create(vRetorno, vIdMov, vNumero);
        }
       public List<Compras_REPORTE_Result> Compras_Reporte(int xId)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Compras_REPORTE(xId).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Compras_REPORTE_PRODUCTO_RECIBIDO_Result> Compras_Reporte_Producto_recibido(int xId)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Compras_REPORTE_PRODUCTO_RECIBIDO(xId).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
