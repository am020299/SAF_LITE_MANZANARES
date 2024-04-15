using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.ClasesCD;
using Entidades;

namespace Negocio.ClasesCN
{
    public class VentasCN
    {
        public static int FORMA_PAGO_VENTA_GUARDAR(int id_venta,int id_empleado,DevExpress.XtraGrid.Views.Grid.GridView view,DevExpress.XtraGrid.Views.Grid.GridView viewPago, int tipo_documento, int tipo_vuelto,decimal cantidad_vuelto,DateTime Fecha, int N_Transferencia, int id_saldo)
        {
            VentasCD obj = new VentasCD();
            return obj.FORMA_PAGO_VENTA_GUARDAR(id_venta,id_empleado,view,viewPago, tipo_documento, tipo_vuelto,cantidad_vuelto,Fecha, N_Transferencia, id_saldo);
        }
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static Tuple<bool,int,string> Venta_Guardar(int xIdEmpleado,int xVendedor,int xNumero,int xIdCliente,DateTime xFecha,DateTime xFechaMaxima,decimal xTipoCambio,string xObservacion,int xTipo,int xIdTermino,string xPersonaReferencia,DevExpress.XtraGrid.Views.Grid.GridView view,DevExpress.XtraGrid.Views.Grid.GridView viewPago,string representante,int moneda,int persona_autoriza,int xPrecio,int vCambioPrecioCliente, decimal retencion1, decimal retencion2)
        {
            VentasCD obj = new VentasCD();
            return obj.Venta_Guardar(xIdEmpleado,xVendedor,xNumero,xIdCliente,xFecha,xFechaMaxima,xTipoCambio,xObservacion,xTipo,xIdTermino,xPersonaReferencia,view,viewPago,representante,moneda,persona_autoriza,xPrecio, vCambioPrecioCliente,retencion1, retencion2);
        }

        public static Tuple<bool, int, string> Venta_GuardarRemision(int xIdEmpleado, int xVendedor, int xNumero, int xIdCliente, DateTime xFecha, DateTime xFechaMaxima, decimal xTipoCambio, string xObservacion, int xTipo, int xIdTermino, string xPersonaReferencia, DevExpress.XtraGrid.Views.Grid.GridView view, DevExpress.XtraGrid.Views.Grid.GridView viewPago, string representante, int moneda, int persona_autoriza, int xPrecio, int vCambioPrecioCliente, decimal retencion1, decimal retencion2)
        {
            VentasCD obj = new VentasCD();
            return obj.Venta_GuardarRemision(xIdEmpleado, xVendedor, xNumero, xIdCliente, xFecha, xFechaMaxima, xTipoCambio, xObservacion, xTipo, xIdTermino, xPersonaReferencia, view, viewPago, representante, moneda, persona_autoriza, xPrecio, vCambioPrecioCliente,retencion1,retencion2);
        }

        public static List<TotalVentasDetalleProducto_Result> TotalVentasDetalleProducto(int id_producto, DateTime fecha_ini, DateTime fecha_fin)
        {
            VentasCD obj = new VentasCD();
            return obj.TotalVentasDetalleProducto(id_producto, fecha_ini, fecha_fin);
        }

        public static Tuple<bool, int, string> Venta_GuardarPrestamo(int xIdEmpleado, int xVendedor, int xNumero, int xIdCliente, DateTime xFecha, DateTime xFechaMaxima, decimal xTipoCambio, string xObservacion, int xTipo, int xIdTermino, string xPersonaReferencia, DevExpress.XtraGrid.Views.Grid.GridView view, DevExpress.XtraGrid.Views.Grid.GridView viewPago, string representante, int moneda, int persona_autoriza, int xPrecio, int vCambioPrecioCliente, decimal retencion1, decimal retencion2)
        {
            VentasCD obj = new VentasCD();
            return obj.Venta_GuardarPrestamo(xIdEmpleado, xVendedor, xNumero, xIdCliente, xFecha, xFechaMaxima, xTipoCambio, xObservacion, xTipo, xIdTermino, xPersonaReferencia, view, viewPago, representante, moneda, persona_autoriza, xPrecio, vCambioPrecioCliente, retencion1, retencion2);
        }

