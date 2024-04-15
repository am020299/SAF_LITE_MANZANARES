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

namespace Presentacion.Formularios.Catalogos
{
    public partial class xfrm_Actualizar_precios : DevExpress.XtraEditors.XtraForm
    {
        public int vId_precio;
        public int vId_linea;
        public int vId_producto;
        public bool vRetorno = false;

        public xfrm_Actualizar_precios(int xId_linea, int xId_producto)
        {
            InitializeComponent();
            this.vId_linea = xId_linea;
            this.vId_producto = xId_producto;
            textNombre.ReadOnly = true;
            textCodigo.ReadOnly = true;

            if (xId_linea > 0 && xId_producto == 0) // Si es linea
            {
                var Precios_Linea = Negocio.ClasesCN.CatalogosCN.Get_precio_linea(xId_linea);

                textCodigo.Text = Precios_Linea.FirstOrDefault().codigo.ToString().ToUpper();
                textNombre.Text = Precios_Linea.FirstOrDefault().nombre.ToString().ToUpper();                
                bindingSourceLinea.DataSource = Precios_Linea;
                gridPrecios.DataSource = bindingSourceLinea;
            }
            else if (xId_linea > 0 && xId_producto > 0) // Si es producto
            {
                var Precios_Producto = Negocio.ClasesCN.CatalogosCN.Get_precio_producto(xId_producto);

                textCodigo.Text = Precios_Producto.FirstOrDefault().codigo.ToString().ToUpper();
                textNombre.Text = Precios_Producto.FirstOrDefault().descripcion.ToString().ToUpper();
                layoutControlItem6.Text = "DESCRIPCIÓN";
                bindingSourceProducto.DataSource = Precios_Producto;
                gridPrecios.DataSource = bindingSourceProducto;
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ViewPrecios.CloseEditor();
            ViewPrecios.UpdateCurrentRow();

            for (int i = 0; i < ViewPrecios.RowCount; i++)
            {
                decimal monto = Convert.ToDecimal(ViewPrecios.GetRowCellValue(i, "monto"));
                if (monto < 0)
                {
                    XtraMessageBox.Show("No puede dejar valores menor a 0, verifique los datos", "Actualización de Precios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (vId_linea > 0 && vId_producto == 0) // Si es linea
            {                
                if (XtraMessageBox.Show("¿Desea Actualizar estos precios?\n ¡Recuerde que al Modificar Precios, Los Pecios del Catálogo de Productos tambien serán Modificados respectivamente!", "Precios Sub-Grupo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) { return; }

                int okEditar = Negocio.ClasesCN.CatalogosCN.Actualiza_Precio_Linea(ViewPrecios);

                if (okEditar > 0)
                {
                    XtraMessageBox.Show("Datos modificados satisfactoriamente", "Precios Sub-grupo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    vRetorno = true;
                    this.Close();
                }
            }
            else if (vId_linea > 0 && vId_producto > 0) // Si es producto
            {
                var Precios_Producto = Negocio.ClasesCN.CatalogosCN.Get_precio_producto(vId_producto);
                if (XtraMessageBox.Show("¿Realmente desea Actualizar estos precios?\n ¡Recuerde que se modificará los precios de este producto al momento de realizar una venta nueva!", "Precios Productos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) { return; }

                int okEditar = Negocio.ClasesCN.CatalogosCN.Actualiza_Precio_Producto(ViewPrecios);

                if (okEditar > 0)
                {
                    XtraMessageBox.Show("Datos modificados satisfactoriamente", "Precios Producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    vRetorno = true;
                    this.Close();
                }
            }
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void ViewPrecios_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
        {
            GridView view = sender as GridView;
            try
            {
                decimal monto = view.GetFocusedRowCellValue("monto").Equals(DBNull.Value) ? 0 : Convert.ToDecimal(view.GetFocusedRowCellValue("monto"));
                switch (view.FocusedColumn.FieldName)
                {
                    case "monto":
                            if ((Convert.ToDecimal(e.Value) < 0.00m) || Convert.ToDecimal(e.Value) > 10000)
                            e.Valid = false;
                        break;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}