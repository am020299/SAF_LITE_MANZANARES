using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.ClasesCD;

namespace Negocio.ClasesCN
{
    public class MantenimientoCN
    {
        public static int Actualizar_Regristro(int id_empleado, string usuario, string contraseña)
        {
            MantenimientoCD obj = new MantenimientoCD();
            return obj.Actualizar_Regristro(id_empleado, usuario, contraseña);
        }
        public static int Crear_Respaldo(string direccion)
        {
            MantenimientoCD obj = new MantenimientoCD();
           return obj.Crear_Respaldo(direccion);
        }
    }
}
