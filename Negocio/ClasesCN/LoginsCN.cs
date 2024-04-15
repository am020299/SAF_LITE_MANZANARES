using Datos.ClasesCD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;

namespace Negocio.ClasesCN
{
    public class LoginsCN
    {
        public static bool HayConexion()
        {
            LoginsCD obj = new LoginsCD();
            return obj.HayConexion();
        }
        public static int contador_usuario_contraseña(string vNickName, string vClave)
        {
            LoginsCD obj = new LoginsCD();
            return obj.contador_usuario_contraseña(vNickName, vClave);
        }
        public static int contador_usuario(string vNickName)
        {
            LoginsCD obj = new LoginsCD();
            return obj.contador_usuario(vNickName);
        }
        public static bool si_existe_usuario(string vNickName)
        {
            LoginsCD obj = new LoginsCD();
            return obj.si_existe_usuario(vNickName);
        }
        public static List<Login_Empleado_Cargar> Obtener_Datos_de_Usuario()
        {
            LoginsCD obj = new LoginsCD();
            return obj.Obtener_Datos_de_Usuario();
        }
        public static List<EmpleadoHuella> Lista_Huella()
        {
            LoginsCD obj = new LoginsCD();
            return obj.Lista_Huella();
        }
        public static long Grabar_inicio_sesion(int id_empleado)
        {
            LoginsCD obj = new LoginsCD();
            return obj.Grabar_inicio_sesion(id_empleado);
        }
        public static int Terminar_inicio_sesion(int id_empleado)
        {
            LoginsCD obj = new LoginsCD();
            return obj.Terminar_inicio_sesion(id_empleado);
        }
        public static bool Consultar_Usuario_Logueado(int id_empleado)
        {
            LoginsCD obj = new LoginsCD();
            return obj.Consultar_Usuario_Logueado(id_empleado);
        }
        public static bool Consultar_id_Logueado(int id_empleado, long id_logueado)
        {
            LoginsCD obj = new LoginsCD();
            return obj.Consultar_id_Logueado(id_empleado,id_logueado);
        }
        public static List<UsuariosLogueados> Cargar_Usuarios_Logueados()
        {
            LoginsCD obj = new LoginsCD();
            return obj.Cargar_Usuarios_Logueados();
        }
        public static string Usuario_a_Cargar(int id_empleado)
        {
            LoginsCD obj = new LoginsCD();
            return obj.Usuario_a_Cargar(id_empleado);
        }
        public static List<Login_OBTENER_DATOS_USUARIOS_Result> Cargar_Datos_Usuarios(int id_empleado)
        {
            LoginsCD obj = new LoginsCD();
            return obj.Cargar_Datos_Usuarios(id_empleado);
        }
        public static int Guardar_huella(byte[] huella, int dedo, int id_empleado, int finger)
        {
            LoginsCD obj = new LoginsCD();
            return obj.Guardar_huella(huella, dedo, id_empleado, finger);
        }
       
    }
}
