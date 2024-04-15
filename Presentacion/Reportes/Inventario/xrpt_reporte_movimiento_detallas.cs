using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Windows.Forms;

namespace Presentacion.Reportes.Inventario
{
    public partial class xrpt_reporte_movimiento_detallas:DevExpress.XtraReports.UI.XtraReport
    {
        BindingSource _source;
        public string[]tipos_movimientos;
        public string[]bodegas;
        public string[] Tipo_Movimientos { get => tipos_movimientos; set => tipos_movimientos = value; }
        public string[] Bodegas { get => bodegas; set => bodegas = value; }
        public xrpt_reporte_movimiento_detallas()
        {
            InitializeComponent();
        }

        private void xrpt_reporte_movimiento_detallas_BeforePrint(object sender,System.Drawing.Printing.PrintEventArgs e)
        {
            this.FilterString = "[descripcion_corta] In (?Tipo_Movimiento) And [nombre] In (?BODEGA) And [fecha_documento] Between(?desde, ?hasta)";

        }
    }
}
