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

namespace Presentacion.Formularios.Mantenimiento
{
    public partial class xfrm_asignar_permisos : DevExpress.XtraEditors.XtraForm
    {
        public xfrm_asignar_permisos()
        {
            InitializeComponent();
        }
        private void Cargar_Usuarios()
        {
            srch_usuarios.Properties.DataSource = Negocio.ClasesCN.CatalogosCN.Empleado_Cargar().ToList();
        }
        private void Cargar_Permisos()
        {
            int id_empleado = Convert.ToInt32(srch_usuarios.EditValue);
            //gridControl_permisos_asignados.DataSource = Negocio.ClasesCN.RolesPermisosCN.Cargar_Permisos(id_empleado).Where(o => o.asignado == 1 && !o.descripcion.Contains("BodegaEspecial")).ToList();
            gridControl_permisos_asignados.DataSource = Negocio.ClasesCN.RolesPermisosCN.Cargar_Permisos(id_empleado).Where(o=>o.asignado==1).ToList();
            gridControl_permisos_sin_asignar.DataSource = Negocio.ClasesCN.RolesPermisosCN.Cargar_Permisos(id_empleado).Where(o => o.asignado == 0).ToList();
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
        private void recorrer()
        {
            //int contador = 0;
            for (int I = 0; (I <= (gridView_permisos_sin_asignar.RowCount - 1)); I++)
            {
                int id_rol = Convert.ToInt32(gridView_permisos_sin_asignar.GetRowCellValue(I, "id"));
                if ((gridView_permisos_sin_asignar.IsRowSelected(I) == true))
                {
                    XtraMessageBox.Show(id_rol.ToString());
                }   
            }  
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
            int id_empleado = Convert.ToInt32(srch_usuarios.EditValue);
            int ok = 0;
            for (int I = 0; (I <= (gridView_permisos_sin_asignar.RowCount - 1)); I++)
            {
                int id_rol = Convert.ToInt32(gridView_permisos_sin_asignar.GetRowCellValue(I, "id"));
                if ((gridView_permisos_sin_asignar.IsRowSelected(I) == true))
                    ok += Negocio.ClasesCN.RolesPermisosCN.Agregar_Quitar_Permisos(id_empleado, id_rol);
            }
            if (ok > 0)
            {
                XtraMessageBox.Show("Permisos Asignados Correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Cargar_Permisos();
            }  
        }
        private void Quitar_Permisos()
        {
            int id_empleado = Convert.ToInt32(srch_usuarios.EditValue);
            int ok = 0;
            for (int I = 0; (I <= (gridView_permisos_asignados.RowCount - 1)); I++)
            {
                int id_rol = Convert.ToInt32(gridView_permisos_asignados.GetRowCellValue(I, "id"));
                if ((gridView_permisos_asignados.IsRowSelected(I) == true))
                    ok += Negocio.ClasesCN.RolesPermisosCN.Agregar_Quitar_Permisos(id_empleado, id_rol);
            }
            if (ok > 0)
            {
                XtraMessageBox.Show("Permisos Removidos Correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Cargar_Permisos();
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
        }
        private void xfrm_asignar_permisos_Load(object sender, EventArgs e)
        {
            Cargar_Usuarios();
        }
        private void srch_usuarios_EditValueChanged(object sender, EventArgs e)
        {
            if (srch_usuarios.EditValue != null)
                Cargar_Permisos();
            else
                limpiar_grid();
        }
        private void btn_asignar_Click(object sender, EventArgs e)
        {
            if (srch_usuarios.EditValue!= null)
            {
                //recorrer();
                if (Validar_Asignar_Permisos() == false)
                    XtraMessageBox.Show("No hay permisos seleccionados", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    DialogResult preg = (XtraMessageBox.Show("¿Desea Asignar Estos Permisos?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question));
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
                    DialogResult preg = (XtraMessageBox.Show("¿Desea Remover Estos Permisos?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question));
                    if (preg == DialogResult.Yes)
                        Quitar_Permisos();
                }
            }
        }
    }
}