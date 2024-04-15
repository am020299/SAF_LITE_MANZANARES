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
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraBars;
using DevExpress.XtraReports.UI;

namespace Presentacion.Formularios.Inventario
{
    public partial class xfrm_KardexConsultaTienda : DevExpress.XtraEditors.XtraForm
    {
        string usuario;
        string cargo;
        public xfrm_KardexConsultaTienda()
        {
            InitializeComponent();
            usuario = Clases.UsuarioLogueado.vNickName;
            cargo = Clases.UsuarioLogueado.vPuestoCargo;
        }

        private void xfrm_Kardex_Load(object sender, EventArgs e)
        {
            //usuario.ToUpper() == "MARLING" && cargo.ToUpper() == "ADMINISTRADOR"
            int vEmpleado = Clases.UsuarioLogueado.vID_Empleado;
            bool tiene_permiso = Presentacion.Clases.UsuarioLogueado.PermisoEspecial(vEmpleado, 133);
            bool cargar_kardex_0 = Negocio.ClasesCN.RolesPermisosCN.Permisos(vEmpleado, 11112);
            bool cargar_total_kardex = Negocio.ClasesCN.RolesPermisosCN.Permisos(vEmpleado, 11114);

            viewKardex.OptionsView.ShowFooter = false;
            if (cargar_total_kardex || Clases.UsuarioLogueado.admin)
                viewKardex.OptionsView.ShowFooter = true;

            if (Clases.UsuarioLogueado.admin)
                bindingSourceKardex.DataSource = Negocio.ClasesCN.InventarioCN.Kardex_Select().Where(x => x.habilitado == true && x.id_bodega == 4 && x.id_lote == 412);
            else
            {
                if (tiene_permiso)
                {
                    toggleSwitch1.Visible = true;
                    if (cargar_kardex_0)
                        bindingSourceKardex.DataSource = Negocio.ClasesCN.InventarioCN.Kardex_Select().Where(x => x.habilitado == true && x.id_bodega == 4 && x.id_lote == 412);
                    else
                        bindingSourceKardex.DataSource = Negocio.ClasesCN.InventarioCN.Kardex_Select().Where(o => o.saldo_actual > 0 && o.habilitado == true && o.id_bodega == 4 && o.id_lote == 412).ToList();
                    verMovimientoPorProductoToolStripMenuItem.Visible = true;
                }
                else
                {
                    toggleSwitch1.Visible = false;
                    bindingSourceKardex.DataSource = Negocio.ClasesCN.InventarioCN.Kardex_Select().Where(o => !o.bodega.Contains("BODEGA ESPECIAL") && o.habilitado == true && o.id_bodega == 4 && o.id_lote == 412);
                    verMovimientoPorProductoToolStripMenuItem.Visible = false;
                }
            }

        }

        private void xfrm_Kardex_Activated(object sender, EventArgs e)
        {
            xfrm_Kardex_Load(null, null);
        }

        PopupMenu menu;
        private void viewKardex_MouseUp(object sender, MouseEventArgs e)
        {
            //try
            //{
            //    if (e.Button == MouseButtons.Right)
            //    {
            //        GridHitInfo hi = viewKardex.CalcHitInfo(e.Location);
            //        object text = "";
            //        if (hi.InRowCell)
            //        {
            //            text = "Exportar a excel";

            //            if (barManager1 == null)
            //            {
            //                barManager1 = new BarManager();
            //                barManager1.Form = this;
            //            }
            //            if (menu == null)
            //                menu = new PopupMenu(barManager1);
            //            menu.ItemLinks.Clear();
            //            BarButtonItem item = new BarButtonItem(barManager1, text.ToString());
            //            item.ImageOptions.ImageIndex = 0;
            //            item.ItemClick += new ItemClickEventHandler(item_Click);
            //            menu.AddItems(new BarItem[] { item });
            //            menu.ShowPopup(Cursor.Position);
            //        }
            //    }
            //}
            //catch (Exception)
            //{

            //}
        }

