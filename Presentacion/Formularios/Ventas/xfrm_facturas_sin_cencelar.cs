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

namespace Presentacion.Formularios.Ventas
{
    public partial class xfrm_facturas_sin_cencelar:DevExpress.XtraEditors.XtraForm
    {
        const int ACTUALIZAR_CADA=3000;


        private void Verifica_Formulario_Abierto( )
        {
            FormCollection fc = Application.OpenForms;

            foreach(Form frm in fc)
            {
                //iterate through
                if(frm.Name == "xfrm_caja_factura_2")
                {
                    frm.ShowDialog();
                }
            }
        }

        public xfrm_facturas_sin_cencelar( )
        {
            InitializeComponent();
            timer.Start();
        }
        private void Carga_Facturas_Pendientes( )
        {
           grid_facturas.DataSource= Negocio.ClasesCN.VentasCN.Ventas_Sin_Cancelar().ToList();
        }
        private void xfrm_facturas_sin_cencelar_Load(object sender,EventArgs e)
        {
            var D = Negocio.ClasesCN.CajaCN.Buscar_Arqueo_Fecha(DateTime.Now.Date, Clases.UsuarioLogueado.vID_Empleado);
            if (D != null)
                Carga_Facturas_Pendientes();
            else
            {
                XtraMessageBox.Show("No hay saldo inicial para el dia; comunicarse con administrador","Información", MessageBoxButtons.OK,MessageBoxIcon.Information);
                btn_Actualizar.Enabled = false;
            }

        }

        private void btn_Actualizar_Click(object sender,EventArgs e)
        {
            Carga_Facturas_Pendientes();
        }

