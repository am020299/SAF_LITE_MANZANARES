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
using System.Globalization;

namespace Presentacion.Formularios.Catalogos
{
    public partial class xfrm_verficar_Excel_importar : DevExpress.XtraEditors.XtraForm
    {
        DataTable dt = new DataTable();
        public xfrm_verficar_Excel_importar()
        {
            InitializeComponent();
            dt.Columns.Add("codigo");
            dt.Columns.Add("descripcion");
            dt.Columns.Add("stock");
            dt.Columns.Add("lote");
            dt.Columns.Add("ubicacion");
            dt.Columns.Add("verificado");

        }
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new Clases.Exportar().ImportarExcel_A_Grid(gridControl1);
            binding_Producto.DataSource = gridControl1.DataSource;
            gridControl1.DataSource = binding_Producto;
            //for(int i = 0;i < gview_verificacion.RowCount;i++)
            //{
            //    string v_codigo="";
            //    string lote="";
            //    string descripcion="";
            //    string ubicacion="";
            //    string verificado="";
            //    string stock="";


            //    try { v_codigo = gview_verificacion.GetRowCellValue(i,"codigo").Equals(DBNull.Value) ? "" : Convert.ToString(gview_verificacion.GetRowCellValue(i,"codigo")).ToUpper().Trim(); } catch(Exception) { v_codigo = ""; }
            //    try { lote = gview_verificacion.GetRowCellValue(i,"lote").Equals(DBNull.Value) ? "" : Convert.ToString(gview_verificacion.GetRowCellValue(i,"lote")).ToUpper().Trim(); } catch(Exception) { lote = ""; }
            //    try { descripcion = gview_verificacion.GetRowCellValue(i,"descripcion").Equals(DBNull.Value) ? "" : Convert.ToString(gview_verificacion.GetRowCellValue(i,"descripcion")).ToUpper().Trim(); } catch(Exception) { descripcion = ""; }
            //    try { ubicacion = gview_verificacion.GetRowCellValue(i,"ubicacion").Equals(DBNull.Value) ? "" : Convert.ToString(gview_verificacion.GetRowCellValue(i,"ubicacion")).ToUpper().Trim(); } catch(Exception) { ubicacion = ""; }
            //    try { verificado = gview_verificacion.GetRowCellValue(i,"verificado").Equals(DBNull.Value) ? "" : Convert.ToString(gview_verificacion.GetRowCellValue(i,"verificado")).ToUpper().Trim(); } catch(Exception) { verificado = ""; }
            //    try { stock = gview_verificacion.GetRowCellValue(i,"stock").Equals(DBNull.Value) ? "" : Convert.ToString(gview_verificacion.GetRowCellValue(i,"stock")).ToUpper().Trim(); } catch(Exception) { stock = ""; }

            //    DataRow Fila= dt.NewRow();
            //    Fila[0] = v_codigo;
            //    Fila[1] = descripcion;
            //    Fila[2] = stock;
            //    Fila[3] = lote;
            //    Fila[4] = ubicacion;
            //    Fila[5] = verificado;
            //    dt.Rows.Add(Fila);
            //}
            //gridControl1.DataSource = dt;
        }



        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridControl1.ForceInitialize();
            var Productos = Negocio.ClasesCN.CatalogosCN.Producto_Cargar().ToList();
            if (gview_verificacion.RowCount > 0)
            {
                progressBarControl1.EditValue = 0;
                progressBarControl1.Properties.Step = 1;
                progressBarControl1.Properties.PercentView = true;
                progressBarControl1.Properties.ShowTitle = true;
                progressBarControl1.Properties.Maximum = gview_verificacion.RowCount;
                progressBarControl1.Properties.Minimum = 0;

                for (int i = 0; i < gview_verificacion.RowCount; i++)
                {

                    string v_codigo = "";
                    string v_lote = "";
                    string v_stock = "";
                    string v_ubicacion = "";


                    try { v_codigo = gview_verificacion.GetRowCellValue(i, "codigo").Equals(DBNull.Value) ? "" : Convert.ToString(gview_verificacion.GetRowCellValue(i, "codigo")).ToUpper().Trim(); } catch (Exception) { v_codigo = ""; }
                    try { v_lote = gview_verificacion.GetRowCellValue(i, "lote").Equals(DBNull.Value) ? "" : Convert.ToString(gview_verificacion.GetRowCellValue(i, "lote")).ToUpper().Trim(); } catch (Exception) { v_lote = ""; }
                    try { v_stock = gview_verificacion.GetRowCellValue(i, "stock").Equals(DBNull.Value) ? "" : Convert.ToString(gview_verificacion.GetRowCellValue(i, "stock")).ToUpper().Trim(); } catch (Exception) { v_stock = ""; }
                    try { v_ubicacion = gview_verificacion.GetRowCellValue(i, "ubicacion").Equals(DBNull.Value) ? "" : Convert.ToString(gview_verificacion.GetRowCellValue(i, "ubicacion")).ToUpper().Trim(); } catch (Exception) { v_ubicacion = ""; }
                    if (Productos.Any(P => P.codigo == v_codigo) && v_lote != string.Empty && v_stock != string.Empty && v_ubicacion != string.Empty)
                    {
                        gview_verificacion.SetRowCellValue(i, "verificado", "CORRECTO");
                    }
                    else
                    {
                        gview_verificacion.SetRowCellValue(i, "verificado", "REVISAR");
                    }
                    progressBarControl1.PerformStep();
                    progressBarControl1.Update();

                }

            }

        }

        private void gview_verificacion_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            //GridView view = sender as GridView;
            //if (view.Name != "gview_verificacion") return;
            //if (!(view.IsDataRow(e.RowHandle))) return;
            //if (e.Column.FieldName == "verificado")
            //{
            //    if (e.CellValue != null)
            //    {
            //        if (e.CellValue.ToString() == "CORRECTO")
            //            e.Appearance.BackColor = Color.LightGreen;
            //        else
            //        {
            //            e.Appearance.BackColor = Color.LightPink;
            //        }

            //    }
            //}
            //if (e.Column.FieldName == "lote")
            //{
            //    if (e.CellValue != null)
            //    {
            //        if (Clases.ClaseValidacionCampos.Validar_Formato_lote(e.CellValue.ToString()))
            //            e.Appearance.BackColor = Color.LightGreen;
            //        else
            //            e.Appearance.BackColor = Color.LightPink;
            //    }
            //}

            GridView view = sender as GridView;
            if (view.Name != "gview_verificacion") return;
            if (!(view.IsDataRow(e.RowHandle))) return;
            if(e.RowHandle >= 0)
            {
                if(e.CellValue.ToString() == "CORRECTO")
                {
                    e.Appearance.BackColor = Color.LightGreen;
                }
                else
                {
                    e.Appearance.BackColor = Color.LightPink;
                }
            }
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new Clases.Exportar().Exportar_Grid_A_Excel(gridControl1);
        }
    }
}