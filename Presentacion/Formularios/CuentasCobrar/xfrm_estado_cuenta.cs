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
using DevExpress.XtraReports.Parameters;

namespace Presentacion.Formularios.CuentasCobrar
{
    public partial class xfrm_estado_cuenta:DevExpress.XtraEditors.XtraForm
    {
        int id_cliente=0;
        DateTime Desde= DateTime.Now.AddDays(-30).Date;
        DateTime Hasta=DateTime.Now.Date;
        public xfrm_estado_cuenta(int id_cliente,DateTime desde,DateTime hasta)
        {
            InitializeComponent();
            this.id_cliente = id_cliente;
            this.Desde = desde;
            this.Hasta = hasta;
        }


        private void xfrm_estado_cuenta_Load(object sender,EventArgs e)
        {
            try
            {
                var Clientes = Negocio.ClasesCN.CuentasCobrarCN.CargarCliente_Select().ToList();
                binding_clients.DataSource = Clientes;
                search_clientes.Properties.DataSource = binding_clients;
                search_clientes.EditValue = this.id_cliente;
                dtp_desde.EditValue = Desde;
                dtp_hasta.EditValue = Hasta;
                grid_estado_cuenta.DataSource = Negocio.ClasesCN.CuentasCobrarCN.Estado_cuenta(this.id_cliente,dtp_desde.DateTime,dtp_hasta.DateTime).ToList(); // Crear procedimiento

            }
            catch(Exception ex )
            {

                Console.WriteLine(ex.Message.ToString());
            }
        }

        private void search_clientes_Properties_ButtonClick(object sender,DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

        }
        private void xfrm_estado_cuenta_Activated(object sender,EventArgs e)
        {
            try
            {
                grid_estado_cuenta.DataSource = Negocio.ClasesCN.CuentasCobrarCN.Estado_cuenta(this.id_cliente,dtp_desde.DateTime,dtp_hasta.DateTime).ToList();
     
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }

        private void bbi_cargar_ItemClick(object sender,DevExpress.XtraBars.ItemClickEventArgs e)
        {
            xfrm_estado_cuenta_Activated(null,null);
        }

        private void bbi_reporte_ItemClick(object sender,DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                Reportes.CuentasCobrar.xrpt_estado_cuenta Reporte= new Reportes.CuentasCobrar.xrpt_estado_cuenta();
                Reporte.fecha_inicio.Value = dtp_desde.DateTime.Date;
                Reporte.fecha_final.Value = dtp_hasta.DateTime.Date;
                DynamicListLookUpSettings clientes = new DynamicListLookUpSettings();
                clientes.DataSource = binding_clients;
                clientes.ValueMember = "id";
                clientes.DisplayMember = "nombre";
                clientes.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
                Reporte.id_cliente.LookUpSettings = clientes;
                Reporte.id_cliente.Value = Convert.ToInt32(search_clientes.EditValue ?? 0);
                Reporte.ShowPreview();
                Reporte.RequestParameters = false;

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }

        private void search_clientes_EditValueChanged(object sender,EventArgs e)
        {
            xfrm_estado_cuenta_Activated(null,null);
        }
    }
}