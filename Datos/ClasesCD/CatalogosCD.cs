using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using Entidades;

namespace Datos.ClasesCD
{

    public class CatalogosCD
    {
      
        public DataTable getMoneda()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("moneda");
            dt.Columns.Add("descripcion");
            DataRow row = dt.NewRow();

            row["moneda"] = 1;
            row["descripcion"] = "Cordobas C$";
            dt.Rows.Add(row);
            row = dt.NewRow();

            row["moneda"] = 2;
            row["descripcion"] = "Dolares USD";
            dt.Rows.Add(row);
            row = dt.NewRow();

            return dt;
        }

        public DataTable getBanco()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("banco");
            DataRow row = dt.NewRow();

            row["banco"] = "BANPRO";
            dt.Rows.Add(row);
            row = dt.NewRow();

            row["banco"] = "LAFISE ";
            dt.Rows.Add(row);
            row = dt.NewRow();

            row["banco"] = "BAC";
            dt.Rows.Add(row);
            row = dt.NewRow();

            return dt;
        }

        public DataTable getMonedaCXC()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("moneda");
            dt.Columns.Add("descripcion");
            DataRow row = dt.NewRow();

            row["moneda"] = 0;
            row["descripcion"] = "TODAS";
            dt.Rows.Add(row);
            row = dt.NewRow();

            row["moneda"] = 1;
            row["descripcion"] = "CORDOBAS C$";
            dt.Rows.Add(row);
            row = dt.NewRow();

            row["moneda"] = 2;
            row["descripcion"] = "DOLARES USD";
            dt.Rows.Add(row);
            row = dt.NewRow();

            return dt;
        }

        
        public List<Obtiene_representantes_clientes_Result> Representantes_clientes(int id_cliente)
        {
            try
            {
                using(Entities db= new Entities())
                {
                    return db.Obtiene_representantes_clientes(id_cliente).ToList();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message.ToList());
                return null;
            }
        }
        
        public DataTable getPrecio()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id");
            dt.Columns.Add("descripcion");
            DataRow row = dt.NewRow();

            row["id"] = 1;
            row["descripcion"] = "PUBLICIDAD";
            dt.Rows.Add(row);
            row = dt.NewRow();

            row["id"] = 2;
            row["descripcion"] = "EVENTUAL";
            dt.Rows.Add(row);
            row = dt.NewRow();

            row["id"] = 3;
            row["descripcion"] = "DETALLE";
            dt.Rows.Add(row);
            row = dt.NewRow();

            row["id"] = 4;
            row["descripcion"] = "ESPECIAL A";
            dt.Rows.Add(row);
            row = dt.NewRow();

            row["id"] = 5;
            row["descripcion"] = "ESPECIAL B";
            dt.Rows.Add(row);
            row = dt.NewRow();

            row["id"] = 6;
            row["descripcion"] = "V.I.P";
            dt.Rows.Add(row);
            row = dt.NewRow();

            row["id"] = 7;
            row["descripcion"] = "EMPRESA";
            dt.Rows.Add(row);
            row = dt.NewRow();

            //row["id"] = 8;
            //row["descripcion"] = "LIQUIDACIÓN";
            //dt.Rows.Add(row);
            //row = dt.NewRow();

            //row["id"] = 9;
            //row["descripcion"] = "EVENTUAL ESPECIAL";
            //dt.Rows.Add(row);
            //row = dt.NewRow();

            //row["id"] = 10;
            //row["descripcion"] = "EVENTUAL LIQUIDACIÓN";
            //dt.Rows.Add(row);
            //row = dt.NewRow();

            //row["id"] = 11;
            //row["descripcion"] = "EMPRESA ESPECIAL";
            //dt.Rows.Add(row);
            //row = dt.NewRow();

            return dt;
        }
        public DataTable getPrecio2()//Se quita precio especial para la gente sin permisos
        {
           
            DataTable dt = new DataTable();
            dt.Columns.Add("id");
            dt.Columns.Add("descripcion");
            DataRow row = dt.NewRow();

            row["id"] = 1;
            row["descripcion"] = "PUBLICIDAD";
            dt.Rows.Add(row);
            row = dt.NewRow();

            row["id"] = 2;
            row["descripcion"] = "EVENTUAL";
            dt.Rows.Add(row);
            row = dt.NewRow();

            row["id"] = 3;
            row["descripcion"] = "DETALLE";
            dt.Rows.Add(row);
            row = dt.NewRow();

            //row["id"] = 4;
            //row["descripcion"] = "PRECIO ESPECIAL";
            //dt.Rows.Add(row);
            //row = dt.NewRow();

            //row["id"] = 5;
            //row["descripcion"] = "ESPECIAL B";
            //dt.Rows.Add(row);
            //row = dt.NewRow();

            //row["id"] = 6;
            //row["descripcion"] = "V.I.P";
            //dt.Rows.Add(row);
            //row = dt.NewRow();

            row["id"] = 7;
            row["descripcion"] = "EMPRESA";
            dt.Rows.Add(row);
            row = dt.NewRow();

            //row["id"] = 8;
            //row["descripcion"] = "LIQUIDACIÓN";
            //dt.Rows.Add(row);
            //row = dt.NewRow();

            //row["id"] = 9;
            //row["descripcion"] = "EVENTUAL ESPECIAL";
            //dt.Rows.Add(row);
            //row = dt.NewRow();

            //row["id"] = 10;
            //row["descripcion"] = "EVENTUAL LIQUIDACIÓN";
            //dt.Rows.Add(row);
            //row = dt.NewRow();

            //row["id"] = 11;
            //row["descripcion"] = "EMPRESA ESPECIAL";
            //dt.Rows.Add(row);
            //row = dt.NewRow();

            return dt;
        }

        public int ProductoHabilitar(int idProd, bool habilitado)
        {
            using (var db = new Entities())
            {
                using (var dbTrans = db.Database.BeginTransaction())
                {
                    try
                    {
                        Producto p = db.Producto.Find(idProd);
                        p.habilitado = habilitado;
                        db.SaveChanges();
                        dbTrans.Commit();

                        return 1;
                    }
                    catch (Exception)
                    {
                        dbTrans.Rollback();
                        return -1;
                    }
                }
            }
        }

        public DataTable getTipoAjuste()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id");
            dt.Columns.Add("descripcion");
            DataRow row = dt.NewRow();

            row["id"] = 1;
            row["descripcion"] = "AUMENTA";
            dt.Rows.Add(row);
            row = dt.NewRow();

            row["id"] = 2;
            row["descripcion"] = "DISMINUYE";
            dt.Rows.Add(row);
            row = dt.NewRow();

            return dt;
        }


        #region PRECIOS
        public Tuple<int, bool> Precio_GUARDAR(string xDescripcion, string xObservacion, int xTipo, int xEstado, DateTime xFecha_actualizacion)
        {
            bool vRetorno = false;
            int vIdPrecio = 0;

            using (var db = new Entities())
            {
                using (var dbTrans = db.Database.BeginTransaction())
                {
                    try
                    {
                        var precioOK = db.Precios_Insert(xDescripcion, xObservacion, xTipo, xEstado, xFecha_actualizacion).FirstOrDefault();
                        if (precioOK != null)
                        {
                            vIdPrecio = 0;//precioOK.id;

                            int OKLinea = 0;
                            int OKProducto = 0;

                            var query_precio = db.Precio_detalle_linea.ToList();
                            var query_linea = db.Linea.ToList();
                            var query_productos = db.Producto.ToList();

                            foreach (var linea in query_linea)
                            {
                                int detalle_lineaOK = db.Precio_detalle_linea_INSERT(vIdPrecio, linea.id, 0.00M);

                                if (detalle_lineaOK > 0) OKLinea++;
                                else break;
                            }

                            foreach (var producto in query_productos)
                            {
                                int detalle_productoOK = db.Precio_detalle_productos_INSERT(vIdPrecio, producto.id_linea, producto.id, 0.00M);

                                if (detalle_productoOK > 0) OKProducto++;
                                else break;
                            }

                            if (query_linea.Count == OKLinea && query_productos.Count == OKProducto) vRetorno = true;

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
            return Tuple.Create(vIdPrecio, vRetorno);
        }

        public List<Precios_Catalogos_SELECT_Result> Get_Precios()
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Precios_Catalogos_SELECT().ToList();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error al cargar los precios, comunicarse con soporte técnico: " + ex);
                return null;
            }
        }

        public List<Precio_Select_Por_Linea_Result> Get_precio_linea(int xId_linea)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Precio_Select_Por_Linea(xId_linea).ToList();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error al cargar los precios, comunicarse con soporte técnico: " + ex);
                return null;
            }
        }

        public List<Precio_Select_Por_Producto_Result> Get_precio_producto(int xId_producto)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Precio_Select_Por_Producto(xId_producto).ToList();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error al cargar los precios, comunicarse con soporte técnico: " + ex);
                return null;
            }
        }

        public int Precio_Actualizar(int xId, string xDescripcion, string xObservacion, DateTime xFecha_actualizacion)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Precios_Actualizar(xId, xDescripcion, xObservacion, xFecha_actualizacion);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error al actualizar un precio, comunicarse con soporte técnico: " + ex);
                return 0;
            }
        }

        public int Precio_Eliminar(int xId)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Precio_Eliminar(xId);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error al eliminar un precio, comunicarse con soporte técnico: " + ex);
                return 0;
            }
        }

        public List<Precio_detalle_linea_SELECT_Result> Precio_Detalle_linea_SELECT()
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Precio_detalle_linea_SELECT().ToList();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error al consultar precio detalle de linea, comunicarse con soporte técnico: " + ex);
                return null;
            }
        }

        public List<Precio_detalle_productos_SELECT_Result> Precio_Detalle_productos_SELECT()
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Precio_detalle_productos_SELECT().ToList();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error al consultar precio detalle de linea, comunicarse con soporte técnico: " + ex);
                return null;
            }
        }

        public int Actualiza_Precio_Linea(GridView view)
        {
            int OK = 0;
            using (var db = new Entities())
            {
                using (var dbTrans = db.Database.BeginTransaction())
                {
                    try
                    {                        
                        for (int i = 0; i < view.RowCount; i++)
                        {
                            int id_precio = Convert.ToInt32(view.GetRowCellValue(i, "id_precio") ?? 0);
                            int id_linea = Convert.ToInt32(view.GetRowCellValue(i, "id_linea") ?? 0);
                            decimal monto = Convert.ToDecimal(view.GetRowCellValue(i, "monto") ?? 0);

                            int okUpdate = db.Precio_Linea_ACTUALIZAR(id_precio, id_linea, monto);

                            if (okUpdate > 0) OK++;
                            else break;
                        }

                        if (OK == view.RowCount) { db.SaveChanges(); dbTrans.Commit(); }
                    }
                    catch (Exception ex)
                    {
                        dbTrans.Rollback();
                        XtraMessageBox.Show("Lo sentimos, ocurrio el siguiente error: " + ex.GetBaseException().Message, "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            return OK;
        }

        public int Actualiza_Precio_Producto(GridView view)
        {
            int OK = 0;
            using (var db = new Entities())
            {
                using (var dbTrans = db.Database.BeginTransaction())
                {
                    try
                    {
                        for (int i = 0; i < view.RowCount; i++)
                        {
                            int id_precio = Convert.ToInt32(view.GetRowCellValue(i, "id_precio") ?? 0);
                            int id_linea = Convert.ToInt32(view.GetRowCellValue(i, "id_linea") ?? 0);
                            int id_producto = Convert.ToInt32(view.GetRowCellValue(i, "id_producto") ?? 0);
                            decimal monto = Convert.ToDecimal(view.GetRowCellValue(i, "monto") ?? 0);

                            int okUpdate = db.Precio_Producto_ACTUALIZAR(id_precio, id_linea, id_producto, monto);

                            if (okUpdate > 0) OK++;
                            else break;
                        }

                        if (OK == view.RowCount) { db.SaveChanges(); dbTrans.Commit(); }
                    }
                    catch (Exception ex)
                    {
                        dbTrans.Rollback();
                        XtraMessageBox.Show("Lo sentimos, ocurrio el siguiente error: " + ex.GetBaseException().Message, "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            return OK;
        }


        #endregion

        #region CLIENTES
        public List<Cliente> getCliente()
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Cliente.ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Cliente_Cargar_Result> Cliente_Cargar()
        {
            try
            {
                using (var db = new Entities())
                {
                    ///db.Cliente_Actualiza_Precio_sistema();
                    return db.Cliente_Cargar().ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Cliente_Cargar_Historico_Result> Cliente_Cargar_Historico()
        {
            try
            {
                using (var db = new Entities())
                {
                    ///db.Cliente_Actualiza_Precio_sistema();
                    return db.Cliente_Cargar_Historico().ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Cliente_Cargar_Historico_C__Result> Cliente_Cargar_Historico_C()
        {
            try
            {
                using (var db = new Entities())
                {
                    ///db.Cliente_Actualiza_Precio_sistema();
                    return db.Cliente_Cargar_Historico_C_().ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<RPTCliente_Nuevo_Result> RPTCliente_Cargar(DateTime FechaIni, DateTime FechaFin)
        {
            try
            {
                using (var db = new Entities())
                {
                    ///db.Cliente_Actualiza_Precio_sistema();
                    return db.RPTCliente_Nuevo(FechaIni, FechaFin).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<FacturasConRetenciones_Result> FacturasConRetenciones(DateTime FechaIni, DateTime FechaFin)
        {
            try
            {
                using (var db = new Entities())
                {
                    ///db.Cliente_Actualiza_Precio_sistema();
                    return db.FacturasConRetenciones(FechaIni, FechaFin).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<CANTIDAD_BILLETES_ARQUEO_Result> RPTDenominaciones_Billetes(DateTime FechaIni, DateTime FechaFin)
        {
            try
            {
                using (var db = new Entities())
                {
                    ///db.Cliente_Actualiza_Precio_sistema();
                    return db.CANTIDAD_BILLETES_ARQUEO(FechaIni, FechaFin).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        //public List<CANTIDAD_BILLETES_ARQUEO_1000_500_Result> RPTDenominaciones_Billetes_1000_500(DateTime FechaIni, DateTime FechaFin)
        //{
        //    try
        //    {
        //        using (var db = new Entities())
        //        {
        //            ///db.Cliente_Actualiza_Precio_sistema();
        //            return db.CANTIDAD_BILLETES_ARQUEO_1000_500(FechaIni, FechaFin).ToList();
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }
        //}

        //public List<CANTIDAD_BILLETES_ARQUEO_200_100_50_20_10_Result> RPTDenominaciones_Billetes_200_100_50_20_10(DateTime FechaIni, DateTime FechaFin)
        //{
        //    try
        //    {
        //        using (var db = new Entities())
        //        {
        //            ///db.Cliente_Actualiza_Precio_sistema();
        //            return db.CANTIDAD_BILLETES_ARQUEO_200_100_50_20_10(FechaIni, FechaFin).ToList();
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }
        //}

        //public List<CANTIDAD_BILLETES_ARQUEO_100_50_Dol_Result> RPTDenominaciones_Billetes_100_50_Dol(DateTime FechaIni, DateTime FechaFin)
        //{
        //    try
        //    {
        //        using (var db = new Entities())
        //        {
        //            ///db.Cliente_Actualiza_Precio_sistema();
        //            return db.CANTIDAD_BILLETES_ARQUEO_100_50_Dol(FechaIni, FechaFin).ToList();
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }
        //}

        //public List<CANTIDAD_BILLETES_ARQUEO_20_10_5_1_Dol_Result> RPTDenominaciones_Billetes_20_10_5_1_Dol(DateTime FechaIni, DateTime FechaFin)
        //{
        //    try
        //    {
        //        using (var db = new Entities())
        //        {
        //            ///db.Cliente_Actualiza_Precio_sistema();
        //            return db.CANTIDAD_BILLETES_ARQUEO_20_10_5_1_Dol(FechaIni, FechaFin).ToList();
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }
        //}
        public List<Reporte_Autorizacion_Result> RPTAutorizacion(DateTime FechaIni, DateTime FechaFin, int idEmpleado)
        {
            try
            {
                using (var db = new Entities())
                {
                    ///db.Cliente_Actualiza_Precio_sistema();
                    return db.Reporte_Autorizacion(FechaIni, FechaFin, idEmpleado).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        public List<Representantes> Representantes_cargar( )
        {
            try
            {
                using(var db = new Entities())
                {
                    return db.Representantes.ToList();
                }
            }
            catch(Exception)
            {
                return null;
            }
        }

        public List<Cliente_SELECTFILA_Result> Cliente_SelectFila(int xId)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Cliente_SELECTFILA(xId).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public int Cliente_Guardar(string xCodigo, string xRuc, string xNombre, string xTelefono, string xCelular, string xDireccion, string xCorreo, int xid_sector, int xPrecio,string repre1 ,string repre2,string  repre3,string cedula1,string cedula2, string cedula3,int usuario_creador, byte[] xImagen_doc_cliete, string departamento, bool esMercado)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Cliente_Guardar(xCodigo, xRuc, xNombre, xTelefono, xCelular, xDireccion, xCorreo, xid_sector, xPrecio,0,0,0,0,usuario_creador,repre1,cedula1,repre2,cedula2,repre3,cedula3, xImagen_doc_cliete, departamento, esMercado);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error al guardar un cliente, comunicarse con soporte técnico: " + ex);
                return 0;
            }
        }

        public int Cliente_Actualizar(int xId, string xCodigo, string xRuc, string xNombre, string xTelefono, string xCelular, string xDireccion, string xCorreo, int xid_sector, int xPrecio, int xUsuario, int id_repre,int id_repre2,int id_repre3, int id_repre4,int Autorizador,string repre1,string repre2,string repre3,string cedula1,string cedula2,string cedula3, byte[] xImagen_doc_cliete, string departamento, bool esMercado)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Cliente_Actualizar(xId, xCodigo, xRuc, xNombre, xTelefono, xCelular, xDireccion, xCorreo, xid_sector, xPrecio, xUsuario,id_repre,id_repre2,id_repre3,id_repre4,Autorizador,repre1,cedula1,repre2,cedula2,repre3,cedula3, xImagen_doc_cliete, departamento, esMercado);
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int Cliente_Eliminar(int xId, int xUsuario)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Cliente_Eliminar(xId, xUsuario);
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        #endregion
        #region SECTORES
        public List<Sectores_Cargar_Result> Sectores_cargar()
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Sectores_Cargar().ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public int Representantes_Insert(string Nombre_rep,string correo, string direccion, string celular,string Cedula)
        {
            try
            {
                using (var db = new Entities())
                {
                    Representantes r = new Representantes();
                    r.nombre_rep = Nombre_rep.ToUpper();
                    r.celular = celular;
                    r.correo = correo;
                    r.direccion = direccion;
                    r.cedula = Cedula;
                    db.Representantes.Add(r);
                    return db.SaveChanges();

                }
            }
            catch(DbEntityValidationException e)
            {
               return 0;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public int Rep_update(string Nombre_rep,string correo,string direccion,string celular,int id_rep,string Cedula)
        {
            try
            {
                using (Entities db = new Entities())
                {

                    Representantes r=db.Representantes.Where(R=>R.id_representante==id_rep).FirstOrDefault();
                    r.nombre_rep = Nombre_rep.ToUpper();
                    r.celular = celular;
                    r.correo = correo;
                    r.direccion = direccion;
                    r.cedula = Cedula.ToUpper().Trim();
                    db.Representantes.Add(r);
                    db.Entry(r).State = System.Data.Entity.EntityState.Modified;
                    return db.SaveChanges();
                }
            }
            catch (Exception)
            {

                return 0;
            }
        }

        public int Sectores_Eliminar(int id_sector, int id_usuario)
        {
            try
            {
                using (Entities db = new Entities())
                {

                    return db.Sectores_Eliminar(id_sector, id_usuario);
                }
            }
            catch (Exception)
            {

                return 0;
            }
        }
        #endregion

        #region CATEGORIA
        public List<Categoria> getCategoria()
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Categoria.ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Categoria_CARGAR_Result> Categoria_Cargar()
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Categoria_CARGAR().ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public int Categoria_Guardar(string xNombre, byte[] xImagen,string xCodigo)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Categoria_GUARDAR(xNombre, xImagen,xCodigo);
                }
            }
            catch (Exception)
            {

                return 0;
            }
        }

        public int Categoria_Actualizar(int xId, string xNombre, byte[] xImagen, int xUsuario)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Categoria_ACTUALIZAR(xId, xNombre, xImagen, xUsuario);
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int Categoria_Eliminar(int xId, int xUsuario)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Categoria_ELIMINAR(xId, xUsuario);
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        #endregion

        #region MARCA
        public List<Marca> getMarca()
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Marca.ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Marca_CARGAR_Result> Marca_Cargar()
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Marca_CARGAR().ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public int Marca_Guardar(string xNombre, byte[] xImagen)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Marca_GUARDAR(xNombre, xImagen);
                }
            }
            catch (Exception)
            {

                return 0;
            }
        }

        public int Marca_Actualizar(int xId, string xNombre, byte[] xImagen, int xUsuario)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Marca_ACTUALIZAR(xId, xNombre, xImagen, xUsuario);
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int Marca_Eliminar(int xId, int xUsuario)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Marca_ELIMINAR(xId, xUsuario);
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        #endregion

        #region LINEA
        public List<Linea> getLinea()
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Linea.ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Lotes_Cargar_Result> CargarLotes()
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Lotes_Cargar().ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Linea_CARGAR_Result> Linea_Cargar()
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Linea_CARGAR().ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public int Linea_Guardar(string xNombre,int id_grupo, decimal precio_mmayor, decimal precio_eventual, decimal precio_unitario, decimal xPrecio4, decimal xPrecio5, decimal xPrecio6,decimal xPrecio7, decimal xPrecio8, decimal xPrecio9, decimal xPrecio10, decimal xPrecio11, decimal xPrecio12, decimal xPrecio13, string codigo, int moneda, string descripcion, decimal costo,bool permiteEdicion)
        {
            int vId_linea = 0;
            using (var db = new Entities())
            {
                using (var dbTrans = db.Database.BeginTransaction())
                {
                    try
                    {
                        var lineaOK = db.Linea_GUARDAR(xNombre, id_grupo, precio_mmayor, precio_eventual, precio_unitario, xPrecio4, xPrecio5, xPrecio6,xPrecio7, xPrecio8, xPrecio9, xPrecio10, xPrecio11, xPrecio12, xPrecio13,codigo, moneda, descripcion, permiteEdicion).FirstOrDefault();
                        vId_linea = lineaOK.id;

                        if (lineaOK != null)
                        {
                            var query_precios = db.Precios.ToList();
                            foreach (var p in query_precios)
                            {
                                int okGuardarPrecios = db.Precio_detalle_linea_INSERT(p.id, vId_linea, 0.00M);
                            }
                        }
                        if (vId_linea > 0) { db.SaveChanges(); dbTrans.Commit(); }
                        else { dbTrans.Rollback(); }
                    }
                    catch (Exception ex)
                    {
                        dbTrans.Rollback();
                        XtraMessageBox.Show("Lo sentimos, ocurrio el siguiente error: " + ex.GetBaseException().Message, "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return 0;
                    }
                }
            }
            return vId_linea;
        }

        public int Linea_Actualizar(int xId, string xNombre, int xUsuario,int id_grupo,decimal precio_mmayor,decimal precio_eventual,decimal precio_unitario,decimal xPrecio4, decimal xPrecio5, decimal xPrecio6, decimal xPrecio7, decimal xPrecio8, decimal xPrecio9, decimal xPrecio10, decimal xPrecio11, decimal xPrecio12, decimal xPrecio13, string codigo, int moneda, string descripcion, decimal costo, bool permiteEdicion)
        {
            try
            {
                int vcodigo = Convert.ToInt32(codigo);
                string xcodigo = Convert.ToString(vcodigo);

                using (var db = new Entities())
                {
                    return db.Linea_ACTUALIZAR(xId, xNombre, xUsuario, id_grupo, precio_mmayor, precio_eventual, precio_unitario, xPrecio4, xPrecio5, xPrecio6, xPrecio7, xPrecio8, xPrecio9, xPrecio10, xPrecio11, xPrecio12, xPrecio13,xcodigo, moneda, descripcion, permiteEdicion);
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int Linea_Eliminar(int xId, int xUsuario)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Linea_ELIMINAR(xId, xUsuario);
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        #endregion

        #region UNIDAD DE MEDIDA
        public List<UnidadMedida> getUnidadMedida()
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.UnidadMedida.ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<UnidadMedida_CARGAR_Result> UnidadMedida_Cargar()
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.UnidadMedida_CARGAR().ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public int UnidadMedida_Guardar(string xDescripcion, string xSimbolo)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.UnidadMedida_GUARDAR(xDescripcion, xSimbolo);
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int UnidadMedida_Actualizar(int xId, string xDescripcion, string xSimbolo, int xUsuario)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.UnidadMedida_ACTUALIZAR(xId, xDescripcion, xSimbolo, xUsuario);
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int UnidadMedida_Eliminar(int xId, int xUsuario)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.UnidadMedida_ELIMINAR(xId, xUsuario);
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        #endregion

        #region PRODUCTO

        public List<Producto_CARGAR_Result> Producto_Cargar()
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Producto_CARGAR().ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public int CambiarCostoProductos(int idProducto, decimal costo)
        {
            using (var db = new Entities())
            {
                using (var dbTrans = db.Database.BeginTransaction())
                {
                    try
                    {
                        Producto p = db.Producto.Find(idProducto);
                        p.costo = costo;
                        db.SaveChanges();
                        dbTrans.Commit();

                        return 1;
                    }
                    catch (Exception)
                    {
                        dbTrans.Rollback();
                        return -1;
                    }
                }
            }
            
        }

        public List<Producto_CARGAR_CORDOBAS_Result> Producto_Cargar_Cordobas()
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Producto_CARGAR_CORDOBAS().ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        //public List<Producto_CARGAR_Dolares_Result> Producto_Cargar_Dolares()
        //{
        //    try
        //    {
        //        using (var db = new Entities())
        //        {
        //            return db.Producto_CARGAR_Dolares().ToList();
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }
        //}

        public List<Producto_CARGAR_SUBGRUPO_Result> Producto_Cargar_Sub(int id_subante)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Producto_CARGAR_SUBGRUPO(id_subante).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Producto_CARGAR_FILA_Result> Producto_Cargar_Fila(int xId)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Producto_CARGAR_FILA(xId).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public int Producto_Guardar(string xCodigo, string xDescripcion, int xIdCategoria, int xIdMarca, int xIdLinea, int xIdUnidadMedida, int xMoneda, decimal xCosto, decimal xUtilidad, decimal xPrecio1, decimal xPrecio2, decimal xPrecio3, decimal xPrecio4, decimal xPrecio5, decimal xPrecio6, decimal xPrecio7, decimal xPrecio8, decimal xPrecio9, decimal xPrecio10, decimal xPrecio11, decimal xPrecio12, decimal xPrecio13,decimal xDescuento, decimal xImpuesto, decimal xStock, decimal xStockMinimo, byte[] xImagen, string xNumeroSerie, bool tipo, bool habilitado)
        {
            int vId_producto = 0;
            using (var db = new Entities())
            {
                using (var dbTrans = db.Database.BeginTransaction())
                {
                    try
                    {
                        var productoOK = db.Producto_GUARDAR(xCodigo, xDescripcion, xIdCategoria, xIdMarca, xIdLinea, xIdUnidadMedida, xMoneda, xCosto, xUtilidad, xPrecio1, xPrecio2, xPrecio3, xPrecio4, xPrecio5, xPrecio6, xPrecio7, xPrecio8, xPrecio9, xPrecio10, xPrecio11, xPrecio12, xPrecio13,xDescuento, xImpuesto, xStock, xStockMinimo, xImagen, xNumeroSerie, tipo, habilitado).FirstOrDefault();
                        vId_producto = productoOK.id;

                        if (productoOK != null)
                        {
                            var query_precios_linea = db.Precio_Select_Por_Linea(xIdLinea).ToList();

                            foreach (var p in query_precios_linea)
                            {
                                int okGuardar = db.Precio_detalle_productos_INSERT(p.id_precio, p.id_linea, vId_producto, p.monto);
                            }
                        }
                        
                        if (vId_producto > 0) { db.SaveChanges(); dbTrans.Commit(); }
                        else { dbTrans.Rollback(); }

                    }
                    catch (Exception ex)
                    {
                        dbTrans.Rollback();
                        XtraMessageBox.Show("Lo sentimos, ocurrio el siguiente error: " + ex.GetBaseException().Message, "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return 0;
                    }
                }
            }
            return vId_producto;
        }
        public int Importar_Productos(string xCodigo, string xDescripcion, string xIdCategoria, string xIdMarca, string xIdLinea, string xIdUnidadMedida, string moneda,  decimal xCosto, decimal xPrecio1, decimal xPrecio2, decimal xPrecio3, decimal xPrecio4, decimal xPrecio5, decimal xPrecio6, decimal xPrecio7, decimal xPrecio8, decimal xDescuento, decimal xImpuesto, decimal xStock, decimal xStockMinimo,  string xNumeroSerie,int numero, string lote, string ubicacion,string codigo_grupo,string xCodigo_subgrupo,string numero_factura, int id_proveedor,DateTime Fecha_Compra,string observaciones)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Importar_productos(xCodigo, xDescripcion, xIdCategoria, xIdMarca, xIdLinea, xIdUnidadMedida,moneda, xCosto, 0, xPrecio1, xPrecio2, xPrecio3, xPrecio4, xPrecio5, xPrecio6, xPrecio7, xPrecio8, xDescuento, xImpuesto, xStock, xStockMinimo,  xNumeroSerie,numero,lote,ubicacion,codigo_grupo,xCodigo_subgrupo,numero_factura,Fecha_Compra,id_proveedor,observaciones).FirstOrDefault().Value;
                }
            }
            catch (Exception exception)
            {
                return 0;
            }
        }

        public List<CODIGO_PROD_CARGAR_FILA_Result> Producto_Codigo_Cargar_Fila(string codigo)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.CODIGO_PROD_CARGAR_FILA(codigo).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public int Importar_Productos_catalogo(string xCodigo,string xDescripcion,string xIdCategoria,string xIdMarca,string xIdLinea,string xIdUnidadMedida,string moneda,decimal xCosto,decimal xPrecio1,decimal xPrecio2,decimal xPrecio3,decimal xPrecio4, decimal xPrecio5, decimal xPrecio6, decimal xPrecio7, decimal xPrecio8, decimal xDescuento,decimal xImpuesto,decimal xStock,decimal xStockMinimo,string xNumeroSerie,int numero,string lote,string ubicacion,string codigo_grupo,string xCodigo_subgrupo)
        {
            try
            {
                using(var db = new Entities())
                {
                   return Convert.ToInt32(db.Importar_productos_catalogo(xCodigo, xDescripcion, xIdCategoria, xIdMarca, xIdLinea, xIdUnidadMedida, moneda, xCosto, 0, xPrecio1, xPrecio2, xPrecio3, xPrecio4, xPrecio5, xPrecio6, xPrecio7, xPrecio8, xDescuento, xImpuesto, xStock, xStockMinimo, xNumeroSerie, numero, lote, ubicacion, codigo_grupo, xCodigo_subgrupo));
                }
            }
            catch(Exception ex)
            {
                return 0;
            }
        }
        public int proximo_numero_orden()
        {
            try
            {
                using (var db = new Entities())
                {
                    return Convert.ToInt32(db.Compras.Max(o=>o.numero)) +1;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public int Producto_Actualizar(int xId, string xCodigo, string xDescripcion, int xIdCategoria, int xIdMarca, int xIdLinea, int xIdUnidadMedida, int xMoneda, decimal xCosto, decimal xUtilidad, decimal xPrecio1, decimal xPrecio2, decimal xPrecio3, decimal xPrecio4, decimal xPrecio5, decimal xPrecio6, decimal xPrecio7, decimal xPrecio8, decimal xPrecio9, decimal xPrecio10, decimal xPrecio11, decimal xPrecio12, decimal xPrecio13,decimal xDescuento, decimal xImpuesto, decimal xStockMinimo, byte[] xImagen, string xNumeroSerie, int xUsuario, bool tipo, bool habilitado)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Producto_ACTUALIZAR(xId, xCodigo, xDescripcion, xIdCategoria, xIdMarca, xIdLinea, xIdUnidadMedida, xMoneda, xCosto, xUtilidad, xPrecio1, xPrecio2, xPrecio3, xPrecio4, xPrecio5, xPrecio6, xPrecio7, xPrecio8, xPrecio9, xPrecio10, xPrecio11, xPrecio12, xPrecio13,xDescuento, xImpuesto, xStockMinimo, xImagen, xNumeroSerie, xUsuario, tipo, habilitado);
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int Producto_Actualizar_SubGrupo(int xId, string xCodigo, string xDescripcion, int xIdCategoria, int xIdMarca, int xIdLinea, int xIdLineaAnterior, int xIdUnidadMedida, int xMoneda, decimal xCosto, decimal xUtilidad, decimal xPrecio1, decimal xPrecio2, decimal xPrecio3, decimal xPrecio4, decimal xPrecio5, decimal xPrecio6, decimal xPrecio7, decimal xPrecio8, decimal xPrecio9, decimal xPrecio10, decimal xPrecio11, decimal xPrecio12, decimal xPrecio13,decimal xDescuento, decimal xImpuesto, decimal xStockMinimo, byte[] xImagen, string xNumeroSerie, int xUsuario, bool tipo)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Producto_ACTUALIZAR_SUBGRUPO(xId, xCodigo, xDescripcion, xIdCategoria, xIdMarca, xIdLinea,xIdLineaAnterior, xIdUnidadMedida, xMoneda, xCosto, xUtilidad, xPrecio1, xPrecio2, xPrecio3, xPrecio4, xPrecio5, xPrecio6, xPrecio7, xPrecio8, xPrecio9, xPrecio10, xPrecio11, xPrecio12, xPrecio13,xDescuento, xImpuesto, xStockMinimo, xImagen, xNumeroSerie, xUsuario, tipo);
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int Producto_Eliminar(int xId, int xUsuario)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Producto_ELIMINAR(xId, xUsuario);
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        #endregion

        #region BODEGA
        public List<Bodega> getBodega()
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Bodega.ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Bodega_CARGAR_Result> Bodega_Cargar()
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Bodega_CARGAR().ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public int Bodega_Guardar(string xNombre, string xEncargado, string xDireccion, string xTelefono)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Bodega_GUARDAR(xNombre, xEncargado, xDireccion, xTelefono);
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int Bodega_Actualizar(int xId, string xNombre, string xEncargado, string xDireccion, string xTelefono, int xUsuario)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Bodega_ACTUALIZAR(xId, xNombre, xEncargado, xDireccion, xTelefono, xUsuario);
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int Bodega_Eliminar(int xId, int xUsuario)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Bodega_ELIMINAR(xId, xUsuario);
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public List<TiposAjustes> getTiposAjustes()
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.TiposAjustes.ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<TiposAjustes_SELECT_Result> TiposAjuste_Select()
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.TiposAjustes_SELECT().ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public int TiposAjustes_Guardar(string xDescripcion, string xDescripcionCorta,int xTipo, int xIdTipoDocumento)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.TiposAjustes_GUARDAR(xDescripcion, xDescripcionCorta, xTipo, xIdTipoDocumento);
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int TiposAjustes_Modificar(int xId, string xDescripcion, string xDescripcionCorta, int xTipo, int xIdTipoDocumento, int xIdUsuario)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.TiposAjustes_MODIFICAR(xId, xDescripcion, xDescripcionCorta, xTipo, xIdTipoDocumento, xIdUsuario);
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int TiposAjustes_Eliminar(int xId, int xIdUsuario)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.TiposAjustes_ELIMINAR(xId, xIdUsuario);
                }
            }
            catch (Exception)
            {
                return 0;
            }

        }

        public List<TiposAjustes> TipoAjuste()
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.TiposAjustes.Where(x => x.activo == true && !(x.AjustesModulos.Where(y => y.activo == true).Select(y => y.id_ajuste).Contains(x.id))).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        #endregion

        #region EMPLEADO

        public  List<Empleado> getEmpleado()
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Empleado.ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Empleado_Cargar_Result> Empleado_Cargar()
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Empleado_Cargar().ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Empleado_Cargar_Arqueo_Result> Empleado_Cargar_Arqueo()
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Empleado_Cargar_Arqueo().ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public int Empleado_Guardar(string xNombre, string xCodigoEmpleado, string xCedula, string xCargo, string xUsuario, string xClave, string xCelular, string xCorreo, string xDireccion, byte[] xFoto)
        {
            try
            {
                using (var db = new Entities())
                {
                    var x= db.Empleado_Guardar(xNombre, xCodigoEmpleado,xCedula, xCargo, xUsuario, xClave, xDireccion, xCelular, xCorreo, xFoto).FirstOrDefault();
                    return Convert.ToInt32(x.id);
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int Empleado_Actualizar(int xId, string xNombre, string xCodigoEmpleado, string xCedula, string xCargo, string xUsuario, string xClave, string xCelular, string xCorreo, string xDireccion, byte[] xFoto,int xIdUsuario)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Empleado_Actualizar(xId, xCodigoEmpleado, xNombre, xCedula, xCargo, xUsuario, xClave, xDireccion, xCelular, xCorreo, xFoto, xIdUsuario);
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int Empleado_Eliminar(int xId, int xUsuario)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Empleado_Eliminar(xId, xUsuario);
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        #endregion

        #region PROVEEDORES

        public List<Proveedores> getProveedores()
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Proveedores.ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }

        }

        public List<Proveedores_Select_Result> Proveedores_Select()
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Proveedores_Select().ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public int Proveedores_Guardar(string xNombre, string xDireccion, string xTelefono, string xRuc, string xCorreo, string xDepartamento, string xCiudad, string xPais, string xContacto, string xTelefonoContacto, string xCorreoContacto, decimal xCreditoMaximo)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Proveedores_Guardar(xNombre, xDireccion, xTelefono, xRuc, xCorreo, xDepartamento, xCiudad, xPais, xContacto, xTelefonoContacto, xCorreoContacto, xCreditoMaximo);
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int Proveedores_Modificar(int xId, string xNombre, string xDireccion, string xTelefono, string xRuc, string xCorreo, string xDepartamento, string xCiudad, string xPais, string xContacto, string xTelefonoContacto, string xCorreoContacto, decimal xCreditoMaximo, int xIdUsuario)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Proveedores_Modificar(xId, xNombre, xDireccion, xTelefono, xRuc, xCorreo, xDepartamento, xCiudad, xPais, xContacto, xTelefonoContacto, xCorreoContacto, xCreditoMaximo, xIdUsuario);
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int Proveedores_Eliminar(int xId, int xIdUsuario)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Proveedores_Eliminar(xId, xIdUsuario);
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        #endregion
        #region LOTES
        public List<Lotes> Lotes_Cargar( )
        {
            try
            {
                using(Entities db= new Entities())
                {
                    return db.Lotes.Where(C=>C.estado!=0).OrderBy(c=> c.fecha_lote).ToList();
                }
            }
            catch(Exception ex)
            {

                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public List<LoteEspecifico_Result> LotesEspecifico_Cargar(DateTime fecha_lote)
        {
            try
            {
                using (Entities db = new Entities())
                {
                    return db.LoteEspecifico(fecha_lote).ToList();
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public DataTable getActivoLotes()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id");
            dt.Columns.Add("nombre");
            DataRow row = dt.NewRow();

            row["id"] = 0;
            row["nombre"] = "INACTIVO";
            dt.Rows.Add(row);
            row = dt.NewRow();

            row["id"] = 1;
            row["nombre"] = "ACTIVO";
            dt.Rows.Add(row);
            row = dt.NewRow();

            return dt;
        }

        public int Lote_Guardar(string xLote)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Lote_GUARDAR(xLote);
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int Lote_Modificar(int id, string xLote, int xActivo)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Lote_MODIFICAR(id, xLote, xActivo);
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }
        #endregion
    }
}
