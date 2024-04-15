using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.Formularios.Ventas
{
    public interface IFormaPago
    {
        bool FormaPago(DevExpress.XtraGrid.Views.Grid.GridView view);
    }
}
