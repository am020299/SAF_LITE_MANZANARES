using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.Formularios.Ventas
{
    public partial class ListaDetalle
    {
        public string codigo { get; set; }
        public int id_bodega { get; set; }
        public int id_producto { get; set; }
        public string descripcion { get; set; }
        public decimal cantidad { get; set; }
        public int id_unidad_medida { get; set; }
        public decimal precio1 { get; set; }
        public decimal descuento { get; set; }
        public decimal impuesto { get; set; }
    }
}
