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

namespace Presentacion.Formularios.Compras
{
    public partial class xfrm_RecibirProducto : DevExpress.XtraEditors.XtraForm, ICompras
    {
        private int _vIdCompra;

        public int vIdCompra { get => _vIdCompra; set => _vIdCompra = value; }

        public xfrm_RecibirProducto()
        {
            InitializeComponent();
        }

        private DataTable getTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id_bodega", typeof(int));
            dt.Columns.Add("id_lote",typeof(int));
            dt.Columns.Add("ubicacion", typeof(string));
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("descripcion", typeof(string));
            dt.Columns.Add("cantidad", typeof(decimal));
            dt.Columns.Add("id_unidad_medida", typeof(int));
            dt.Columns.Add("precio_nuevo", typeof(decimal));
         

            return dt;
        }

        public bool getCompras(List<Entidades.Compras> xCompras)
        {
            var query = xCompras.FirstOrDefault();
            if (query != null)
            {
                vIdCompra = query.id;
                txtNumeroFactura.Text = query.numero_factura;
                txtObservacion.Text = query.observacion;
                lookUpEdit_Proveedor.EditValue = query.id_proveedor;
                dateFecha.EditValue = query.fecha;
                dateFechaEstimada.EditValue = query.fecha_estimada;

                return true;
            }
            else { return false; }
        }

        public void getDetalleCompra(DataTable xDetalleCompra)
        {
            gridDetalle.DataSource = xDetalleCompra;
        }

        private void xfrm_RecibirProducto_Load(object sender, EventArgs e)
        {
            bindingSourceDetalle.DataSource = getTable();
            lookUpEdit_Proveedor.Properties.DataSource = Negocio.ClasesCN.CatalogosCN.getProveedores();
            repositoryItemLookUpEdit_Producto.DataSource = Negocio.ClasesCN.CatalogosCN.Producto_Cargar();
            repositoryItemLookUpEdit_Bodega.DataSource = lookUpEdit_Bodega.Properties.DataSource = Negocio.ClasesCN.CatalogosCN.Bodega_Cargar();
            repositoryItemLookUpEdit_UnidadMedida.DataSource = Negocio.ClasesCN.CatalogosCN.UnidadMedida_Cargar();
            repository_Lote.DataSource = look_Lotes.Properties.DataSource= Negocio.ClasesCN.CatalogosCN.Lotes_Cargar().ToList();
        }

        private void lookUpEdit_Bodega_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < viewDetalle.RowCount; i++)
                {
                    viewDetalle.SetRowCellValue(i, "id_bodega", lookUpEdit_Bodega.EditValue);
                }
            }
            catch (Exception)
            {
                
            }
        }
        bool Validar()
        {
            bool vRetorno = true;

            for (int i = 0; i < viewDetalle.RowCount; i++)
            {
                int bodega = Convert.ToInt32(viewDetalle.GetRowCellValue(i, "id_bodega"));
                if (bodega > 0) continue;
                else { vRetorno = false; viewDetalle.FocusedRowHandle = i; viewDetalle.SetColumnError(colBodega, "Campo requerido"); break; }
            }

            return vRetorno;
        }

        private void lookUpEdit_Proveedor_EditValueChanged(object sender, EventArgs e)
        {
            var query = Negocio.ClasesCN.CatalogosCN.Proveedores_Select().Where(x => x.id == Convert.ToInt32(lookUpEdit_Proveedor.EditValue)).FirstOrDefault();
            if (query != null)
            {
                txt_Tel.Text = query.telefono;
                txt_Ruc.Text = query.ruc;
                txt_Dir.Text = query.direccion;
            }
        }

        private void bbiGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Validar())
            {
                Clases.MyMessageBox.MessageFont = new Font(Clases.MyMessageBox.MessageFont.FontFamily, 24);
                if (Clases.MyMessageBox.Show("Desea Recibir esta Orden de Compra?", "Recibir Orden de Compra", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
                var recibirOK = Negocio.ClasesCN.ComprasCN.Compra_Recibir(vIdCompra, Clases.UsuarioLogueado.vID_Empleado, Convert.ToBoolean(toggleSwitch1.EditValue), Convert.ToDateTime(dateFecha.EditValue), txtNumeroFactura.Text, txtObservacion.Text, Clases.UsuarioLogueado.vID_Empleado, lookUpEdit_Proveedor.Text, viewDetalle);
                if (recibirOK.Item1)
                {
                    Clases.MyMessageBox.Show("Orden de Compra Recibida Correctamente", "Orden de Compra", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            else {}
        }

        private void look_Lotes_EditValueChanged(object sender,EventArgs e)
        {
            try
            {
                for(int i = 0;i < viewDetalle.RowCount;i++)
                {
                    viewDetalle.SetRowCellValue(i,col_id_lote,look_Lotes.EditValue);
                }
            }
            catch(Exception)
            {

            }
        }
    }
}