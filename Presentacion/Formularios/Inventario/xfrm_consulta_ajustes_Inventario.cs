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
using Entidades;
using Presentacion.Formularios.Catalogos;

namespace Presentacion.Formularios.Inventario
{
    public partial class xfrm_consulta_ajustes_Inventario:DevExpress.XtraEditors.XtraForm
    {
       
        public xfrm_consulta_ajustes_Inventario()
        {
            InitializeComponent();
        }
        List<Entidades.Ajsutes_Select_Rango_Result>Ajustes_Todos_Select= new List<Ajsutes_Select_Rango_Result>();
        private void xfrm_consulta_ajustes_Inventario_Load(object sender,EventArgs e)
        {
            date_desde.DateTime = DateTime.Now.AddDays(-1);

            date_hasta.DateTime = DateTime.Now;
            var Ajustes=Negocio.ClasesCN.CatalogosCN.TiposAjuste_Select().ToList();
            Clases.UsuarioLogueado.bodegaEspecial(look_bodega);//Se comprueba si el usuario tiene los permisos en este caso solo el admin-marling
            //var Bodegas= Negocio.ClasesCN.CatalogosCN.Bodega_Cargar().ToList();
            //look_bodega.Properties.DataSource = Bodegas;
            look_tipo_movimiento.Properties.DataSource = Ajustes;
        

         }

        private void barButtonItem1_ItemClick(object sender,DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                Ajustes_Todos_Select = Negocio.ClasesCN.InventarioCN.Ajustes_Select_Rango_fechas(date_desde.DateTime,date_hasta.DateTime);

                if(look_tipo_movimiento.EditValue == null && look_bodega.EditValue == null)
                {
                    grid_control_ajustes.DataSource = Ajustes_Todos_Select;
                }
                else if((look_tipo_movimiento.EditValue != null && look_bodega.EditValue == null))
                {
                    grid_control_ajustes.DataSource = Ajustes_Todos_Select.Where(R => R.id_tipo_ajuste == Convert.ToInt32(look_tipo_movimiento.EditValue)).ToList();
                }
                else if(((look_tipo_movimiento.EditValue == null && look_bodega.EditValue != null)))
                {
                    grid_control_ajustes.DataSource = Ajustes_Todos_Select.Where(R => R.nombre == look_bodega.EditValue.ToString()).ToList();
                }
                else
                {
                    grid_control_ajustes.DataSource = Ajustes_Todos_Select.Where(R => R.nombre == look_bodega.EditValue.ToString() && R.id_tipo_ajuste==Convert.ToInt32(look_tipo_movimiento.EditValue)).ToList();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }

        private void simpleButton2_Click(object sender,EventArgs e)
        {
            look_bodega.EditValue = null;
        }

        private void simpleButton1_Click(object sender,EventArgs e)
        {
            look_tipo_movimiento.EditValue = null;
        }

        private void vERREPORTEDEAJUSTEToolStripMenuItem_Click(object sender,EventArgs e)
        {
            try
            {
                if(gview_ajustes.RowCount > 0 && gview_ajustes.IsDataRow(gview_ajustes.FocusedRowHandle))
                {
                    BindingSource source = new BindingSource();
                    int vMov = Convert.ToInt32(gview_ajustes.GetFocusedRowCellDisplayText("id"));
                    source.DataSource = Negocio.ClasesCN.InventarioCN.Reporte_Ajuste(vMov);
                    var report = new Reportes.Inventario.xrpt_ajuste(source);
                    report.ShowPreviewDialog();
                }
            }
            catch(Exception)
            {

                throw;
            }
        }

        private void bbi_exportar_ItemClick(object sender,DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new Clases.Exportar().Exportar_Grid_A_Excel(grid_control_ajustes);
        }

        private void rEVERTIRAJUSTEToolStripMenuItem_Click(object sender,EventArgs e)
        {
            try
            {
                if(gview_ajustes.RowCount > 0 && gview_ajustes.IsDataRow(gview_ajustes.FocusedRowHandle))
                {
                    int vMov = Convert.ToInt32(gview_ajustes.GetFocusedRowCellDisplayText("id"));
                    string  numero = Convert.ToString(gview_ajustes.GetFocusedRowCellDisplayText("numero_documento"));

                    var FAutorizacion= new  xfrm_autorizacion("REVERTIR MOVIMIENTO DE INVENTARIO");
                    FAutorizacion.numero_permiso = 126;
                    FAutorizacion.permiso = "REVERTIR MOVIMIENTO DE INVENTARIO";
                    FAutorizacion.ShowDialog();

                    if(FAutorizacion.Autorizado)
                    {
                        Clases.MyMessageBox.MessageFont = new Font(Clases.MyMessageBox.MessageFont.FontFamily,16);
                        DialogResult Pregunta= Clases.MyMessageBox.Show($"¿Esta Completamente seguro de Anular el movimiento numero {numero}?","Confirmacion",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
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

        private void contextMenuStrip1_Opening(object sender,CancelEventArgs e)
        {
            try
            {    if(gview_ajustes.RowCount > 0)
                {
                    if(gview_ajustes.IsDataRow(gview_ajustes.FocusedRowHandle))
                    {
                        int vMov = Convert.ToInt32(gview_ajustes.GetFocusedRowCellDisplayText("id"));
                        DateTime Fecha= Convert.ToDateTime(gview_ajustes.GetFocusedRowCellDisplayText("fecha_documento"));

                        int estado=Negocio.ClasesCN.InventarioCN.Estado_Movimiento(vMov);

                        rEVERTIRAJUSTEToolStripMenuItem.Enabled = estado == 1 && Fecha.Date == DateTime.Now.Date;
                    }
                }
            }
            catch(Exception ex)
            {
                new Clases.ClaseValidacionCampos().Escribir_Error(ex);
                throw;
            }
        }

        private void vERREPORTEDEAJUSTEMCARTAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (gview_ajustes.RowCount > 0 && gview_ajustes.IsDataRow(gview_ajustes.FocusedRowHandle))
                {
                    BindingSource source = new BindingSource();
                    int vMov = Convert.ToInt32(gview_ajustes.GetFocusedRowCellDisplayText("id"));
                    source.DataSource = Negocio.ClasesCN.InventarioCN.Reporte_Ajuste(vMov);
                    var report = new Reportes.Inventario.xrpt_ajuste_MCarta(source);
                    report.ShowPreviewDialog();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}