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
    
    public partial class DocumentosCuentasCobrar_Clientes_Select_Result
    {
        public int id_documento { get; set; }
        public int numero_documento { get; set; }
        public string nombre_documento { get; set; }
        public Nullable<int> id_cliente { get; set; }
        public Nullable<int> numero_doc { get; set; }
        public Nullable<System.DateTime> fecha_doc { get; set; }
        public Nullable<decimal> subtotal_doc { get; set; }
        public Nullable<decimal> monto_descuento_doc { get; set; }
        public Nullable<decimal> monto_impuesto_doc { get; set; }
        public Nullable<decimal> retenciones { get; set; }
        public Nullable<decimal> monto_doc { get; set; }
        public Nullable<decimal> saldo { get; set; }
        public string concepto { get; set; }
        public int dias { get; set; }
        public string nombre { get; set; }
        public string codigo { get; set; }
        public Nullable<System.DateTime> fecha_vencimiento { get; set; }
        public int estatus_documento { get; set; }
        public int moneda { get; set; }
    }
}
