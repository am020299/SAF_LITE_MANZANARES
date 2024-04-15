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

namespace Presentacion.Formularios.Ventas
{
    public partial class xfrm_BuscarProducto : DevExpress.XtraEditors.XtraForm
    {
        private int _vIdBodega;
        public xfrm_BuscarProducto()
        {
            InitializeComponent();
        }

        public int vIdBodega { get => _vIdBodega; set => _vIdBodega = value; }

        private void xfrm_BuscarProducto_Load(object sender, EventArgs e)
        {
            bindingSourceProductos.DataSource = Negocio.ClasesCN.InventarioCN.Kardex_SelectVenta().Where(x => x.id_bodega == vIdBodega).ToList();
            gridView1.BestFitColumns();
        }

        internal IProducto IProd { get; set; }
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                string vCodigo = gridView1.GetFocusedRowCellValue("codigo").ToString();
                if (!string.IsNullOrEmpty(vCodigo.Replace(" ","")))
                {
                    if (IProd != null)
                    {
                        IProd.InsertarDetalle(vCodigo);
                        this.Close();
                    }
                }
            }
            catch (Exception) { }
        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    gridView1_DoubleClick(null, null);
                }
            }
            catch (Exception) { }
        }
    }
}