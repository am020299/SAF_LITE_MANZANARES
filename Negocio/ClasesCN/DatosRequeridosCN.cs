using Datos.ClasesCD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.ClasesCN
{
    public class DatosRequeridosCN
    {
        [DataObjectMethod(DataObjectMethodType.Fill)]
        public static List<Tuple<DateTime, Decimal>> ObtenerCambioMensual(int Año, int Mes)
        {
            DatosRequeridosCD obj = new DatosRequeridosCD();
            return obj.ObtenerCambioMensual(Año, Mes);
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static bool Validar_archivo_tipo_cambio(DateTime Fecha)
        {
            DatosRequeridosCD obj = new DatosRequeridosCD();
            return obj.Validar_archivo_tipo_cambio(Fecha);
        }
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static int AgregaCambioContable(string fecha, decimal monto)
        {

            DatosRequeridosCD obj = new DatosRequeridosCD();
            return obj.AgregaCambioContable(fecha, monto);
        }
        public static int AgregaCambioMensual(decimal monto)
        {
            DatosRequeridosCD obj = new DatosRequeridosCD();
            return obj.AgregaCambioMensual(monto);
        }
        public static int AgregaCambioMensual_compra(decimal monto)
        {
            DatosRequeridosCD obj = new DatosRequeridosCD();
            return obj.AgregaCambioMensual_compra(monto);
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static decimal Obtener_tipo_cambio_hoy()
        {
            DatosRequeridosCD obj = new DatosRequeridosCD();
            return obj.obtener_tipo_cambio_oficial();
        }
        public static decimal obtener_tipo_cambio_mensual()
        {
            DatosRequeridosCD obj = new DatosRequeridosCD();
            return obj.obtener_tipo_cambio_mensual();
        }
        public static decimal obtener_tipo_cambio_mensual_Compra( )
        {
            DatosRequeridosCD obj = new DatosRequeridosCD();
            return obj.obtener_tipo_cambio_mensual_compra();
        }
        public static decimal Obtner_Tipo_Cambio_Mensual()
        {
            DatosRequeridosCD obj = new DatosRequeridosCD();
            return obj.Obtner_Tipo_Cambio_Mensual();
        }

        public static decimal Obtner_Tipo_Cambio_Mensual_compra( )
        {
            DatosRequeridosCD obj = new DatosRequeridosCD();
            return obj.Obtner_Tipo_Cambio_Mensual_Compra();
        }
        public static bool Datos_Empresa()
        {
            DatosRequeridosCD obj = new DatosRequeridosCD();
            return obj.Datos_Empresa();
        }
    }
}