        public static Tuple<bool> Venta_DevolverPrestamos(int xIdPrestamo,int xIdEmpleado, int xVendedor, int xNumero, int xIdCliente, DateTime xFecha, DateTime xFechaMaxima, decimal xTipoCambio, string xObservacion, int xTipo, int xIdTermino, string xPersonaReferencia, DevExpress.XtraGrid.Views.Grid.GridView view, DevExpress.XtraGrid.Views.Grid.GridView viewPago, string representante, int moneda, int persona_autoriza, int xPrecio, int vCambioPrecioCliente, decimal retencion1, decimal retencion2)
        {
            VentasCD obj = new VentasCD();
            return obj.Venta_DevolverPrestamos(xIdPrestamo, xIdEmpleado, xVendedor, xNumero, xIdCliente, xFecha, xFechaMaxima, xTipoCambio, xObservacion, xTipo, xIdTermino, xPersonaReferencia, view, viewPago, representante, moneda, persona_autoriza, xPrecio, vCambioPrecioCliente, retencion1, retencion2);
        }

        public static Tuple<bool, int, string> Remision_Guardar(int xIdEmpleado, int xVendedor, int xNumero, int xIdCliente, DateTime xFecha, DateTime xFechaMaxima, decimal xTipoCambio, string xObservacion, int xTipo, int xIdTermino, string xPersonaReferencia, DevExpress.XtraGrid.Views.Grid.GridView view, DevExpress.XtraGrid.Views.Grid.GridView viewPago, string representante, int moneda, int persona_autoriza, int xPrecio, int vCambioPrecioCliente)
        {
            VentasCD obj = new VentasCD();
            return obj.Remision_Guardar(xIdEmpleado, xVendedor, xNumero, xIdCliente, xFecha, xFechaMaxima, xTipoCambio, xObservacion, xTipo, xIdTermino, xPersonaReferencia, view, viewPago, representante, moneda, persona_autoriza, xPrecio, vCambioPrecioCliente);
        }

        public static Tuple<bool, int, string> Prestamo_Guardar(int xIdEmpleado, int xVendedor, int xNumero, int xIdCliente, DateTime xFecha, DateTime xFechaMaxima, decimal xTipoCambio, string xObservacion, int xTipo, int xIdTermino, string xPersonaReferencia, DevExpress.XtraGrid.Views.Grid.GridView view, DevExpress.XtraGrid.Views.Grid.GridView viewPago, string representante, int moneda, int persona_autoriza, int xPrecio, int vCambioPrecioCliente)
        {
            VentasCD obj = new VentasCD();
            return obj.Prestamo_Guardar(xIdEmpleado, xVendedor, xNumero, xIdCliente, xFecha, xFechaMaxima, xTipoCambio, xObservacion, xTipo, xIdTermino, xPersonaReferencia, view, viewPago, representante, moneda, persona_autoriza, xPrecio, vCambioPrecioCliente);
        }
        public static Tuple<bool, int> Cotizacion_Actualizar(int id_cotizacion, int xIdEmpleado, int xVendedor, int xIdCliente, DateTime xFecha, DateTime xFechaMaxima, decimal xTipoCambio, string xObservacion, string xPersonaReferencia, DevExpress.XtraGrid.Views.Grid.GridView view, string representante, int moneda, int persona_autoriza, int xPrecio, int vCambioPrecioCliente)
        {
            VentasCD obj = new VentasCD();
            return obj.Cotizacion_Actualizar( id_cotizacion,  xIdEmpleado,  xVendedor, xIdCliente,  xFecha,  xFechaMaxima, xTipoCambio,  xObservacion,  xPersonaReferencia,  view,  representante,  moneda,  persona_autoriza,  xPrecio,  vCambioPrecioCliente);
        }

        public static Tuple<bool, int> Remision_Actualizar(int id_cotizacion, int xIdEmpleado, int xVendedor, int xIdCliente, DateTime xFecha, DateTime xFechaMaxima, decimal xTipoCambio, string xObservacion, string xPersonaReferencia, DevExpress.XtraGrid.Views.Grid.GridView view, string representante, int moneda, int persona_autoriza, int xPrecio, int vCambioPrecioCliente)
        {
            VentasCD obj = new VentasCD();
            return obj.Remision_Actualizar(id_cotizacion, xIdEmpleado, xVendedor, xIdCliente, xFecha, xFechaMaxima, xTipoCambio, xObservacion, xPersonaReferencia, view, representante, moneda, persona_autoriza, xPrecio, vCambioPrecioCliente);
        }

