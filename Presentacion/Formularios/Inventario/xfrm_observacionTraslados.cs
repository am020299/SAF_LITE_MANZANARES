using DevExpress.XtraEditors;
using Presentacion.Formularios.Catalogos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Formularios.Inventario
{
    public partial class xfrm_observacionTraslados : DevExpress.XtraEditors.XtraForm
    {
        int idMovimiento = 0;
        DateTime fechaini, fechafin;
        public xfrm_observacionTraslados(int idMov, DateTime fechaInicio, DateTime fechaFinal)
        {
            this.idMovimiento = idMov;
            this.fechaini = fechaInicio;
            this.fechafin = fechaFinal;
            InitializeComponent();
        }

        private void bbi_cerrar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void bbi_Guardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var Permisos = Negocio.ClasesCN.RolesPermisosCN.Cargar_Permisos(0).Where(p => p.id_rol == 11156).FirstOrDefault();
            xfrm_autorizacion frm = new xfrm_autorizacion("ACTUALIZAR OBSERVACION DE TRASLADOS");
            frm.numero_permiso = Permisos.id_rol ?? 0;
            frm.permiso = Permisos.descripcion.ToUpper();
            frm.ShowDialog();
            if (frm.Autorizado)
            {
                string vobservacion = memoEditObservacion.Text;
                var query = Negocio.ClasesCN.InventarioCN.ActualizarObservacionTraslados(idMovimiento, vobservacion);
                if (query != 0)
                {
                    XtraMessageBox.Show("Observacion Editada Correctamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            else
            {
                XtraMessageBox.Show($"Usted no tiene autorizacion de {frm.permiso.ToUpper()}", "Información");
            }

        }

        private void xfrm_observacionTraslados_Load(object sender, EventArgs e)
        {
            var Traslados = Negocio.ClasesCN.InventarioCN.Traslados_Select_Rango(fechaini, fechafin).Where(x => x.id == idMovimiento).FirstOrDefault();
            if(Traslados != null)
            {
                memoEditObservacion.Text = Traslados.observacion;
            }
        }
    }
}