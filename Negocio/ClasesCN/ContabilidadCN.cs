using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.ClasesCD;
using DevExpress.XtraGrid.Views.Grid;
using Entidades;
namespace Negocio.ClasesCN
{
    public class ContabilidadCN
    {
        #region CUENTAS
        [DataObjectMethod(DataObjectMethodType.Fill)]
        public static List<VerCuentas> Cuentas_Select( )
        {
            ContabilidadCD CD = new ContabilidadCD();
            return CD.Cuentas_Select();

        }
        [DataObjectMethod(DataObjectMethodType.Fill)]
        public static List<ParametrosCuentasContables> GetParametrosCuentas()
        {
            ContabilidadCD CD = new ContabilidadCD();
            return CD.ParametrosCuentasContables_Select();

        }
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static int Cuenta_Insert(string numero_cuenta,string nombre_cuenta,string naturaleza,string clasificacion,bool agrupacion,bool deslizamiento,int nivel,int id_usuario)
        {
            ContabilidadCD CD = new ContabilidadCD();
            return CD.Cuenta_Insert(numero_cuenta,nombre_cuenta,naturaleza,clasificacion,agrupacion,deslizamiento,nivel,id_usuario);
        }
        [DataObjectMethod(DataObjectMethodType.Update)]
        public  static int Cuenta_Modificar(int id_cuenta,string numero_cuenta,string nombre_cuenta,bool agrupacion,bool deslizamiento,int nivel,int id_usuario)
        {
            ContabilidadCD CD = new ContabilidadCD();
            return CD.Cuenta_Modificar(id_cuenta,numero_cuenta,nombre_cuenta,agrupacion,deslizamiento,nivel,id_usuario);
        }
        [DataObjectMethod(DataObjectMethodType.Update)]
        public int Cuenta_Eliminar(int id_cuenta,string numero_cuenta,string nombre_cuenta,bool agrupacion,bool deslizamiento,int nivel,int id_usuario)
        {
            ContabilidadCD Cd= new ContabilidadCD();
            return Cd.Cuenta_Eliminar(id_cuenta,numero_cuenta,nombre_cuenta,agrupacion,deslizamiento,nivel,id_usuario);
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static bool Tiene_Movimientos(int id_cuenta)
        {
            ContabilidadCD cd= new ContabilidadCD();
            return cd.Tienen_Movimientos(id_cuenta);
        }
        public static Tuple<List<int>,List<int>> CuentasModificarAgrupacion_Deslizamiento(List<int> Lista_cuentas_modificar,bool agrupacion,bool deslizamiento,int id_usuario)
        {
            ContabilidadCD cd= new ContabilidadCD();
            return cd.CuentasModificarAgrupacion_Deslizamiento(Lista_cuentas_modificar,agrupacion,deslizamiento,id_usuario);

        }
        public static bool Cuenta_Validar(string numero_cuenta)
        {
            ContabilidadCD CD=new ContabilidadCD();
            return CD.Cuenta_Validar(numero_cuenta);
        }
        public static VerCuentas Cuenta(string numero_cuenta)
        {
            ContabilidadCD CD=new ContabilidadCD();
            return CD.Cuenta(numero_cuenta);
        }
        #endregion
        #region COMPROBANTES
        [DataObjectMethod(DataObjectMethodType.Fill)]
        public static List<TipoComprobante> Tipo_Comprobantes_Select( )
        {
            ContabilidadCD CD = new ContabilidadCD();
            return CD.Tipo_Comprobante_Select();

        }
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static int ComprobanteDiario_Insert(string concepto,int tipo,int id_usuario,DateTime fecha,GridView Grilla)
        {
            ContabilidadCD CD = new ContabilidadCD();
            return CD.ComprobanteDiario_Insert(concepto,tipo,id_usuario,fecha,Grilla);
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static DateTime Fecha_Primer_Asiento( )
        {
            ContabilidadCD CD = new ContabilidadCD();
            return CD.Fecha_Primer_Asiento();
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static DateTime Fecha_Ultimo_Asiento( )
        {
            ContabilidadCD CD = new ContabilidadCD();
            return CD.Fecha_Ultimo_Asiento();
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<Comprobante_diarios_Select_Result> Comprobante_Diarios_Select(DateTime Desde,DateTime Hasta,int Tipo_Documento)
        {
            ContabilidadCD CD = new ContabilidadCD();
            return CD.Comprobante_Diarios_Select(Desde.Date,Hasta.Date,Tipo_Documento);

        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<ComprobanteDiaarioDetalle_Select_Result> ComprobanteDiarioDetalles_Select(DateTime Desde,DateTime Hasta)
        {
            ContabilidadCD CD = new ContabilidadCD();
            return CD.ComprobanteDiarioDetalles_Select(Desde,Hasta);
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static ComprobanteDiario Comprobante_Diarios_Select(int id_comprobante)
        {
            ContabilidadCD CD = new ContabilidadCD();
            return CD.Comprobante_Diarios_Select(id_comprobante);
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static DataTable ComprobanteDiarioDetalles_Select(int id_comprobante)
        {
            ContabilidadCD CD = new ContabilidadCD();
            return CD.ComprobanteDiarioDetalles_Select(id_comprobante);
        }
        [DataObjectMethod(DataObjectMethodType.Update)]
        public static int ComprobanteDiarioDetalle_Actualizar(int id_detalle_actualizar)
        {
            ContabilidadCD CD = new ContabilidadCD();
            return CD.ComprobanteDiarioDetalle_Actualizar(id_detalle_actualizar);
        }
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static int comprobanteDiarioDetalle_Insertar(string numero_cuenta,int id_comprobante,decimal debe,decimal haber)
        {
            ContabilidadCD CD = new ContabilidadCD();
            return CD.comprobanteDiarioDetalle_Insertar(numero_cuenta,id_comprobante,debe,haber);
        }
        [DataObjectMethod(DataObjectMethodType.Update)]
        public static int ComprobanteDiario_Actualizar(int id_comprobante,int id_usuario,String Concepto_asiento)
        {
            ContabilidadCD cd= new ContabilidadCD();
            return cd.ComprobanteDiario_Actualizar(id_comprobante,id_usuario,Concepto_asiento);
        }
        [DataObjectMethod(DataObjectMethodType.Update)]
        public static int ComprobanteDiario_Eliminar(int id_comprobante,int id_usuario,string Motivo)
        {
            ContabilidadCD cd= new ContabilidadCD();
            return cd.ComprobanteDiario_Eliminar(id_comprobante,id_usuario,Motivo);
        }

        #endregion
        #region REPORTES
        public static List<ComprobanteDiario_Select_Reporte_Result> ComprobanteDiario_Reporte(int id_comprobante)
        {
            ContabilidadCD cd = new ContabilidadCD();
            return cd.ComprobanteDiario_Reporte(id_comprobante);
        }
        #endregion
    }
}
