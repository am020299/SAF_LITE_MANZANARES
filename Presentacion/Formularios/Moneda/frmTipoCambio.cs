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
using System.Net;
using System.IO;
using System.Xml;
using DevExpress.Internal.WinApi.Window.Data.Xml.Dom;
using Presentacion.Clases;


namespace Presentacion.Formularios.Moneda
{
    public partial class frmTipoCambio : DevExpress.XtraEditors.XtraForm
    {
        public frmTipoCambio( )
        {
            InitializeComponent();
            Presentacion.Clases.ConexionInternet p = new ConexionInternet();
            if (p.Hay_Internet() == false)
            {
                btn_tc_internet.Enabled = false;
                XtraMessageBox.Show("Se desabilito la opcion de importar de la web, debido a que no hay conexión a internet.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            gridDetalle.DataSource=null;
            var import = new Presentacion.Clases.Exportar();
            import.ImportarExcel_A_Grid(gridDetalle);
        }
        private void GuardarTipoCambio()
        {
            try
            {
        
                for (int i = 0; i < gvDetalle.RowCount; i++)
                {
                    string fecha = Convert.ToDateTime(gvDetalle.GetRowCellDisplayText(i, gvDetalle.Columns[0])).ToString("yyyy-MM-dd");
                    decimal monto = Convert.ToDecimal(gvDetalle.GetRowCellDisplayText(i, gvDetalle.Columns[1]));

                    if (Negocio.ClasesCN.DatosRequeridosCN.AgregaCambioContable(fecha, monto) < 1)
                        XtraMessageBox.Show("La fecha '" + fecha + "' ya tiene un tipo de cambio asignado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
         
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int dia_del_mes = DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month);

            if (gvDetalle == null || gvDetalle.SelectedRowsCount == 0)
            {
                XtraMessageBox.Show("Importe el archivo excel del BCN", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (gvDetalle.RowCount < dia_del_mes)
                {
                    XtraMessageBox.Show("El archivo no contiene las " + dia_del_mes + " filas del mes actual");
                }
                else
                {
                    if (Negocio.ClasesCN.DatosRequeridosCN.Validar_archivo_tipo_cambio(Convert.ToDateTime(gvDetalle.GetRowCellDisplayText(0, gvDetalle.Columns[0]))) == true)
                    {
                        GuardarTipoCambio();
                        XtraMessageBox.Show("Tipo de Cambio Contable Guardado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Limpiar();
                        this.Close();
                    }
                    else
                        XtraMessageBox.Show("Este Archivo ya fue importado anteriormente o no tiene el formato correcto\nVerifique el archivo a importar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void Limpiar()
        {
            gridDetalle.DataSource = null;
            gridDetalle.RefreshDataSource();
            txtMsg.Text = string.Empty;
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        private void frmTipoCambio_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Negocio.ClasesCN.DatosRequeridosCN.Obtener_tipo_cambio_hoy()==0)
            {
                e.Cancel = true;
                XtraMessageBox.Show("Para Cerrar esta ventana tiene que haber un tipo de cambio válido para este mes", "Cerrar Ventanas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                XtraMessageBox.Show("Esta Ventana se cerrará por que ya se ha ingresado tipo de cambio válido para este mes.", "Cerrar Ventanas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btn_tc_internet_Click(object sender, EventArgs e)
        {
            carga_datos_tc();   
        }
        public void carga_datos_tc()
        {
            Limpiar();
            var X = Negocio.ClasesCN.DatosRequeridosCN.ObtenerCambioMensual(DateTime.Today.Year, DateTime.Today.Month);
            if (X.Count > 0)
            {
                gridDetalle.DataSource = X.ToList();
                gvDetalle.Columns[0].Caption = "Fecha";
                gvDetalle.Columns[1].Caption = "Córdobas por USD";
            }

        }
    }
}