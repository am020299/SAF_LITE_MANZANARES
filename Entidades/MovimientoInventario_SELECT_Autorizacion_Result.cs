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
    
    public partial class MovimientoInventario_SELECT_Autorizacion_Result
    {
        public int id { get; set; }
        public string numero_documento { get; set; }
        public int id_tipo_ajuste { get; set; }
        public string tipo_ajuste { get; set; }
        public string tipo_ajuste_corto { get; set; }
        public string tipo_documento { get; set; }
        public System.DateTime fecha_documento { get; set; }
        public string observacion { get; set; }
        public string persona_referencia { get; set; }
        public string empleado { get; set; }
        public int tipo { get; set; }
        public int id_referencia { get; set; }
        public Nullable<System.DateTime> fecha_registro { get; set; }
        public bool autorizado { get; set; }
        public string empresa_nombre { get; set; }
        public string empresa_eslogan { get; set; }
        public string empresa_direccion { get; set; }
        public string empresa_telefono { get; set; }
        public string empresa_ruc { get; set; }
        public byte[] empresa_logo { get; set; }
    }
}
