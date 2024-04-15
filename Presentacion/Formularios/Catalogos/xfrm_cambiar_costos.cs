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
    public partial class xfrm_cambiar_costos : DevExpress.XtraEditors.XtraForm
    {
        public xfrm_cambiar_costos()
        {
            InitializeComponent();
        }
        private void Cargar_Usuarios()
        {
            srch_usuarios.Properties.DataSource = Negocio.ClasesCN.CatalogosCN.Linea_Cargar().ToList();
            srch_usuarios2.Properties.DataSource = Negocio.ClasesCN.CatalogosCN.Linea_Cargar().ToList();
            bindingSourceLinea.DataSource = Negocio.ClasesCN.CatalogosCN.Linea_Cargar();
        }

        private void Cargar_Productos(int agrega)
        {
            if (agrega == 1)
            {
                gridControl_permisos_sin_asignar.DataSource = Negocio.ClasesCN.CatalogosCN.Producto_Cargar().Where(o => o.id_linea == Convert.ToInt32(srch_usuarios.EditValue)).ToList();
            }
            else
            {
                gridControl_permisos_asignados.DataSource = Negocio.ClasesCN.CatalogosCN.Producto_Cargar().Where(o => o.id_linea == Convert.ToInt32(srch_usuarios2.EditValue)).ToList();
                //form.CargarProductos();
            }
            
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
            int id_subgrupo = Convert.ToInt32(srch_usuarios.EditValue);
            if (id_subgrupo != 0)
            {
                int ok = 0;
                for (int I = 0; (I <= (gridView_permisos_sin_asignar.RowCount - 1)); I++)
                {
                    int id_producto = Convert.ToInt32(gridView_permisos_sin_asignar.GetRowCellValue(I, "id"));
                    decimal costo = Convert.ToDecimal(gridView_permisos_sin_asignar.GetRowCellValue(I, "costo"));
                    var queryProd = Negocio.ClasesCN.CatalogosCN.Producto_Cargar().Where(x => x.id == id_producto).FirstOrDefault();
                    if ((gridView_permisos_sin_asignar.IsRowSelected(I) == true))
                    {
                        ok += Negocio.ClasesCN.CatalogosCN.CambiarCostoProductos(id_producto,costo);
                    }

                }
                if (ok > 0)
                {
                    XtraMessageBox.Show("Costos Asignados Correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    gridView_permisos_sin_asignar.ClearColumnsFilter();
                    Cargar_Productos(1);
                }
            }
            else
            {
                XtraMessageBox.Show("Por favor seleccione un subgrupo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        if (querysub.descripcion_subgrupo == "")
                        {
                            ok += Negocio.ClasesCN.CatalogosCN.Producto_Actualizar_SubGrupo(queryProd.id, queryProd.codigo, queryProd.descripcion, queryProd.id_categoria, queryProd.id_marca, querysub.id, id_subgrupo2, Convert.ToInt32(queryProd.id_unidad_medida), queryProd.moneda, Convert.ToDecimal(queryProd.costo), Convert.ToDecimal(queryProd.utilidad), Convert.ToDecimal(querysub.precio_mayor), Convert.ToDecimal(querysub.precio_eventual), Convert.ToDecimal(querysub.precio_eventual), Convert.ToDecimal(querysub.precio_4), Convert.ToDecimal(querysub.precio_5), Convert.ToDecimal(querysub.precio_6), Convert.ToDecimal(querysub.precio_7), Convert.ToDecimal(querysub.precio_8), Convert.ToDecimal(querysub.precio_9), Convert.ToDecimal(querysub.precio_10), Convert.ToDecimal(querysub.precio_11), Convert.ToDecimal(querysub.precio_12), Convert.ToDecimal(querysub.precio_13),Convert.ToDecimal(queryProd.descuento), Convert.ToDecimal(queryProd.impuesto), Convert.ToDecimal(queryProd.stock_minimo), null, numero_serie, Clases.UsuarioLogueado.vID_Empleado, Convert.ToBoolean(queryProd.tipo_producto));
                        }
                        else
                        {
                            ok += Negocio.ClasesCN.CatalogosCN.Producto_Actualizar_SubGrupo(queryProd.id, queryProd.codigo, querysub.descripcion_subgrupo, queryProd.id_categoria, queryProd.id_marca, querysub.id, id_subgrupo2, Convert.ToInt32(queryProd.id_unidad_medida), queryProd.moneda, Convert.ToDecimal(queryProd.costo), Convert.ToDecimal(queryProd.utilidad), Convert.ToDecimal(querysub.precio_mayor), Convert.ToDecimal(querysub.precio_eventual), Convert.ToDecimal(querysub.precio_eventual), Convert.ToDecimal(querysub.precio_4), Convert.ToDecimal(querysub.precio_5), Convert.ToDecimal(querysub.precio_6), Convert.ToDecimal(querysub.precio_7), Convert.ToDecimal(querysub.precio_8), Convert.ToDecimal(querysub.precio_9), Convert.ToDecimal(querysub.precio_10), Convert.ToDecimal(querysub.precio_11),Convert.ToDecimal(querysub.precio_12),Convert.ToDecimal(querysub.precio_13), Convert.ToDecimal(queryProd.descuento), Convert.ToDecimal(queryProd.impuesto), Convert.ToDecimal(queryProd.stock_minimo), null, numero_serie, Clases.UsuarioLogueado.vID_Empleado, Convert.ToBoolean(queryProd.tipo_producto));
                        }
                    }

                }
                if (ok > 0)
                {
                    XtraMessageBox.Show("SubGrupo cambiado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Cargar_Productos(0);
                    //Cargar_Productos(1);
                }
            }
            else
            {
                XtraMessageBox.Show("Por favor seleccione el subgrupo de destino", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            //int id_subgrupo = Convert.ToInt32(srch_usuarios.EditValue);
            //int id_subgrupoA = Convert.ToInt32(srch_usuarios2.EditValue);
            //srch_usuarios2.EditValue = null;
            if (srch_usuarios.EditValue != null)
            {
                //srch_usuarios2.Properties.DataSource = Negocio.ClasesCN.CatalogosCN.Linea_Cargar().Where(x => x.id != Convert.ToInt32(srch_usuarios.EditValue));
                //srch_usuarios2.EditValue = id_subgrupoA; 
                Cargar_Productos(1);
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
                    DialogResult preg = (XtraMessageBox.Show("¿Desea agregar estos productos?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question));
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
                    DialogResult preg = (XtraMessageBox.Show("¿Desea cambiar el subgrupo de este producto ?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question));
                    if (preg == DialogResult.Yes)
                        Quitar_Permisos();
                }
            }
        }

        private void srch_usuarios2_EditValueChanged(object sender, EventArgs e)
        {
            //int id_subgrupo = Convert.ToInt32(srch_usuarios2.EditValue);
            ////int id_subgrupoA = Convert.ToInt32(srch_usuarios.EditValue);
            ////srch_usuarios2.EditValue = null;
            if (srch_usuarios2.EditValue != null)
            {
                //srch_usuarios.Properties.DataSource = Negocio.ClasesCN.CatalogosCN.Linea_Cargar().Where(x => x.id != Convert.ToInt32(srch_usuarios2.EditValue));
                //srch_usuarios.EditValue = id_subgrupoA;
                //Cargar_Productos(0);
            }
            else
                limpiar_grid();

        }

        private void bbi_limpiar_Click(object sender, EventArgs e)
        {
            limpiar_grid();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (srch_usuarios.EditValue != null)
            {
                //recorrer();
                if (Validar_Asignar_Permisos() == false)
                    XtraMessageBox.Show("No hay productos seleccionados seleccionados", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    DialogResult preg = (XtraMessageBox.Show("¿Desea agregar estos productos?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question));
                    if (preg == DialogResult.Yes)
                        Asignar_Permisos();
                }
            }
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            while (gridView_permisos_sin_asignar.RowCount != 0)
            {
                gridView_permisos_sin_asignar.SelectAll();
                gridView_permisos_sin_asignar.DeleteSelectedRows();
                gridView_permisos_sin_asignar.ClearColumnsFilter();
            }
            srch_usuarios.EditValue = null;
        }
    }
}