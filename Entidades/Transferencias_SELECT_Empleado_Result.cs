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
    
    public partial class Transferencias_SELECT_Empleado_Result
    {
        public string N_FACTURA { get; set; }
        public string CLIENTE { get; set; }
        public string EMPLEADO { get; set; }
        public Nullable<int> N_Transferencia { get; set; }
        public Nullable<decimal> MONTO { get; set; }
        public Nullable<System.DateTime> FECHA { get; set; }
        public string descripcion { get; set; }
        public int moneda { get; set; }
        public Nullable<int> id_forma_pago { get; set; }
    }
}