        public static Tuple<bool, int> Prestamo_Actualizar(int id_cotizacion, int xIdEmpleado, int xVendedor, int xIdCliente, DateTime xFecha, DateTime xFechaMaxima, decimal xTipoCambio, string xObservacion, string xPersonaReferencia, DevExpress.XtraGrid.Views.Grid.GridView view, string representante, int moneda, int persona_autoriza, int xPrecio, int vCambioPrecioCliente)
        {
            VentasCD obj = new VentasCD();
            return obj.Prestamo_Actualizar(id_cotizacion, xIdEmpleado, xVendedor, xIdCliente, xFecha, xFechaMaxima, xTipoCambio, xObservacion, xPersonaReferencia, view, representante, moneda, persona_autoriza, xPrecio, vCambioPrecioCliente);
        }
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static Tuple<bool,int,string> Venta_Devolucion(int xIdVenta,DateTime xFecha,string xObservacion,int xIdEmpleado,int xTipoVenta)
        {
            VentasCD obj = new VentasCD();
            return obj.Venta_Devolucion(xIdVenta,xFecha,xObservacion,xIdEmpleado,xTipoVenta);
        }

        public static Tuple<bool, int> Remision_Devolucion(int xIdVenta, DateTime xFecha, string xObservacion, int xIdEmpleado, int xTipoVenta)
        {
            VentasCD obj = new VentasCD();
            return obj.Remision_Devolucion(xIdVenta, xFecha, xObservacion, xIdEmpleado, xTipoVenta);
        }

        [DataObjectMethod(DataObjectMethodType.Fill)]
        public static List<Venta> getVentas( )
        {
            VentasCD obj = new VentasCD();
            return obj.getVentas();
        }

        public static List<Prestamos> getPrestamos()
        {
            VentasCD obj = new VentasCD();
            return obj.getPrestamos();
        }

        [DataObjectMethod(DataObjectMethodType.Fill)]
        public static List<Ventas_SELECT_Result> Ventas_Select(int xTipo)
        {
            VentasCD obj = new VentasCD();
            return obj.Ventas_Select(xTipo);
        }

        public static List<Ventas_SELECT_Devoluciones_Result> Ventas_Select_Devoluciones(int xTipo)
        {
            VentasCD obj = new VentasCD();
            return obj.Ventas_Select_Devoluciones(xTipo);
        }

        public static List<Ventas_SELECT_DevolucionesProductoDañado_Result> Ventas_SELECT_DevolucionesProductoDañado(int xTipo)
        {
            VentasCD obj = new VentasCD();
            return obj.Ventas_SELECT_DevolucionesProductoDañado(xTipo);
        }

        

        public static List<Ventas_SELECT_REMISION_Result> Ventas_Select_Remision(int xTipo)
        {
            VentasCD obj = new VentasCD();
            return obj.Ventas_Select_Remision(xTipo);
        }

        public static List<Ventas_SELECT_PRESTAMOS_Result> Ventas_Select_Prestamos(int xTipo)
        {
            VentasCD obj = new VentasCD();
            return obj.Ventas_Select_Prestamos(xTipo);
        }
        [DataObjectMethod(DataObjectMethodType.Fill)]
        public static List<Ventas_SELECT_SIN_CANCELAR_Result> Ventas_Sin_Cancelar( )
        {

            VentasCD obj = new VentasCD();
            return obj.Ventas_Sin_Cancelar();
        }
        [DataObjectMethod(DataObjectMethodType.Fill)]
        public static List<Ventas_SELECT_Por_ID_Result> Ventas_Select_por_ID(int id)
        {
            VentasCD obj = new VentasCD();
            return obj.Ventas_Select_por_ID(id);
        }
        public static int moneda_facatura(int id)
        {
            VentasCD obj = new VentasCD();
            return obj.moneda_facatura(id);
        }

        [DataObjectMethod(DataObjectMethodType.Fill)]
        public static List<VentasDetalle_SELECT_Result> VentasDetalle_Select(int xIdVenta)
        {
            VentasCD obj = new VentasCD();
            return obj.VentasDetalle_Select(xIdVenta);
        }

        public static List<PrestamoDetalle_SELECT_Result> PrestamoDetalle_SELECT(int xIdVenta)
        {
            VentasCD obj = new VentasCD();
            return obj.PrestamoDetalle_SELECT(xIdVenta);
        }
        public static List<VentaDetalles_Select_Todas_Result> Detalles_Todos( )
        {
            VentasCD cd= new VentasCD();
            return cd.Detalles_Todos();
        }

