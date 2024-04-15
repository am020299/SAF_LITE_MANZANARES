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
using DevExpress.Utils;
using DevExpress.XtraReports.UI;

namespace Presentacion.Formularios.Compras
{
    public partial class xfrm_MostrarCompra : DevExpress.XtraEditors.XtraForm
    {
        public xfrm_MostrarCompra()
        {
            InitializeComponent();
            repositoryItemLookUpEdit_Estado.DataSource = getEstado();
        }

        public DataTable getEstado()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("estado");
            dt.Columns.Add("descripcion");
            DataRow row = dt.NewRow();

            row["estado"] = 1;
            row["descripcion"] = "SIN RECIBIR";
            dt.Rows.Add(row);
            row = dt.NewRow();

            row["estado"] = 2;
            row["descripcion"] = "RECIBIDO";
            dt.Rows.Add(row);
            row = dt.NewRow();

            return dt;
        }

        private void xfrm_MostrarCompra_Load(object sender, EventArgs e)
        {
            //bindingSourceCompras.DataSource = Negocio.ClasesCN.ComprasCN.Compras_Select();
            bbi_FechaInicio.EditValue = DateTime.Now.AddMonths(-1);
            bbi_FechaFin.EditValue = DateTime.Now;
            CargarDatos(Convert.ToDateTime(bbi_FechaInicio.EditValue), Convert.ToDateTime(bbi_FechaFin.EditValue));
        }

        void CargarDatos(DateTime FechaIni, DateTime FechaFin)
        {
            bindingSourceCompras.DataSource = Negocio.ClasesCN.ComprasCN.Compras_Select().Where(x => x.fecha >= FechaIni && x.fecha <= FechaFin);
        }

        private void xfrm_MostrarCompra_Activated(object sender, EventArgs e)
        {
            xfrm_MostrarCompra_Load(null, null);
        }

