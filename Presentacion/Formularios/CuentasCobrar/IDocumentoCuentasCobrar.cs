using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.Formularios.CuentasCobrar
{
    public interface IDocumentoCuentasCobrar
    {

    //    bool DocuementoCuentasCobrar(Entidades.DocumentosCuentasCobrar Doc);
        bool IsNuevo { get; set; }
        int IdDocumentoCuentasCobrar { get; set;}
        int IdCliente { get; set; }
       
    }
}
