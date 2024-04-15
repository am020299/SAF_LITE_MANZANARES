using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraGrid;
using Entidades;
using Negocio;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraReports.UI;

namespace Presentacion.Clases
{
    public class UsuarioLogueado
    {
        public static int vID_Empleado;
        public static long vID_logueado;
        public static string vNickName;
        public static string vClave;
        public static string vPuestoCargo;
        public static string vNombres;
        public static string vApellidos;
        public static string vNombreCompleto;
        public static bool admin;
        public static int  Establecer_Usuario_Logueado(string nick_name)
        {
            admin = false;
            foreach (var r in Negocio.ClasesCN.LoginsCN.Obtener_Datos_de_Usuario().Where(X=>X.usuario.ToLower()==nick_name.ToLower()))
            {
                vID_Empleado = r.id;
                vNombres = r.nombre;
                vNombreCompleto =r.nombre;
                vNickName = nick_name;
                vPuestoCargo = r.cargo;
                vClave = r.clave;
                if (r.tipo_empleado == 1 || r.tipo_empleado == 2)
                    admin = true;
            }
            return vID_Empleado;
        }
        public static void Establecer_id_Logueado(long id_logueado)
        {
            vID_logueado = id_logueado;
        }
        public static void precioEspecial(LookUpEdit control, RepositoryItemLookUpEdit repo, int id_empleado)
        {
            vID_Empleado = id_empleado;
            if (Negocio.ClasesCN.RolesPermisosCN.Permisos(id_empleado, 127) && repo == null )//127 es el tipo de ROL en este caso PRECIO ESPECIAL
            {
                control.Properties.DataSource = Negocio.ClasesCN.CatalogosCN.getPrecio();
            }
            else if (Negocio.ClasesCN.RolesPermisosCN.Permisos(id_empleado, 127) && repo != null)
            {
                repo.Columns["precio4"].Visible = true;
                repo.Columns["precio5"].Visible = true;
                repo.Columns["precio6"].Visible = true;
                repo.Columns["precio7"].Visible = true;
                repo.Columns["precio8"].Visible = true;
                repo.Columns["precio9"].Visible = true;
                repo.Columns["precio10"].Visible = true;
                repo.Columns["precio11"].Visible = true;
            }
            else if (!Negocio.ClasesCN.RolesPermisosCN.Permisos(id_empleado, 127) && repo == null)
            {
                control.Properties.DataSource = Negocio.ClasesCN.CatalogosCN.getPrecio2();
            }
            else
            {
                if (!Negocio.ClasesCN.RolesPermisosCN.Permisos(id_empleado, 127) && repo != null)
                {
                    repo.Columns["precio4"].Visible = false;
                    repo.Columns["precio5"].Visible = false;
                    repo.Columns["precio6"].Visible = false;
                    repo.Columns["precio7"].Visible = false;
                    repo.Columns["precio8"].Visible = false;
                    repo.Columns["precio9"].Visible = false;
                    repo.Columns["precio10"].Visible = false;
                    repo.Columns["precio11"].Visible = false;
                }

            }
           
        }

        public static bool saberAdminM()//Comprueba si es la marling
        {
            if ((vNickName.ToUpper() == "MARLING" && vPuestoCargo.ToUpper().Contains("ADMINISTRADOR")) || vNickName.ToUpper() == "ADMIN")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Metodo para permisos especiales, se puede utilizar donde sea, tomando en cuenta el numero del permiso en la base de datos
        public static bool PermisoEspecial(int id_empleado, int numero_permiso)
        {
            vID_Empleado = id_empleado;
            bool tiene_permiso = Negocio.ClasesCN.RolesPermisosCN.Permisos(id_empleado, numero_permiso);

            if (tiene_permiso || vNickName.ToUpper() == "ADMIN")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void bodegaEspecial(LookUpEdit control)
        {
            //vNickName = usuario;
            //vPuestoCargo = cargo;
            if (saberAdminM())
            {
                control.Properties.DataSource = Negocio.ClasesCN.CatalogosCN.Bodega_Cargar();
            }
            else
            {
                control.Properties.DataSource = Negocio.ClasesCN.CatalogosCN.Bodega_Cargar().Where(o => !o.nombre.Contains("BODEGA ESPECIAL"));
            }

        }


    }
}
