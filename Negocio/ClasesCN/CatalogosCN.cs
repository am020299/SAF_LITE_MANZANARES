using Entidades;
using System.Collections.Generic;
using System.ComponentModel;
using Datos.ClasesCD;
using System.Data;
using System;
using DevExpress.XtraGrid.Views.Grid;

namespace Negocio.ClasesCN
{
    public class CatalogosCN
    {
        [DataObjectMethod(DataObjectMethodType.Fill)]
        public static DataTable getMoneda( )
        {
            CatalogosCD obj = new CatalogosCD();
            return obj.getMoneda();
        }

        public static DataTable getBanco()
        {
            CatalogosCD obj = new CatalogosCD();
            return obj.getBanco();
        }

        public static DataTable getMonedaCXC()
        {
            CatalogosCD obj = new CatalogosCD();
            return obj.getMonedaCXC();
        }

        public static List<Obtiene_representantes_clientes_Result> Representantes_clientes(int id_cliente)
        {
            CatalogosCD dc= new CatalogosCD();
            return dc.Representantes_clientes(id_cliente);
        }
        [DataObjectMethod(DataObjectMethodType.Fill)]
        public static DataTable getPrecio( )
        {
            CatalogosCD obj = new CatalogosCD();
            return obj.getPrecio();
        }
        public static DataTable getPrecio2()
        {
            CatalogosCD obj = new CatalogosCD();
            return obj.getPrecio2();
        }

        [DataObjectMethod(DataObjectMethodType.Fill)]
        public static DataTable getTipoAjuste( )
        {
            CatalogosCD obj = new CatalogosCD();
            return obj.getTipoAjuste();
        }

        #region CLIENTES
        [DataObjectMethod(DataObjectMethodType.Fill)]
        public static List<Cliente> getCliente( )
        {
            CatalogosCD obj = new CatalogosCD();
            return obj.getCliente();
        }

        [DataObjectMethod(DataObjectMethodType.Fill)]
        public static List<Cliente_Cargar_Result> Cliente_Cargar( )
        {
            CatalogosCD obj = new CatalogosCD();
            return obj.Cliente_Cargar();
        }

        public static List<Cliente_Cargar_Historico_Result> Cliente_Cargar_Historico()
        {
            CatalogosCD obj = new CatalogosCD();
            return obj.Cliente_Cargar_Historico();
        }
        public static List<Cliente_Cargar_Historico_C__Result> Cliente_Cargar_Historico_C()
        {
            CatalogosCD obj = new CatalogosCD();
            return obj.Cliente_Cargar_Historico_C();
        }

        public static List<RPTCliente_Nuevo_Result> RPTCliente_Cargar(DateTime FechaIni, DateTime FechaFin)
        {
            CatalogosCD obj = new CatalogosCD();
            return obj.RPTCliente_Cargar(FechaIni, FechaFin);
        }

        public static List<FacturasConRetenciones_Result> FacturasConRetenciones(DateTime FechaIni, DateTime FechaFin)
        {
            CatalogosCD obj = new CatalogosCD();
            return obj.FacturasConRetenciones(FechaIni, FechaFin);
        }

        public static List<CANTIDAD_BILLETES_ARQUEO_Result> RPTDenominaciones_Billetes(DateTime FechaIni, DateTime FechaFin)
        {
            CatalogosCD obj = new CatalogosCD();
            return obj.RPTDenominaciones_Billetes(FechaIni, FechaFin);
        }

        //public static List<CANTIDAD_BILLETES_ARQUEO_1000_500_Result> RPTDenominaciones_Billetes_1000_500(DateTime FechaIni, DateTime FechaFin)
        //{
        //    CatalogosCD obj = new CatalogosCD();
        //    return obj.RPTDenominaciones_Billetes_1000_500(FechaIni, FechaFin);
        //}

        //public static List<CANTIDAD_BILLETES_ARQUEO_200_100_50_20_10_Result> RPTDenominaciones_Billetes_200_100_50_20_10(DateTime FechaIni, DateTime FechaFin)
        //{
        //    CatalogosCD obj = new CatalogosCD();
        //    return obj.RPTDenominaciones_Billetes_200_100_50_20_10(FechaIni, FechaFin);
        //}

