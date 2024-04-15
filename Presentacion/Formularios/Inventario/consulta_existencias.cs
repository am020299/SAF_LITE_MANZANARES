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

namespace Presentacion.Formularios.Inventario
{
    public partial class consulta_existencias:DevExpress.XtraEditors.XtraForm
    {
        public consulta_existencias( )
        {
            InitializeComponent();
        }
        DataTable getNivelStock( )
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id");
            dt.Columns.Add("descripcion");
            DataRow row = dt.NewRow();

            row["id"] = 1;//Mayor al stock
            row["descripcion"] = "MAYOR";
            dt.Rows.Add(row);
            row = dt.NewRow();

            row["id"] = 2;//Igual al stock
            row["descripcion"] = "IGUAL";
            dt.Rows.Add(row);
            row = dt.NewRow();

            row["id"] = 3;//Menor al stock
            row["descripcion"] = "MENOR";
            dt.Rows.Add(row);
            row = dt.NewRow();

            return dt;
        }
        private void Cargar( )
        {
            repositoryItemLookUpEditNivelStock.DataSource = getNivelStock();
            bindingSourceCategoria.DataSource = Negocio.ClasesCN.CatalogosCN.Categoria_Cargar();
            bindingSourceMarca.DataSource = Negocio.ClasesCN.CatalogosCN.Marca_Cargar();
            bindingSourceLinea.DataSource = Negocio.ClasesCN.CatalogosCN.Linea_Cargar();
            bindingSourceUnidadMedida.DataSource = Negocio.ClasesCN.CatalogosCN.UnidadMedida_Cargar();
          
            bindingSourceMoneda.DataSource = Negocio.ClasesCN.CatalogosCN.getMoneda();
          
            bindingSourceProductos.DataSource = Negocio.ClasesCN.CatalogosCN.Producto_Cargar().Where(P=>P.stock<=0 && P.tipo_producto==false && P.habilitado == true).OrderBy(O=>O.id);
            viewProductos.BestFitColumns();
            viewProductos.ClearColumnsFilter();
            viewProductos.ClearGrouping();
        }
        private void consulta_existencias_Load(object sender,EventArgs e)
        {
            Cargar();
        }

        private void gridProductos_Click(object sender,EventArgs e)
        {

        }

        private void bbi_refrescar_ItemClick(object sender,DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bindingSourceProductos.DataSource = Negocio.ClasesCN.CatalogosCN.Producto_Cargar().Where(P => P.stock <= 0 && P.tipo_producto == false && P.habilitado == true).OrderBy(O => O.id);
            gridProductos.DataSource = bindingSourceProductos;
        }

        private void bbi_reporte_ItemClick(object sender,DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bindingSourceProductos.DataSource = Negocio.ClasesCN.CatalogosCN.Producto_Cargar().Where(P => P.stock <= 0 && P.tipo_producto == false && P.habilitado == true).OrderBy(O => O.id);
            var Reporte = new Reportes.Inventario.xrpt_sin_existencias(bindingSourceProductos);
            Reporte.Parameters[0].Visible = false;
            Reporte.Parameters[0].Value = DateTime.Now.Date;
            Reporte.ShowPreview();

        }

        private void bbi_existencia_baja_ItemClick(object sender,DevExpress.XtraBars.ItemClickEventArgs e)
        {
            repositoryItemLookUpEditNivelStock.DataSource = getNivelStock();
            bindingSourceCategoria.DataSource = Negocio.ClasesCN.CatalogosCN.Categoria_Cargar();
            bindingSourceMarca.DataSource = Negocio.ClasesCN.CatalogosCN.Marca_Cargar();
            bindingSourceLinea.DataSource = Negocio.ClasesCN.CatalogosCN.Linea_Cargar();
            bindingSourceUnidadMedida.DataSource = Negocio.ClasesCN.CatalogosCN.UnidadMedida_Cargar();

            bindingSourceMoneda.DataSource = Negocio.ClasesCN.CatalogosCN.getMoneda();

            bindingSourceProductos.DataSource = Negocio.ClasesCN.CatalogosCN.Producto_Cargar().Where(P => P.stock <= P.stock_minimo && P.habilitado == true).OrderBy(O => O.id);
            viewProductos.BestFitColumns();
            viewProductos.ClearColumnsFilter();
            viewProductos.ClearGrouping();
        }

        private void reporte_existencia_baja_ItemClick(object sender,DevExpress.XtraBars.ItemClickEventArgs e)
        {

            bindingSourceProductos.DataSource = Negocio.ClasesCN.CatalogosCN.Producto_Cargar().Where(P => P.stock <= P.stock_minimo && P.tipo_producto==false && P.habilitado == true).OrderBy(O => O.id);
            var Reporte = new Reportes.Inventario.xrpt_producto_bajo_existencia(bindingSourceProductos);
            Reporte.Parameters[0].Visible = false;
            Reporte.Parameters[0].Value = DateTime.Now.Date;
            Reporte.ShowPreview();
        }

        private void bbi_exportar_excel_ItemClick(object sender,DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new Clases.Exportar().Exportar_Grid_A_Excel(gridProductos);
        }
    }
}