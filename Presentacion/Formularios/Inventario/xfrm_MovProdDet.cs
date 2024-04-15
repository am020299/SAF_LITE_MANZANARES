using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Formularios.Inventario
{
    public partial class xfrm_MovProdDet : DevExpress.XtraEditors.XtraForm
    {
        public xfrm_MovProdDet()
        {
            InitializeComponent();
        }

        void CargarDataSource()
        {
            repositoryItemSearchLookUpEditProducto.DataSource = Negocio.ClasesCN.CatalogosCN.Producto_Cargar();
            //gridControlDetalle.DataSource = Negocio.ClasesCN.ComprasCN.Compras_Select().Where(x => x.fecha >= FechaIni && x.fecha <= FechaFin).OrderByDescending(x => x.id);
        }

        void CargarDatosIniciales()
        {
            txt_totalVentas.Text = "0";
            date_Inicio.EditValue = DateTime.Now.AddMonths(-1);
            date_fin.EditValue = DateTime.Now;
        }

        private void bbi_Salir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void xfrm_MovProdDet_Load(object sender, EventArgs e)
        {
            CargarDataSource();
            CargarDatosIniciales();
        }

        private void bbi_Cargar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int id_producto = Convert.ToInt32(srch_producto.EditValue);
            DateTime fecha_ini = Convert.ToDateTime(date_Inicio.EditValue);
            DateTime fecha_fin = Convert.ToDateTime(date_fin.EditValue);

            var queryCompras = Negocio.ClasesCN.ComprasCN.Compras_Select_PRODUCTO(id_producto, fecha_ini, fecha_fin).OrderByDescending(x => x.id);
            var queryProducto = Negocio.ClasesCN.VentasCN.TotalVentasDetalleProducto(id_producto, fecha_ini, fecha_fin).FirstOrDefault();

            if (queryCompras != null)
            {
                gridControlDetalle.DataSource = queryCompras;
            }

            if(queryProducto != null)
            {
                txt_totalVentas.Text = Convert.ToInt32(queryProducto.cantidad).ToString();
            }
        }
    }
}