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
    
    public partial class Ventas_SELECT_REMISION_Result
    {
        public int id { get; set; }
        public string empleado { get; set; }
        public string numero { get; set; }
        public int dias { get; set; }
        public string termino { get; set; }
        public string cliente { get; set; }
        public System.DateTime fecha { get; set; }
        public Nullable<System.DateTime> fecha_maxima { get; set; }
        public decimal tipo_cambio { get; set; }
        public string observacion { get; set; }
        public int estado_recibo { get; set; }
        public int estado { get; set; }
        public string hora { get; set; }
        public Nullable<decimal> descuento { get; set; }
        public Nullable<decimal> impuesto { get; set; }
        public Nullable<decimal> total { get; set; }
        public int retencion_dgi_2 { get; set; }
        public int retencion_alcaldia_1 { get; set; }
        public bool activo { get; set; }
        public string nombre_rep { get; set; }
        public string moneda_factura { get; set; }
        public Nullable<int> moneda { get; set; }
        public int id_cliente { get; set; }
        public Nullable<int> tipo_precio { get; set; }
        public string precio { get; set; }
        public string precioCambio { get; set; }
        public Nullable<int> Cambio_Precio_Cliente { get; set; }
    }
}