//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Entidades
{
    using System;
    using System.Collections.Generic;
    
    public partial class TipoComprobante
    {
        public int id_tipo { get; set; }
        public int tipo_comprobante { get; set; }
        public string descripcion { get; set; }
        public int estado { get; set; }
        public System.DateTime fecha_de_registro { get; set; }
        public bool automatico { get; set; }
    }
}
