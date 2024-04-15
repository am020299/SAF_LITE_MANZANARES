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
using System.IO;
using System.Data.SqlClient;

namespace Presentacion.Formularios.Mantenimiento
{
    public partial class xfrm_mantenimiento : DevExpress.XtraEditors.XtraForm
    {
        public xfrm_mantenimiento()
        {
            InitializeComponent();
        }
        private void Crear_respaldo(string direccion)
        {
            DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(typeof(Presentacion.Formularios.Principal.WaitForm1));
            if (Negocio.ClasesCN.MantenimientoCN.Crear_Respaldo(direccion) > 0)
            {
                XtraMessageBox.Show("Respaldo realizado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm();
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName="";
            saveFileDialog1.Filter = "All files (*.bak*)|*.bak*";
            saveFileDialog1.ShowDialog();
        }
        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string name = saveFileDialog1.FileName;
            if (name.Contains(".bak"))
                name = saveFileDialog1.FileName;
            else
                name = name + ".bak";

            //XtraMessageBox.Show(name);
            Crear_respaldo(name);
        }
    }
}