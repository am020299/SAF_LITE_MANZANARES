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
    
    public partial class reportes_de_ventas_Result
    {
        public string empresa_nombre { get; set; }
        public string empresa_eslogan { get; set; }
        public string empresa_direccion { get; set; }
        public string empresa_telefono { get; set; }
        public string empresa_ruc { get; set; }
        public byte[] empresa_logo { get; set; }
        public Nullable<System.DateTime> mes_año { get; set; }
        public System.DateTime fecha { get; set; }
        public string numero_factura { get; set; }
        public string nombre { get; set; }
        public string cliente { get; set; }
        public string linea { get; set; }
        public string codigo { get; set; }
        public string descripcion { get; set; }
        public decimal cantidad_vendidas { get; set; }
        public decimal precio_sin_descuento_sin_iva { get; set; }
        public Nullable<decimal> descuento { get; set; }
        public Nullable<decimal> iva { get; set; }
        public Nullable<decimal> sub_total { get; set; }
        public decimal total { get; set; }
    }
}