using Datos.ClasesCD;
using DevExpress.XtraGrid.Views.Grid;
using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.ClasesCN
{
    public class InventarioCN
    {
        InventarioCD _Inventario_CD = new InventarioCD();
        public static decimal Precio_De_Producto(int tp,int id_producto)
        {
            InventarioCD obj = new InventarioCD();
            return obj.Precio_De_Producto(tp,id_producto);
        }
        public static string Precio_De_Producto_letras(int tp,int id_producto)
        {
            InventarioCD obj = new InventarioCD();
            return obj.Precio_De_Producto_letras(tp,id_producto);
        }
        [DataObjectMethod(DataObjectMethodType.Fill)]
        public static List<Kardex_SELECT_Result> Kardex_Select( )
        {
            InventarioCD obj = new InventarioCD();
            return obj.Kardex_Select();
        }
        public static int Estado_Movimiento(int id_movimiento)
        {
            InventarioCD obj= new InventarioCD();
            return obj.Estado_Movimiento(id_movimiento);
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public static int Revierte_Movimiento(int id_movimiento_invetario)
        {
            InventarioCD Obj = new InventarioCD();
            return Obj.Revierte_Movimiento(id_movimiento_invetario);

        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<Kardex_SELECTFILA_Result> Kardex_SelectFila(int xIdProducto,int xIdBodega)
        {
            InventarioCD obj = new InventarioCD();
            return obj.Kardex_SelectFila(xIdProducto,xIdBodega);
        }
        public static List<Kardex_SELECTFILA_COD_Result> Kardex_SelectFila_COD(string xCodProducto,int xIdBodega)
        {
            InventarioCD obj = new InventarioCD();
            return obj.Kardex_SelectFila_COD(xCodProducto,xIdBodega);
        }

        [DataObjectMethod(DataObjectMethodType.Fill)]
        public static List<MovimientoInventario_SELECT_Result> MovimientoInventario_Select(bool xCerrado,DateTime desde,DateTime hasta)
        {
            InventarioCD obj = new InventarioCD();
            return obj.MovimientoInventario_Select(xCerrado,desde.Date,hasta.Date);
        }

        public static List<MovimientoDevolucionSelect_Result> MovimientoDevolucionSelect(bool xCerrado, DateTime desde, DateTime hasta)
        {
            InventarioCD obj = new InventarioCD();
            return obj.MovimientoDevolucionSelect(xCerrado, desde.Date, hasta.Date);
        }

        public static List<MovimientoDevolucionSelect_ProdDañado_Result> MovimientoDevolucionSelect_ProdDañado(bool xCerrado, DateTime desde, DateTime hasta)
        {
            InventarioCD obj = new InventarioCD();
            return obj.MovimientoDevolucionSelect_ProdDañado(xCerrado, desde.Date, hasta.Date);
        }


        public static List<MovimientoInventario_SELECT_Autorizacion_Result> MovimientoInventario_Select_Autorizacion(bool xCerrado, DateTime desde, DateTime hasta)
        {
            InventarioCD obj = new InventarioCD();
            return obj.MovimientoInventario_Select_Autorizacion(xCerrado, desde.Date, hasta.Date);
        }

        [DataObjectMethod(DataObjectMethodType.Fill)]
        public static List<MovimientoInventarioDetalle_SELECT_Result> MovimientoInventarioDetalle_Select(int xIdMovimiento)
        {
            InventarioCD obj = new InventarioCD();
            return obj.MovimientoInventarioDetalle_Select(xIdMovimiento);
        }


        public static List<MovimientoDevolucionDetalleSelect_Result> MovimientoDevolucionDetalleSelect(int id_venta)
        {
            InventarioCD obj = new InventarioCD();
            return obj.MovimientoDevolucionDetalleSelect(id_venta);
        }

        public static List<MovimientoDevolucionDetalleSelect_ProductoDañado_Result> MovimientoDevolucionDetalleSelect_ProductoDañado(int id_venta)
        {
            InventarioCD obj = new InventarioCD();
            return obj.MovimientoDevolucionDetalleSelect_ProductoDañado(id_venta);
        }

        public static List<MovimientoInventarioDetalle_SELECT_Autorizacion_Result> MovimientoInventarioDetalle_Select_Autorizacion(int xIdMovimiento)
        {
            InventarioCD obj = new InventarioCD();
            return obj.MovimientoInventarioDetalle_Select_Autorizacion(xIdMovimiento);
        }

        [DataObjectMethod(DataObjectMethodType.Fill)]
        public static List<Movimientos_de_inventarios_detallados_por_rango_fecha_Result> Movimiento_detallado_por_rango(DateTime desde,DateTime Hasta)
        {
            InventarioCD obj = new InventarioCD();
            return obj.Movimiento_detallado_por_rango(desde,Hasta);
        }
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static Tuple<bool,int,string> MovimientoInventario_Guardar(int xIdTipoAjuste,DateTime xFecha,string xNumeroReferencia,string xObservacion,int xIdEmpleado,string xPersonaReferencia,int xTipo,int xIdReferencia,DevExpress.XtraGrid.Views.Grid.GridView view,int id_bodega)
        {
            InventarioCD obj = new InventarioCD();
            return obj.MovimientoInventario_Guardar(xIdTipoAjuste,xFecha,xNumeroReferencia,xObservacion,xIdEmpleado,xPersonaReferencia,xTipo,xIdReferencia,view,id_bodega);
        }

        public static Tuple<bool, int, string> AjusteInventario_Guardar(int xIdTipoAjuste, DateTime xFecha, string xNumeroReferencia, string xObservacion, int xIdEmpleado, string xPersonaReferencia, int xTipo, int xIdReferencia, DevExpress.XtraGrid.Views.Grid.GridView view, int id_bodega)
        {
            InventarioCD obj = new InventarioCD();
            return obj.AjusteInventario_Guardar(xIdTipoAjuste, xFecha, xNumeroReferencia, xObservacion, xIdEmpleado, xPersonaReferencia, xTipo, xIdReferencia, view, id_bodega);
        }

        public static Tuple<bool, int, string> AjusteInventario_Guardar_Autorizacion(int xIdTipoAjuste, DateTime xFecha, string xNumeroReferencia, string xObservacion, int xIdEmpleado, string xPersonaReferencia, int xTipo, int xIdReferencia, DevExpress.XtraGrid.Views.Grid.GridView view, int id_bodega)
        {
            InventarioCD obj = new InventarioCD();
            return obj.AjusteInventario_Guardar_Autorizacion(xIdTipoAjuste, xFecha, xNumeroReferencia, xObservacion, xIdEmpleado, xPersonaReferencia, xTipo, xIdReferencia, view, id_bodega);
        }

        public static Tuple<bool, int, string> AjusteInventario_Guardar_Autorizado(int xIdTipoAjuste, DateTime xFecha, string xNumeroReferencia, string xObservacion, int xIdEmpleado, string xPersonaReferencia, int xTipo, int xIdReferencia, DevExpress.XtraGrid.Views.Grid.GridView view, int id_bodega, string xNumeroDoc)
        {
            InventarioCD obj = new InventarioCD();
            return obj.AjusteInventario_Guardar_Autorizado(xIdTipoAjuste, xFecha, xNumeroReferencia, xObservacion, xIdEmpleado, xPersonaReferencia, xTipo, xIdReferencia, view, id_bodega, xNumeroDoc);
        }

        [DataObjectMethod(DataObjectMethodType.Fill)]
        public static List<Kardex_SELECT_VENTA_Result> Kardex_SelectVenta( )
        {
            InventarioCD obj = new InventarioCD();
            return obj.Kardex_SelectVenta();
        }

        public static List<Kardex_SELECT_VENTAEXC_Result> Kardex_SelectVentaEXC()
        {
            InventarioCD obj = new InventarioCD();
            return obj.Kardex_SelectVentaEXC();
        }

        public static List<Kardex_SELECT_VENTAEXC_Devoluciones_Result> Kardex_SelectVentaEXC_Devolucion(int id_venta)
        {
            InventarioCD obj = new InventarioCD();
            return obj.Kardex_SelectVentaEXC_Devolucion(id_venta);
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public static int Kardex_ModificarUbicacion(int xIdProducto,int xIdBodega,string xUbicacion)
        {
            InventarioCD obj = new InventarioCD();
            return obj.Kardex_ModificarUbicacion(xIdProducto,xIdBodega,xUbicacion);
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static Tuple<bool,int,string> TrasladoBodega_Guardar(int xBodega1,int xBodega2,DateTime xFecha,string xNumeroReferencia,string xObservacion,int xIdEmpleado,string xPersonaReferencia,DevExpress.XtraGrid.Views.Grid.GridView view_desde,GridView view_hasta)
        {
            InventarioCD obj = new InventarioCD();
            return obj.TrasladoBodega_Guardar(xBodega1,xBodega2,xFecha,xNumeroReferencia,xObservacion,xIdEmpleado,xPersonaReferencia,view_desde,view_hasta);
        }

        [DataObjectMethod(DataObjectMethodType.Fill)]
        public static List<Traslado_REPORTE_Result> Traslado_Reporte(int xId,int xIdBodega)
        {
            InventarioCD obj = new InventarioCD();
            return obj.Traslado_Reporte(xId,xIdBodega);
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Tuple<int,string> Traslado_ObtenerBodega(int xIdMovimiento,int xMenorMayor)
        {
            InventarioCD obj = new InventarioCD();
            return obj.Traslado_ObtenerBodega(xIdMovimiento,xMenorMayor);
        }

        #region PROCEDIMINETOS PARA REPORTES
        public static List<Ajuste_REPORTE_Result> Reporte_Ajuste(int id)
        {
            InventarioCD obj = new InventarioCD();
            return obj.Reporte_Ajuste(id);
        }

        public static List<Ajuste_REPORTE_Autorizacion_Result> Reporte_Ajuste_Autorizacion(int id)
        {
            InventarioCD obj = new InventarioCD();
            return obj.Reporte_Ajuste_Autorizacion(id);
        }
        [DataObjectMethod(DataObjectMethodType.Fill)]
        public static List<InventarioPorDinero_Result> InventarioPorDinero( )
        {
            InventarioCD obj = new InventarioCD();
            return obj.InventarioPorDinero();
        }

        [DataObjectMethod(DataObjectMethodType.Fill)]
        public static List<InventarioPorDinero_SELECTBODEGA_Result> InventarioPorDinero_SelectBodega(int xIdBodega)
        {
            InventarioCD obj = new InventarioCD();
            return obj.InventarioPorDinero_SelectBodega(xIdBodega);
        }

        [DataObjectMethod(DataObjectMethodType.Fill)]
        public static List<ListadoProducto_Result> ListadoProducto(decimal xCantidad)
        {
            InventarioCD obj = new InventarioCD();
            return obj.ListadoProducto(xCantidad);
        }

        #endregion
        public static List<Movimiento_Por_Producto_Result> Movimiento_por_producto(int id_producto,int id_bodega, int id_lote, string ubicacion)
        {
            InventarioCD obj = new InventarioCD();
            return obj.Movimiento_por_producto(id_producto, id_bodega, id_lote, ubicacion);
        }
        public static List<Producto_Select_Fila_por_Lote_Result> Producto_Select_Fila_Lote(int id_producto,int id_bodega,int Vid_Lote)
        {
            InventarioCD obj= new InventarioCD();
            return obj.Producto_Select_Fila_Lote(id_producto,id_bodega,Vid_Lote);
        }
        //public static List<Consulta_Inventario_Result> Consulta_Inventario( )
        //{
        //    InventarioCD obj= new InventarioCD();
        //    return obj.Consulta_Inventario();
        //}
        public static System.Data.DataTable Consulta_Inventario_dynamic(bool todo)
        {
            InventarioCD inventarioCd= new InventarioCD();
            return inventarioCd.Consulta_Inventario_dinamica(todo);
        }

        public static System.Data.DataTable Consulta_Inventario_dynamic_Especial(bool todo)
        {
            InventarioCD inventarioCd = new InventarioCD();
            return inventarioCd.Consulta_Inventario_dinamica_Especial(todo);
        }
        public static System.Data.DataTable Consulta_Inventario_Por_Subgrupo(int id_subgrupo )
        {
            InventarioCD inventario= new InventarioCD();
            return inventario.Consulta_Inventario_por_Sub_Grupo(id_subgrupo);
        }
        public static List<Ajsutes_Select_Rango_Result> Ajustes_Select_Rango_fechas(DateTime Desde,DateTime Hasta)
        {
            InventarioCD ob= new InventarioCD();

            return ob.Ajustes_Select_Rango_fechas(Desde,Hasta);
        }

        public static List<Ajsutes_Select_Rango_Aut_Result> Ajustes_Select_Rango_Aut_fechas(DateTime Desde, DateTime Hasta)
        {
            InventarioCD ob = new InventarioCD();

            return ob.Ajustes_Select_Rango_Aut_fechas(Desde, Hasta);
        }
        public  static List<Traslados_Select_Rango_Result> Traslados_Select_Rango(DateTime Desde,DateTime Hasta)
        {
            InventarioCD ob= new InventarioCD();

            return ob.Traslados_Select_Rango(Desde,Hasta);
        }

        public static int AnularMov_Autorizacion(int xidMovimiento)
        {
            InventarioCD obj = new InventarioCD();
            return obj.AnularMov_Autorizacion(xidMovimiento);
        }

        public static int ActualizarObservacionTraslados(int idMovimiento, string xObservacion)
        {
            InventarioCD obj = new InventarioCD();
            return obj.ActualizarObservacionTraslados(idMovimiento, xObservacion);
        }

        public static string RetornarNumeroDocumentoCambioClientes()
        {
            InventarioCD obj = new InventarioCD();
            return obj.RetornarNumeroDocumentoCambioClientes();
        }

        public static string RetornarNumeroDocumentoProductoFallado()
        {
            InventarioCD obj = new InventarioCD();
            return obj.RetornarNumeroDocumentoProductoFallado();
        }

        public static int DevolucionEntrada(int id_venta, string observaciones, int id_empleado, string persona_referencia,GridView gridViewDetalleMod, string numeroDocumento)
        {
            InventarioCD obj = new InventarioCD();
            return obj.DevolucionEntrada(id_venta, observaciones, id_empleado, persona_referencia, gridViewDetalleMod, numeroDocumento);
        }

        public static int DevolucionEntradaProdDañado(int id_venta, string observaciones, int id_empleado, string persona_referencia, GridView gridViewDetalleMod, string numeroDocumento)
        {
            InventarioCD obj = new InventarioCD();
            return obj.DevolucionEntradaProdDañado(id_venta, observaciones, id_empleado, persona_referencia, gridViewDetalleMod, numeroDocumento);
        }

        public static int DevolucionSalida(int id_venta, string observaciones, int id_empleado, string persona_referencia, GridView gridViewDetalleMod, string numeroDocumento)
        {
            InventarioCD obj = new InventarioCD();
            return obj.DevolucionSalida(id_venta, observaciones, id_empleado, persona_referencia, gridViewDetalleMod, numeroDocumento);
        }

        public static int DevolucionSalidaProdDañado(int id_venta, string observaciones, int id_empleado, string persona_referencia, GridView gridViewDetalleMod, string numeroDocumento)
        {
            InventarioCD obj = new InventarioCD();
            return obj.DevolucionSalidaProdDañado(id_venta, observaciones, id_empleado, persona_referencia, gridViewDetalleMod, numeroDocumento);
        }

        public static int SaldoFactura(int id_venta, string observaciones, int id_empleado, string persona_referencia, GridView gridViewDetalleMod, GridView gridViewDetalleModSalida, int mov_generado)
        {
            InventarioCD obj = new InventarioCD();
            return obj.SaldoFactura(id_venta, observaciones, id_empleado, persona_referencia, gridViewDetalleMod, gridViewDetalleModSalida, mov_generado);
        }

        public static List<ReporteDevoluciones_Result> ReporteDevoluciones(int id_venta)
        {
            InventarioCD obj = new InventarioCD();
            return obj.ReporteDevoluciones(id_venta);
        }

        public static List<ReporteDevoluciones_ProductoDañado_Result> ReporteDevoluciones_ProductoDañado(int id_venta)
        {
            InventarioCD obj = new InventarioCD();
            return obj.ReporteDevoluciones_ProductoDañado(id_venta);
        }

        
    }
}
