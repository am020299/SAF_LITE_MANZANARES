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

namespace Presentacion.Formularios.CuentasCobrar
{
    public partial class xfrm_ParametrosCXC:DevExpress.XtraEditors.XtraForm
    {
        public xfrm_ParametrosCXC( )
        {
            InitializeComponent();
        }

        private void xfrm_ParametrosCXC_Load(object sender,EventArgs e)
        {
            binding_CuentasContabilidad.DataSource=Negocio.ClasesCN.ContabilidadCN.Cuentas_Select().Select(C => new { CUENTA = C.numero_cuenta,DESCRIPCION = C.nombre_cuenta,NIVEL = C.nivel }).ToList();
            repositorio_search_cuentas.DataSource=binding_CuentasContabilidad;
            binding_CuentasContables.DataSource=Negocio.ClasesCN.CuentasCobrarCN.CuentasContables_Select().ToList();
        }

        private void gview_cuentas_RowUpdated(object sender,DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            try
            {
                string vId =gview_cuentas.GetFocusedRowCellValue(col_id_cuenta).ToString();
                string vCodigo = gview_cuentas.GetFocusedRowCellValue(col_numero_cuenta).ToString();
                string vDescripcion = gview_cuentas.GetFocusedRowCellValue(col_Descripcion).ToString().ToUpper();
                if(vId!="0")
                {
                    if(XtraMessageBox.Show($"¿Desea actualizar la cuenta contable para {vDescripcion} a la cuenta {vCodigo}?","Mensaje del sistema",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
                    {
                        int resultado= Negocio.ClasesCN.CuentasCobrarCN.CuentaContable_Update(vCodigo,Convert.ToInt32(vId),Clases.UsuarioLogueado.vID_Empleado);
                        if(resultado>0)
                        {
                            XtraMessageBox.Show($"Se ha actualizado existosamente la cuenta contable de {vDescripcion}","Mensaje del sistema",MessageBoxButtons.OK,MessageBoxIcon.Information);
                            binding_CuentasContables.DataSource=Negocio.ClasesCN.CuentasCobrarCN.CuentasContables_Select().ToList();
                            binding_CuentasContabilidad.DataSource=Negocio.ClasesCN.ContabilidadCN.Cuentas_Select().Select(C => new { CUENTA = C.numero_cuenta,DESCRIPCION = C.nombre_cuenta,NIVEL = C.nivel }).ToList();
                            repositorio_search_cuentas.DataSource=binding_CuentasContabilidad;
                        }
                        else
                        {
                            XtraMessageBox.Show($"Lo sentimos no se ha podido Actualizar la cuenta contable de {vDescripcion}","Mensaje del sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
                            binding_CuentasContables.DataSource=Negocio.ClasesCN.CuentasCobrarCN.CuentasContables_Select().ToList();
                            binding_CuentasContabilidad.DataSource=Negocio.ClasesCN.ContabilidadCN.Cuentas_Select().Select(C => new { CUENTA = C.numero_cuenta,DESCRIPCION = C.nombre_cuenta,NIVEL = C.nivel }).ToList();
                            repositorio_search_cuentas.DataSource=binding_CuentasContabilidad;
                        }
                    }

                }
                

            }
            catch(Exception ex)
            {
                XtraMessageBox.Show($"Lo sentimos ha ocurrido el siguiente error.{Environment.NewLine}Error:{ex.Message}.","Mensaje del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}