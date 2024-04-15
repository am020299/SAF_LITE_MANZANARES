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
    public class LoginsCD
    {
        bool v = false;
        public bool HayConexion()
        {
            using (var db = new Entities())
            {
                DbConnection con = db.Database.Connection;
                try
                {
                    con.Open(); // check the database connection                    
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        public int contador_usuario_contraseña(string vNickName, string vClave)
        {
            try
            {
                using (var db = new Entities())
                {
                    var resultado = (from n in db.Login_Empleado_Cargar
                                     where n.usuario == vNickName && n.clave == vClave //&& n.admin == true 
                                     select n).Count();
                    return resultado;
                }
            }
            catch (Exception)
            {
                return 0;
            } 
        }
        public int contador_usuario(string vNickName)
        {
            try
            {
                using (var db = new Entities())
                {
                    var resultado = (from n in db.Login_Empleado_Cargar
                                     where n.usuario == vNickName// && n.admin == true
                                     select n).Count();
                    return resultado;
                }
            }
            catch (Exception)
            {
                return 0;
            }   
        }
        public bool si_existe_usuario(string vNickName)
        {
            using (var db = new Entities())
            {
                if (db.Login_Empleado_Cargar.Any(o => o.usuario == vNickName ))
                {
                    v = true;
                }
                else
                    v = false;
            }
            return v;
        }
        public List<Login_Empleado_Cargar> Obtener_Datos_de_Usuario(string nickname="")
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Login_Empleado_Cargar.ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }      
        }
        public List<EmpleadoHuella>Lista_Huella()
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.EmpleadoHuella.ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        public long Grabar_inicio_sesion(int id_empleado)
        {
            try
            {
                using (var db = new Entities())
                {
                    if (db.Login_GUARDAR_INICIO_SESION(id_empleado, "", "") > 0)
                    {
                        return Convert.ToInt64(db.Logins.Where(o=>o.id_empleado== id_empleado && o.logueado==true).Max(o => o.id_login));
                    }
                    else
                        return 0;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public int Terminar_inicio_sesion(int id_empleado)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Logins_FIN_SESION(id_empleado);
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public bool Consultar_Usuario_Logueado(int id_empleado)
        {
            try
            {
                using (var db = new Entities())
                {
                    var x = db.Logins.Where(o => o.id_empleado == id_empleado && o.logueado == true).FirstOrDefault();
                    if (Convert.ToInt32(x.id_empleado)>0)
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
        public bool Consultar_id_Logueado(int id_empleado, long id_logueado)
        {
            try
            {
                using (var db = new Entities())
                {
                    var x = db.Logins.Where(o => o.id_empleado == id_empleado && o.logueado== true).FirstOrDefault();
                    if (id_logueado == x.id_login)
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
        public List<UsuariosLogueados> Cargar_Usuarios_Logueados()
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.UsuariosLogueados.ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        public List<Login_OBTENER_DATOS_USUARIOS_Result> Cargar_Datos_Usuarios(int id_empleado)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Login_OBTENER_DATOS_USUARIOS(id_empleado).ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        public string Usuario_a_Cargar(int id_empleado)
        {
            try
            {
                using (var db = new Entities())
                {
                    var x = db.Empleado.Where(o => o.id == id_empleado).FirstOrDefault();
                    return x.usuario;
                }

            }
            catch (Exception)
            {

                return "";
            }
        }
        public int Guardar_huella(byte[] huella, int dedo, int id_empleado, int finger)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Huella_Guardar(huella, dedo, id_empleado, finger);
                }
            }
            catch (Exception )
            {
                XtraMessageBox.Show("Error en la ejecución; comunicarse con soporte técnico", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }   
    }
}
