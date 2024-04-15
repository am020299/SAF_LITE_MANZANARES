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

namespace Presentacion.Formularios.Catalogos
{
    public partial class xfrm_productos_inactivos : DevExpress.XtraEditors.XtraForm
    {
        public xfrm_productos_inactivos()
        {
            InitializeComponent();
        }
        private void Cargar_Usuarios()
        {
            srch_usuarios.Properties.DataSource = Negocio.ClasesCN.CatalogosCN.Linea_Cargar().ToList();
            srch_usuarios2.Properties.DataSource = Negocio.ClasesCN.CatalogosCN.Linea_Cargar().ToList();
            bindingSourceLinea.DataSource = Negocio.ClasesCN.CatalogosCN.Linea_Cargar();
        }

        private void Cargar_Productos()
        {
                gridControl_permisos_sin_asignar.DataSource = Negocio.ClasesCN.CatalogosCN.Producto_Cargar().Where(o => o.id_linea == Convert.ToInt32(srch_usuarios.EditValue) && o.habilitado == true).ToList();
                gridControl_permisos_asignados.DataSource = Negocio.ClasesCN.CatalogosCN.Producto_Cargar().Where(o => o.id_linea == Convert.ToInt32(srch_usuarios.EditValue) && o.habilitado == false).ToList();
        }
        private bool Validar_Asignar_Permisos()
        {
            int contador = 0;
            for (int I = 0; (I <= (gridView_permisos_sin_asignar.RowCount - 1)); I++)
            {
                if ((gridView_permisos_sin_asignar.IsRowSelected(I) == true))
                    contador += 1;
            }
            if (contador > 0)
                return true;
            else
                return false;
        }

        private bool Validar_Quitar_Permisos()
        {
            int contador = 0;
            for (int I = 0; (I <= (gridView_permisos_asignados.RowCount - 1)); I++)
            {
                if ((gridView_permisos_asignados.IsRowSelected(I) == true))
                    contador += 1;
            }
            if (contador > 0)
                return true;
            else
                return false;
        }
        private void Asignar_Permisos()
        {
            string numero_serie = "";
            int id_subgrupo = Convert.ToInt32(srch_usuarios2.EditValue);
            int id_subgrupo2 = Convert.ToInt32(srch_usuarios.EditValue);
            if (id_subgrupo2 != 0)
            {
                int ok = 0;
                for (int I = 0; (I <= (gridView_permisos_sin_asignar.RowCount - 1)); I++)
                {
                    int id_rol = Convert.ToInt32(gridView_permisos_sin_asignar.GetRowCellValue(I, "id"));
                    var queryProd = Negocio.ClasesCN.CatalogosCN.Producto_Cargar().Where(x => x.id == id_rol).FirstOrDefault();
                    var querysub = Negocio.ClasesCN.CatalogosCN.Linea_Cargar().Where(x => x.id == id_subgrupo).FirstOrDefault();
                    if ((gridView_permisos_sin_asignar.IsRowSelected(I) == true))
                    {
                        ok += Negocio.ClasesCN.CatalogosCN.ProductoHabilitar(queryProd.id, false);
                    }

                }
                if (ok > 0)
                {
                    XtraMessageBox.Show("Producto Deshabilitado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Cargar_Productos();
                }
            }
            else
            {
                XtraMessageBox.Show("Por favor seleccione al menos un producto", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }
        private void Quitar_Permisos()
        {
            string numero_serie = "";
            int id_subgrupo = Convert.ToInt32(srch_usuarios.EditValue);
            int id_subgrupo2 = Convert.ToInt32(srch_usuarios2.EditValue);
            if (id_subgrupo != 0)
            {
                int ok = 0;
                for (int I = 0; (I <= (gridView_permisos_asignados.RowCount - 1)); I++)
                {
                    int id_rol = Convert.ToInt32(gridView_permisos_asignados.GetRowCellValue(I, "id"));
                    var queryProd = Negocio.ClasesCN.CatalogosCN.Producto_Cargar().Where(x => x.id == id_rol).FirstOrDefault();
                    var querysub = Negocio.ClasesCN.CatalogosCN.Linea_Cargar().Where(x => x.id == id_subgrupo).FirstOrDefault();
                    if ((gridView_permisos_asignados.IsRowSelected(I) == true))
                    {
                        ok += Negocio.ClasesCN.CatalogosCN.ProductoHabilitar(queryProd.id, true);
                    }

                }
                if (ok > 0)
                {
                    XtraMessageBox.Show("Producto Habilitado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Cargar_Productos();
                }
            }
            else
            {
                XtraMessageBox.Show("Por favor seleccione al menos un producto", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        private void limpiar_grid()
        {
            while (gridView_permisos_asignados.RowCount != 0)
            {
                gridView_permisos_asignados.SelectAll();
                gridView_permisos_asignados.DeleteSelectedRows();
                
            }
            while (gridView_permisos_sin_asignar.RowCount != 0)
            {
                
                gridView_permisos_sin_asignar.SelectAll();
                gridView_permisos_sin_asignar.DeleteSelectedRows();
            }
            srch_usuarios.EditValue = null;
            srch_usuarios2.EditValue = null;
        }
        private void xfrm_asignar_permisos_Load(object sender, EventArgs e)
        {
            Cargar_Usuarios();
        }
        private void srch_usuarios_EditValueChanged(object sender, EventArgs e)
        {
            if (srch_usuarios.EditValue != null)
            {
                Cargar_Productos();
            }
            else
                limpiar_grid();

        }
        private void btn_asignar_Click(object sender, EventArgs e)
        {
            if (srch_usuarios.EditValue!= null)
            {
                //recorrer();
                if (Validar_Asignar_Permisos() == false)
                    XtraMessageBox.Show("No hay productos seleccionados seleccionados", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    DialogResult preg = (XtraMessageBox.Show("¿Desea deshabilitar estos productos?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question));
                    if (preg == DialogResult.Yes)
                        Asignar_Permisos();
                }
            }
        }
        private void btn_retirar_Click(object sender, EventArgs e)
        {
            if (srch_usuarios.EditValue != null)
            {
                if (Validar_Quitar_Permisos() == false)
                    XtraMessageBox.Show("No hay permisos seleccionados", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    DialogResult preg = (XtraMessageBox.Show("¿Desea habilitar estos productos?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question));
                    if (preg == DialogResult.Yes)
                        Quitar_Permisos();
                }
            }
        }

        private void srch_usuarios2_EditValueChanged(object sender, EventArgs e)
        {
            if (srch_usuarios2.EditValue != null)
            {
                Cargar_Productos();
            }
            else
                limpiar_grid();

        }

        private void bbi_limpiar_Click(object sender, EventArgs e)
        {
            limpiar_grid();
        }
    }
}