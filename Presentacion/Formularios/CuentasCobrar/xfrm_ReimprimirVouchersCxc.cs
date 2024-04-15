using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Formularios.CuentasCobrar
{
    public partial class xfrm_ReimprimirVouchersCxc : DevExpress.XtraEditors.XtraForm
    {
        public xfrm_ReimprimirVouchersCxc()
        {
            InitializeComponent();
        }

        private void xfrm_ReimprimirVouchersCxc_Load(object sender, EventArgs e)
        {
            gridControlDocumentos.DataSource = Negocio.ClasesCN.CuentasCobrarCN.Documentos_AplicadosCargar();
        }

        private void VertoolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id_documento = Convert.ToInt32(ViewDetalle.GetFocusedRowCellValue("id_documento"));
            string moneda = Convert.ToString(ViewDetalle.GetFocusedRowCellValue("moneda_factura"));
            var data = Negocio.ClasesCN.CuentasCobrarCN.Reporte_Documentos_Fila_Select(id_documento).FirstOrDefault();
            decimal monto_Neto;
            if(data.moneda == "CORDOBAS")
            {
                monto_Neto =  Convert.ToDecimal(Negocio.ClasesCN.CuentasCobrarCN.Reporte_Documentos_Fila_Select(id_documento).Sum(x => x.pago_abono));
            }
            else
            {
                monto_Neto = Convert.ToDecimal(Negocio.ClasesCN.CuentasCobrarCN.Reporte_Documentos_Fila_Select(id_documento).Sum(x => x.pago_abono)) * Convert.ToDecimal(data.tipo_cambio);
            }

            BindingSource Origen_Datos = new BindingSource();
            Origen_Datos.DataSource = Negocio.ClasesCN.CuentasCobrarCN.Reporte_Documentos_Fila_Select(id_documento).ToList();
            var Reporte = new Reportes.CuentasCobrar.xfrm_recibo_abono_termicoV2(Origen_Datos);
            Reporte.Cantidad_Letras.Value = Clases.numeros_a_letras.ToCardinal(Convert.ToDecimal(monto_Neto));
            Reporte.Cantidad_Letras.Visible = false;
            Reporte.parameter1.Visible = false;
            Reporte.parameter1.Value = id_documento;
            Reporte.ShowPreview();

        }

        private void reimprimirVoucherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id_documento = Convert.ToInt32(ViewDetalle.GetFocusedRowCellValue("id_documento"));
            string moneda = Convert.ToString(ViewDetalle.GetFocusedRowCellValue("moneda_factura"));
            var data = Negocio.ClasesCN.CuentasCobrarCN.Reporte_Documentos_Fila_Select(id_documento).FirstOrDefault();
            decimal monto_Neto;
            if (data.moneda == "DOLARES")
            {
                monto_Neto = Convert.ToDecimal(Negocio.ClasesCN.CuentasCobrarCN.Reporte_Documentos_Fila_Select(id_documento).Sum(x => x.pago_abono));
            }
            else
            {
                monto_Neto = Convert.ToDecimal(Negocio.ClasesCN.CuentasCobrarCN.Reporte_Documentos_Fila_Select(id_documento).Sum(x => x.pago_abono)) / Convert.ToDecimal(data.tipo_cambio);
            }

            BindingSource Origen_Datos = new BindingSource();
            Origen_Datos.DataSource = Negocio.ClasesCN.CuentasCobrarCN.Reporte_Documentos_Fila_Select(id_documento).ToList();
            var Reporte = new Reportes.CuentasCobrar.xfrm_recibo_abono_termicoV2Dolares(Origen_Datos);
            Reporte.Cantidad_Letras.Value = Clases.numeros_a_letras.ToCardinal(Convert.ToDecimal(monto_Neto));
            Reporte.Cantidad_Letras.Visible = false;
            Reporte.parameter1.Visible = false;
            Reporte.parameter1.Value = id_documento;
            Reporte.ShowPreview();
        }

        private void bbi_Actualizar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridControlDocumentos.DataSource = Negocio.ClasesCN.CuentasCobrarCN.Documentos_AplicadosCargar();
        }

        private void anularReciboToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id_documento = Convert.ToInt32(ViewDetalle.GetFocusedRowCellValue("id_documento"));
            var query = Negocio.ClasesCN.CuentasCobrarCN.AnularRecibo(id_documento);
            if(query > 0)
            {
                XtraMessageBox.Show("Recbio Anulado Correctamente", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                gridControlDocumentos.DataSource = Negocio.ClasesCN.CuentasCobrarCN.Documentos_AplicadosCargar();

            }
            else
            {
                XtraMessageBox.Show("Lo sentimos ocurrio un error. Este Recibo ya fue cancelado en Caja", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}