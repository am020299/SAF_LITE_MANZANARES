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

namespace Presentacion.Formularios.Catalogos
{
    public partial class xfrmListaPrecios : DevExpress.XtraEditors.XtraForm
    {
        public xfrmListaPrecios()
        {
            InitializeComponent();
           
        }

        private void xfrmListaPrecios_Load(object sender, EventArgs e)
        {
            bindingSourceProducto.DataSource = Negocio.ClasesCN.CatalogosCN.Producto_Cargar();
            int vEmpleado = Clases.UsuarioLogueado.vID_Empleado;
            bool tiene_permiso_publicidad = Negocio.ClasesCN.RolesPermisosCN.Permisos(vEmpleado, 11119);
            bool tiene_permiso_eventual = Negocio.ClasesCN.RolesPermisosCN.Permisos(vEmpleado, 11120);
            bool tiene_permiso_empresa = Negocio.ClasesCN.RolesPermisosCN.Permisos(vEmpleado, 11121);
            bool tiene_permiso_detalle = Negocio.ClasesCN.RolesPermisosCN.Permisos(vEmpleado, 11122);
            //bool tiene_permiso_especialB = Negocio.ClasesCN.RolesPermisosCN.Permisos(vEmpleado, 11123);
            bool tiene_permiso_especialA = Negocio.ClasesCN.RolesPermisosCN.Permisos(vEmpleado, 11124);
            bool tiene_permiso_vip = Negocio.ClasesCN.RolesPermisosCN.Permisos(vEmpleado, 11125);
            bool tiene_permiso_liquidacion = Negocio.ClasesCN.RolesPermisosCN.Permisos(vEmpleado, 11126);
            //bool tiene_permiso_eventual_especial = Negocio.ClasesCN.RolesPermisosCN.Permisos(vEmpleado, 11127);
            //bool tiene_permiso_eventual_liquidacion = Negocio.ClasesCN.RolesPermisosCN.Permisos(vEmpleado, 11128);
            //bool tiene_permiso_empresa_especial = Negocio.ClasesCN.RolesPermisosCN.Permisos(vEmpleado, 11129);

            if (Clases.UsuarioLogueado.saberAdminM())
            {
                //gridColumn1.Visible = false;
                //gridColumn11.Visible = true;
                //gridColumn12.Visible = true;
                //gridColumn2.Visible = true;
                //gridColumn3.Visible = true;
                //gridColumn4.Visible = true;
                //gridColumn5.Visible = true;
                //gridColumn6.Visible = true;
                //gridColumn7.Visible = true;
                //gridColumn8.Visible = true;
                //gridColumn9.Visible = true;
                //gridColumn10.Visible = true;
                //gridColumn13.Visible = true;
                //gridColumn14.Visible = true;
                //gridColumn15.Visible = true;
            }
            else
            {
                if (Clases.UsuarioLogueado.vID_Empleado == vEmpleado)
                {
                    gridColumn3.Visible = false;
                    gridColumn4.Visible = false;
                    gridColumn5.Visible = false;
                    gridColumn6.Visible = false;
                    gridColumn7.Visible = false;
                    gridColumn8.Visible = false;
                    gridColumn9.Visible = false;
                    gridColumn10.Visible = false;
                    gridColumn13.Visible = false;
                    gridColumn14.Visible = false;
                    gridColumn15.Visible = false;

                    if (tiene_permiso_detalle)
                    {
                        //gridColumn1.Visible = false;
                        //gridColumn11.Visible = true;
                        //gridColumn12.Visible = true;
                        //gridColumn2.Visible = true;
                        gridColumn5.Visible = true;

                        gridColumn11.VisibleIndex = 1;
                        gridColumn12.VisibleIndex = 2;
                        gridColumn2.VisibleIndex = 3;
                        gridColumn5.VisibleIndex = 4;
                    }

                    if (tiene_permiso_publicidad)
                    {
                        //gridColumn1.Visible = false;
                        //gridColumn11.Visible = true;
                        //gridColumn12.Visible = true;
                        //gridColumn2.Visible = true;
                        gridColumn3.Visible = true;

                        gridColumn11.VisibleIndex = 1;
                        gridColumn12.VisibleIndex = 2;
                        gridColumn2.VisibleIndex = 3;
                        gridColumn3.VisibleIndex = 5;
                    }

                    //if (tiene_permiso_especialB)
                    //{
                    //    //gridColumn1.Visible = false;
                    //    //gridColumn11.Visible = true;
                    //    //gridColumn12.Visible = true;
                    //    //gridColumn2.Visible = true;
                    //    gridColumn7.Visible = true;

                    //    gridColumn11.VisibleIndex = 1;
                    //    gridColumn12.VisibleIndex = 2;
                    //    gridColumn2.VisibleIndex = 3;
                    //    gridColumn7.VisibleIndex = 6;
                    //}

                    if (tiene_permiso_especialA)
                    {
                        //gridColumn1.Visible = false;
                        //gridColumn11.Visible = true;
                        //gridColumn12.Visible = true;
                        //gridColumn2.Visible = true;
                        gridColumn8.Visible = true;

                        gridColumn11.VisibleIndex = 1;
                        gridColumn12.VisibleIndex = 2;
                        gridColumn2.VisibleIndex = 3;
                        gridColumn8.VisibleIndex = 7;
                    }

                    if (tiene_permiso_vip)
                    {
                        //gridColumn1.Visible = false;
                        //gridColumn11.Visible = true;
                        //gridColumn12.Visible = true;
                        //gridColumn2.Visible = true;
                        gridColumn9.Visible = true;

                        gridColumn11.VisibleIndex = 1;
                        gridColumn12.VisibleIndex = 2;
                        gridColumn2.VisibleIndex = 3;
                        gridColumn9.VisibleIndex = 8;
                    }

                    if (tiene_permiso_liquidacion)
                    {
                        //gridColumn1.Visible = false;
                        //gridColumn11.Visible = true;
                        //gridColumn12.Visible = true;
                        //gridColumn2.Visible = true;
                        gridColumn10.Visible = true;

                        gridColumn11.VisibleIndex = 1;
                        gridColumn12.VisibleIndex = 2;
                        gridColumn2.VisibleIndex = 3;
                        gridColumn10.VisibleIndex = 9;
                    }

                    if (tiene_permiso_eventual)
                    {
                        //gridColumn1.Visible = false;
                        //gridColumn11.Visible = true;
                        //gridColumn12.Visible = true;
                        //gridColumn2.Visible = true;
                        gridColumn4.Visible = true;

                        gridColumn11.VisibleIndex = 1;
                        gridColumn12.VisibleIndex = 2;
                        gridColumn2.VisibleIndex = 3;
                        gridColumn4.VisibleIndex = 10;
                    }

                    //if (tiene_permiso_eventual_especial)
                    //{
                    //    //gridColumn1.Visible = false;
                    //    //gridColumn11.Visible = true;
                    //    //gridColumn12.Visible = true;
                    //    //gridColumn2.Visible = true;
                    //    gridColumn4.Visible = true;

                    //    gridColumn11.VisibleIndex = 1;
                    //    gridColumn12.VisibleIndex = 2;
                    //    gridColumn2.VisibleIndex = 3;
                    //    gridColumn4.VisibleIndex = 11;
                    //}

                    //if (tiene_permiso_eventual_liquidacion)
                    //{
                    //    //gridColumn1.Visible = false;
                    //    //gridColumn11.Visible = true;
                    //    //gridColumn12.Visible = true;
                    //    //gridColumn2.Visible = true;
                    //    gridColumn4.Visible = true;

                    //    gridColumn11.VisibleIndex = 1;
                    //    gridColumn12.VisibleIndex = 2;
                    //    gridColumn2.VisibleIndex = 3;
                    //    gridColumn4.VisibleIndex = 12;
                    //}

                    if (tiene_permiso_empresa)
                    {
                        //gridColumn1.Visible = false;
                        //gridColumn11.Visible = true;
                        //gridColumn12.Visible = true;
                        //gridColumn2.Visible = true;
                        gridColumn6.Visible = true;

                        gridColumn11.VisibleIndex = 1;
                        gridColumn12.VisibleIndex = 2;
                        gridColumn2.VisibleIndex = 3;
                        gridColumn6.VisibleIndex = 13;
                    }

                    //if (tiene_permiso_empresa_especial)
                    //{
                    //    //gridColumn1.Visible = false;
                    //    //gridColumn11.Visible = true;
                    //    //gridColumn12.Visible = true;
                    //    //gridColumn2.Visible = true;
                    //    gridColumn6.Visible = true;

                    //    gridColumn11.VisibleIndex = 1;
                    //    gridColumn12.VisibleIndex = 2;
                    //    gridColumn2.VisibleIndex = 3;
                    //    gridColumn6.VisibleIndex = 14;
                    //}
                }
            }
        }
    }
}