        //public static List<CANTIDAD_BILLETES_ARQUEO_100_50_Dol_Result> RPTDenominaciones_Billetes_100_50_Dol(DateTime FechaIni, DateTime FechaFin)
        //{
        //    CatalogosCD obj = new CatalogosCD();
        //    return obj.RPTDenominaciones_Billetes_100_50_Dol(FechaIni, FechaFin);
        //}

        //public static List<CANTIDAD_BILLETES_ARQUEO_20_10_5_1_Dol_Result> RPTDenominaciones_Billetes_20_10_5_1_Dol(DateTime FechaIni, DateTime FechaFin)
        //{
        //    CatalogosCD obj = new CatalogosCD();
        //    return obj.RPTDenominaciones_Billetes_20_10_5_1_Dol(FechaIni, FechaFin);
        //}

        public static List<Reporte_Autorizacion_Result> RPTAutorizacion(DateTime FechaIni, DateTime FechaFin, int idEmpleado)
        {
            CatalogosCD obj = new CatalogosCD();
            return obj.RPTAutorizacion(FechaIni, FechaFin,idEmpleado);
        }

        [DataObjectMethod(DataObjectMethodType.Fill)]
        public static List<Representantes> Representantes_Cargar( )
        {
            CatalogosCD obj = new CatalogosCD();
            return obj.Representantes_cargar();
        }

        public static int ProductoHabilitar(int idProd, bool habilitado)
        {
            CatalogosCD obj = new CatalogosCD();
            return obj.ProductoHabilitar(idProd, habilitado);
        }

