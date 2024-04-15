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
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraReports.UI;
using Presentacion.Formularios.Catalogos;

namespace Presentacion.Formularios.Ventas
{

    public partial class xfrm_convertir_prestamo_factura : DevExpress.XtraEditors.XtraForm
    {
        private int _vTipoVenta;
        private decimal _vTipoCambio;
        public int _vIdCliente;
        DataTable dt,Moneda_dT;
        int persona_autoriza=0;
        public int IDempleado;
        decimal sub_total, descuento_total, iva, total;

        bool cotizacion,actualizar;
        int idCotizacion;

        public xfrm_convertir_prestamo_factura(int xTipoVenta, int idcotiza, bool modificar)
        {
            vTipoVenta = xTipoVenta;
            this.actualizar = modificar;
            this.idCotizacion = idcotiza;
            InitializeComponent();
            dateFecha.EditValue = DateTime.Now;
            dateFechaEstimada.EditValue = DateTime.Now;
            Moneda_dT = new DataTable();
            Moneda_dT.Columns.Add("moneda",typeof(int));
            Moneda_dT.Columns.Add("descripcion",typeof(string));
            IDempleado = Clases.UsuarioLogueado.vID_Empleado;
            precioEspecial();

        }
        public int vTipoVenta { get => _vTipoVenta; set => _vTipoVenta = value; }
        public decimal vTipoCambio { get => _vTipoCambio; set => _vTipoCambio = value; }
        public int vIdCliente { get => _vIdCliente; set => _vIdCliente = value; }

