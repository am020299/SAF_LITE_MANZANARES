using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraReports.UI;
using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace Presentacion.Formularios.Ventas
{
    public partial class xfrm_productos_mas_vendidos : DevExpress.XtraEditors.XtraForm
    {
        DateTime f_ini, f_fin;

        public xfrm_productos_mas_vendidos()
        {
            InitializeComponent();

            //date_hasta.EditValue = new DateTime(2020, 07, 30);
            //date_desde.EditValue = new DateTime(2020, 07, 01);

            date_hasta.EditValue = DateTime.Now;
            date_desde.EditValue = DateTime.Now.AddDays(-7);

            carga_datos();
        }

        public void carga_datos()
        {
            f_ini = Convert.ToDateTime(date_desde.EditValue).Date;
            f_fin = Convert.ToDateTime(date_hasta.EditValue).Date;
            var verficaOk = VerificaRangoFecha(f_ini, f_fin);

            if (!verficaOk.Item1)
            {
                XtraMessageBox.Show("Lo sentimos, pero " + verficaOk.Item2, "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                var query = Negocio.ClasesCN.VentasCN.Productos_mas_Vendidos_Rango(f_ini, f_fin);
                binding_datos.DataSource = query;

                grid_datos.DataSource = query;

                view_datos.BestFitColumns();
                view_detalle.BestFitColumns();
            }

            view_datos.Columns["cantidad_vendida"].GroupIndex = -1;
            view_datos.Columns["nombre"].GroupIndex = -1;

            view_datos.Columns["nombre"].SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom;
            view_datos.CustomColumnSort += OrdenColumnaPersonalizada;

            view_datos.Columns["nombre"].SortOrder = DevExpress.Data.ColumnSortOrder.Descending;
            view_datos.SortInfo.Add(new GridColumnSortInfo(view_datos.Columns["nombre"], DevExpress.Data.ColumnSortOrder.Ascending));
            view_datos.Columns["nombre"].GroupIndex = 0;
            view_datos.ExpandAllGroups();
        }

        private Tuple<bool, string> VerificaRangoFecha(DateTime date1, DateTime date2)
        {
            int result = DateTime.Compare(date1, date2);
            string menseaje = "";
            bool vRetorno = false;

            if (result < 0)
            {
                //"date1 es menor a date2";
                vRetorno = true;
            }
            else if (result == 0)
            {
                //"date1 es el mismo que date2";
                vRetorno = true;
            }
            else
            {
                //"date1 es mayor a date2";
                menseaje = "Fecha inicial no puede ser mayor a la final";
                vRetorno = false;
            }

            return Tuple.Create(vRetorno, menseaje);
            //Console.WriteLine("{0} {1} {2}", date1, relationship, date2);            
        }

        void OrdenColumnaPersonalizada(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnSortEventArgs e)
        {
            decimal first = Convert.ToDecimal(view_datos.GetListSourceRowCellValue(e.ListSourceRowIndex1, view_datos.Columns["cantidad_vendida"]));
            decimal second = Convert.ToDecimal(view_datos.GetListSourceRowCellValue(e.ListSourceRowIndex2, view_datos.Columns["cantidad_vendida"]));

            if (first < second)
                e.Result = -1;
            else
                if (first > second)
                e.Result = 1;
            else
                e.Result = 0;

            e.Handled = true;
        }

        private void bbi_reporte_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            f_ini = Convert.ToDateTime(date_desde.EditValue).Date;
            f_fin = Convert.ToDateTime(date_hasta.EditValue).Date;

            //binding_datos.DataSource = Negocio.ClasesCN.VentasCN.Top10ProductosMasVendidos_Rango(20, f_ini, f_fin);
            DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(typeof(Principal.WaitForm1));
            binding_datos.DataSource = Negocio.ClasesCN.VentasCN.Productos_mas_Vendidos_Rango(f_ini, f_fin);

            var reporte = new Reportes.Ventas.xrpt_productos_mas_vendidos(binding_datos);
            reporte.Parameters[0].Value = f_ini;
            reporte.Parameters[1].Value = f_fin;

            reporte.Parameters[0].Visible = false;
            reporte.Parameters[1].Visible = false;

            reporte.ShowPreview();
            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm();
        }

        private void imprimirDetalleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f_ini = Convert.ToDateTime(date_desde.EditValue).Date;
            f_fin = Convert.ToDateTime(date_hasta.EditValue).Date;
            int id_producto = Convert.ToInt32(view_datos.GetFocusedRowCellValue("id_producto"));

            DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(typeof(Principal.WaitForm1));
            binding_detalle.DataSource = Negocio.ClasesCN.VentasCN.Detalle_producto_vendido(f_ini, f_fin, id_producto);

            var reporte = new Reportes.Ventas.xrpt_Detalle_Producto_Vendido(binding_detalle);
            reporte.Parameters[0].Value = f_ini;
            reporte.Parameters[1].Value = f_fin;

            reporte.Parameters[0].Visible = false;
            reporte.Parameters[1].Visible = false;

            reporte.ShowPreview();
            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm();
        }

        private void bbiExportExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (grid_datos != null)
                    new Clases.Exportar().Exportar_Grid_A_Excel(grid_datos);
                else XtraMessageBox.Show("Lo sentimos, pero no hay datos que exportar", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Ha ocurrido el siguiente error, comunicarse con soporte ténico", "Error del sistema: \n" + ex, MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void exportarAExcelDetalleDelProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (grid_detalle != null)
                    new Clases.Exportar().Exportar_Grid_A_Excel(grid_detalle);
                else XtraMessageBox.Show("Lo sentimos, pero no hay datos que exportar", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Ha ocurrido el siguiente error, comunicarse con soporte ténico", "Error del sistema: \n" + ex, MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void bbi_cargar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { carga_datos(); }

        private void xfrm_productos_mas_vendidos_Load(object sender, EventArgs e) 
        {
            view_datos.OptionsView.ShowFooter = false;
            dockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
            bool cargar_total_kardex = Negocio.ClasesCN.RolesPermisosCN.Permisos(Clases.UsuarioLogueado.vID_Empleado, 11166);
            if(cargar_total_kardex || Clases.UsuarioLogueado.admin)
            {
                view_datos.OptionsView.ShowFooter = true;
                dockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Visible;
            }
            carga_datos();  
        }

        private void date_desde_Properties_EditValueChanged(object sender, EventArgs e) { carga_datos(); }

        private void date_hasta_Properties_EditValueChanged(object sender, EventArgs e) { carga_datos(); }

        CultureInfo ciUSA = new CultureInfo("en-US");
        CultureInfo ciNIC = new CultureInfo("es-NI", false);

        private void view_datos_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "total_venta" && e.ListSourceRowIndex != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
            {
                int tipoMoneda = (int)view_datos.GetListSourceRowCellValue(e.ListSourceRowIndex, "moneda");
                decimal total = Convert.ToDecimal(e.Value);

                switch (tipoMoneda)
                {
                    case 1:
                        e.DisplayText = string.Format(ciNIC, "{0:c}", total);
                        break;
                    case 2:
                        e.DisplayText = string.Format(ciUSA, "{0:c}", total);
                        break;
                }
            }
        }

        private void view_datos_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            f_ini = Convert.ToDateTime(date_desde.EditValue).Date;
            f_fin = Convert.ToDateTime(date_hasta.EditValue).Date;
            int id_producto = Convert.ToInt32(view_datos.GetFocusedRowCellValue("id_producto"));
            string vCodigo = Convert.ToString(view_datos.GetFocusedRowCellValue("codigo"));

            view_detalle.ViewCaption = vCodigo;
            dockPanel1.Text = "Detalle del Producto [Código: " + view_datos.GetFocusedRowCellDisplayText("codigo") + "]";
            grid_detalle.DataSource = Negocio.ClasesCN.VentasCN.Detalle_producto_vendido(f_ini, f_fin, id_producto);
        }

        private void bbi_exportar_detalle_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (grid_detalle != null)
                    new Clases.Exportar().Exportar_Grid_A_Excel(grid_detalle);
                else XtraMessageBox.Show("Lo sentimos, pero no hay datos que exportar", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Ha ocurrido el siguiente error, comunicarse con soporte ténico", "Error del sistema: \n" + ex, MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void view_detalle_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "total_dolares" && e.ListSourceRowIndex != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
            {
                decimal total = Convert.ToDecimal(e.Value);
                e.DisplayText = string.Format("${0:n2}", total);
            }

            if (e.Column.FieldName == "total_cordoba" && e.ListSourceRowIndex != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
            {
                decimal total = Convert.ToDecimal(e.Value);
                e.DisplayText = string.Format("C${0:n2}", total);
            }
        }
    }
}