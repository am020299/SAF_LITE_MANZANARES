using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.Formularios.Ventas
{
    public interface IPrestamo
    {
        bool getPrestamo(List<Entidades.Prestamos> xPrestamos);

        void getPrestamoDetalle(DataTable xPrestamoDetalle);
    }
}
