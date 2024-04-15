using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos.ClasesCD;
using System.ComponentModel;
using DevExpress.XtraGrid.Views.Grid;

namespace Negocio.ClasesCN
{
    public class CuentasCobrarCN
    {
        #region Parametros
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<CuentasContables> CuentasContables_Select( )
        {
            CuentasCobrarCD obj= new CuentasCobrarCD();
            return obj.CuentasContablesParametros_Select();
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<ModuloSistema> ModuloSistema_Select( )
        {
            CuentasCobrarCD obj= new CuentasCobrarCD();
            return obj.ModulosSistema_Select();
        }
        [DataObjectMethod(DataObjectMethodType.Update)]
        public static int CuentaContable_Update(string numero_cuenta,int id_cuenta,int id_usuario)
        {
            CuentasCobrarCD obj= new CuentasCobrarCD();
            return obj.CuentaContable_Update(numero_cuenta,id_cuenta,id_usuario);
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<TiposDocumentosCx> TiposDocumentosCxc( )
        {
            CuentasCobrarCD obj= new CuentasCobrarCD();
            return obj.TiposDocumentosCxc();
        }
        #endregion
        #region CUENTAS POR COBRAR
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<DocumentosCuentasCobrar> DocumentosCuentasCobrar_Select( )
        {
            CuentasCobrarCD obj= new CuentasCobrarCD();
            return obj.DocumentosCuentasCobrar_Select();
        }
        public static List<CuentasCobrarSelect_Result> CuentasCobrarMaestro_Select( )
        {
            CuentasCobrarCD obj= new CuentasCobrarCD();
            return obj.CuentasCobrarMaestro_Select();
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<CuentasCobrarDetalles_Select_Result> CuentasCobrarDetalles_Todos( )
        {
            CuentasCobrarCD obj= new CuentasCobrarCD();
            return obj.CuentasCobrarDetalles_Todos();
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<CuentasCobrarDetalles_Select_Cliente_Result> CuentasCobrarDetalles_Todos(int id_cliente)
        {
            CuentasCobrarCD obj= new CuentasCobrarCD();
            return obj.CuentasCobrarDetalles_Todos(id_cliente);
        }
        public static List<DocumentosCuentasCobrar_Clientes_Select_Result> DocumentosCuentasCobrar_Por_cliente(int id_cliente)
        {
            CuentasCobrarCD obj= new CuentasCobrarCD();
            return obj.DocumentosCuentasCobrar_Por_cliente(id_cliente);

        }

        public static List<CargarClienteCobrar_Result> CargarCliente_Select()
        {
            CuentasCobrarCD obj = new CuentasCobrarCD();
            return obj.CargarCliente_Select();
        }
        public static Documento_Cliente_Select_Result Documento_Cliente_Select_Fila(int id_cliente,int id_documento)
        {
            CuentasCobrarCD obj= new CuentasCobrarCD();
            return obj.Documento_Cliente_Select_Fila(id_cliente,id_documento);
        }
        public static int Verfica_maximo_documento(int tipo_documento)
        {
            CuentasCobrarCD obj= new CuentasCobrarCD();
            return obj.Verfica_maximo_documento(tipo_documento);

        }

        public static int DocumentosCuentasCobrar_Insert(int tipo_documento,int id_cliente,int numero_documento,DateTime fecha_doc,decimal monto_total_doc,decimal sub_total_doc,decimal descuento,decimal impuesto,int id_usuario,string concepto_documento,int id_cobrador,decimal retenciones,bool hay_contabilidad,int id_terminos,int numero_modulo,int id_factura)
        {
            CuentasCobrarCD obj= new CuentasCobrarCD();
            return obj.DocumentosCuentasCobrar_Insert(tipo_documento,id_cliente,numero_documento,fecha_doc,monto_total_doc,sub_total_doc,descuento,impuesto,id_usuario,concepto_documento,id_cobrador,retenciones,hay_contabilidad,id_terminos,numero_modulo,id_factura);
        }
        public static DocumentosCuentasCobrar DocumentosCuentasCobrar_Select(int id_documento)
        {
            CuentasCobrarCD obj= new CuentasCobrarCD();
            return obj.DocumentosCuentasCobrar_Select(id_documento);
        }

        public static int AnularRecibo(int id_documento)
        {
            CuentasCobrarCD obj = new CuentasCobrarCD();
            return obj.AnularRecibo(id_documento);
        }

        public static bool Documento_ya_Aplicado(int id_documento)
        {
            CuentasCobrarCD obj= new CuentasCobrarCD();
            return obj.Documento_ya_Aplicado(id_documento);
        }
        public static bool Existe_numero_documento(int numero_doc,int tipo_documento)
        {
            CuentasCobrarCD obj = new CuentasCobrarCD();
            return obj.Existe_numero_documento(numero_doc,tipo_documento);
        }
        public static int DocumentosCuentasCobrar_Eliminar(int id_documento,int id_usuario,int numero_modulo)
        {
            CuentasCobrarCD obj = new CuentasCobrarCD();
            return obj.DocumentosCuentasCobrar_Anular(id_documento,id_usuario,numero_modulo);
        }
        public static int DocumentosCuentasCobrar_Update(int tipo_documento,int id_cliente,int numero_documento,DateTime fecha_doc,decimal monto_total_doc,decimal sub_total_doc,decimal descuento,decimal impuesto,int id_usuario,string concepto_documento,int id_cobrador,decimal retenciones,bool hay_contabilidad,int id_terminos,int numero_modulo,int id_documento)
        {
            CuentasCobrarCD obj= new CuentasCobrarCD();
            return obj.DocumentosCuentasCobrar_Update(tipo_documento,id_cliente,numero_documento,fecha_doc,monto_total_doc,sub_total_doc,descuento,impuesto,id_usuario,concepto_documento,id_cobrador,retenciones,hay_contabilidad,id_terminos,numero_modulo,id_documento);
        }
        public static int Aplica_documento_Cuentas_cobrar(int id_tipo_documento, int id_cliente, decimal sub_total_doc, string concepto_documento, int id_usuario, int id_cobrador, GridView Grilla, bool permit_seleccionar)
        {
            CuentasCobrarCD obj = new CuentasCobrarCD();
            return obj.Aplica_documento_Cuentas_cobrar( id_tipo_documento, id_cliente,  sub_total_doc,  concepto_documento,  id_usuario,id_cobrador,  Grilla,  permit_seleccionar);
        }

        public static List<Documento_AplicadosCargar_Result> Documentos_AplicadosCargar()
        {
            CuentasCobrarCD obj = new CuentasCobrarCD();
            return obj.Documentos_AplicadosCargar();
        }
        public static List<Report_Documento_Select_FilaCxc_Result> Reporte_Documentos_Fila_Select(int id_documento)
        {
            CuentasCobrarCD objCD = new CuentasCobrarCD();
            return objCD.Reporte_Documento_Select_Fila(id_documento).ToList();
        }

        #endregion
        #region Reportes
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<Movimientos_Por_Rango_Fechas_Result> Documentos_CuentasCobrar_Select_Rango(DateTime Desde,DateTime hasta)
        {
            CuentasCobrarCD obj = new CuentasCobrarCD();
            return obj.Documentos_CuentasCobrar_Select_Rango(Desde,hasta);
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<Documento_Select_Fila_Result> Documentos_Fila_Select(int id_documento)
        {
            CuentasCobrarCD objCD = new CuentasCobrarCD();
            return objCD.Documento_Select_Fila(id_documento).ToList();
        }

        public static List<Antiguedad_de_saldos_Result> Antiguedad_de_saldos_cuentas_por_cobrar()
        {
            CuentasCobrarCD obj = new CuentasCobrarCD();
            return obj.Antiguedad_de_saldos_cuentas_por_cobrar();
        }

        public static List<Estado_Cuenta_CXC_Result> Estado_cuenta(int id_cliente, DateTime Desde, DateTime Hasta)
        {
            CuentasCobrarCD obj = new CuentasCobrarCD();
            return obj.Estado_cuenta(id_cliente, Desde, Hasta);
        }

        public static List<ver_deuda_clientes_Result> cxc_clientes(int estado)
        {
            CuentasCobrarCD obj = new CuentasCobrarCD();
            return obj.cxc_clientes(estado);
        }

        #endregion

    }
}
