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
    
    public partial class UsuariosRolesPermisos
    {
        public int id { get; set; }
        public int id_empleado { get; set; }
        public int id_permiso { get; set; }
        public bool estado { get; set; }
        public System.DateTime fecha_registro { get; set; }
        public Nullable<System.DateTime> fecha_modificacion { get; set; }
    
        public virtual Empleado Empleado { get; set; }
    }
}