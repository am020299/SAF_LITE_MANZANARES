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
    
    public partial class VentasPorSubGrupo_Result
    {
        public int id_producto { get; set; }
        public string codigo { get; set; }
        public int id_sub_grupo { get; set; }
        public string sub_grupo { get; set; }
        public Nullable<decimal> cant_vendida { get; set; }
        public decimal precio { get; set; }
        public System.DateTime fecha { get; set; }
    }
}