        [DataObjectMethod(DataObjectMethodType.Fill)]
        public static DataTable getVentasDetalle(int xIdVenta)
        {
            VentasCD obj = new VentasCD();
            return obj.getVentasDetalle(xIdVenta);
        }

        public static DataTable getPrestamoDetalle(int xIdVenta)
        {
            VentasCD obj = new VentasCD();
            return obj.getPrestamoDetalle(xIdVenta);
        }
        public static List<Detalle_Cotizacion> Cargar_Detalle_Cotizacion(int xIdVenta)
        {
            VentasCD obj = new VentasCD();
            return obj.Cargar_Detalle_Cotizacion(xIdVenta);
        }

        public static List<Detalle_Prestamo> Cargar_Detalle_Prestamo(int xIdVenta)
        {
            VentasCD obj = new VentasCD();
            return obj.Cargar_Detalle_Prestamo(xIdVenta);
        }
        [DataObjectMethod(DataObjectMethodType.Update)]
        public static int Venta_Eliminar(int xId, int xIdUsuario)
        {
            VentasCD obj = new VentasCD();
            return obj.Venta_Eliminar(xId, xIdUsuario);
        }

        [DataObjectMethod(DataObjectMethodType.Fill)]
        public static List<Venta_REPORTE_Result> Venta_Reporte(int xId)
        {
            VentasCD obj = new VentasCD();
            return obj.Venta_Reporte(xId);
        }

        public static List<Venta_Prestamo_REPORTE_Result> Venta_Prestamo_REPORTE(int xId)
        {
            VentasCD obj = new VentasCD();
            return obj.Venta_Prestamo_REPORTE(xId);
        }


        [DataObjectMethod(DataObjectMethodType.Fill)]
        public static List<FormaPago_SELECTVENTA_Result> FormaPago_SelectVenta(int xIdVenta)
        {
            VentasCD obj = new VentasCD();
            return obj.FormaPago_SelectVenta(xIdVenta);
        }

        [DataObjectMethod(DataObjectMethodType.Fill)]
        public static List<FormaPago> getFormaPago()
        {
            VentasCD obj = new VentasCD();
            return obj.getFormaPago();
        }

