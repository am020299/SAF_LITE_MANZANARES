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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;

namespace Presentacion.Formularios.CuentasCobrar
{
    public partial class xfrm_CuentasCobrar:DevExpress.XtraEditors.XtraForm
    {
        public xfrm_CuentasCobrar( )
        {
            InitializeComponent();
        }
        decimal saldo_vencido=0.0m,pendiente=0.00m,cancelado=0.00m;

        private void Cargar_CuentasCobrarSelect( )
        {
            try
            {
                binding_cuentasCobrar.DataSource=Negocio.ClasesCN.CuentasCobrarCN.CuentasCobrarMaestro_Select().Where(x => x.moneda == 1).ToList();
                grid_personas.DataSource=binding_cuentasCobrar;
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show($"Lo sentimos ha ocurrido el siguiente error.{Environment.NewLine}Error:{ex.Message}.","Mensaje del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void xfrm_CuentasCobrar_Load(object sender,EventArgs e)
        {
            try
            {
                Cargar_CuentasCobrarSelect();
                cbb_tipo_saldo.EditValue="TODOS";
              
            }
            catch(Exception)
            {
                throw;
            }
        }

        private void gview_detalles_cliente_CustomSummaryCalculate(object sender,DevExpress.Data.CustomSummaryEventArgs e)
        {
            GridView view = sender as GridView;
            int idsumatoria= Convert.ToInt32((e.Item as GridSummaryItem).Tag);

            if(e.SummaryProcess==DevExpress.Data.CustomSummaryProcess.Start)
            {
                saldo_vencido=0.0m;
                pendiente=0.00m;
                cancelado=0.00m;
            }

            if(e.SummaryProcess==DevExpress.Data.CustomSummaryProcess.Calculate)
            {
                bool sumarvencido=view.GetRowCellValue(e.RowHandle,col_estatus_detalles).ToString().ToLower().Trim()=="vencido".ToLower();
                bool sumarpendiente=view.GetRowCellValue(e.RowHandle,col_estatus_detalles).ToString().ToLower().Trim()=="pendiente".ToLower();
                bool sumarCancelado=view.GetRowCellValue(e.RowHandle,col_estatus_detalles).ToString().ToLower().Trim()=="cancelado".ToLower();
                switch(idsumatoria)
                {
                    case 1:
                        if(sumarvencido)
                        {
                            saldo_vencido+=(decimal) e.FieldValue;
                        }
                        break;
                    case 2:
                        if(sumarpendiente)
                        {
                            pendiente+=(decimal) e.FieldValue;
                        }
                        break;
                    case 3:
                        if(sumarCancelado)
                        {
                            cancelado+=(decimal) e.FieldValue;
                        }
                        break;

                    default:
                        break;
                }
            }

            if(e.SummaryProcess==DevExpress.Data.CustomSummaryProcess.Finalize)
            {
                switch(idsumatoria)
                {
                    case 1:
                       // e.TotalValueReady=true;
                        e.TotalValue=saldo_vencido;
                        break;
                    case 2:
                       // e.TotalValueReady=true;
                        e.TotalValue=pendiente;
                        break;
                    case 3:
                     //   e.TotalValueReady=true;
                        e.TotalValue=cancelado;
                        break;

                    default:
                        break;
                }
            }
        }

        private void gview_detalles_cliente_RowStyle(object sender,RowStyleEventArgs e)
        {
            try
            {
                GridView View = sender as GridView;
                if(e.RowHandle >= 0)
                {
                    string estatus = Convert.ToString(View.GetRowCellValue(e.RowHandle, View.Columns["estatus_documento"])).ToLower() ;
                    //decimal vhaber = Convert.ToDecimal(View.GetRowCellValue(e.RowHandle, View.Columns["haber"]));
                    //int sucursal = Convert.ToInt32(View.GetRowCellValue(e.RowHandle, View.Columns["sucursal"]));
                    //int estado = Convert.ToInt32(View.GetRowCellValue(e.RowHandle,col_Estado));
                    if(estatus =="vencido".ToLower())
                    {
                        e.Appearance.BackColor = Color.Pink;
                        e.Appearance.Font = new Font("Tahoma",9.75F,FontStyle.Regular,GraphicsUnit.Point,((byte) (0)));
                    }
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show($"Lo sentimos ha ocurrido el siguiente error.{Environment.NewLine}Error:{ex.Message}.","Mensaje del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void repositoryItemComboBox1_EditValueChanged(object sender,EventArgs e)
        {
            
        }

        private void cbb_tipo_saldo_EditValueChanged(object sender,EventArgs e)
        {
            try
            {

                if((string) cbb_tipo_saldo.EditValue=="TODOS")
                {
                    Cargar_CuentasCobrarSelect();
                }
                else if((string) cbb_tipo_saldo.EditValue=="CON SALDO VENCIDO")
                {
                    binding_cuentasCobrar.DataSource=Negocio.ClasesCN.CuentasCobrarCN.CuentasCobrarMaestro_Select().Where(C=>C.saldo_vencido>0).ToList();
                    grid_personas.DataSource=binding_cuentasCobrar;

                }
                else if((string) cbb_tipo_saldo.EditValue=="SIN SALDO VENCIDO")
                {
                    binding_cuentasCobrar.DataSource=Negocio.ClasesCN.CuentasCobrarCN.CuentasCobrarMaestro_Select().Where(C => C.saldo_vencido<=0).ToList();
                    grid_personas.DataSource=binding_cuentasCobrar;
                }


            }
            catch(Exception ex)
            {
                XtraMessageBox.Show($"Lo sentimos ha ocurrido el siguiente error.{Environment.NewLine}Error:{ex.Message}.","Mensaje del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            /// XtraMessageBox.Show(cbb_tipo_saldo.EditValue.ToString());
        }

        private void cbb_tipo_saldo_ItemClick(object sender,DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void gview_personas_MouseUp(object sender,MouseEventArgs e)
        {
            try
            {
                if(e.Button != MouseButtons.Right)
                    return;
                DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hitInfo = gview_personas.CalcHitInfo(e.Location);
                if(hitInfo.InDataRow)
                {
                    radialMenu.ShowPopup(Control.MousePosition);

                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show($"Lo sentimos ha ocurrido el siguiente error.{Environment.NewLine}Error:{ex.Message}.","Mensaje del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void bbi_nuevo_documento_ItemClick(object sender,DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                int id_cliente= Convert.ToInt32(gview_personas.GetRowCellValue(gview_personas.FocusedRowHandle,col_id_clientePersonas));
                 var form = new CuentasCobrar.xfrm_Agrega_Documento(id_cliente);
                form.search_clientes.ReadOnly=true;
                 form.Show();
     
            }
            catch(Exception ex)
            {

                throw;
            }
        }

        private void xfrm_CuentasCobrar_Activated(object sender,EventArgs e)
        {
            xfrm_CuentasCobrar_Load(null,null);
        }

        private void barButtonItem1_ItemClick(object sender,DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                radialMenu.ShowPopup(Control.MousePosition);
            }
            catch(Exception)
            {

                throw;
            }
        }

        private void bbi_ver_detalles_ItemClick(object sender,DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
        }

        private void xfrm_CuentasCobrar_KeyUp(object sender,KeyEventArgs e)
        {
            //Nuevo Documento 

        }

        private void bbi_aplicar_documento_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                int id_cliente = Convert.ToInt32(gview_personas.GetRowCellValue(gview_personas.FocusedRowHandle, col_id_clientePersonas));
                var form = new CuentasCobrar.xfrm_estado_cuenta(id_cliente, DateTime.Now.AddDays(-30).Date, DateTime.Now.Date);
                form.Show();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }

        private void gview_personas_FocusedRowChanged(object sender,DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                binding_Detalles.DataSource=null;
                dockPanel1.Text=$"DETALLES";
                if(gview_personas.RowCount>0)
                {
                    if(!gview_personas.IsFilterRow(gview_personas.FocusedRowHandle))
                    {
                        int id_cliente = Convert.ToInt32(gview_personas.GetFocusedRowCellValue(col_id_clientePersonas));
                        string nombre_cliente=gview_personas.GetFocusedRowCellValue(col_nombreCliente).ToString();
                        var Consulta=Negocio.ClasesCN.CuentasCobrarCN.CuentasCobrarDetalles_Todos(id_cliente).Where(x => x.moneda == 1).OrderByDescending(X=>X.estatus_documento).ThenByDescending(C=>C.fecha_vencimiento).ToList();
                        binding_Detalles.DataSource=Consulta;
                        grid_detalles.DataSource=binding_Detalles;
                        dockPanel1.Text=$"DETALLES DE {nombre_cliente.ToUpper()}";
                    }
                }

            }
            catch(Exception ex)
            {
                XtraMessageBox.Show($"Lo sentimos ha ocurrido el siguiente error.{Environment.NewLine}Error:{ex.Message}.","Mensaje del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }

        private void gview_personas_RowStyle(object sender,DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            try
            {
                GridView View = sender as GridView;
                if(e.RowHandle >= 0)
                {
                    decimal saldo_vencido = Convert.ToDecimal(View.GetRowCellValue(e.RowHandle, View.Columns["saldo_vencido"])) ;
                    if(saldo_vencido > 0)
                    {
                        e.Appearance.BackColor = Color.Pink;
                        e.Appearance.Font = new Font("Tahoma",9.75F,FontStyle.Regular,GraphicsUnit.Point,((byte) (0)));
                    }
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show($"Lo sentimos ha ocurrido el siguiente error.{Environment.NewLine}Error:{ex.Message}.","Mensaje del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }



    }
}