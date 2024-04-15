using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Presentacion.Formularios.Contabilidad
{
    interface IComprobantes
    {
        bool Comprobante_Diario(ComprobanteDiario Comprobante);
        void Obtener_ComprobanteDetalle(DataTable DetalleComprobante);
        bool  isNuevo {get; set; }
        int id_asiento { get; set; }

    }
}
