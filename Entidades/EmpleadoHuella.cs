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
    
    public partial class EmpleadoHuella
    {
        public int id_huella { get; set; }
        public byte[] huella { get; set; }
        public Nullable<int> estado { get; set; }
        public Nullable<System.DateTime> fecha_registro { get; set; }
        public Nullable<int> dedo { get; set; }
        public Nullable<int> id_empleado { get; set; }
        public Nullable<bool> verificado { get; set; }
        public Nullable<int> finger { get; set; }
    
        public virtual Empleado Empleado { get; set; }
    }
}
