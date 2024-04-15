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
    public partial class xfrm_usuarios_logueados : DevExpress.XtraEditors.XtraForm
    {
        int id_empleado;
        public xfrm_usuarios_logueados()
        {
            InitializeComponent();
            id_empleado = Clases.UsuarioLogueado.vID_Empleado;
        }
        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(gridView_Usuarios_Logueados.GetRowCellValue(gridView_Usuarios_Logueados.FocusedRowHandle, "id_empleado"));
            if (id > 0)
            {
                if (id == id_empleado)
                {
                    XtraMessageBox.Show("Usuario no puede cerrar su misma sesión", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    gridControl_Usuarios_Logueados.DataSource = Negocio.ClasesCN.LoginsCN.Cargar_Usuarios_Logueados().ToList();
                }
                else
                {
                    DialogResult preg = XtraMessageBox.Show("¿Desea cerrar sesión para este usuario?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (preg == DialogResult.Yes)
                    {
                        int ok = Negocio.ClasesCN.LoginsCN.Terminar_inicio_sesion(id);
                        if (ok > 0)
                        {
                            XtraMessageBox.Show("Sesión cerrada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            gridControl_Usuarios_Logueados.DataSource = Negocio.ClasesCN.LoginsCN.Cargar_Usuarios_Logueados().ToList();
                        }
                    }
                }
            }
        }
        private void xfrm_usuarios_logueados_Load(object sender, EventArgs e)
        {
            gridControl_Usuarios_Logueados.DataSource = Negocio.ClasesCN.LoginsCN.Cargar_Usuarios_Logueados().ToList();
        }

        private void bbi_actualizar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridControl_Usuarios_Logueados.DataSource = Negocio.ClasesCN.LoginsCN.Cargar_Usuarios_Logueados().ToList();
        }
    }
}