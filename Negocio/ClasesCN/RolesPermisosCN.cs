using Datos.ClasesCD;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.ClasesCN
{
    public class RolesPermisosCN
    {
        public static bool Permisos(int id_empleado, int id_rol)
        {
            RolesPermisosCD obj = new RolesPermisosCD();
            return obj.Permisos(id_empleado, id_rol);
        }
        public static List<Permisos_CARGAR_PERMISOS_ASIGNADOS_Result> Cargar_Permisos(int id_empleado)
        {
            RolesPermisosCD obj = new RolesPermisosCD();
            return obj.Cargar_Permisos(id_empleado);
        }
        public static int Agregar_Quitar_Permisos(int id_empleado, int id_rol)
        {
            RolesPermisosCD obj = new RolesPermisosCD();
            return obj.Agregar_Quitar_Permisos(id_empleado, id_rol);
        }
        public static int Consultar_Usuario_Admin(int id_empleado)
        {
            RolesPermisosCD obj = new RolesPermisosCD();
            return obj.Consultar_Usuario_Admin(id_empleado);
        }
        public static int Consultar_Roles_Permisos(int numero_rol, int numero_permiso, string nombre_rol, string nombre_permiso)
        {
            RolesPermisosCD obj = new RolesPermisosCD();
            return obj.Consultar_Roles_Permisos(numero_rol, numero_permiso, nombre_rol, nombre_permiso);
        }
        public static Empleado Empleado_por_usuario_Select(string usuario)
        {
            RolesPermisosCD obj = new RolesPermisosCD();
            return obj.Empleado_por_usuario_Select(usuario);
        }

        public static bool consultarPermisoPorEmpleado(int idEmpleado, int idPermiso)
        {
            RolesPermisosCD obj = new RolesPermisosCD();
            return obj.consultarPermisoPorEmpleado(idEmpleado, idPermiso);
        }
        public static bool registrarAutorizacion(int idEmpleado, int id_empleado_autoriza, string observacion_modulo, string concepto, string clave)
        {
            RolesPermisosCD obj = new RolesPermisosCD();
            return obj.registrarAutorizacion( idEmpleado,  id_empleado_autoriza,  observacion_modulo, concepto,clave);
        }
        public static List<Reporte_Autirzacion_Result> Reporte_Autorizacion(DateTime fecha_inicial, DateTime fecha_fin, int id_autoriza)
        {
            RolesPermisosCD obj = new RolesPermisosCD();
            return obj.Reporte_Autorizacion( fecha_inicial, fecha_fin,  id_autoriza);
        }
        public static List<Empleado_Autoriza> Cargar_Empleados_Autoriza()
        {
            RolesPermisosCD obj = new RolesPermisosCD();
            return obj.Cargar_Empleados_Autoriza();
        }
    }
}
