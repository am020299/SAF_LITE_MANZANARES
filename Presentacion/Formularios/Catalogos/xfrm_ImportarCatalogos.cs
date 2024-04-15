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
using Entidades;
using System.Drawing.Drawing2D;
using System.IO;
using DPFP.Capture;
using DPFP;
using System.Text.RegularExpressions;
using System.Drawing.Imaging;
using DevExpress.XtraEditors.Camera;
using DevExpress.XtraNavBar.ViewInfo;

namespace Presentacion.Formularios.Catalogos
{
    public partial class xfrm_ImportarCatalogos:XtraForm
    {
        decimal tipo_cambio_dia = 0, tipo_cambio_mensual = 0;
        public xfrm_ImportarCatalogos( )
        {
            InitializeComponent();
        }

        private void xfrm_ImportarCatalogos_FormClosing(object sender,FormClosingEventArgs e)
        {
            this.Dispose();
        }

        private void navBarControl1_CustomDrawLink(object sender,DevExpress.XtraNavBar.ViewInfo.CustomDrawNavBarElementEventArgs e)
        {
            //DevExpress.XtraNavBar.NavBarItemLink link = ((NavLinkInfoArgs)e.ObjectInfo).Link;
            //if (link.State == DevExpress.Utils.Drawing.ObjectState.Selected)
            //{
            //    e.Graphics.FillRectangle(Brushes.Orange, e.RealBounds);
            //}
        }
        private void Mostrar_Pagina(int tap)//1:Cuentas
        {
            standaloneBarDockControl1.Visible = true;
            progressBarControl1.Visible = true;
            xtrab_control1.Visible = true;
            switch(tap)
            {
                case 1:
                    //
                    bar2.Visible = progressBarControl1.Visible = true;
                    tabProducto.PageVisible = true;
                    tabTipoCambio.PageVisible = false;
                    btnCrearPlantilla.Enabled = true;
                    bbiCargarBCN.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    comboBoxEditMes.Visible = false;
                    fecha_compra.DateTime = DateTime.Now.Date;
                    look_proveedor.Properties.DataSource = Negocio.ClasesCN.CatalogosCN.Proveedores_Select();

                    break;
                case 2:
                    //
                    bar2.Visible = progressBarControl1.Visible = true;
                    tabProducto.PageVisible = false;
                    tabTipoCambio.PageVisible = true;
                    btnCrearPlantilla.Enabled = true;
                    bbiCargarBCN.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    //DateTime fecha_servidor = Negocio.ClasesCN.Servidor_ActivoCN.Obtener_Fecha_Y_Hora_Del_Servidor_GETDATE();
                    //int mes = fecha_servidor.Month;
                    //int dia = fecha_servidor.Day;
                    //comboBoxEditMes.SelectedIndex = mes - 1;
                    comboBoxEditMes.Visible = true;
                    break;
                case 3:
                    //
                    tabProducto.PageVisible = false;
                    tabTipoCambio.PageVisible = false;
                    btnCrearPlantilla.Enabled = false;
                    bbiCargarBCN.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    bar2.Visible = progressBarControl1.Visible = false;
                    comboBoxEditMes.Visible = false;
                    Moneda.frmTipoCambioUnico fr = new Moneda.frmTipoCambioUnico();
                    fr.ShowDialog();
                    break;
            }
            progressBarControl1.EditValue = 0;
            progressBarControl1.Properties.ShowTitle = false;
        }
        private void Crear_Plantilla(string tap)//1:Cuentas
        {
            switch(tap)
            {
                case "tabProducto":
                    //Crear plantilla de grid de las cuentas
                    if(viewProducto_Export.RowCount == 0)
                        new Clases.Exportar().Exportar_Grid_A_Excel(gridProductos_Export);
                    break;
                case "tabTipoCambio":
                    //Crear plantilla de grid de las cuentas
                    if(viewTipoCambio.RowCount == 0)
                        new Clases.Exportar().Exportar_Grid_A_Excel(gridTipoCambio_Export);
                    break;
            }
        }
        private void Importar_Archivo(string tap)//1:Cuentas
        {
            switch(tap)
            {
                case "tabProducto":
                    //Importar archivo al grid de las cuentas
                    gridProductos.RefreshDataSource();
                    new Clases.Exportar().ImportarExcel_A_Grid(gridProductos);
                    break;
                case "tabTipoCambio":
                    //Importar archivo al grid de las cuentas
                    comboBoxEditMes.Visible = true;
                    gridTipoCambio.RefreshDataSource();
                    new Clases.Exportar().ImportarExcel_A_Grid(gridTipoCambio);
                    break;
            }
        }
        private void Guardar(string tap)//1:Cuentas
        {
            switch(tap)
            {
                case "tabProducto":
                    if(viewProducto.RowCount > 0)
                    {
                        DialogResult pregunta = XtraMessageBox.Show("¿Desea importar este archivo?", "Producto", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if(pregunta == DialogResult.Yes)
                            GuardarProducto();

                    }
                    break;
                case "tabTipoCambio":
                    if(viewTipoCambio.RowCount > 0)
                    {
                        DialogResult pregunta = XtraMessageBox.Show("¿Desea importar este archivo?", "Tipo de Cambio", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if(pregunta == DialogResult.Yes)
                            Agregar_Tipo_de_Cambio();
                    }
                    break;
            }
        }
        private void btnGuardar_ItemClick(object sender,DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Guardar(xtrab_control1.SelectedTabPage.Name);
        }
        private void btnCrearPlantilla_ItemClick(object sender,DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Crear_Plantilla(xtrab_control1.SelectedTabPage.Name);
        }
        private void btnImportar_ItemClick(object sender,DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Importar_Archivo(xtrab_control1.SelectedTabPage.Name);
            progressBarControl1.EditValue = 0;
            progressBarControl1.Properties.ShowTitle = false;
        }

        #region CONTABILIDAD
        private void ObtenerTipoCambioDia( )
        {
            tipo_cambio_dia = Negocio.ClasesCN.DatosRequeridosCN.Obtener_tipo_cambio_hoy();
            tipo_cambio_mensual = Negocio.ClasesCN.DatosRequeridosCN.obtener_tipo_cambio_mensual();
            Principal.xfrm_Principal frp = new Principal.xfrm_Principal();
            frp.barStaticItem_tipo_cambio.Caption = "Tipo Cambio Día: C$ " + Convert.ToString(tipo_cambio_dia) + " Tipo Cambio Mensual: C$" + Convert.ToString(tipo_cambio_mensual);
        }
        private void nbi_Productos_LinkClicked(object sender,DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Mostrar_Pagina(1);
        }

        private void nbiTipoCambio_LinkClicked(object sender,DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Mostrar_Pagina(2);
        }
        private void nbiTipoCambioUnico_LinkClicked(object sender,DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Mostrar_Pagina(3);
        }
        private void nbiTipoCambioMensual_LinkClicked(object sender,DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Mostrar_Pagina(3);
        }
        private bool Validar_Campos( )
        {
            bool retorno= false;
            if(look_proveedor.EditValue == null)
            {
                XtraMessageBox.Show("Debe de Seleccionar un proveedor");
                look_proveedor.Focus();

            }
            else if(txt_n_factura.Text == string.Empty)
            {
                XtraMessageBox.Show("Debe de colocar un numero de factura");
                look_proveedor.Focus();
            }
            else
                retorno = true;
            return retorno;
        }
        private void Agregar_Tipo_de_Cambio()
        {
            string vFecha = "";
            decimal vMonto = 0.00m;
            try
            {
                progressBarControl1.EditValue = 0;
                Cursor.Current = Cursors.WaitCursor;

                for (int i = 0; i < viewTipoCambio.RowCount; i++)
                {

                    progressBarControl1.Properties.Step = 1;
                    progressBarControl1.Properties.PercentView = true;
                    progressBarControl1.Properties.ShowTitle = true;
                    progressBarControl1.Properties.Maximum = viewTipoCambio.RowCount;
                    progressBarControl1.Properties.Minimum = 0;

                    vFecha = Convert.ToDateTime(viewTipoCambio.GetRowCellValue(i, viewTipoCambio.Columns[0]).ToString().Trim()).ToString("yyyy-MM-dd");
                    vMonto = Convert.ToDecimal(viewTipoCambio.GetRowCellValue(i, viewTipoCambio.Columns[1]).ToString().Trim());

                    int no_ok = 0;

                    if (!string.IsNullOrEmpty(vFecha.Trim().Replace(" ", "")) && vMonto > 0)
                    {
                        int ok_cuenta = Negocio.ClasesCN.DatosRequeridosCN.AgregaCambioContable(vFecha, vMonto);

                        if (ok_cuenta < 1)
                        {
                            no_ok++;
                        }
                    }

                    progressBarControl1.PerformStep();
                    progressBarControl1.Update();

                    if (i == (viewTipoCambio.RowCount - 1))
                        XtraMessageBox.Show("Importación completada con exito, " + (viewTipoCambio.RowCount) + " registros guardados, " + no_ok + " no guardados", "Tipo de Cambio", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception ex) { XtraMessageBox.Show("Lo sentimos, ocurrio un error al momento de agregar el tipo de cambio\nError: " + ex.Message, "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information); }

            Cursor.Current = Cursors.Default;

        }

        void LimpiarCamposCompras()
        {
            repositoryItemLookUpEdit_Categoria.DataSource = Negocio.ClasesCN.CatalogosCN.Categoria_Cargar();
            repositoryItemLookUpEdit_Linea.DataSource = Negocio.ClasesCN.CatalogosCN.Linea_Cargar();
            repositoryItemLookUpEdit_Marca.DataSource = Negocio.ClasesCN.CatalogosCN.Marca_Cargar();
            repositoryItemLookUpEdit_Moneda.DataSource = Negocio.ClasesCN.CatalogosCN.getMoneda();
            repositoryItemLookUpEdit_UM.DataSource = Negocio.ClasesCN.CatalogosCN.UnidadMedida_Cargar();

            txt_observaciones.EditValue = string.Empty;
            txt_n_factura.EditValue = string.Empty;
            fecha_compra.DateTime = DateTime.Now.Date;
            look_proveedor.EditValue = null;
        }

        private void GuardarProducto( )
        {
            string vCodigo = "";
            string vDescripcion = "";
            string vCategoria = "";
            string vMarca = "";
            string vLinea = "";
            string vUnidadMedida = "";
            string vMoneda = "";
            decimal vCosto = 0.00M;
            decimal vUtilidad = 0.00M;
            decimal vPrecio1 = 0.00M;
            decimal vPrecio2 = 0.00M;
            decimal vPrecio3 = 0.00M;
            decimal vPrecio4 = 0.00M;
            decimal vPrecio5 = 0.00M;
            decimal vPrecio6 = 0.00M;
            decimal vPrecio7 = 0.00M;
            decimal vPrecio8 = 0.00M;
            decimal vDescuento = 0.00M;
            decimal vImpuesto = 0.00M;
            decimal vStock = 0.00M;
            decimal vStockMinimo = 0.00M;
            string vNumeroSerie = "";
            string vlote = "";
            string vubicacion = "";
            string v_codigo_grupo=string.Empty;
            string v_codigo_subgrupo=string.Empty;
            string vNumero_factura = txt_n_factura.Text.Trim().ToUpper();
            //PictureEdit pe = new PictureEdit();
            //pe.EditValue = Presentacion.Properties.Resources.default_image_450;
            //MemoryStream ms = new MemoryStream();
            //try
            //{
            //    pe.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            //}
            //catch { }
            //byte[] vImagen = null;//ms.ToArray();
            if(Validar_Campos())
            {
                //ms.Close();
                try
                {

                    if (!checkEdit1.Checked)
                    {
                        var query_compra = Negocio.ClasesCN.ComprasCN.getCompras().Select(x => new { x.numero_factura });

                        foreach (var item in query_compra)
                        {
                            if (vNumero_factura == item.numero_factura)
                            {
                                XtraMessageBox.Show("Lo sentimos, el número de esta factura (" + vNumero_factura + ") ya existe ", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                    }

                    progressBarControl1.EditValue = 0;
                    progressBarControl1.Properties.Step = 1;
                    progressBarControl1.Properties.PercentView = true;
                    progressBarControl1.Properties.ShowTitle = true;
                    progressBarControl1.Properties.Minimum = 0;
                    Cursor.Current = Cursors.WaitCursor;


                    int ok = 0;
                    for(int i = 0;i < viewProducto.RowCount;i++)
                    {

                        progressBarControl1.Properties.Maximum = viewProducto.RowCount;


                        try { vCodigo = viewProducto.GetRowCellValue(i,"codigo").Equals(DBNull.Value) ? "" : Convert.ToString(viewProducto.GetRowCellValue(i,"codigo")).ToUpper().Trim(); } catch(Exception) { vCodigo = ""; }
                        try { vDescripcion = viewProducto.GetRowCellValue(i,"descripcion").Equals(DBNull.Value) ? "" : Convert.ToString(viewProducto.GetRowCellValue(i,"descripcion")).ToUpper().Trim(); } catch(Exception) { vDescripcion = ""; }
                        try { vCategoria = viewProducto.GetRowCellValue(i,"grupo").Equals(DBNull.Value) ? "" : Convert.ToString(viewProducto.GetRowCellValue(i,"grupo")); } catch(Exception) { vCategoria = ""; }
                        try { vMarca = viewProducto.GetRowCellValue(i,"marca").Equals(DBNull.Value) ? "" : Convert.ToString(viewProducto.GetRowCellValue(i,"marca")); } catch(Exception) { vMarca = ""; }
                        try { vLinea = viewProducto.GetRowCellValue(i,"subgrupo").Equals(DBNull.Value) ? "" : Convert.ToString(viewProducto.GetRowCellValue(i,"subgrupo")); } catch(Exception) { vLinea = ""; }
                        try { vUnidadMedida = viewProducto.GetRowCellValue(i,"unidad_medida").Equals(DBNull.Value) ? "" : Convert.ToString(viewProducto.GetRowCellValue(i,"unidad_medida")); } catch(Exception) { vUnidadMedida = ""; };
                        try { vMoneda = viewProducto.GetRowCellValue(i,"moneda").Equals(DBNull.Value) ? "" : Convert.ToString(viewProducto.GetRowCellValue(i,"moneda")); } catch(Exception) { vMoneda = ""; }
                        try { vCosto = viewProducto.GetRowCellValue(i,"costo").Equals(DBNull.Value) ? 0.00M : Convert.ToDecimal(viewProducto.GetRowCellValue(i,"costo")); } catch(Exception) { vCosto = 0.00M; }
                        try { vUtilidad = viewProducto.GetRowCellValue(i,"utilidad").Equals(DBNull.Value) ? 0.00M : Convert.ToDecimal(viewProducto.GetRowCellValue(i,"utilidad")); } catch(Exception) { vUtilidad = 0.00M; }
                        try { vPrecio1 = viewProducto.GetRowCellValue(i,"publicidad").Equals(DBNull.Value) ? 0.00M : Convert.ToDecimal(viewProducto.GetRowCellValue(i,"publicidad")); } catch(Exception) { vPrecio1 = 0.00M; }
                        try { vPrecio2 = viewProducto.GetRowCellValue(i,"eventual").Equals(DBNull.Value) ? 0.00M : Convert.ToDecimal(viewProducto.GetRowCellValue(i,"eventual")); } catch(Exception) { vPrecio2 = 0.00M; }
                        try { vPrecio3 = viewProducto.GetRowCellValue(i,"detalle").Equals(DBNull.Value) ? 0.00M : Convert.ToDecimal(viewProducto.GetRowCellValue(i,"detalle")); } catch(Exception) { vPrecio3 = 0.00M; }
                        try { vPrecio4 = viewProducto.GetRowCellValue(i,"precio4").Equals(DBNull.Value) ? 0.00M : Convert.ToDecimal(viewProducto.GetRowCellValue(i,"precio4")); } catch(Exception) { vPrecio4 = 0.00M; }
                        try { vPrecio5 = viewProducto.GetRowCellValue(i, "precio5").Equals(DBNull.Value) ? 0.00M : Convert.ToDecimal(viewProducto.GetRowCellValue(i, "precio5")); } catch (Exception) { vPrecio5 = 0.00M; }
                        try { vPrecio6 = viewProducto.GetRowCellValue(i, "precio6").Equals(DBNull.Value) ? 0.00M : Convert.ToDecimal(viewProducto.GetRowCellValue(i, "precio6")); } catch (Exception) { vPrecio6 = 0.00M; }
                        try { vPrecio7 = viewProducto.GetRowCellValue(i, "precio7").Equals(DBNull.Value) ? 0.00M : Convert.ToDecimal(viewProducto.GetRowCellValue(i, "precio7")); } catch (Exception) { vPrecio7 = 0.00M; }
                        try { vPrecio8 = viewProducto.GetRowCellValue(i, "precio8").Equals(DBNull.Value) ? 0.00M : Convert.ToDecimal(viewProducto.GetRowCellValue(i, "precio8")); } catch (Exception) { vPrecio8 = 0.00M; }
                        try { vDescuento = viewProducto.GetRowCellValue(i,"descuento").Equals(DBNull.Value) ? 0.00M : Convert.ToDecimal(viewProducto.GetRowCellValue(i,"descuento")); } catch(Exception) { vDescuento = 0.00M; }
                        try { vImpuesto = viewProducto.GetRowCellValue(i,"impuesto").Equals(DBNull.Value) ? 0.00M : Convert.ToDecimal(viewProducto.GetRowCellValue(i,"impuesto")); } catch(Exception) { vImpuesto = 15.00M; }
                        try { vStock = viewProducto.GetRowCellValue(i,"stock").Equals(DBNull.Value) ? 0.00M : Convert.ToDecimal(viewProducto.GetRowCellValue(i,"stock")); } catch(Exception) { vStock = 0.00M; }
                        try { vStockMinimo = viewProducto.GetRowCellValue(i,"stock_minimo").Equals(DBNull.Value) ? 0.00M : Convert.ToDecimal(viewProducto.GetRowCellValue(i,"stock_minimo")); } catch(Exception) { vStockMinimo = 0.00M; }
                        try { vNumeroSerie = viewProducto.GetRowCellValue(i,"numero_serie").Equals(DBNull.Value) ? "" : Convert.ToString(viewProducto.GetRowCellValue(i,"numero_serie")).ToUpper(); } catch(Exception) { vNumeroSerie = ""; }
                        try { vlote = viewProducto.GetRowCellValue(i,"lote").Equals(DBNull.Value) ? "" : Convert.ToString(viewProducto.GetRowCellValue(i,"lote")).ToUpper(); } catch(Exception) { vlote = "S/L"; }
                        try { vubicacion = viewProducto.GetRowCellValue(i,"ubicacion").Equals(DBNull.Value) ? "" : Convert.ToString(viewProducto.GetRowCellValue(i,"ubicacion")).ToUpper(); } catch(Exception) { vubicacion = "S/U"; }
                        try { v_codigo_grupo = viewProducto.GetRowCellValue(i,col_codigo_grupo).Equals(DBNull.Value) ? "" : Convert.ToString(viewProducto.GetRowCellValue(i,col_codigo_grupo)).ToUpper(); } catch(Exception) { v_codigo_grupo = ""; }
                        try { v_codigo_subgrupo = viewProducto.GetRowCellValue(i,col_codigo_subgrupo).Equals(DBNull.Value) ? "" : Convert.ToString(viewProducto.GetRowCellValue(i,col_codigo_subgrupo)).ToUpper(); } catch(Exception) { v_codigo_subgrupo = ""; }


                        if (!checkEdit1.Checked)
                        {
                            if (vCodigo != "" /*&& Clases.ClaseValidacionCampos.Validar_Formato_lote(vlote)*/ /*&& vCategoria != "" && vMarca != "" && vLinea != "" && vUnidadMedida != ""*/)
                            {
                                int numero = Convert.ToInt32(txt_numero.EditValue);
                                int ProductoOK = Negocio.ClasesCN.CatalogosCN.Importar_Productos(vCodigo, vDescripcion, vCategoria, vMarca, vLinea, vUnidadMedida, vMoneda, vCosto, vPrecio1, vPrecio2, vPrecio3, vPrecio4, vPrecio5, vPrecio6, vPrecio7, vPrecio8, vDescuento, vImpuesto, vStock, vStockMinimo, vNumeroSerie, numero, vlote, vubicacion, v_codigo_grupo, v_codigo_subgrupo, txt_n_factura.Text.Trim().ToUpper(), Convert.ToInt32(look_proveedor.EditValue ?? 0), fecha_compra.DateTime.Date, txt_observaciones.Text.Trim().ToUpper());
                                if (ProductoOK > 0)
                                {
                                    ok++;
                                    viewProducto.SelectRow(i);
                                }

                            }
                        }
                        else 
                        {
                            if (vCodigo != "")
                            {
                                int ProductoOK = Negocio.ClasesCN.CatalogosCN.Importar_Productos_catalogos(vCodigo, vDescripcion, vCategoria, vMarca, vLinea, vUnidadMedida, vMoneda, vCosto, vPrecio1, vPrecio2, vPrecio3, vPrecio4, vPrecio5, vPrecio6, vPrecio7, vPrecio8, vDescuento, vImpuesto, vStock, vStockMinimo, vNumeroSerie, 0, vlote, vubicacion, v_codigo_grupo, v_codigo_subgrupo);
                                if (ProductoOK > 0)
                                {
                                    ok++;
                                    viewProducto.SelectRow(i);
                                }
                            }
                              
                        }
                        progressBarControl1.PerformStep();
                        progressBarControl1.Update();
                    }

                    XtraMessageBox.Show("Importación completada con exito, " + ok + " registros guardados, " + (viewProducto.RowCount - ok) + " no guardados","Producto",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    LimpiarCamposCompras();
                }
                catch (Exception ex) { XtraMessageBox.Show("Lo sentimos, ocurrio un error al momento de agregar el tipo de cambio\nError: " + ex.Message,"Mensaje del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Information); }

            int[] filas = viewProducto.GetSelectedRows();
            if(filas.Length > 0) { viewProducto.DeleteSelectedRows(); }

            Cursor.Current = Cursors.Default;
            txt_numero.EditValue = Negocio.ClasesCN.CatalogosCN.proximo_numero_orden();
        }
        }
        #endregion
        private void xfrm_ImportarCatalogos_Load(object sender, EventArgs e)
        {
            repositoryItemLookUpEdit_Categoria.DataSource = Negocio.ClasesCN.CatalogosCN.Categoria_Cargar();
            repositoryItemLookUpEdit_Linea.DataSource = Negocio.ClasesCN.CatalogosCN.Linea_Cargar();
            repositoryItemLookUpEdit_Marca.DataSource = Negocio.ClasesCN.CatalogosCN.Marca_Cargar();
            repositoryItemLookUpEdit_Moneda.DataSource = Negocio.ClasesCN.CatalogosCN.getMoneda();
            repositoryItemLookUpEdit_UM.DataSource = Negocio.ClasesCN.CatalogosCN.UnidadMedida_Cargar();
            txt_numero.EditValue = Negocio.ClasesCN.CatalogosCN.proximo_numero_orden();
        }

        private void xfrm_ImportarCatalogos_Activated(object sender, EventArgs e)
        {
            repositoryItemLookUpEdit_Categoria.DataSource = Negocio.ClasesCN.CatalogosCN.Categoria_Cargar();
            repositoryItemLookUpEdit_Linea.DataSource = Negocio.ClasesCN.CatalogosCN.Linea_Cargar();
            repositoryItemLookUpEdit_Marca.DataSource = Negocio.ClasesCN.CatalogosCN.Marca_Cargar();
            repositoryItemLookUpEdit_Moneda.DataSource = Negocio.ClasesCN.CatalogosCN.getMoneda();
            repositoryItemLookUpEdit_UM.DataSource = Negocio.ClasesCN.CatalogosCN.UnidadMedida_Cargar();
        }

        private void checkEdit1_CheckedChanged(object sender,EventArgs e)
        {

        }

        private void barButtonItem2_ItemClick(object sender,DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new Clases.Exportar().Exportar_Grid_A_Excel(gridControl1);
        }

        private void bbiCargarBCN_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int vAno = DateTime.Now.Year;
            int vMes = DateTime.Now.Month;

            if (vMes == 12) if (DateTime.Now.Day > 25) if (comboBoxEditMes.SelectedIndex + 1 == 1) vAno += 1;

            gridTipoCambio.DataSource = Negocio.ClasesCN.DatosRequeridosCN.ObtenerCambioMensual(vAno, comboBoxEditMes.SelectedIndex + 1);
            
            viewTipoCambio.Columns[0].Caption = "Fecha";
            viewTipoCambio.Columns[1].Caption = "Córdobas por USD";
        }

      
    }
}