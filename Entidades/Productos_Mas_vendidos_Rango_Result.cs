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
    
    public partial class Productos_Mas_vendidos_Rango_Result
    {
        public int estado { get; set; }
        public int id_producto { get; set; }
        public Nullable<int> id_linea { get; set; }
        public string codigo { get; set; }
        public string descripcion { get; set; }
        public string nombre { get; set; }
        public Nullable<decimal> cantidad_vendida { get; set; }
        public Nullable<decimal> total_venta { get; set; }
        public Nullable<int> moneda { get; set; }
        public string moneda_descripcion { get; set; }
        public Nullable<System.DateTime> fecha_ultima_venta { get; set; }
    }
}
