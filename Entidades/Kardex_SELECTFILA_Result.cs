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
    
    public partial class Kardex_SELECTFILA_Result
    {
        public int id_producto { get; set; }
        public string codigo { get; set; }
        public Nullable<int> id_lote { get; set; }
        public string lote { get; set; }
        public string producto { get; set; }
        public string categoria { get; set; }
        public string marca { get; set; }
        public int id_bodega { get; set; }
        public string bodega { get; set; }
        public string ubicacion { get; set; }
        public decimal saldo_inicial { get; set; }
        public decimal entradas { get; set; }
        public decimal salidas { get; set; }
        public decimal ajuste { get; set; }
        public decimal saldo_actual { get; set; }
        public decimal comprometido { get; set; }
        public Nullable<decimal> prestamos { get; set; }
        public decimal disponible { get; set; }
        public Nullable<bool> tipo_producto { get; set; }
        public int moneda { get; set; }
        public Nullable<bool> habilitado { get; set; }
    }
}