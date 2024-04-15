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
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraGrid.Views.Grid;
using Entidades;
using Presentacion.Clases;
using DevExpress.XtraReports.UI;

namespace Presentacion.Formularios.Contabilidad
{
    public partial class xfrm_buscarComprobantes:DevExpress.XtraEditors.XtraForm
    {
        DataTable tabla_maestra = new DataTable("MasterTable");
        DataTable tabla_detalle = new DataTable("DetailTable");
        DXErrorProvider ErroProvider= new DXErrorProvider();
        DataView Comprobantes_View= new DataView();
  
       
           public xfrm_buscarComprobantes( )
        {
            InitializeComponent();
            DataColumn parentColumn = new DataColumn("id_comprobante", typeof(int));
            tabla_maestra.Columns.Add(parentColumn);
            tabla_maestra.Columns.AddRange(new DataColumn[]{
                new DataColumn("num_comprobante",typeof(int)),
                new DataColumn("fecha_registro",typeof(DateTime)),
                new DataColumn("fecha_asiento", typeof(DateTime)),
                new DataColumn("concepto", typeof(string)),
                new DataColumn("Tipo", typeof(string)),
                new DataColumn("tipo_numero", typeof(int)),
                 new DataColumn("debe", typeof(decimal)),
                 new DataColumn("haber", typeof(decimal)),
                 new DataColumn("Estado", typeof(bool)),
            });
            DataColumn childrenColumn = new DataColumn("id_comprobante", typeof(int));
            tabla_detalle.Columns.Add(childrenColumn);
            tabla_detalle.Columns.AddRange(new DataColumn[]
            {   new DataColumn("id",typeof(int)),
                new DataColumn("cta",typeof(string)),
                new DataColumn("nombre_cuenta", typeof(string)),
                new DataColumn("debe", typeof(decimal)),
                new DataColumn("haber", typeof(decimal)),
            });
        }

