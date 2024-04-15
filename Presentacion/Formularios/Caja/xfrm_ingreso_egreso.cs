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
using DevExpress.XtraGrid.Views.Tile;
using DevExpress.XtraGrid.Views.Grid;

namespace Presentacion.Formularios.Caja
{
    public partial class xfrm_ingreso_egreso : DevExpress.XtraEditors.XtraForm
    {
        int id_empleado;
        private decimal vTipoCambio;
        public xfrm_ingreso_egreso()
        {
            InitializeComponent();
            id_empleado = Clases.UsuarioLogueado.vID_Empleado;
        }
        private void cargar_datos_iniciales()
        {
            fecha_caja.EditValue = DateTime.Now.ToShortDateString();
            rd_tipo_movimiento.SelectedIndex = 0;
            DateTime fecha = Convert.ToDateTime(fecha_caja.EditValue);
            if (Negocio.ClasesCN.CajaCN.saldo_inicial_del_dia(fecha) == 0)
            {
                XtraMessageBox.Show("No hay saldo inicial disponible; comunicarse con administrador","Caja" ,MessageBoxButtons.OK, MessageBoxIcon.Information);
                layoutControl1.Enabled = btn_guardar.Enabled= gridFormaPago.Enabled =false;
            }
            else
            {
                txt_tipo_cambio.EditValue = Negocio.ClasesCN.DatosRequeridosCN.obtener_tipo_cambio_mensual();
                txt_saldo_disponible.Text = Negocio.ClasesCN.CajaCN.saldo_disponible_del_dia(fecha).ToString("n2") ;
                cargar_personas();
            }
            repositoryItemLookUpEdit_Moneda.DataSource = Negocio.ClasesCN.CatalogosCN.getMoneda();
            bindingSourceDetalle.DataSource = getTable();
            vTipoCambio = Negocio.ClasesCN.DatosRequeridosCN.obtener_tipo_cambio_mensual();
        }
        private void consultar_fecha_cerrada()
        {
            DateTime fecha = Convert.ToDateTime(fecha_caja.EditValue);
            txt_tipo_cambio.EditValue = Negocio.ClasesCN.DatosRequeridosCN.obtener_tipo_cambio_mensual();
            txt_saldo_disponible.Text = Negocio.ClasesCN.CajaCN.saldo_disponible_del_dia(fecha).ToString("n2");
            if (Negocio.ClasesCN.CajaCN.CONSULTAR_SI_FECHA_ESTA_CERRADA(fecha))
            {
                XtraMessageBox.Show("Fecha ya cerrada", "Caja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btn_guardar.Enabled = gridFormaPago.Enabled = gridDetalleFormaPago.Enabled = false;
            }
            else
                btn_guardar.Enabled = gridFormaPago.Enabled = gridDetalleFormaPago.Enabled = true;
        }
        private DataTable getTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id_forma_pago", typeof(int));
            dt.Columns.Add("monto", typeof(decimal));
            dt.Columns.Add("moneda", typeof(int));
            dt.Columns.Add("tipo_cambio", typeof(decimal));
            return dt;
        }
        private void Limpiar_controles()
        {
            DateTime fecha = Convert.ToDateTime(fecha_caja.EditValue);
            txt_saldo_disponible.Text = Negocio.ClasesCN.CajaCN.saldo_disponible_del_dia(fecha).ToString("n2");
            cargar_personas();
            int tm = Convert.ToInt32(rd_tipo_movimiento.EditValue);
            txt_numero_recibo.EditValue = Negocio.ClasesCN.CajaCN.numero_recibo(tm) + 1;
            txt_concepto.Text = string.Empty;
            bindingSourceDetalle.DataSource = null;
            bindingSourceDetalle.DataSource = getTable();
            calculos();
        }
        private void cargar_personas()
        {
            cmbx_persona_referencia.Text = string.Empty;
            cmbx_persona_referencia.Properties.Items.Clear();
            foreach (var r in Negocio.ClasesCN.CajaCN.Personas_Referencias().ToList())
                cmbx_persona_referencia.Properties.Items.Add(r.nombre);
        }
        private void xfrm_ingreso_egreso_Load(object sender, EventArgs e)
        {
            cargar_datos_iniciales();
        }
        private void rd_tipo_movimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            int tm = Convert.ToInt32(rd_tipo_movimiento.EditValue);
            txt_numero_recibo.EditValue = Negocio.ClasesCN.CajaCN.numero_recibo(tm)+1;
            if(tm==0)
                bindingSourceFormaPago.DataSource = Negocio.ClasesCN.VentasCN.FormaPago_Select().Where(o=>o.efectivo==true);
            else
                bindingSourceFormaPago.DataSource = Negocio.ClasesCN.VentasCN.FormaPago_Select();
        }
        private bool validar_guardar_operacion()
        {
            if (cmbx_persona_referencia.Text.Trim() == string.Empty || txt_concepto.Text.Trim() == string.Empty || viewDetalleFormaPago.RowCount==0)
            {
                XtraMessageBox.Show("Completar campos vacios", "Caja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else
                return true;
        }    
        private void Guardar_Movimiento()
        {
            DateTime fecha_ejecucion = Convert.ToDateTime(fecha_caja.EditValue);
            decimal tc = Convert.ToDecimal(txt_tipo_cambio.EditValue);
            int tm= Convert.ToInt32(rd_tipo_movimiento.EditValue);
            int td = 7;
            int id_mov = Negocio.ClasesCN.CajaCN.MOVIMIENTO_CAJA_GUARDAR(fecha_ejecucion, txt_concepto.Text.Trim(), cmbx_persona_referencia.Text.Trim(), tm, 0, td, txt_numero_recibo.Text, id_empleado, tc, viewDetalleFormaPago, 99, DateTime.Now);
            if(id_mov>0)
            {
                XtraMessageBox.Show("Movimiento generado correctamente","Caja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BindingSource source = new BindingSource();
                source.DataSource = Negocio.ClasesCN.CajaCN.Reporte_de_recibo(id_mov);
                var report = new Reportes.Caja.ReporteReciboCaja(source);
                report.ShowPreviewDialog();
                report.Dispose();
                Limpiar_controles();
            }
            else
                XtraMessageBox.Show("Movimiento no puede generarse; favor revisar datos a registrar", "Caja", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        private void btn_guardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (validar_guardar_operacion())
            {
                DialogResult preg = XtraMessageBox.Show("¿Desea generar este recibo?","Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (preg == DialogResult.Yes)
                    Guardar_Movimiento();
            }
        }

        private void tileViewFormaPago_ItemClick(object sender, DevExpress.XtraGrid.Views.Tile.TileViewItemClickEventArgs e)
        {
            TileView view = sender as TileView;
            try
            {
                int vIdFormaPago = view.GetFocusedRowCellValue("id").Equals(DBNull.Value) ? 0 : Convert.ToInt32(view.GetFocusedRowCellValue("id"));
                for (int i = 0; i < viewDetalleFormaPago.RowCount; i++)
                {
                    if ((int)viewDetalleFormaPago.GetRowCellValue(i, "id_forma_pago") == vIdFormaPago)
                    {
                        viewDetalleFormaPago.FocusedRowHandle = i;
                        viewDetalleFormaPago.Focus();
                        return;
                    }
                }

                var query = Negocio.ClasesCN.VentasCN.FormaPago_Select().Where(x => x.id == vIdFormaPago).FirstOrDefault();
                if (query != null)
                {
                    viewDetalleFormaPago.AddNewRow();
                    int rowHandler = viewDetalleFormaPago.GetRowHandle(viewDetalleFormaPago.DataRowCount);

                    if (viewDetalleFormaPago.IsNewItemRow(rowHandler))
                    {
                        viewDetalleFormaPago.SetRowCellValue(rowHandler, "id_forma_pago", vIdFormaPago);
                        viewDetalleFormaPago.SetRowCellValue(rowHandler, "monto", 0.00M);
                        viewDetalleFormaPago.SetRowCellValue(rowHandler, "moneda", query.moneda);
                        if (query.moneda == 1) viewDetalleFormaPago.SetRowCellValue(rowHandler, "tipo_cambio", 1.00M);
                        else viewDetalleFormaPago.SetRowCellValue(rowHandler, "tipo_cambio", vTipoCambio);
                        viewDetalleFormaPago.FocusedRowHandle = rowHandler;
                    }
                }
                viewDetalleFormaPago.Focus();
            }
            catch (Exception) { }
        }

        private void viewDetalleFormaPago_KeyDown(object sender, KeyEventArgs e)
        {
            if (viewDetalleFormaPago.RowCount == 0) return;
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                viewDetalleFormaPago.CloseEditor();
                viewDetalleFormaPago.UpdateCurrentRow();
                SendKeys.Send("{ESC}");
            }

            if (e.KeyCode == Keys.Delete)
            {
                viewDetalleFormaPago.DeleteRow(viewDetalleFormaPago.FocusedRowHandle);
                calculos();
            }
        }

        private void viewDetalleFormaPago_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            GridView view = sender as GridView;
            try
            {
                switch (view.FocusedColumn.FieldName)
                {
                    case "monto":
                        if ((Convert.ToDecimal(e.Value) < 0))
                            e.Valid = false;
                        break;
                }
            }
            catch (Exception)
            {
                e.Valid = false;
            }
        }
        private void calculos()
        {
            decimal total=0;
            for (int i = 0; i < viewDetalleFormaPago.RowCount; i++)
            {
                 int tipo_moneda= Convert.ToInt32(viewDetalleFormaPago.GetRowCellValue(i, "moneda"));
                 decimal cantidad = Convert.ToDecimal(viewDetalleFormaPago.GetRowCellValue(i, "monto"));
                if (tipo_moneda == 2)
                    total += (cantidad * vTipoCambio);
                else
                    total += cantidad;
            }
            txt_total.Text = total.ToString("n2");
            if (rd_tipo_movimiento.SelectedIndex == 1)
            {
                decimal saldo_disponible = Convert.ToDecimal(txt_saldo_disponible.EditValue);
                if(total> saldo_disponible)
                {
                    btn_guardar.Enabled = false;
                    XtraMessageBox.Show("Monto a registrar no puede ser mayor al disponible","Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    btn_guardar.Enabled = true;
            }
        }
        private void viewDetalleFormaPago_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            calculos();
        }

        private void txt_concepto_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void fecha_caja_EditValueChanged(object sender, EventArgs e)
        {
            if (fecha_caja.EditValue != null)
                consultar_fecha_cerrada();
        }
    }
}