        private void xfrm_NuevaVenta_Load(object sender,EventArgs e)
        {
            try
            {
                ///   Moneda_dT = Negocio.ClasesCN.CatalogosCN.getMoneda();

                if (Clases.UsuarioLogueado.admin || Negocio.ClasesCN.RolesPermisosCN.Permisos(Clases.UsuarioLogueado.vID_Empleado, 135))
                    dateFecha.Enabled = dateFechaEstimada.Enabled = true;

                if (Clases.UsuarioLogueado.admin || Negocio.ClasesCN.RolesPermisosCN.Permisos(Clases.UsuarioLogueado.vID_Empleado, 1356))
                   lookUpEdit_Terminos.Enabled = true;

                Moneda_dT = Negocio.ClasesCN.CatalogosCN.getMoneda();
                look_moneda.Properties.DataSource = Moneda_dT;
                bindingSourceCliente.DataSource = Negocio.ClasesCN.CatalogosCN.Cliente_Cargar();
                var Terminos= Negocio.ClasesCN.ParametrosCN.Terminos_Select();
                lookUpEdit_Terminos.Properties.DataSource = Terminos;
                lookUpEdit_Terminos.EditValue = Terminos.Min(x => x.id);
                lookUpEdit_Vendedor.Properties.DataSource = Negocio.ClasesCN.CatalogosCN.Empleado_Cargar().ToList();
                lookUpEdit_Vendedor.EditValue = Clases.UsuarioLogueado.vID_Empleado;
                var Bodegas=Negocio.ClasesCN.CatalogosCN.Bodega_Cargar();
                repositoryItemLookUpEdit_Bodega.DataSource = lookUpEdit_Bodega.Properties.DataSource = Bodegas;

                lookUpEdit_Bodega.EditValue = 4;
                repositoryItemLookUpEdit_Producto.DataSource= Negocio.ClasesCN.InventarioCN.Kardex_SelectVentaEXC().Where(x => x.id_bodega == 4 && x.moneda == Convert.ToInt32(look_moneda.EditValue)).ToList();
                repositoryItemLookUpEdit_UnidadMedida.DataSource = Negocio.ClasesCN.CatalogosCN.UnidadMedida_Cargar();
                vTipoCambio = Negocio.ClasesCN.DatosRequeridosCN.obtener_tipo_cambio_mensual();
                txt_tipo_cambio_mes.EditValue = vTipoCambio;
                look_moneda.EditValue = Convert.ToString(Negocio.ClasesCN.VentasCN.devolverMoneda(idCotizacion));//2.ToString();

                Consultar_Fecha_Cerrada();
                repositoryItemLookUpEdit_Producto.Columns["precio4"].Caption = "PRECIO ESPECIAL";
                //
                //bindingSourceDetalle.DataSource = null;
                //bindingSourceDetalle.DataSource = getTable();
                bindingSourceDetalle.DataSource = Negocio.ClasesCN.VentasCN.Cargar_Detalle_Prestamo(idCotizacion);
                //int monedat = Convert.ToInt32(Negocio.ClasesCN.VentasCN.Cargar_Detalle_Cotizacion(idCotizacion).Select(x => x.moneda));
                //look_moneda.EditValue = monedat;
                gridVenta.DataSource = bindingSourceDetalle;
                getVenta(actualizar);
                //calculo_total();
                //actualizarFilas();

            }
            catch(Exception ex) { }
        }
        private void Consultar_Fecha_Cerrada( )
        {
            if(dateFecha.EditValue != null && Convert.ToInt32(lookUpEdit_Terminos.EditValue) == 1 && vTipoVenta == 1)
            {
                DateTime fecha = Convert.ToDateTime(dateFecha.Text);
                if(Negocio.ClasesCN.CajaCN.CONSULTAR_SI_FECHA_ESTA_CERRADA(fecha))
                {
                    btnGuardar.Enabled = false;
                    Clases.MyMessageBox.MessageFont = new Font(Clases.MyMessageBox.MessageFont.FontFamily,22);
                    Clases.MyMessageBox.Show("Fecha para facturar, ya se encuentra cerrada","Información",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else
                    btnGuardar.Enabled = true;
            }
        }
        private void xfrm_NuevaVenta_Activated(object sender,EventArgs e)
        {
            //bindingSourceCliente.DataSource = Negocio.ClasesCN.CatalogosCN.Cliente_Cargar();
            //lookUpEdit_Vendedor.Properties.DataSource = Negocio.ClasesCN.CatalogosCN.Empleado_Cargar().ToList();
            //vTipoCambio = Negocio.ClasesCN.DatosRequeridosCN.obtener_tipo_cambio_mensual();
            //if (vTipoVenta != 2)
            //{
            //    bindingSourceProducto.DataSource = Negocio.ClasesCN.InventarioCN.Kardex_SelectVenta().Where(x => x.id_bodega == int.Parse(lookUpEdit_Bodega.EditValue.ToString()) && x.moneda == Convert.ToInt32(look_moneda.EditValue)).ToList();
            //}
            
            //txt_tipo_cambio_mes.EditValue = vTipoCambio;
            //calculo_total();
        }
        private void xfrm_NuevaVenta_FormClosing(object sender,FormClosingEventArgs e)
        {
            if(viewDetalle.OptionsBehavior.Editable)
                if(viewDetalle.RowCount > 0)
                    e.Cancel = true;
        }
        private DataTable getTable( )
        {
            dt = new DataTable();
            dt.Columns.Add("id_bodega",typeof(int));
            dt.Columns.Add("id_producto",typeof(int));
            dt.Columns.Add("descripcion",typeof(string));
            dt.Columns.Add("cantidad",typeof(decimal));
            dt.Columns.Add("id_unidad_medida",typeof(int));
            dt.Columns.Add("tipo_precio",typeof(int));
            dt.Columns.Add("precio1",typeof(decimal));
            dt.Columns.Add("descuento",typeof(decimal));
            dt.Columns.Add("impuesto",typeof(decimal));
            dt.Columns.Add("id_lote",typeof(int));
            dt.Columns.Add("Nfila",typeof(int));
            dt.Columns.Add("codigo_producto",typeof(string));
            dt.Columns.Add("ubicacion",typeof(string));
            dt.Columns.Add("tipo_producto",typeof(string));
            dt.Columns.Add("categoria",typeof(string));

            return dt;
        }
        private void lookUpEdit_Cliente_EditValueChanged(object sender,EventArgs e)
        {
            txt_Tel.Text = string.Empty;
            txt_Ruc.Text = string.Empty;
            txt_Dir.Text = string.Empty;
            var query = Negocio.ClasesCN.CatalogosCN.Cliente_Cargar().Where(x => x.id == Convert.ToInt32(lookUpEdit_Cliente.EditValue)).FirstOrDefault();
            if(query != null)
            {
                var repres= Negocio.ClasesCN.CatalogosCN.Representantes_clientes(query.id).ToList();
                look_representante.Properties.DataSource = repres;
                if(repres.Count > 0)
                {
                    look_representante.EditValue = repres.FirstOrDefault().Representantes.ToUpper();
                }
                else
                {
                    look_representante.EditValue = "N/A";
                }

                txt_Tel.Text = query.celular;
                txt_Ruc.Text = query.ruc;
                txt_Dir.Text = query.direccion;
                //   look_representante.EditValue = query.id_representante;
                look_precio.SelectedIndex = (query.precio ?? 0) - 1;

            }
        }
        #region METODOS VIEW
        private void repositoryItemSearchLookUpEdit_Producto_EditValueChanged(object sender,EventArgs e)
        {
            try
            {
                // object value = (sender as LookUpEdit).EditValue;

                SearchLookUpEdit editor = (sender as SearchLookUpEdit);
                var Fila_Producto=(Entidades.Kardex_SELECT_VENTA_Result)editor.GetSelectedDataRow();
                int vPrecio =Convert.ToInt16(look_precio.SelectedIndex)+1;
                //try { vPrecio = Convert.ToInt32(Negocio.ClasesCN.CatalogosCN.Cliente_SelectFila(int.Parse(lookUpEdit_Cliente.EditValue.ToString())).FirstOrDefault().precio); } catch (Exception) { vPrecio = 1; }

                var query = Negocio.ClasesCN.InventarioCN.Producto_Select_Fila_Lote(Fila_Producto.id,Fila_Producto.id_bodega,Fila_Producto.id_lote??0).FirstOrDefault();
                // var kardex_venta= Negocio.ClasesCN.InventarioCN.Kardex_SelectFila(Convert.ToInt32(value.ToString()),Convert.ToInt32(lookUpEdit_Bodega.EditValue??0)).FirstOrDefault();
                if(query != null)
                {
                    viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle,"tipo_precio",vPrecio);
                    switch(vPrecio)
                    {
                        case 1:
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle,"cantidad",1.00);
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle,"id_unidad_medida",query.id_unidad_medida);
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle,"descripcion",query.descripcion);
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle,"precio1",query.precio1);
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle,"descuento",query.descuento);
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle,"impuesto",query.impuesto);
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle,"id_producto",query.id);
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle,"ubicacion",query.ubicacion);
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle,col_lote,Fila_Producto.id_lote);
                            break;

                        case 2:
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle,"cantidad",1.00);
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle,"id_unidad_medida",query.id_unidad_medida);
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle,"descripcion",query.descripcion);
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle,"precio1",query.precio2);
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle,"descuento",query.descuento);
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle,"impuesto",query.impuesto);
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle,"id_producto",query.id);
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle,"ubicacion",query.ubicacion);
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle,col_lote,Fila_Producto.id_lote);
                            break;

                        case 3:
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle,"cantidad",1.00);
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle,"id_unidad_medida",query.id_unidad_medida);
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle,"descripcion",query.descripcion);
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle,"precio1",query.precio3);
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle,"descuento",query.descuento);
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle,"impuesto",query.impuesto);
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle,"id_producto",query.id);
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle,"ubicacion",query.ubicacion);
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle,col_lote,Fila_Producto.id_lote);
                            break;

                        case 4:
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle,"cantidad",1.00);
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle,"id_unidad_medida",query.id_unidad_medida);
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle,"descripcion",query.descripcion);
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle,"precio1",query.precio4);
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle,"descuento",query.descuento);
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle,"impuesto",query.descuento);
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle,"id_producto",query.id);
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle,"ubicacion",query.ubicacion);
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle,"id_lote",Fila_Producto.id_lote);
                            break;

                        default:
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle,"cantidad",1.00);
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle,"id_unidad_medida",query.id_unidad_medida);
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle,"descripcion",query.descripcion);
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle,"precio1",query.precio1);
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle,"descuento",query.descuento);
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle,"impuesto",query.impuesto);
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle,"id_producto",query.id);
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle,"ubicacion",query.ubicacion);
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle,col_lote,Fila_Producto.id_lote);
                            break;
                    }
                }
            }
            catch(Exception ex) { }
        }

        bool ProductoExiste(int vIdProducto,int vIdBodega,int vid_lote,GridView view)
        {
            bool retorno = false;
            for(int i = 0;i < view.RowCount;i++)
            {
                int focus = view.FocusedRowHandle;
                if(i == focus) continue;
                int Producto = Convert.ToInt32(view.GetRowCellValue(i, "id_producto"));
                int Bodega = Convert.ToInt32(view.GetRowCellValue(i, "id_bodega"));
                int Lote = Convert.ToInt32(view.GetRowCellValue(i, "id_lote"));
                if(vIdProducto == Producto && vIdBodega == Bodega && Lote == vid_lote) { retorno = true; break; }
            }
            return retorno;
        }

        private decimal vExist = 0.00M;
        private Decimal Precio_detalle=0.00M;
        private string precio=string.Empty;
        int tipo_precio=0;
        private void viewDetalle_ValidatingEditor(object sender,DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            GridView view = sender as GridView;

            try
            {

                int bodega = view.GetFocusedRowCellValue("id_bodega").Equals(DBNull.Value) ? 0 : Convert.ToInt32(view.GetFocusedRowCellValue("id_bodega"));
                int producto = view.GetFocusedRowCellValue("id_producto").Equals(DBNull.Value) ? 0 : Convert.ToInt32(view.GetFocusedRowCellValue("id_producto"));
                int id_lote = view.GetFocusedRowCellValue("id_lote").Equals(DBNull.Value) ? 0 : Convert.ToInt32(view.GetFocusedRowCellValue("id_lote"));
                Precio_detalle = Negocio.ClasesCN.InventarioCN.Precio_De_Producto(look_precio.SelectedIndex+1, producto);
                //precio = Negocio.ClasesCN.InventarioCN.Precio_De_Producto_letras(look_precio.SelectedIndex + 1,producto);
                decimal precio_celda = view.GetFocusedRowCellValue("precio1").Equals(DBNull.Value) ? 0.00M : Convert.ToInt32(view.GetFocusedRowCellValue("precio1"));

                switch (view.FocusedColumn.FieldName)
                {
                    case "cantidad":
                        //if ((Convert.ToInt32(e.Value) <= 0) || (Convert.ToInt32(e.Value) > 1000000))
                        //    e.Valid = false;
                        //if(vTipoVenta == 1)
                        //{

                            var query = Negocio.ClasesCN.InventarioCN.Producto_Select_Fila_Lote(producto, bodega,id_lote).FirstOrDefault();
                            vExist = decimal.Parse(query.stock.ToString());
                            //  if (query.tipo_producto==false)
                            //  {
                            if((Convert.ToDecimal(e.Value) <= 0.00m) || (Convert.ToDecimal(e.Value) > query.stock))
                                e.Valid = false;
                            //  }

                        //}
                        break;
                    case "descuento":
                        if((Convert.ToDecimal(e.Value) < 0.00m))
                            e.Valid = false;
                        break;

                    //case "impuesto":
                    //    if ((Convert.ToDecimal(e.Value) <= 0.00m))
                    //        e.Valid = false;
                    //    break;

                    case "precio1":

                        if(Convert.ToDecimal(e.Value) <= Precio_detalle)// AGREGADO VALIDACION DE QUE NO PUEDE DISMINUIR PRECIO AL MOMENTO DE SELECCIONAR PRECIO LIBRE, YA QUE NO RECUERDAN SUS VALIDACIONES ESTA GENTE
                        //if (Convert.ToDecimal(e.Value) < precio_celda)
                        {
                            e.Valid = false;
                        }
                        if((Convert.ToDecimal(e.Value) <= 0.00m))
                            e.Valid = false;

                        break;

                    //case "id_producto":
                    //    if(ProductoExiste(producto,bodega,id_lote,view))
                    //        e.Valid = false;
                    //    if(producto == 0 || Convert.ToInt32(e.Value) <= 0)
                    //    { e.Valid = false; }
                    //    break;
                }
            }
            catch(Exception) { e.Valid = false; }
        }
        private void viewDetalle_InvalidValueException(object sender,DevExpress.XtraEditors.Controls.InvalidValueExceptionEventArgs e)
        {
            GridView view = sender as GridView;

            switch(view.FocusedColumn.FieldName)
            {
                case "cantidad":
                    //if(vTipoVenta == 1)
                    //{
                        e.ExceptionMode = ExceptionMode.DisplayError;
                        e.WindowCaption = "Error en el valor ingresado";
                        e.ErrorText = "Cantidad no puede ser menor/igual a 0 o mayor a " + String.Format("{0:n2}",vExist);
                    //}
                    //view.HideEditor();
                    break;

                case "descuento":
                    e.ExceptionMode = ExceptionMode.DisplayError;
                    e.WindowCaption = "Error en el valor ingresado";
                    e.ErrorText = "Descuento no puede ser menor a 0";
                    //view.HideEditor();
                    break;

                //case "impuesto":
                //    e.ExceptionMode = ExceptionMode.DisplayError;
                //    e.WindowCaption = "Error en el valor ingresado";
                //    e.ErrorText = "Impuesto no puede ser menor a 0";
                //    //view.HideEditor();
                //    break;

                case "precio1":
                    e.ExceptionMode = ExceptionMode.DisplayError;
                    e.WindowCaption = "Error en el valor ingresado";
                    e.ErrorText = $"Precio no puede ser menor a {string.Format("{0:n2}",Precio_detalle)} ({precio}) ni menor o igual a 0";
                    //view.HideEditor();
                    break;

                case "id_producto":
                    e.ExceptionMode = ExceptionMode.DisplayError;
                    e.WindowCaption = "Error al agregar producto";
                    e.ErrorText = "Campo rquerido";
                    //view.HideEditor();
                    break;
            }
        }
        private void viewDetalle_ValidateRow(object sender,ValidateRowEventArgs e)
        {
            GridView view = sender as GridView;
            //if (vTipoVenta != 0)
            //{
                try
                {

                    var vIdBodega = view.GetFocusedRowCellValue("id_bodega").Equals(DBNull.Value) ? 0 : Convert.ToInt32(view.GetFocusedRowCellValue("id_bodega"));
                    if (vIdBodega == 0) { e.Valid = false; view.SetColumnError(colBodega, "Campo requerido"); view.FocusedColumn = colBodega; }

                    var vIdProducto = view.GetFocusedRowCellValue("id_producto").Equals(DBNull.Value) ? 0 : Convert.ToInt32(view.GetFocusedRowCellValue("id_producto"));
                    if (vIdProducto == 0)
                    {
                        e.Valid = false;
                        view.SetColumnError(colID, "Campo requerido"); view.FocusedColumn = colID;
                    }

                    var vid_Lote = view.GetFocusedRowCellValue("id_lote").Equals(DBNull.Value) ? 0 : Convert.ToInt32(view.GetFocusedRowCellValue(col_lote));
                    if (vid_Lote == 0)
                    {
                        e.Valid = false;
                        view.SetColumnError(colID, "Campo requerido"); view.FocusedColumn = colID;
                    }
                    var vCantidad = view.GetFocusedRowCellValue("cantidad").Equals(DBNull.Value) ? "" : Convert.ToString(view.GetFocusedRowCellValue("cantidad"));
                    
                    if (string.IsNullOrEmpty(vCantidad))
                    {
                        e.Valid = false;
                        view.SetColumnError(colCantidad, "Campo requerido"); view.FocusedColumn = colCantidad;
                    }

                    else
                    {
                        //int bodega = view.GetFocusedRowCellValue("id_bodega").Equals(DBNull.Value) ? 0 : Convert.ToInt32(view.GetFocusedRowCellValue("id_bodega"));
                        //int producto = view.GetFocusedRowCellValue("id_producto").Equals(DBNull.Value) ? 0 : Convert.ToInt32(view.GetFocusedRowCellValue("id_producto"));
                        //int vid_lote = view.GetFocusedRowCellValue("id_lote").Equals(DBNull.Value) ? 0 : Convert.ToInt32(view.GetFocusedRowCellValue("id_lote"));
                        var query = Negocio.ClasesCN.InventarioCN.Producto_Select_Fila_Lote(vIdProducto, vIdBodega, vid_Lote).FirstOrDefault();

                        if (Convert.ToDecimal(vCantidad) > query.stock && vTipoVenta == 1)
                        {
                            e.Valid = false;
                            view.SetColumnError(colCantidad, "Cantidad no puede ser mayor a " + String.Format("{0:n2}", query.stock));
                            view.FocusedColumn = colCantidad;
                        }

                    }
                    var query_costo = 0;
                    var vPrecio = view.GetFocusedRowCellValue("precio1").Equals(DBNull.Value) ? "" : Convert.ToString(view.GetFocusedRowCellValue("precio1"));
                    if (string.IsNullOrEmpty(vPrecio))
                    {
                        e.Valid = false;
                        view.SetColumnError(colPrecio, "Campo requerido"); view.FocusedColumn = colPrecio;
                    }
                    else
                    {
                        if (Convert.ToDecimal(vPrecio) < query_costo)
                        {
                            e.Valid = false; view.SetColumnError(colPrecio, "Precio no puede ser menor al costo (" + String.Format("{0:n2}", query_costo) + ")"); view.FocusedColumn = colPrecio;
                        }
                    }
                    var vDescuento = view.GetFocusedRowCellValue("descuento").Equals(DBNull.Value) ? "" : Convert.ToString(view.GetFocusedRowCellValue("descuento"));
                    if (string.IsNullOrEmpty(vDescuento))
                    {
                        e.Valid = false;
                        view.SetColumnError(colDescuento, "Campo requerido");
                        view.FocusedColumn = colDescuento;
                    }
                    //if (ProductoExiste(vIdProducto, vIdBodega, vid_Lote, view)) { e.Valid = false; view.SetColumnError(colID, "Codigo ya esta agregado"); view.FocusedColumn = colID; }

                }
                catch (Exception ex)
                {
                    e.Valid = false;
                }

            //}
           
        }
        private void viewDetalle_InvalidRowException(object sender,InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
            e.WindowCaption = "Error en el valor ingresado";
            e.ErrorText = "Campo requerido";
        }
        private void viewDetalle_KeyDown(object sender,KeyEventArgs e)
        {
            try
            {
                if(e.KeyCode == Keys.Delete)
                {
                    GridView view = sender as GridView;
                    //if (XtraMessageBox.Show("Desea Eliminar Este Registro?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
                    view.DeleteRow(view.FocusedRowHandle);

                    if(viewDetalle.RowCount > 0) { lookUpEdit_Bodega.Enabled = false; layoutControlItemMostrar.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always; }
                    else { lookUpEdit_Bodega.Enabled = true; layoutControlItemMostrar.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never; }
                    calculo_total();
                }

            }
            catch(Exception ex)
            {
                XtraMessageBox.Show("Error :" + ex.Message);
            }
        }
        private void viewDetalle_InitNewRow(object sender,InitNewRowEventArgs e)
        {
            try
            {

                //repositoryItemLookUpEdit_Producto.Columns["precio4"].Visible = false;
                
               repositoryItemLookUpEdit_Producto.DataSource= Negocio.ClasesCN.InventarioCN.Kardex_SelectVentaEXC().Where(x => x.id_bodega == int.Parse(lookUpEdit_Bodega.EditValue.ToString()) && x.moneda == Convert.ToInt32(look_moneda.EditValue)).ToList();
                viewDetalle.SetFocusedRowCellValue("id_bodega",lookUpEdit_Bodega.EditValue);
                
            }
            catch(Exception)
            {
                viewDetalle.SetFocusedRowCellValue("id_bodega",Negocio.ClasesCN.CatalogosCN.Bodega_Cargar().Min(x => x.id));
            }
        }
        private void itera_cantidades( )
        {
            Dictionary<string,int>categoria_Cantidad= new Dictionary<string, int>();

            for(int i = 0;i < viewDetalle.RowCount;i++)
            {
                string categoria=Convert.ToString(viewDetalle.GetRowCellValue(i,viewDetalle.Columns["categoria"]));
                int cantidad=Convert.ToInt32(viewDetalle.GetRowCellValue(i,viewDetalle.Columns["cantidad"]));
                if(categoria_Cantidad.ContainsKey(categoria))
                {
                    categoria_Cantidad[categoria] += cantidad;
                }
                else
                {
                    categoria_Cantidad.Add(categoria,cantidad);
                }
            }
            foreach(var CC in categoria_Cantidad)
            {
                if(CC.Value < 6)
                {
                    for(int i = 0;i < viewDetalle.RowCount;i++)
                    {
                        int id_producto = Convert.ToInt32(viewDetalle.GetRowCellValue(i,"id_producto"));
                        string categoria = Convert.ToString(viewDetalle.GetRowCellValue(i,"categoria"));
                        if(CC.Key == categoria)
                        {
                            if(!Es_Servicio(viewDetalle,i))
                            {
                                decimal precio = Negocio.ClasesCN.InventarioCN.Precio_De_Producto(3, id_producto);
                                viewDetalle.SetRowCellValue(i,"precio1",precio);
                                tipo_precio = 3;
                            }
                        }
                    }
                }
                else
                {
                    var cliente = Negocio.ClasesCN.CatalogosCN.Cliente_SelectFila(Convert.ToInt32(lookUpEdit_Cliente.EditValue)).FirstOrDefault();

                    for (int i = 0;i < viewDetalle.RowCount;i++)
                    {
                        int id_producto = Convert.ToInt32(viewDetalle.GetRowCellValue(i,"id_producto"));
                        string categoria = Convert.ToString(viewDetalle.GetRowCellValue(i,"categoria"));
                        if(CC.Key == categoria)
                        {
                            if(!Es_Servicio(viewDetalle,i))
                            {
                                decimal precio = Negocio.ClasesCN.InventarioCN.Precio_De_Producto(look_precio.SelectedIndex+1, id_producto);

                                if (precio == 0.00M)
                                {
                                    precio = Negocio.ClasesCN.InventarioCN.Precio_De_Producto(Convert.ToInt32(cliente.precio), id_producto);
                                }

                                viewDetalle.SetRowCellValue(i,"precio1",precio);
                                tipo_precio = look_precio.SelectedIndex + 1;
                            }
                        }
                    }
                }
            }
        }
        private void viewDetalle_RowUpdated(object sender,RowObjectEventArgs e)
        {
            try
            {

                viewDetalle.UpdateSummary();
                
                if(!check_precio_libre.Checked)
                {
                    if(look_precio.ReadOnly)
                    {
                        Dictionary<string,int>categoria_Cantidad= new Dictionary<string, int>();

                        for(int i = 0;i < viewDetalle.RowCount;i++)
                        {
                            string categoria=Convert.ToString(viewDetalle.GetRowCellValue(i,viewDetalle.Columns["categoria"]));
                            int cantidad=Convert.ToInt32(viewDetalle.GetRowCellValue(i,viewDetalle.Columns["cantidad"]));
                            if(categoria_Cantidad.ContainsKey(categoria))
                            {
                                categoria_Cantidad[categoria] += cantidad;
                            }
                            else
                            {
                                categoria_Cantidad.Add(categoria,cantidad);
                            }
                        }
                        foreach(var CC in categoria_Cantidad)
                        {
                            if(CC.Value < 6)//Antes era 11 ahora son 6
                            {
                                for(int i = 0;i < viewDetalle.RowCount;i++)
                                {
                                    int id_producto = Convert.ToInt32(viewDetalle.GetRowCellValue(i, "id_producto"));
                                    string categoria = Convert.ToString(viewDetalle.GetRowCellValue(i, "categoria"));
                                    if(CC.Key == categoria)
                                    {
                                        // REVISAR CODIGO, YA QUE PONE TIPO PRECIO
                                        if(!Es_Servicio(viewDetalle,i))
                                        {
                                            decimal precio = Negocio.ClasesCN.InventarioCN.Precio_De_Producto(3, id_producto);
                                            viewDetalle.SetRowCellValue(i, "precio1",precio);
                                            tipo_precio = 3;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                for(int i = 0;i < viewDetalle.RowCount;i++)
                                {
                                    int id_producto = Convert.ToInt32(viewDetalle.GetRowCellValue(i, "id_producto"));
                                    string categoria = Convert.ToString(viewDetalle.GetRowCellValue(i, "categoria"));
                                    if(CC.Key == categoria)
                                    {
                                        if(!Es_Servicio(viewDetalle,i))
                                        {
                                            decimal precio = Negocio.ClasesCN.InventarioCN.Precio_De_Producto(look_precio.SelectedIndex+1, id_producto);
                                            viewDetalle.SetRowCellValue(i, "precio1",precio);
                                            tipo_precio = look_precio.SelectedIndex + 1;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else { tipo_precio = 7; }
                calculo_total();
                viewDetalle.UpdateTotalSummary();
            }
            catch(Exception) { }
        }
        #endregion
        DXErrorProvider dXError = new DXErrorProvider();
        bool Validar( )
        {
            bool retorno = false;

            dXError.ClearErrors(); dXError.Dispose();
            /*if (string.IsNullOrEmpty(txtNumeroFactura.Text.Trim().Replace(" ", "")))
            {
                dXError.SetError(txtNumeroFactura, "Campo requerido");
                txtNumeroFactura.Focus();
            }
            else */
            if(lookUpEdit_Cliente.EditValue == null)
            {
                dXError.SetError(lookUpEdit_Cliente,"Campo requerido");
                lookUpEdit_Cliente.Focus();
            }
            else if(lookUpEdit_Terminos.EditValue == null)
            {
                dXError.SetError(lookUpEdit_Terminos,"Campo requerido");
                lookUpEdit_Terminos.Focus();
            }
            else if(lookUpEdit_Vendedor.EditValue == null)
            {
                dXError.SetError(lookUpEdit_Vendedor,"Campo requerido");
                lookUpEdit_Vendedor.Focus();
            }
            else if(dateFecha.Text.Length <= 0 || dateFechaEstimada.Text.Length <= 0)
            {
                dXError.SetError(dateFecha,"Campo requerido");
                dXError.SetError(dateFechaEstimada,"Campo requerido");
                dateFecha.Focus();
            }
            else if(viewDetalle.RowCount == 0)
            {
                XtraMessageBox.Show("No hay detalles que guardar","Información",MessageBoxButtons.OK,MessageBoxIcon.Information);
                viewDetalle.Focus();
            }

            else { retorno = true; }


            return retorno;
        }
        void GuardarOrden(int Opcion)
        {
            int vCambioPrecioCliente = 0;
            int vEmpleado = Clases.UsuarioLogueado.vID_Empleado;
            int vNumeroFactura = 0;// Convert.ToInt32(txtNumeroFactura.EditValue);
            int vCliente = Convert.ToInt32(lookUpEdit_Cliente.EditValue);
            DateTime vFecha = DateTime.Now;
            DateTime vFechaEstimada = DateTime.Now;
            string vObservacion = txtObservacion.Text.Trim();
            string vPersonaReferencia = look_representante.Text.ToUpper();
            int vIdTermino = Convert.ToInt32(lookUpEdit_Terminos.EditValue);
            int vVendedor = Clases.UsuarioLogueado.vID_Empleado;
            decimal retencion1 = 0.00M;
            decimal retencion2 = 0.00M;

            //Consula la tabla clientes para solo obtener la columna precio con el id cliente
            var queryColprecioCliente = Negocio.ClasesCN.VentasCN.getPrecioClientes().Where(x => x.id == vCliente).Select(x => x.precio);

            foreach (var precioCliente in queryColprecioCliente)
            {
                //Verifico si el precio del cliente en el combobox se cambia con respecto al precio del cliente por defecto y si el tipo de precio es detalle == 3
                if (tipo_precio == 3 && precioCliente != Convert.ToInt32(look_precio.SelectedIndex + 1))
                {
                    vCambioPrecioCliente = Convert.ToInt32(look_precio.SelectedIndex + 1);//si es asi agarra los valores seleccionados del combobox
                }
                //Si el precio no es detalle y el precio por defecto del cliente es igual al que se selecciona en el combobx
                else if (tipo_precio != 3 && precioCliente == Convert.ToInt32(look_precio.SelectedIndex + 1))
                {
                    vCambioPrecioCliente = Convert.ToInt32(look_precio.SelectedIndex + 1);//Agarro los valores seleccionados del combobox
                    tipo_precio = Convert.ToInt32(look_precio.SelectedIndex + 1);//Agarro los valores seleccionados del combobox
                }
                else
                {
                    vCambioPrecioCliente = 3;//De lo contrario, significa que no se cambió el precio del cliente y se vendió a detalle  (3)
                }
            }


            try { vVendedor = Convert.ToInt32(lookUpEdit_Vendedor.EditValue); } catch (Exception) { vVendedor = Clases.UsuarioLogueado.vID_Empleado; }
            try { tipo_precio = check_precio_libre.Checked ? 7 : tipo_precio; } catch { }

            var VentaOK = Negocio.ClasesCN.VentasCN.Venta_GuardarPrestamo(vEmpleado, vVendedor, vNumeroFactura, vCliente, vFecha, vFechaEstimada, vTipoCambio, vObservacion, vTipoVenta, vIdTermino, vPersonaReferencia, viewDetalle, viewPago, look_representante.Text.ToUpper(), Convert.ToInt32(look_moneda.EditValue ?? 0), persona_autoriza, tipo_precio, vCambioPrecioCliente,retencion1,retencion2);
            if (VentaOK.Item1)
            {
                txtNumeroFactura.Text = VentaOK.Item3;
                Negocio.ClasesCN.VentasCN.PasarPrestamoAFacturado(idCotizacion);
                Clases.MyMessageBox.Show("Guardada Correctamente","Venta",MessageBoxButtons.OK,MessageBoxIcon.Information);
                if(Opcion == 1)
                {
                    btnLimpiar_ItemClick(null,null);
                }
                else if(Opcion == 2)
                {
                    if(vTipoVenta == 0)
                    {
                        BindingSource source = new BindingSource();
                        source.DataSource = Negocio.ClasesCN.VentasCN.Venta_Reporte(VentaOK.Item2);
                        var report = new Reportes.Ventas.Cotizacion1(source);
                        report.ShowPreviewDialog();
                        report.Dispose();
                    }
                }
                this.Close();
            }
           
        }
        void ActualizarOrden(int Opcion)
        {
            var Permisos = Negocio.ClasesCN.RolesPermisosCN.Cargar_Permisos(0).Where(p => p.id_rol == 11149).FirstOrDefault();
            xfrm_autorizacion frm = new xfrm_autorizacion("Editar Prestaamo");
            frm.numero_permiso = Permisos.id_rol ?? 0;
            frm.permiso = Permisos.descripcion.ToUpper();
            frm.ShowDialog();
            if (frm.Autorizado)
            {
                int vCambioPrecioCliente = 0;
                int vEmpleado = Clases.UsuarioLogueado.vID_Empleado;
                int vNumeroFactura = 0;// Convert.ToInt32(txtNumeroFactura.EditValue);
                int vCliente = Convert.ToInt32(lookUpEdit_Cliente.EditValue);
                DateTime vFecha = Convert.ToDateTime(dateFecha.EditValue);
                DateTime vFechaEstimada = Convert.ToDateTime(dateFechaEstimada.EditValue);
                string vObservacion = txtObservacion.Text.Trim();
                string vPersonaReferencia = look_representante.Text.ToUpper();
                int vIdTermino = Convert.ToInt32(lookUpEdit_Terminos.EditValue);
                int vVendedor = Clases.UsuarioLogueado.vID_Empleado;

                //Consula la tabla clientes para solo obtener la columna precio con el id cliente
                var queryColprecioCliente = Negocio.ClasesCN.VentasCN.getPrecioClientes().Where(x => x.id == vCliente).Select(x => x.precio);

                foreach (var precioCliente in queryColprecioCliente)
                {
                    //Verifico si el precio del cliente en el combobox se cambia con respecto al precio del cliente por defecto y si el tipo de precio es detalle == 3
                    if (tipo_precio == 3 && precioCliente != Convert.ToInt32(look_precio.SelectedIndex + 1))
                    {
                        vCambioPrecioCliente = Convert.ToInt32(look_precio.SelectedIndex + 1);//si es asi agarra los valores seleccionados del combobox
                    }
                    //Si el precio no es detalle y el precio por defecto del cliente es igual al que se selecciona en el combobx
                    else if (tipo_precio != 3 && precioCliente == Convert.ToInt32(look_precio.SelectedIndex + 1))
                    {
                        vCambioPrecioCliente = Convert.ToInt32(look_precio.SelectedIndex + 1);//Agarro los valores seleccionados del combobox
                    }
                    else
                    {
                        vCambioPrecioCliente = 3;//De lo contrario, significa que no se cambió el precio del cliente y se vendió a detalle  (3)
                    }
                }


                try { vVendedor = Convert.ToInt32(lookUpEdit_Vendedor.EditValue); } catch (Exception) { vVendedor = Clases.UsuarioLogueado.vID_Empleado; }
                try { tipo_precio = check_precio_libre.Checked ? 7 : tipo_precio; } catch { }

                var VentaOK = Negocio.ClasesCN.VentasCN.Prestamo_Actualizar(idCotizacion, vEmpleado, vVendedor, vCliente, vFecha, vFechaEstimada, vTipoCambio, vObservacion, vPersonaReferencia, viewDetalle, look_representante.Text.ToUpper(), Convert.ToInt32(look_moneda.EditValue ?? 0), persona_autoriza, tipo_precio, vCambioPrecioCliente);
                if (VentaOK.Item1)
                {
                    Clases.MyMessageBox.Show("Guardada Correctamente", "Remisiones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (Opcion == 1)
                    {
                        btnLimpiar_ItemClick(null, null);
                    }
                    else if (Opcion == 2)
                    {
                        if (vTipoVenta == 0)
                        {
                            BindingSource source = new BindingSource();
                            source.DataSource = Negocio.ClasesCN.VentasCN.Venta_Reporte(VentaOK.Item2);
                            var report = new Reportes.Ventas.Cotizacion1(source);
                            report.ShowPreviewDialog();
                            report.Dispose();
                        }

                    }
                    this.Close();
                }
            }
            else
            {
                XtraMessageBox.Show($"Usted no tiene autorizacion de {frm.permiso.ToUpper()}", "Información");
            }
        }
        private void btnGuardar_ItemClick(object sender,DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                bool cantidadvalida = false;

                viewDetalle.CloseEditor();
                viewDetalle.UpdateCurrentRow();
                if(!Validar()) return;
                int vDias = Negocio.ClasesCN.ParametrosCN.getTerminos().Where(x => x.id == int.Parse(lookUpEdit_Terminos.EditValue.ToString())).FirstOrDefault().dias;

                for (int i = 0; i < viewDetalle.DataRowCount; i++)
                {
                    int idBodega = viewDetalle.GetRowCellValue(i, "id_bodega").Equals(DBNull.Value) ? 0 : Convert.ToInt32(viewDetalle.GetRowCellValue(i, "id_bodega"));
                    int idProducto = viewDetalle.GetRowCellValue(i, "id_producto").Equals(DBNull.Value) ? 0 : Convert.ToInt32(viewDetalle.GetRowCellValue(i, "id_producto"));
                    decimal cantidad = decimal.Parse(viewDetalle.GetRowCellValue(i, "cantidad").ToString());
                    //string codigo = Convert.ToString(viewDetalle.GetRowCellValue(i, "codigo").Equals(DBNull.Value) ? 0 : viewDetalle.GetRowCellValue(i, "codigo"));

                    var consulta = Negocio.ClasesCN.InventarioCN.Kardex_SelectFila(idProducto, idBodega).FirstOrDefault();

                    if (cantidad > consulta.saldo_actual)
                    {
                        XtraMessageBox.Show("El producto " + viewDetalle.GetRowCellValue(i, "descripcion")  + " contiene una cantidad en factura (" + cantidad + ") mayor a la existencia en el inventerio de la bodega TIENDA (" + consulta.saldo_actual + ")", "Datos erroneos de productos en factura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        XtraMessageBox.Show("Favor de actualizar bodega y revisar cantidades", "Actualizar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cantidadvalida = false;
                        break;
                    }
                    cantidadvalida = true;
                    //i++;
                }

                if (cantidadvalida)
                {

                    if (actualizar)
                    {
                        Clases.MyMessageBox.MessageFont = new Font(Clases.MyMessageBox.MessageFont.FontFamily, 24);
                        if (Clases.MyMessageBox.Show("¿Desea modificar este Prestamo?", "Cotizacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
                        ActualizarOrden(1);
                    }
                    else
                    {
                        Clases.MyMessageBox.MessageFont = new Font(Clases.MyMessageBox.MessageFont.FontFamily, 24);
                        if (Clases.MyMessageBox.Show("¿Desea Guardar esta Orden?", "Venta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
                        viewPago = new GridView();
                        GuardarOrden(1);
                    }
                  
                } else { return; }
            }
            catch(Exception ex) { XtraMessageBox.Show("Ha ocurrido un error, Favor comunicarse con soporte ténico " + ex, "Mensaje de aplicación", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void btnGuardarImprimir_ItemClick(object sender,DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                bool cantidadvalida = false;

                viewDetalle.CloseEditor();
                viewDetalle.UpdateCurrentRow();
                if (!Validar()) return;
                int vDias = Negocio.ClasesCN.ParametrosCN.getTerminos().Where(x => x.id == int.Parse(lookUpEdit_Terminos.EditValue.ToString())).FirstOrDefault().dias;

                for (int i = 0; i < viewDetalle.DataRowCount; i++)
                {
                    int idBodega = viewDetalle.GetRowCellValue(i, "id_bodega").Equals(DBNull.Value) ? 0 : Convert.ToInt32(viewDetalle.GetRowCellValue(i, "id_bodega"));
                    int idProducto = viewDetalle.GetRowCellValue(i, "id_producto").Equals(DBNull.Value) ? 0 : Convert.ToInt32(viewDetalle.GetRowCellValue(i, "id_producto"));
                    decimal cantidad = decimal.Parse(viewDetalle.GetRowCellValue(i, "cantidad").ToString());
                    //string codigo = Convert.ToString(viewDetalle.GetRowCellValue(i, "codigo").Equals(DBNull.Value) ? 0 : viewDetalle.GetRowCellValue(i, "codigo"));

                    var consulta = Negocio.ClasesCN.InventarioCN.Kardex_SelectFila(idProducto, idBodega).FirstOrDefault();

                    if (cantidad > consulta.saldo_actual)
                    {
                        XtraMessageBox.Show("El producto " + viewDetalle.GetRowCellValue(i, "descripcion") + " con código " + /*viewDetalle.GetRowCellValue(i, "codigo")*/viewDetalle.GetRowCellValue(i, "codigo") + " contiene una cantidad en factura (" + cantidad + ") mayor a la existencia en el inventerio de la bodega TIENDA (" + consulta.saldo_actual + ")", "Datos erroneos de productos en factura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        XtraMessageBox.Show("Favor de actualizar bodega y revisar cantidades", "Actualizar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cantidadvalida = false;
                        break;
                    }
                    cantidadvalida = true;
                    i++;
                }

                if (cantidadvalida)
                {
                    if (vTipoVenta > 0 && vDias <= 0)
                    {
                        if (Clases.MyMessageBox.Show("¿Desea Guardar esta Orden?", "Venta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
                        viewPago = new GridView();
                        GuardarOrden(2);
                    }
                    else
                    {
                        Clases.MyMessageBox.MessageFont = new Font(Clases.MyMessageBox.MessageFont.FontFamily, 24);
                        if (Clases.MyMessageBox.Show("¿Desea Guardar esta Orden?", "Venta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
                        viewPago = new GridView();
                        GuardarOrden(2);
                    }
                } else { return; }
            }
            catch (Exception ex) { XtraMessageBox.Show("Ha ocurrido un error, Favor comunicarse con soporte ténico" + ex.Message, "Mensaje de aplicación", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void btnLimpiar_ItemClick(object sender,DevExpress.XtraBars.ItemClickEventArgs e)
        {
            lookUpEdit_Cliente.EditValue = null;
            txtNumeroFactura.Text = string.Empty;
            txtObservacion.Text = string.Empty;
            dateFecha.EditValue = DateTime.Now;
            dateFechaEstimada.EditValue = DateTime.Now;
            gridVenta.DataSource = null;
            bindingSourceDetalle.DataSource = null;
            bindingSourceDetalle.DataSource = getTable();
            gridVenta.DataSource = bindingSourceDetalle;
            //bindingSourceProducto.DataSource = null;
            lookUpEdit_Bodega_EditValueChanged(null,null);
            viewPago = null;
            viewDetalle.Focus();
            SendKeys.Send("{ESC}");
            lookUpEdit_Cliente.Focus();
            lookUpEdit_Bodega.Enabled = true;
            layoutControlItemMostrar.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            toggleSwitch1.IsOn = false;
            btnGuardar.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            //txtDescuentoMonto.EditValue = null;
            //txtDescuentoPorcentaje.EditValue = null;
            look_precio.SelectedIndex = -1;
            look_representante.EditValue = null;

            //viewDetalle.Columns[3].Visible = false;
            look_precio.ReadOnly = true;
            //viewDetalle.Columns[3].OptionsColumn.AllowEdit = true;
            //viewDetalle.Columns[3].OptionsColumn.AllowFocus = false;
            viewDetalle.Columns[1].Visible = false;
            persona_autoriza = 0;
            calculo_total();
            tipo_precio = 0;
        }
        public bool getVenta(bool actualizar)
        {
            var query =Negocio.ClasesCN.VentasCN.getPrestamos().Where(o=>o.id==idCotizacion).FirstOrDefault();
            if(query != null)
            {
                txtNumeroFactura.Text = query.numero;
                txtObservacion.Text = query.observacion;
                if(actualizar)
                {
                    dateFecha.EditValue = query.fecha;
                    dateFechaEstimada.EditValue = query.fecha_maxima;
                }
                else
                {
                    dateFecha.EditValue = DateTime.Now;
                    dateFechaEstimada.EditValue = DateTime.Now;
                }
                lookUpEdit_Cliente.EditValue = query.id_cliente;
                //lookUpEdit_Terminos.EditValue = query.id_termino;
                return true;
            }
            else { return false; }
        }
    
        private GridView viewPago;
     
        private void calculo_total( )
        {
            sub_total = 0; descuento_total = 0; iva = 0; total = 0;
            for(int i = 0;i < viewDetalle.RowCount;i++)
            {
                decimal precio = Convert.ToDecimal(viewDetalle.GetRowCellValue(i, "precio1"));
                decimal cantidad = Convert.ToDecimal(viewDetalle.GetRowCellValue(i, "cantidad"));
                decimal descuento = Convert.ToDecimal(viewDetalle.GetRowCellValue(i, "descuento"));
                decimal impuesto = Convert.ToDecimal(viewDetalle.GetRowCellValue(i, "impuesto"));
                sub_total += (precio * cantidad);
                //    descuento_total += ((precio * cantidad) * (descuento / 100));
                //iva += (((precio * cantidad) - ((precio * cantidad) * (descuento / 100))) * (impuesto / 100));
            }
            decimal suma = Convert.ToDecimal(viewDetalle.Columns["total"].SummaryItem.SummaryValue);
            total = (sub_total - descuento_total + iva);
            total = Convert.ToInt32(look_moneda.EditValue ?? 0) == 1 ? total : total * vTipoCambio;
            decimal retencion_1, retencion_2;
            //if (chk_1.Checked)
            //    retencion_1 = Math.Round(suma * Convert.ToDecimal(0.01), 2);
            //else
            //    retencion_1 = 0;

            //if (chk_2.Checked)
            //    retencion_2 = Math.Round(suma * Convert.ToDecimal(0.02), 2);
            //else
            //    retencion_2 = 0;

            //spinEdit_retencion1.EditValue = retencion_1;
            //spinEdit_retencion2.EditValue = retencion_2;
            //txt_total.Text = (total-retencion_1-retencion_2).ToString("n2");
            //total = 0;
            //total= dt.AsEnumerable().Sum(row => row.Field<decimal>("total"));//  Decimal.Round(Convert.ToDecimal(viewDetalle.Columns["total"].SummaryItem.SummaryValue), 2);
            //total = total * vTipoCambio;
            //txt_total.Text = total.ToString("n2");

        }
        private bool Es_Servicio(GridView view, int fila )
        {
            GridColumn col = view.Columns["tipo_producto"];
            bool val = Convert.ToBoolean (view.GetRowCellValue(fila, col));
            return val;
        }
                

        private void repositoryItemLookUpEdit_Bodega_EditValueChanged(object sender, EventArgs e)
        {
            object value = (sender as LookUpEdit).EditValue;
            
            var vIdProducto = viewDetalle.GetFocusedRowCellValue("id_producto").Equals(DBNull.Value) ? 0 : Convert.ToInt32(viewDetalle.GetFocusedRowCellValue("id_producto"));
            if (vIdProducto == 0)
            {
                //repositoryItemLookUpEdit_Producto.DataSource = Negocio.ClasesCN.InventarioCN.Kardex_SelectVenta().Where(x => x.id_bodega == int.Parse(value.ToString())).ToList();
                repositoryItemLookUpEdit_Producto.DataSource= Negocio.ClasesCN.InventarioCN.Kardex_SelectVentaEXC().Where(x => x.id_bodega == int.Parse(lookUpEdit_Bodega.EditValue.ToString()) && x.moneda == Convert.ToInt32(look_moneda.EditValue)).ToList();
            }
            else
            {
                //repositoryItemLookUpEdit_Producto.DataSource = Negocio.ClasesCN.InventarioCN.Kardex_SelectVenta().Where(x => x.id_bodega == int.Parse(value.ToString())).ToList();
                repositoryItemLookUpEdit_Producto.DataSource = Negocio.ClasesCN.InventarioCN.Kardex_SelectVentaEXC().Where(x => x.id_bodega == int.Parse(lookUpEdit_Bodega.EditValue.ToString()) && x.moneda == Convert.ToInt32(look_moneda.EditValue)).ToList();
                var query = Negocio.ClasesCN.InventarioCN.Kardex_SelectVentaEXC().Where(x => x.id_bodega == int.Parse(value.ToString()) && x.id == vIdProducto).FirstOrDefault();
                if (query == null)
                {
                    viewDetalle.SetFocusedRowCellValue("id_producto", null);
                    viewDetalle.SetFocusedRowCellValue("descripcion", "");
                }
            }
            lookUpEdit_Bodega.EditValue = value;
        }
     
        private void toggleSwitch1_Toggled(object sender, EventArgs e)
        {
            colBodega.Visible = toggleSwitch1.IsOn;
            //colBodega.OptionsColumn.AllowFocus = toggleSwitch1.IsOn;
        }

        private void lookUpEdit_Bodega_EditValueChanged(object sender, EventArgs e)
        {
            if (viewDetalle.RowCount == 0)
            {
                //if (vTipoVenta == 1)
                repositoryItemLookUpEdit_Producto.DataSource =  Negocio.ClasesCN.InventarioCN.Kardex_SelectVentaEXC().Where(x => x.id_bodega == int.Parse(lookUpEdit_Bodega.EditValue.ToString()) && x.moneda == Convert.ToInt32(look_moneda.EditValue)).ToList();
             
            }
        }

        private void txtDescuentoPorcentaje_Validated(object sender, EventArgs e)
        {
            //try
            //{
            //    var monto = viewDetalle.Columns["precio1"].SummaryItem.SummaryValue;
            //    for (int i = 0; i < viewDetalle.RowCount; i++)
            //    {
            //        viewDetalle.SetRowCellValue(i, "descuento", txtDescuentoPorcentaje.EditValue);
            //    }
            //    viewDetalle.UpdateCurrentRow();
            //    if (monto == null) txtDescuentoMonto.EditValue = 0.00M;
            //    else
            //    {
            //        txtDescuentoMonto.EditValue = viewDetalle.Columns["descuento"].SummaryItem.SummaryValue;
            //    }
            //}
            //catch (Exception)
            //{
                
            //}
        }

        private void txtDescuentoPorcentaje_KeyPress(object sender, KeyPressEventArgs e)
        {
            string cadena = "1234567890." + (Char)8;

            if (!cadena.Contains(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void dateFecha_EditValueChanged(object sender, EventArgs e)
        {
            Consultar_Fecha_Cerrada();
        }

        private void lookUpEdit_Terminos_EditValueChanged(object sender, EventArgs e)
        {
            //int id_termino = Convert.ToInt32(lookUpEdit_Terminos.EditValue);
            //if (id_termino > 1)
            //{
            //    var Permisos = Negocio.ClasesCN.RolesPermisosCN.Cargar_Permisos(0).Where(p => p.id_rol == 136).FirstOrDefault();
            //    xfrm_autorizacion frm = new xfrm_autorizacion();
            //    frm.numero_permiso = Permisos.id_rol ?? 0;
            //    frm.permiso = Permisos.descripcion.ToUpper();
            //    frm.ShowDialog();
            //    if (!frm.Autorizado)
            //        lookUpEdit_Terminos.EditValue = 1;
            //}
            
            //Consultar_Fecha_Cerrada();
        }
        private void repositoryItemLookUpEdit_Producto_EditValueChanged(object sender,EventArgs e)
        {
            try
            {


                //LookUpEdit editor = (sender as LookUpEdit);
                //var Fila_Producto=(Entidades.Kardex_SELECT_VENTA_Result)editor.GetSelectedDataRow();
                object value = (sender as LookUpEdit).EditValue;
                int id_producto = int.Parse(value.ToString());
                int vPrecio = Convert.ToInt16(look_precio.SelectedIndex)+1;
                var Fila_Producto = Negocio.ClasesCN.InventarioCN.Kardex_SelectVentaEXC().Where(o=>o.id==id_producto && o.id_bodega==4).FirstOrDefault() ;

                var query = Negocio.ClasesCN.InventarioCN.Producto_Select_Fila_Lote(Fila_Producto.id, Fila_Producto.id_bodega, Fila_Producto.id_lote ?? 0).FirstOrDefault();


                if (check_precio_libre.Checked)
                {
                    vPrecio = 3;
                }
                if (query != null)
                {
                    viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle, "tipo_precio", vPrecio);
                    switch (vPrecio)
                    {
                        case 1:
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle, "cantidad", 1.00);
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle, "id_unidad_medida", query.id_unidad_medida);
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle, "descripcion", query.descripcion);
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle, "precio1", query.precio3);
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle, "descuento", query.descuento);
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle, "impuesto", query.impuesto);
                            //viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle, "id_producto", query.id);
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle, "ubicacion", query.ubicacion);
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle, col_lote, Fila_Producto.id_lote);
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle, col_tipo_producto, Fila_Producto.tipo_producto);
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle, col_categoria, Fila_Producto.id_categoria);
                            break;

                        case 2:
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle, "cantidad", 1.00);
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle, "id_unidad_medida", query.id_unidad_medida);
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle, "descripcion", query.descripcion);
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle, "precio1", query.precio3);
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle, "descuento", query.descuento);
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle, "impuesto", query.impuesto);
                            //viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle, "id_producto", query.id);
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle, "ubicacion", query.ubicacion);
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle, col_lote, Fila_Producto.id_lote);
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle, col_tipo_producto, Fila_Producto.tipo_producto);
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle, col_categoria, Fila_Producto.id_categoria);
                            break;

                        case 3:
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle, "cantidad", 1.00);
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle, "id_unidad_medida", query.id_unidad_medida);
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle, "descripcion", query.descripcion);
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle, "precio1", query.precio3);
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle, "descuento", query.descuento);
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle, "impuesto", query.impuesto);
                            //viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle, "id_producto", query.id);
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle, "ubicacion", query.ubicacion);
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle, col_lote, Fila_Producto.id_lote);
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle, col_tipo_producto, Fila_Producto.tipo_producto);
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle, col_categoria, Fila_Producto.id_categoria);
                            break;

                        case 4:
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle, "cantidad", 1.00);
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle, "id_unidad_medida", query.id_unidad_medida);
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle, "descripcion", query.descripcion);
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle, "precio1", query.precio4);
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle, "descuento", query.descuento);
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle, "impuesto", query.descuento);
                            //viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle, "id_producto", query.id);
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle, "ubicacion", query.ubicacion);
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle, "id_lote", Fila_Producto.id_lote);
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle, col_tipo_producto, Fila_Producto.tipo_producto);
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle, col_categoria, Fila_Producto.id_categoria);
                            break;

                        default:
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle, "cantidad", 1.00);
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle, "id_unidad_medida", query.id_unidad_medida);
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle, "descripcion", query.descripcion);
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle, "precio1", query.precio3);
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle, "descuento", query.descuento);
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle, "impuesto", query.impuesto);
                            //viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle, "id_producto", query.id);
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle, "ubicacion", query.ubicacion);
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle, col_lote, Fila_Producto.id_lote);
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle, col_tipo_producto, Fila_Producto.tipo_producto);
                            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle, col_categoria, Fila_Producto.id_categoria);
                            break;
                    }
                }
            }
            catch(Exception ex) { }
        }

        private void look_precio_MouseDoubleClick(object sender,MouseEventArgs e)
        {
            try
            {
                if(!check_precio_libre.Checked)
                {
                    var Permisos=Negocio.ClasesCN.RolesPermisosCN.Cargar_Permisos(0).Where(p=>p.id_rol==103).FirstOrDefault();
                    xfrm_autorizacion frm= new xfrm_autorizacion("CAMBIO DE PRECIO A CLIENTE " +lookUpEdit_Cliente.Text);
                    frm.numero_permiso = Permisos.id_rol ?? 0;
                    frm.permiso = Permisos.descripcion.ToUpper();
                    frm.ShowDialog();
                    if(frm.Autorizado)
                    {

                        look_precio.ReadOnly = false;
                        viewDetalle.Columns[3].Visible = true;
                        viewDetalle.Columns[3].OptionsColumn.AllowEdit = true;
                        viewDetalle.Columns[3].OptionsColumn.AllowFocus = true;
                        persona_autoriza = frm.Id_autorizador();
                        XtraMessageBox.Show($"El usuario {frm.Nombre_Empleado_Autorizador} ha autorizado {frm.permiso.ToUpper()} Correctamente","Advertencia");

                    }
                    else
                    {
                        viewDetalle.Columns[3].Visible = false;
                        look_precio.ReadOnly = true;
                        viewDetalle.Columns[3].OptionsColumn.AllowEdit = false;
                        viewDetalle.Columns[3].OptionsColumn.AllowFocus = false;
                        persona_autoriza = 0;
                        XtraMessageBox.Show($"No se ha Autorizado la operacion {frm.permiso.ToUpper()}","Información");
                    }
                }
                else
                {
                    XtraMessageBox.Show($"Esta Factura está marcada para llevar precio libre, es decir vendedor puede editar el precio discreción.","Información");
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void look_precio_SelectedIndexChanged(object sender,EventArgs e)
        {
            var cliente = Negocio.ClasesCN.CatalogosCN.Cliente_SelectFila(Convert.ToInt32(lookUpEdit_Cliente.EditValue)).FirstOrDefault();

            if (!cotizacion)
            {
                if (look_precio.EditValue != null)
                {
                    for (int i = 0; i < viewDetalle.RowCount; i++)
                    {
                        viewDetalle.SetRowCellValue(i, col_tipo_precio, look_precio.SelectedIndex + 1);
                        int id_producto = Convert.ToInt32(viewDetalle.GetRowCellValue(i, "id_producto"));
                        decimal precio = Negocio.ClasesCN.InventarioCN.Precio_De_Producto(look_precio.SelectedIndex + 1, id_producto);

                        if (precio == 0.00M)
                        {
                            precio = Negocio.ClasesCN.InventarioCN.Precio_De_Producto(Convert.ToInt32(cliente.precio), id_producto);
                        }

                        viewDetalle.SetRowCellValue(i, "precio1", precio);
                    }

                    viewDetalle.UpdateSummary();
                    if (vTipoVenta != 2)
                        viewDetalle.UpdateTotalSummary();
                }
            }

            cotizacion = false;
        }

        private void check_lleva_bordado_CheckedChanged(object sender,EventArgs e)
        {
            try
            {
                if(check_precio_libre.Checked)
                {
                    itera_cantidades();
                    viewDetalle.Columns["precio1"].OptionsColumn.AllowEdit = true;
                    viewDetalle.Columns["precio1"].OptionsColumn.AllowFocus = true;
                    viewDetalle_RowUpdated(null,null);
                }
                else
                {
                    viewDetalle.Columns["precio1"].OptionsColumn.AllowEdit = false;
                    viewDetalle.Columns["precio1"].OptionsColumn.AllowFocus = false;
                    viewDetalle_RowUpdated(null,null);
                }

            }
            catch(Exception ex)
            {

                throw;
            }

        }

        private void viewDetalle_ShowingEditor(object sender,CancelEventArgs e)
        {
           
            if (!check_precio_libre.Checked)
            {
                GridView view = sender as GridView;
                if(Es_Servicio(view,view.FocusedRowHandle))
                {
                    view.Columns["precio1"].OptionsColumn.AllowFocus = true;
                    view.Columns["precio1"].OptionsColumn.AllowEdit = true;
                    if(view.FocusedColumn.FieldName == "tipo_producto" && !Es_Servicio(view,view.FocusedRowHandle))
                        e.Cancel = true;
                }
                else
                {
                    view.Columns["precio1"].OptionsColumn.AllowFocus = false;
                    view.Columns["precio1"].OptionsColumn.AllowEdit = false;
                    if(view.FocusedColumn.FieldName == "tipo_producto" && !Es_Servicio(view,view.FocusedRowHandle))
                        e.Cancel = true;
                }
            }
        }

        private void look_moneda_EditValueChanged(object sender, EventArgs e)
        {
            bindingSourceCliente.DataSource = Negocio.ClasesCN.CatalogosCN.Cliente_Cargar();
            //   lookUpEdit_Bodega.EditValue = Negocio.ClasesCN.CatalogosCN.Bodega_Cargar().Where(B => B.nombre.ToUpper() == Presentacion.Properties.Settings.Default.Bodega_Venta.ToUpper()).FirstOrDefault().id;
            look_representante.Properties.DataSource = Negocio.ClasesCN.CatalogosCN.Representantes_Cargar();
            vTipoCambio = Negocio.ClasesCN.DatosRequeridosCN.obtener_tipo_cambio_mensual();
            repositoryItemLookUpEdit_Producto.DataSource =  Negocio.ClasesCN.InventarioCN.Kardex_SelectVentaEXC().Where(x => x.id_bodega == int.Parse(lookUpEdit_Bodega.EditValue.ToString()) /*&& x.moneda == Convert.ToInt32(look_moneda.EditValue)*/).ToList();
            bindingSourceDetalle.DataSource = null;
            bindingSourceDetalle.DataSource = getTable();
            gridVenta.DataSource = bindingSourceDetalle;
            txt_tipo_cambio_mes.EditValue = vTipoCambio;
            calculo_total();
        }

        private void txtDescuentoMonto_Validated(object sender, EventArgs e)
        {
            //try
            //{
            //    var monto = viewDetalle.Columns["precio1"].SummaryItem.SummaryValue;
            //    var vDescuento = txtDescuentoMonto.EditValue;
            //    txtDescuentoPorcentaje.EditValue = (decimal.Parse(vDescuento.ToString()) / decimal.Parse(monto.ToString())) * 100;
            //    txtDescuentoPorcentaje_Validated(null, null);
            //}
            //catch (Exception) { }
        }

        private void lookUpEdit_Terminos_Properties_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Tag.ToString() == "2")
            {
                int count = Negocio.ClasesCN.ParametrosCN.Terminos_Select().Count;
                var form = new CuentasCobrar.xftm_nuevo_termino();
                form.ShowDialog();
                int count_nuevo = Negocio.ClasesCN.ParametrosCN.Terminos_Select().Count;
                lookUpEdit_Terminos.Properties.DataSource = Negocio.ClasesCN.ParametrosCN.Terminos_Select();
                if (count != count_nuevo)
                {
                    int max = Negocio.ClasesCN.ParametrosCN.Terminos_Select().Max(x => x.id);
                    lookUpEdit_Terminos.EditValue = max;
                }
            }
        }

        private void chk_1_CheckedChanged(object sender, EventArgs e)
        {
            calculo_total();
        }

        private void chk_2_CheckedChanged(object sender, EventArgs e)
        {
            calculo_total();
        }

        //private void chk_1_Click(object sender, EventArgs e)
        //{
        //    if (chk_1.ReadOnly)
        //    {
        //        string vNombre = lookUpEdit_Cliente.Text;
        //        if (!Negocio.ClasesCN.RolesPermisosCN.Permisos(Clases.UsuarioLogueado.vID_Empleado, 11140))
        //        {
        //            var FAutorizacion = new xfrm_autorizacion("AGREGAR RETENCION 1% A FACTURA DEL CLIENTE" + vNombre);
        //            FAutorizacion.numero_permiso = 11140;
        //            FAutorizacion.permiso = "AGREGAR RETENCION 1% A FACTURA";
        //            FAutorizacion.ShowDialog();

        //            if (FAutorizacion.Autorizado)
        //            {

        //                chk_1.ReadOnly = false;

        //            }
        //            else
        //            {

        //                chk_1.ReadOnly = true;
        //                XtraMessageBox.Show("La acción de " + FAutorizacion.permiso + " no fue autorizada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);

        //            }
        //        }
        //    }
        //}

        //private void chk_2_Click(object sender, EventArgs e)
        //{
        //    if (chk_2.ReadOnly)
        //    {
        //        string vNombre = lookUpEdit_Cliente.Text;
        //        if (!Negocio.ClasesCN.RolesPermisosCN.Permisos(Clases.UsuarioLogueado.vID_Empleado, 11141))
        //        {
        //            var FAutorizacion = new xfrm_autorizacion("AGREGAR RETENCION 2% A FACTURA DEL CLIENTE" + vNombre);
        //            FAutorizacion.numero_permiso = 11141;
        //            FAutorizacion.permiso = "AGREGAR RETENCION 2% A FACTURA";
        //            FAutorizacion.ShowDialog();

        //            if (FAutorizacion.Autorizado)
        //            {

        //                chk_2.ReadOnly = false;

        //            }
        //            else
        //            {

        //                chk_2.ReadOnly = true;
        //                XtraMessageBox.Show("La acción de " + FAutorizacion.permiso + " no fue autorizada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);

        //            }
        //        }
        //    }
        //}

        private void blbi_Actualizar_Productos_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(typeof(Principal.WaitForm1));
            repositoryItemLookUpEdit_Producto.DataSource = Negocio.ClasesCN.InventarioCN.Kardex_SelectVentaEXC().Where(x => x.id_bodega == int.Parse(lookUpEdit_Bodega.EditValue.ToString()) && x.moneda == Convert.ToInt32(look_moneda.EditValue)).ToList();
            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm();
        }

        private void txtDescuentoPorcentaje_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                viewDetalle.UpdateCurrentRow();
                viewDetalle.Focus();
            }
        }

        private void repositorio_cmbx_precios_EditValueChanged(object sender, EventArgs e)
        {
            ImageComboBoxEdit edit = (ImageComboBoxEdit)sender;
            object editValue = edit.EditValue;
            int tipo = Convert.ToInt32(editValue);
            int id_producto = Convert.ToInt32(viewDetalle.GetFocusedRowCellValue("id_producto"));
            decimal precio = Negocio.ClasesCN.InventarioCN.Precio_De_Producto(tipo, id_producto);
            viewDetalle.SetRowCellValue(viewDetalle.FocusedRowHandle, "precio1", precio);
        }

        private void precioEspecial()
        {
            //Valido si el usuario tiene los permisos de ver el precio
            Clases.UsuarioLogueado.precioEspecial(null, repositoryItemLookUpEdit_Producto, IDempleado);
        }
        public void actualizarFilas()
        {
            try
            {

                viewDetalle.UpdateSummary();

                if (!check_precio_libre.Checked)
                {
                    if (look_precio.ReadOnly)
                    {
                        Dictionary<string, int> categoria_Cantidad = new Dictionary<string, int>();

                        for (int i = 0; i < viewDetalle.RowCount; i++)
                        {
                            string categoria = Convert.ToString(viewDetalle.GetRowCellValue(i, viewDetalle.Columns["categoria"]));
                            int cantidad = Convert.ToInt32(viewDetalle.GetRowCellValue(i, viewDetalle.Columns["cantidad"]));
                            if (categoria_Cantidad.ContainsKey(categoria))
                            {
                                categoria_Cantidad[categoria] += cantidad;
                            }
                            else
                            {
                                categoria_Cantidad.Add(categoria, cantidad);
                            }
                        }
                        foreach (var CC in categoria_Cantidad)
                        {
                            if (CC.Value < 6)
                            {
                                for (int i = 0; i < viewDetalle.RowCount; i++)
                                {
                                    int id_producto = Convert.ToInt32(viewDetalle.GetRowCellValue(i, "id_producto"));
                                    string categoria = Convert.ToString(viewDetalle.GetRowCellValue(i, "categoria"));
                                    if (CC.Key == categoria)
                                    {
                                        if (!Es_Servicio(viewDetalle, i))
                                        {
                                            decimal precio = Negocio.ClasesCN.InventarioCN.Precio_De_Producto(3, id_producto);
                                            viewDetalle.SetRowCellValue(i, "precio1", precio);
                                            tipo_precio = 3;

                                        }
                                    }
                                }
                            }
                            else
                            {
                                for (int i = 0; i < viewDetalle.RowCount; i++)
                                {
                                    int id_producto = Convert.ToInt32(viewDetalle.GetRowCellValue(i, "id_producto"));
                                    string categoria = Convert.ToString(viewDetalle.GetRowCellValue(i, "categoria"));
                                    if (CC.Key == categoria)
                                    {
                                        if (!Es_Servicio(viewDetalle, i))
                                        {
                                            decimal precio = Negocio.ClasesCN.InventarioCN.Precio_De_Producto(look_precio.SelectedIndex + 1, id_producto);
                                            viewDetalle.SetRowCellValue(i, "precio1", precio);
                                            tipo_precio = look_precio.SelectedIndex + 1;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else { tipo_precio = 7; }
                calculo_total();
                viewDetalle.UpdateTotalSummary();
            }
            catch (Exception ex) { }
        }
    }
}