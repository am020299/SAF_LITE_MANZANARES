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
using DevExpress.XtraGrid.Views.Tile;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Controls;

namespace Presentacion.Formularios.Ventas
{
    public partial class xfrm_FormaPagoVenta : DevExpress.XtraEditors.XtraForm
    {
        public xfrm_FormaPagoVenta()
        {
            InitializeComponent();
        }
        private decimal _vTotal;
        private decimal vTipoCambio;

        public decimal vTotal { get => _vTotal; set => _vTotal = value; }

        private void xfrm_FormaPagoVenta_Load(object sender, EventArgs e)
        {
            bindingSourceFormaPago.DataSource = Negocio.ClasesCN.VentasCN.FormaPago_Select();
            bindingSourceDetalle.DataSource = getTable();
            repositoryItemLookUpEdit_Moneda.DataSource = Negocio.ClasesCN.CatalogosCN.getMoneda();
            txtTotal.EditValue = vTotal;
            vTipoCambio = Negocio.ClasesCN.DatosRequeridosCN.Obtener_tipo_cambio_hoy();
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
                UpdateDatos();
            }

            if(e.KeyCode == Keys.Delete)
            {
                viewDetalleFormaPago.DeleteRow(viewDetalleFormaPago.FocusedRowHandle);
                UpdateDatos();
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
                        if ((Convert.ToInt32(e.Value) < 0))
                            e.Valid = false;
                        break;
                }
            }
            catch (Exception)
            {
                e.Valid = false;
            }
        }

        private void viewDetalleFormaPago_InvalidValueException(object sender, DevExpress.XtraEditors.Controls.InvalidValueExceptionEventArgs e)
        {
            GridView view = sender as GridView;

            switch (view.FocusedColumn.FieldName)
            {
                case "monto":
                    e.ExceptionMode = ExceptionMode.DisplayError;
                    e.WindowCaption = "Error en el valor ingresado";
                    e.ErrorText = "Valor no puede ser negativo";
                    break;
            }
        }

        private void viewDetalleFormaPago_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            GridView view = sender as GridView;
            try
            {
                var vCantidad = view.GetFocusedRowCellValue("monto").Equals(DBNull.Value) ? "" : Convert.ToString(view.GetFocusedRowCellValue("monto"));
                if (string.IsNullOrEmpty(vCantidad)) { e.Valid = false; view.SetColumnError(colMonto, "Campo requerido"); view.FocusedColumn = colMonto; }
            }
            catch (Exception)
            {

            }
        }

        private void viewDetalleFormaPago_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
            e.WindowCaption = "Error en el valor ingresado";
            e.ErrorText = "Campo requerido";
        }

        private void viewDetalleFormaPago_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            UpdateDatos();
        }

        private void UpdateDatos()
        {
            var monto = viewDetalleFormaPago.Columns["monto1"].SummaryItem.SummaryValue;
            txtMonto.EditValue = monto;
            decimal diferencia = vTotal - Convert.ToDecimal(monto);
            if (diferencia > 0) { txtSaldo.EditValue = diferencia; txtCambio.EditValue = 0.00M; btntCobrarFactura.Enabled = false; }
            else { txtCambio.EditValue = diferencia * -1.00M; txtSaldo.EditValue = 0.00M; btntCobrarFactura.Enabled = true; }

            if (viewDetalleFormaPago.RowCount == 0) btntCobrarFactura.Enabled = false;
        }

        decimal CalcularColumnaSaldo(GridView view, int listSourceRowIndex)
        {
            decimal monto = 0.00m;
            for (int i = 0; i <= listSourceRowIndex; i++)
            {
                monto = monto + Convert.ToDecimal(view.GetListSourceRowCellValue(i, "monto1"));
            }
            
            return (vTotal - monto);
        }
        private void viewDetalleFormaPago_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.Column.FieldName == "saldo" && e.IsGetData)
                e.Value = CalcularColumnaSaldo(view, e.ListSourceRowIndex);
        }

        public IFormaPago iforma { get; set; }
        private void btntCobrarFactura_Click(object sender, EventArgs e)
        {
            UpdateDatos();
            if (viewDetalleFormaPago.RowCount == 0) return;

            if (Convert.ToDecimal(txtTotal.EditValue) <= Convert.ToDecimal(txtMonto.EditValue))
            {
                if (iforma == null) return;
                if (iforma.FormaPago(viewDetalleFormaPago))
                    this.Close();
            }
        }
    } 
}