using Datos.ClasesCD;
using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.ClasesCN
{
    public class ParametrosCN
    {
        #region DATOS DE EMPRESA

        [DataObjectMethod(DataObjectMethodType.Fill)]
        public static List<DatosEmpresa> getDatosEmpresa()
        {
            ParametrosCD obj = new ParametrosCD();
            return obj.getDatosEmpresa();
        }

        [DataObjectMethod(DataObjectMethodType.Fill)]
        public static List<DatosEmpresa_Select_Result> DatosEmpresa_Select()
        {
            ParametrosCD obj = new ParametrosCD();
            return obj.DatosEmpresa_Select();
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static int DatosEmpresa_Guardar(string xNombre, string xEslogan, string xRuc, string xTributario, string xTelefono, string xCorreo, string xSitioWeb, string xDireccion, string xCiudad, string xDepartamento, string xCodigoPostal, string xCorreoAdmin, byte[] xLogo, string xCelular1, string xCelular2)
        {
            ParametrosCD obj = new ParametrosCD();
            return obj.DatosEmpresa_Guardar(xNombre, xEslogan, xRuc, xTributario, xTelefono, xCorreo, xSitioWeb, xDireccion, xCiudad, xDepartamento, xCodigoPostal, xCorreoAdmin, xLogo, xCelular1, xCelular2);
                
        }

        [DataObjectMethod(DataObjectMethodType.Fill)]
        public static List<TipoDocumento> getTipoDocumento()
        {
            ParametrosCD obj = new ParametrosCD();
            return obj.getTipoDocumento();
        }

        [DataObjectMethod(DataObjectMethodType.Fill)]
        public static List<TipoDocumento_SELECT_Result> TipoDocumento_Select()
        {
            ParametrosCD obj = new ParametrosCD();
            return obj.TipoDocumento_Select();
        }

        #endregion

        [DataObjectMethod(DataObjectMethodType.Fill)]
        public static List<Terminos> getTerminos()
        {
            ParametrosCD obj = new ParametrosCD();
            return obj.getTerminos();
        }

        [DataObjectMethod(DataObjectMethodType.Fill)]
        public static List<Terminos_SELECT_Result> Terminos_Select()
        {
            ParametrosCD obj = new ParametrosCD();
            return obj.Terminos_Select();
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static int Terminos_Guardar(string xDescripcion, int xDias)
        {
            ParametrosCD obj = new ParametrosCD();
            return obj.Terminos_Guardar(xDescripcion, xDias);
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public static int Terminos_Modificar(int xId, string xDescripcion, int xDias, int xIdUsuario)
        {
            ParametrosCD obj = new ParametrosCD();
            return obj.Terminos_Modificar(xId, xDescripcion, xDias, xIdUsuario);
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public static int Terminos_Eliminar(int xId, int xIdUsuario)
        {
            ParametrosCD obj = new ParametrosCD();
            return obj.Terminos_Eliminar(xId, xIdUsuario);
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static int getAjustesModulos(int xTipo)
        {
            ParametrosCD obj = new ParametrosCD();
            return obj.getAjustesModulos(xTipo);
        }
        public static Tuple<string, string> Obtener_Servidor_correos()
        {
            ParametrosCD obj = new ParametrosCD();
            return obj.Obtener_Servidor_correos();
        }
        public static List<Correos_enviar> Correos_Documentos_Enviar_Select()
        {
            ParametrosCD obj = new ParametrosCD();
            return obj.Correos_Documentos_Enviar_Select();
        }
    }
}
