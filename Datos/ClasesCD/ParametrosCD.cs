using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.ClasesCD
{
    public class ParametrosCD
    {
        public List<DatosEmpresa> getDatosEmpresa()
        {
            try
            {
                using(var db = new Entities())
                {
                    return db.DatosEmpresa.ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<DatosEmpresa_Select_Result> DatosEmpresa_Select()
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.DatosEmpresa_Select().ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public int DatosEmpresa_Guardar(string xNombre,string xEslogan,string xRuc,string xTributario,string xTelefono,string xCorreo,string xSitioWeb,string xDireccion, string xCiudad, string xDepartamento, string xCodigoPostal, string xCorreoAdmin,byte[] xLogo,string xCelular1,string xCelular2)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.DatosEmpresa_Guardar(xNombre, xEslogan, xRuc, xTributario, xTelefono, xCorreo, xSitioWeb, xDireccion, xCiudad, xDepartamento, xCodigoPostal, xCorreoAdmin, xLogo, xCelular1, xCelular2);
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public List<TipoDocumento> getTipoDocumento()
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.TipoDocumento.ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<TipoDocumento_SELECT_Result> TipoDocumento_Select()
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.TipoDocumento_SELECT().ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Terminos> getTerminos()
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Terminos.ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Terminos_SELECT_Result> Terminos_Select()
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Terminos_SELECT().ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public int Terminos_Guardar(string xDescripcion, int xDias)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Terminos_GUARDAR(xDescripcion, xDias);
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int Terminos_Modificar(int xId,string xDescripcion, int xDias, int xIdUsuario)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Terminos_MODIFICAR(xId, xDescripcion, xDias, xIdUsuario);
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int Terminos_Eliminar(int xId, int xIdUsuario)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Terminos_ELIMINAR(xId, xIdUsuario);
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int getAjustesModulos(int xTipo)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.AjustesModulos.Where(x => x.activo == true && x.tipo == xTipo).FirstOrDefault().id_ajuste;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public Tuple<string, string> Obtener_Servidor_correos()
        {
            try
            {
                string ip = string.Empty;
                string puerto = string.Empty;
                using (var db = new Entities())
                {
                    var Servidores = db.servidor_de_correo.FirstOrDefault();
                    if (Servidores != null)
                    {
                        ip = Servidores.host;
                        puerto = Servidores.puerto;

                    }
                }
                return Tuple.Create(ip, puerto);
            }
            catch (Exception ex)
            {

                return Tuple.Create(string.Empty, string.Empty);
            }
        }
        public List<Correos_enviar> Correos_Documentos_Enviar_Select()
        {
            using (var db = new Entities())
            {
                return db.Correos_enviar.Where(o => o.estado == 1).ToList();
            }
        }
    }
}