        private void xfrm_buscarComprobantes_Load(object sender,EventArgs e)
        {
            try
            {
                dtp_desde.Properties.MinValue=Negocio.ClasesCN.ContabilidadCN.Fecha_Primer_Asiento();
                dtp_hasta.Properties.MinValue=Negocio.ClasesCN.ContabilidadCN.Fecha_Primer_Asiento();
                dtp_desde.Properties.MaxValue=Negocio.ClasesCN.ContabilidadCN.Fecha_Ultimo_Asiento();
                dtp_hasta.Properties.MaxValue=Negocio.ClasesCN.ContabilidadCN.Fecha_Ultimo_Asiento();
                dtp_hasta.EditValue=DateTime.Now.Date;
                dtp_desde.EditValue=DateTime.Now.Date;
                Look_tipo_comprobante.Properties.DataSource=Negocio.ClasesCN.ContabilidadCN.Tipo_Comprobantes_Select().Where(X => X.estado==1).ToList();
            }
            catch( Exception ex)
            {
                XtraMessageBox.Show($"Lo sentimos ha ocurrido el siguiente error.{Environment.NewLine}Error:{ex.Message}.","Mensaje del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        }
        }
        private DataTable Comprobante_Diarios_Select(DateTime Desde, DateTime Hasta ,int Tipo_Doc)
        {
            try
            {

                tabla_detalle.Clear();
                tabla_maestra.Clear();
                var comprobantes=Negocio.ClasesCN.ContabilidadCN.Comprobante_Diarios_Select(Desde,Hasta,Tipo_Doc).ToList();
                foreach(var C in comprobantes)
                {
                    DataRow Fila= tabla_maestra.NewRow();
                    Fila[0]=C.id;
                    Fila[1]=C.numero_comprobante??0;
                    Fila[2]=C.fecha_registro??DateTime.Now;
                    Fila[3]=C.fecha_asiento??DateTime.Now;
                    Fila[4]=C.concepto??string.Empty;
                    Fila[5]=C.Tipo??string.Empty;
                    Fila[6]=C.tipo_numero??0;
                    Fila[7]=C.debe??0.00m;
                    Fila[8]=C.haber??0.00m;
                    Fila[9]=C.Estado??0;
                    tabla_maestra.Rows.Add(Fila);
                }
                var detalles=Negocio.ClasesCN.ContabilidadCN.ComprobanteDiarioDetalles_Select(Desde,Hasta).ToList();
                foreach(var D in detalles)
                {
                    DataRow Fila=tabla_detalle.NewRow();
                    Fila[0]=D.id_comprobante;
                    Fila[1]=D.id_detalle;
                    Fila[2]=D.numero_cuenta??string.Empty ;
                    Fila[3]=D.nombre_cuenta??String.Empty;
                    Fila[4]=D.debe??0.00m;
                    Fila[5]=D.haber??0.00m;
                    tabla_detalle.Rows.Add(Fila);
                }
                using(DataSet ds = new DataSet())
                {
                    ds.Tables.AddRange(new DataTable[] { tabla_maestra.Copy(),tabla_detalle.Copy() });
                    DataRelation relation = new DataRelation("Detalle Comprobante", ds.Tables[0].Columns[0], ds.Tables[1].Columns[0], false);
                    ds.Relations.Add(relation);
                    return ds.Tables[0];
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show($"Lo sentimos ha ocurrido el siguiente error.{Environment.NewLine}Error:{ex.Message}.","Mensaje del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return tabla_maestra;
            }

        }
        private void bbi_buscar_ItemClick(object sender,DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                ErroProvider.ClearErrors();
                if(Look_tipo_comprobante.EditValue!=null)
                {
                    if(radio_tipo_busqueda.SelectedIndex==0)
                    {
                        if(dtp_desde.Text.Length>0 && dtp_hasta.Text.Length>0)
                        {
                            Comprobantes_View=Comprobante_Diarios_Select(dtp_desde.DateTime.Date,dtp_hasta.DateTime.Date,Convert.ToInt32(Look_tipo_comprobante.EditValue??0)).DefaultView;
                            grid_control_comprobantes.DataSource=Comprobantes_View;
                            radio_tipo_cuadratura_SelectedIndexChanged(null,null);

                        }
                    }
                    else
                    {
                        if(dtp_desde.Text.Length>0 && dtp_hasta.Text.Length>0)
                        {
                            Comprobantes_View=Comprobante_Diarios_Select(dtp_desde.DateTime.Date,dtp_desde.DateTime.Date,Convert.ToInt32(Look_tipo_comprobante.EditValue??0)).DefaultView;
                            grid_control_comprobantes.DataSource=Comprobantes_View;
                            radio_tipo_cuadratura_SelectedIndexChanged(null,null);

                        }
                    }
                    var primero=Negocio.ClasesCN.ContabilidadCN.Fecha_Primer_Asiento();
                    var ultimo=Negocio.ClasesCN.ContabilidadCN.Fecha_Ultimo_Asiento();
                    dtp_desde.Properties.MinValue=primero; ;
                    dtp_hasta.Properties.MinValue=primero;
                    dtp_desde.Properties.MaxValue=ultimo;
                    dtp_hasta.Properties.MaxValue=ultimo;
                } 

            }
            catch(Exception ex)
            {
                XtraMessageBox.Show($"Lo sentimos ha ocurrido el siguiente error.{Environment.NewLine}Error:{ex.Message}.","Mensaje del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void radio_tipo_cuadratura_SelectedIndexChanged(object sender,EventArgs e)
        {
            try
            {
                if(radio_tipo_cuadratura.SelectedIndex==0)
                {
                    Comprobantes_View.RowFilter="";
                    grid_control_comprobantes.DataSource=Comprobantes_View;
                }
                else if(radio_tipo_cuadratura.SelectedIndex==1)
                {
                    Comprobantes_View.RowFilter="debe=haber";
                    grid_control_comprobantes.DataSource=Comprobantes_View;

                }
                else if(radio_tipo_cuadratura.SelectedIndex==2)
                {
                    Comprobantes_View.RowFilter="debe<>haber";
                    grid_control_comprobantes.DataSource=Comprobantes_View;
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show($"Lo sentimos ha ocurrido el siguiente error.{Environment.NewLine}Error:{ex.Message}.","Mensaje del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void gview_comprobantes_CustomSummaryCalculate(object sender,DevExpress.Data.CustomSummaryEventArgs e)
        {
            try
            {
                if(e.IsTotalSummary)
                {
                    GridView view = sender as GridView;
                    decimal vdebe = Convert.ToDecimal(view.Columns["debe"].SummaryItem.SummaryValue);
                    decimal vhaber = Convert.ToDecimal(view.Columns["haber"].SummaryItem.SummaryValue);
                    e.TotalValue = Math.Abs(vdebe-vhaber);
                    e.TotalValueReady = true;
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show($"Lo sentimos ha ocurrido el siguiente error.{Environment.NewLine}Error:{ex.Message}.","Mensaje del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void radio_tipo_busqueda_SelectedIndexChanged(object sender,EventArgs e)
        {
            if(radio_tipo_busqueda.SelectedIndex == 0)
            {
                dtp_desde.Enabled = true;
                dtp_hasta.Enabled=true;
                dtp_desde.Focus();
                grid_control_comprobantes.DataSource = null;
                gview_comprobantes.ClearColumnsFilter();
            }
            else if(radio_tipo_busqueda.SelectedIndex == 1)
            {
                dtp_hasta.Enabled = true;
                dtp_hasta.Enabled=false;
                dtp_desde.Focus();
                grid_control_comprobantes.DataSource = null;
                gview_comprobantes.ClearColumnsFilter();
            }
        }

        private void dtp_desde_EditValueChanged(object sender,EventArgs e)
        {
            if(Convert.ToDateTime(dtp_hasta.EditValue).Date < Convert.ToDateTime(dtp_desde.EditValue).Date)
            {
                XtraMessageBox.Show("El valor de la fecha del fin de la busqueda no\n puede ser menor a la fecha inicio de la busqueda","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                dtp_hasta.Focus();
            }
            else
            {
               bbi_buscar_ItemClick(null,null);
            }
        }

        private void dtp_hasta_EditValueChanged(object sender,EventArgs e)
        {

            if(Convert.ToDateTime(dtp_hasta.EditValue).Date < Convert.ToDateTime(dtp_desde.EditValue).Date)
            {
                XtraMessageBox.Show("El valor de la fecha final de la busqueda no\n puede ser menor a la fecha inicio de la busqueda","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                dtp_hasta.Focus();
            }
            else
            {
                bbi_buscar_ItemClick(null,null);
            }
        }
        private void blb_editar_asiento_ItemClick(object sender,DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
               
                xfrm_NuevoAsientoContable ModificaAsientoContable= new xfrm_NuevoAsientoContable();
                ModificaAsientoContable.Text="MODIFICAR ASIENTO CONTABLE";
                ModificaAsientoContable.blb_Guardar.Caption="GUARDAR MODIFICACIÓN";
                ModificaAsientoContable.blb_Guardar_Imprimir.Caption="GUARDAR E IMPRIMIR MODIFICACION";
                ModificaAsientoContable.MdiParent=this.MdiParent;
                IComprobantes icomprobates=ModificaAsientoContable as IComprobantes;
                if(icomprobates!=null)
                {
                    icomprobates.isNuevo=false;
                    icomprobates.id_asiento=Convert.ToInt32(gview_comprobantes.GetFocusedRowCellValue
                    (col_id_comprobante));
                    bool existe_asiento=icomprobates.Comprobante_Diario(Negocio.ClasesCN.ContabilidadCN.Comprobante_Diarios_Select(Convert.ToInt32(gview_comprobantes.GetFocusedRowCellValue
                    (col_id_comprobante))));
                    icomprobates.Obtener_ComprobanteDetalle(Negocio.ClasesCN.ContabilidadCN.ComprobanteDiarioDetalles_Select(Convert.ToInt32(gview_comprobantes.GetFocusedRowCellValue
                        (col_id_comprobante))));
                    if(!existe_asiento) return;
                    ModificaAsientoContable.Show();
                    menu.HidePopup();
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show($"Lo sentimos ha ocurrido el siguiente error.{Environment.NewLine}Error:{ex.Message}.","Mensaje del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void grid_control_comprobantes_Click(object sender,EventArgs e)
        {

        }

        private void gview_comprobantes_MouseUp(object sender,MouseEventArgs e)
        {
            if(e.Button != MouseButtons.Right)
                return;
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hitInfo = gview_comprobantes.CalcHitInfo(e.Location);
            if(hitInfo.InDataRow)
            {
                menu.ShowPopup(Control.MousePosition);
            }
        }

        private void Look_tipo_comprobante_EditValueChanged(object sender,EventArgs e)
        {
            bbi_buscar_ItemClick(null,null);
        }

        private void gview_comprobantes_RowStyle(object sender,RowStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if(e.RowHandle >= 0)
            {
                decimal vdebe = Convert.ToDecimal(View.GetRowCellValue(e.RowHandle, View.Columns["debe"]));
                decimal vhaber = Convert.ToDecimal(View.GetRowCellValue(e.RowHandle, View.Columns["haber"]));
                int sucursal = Convert.ToInt32(View.GetRowCellValue(e.RowHandle, View.Columns["sucursal"]));
                int estado = Convert.ToInt32(View.GetRowCellValue(e.RowHandle,col_Estado));
                if(vdebe != vhaber)
                {
                    e.Appearance.ForeColor = Color.Red;
                    e.Appearance.Font = new Font("Tahoma",9.75F,FontStyle.Regular,GraphicsUnit.Point,((byte) (0)));
                }
            }
        }
        private void Motivo_Showing(object sender,XtraMessageShowingArgs e)
        {
            e.Form.Icon = this.Icon;

        }
        private void blb_AnularAsiento_ItemClick(object sender,DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                menu.HidePopup();
                MyMessageBox.MessageFont = new Font(Clases.MyMessageBox.MessageFont.FontFamily,24);
                int id_comprobante=Convert.ToInt32(gview_comprobantes.GetFocusedRowCellValue
                    (col_id_comprobante));
                XtraInputBoxArgs Motivo = new XtraInputBoxArgs();
                Motivo.Caption = "MOTIVO ANULACIÓN ASIENTO";
                Motivo.Prompt = "MOTIVO ANULACIÓN ASIENTO";
                Motivo.DefaultButtonIndex = 0;
                Motivo.Showing += Motivo_Showing;
                MemoEdit editor = new MemoEdit();
                editor.Properties.AllowNullInput=DevExpress.Utils.DefaultBoolean.False;
                editor.Properties.WordWrap=true;
                editor.Properties.CharacterCasing=CharacterCasing.Upper;
                Motivo.Editor = editor;
                if(Motivo!=null)
                {
                    var razon = XtraInputBox.Show(Motivo).ToString();
                    if(string.IsNullOrEmpty(razon))
                    {
                        XtraMessageBox.Show("Debe de colocar Motivo de Anulacion");
                        Motivo.Showing += Motivo_Showing;
                    }
                    DialogResult Preugnta=MyMessageBox.Show($"¿Esta Completamente Seguro de Anular el Asiento{Environment.NewLine}por el siguiente motivo {razon}?","Confirmación",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                    if(Preugnta==DialogResult.Yes)
                    {
                        int okGuardar=Negocio.ClasesCN.ContabilidadCN.ComprobanteDiario_Eliminar(id_comprobante,UsuarioLogueado.vID_Empleado,razon.ToUpper());
                        if(okGuardar>0)
                        {
                            MyMessageBox.Show("Asiento Anulado Exitosamente","Información",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        }
                        else
                        {
                            XtraMessageBox.Show(String.Format("No se ha podido, Anular el asiento"),"Mensaje del sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch(Exception )
            {
                //XtraMessageBox.Show($"Lo sentimos ha ocurrido el siguiente error.{Environment.NewLine}Error:{ex.Message}.","Mensaje del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void xfrm_buscarComprobantes_Activated(object sender,EventArgs e)
        {
            bbi_buscar_ItemClick(null,null);
        }

        private void bbi_expoortar_listado_ItemClick(object sender,DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void blb_Nuevo_Asiento_ItemClick(object sender,DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                xfrm_NuevoAsientoContable nuevoAsientoContable= new xfrm_NuevoAsientoContable();
                nuevoAsientoContable.MdiParent=this.MdiParent;
                IComprobantes icomprobates=nuevoAsientoContable as IComprobantes;
                if(icomprobates!=null)
                {
                    icomprobates.isNuevo=true;
                    nuevoAsientoContable.Show();
                    menu.HidePopup();
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show($"Lo sentimos ha ocurrido el siguiente error.{Environment.NewLine}Error:{ex.Message}.","Mensaje del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void blb_ImprimrAsiento_ItemClick(object sender,DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                binding_Reporte.DataSource=Negocio.ClasesCN.ContabilidadCN.ComprobanteDiario_Reporte(Convert.ToInt32(gview_comprobantes.GetFocusedRowCellValue
                    (col_id_comprobante)));
                var reporte = new Reportes.Contabilidad.ComprobanteDiario(binding_Reporte);
                menu.HidePopup();
                reporte.ShowPreview();
                reporte.Parameters[0].Visible=false;
                menu.HidePopup();
             //   reporte.Dispose();
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show($"Lo sentimos ha ocurrido el siguiente error.{Environment.NewLine}Error:{ex.Message}.","Mensaje del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void gview_comprobantes_FocusedRowChanged(object sender,DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {

            }
            catch(Exception ex)
            {
                XtraMessageBox.Show($"Lo sentimos ha ocurrido el siguiente error.{Environment.NewLine}Error:{ex.Message}.","Mensaje del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}