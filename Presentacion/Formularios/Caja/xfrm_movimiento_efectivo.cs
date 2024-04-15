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

namespace Presentacion.Formularios.Caja
{
    public partial class xfrm_movimiento_efectivo : DevExpress.XtraEditors.XtraForm
    {
        int id_empleado;
        public xfrm_movimiento_efectivo()
        {
            InitializeComponent();
            id_empleado = Clases.UsuarioLogueado.vID_Empleado;
        }
        private void cargar_datos_iniciales()
        {
            fecha_ejecucion.EditValue =fecha_final.EditValue= DateTime.Now.ToShortDateString();
            DateTime fecha = Convert.ToDateTime(fecha_ejecucion.EditValue);
            cargar_datos_movimiento(fecha);
            gridControl_movimiento_caja.Focus();
        }
        private void cargar_datos_movimiento_cordobas(DateTime fecha)
        {
            decimal saldo_inicial= Negocio.ClasesCN.CajaCN.saldo_inicial_del_dia(fecha);
            txt_saldo_inicial.EditValue = Negocio.ClasesCN.CajaCN.saldo_inicial_del_dia(fecha).ToString("n2");
            gridControl_movimiento_caja.DataSource = Negocio.ClasesCN.CajaCN.MOVIMIENTO_CAJA_MOSTRAR_CORDOBAS(fecha).ToList();
            if(Negocio.ClasesCN.CajaCN.CONSULTAR_SI_FECHA_ESTA_CERRADA(fecha))
            {
                btn_cerrar.Enabled = false;
                bbi_reporte.Enabled = bbi_reporte_detallado.Enabled = true;
            }
            else
            {
                bbi_reporte.Enabled = bbi_reporte_detallado.Enabled = false;
                if(gridView_movimiento.RowCount > 0)
                    btn_cerrar.Enabled = true;
                else
                    btn_cerrar.Enabled = false;
            }

            decimal ingresos= Decimal.Round(Convert.ToDecimal(gridView_movimiento.Columns["ingreso"].SummaryItem.SummaryValue), 2);
            decimal egresos = Decimal.Round(Convert.ToDecimal(gridView_movimiento.Columns["egreso"].SummaryItem.SummaryValue), 2);
            decimal total = ingresos - egresos + saldo_inicial;
            txt_saldo_final.EditValue = total.ToString("n2");
        }
        private void cargar_datos_movimiento(DateTime fecha)
        {
            decimal saldo_inicial= Negocio.ClasesCN.CajaCN.saldo_inicial_del_dia(fecha);
            txt_saldo_inicial.EditValue = Negocio.ClasesCN.CajaCN.saldo_inicial_del_dia(fecha).ToString("n2");
            gridControl_movimiento_caja.DataSource = Negocio.ClasesCN.CajaCN.MOVIMIENTO_CAJA_MOSTRAR(fecha).ToList();
            if (Negocio.ClasesCN.CajaCN.CONSULTAR_SI_FECHA_ESTA_CERRADA(fecha))
            {
                btn_cerrar.Enabled = false;
                bbi_reporte.Enabled = bbi_reporte_detallado.Enabled=true;
            }
            else
            {
                bbi_reporte.Enabled = bbi_reporte_detallado.Enabled = false;
                if(gridView_movimiento.RowCount>0)
                   btn_cerrar.Enabled = true;
                else
                    btn_cerrar.Enabled = false;
            }
                
            decimal ingresos= Decimal.Round(Convert.ToDecimal(gridView_movimiento.Columns["ingreso"].SummaryItem.SummaryValue), 2);
            decimal egresos = Decimal.Round(Convert.ToDecimal(gridView_movimiento.Columns["egreso"].SummaryItem.SummaryValue), 2);
            decimal total = ingresos - egresos + saldo_inicial;
            txt_saldo_final.EditValue = total.ToString("n2");
        }
        private void Reporte_Movimiento_Fecha(DateTime fecha)
        {
            BindingSource source = new BindingSource();
            source.DataSource = Negocio.ClasesCN.CajaCN.Reporte_de_Movimiento(fecha); 
            var report = new Reportes.Caja.ReporteMovimientoEfectivo(source);
            report.Parameters[0].Value = fecha;
            report.ShowPreviewDialog();
            report.Dispose();
        }
        private void Reporte_Movimiento_Detalle_Fecha(DateTime fecha)
        {
            BindingSource source = new BindingSource();
            source.DataSource = Negocio.ClasesCN.CajaCN.Reporte_de_Movimiento_Detallado(fecha);
            var report = new Reportes.Caja.Reporte_MovimientoDetallado(source);
            report.Parameters[0].Value = fecha;
            report.ShowPreviewDialog();
            report.Dispose();
        }
        private void Reporte_De_Egresos(DateTime fecha_ini, DateTime Fecha_fin)
        {
            BindingSource source = new BindingSource();
            source.DataSource = Negocio.ClasesCN.CajaCN.Reporte_de_Egresos(fecha_ini, Fecha_fin);
            var report = new Reportes.Caja.ReporteDeEgresos(source);
             report.Parameters[0].Value = fecha_ini;
             report.Parameters[1].Value = Fecha_fin;
            report.ShowPreviewDialog();
            report.Dispose();
        }
        private void xfrm_movimiento_efectivo_Load(object sender, EventArgs e)
        {
            cargar_datos_iniciales();
        }

