using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Windows.Forms;

namespace Presentacion.Reportes.Inventario
{
    public partial class xrpt_subgrupos:DevExpress.XtraReports.UI.XtraReport
    {
        int id_empleado;
        public xrpt_subgrupos(BindingSource Recurso)
        {
            InitializeComponent();
            this.DataSource = Recurso;
            id_empleado = Clases.UsuarioLogueado.vID_Empleado;
        }

        private void xrpt_subgrupos_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            xrTableCell14.Visible = false;
            xrTableCell7.Visible = false;
            if (Negocio.ClasesCN.RolesPermisosCN.Permisos(id_empleado, 127))
            {
                xrTableCell14.Visible = true;
                xrTableCell7.Visible = true;
            }
           

        }
    }
}
