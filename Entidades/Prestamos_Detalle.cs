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
    
    public partial class Prestamos_Detalle
    {
        public int id { get; set; }
        public int id_venta { get; set; }
        public Nullable<int> id_bodega { get; set; }
        public int id_producto { get; set; }
        public decimal cantidad { get; set; }
        public decimal precio { get; set; }
        public decimal descuento { get; set; }
        public decimal impuesto { get; set; }
        public decimal total { get; set; }
        public Nullable<bool> activo { get; set; }
        public Nullable<System.DateTime> fecha_registro { get; set; }
        public Nullable<int> id_lote { get; set; }
        public string ubicacion { get; set; }
        public string descripcion_subgrupo_venta { get; set; }
    
        public virtual Producto Producto { get; set; }
        public virtual Prestamos Prestamos { get; set; }
    }
}