        private void gview_Facturas_DoubleClick(object sender,EventArgs e)
        {
            try
            {
                //imprimir
                if(gview_Facturas.IsValidRowHandle(gview_Facturas.FocusedRowHandle))
                {
                    var D = Negocio.ClasesCN.CajaCN.Buscar_Arqueo_Fecha(DateTime.Now, Clases.UsuarioLogueado.vID_Empleado);
                    if(D.id_registro != 0)
                    {
                        int id_factura = Convert.ToInt32(gview_Facturas.GetFocusedRowCellValue("id") ?? 0);
                        int id_documento_cxc = Convert.ToInt32(gview_Facturas.GetFocusedRowCellValue("id_documento_cxc") ?? 0);
                        int tipo = Convert.ToInt32(gview_Facturas.GetFocusedRowCellValue("tipo_documento") ?? 0);
                        bool esCambio = Convert.ToBoolean(gview_Facturas.GetFocusedRowCellValue("esCambio") ?? false);
                        decimal monto = Convert.ToDecimal(gview_Facturas.GetFocusedRowCellValue("total") ?? 0.00);
                        int moneda = Convert.ToInt32(gview_Facturas.GetFocusedRowCellValue("moneda") ?? 0);
                        string moneda_factura = Convert.ToString(gview_Facturas.GetFocusedRowCellValue("moneda_factura"));
                        var form = new Ventas.xfrm_caja_factura_2(tipo);
                        form.id_factura = id_factura;
                        //form.total_documento = monto;
                        //form.tipo_moneda_factura=moneda;
                        form.tipo_documento = tipo;
                        form.ShowDialog();

                        if (tipo == 1 && esCambio == false)
                        {
                            source.DataSource = Negocio.ClasesCN.VentasCN.Venta_Reporte(id_factura);
                            var report = new Reportes.Ventas.FacturaTermicaCordobas(source);
                            int vEmpleado = Clases.UsuarioLogueado.vID_Empleado;
                            bool tiene_permiso = Presentacion.Clases.UsuarioLogueado.PermisoEspecial(vEmpleado, 130);

                            if (tiene_permiso)
                            {
                                report.Parameters[0].Visible = true;
                                //report.Parameters[2].Visible = true;
                                report.ShowPreviewDialog();
                            }
                            else
                            {
                                report.Parameters[0].Visible = false;
                                report.Parameters[1].Visible = false;
                                //report.Parameters[2].Visible = false;
                                report.ShowPreviewDialog();
                            }
                        }
                        else if (tipo == 2 && esCambio == false)
                        {
                            if (moneda_factura == "CORDOBAS")
                            {
                                var data = Negocio.ClasesCN.CuentasCobrarCN.Reporte_Documentos_Fila_Select(id_documento_cxc).FirstOrDefault();
                                decimal monto_Neto;
                                if (data.moneda == "CORDOBAS")
                                {
                                    monto_Neto = Convert.ToDecimal(Negocio.ClasesCN.CuentasCobrarCN.Reporte_Documentos_Fila_Select(id_documento_cxc).Sum(x => x.pago_abono));
                                }
                                else
                                {
                                    monto_Neto = Convert.ToDecimal(Negocio.ClasesCN.CuentasCobrarCN.Reporte_Documentos_Fila_Select(id_documento_cxc).Sum(x => x.pago_abono)) * Convert.ToDecimal(data.tipo_cambio);
                                }

                                BindingSource Origen_Datos = new BindingSource();
                                Origen_Datos.DataSource = Negocio.ClasesCN.CuentasCobrarCN.Reporte_Documentos_Fila_Select(id_documento_cxc).ToList();
                                var Reporte = new Reportes.CuentasCobrar.xfrm_recibo_abono_termicoV2(Origen_Datos);
                                Reporte.Cantidad_Letras.Value = Clases.numeros_a_letras.ToCardinal(Convert.ToDecimal(monto_Neto));
                                Reporte.Cantidad_Letras.Visible = false;
                                Reporte.parameter1.Visible = false;
                                Reporte.parameter1.Value = id_documento_cxc;
                                Reporte.ShowPreview();
                            }
                            else
                            {
                                var data = Negocio.ClasesCN.CuentasCobrarCN.Reporte_Documentos_Fila_Select(id_documento_cxc).FirstOrDefault();
                                decimal monto_Neto;
                                if (data.moneda == "DOLARES")
                                {
                                    monto_Neto = Convert.ToDecimal(Negocio.ClasesCN.CuentasCobrarCN.Reporte_Documentos_Fila_Select(id_documento_cxc).Sum(x => x.pago_abono));
                                }
                                else
                                {
                                    monto_Neto = Convert.ToDecimal(Negocio.ClasesCN.CuentasCobrarCN.Reporte_Documentos_Fila_Select(id_documento_cxc).Sum(x => x.pago_abono)) / Convert.ToDecimal(data.tipo_cambio);
                                }

                                BindingSource Origen_Datos = new BindingSource();
                                Origen_Datos.DataSource = Negocio.ClasesCN.CuentasCobrarCN.Reporte_Documentos_Fila_Select(id_documento_cxc).ToList();
                                var Reporte = new Reportes.CuentasCobrar.xfrm_recibo_abono_termicoV2Dolares(Origen_Datos);
                                Reporte.Cantidad_Letras.Value = Clases.numeros_a_letras.ToCardinal(Convert.ToDecimal(monto_Neto));
                                Reporte.Cantidad_Letras.Visible = false;
                                Reporte.parameter1.Visible = false;
                                Reporte.parameter1.Value = id_documento_cxc;
                                Reporte.ShowPreview();
                            }
                        }
                        else if(tipo == 1 && esCambio == true)
                        {
                            source.DataSource = Negocio.ClasesCN.VentasCN.Venta_Reporte(id_factura);
                            var report = new Reportes.Ventas.FacturaTermicaCordobasDev(source);
                            int vEmpleado = Clases.UsuarioLogueado.vID_Empleado;
                            bool tiene_permiso = Presentacion.Clases.UsuarioLogueado.PermisoEspecial(vEmpleado, 130);

                            if (tiene_permiso)
                            {
                                //report.Parameters[0].Visible = true;
                                //report.Parameters[2].Visible = true;
                                report.ShowPreviewDialog();
                            }
                            else
                            {
                                report.Parameters[0].Visible = false;
                                report.Parameters[1].Visible = false;
                                //report.Parameters[2].Visible = false;
                                report.ShowPreviewDialog();
                            }
                        }

                        Carga_Facturas_Pendientes();
                    }
                    else
                    {
                        Clases.MyMessageBox.MessageFont = new Font(Clases.MyMessageBox.MessageFont.FontFamily, 16);
                        Clases.MyMessageBox.Show($"Lo sentimos, necesita iniciar su arqueo del dia de hoy para cancelar las facturas", "Caja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch(Exception)
            {
                //Console.Write("Para no mostrar excepcion al usuario");
            }
        }

        private void timer_Tick(object sender,EventArgs e)
        {
            Carga_Facturas_Pendientes();
        }

        private void xfrm_facturas_sin_cencelar_Activated(object sender,EventArgs e)
        {
            timer.Interval = ACTUALIZAR_CADA;
            Carga_Facturas_Pendientes();
        }
    }
}