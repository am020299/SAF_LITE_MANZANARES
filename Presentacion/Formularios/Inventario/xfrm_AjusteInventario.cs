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
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraReports.UI;
using Presentacion.Formularios.Catalogos;

namespace Presentacion.Formularios.Inventario
{
    public partial class xfrm_AjusteInventario : DevExpress.XtraEditors.XtraForm
    {
        int id_empleado;
        string usuario;
        string cargo;
        public xfrm_AjusteInventario()
        {
            InitializeComponent();
            id_empleado = Clases.UsuarioLogueado.vID_Empleado;
            usuario = Clases.UsuarioLogueado.vNickName;
            cargo = Clases.UsuarioLogueado.vPuestoCargo;
            bodegaEspecial();
        }

        #region VIEW
        private void xfrm_AjusteInventario_Load(object sender, EventArgs e)
        {
            lookUpEdit_Ajuste.Properties.DataSource = Negocio.ClasesCN.CatalogosCN.TipoAjuste().Where(x => x.id != 12 || x.id != 13);
            bindingSourceAjuste.DataSource = getTable();
            repositoryItemLookUpEdit_Producto.DataSource = Negocio.ClasesCN.CatalogosCN.Producto_Cargar().Where(x => x.habilitado == true);
            repositoryItemLookUpEdit_Bodega.DataSource = lookUpEditBodega1.Properties.DataSource = Negocio.ClasesCN.CatalogosCN.Bodega_Cargar();
            repositoryItemLookUpEdit_UnidadMedida.DataSource = Negocio.ClasesCN.CatalogosCN.UnidadMedida_Cargar();
            repository_lote.DataSource = Negocio.ClasesCN.CatalogosCN.Lotes_Cargar().Select(L => new { id_lote = L.id_lote, lote = L.lote }).ToList();
            repository_ubicacion.DataSource = Negocio.ClasesCN.InventarioCN.Kardex_Select().Select(K => new { ubicacion = K.ubicacion }).Distinct().ToList();
            txt_PersonaReferencia.Text = Presentacion.Clases.UsuarioLogueado.vNombreCompleto;
            txt_PersonaReferencia.ReadOnly = true;
            dateFecha.EditValue = DateTime.Now;
            bodegaEspecial();

        }
        private void xfrm_AjusteInventario_Activated(object sender, EventArgs e)
        {
            lookUpEdit_Ajuste.Properties.DataSource = Negocio.ClasesCN.CatalogosCN.TipoAjuste().Where(x => x.id != 12 || x.id != 13);
            repositorio_search_producto.DataSource = Negocio.ClasesCN.CatalogosCN.Producto_Cargar().Where(x => x.habilitado == true);
            repositoryItemLookUpEdit_Bodega.DataSource = Negocio.ClasesCN.CatalogosCN.Bodega_Cargar();
            repositoryItemLookUpEdit_UnidadMedida.DataSource = Negocio.ClasesCN.CatalogosCN.UnidadMedida_Cargar();
            txt_PersonaReferencia.Text = Presentacion.Clases.UsuarioLogueado.vNombreCompleto;
            txt_PersonaReferencia.ReadOnly = true;
            dateFecha.EditValue = DateTime.Now;
            repository_ubicacion.DataSource = Negocio.ClasesCN.InventarioCN.Kardex_Select().Select(K => new { ubicacion = K.ubicacion }).Distinct().ToList();
        }
        private void xfrm_AjusteInventario_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (viewDetalle.OptionsBehavior.Editable)
                if (viewDetalle.RowCount > 0)
                    e.Cancel = true;
        }
        private DataTable getTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id_bodega", typeof(int));
            dt.Columns.Add("id_producto", typeof(int));
            dt.Columns.Add("descripcion", typeof(string));
            dt.Columns.Add("cantidad", typeof(decimal));
            dt.Columns.Add("id_unidad_medida", typeof(int));
            dt.Columns.Add("id_lote", typeof(int));
            dt.Columns.Add("ubicacion", typeof(string));

