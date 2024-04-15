using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos.ClasesCD;
using System.ComponentModel;

namespace Negocio.ClasesCN
{
    public class CajaCN
    {
        #region SALDO INICIAL
        public static int SALDO_INICIAL_GUARDAR(DateTime fecha, decimal saldo, int id_empleado, decimal tc)
        {
            CajaCD obj = new CajaCD();
            return obj.SALDO_INICIAL_GUARDAR(fecha, saldo, id_empleado, tc);
        }
        public static int SALDO_INICIAL_ELIMINAR(int id_cierre, int id_empleado)
        {
            CajaCD obj = new CajaCD();
            return obj.SALDO_INICIAL_ELIMINAR(id_cierre,id_empleado);
        }
        public static int SALDO_INICIAL_EDITAR(int id_cierre, DateTime fecha, decimal saldo, int id_empleado, decimal tc)
        {
            CajaCD obj = new CajaCD();
            return obj.SALDO_INICIAL_EDITAR(id_cierre, fecha, saldo, id_empleado, tc);
        }
        public static List<SaldoInicial_Mostrar_Result> SALDO_INICIAL_MOSTRAR()
        {
            CajaCD obj = new CajaCD();
            return obj.SALDO_INICIAL_MOSTRAR();
        }
        #endregion
        #region VALIDACION SALDO INICIAL
        public static bool SI_EXISTE_YA_UNA_FECHA_INGRESADA(DateTime fecha)
        {
            CajaCD obj = new CajaCD();
            return obj.SI_EXISTE_YA_UNA_FECHA_INGRESADA(fecha);
        }
        public decimal SALDO_INICIAL_DIA(DateTime fecha)
        {
            CajaCD obj = new CajaCD();
            return obj.SALDO_INICIAL_DIA(fecha);
        }
        #endregion
        #region MOVIMIENTO DE CAJA
        public static int MOVIMIENTO_CAJA_GUARDAR( DateTime fecha, string concepto, string persona, int tipo_movimiento, int id_documento, int tipo_documento, string numero_referencia, int id_usuario, decimal tipo_cambio, DevExpress.XtraGrid.Views.Grid.GridView view_pago, int N_Transferencia, DateTime fecha_deposito)
        {
            CajaCD obj = new CajaCD();
            return obj.MOVIMIENTO_CAJA_GUARDAR( fecha, concepto, persona, tipo_movimiento,id_documento, tipo_documento, numero_referencia, id_usuario, tipo_cambio,view_pago, N_Transferencia, fecha_deposito);     
        }
        public static int MOVIMIENTO_CAJA_GUARDAR_DETALLE(int id_movimiento, int tipo_movimiento, decimal tipo_cambio, decimal cantidad, int id_forma, int N_Transferencia, DateTime fecha_deposito)
        {
            //tipo movimiento 1 entrada 0 salida moneda --1 cordoba 2 dolar --1 tarjeta 2 efectivo
            CajaCD obj = new CajaCD();
            return obj.MOVIMIENTO_CAJA_GUARDAR_DETALLE(id_movimiento, tipo_movimiento, tipo_cambio, cantidad, id_forma, N_Transferencia, fecha_deposito);
        }
        public static int MOVIMIENTO_CAJA_ELIMINAR(int id_usuario, int id_movimiento)
        {
            CajaCD obj = new CajaCD();
            return obj.MOVIMIENTO_CAJA_ELIMINAR(id_usuario, id_movimiento);
        }
        public static List<MovimientoCaja_Mostrar_Result> MOVIMIENTO_CAJA_MOSTRAR(DateTime fecha)
        {
            CajaCD obj = new CajaCD();
            return obj.MOVIMIENTO_CAJA_MOSTRAR(fecha);
        }
        public static List<MovimientoCaja_Mostrar_Cordobas_Result> MOVIMIENTO_CAJA_MOSTRAR_CORDOBAS(DateTime fecha)
        {
            CajaCD obj = new CajaCD();
            return obj.MOVIMIENTO_CAJA_MOSTRAR_CORDOBAS(fecha);
        }

