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
using Presentacion.Formularios.Catalogos;

namespace Presentacion.Formularios.Inventario
{
    public partial class xfrm_Consulta_Traslados:DevExpress.XtraEditors.XtraForm
    {
        public xfrm_Consulta_Traslados( )
        {
            InitializeComponent();
        }

        private void barButtonItem1_ItemClick(object sender,DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var Traslados = Negocio.ClasesCN.InventarioCN.Traslados_Select_Rango(date_desde.DateTime,date_hasta.DateTime);

                if(Convert.ToString(look_bodega.EditValue) == "TODAS" || look_bodega.EditValue == null)
                {
                    grid_control_traslados.DataSource = Traslados.ToList();

                }
                else
                {
                    grid_control_traslados.DataSource = Traslados.Where(O=>O.nombre==look_bodega.EditValue.ToString()).ToList();
                }

            }
            catch(Exception ex)
            {

                throw;
            }
        }

        private void xfrm_Consulta_Traslados_Load(object sender,EventArgs e)
        {
            date_desde.DateTime = DateTime.Now.AddDays(-1);

            date_hasta.DateTime = DateTime.Now;
            //Clases.UsuarioLogueado.bodegaEspecial(look_bodega);
            //var Bodegas= Negocio.ClasesCN.CatalogosCN.Bodega_Cargar().ToList();
            look_bodega.Properties.DataSource = getBodegas();
         }

        DataTable getBodegas()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id");
            dt.Columns.Add("nombre");
            DataRow row = dt.NewRow();

            row["id"] = 0;
            row["nombre"] = "TODAS";
            dt.Rows.Add(row);
            row = dt.NewRow();

            foreach (var cat in Negocio.ClasesCN.CatalogosCN.Bodega_Cargar())
            {
                row["id"] = cat.id;
                row["nombre"] = cat.nombre;
                dt.Rows.Add(row);
                row = dt.NewRow();
            }

            return dt;
        }

        private void btn_vaciar_Click(object sender,EventArgs e)
        {
            look_bodega.EditValue = null;
        }

        private void iMPRIMIRTRASLADOToolStripMenuItem_Click(object sender,EventArgs e)
        {
            BindingSource source = new BindingSource();
            int vMov = Convert.ToInt32(gview_traslados.GetFocusedRowCellDisplayText("id"));
            var deBodega = Negocio.ClasesCN.InventarioCN.Traslado_ObtenerBodega(vMov, 0);
            var haciaBodega = Negocio.ClasesCN.InventarioCN.Traslado_ObtenerBodega(vMov, 1);
            source.DataSource = Negocio.ClasesCN.InventarioCN.Traslado_Reporte(vMov,haciaBodega.Item1);
            var report = new Reportes.Inventario.xrpt_traslado_bodega(source);
            report.Parameters[0].Value = deBodega.Item2;
            report.ShowPreviewDialog();
        }

        private void contextMenuStrip1_Opening(object sender,CancelEventArgs e)
        {
            try
            {

                if(gview_traslados.IsDataRow(gview_traslados.FocusedRowHandle) && gview_traslados.RowCount >0)
                {
                    int vMov = Convert.ToInt32(gview_traslados.GetFocusedRowCellDisplayText("id"));
                    DateTime Fecha= Convert.ToDateTime(gview_traslados.GetFocusedRowCellDisplayText("fecha_documento"));

                    int estado=Negocio.ClasesCN.InventarioCN.Estado_Movimiento(vMov);

                    rEVERTIRTRASLADOToolStripMenuItem.Enabled = estado == 1; //&& Fecha.Date==DateTime.Now.Date;
                    
                }
                
            }
            catch(Exception ex)
            {
                new Clases.ClaseValidacionCampos().Escribir_Error(ex);
                throw;
            }
        }

        private void rEVERTIRTRASLADOToolStripMenuItem_Click(object sender,EventArgs e)
        {
            try
            {
                if(gview_traslados.RowCount > 0 && gview_traslados.IsDataRow(gview_traslados.FocusedRowHandle))
                {
                    int vMov = Convert.ToInt32(gview_traslados.GetFocusedRowCellDisplayText("id"));
                    string  numero = Convert.ToString(gview_traslados.GetFocusedRowCellDisplayText("numero_documento"));

                    var FAutorizacion= new  xfrm_autorizacion("REVERTIR MOVIMIENTO DE TRASLADO");
                    FAutorizacion.numero_permiso = 126;
                    FAutorizacion.permiso = "REVERTIR MOVIMIENTO DE INVENTARIO";
                    FAutorizacion.ShowDialog();

                    if(FAutorizacion.Autorizado)
                    {
                        Clases.MyMessageBox.MessageFont = new Font(Clases.MyMessageBox.MessageFont.FontFamily,16);
                        DialogResult Pregunta= Clases.MyMessageBox.Show($"¿Esta Completamente seguro de Anular el Traslado numero {numero}?","Confirmacion",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                        if(Pregunta == DialogResult.Yes)
                        {
                            int resultado = Negocio.ClasesCN.InventarioCN.Revierte_Movimiento(vMov);
                            if(resultado > 0)
                            {
                                Clases.MyMessageBox.Show($"Movimiento {numero} fue Anulado Correctamente");
                                barButtonItem1_ItemClick(null,null);

                            }
                        }
                    }


                    else
                    {
                        XtraMessageBox.Show("La acción de " + FAutorizacion.permiso + " no fue autorizada","Mensaje",MessageBoxButtons.OK,MessageBoxIcon.Error);

                    }
                }
            }
            catch(Exception ex)
            {
                new Clases.ClaseValidacionCampos().Escribir_Error(ex);
                throw;
            }
        }

        private void EditarObservacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int vMov = Convert.ToInt32(gview_traslados.GetFocusedRowCellDisplayText("id"));
            xfrm_observacionTraslados form = new xfrm_observacionTraslados(vMov, date_desde.DateTime, date_hasta.DateTime);
            form.ShowDialog();
            form.Dispose();
            barButtonItem1_ItemClick(null, null);
        }

        private void iMPRIMIRTRASLADOMCARTAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BindingSource source = new BindingSource();
            int vMov = Convert.ToInt32(gview_traslados.GetFocusedRowCellDisplayText("id"));
            var deBodega = Negocio.ClasesCN.InventarioCN.Traslado_ObtenerBodega(vMov, 0);
            var haciaBodega = Negocio.ClasesCN.InventarioCN.Traslado_ObtenerBodega(vMov, 1);
            source.DataSource = Negocio.ClasesCN.InventarioCN.Traslado_Reporte(vMov, haciaBodega.Item1);
            var report = new Reportes.Inventario.xrpt_traslado_bodega_MCarta(source);
            report.Parameters[0].Value = deBodega.Item2;
            report.ShowPreviewDialog();
        }
    }
}