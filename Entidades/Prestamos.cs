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
    
    public partial class Prestamos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Prestamos()
        {
            this.Prestamos_Detalle = new HashSet<Prestamos_Detalle>();
        }
    
        public int id { get; set; }
        public int id_empleado { get; set; }
        public string numero { get; set; }
        public int id_cliente { get; set; }
        public System.DateTime fecha { get; set; }
        public System.DateTime fecha_estimada { get; set; }
        public Nullable<System.DateTime> fecha_maxima { get; set; }
        public decimal tipo_cambio { get; set; }
        public string observacion { get; set; }
        public int estado { get; set; }
        public bool activo { get; set; }
        public int tipo { get; set; }
        public int id_termino { get; set; }
        public int vendedor { get; set; }
        public System.DateTime fecha_registro { get; set; }
        public Nullable<int> id_representante_venta { get; set; }
        public Nullable<int> moneda { get; set; }
        public Nullable<int> id_empleado_autoriza { get; set; }
        public string nombre_representante { get; set; }
        public Nullable<int> tipo_precio { get; set; }
        public Nullable<int> Cambio_Precio_Cliente { get; set; }
        public Nullable<decimal> retencion_1 { get; set; }
        public Nullable<decimal> retencion_2 { get; set; }
    
        public virtual Cliente Cliente { get; set; }
        public virtual Empleado Empleado { get; set; }
        public virtual Terminos Terminos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Prestamos_Detalle> Prestamos_Detalle { get; set; }
    }
}