        [DataObjectMethod(DataObjectMethodType.Fill)]
        public static List<Cliente_SELECTFILA_Result> Cliente_SelectFila(int xId)
        {
            CatalogosCD obj = new CatalogosCD();
            return obj.Cliente_SelectFila(xId);
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static int Cliente_Guardar(string xCodigo,string xRuc,string xNombre,string xTelefono,string xCelular,string xDireccion,string xCorreo,int xid_sector,int xPrecio,string repre1,string repre2,string repre3,string cedula1,string cedula2,string cedula3,int usuario_creador, byte[] xImagen_doc_cliete, string departamento, bool esMercado)
        {
            CatalogosCD obj = new CatalogosCD();
            return obj.Cliente_Guardar(xCodigo,xRuc,xNombre,xTelefono,xCelular,xDireccion,xCorreo,xid_sector,xPrecio,repre1,repre2,repre3,cedula1,cedula2,cedula3,usuario_creador, xImagen_doc_cliete, departamento, esMercado);
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public static int Cliente_Actualizar(int xId,string xCodigo,string xRuc,string xNombre,string xTelefono,string xCelular,string xDireccion,string xCorreo,int xid_Sector,int xPrecio,int xUsuario,int id_repre,int id_repre2,int id_repre3,int id_repre4,int Autorizador,string repre1,string repre2,string repre3,string cedula1,string cedula2,string cedula3, byte[] xImagen_doc_cliete, string departamento, bool esMercado)
        {
            CatalogosCD obj = new CatalogosCD();
            return obj.Cliente_Actualizar(xId,xCodigo,xRuc,xNombre,xTelefono,xCelular,xDireccion,xCorreo,xid_Sector,xPrecio,xUsuario,id_repre,id_repre2,id_repre3,id_repre4,Autorizador,repre1,repre2,repre3,cedula1,cedula2,cedula3, xImagen_doc_cliete, departamento, esMercado);
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public static int Cliente_Eliminar(int xId,int xUsuario)
        {
            CatalogosCD obj = new CatalogosCD();
            return obj.Cliente_Eliminar(xId,xUsuario);
        }

        #endregion
        #region SECTORES
        [DataObjectMethod(DataObjectMethodType.Fill)]
        public static List<Sectores_Cargar_Result> Sectores_cargar( )
        {
            CatalogosCD obj = new CatalogosCD();
            return obj.Sectores_cargar();
        }
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static int Representantes_Insert(string Nombre_rep,string correo,string direccion,string celular,string Cedula)
        {

            CatalogosCD obj = new CatalogosCD();
            return obj.Representantes_Insert(Nombre_rep,correo,direccion,celular,Cedula);
        }
        [DataObjectMethod(DataObjectMethodType.Update)]
        public static int Representantes_Update(string Nombre_rep,string correo,string direccion,string celular,int vId,string Cedula)
        {
            CatalogosCD obj = new CatalogosCD();
            return obj.Rep_update(Nombre_rep,correo,direccion,celular,vId,Cedula);
        }
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public int Sectores_Eliminar(int id_sector,int id_usuario)
        {
            CatalogosCD obj = new CatalogosCD();
            return obj.Sectores_Eliminar(id_sector,id_usuario);
        }
        #endregion
        #region CATEGORIA
        [DataObjectMethod(DataObjectMethodType.Fill)]
        public static List<Categoria> getCategoria( )
        {
            CatalogosCD obj = new CatalogosCD();
            return obj.getCategoria();
        }

        [DataObjectMethod(DataObjectMethodType.Fill)]
        public static List<Categoria_CARGAR_Result> Categoria_Cargar( )
        {
            CatalogosCD obj = new CatalogosCD();
            return obj.Categoria_Cargar();
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static int Categoria_Guardar(string xNombre,byte[] xImagen,string codigo)
        {
            CatalogosCD obj = new CatalogosCD();
            return obj.Categoria_Guardar(xNombre,xImagen,codigo);
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public static int Categoria_Actualizar(int xId,string xNombre,byte[] xImagen,int xUsuario)
        {
            CatalogosCD obj = new CatalogosCD();
            return obj.Categoria_Actualizar(xId,xNombre,xImagen,xUsuario);
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public static int Categoria_Eliminar(int xId,int xUsuario)
        {
            CatalogosCD obj = new CatalogosCD();
            return obj.Categoria_Eliminar(xId,xUsuario);
        }

        #endregion

        #region MARCA
        [DataObjectMethod(DataObjectMethodType.Fill)]
        public static List<Marca> getMarca( )
        {
            CatalogosCD obj = new CatalogosCD();
            return obj.getMarca();
        }

        [DataObjectMethod(DataObjectMethodType.Fill)]
        public static List<Marca_CARGAR_Result> Marca_Cargar( )
        {
            CatalogosCD obj = new CatalogosCD();
            return obj.Marca_Cargar();
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static int Marca_Guardar(string xNombre,byte[] xImagen)
        {
            CatalogosCD obj = new CatalogosCD();
            return obj.Marca_Guardar(xNombre,xImagen);
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public static int Marca_Actualizar(int xId,string xNombre,byte[] xImagen,int xUsuario)
        {
            CatalogosCD obj = new CatalogosCD();
            return obj.Marca_Actualizar(xId,xNombre,xImagen,xUsuario);
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public static int Marca_Eliminar(int xId,int xUsuario)
        {
            CatalogosCD obj = new CatalogosCD();
            return obj.Marca_Eliminar(xId,xUsuario);
        }

        #endregion

        #region PRECIOS
        
        public static Tuple<int, bool> Precio_GUARDAR(string xDescripcion, string xObservacion, int xTipo, int xEstado, DateTime xFecha_actualizacion)
        {
            CatalogosCD obj = new CatalogosCD();
            return obj.Precio_GUARDAR(xDescripcion, xObservacion, xTipo, xEstado, xFecha_actualizacion);
        }

        [DataObjectMethod(DataObjectMethodType.Fill)]
        public static List<Precios_Catalogos_SELECT_Result> Get_Precios()
        {
            CatalogosCD obj = new CatalogosCD();
            return obj.Get_Precios();
        }
        
        public static int Precio_Actualizar(int xId, string xDescripcion, string xObservacion, DateTime xFecha_actualizacion)
        {
            CatalogosCD obj = new CatalogosCD();
            return obj.Precio_Actualizar(xId, xDescripcion, xObservacion, xFecha_actualizacion);
        }

        public static int Precio_Eliminar(int xId)
        {
            CatalogosCD obj = new CatalogosCD();
            return obj.Precio_Eliminar(xId);
        }

        [DataObjectMethod(DataObjectMethodType.Fill)]
        public static List<Precio_detalle_linea_SELECT_Result> Precio_Detalle_linea_SELECT()
        {
            CatalogosCD obj = new CatalogosCD();
            return obj.Precio_Detalle_linea_SELECT();
        }

        public static List<Precio_detalle_productos_SELECT_Result> Precio_Detalle_productos_SELECT()
        {
            CatalogosCD obj = new CatalogosCD();
            return obj.Precio_Detalle_productos_SELECT();
        }

        public static int Actualiza_Precio_Linea(GridView view)
        {
            CatalogosCD obj = new CatalogosCD();
            return obj.Actualiza_Precio_Linea(view);
        }
        public static int Actualiza_Precio_Producto(GridView view)
        {
            CatalogosCD obj = new CatalogosCD();
            return obj.Actualiza_Precio_Producto(view);
        }

        public static List<Precio_Select_Por_Linea_Result> Get_precio_linea(int xId_linea)
        {
            CatalogosCD obj = new CatalogosCD();
            return obj.Get_precio_linea(xId_linea);
        }

        public static List<Precio_Select_Por_Producto_Result> Get_precio_producto(int xId_producto)
        {
            CatalogosCD obj = new CatalogosCD();
            return obj.Get_precio_producto(xId_producto);
        }

        #endregion

        #region LINEA
        [DataObjectMethod(DataObjectMethodType.Fill)]
        public static List<Linea> getLinea( )
        {
            CatalogosCD obj = new CatalogosCD();
            return obj.getLinea();
        }

        [DataObjectMethod(DataObjectMethodType.Fill)]
        public static List<Linea_CARGAR_Result> Linea_Cargar( )
        {
            CatalogosCD obj = new CatalogosCD();
            return obj.Linea_Cargar();
        }

        public static List<Lotes_Cargar_Result> CargarLotes()
        {
            CatalogosCD obj = new CatalogosCD();
            return obj.CargarLotes();
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static int Linea_Guardar(string xNombre,int id_grupo,decimal precio_mmayor,decimal precio_eventual,decimal precio_unitario,decimal xPrecio4, decimal xPrecio5, decimal xPrecio6, decimal xPrecio7, decimal xPrecio8, decimal xPrecio9, decimal xPrecio10, decimal xPrecio11, string codigo, int moneda, string descripcion, decimal costo, decimal xPrecio12, decimal xPrecio13, bool permiteEdicion)
        {
            CatalogosCD obj = new CatalogosCD();
            return obj.Linea_Guardar(xNombre,id_grupo,precio_mmayor,precio_eventual,precio_unitario,xPrecio4, xPrecio5, xPrecio6, xPrecio7, xPrecio8, xPrecio9, xPrecio10, xPrecio11, xPrecio12, xPrecio13, codigo, moneda, descripcion, costo, permiteEdicion);
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public static int Linea_Actualizar(int xId,string xNombre,int xUsuario,int id_grupo,decimal precio_mmayor,decimal precio_eventual,decimal precio_unitario,decimal xPrecio4, decimal xPrecio5, decimal xPrecio6, decimal xPrecio7, decimal xPrecio8, decimal xPrecio9, decimal xPrecio10, decimal xPrecio11, decimal xPrecio12, decimal xPrecio13,string codigo, int moneda, string descripcion, decimal costo, bool permiteEdicion)
        {
            CatalogosCD obj = new CatalogosCD();
            return obj.Linea_Actualizar(xId, xNombre, xUsuario,id_grupo,precio_mmayor,precio_eventual,precio_unitario,xPrecio4, xPrecio5, xPrecio6, xPrecio7, xPrecio8, xPrecio9, xPrecio10, xPrecio11, xPrecio12, xPrecio13, codigo, moneda, descripcion, costo, permiteEdicion);
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public static int Linea_Eliminar(int xId, int xUsuario)
        {
            CatalogosCD obj = new CatalogosCD();
            return obj.Linea_Eliminar(xId, xUsuario);
        }

        #endregion

        #region UNIDAD DE MEDIDA
        [DataObjectMethod(DataObjectMethodType.Fill)]
        public static List<UnidadMedida> getUnidadMedida()
        {
            CatalogosCD obj = new CatalogosCD();
            return obj.getUnidadMedida();
        }

        [DataObjectMethod(DataObjectMethodType.Fill)]
        public static List<UnidadMedida_CARGAR_Result> UnidadMedida_Cargar()
        {
            CatalogosCD obj = new CatalogosCD();
            return obj.UnidadMedida_Cargar();
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static int UnidadMedida_Guardar(string xDescripcion, string xSimbolo)
        {
            CatalogosCD obj = new CatalogosCD();
            return obj.UnidadMedida_Guardar(xDescripcion, xSimbolo);
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public static int UnidadMedida_Actualizar(int xId, string xDescripcion, string xSimbolo, int xUsuario)
        {
            CatalogosCD obj = new CatalogosCD();
            return obj.UnidadMedida_Actualizar(xId, xDescripcion, xSimbolo, xUsuario);
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public static int UnidadMedida_Eliminar(int xId, int xUsuario)
        {
            CatalogosCD obj = new CatalogosCD();
            return obj.UnidadMedida_Eliminar(xId, xUsuario);
        }

        #endregion

        #region PRODUCTO

        [DataObjectMethod(DataObjectMethodType.Fill)]
        public static List<Producto_CARGAR_Result> Producto_Cargar()
        {
            CatalogosCD obj = new CatalogosCD();
            return obj.Producto_Cargar();
        }

        public static int CambiarCostoProductos(int idProducto, decimal costo)
        {
            CatalogosCD obj = new CatalogosCD();
            return obj.CambiarCostoProductos(idProducto, costo);
        }
        

        public static List<Producto_CARGAR_CORDOBAS_Result> Producto_Cargar_Cordobas()
        {
            CatalogosCD obj = new CatalogosCD();
            return obj.Producto_Cargar_Cordobas();
        }

        //public static List<Producto_CARGAR_Result> Producto_Cargar_Dolares()
        //{
        //    CatalogosCD obj = new CatalogosCD();
        //    return obj.Producto_Cargar_Dolares();
        //}

        public static List<Producto_CARGAR_SUBGRUPO_Result> Producto_Cargar_Sub(int id_subante)
        {
            CatalogosCD obj = new CatalogosCD();
            return obj.Producto_Cargar_Sub(id_subante);
        }
        public static List<Producto_CARGAR_FILA_Result> Producto_Cargar_Fila(int xId)
        {
            CatalogosCD obj = new CatalogosCD();
            return obj.Producto_Cargar_Fila(xId);
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static int Producto_Guardar(string xCodigo, string xDescripcion, int xIdCategoria, int xIdMarca, int xIdLinea, int xIdUnidadMedida, int xMoneda, decimal xCosto, decimal xUtilidad, decimal xPrecio1, decimal xPrecio2, decimal xPrecio3, decimal xPrecio4, decimal xPrecio5, decimal xPrecio6, decimal xPrecio7, decimal xPrecio8, decimal xPrecio9, decimal xPrecio10, decimal xPrecio11, decimal xPrecio12, decimal xPrecio13,decimal xDescuento, decimal xImpuesto, decimal xStock, decimal xStockMinimo, byte[] xImagen, string xNumeroSerie, bool tipo, bool habilitado)
        {
            CatalogosCD obj = new CatalogosCD();
            return obj.Producto_Guardar(xCodigo, xDescripcion, xIdCategoria, xIdMarca, xIdLinea, xIdUnidadMedida, xMoneda, xCosto, xUtilidad, xPrecio1, xPrecio2, xPrecio3, xPrecio4, xPrecio5, xPrecio6, xPrecio7, xPrecio8, xPrecio9, xPrecio10, xPrecio11, xPrecio12, xPrecio13,xDescuento, xImpuesto, xStock, xStockMinimo, xImagen, xNumeroSerie, tipo, habilitado);
        }

        public static int Importar_Productos(string xCodigo, string xDescripcion, string xIdCategoria, string xIdMarca, string xIdLinea, string xIdUnidadMedida,string moneda, decimal xCosto, decimal xPrecio1, decimal xPrecio2, decimal xPrecio3, decimal xPrecio4, decimal xPrecio5, decimal xPrecio6, decimal xPrecio7, decimal xPrecio8, decimal xDescuento, decimal xImpuesto, decimal xStock, decimal xStockMinimo, string xNumeroSerie,int numero,string lote, string ubicacion,string codigo_grupo,string codigo_subgrupo,string numero_factura,int id_proveedor,DateTime Fecha_Compra,string observaciones)
        {
            CatalogosCD obj = new CatalogosCD();
            return obj.Importar_Productos(xCodigo, xDescripcion, xIdCategoria, xIdMarca, xIdLinea, xIdUnidadMedida,moneda,  xCosto, xPrecio1, xPrecio2, xPrecio3, xPrecio4, xPrecio5, xPrecio6, xPrecio7, xPrecio8, xDescuento, xImpuesto, xStock, xStockMinimo, xNumeroSerie,numero,lote,ubicacion,codigo_grupo,codigo_subgrupo,numero_factura,id_proveedor,Fecha_Compra,observaciones);
        }

        public static int Importar_Productos_catalogos(string xCodigo,string xDescripcion,string xIdCategoria,string xIdMarca,string xIdLinea,string xIdUnidadMedida,string moneda,decimal xCosto,decimal xPrecio1,decimal xPrecio2,decimal xPrecio3,decimal xPrecio4, decimal xPrecio5, decimal xPrecio6, decimal xPrecio7, decimal xPrecio8, decimal xDescuento,decimal xImpuesto,decimal xStock,decimal xStockMinimo,string xNumeroSerie,int numero,string lote,string ubicacion,string codigo_grupo,string codigo_subgrupo)
        {
            CatalogosCD obj = new CatalogosCD();
            return obj.Importar_Productos_catalogo(xCodigo,xDescripcion,xIdCategoria,xIdMarca,xIdLinea,xIdUnidadMedida,moneda,xCosto,xPrecio1,xPrecio2,xPrecio3,xPrecio4, xPrecio5, xPrecio6, xPrecio7, xPrecio8, xDescuento,xImpuesto,xStock,xStockMinimo,xNumeroSerie,numero,lote,ubicacion,codigo_grupo,codigo_subgrupo);
        }
        public static int proximo_numero_orden()
        {
            CatalogosCD obj = new CatalogosCD();
            return obj.proximo_numero_orden();
        }
        [DataObjectMethod(DataObjectMethodType.Update)]
        public static int Producto_Actualizar(int xId, string xCodigo, string xDescripcion, int xIdCategoria, int xIdMarca, int xIdLinea, int xIdUnidadMedida, int xMoneda, decimal xCosto, decimal xUtilidad, decimal xPrecio1, decimal xPrecio2, decimal xPrecio3, decimal xPrecio4, decimal xPrecio5, decimal xPrecio6, decimal xPrecio7, decimal xPrecio8, decimal xPrecio9, decimal xPrecio10, decimal xPrecio11, decimal xPrecio12, decimal xPrecio13,decimal xDescuento, decimal xImpuesto, decimal xStockMinimo, byte[] xImagen, string xNumeroSerie, int xUsuario, bool tipo, bool habilitado)
        {
            CatalogosCD obj = new CatalogosCD();
            return obj.Producto_Actualizar(xId, xCodigo, xDescripcion, xIdCategoria, xIdMarca, xIdLinea, xIdUnidadMedida, xMoneda, xCosto, xUtilidad, xPrecio1, xPrecio2, xPrecio3, xPrecio4, xPrecio5, xPrecio6, xPrecio7, xPrecio8, xPrecio9, xPrecio10, xPrecio11, xPrecio12, xPrecio13,xDescuento, xImpuesto, xStockMinimo, xImagen, xNumeroSerie, xUsuario, tipo, habilitado);
        }

        public static int Producto_Actualizar_SubGrupo(int xId, string xCodigo, string xDescripcion, int xIdCategoria, int xIdMarca, int xIdLinea, int xIdLineaAnterior, int xIdUnidadMedida, int xMoneda, decimal xCosto, decimal xUtilidad, decimal xPrecio1, decimal xPrecio2, decimal xPrecio3, decimal xPrecio4, decimal xPrecio5, decimal xPrecio6, decimal xPrecio7, decimal xPrecio8, decimal xPrecio9, decimal xPrecio10, decimal xPrecio11, decimal xPrecio12, decimal xPrecio13,decimal xDescuento, decimal xImpuesto, decimal xStockMinimo, byte[] xImagen, string xNumeroSerie, int xUsuario, bool tipo)
        {
            CatalogosCD obj = new CatalogosCD();
            return obj.Producto_Actualizar_SubGrupo(xId, xCodigo, xDescripcion, xIdCategoria, xIdMarca, xIdLinea, xIdLineaAnterior,  xIdUnidadMedida, xMoneda, xCosto, xUtilidad, xPrecio1, xPrecio2, xPrecio3, xPrecio4, xPrecio5, xPrecio6, xPrecio7, xPrecio8, xPrecio9, xPrecio10, xPrecio11, xPrecio12, xPrecio13,xDescuento, xImpuesto, xStockMinimo, xImagen, xNumeroSerie, xUsuario, tipo);
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public static int Producto_Eliminar(int xId, int xUsuario)
        {
            CatalogosCD obj = new CatalogosCD();
            return obj.Producto_Eliminar(xId, xUsuario);

        }
        public static List<CODIGO_PROD_CARGAR_FILA_Result> Codigo_Producto_Cargar_Fila(string codigo)
        {
            CatalogosCD obj = new CatalogosCD();
            return obj.Producto_Codigo_Cargar_Fila(codigo);
        }

        #endregion

        #region BODEGA
        [DataObjectMethod(DataObjectMethodType.Fill)]
        public static List<Bodega> getBodega()
        {
            CatalogosCD obj = new CatalogosCD();
            return obj.getBodega();
        }

        [DataObjectMethod(DataObjectMethodType.Fill)]
        public static List<Bodega_CARGAR_Result> Bodega_Cargar()
        {            
            CatalogosCD obj = new CatalogosCD();
            return obj.Bodega_Cargar();
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static int Bodega_Guardar(string xNombre, string xEncargado, string xDireccion, string xTelefono)
        {
            CatalogosCD obj = new CatalogosCD();
            return obj.Bodega_Guardar(xNombre, xEncargado, xDireccion, xTelefono);

        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public static int Bodega_Actualizar(int xId, string xNombre, string xEncargado, string xDireccion, string xTelefono, int xUsuario)
        {
            CatalogosCD obj = new CatalogosCD();
            return obj.Bodega_Actualizar(xId, xNombre, xEncargado, xDireccion, xTelefono, xUsuario);

        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public static int Bodega_Eliminar(int xId, int xUsuario)
        {
            CatalogosCD obj = new CatalogosCD();
            return obj.Bodega_Eliminar(xId, xUsuario);
        }

        public static List<TiposAjustes> getTiposAjustes()
        {
            CatalogosCD obj = new CatalogosCD();
            return obj.getTiposAjustes();
        }

        [DataObjectMethod(DataObjectMethodType.Fill)]
        public static List<TiposAjustes_SELECT_Result> TiposAjuste_Select()
        {
            CatalogosCD obj = new CatalogosCD();
            return obj.TiposAjuste_Select();
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static int TiposAjustes_Guardar(string xDescripcion, string xDescripcionCorta, int xTipo, int xIdTipoDocumento)
        {
            CatalogosCD obj = new CatalogosCD();
            return obj.TiposAjustes_Guardar(xDescripcion, xDescripcionCorta, xTipo, xIdTipoDocumento);
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public static int TiposAjustes_Modificar(int xId, string xDescripcion, string xDescripcionCorta, int xTipo, int xIdTipoDocumento, int xIdUsuario)
        {
            CatalogosCD obj = new CatalogosCD();
            return obj.TiposAjustes_Modificar(xId, xDescripcion, xDescripcionCorta, xTipo, xIdTipoDocumento, xIdUsuario);
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public static int TiposAjustes_Eliminar(int xId, int xIdUsuario)
        {
            CatalogosCD obj = new CatalogosCD();
            return obj.TiposAjustes_Eliminar(xId, xIdUsuario);

        }

        [DataObjectMethod(DataObjectMethodType.Fill)]
        public static List<TiposAjustes> TipoAjuste()
        {
            CatalogosCD obj = new CatalogosCD();
            return obj.TipoAjuste();
        }
        #endregion

        #region EMPLEADO
        [DataObjectMethod(DataObjectMethodType.Fill)]
        public static List<Empleado> getEmpleado()
        {
            CatalogosCD obj = new CatalogosCD();
            return obj.getEmpleado();
        }

        [DataObjectMethod(DataObjectMethodType.Fill)]
        public static List<Empleado_Cargar_Result> Empleado_Cargar()
        {
            CatalogosCD obj = new CatalogosCD();
            return obj.Empleado_Cargar();
        }

        public static List<Empleado_Cargar_Arqueo_Result> Empleado_Cargar_Arqueo()
        {
            CatalogosCD obj = new CatalogosCD();
            return obj.Empleado_Cargar_Arqueo();
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static int Empleado_Guardar(string xNombre, string xCodigoEmpleado,string xCedula, string xCargo, string xUsuario, string xClave, string xCelular, string xCorreo, string xDireccion, byte[] xFoto)
        {
            CatalogosCD obj = new CatalogosCD();
            return obj.Empleado_Guardar(xNombre, xCodigoEmpleado, xCedula, xCargo, xUsuario, xClave, xCelular, xCorreo, xDireccion, xFoto);
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public static int Empleado_Actualizar(int xId, string xNombre, string xCodigoEmpleado,string xCedula, string xCargo, string xUsuario, string xClave, string xCelular, string xCorreo, string xDireccion, byte[] xFoto, int xIdUsuario)
        {
            CatalogosCD obj = new CatalogosCD();
            return obj.Empleado_Actualizar(xId, xNombre, xCodigoEmpleado, xCedula, xCargo, xUsuario, xClave, xCelular, xCorreo, xDireccion, xFoto, xIdUsuario);
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public static int Empleado_Eliminar(int xId, int xUsuario)
        {
            CatalogosCD obj = new CatalogosCD();
            return obj.Empleado_Eliminar(xId, xUsuario);
        }

        #endregion

        #region PROVEEDORES

        [DataObjectMethod(DataObjectMethodType.Fill)]
        public static List<Proveedores> getProveedores()
        {
            CatalogosCD obj = new CatalogosCD();
            return obj.getProveedores();
        }

        [DataObjectMethod(DataObjectMethodType.Fill)]
        public static List<Proveedores_Select_Result> Proveedores_Select()
        {
            CatalogosCD obj = new CatalogosCD();
            return obj.Proveedores_Select();
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static int Proveedores_Guardar(string xNombre, string xDireccion, string xTelefono, string xRuc, string xCorreo, string xDepartamento, string xCiudad, string xPais, string xContacto, string xTelefonoContacto, string xCorreoContacto, decimal xCreditoMaximo)
        {
            CatalogosCD obj = new CatalogosCD();
            return obj.Proveedores_Guardar(xNombre, xDireccion, xTelefono, xRuc, xCorreo, xDepartamento, xCiudad, xPais, xContacto, xTelefonoContacto, xCorreoContacto, xCreditoMaximo);
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public static int Proveedores_Modificar(int xId, string xNombre, string xDireccion, string xTelefono, string xRuc, string xCorreo, string xDepartamento, string xCiudad, string xPais, string xContacto, string xTelefonoContacto, string xCorreoContacto, decimal xCreditoMaximo, int xIdUsuario)
        {
            CatalogosCD obj = new CatalogosCD();
            return obj.Proveedores_Modificar(xId, xNombre, xDireccion, xTelefono, xRuc, xCorreo, xDepartamento, xCiudad, xPais, xContacto, xTelefonoContacto, xCorreoContacto, xCreditoMaximo, xIdUsuario);
                
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public static int Proveedores_Eliminar(int xId, int xIdUsuario)
        {
            CatalogosCD obj = new CatalogosCD();
            return obj.Proveedores_Eliminar(xId, xIdUsuario);
        }

        #endregion
        #region LOTES
        [DataObjectMethod(DataObjectMethodType.Fill)]
        public static List<Lotes> Lotes_Cargar( )
        {
            CatalogosCD obj = new CatalogosCD();
            return obj.Lotes_Cargar();
        }

        public static List<LoteEspecifico_Result> LotesEspecifico_Cargar(DateTime fecha_lote)
        {
            CatalogosCD obj = new CatalogosCD();
            return obj.LotesEspecifico_Cargar(fecha_lote);
        }

        

        public static DataTable getActivoLotes()
        {
            CatalogosCD obj = new CatalogosCD();
            return obj.getActivoLotes();
        }

        public static int Lote_Guardar(string xLote)
        {
            CatalogosCD obj = new CatalogosCD();
            return obj.Lote_Guardar(xLote);
        }

        public static int Lote_Modificar(int id, string xLote, int xActivo)
        {
            CatalogosCD obj = new CatalogosCD();
            return obj.Lote_Modificar(id, xLote, xActivo);
        }
        #endregion
    }
}
