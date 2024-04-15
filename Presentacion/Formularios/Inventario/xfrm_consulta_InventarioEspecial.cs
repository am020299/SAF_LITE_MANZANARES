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

namespace Presentacion.Formularios.Inventario
{
    public partial class xfrm_consulta_InventarioEspecial : DevExpress.XtraEditors.XtraForm
    {
        public xfrm_consulta_InventarioEspecial( )
        {
            InitializeComponent();
        }

        private void cargar( )
        {
            if(Clases.UsuarioLogueado.vID_Empleado==1023)
              grid_Consulta_Inventario.DataSource = Negocio.ClasesCN.InventarioCN. Consulta_Inventario_dynamic_Especial(false);//Negocio.ClasesCN.InventarioCN.Consulta_Inventario().ToList();
            else
                grid_Consulta_Inventario.DataSource = Negocio.ClasesCN.InventarioCN.Consulta_Inventario_dynamic_Especial(true);
            //gview_consulta.OptionsView.ShowFooter = true;

            

            if(gview_consulta.Columns.Count > 0)
            {
                // Ocultar columnas de id
                gview_consulta.Columns[0].Visible = false;
                gview_consulta.Columns[3].Visible = false;
                // Crear grupo por SUB GRUPO
                gview_consulta.Columns[4].Group();
                
                for (int i = 1; i < gview_consulta.Columns.Count; i++)
                {
                    gview_consulta.Columns[i].Caption = gview_consulta.Columns[i].FieldName.Replace('_',' ').ToUpper();

                    if(i > 2)
                    {
                        gview_consulta.Columns[i].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;

                        gview_consulta.Columns[i].SummaryItem.FieldName = gview_consulta.Columns[i].FieldName;

                        gview_consulta.Columns[i].SummaryItem.DisplayFormat = "{0:n2}";
                    }
                }
            }

        }
        private void xfrm_consulta_Inventario_Load(object sender,EventArgs e)
        {
            cargar();
            gview_consulta.OptionsView.ShowFooter = false;
            bbi_exportar_excel.Enabled = false;
            bool cargar_total_consulta_inventario = Negocio.ClasesCN.RolesPermisosCN.Permisos(Clases.UsuarioLogueado.vID_Empleado, 11115);
            bool habilitar_boton_excel = Negocio.ClasesCN.RolesPermisosCN.Permisos(Clases.UsuarioLogueado.vID_Empleado, 11116);
            if (cargar_total_consulta_inventario || Clases.UsuarioLogueado.admin)
                gview_consulta.OptionsView.ShowFooter = true;
            if (habilitar_boton_excel || Clases.UsuarioLogueado.admin)
                bbi_exportar_excel.Enabled = true;
        }

        private void bbi_actualizar_ItemClick(object sender,DevExpress.XtraBars.ItemClickEventArgs e)
        {
            cargar();
        }

        private void xfrm_consulta_Inventario_Activated(object sender,EventArgs e)
        {
            cargar();
        }

        private void bbi_exportar_excel_ItemClick(object sender,DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new Clases.Exportar().Exportar_Grid_A_Excel(grid_Consulta_Inventario);
        }
    }
}