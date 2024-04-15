using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.Formularios.Compras
{
    public interface ICompras
    {
        bool getCompras(List<Entidades.Compras> xCompras);

        void getDetalleCompra(DataTable xDetalleCompra);
    }
}
