using System;
using Entidades;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using DevExpress.XtraEditors;
using System.Windows.Forms;

namespace Datos.ClasesCD
{
    public class RolesPermisosCD
    {
        public bool Permisos(int id_empleado, int id_rol)
        {
            try
            {
                using (var db = new Entities())
                {
                    if (db.Permisos_CARGAR_PERMISOS_ASIGNADOS(id_empleado).Any(o => o.id_rol == id_rol && o.asignado==1))
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<Permisos_CARGAR_PERMISOS_ASIGNADOS_Result> Cargar_Permisos(int id_empleado)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Permisos_CARGAR_PERMISOS_ASIGNADOS(id_empleado).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        public int Agregar_Quitar_Permisos(int id_empleado, int id_rol)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Roles_GUARDAR_ROLES_PERMISOS_USUARIOS(id_empleado,0 , id_rol, false);
                }
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Error en la ejecución; comunicarse con soporte técnico", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
        public int Consultar_Usuario_Admin(int id_empleado)
        {
            try
            {
                using (var db = new Entities())
                {
                    var x = db.Empleado.Where(o=>o.id== id_empleado).FirstOrDefault();
                    return Convert.ToInt32(x.tipo_empleado);
                }
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Error en la ejecución; comunicarse con soporte técnico", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
        public int Consultar_Roles_Permisos(int numero_rol, int numero_permiso, string nombre_rol, string nombre_permiso)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Roles_Permisos_GUARDAR(numero_rol,numero_permiso,nombre_rol,nombre_permiso);
                }
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Error en la ejecución; comunicarse con soporte técnico", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
        public Empleado Empleado_por_usuario_Select(string usuario)
        {
            try
            {
                using(Entities db = new Entities())
                {
                    return db.Empleado.Where(U => U.usuario.ToUpper() == usuario.ToUpper()).FirstOrDefault();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine( ex.Message);
                return null;
            }
        }

        public bool consultarPermisoPorEmpleado (int idEmpleado, int idPermiso)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.UsuariosRolesPermisos.Where(x => x.id_empleado == idEmpleado && x.id_permiso == idPermiso && x.estado == true).Any();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("No se ha logrado establecer una conexión a la base de datos\nEl siguiente mensaje de error esta orientado para los desarrolladores: " + ex.GetBaseException().Message, "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        public bool registrarAutorizacion( int idEmpleado,int id_empleado_autoriza,string observacion_modulo, string concepto,string clave )
        {
            try
            {
                using (var db = new Entities())
                {
                    using (var transaccion = db.Database.BeginTransaction())
                    {
                        try
                        {
                            Autorizacion a = new Autorizacion();

                            a.idEmpleado = idEmpleado;
                            a.id_empleado_autoriza = id_empleado_autoriza;
                            a.modulo = observacion_modulo;
                            a.concepto = concepto;
                            a.registroActivo = true;
                            a.fecha_registro = DateTime.Now;
                            a.clave = clave;
                            db.Autorizacion.Add(a);
                            db.SaveChanges();
                            transaccion.Commit();

                            return true;
                        }
                        catch (Exception ex)
                        {
                            transaccion.Rollback();
                            XtraMessageBox.Show("No se ha logrado ingresar los datos de la autorizacion al sistema\nEl siguiente mensaje de error esta orientado para los desarrolladores: " + ex.GetBaseException().Message, "Error al ingresar datos al sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("No se ha logrado establecer una conexión a la base de datos\nEl siguiente mensaje de error esta orientado para los desarrolladores: " + ex.GetBaseException().Message, "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        public  List<Reporte_Autirzacion_Result> Reporte_Autorizacion(DateTime fecha_inicial,DateTime fecha_fin, int id_autoriza)
        {
            try
            {
                using (var db= new Entities())
                {
                    return db.Reporte_Autirzacion(fecha_inicial,fecha_fin, id_autoriza).ToList();
                }
            }
            catch (Exception)
            {

               return null;
            }
        }

        public List<Empleado_Autoriza> Cargar_Empleados_Autoriza()
        {
            List<Empleado_Autoriza> list = new List<Empleado_Autoriza>();
            using (var db = new Entities())
            {
                var query = (from ea in db.Autorizacion
                             join e in db.Empleado on ea.id_empleado_autoriza equals e.id 
                             select new {e.nombre,ea.id_empleado_autoriza }).Distinct().ToList();

                foreach ( var x in query)
                {
                    list.Add( new Empleado_Autoriza
                    {
                        id=Convert.ToInt32(x.id_empleado_autoriza),
                        nombre=x.nombre

                    });
                }
            }
            return list;
        }
    }
}
