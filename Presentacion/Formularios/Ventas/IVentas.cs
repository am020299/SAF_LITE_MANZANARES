using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.Formularios.Ventas
{
    public interface IVentas
    {
        bool getVenta(List<Entidades.Venta> xVenta);

        void getDetalleVenta(DataTable xDetalleVenta);

        bool FormaPago(DevExpress.XtraGrid.Views.Grid.GridView view);


    }
}
