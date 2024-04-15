using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.Formularios.Catalogos
{
    public   interface IAutorizacion
    {
        bool Autorizado { get; set; }
        string permiso { get; set; }
        int numero_permiso { get; set; }
        bool Autorizar(int numero_permiso,string permiso);
        
 }
}