        void item_Click(object sender, EventArgs e)
        {
            //new Clases.Exportar().Exportar_Grid_A_Excel(gridKardex);
        }

        private void viewKardex_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            try
            {
                //    int vProducto = Convert.ToInt32(viewKardex.GetFocusedRowCellValue("id_producto"));
                //    int vBodega = Convert.ToInt32(viewKardex.GetFocusedRowCellValue("id_bodega"));
                //    string vUbicacion = viewKardex.GetFocusedRowCellValue("ubicacion").ToString().ToUpper();

                //    if (Negocio.ClasesCN.InventarioCN.Kardex_ModificarUbicacion(vProducto, vBodega, vUbicacion) > 0)
                //        bindingSourceKardex.DataSource = Negocio.ClasesCN.InventarioCN.Kardex_Select();
            }
            catch (Exception) { }
        }

        private void exportarExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Clases.Exportar().Exportar_Grid_A_Excel(gridKardex);
        }

        private void verMovimientoPorProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int ip = Convert.ToInt32(viewKardex.GetFocusedRowCellDisplayText("id_producto"));
                int ib = Convert.ToInt32(viewKardex.GetFocusedRowCellDisplayText("id_bodega"));
                int il = Convert.ToInt32(viewKardex.GetFocusedRowCellDisplayText("id_lote"));
                string ubicacion = Convert.ToString(viewKardex.GetFocusedRowCellDisplayText("ubicacion"));

                BindingSource source = new BindingSource();
                source.DataSource = Negocio.ClasesCN.InventarioCN.Movimiento_por_producto(ip, ib, il, ubicacion);

                if (source.Count == 0) return;
                var report = new Reportes.Inventario.ReporteMovimientoProducto(source);
                report.ShowPreview();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error; " + ex);
                throw;
            }

        }

        private void actualizarVentanaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            xfrm_Kardex_Load(null, null);
        }

        private void toggleSwitch1_Toggled(object sender, EventArgs e)
        {
            //if (toggleSwitch1.IsOn)
            //{
                
            //    bindingSourceKardex.DataSource = Negocio.ClasesCN.InventarioCN.Kardex_Select().Where(o => o.saldo_actual > 0).ToList();
            //}
            //else
            //{
            //    bindingSourceKardex.DataSource = Negocio.ClasesCN.InventarioCN.Kardex_Select();
            //}


            int vEmpleado = Clases.UsuarioLogueado.vID_Empleado;
            bool tiene_permiso = Presentacion.Clases.UsuarioLogueado.PermisoEspecial(vEmpleado, 133);
            //bool cargar_kardex_0 = Negocio.ClasesCN.RolesPermisosCN.Permisos(vEmpleado, 11112);
            bool cargar_total_kardex = Negocio.ClasesCN.RolesPermisosCN.Permisos(vEmpleado, 11114);
            {
                if (tiene_permiso)
                {
                    toggleSwitch1.Visible = true;
                    if (toggleSwitch1.IsOn)
                    {
                        bindingSourceKardex.DataSource = Negocio.ClasesCN.InventarioCN.Kardex_Select().Where(o => o.saldo_actual > 0 && o.habilitado == true).ToList();
                    }
                    else
                        bindingSourceKardex.DataSource = Negocio.ClasesCN.InventarioCN.Kardex_Select().Where(x => x.habilitado == true);
                    verMovimientoPorProductoToolStripMenuItem.Visible = true;
                }
                else
                {
                    toggleSwitch1.Visible = false;
                    bindingSourceKardex.DataSource = Negocio.ClasesCN.InventarioCN.Kardex_Select().Where(o => !o.bodega.Contains("BODEGA ESPECIAL") && o.habilitado == true);
                    verMovimientoPorProductoToolStripMenuItem.Visible = false;
                }
            }
        }
    }
}