        private void btn_cargar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fecha_ejecucion.EditValue != null)
            {
                DateTime fecha = Convert.ToDateTime(fecha_ejecucion.EditValue);
                cargar_datos_movimiento(fecha);
            }
        }

        private void btn_cerrar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(Negocio.ClasesCN.CajaCN.CONSULTAR_SI_HAY_FACTURAS_SIN_RECIBO()== false)
            {
                DialogResult preg = XtraMessageBox.Show("¿Desea realizar el cierre de esta fecha?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (preg == DialogResult.Yes)
                {
                    DateTime fecha = Convert.ToDateTime(fecha_ejecucion.EditValue);
                    decimal saldo_final = Convert.ToDecimal(txt_saldo_final.EditValue);
                    if (Negocio.ClasesCN.CajaCN.CIERRE_CAJA_GUARDAR(fecha, saldo_final, id_empleado) > 0)
                    {
                        XtraMessageBox.Show("Cierre de caja realizado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cargar_datos_movimiento(fecha);
                        Reporte_Movimiento_Fecha(fecha);
                        Reporte_Movimiento_Detalle_Fecha(fecha);
                    }
                }
            }
            else
                XtraMessageBox.Show("Hay facturas de contado sin entregar; revisar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void fecha_ejecucion_EditValueChanged(object sender, EventArgs e)
        {
            if (fecha_ejecucion.EditValue != null)
            {
                DateTime fecha = Convert.ToDateTime(fecha_ejecucion.EditValue);
                cargar_datos_movimiento(fecha);
            }
        }

        private void gridView_movimiento_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                return;

            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hitInfo = gridView_movimiento.CalcHitInfo(e.Location);
            if (hitInfo.InDataRow)
            {
                radialMenu1.ShowPopup(Control.MousePosition);
            }
        }

        private void bbi_eliminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int id_movimiento = Convert.ToInt32(gridView_movimiento.GetFocusedRowCellValue("id_movimiento"));
            DialogResult preg = XtraMessageBox.Show("¿Desea anular este movimiento?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (preg == DialogResult.Yes)
            {
                if (Negocio.ClasesCN.CajaCN.MOVIMIENTO_CAJA_ELIMINAR(id_empleado, id_movimiento) > 0)
                {
                    XtraMessageBox.Show("Movimiento anulado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DateTime fecha = Convert.ToDateTime(fecha_ejecucion.EditValue);
                    cargar_datos_movimiento(fecha);        
                }
            }  
        }

        private void bbi_ver_recibo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           int id_movimiento= Convert.ToInt32(gridView_movimiento.GetFocusedRowCellValue("id_movimiento"));
            BindingSource source = new BindingSource();
            source.DataSource = Negocio.ClasesCN.CajaCN.Reporte_de_recibo(id_movimiento);
            var report = new Reportes.Caja.ReporteReciboCaja(source);
            report.ShowPreviewDialog();
            report.Dispose();
        }

        private void bbi_ver_documento_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int tipo = Convert.ToInt32(gridView_movimiento.GetFocusedRowCellValue("tipo_documento"));
            int id_documento = Convert.ToInt32(gridView_movimiento.GetFocusedRowCellValue("id_documento"));
            int id_movimiento = Convert.ToInt32(gridView_movimiento.GetFocusedRowCellValue("id_movimiento"));

            int vEmpleado = Clases.UsuarioLogueado.vID_Empleado;
            bool tiene_permiso = Presentacion.Clases.UsuarioLogueado.PermisoEspecial(vEmpleado, 130);

            if (tipo == 6)
            {
                BindingSource source = new BindingSource();
                source.DataSource = Negocio.ClasesCN.VentasCN.Venta_Reporte(id_documento);
                var report = new Reportes.Ventas.FacturaTermica(source);
                if (tiene_permiso) { report.Parameters[0].Visible = true; } else { report.Parameters[0].Visible = false; }
                report.ShowPreviewDialog();
                report.Dispose();
            }
            else if(tipo == 8)
            {
                BindingSource source = new BindingSource();
                source.DataSource = Negocio.ClasesCN.VentasCN.Venta_Reporte(id_documento);
                var report = new Reportes.Ventas.FacturaTermica(source);
                if (tiene_permiso) { report.Parameters[0].Visible = true; } else { report.Parameters[0].Visible = false; }
                report.ShowPreviewDialog();
                report.Dispose();

            }
            else if(tipo == 7)
            {
                BindingSource source = new BindingSource();
                source.DataSource = Negocio.ClasesCN.CajaCN.Reporte_de_recibo(id_movimiento);
                var report = new Reportes.Caja.ReporteReciboCaja(source);
                report.ShowPreviewDialog();
                report.Dispose();
            }
        }

        private void radialMenu1_Popup(object sender, EventArgs e)
        {
            int estado = Convert.ToInt32(gridView_movimiento.GetFocusedRowCellValue("estado"));
            if ( estado== 0)
                bbi_eliminar.Enabled= bbi_ver_documento.Enabled =bbi_ver_recibo.Enabled = false;
            else if (estado == 2)
                bbi_eliminar.Enabled = false;

        }

        private void bbi_reporte_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DateTime fecha = Convert.ToDateTime(fecha_ejecucion.EditValue);
            Reporte_Movimiento_Fecha(fecha);
        }

        private void bbi_reporte_detallado_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DateTime fecha = Convert.ToDateTime(fecha_ejecucion.EditValue);
            Reporte_Movimiento_Detalle_Fecha(fecha);
        }

        private void bbi_egresos_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DateTime fecha_i = Convert.ToDateTime(fecha_ejecucion.EditValue);
            DateTime fecha_f = Convert.ToDateTime(fecha_final.EditValue);
            Reporte_De_Egresos(fecha_i, fecha_f);
        }

        private void bbi_cargar_Cordobas_ItemClick(object sender,DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(fecha_ejecucion.EditValue != null)
            {
                DateTime fecha = Convert.ToDateTime(fecha_ejecucion.EditValue);
                cargar_datos_movimiento_cordobas(fecha);
            }
        }
    }
}