        private void viewCompras_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                return;

            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hitInfo = viewCompras.CalcHitInfo(e.Location);
            if (hitInfo.InDataRow)
            {
                //viewCompras.FocusedRowHandle = hitInfo.RowHandle;
                radialMenu1.ShowPopup(Control.MousePosition);
                //XtraMessageBox.Show(hitInfo.View.GetFocusedRowCellDisplayText("id"));
            }
        }
        public ICompras iCompras { get; set; }

        void Opciones(int i)
        {
            radialMenu1.HidePopup();
            switch (i)
            {
                case 1:
                    try
                    {
                        var form = new xfrm_NuevaCompra(0);
                        form.Text = "VER ORDEN DE COMPRA";
                        form.viewDetalle.OptionsBehavior.Editable = false;
                        form.btnGuardar.Enabled = false;
                        form.btnGuardarImprimir.Enabled = false;
                        form.MdiParent = this.MdiParent;
                        iCompras = form;
                        bool resultOK = iCompras.getCompras(Negocio.ClasesCN.ComprasCN.getCompras().Where(x => x.id == Convert.ToInt32(viewCompras.GetFocusedRowCellValue("id"))).ToList());
                        iCompras.getDetalleCompra(Negocio.ClasesCN.ComprasCN.getComprasDetalle(Convert.ToInt32(viewCompras.GetFocusedRowCellValue("id"))));
                        if (!resultOK) return;
                        form.Show();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    break;

                case 2:
                    try
                    {
                        var form = new xfrm_NuevaCompra(1);
                        form.Text = "EDITAR ORDEN DE COMPRA";
                        //form.viewDetalle.OptionsBehavior.Editable = false;
                        //form.btnGuardar.Enabled = false;
                        //form.btnGuardarImprimir.Enabled = false;
                        form.MdiParent = this.MdiParent;
                        iCompras = form;
                        bool resultOK = iCompras.getCompras(Negocio.ClasesCN.ComprasCN.getCompras().Where(x => x.id == Convert.ToInt32(viewCompras.GetFocusedRowCellValue("id"))).ToList());
                        iCompras.getDetalleCompra(Negocio.ClasesCN.ComprasCN.getComprasDetalle(Convert.ToInt32(viewCompras.GetFocusedRowCellValue("id"))));
                        if (!resultOK) return;
                        form.Show();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    break;

                case 3:
                    try
                    {
                        var form = new xfrm_NuevaCompra(0);
                        form.Text = "DUPLICAR ORDEN DE COMPRA";
                        //form.viewDetalle.OptionsBehavior.Editable = false;
                        //form.btnGuardar.Enabled = false;
                        //form.btnGuardarImprimir.Enabled = false;
                        form.MdiParent = this.MdiParent;
                        iCompras = form;
                        bool resultOK = iCompras.getCompras(Negocio.ClasesCN.ComprasCN.getCompras().Where(x => x.id == Convert.ToInt32(viewCompras.GetFocusedRowCellValue("id"))).ToList());
                        iCompras.getDetalleCompra(Negocio.ClasesCN.ComprasCN.getComprasDetalle(Convert.ToInt32(viewCompras.GetFocusedRowCellValue("id"))));
                        if (!resultOK) return;
                        form.Show();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    break;
            }
        }
        private void bbiVerOrden_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Opciones(1);
        }

        private void bbiEditarCompra_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Opciones(2);
        }

        private void bbiDuplicarCompra_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Opciones(3);
        }

        private void bbiEliminarCompra_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            radialMenu1.HidePopup();
            labelControl1.Text = "¿ Eliminar la Compra [Nº " + viewCompras.GetFocusedRowCellDisplayText("numero") + "] ?";
            
            flyoutPanel1.ShowBeakForm();
        }

        private void flyoutPanel1_ButtonClick(object sender, FlyoutPanelButtonClickEventArgs e)
        {
            string tag = e.Button.Tag.ToString();
            switch (tag)
            {
                case "aceptar":
                    (sender as FlyoutPanel).HidePopup();
                    if (Negocio.ClasesCN.ComprasCN.Compra_Eliminar(Convert.ToInt32(viewCompras.GetFocusedRowCellValue("id")), 0) > 0)
                    {
                        flyoutPanel2.ShowPopup();
                        xfrm_MostrarCompra_Activated(null, null);
                    }
                    break;
                case "cancelar":
                    // . . . 
                    (sender as FlyoutPanel).HidePopup();
                    break;
            }
        }
        
        private void bbiRecibirProducto_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                radialMenu1.HidePopup();
                int vId = Convert.ToInt32(viewCompras.GetFocusedRowCellValue("id"));
                var formRecibirProducto = new xfrm_RecibirProducto();
                iCompras = formRecibirProducto;
                bool resultOK = iCompras.getCompras(Negocio.ClasesCN.ComprasCN.getCompras().Where(x => x.id == vId).ToList());
                iCompras.getDetalleCompra(Negocio.ClasesCN.ComprasCN.getComprasDetalle(vId));
                if (!resultOK) return;
                formRecibirProducto.ShowDialog(this.FindForm());
                formRecibirProducto.Dispose();
                xfrm_MostrarCompra_Load(null, null);
            }
            catch (Exception)
            {
            }
        }

        private void radialMenu1_Popup(object sender, EventArgs e)
        {
            if (Convert.ToInt32(viewCompras.GetFocusedRowCellValue("estado")) == 2) bbiRecibirProducto.Enabled = bbiEliminarCompra.Enabled = bbiEditarCompra.Enabled = false;
            else bbiRecibirProducto.Enabled = bbiEliminarCompra.Enabled = bbiEditarCompra.Enabled = true;
        }
        private void bbiImprimir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int estado = Convert.ToInt32(viewCompras.GetFocusedRowCellValue("estado"));
            int id_compra = Convert.ToInt32(viewCompras.GetFocusedRowCellValue("id"));

            BindingSource source = new BindingSource();
          
            if (estado == 2)
            {
                //var report = new Reportes.Compras.OrdenCompra(2);
                //report.DataSource = Negocio.ClasesCN.ComprasCN.Compras_Reporte_Producto_recibido(id_compra);
                //report.ShowPreviewDialog();
                source.DataSource = Negocio.ClasesCN.ComprasCN.Compras_Reporte_Producto_recibido(id_compra);
                var report = new Reportes.Compras.OrdenCompra(source);
                report.ShowPreviewDialog();
                report.Dispose();
            }
            else
            {
                source.DataSource = Negocio.ClasesCN.ComprasCN.Compras_Reporte(id_compra);
                var report = new Reportes.Compras.OrdenCompra(source);
                report.ShowPreviewDialog();
                report.Dispose();
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CargarDatos(Convert.ToDateTime(bbi_FechaInicio.EditValue), Convert.ToDateTime(bbi_FechaFin.EditValue));
        }
    }
}