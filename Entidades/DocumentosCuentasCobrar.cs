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
    using System.Collections.Generic;
    
    public partial class DocumentosCuentasCobrar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DocumentosCuentasCobrar()
        {
            this.AplicacionDocumentos = new HashSet<AplicacionDocumentos>();
            this.AplicacionDocumentos1 = new HashSet<AplicacionDocumentos>();
        }
    
        public int id_documento { get; set; }
        public Nullable<int> tipo_documento { get; set; }
        public Nullable<int> id_cliente { get; set; }
        public Nullable<int> numero_doc { get; set; }
        public Nullable<System.DateTime> fecha_doc { get; set; }
        public Nullable<decimal> monto_doc { get; set; }
        public Nullable<decimal> subtotal_doc { get; set; }
        public Nullable<decimal> monto_descuento_doc { get; set; }
        public Nullable<decimal> monto_impuesto_doc { get; set; }
        public Nullable<System.DateTime> fecha_regisro { get; set; }
        public Nullable<int> estado { get; set; }
        public Nullable<int> id_usuario { get; set; }
        public Nullable<int> id_comprobante { get; set; }
        public string concepto { get; set; }
        public Nullable<decimal> retenciones { get; set; }
        public int id_cobrador { get; set; }
        public Nullable<int> id_termino { get; set; }
        public int modulo { get; set; }
        public Nullable<int> id_factura { get; set; }
    
        public virtual Cliente Cliente { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AplicacionDocumentos> AplicacionDocumentos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AplicacionDocumentos> AplicacionDocumentos1 { get; set; }
    }
}