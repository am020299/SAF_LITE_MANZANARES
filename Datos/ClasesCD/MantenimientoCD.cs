using DevExpress.XtraEditors;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Datos.ClasesCD
{
    public class MantenimientoCD
    {
        public int Actualizar_Regristro(int id_empleado, string usuario, string contraseña)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Usuario_ACTUALIZAR_DATOS(id_empleado, usuario, contraseña);
                }
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Error en la ejecución; comunicarse con soporte técnico", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
        public int Crear_Respaldo(string direccion)
        {
            try
            {
                using (var db = new Entities())
                {
                   return db.BD_Crear_Respaldo(direccion);
                }
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Error en la ejecución; comunicarse con soporte técnico", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
    }
}
