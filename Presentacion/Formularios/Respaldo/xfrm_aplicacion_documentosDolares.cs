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
using System.Diagnostics;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraReports.UI;

namespace Presentacion.Formularios.CuentasCobrar
{
    public partial class xfrm_aplicacion_documentosDolares : DevExpress.XtraEditors.XtraForm
    {
        public xfrm_aplicacion_documentosDolares()
        {
            InitializeComponent();
        }
        public xfrm_aplicacion_documentosDolares(int id_cliente, int id_doc)
        {
            InitializeComponent();
            this.id_cliente = id_cliente;
            this.id_doc_aplicar = id_doc;
        }
        decimal suma = 0.00m;
        int id_cliente = 0;
        int id_doc_aplicar = 0;
        DXErrorProvider Error = new DXErrorProvider();
        private bool EsNumero(string tex)
        {
            try
            {
                if (string.IsNullOrEmpty(tex.Trim()))
                    return false;
                else
                {
                    Decimal.Parse(tex.Trim());
                    return true;
                }
            }
            catch (Exception ex)
            {
                // XtraMessageBox.Show(string.Format("Lo sentimos, ha ocurrido un error {0}",ex.Message.ToString()),"Mensaje del sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }
        }
        private void xfrm_aplicacion_documentos_Load(object sender, EventArgs e)
        {
            var Clientes = Negocio.ClasesCN.CuentasCobrarCN.CargarCliente_Select().Where(x => x.moneda == 2).ToList();
            search_clientes.Properties.DataSource = Clientes;
            search_cobrador.Properties.DataSource = Negocio.ClasesCN.CatalogosCN.Empleado_Cargar().ToList();
            search_cobrador.EditValue = Clases.UsuarioLogueado.vID_Empleado;
            binding_documentos_cliente.DataSource = Negocio.ClasesCN.CuentasCobrarCN.TiposDocumentosCxc().Where(o => o.id_tipo_documento == 5 || o.id_tipo_documento == 4).ToList();
            var moneda = Negocio.ClasesCN.CatalogosCN.getMonedaCXC();
            bindingSourceMoneda.DataSource = moneda;
            lookUp_Moneda.EditValue = 0.ToString();
            if (this.id_cliente != 0 && this.id_doc_aplicar != 0)
            {
                search_clientes.EditValue = id_cliente;
                search_clientes_EditValueChanged(null, null);
                search_cancelar_con.EditValue = id_doc_aplicar;

                radio_distribucion.SelectedIndex = 2;
            }
        }

        private void search_clientes_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                txt_restante.EditValue = 0.00m;
                txt_saldo_doc.EditValue = 0.00m;
                var D = Negocio.ClasesCN.CuentasCobrarCN.DocumentosCuentasCobrar_Por_cliente(Convert.ToInt32(search_clientes.EditValue)).Where(x => x.moneda == 2)

                        .Select(
                        X => new
                        {
                            X.id_documento,
                            X.numero_documento,
                            X.nombre_documento,
                            X.id_cliente,
                            X.numero_doc,
                            moneda = X.moneda == 1 ? "CORDOBAS" : X.moneda == 2 ? "DOLARES" : "N/A",
                            X.fecha_doc,
                            X.subtotal_doc,
                            X.monto_descuento_doc,
                            X.monto_impuesto_doc,
                            X.retenciones,
                            X.monto_doc,
                            X.saldo,
                            X.concepto,
                            X.dias,
                            X.nombre,
                            X.codigo,
                            fecha_vencimiento = X.fecha_vencimiento.HasValue == false ? null : X.fecha_vencimiento,
                            X.estatus_documento,
                            estatus_letras = X.estatus_documento == 1 ? "VENCIDO" : X.estatus_documento == 2 ? "CANCELADO" : X.estatus_documento == 3 ? "PENDIENTE" : X.estatus_documento == 4 ? "APLICADO" : X.estatus_documento == 5 ? "NO APLICADO" : "N/A",
                            monto_pago = 0.00m
                        }
                        )
                        .ToList();

                if (search_clientes.EditValue != null)
                {

                    ///D.Where(F => F.numero_documento==2 || F.numero_documento==4 ||F.numero_documento==5).Where(S=>S.saldo>0).ToList();

                    search_cancelar_con.Properties.DataSource = binding_documentos_cliente;


                    DataTable dt_documentos_pendientes = new DataTable();
                    dt_documentos_pendientes.Clear();

                    dt_documentos_pendientes.Columns.Add("id_documento", typeof(int));
                    dt_documentos_pendientes.Columns.Add("numero_documento", typeof(int));
                    dt_documentos_pendientes.Columns.Add("nombre_documento", typeof(string));
                    dt_documentos_pendientes.Columns.Add("id_cliente", typeof(int));
                    dt_documentos_pendientes.Columns.Add("numero_doc", typeof(string));
                    dt_documentos_pendientes.Columns.Add("moneda", typeof(string));
                    dt_documentos_pendientes.Columns.Add("fecha_doc", typeof(DateTime));
                    dt_documentos_pendientes.Columns.Add("subtotal_doc", typeof(decimal));
                    dt_documentos_pendientes.Columns.Add("monto_descuento_doc", typeof(decimal));
                    dt_documentos_pendientes.Columns.Add("monto_impuesto_doc", typeof(decimal));
                    dt_documentos_pendientes.Columns.Add("retenciones", typeof(decimal));
                    dt_documentos_pendientes.Columns.Add("monto_doc", typeof(decimal));
                    dt_documentos_pendientes.Columns.Add("saldo", typeof(decimal));
                    dt_documentos_pendientes.Columns.Add("concepto", typeof(string));
                    dt_documentos_pendientes.Columns.Add("dias", typeof(int));
                    dt_documentos_pendientes.Columns.Add("nombre", typeof(string));
                    dt_documentos_pendientes.Columns.Add("codigo", typeof(string));
                    dt_documentos_pendientes.Columns.Add("fecha_vencimiento", typeof(string));
                    dt_documentos_pendientes.Columns.Add("estatus_documento", typeof(int));
                    dt_documentos_pendientes.Columns.Add("estatus_letras", typeof(string));
                    dt_documentos_pendientes.Columns.Add("monto_pago", typeof(decimal));
                    foreach (var d in D.Where(F => (F.numero_documento == 1 || F.numero_documento == 3 || F.numero_documento == 6) && F.estatus_documento != 2).OrderBy(C => C.fecha_doc).ToList())
                    {
                        DataRow fila = dt_documentos_pendientes.NewRow();
                        fila[0] = d.id_documento;
                        fila[1] = d.numero_documento;
                        fila[2] = d.nombre_documento;
                        fila[3] = d.id_cliente;
                        fila[4] = d.numero_doc;
                        fila[5] = d.moneda;
                        fila[6] = d.fecha_doc;
                        fila[7] = d.subtotal_doc;
                        fila[8] = d.monto_descuento_doc;
                        fila[9] = d.monto_impuesto_doc;
                        fila[10] = d.retenciones;
                        fila[11] = d.monto_doc;
                        fila[12] = d.saldo;
                        fila[13] = d.concepto;
                        fila[14] = d.dias;
                        fila[15] = d.nombre;
                        fila[16] = d.codigo;
                        fila[17] = d.fecha_vencimiento.HasValue ? d.fecha_vencimiento.Value.ToString("dd/MM/yyyy") : string.Empty;
                        fila[18] = d.estatus_documento;
                        fila[19] = d.estatus_letras;
                        fila[20] = d.monto_pago;
                        dt_documentos_pendientes.Rows.Add(fila);
                    }

                    // binding_para_cancelar.DataSource=D.Where(F => F.numero_documento==1 || F.numero_documento==3 ||F.numero_documento==6).OrderBy(C => C.fecha_vencimiento).ToList();
                    grid_docs_pendientes_cancelar.DataSource = dt_documentos_pendientes;
                    search_cancelar_con.Focus();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void Distribuir_Saldo()
        {
            try
            {
                gview_docs_pendientes_cancelar.MoveFirst();
                decimal saldo_abono = 0.00m;
                int[] Filas_Seleccionadas = gview_docs_pendientes_cancelar.GetSelectedRows();

                for (int i = 0; i < gview_docs_pendientes_cancelar.RowCount; i++)
                {
                    int rowHandle = gview_docs_pendientes_cancelar.GetVisibleRowHandle(i);
                    if (gview_docs_pendientes_cancelar.IsDataRow(rowHandle))
                    {
                        gview_docs_pendientes_cancelar.SetRowCellValue(rowHandle, "monto_pago", 0.00m);
                        saldo_abono = Convert.ToDecimal(txt_saldo_doc.EditValue ?? 0);
                    }
                }
                switch (radio_distribucion.SelectedIndex)
                {
                    case 0://Mas Antiguo se hace la division entre los seleccionados y se coloca del mas antiguo hacia adelante

                        //Stopwatch watch = Stopwatch.StartNew();
                        gview_docs_pendientes_cancelar.Columns["monto_pago"].OptionsColumn.AllowEdit = true;
                        if (Convert.ToDecimal(txt_saldo_doc.EditValue ?? 0.00M) > 0.00m && gview_docs_pendientes_cancelar.RowCount > 0)
                        {
                            if (check_permite_seleccionar.Checked)
                            {
                                foreach (int fila in Filas_Seleccionadas.Where(X => Convert.ToDecimal(X.ToString()) >= 0.00M))
                                {

                                    Decimal saldo_documento_pendiente = Convert.ToDecimal(gview_docs_pendientes_cancelar.GetRowCellValue(fila, "saldo"));
                                    if (saldo_documento_pendiente >= saldo_abono && saldo_abono > 0)
                                    {
                                        gview_docs_pendientes_cancelar.SetRowCellValue(fila, "monto_pago", saldo_abono);
                                        saldo_abono -= saldo_abono;
                                        txt_restante.EditValue = 0.00;

                                    }
                                    else if (saldo_abono > 0 && saldo_documento_pendiente > 0)
                                    {
                                        saldo_documento_pendiente = Convert.ToDecimal(gview_docs_pendientes_cancelar.GetRowCellValue(fila, "saldo"));
                                        decimal pago_efectvo = saldo_abono - saldo_documento_pendiente;

                                        gview_docs_pendientes_cancelar.SetRowCellValue(fila, col_pagoo, saldo_documento_pendiente);
                                        saldo_abono = pago_efectvo;
                                        // txt_restante.EditValue= Convert.ToDecimal(gview_docs_pendientes_cancelar.Columns["monto_pago"].SummaryItem.SummaryValue);
                                        txt_restante.EditValue = saldo_abono;
                                    }
                                    else
                                    {
                                        gview_docs_pendientes_cancelar.SetRowCellValue(fila, col_pagoo, 0.00);
                                    }
                                }
                            }
                            else
                            {

                                for (int i = 0; i < gview_docs_pendientes_cancelar.RowCount; i++)
                                {

                                    int fila = gview_docs_pendientes_cancelar.GetVisibleRowHandle(i);
                                    {
                                        Decimal saldo_documento_pendiente = Convert.ToDecimal(gview_docs_pendientes_cancelar.GetRowCellValue(fila, "saldo"));
                                        if (saldo_documento_pendiente >= saldo_abono && saldo_abono > 0)
                                        {
                                            gview_docs_pendientes_cancelar.SetRowCellValue(fila, "monto_pago", saldo_abono);
                                            saldo_abono -= saldo_abono;
                                            txt_restante.EditValue = saldo_abono;
                                        }
                                        else if (saldo_abono > 0 && saldo_documento_pendiente > 0)
                                        {
                                            saldo_documento_pendiente = Convert.ToDecimal(gview_docs_pendientes_cancelar.GetRowCellValue(fila, "saldo"));
                                            decimal pago_efectvo = saldo_abono - saldo_documento_pendiente;

                                            gview_docs_pendientes_cancelar.SetRowCellValue(fila, col_pagoo, saldo_documento_pendiente);
                                            saldo_abono = pago_efectvo;
                                            //  txt_restante.EditValue=Convert.ToDecimal(gview_docs_pendientes_cancelar.Columns["monto_pago"].SummaryItem.SummaryValue);
                                            txt_restante.EditValue = saldo_abono;
                                        }
                                        else
                                        {
                                            gview_docs_pendientes_cancelar.SetRowCellValue(fila, col_pagoo, 0.00);
                                        }
                                    }
                                }
                            }
                        }
                        gview_docs_pendientes_cancelar.Columns["monto_pago"].OptionsColumn.AllowEdit = false;
                        break;
                    case 1:  //Equitativo para los documentos seleccionado dividir el saldo entre la cantidad de seleccionados y asignar valores

                        if (Convert.ToDecimal(txt_saldo_doc.EditValue ?? 0) > 0.00m && gview_docs_pendientes_cancelar.RowCount > 0)
                        {
                            if (!check_permite_seleccionar.Checked)
                            {
                                decimal abono_cada_documento = 0.00m;
                                saldo_abono = Convert.ToDecimal(txt_saldo_doc.EditValue);
                                abono_cada_documento = saldo_abono / gview_docs_pendientes_cancelar.DataRowCount;
                                for (int i = 0; i < gview_docs_pendientes_cancelar.RowCount; i++)
                                {
                                    int fila = gview_docs_pendientes_cancelar.GetVisibleRowHandle(i);
                                    decimal monto_documento_total = Convert.ToDecimal(gview_docs_pendientes_cancelar.GetRowCellValue(fila, "saldo"));
                                    if (abono_cada_documento > monto_documento_total)
                                    {
                                        saldo_abono = saldo_abono - monto_documento_total;
                                        txt_restante.EditValue = saldo_abono;
                                        gview_docs_pendientes_cancelar.SetRowCellValue(fila, "monto_pago", monto_documento_total);
                                    }
                                    else
                                    {
                                        saldo_abono = saldo_abono - monto_documento_total;
                                        gview_docs_pendientes_cancelar.SetRowCellValue(fila, "monto_pago", abono_cada_documento);
                                        txt_restante.EditValue = saldo_abono < 0 ? 0 : saldo_abono;
                                    }

                                }
                            }
                            else
                            {
                                saldo_abono = (decimal)txt_saldo_doc.EditValue;
                                if (Filas_Seleccionadas.Where(X => Convert.ToDecimal(X.ToString()) >= 0).Count() > 0)
                                {
                                    decimal abono_cada_documento = saldo_abono / Filas_Seleccionadas.Where(X => Convert.ToDecimal(X.ToString()) >= 0).Count();
                                    foreach (int fila in Filas_Seleccionadas.Where(X => Convert.ToDecimal(X.ToString()) >= 0))
                                    {
                                        if (gview_docs_pendientes_cancelar.IsDataRow(fila))
                                        {
                                            decimal monto_documento_total = Convert.ToDecimal(gview_docs_pendientes_cancelar.GetRowCellValue(fila, "saldo"));
                                            if (abono_cada_documento > monto_documento_total)
                                            {
                                                saldo_abono = saldo_abono - monto_documento_total;
                                                txt_restante.EditValue = saldo_abono;
                                                gview_docs_pendientes_cancelar.SetRowCellValue(fila, "monto_pago", monto_documento_total);
                                            }
                                            else
                                            {
                                                saldo_abono = saldo_abono - monto_documento_total;
                                                gview_docs_pendientes_cancelar.SetRowCellValue(fila, "monto_pago", abono_cada_documento);
                                                txt_restante.EditValue = saldo_abono < 0 ? 0 : saldo_abono;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    case 2://Manual es asignado por el usuario
                        gview_docs_pendientes_cancelar.Columns["monto_pago"].OptionsColumn.AllowEdit = true;
                        break;
                }
                //search_cancelar_con.EditValueChanged += new System.EventHandler(this.search_cancelar_con_EditValueChanged);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        private void search_cancelar_con_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                txt_saldo_doc.EditValue = 00.00m;
                txt_restante.EditValue = 0.00m;
                if (search_cancelar_con.EditValue != null)
                {
                    GridView view = search_cancelar_con.Properties.View;

                    //var data= Negocio.ClasesCN.CuentasCobrarCN.Documento_Cliente_Select_Fila(Convert.ToInt32(search_clientes.EditValue??0),Convert.ToInt32(search_cancelar_con.EditValue??0));
                    //;

                    txt_saldo_doc.Focus();

                    //view.FocusedRowHandle=Convert.ToInt32(search_cancelar_con.EditValue??0);
                    //int rowHandle = view.FocusedRowHandle;
                    //if(data!=null)
                    //{
                    //   // string fieldName = "saldo";
                    //    //object value = view.GetRowCellValue(rowHandle, fieldName);
                    //    object nombre_docomento=data.nombre_documento.ToString().ToUpper();
                    //    txt_saldo_doc.EditValue=data.saldo;
                    //    txt_restante.EditValue=data.saldo;
                    //   Distribuir_Saldo();
                    //}
                }
                else
                {
                    txt_saldo_doc.EditValue = 0.00m;
                    txt_restante.EditValue = 0.00m;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (search_cancelar_con.EditValue != null)
                {
                    Distribuir_Saldo();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        private void gview_docs_pendientes_cancelar_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            if (search_cancelar_con.EditValue != null)
            {
                Distribuir_Saldo();
            }

        }
        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (search_cancelar_con.EditValue != null)
                {
                    gview_docs_pendientes_cancelar.OptionsSelection.MultiSelect = check_permite_seleccionar.Checked;
                    Distribuir_Saldo();
                }


            }
            catch (Exception ex)
            {

                throw;
            }
        }
        private void gview_docs_pendientes_cancelar_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                int idsumatoria = Convert.ToInt32((e.Item as GridSummaryItem).Tag);


                if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Start)
                {
                    suma = 0.00m;
                }
                if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Calculate)
                {
                    switch (idsumatoria)
                    {
                        case 1:

                            suma += (decimal)e.FieldValue;
                            break;
                    }
                }
                if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize)
                {
                    switch (idsumatoria)
                    {
                        case 1:
                            // e.TotalValueReady=true;
                            e.TotalValue = suma;
                            txt_restante.EditValue = Convert.ToDecimal(txt_saldo_doc.EditValue ?? 0) - Convert.ToDecimal(e.TotalValue);
                            break;
                    }

                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        private void gview_docs_pendientes_cancelar_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }
        private void gview_docs_pendientes_cancelar_InvalidValueException(object sender, DevExpress.XtraEditors.Controls.InvalidValueExceptionEventArgs e)
        {
            switch (gview_docs_pendientes_cancelar.FocusedColumn.FieldName)
            {
                case "monto_pago":
                    Error.ClearErrors();
                    if (!this.EsNumero(e.Value.ToString()))
                    {
                        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
                        e.WindowCaption = "Debe de colocar un valor numerico";
                        e.ErrorText = "valor debe de ser numerico";
                    }
                    else if (Convert.ToDecimal(e.Value) < 0)
                    {
                        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
                        e.WindowCaption = "Debe de colocar un valor Mayor o igual que 0";
                        e.ErrorText = "valor debe de ser numerico mayor o igual a 0";

                    }
                    else if (Convert.ToDecimal(e.Value) > Convert.ToDecimal(gview_docs_pendientes_cancelar.GetFocusedRowCellValue("saldo")))
                    {
                        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
                        e.WindowCaption = "Monto a Pagar no puede ser mayor al saldo del documento pendiente";
                        e.ErrorText = "Monto a Pagar no puede ser mayor al saldo del documento pendiente";
                    }
                    else if (Convert.ToDecimal(e.Value) > Convert.ToDecimal(txt_restante.EditValue ?? 0))
                    {
                        e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.DisplayError;
                        e.WindowCaption = "Monto a Pagar no puede ser mayor al saldo del restante del documento con que Cancela";
                        e.ErrorText = "Monto a Pagar no puede ser mayor al saldo del restante del documento con que Cancela";
                        Error.SetError(txt_restante, $"Monto de pago no puede ser mayor a {Math.Round(Convert.ToDecimal(txt_restante.EditValue ?? 0), 3, MidpointRounding.AwayFromZero).ToString()}");
                        txt_restante.EditValue = Convert.ToDecimal(txt_saldo_doc.EditValue ?? 0) - Convert.ToDecimal(gview_docs_pendientes_cancelar.Columns["monto_pago"].SummaryItem.SummaryValue);
                    }




                    break;


            }
        }
        private void gview_docs_pendientes_cancelar_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            switch (gview_docs_pendientes_cancelar.FocusedColumn.FieldName)
            {
                case "monto_pago":
                    if (!this.EsNumero(e.Value.ToString()))
                    {
                        e.Valid = false;
                    }
                    else if (Convert.ToDecimal(e.Value) < 0)
                    {


                        e.Valid = false;

                    }
                    else if (Convert.ToDecimal(e.Value) > Convert.ToDecimal(gview_docs_pendientes_cancelar.GetFocusedRowCellValue("saldo")))
                    {
                        e.Valid = false;
                    }
                    else if (Convert.ToDecimal(e.Value) > Convert.ToDecimal(txt_restante.EditValue ?? 0))
                    {
                        e.Valid = false;
                    }

                    break;
            }
        }
        private void gview_docs_pendientes_cancelar_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            Error.ClearErrors();
            GridView vista = sender as GridView;
            vista.ClearColumnErrors();
            GridColumn monto_pago = vista.Columns["monto_pago"];
            GridColumn saldo_documento = vista.Columns["saldo"];
            if (vista.IsDataRow(e.RowHandle))
            {
                string monto_pago_ = vista.GetRowCellValue(e.RowHandle, monto_pago).ToString();
                string saldo_documento_ = vista.GetRowCellValue(e.RowHandle, saldo_documento).ToString();
                if (monto_pago_ == string.Empty)
                {
                    e.Valid = false;
                    vista.SetColumnError(monto_pago, string.Format("Debe de colocar valor"));
                    vista.FocusedColumn = monto_pago;
                    vista.FocusedRowHandle = e.RowHandle;
                    vista.ShowEditor();
                }
                else if (Convert.ToDecimal(monto_pago_) < 0)
                {
                    e.Valid = false;
                    vista.SetColumnError(monto_pago, string.Format("Coloque un valor mayor o igual que 0 "));
                    vista.FocusedColumn = monto_pago;
                    vista.FocusedRowHandle = e.RowHandle;
                    vista.ShowEditor();
                }
                else if (Convert.ToDecimal(monto_pago_) > Convert.ToDecimal(saldo_documento_))
                {
                    e.Valid = false;
                    vista.SetColumnError(monto_pago, string.Format("Pago no puede ser mayor que el saldo del documento"));
                    vista.FocusedColumn = monto_pago;
                    vista.FocusedRowHandle = e.RowHandle;
                    vista.ShowEditor();
                }
                else if (Convert.ToDecimal(monto_pago_) > Convert.ToDecimal(saldo_documento_))
                {

                    e.Valid = false;
                    vista.SetColumnError(monto_pago, string.Format($"Pago no puede ser mayor que el saldo del disponible en el Documento {search_cancelar_con.Text}"));
                    Error.SetError(txt_restante, $"El monto del pago no puede ser mayor a {Math.Round(Convert.ToDecimal(txt_restante.EditValue ?? 0), 3, MidpointRounding.AwayFromZero).ToString()}");
                    vista.FocusedColumn = monto_pago;
                    vista.FocusedRowHandle = e.RowHandle;
                    vista.ShowEditor();
                }

            }
        }

        private void gview_docs_pendientes_cancelar_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "monto_pago")
            {
                // gview_docs_pendientes_cancelar.PostEditor();
                gview_docs_pendientes_cancelar.UpdateTotalSummary();
            }
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            search_cancelar_con.EditValue = null;
            radio_distribucion.SelectedIndex = 0;
            search_clientes.EditValue = null;

        }
        private bool Validar_aplicacion()
        {
            Error.ClearErrors();
            bool resultado = false;

            try
            {
                if (search_clientes.EditValue == null)
                {
                    Error.SetError(search_clientes, "Por Favor Seleccione un Cliente de la lista desplegable");
                    return resultado;
                }
                else if (search_cancelar_con.EditValue == null)
                {
                    Error.SetError(search_cancelar_con, "Por Favor Seleccione un documento de la lista desplegable");
                    return resultado;
                }
                else if (Convert.ToDecimal(gview_docs_pendientes_cancelar.Columns["monto_pago"].SummaryItem.SummaryValue) == 0)
                {
                    XtraMessageBox.Show($"Por Favor haga distrubucion del saldo del documento seleccionado", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return resultado;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception)
            {
                return false;


            }

        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (Validar_aplicacion())
                {
                    if (XtraMessageBox.Show($"¿Desea aplicar el documento {search_cancelar_con.Text}?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                        int resultado = Negocio.ClasesCN.CuentasCobrarCN.Aplica_documento_Cuentas_cobrar(Convert.ToInt32(search_cancelar_con.EditValue), Convert.ToInt32(search_clientes.EditValue), Convert.ToDecimal(txt_saldo_doc.EditValue), txt_concepto.Text, Clases.UsuarioLogueado.vID_Empleado, Convert.ToInt32(search_cobrador.EditValue), gview_docs_pendientes_cancelar, check_permite_seleccionar.Checked);
                        if (resultado > 0)
                        {
                            XtraMessageBox.Show("Se ha aplicado correctamente el documento", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            decimal monto_pendiente = Convert.ToDecimal(gview_docs_pendientes_cancelar.Columns["saldo"].SummaryItem.SummaryValue);
                            decimal saldo_abonado = Convert.ToDecimal(gview_docs_pendientes_cancelar.Columns["monto_pago"].SummaryItem.SummaryValue);
                            BindingSource Origen_Datos = new BindingSource();

                            if (Convert.ToBoolean(radioGroup_tipo_papel.EditValue))
                            {
                                Origen_Datos.DataSource = Negocio.ClasesCN.CuentasCobrarCN.Documentos_Fila_Select(resultado).ToList();
                                var Reporte = new Reportes.CuentasCobrar.xfrm_recibo_abono_termico(Origen_Datos);
                                Reporte.Parameters[1].Value = Clases.numeros_a_letras.ToCardinal(saldo_abonado);
                                Reporte.Parameters[1].Visible = false;
                                Reporte.Parameters[0].Visible = false;
                                Reporte.Parameters[0].Value = resultado;
                                Reporte.Saldo.Value = monto_pendiente - saldo_abonado;
                                Reporte.ShowPreview();
                            }
                            else
                            {
                                Origen_Datos.DataSource = Negocio.ClasesCN.CuentasCobrarCN.Documentos_Fila_Select(resultado).ToList();
                                var Reporte = new Reportes.CuentasCobrar.xfrm_recibo_abono(Origen_Datos);
                                Reporte.Parameters[1].Value = Clases.numeros_a_letras.ToCardinal(saldo_abonado);
                                Reporte.Parameters[1].Visible = false;
                                Reporte.Parameters[0].Visible = false;
                                Reporte.Parameters[0].Value = resultado;
                                Reporte.Saldo.Value = monto_pendiente - saldo_abonado;
                                Reporte.ShowPreview();
                            }
                            search_clientes_EditValueChanged(null, null);
                        }
                        else
                        {
                            XtraMessageBox.Show("No se ha podido aplicar el documento a ningun documento pendiente", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Se ha aplicado correctamente el documento", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void search_cobrador_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

        }

        private void txt_saldo_doc_EditValueChanged(object sender, EventArgs e)
        {
            Distribuir_Saldo();
        }

        private void eXPORTARAEXCELToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gview_docs_pendientes_cancelar.RowCount > 0)
            {
                new Clases.Exportar().Exportar_Grid_A_Excel(grid_docs_pendientes_cancelar);
            }
        }

        private void lookUp_Moneda_EditValueChanged(object sender, EventArgs e)
        {
            //search_clientes_EditValueChanged(null, null);
        }
    }
}