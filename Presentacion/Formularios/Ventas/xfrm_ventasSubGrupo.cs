using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Formularios.Ventas
{
    public partial class xfrm_ventasSubGrupo : DevExpress.XtraEditors.XtraForm
    {
        public xfrm_ventasSubGrupo()
        {
            InitializeComponent();
        }

        private void xfrm_ventasSubGrupo_Load(object sender, EventArgs e)
        {
            dateFecha_Inicio.EditValue = DateTime.Now.AddMonths(-1);
            dateFecha_Fin.EditValue = DateTime.Now;

            CargarDatos();
        }

        void CargarDatos()
        {
            DateTime fecha_ini = Convert.ToDateTime(dateFecha_Inicio.EditValue);
            DateTime fecha_fin = Convert.ToDateTime(dateFecha_Fin.EditValue);
            bindingSource_VentasSubGrupo.DataSource = Negocio.ClasesCN.VentasCN.Ventas_SubGrupo(fecha_ini, fecha_fin);
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CargarDatos();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new Clases.Exportar().Exportar_Grid_A_Excel(gridControlVentasSubGrupo);
        }
    }
}