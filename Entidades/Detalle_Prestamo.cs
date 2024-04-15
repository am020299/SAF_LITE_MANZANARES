using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Detalle_Prestamo
    {
        public Detalle_Prestamo() { }
        public int id_producto { get; set; }
        public string codigo_producto { get; set; }
        public string descripcion { get; set; }
        public decimal precio1 { get; set; }
        public decimal cantidad { get; set; }
        public decimal descuento { get; set; }
        public decimal impuesto { get; set; }
        public string ubicacion { get; set; }
        public int id_lote { get; set; }
        public int id_bodega { get; set; }
        public int id_unidad_medida { get; set; }
        public int moneda { get; set; }
    }
}