        public static List<MovimientoCaja_Mostrar_Empleado_Result> MOVIMIENTO_CAJA_MOSTRAR_EMPLEADO(DateTime fecha, int idEmpleado)
        {
            CajaCD obj = new CajaCD();
            return obj.MOVIMIENTO_CAJA_MOSTRAR_EMPLEADO(fecha, idEmpleado);
        }
        public static List<MovimientoCaja_Mostrar_Cordobas_Empleados_Result> MOVIMIENTO_CAJA_MOSTRAR_CORDOBAS_EMPLEADO(DateTime fecha, int idEmpleado)
        {
            CajaCD obj = new CajaCD();
            return obj.MOVIMIENTO_CAJA_MOSTRAR_CORDOBAS_EMPLEADO(fecha, idEmpleado);
        }
        #endregion
        #region CIERRE DE CAJA
        public static int CIERRE_CAJA_GUARDAR(DateTime fecha, decimal saldo, int id_empleado)
        {
            CajaCD obj = new CajaCD();
            return obj.CIERRE_CAJA_GUARDAR(fecha, saldo, id_empleado);
        }

        public static int REABRIR_ARQUEO_CAJA(DateTime fecha)
        {
            CajaCD obj = new CajaCD();
            return obj.REABRIR_ARQUEO_CAJA(fecha);
        }
        #endregion
        #region ARQUEO CAJA
        public static List<Arqueo_En_Blanco_Select_Result> Arqueo_en_blanco( )
        {
            CajaCD dc= new CajaCD();
            return dc.Arqueo_en_blanco();
        }
        public static Arqueos Buscar_Arqueo_Fecha(DateTime Fecha, int id_empleado)
        {
            CajaCD dc= new CajaCD();
            return dc.Buscar_Arqueo_Fecha(Fecha, id_empleado);
        }

        public static int Buscar_Arqueo_Fecha_General(DateTime Fecha)
        {
            CajaCD dc = new CajaCD();
            return dc.Buscar_Arqueo_Fecha_General(Fecha);
        }

        public static List<Arqueo_Obetener_ID_GeneralDia_Result> Buscar_Arqueo_Fecha_Validar(DateTime Fecha)
        {
            CajaCD dc = new CajaCD();
            return dc.Buscar_Arqueo_Fecha_Validar(Fecha);
        }

        public static List<Arqueo_reporte_select_Result> Reporte_Arqueo(int id)
        {
            CajaCD dc= new CajaCD();
            return dc.Reporte_Arqueo(id);
        }

        public static List<Arqueo_reporte_select_General_Result> Reporte_Arqueo_General(DateTime fecha)
        {
            CajaCD dc = new CajaCD();
            return dc.Reporte_Arqueo_General(fecha);
        }

        public static List<Arqueo_reporte_select_Empleado_Result> Reporte_Arqueo_Emmpleado(int id, int idEmpleado)
        {
            CajaCD dc = new CajaCD();
            return dc.Reporte_Arqueo_Empleado(id, idEmpleado);
        }
        public static List<Arqueo_Select_Por_ID_Result> Cargar_Arqueo_por_ID(int id_arqueo)
        {

            CajaCD dc= new CajaCD();
            return dc.Cargar_Arqueo_por_ID(id_arqueo);
        }

        public static List<Arqueo_Select_Por_Fecha_Result> Cargar_Arqueo_por_Fecha(DateTime fecha)
        {

            CajaCD dc = new CajaCD();
            return dc.Cargar_Arqueo_por_Fecha(fecha);
        }

