using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;

namespace Presentacion.Formularios.Inventario
{
    public partial class xfrm_grupos_subgrupos:DevExpress.XtraEditors.XtraForm
    {
        public xfrm_grupos_subgrupos( )
        {
            InitializeComponent();
        }

        private void cargar( )
        {
            gridConsulta.DataSource = Negocio.ClasesCN.InventarioCN.Consulta_Inventario_Por_Subgrupo(Convert.ToInt32(look_sub_grupo.EditValue??0));//Negocio.ClasesCN.InventarioCN.Consulta_Inventario().ToList();
            gview_consulta.OptionsView.ShowFooter = true;
            //if (Clases.UsuarioLogueado.saberAdminM())
            //{
            //    gview_consulta.Columns
            //}


            if(gview_consulta.Columns.Count > 0)
            {
                gview_consulta.Columns[0].Visible = false;
                gview_consulta.Columns[1].Visible = false;
                gview_consulta.Columns[7].Visible = false;
                if (Clases.UsuarioLogueado.saberAdminM())
                {
                    gview_consulta.Columns[7].Visible = true;
                }
               
                
                for(int i = 1;i < gview_consulta.Columns.Count;i++)
                {
                    gview_consulta.Columns[i].Caption = gview_consulta.Columns[i].FieldName.Replace('_',' ').ToUpper();

                    if(i > 3)
                    {

                        gview_consulta.Columns[i].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;

                        gview_consulta.Columns[i].SummaryItem.FieldName = gview_consulta.Columns[i].FieldName;

                        gview_consulta.Columns[i].SummaryItem.DisplayFormat = "{0:n2}";
                    }

                }
            }

        }
        private void labelControl2_Click(object sender,EventArgs e)
        {

        }

        private void xfrm_grupos_subgrupos_Load(object sender,EventArgs e)
        {
            //var Productos=Negocio.ClasesCN.CatalogosCN.Producto_Cargar();
        //    look_grupo.Properties.DataSource = Negocio.ClasesCN.CatalogosCN.Categoria_Cargar().ToList();
            look_sub_grupo.Properties.DataSource = Negocio.ClasesCN.CatalogosCN.Linea_Cargar().ToList();

        }

        private void simpleButton1_Click(object sender,EventArgs e)
        {
            if(look_sub_grupo.EditValue != null)
            {
                var Productos=Negocio.ClasesCN.CatalogosCN.Producto_Cargar().Where(F=>F.id_linea==Convert.ToInt32(look_sub_grupo.EditValue??0)&& F.habilitado == true).ToList();
                BindingSource Recurso= new BindingSource();
                Recurso.DataSource = Productos;
                Reportes.Inventario.xrpt_subgrupos Reporte= new Reportes.Inventario.xrpt_subgrupos (Recurso);
                Reporte.DataSource = Recurso;
                Reporte.ShowPreviewDialog();


            }
        }

        private void gridControl1_Click(object sender,EventArgs e)
        {

        }

        private void simpleButton2_Click(object sender,EventArgs e)
        {
            if(look_sub_grupo.EditValue!=null)
            {
                cargar();
            }
        }

        private void simpleButton3_Click(object sender,EventArgs e)
        {
            new Clases.Exportar().Exportar_Grid_A_Excel(gridConsulta);
        }
    }
}