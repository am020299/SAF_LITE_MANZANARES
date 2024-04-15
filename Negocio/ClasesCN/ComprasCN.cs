using Datos.ClasesCD;
using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.ClasesCN
{
    public class ComprasCN
    {
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static Tuple<bool, int, string> Compra_Guardar(string xNumero, int xIdProveedor, DateTime xFecha, DateTime xFechaEstimada, string xObservacion, DevExpress.XtraGrid.Views.Grid.GridView view)
        {
            ComprasCD obj = new ComprasCD();
            return obj.Compra_Guardar(xNumero, xIdProveedor, xFecha, xFechaEstimada, xObservacion, view);
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public static bool Compra_Modificar(int xId, string xNumero, int xIdProveedor, DateTime xFecha, DateTime xFechaEstimada, string xObservacion, DevExpress.XtraGrid.Views.Grid.GridView view)
        {
            ComprasCD obj = new ComprasCD();
            return obj.Compra_Modificar(xId, xNumero, xIdProveedor, xFecha, xFechaEstimada, xObservacion, view);
        }

        [DataObjectMethod(DataObjectMethodType.Fill)]
        public static List<Compras_SELECT_Result> Compras_Select()
        {
            ComprasCD obj = new ComprasCD();
            return obj.Compras_Select();
        }

        [DataObjectMethod(DataObjectMethodType.Fill)]
        public static List<Compras> getCompras()
        {
            ComprasCD obj = new ComprasCD();
            return obj.getCompras();
        }

        [DataObjectMethod(DataObjectMethodType.Fill)]
        public static DataTable getComprasDetalle(int xIdCompra)
        {
            ComprasCD obj = new ComprasCD();
            return obj.getComprasDetalle(xIdCompra);
        }

        public static List<Compras_SELECT_PRODUCTO_Result> Compras_Select_PRODUCTO(int id_producto, DateTime fecha_ini, DateTime fecha_fin)
        {
            ComprasCD obj = new ComprasCD();
            return obj.Compras_Select_PRODUCTO(id_producto, fecha_ini, fecha_fin);
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public static int Compra_Eliminar(int xId, int xIdUsuario)
        {
            ComprasCD obj = new ComprasCD();
            return obj.Compra_Eliminar(xId, xIdUsuario);
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public static Tuple<bool, int, string> Compra_Recibir(int xIdCompra, int xIdUsuario, bool xActualizarCosto, DateTime xFecha, string xNumeroReferencia, string xObservacion, int xIdEmpleado, string xPersonaReferencia, DevExpress.XtraGrid.Views.Grid.GridView view)
        {
            ComprasCD obj = new ComprasCD();
            return obj.Compra_Recibir(xIdCompra, xIdUsuario, xActualizarCosto, xFecha, xNumeroReferencia, xObservacion, xIdEmpleado, xPersonaReferencia, view);
        }

        [DataObjectMethod(DataObjectMethodType.Fill)]
        public static List<Compras_REPORTE_Result> Compras_Reporte(int xId)
        {
            ComprasCD obj = new ComprasCD();
            return obj.Compras_Reporte(xId);
        }

        [DataObjectMethod(DataObjectMethodType.Fill)]
        public static List<Compras_REPORTE_PRODUCTO_RECIBIDO_Result> Compras_Reporte_Producto_recibido(int xId)
        {
            ComprasCD obj = new ComprasCD();
            return obj.Compras_Reporte_Producto_recibido(xId);
        }
    }
}