        [DataObjectMethod(DataObjectMethodType.Fill)]
        public static List<FormaPago_SELECT_Result> FormaPago_Select()
        {
            VentasCD obj = new VentasCD();
            return obj.FormaPago_Select();
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static int FormaPago_Insertar(string xDescripcion, string xDescripcionCorta, int xMoneda, byte[] xImagen,bool efectivo)
        {
            VentasCD obj = new VentasCD();
            return obj.FormaPago_Insertar(xDescripcion, xDescripcionCorta, xMoneda, xImagen, efectivo);
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public static int FormaPago_Modificar(int xId, string xDescripcion, string xDescripcionCorta, int xMoneda, bool efectivo, byte[] xImagen, int xIdUsuario)
        {
            VentasCD obj = new VentasCD();
            return obj.FormaPago_Modificar(xId, xDescripcion, xDescripcionCorta, xMoneda, efectivo, xImagen, xIdUsuario);
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public static int FormaPago_Eliminar(int xId, int xIdUsuario)
        {
            VentasCD obj = new VentasCD();
            return obj.FormaPago_Eliminar(xId, xIdUsuario);
        }

        [DataObjectMethod(DataObjectMethodType.Fill)]
        public static List<FormaPagoVenta> getFormaPagoVenta()
        {
            VentasCD obj = new VentasCD();
            return obj.getFormaPagoVenta();
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static int ExisteAbonoFactura(int xIdVenta)
        {
            VentasCD obj = new VentasCD();
            return obj.ExisteAbonoFactura(xIdVenta);
        }

        public static int devolverMoneda(int xIdVenta)
        {
            VentasCD obj = new VentasCD();
            return obj.devolverMoneda(xIdVenta);
        }

        #region CONSULTA DE REPORTES

        [DataObjectMethod(DataObjectMethodType.Fill)]
        public static List<VentasPorFecha_Result> VentasPorFechas(int xTipo, DateTime xFechaInicial, DateTime xFechaFin)
        {
            VentasCD obj = new VentasCD();
            return obj.VentasPorFechas(xTipo, xFechaInicial, xFechaFin);
        }
        public static List<reportes_de_ventas_Result> Ventas_Reportes(DateTime xFechaInicial, DateTime xFechaFin)
        {
            VentasCD obj = new VentasCD();
            return obj.Ventas_Reportes(xFechaInicial, xFechaFin);
        }

        /// <summary>
        /// Retorna un TOP 10 de Clientes y Productos, para cada cliente trae los 10 productos mas llevados por esos clientes 
        /// </summary>
        /// <param name="desde">Fecha inicio de la Busqueda</param>
        /// <param name="Hasta">Fecha Final de la Busqueda</param>
        /// <returns>Lista TOP_10_PRODUCTOS_POR_CLIENTES_RANGO_Result</returns>
        //public List<TOP_10_PRODUCTOS_POR_CLIENTES_RANGO_Result> Top10ProductosPorClientes(DateTime desde,DateTime Hasta)
        //{
        //    VentasCD vd= new VentasCD();
        //    return vd.Top10ProductosPorClientes(desde,Hasta);
        //}
        /// <summary>
        /// Retorna un TOP 10 de clientes que mas compran en el periodo dado.
        /// </summary>
        /// <param name="desde">Fecha inicio de la Busqueda</param>
        /// <param name="Hasta">Fecha finl de la busqueda</param>
        /// <param name="moneda">Tipo de moneda 1 Para cordobas, 2 para Dolares</param>
        /// <returns></returns>
        //public List<TOP_10_CLIENTES_VENTAS_POR_RANGO_MONEDA_Result> Top10ClientesPorRangoMoneda(DateTime desde,DateTime Hasta,int moneda)
        //{
        //    VentasCD vd= new VentasCD();
        //    return vd.Top10ClientesPorRangoMoneda(desde,Hasta,moneda);
        //}
        /// <summary>
        /// Retorna TOP 10 de los productos mas vendidos en un rango dado de un grupo especifico.
        /// </summary>
        /// <param name="desde">Fecha inicio de la Busqueda</param>
        /// <param name="Hasta">Fecha finl de la busqueda</param>
        /// <param name="id_grupo">Id de la tabla Categorias</param>
        /// <returns></returns>
        public static List<productos_mas_vendidos_Result> Top10ProductosMasVendidos_Rango (int top,DateTime desde,DateTime Hasta)
        {
            VentasCD vd= new VentasCD();
            return vd.Top10ProductosMasVendidos_Rango (top,desde,Hasta);
        }

        public static List<Productos_Mas_vendidos_Rango_Result> Productos_mas_Vendidos_Rango(DateTime desde, DateTime Hasta)
        {
            VentasCD obj = new VentasCD();
            return obj.Productos_mas_Vendidos_Rango(desde, Hasta);
        }

        public static List<Detalle_Producto_mas_vendido_Result> Detalle_producto_vendido(DateTime desde, DateTime Hasta, int xId_producto)
        {
            VentasCD obj = new VentasCD();
            return obj.Detalle_producto_vendido(desde, Hasta, xId_producto);
        }

        public static List<ClientesMasFrecuentes_Result> Cliete_Frecuencia_select(DateTime xfecha_ini, DateTime xfecha_fin)
        {
            VentasCD obj = new VentasCD();
            return obj.Cliete_Frecuencia_select(xfecha_ini, xfecha_fin);
        }

        public static List<ClientesMasFrecuentesV2_Result> Cliete_Frecuencia_selectV2(DateTime xfecha_ini, DateTime xfecha_fin)
        {
            VentasCD obj = new VentasCD();
            return obj.Cliete_Frecuencia_selectV2(xfecha_ini, xfecha_fin);
        }

        public static void DesactivarCotizacion(int idCotizacion)
        {
            VentasCD obj = new VentasCD();
            obj.DesactivarCotizacion(idCotizacion);
        }

        public static void PasarPrestamoAFacturado(int idCotizacion)
        {
            VentasCD obj = new VentasCD();
            obj.PasarPrestamoAFacturado(idCotizacion);
        }
        [DataObjectMethod(DataObjectMethodType.Fill)]
        public static List<deteccionCambioPrecioCliente_Result> getDetectarCambioPrecioCliente(DateTime fecha)
        {
            VentasCD obj = new VentasCD();
            return obj.getDetectarCambioPrecioCliente(fecha);
        }

        public static List<Cliente> getPrecioClientes()
        {
            VentasCD obj = new VentasCD();
            return obj.getPrecioCliente();
        }

        public static List<VentasPorSubGrupo_Result> Ventas_SubGrupo(DateTime fecha_ini, DateTime fecha_fin)
        {
            VentasCD obj = new VentasCD();
            return obj.Ventas_SubGrupo(fecha_ini, fecha_fin);
        }

        #endregion
    }
}