        public static bool Arqueo_Guardar(DateTime fecha_arqueo,int empleado,int estado_arqueo,decimal tipo_cambio,DevExpress.XtraGrid.Views.Grid.GridView view_cordobas_inicial,DevExpress.XtraGrid.Views.Grid.GridView view_dolares_inicial,DevExpress.XtraGrid.Views.Grid.GridView view_cordobas_final,DevExpress.XtraGrid.Views.Grid.GridView view_dolares_final, int id_arqueo)
        {
            CajaCD dc= new CajaCD();
            return dc.Arqueo_Guardar(fecha_arqueo,  empleado,  estado_arqueo,  tipo_cambio,view_cordobas_inicial,view_dolares_inicial,  view_cordobas_final, view_dolares_final,id_arqueo);
        }
        #endregion
        #region VALIDACION CIERRE DE CAJA
        public static int VALIDAR_CIERRE_DE_CAJA(DateTime fecha)
        {
            CajaCD obj = new CajaCD();
            return obj.VALIDAR_CIERRE_DE_CAJA(fecha);
        }
        public static bool CONSULTAR_SI_FECHA_ESTA_CERRADA(DateTime fecha)
        {
            CajaCD obj = new CajaCD();
            return obj.CONSULTAR_SI_FECHA_ESTA_CERRADA(fecha);
        }
        public static bool CONSULTAR_SI_HAY_FACTURAS_SIN_RECIBO()
        {
            CajaCD obj = new CajaCD();
            return obj.CONSULTAR_SI_HAY_FACTURAS_SIN_RECIBO();
        }
        #endregion
        public static int numero_recibo(int tipo_movimiento)
        {
            CajaCD obj = new CajaCD();
            return obj.numero_recibo(tipo_movimiento);
        }
        public static List<PersonaReferencia> Personas_Referencias()
        {
            CajaCD obj = new CajaCD();
            return obj.Personas_Referencias();
        }
        public static decimal saldo_disponible_del_dia(DateTime fecha)
        {
            CajaCD obj = new CajaCD();
            return obj.saldo_disponible_del_dia(fecha);
        }
        public static decimal saldo_inicial_del_dia(DateTime fecha)
        {
            CajaCD obj = new CajaCD();
            return obj.saldo_inicial_del_dia(fecha);
        }
        public static List<Reporte_Recibo_Result> Reporte_de_recibo(int id_mov)
        {
            CajaCD obj = new CajaCD();
            return obj.Reporte_de_recibo(id_mov);
        }
        public static List<Reporte_Movimiento_Por_Dia_Result> Reporte_de_Movimiento(DateTime fecha)
        {
            CajaCD obj = new CajaCD();
            return obj.Reporte_de_Movimiento(fecha);
        }
        public static List<Reporte_Movimiento_Por_Dia_Detallado_Result> Reporte_de_Movimiento_Detallado(DateTime fecha)
        {
            CajaCD obj = new CajaCD();
            return obj.Reporte_de_Movimiento_Detallado(fecha);
        }
        public static List<Reporte_Movimiento_Egresos_Result> Reporte_de_Egresos(DateTime fecha_inicio, DateTime fecha_fin)
        {
            CajaCD obj = new CajaCD();
            return obj.Reporte_de_Egresos(fecha_inicio, fecha_fin);
        }
        public static List<Diferencia_recibir_venta_como_publicidad_Result> Diferencia_Precios(DateTime desde,DateTime Hasta)
        {
            CajaCD obj = new CajaCD();
            return obj.Diferencia_Precios(desde,Hasta);

        }
        public static List<Transferencias_SELECT_Result> TRANSFERENCIA_SELECT(DateTime fecha, int formapago)
        {
            CajaCD obj = new CajaCD();
            return obj.TRANSFERENCIAS_SELECT(fecha,formapago);

        }

        public static List<Transferencias_SELECT_Empleado_Result> TRANSFERENCIA_SELECT_Empleado(DateTime fecha, int formapago, int idEmpleado)
        {
            CajaCD obj = new CajaCD();
            return obj.TRANSFERENCIAS_SELECT_Empleado(fecha, formapago, idEmpleado);

        }

        public static List<Transferencias_rango_SELECT_Result> TRANSFERENCIA_rango_SELECT(DateTime fechaDesde, DateTime fechaHasta, int formapago)
        {
            CajaCD obj = new CajaCD();
            return obj.TRANSFERENCIAS_rango_SELECT(fechaDesde, fechaHasta, formapago);

        }

        public static List<SaldoFavorClientes_Select_Result> SaldoFavorClientes_Select(DateTime fechaDesde, DateTime fechaHasta)
        {
            CajaCD obj = new CajaCD();
            return obj.SaldoFavorClientes_Select(fechaDesde, fechaHasta);

        }

        

        public static List<Cheques_rango_SELECT_Result> CHEQUES_rango_SELECT(DateTime fechaDesde, DateTime fechaHasta, int formapago)
        {
            CajaCD obj = new CajaCD();
            return obj.CHEQUES_rango_SELECT(fechaDesde, fechaHasta, formapago);
        }

        public static List<cargarTodasTransferencias_Result> cargarTodasTransferencias()
        {
            CajaCD obj = new CajaCD();
            return obj.cargarTodasTransferencias();

        }

        public static List<cargarTodasCheques_Result> cargarTodosCheques()
        {
            CajaCD obj = new CajaCD();
            return obj.cargarTodosCheques();

        }
        public static List<MovimientoCajaDetalle> getMovimientoCajaDetalle()
        {
            CajaCD obj = new CajaCD();
            return obj.getMovimientoCajaDetalle();
        }
    }
}