            return dt;
        }
        private void repositoryItemLookUpEdit_Producto_EditValueChanged(object sender, EventArgs e)
        {
            object value = (sender as LookUpEdit).EditValue;
            var query = Negocio.ClasesCN.CatalogosCN.Producto_Cargar_Fila(int.Parse(value.ToString())).Where(x => x.habilitado == true).FirstOrDefault();
            if (query != null)
            {
                viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle, "cantidad", 1.00M);
                viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle, "id_unidad_medida", query.id_unidad_medida);
                viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle, "descripcion", query.descripcion);
            }
        }
        private void repositorio_search_producto_EditValueChanged(object sender, EventArgs e)
        {
            object value = (sender as SearchLookUpEdit).EditValue;


            var query = Negocio.ClasesCN.CatalogosCN.Producto_Cargar_Fila(int.Parse(value.ToString())).Where(x => x.habilitado == true).FirstOrDefault();
            if (query != null)
            {
                viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle, "cantidad", 1.00M);
                viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle, "id_unidad_medida", query.id_unidad_medida);
                viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle, "descripcion", query.descripcion);
            }
        }
        bool ProductoExiste(int vIdProducto, int vIdBodega, int Vid_Lote, GridView view)
        {
            bool retorno = false;
            for (int i = 0; i < view.RowCount; i++)
            {
                int focus = view.FocusedRowHandle;
                if (i == focus) continue;
                int Producto = Convert.ToInt32(view.GetRowCellValue(i, "id_producto"));
                int Bodega = Convert.ToInt32(lookUpEditBodega1.EditValue ?? 0);
                int Lote = Convert.ToInt32(view.GetRowCellValue(i, "id_lote"));
                if (vIdProducto == Producto && vIdBodega == Bodega && Vid_Lote == Lote)
                { retorno = true; break; }
            }
            return retorno;
        }
        private decimal vExist = 0.00M;
        private void viewDetalle_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            GridView view = sender as GridView;

            switch (view.FocusedColumn.FieldName)
            {
                case "cantidad":
                    int IdAjuste = Convert.ToInt32(lookUpEdit_Ajuste.EditValue == null ? 0 : lookUpEdit_Ajuste.EditValue);
                    int Mov = Convert.ToInt16(Negocio.ClasesCN.CatalogosCN.getTiposAjustes().Where(x => x.id == IdAjuste).FirstOrDefault() == null ? 0 :
                        Negocio.ClasesCN.CatalogosCN.getTiposAjustes().Where(x => x.id == IdAjuste).FirstOrDefault().tipo_movimiento);
                    if (Mov == 2)
                    {
                        int bodega = Convert.ToInt32(lookUpEditBodega1.EditValue ?? 0);//view.GetFocusedRowCellValue(colBodega).Equals(DBNull.Value) ? 0 : Convert.ToInt32(view.GetFocusedRowCellValue(colBodega));
                        int producto = view.GetFocusedRowCellValue("id_producto").Equals(DBNull.Value) ? 0 : Convert.ToInt32(view.GetFocusedRowCellValue("id_producto"));
                        var vid_Lote = view.GetFocusedRowCellValue("id_lote").Equals(DBNull.Value) ? 0 : Convert.ToInt32(view.GetFocusedRowCellValue("id_lote"));
                        var ubicacion = view.GetFocusedRowCellValue("ubicacion").Equals(DBNull.Value) ? -1 : Convert.ToInt32(view.GetFocusedRowCellValue("ubicacion"));
                        var Productos = Negocio.ClasesCN.InventarioCN.Producto_Select_Fila_Lote(producto, bodega, vid_Lote).Where(u => u.ubicacion == ubicacion.ToString() && u.habilitado == true);
                        var query = Productos.Count() != 0 ? Productos.FirstOrDefault().stock : 0;


                        // var query = Negocio.ClasesCN.InventarioCN.Kardex_SelectFila(producto, bodega)==null?0:Negocio.ClasesCN.InventarioCN.Kardex_SelectFila(producto, bodega).FirstOrDefault().saldo_actual;
                        vExist = decimal.Parse(query.ToString());
                        if ((Convert.ToInt32(e.Value) <= 0) || (Convert.ToDecimal(e.Value) > query))
                            e.Valid = false;
                    }
                    else
                    {
                        if ((Convert.ToInt32(e.Value) <= 0) || (Convert.ToDecimal(e.Value) > 1000000))
                            e.Valid = false;
                    }
                    break;

                    //case colBodega:
                    //     int vBodega=view.GetFocusedRowCellValue(colBodega).Equals(DBNull.Value) ? 0 : Convert.ToInt32(view.GetFocusedRowCellValue(colBodega));
                    //    if(vBodega == 0)
                    //    {
                    //        e.Valid = false;
                    //    }
                    //    break;
            }
        }
        private void viewDetalle_InvalidValueException(object sender, DevExpress.XtraEditors.Controls.InvalidValueExceptionEventArgs e)
        {
            GridView view = sender as GridView;

            switch (view.FocusedColumn.FieldName)
            {
                case "cantidad":
                    e.ExceptionMode = ExceptionMode.DisplayError;
                    e.WindowCaption = "Error en el valor ingresado";
                    e.ErrorText = "Cantidad no puede ser menor/igual a 0 o mayor a " + String.Format("{0:n2}", vExist);
                    //view.HideEditor();
                    break;

                    //case colBodega:
                    //    e.ExceptionMode = ExceptionMode.DisplayError;
                    //    e.WindowCaption = "El campo bodega es un campo requerido";
                    //    e.ErrorText = "La bodega es requerida";
                    //    //view.HideEditor();
                    //    break;
            }
        }
        private void viewDetalle_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            GridView view = sender as GridView;
            try
            {

                var vIdBodega = Convert.ToInt32(lookUpEditBodega1.EditValue ?? 0); //view.GetFocusedRowCellValue(colBodega).Equals(DBNull.Value) ? 0 : Convert.ToInt32(view.GetFocusedRowCellValue(colBodega));
                if (vIdBodega == 0)
                {
                    e.Valid = false;
                    new DXErrorProvider().SetError(lookUpEditBodega1, "Campo requerido");
                    view.FocusedColumn = colID;
                }

                var vIdProducto = view.GetFocusedRowCellValue("id_producto").Equals(DBNull.Value) ? 0 : Convert.ToInt32(view.GetFocusedRowCellValue("id_producto"));
                if (vIdProducto == 0) { e.Valid = false; view.SetColumnError(colID, "Campo requerido"); view.FocusedColumn = colID; }

                var vid_Lote = view.GetFocusedRowCellValue("id_lote").Equals(DBNull.Value) ? 0 : Convert.ToInt32(view.GetFocusedRowCellValue("id_lote"));
                if (vid_Lote == 0) { e.Valid = false; view.SetColumnError(col_id_lote, "Campo requerido"); view.FocusedColumn = col_id_lote; }
                var ubicacion = view.GetFocusedRowCellValue("ubicacion").Equals(DBNull.Value) ? -1 : Convert.ToInt32(view.GetFocusedRowCellValue("ubicacion"));
                if (ubicacion == -1) { e.Valid = false; view.SetColumnError(col_ubicacion, "Campo requerido"); view.FocusedColumn = col_ubicacion; }
                var vCantidad = view.GetFocusedRowCellValue("cantidad").Equals(DBNull.Value) ? "" : Convert.ToString(view.GetFocusedRowCellValue("cantidad"));
                if (string.IsNullOrEmpty(vCantidad))
                {
                    e.Valid = false; view.SetColumnError(colCantidad, "Campo requerido"); view.FocusedColumn = colCantidad;
                }
                else
                {
                    int IdAjuste = Convert.ToInt32(lookUpEdit_Ajuste.EditValue == null ? 0 : lookUpEdit_Ajuste.EditValue);
                    int Mov = Convert.ToInt16(Negocio.ClasesCN.CatalogosCN.getTiposAjustes().Where(x => x.id == IdAjuste).FirstOrDefault() == null ? 0 : Negocio.ClasesCN.CatalogosCN.getTiposAjustes().Where(x => x.id == IdAjuste).FirstOrDefault().tipo_movimiento);

                    if (Mov == 2)
                    {
                        int bodega = Convert.ToInt32(lookUpEditBodega1.EditValue ?? 0); //view.GetFocusedRowCellValue(colBodega).Equals(DBNull.Value) ? 0 : Convert.ToInt32(view.GetFocusedRowCellValue(colBodega));
                        int producto = view.GetFocusedRowCellValue("id_producto").Equals(DBNull.Value) ? 0 : Convert.ToInt32(view.GetFocusedRowCellValue("id_producto"));
                        int id_lote = view.GetFocusedRowCellValue("id_lote").Equals(DBNull.Value) ? 0 : Convert.ToInt32(view.GetFocusedRowCellValue("id_lote"));
                        var Productos = Negocio.ClasesCN.InventarioCN.Producto_Select_Fila_Lote(producto, bodega, id_lote).Where(u => u.ubicacion == ubicacion.ToString() && u.habilitado == true);
                        var query = Productos.Count() != 0 ? Productos.FirstOrDefault().stock : 0;


                        if (Convert.ToDecimal(vCantidad) > query) { e.Valid = false; view.SetColumnError(colCantidad, "Cantidad no puede ser mayor a " + String.Format("{0:n2}", query)); view.FocusedColumn = colCantidad; }
                    }
                    else if (Convert.ToDecimal(vCantidad) <= 0.00M) { e.Valid = false; view.SetColumnError(colCantidad, "Cantidad no puede ser menor/igual a 0"); view.FocusedColumn = colCantidad; }
                }

                //  if (ProductoExiste(vIdProducto, vIdBodega,vid_Lote,view)) { e.Valid = false; view.SetColumnError(colID, "Codigo ya esta agregado"); view.FocusedColumn = colID; }

            }
            catch (Exception ex)
            {
                e.Valid = false;
                view.SetColumnError(colID, "Campo requerido");
                view.FocusedColumn = colID;
                new DXErrorProvider().SetError(lookUpEditBodega1, "Campo requerido");
                view.FocusedColumn = colID;
                view.SetColumnError(colCantidad, "Campo requerido");
                view.FocusedColumn = colCantidad;
            }
        }
        private void viewDetalle_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
            e.WindowCaption = "Error en el valor ingresado";
            e.ErrorText = "Campo requerido";
        }
        private void viewDetalle_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete)
                {
                    GridView view = sender as GridView;
                    int[] filas = view.GetSelectedRows();
                    if (filas.Length > 0) { view.DeleteSelectedRows(); }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error :" + ex.Message);
            }
        }
        #endregion
        DXErrorProvider dXError = new DXErrorProvider();
        bool Validar()
        {
            bool retorno = false;

            dXError.ClearErrors(); dXError.Dispose();
            /*if (string.IsNullOrEmpty(txtNumeroFactura.Text.Trim().Replace(" ", "")))
            {
                dXError.SetError(txtNumeroFactura, "Campo requerido");
                txtNumeroFactura.Focus();
            }
            else */
            if (lookUpEdit_Ajuste.EditValue == null)
            {
                dXError.SetError(lookUpEdit_Ajuste, "Campo requerido");
                lookUpEdit_Ajuste.Focus();
            }
            else if (dateFecha.Text.Length <= 0)
            {
                dXError.SetError(dateFecha, "Campo requerido");
                dateFecha.Focus();
            }
            else if (viewDetalle.RowCount == 0)
            {
                XtraMessageBox.Show("No hay detalles que guardar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                viewDetalle.Focus();
            }
            else { retorno = true; }


            return retorno;
        }
        private void bbiGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!Validar()) return;
            //var Permisos = Negocio.ClasesCN.RolesPermisosCN.Cargar_Permisos(0).Where(p => p.id_rol == 12).FirstOrDefault();
            //xfrm_autorizacion frm = new xfrm_autorizacion("REALIZACION DE AJUSTE DE INVENTARIO");
            //frm.numero_permiso = Permisos.id_rol ?? 0;
            //frm.permiso = Permisos.descripcion.ToUpper();
            //frm.ShowDialog();
            //if (frm.Autorizado)
            //{
            if (Clases.MyMessageBox.Show("¿Desea Guardar el Ajuste?", "Ajuste de Inventario", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            int vEmpleado = Clases.UsuarioLogueado.vID_Empleado;
            int vAjuste = Convert.ToInt32(lookUpEdit_Ajuste.EditValue);
            DateTime vFecha = Convert.ToDateTime(dateFecha.EditValue);
            string vNumeroReferencia = txt_NumeroReferencia.Text.Trim();
            string vObservacion = txtObservacion.Text.Trim();
            string vPersonaReferencia = txt_PersonaReferencia.Text;
            int vTipo = 4;

            var MovOK = Negocio.ClasesCN.InventarioCN.AjusteInventario_Guardar_Autorizacion(vAjuste, vFecha, vNumeroReferencia, vObservacion, vEmpleado, vPersonaReferencia, vTipo, 0, viewDetalle, Convert.ToInt32(lookUpEditBodega1.EditValue ?? 0));//Convert.ToInt32(look_lote.EditValue??0));
            if (MovOK.Item1)
            {
                txtNumeroFactura.Text = MovOK.Item3;
                Clases.MyMessageBox.Show("Guardada Correctamente", "Inventario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //BindingSource source = new BindingSource();
                //int vMov = MovOK.Item2;
                //source.DataSource = Negocio.ClasesCN.InventarioCN.Reporte_Ajuste(vMov);
                //var report = new Reportes.Inventario.xrpt_ajuste(source);
                //report.ShowPreviewDialog();
                bbiLimpiar_ItemClick(null, null);
                xfrm_AjusteInventario_Activated(null, null);
            }
            //}
            //else
            //{
            //    XtraMessageBox.Show($"Usted no tiene autorizacion de {frm.permiso.ToUpper()}", "Información");
            //}
        }

        private void bbiLimpiar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            lookUpEdit_Ajuste.EditValue = null;
            lookUpEditBodega1.EditValue = null;
            txtNumeroFactura.Text = string.Empty;
            txtObservacion.Text = string.Empty;
            txt_NumeroReferencia.Text = string.Empty;
            txt_PersonaReferencia.Text = string.Empty;
            dateFecha.EditValue = DateTime.Now;
            gridAjuste.DataSource = null;
            bindingSourceAjuste.DataSource = null;
            bindingSourceAjuste.DataSource = getTable();
            gridAjuste.DataSource = bindingSourceAjuste;
            SendKeys.Send("{ESC}");
        }
        private void lookUpEdit_Ajuste_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (viewDetalle.RowCount > 0)
                {
                    viewDetalle.ClearSelection();
                    for (int i = 0; i < viewDetalle.RowCount; i++)
                    {
                        int bodega = Convert.ToInt32(lookUpEditBodega1.EditValue ?? 0);//Convert.ToInt32(viewDetalle.GetRowCellValue(i, colBodega));
                        int producto = Convert.ToInt32(viewDetalle.GetRowCellValue(i, "id_producto"));
                        decimal vCantidad = Convert.ToDecimal(viewDetalle.GetRowCellValue(i, "cantidad"));
                        var query = Convert.ToDecimal(Negocio.ClasesCN.InventarioCN.Kardex_SelectFila(producto, bodega).Where(x => x.habilitado == true).FirstOrDefault() == null ? 0.00M : Negocio.ClasesCN.InventarioCN.Kardex_SelectFila(producto, bodega).Where(x => x.habilitado == true).FirstOrDefault().saldo_actual);

                        int Mov = Convert.ToInt16(Negocio.ClasesCN.CatalogosCN.getTiposAjustes().Where(x => x.id == Convert.ToInt32(lookUpEdit_Ajuste.EditValue)).FirstOrDefault().tipo_movimiento);

                        if (Mov == 2)
                        {
                            if (query <= 0.00m) { viewDetalle.SelectRow(i); }
                            else if (vCantidad > query) { viewDetalle.SetRowCellValue(i, "cantidad", query); }
                        }
                    }
                    viewDetalle.DeleteSelectedRows();
                }
            }
            catch (Exception) { }
        }

        private void viewDetalle_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                if (e.PrevFocusedColumn.Name == "colBodega")
                {
                    var vIdBodega = Convert.ToInt32(lookUpEditBodega1.EditValue ?? 0);//view.GetFocusedRowCellValue(colBodega).Equals(DBNull.Value) ? 0 : Convert.ToInt32(view.GetFocusedRowCellValue(colBodega));
                    if (vIdBodega == 0)
                    {
                        view.FocusedColumn = e.PrevFocusedColumn;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void bodegaEspecial()
        {
            //Clases.UsuarioLogueado.bodegaEspecial(lookUpEditBodega1, usuario, cargo);
            Clases.UsuarioLogueado.bodegaEspecial(lookUpEditBodega1);
        }

        private void lookUpEditBodega1_EditValueChanged(object sender, EventArgs e)
        {
            string lote = "ENE";
            if (Convert.ToInt32(lookUpEditBodega1.EditValue) == 4 || Convert.ToInt32(lookUpEditBodega1.EditValue) == 2)
            {
                repository_lote.DataSource = Negocio.ClasesCN.CatalogosCN.Lotes_Cargar().Where(x => x.lote.StartsWith(lote));//.Where(x => x.id_lote == 412 && x.id_lote == 362);
                //repository_lote.DataSource = Negocio.ClasesCN.CatalogosCN.Lotes_Cargar().Select(L => new { id_lote = L.id_lote, lote = L.lote }).ToList();
            }
            else
            {
                repository_lote.DataSource = Negocio.ClasesCN.CatalogosCN.Lotes_Cargar().Select(L => new { id_lote = L.id_lote, lote = L.lote }).ToList();
            }

        }

        private void bbi_crearPlantilla_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (viewDetalle.RowCount == 0)
                new Clases.Exportar().Exportar_Grid_A_Excel(gridAjusteExportar);
        }

        private void bbi_Importar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridAjuste.RefreshDataSource();
            new Clases.Exportar().ImportarExcel_A_Grid(gridAjuste);
            ComprobarImporte();
        }

        void ComprobarImporte()
        {
            if (viewDetalle.RowCount > 0)
            {
                int bodega = Convert.ToInt32(lookUpEditBodega1.EditValue == null ? 0 : lookUpEditBodega1.EditValue);
                for (int i = 0; i < viewDetalle.RowCount; i++)
                {
                    string producto = viewDetalle.GetRowCellValue(i, "id_producto").ToString();
                    string lote = viewDetalle.GetRowCellValue(i, "id_lote").ToString();
                    //string ubicacion = viewDetalle.GetRowCellValue(i, "ubicacion").ToString();

                    var queryproducto = Negocio.ClasesCN.CatalogosCN.Codigo_Producto_Cargar_Fila(producto).FirstOrDefault();
                    var queryLote = Negocio.ClasesCN.CatalogosCN.Lotes_Cargar().Where(x => x.lote == lote).FirstOrDefault();

                    if (queryproducto != null && queryLote != null)
                    {
                        viewDetalle.SetRowCellValue(i, "id_producto", queryproducto.id);
                        viewDetalle.SetRowCellValue(i, "id_lote", queryLote.id_lote);
                        viewDetalle.SetRowCellValue(i, "id_unidad_medida", queryproducto.id_unidad_medida);
                    }
                    else
                    {
                        XtraMessageBox.Show("Ocurrio un error al importar el archivo Excel. Por favor revise el archivo e intente nuevamente", "Inventario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
    }
}