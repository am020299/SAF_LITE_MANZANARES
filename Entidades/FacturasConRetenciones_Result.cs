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
    
    public partial class FacturasConRetenciones_Result
    {
        public int id { get; set; }
        public System.DateTime fecha { get; set; }
        public string numero_factura { get; set; }
        public Nullable<int> numero_recibo { get; set; }
        public string nombre_cliente { get; set; }
        public Nullable<decimal> SubTotal { get; set; }
        public Nullable<decimal> retencion_1 { get; set; }
        public Nullable<decimal> retencion_2 { get; set; }
        public Nullable<decimal> TotalFactura { get; set; }
    }
}
