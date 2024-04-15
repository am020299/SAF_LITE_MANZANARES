using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using DevExpress.XtraEditors;
using Entidades;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using Presentacion.Clases;
using DevExpress.XtraReports.UI;

namespace Presentacion.Formularios.Contabilidad
{
    public partial class xfrm_NuevoAsientoContable:DevExpress.XtraEditors.XtraForm,IComprobantes
    {
        DataTable cuentasdt,detalle_comprobantes;
        bool agrupacion=false;
        string nombre_cuenta_=string.Empty;
        bool agrupacion_=false;
        string nombre_cuenta="";
        int correcto=0;
        DXErrorProvider  ErrorProvider= new DXErrorProvider();
        public xfrm_NuevoAsientoContable( )
        {
            InitializeComponent();
            detalle_comprobantes= new DataTable();
            detalle_comprobantes.Columns.Add("num_cuenta",typeof(string));
            detalle_comprobantes.Columns.Add("nom_cuenta",typeof(string));
            detalle_comprobantes.Columns.Add("debe",typeof(decimal));
            detalle_comprobantes.Columns.Add("haber",typeof(decimal));
        }
        public bool isNuevo{ get; set;}
        public int id_asiento { get; set; }
        public void Obtener_ComprobanteDetalle(DataTable DetalleComprobante)
        {
            grid_asiento.DataSource=DetalleComprobante;
        }
        public bool Comprobante_Diario(ComprobanteDiario Comprobante)
        {
            if(Comprobante!=null)
            {
                txtConcepto.Text=Comprobante.descripcion.ToUpper();
                dtFecha_Asiento.DateTime=Comprobante.fecha_asiento.Value.Date;
                lookTipo_Asiento.EditValue=Comprobante.tipo_comprobante;
               
                return true;
            }
            else
                return false;
        }
        private void Cargar_cuentas( )
        {
            cuentasdt= new DataTable();
            cuentasdt.Columns.Add("cta",typeof(string));
            cuentasdt.Columns.Add("nombre_cuenta",typeof(string));
            cuentasdt.Columns.Add("agrupacion",typeof(bool));
            var Cuentas= Negocio.ClasesCN.ContabilidadCN.Cuentas_Select();
            foreach(var C in Cuentas)
            {
                DataRow fila = cuentasdt.NewRow();
                fila[0]=C.numero_cuenta??"";
                fila[1]=C.nombre_cuenta.ToUpper()??"";
                fila[2]=C.agrupacion??1;
                cuentasdt.Rows.Add(fila);
            }
            lookCuenta.Properties.DataSource=cuentasdt;
            rp_cta.DataSource=cuentasdt;
        }
        private bool EsNumero(string tex)
        {
            try
            {
                if(string.IsNullOrEmpty(tex.Trim()))
                    return false;
                else
                {
                    Decimal.Parse(tex.Trim());
                    return true;
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(string.Format("Lo sentimos, ha ocurrido un error {0}",ex.Message.ToString()),"Mensaje del sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }
        }
        private void Cargar_Tipo_Comprobantes(int tipo)
        {
            switch(tipo)
            {
                case 1:
                    lookTipo_Asiento.Properties.DataSource=Negocio.ClasesCN.ContabilidadCN.Tipo_Comprobantes_Select().Where(A => A.automatico==false && A.estado==1).ToList();
                    break;
                case 2:
                    lookTipo_Asiento.Properties.DataSource=Negocio.ClasesCN.ContabilidadCN.Tipo_Comprobantes_Select().Where(A => A.estado==1).ToList();
                    break;
            }
          
        }
        private void xfrm_NuevoAsientoContable_Load(object sender,EventArgs e)
        {
            try
            {
                if(isNuevo)
                {
                    Cargar_cuentas();
                    Cargar_Tipo_Comprobantes(1);
                    dtFecha_Asiento.DateTime=DateTime.Now.Date;
                    txtDebe1.EditValue=0.00m;
                    txtHaber.EditValue=0.00m;

                }
                else
                {
                    Cargar_cuentas();
                    Cargar_Tipo_Comprobantes(2);
                    lookTipo_Asiento.ReadOnly=!isNuevo;
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show($"Error:{ex.Message}","Mensaje del sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void lookCuenta_EditValueChanged(object sender,EventArgs e)
        {
            if(lookCuenta.EditValue!=null)
            {
                var FILA=lookCuenta.GetSelectedDataRow() as DataRowView;
                agrupacion =Convert.ToBoolean(FILA.Row.ItemArray[2]);
                nombre_cuenta_=FILA.Row.ItemArray[1].ToString();
            }
        }
        private void txtDebe_EditValueChanged(object sender,EventArgs e)
        {
            try
            {
                if(Convert.ToDecimal(txtDebe1.EditValue??0)<0  && txtDebe1.ContainsFocus)
                {
                    ErrorProvider.SetError(txtDebe1,$"Valor no puede ser  Negativo");
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show($"Error:{ex.Message}","Mensaje del sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void txtHaber_EditValueChanged(object sender,EventArgs e)
        {
            try
            {
                if(Convert.ToDecimal(txtHaber.EditValue??0)<0 && txtHaber.ContainsFocus)
                {
                    ErrorProvider.SetError(txtHaber,$"Valor no puede ser  Negativo");
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show($"Error:{ex.Message}","Mensaje del sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private bool Validar_Fila()
        {
            ErrorProvider.ClearErrors();
            if(lookCuenta.EditValue==null)
            {
                ErrorProvider.SetError(lookCuenta,$"Debe de Seleccionar una Cuenta Contable");
                return false;
            }
            else if(Convert.ToDecimal(txtDebe1.EditValue??0)<0)
            {
                ErrorProvider.SetError(txtDebe1,$"Valor no puede ser  Negativo");
                return false;
            }
            else if(Convert.ToDecimal(txtHaber.EditValue??0)<0)
            {
                ErrorProvider.SetError(txtHaber,$"Valor no puede ser  Negativo");
                return false;
            }
            else if(Convert.ToDecimal(txtHaber.EditValue??0)>0 && Convert.ToDecimal(txtDebe1.EditValue??0)>0)
            {
                ErrorProvider.SetError(txtHaber,$"Sólo se puede hacer un movimiento a la vez o DEBE O HABER");
                ErrorProvider.SetError(txtDebe1,$"Sólo se puede hacer un movimiento a la vez o DEBE O HABER");
                return false;
            }
            else if(Convert.ToDecimal(txtHaber.EditValue??0)==0 && Convert.ToDecimal(txtDebe1.EditValue??0)==0)
            {
                ErrorProvider.SetError(txtHaber,$"Debe de hacer un movimiento  DEBE O HABER");
                ErrorProvider.SetError(txtDebe1,$"Debe de hacer un movimiento  DEBE O HABER");
                return false;
            }
            else
                return true;
        }
        private bool Validar_guardar( )
        {
            try
            {
                DateTime fecha=dtFecha_Asiento.DateTime.Date;
                ErrorProvider.ClearErrors();
                bool resultado=false;
                decimal totaldebe = Convert.ToDecimal(gview_asiento.Columns[3].SummaryItem.SummaryValue);
                decimal totalhaber = Convert.ToDecimal(gview_asiento.Columns[4].SummaryItem.SummaryValue);
                if(lookTipo_Asiento.EditValue==null || lookTipo_Asiento.Text.Length<=0)
                {
                    ErrorProvider.SetError(lookTipo_Asiento,"Debe de seleccionar un tipo de asiento a realizar");
                    lookTipo_Asiento.Focus();
                    return resultado;
                }
                else if(dtFecha_Asiento.Text.Length<=0 || dtFecha_Asiento.EditValue==null)
                {
                    ErrorProvider.SetError(dtFecha_Asiento,"Debe de seleccionar para el asiento contable");
                    dtFecha_Asiento.Focus();
                    return resultado;
                }
                else if(txtConcepto.Text.Trim().Length<=0 || string.IsNullOrEmpty(txtConcepto.Text))
                {
                    ErrorProvider.SetError(txtConcepto,"Debe de indicar concepto para el asiento contable");
                    txtConcepto.Focus();
                    return resultado;
                }
                else if(totaldebe!=totalhaber)
                {
                    XtraMessageBox.Show("Asiento contable se encuentra descuadrado, por favor verifique los datos","Mensaje del sistema",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return resultado;
                }
                else if(gview_asiento.RowCount<=0)
                {
                    XtraMessageBox.Show("Asiento contable no posee detalles, por favor verifique los datos e intente nuevamente","Mensaje del sistema",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return resultado;
                }
                else
                {
                    return true;
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(string.Format("Lo sentimos, ha ocurrido un error al momento de validar campos {0}",ex.Message.ToString()),"Mensaje del sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }
        }
        private void btn_agregar_detalle_Click(object sender,EventArgs e)
        {
            try
            {
                if(Validar_Fila())
                {
                    string vNumCuenta=lookCuenta.EditValue.ToString();
                    decimal vdebe=Convert.ToDecimal(string.IsNullOrEmpty(txtDebe1.Text)==true?"0.00":txtDebe1.Text.Trim());
                    decimal vHaber=Convert.ToDecimal(string.IsNullOrEmpty(txtHaber.Text)==true?"0.00":txtHaber.Text.Trim());
                    DataRow FILA=detalle_comprobantes.NewRow();
                    FILA[0]=vNumCuenta;
                    FILA[1]=nombre_cuenta_;
                    FILA[2]=vdebe;
                    FILA[3]=vHaber;
                    if(isNuevo)
                    {
                        detalle_comprobantes.Rows.Add(FILA);
                        grid_asiento.DataSource=detalle_comprobantes;
                    }
                    else
                    {
                        int InseertOk=Negocio.ClasesCN.ContabilidadCN.comprobanteDiarioDetalle_Insertar
                                    (vNumCuenta,id_asiento,vdebe,vHaber);
                        if(InseertOk>0)
                        {
                            grid_asiento.DataSource=Negocio.ClasesCN.ContabilidadCN.ComprobanteDiarioDetalles_Select(Convert.ToInt32(id_asiento));
                        }
                        else
                        {
                            XtraMessageBox.Show("Lo sentimos no se ha podido actualizar el detalle del asiento","Mensaje del sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        }
                    }
                    lookCuenta.EditValue=null;
                    txtDebe1.EditValue=0.00m;
                    txtHaber.EditValue=0.00m;
                    lookCuenta.Focus();
                    ////XtraMessageBox.Show("Fila Correcta");
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show($"Error:{ex.Message}","Mensaje del sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void lookCuenta_Leave(object sender,EventArgs e)
        {
            try
            {
                if(agrupacion)
                {
                    XtraMessageBox.Show(string.Format("La cuenta {0} no permite movimientos por que es una cuenta de agrupacion",nombre_cuenta_),"Mensaje del sistema",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    lookCuenta.EditValue=null;
                    txtDebe1.EditValue=0.00m;
                    txtHaber.EditValue=0.00m;
                    lookCuenta.Focus();
                    agrupacion=false;
                    nombre_cuenta_=string.Empty;
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(string.Format("Lo sentimos, ha ocurrido un error {0}",ex.Message.ToString()),"Mensaje del sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }    
        private void rp_cta_EditValueChanged(object sender,EventArgs e)
        {
            try
            {
                LookUpEdit Editor = sender as LookUpEdit;
                var fila=rp_cta.GetDataSourceRowByKeyValue(Editor.EditValue) as DataRowView;
                agrupacion_=Convert.ToBoolean(fila.Row.ItemArray[2]);
                nombre_cuenta=fila.Row.ItemArray[1].ToString();
                {
                    decimal? v_temp_debe=Convert.ToDecimal(gview_asiento.GetFocusedRowCellValue(col_debe));
                    decimal? v_temo_haber=Convert.ToDecimal(gview_asiento.GetFocusedRowCellValue(col_haber));
                    gview_asiento.SetFocusedRowCellValue("nom_cuenta",nombre_cuenta);
                    gview_asiento.SetFocusedRowCellValue("debe",v_temp_debe==null ? 0.00m : v_temp_debe);
                    gview_asiento.SetFocusedRowCellValue("haber",v_temo_haber==null ? 0.00m : v_temo_haber);
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(string.Format("Lo sentimos a ocurrido un error al momento de obtener nombre de la cuenta {0}",ex.Message.ToString()),"Mensaje de sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void Borrar_filas(DevExpress.XtraGrid.Views.Grid.GridView view,int id_detalle =0)
        {

            if(view == null || view.SelectedRowsCount == 0) return;

            DataRow[] rows = new DataRow[view.SelectedRowsCount];

            for(int i = 0;i < view.SelectedRowsCount;i++)

                rows[i] = view.GetDataRow(view.GetSelectedRows()[i]);

            view.BeginSort();

            try
            {
                if(id_detalle==0 && isNuevo)
                {
                    foreach(DataRow row in rows)
                        row.Delete();
                }
                else if (id_detalle!=0 && !isNuevo)
                {
                    int resultado= Negocio.ClasesCN.ContabilidadCN.ComprobanteDiarioDetalle_Actualizar(id_detalle);
                    if(resultado>0)
                    {
                        grid_asiento.DataSource=Negocio.ClasesCN.ContabilidadCN.ComprobanteDiarioDetalles_Select(Convert.ToInt32(id_asiento));
                    }
                    else
                    {
                        XtraMessageBox.Show($"Lo sentimos no se pudo borrar la fila seleccionada","Mesnaje del sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                }
            }

            finally
            {
                view.EndSort();
            }

        }
        private void gview_asiento_RowUpdated(object sender,DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            try
            {
                if(!agrupacion_)
                {
                    if(!isNuevo)
                    {
                        if(gview_asiento.GetFocusedRowCellValue(col_id_detalle)!=null)
                        {
                            int id_detalle=Convert.ToInt32(gview_asiento.GetFocusedRowCellValue(col_id_detalle));
                            if(Negocio.ClasesCN.ContabilidadCN.ComprobanteDiarioDetalle_Actualizar(id_detalle)>0)
                            {
                                string vNumCuenta=gview_asiento.GetFocusedRowCellValue(col_cta).ToString();
                                decimal vdebe=Convert.ToDecimal(gview_asiento.GetFocusedRowCellValue(col_debe));
                                decimal vHaber=Convert.ToDecimal(gview_asiento.GetFocusedRowCellValue(col_haber));
                                int InseertOk=Negocio.ClasesCN.ContabilidadCN.comprobanteDiarioDetalle_Insertar
                                    (vNumCuenta,id_asiento,vdebe,vHaber);
                                if(InseertOk>0)
                                {
                                    grid_asiento.DataSource=Negocio.ClasesCN.ContabilidadCN.ComprobanteDiarioDetalles_Select(Convert.ToInt32(id_asiento));
                                }
                                else
                                {
                                    XtraMessageBox.Show("Lo sentimos no se ha podido actualizar el detalle del asiento","Mensaje del sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
                                }
                            }
                        }
                        else
                        {
                            string vNumCuenta=gview_asiento.GetFocusedRowCellValue(col_cta).ToString();
                            decimal vdebe=Convert.ToDecimal(gview_asiento.GetFocusedRowCellValue(col_debe));
                            decimal vHaber=Convert.ToDecimal(gview_asiento.GetFocusedRowCellValue(col_haber));
                            DataRow FILA=detalle_comprobantes.NewRow();
                            FILA[0]=vNumCuenta;
                            FILA[1]=nombre_cuenta_;
                            FILA[2]=vdebe;
                            FILA[3]=vHaber;
                            detalle_comprobantes.Rows.Add(FILA);
                            grid_asiento.DataSource=detalle_comprobantes;

                        }
                    }
                  
                }
                else
                {
                    XtraMessageBox.Show(string.Format("La cuenta {0} no permite movimientos por que es una cuenta de agrupacion",nombre_cuenta),"Mensaje del sistema",MessageBoxButtons.OK,MessageBoxIcon.Warning);

                   // Borrar_filas(gview_asiento,Convert.ToInt32(gview_asiento.GetFocusedRowCellValue(col_id_detalle)??0));
                    grid_asiento.DataSource=Negocio.ClasesCN.ContabilidadCN.ComprobanteDiarioDetalles_Select(Convert.ToInt32(id_asiento));
                    agrupacion_=false;
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(string.Format("Lo sentimos, ha ocurrido un error {0}",ex.Message.ToString()),"Mensaje del sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
       private void gview_asiento_KeyDown(object sender,KeyEventArgs e)
        {
            try
            {
                if(e.KeyCode == Keys.Delete)
                {
                    if(gview_asiento.RowCount != 0)
                    {
                        if(XtraMessageBox.Show("¿Desea eliminar este registro?","Desea eliminar",MessageBoxButtons.YesNo,MessageBoxIcon.Question) != DialogResult.Yes) return;
                        Borrar_filas(gview_asiento,Convert.ToInt32(gview_asiento.GetFocusedRowCellValue(col_id_detalle)));

                    }
                }
            }
            catch(Exception)
            {
                XtraMessageBox.Show("Error al eliminar fila","Error",MessageBoxButtons.YesNo,MessageBoxIcon.Error);
            }
        }
        private void gview_asiento_ValidatingEditor(object sender,DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            switch(gview_asiento.FocusedColumn.FieldName)
            {
                case "num_cuenta":
                    if(!this.EsNumero(e.Value.ToString()))
                    {
                        e.Valid = false;
                    }
                    else
                    {
                        if(Convert.ToDecimal(e.Value) < 0)
                        {
                            e.Valid = false;
                        }
                    }
                    break;

                case "debe":
                    if(!this.EsNumero(e.Value.ToString()))
                    {
                        e.Valid = false;
                    }
                    else
                    {
                        if(Convert.ToDecimal(e.Value) < 0)
                        {
                            e.Valid = false;
                        }
                    }
                    break;
                case "haber":
                    if(!this.EsNumero(e.Value.ToString()))
                    {
                        e.Valid = false;
                    }
                    else
                    {
                        if(Convert.ToDecimal(e.Value) < 0)
                        {
                            e.Valid = false;
                        }
                    }
                    break;
            }
        }
        private void gview_asiento_ValidateRow(object sender,DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {

                GridView vista= sender as GridView;
                vista.ClearColumnErrors();
                GridColumn debe= vista.Columns["debe"];
                GridColumn haber= vista.Columns["haber"];
                GridColumn Cuenta=vista.Columns["num_cuenta"];

                string debe_ =vista.GetRowCellValue(e.RowHandle,debe).ToString();
                string haber_ = vista.GetRowCellValue(e.RowHandle,haber).ToString();
                string cuenta_= vista.GetRowCellValue(e.RowHandle,Cuenta).ToString();

                if(string.IsNullOrEmpty(cuenta_))
                {
                    e.Valid=false;
                    vista.SetColumnError(Cuenta,string.Format("Debe de colocar un número de cuenta"));

                    vista.FocusedColumn=Cuenta;
                    vista.FocusedRowHandle=e.RowHandle;
                    vista.ShowEditor();
                }
                if(debe_==string.Empty || haber_==string.Empty)
                {
                    e.Valid=false;
                    vista.SetColumnError(string.IsNullOrEmpty(haber_)==true ? debe : haber,string.Format("Debe de colocar valor"));
                    vista.FocusedColumn=string.IsNullOrEmpty(haber_)==true ? debe : haber;
                    vista.FocusedRowHandle=e.RowHandle;
                    vista.ShowEditor();
                }
                else if(Convert.ToDecimal(debe_)==0 && Convert.ToDecimal(haber_)==0)
                {
                    e.Valid=false;
                    vista.SetColumnError(haber,string.Format("Coloque un valor mayor que 0 "));
                    vista.SetColumnError(debe,string.Format("Coloque un valor mayor que 0"));
                    vista.FocusedColumn=haber;
                    vista.FocusedColumn=debe;
                    vista.FocusedRowHandle=e.RowHandle;
                    vista.ShowEditor();
                }
                else if(Convert.ToDecimal(debe_)>0 && Convert.ToDecimal(haber_)>0)
                {
                    e.Valid=false;
                    vista.SetColumnError(haber,string.Format("Solo debe de colocar un movimiento DEBE o HABER"));
                    vista.SetColumnError(debe,string.Format("Solo debe de colocar un movimiento DEBE o HABER"));
                    vista.FocusedColumn=haber;
                    vista.FocusedColumn=debe;
                    vista.FocusedRowHandle=e.RowHandle;
                    vista.ShowEditor();
                }

            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(string.Format("Lo sentimos, ha ocurrido un error {0}",ex.Message.ToString()),"Mensaje del sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void gview_asiento_InvalidValueException(object sender,DevExpress.XtraEditors.Controls.InvalidValueExceptionEventArgs e)
        {
            switch(gview_asiento.FocusedColumn.FieldName)
            {
                case "num_cuenta":
                    e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
                    e.WindowCaption = "Debe de colocar numero de cuenta";
                    e.ErrorText = "El valor debe no debe de ser vacio";
                    break;

                case "debe":
                    e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
                    e.WindowCaption = "Debe de colocar un valor y debe de ser no negativo";
                    e.ErrorText = "El valor no puede ser vacio ni negativo";
                    break;
                case "haber":
                    e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
                    e.WindowCaption = "Debe de colocar un valor y debe de ser no negativo";
                    e.ErrorText = "El valor no puede ser negativo ni vacio";
                    break;
            }

        }
        private void gview_asiento_InvalidRowException(object sender,DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode=DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }
        private void gview_asiento_CustomSummaryCalculate(object sender,DevExpress.Data.CustomSummaryEventArgs e)
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
                XtraMessageBox.Show(string.Format("Lo sentimos, ha ocurrido un error {0}",ex.Message.ToString()),"Mensaje del sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void Guardar( )
        {
            if(isNuevo)
            {

                DialogResult Pregunta=MyMessageBox.Show($"¿Esta completamente seguro de guardar el asiento contable {lookTipo_Asiento.Text} con fecha {dtFecha_Asiento.DateTime.Date.ToShortDateString()}?","Información",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if(Pregunta==DialogResult.Yes)
                {
                    DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(typeof(Formularios.Principal.WaitForm1));
                     correcto=Negocio.ClasesCN.ContabilidadCN.ComprobanteDiario_Insert(txtConcepto.EditValue.ToString().ToUpper(),Convert.ToInt32( lookTipo_Asiento.EditValue),UsuarioLogueado.vID_Empleado,dtFecha_Asiento.DateTime.Date,gview_asiento);
                    if(correcto>0)
                    {
                        DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm();
                        MyMessageBox.Show($"Se ha agregado el Asiento Contable Tipo {lookTipo_Asiento.Text.ToString()}, a la fecha {dtFecha_Asiento.DateTime.ToShortDateString().ToString()}","Mensaje del sistema",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        isNuevo=true;
                        Limpiar_Campos();
                    }
                    else
                    { DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(); }
                }
            }
            else if(!isNuevo)
            {

                if(Negocio.ClasesCN.ContabilidadCN.ComprobanteDiario_Actualizar(id_asiento,UsuarioLogueado.vID_Empleado,txtConcepto.Text.Trim())>0)
                {
                    MyMessageBox.Show($"Actualizado Sastifactoriamente","Mensaje del sistema",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }

            }
        }
        private void blb_Guardar_ItemClick(object sender,DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                MyMessageBox.MessageFont = new Font(Clases.MyMessageBox.MessageFont.FontFamily,24);
                if(Validar_guardar())
                {
                    if(isNuevo)
                    {

                        DialogResult Pregunta=MyMessageBox.Show($"¿Esta completamente seguro de guardar el asiento contable {lookTipo_Asiento.Text} con fecha {dtFecha_Asiento.DateTime.Date.ToShortDateString()}?","Información",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                        if(Pregunta==DialogResult.Yes)
                        {
                            DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(typeof(Formularios.Principal.WaitForm1));
                            correcto=Negocio.ClasesCN.ContabilidadCN.ComprobanteDiario_Insert(txtConcepto.EditValue.ToString().ToUpper(),Convert.ToInt32( lookTipo_Asiento.EditValue),UsuarioLogueado.vID_Empleado,dtFecha_Asiento.DateTime.Date,gview_asiento);
                            if(correcto>0)
                            {
                                DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm();
                                MyMessageBox.Show($"Se ha agregado el Asiento Contable Tipo {lookTipo_Asiento.Text.ToString()}, a la fecha {dtFecha_Asiento.DateTime.ToShortDateString().ToString()}","Mensaje del sistema",MessageBoxButtons.OK,MessageBoxIcon.Information);
                                isNuevo=true;
                                Limpiar_Campos();
                            }
                            else
                            { DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(); }
                        }
                    }
                    else if(!isNuevo)
                    {

                        if(Negocio.ClasesCN.ContabilidadCN.ComprobanteDiario_Actualizar(id_asiento,UsuarioLogueado.vID_Empleado,txtConcepto.Text.Trim())>0)
                        {
                            MyMessageBox.Show($"Actualizado Sastifactoriamente","Mensaje del sistema",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        }

                    }
                }
            }
            catch( Exception ex)
            {
                XtraMessageBox.Show($"Lo sentimos ha ocurrido un error{Environment.NewLine}Error:{ex.Message}","Mensaje del sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
                DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm();
            }
        }
        private void Limpiar_Campos( )
        {
            try
            {
                lookTipo_Asiento.EditValue=null;
                dtFecha_Asiento.DateTime=DateTime.Now.Date;
                txtConcepto.EditValue=string.Empty;
                lookCuenta.EditValue=null;
                txtDebe1.EditValue=0;
                txtHaber.EditValue=0;
                cuentasdt.Clear();
                grid_asiento.DataSource=null;

            }
            catch( Exception ex)
            {
                XtraMessageBox.Show($"Lo sentimos ha ocurrido un error{Environment.NewLine}Error:{ex.Message}","Mensaje del sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void imprimir( )
        {
            binding_Reporte.DataSource=Negocio.ClasesCN.ContabilidadCN.ComprobanteDiario_Reporte(Convert.ToInt32(correcto));
            var reporte = new Reportes.Contabilidad.ComprobanteDiario(binding_Reporte);
            reporte.ShowPreview();
            reporte.Parameters[0].Visible=false;
        }
        private void blb_Guardar_Imprimir_ItemClick(object sender,DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                blb_Guardar_ItemClick(null,null);
                if (correcto>0)
                imprimir();

            }
            catch(Exception ex)
            {
                XtraMessageBox.Show($"Lo sentimos ha ocurrido un error{Environment.NewLine}Error:{ex.Message}","Mensaje del sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void xfrm_NuevoAsientoContable_FormClosing(object sender,FormClosingEventArgs e)
        {
            try
            {
                MyMessageBox.MessageFont = new Font(Clases.MyMessageBox.MessageFont.FontFamily,22);
                decimal totaldebe = Convert.ToDecimal(gview_asiento.Columns[3].SummaryItem.SummaryValue);
                decimal totalhaber = Convert.ToDecimal(gview_asiento.Columns[4].SummaryItem.SummaryValue);
                if(gview_asiento.RowCount>0)
                {
                    if(isNuevo)
                    {
                        DialogResult preg = MyMessageBox.Show($"Hay Registros pendientes de guardar en esta Ventana {Environment.NewLine}¿Desea Guardarlos?", "Información", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                        if(preg == DialogResult.Yes)
                        {

                            if(Validar_guardar())
                            {
                                Guardar();
                            }
                            else
                            {
                                e.Cancel=true;
                            }
                        }
                        else if(preg==DialogResult.No)
                        {
                            e.Cancel=false;
                        }
                        else if(preg==DialogResult.Cancel)
                        {
                            e.Cancel=true;
                        }

                    }
                   else
                    {
                        if(Validar_guardar())
                        {
                            Negocio.ClasesCN.ContabilidadCN.ComprobanteDiario_Actualizar(id_asiento,UsuarioLogueado.vID_Empleado,txtConcepto.Text.Trim());
                        }
                        else
                        {
                            e.Cancel=true;
                        }
                    }
                }
     
                
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show($"Lo sentimos ha ocurrido un error{Environment.NewLine}Error:{ex.Message}","Mensaje del sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void blb_Limpiar_ItemClick(object sender,DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DialogResult preg = XtraMessageBox.Show("¿Desea cancelar Operación?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(preg == DialogResult.Yes)
                {
                    isNuevo=false;
                    this.Close();

                }
            }
            catch(Exception)
            {

                throw;
            }
        }
    }
}