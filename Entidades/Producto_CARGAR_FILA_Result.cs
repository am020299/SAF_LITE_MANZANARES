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
    
    public partial class Producto_CARGAR_FILA_Result
    {
        public int id { get; set; }
        public string codigo { get; set; }
        public string descripcion { get; set; }
        public int id_categoria { get; set; }
        public int id_marca { get; set; }
        public Nullable<int> id_linea { get; set; }
        public Nullable<int> id_unidad_medida { get; set; }
        public int moneda { get; set; }
        public Nullable<decimal> costo { get; set; }
        public Nullable<decimal> utilidad { get; set; }
        public decimal precio1 { get; set; }
        public Nullable<decimal> precio2 { get; set; }
        public Nullable<decimal> precio3 { get; set; }
        public Nullable<decimal> precio4 { get; set; }
        public Nullable<decimal> precio5 { get; set; }
        public Nullable<decimal> precio6 { get; set; }
        public Nullable<decimal> descuento { get; set; }
        public Nullable<decimal> impuesto { get; set; }
        public Nullable<decimal> stock { get; set; }
        public Nullable<decimal> stock_minimo { get; set; }
        public byte[] imagen { get; set; }
        public Nullable<bool> habilitado { get; set; }
    }
}
