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
using DevExpress.XtraReports.Parameters;

namespace Presentacion.Formularios.Inventario
{
    public partial class xfrm_movimiento_inventario_detallado:DevExpress.XtraEditors.XtraForm
    {
        string usuario;
        string cargo;
        public xfrm_movimiento_inventario_detallado( )
        {
            InitializeComponent();
            usuario = Clases.UsuarioLogueado.vNickName;
            cargo = Clases.UsuarioLogueado.vPuestoCargo;
        }

        private void xfrm_movimiento_inventario_detallado_Load(object sender,EventArgs e)
        {
            dtp_desde.DateTime = DateTime.Now.AddDays(-15);
            dtp_hasta.DateTime = DateTime.Now.Date;

        }

        private void bbi_cargar_ItemClick(object sender,DevExpress.XtraBars.ItemClickEventArgs e)
        {


            try
            {
                if (Clases.UsuarioLogueado.saberAdminM())
                {
                    binding_detalles.DataSource = Negocio.ClasesCN.InventarioCN.Movimiento_detallado_por_rango(dtp_desde.DateTime, dtp_hasta.DateTime);
                }
                else
                {
                    binding_detalles.DataSource = Negocio.ClasesCN.InventarioCN.Movimiento_detallado_por_rango(dtp_desde.DateTime, dtp_hasta.DateTime).Where(x => !x.nombre.Contains("BODEGA ESPECIAL"));
                }
               
                grid_movimiento_detalle.DataSource = binding_detalles;
                
            }
            catch(Exception ex)
            {

                throw;
            }
        }

        private void binding_detalles_CurrentChanged(object sender,EventArgs e)
        {

        }

        private void bbi_excel_ItemClick(object sender,DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                new Clases.Exportar().Exportar_Grid_A_Excel(grid_movimiento_detalle);

            }
            catch(Exception)
            {

                throw;
            }
        }

        private void bbi_reporte_ItemClick(object sender,DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var Consulta=Negocio.ClasesCN.InventarioCN.Movimiento_detallado_por_rango(dtp_desde.DateTime,dtp_hasta.DateTime);
               // string []Tipo_Movimientos=Consulta.Select(C=>C.descripcion_corta).Distinct().ToArray();
                var Reporte=new Reportes.Inventario.xrpt_reporte_movimiento_detallas();
                string [] Tipos_Movimientos=Consulta.Select(X=>X.descripcion_corta).Distinct().ToArray();
                string [] Bodegas=Consulta.Select(X=>X.nombre).Distinct().ToArray();

                //    Reporte.DataSource = Consulta.Select(E=>new { E.empresa_nombre,E.empresa_ruc,E.empresa_direccion,E.empresa_eslogan,E.empresa_telefono}).Distinct().ToList();
                Reporte.Tipo_Movimientos = Tipos_Movimientos;
                Reporte.Bodegas = Bodegas;
                Reporte.Tipo_Movimiento.Visible = true;
                Reporte.DataSource = Consulta;
                Reporte.desde.Value = dtp_desde.DateTime.Date;
                Reporte.hasta.Value = dtp_hasta.DateTime.Date;

                Reporte.Tipo_Movimiento.Value = Consulta.Count() > 0 ? Consulta.FirstOrDefault().descripcion_corta : string.Empty;
                DynamicListLookUpSettings tipo_movimientoSettings = new DynamicListLookUpSettings();
                tipo_movimientoSettings.DataSource = Consulta;
                tipo_movimientoSettings.DisplayMember = "descripcion_corta";
                tipo_movimientoSettings.ValueMember = "descripcion_corta";
                Reporte.Tipo_Movimiento.LookUpSettings = tipo_movimientoSettings;


                Reporte.BODEGA.Value = Consulta.Count() > 0 ? Consulta.FirstOrDefault().nombre : string.Empty;
                DynamicListLookUpSettings bodegaSettings = new DynamicListLookUpSettings();
                bodegaSettings.DataSource = Consulta;
                bodegaSettings.DisplayMember = "nombre";
                bodegaSettings.ValueMember = "nombre";
                Reporte.BODEGA.LookUpSettings = bodegaSettings;

                Reporte.RequestParameters = false;
                Reporte.ShowPreview();
                 





            }
            catch(Exception)
            {

                throw;
            }
        }
    }
}