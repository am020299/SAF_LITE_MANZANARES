using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using DPFP;
using DPFP.Capture;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Presentacion.Formularios.Catalogos
{
    public partial class xfrm_Catalogos:DevExpress.XtraEditors.XtraForm, DPFP.Capture.EventHandler
    {
        private List<Entidades.Cliente_Cargar_Result> clientes_Activos = new List<Entidades.Cliente_Cargar_Result>();

        int id_empleado;
        GridControl grilla_exportar;
        string id_cliente = 0.ToString();
        string id_subgrupo = 0.ToString();
        string id_proveedor = 0.ToString();
        string id_grupo = 0.ToString();
        string usuario;
        string cargo;
        DataTable Tabla_Lineas = new DataTable("Lineas");
        DataTable Tabla_Precio_Detalle_Linea = new DataTable("PrecioDetallesLinea");
        DataTable Tabla_Productos = new DataTable("Productos");
        DataTable Tabla_Precio_Detalle_Producto = new DataTable("PrecioDetallesProducto");
        //public int IDempleado;
        public xfrm_Catalogos( )
        {
            InitializeComponent();
            id_empleado = Clases.UsuarioLogueado.vID_Empleado;
            usuario = Clases.UsuarioLogueado.vNickName;
            cargo = Clases.UsuarioLogueado.vPuestoCargo;
            
            //No sacar las tablas del init 
            CargarTablasLinea();
            CargarTablasProductos();
        }
        private void Buscar_Permisos_Roles_Sin_Guardar( )
        {
            var Permisos=Negocio.ClasesCN.RolesPermisosCN.Cargar_Permisos(Clases.UsuarioLogueado.vID_Empleado).Where(P=>P.asignado==1).ToList();
            if(Negocio.ClasesCN.RolesPermisosCN.Consultar_Usuario_Admin(Clases.UsuarioLogueado.vID_Empleado) == 0)
            {
                if(Permisos.Count() > 0)
                {
                    navBarGroupEmpleado.Visible = Permisos.Any(P => P.id_rol == 105);
                    navBarGroupClientes.Visible = Permisos.Any(P => P.id_rol == 106);
                    navBarGroup_Caja.Visible = Permisos.Any(P => P.id_rol == 107);
                    navBarGroupProveedores.Visible = Permisos.Any(P => P.id_rol == 108);
                    navBarGroupProductos.Visible = Permisos.Any(P => P.id_rol == 109);
                    nbiCategoria.Visible = Permisos.Any(P => P.id_rol == 110);
                    nbiMarca.Visible = Permisos.Any(P => P.id_rol == 112);
                    nbiLinea.Visible = Permisos.Any(P => P.id_rol == 111);
                    nbiProducto.Visible = Permisos.Any(P => P.id_rol == 113);
                    navBarGroupPresentacion.Visible = Permisos.Any(P => P.id_rol == 114);
                    navBarGroupBodega.Visible = Permisos.Any(P => P.id_rol == 115);
                }
                else
                {
                    navBarGroupEmpleado.Visible = false; ;
                    navBarGroupClientes.Visible = false;// Permisos.Any(P => P.id_rol == 106);
                    navBarGroup_Caja.Visible = false;// Permisos.Any(P => P.id_rol == 107);
                    navBarGroupProveedores.Visible = false;// Permisos.Any(P => P.id_rol == 108);
                    navBarGroupProductos.Visible = false;// Permisos.Any(P => P.id_rol == 109);
                    nbiCategoria.Visible = false;// Permisos.Any(P => P.id_rol == 110);
                    nbiMarca.Visible = false;// Permisos.Any(P => P.id_rol == 112);
                    nbiLinea.Visible = false;// Permisos.Any(P => P.id_rol == 111);
                    nbiProducto.Visible = false;// Permisos.Any(P => P.id_rol == 113);
                    navBarGroupPresentacion.Visible = false;// Permisos.Any(P => P.id_rol == 114);
                    navBarGroupBodega.Visible = false;// Permisos.Any(P => P.id_rol == 115);

                }
            }
        }
        private void xfrm_Catalogos_Load(object sender,EventArgs e)
        {
            Buscar_Permisos_Roles_Sin_Guardar();
            if(Clases.UsuarioLogueado.saberAdminM())
            {
                bbi_cambio_subgrupos.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            else
            {
                bbi_cambio_subgrupos.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
        }
        public void Mostrar_Pagina(int tap)//1:Cliente, 2:Categoria, 3:Marcas, 4:Unidad Medida, 5:Productos, 6:Bodega, 7:Linea, 8:Empleado, 9:Tipo Ajuste
        {
            XtraTabControlCatalogos.Visible = true;
            
            switch (tap)
            {
                case 1:
                    
                    tab_cierres_caja.PageVisible = tabFormaPago.PageVisible = tabProveedores.PageVisible = tabTiposAjustes.PageVisible = tabEmpleado.PageVisible = tabLinea.PageVisible = tabBodega.PageVisible = tabProductos.PageVisible = tabUnidadMedida.PageVisible = tabCategoria.PageVisible = tabMarca.PageVisible = tabSectores.PageVisible = tabPrecios.PageVisible = tabLotes.PageVisible = false;
                    tabClientes.PageVisible = true;
                    tabClientes.Text = "Listado de Clientes Publicidad".ToUpper();
                    rp_id_sector.DataSource = Negocio.ClasesCN.CatalogosCN.Sectores_cargar().ToList();
                    rp_id_sector.DisplayMember = "nombre";
                    rp_id_sector.ValueMember = "id_sector";
                    repositoryItemLookUpEdit_Precio.DataSource = looks_precio.Properties.DataSource = Negocio.ClasesCN.CatalogosCN.getPrecio();
                    var Representantes= Negocio.ClasesCN.CatalogosCN.Representantes_Cargar().Select(R=>new {R.nombre_rep,R.id_representante}).ToList();
                    repository_representante_lookup.DataSource = Representantes; //Representantes;

                    CargarClientes();
                    gridCliente.ContextMenuStrip = clicl_derecho_exportar;
                    grilla_exportar = gridCliente;
                    editar.Checked = true;
                    looks_precio.ReadOnly = true;
                    bbi_guardar.Enabled = false;
                    precioEspecial();
                    pictureEditCliente_documento.EditValue = Properties.Resources.default_image_450;
                    LimpiarDatosClientes();
                    //timer1.Stop();
                    //binding_sectores.DataSource = Negocio.ClasesCN.CatalogosCN.Representantes_Cargar();
                    break;

                case 2:
                    tab_cierres_caja.PageVisible = tabFormaPago.PageVisible = tabProveedores.PageVisible = tabTiposAjustes.PageVisible = tabEmpleado.PageVisible = tabLinea.PageVisible = tabBodega.PageVisible = tabProductos.PageVisible = tabUnidadMedida.PageVisible = tabClientes.PageVisible = tabMarca.PageVisible = tabSectores.PageVisible = tabPrecios.PageVisible = tabLotes.PageVisible = false;
                    tabCategoria.PageVisible = true;
                    CargarCategoria();
                    gridCategoria.ContextMenuStrip = clicl_derecho_exportar;
                    grilla_exportar = gridCategoria;
                    //timer1.Stop();
                    break;

                case 3:
                    tab_cierres_caja.PageVisible = tabFormaPago.PageVisible = tabProveedores.PageVisible = tabTiposAjustes.PageVisible = tabEmpleado.PageVisible = tabLinea.PageVisible = tabBodega.PageVisible = tabProductos.PageVisible = tabUnidadMedida.PageVisible = tabClientes.PageVisible = tabCategoria.PageVisible = tabSectores.PageVisible = tabPrecios.PageVisible = tabLotes.PageVisible = false;
                    tabMarca.PageVisible = true;
                    CargarMarcas();
                    gridMarcas.ContextMenuStrip = clicl_derecho_exportar;
                    grilla_exportar = gridMarcas;
                    //timer1.Stop();
                    break;

                case 4:
                    tab_cierres_caja.PageVisible = tabFormaPago.PageVisible = tabProveedores.PageVisible = tabTiposAjustes.PageVisible = tabEmpleado.PageVisible = tabLinea.PageVisible = tabBodega.PageVisible = tabProductos.PageVisible = tabMarca.PageVisible = tabClientes.PageVisible = tabCategoria.PageVisible = tabSectores.PageVisible = tabPrecios.PageVisible = tabLotes.PageVisible = false;
                    tabUnidadMedida.PageVisible = true;
                    //timer1.Stop();
                    CargarUnidadMedida();
                    break;

                case 5:
                    tab_cierres_caja.PageVisible = tabFormaPago.PageVisible = tabProveedores.PageVisible = tabTiposAjustes.PageVisible = tabEmpleado.PageVisible = tabLinea.PageVisible = tabBodega.PageVisible = tabUnidadMedida.PageVisible = tabMarca.PageVisible = tabClientes.PageVisible = tabCategoria.PageVisible = tabSectores.PageVisible = tabPrecios.PageVisible = tabLotes.PageVisible = false;
                    tabProductos.PageVisible = true;
                    CargarCategoria();
                    CargarMarcas();
                    CargarLinea();
                    CargarUnidadMedida();
                    bindingSourceMoneda.DataSource = Negocio.ClasesCN.CatalogosCN.getMoneda();
                    repositoryItemLookUpEditNivelStock.DataSource = getNivelStock();
                    CargarProductos();
                    gridProductos.ContextMenuStrip = clicl_derecho_exportar;
                    grilla_exportar = gridProductos;
                    HabilitarDeshabilitarControles(3);
                    HabilitarDeshabilitarControles(4);
                    //timer1.Start();
                    break;

                case 6:
                    tab_cierres_caja.PageVisible = tabFormaPago.PageVisible = tabProveedores.PageVisible = tabTiposAjustes.PageVisible = tabEmpleado.PageVisible = tabLinea.PageVisible = tabProductos.PageVisible = tabUnidadMedida.PageVisible = tabMarca.PageVisible = tabClientes.PageVisible = tabCategoria.PageVisible = tabSectores.PageVisible = tabPrecios.PageVisible = tabLotes.PageVisible = false;
                    tabBodega.PageVisible = true;
                    //timer1.Stop();
                    CargarBodega();
                    break;

                case 7:
                    tab_cierres_caja.PageVisible = tabFormaPago.PageVisible = tabProveedores.PageVisible = tabTiposAjustes.PageVisible = tabEmpleado.PageVisible = tabBodega.PageVisible = tabProductos.PageVisible = tabUnidadMedida.PageVisible = tabMarca.PageVisible = tabClientes.PageVisible = tabCategoria.PageVisible = tabSectores.PageVisible = tabPrecios.PageVisible = tabLotes.PageVisible = false;
                    tabLinea.PageVisible = true;
                    bindingSourceMoneda.DataSource = Negocio.ClasesCN.CatalogosCN.getMoneda();
                    CargarLinea();
                    gridLinea.ContextMenuStrip = clicl_derecho_exportar;
                    grilla_exportar = gridLinea;
                    //timer1.Stop();
                    break;

                case 8:
                    tab_cierres_caja.PageVisible = tabFormaPago.PageVisible = tabProveedores.PageVisible = tabTiposAjustes.PageVisible = tabLinea.PageVisible = tabBodega.PageVisible = tabProductos.PageVisible = tabUnidadMedida.PageVisible = tabMarca.PageVisible = tabClientes.PageVisible = tabCategoria.PageVisible = tabSectores.PageVisible = tabPrecios.PageVisible = tabLotes.PageVisible = false;
                    tabEmpleado.PageVisible = true;
                    CargarEmpleados();
                    gridEmpleado.ContextMenuStrip = clicl_derecho_exportar;
                    grilla_exportar = gridEmpleado;
                    //timer1.Stop();
                    break;
                case 9:
                    tab_cierres_caja.PageVisible = tabFormaPago.PageVisible = tabProveedores.PageVisible = tabEmpleado.PageVisible = tabLinea.PageVisible = tabBodega.PageVisible = tabProductos.PageVisible = tabUnidadMedida.PageVisible = tabMarca.PageVisible = tabClientes.PageVisible = tabCategoria.PageVisible = tabSectores.PageVisible = tabPrecios.PageVisible = tabLotes.PageVisible = false;
                    tabTiposAjustes.PageVisible = true;
                    repositoryItemLookUpEdit_TipoAjuste.DataSource = Negocio.ClasesCN.CatalogosCN.getTipoAjuste();
                    repositoryItemLookUpEdit_TipoDocumento.DataSource = Negocio.ClasesCN.ParametrosCN.TipoDocumento_Select();
                    //timer1.Stop();
                    CargarTipoAjuste();
                    break;
                case 10:
                    tab_cierres_caja.PageVisible = tabFormaPago.PageVisible = tabTiposAjustes.PageVisible = tabEmpleado.PageVisible = tabLinea.PageVisible = tabBodega.PageVisible = tabProductos.PageVisible = tabUnidadMedida.PageVisible = tabMarca.PageVisible = tabClientes.PageVisible = tabCategoria.PageVisible = tabSectores.PageVisible = tabPrecios.PageVisible = tabLotes.PageVisible = false;
                    tabProveedores.PageVisible = true;
                    //timer1.Stop();
                    CargarProveedores();
                    break;
                case 11:
                    tab_cierres_caja.PageVisible = tabProveedores.PageVisible = tabTiposAjustes.PageVisible = tabEmpleado.PageVisible = tabLinea.PageVisible = tabBodega.PageVisible = tabProductos.PageVisible = tabUnidadMedida.PageVisible = tabMarca.PageVisible = tabClientes.PageVisible = tabCategoria.PageVisible = tabSectores.PageVisible = tabPrecios.PageVisible = tabLotes.PageVisible = false;
                    tabFormaPago.PageVisible = true;
                    bindingSourceMoneda.DataSource = Negocio.ClasesCN.CatalogosCN.getMoneda();
                    CargarFormaPago();
                    break;
                case 12:
                    tab_cierres_caja.PageVisible = tabProveedores.PageVisible = tabTiposAjustes.PageVisible = tabEmpleado.PageVisible = tabLinea.PageVisible = tabBodega.PageVisible = tabProductos.PageVisible = tabUnidadMedida.PageVisible = tabMarca.PageVisible = tabClientes.PageVisible = tabCategoria.PageVisible = tabFormaPago.PageVisible = tabPrecios.PageVisible = tabLotes.PageVisible = false;
                    tabSectores.PageVisible = true;
                    binding_sectores.DataSource = Negocio.ClasesCN.CatalogosCN.Representantes_Cargar();
                    grid_sectores.DataSource = binding_sectores;

                    break;
                case 13:
                    tabSectores.PageVisible = tabProveedores.PageVisible = tabTiposAjustes.PageVisible = tabEmpleado.PageVisible = tabLinea.PageVisible = tabBodega.PageVisible = tabProductos.PageVisible = tabUnidadMedida.PageVisible = tabMarca.PageVisible = tabClientes.PageVisible = tabCategoria.PageVisible = tabFormaPago.PageVisible = tabPrecios.PageVisible = tabLotes.PageVisible = false;
                    tab_cierres_caja.PageVisible = true;
                    break;

                case 14:
                    tab_cierres_caja.PageVisible = tabFormaPago.PageVisible = tabProveedores.PageVisible = tabTiposAjustes.PageVisible = tabEmpleado.PageVisible = tabLinea.PageVisible = tabBodega.PageVisible = tabProductos.PageVisible = tabUnidadMedida.PageVisible = tabClientes.PageVisible = tabMarca.PageVisible = tabSectores.PageVisible = tabCategoria.PageVisible = tabLotes.PageVisible = false;
                    tabPrecios.PageVisible = true;
                    //timer1.Stop();
                    CargarPrecios();
                    break;

                case 15:
                    tab_cierres_caja.PageVisible = tabFormaPago.PageVisible = tabProveedores.PageVisible = tabTiposAjustes.PageVisible = tabEmpleado.PageVisible = tabLinea.PageVisible = tabBodega.PageVisible = tabUnidadMedida.PageVisible = tabMarca.PageVisible = tabClientes.PageVisible = tabCategoria.PageVisible = tabSectores.PageVisible = tabPrecios.PageVisible = tabLotes.PageVisible = false;
                    tabProductos.PageVisible = false;
                    tabProductos.PageVisible = true;
                    CargarCategoria();
                    CargarMarcas();
                    CargarLinea();
                    CargarUnidadMedida();
                    bindingSourceMoneda.DataSource = Negocio.ClasesCN.CatalogosCN.getMoneda();
                    repositoryItemLookUpEditNivelStock.DataSource = getNivelStock();
                    CargarProductosDeshab();
                    gridProductos.ContextMenuStrip = clicl_derecho_exportar;
                    grilla_exportar = gridProductos;
                    HabilitarDeshabilitarControles(3);
                    HabilitarDeshabilitarControles(4);
                    //timer1.Start();
                    break;

                case 16:
                    tab_cierres_caja.PageVisible = tabFormaPago.PageVisible = tabProveedores.PageVisible = tabTiposAjustes.PageVisible = tabEmpleado.PageVisible = tabLinea.PageVisible = tabBodega.PageVisible = tabUnidadMedida.PageVisible = tabMarca.PageVisible = tabClientes.PageVisible = tabCategoria.PageVisible = tabSectores.PageVisible = tabPrecios.PageVisible = tabProductos.PageVisible = false;
                    tabLotes.PageVisible = true;
                    CargarLotes();
                    break;

                case 17:

                    tab_cierres_caja.PageVisible = tabFormaPago.PageVisible = tabProveedores.PageVisible = tabTiposAjustes.PageVisible = tabEmpleado.PageVisible = tabLinea.PageVisible = tabBodega.PageVisible = tabProductos.PageVisible = tabUnidadMedida.PageVisible = tabCategoria.PageVisible = tabMarca.PageVisible = tabSectores.PageVisible = tabPrecios.PageVisible = tabLotes.PageVisible = false;
                    tabClientes.PageVisible = true;
                    tabClientes.Text = "Listado de Clientes Mercado".ToUpper();
                    rp_id_sector.DataSource = Negocio.ClasesCN.CatalogosCN.Sectores_cargar().ToList();
                    rp_id_sector.DisplayMember = "nombre";
                    rp_id_sector.ValueMember = "id_sector";
                    repositoryItemLookUpEdit_Precio.DataSource = looks_precio.Properties.DataSource = Negocio.ClasesCN.CatalogosCN.getPrecio();
                    var RepresentantesMercado = Negocio.ClasesCN.CatalogosCN.Representantes_Cargar().Select(R => new { R.nombre_rep, R.id_representante }).ToList();
                    repository_representante_lookup.DataSource = RepresentantesMercado; //Representantes;

                    CargarClientesMercado();
                    gridCliente.ContextMenuStrip = clicl_derecho_exportar;
                    grilla_exportar = gridCliente;
                    editar.Checked = true;
                    looks_precio.ReadOnly = true;
                    bbi_guardar.Enabled = false;
                    precioEspecial();
                    pictureEditCliente_documento.EditValue = Properties.Resources.default_image_450;
                    LimpiarDatosClientes();
                    //timer1.Stop();
                    //binding_sectores.DataSource = Negocio.ClasesCN.CatalogosCN.Representantes_Cargar();
                    break;
            }
        }
        #region VENTA
        #region CLIENTES
        int contador;
        private void txt_ruc_Leave(object sender, EventArgs e)
        {
            string vId = id_cliente == 0.ToString() ? 0.ToString() : viewCliente.GetFocusedRowCellValue("id").ToString();
            if (vId == "0")
            {
                if (txt_ruc.Text.Trim() != string.Empty)
                {
                    contador = clientes_Activos.Where(o => o.ruc != string.Empty && o.ruc == txt_ruc.Text.Trim()).Count();
                    if (contador > 0)
                    {
                        dxErrorProvider1.SetError(txt_ruc, "Registro ya Existe");
                        bbi_guardar.Enabled = false;
                    }
                    else
                    {
                        dxErrorProvider1.ClearErrors();
                        bbi_guardar.Enabled = true;
                    }

                }
                else
                {
                    dxErrorProvider1.ClearErrors();
                    bbi_guardar.Enabled = true;
                }
            }
            
        }

        private void txt_nombre_Leave(object sender, EventArgs e)
        {
            string vId = id_cliente == 0.ToString() ? 0.ToString() : viewCliente.GetFocusedRowCellValue("id").ToString();
            if (vId == "0")
            {
                if (txt_nombre.Text.Trim() != string.Empty)
                {
                    contador = clientes_Activos.Where(o => o.nombre == txt_nombre.Text.Trim()).Count();
                    if (contador > 0)
                    {
                        dxErrorProvider1.SetError(txt_nombre, "Registro ya Existe");
                        bbi_guardar.Enabled = true;
                    }
                    else
                    {
                        dxErrorProvider1.ClearErrors();
                        bbi_guardar.Enabled = true;
                    }

                }
                else
                {
                    dxErrorProvider1.ClearErrors();
                    bbi_guardar.Enabled = true;
                }
            }
         
        }

        private void txt_Telefono_Leave(object sender, EventArgs e)
        {
            string vId = id_cliente == 0.ToString() ? 0.ToString() : viewCliente.GetFocusedRowCellValue("id").ToString();
            if (vId == "0")
            {
                if (txt_Telefono.Text.Trim() != string.Empty)
                {
                    contador = clientes_Activos.Where(o => o.telefono != string.Empty && o.telefono == txt_Telefono.Text.Trim()).Count();
                    if (contador > 0)
                    {
                        dxErrorProvider1.SetError(txt_Telefono, "Registro ya Existe");
                        bbi_guardar.Enabled = false;
                    }
                    else
                    {
                        dxErrorProvider1.ClearErrors();
                        bbi_guardar.Enabled = true;
                    }

                }
                else
                {
                    dxErrorProvider1.ClearErrors();
                    bbi_guardar.Enabled = true;
                }
            }
          
        }

        private void txt_Celular_Leave(object sender, EventArgs e)
        {
            string vId = id_cliente == 0.ToString() ? 0.ToString() : viewCliente.GetFocusedRowCellValue("id").ToString();
            if (vId == "0")
            {
                if (txt_Celular.Text.Trim() != string.Empty)
                {
                    contador = clientes_Activos.Where(o => o.celular != string.Empty && o.celular == txt_Celular.Text.Trim()).Count();
                    if (contador > 0)
                    {
                        dxErrorProvider1.SetError(txt_Celular, "Registro ya Existe");
                        bbi_guardar.Enabled = false;
                    }
                    else
                    {
                        dxErrorProvider1.ClearErrors();
                        bbi_guardar.Enabled = true;
                    }

                }
                else
                {
                    dxErrorProvider1.ClearErrors();
                    bbi_guardar.Enabled = true;
                }
            }
           
        }
        void CargarClientes( )
        {
            //clientes_Activos = 
            bindingSourceCliente.DataSource = Negocio.ClasesCN.CatalogosCN.Cliente_Cargar().Where(x => x.esMercado == Convert.ToBoolean(0));//clientes_Activos;// Negocio.ClasesCN.CatalogosCN.Cliente_Cargar();
        }

        void CargarClientesMercado()
        {
            //clientes_Activos_Mercado = Negocio.ClasesCN.CatalogosCN.Cliente_Cargar();
            bindingSourceCliente.DataSource = Negocio.ClasesCN.CatalogosCN.Cliente_Cargar().Where(x => x.esMercado == Convert.ToBoolean(1));
        }

        private void nbiCliente_LinkClicked(object sender,DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Mostrar_Pagina(1);
        }

        private void viewCliente_KeyDown(object sender,KeyEventArgs e)
        {
            try
            {
                if(e.KeyCode == Keys.Delete)
                {
                    if(viewCliente.RowCount > 0)
                    {
                        if(XtraMessageBox.Show("¿Desea eliminar este registro?","Cliente",MessageBoxButtons.YesNo,MessageBoxIcon.Question) != DialogResult.Yes) return;
                        int eliminar = Negocio.ClasesCN.CatalogosCN.Cliente_Eliminar(Convert.ToInt32(viewCliente.GetFocusedRowCellValue("id")), 0);
                        if(eliminar > 0)
                        {
                            XtraMessageBox.Show("Registro eliminado con exito","Cliente",MessageBoxButtons.OK,MessageBoxIcon.Information);
                            CargarClientes();
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show("Error :" + ex.Message);
            }
        }
        private void viewCliente_RowUpdated(object sender,DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            try
            {
                string vId = viewCliente.GetFocusedRowCellValue("id").ToString();
                string vCodigo = Convert.ToString(viewCliente.GetFocusedRowCellValue("codigo") ?? "").ToUpper().Trim();
                string vRuc = Convert.ToString(viewCliente.GetFocusedRowCellValue("ruc") ?? "").ToUpper().Trim();
                string vNombre = Convert.ToString(viewCliente.GetFocusedRowCellValue("nombre") ?? "").ToUpper().Trim();
                string vTelefono = Convert.ToString(viewCliente.GetFocusedRowCellValue("telefono") ?? "").ToUpper().Trim();
                string vCelular = Convert.ToString(viewCliente.GetFocusedRowCellValue("celular") ?? "").ToUpper().Trim();
                string vDireccion = Convert.ToString(viewCliente.GetFocusedRowCellValue("direccion") ?? "").ToUpper().Trim();
                string vCorreo = Convert.ToString(viewCliente.GetFocusedRowCellValue("correo") ?? "").ToUpper().Trim();
                int vid_sector = 0;
                try { vid_sector = Convert.ToInt32(viewCliente.GetFocusedRowCellValue("id_sector")); } catch(Exception) { };
                int vPrecio = 1;
                try { vPrecio = Convert.ToInt32(viewCliente.GetFocusedRowCellValue("precio")); } catch(Exception) { vPrecio = 1; }
                int  id_rep = Convert.ToInt32(viewCliente.GetFocusedRowCellValue(col_nombre_representantne) ?? 0);
                int  id_rep2 = Convert.ToInt32(viewCliente.GetFocusedRowCellValue(col_nombre_representante2) ?? 0);
                int  id_rep3 = Convert.ToInt32(viewCliente.GetFocusedRowCellValue(col_nombre_representante3) ?? 0);
                int  id_rep4 = Convert.ToInt32(viewCliente.GetFocusedRowCellValue(col_cedula_representante_1) ?? 0);
                if(!string.IsNullOrEmpty(vNombre.Trim().Replace(" ","")))
                {
                    if(vId == "0")
                    {
                        //nuevo

                        foreach(var list in Negocio.ClasesCN.CatalogosCN.Cliente_Cargar())
                        {
                            if((vNombre.ToUpper() == list.nombre.Trim()) || vCodigo == list.codigo)
                            {
                                XtraMessageBox.Show("Lo sentimos, este registro ya existe","Clientes",MessageBoxButtons.OK,MessageBoxIcon.Error);
                                CargarClientes();
                                viewCliente.MoveFirst();
                                return;
                            }
                        }

                        int okGuardar =0; //Negocio.ClasesCN.CatalogosCN.Cliente_Guardar(vCodigo, vRuc, vNombre, vTelefono, vCelular, vDireccion, vCorreo, vid_sector, vPrecio,id_rep,id_rep2,id_rep3,id_rep4,Clases.UsuarioLogueado.vID_Empleado);
                        if(okGuardar > 0)
                        {
                            XtraMessageBox.Show("Registro guardado satisfactoriamente","Clientes",MessageBoxButtons.OK,MessageBoxIcon.Information);
                            CargarClientes();
                            viewCliente.MoveFirst();
                        }
                        else
                        {
                            XtraMessageBox.Show("Lo sentimos, no se pudo guardar los datos, verifique la información","Clientes",MessageBoxButtons.OK,MessageBoxIcon.Error);
                            CargarClientes();
                            viewCliente.MoveFirst();
                        }
                    }
                    else
                    {
                        //actualizar
                        if(vId == 1.ToString())
                        {
                            XtraMessageBox.Show("Lo sentimos, No esta Permitido editar el cliente contado","Clientes",MessageBoxButtons.OK,MessageBoxIcon.Error);
                            CargarClientes();
                            viewCliente.MoveFirst();
                            return;
                        }

                        foreach(var list in Negocio.ClasesCN.CatalogosCN.Cliente_Cargar().Where(x => x.id != int.Parse(vId)))
                        {
                            if((vNombre == list.nombre.Trim()) || vCodigo == list.codigo || vId == list.id.ToString())
                            {
                                XtraMessageBox.Show("Lo sentimos, este registro ya existe","Clientes",MessageBoxButtons.OK,MessageBoxIcon.Error);
                                CargarClientes();
                                viewCliente.MoveFirst();
                                return;
                            }
                        }

                        int okEditar = 0;// Negocio.ClasesCN.CatalogosCN.Cliente_Actualizar(int.Parse(vId), vCodigo, vRuc, vNombre, vTelefono, vCelular, vDireccion, vCorreo, vid_sector, vPrecio, Clases.UsuarioLogueado.vID_Empleado,id_rep,id_rep2,id_rep3,id_rep4,Clases.UsuarioLogueado.vID_Empleado);
                        if(okEditar > 0)
                        {
                            XtraMessageBox.Show("Datos modificados satisfactoriamente","Clientes",MessageBoxButtons.OK,MessageBoxIcon.Information);
                            CargarClientes();
                            viewCliente.MoveNext();
                        }
                        else
                        {
                            XtraMessageBox.Show("Lo sentimos, no se pudo modificar los datos, verifique la información","Clientes",MessageBoxButtons.OK,MessageBoxIcon.Error);
                            CargarClientes();
                            viewCliente.MoveNext();
                        }


                    }

                }
                else
                {
                    XtraMessageBox.Show("Lo sentimos, no puede dejar el nombre vacio","Mensaje",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    CargarClientes();
                    viewCliente.MoveFirst();
                }
            }
            catch(Exception)
            {
                CargarClientes();
            }
        }

        private void viewCliente_CellValueChanged(object sender,DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            string vId = viewCliente.GetFocusedRowCellValue("id").ToString();
            string vCodigo = Convert.ToString(viewCliente.GetFocusedRowCellValue("codigo") ?? "").ToUpper().Trim();
            string vRuc = Convert.ToString(viewCliente.GetFocusedRowCellValue("ruc") ?? "").ToUpper().Trim();
            string vNombre = Convert.ToString(viewCliente.GetFocusedRowCellValue("nombre") ?? "").ToUpper().Trim();
            string vTelefono = Convert.ToString(viewCliente.GetFocusedRowCellValue("telefono") ?? "").ToUpper().Trim();
            string vCelular = Convert.ToString(viewCliente.GetFocusedRowCellValue("celular") ?? "").ToUpper().Trim();
            string vDireccion = Convert.ToString(viewCliente.GetFocusedRowCellValue("direccion") ?? "").ToUpper().Trim();
            string vCorreo = Convert.ToString(viewCliente.GetFocusedRowCellValue("correo") ?? "").ToUpper().Trim();
            int vid_sector = 0;
            try { vid_sector = Convert.ToInt32(viewCliente.GetFocusedRowCellValue("id_sector")); } catch(Exception) { };
            int vPrecio = 1;
            try { vPrecio = Convert.ToInt32(viewCliente.GetFocusedRowCellValue("precio")); } catch(Exception) { vPrecio = 1; }
            int  id_rep = Convert.ToInt32(viewCliente.GetFocusedRowCellValue(col_nombre_representantne) ?? 0);
            int  id_rep2 = Convert.ToInt32(viewCliente.GetFocusedRowCellValue(col_nombre_representante2) ?? 0);
            int  id_rep3 = Convert.ToInt32(viewCliente.GetFocusedRowCellValue(col_nombre_representante3) ?? 0);
            int  id_rep4 = Convert.ToInt32(viewCliente.GetFocusedRowCellValue(col_cedula_representante_1) ?? 0);
            if(e.Column.Name == "col_precio_cliente" && vId != "0")
            {
                var FAutorizacion= new  xfrm_autorizacion("CAMBIO DE PRECIOS A CLIENTE A" +vNombre);
                FAutorizacion.numero_permiso = 101;
                FAutorizacion.permiso = "CAMBIO DE PRECIOS A CLIENTES";
                FAutorizacion.ShowDialog();

                if(FAutorizacion.Autorizado)
                {

                    if(XtraMessageBox.Show("¿Desea modificar el registro?","Clientes",MessageBoxButtons.YesNo,MessageBoxIcon.Question) != DialogResult.Yes) { CargarClientes(); return; }
                    int okEditar = 0;//Negocio.ClasesCN.CatalogosCN.Cliente_Actualizar(int.Parse(vId), vCodigo, vRuc, vNombre, vTelefono, vCelular, vDireccion, vCorreo, vid_sector, vPrecio, Clases.UsuarioLogueado.vID_Empleado,id_rep,id_rep2,id_rep3,id_rep4,Clases.UsuarioLogueado.vID_Empleado);
                    if(okEditar > 0)
                    {
                        XtraMessageBox.Show("Datos modificados satisfactoriamente","Clientes",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        CargarClientes();
                        viewCliente.MoveNext();
                    }
                    else
                    {
                        XtraMessageBox.Show("Lo sentimos, no se pudo modificar los datos, verifique la información","Clientes",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        CargarClientes();
                        viewCliente.MoveNext();
                    }
                }
                else
                {
                    XtraMessageBox.Show("La acción de " + FAutorizacion.permiso + " no fue autorizada","Mensaje",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    CargarClientes();
                }
                // MessageBox.Show("");
                /// viewCliente.RowUpdated+= new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.viewCliente_RowUpdated);
            }
            //else
            //{

            //    int okEditar = Negocio.ClasesCN.CatalogosCN.Cliente_Actualizar(int.Parse(vId), vCodigo, vRuc, vNombre, vTelefono, vCelular, vDireccion, vCorreo, vid_sector, vPrecio, Clases.UsuarioLogueado.vID_Empleado,id_rep);
            //    if(okEditar > 0)
            //    {
            //        XtraMessageBox.Show("Datos modificados satisfactoriamente","Clientes",MessageBoxButtons.OK,MessageBoxIcon.Information);
            //        CargarClientes();
            //        viewCliente.MoveNext();
            //    }
            //    else
            //    {
            //        XtraMessageBox.Show("Lo sentimos, no se pudo modificar los datos, verifique la información","Clientes",MessageBoxButtons.OK,MessageBoxIcon.Error);
            //        CargarClientes();
            //        viewCliente.MoveNext();
            //    }

            //    //   viewCliente.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.viewCliente_RowUpdated);

            //}
        }

        private void pictureEditCliente_documento_EditValueChanged(object sender, EventArgs e)
        {
            if (pictureEditCliente_documento.EditValue == null) { pictureEditCliente_documento.EditValue = Properties.Resources.default_image_450; }
        }

        private void pictureEditCliente_documento_DoubleClick(object sender, EventArgs e)
        {
            if (viewCliente.RowCount > 0)
            {
                int vId = Convert.ToInt32(viewCliente.GetFocusedRowCellValue("id").ToString());
                var query_img = Negocio.ClasesCN.CatalogosCN.Cliente_SelectFila(vId).FirstOrDefault();

                if (query_img.imagen_documento != null)
                {
                    // Convertir foto de bytes a Image
                    Image img_actual = byteArrayToImage(query_img.imagen_documento);

                    var form = new xfrm_Viewer_image(img_actual);                    

                    form.ShowDialog();
                }
                else
                {
                    XtraMessageBox.Show("No hay imagen que mostrar!", "Cargar Imagen", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        // Convertir un arreglo de bytes a Image
        public Image byteArrayToImage(byte[] bytesArr)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream(bytesArr))
                {
                    Image img = Image.FromStream(ms);
                    return img;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
        #region SECTORES

        private void navitem_sectores_LinkClicked(object sender,DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Mostrar_Pagina(12);
        }
        private void gview_sectores_RowUpdated(object sender,DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            try
            {
                string VId_rep = gview_sectores.GetFocusedRowCellValue(col_id_representante).ToString();
                string vnombre_rep = Convert.ToString(gview_sectores.GetFocusedRowCellValue(col_nombre_representante) ?? "").ToUpper().Trim();
                string correo = Convert.ToString(gview_sectores.GetFocusedRowCellValue(col_correo_representante) ?? "").ToUpper().Trim();
                string direccion = Convert.ToString(gview_sectores.GetFocusedRowCellValue(col_direccion_rep) ?? "").ToUpper().Trim();
                string celu = Convert.ToString(gview_sectores.GetFocusedRowCellValue(col_cellular_rep) ?? "").ToUpper().Trim();
                string cedula = Convert.ToString(gview_sectores.GetFocusedRowCellValue(col_cedula) ?? "").ToUpper().Trim();
                // string v_descripcion = Convert.ToString(gview_sectores.GetFocusedRowCellValue(col_cellular_rep) ?? "").ToUpper().Trim();
                if(!string.IsNullOrEmpty(vnombre_rep.Trim().Replace(" ","")))
                {
                    if(VId_rep == "0")
                    {
                        //nuevo

                        foreach(var list in Negocio.ClasesCN.CatalogosCN.Representantes_Cargar())
                        {
                            if((vnombre_rep.ToUpper() == list.nombre_rep.ToUpper().ToString().Trim()))
                            {
                                XtraMessageBox.Show("Lo sentimos, ya existe representante la base de datos","Mensaje del sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
                                binding_sectores.DataSource = Negocio.ClasesCN.CatalogosCN.Representantes_Cargar();
                                grid_sectores.DataSource = binding_sectores;
                                gview_sectores.MoveFirst();
                                return;
                            }

                        }
                        int okGuardar = Negocio.ClasesCN.CatalogosCN.Representantes_Insert(vnombre_rep,correo,direccion,celu,cedula);
                        if(okGuardar > 0)
                        {
                            XtraMessageBox.Show("Registro guardado satisfactoriamente","Mensaje del sistema",MessageBoxButtons.OK,MessageBoxIcon.Information);
                            binding_sectores.DataSource = Negocio.ClasesCN.CatalogosCN.Representantes_Cargar();
                            grid_sectores.DataSource = binding_sectores;
                            gview_sectores.MoveFirst();

                        }
                        else
                        {
                            XtraMessageBox.Show("Lo sentimos, no se pudo guardar los datos, verifique la información","Mensaje del sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
                            binding_sectores.DataSource = Negocio.ClasesCN.CatalogosCN.Representantes_Cargar();
                            grid_sectores.DataSource = binding_sectores;
                            gview_sectores.MoveFirst();
                        }
                    }
                    else
                    {
                        foreach(var list in Negocio.ClasesCN.CatalogosCN.Representantes_Cargar().Where(V => V.id_representante.ToString() != VId_rep.ToString()))
                        {
                            if((vnombre_rep.Trim().ToUpper() == list.nombre_rep.ToString().Trim().ToUpper()))
                            {
                                XtraMessageBox.Show("Lo sentimos, ya existe un representante en la base de datos","Mensaje del sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
                                binding_sectores.DataSource = Negocio.ClasesCN.CatalogosCN.Representantes_Cargar();
                                grid_sectores.DataSource = binding_sectores;
                                gview_sectores.MoveFirst();
                                return;
                            }

                        }
                        if(XtraMessageBox.Show("¿Desea modificar el registro?","Mensaje del sistema",MessageBoxButtons.YesNo,MessageBoxIcon.Question) != DialogResult.Yes)
                        {
                            binding_sectores.DataSource = Negocio.ClasesCN.CatalogosCN.Representantes_Cargar();
                            grid_sectores.DataSource = binding_sectores;
                            return;
                        }

                        int okEditar = Negocio.ClasesCN.CatalogosCN.Representantes_Update(vnombre_rep,correo,direccion,celu,int.Parse( VId_rep),cedula);
                        if(okEditar > 0)
                        {
                            XtraMessageBox.Show("Datos modificados satisfactoriamente","Mensaje del sistema",MessageBoxButtons.OK,MessageBoxIcon.Information);
                            binding_sectores.DataSource = Negocio.ClasesCN.CatalogosCN.Representantes_Cargar();
                            grid_sectores.DataSource = binding_sectores;
                        }
                        else
                        {
                            XtraMessageBox.Show("Lo sentimos, no se pudo modificar los datos, verifique la información","Mensaje del sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
                            binding_sectores.DataSource = Negocio.ClasesCN.CatalogosCN.Representantes_Cargar();
                            grid_sectores.DataSource = binding_sectores;
                        }
                    }
                }
                else
                {
                    XtraMessageBox.Show("Lo sentimos, no puede dejar el nombre vacio ni el numero de sector","Mensaje del sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    CargarClientes();
                    viewCliente.MoveFirst();
                }
            }

            catch(Exception ex)
            {

                binding_sectores.DataSource = Negocio.ClasesCN.CatalogosCN.Sectores_cargar();
                grid_sectores.DataSource = binding_sectores;
            }
        }
        #endregion
        #region FORMA DE PAGO
        void CargarFormaPago( )
        {
            bindingSourceFormaPago.DataSource = Negocio.ClasesCN.VentasCN.FormaPago_Select();
        }

        private void nbiFormaPago_LinkClicked(object sender,DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Mostrar_Pagina(11);
        }

        private void viewFormaPago_RowUpdated(object sender,DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            try
            {
                string vId = viewFormaPago.GetFocusedRowCellValue("id").ToString();
                string vNombre = viewFormaPago.GetFocusedRowCellValue("descripcion").ToString().Trim().ToUpper();
                string vNombreCorto = viewFormaPago.GetFocusedRowCellValue("descripcion_corta").ToString().Trim().ToUpper();
                int vMoneda = Convert.ToInt32(viewFormaPago.GetFocusedRowCellValue("moneda"));
                bool efectivo = Convert.ToBoolean(viewFormaPago.GetFocusedRowCellValue("efectivo"));
                byte[] vImagen = (byte[])(viewFormaPago.GetFocusedRowCellValue("imagen"));

                if(!string.IsNullOrEmpty(vNombre.Trim().Replace(" ","")))
                {
                    if(vId == "0")
                    {
                        //nuevor

                        foreach(var list in Negocio.ClasesCN.VentasCN.FormaPago_Select())
                        {
                            if((vNombre == list.descripcion.Trim()))
                            {
                                XtraMessageBox.Show("Lo sentimos, este registro ya existe","Forma de Pago",MessageBoxButtons.OK,MessageBoxIcon.Error);
                                CargarFormaPago();
                                viewFormaPago.MoveFirst();
                                return;
                            }
                        }

                        int okGuardar = Negocio.ClasesCN.VentasCN.FormaPago_Insertar(vNombre, vNombreCorto, vMoneda, vImagen, efectivo);
                        if(okGuardar > 0)
                        {
                            XtraMessageBox.Show("Registro guardado satisfactoriamente","Forma de Pago",MessageBoxButtons.OK,MessageBoxIcon.Information);
                            CargarFormaPago();
                            viewFormaPago.MoveFirst();
                        }
                        else
                        {
                            XtraMessageBox.Show("Lo sentimos, no se pudo guardar los datos, verifique la información","Forma de Pago",MessageBoxButtons.OK,MessageBoxIcon.Error);
                            CargarFormaPago();
                            viewFormaPago.MoveFirst();
                        }
                    }
                    else
                    {
                        //actualizar

                        var query = Negocio.ClasesCN.VentasCN.getFormaPagoVenta().Where(x => x.id_forma_pago == int.Parse(vId)).FirstOrDefault();
                        if(query != null)
                        {
                            XtraMessageBox.Show("Lo sentimos, este registro ya fue utilizado en una factura","Forma de Pago",MessageBoxButtons.OK,MessageBoxIcon.Error);
                            return;
                        }

                        foreach(var list in Negocio.ClasesCN.CatalogosCN.Categoria_Cargar().Select(x => new { x.nombre,x.id }).Where(x => x.id != int.Parse(vId)))
                        {
                            if((vNombre == list.nombre.Trim()))
                            {
                                XtraMessageBox.Show("Lo sentimos, este registro ya existe","Forma de Pago",MessageBoxButtons.OK,MessageBoxIcon.Error);
                                CargarFormaPago();
                                viewFormaPago.MoveFirst();
                                return;
                            }
                        }

                        if(XtraMessageBox.Show("¿Desea modificar el registro?","Forma de Pago",MessageBoxButtons.YesNo,MessageBoxIcon.Question) != DialogResult.Yes) { CargarFormaPago(); return; }
                        int okEditar = Negocio.ClasesCN.VentasCN.FormaPago_Modificar(int.Parse(vId), vNombre, vNombreCorto,vMoneda, efectivo, vImagen, Clases.UsuarioLogueado.vID_Empleado);
                        if(okEditar > 0)
                        {
                            XtraMessageBox.Show("Datos modificados satisfactoriamente","Forma de Pago",MessageBoxButtons.OK,MessageBoxIcon.Information);
                            CargarFormaPago();
                            viewFormaPago.MoveNext();
                        }
                        else
                        {
                            XtraMessageBox.Show("Lo sentimos, no se pudo modificar los datos, verifique la información","Forma de Pago",MessageBoxButtons.OK,MessageBoxIcon.Error);
                            CargarFormaPago();
                            viewFormaPago.MoveNext();
                        }
                    }
                }
                else
                {
                    XtraMessageBox.Show("No puede dejar campos vacios","Forma de Pago",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    CargarFormaPago();
                    viewFormaPago.MoveFirst();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                CargarFormaPago();
            }
        }

        private void viewFormaPago_KeyDown(object sender,KeyEventArgs e)
        {
            try
            {
                if(e.KeyCode == Keys.Delete)
                {
                    if(viewFormaPago.RowCount > 0)
                    {
                        int vId = Convert.ToInt32(viewFormaPago.GetFocusedRowCellValue("id"));
                        var query = Negocio.ClasesCN.VentasCN.getFormaPagoVenta().Where(x => x.id_forma_pago == vId).FirstOrDefault();
                        if(query != null)
                        {
                            XtraMessageBox.Show("Lo sentimos, este registro ya fue utilizado en una factura","Forma de Pago",MessageBoxButtons.OK,MessageBoxIcon.Error);
                            return;
                        }

                        if(XtraMessageBox.Show("¿Desea eliminar este registro?","Forma de Pago",MessageBoxButtons.YesNo,MessageBoxIcon.Question) != DialogResult.Yes) return;
                        int eliminar = Negocio.ClasesCN.VentasCN.FormaPago_Eliminar(vId, Clases.UsuarioLogueado.vID_Empleado);
                        if(eliminar > 0)
                        {
                            XtraMessageBox.Show("Registro eliminado con exito","Forma de Pago",MessageBoxButtons.OK,MessageBoxIcon.Information);
                            CargarFormaPago();
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show("Error :" + ex.Message);
            }
        }

        #endregion

        #endregion
        #region PRODUCTOS

        #region CATEGORIA
        void CargarCategoria( )
        {
            bindingSourceCategoria.DataSource = Negocio.ClasesCN.CatalogosCN.Categoria_Cargar();
            gridCategoria.DataSource = bindingSourceCategoria;
        }

        private void nbiCategoria_LinkClicked(object sender,DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Mostrar_Pagina(2);
            bbi_modificar_grupos.Enabled = bbi_exportar_grupos.Enabled = bbi_nuevo_grupo.Enabled =  true;
        }

        private void viewCategoria_RowUpdated(object sender,DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            try
            {
                string vId = viewCategoria.GetFocusedRowCellValue("id").ToString();
                string vNombre = viewCategoria.GetFocusedRowCellValue("nombre").ToString().Trim().ToUpper();
                string v_codigo = viewCategoria.GetFocusedRowCellValue("codigo").ToString().Trim().ToUpper();
                byte[] vImagen = (byte[])(viewCategoria.GetFocusedRowCellValue("imagen"));

                if(!string.IsNullOrEmpty(vNombre.Trim().Replace(" ","")))
                {
                    if(vId == "0")
                    {
                        //nuevor

                        foreach(var list in Negocio.ClasesCN.CatalogosCN.Categoria_Cargar().Select(x => new { x.nombre }))
                        {
                            if((vNombre == list.nombre.Trim()))
                            {
                                XtraMessageBox.Show("Lo sentimos, este registro ya existe","Categoria",MessageBoxButtons.OK,MessageBoxIcon.Error);
                                CargarCategoria();
                                viewCategoria.MoveFirst();
                                return;
                            }
                        }

                        int okGuardar = Negocio.ClasesCN.CatalogosCN.Categoria_Guardar(vNombre, vImagen,v_codigo);
                        if(okGuardar > 0)
                        {
                            XtraMessageBox.Show("Registro guardado satisfactoriamente","Categoria",MessageBoxButtons.OK,MessageBoxIcon.Information);
                            CargarCategoria();
                            viewCategoria.MoveFirst();
                        }
                        else
                        {
                            XtraMessageBox.Show("Lo sentimos, no se pudo guardar los datos, verifique la información","Categoria",MessageBoxButtons.OK,MessageBoxIcon.Error);
                            CargarCategoria();
                            viewCategoria.MoveFirst();
                        }
                    }
                    else
                    {
                        //actualizar

                        foreach(var list in Negocio.ClasesCN.CatalogosCN.Categoria_Cargar().Select(x => new { x.nombre,x.id }).Where(x => x.id != int.Parse(vId)))
                        {
                            if((vNombre == list.nombre.Trim()))
                            {
                                XtraMessageBox.Show("Lo sentimos, este registro ya existe","Categoria",MessageBoxButtons.OK,MessageBoxIcon.Error);
                                CargarCategoria();
                                viewCategoria.MoveFirst();
                                return;
                            }
                        }

                        if(XtraMessageBox.Show("¿Desea modificar el registro?","Categoria",MessageBoxButtons.YesNo,MessageBoxIcon.Question) != DialogResult.Yes) { CargarCategoria(); return; }
                        int okEditar = Negocio.ClasesCN.CatalogosCN.Categoria_Actualizar(int.Parse(vId), vNombre, vImagen, 0);
                        if(okEditar > 0)
                        {
                            XtraMessageBox.Show("Datos modificados satisfactoriamente","Categoria",MessageBoxButtons.OK,MessageBoxIcon.Information);
                            CargarCategoria();
                            viewCategoria.MoveNext();
                        }
                        else
                        {
                            XtraMessageBox.Show("Lo sentimos, no se pudo modificar los datos, verifique la información","Categoria",MessageBoxButtons.OK,MessageBoxIcon.Error);
                            CargarCategoria();
                            viewCategoria.MoveNext();
                        }
                    }
                }
                else
                {
                    XtraMessageBox.Show("No puede dejar campos vacios","Categoria",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    CargarCategoria();
                    viewCategoria.MoveFirst();
                }
            }
            catch(Exception)
            {
                CargarCategoria();
            }
        }

        private void bbi_nuevo_grupo_ItemClick(object sender,DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bbi_modificar_grupos.Enabled = bbi_exportar_grupos.Enabled = bbi_nuevo_grupo.Enabled = false;
            txt_nombre_grupo.Enabled = true;
            txt_codigo_grupo.Enabled = false;
            id_grupo = 0.ToString();
            txt_codigo_grupo.Text = String.Empty;
            txt_nombre_grupo.Text = string.Empty;
            txt_nombre_grupo.Focus();

        }
        private void bbi_modificar_grupos_ItemClick(object sender,DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bbi_modificar_grupos.Enabled = bbi_exportar_grupos.Enabled = bbi_nuevo_grupo.Enabled = false;
            txt_nombre_grupo.Enabled = true;
            txt_codigo_grupo.Enabled = false;
        }
        private void bbi_guardar_grupos_ItemClick(object sender,DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string vId = id_grupo;//viewCategoria.GetFocusedRowCellValue("id").ToString();
            string vNombre = txt_nombre_grupo.Text.ToString(); //viewCategoria.GetFocusedRowCellValue("nombre").ToString().Trim().ToUpper();
            string v_codigo = string.Empty;//viewCategoria.GetFocusedRowCellValue("codigo").ToString().Trim().ToUpper();
            try
            {
                if(vId == "0")
                {
                    //nuevor

                    foreach(var list in Negocio.ClasesCN.CatalogosCN.Categoria_Cargar().Select(x => new { x.nombre }))
                    {
                        if((vNombre == list.nombre.Trim()))
                        {
                            XtraMessageBox.Show("Lo sentimos, este registro ya existe","Categoria",MessageBoxButtons.OK,MessageBoxIcon.Error);
                            CargarCategoria();
                            viewCategoria.MoveFirst();
                            return;
                        }
                    }

                    int okGuardar = Negocio.ClasesCN.CatalogosCN.Categoria_Guardar(vNombre, null,v_codigo);
                    if(okGuardar > 0)
                    {
                        XtraMessageBox.Show("Registro guardado satisfactoriamente","Categoria",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        CargarCategoria();
                        
                        viewCategoria.MoveFirst();
                    }
                    else
                    {
                        XtraMessageBox.Show("Lo sentimos, no se pudo guardar los datos, verifique la información","Categoria",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        CargarCategoria();
                        viewCategoria.MoveFirst();
                    }
                }
                else
                {
                    //actualizar

                    foreach(var list in Negocio.ClasesCN.CatalogosCN.Categoria_Cargar().Select(x => new { x.nombre,x.id }).Where(x => x.id != int.Parse(vId)))
                    {
                        if((vNombre == list.nombre.Trim()))
                        {
                            XtraMessageBox.Show("Lo sentimos, este registro ya existe","Categoria",MessageBoxButtons.OK,MessageBoxIcon.Error);
                            CargarCategoria();
                            viewCategoria.MoveFirst();
                            return;
                        }
                    }

                    if(XtraMessageBox.Show("¿Desea modificar el registro?","Categoria",MessageBoxButtons.YesNo,MessageBoxIcon.Question) != DialogResult.Yes) { CargarCategoria(); return; }
                    int okEditar = Negocio.ClasesCN.CatalogosCN.Categoria_Actualizar(int.Parse(vId), vNombre, null, 0);
                    if(okEditar > 0)
                    {
                        XtraMessageBox.Show("Datos modificados satisfactoriamente","Categoria",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        CargarCategoria();
                        viewCategoria.MoveFirst();
                    }
                    else
                    {
                        XtraMessageBox.Show("Lo sentimos, no se pudo modificar los datos, verifique la información","Categoria",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        CargarCategoria();
                        viewCategoria.MoveFirst();
                    }
                }
            }
            catch(Exception ex)
            {
            }
        }
        private void viewCategoria_FocusedRowChanged(object sender,DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            id_grupo = Convert.ToString(viewCategoria.GetFocusedRowCellValue("id") ?? "0").ToUpper().Trim();
            string nombre_grupo=Convert.ToString (viewCategoria.GetFocusedRowCellValue("nombre")??"").ToString();
            string codigo_grupo= Convert.ToString(viewCategoria.GetFocusedRowCellValue("codigo")??"").ToString();
            txt_nombre_grupo.EditValue = nombre_grupo;
            txt_codigo_grupo.EditValue = codigo_grupo;
            bbi_cancelar_grupos_ItemClick(null,null);
        }
        private void bbi_cancelar_grupos_ItemClick(object sender,DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bbi_modificar_grupos.Enabled = true;
            bbi_nuevo_grupo.Enabled = true;
            bbi_exportar_grupos.Enabled = true;
            txt_nombre_grupo.Enabled = false;
            id_grupo = Convert.ToString(viewCategoria.GetFocusedRowCellValue("id") ?? "0").ToUpper().Trim();

        }

        private void viewCategoria_KeyDown(object sender,KeyEventArgs e)
        {
            try
            {
                if(e.KeyCode == Keys.Delete)
                {
                    if(viewCategoria.RowCount > 0)
                    {
                        if(XtraMessageBox.Show("¿Desea eliminar este registro?","Categoria",MessageBoxButtons.YesNo,MessageBoxIcon.Question) != DialogResult.Yes) return;
                        int eliminar = Negocio.ClasesCN.CatalogosCN.Categoria_Eliminar(Convert.ToInt32(viewCategoria.GetFocusedRowCellValue("id")), 0);
                        if(eliminar > 0)
                        {
                            XtraMessageBox.Show("Registro eliminado con exito","Categoria",MessageBoxButtons.OK,MessageBoxIcon.Information);
                            CargarCategoria();
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show("Error :" + ex.Message);
            }
        }
        #endregion
        #region MARCA

        void CargarMarcas( )
        {
            bindingSourceMarca.DataSource = Negocio.ClasesCN.CatalogosCN.Marca_Cargar();
            gridMarcas.DataSource = bindingSourceMarca;
        }

        private void nbiMarca_LinkClicked(object sender,DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Mostrar_Pagina(3);
        }

        private void viewMarcas_RowUpdated(object sender,DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            try
            {
                string vId = viewMarcas.GetFocusedRowCellValue("id").ToString();
                string vNombre = viewMarcas.GetFocusedRowCellValue("nombre").ToString().Trim().ToUpper();
                byte[] vImagen = (byte[])(viewMarcas.GetFocusedRowCellValue("imagen"));

                if(!string.IsNullOrEmpty(vNombre.Trim().Replace(" ","")))
                {
                    if(vId == "0")
                    {
                        //nuevo

                        foreach(var list in Negocio.ClasesCN.CatalogosCN.Marca_Cargar().Select(x => new { x.nombre }))
                        {
                            if((vNombre == list.nombre.Trim()))
                            {
                                XtraMessageBox.Show("Lo sentimos, este registro ya existe","Marca",MessageBoxButtons.OK,MessageBoxIcon.Error);
                                CargarMarcas();
                                viewMarcas.MoveFirst();
                                return;
                            }
                        }

                        int okGuardar = Negocio.ClasesCN.CatalogosCN.Marca_Guardar(vNombre, vImagen);
                        if(okGuardar > 0)
                        {
                            XtraMessageBox.Show("Registro guardado satisfactoriamente","Marca",MessageBoxButtons.OK,MessageBoxIcon.Information);
                            CargarMarcas();
                            viewMarcas.MoveFirst();
                        }
                        else
                        {
                            XtraMessageBox.Show("Lo sentimos, no se pudo guardar los datos, verifique la información","Marca",MessageBoxButtons.OK,MessageBoxIcon.Error);
                            CargarMarcas();
                            viewMarcas.MoveFirst();
                        }
                    }
                    else
                    {
                        //actualizar

                        foreach(var list in Negocio.ClasesCN.CatalogosCN.Marca_Cargar().Select(x => new { x.nombre,x.id }).Where(x => x.id != int.Parse(vId)))
                        {
                            if((vNombre == list.nombre.Trim()))
                            {
                                XtraMessageBox.Show("Lo sentimos, este registro ya existe","Marca",MessageBoxButtons.OK,MessageBoxIcon.Error);
                                CargarMarcas();
                                viewMarcas.MoveFirst();
                                return;
                            }
                        }

                        if(XtraMessageBox.Show("¿Desea modificar el registro?","Marca",MessageBoxButtons.YesNo,MessageBoxIcon.Question) != DialogResult.Yes) { CargarMarcas(); return; }
                        int okEditar = Negocio.ClasesCN.CatalogosCN.Marca_Actualizar(int.Parse(vId), vNombre, vImagen, 0);
                        if(okEditar > 0)
                        {
                            XtraMessageBox.Show("Datos modificados satisfactoriamente","Marca",MessageBoxButtons.OK,MessageBoxIcon.Information);
                            CargarMarcas();
                            viewMarcas.MoveNext();
                        }
                        else
                        {
                            XtraMessageBox.Show("Lo sentimos, no se pudo modificar los datos, verifique la información","Marca",MessageBoxButtons.OK,MessageBoxIcon.Error);
                            CargarMarcas();
                            viewMarcas.MoveNext();
                        }
                    }
                }
                else
                {
                    XtraMessageBox.Show("No puede dejar campos vacios","Marca",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    CargarMarcas();
                    viewMarcas.MoveFirst();
                }
            }
            catch(Exception)
            {
                CargarMarcas();
            }
        }

        private void viewMarcas_KeyDown(object sender,KeyEventArgs e)
        {
            try
            {
                if(e.KeyCode == Keys.Delete)
                {
                    if(viewMarcas.RowCount > 0)
                    {
                        if(XtraMessageBox.Show("¿Desea eliminar este registro?","Marca",MessageBoxButtons.YesNo,MessageBoxIcon.Question) != DialogResult.Yes) return;
                        int eliminar = Negocio.ClasesCN.CatalogosCN.Marca_Eliminar(Convert.ToInt32(viewMarcas.GetFocusedRowCellValue("id")), 0);
                        if(eliminar > 0)
                        {
                            XtraMessageBox.Show("Registro eliminado con exito","Marca",MessageBoxButtons.OK,MessageBoxIcon.Information);
                            CargarMarcas();
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show("Error :" + ex.Message);
            }
        }
        #endregion

        #region PRECIOS

        private void nbiPrecios_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Mostrar_Pagina(14);
        }

        void CargarPrecios()
        {
            bindingSourcePrecios.DataSource = Negocio.ClasesCN.CatalogosCN.Get_Precios();
            gridPrecios.DataSource = bindingSourcePrecios;
        }

        private void ViewPrecios_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            try
            {
                string vId = ViewPrecios.GetFocusedRowCellValue("id").ToString();
                string vNombre = ViewPrecios.GetFocusedRowCellValue("descripcion_corta").ToString().Trim().ToUpper();
                var vObservacion = Convert.ToString(ViewPrecios.GetFocusedRowCellValue("observacion")).Equals(DBNull.Value) ? "" : Convert.ToString(ViewPrecios.GetFocusedRowCellValue("observacion")).Trim().ToUpper();

                if (!string.IsNullOrEmpty(vNombre.Trim().Replace(" ", "")))
                {
                    if (vId == "0")
                    {
                        //nuevo

                        foreach (var list in Negocio.ClasesCN.CatalogosCN.Get_Precios().Select(x => new { x.descripcion_corta }))
                        {
                            if ((vNombre == list.descripcion_corta.Trim()))
                            {
                                XtraMessageBox.Show("Lo sentimos, este nombre ya está en uso", "Precios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                CargarPrecios();
                                ViewPrecios.MoveFirst();
                                return;
                            }
                        }

                        DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(typeof(Principal.WaitForm1));
                        var okGuardar = Negocio.ClasesCN.CatalogosCN.Precio_GUARDAR(vNombre, vObservacion.ToString(), 1, 1, DateTime.Now);
                        if (okGuardar.Item1 > 0 && okGuardar.Item2)
                        {
                            XtraMessageBox.Show("Registro guardado satisfactoriamente", "Precios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargarPrecios();
                            ViewPrecios.MoveLast();
                        }
                        DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm();
                    }
                    else
                    {
                        //actualizar

                        foreach (var list in Negocio.ClasesCN.CatalogosCN.Get_Precios().Select(x => new { x.descripcion_corta, x.id }).Where(x => x.id != int.Parse(vId)))
                        {
                            if ((vNombre == list.descripcion_corta.Trim()))
                            {
                                XtraMessageBox.Show("Lo sentimos, este nombre ya está en uso", "Precio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                CargarPrecios();
                                ViewPrecios.MoveFirst();
                                return;
                            }
                        }

                        if (XtraMessageBox.Show("¿Desea modificar el registro?", "Precio", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) { CargarPrecios(); return; }

                        DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(typeof(Principal.WaitForm1));
                        int okEditar = Negocio.ClasesCN.CatalogosCN.Precio_Actualizar(int.Parse(vId), vNombre, vObservacion, DateTime.Now);
                        if (okEditar > 0)
                        {
                            XtraMessageBox.Show("Datos modificados satisfactoriamente", "Precio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargarPrecios();
                            ViewPrecios.MoveNext();
                        }
                        DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm();
                    }
                }
                else
                {
                    XtraMessageBox.Show("No puede dejar campos vacios", "Precio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CargarPrecios();
                    ViewPrecios.MoveFirst();
                    return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                CargarPrecios();
            }
        }

        private void ViewPrecios_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete)
                {
                    if (ViewPrecios.RowCount > 0)
                    {
                        if (XtraMessageBox.Show("¿Está completamente seguro(a) de eliminar este registro?", "Precio", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
                        int eliminar = Negocio.ClasesCN.CatalogosCN.Precio_Eliminar(Convert.ToInt32(ViewPrecios.GetFocusedRowCellValue("id")));
                        if (eliminar > 0)
                        {
                            XtraMessageBox.Show("Registro eliminado con exito", "Precio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargarPrecios();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error :" + ex);
            }
        }


        #endregion


        #region LINEA

        void CargarLinea( )
        {
            bindingSourceLinea.DataSource = Negocio.ClasesCN.CatalogosCN.Linea_Cargar();
            bindingSourceCategoria.DataSource = Negocio.ClasesCN.CatalogosCN.Categoria_Cargar();
            //bindingSourceLinea.DataSource = Negocio.ClasesCN.CatalogosCN.Linea_Cargar();
            //gridLinea.DataSource = CargaDatosLinea();
            //bindingSourceCategoria.DataSource = Negocio.ClasesCN.CatalogosCN.Categoria_Cargar();
        }

        void CargarLotes()
        {
            bindingSourceLotes.DataSource = Negocio.ClasesCN.CatalogosCN.CargarLotes();
            repositoryItemLookUpEdit_Lote.DataSource = Negocio.ClasesCN.CatalogosCN.getActivoLotes();
        }

        private void nbiLinea_LinkClicked(object sender,DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Mostrar_Pagina(7);
            txt_nombre_subgrupo.ReadOnly = txtDescripcion_subgrupo.ReadOnly = look_grupo_de_subgrupo.ReadOnly = lookUpEdit_Moneda_Subgrupos.ReadOnly = txt_codigo_subgrupo.ReadOnly =txt_precio_mayor.ReadOnly= txt_precio_4.ReadOnly=txt_precio_detalle.ReadOnly=txt_precio_Eventual.ReadOnly = txtprecio_5.ReadOnly = txtprecio_6.ReadOnly = ck_BloquearEdicionSG.ReadOnly = true;
            bbi_nuevo_subgrupo.Enabled = true;
            bbi_exportar_subgrupop.Enabled = true;
            bbi_refrescar_subgrupo.Enabled = true;
            bbi_editar_subgrupos.Enabled = true;
        }

        void CargarTablasLinea()
        {
            DataColumn parentColumn = new DataColumn("id", typeof(int));
            Tabla_Lineas.Columns.Add(parentColumn);
            Tabla_Lineas.Columns.AddRange(new DataColumn[]
                {
                    //new DataColumn("id",typeof(int)),
                    new DataColumn("nombre",typeof(string)),
                    new DataColumn("fecha_registro",typeof(DateTime)),
                    new DataColumn("activo",typeof(bool)),
                    new DataColumn("id_grupo",typeof(int)),
                    new DataColumn("precio_mayor",typeof(decimal)),
                    new DataColumn("precio_eventual",typeof(decimal)),
                    new DataColumn("precio_unitario",typeof(decimal)),
                    new DataColumn("precio_4",typeof(decimal)),
                    new DataColumn("codigo",typeof(string)),
                    new DataColumn("moneda_subgrupo",typeof(int)),
                    new DataColumn("descripcion_subgrupo",typeof(string))
                });

            DataColumn childrenColumn = new DataColumn("id_linea", typeof(int));
            Tabla_Precio_Detalle_Linea.Columns.Add(childrenColumn);
            Tabla_Precio_Detalle_Linea.Columns.AddRange(new DataColumn[]
                {
                    //new DataColumn("id_linea",typeof(string)),
                    new DataColumn("id_precio",typeof(int)),
                    new DataColumn("descripcion_corta",typeof(string)),
                    new DataColumn("monto",typeof(decimal))
                });
        }

        private DataTable CargaDatosLinea()
        {
            try
            {
                Tabla_Lineas.Clear();
                Tabla_Precio_Detalle_Linea.Clear();

                var lineas = Negocio.ClasesCN.CatalogosCN.Linea_Cargar();
                foreach (var l in lineas)
                {
                    DataRow fila = Tabla_Lineas.NewRow();
                    fila[0] = l.id;
                    fila[1] = l.nombre;
                    fila[2] = l.fecha_registro;
                    fila[3] = l.activo;
                    fila[4] = l.id_grupo;
                    fila[5] = l.precio_mayor;
                    fila[6] = l.precio_eventual;
                    fila[7] = l.precio_unitario;
                    fila[8] = l.precio_4;
                    fila[9] = l.codigo;
                    fila[10] = l.moneda_subgrupo.Equals(DBNull.Value) ? 0 : Convert.ToInt32(l.moneda_subgrupo);
                    fila[11] = l.descripcion_subgrupo ?? string.Empty;

                    Tabla_Lineas.Rows.Add(fila);
                }

                var Detalle = Negocio.ClasesCN.CatalogosCN.Precio_Detalle_linea_SELECT();
                foreach (var d in Detalle)
                {
                    DataRow fila = Tabla_Precio_Detalle_Linea.NewRow();
                    fila[0] = d.id_linea;
                    fila[1] = d.id_precio;
                    fila[2] = d.descripcion_corta;
                    fila[3] = d.monto;

                    Tabla_Precio_Detalle_Linea.Rows.Add(fila);
                }

                using (DataSet ds = new DataSet())
                {
                    ds.Tables.AddRange(new DataTable[] { Tabla_Lineas.Copy(), Tabla_Precio_Detalle_Linea.Copy() });

                    DataRelation relation = new DataRelation("Precios", ds.Tables[0].Columns[0], ds.Tables[1].Columns[0], false);
                    ds.Relations.Add(relation);
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        private void viewLinea_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int id_linea = Convert.ToInt32(viewLinea.GetFocusedRowCellValue(col_id_subgrupo));

                if (viewLinea.RowCount > 0)
                {
                    xfrm_Actualizar_precios form = new xfrm_Actualizar_precios(id_linea, 0);
                    form.ShowDialog();
                    if (form.vRetorno) { CargarLinea(); }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                CargarLinea();
                throw;
            }
        }

        private void viewLinea_RowUpdated(object sender,DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            try
            {
                string vId = viewLinea.GetFocusedRowCellValue("id").ToString();
                string vid_grupo = viewLinea.GetFocusedRowCellValue("id_grupo").ToString();
                string vNombre = viewLinea.GetFocusedRowCellValue("nombre").ToString().Trim().ToUpper();
                string v_precio_mayor=viewLinea.GetFocusedRowCellValue(col_precio_mayor).ToString();
                string v_precio_eventual=viewLinea.GetFocusedRowCellValue(col_precio_eventual).ToString();
                string v_precio_unitario=viewLinea.GetFocusedRowCellValue(col_precio_unitario).ToString();
                string v_precio_4=viewLinea.GetFocusedRowCellValue(col_precio_4).ToString();
                string v_codigo=viewLinea.GetFocusedRowCellValue(col_codigo_subgrupo).ToString();
                int moneda_subgrupo = Convert.ToInt32(viewLinea.GetFocusedRowCellValue(col_moneda_subgrupo));
                string descripcion_subgrupo = Convert.ToString(viewLinea.GetFocusedRowCellValue(col_descripcion_subgrupo).ToString());

                if (!string.IsNullOrEmpty(vNombre.Trim().Replace(" ","")))
                {
                    if(vId == "0")
                    {
                        //nuevo
                        foreach(var list in Negocio.ClasesCN.CatalogosCN.Linea_Cargar().Select(x => new { x.nombre }))
                        {
                            if((vNombre == list.nombre.Trim()))
                            {
                                XtraMessageBox.Show("Lo sentimos, este registro ya existe","Linea",MessageBoxButtons.OK,MessageBoxIcon.Error);
                                CargarLinea();
                                viewLinea.MoveFirst();
                                return;
                            }
                        }

                        //int okGuardar = Negocio.ClasesCN.CatalogosCN.Linea_Guardar(vNombre,Convert.ToInt32(vid_grupo),Convert.ToDecimal(v_precio_mayor),Convert.ToDecimal(v_precio_eventual),Convert.ToDecimal(v_precio_unitario),Convert.ToDecimal(v_precio_4),v_codigo, moneda_subgrupo, descripcion_subgrupo);
                        //if(okGuardar > 0)
                        //{
                        //    XtraMessageBox.Show("Registro guardado satisfactoriamente","Linea",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        //    CargarLinea();
                        //    viewLinea.MoveFirst();
                        //}
                        //else
                        //{
                        //    XtraMessageBox.Show("Lo sentimos, no se pudo guardar los datos, verifique la información","Linea",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        //    CargarLinea();
                        //    viewLinea.MoveFirst();
                        //}
                    }
                    else
                    {
                        //actualizar
                        foreach(var list in Negocio.ClasesCN.CatalogosCN.Linea_Cargar().Select(x => new { x.nombre,x.id }).Where(x => x.id != int.Parse(vId)))
                        {
                            if((vNombre == list.nombre.Trim()))
                            {
                                XtraMessageBox.Show("Lo sentimos, este registro ya existe","Linea",MessageBoxButtons.OK,MessageBoxIcon.Error);
                                CargarLinea();
                                viewLinea.MoveFirst();
                                return;
                            }
                        }

                        if(XtraMessageBox.Show("¿Desea Actualizar este registro?\n ¡Recuerde que al Modificar Precios aqui, Los precios del Catálogo de Productos tambien serán Modificados!","Linea",MessageBoxButtons.YesNo,MessageBoxIcon.Question) != DialogResult.Yes) { CargarLinea(); return; }
                        //int okEditar = Negocio.ClasesCN.CatalogosCN.Linea_Actualizar(int.Parse(vId), vNombre, 0,Convert.ToInt32(vid_grupo),Convert.ToDecimal(v_precio_mayor),Convert.ToDecimal(v_precio_eventual),Convert.ToDecimal(v_precio_unitario),Convert.ToDecimal(v_precio_4),v_codigo, moneda_subgrupo, descripcion_subgrupo);
                        //if(okEditar > 0)
                        //{
                        //    XtraMessageBox.Show("Datos modificados satisfactoriamente","Linea",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        //    CargarLinea();
                        //    viewLinea.MoveNext();
                        //}
                        //else
                        //{
                        //    XtraMessageBox.Show("Lo sentimos, no se pudo modificar los datos, verifique la información","Linea",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        //    CargarLinea();
                        //    viewLinea.MoveNext();
                        //}
                    }
                }
                else
                {
                    XtraMessageBox.Show("No puede dejar campos vacios","Linea",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    CargarLinea();
                    viewLinea.MoveFirst();
                }
            }
            catch(Exception)
            {
                CargarLinea();
            }
        }

        private void viewLinea_ValidatingEditor(object sender,DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            GridView view = sender as GridView;

            try
            {
                switch(view.FocusedColumn.FieldName)
                {
                    case "precio_mayor":
                        if((Convert.ToDecimal(e.Value) < 0.00m))
                            e.Valid = false;
                        break;
                    case "precio_eventual":
                        if((Convert.ToDecimal(e.Value) < 0.00m))
                            e.Valid = false;
                        break;
                    case "precio_unitario":
                        if((Convert.ToDecimal(e.Value) < 0.00m))
                            e.Valid = false;
                        break;
                    case "precio_4":
                        if((Convert.ToDecimal(e.Value) < 0.00m))
                            e.Valid = false;
                        break;
                }
            }
            catch(Exception) { e.Valid = false; }
        }

        private void viewLinea_InvalidValueException(object sender,DevExpress.XtraEditors.Controls.InvalidValueExceptionEventArgs e)
        {
            GridView view = sender as GridView;

            switch(view.FocusedColumn.FieldName)
            {
                case "precio_mayor":
                    e.ExceptionMode = ExceptionMode.DisplayError;
                    e.WindowCaption = "Error en el valor ingresado";
                    e.ErrorText = "Cantidad no puede ser menor a 0";
                    break;
                case "precio_eventual":
                    e.ExceptionMode = ExceptionMode.DisplayError;
                    e.WindowCaption = "Error en el valor ingresado";
                    e.ErrorText = "Cantidad no puede ser menor a 0";
                    break;
                case "precio_unitario":
                    e.ExceptionMode = ExceptionMode.DisplayError;
                    e.WindowCaption = "Error en el valor ingresado";
                    e.ErrorText = "Cantidad no puede ser menor a 0";
                    break;
                case "precio_4":
                    e.ExceptionMode = ExceptionMode.DisplayError;
                    e.WindowCaption = "Error en el valor ingresado";
                    e.ErrorText = "Cantidad no puede ser menor a 0";
                    break;
            }
        }

        private void viewLinea_InvalidRowException(object sender,DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
            e.WindowCaption = "Error en el valor ingresado";
            e.ErrorText = "Campo requerido";
        }

        private void viewLinea_ValidateRow(object sender,DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            GridView view = sender as GridView;

            try
            {
                var id_grupo = view.GetFocusedRowCellValue("id_grupo").Equals(DBNull.Value) ? 0 : Convert.ToInt32(view.GetFocusedRowCellValue("id_grupo"));
                if(id_grupo == 0) { e.Valid = false; view.SetColumnError(col_grupos,"Campo requerido"); view.FocusedColumn = col_grupos; }

                var v_nombre = view.GetFocusedRowCellValue("nombre").Equals(DBNull.Value) ? string.Empty : Convert.ToString(view.GetFocusedRowCellValue(col_nombre_subgrupo));
                if(string.IsNullOrEmpty(v_nombre))
                {
                    e.Valid = false; view.SetColumnError(col_nombre_subgrupo,"Campo requerido"); view.FocusedColumn = col_nombre_subgrupo;
                }
                var precio_mayor = view.GetFocusedRowCellValue(col_precio_mayor).Equals(DBNull.Value) ? 0 : Convert.ToInt32(view.GetFocusedRowCellValue(col_precio_mayor));
                var precio_eventual = view.GetFocusedRowCellValue(col_precio_eventual).Equals(DBNull.Value) ? 0 : Convert.ToInt32(view.GetFocusedRowCellValue(col_precio_eventual));
                var precio_unitario = view.GetFocusedRowCellValue(col_precio_unitario).Equals(DBNull.Value) ? 0 : Convert.ToInt32(view.GetFocusedRowCellValue(col_precio_unitario));
                var precio_4 = view.GetFocusedRowCellValue(col_precio_4).Equals(DBNull.Value) ? 0 : Convert.ToInt32(view.GetFocusedRowCellValue(col_precio_4));
                if(precio_mayor < 0)
                {
                    e.Valid = false;
                    view.SetColumnError(col_precio_mayor,"Precio no puede ser negativo");
                    view.FocusedColumn = col_precio_mayor;
                }
                if(precio_eventual < 0)
                {
                    e.Valid = false;
                    view.SetColumnError(col_precio_mayor,"Precio no puede ser negativo");
                    view.FocusedColumn = col_precio_mayor;
                }
                if(precio_unitario < 0)
                {
                    e.Valid = false;
                    view.SetColumnError(col_precio_mayor,"Precio no puede ser negativo");
                    view.FocusedColumn = col_precio_mayor;
                }
                if(precio_4 < 0)
                {
                    e.Valid = false;
                    view.SetColumnError(col_precio_mayor,"Precio no puede ser negativo");
                    view.FocusedColumn = col_precio_mayor;
                }

            }
            catch(Exception ex)
            {
                e.Valid = false;
            }
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (grilla_exportar != null)
                    new Clases.Exportar().Exportar_Grid_A_Excel(gridLinea);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void viewLinea_FocusedRowChanged(object sender,DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

            if(viewLinea.RowCount > 0)
            {
                //Convert.ToString(viewCliente.GetFocusedRowCellValue("codigo") ?? "").ToUpper().Trim()
                id_subgrupo = Convert.ToString(viewLinea.GetFocusedRowCellValue("id") ?? "0").ToUpper().Trim();
                string nombre_subgrupo=Convert.ToString (viewLinea.GetFocusedRowCellValue(col_nombre_subgrupo)??"").ToString();
                string v_codigo_subgrupo= Convert.ToString(viewLinea.GetFocusedRowCellValue(col_codigo_subgrupo)??"").ToString();
                int id_grupo=Convert.ToInt32(viewLinea.GetFocusedRowCellValue(col_grupos)??0);
                decimal precio_mayor=Convert.ToDecimal(viewLinea.GetFocusedRowCellValue(col_precio_mayor)??0.00M);
                decimal precio_eventual=Convert.ToDecimal(viewLinea.GetFocusedRowCellValue(col_precio_eventual)??0.00M);
                decimal precio_unitario=Convert.ToDecimal(viewLinea.GetFocusedRowCellValue(col_precio_unitario)??0.00M);
                decimal precio_4=Convert.ToDecimal(viewLinea.GetFocusedRowCellValue(col_precio_4)??0.00M);
                decimal precio_5 = Convert.ToDecimal(viewLinea.GetFocusedRowCellValue(col_precio_5) ?? 0.00M);
                decimal precio_6 = Convert.ToDecimal(viewLinea.GetFocusedRowCellValue(col_precio_6) ?? 0.00M);
                decimal precio_7 = Convert.ToDecimal(viewLinea.GetFocusedRowCellValue(col_precio_7) ?? 0.00M);
                decimal precio_8 = Convert.ToDecimal(viewLinea.GetFocusedRowCellValue(col_precio_8) ?? 0.00M);
                decimal precio_9 = Convert.ToDecimal(viewLinea.GetFocusedRowCellValue(col_precio_9) ?? 0.00M);
                decimal precio_10 = Convert.ToDecimal(viewLinea.GetFocusedRowCellValue(col_precio_10) ?? 0.00M);
                decimal precio_11 = Convert.ToDecimal(viewLinea.GetFocusedRowCellValue(col_precio_11) ?? 0.00M);
                decimal precio_12 = Convert.ToDecimal(viewLinea.GetFocusedRowCellValue(col_precio_docena) ?? 0.00M);
                decimal precio_13 = Convert.ToDecimal(viewLinea.GetFocusedRowCellValue(col_precio_bulto) ?? 0.00M);
                decimal costo = Convert.ToDecimal(viewLinea.GetFocusedRowCellValue(colCosto) ?? 0.00M);
                int moneda_subgrupo = Convert.ToInt32(viewLinea.GetFocusedRowCellValue("moneda_subgrupo") ?? 0);
                string v_descripcion_subgrupo = Convert.ToString(viewLinea.GetFocusedRowCellValue(col_descripcion_subgrupo) ?? "").ToString();
                bool permiteEdicion = Convert.ToBoolean(viewLinea.GetFocusedRowCellValue("permiteEdicion"));
                
                txt_nombre_subgrupo.EditValue = nombre_subgrupo.ToUpper();
                txt_codigo_subgrupo.EditValue = v_codigo_subgrupo.ToUpper();
                look_grupo_de_subgrupo.EditValue = id_grupo;
                lookUpEdit_Moneda_Subgrupos.EditValue = moneda_subgrupo.ToString();
                txt_precio_mayor.EditValue = precio_mayor;
                txt_precio_Eventual.EditValue = precio_eventual;
                txt_precio_detalle.EditValue = precio_unitario;
                txt_precio_4.EditValue = precio_4;
                txtprecio_5.EditValue = precio_5;
                txtprecio_6.EditValue = precio_6;
                txtprecio_7.EditValue = precio_7;
                txtprecio_8.EditValue = precio_8;
                txtprecio_9.EditValue = precio_9;
                txtprecio_10.EditValue = precio_10;
                txtprecio_11.EditValue = precio_11;
                txt_precio_docena.EditValue = precio_12;
                txt_precio_bulto.EditValue = precio_13;
                txt_costo.EditValue = costo;
                txtDescripcion_subgrupo.EditValue = v_descripcion_subgrupo.ToUpper();
                ck_BloquearEdicionSG.EditValue = permiteEdicion;
                txt_nombre_subgrupo.ReadOnly = look_grupo_de_subgrupo.ReadOnly = lookUpEdit_Moneda_Subgrupos.ReadOnly = txtDescripcion_subgrupo.ReadOnly = txt_codigo_subgrupo.ReadOnly = txt_precio_mayor.ReadOnly = txt_precio_4.ReadOnly = txt_precio_detalle.ReadOnly = txt_precio_Eventual.ReadOnly = txtprecio_7.ReadOnly = txtprecio_8.ReadOnly = txtprecio_9.ReadOnly = txtprecio_10.ReadOnly = txtprecio_11.ReadOnly = txtprecio_5.ReadOnly = txtprecio_6.ReadOnly = ck_BloquearEdicionSG.ReadOnly = true;
            }
        }
        
        private bool Validar_Subgrupo( )
        {
            ErrorProvider Error= new ErrorProvider();
            bool resultado = false;

            if(txt_nombre_subgrupo.EditValue.ToString() == string.Empty)
            {
                Error.SetError(txt_nombre_subgrupo,"Lo sentimos no esta permitido dejar nombre vacio");
                txt_nombre_subgrupo.Focus();
                return resultado;
            }
            else if (Convert.ToInt32(lookUpEdit_Moneda_Subgrupos.EditValue) == 0)
            {
                Error.SetIconAlignment(lookUpEdit_Moneda_Subgrupos, ErrorIconAlignment.MiddleLeft);
                Error.SetError(lookUpEdit_Moneda_Subgrupos, "Lo sentimos, debe seleccionar una moneda");
                lookUpEdit_Moneda_Subgrupos.Focus();
                return resultado;
            }
            else if (Convert.ToDecimal(txt_precio_mayor.EditValue ?? 0) < 0 || Convert.ToDecimal(txt_precio_Eventual.EditValue ?? 0) < 0 || Convert.ToDecimal(txt_precio_detalle.EditValue ?? 0) < 0 || Convert.ToDecimal(txt_precio_4.EditValue ?? 0) < 0 || Convert.ToDecimal(txtprecio_5.EditValue ?? 0) < 0 || Convert.ToDecimal(txtprecio_6.EditValue ?? 0) < 0)
            {
                Error.SetError(txt_precio_mayor,"Lo sentimos los precios no pueden quedar menor a 0");
                txt_precio_mayor.Focus();
                return resultado;
            }
            else { return resultado = true; }

        }
        private void bbi_guardar_subgrupo_ItemClick(object sender,DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if(Validar_Subgrupo())
                {

                    string nombre_subgrupo=Convert.ToString(txt_nombre_subgrupo.EditValue??"").ToString();
                    string v_codigo_subgrupo= Convert.ToString(txt_codigo_subgrupo.EditValue??"").ToString();
                    int id_grupo=Convert.ToInt32(look_grupo_de_subgrupo.EditValue??0);
                    decimal precio_mayor=Convert.ToDecimal(txt_precio_mayor.EditValue??0.00M);
                    decimal precio_eventual=Convert.ToDecimal(txt_precio_Eventual.EditValue??0.00M);
                    decimal precio_unitario=Convert.ToDecimal(txt_precio_detalle.EditValue??0.00M);
                    decimal precio_4=Convert.ToDecimal(txt_precio_4.EditValue ??0.00M);
                    decimal precio_5 = Convert.ToDecimal(txtprecio_5.EditValue ?? 0.00M);
                    decimal precio_6 = Convert.ToDecimal(txtprecio_6.EditValue ?? 0.00M);
                    decimal precio_7 = Convert.ToDecimal(txtprecio_7.EditValue ?? 0.00M);
                    decimal precio_8 = Convert.ToDecimal(txtprecio_8.EditValue ?? 0.00M);
                    decimal precio_9 = Convert.ToDecimal(txtprecio_9.EditValue ?? 0.00M);
                    decimal precio_10 = Convert.ToDecimal(txtprecio_10.EditValue ?? 0.00M);
                    decimal precio_11 = Convert.ToDecimal(txtprecio_11.EditValue ?? 0.00M);
                    decimal precio_12 = Convert.ToDecimal(txt_precio_docena.EditValue ?? 0.00M);
                    decimal precio_13 = Convert.ToDecimal(txt_precio_bulto.EditValue ?? 0.00M);
                    decimal costo = Convert.ToDecimal(txt_costo.EditValue ?? 0.00M);
                    int moneda_subgrupo = Convert.ToInt32(lookUpEdit_Moneda_Subgrupos.EditValue ?? 0);
                    string descripcion_subgrupo = Convert.ToString(txtDescripcion_subgrupo.EditValue ?? "").ToString();
                    bool permiteEdicion = Convert.ToBoolean(ck_BloquearEdicionSG.EditValue);

                    if(!string.IsNullOrEmpty(nombre_subgrupo.Trim().Replace(" ","")))
                    {
                        if(id_subgrupo == "0")
                        {
                            //nuevo
                            foreach(var list in Negocio.ClasesCN.CatalogosCN.Linea_Cargar().Select(x => new { x.nombre }))
                            {
                                if((nombre_subgrupo == list.nombre.Trim()))
                                {
                                    XtraMessageBox.Show("Lo sentimos, este registro ya existe","Linea",MessageBoxButtons.OK,MessageBoxIcon.Error);
                                    CargarLinea();
                                    viewLinea.MoveFirst();
                                    return;
                                }
                            }

                            int okGuardar = Negocio.ClasesCN.CatalogosCN.Linea_Guardar(nombre_subgrupo, Convert.ToInt32(id_grupo), Convert.ToDecimal(precio_mayor), Convert.ToDecimal(precio_eventual), Convert.ToDecimal(precio_unitario), Convert.ToDecimal(precio_4), Convert.ToDecimal(precio_5), Convert.ToDecimal(precio_6), Convert.ToDecimal(precio_7), Convert.ToDecimal(precio_8), Convert.ToDecimal(precio_9), Convert.ToDecimal(precio_10), Convert.ToDecimal(precio_11), v_codigo_subgrupo, moneda_subgrupo, descripcion_subgrupo, Convert.ToDecimal(costo), Convert.ToDecimal(precio_12), Convert.ToDecimal(precio_13), permiteEdicion);
                            if(okGuardar > 0)
                            {
                                XtraMessageBox.Show("Registro guardado satisfactoriamente","SubGrupo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                                CargarLinea();
                                bbi_Cancelar_subgrupo_ItemClick(null, null);
                                viewLinea.MoveFirst();
                            }
                            else
                            {
                                XtraMessageBox.Show("Lo sentimos, no se pudo guardar los datos, verifique la información","SubGrupo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                                CargarLinea();
                                viewLinea.MoveFirst();
                            }
                        }
                        else
                        {
                            //actualizar
                            foreach(var list in Negocio.ClasesCN.CatalogosCN.Linea_Cargar().Select(x => new { x.nombre, x.codigo, x.id }).Where(x => x.id != int.Parse(id_subgrupo)))
                            {
                                if((nombre_subgrupo == list.nombre.Trim()) || (v_codigo_subgrupo == list.codigo))
                                {
                                    XtraMessageBox.Show("Lo sentimos, este nombre (" + nombre_subgrupo + ") ó el código (" + v_codigo_subgrupo + ") ya existe", "Linea",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                                    //CargarLinea();
                                    //viewLinea.MoveFirst();
                                    return;
                                }
                            }

                            if(XtraMessageBox.Show("¿Desea Actualizar este registro?\n ¡Recuerde que al Modificar Precios o Moneda aquí, Los Precios, Costos y Monedas del Catálogo de Productos tambien serán Modificados!", "Linea",MessageBoxButtons.YesNo,MessageBoxIcon.Question) != DialogResult.Yes) { CargarLinea(); return; }
                            int okEditar = Negocio.ClasesCN.CatalogosCN.Linea_Actualizar(int.Parse(id_subgrupo), nombre_subgrupo, 0, Convert.ToInt32(id_grupo), Convert.ToDecimal(precio_mayor), Convert.ToDecimal(precio_eventual), Convert.ToDecimal(precio_unitario), Convert.ToDecimal(precio_4), Convert.ToDecimal(precio_5), Convert.ToDecimal(precio_6), Convert.ToDecimal(precio_7), Convert.ToDecimal(precio_8), Convert.ToDecimal(precio_9), Convert.ToDecimal(precio_10), Convert.ToDecimal(precio_11), Convert.ToDecimal(precio_12), Convert.ToDecimal(precio_13),v_codigo_subgrupo, moneda_subgrupo, descripcion_subgrupo, costo, permiteEdicion);
                            if(okEditar > 0)
                            {
                                XtraMessageBox.Show("Datos modificados satisfactoriamente","Subgrupo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                                CargarLinea();
                                bbi_Cancelar_subgrupo_ItemClick(null, null);
                                viewLinea.MoveNext();
                            }
                            else
                            {
                                XtraMessageBox.Show("Lo sentimos, no se pudo modificar los datos, verifique la información","Subgrupo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                                CargarLinea();
                                viewLinea.MoveNext();
                            }
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("No puede dejar campos vacios","Linea",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                        CargarLinea();
                        viewLinea.MoveFirst();
                    }
                }
            }
            catch(Exception)
            {
                throw;
            }
        }
        private void bbi_nuevo_subgrupo_ItemClick(object sender,DevExpress.XtraBars.ItemClickEventArgs e)
        {
            id_subgrupo = 0.ToString();
            txt_nombre_subgrupo.EditValue = string.Empty;
            look_grupo_de_subgrupo.EditValue = 0;
            lookUpEdit_Moneda_Subgrupos.EditValue = 0.ToString();
            txt_codigo_subgrupo.EditValue = string.Empty;
            txt_precio_mayor.EditValue = 0.00M;
            txt_precio_Eventual.EditValue = 0.00M;
            txt_precio_detalle.EditValue = 0.00M;
            txt_precio_4.EditValue = 0.00M;
            txtprecio_5.EditValue = 0.00M;
            txtprecio_6.EditValue = 0.00M;
            txtprecio_7.EditValue = 0.00M;
            txtprecio_8.EditValue = 0.00M;
            txtprecio_9.EditValue = 0.00M;
            txtprecio_10.EditValue = 0.00M;
            txtprecio_11.EditValue = 0.00M;
            txt_precio_docena.EditValue = 0.00M;
            txt_precio_bulto.EditValue = 0.00M;
            txt_costo.EditValue = 0.00M;
            txtDescripcion_subgrupo.EditValue = string.Empty;
            ck_BloquearEdicionSG.EditValue = false;
            txt_nombre_subgrupo.Focus();
            txt_nombre_subgrupo.ReadOnly = txtDescripcion_subgrupo.ReadOnly = look_grupo_de_subgrupo.ReadOnly = lookUpEdit_Moneda_Subgrupos.ReadOnly = txt_codigo_subgrupo.ReadOnly = txt_precio_mayor.ReadOnly = txt_precio_4.ReadOnly = txt_precio_detalle.ReadOnly = txt_precio_Eventual.ReadOnly = txtprecio_5.ReadOnly = txtprecio_6.ReadOnly = txtprecio_7.ReadOnly = txtprecio_8.ReadOnly = txtprecio_9.ReadOnly = txtprecio_10.ReadOnly = txtprecio_11.ReadOnly = txt_costo.ReadOnly = txt_precio_docena.ReadOnly = txt_precio_bulto.ReadOnly = ck_BloquearEdicionSG.ReadOnly = false;
            txt_nombre_subgrupo.Focus();

            bbi_refrescar_subgrupo.Enabled = false;
            bbi_refrescar_subgrupo.Enabled = false;
            bbi_exportar_subgrupop.Enabled = false;
            txt_codigo_subgrupo.Enabled = false;
        }

        private void lookUpEditLinea_EditValueChanged(object sender, EventArgs e)
        {
            if (lookUpEditLinea.EditValue != null)
            {
                int vIdLinea = Convert.ToInt32(lookUpEditLinea.EditValue);
                string nombrePro = textEditCodigo.Text;
                var query = Negocio.ClasesCN.CatalogosCN.getLinea().Where(x => x.id == vIdLinea).FirstOrDefault();
                var queryProd = Negocio.ClasesCN.CatalogosCN.Producto_Cargar().Where(x => x.codigo == nombrePro).FirstOrDefault();

                if (query != null)
                {
                    if (query.descripcion_subgrupo == "" && queryProd != null)
                    {
                        textEditDescripcion.Text = queryProd.descripcion.ToString(); 
                    }
                    else
                    {
                        textEditDescripcion.Text = query.descripcion_subgrupo.ToString();
                    }
                    lookUpEditMoneda.EditValue = query.moneda_subgrupo.ToString();
                    lookUpEditCategoria.EditValue = query.id_grupo;
                    textEditPrecio1.EditValue = query.precio_mayor;
                    textEditPrecio2.EditValue = query.precio_eventual;
                    textEditPrecio3.EditValue = query.precio_unitario;
                    textEditPrecio4.EditValue = query.precio_4;
                    textEditPrecio5.EditValue = query.precio_5;
                    textEditPrecio6.EditValue = query.precio_6;
                    textEditPrecio7.EditValue = query.precio_7;
                    textEditPrecio8.EditValue = query.precio_8;
                    textEditPrecio9.EditValue = query.precio_9;
                    textEditPrecio10.EditValue = query.precio_10;
                    textEditPrecio11.EditValue = query.precio_11;
                }
            }
        }

        #endregion
        #region PRODUCTO

        private int vTemp;

        public void CargarProductos( )
        {
            bindingSourceProductos.DataSource = Negocio.ClasesCN.CatalogosCN.Producto_Cargar().Where(x => x.habilitado == true).OrderByDescending(x => x.id);
            //gridProductos.DataSource = CargaDatosProductos();
            viewProductos.BestFitColumns();
            viewProductos.ClearColumnsFilter();
            viewProductos.ClearGrouping();
            viewProductos_FocusedRowChanged(null,null);
            HabilitarDeshabilitarControles(1);
            HabilitarDeshabilitarControles(5);
        }

        public void CargarProductosDeshab()
        {
            bindingSourceProductos.DataSource = Negocio.ClasesCN.CatalogosCN.Producto_Cargar().Where(x => x.habilitado == false);
            //gridProductos.DataSource = CargaDatosProductos();
            viewProductos.BestFitColumns();
            viewProductos.ClearColumnsFilter();
            viewProductos.ClearGrouping();
            viewProductos_FocusedRowChanged(null, null);
            HabilitarDeshabilitarControles(1);
            HabilitarDeshabilitarControles(5);
        }

        private void viewProductos_FocusedRowChanged(object sender,DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                int id_producto = Convert.ToInt32(viewProductos.GetFocusedRowCellValue("id"));
                var query_producto = Negocio.ClasesCN.CatalogosCN.Producto_Cargar_Fila(id_producto).FirstOrDefault();

                HabilitarDeshabilitarControles(1);
                HabilitarDeshabilitarControles(5);

                if (viewProductos.RowCount > 0)
                {
                    lookUpEditMoneda.ItemIndex = Convert.ToInt32(viewProductos.GetFocusedRowCellValue("moneda")) - 1;
                    textEditCodigo.Text = viewProductos.GetFocusedRowCellValue("codigo").ToString();
                    textEditCodigo_KeyPress(null, null);
                    textEditDescripcion.Text = viewProductos.GetFocusedRowCellValue("descripcion").ToString();
                    lookUpEditCategoria.EditValue = viewProductos.GetFocusedRowCellValue("id_categoria");
                    lookUpEditMarca.EditValue = viewProductos.GetFocusedRowCellValue("id_marca");
                    lookUpEditLinea.EditValue = viewProductos.GetFocusedRowCellValue("id_linea");
                    lookUpEditUnidadMedida.EditValue = viewProductos.GetFocusedRowCellValue("id_unidad_medida");
                    textEditPrecio1.EditValue = Convert.ToDecimal(viewProductos.GetFocusedRowCellValue("precio1") ?? 0.00M);
                    textEditPrecio2.EditValue = Convert.ToDecimal(viewProductos.GetFocusedRowCellValue("precio2") ?? 0.00M);
                    textEditPrecio3.EditValue = Convert.ToDecimal(viewProductos.GetFocusedRowCellValue("precio3") ?? 0.00M);
                    textEditPrecio4.EditValue = Convert.ToDecimal(viewProductos.GetFocusedRowCellValue("precio4") ?? 0.00M);
                    textEditPrecio5.EditValue = Convert.ToDecimal(viewProductos.GetFocusedRowCellValue("precio5") ?? 0.00M);
                    textEditPrecio6.EditValue = Convert.ToDecimal(viewProductos.GetFocusedRowCellValue("precio6") ?? 0.00M);
                    textEditPrecio7.EditValue = Convert.ToDecimal(viewProductos.GetFocusedRowCellValue("precio7") ?? 0.00M);
                    textEditPrecio8.EditValue = Convert.ToDecimal(viewProductos.GetFocusedRowCellValue("precio8") ?? 0.00M);
                    textEditPrecio9.EditValue = Convert.ToDecimal(viewProductos.GetFocusedRowCellValue("precio9") ?? 0.00M);
                    textEditPrecio10.EditValue = Convert.ToDecimal(viewProductos.GetFocusedRowCellValue("precio10") ?? 0.00M);
                    textEditPrecio11.EditValue = Convert.ToDecimal(viewProductos.GetFocusedRowCellValue("precio11") ?? 0.00M);
                    txt_precio_docena_producto.EditValue = Convert.ToDecimal(viewProductos.GetFocusedRowCellValue("precio_12") ?? 0.00M);
                    txt_precio_bulto_producto.EditValue = Convert.ToDecimal(viewProductos.GetFocusedRowCellValue("precio_13") ?? 0.00M);
                    txt_costo_Producto.EditValue = Convert.ToDecimal(viewProductos.GetFocusedRowCellValue("costo") ?? 0.00M);
                    textEditImpuesto.EditValue = Convert.ToDecimal(viewProductos.GetFocusedRowCellValue("impuesto") ?? 0.00M);
                    textEditDescuento.EditValue = Convert.ToDecimal(viewProductos.GetFocusedRowCellValue("descuento") ?? 0.00M);
                    textEditCosto.EditValue = Convert.ToDecimal(viewProductos.GetFocusedRowCellValue("costo") ?? 0.00M);
                    textEditUtilidad.EditValue = Convert.ToDecimal(viewProductos.GetFocusedRowCellValue("utilidad") ?? 0.00M);
                    textEditStock.EditValue = Convert.ToDecimal(viewProductos.GetFocusedRowCellValue("stock") ?? 0.00M);
                    textEditStockMinimo.EditValue = Convert.ToDecimal(viewProductos.GetFocusedRowCellValue("stock_minimo") ?? 0.00M);
                    pictureEditProducto.EditValue = query_producto.imagen;
                    check_es_servicio.Checked = Convert.ToBoolean(viewProductos.GetFocusedRowCellValue("tipo_producto"));
                    check_deshabilitar.Checked = Convert.ToBoolean(viewProductos.GetFocusedRowCellValue("habilitado"));
                    lookUpEditMoneda.EditValue = Convert.ToInt32(viewProductos.GetFocusedRowCellValue("moneda"));
                }
                else
                {
                    HabilitarDeshabilitarControles(3);
                }
            }
            catch(Exception ex) { Console.WriteLine(ex); }
        }

        private void nbiProducto_LinkClicked(object sender,DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Mostrar_Pagina(5);
            //HabilitarDeshabilitarControles(3);
        }

        void CargarTablasProductos()
        {
            DataColumn parentColumnProductos = new DataColumn("id", typeof(int));
            Tabla_Productos.Columns.Add(parentColumnProductos);
            Tabla_Productos.Columns.AddRange(new DataColumn[]
                {
                    //new DataColumn("id",typeof(int)),
                    new DataColumn("codigo", typeof(string)),
                    new DataColumn("descripcion", typeof(string)),
                    new DataColumn("id_categoria", typeof(int)),
                    new DataColumn("id_marca", typeof(int)),
                    new DataColumn("id_linea", typeof(int)),
                    new DataColumn("id_unidad_medida", typeof(int)),
                    new DataColumn("moneda", typeof(int)),
                    new DataColumn("costo", typeof(decimal)),
                    new DataColumn("utilidad", typeof(decimal)),
                    new DataColumn("precio1", typeof(decimal)),
                    new DataColumn("precio2", typeof(decimal)),
                    new DataColumn("precio3", typeof(decimal)),
                    new DataColumn("precio4", typeof(decimal)),
                    new DataColumn("descuento", typeof(decimal)),
                    new DataColumn("impuesto", typeof(decimal)),
                    new DataColumn("stock", typeof(decimal)),
                    new DataColumn("stock_minimo", typeof(decimal)),
                    new DataColumn("imagen", typeof(string)),
                    new DataColumn("tipo_producto", typeof(bool)),
                    new DataColumn("talla", typeof(string)),
                    new DataColumn("marca", typeof(string)),
                    new DataColumn("grupo", typeof(string)),
                    new DataColumn("subgrupo", typeof(string))
                });

            DataColumn childrenColumnProductos = new DataColumn("id_producto", typeof(int));
            Tabla_Precio_Detalle_Producto.Columns.Add(childrenColumnProductos);
            Tabla_Precio_Detalle_Producto.Columns.AddRange(new DataColumn[]
                {

                    new DataColumn("id_precio", typeof(int)),
                    new DataColumn("id_linea", typeof(int)),
                    new DataColumn("descripcion_corta", typeof(string)),
                    new DataColumn("monto", typeof(decimal))
                });
        }

        private DataTable CargaDatosProductos()
        {
            try
            {
                Tabla_Productos.Clear();
                Tabla_Precio_Detalle_Producto.Clear();

                var productos = Negocio.ClasesCN.CatalogosCN.Producto_Cargar();
                foreach (var p in productos)
                {
                    DataRow fila = Tabla_Productos.NewRow();
                    fila[0] = p.id;
                    fila[1] = p.codigo;
                    fila[2] = p.descripcion ?? string.Empty;
                    fila[3] = p.id_categoria;
                    fila[4] = p.id_marca;
                    fila[5] = p.id_linea;
                    fila[6] = p.id_unidad_medida;
                    fila[7] = p.moneda.Equals(DBNull.Value) ? 0 : Convert.ToInt32(p.moneda);
                    fila[8] = p.costo;
                    fila[9] = p.utilidad;
                    fila[10] = p.precio1;
                    fila[11] = p.precio2;
                    fila[12] = p.precio3;
                    fila[13] = p.precio4;
                    fila[14] = p.descuento;
                    fila[15] = p.impuesto;
                    fila[16] = p.stock;
                    fila[17] = p.stock_minimo;
                    fila[18] = p.imagen;
                    fila[19] = p.tipo_producto.Equals(DBNull.Value) ? 0 : Convert.ToInt32(p.tipo_producto);
                    fila[20] = p.talla;
                    fila[21] = p.marca;
                    fila[22] = p.grupo;
                    fila[23] = p.subgrupo;

                    Tabla_Productos.Rows.Add(fila);
                }

                var Detalle = Negocio.ClasesCN.CatalogosCN.Precio_Detalle_productos_SELECT();
                foreach (var d in Detalle)
                {
                    DataRow fila = Tabla_Precio_Detalle_Producto.NewRow();
                    fila[0] = d.id_producto;
                    fila[1] = d.id_precio;
                    fila[2] = d.id_linea;
                    fila[3] = d.descripcion_corta;
                    fila[4] = d.monto;

                    Tabla_Precio_Detalle_Producto.Rows.Add(fila);
                }

                using (DataSet ds = new DataSet())
                {
                    ds.Tables.AddRange(new DataTable[] { Tabla_Productos.Copy(), Tabla_Precio_Detalle_Producto.Copy() });

                    DataRelation relation = new DataRelation("Precios", ds.Tables[0].Columns[0], ds.Tables[1].Columns[0], false);
                    ds.Relations.Add(relation);
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        private void viewProductos_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int id_linea = Convert.ToInt32(viewProductos.GetFocusedRowCellValue("id_linea"));
                int id_product = Convert.ToInt32(viewProductos.GetFocusedRowCellValue("id"));

                if (viewProductos.RowCount > 0)
                {
                    xfrm_Actualizar_precios form = new xfrm_Actualizar_precios(id_linea, id_product);
                    form.ShowDialog();
                    if (form.vRetorno) { CargarProductos(); }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                CargarProductos();
                throw;
            }
        }


        private void textEditCodigo_KeyPress(object sender,KeyPressEventArgs e)
        {
            string cadena = "qwertyuiopasdfghjklzxcvbnm1234567890QWERTYUIOPASDFGHJKLZXCVBNM-/() " + (Char)8;

            try
            {
                if(!cadena.Contains(e.KeyChar))
                {
                    e.Handled = true;
                }
                else { barCodeControl1.Text = textEditCodigo.Text; }
            }
            catch(Exception) { barCodeControl1.Text = textEditCodigo.Text; }
        }

        private void bbiOperaciones_ItemClick(object sender,DevExpress.XtraBars.ItemClickEventArgs e)
        {
            radialMenuProducto.ShowPopup(Control.MousePosition);
        }

        private int vIdProducto;
        bool ValidarCamposProducto( )
        {
            dxError.ClearErrors(); dxError.Dispose();
            bool retorno = false;

            //if (string.IsNullOrEmpty(textEditCodigo.Text.Trim().Replace(" ", "")))
            //{
            //    dxError.SetError(textEditCodigo, "Campo Requerido");
            //}
            if(string.IsNullOrEmpty(textEditDescripcion.Text.Trim().Replace(" ","")))
            {
                dxError.SetError(textEditDescripcion,"Campo Requerido");
            }
            else if(lookUpEditCategoria.EditValue == null)
            {
                dxError.SetError(lookUpEditCategoria,"Campo Requerido");
            }
            else if(lookUpEditMarca.EditValue == null)
            {
                dxError.SetError(lookUpEditMarca,"Campo Requerido");
            }
            else if(lookUpEditLinea.EditValue == null)
            {
                dxError.SetError(lookUpEditLinea,"Campo Requerido");
            }
            else if(lookUpEditUnidadMedida.EditValue == null)
            {
                dxError.SetError(lookUpEditUnidadMedida,"Campo Requerido");
            }
            else if(string.IsNullOrEmpty(textEditStock.Text.Trim().Replace(" ","")))
            {
                dxError.SetError(textEditStock,"Campo Requerido");
            }
            else if(Convert.ToDecimal(textEditStock.Text) < 0.00M)
            {
                dxError.SetError(textEditStock,"Valor No Puede Ser Negativo");
            }
            else if(string.IsNullOrEmpty(textEditStockMinimo.Text.Trim().Replace(" ","")))
            {
                dxError.SetError(textEditStockMinimo,"Campo Requerido");
            }
            else if(Convert.ToDecimal(textEditStockMinimo.Text) < 0.00M)
            {
                dxError.SetError(textEditStockMinimo,"Valor No Puede Ser Negativo o 0");
            }
            else if(lookUpEditMoneda.EditValue == null)
            {
                dxError.SetError(lookUpEditMoneda,"Campo Requerido");
            }
            else if(string.IsNullOrEmpty(textEditPrecio1.Text.Trim().Replace(" ","")))
            {
                dxError.SetError(textEditPrecio1,"Campo Requerido");
            }
            else if(Convert.ToDecimal(textEditPrecio1.Text) < 0.00M)
            {
                dxError.SetError(textEditPrecio1,"Valor No Puede Ser Negativo");
            }
            else if(Convert.ToDecimal(string.IsNullOrEmpty(textEditPrecio2.Text) ? "0.00" : textEditPrecio2.Text) < 0.00M)
            {
                dxError.SetError(textEditPrecio2,"Campo Requerido");
            }
            //else if (Convert.ToDecimal(textEditPrecio2.Text) < 0.00M)
            //{
            //    dxError.SetError(textEditPrecio2, "Valor No Puede Ser Negativo");
            //}
            else if(Convert.ToDecimal(string.IsNullOrEmpty(textEditPrecio3.Text) ? "0.00" : textEditPrecio3.Text) < 0.00M)
            {
                dxError.SetError(textEditPrecio3,"Campo Requerido");
            }
            //else if (Convert.ToDecimal(textEditPrecio3.Text) < 0.00M)
            //{
            //    dxError.SetError(textEditPrecio3, "Valor No Puede Ser Negativo");
            //}
            else if(Convert.ToDecimal(string.IsNullOrEmpty(textEditPrecio4.Text) ? "0.00" : textEditPrecio4.Text) < 0.00M)
            {
                dxError.SetError(textEditPrecio4,"Campo Requerido");
            }
            else if (Convert.ToDecimal(string.IsNullOrEmpty(textEditPrecio5.Text) ? "0.00" : textEditPrecio5.Text) < 0.00M)
            {
                dxError.SetError(textEditPrecio5, "Campo Requerido");
            }
            else if (Convert.ToDecimal(string.IsNullOrEmpty(textEditPrecio6.Text) ? "0.00" : textEditPrecio6.Text) < 0.00M)
            {
                dxError.SetError(textEditPrecio6, "Campo Requerido");
            }
            else if (Convert.ToDecimal(string.IsNullOrEmpty(textEditPrecio7.Text) ? "0.00" : textEditPrecio7.Text) < 0.00M)
            {
                dxError.SetError(textEditPrecio7, "Campo Requerido");
            }
            else if (Convert.ToDecimal(string.IsNullOrEmpty(textEditPrecio8.Text) ? "0.00" : textEditPrecio8.Text) < 0.00M)
            {
                dxError.SetError(textEditPrecio8, "Campo Requerido");
            }
            else if (Convert.ToDecimal(string.IsNullOrEmpty(textEditPrecio9.Text) ? "0.00" : textEditPrecio9.Text) < 0.00M)
            {
                dxError.SetError(textEditPrecio9, "Campo Requerido");
            }
            else if (Convert.ToDecimal(string.IsNullOrEmpty(textEditPrecio10.Text) ? "0.00" : textEditPrecio10.Text) < 0.00M)
            {
                dxError.SetError(textEditPrecio10, "Campo Requerido");
            }
            else if (Convert.ToDecimal(string.IsNullOrEmpty(textEditPrecio11.Text) ? "0.00" : textEditPrecio11.Text) < 0.00M)
            {
                dxError.SetError(textEditPrecio11, "Campo Requerido");
            }
            else if (Convert.ToDecimal(string.IsNullOrEmpty(txt_costo.Text) ? "0.00" : txt_costo.Text) < 0.00M)
            {
                dxError.SetError(txt_costo, "Campo Requerido");
            }

            //else if (Convert.ToDecimal(textEditPrecio4.Text) < 0.00M)
            //{
            //    dxError.SetError(textEditPrecio4, "Valor No Puede Ser Negativo");
            //}
            else if(Convert.ToDecimal(string.IsNullOrEmpty(textEditImpuesto.Text) ? "0.00" : textEditImpuesto.Text) < 0.00M)
            {
                dxError.SetError(textEditImpuesto,"Campo Requerido");
            }
            //else if (Convert.ToDecimal(textEditImpuesto.Text) < 0.00M)
            //{
            //    dxError.SetError(textEditImpuesto, "Valor No Puede Ser Negativo");
            //}
            //else if (string.IsNullOrEmpty(textEditCosto.Text.Trim().Replace(" ", "")))
            //{
            //    dxError.SetError(textEditCosto, "Campo Requerido");
            //}
            else if(Convert.ToDecimal(string.IsNullOrEmpty(textEditCosto.Text) ? "0.00" : textEditCosto.Text) < 0.00M)
            {
                dxError.SetError(textEditCosto,"Valor No Puede Ser Negativo o cero");
            }
            else if(Convert.ToDecimal(string.IsNullOrEmpty(textEditUtilidad.Text) ? "0.00" : textEditUtilidad.Text) < 0.00M)
            {
                dxError.SetError(textEditUtilidad,"Campo Requerido");
            }
            //else if (Convert.ToDecimal(textEditUtilidad.Text) < 0.00M)
            //{
            //    dxError.SetError(textEditUtilidad, "Valor No Puede Ser Negativo");
            //}
            //else if (string.IsNullOrEmpty(textEditDescuento.Text.Trim().Replace(" ", "")))
            //{
            //    dxError.SetError(textEditDescuento, "Campo Requerido");
            //}
            else if(Convert.ToDecimal(string.IsNullOrEmpty(textEditImpuesto.Text) ? "0.00" : textEditImpuesto.Text) < 0.00M)
            {
                dxError.SetError(textEditDescuento,"Valor No Puede Ser Negativo");
            }
            else { retorno = true; }

            return retorno;
        }

        private void textEditCodigo_Leave(object sender,EventArgs e)
        {
            dxError.ClearErrors(); dxError.Dispose();
            if(vTemp == 0)
            {
                if(!string.IsNullOrEmpty(textEditCodigo.Text))
                {
                    var query = Negocio.ClasesCN.CatalogosCN.Producto_Cargar().Where(x => x.codigo.Trim() == textEditCodigo.Text.Trim()).FirstOrDefault();
                    if(query != null)
                    {
                        dxError.SetError(textEditCodigo,"El Codigo '" + textEditCodigo.Text + "' Ya Existe. (" + query.descripcion + ")");
                        textEditCodigo.Text = string.Empty;
                        textEditCodigo.Focus();
                    }
                }
            }
            else if(vTemp == 1)
            {
                if(!string.IsNullOrEmpty(textEditCodigo.Text))
                {
                    var query = Negocio.ClasesCN.CatalogosCN.Producto_Cargar().Where(x => x.codigo.Trim() == textEditCodigo.Text.Trim() && x.id != vIdProducto).FirstOrDefault();
                    if(query != null)
                    {
                        dxError.SetError(textEditCodigo,"El Codigo '" + textEditCodigo.Text + "' Ya Existe. (" + query.descripcion + ")");
                        textEditCodigo.Text = string.Empty;
                        textEditCodigo.Focus();
                    }
                }
            }
        }

        private void textEditPrecio1_EditValueChanged(object sender,EventArgs e)
        {
            if(textEditPrecio1.Text != string.Empty)
            {
                //double precio1 = Convert.ToDouble(textEditPrecio1.EditValue);
                //double porcentaje1 = 0.01;
                //double porcentaje2 =0.055;
                //double porcentaje3 =0.11;
                //textEditPrecio2.EditValue = Convert.ToDouble((precio1*porcentaje1)+precio1);
                //textEditPrecio3.EditValue = Convert.ToDouble((precio1 * porcentaje2) + precio1);
                //textEditPrecio4.EditValue = Convert.ToDouble((precio1 * porcentaje3) + precio1);
            }
        }
        DataTable getNivelStock( )
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id");
            dt.Columns.Add("descripcion");
            DataRow row = dt.NewRow();

            row["id"] = 1;//Mayor al stock
            row["descripcion"] = "MAYOR";
            dt.Rows.Add(row);
            row = dt.NewRow();

            row["id"] = 2;//Igual al stock
            row["descripcion"] = "IGUAL";
            dt.Rows.Add(row);
            row = dt.NewRow();

            row["id"] = 3;//Menor al stock
            row["descripcion"] = "MENOR";
            dt.Rows.Add(row);
            row = dt.NewRow();

            return dt;
        }
        int NivelStock(GridView view,int listSourceRowIndex)
        {
            int vStock = Convert.ToInt32(view.GetListSourceRowCellValue(listSourceRowIndex, "stock"));
            int vStockMinimo = Convert.ToInt32(view.GetListSourceRowCellValue(listSourceRowIndex, "stock_minimo"));

            if(vStock > vStockMinimo) return 1;
            if(vStock == vStockMinimo) return 2;
            if(vStock < vStockMinimo) return 3;
            else return 0;
        }
        private void viewProductos_CustomUnboundColumnData(object sender,DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            GridView view = sender as GridView;
            if(e.Column.FieldName == "nivel_stock" && e.IsGetData)
                e.Value = NivelStock(view,e.ListSourceRowIndex);
        }

        private void viewProductos_RowCellStyle(object sender,RowCellStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if(e.Column.FieldName == "stock")
            {
                int nivel = Convert.ToInt32(View.GetRowCellValue(e.RowHandle, "nivel_stock"));
                if(nivel == 2)//Igual
                {
                    e.Appearance.ForeColor = Color.Orange;
                    e.Appearance.Font = new Font("Tahoma",9.75F,FontStyle.Bold,GraphicsUnit.Point,((byte) (0)));
                }
                if(nivel == 3)//Menor
                {
                    e.Appearance.ForeColor = Color.Red;
                    e.Appearance.Font = new Font("Tahoma",9.75F,FontStyle.Bold,GraphicsUnit.Point,((byte) (0)));
                }
                if(nivel == 1)//Mayor
                {
                    //e.Appearance.ForeColor = Color.Red;
                    e.Appearance.Font = new Font("Tahoma",9.75F,FontStyle.Bold,GraphicsUnit.Point,((byte) (0)));
                }
            }
        }

        private void bbiEtiquetas_ItemClick(object sender,DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var report = new Reportes.Inventario.EtiquetaProducto(bindingSourceProductos);
            report.ShowPreview();
        }
        private void bbiEtiqueta_unitaria_ItemClick(object sender,DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var report = new Reportes.Inventario.Etiqueta(bindingSourceProductos);
            report.ShowPreview();
        }

        #endregion
        
        #endregion
        #region PRESENTACION

        #region UNIDAD DE MEDIDA

        void CargarUnidadMedida( )
        {
            bindingSourceUnidadMedida.DataSource = Negocio.ClasesCN.CatalogosCN.UnidadMedida_Cargar();
            gridUnidadMedida.DataSource = bindingSourceUnidadMedida;
        }

        private void nbiUnidadMedida_LinkClicked(object sender,DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Mostrar_Pagina(4);
        }

        private void viewUnidadMedida_RowUpdated(object sender,DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            try
            {
                string vId = viewUnidadMedida.GetFocusedRowCellValue("id").ToString();
                string vDescripcion = viewUnidadMedida.GetFocusedRowCellValue("descripcion").ToString().Trim().ToUpper();
                string vSimbolo = viewUnidadMedida.GetFocusedRowCellValue("simbolo").ToString().Trim().ToUpper();

                if(!string.IsNullOrEmpty(vDescripcion.Trim().Replace(" ","")) && !string.IsNullOrEmpty(vSimbolo.Trim().Replace(" ","")))
                {
                    if(vId == "0")
                    {
                        //nuevo

                        foreach(var list in Negocio.ClasesCN.CatalogosCN.UnidadMedida_Cargar())
                        {
                            if((vDescripcion == list.descripcion.Trim()) || vSimbolo == list.simbolo.Trim())
                            {
                                XtraMessageBox.Show("Lo sentimos, este registro ya existe","Unidad de Medida",MessageBoxButtons.OK,MessageBoxIcon.Error);
                                CargarUnidadMedida();
                                viewUnidadMedida.MoveFirst();
                                return;
                            }
                        }

                        int okGuardar = Negocio.ClasesCN.CatalogosCN.UnidadMedida_Guardar(vDescripcion, vSimbolo);
                        if(okGuardar > 0)
                        {
                            XtraMessageBox.Show("Registro guardado satisfactoriamente","Unidad de Medida",MessageBoxButtons.OK,MessageBoxIcon.Information);
                            CargarUnidadMedida();
                            viewUnidadMedida.MoveFirst();
                        }
                        else
                        {
                            XtraMessageBox.Show("Lo sentimos, no se pudo guardar los datos, verifique la información","Unidad de Medida",MessageBoxButtons.OK,MessageBoxIcon.Error);
                            CargarUnidadMedida();
                            viewUnidadMedida.MoveFirst();
                        }
                    }
                    else
                    {
                        //actualizar

                        foreach(var list in Negocio.ClasesCN.CatalogosCN.UnidadMedida_Cargar().Where(x => x.id != int.Parse(vId)))
                        {
                            if((vDescripcion == list.descripcion.Trim()) || vSimbolo == list.simbolo.Trim())
                            {
                                XtraMessageBox.Show("Lo sentimos, este registro ya existe","Unidad de Medida",MessageBoxButtons.OK,MessageBoxIcon.Error);
                                CargarUnidadMedida();
                                viewUnidadMedida.MoveFirst();
                                return;
                            }
                        }

                        if(XtraMessageBox.Show("¿Desea modificar el registro?","Unidad de Medida",MessageBoxButtons.YesNo,MessageBoxIcon.Question) != DialogResult.Yes) { CargarUnidadMedida(); return; }
                        int okEditar = Negocio.ClasesCN.CatalogosCN.UnidadMedida_Actualizar(int.Parse(vId), vDescripcion, vSimbolo, 0);
                        if(okEditar > 0)
                        {
                            XtraMessageBox.Show("Datos modificados satisfactoriamente","Unidad de Medida",MessageBoxButtons.OK,MessageBoxIcon.Information);
                            CargarUnidadMedida();
                            viewUnidadMedida.MoveNext();
                        }
                        else
                        {
                            XtraMessageBox.Show("Lo sentimos, no se pudo modificar los datos, verifique la información","Unidad de Medida",MessageBoxButtons.OK,MessageBoxIcon.Error);
                            CargarUnidadMedida();
                            viewUnidadMedida.MoveNext();
                        }
                    }
                }
                else
                {
                    XtraMessageBox.Show("No puede dejar campos vacios","Unidad de Medida",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    CargarUnidadMedida();
                    viewUnidadMedida.MoveFirst();
                }
            }
            catch(Exception)
            {
                CargarUnidadMedida();
            }
        }

        private void viewUnidadMedida_KeyDown(object sender,KeyEventArgs e)
        {
            try
            {
                if(e.KeyCode == Keys.Delete)
                {
                    if(viewUnidadMedida.RowCount > 0)
                    {
                        if(XtraMessageBox.Show("¿Desea eliminar este registro?","Unidad de Medida",MessageBoxButtons.YesNo,MessageBoxIcon.Question) != DialogResult.Yes) return;
                        int eliminar = Negocio.ClasesCN.CatalogosCN.UnidadMedida_Eliminar(Convert.ToInt32(viewUnidadMedida.GetFocusedRowCellValue("id")), 0);
                        if(eliminar > 0)
                        {
                            XtraMessageBox.Show("Registro eliminado con exito","Unidad de Medida",MessageBoxButtons.OK,MessageBoxIcon.Information);
                            CargarUnidadMedida();
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show("Error :" + ex.Message);
            }
        }
        #endregion

        #endregion
        #region INVENTARIO

        private void nbiBodega_LinkClicked(object sender,DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Mostrar_Pagina(6);
        }

        void CargarBodega( )
        {
            if (Clases.UsuarioLogueado.saberAdminM())
            {
                bindingSourceBodega.DataSource = Negocio.ClasesCN.CatalogosCN.Bodega_Cargar();
            }
            else
            {
                bindingSourceBodega.DataSource = Negocio.ClasesCN.CatalogosCN.Bodega_Cargar().Where(o => !o.nombre.Contains("BODEGA ESPECIAL"));
            }
            //bindingSourceBodega.DataSource = Negocio.ClasesCN.CatalogosCN.Bodega_Cargar().Where(o => !o.nombre.Contains("BODEGA ESPECIAL"));
        }

        private void viewBodega_RowUpdated(object sender,DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            try
            {
                string vId = viewBodega.GetFocusedRowCellValue("id").ToString();
                string vNombre = Convert.ToString(viewBodega.GetFocusedRowCellValue("nombre") ?? "").ToUpper().Trim();
                string vEncargado = Convert.ToString(viewBodega.GetFocusedRowCellValue("encargado") ?? "").ToUpper().Trim();
                string vDireccion = Convert.ToString(viewBodega.GetFocusedRowCellValue("direccion") ?? "").ToUpper().Trim();
                string vTelefono = Convert.ToString(viewBodega.GetFocusedRowCellValue("telefono") ?? "").ToUpper().Trim();

                if(!string.IsNullOrEmpty(vNombre.Trim().Replace(" ","")))
                {
                    if(vId == "0")
                    {
                        //nuevo

                        foreach(var list in Negocio.ClasesCN.CatalogosCN.Bodega_Cargar())
                        {
                            if((vNombre == list.nombre.Trim()))
                            {
                                XtraMessageBox.Show("Lo sentimos, este registro ya existe","Bodega",MessageBoxButtons.OK,MessageBoxIcon.Error);
                                CargarBodega();
                                viewBodega.MoveFirst();
                                return;
                            }
                        }

                        int okGuardar = Negocio.ClasesCN.CatalogosCN.Bodega_Guardar(vNombre, vEncargado, vDireccion, vTelefono);
                        if(okGuardar > 0)
                        {
                            XtraMessageBox.Show("Registro guardado satisfactoriamente","Bodega",MessageBoxButtons.OK,MessageBoxIcon.Information);
                            CargarBodega();
                            viewBodega.MoveFirst();
                        }
                        else
                        {
                            XtraMessageBox.Show("Lo sentimos, no se pudo guardar los datos, verifique la información","Bodega",MessageBoxButtons.OK,MessageBoxIcon.Error);
                            CargarBodega();
                            viewBodega.MoveFirst();
                        }
                    }
                    else
                    {
                        //actualizar

                        foreach(var list in Negocio.ClasesCN.CatalogosCN.Bodega_Cargar().Where(x => x.id != int.Parse(vId)))
                        {
                            if((vNombre == list.nombre.Trim()))
                            {
                                XtraMessageBox.Show("Lo sentimos, este registro ya existe","Bodega",MessageBoxButtons.OK,MessageBoxIcon.Error);
                                CargarBodega();
                                viewBodega.MoveFirst();
                                return;
                            }
                        }

                        if(XtraMessageBox.Show("¿Desea modificar el registro?","Bodega",MessageBoxButtons.YesNo,MessageBoxIcon.Question) != DialogResult.Yes) { CargarBodega(); return; }
                        int okEditar = Negocio.ClasesCN.CatalogosCN.Bodega_Actualizar(int.Parse(vId), vNombre, vEncargado, vDireccion, vTelefono, 0);
                        if(okEditar > 0)
                        {
                            XtraMessageBox.Show("Datos modificados satisfactoriamente","Bodega",MessageBoxButtons.OK,MessageBoxIcon.Information);
                            CargarBodega();
                            viewBodega.MoveNext();
                        }
                        else
                        {
                            XtraMessageBox.Show("Lo sentimos, no se pudo modificar los datos, verifique la información","Bodega",MessageBoxButtons.OK,MessageBoxIcon.Error);
                            CargarBodega();
                            viewBodega.MoveNext();
                        }
                    }
                }
                else
                {
                    XtraMessageBox.Show("Lo sentimos, no puede dejar el nombre vacio","Bodega",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    CargarBodega();
                    viewBodega.MoveFirst();
                }
            }
            catch(Exception)
            {
                CargarBodega();
            }
        }

        void CargarTipoAjuste( )
        {
            bindingSourceTiposAjustes.DataSource = Negocio.ClasesCN.CatalogosCN.TiposAjuste_Select();
        }

        private void nbiTipoAjuste_LinkClicked(object sender,DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Mostrar_Pagina(9);
        }

        private void viewTiposAjustes_RowUpdated(object sender,DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            try
            {
                string vId = viewTiposAjustes.GetFocusedRowCellValue("id").ToString();
                string vDescripcion = Convert.ToString(viewTiposAjustes.GetFocusedRowCellValue("descripcion") ?? "").ToUpper().Trim();
                string vDescripcionCorta = Convert.ToString(viewTiposAjustes.GetFocusedRowCellValue("descripcion_corta") ?? "").ToUpper().Trim();
                int vTipoMovimiento = Convert.ToInt32(viewTiposAjustes.GetFocusedRowCellValue("tipo_movimiento") ?? 0);
                int vIdTipoDocumento = 1;//Convert.ToInt32(viewTiposAjustes.GetFocusedRowCellValue("id_tipo_documento") ?? 0);

                if(!string.IsNullOrEmpty(vDescripcion.Trim().Replace(" ","")) && !string.IsNullOrEmpty(vDescripcionCorta.Trim().Replace(" ","")) && vTipoMovimiento > 0 && vIdTipoDocumento > 0)
                {
                    if(vId == "0")
                    {
                        //nuevo

                        foreach(var list in Negocio.ClasesCN.CatalogosCN.TiposAjuste_Select())
                        {
                            if((vDescripcion == list.descripcion.Trim()))
                            {
                                XtraMessageBox.Show("Lo sentimos, este registro ya existe","Tipos de Ajustes",MessageBoxButtons.OK,MessageBoxIcon.Error);
                                CargarTipoAjuste();
                                viewTiposAjustes.MoveFirst();
                                return;
                            }
                        }

                        int okGuardar = Negocio.ClasesCN.CatalogosCN.TiposAjustes_Guardar(vDescripcion, vDescripcionCorta, vTipoMovimiento, vIdTipoDocumento);
                        if(okGuardar > 0)
                        {
                            XtraMessageBox.Show("Registro guardado satisfactoriamente","Bodega",MessageBoxButtons.OK,MessageBoxIcon.Information);
                            CargarTipoAjuste();
                            viewTiposAjustes.MoveFirst();
                        }
                        else
                        {
                            XtraMessageBox.Show("Lo sentimos, no se pudo guardar los datos, verifique la información","Tipos de Ajustes",MessageBoxButtons.OK,MessageBoxIcon.Error);
                            CargarTipoAjuste();
                            viewTiposAjustes.MoveFirst();
                        }
                    }
                    else
                    {
                        //actualizar

                        foreach(var list in Negocio.ClasesCN.CatalogosCN.TiposAjuste_Select().Where(x => x.id != int.Parse(vId)))
                        {
                            if((vDescripcion == list.descripcion.Trim()))
                            {
                                XtraMessageBox.Show("Lo sentimos, este registro ya existe","Tipos de Ajustes",MessageBoxButtons.OK,MessageBoxIcon.Error);
                                CargarTipoAjuste();
                                viewTiposAjustes.MoveFirst();
                                return;
                            }
                        }

                        if(XtraMessageBox.Show("¿Desea modificar el registro?","Tipos de Ajustes",MessageBoxButtons.YesNo,MessageBoxIcon.Question) != DialogResult.Yes) { CargarTipoAjuste(); return; }
                        int okEditar = Negocio.ClasesCN.CatalogosCN.TiposAjustes_Modificar(int.Parse(vId), vDescripcion, vDescripcionCorta, vTipoMovimiento, vIdTipoDocumento, 0);
                        if(okEditar > 0)
                        {
                            XtraMessageBox.Show("Datos modificados satisfactoriamente","Tipos de Ajustes",MessageBoxButtons.OK,MessageBoxIcon.Information);
                            CargarTipoAjuste();
                            viewTiposAjustes.MoveNext();
                        }
                        else
                        {
                            XtraMessageBox.Show("Lo sentimos, no se pudo modificar los datos, verifique la información","Tipos de Ajustes",MessageBoxButtons.OK,MessageBoxIcon.Error);
                            CargarTipoAjuste();
                            viewTiposAjustes.MoveNext();
                        }
                    }
                }
                else
                {
                    XtraMessageBox.Show("Lo sentimos, no puede dejar el nombre vacio","Tipos de Ajustes",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    CargarTipoAjuste();
                    viewTiposAjustes.MoveFirst();
                }
            }
            catch(Exception)
            {
                CargarTipoAjuste();
            }
        }
        #endregion
        #region EMPLEADO

        void CargarEmpleados( )
        {
            bindingSourceEmpleado.DataSource = Negocio.ClasesCN.CatalogosCN.Empleado_Cargar();
            viewEmpleado.BestFitColumns();
            viewEmpleado.ClearColumnsFilter();
            viewEmpleado.ClearGrouping();
            viewEmpleado_FocusedRowChanged(null,null);
            HabilitarDeshabilitarControles(1);
            HabilitarDeshabilitarControles(5);
        }
        private void nbiEmpleado_LinkClicked(object sender,DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Mostrar_Pagina(8);
            //picture_huella.Image = Presentacion.Properties.Resources.finger_desconectado;
            //Mostrar_Mensaje("ESCÁNER DE HUELLAS NO ENCONTRADO...", Color.DarkRed);
            Iniciar_Controles_Huella();
            this.timer_MensajeHuella.Interval = vINTERVALO_TIMER_HUELLA;
        }
        private void bbiOperacionesEmpleado_ItemClick(object sender,DevExpress.XtraBars.ItemClickEventArgs e)
        {
            radialMenuProducto.ShowPopup(Control.MousePosition);
        }
        private void viewEmpleado_FocusedRowChanged(object sender,DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                usuario_nuevo = false;
                HabilitarDeshabilitarControles(1);
                HabilitarDeshabilitarControles(5);
                if(viewEmpleado.RowCount > 0)
                {
                    textEditEmpleadoNombre.Text = viewEmpleado.GetFocusedRowCellValue("nombre").ToString();
                    textEditEmpleadoCedula.Text = viewEmpleado.GetFocusedRowCellValue("cedula").ToString();
                    textEditEmpleadoCargo.Text = viewEmpleado.GetFocusedRowCellValue("cargo").ToString();
                    textEditEmpleadoUsuario.Text = viewEmpleado.GetFocusedRowCellValue("usuario").ToString();
                    textEditEmpleadoClave.Text = new ED.E_D().D(viewEmpleado.GetFocusedRowCellValue("clave").ToString());
                    textEditEmpleadoCelular.Text = viewEmpleado.GetFocusedRowCellValue("celular").ToString();
                    textEditEmpleadoCorreo.Text = viewEmpleado.GetFocusedRowCellValue("correo").ToString();
                    textEditEmpleadoDireccion.Text = viewEmpleado.GetFocusedRowCellValue("direccion").ToString();
                    txtCodigoEmpleado.Text = viewEmpleado.GetFocusedRowCellValue("codigo_empleado").ToString();
                    pictureEditEmpleadoFoto.EditValue = viewEmpleado.GetFocusedRowCellValue("foto");
                }
                else
                {
                    HabilitarDeshabilitarControles(3);
                }
            }
            catch(Exception) { }
        }

        private int vIdEmpleado;
        bool ValidarCamposEmpleado( )
        {
            dxError.ClearErrors(); dxError.Dispose();
            bool retorno = false;

            if(string.IsNullOrEmpty(textEditEmpleadoNombre.Text.Trim().Replace(" ","")))
            {
                dxError.SetError(textEditEmpleadoNombre,"Campo Requerido");
            }
            else if(string.IsNullOrEmpty(textEditEmpleadoCargo.Text.Trim().Replace(" ","")))
            {
                dxError.SetError(textEditEmpleadoCargo,"Campo Requerido");
            }/*
            else if (string.IsNullOrEmpty(textEditEmpleadoCedula.Text.Trim().Replace(" ", "")))
            {
                dxError.SetError(textEditEmpleadoCedula, "Campo Requerido");
            }
            else if (string.IsNullOrEmpty(textEditEmpleadoUsuario.Text.Trim().Replace(" ", "")))
            {
                dxError.SetError(textEditEmpleadoUsuario, "Campo Requerido");
            }
            else if (string.IsNullOrEmpty(textEditEmpleadoClave.Text.Trim().Replace(" ", "")))
            {
                dxError.SetError(textEditEmpleadoClave, "Campo Requerido");
            }
            else if (string.IsNullOrEmpty(textEditEmpleadoCelular.Text.Trim().Replace(" ", "")))
            {
                dxError.SetError(textEditEmpleadoCelular, "Campo Requerido");
            }
            else if (string.IsNullOrEmpty(textEditEmpleadoCorreo.Text.Trim().Replace(" ", "")))
            {
                dxError.SetError(textEditEmpleadoCorreo, "Campo Requerido");
            }
            else if (string.IsNullOrEmpty(textEditEmpleadoDireccion.Text.Trim().Replace(" ", "")))
            {
                dxError.SetError(textEditEmpleadoDireccion, "Campo Requerido");
            }*/
            else if(!string.IsNullOrEmpty(textEditEmpleadoUsuario.Text.Trim().Replace(" ","")))
            {
                if(string.IsNullOrEmpty(textEditEmpleadoClave.Text.Trim().Replace(" ","")))
                {
                    dxError.SetError(textEditEmpleadoClave,"Campo Requerido");
                }
                else { retorno = true; }
            }
            else { retorno = true; }

            return retorno;
        }

        private void textEditEmpleadoUsuario_KeyPress(object sender,KeyPressEventArgs e)
        {
            string cadena = "qwertyuiopasdfghjklñzxcvbnm1234567890QWERTYUIOPASDFGHJKLÑZXCVBNM" + (Char)8;
            try
            {
                if(!cadena.Contains(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            catch(Exception) { }
        }

        private void textEditEmpleadoClave_KeyPress(object sender,KeyPressEventArgs e)
        {
            string cadena = "" + (Char)32;
            try
            {
                if(cadena.Contains(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            catch(Exception) { }
        }

        private void lblOjo_MouseDown(object sender,MouseEventArgs e)
        {
            if(vTemp == 1)
            {
                if(Convert.ToInt32(viewEmpleado.GetFocusedRowCellValue("id")) != Clases.UsuarioLogueado.vID_Empleado)
                    return;
            }
            this.textEditEmpleadoClave.Properties.UseSystemPasswordChar = false;
        }

        private void lblOjo_MouseUp(object sender,MouseEventArgs e)
        {
            this.textEditEmpleadoClave.Properties.UseSystemPasswordChar = true;
        }

        private void textEditEmpleadoClave_Leave(object sender,EventArgs e)
        {
            if(!string.IsNullOrEmpty(textEditEmpleadoUsuario.Text))
            {
                if(!string.IsNullOrEmpty(textEditEmpleadoClave.Text))
                {
                    dxError.ClearErrors(); dxError.Dispose();
                    if(textEditEmpleadoClave.Text.Length < 6)
                    {
                        textEditEmpleadoClave.Focus();
                        textEditEmpleadoClave.SelectAll();
                        dxError.SetError(textEditEmpleadoClave,"Clave tiene que ser mayor o igual a 6 digitos");
                    }
                }
            }
            else
            {
                textEditEmpleadoClave.Text = string.Empty;
            }
        }
        private void textEditEmpleadoUsuario_TextChanged(object sender,EventArgs e)
        {
            if(usuario_nuevo == true)
            {
                if(textEditEmpleadoUsuario.Text.Trim() != string.Empty)
                {
                    if(Negocio.ClasesCN.LoginsCN.si_existe_usuario(textEditEmpleadoUsuario.Text.Trim()) == true)
                    {
                        XtraMessageBox.Show("Nickname de Usuario ya existe; Registrar otro","Información",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        standaloneBarDockControl2.Enabled = false;
                        dxErrorProvider1.SetError(textEditEmpleadoUsuario,"Nickname de Usuario ya existe; Registrar otro");
                    }
                    else
                    {
                        standaloneBarDockControl2.Enabled = true;
                        dxErrorProvider1.ClearErrors();
                    }
                }
                else
                    dxErrorProvider1.ClearErrors();
            }
            else
                dxErrorProvider1.ClearErrors();
        }
        #region HUELLA
        bool iniciado = false, iniciar_captura = false, huella_capturada= false, conectado= false, guardar_empleado= false,usuario_nuevo= false;
        private DPFP.Capture.Capture captura;
        private DPFP.Processing.Enrollment enroll;
        private delegate void delegadoMuestra(string text);
        private delegate void delegadoControles( );
        int vINTERVALO_TIMER_HUELLA = 3000;
        public DPFP.Template template;
        bool vHayScanner;
        int brazo, dedo;
        public enum HuellaDedo
        {
            MENIQUE_IZQ = 1,
            ANULAR_IZQ = 2,
            MEDIO_IZQ = 3,
            INDICE_IZQ = 4,
            PULGAR_IZQ = 5,
            PULGAR_DER = 6,
            INDICE_DER = 7,
            MEDIO_DER = 8,
            ANULAR_DER = 9,
            MENIQUE_DER = 10
        }
        public enum HuellaBrazo
        {
            IZQUIERDO = 0,
            DERECHO = 1
        }
        private void IniciarCaptura( )
        {
            if(!captura.Equals(null))
            {
                try
                {
                    captura.StartCapture();
                }
                catch(Exception)
                {
                    captura.StopCapture();
                    //XtraMessageBox.Show("Error: No se pudo iniciar la captura");
                    Mostrar_Mensaje("ESCÁNER DE HUELLAS NO ENCONTRADO...",Color.DarkRed);
                    Ejecutar(( ) => { picture_huella.Image = Properties.Resources.finger_desconectado; });
                }
            }
        }
        private void PararCaptura( )
        {
            try
            {
                if(!captura.Equals(null))
                {
                    captura.StopCapture();
                    iniciado = false;
                }
            }
            catch(Exception)
            {
                XtraMessageBox.Show("Error: No se pudo parar la captura");
                iniciado = true;
            }
        }
        public virtual void Init( )
        {
            try
            {
                captura = new DPFP.Capture.Capture();
                if(!captura.Equals(null))
                {
                    captura.EventHandler = this;
                    enroll = new DPFP.Processing.Enrollment();
                    StringBuilder text = new StringBuilder();
                    text.AppendFormat("Necesitas pasar el dedo {0} veces",enroll.FeaturesNeeded);
                    lbl_MensajeHuella.Text = text.ToString();
                }
                else
                    XtraMessageBox.Show("No se pudo iniciar la captura");
            }
            catch(Exception)
            {
                XtraMessageBox.Show("Error: No se pudo iniciar la captura");
            }
        }
        private void CapturarManoIzq(int d)
        {
            if(iniciado)
            {
                PararCaptura();
                //pbIzq.Visible = true;
                //pbDer.Visible = false;
                //pbIzq.Image = null;
                //pbDer.Image = null;
                lbl_MensajeHuella.Visible = true;
                lbl_MensajeHuella.Visible = false;
                Init();
                IniciarCaptura();
                brazo = (int) HuellaBrazo.IZQUIERDO;
                dedo = d;
                iniciado = true;
            }
            else
            {
                //pbIzq.Visible = true;
                //pbDer.Visible = false;
                //pbIzq.Image = null;
                //pbDer.Image = null;
                lbl_MensajeHuella.Visible = true;
                lbl_MensajeHuella.Visible = false;
                Init();
                IniciarCaptura();
                brazo = (int) HuellaBrazo.IZQUIERDO;
                dedo = d;
                iniciado = true;
            }
            //groupControl1.ContentImage = Properties.Resources.s
        }
        private void CapturarManoDer(int d)
        {
            if(iniciado)
            {
                PararCaptura();
                Init();
                IniciarCaptura();
                brazo = (int) HuellaBrazo.DERECHO;
                dedo = d;
                iniciado = true;
            }
            else
            {
                brazo = (int) HuellaBrazo.DERECHO;
                Init();
                IniciarCaptura();
                dedo = d;
                iniciado = true;
            }
        }
        public void AsignarImagen(Bitmap bmp)
        {
            picture_huella.Image = bmp;
            //pbDer.Image = bmp;
        }
        public Bitmap Convertir_MapaBits(DPFP.Sample Sample)
        {
            SampleConversion convertidor = new SampleConversion();
            Bitmap mapaBits = null;

            convertidor.ConvertToPicture(Sample,ref mapaBits);

            return mapaBits;
        }
        private void CambiarBotonListo( )
        {
            picture_huella.Image = Presentacion.Properties.Resources.Finger_Huella_Reconocida;
            Mostrar_Mensaje("Huella Capturada Correctamente",Color.DarkGreen);
            huella_capturada = true;
            btn_iniciar_captura.Text = "LISTO!!!!";
            //btn_iniciar_captura.ForeColor = Color.Green;
            if(brazo == (int) HuellaBrazo.IZQUIERDO)
            {
                if(dedo == (int) HuellaDedo.PULGAR_IZQ)
                {
                    btn_iniciar_captura.ForeColor = Color.Green;
                }
                else
                {
                    if(dedo == (int) HuellaDedo.INDICE_IZQ)
                    {
                        btn_iniciar_captura.Text = "LISTO";
                        btn_iniciar_captura.ForeColor = Color.Green;
                    }
                    else
                    {
                        if(dedo == (int) HuellaDedo.MEDIO_IZQ)
                        {
                            btn_iniciar_captura.Text = "LISTO";
                            btn_iniciar_captura.ForeColor = Color.Green;
                        }
                        else
                        {
                            if(dedo == (int) HuellaDedo.ANULAR_IZQ)
                            {
                                btn_iniciar_captura.Text = "LISTO";
                                btn_iniciar_captura.ForeColor = Color.Green;
                            }
                            else
                            {
                                if(dedo == (int) HuellaDedo.MENIQUE_IZQ)
                                {
                                    btn_iniciar_captura.Text = "LISTO";
                                    btn_iniciar_captura.ForeColor = Color.Green;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                if(dedo == (int) HuellaDedo.PULGAR_DER)
                {
                    btn_iniciar_captura.Text = "LISTO";
                    btn_iniciar_captura.ForeColor = Color.Green;
                }
                else
                {
                    if(dedo == (int) HuellaDedo.INDICE_DER)
                    {
                        btn_iniciar_captura.Text = "LISTO";
                        btn_iniciar_captura.ForeColor = Color.Green;
                    }
                    else
                    {
                        if(dedo == (int) HuellaDedo.MEDIO_DER)
                        {
                            btn_iniciar_captura.Text = "LISTO";
                            btn_iniciar_captura.ForeColor = Color.Green;
                        }
                        else
                        {
                            if(dedo == (int) HuellaDedo.ANULAR_DER)
                            {
                                btn_iniciar_captura.Text = "LISTO";
                                btn_iniciar_captura.ForeColor = Color.Green;
                            }
                            else
                            {
                                if(dedo == (int) HuellaDedo.MENIQUE_DER)
                                {
                                    btn_iniciar_captura.Text = "LISTO";
                                    btn_iniciar_captura.ForeColor = Color.Green;
                                }
                            }
                        }
                    }
                }
            }
        }
        public DPFP.FeatureSet ExtrarCaracteristica(DPFP.Sample sample,DPFP.Processing.DataPurpose purpose)
        {
            DPFP.Processing.FeatureExtraction ex = new DPFP.Processing.FeatureExtraction();
            DPFP.Capture.CaptureFeedback ali = CaptureFeedback.None;
            DPFP.FeatureSet carac = new FeatureSet();
            ex.CreateFeatureSet(sample,purpose,ref ali,ref carac);
            if(ali == DPFP.Capture.CaptureFeedback.Good)
            {
                return carac;
            }
            else
            {
                return null;
            }
        }
        private void MostrarVeces(string texto)//para ir disminuyendo el conteo cada vez que captura huella
        {
            if(lbl_MensajeHuella.InvokeRequired)
            {
                delegadoMuestra deleg = new delegadoMuestra(MostrarVeces);
                this.Invoke(deleg,new object[] { texto });
            }
            else
            {
                lbl_MensajeHuella.Text = texto;
                //vecesDedoD.Text = texto;
            }
        }
        public void ModificarControles( )//para habilitar boton cuando se capture huella, no se puede hacer en el metodo de proceso, se tiene que sar delegado
        {
            if(InvokeRequired)
            {
                //Invoke(new MethodInvoker(() => ModificarControles()));
                delegadoControles deleg = new delegadoControles(ModificarControles);
                this.Invoke(deleg,new object[] { });
            }
            else
            {
                //bbi_guardar_empleado.Enabled = true;
                CambiarBotonListo();
            }
        }
        public void Procesar(DPFP.Sample sample)
        {
            DPFP.FeatureSet caracteristica = ExtrarCaracteristica(sample, DPFP.Processing.DataPurpose.Enrollment);
            if(!caracteristica.Equals(null))
            {
                try
                {
                    enroll.AddFeatures(caracteristica);
                }
                catch(Exception)
                {
                    XtraMessageBox.Show("Error: Huella no reconocida");
                    PararCaptura();
                }
                finally
                {
                    StringBuilder text = new StringBuilder();
                    text.AppendFormat("Necesitas pasar el dedo {0} veces",enroll.FeaturesNeeded);
                    MostrarVeces(text.ToString());
                    switch(enroll.TemplateStatus)
                    {
                        case DPFP.Processing.Enrollment.Status.Ready:
                            template = enroll.Template;
                            PararCaptura();
                            ModificarControles();
                            break;
                        case DPFP.Processing.Enrollment.Status.Failed:
                            enroll.Clear();
                            PararCaptura();
                            IniciarCaptura();
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        public void OnComplete(object Capture,string ReaderSerialNumber,Sample Sample)
        {
            if(iniciar_captura)
            {
                AsignarImagen(Convertir_MapaBits(Sample));
                Procesar(Sample);
            }
        }
        public void OnFingerGone(object Capture,string ReaderSerialNumber)
        { }
        public void OnFingerTouch(object Capture,string ReaderSerialNumber)
        { }
        public void OnReaderConnect(object Capture,string ReaderSerialNumber)
        {
            try
            {
                vHayScanner = true;
                Ejecutar(( ) => { FingerConectado(); });
                Ejecutar(( ) => { picture_huella.Image = Properties.Resources.finger_conectado; });
            }
            catch(DPFP.Error.SDKException)
            {
                GC.Collect();
            }
        }
        public void OnReaderDisconnect(object Capture,string ReaderSerialNumber)
        {
            try
            {
                vHayScanner = false;
                Ejecutar(( ) => { FingerDesconectado(); });
                Ejecutar(( ) => { picture_huella.Image = Properties.Resources.finger_desconectado; });
            }
            catch(DPFP.Error.SDKException)
            {
                GC.Collect();
            }
            //XtraMessageBox.Show("Finger desconectado, Conectelo e intente nuevamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void OnSampleQuality(object Capture,string ReaderSerialNumber,CaptureFeedback CaptureFeedback)
        { }
        private void timer_MensajeHuella_Tick(object sender,EventArgs e)
        {
            try
            {
                if(timer_MensajeHuella.Interval == vINTERVALO_TIMER_HUELLA)
                {
                    LimpiarHuella();
                }
            }
            catch(Exception) { }
        }
        private void Ejecutar(Action a)
        {
            try
            {
                BeginInvoke(new Action(a));
            }
            catch(InvalidOperationException) { }
        }
        void LimpiarHuella( )
        {
            try
            {
                if(vHayScanner)
                {
                    Ejecutar(( ) => { FingerConectado(); });
                    Ejecutar(( ) => { picture_huella.Image = Properties.Resources.finger_conectado; });
                }
            }
            catch(Exception)
            {

                throw;
            }
        }
        private void Iniciar_Controles_Huella( )
        {
            if(iniciado)
            {
                PararCaptura();
                Init();
                IniciarCaptura();
                iniciado = true;
            }
            else
            {
                Init();
                IniciarCaptura();
                iniciado = true;
            }
        }
        private void limpiar_controles_huella( )
        {
            iniciar_captura = huella_capturada = false;
            if(iniciado)
            {
                PararCaptura();
                Init();
                IniciarCaptura();
                iniciado = true;
            }
            else
            {
                Init();
                IniciarCaptura();
                iniciado = true;
            }
            enroll.Clear();
            btn_iniciar_captura.Enabled = false;
            btn_iniciar_captura.Text = "Iniciar Captura";
        }
        void FingerConectado( )
        {
            try
            {
                Mostrar_Mensaje("» ESCÁNER DE HUELLAS ACTIVO «",Color.DarkBlue);
                picture_huella.Image = Properties.Resources.finger_conectado;
                Set_Estado_Finger("Dispositivo Activo");
                conectado = true;
                if(guardar_empleado == true)
                    btn_iniciar_captura.Enabled = true;
            }
            catch(Exception) { }
        }
        void FingerDesconectado( )
        {
            try
            {
                Mostrar_Mensaje("ESCÁNER DE HUELLAS NO ENCONTRADO...",Color.DarkRed);
                picture_huella.Image = Properties.Resources.finger_desconectado;
                //--------------------------------------------------
                Set_Estado_Finger("Dispositivo No Encontrado");
                conectado = false;
                if(guardar_empleado == true)
                    btn_iniciar_captura.Enabled = false;

            }
            catch(Exception) { }
        }
        public void Set_Estado_Finger(string mensaje)
        {
            try
            {
                ToolTip tt = new ToolTip();
                tt.SetToolTip(this.picture_huella,mensaje);
                //picture_huella = mensaje;
                //picture_huella.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
                //picture_huella.ToolTipTitle = "Escáner de Huellas";
                //picture_huella.Show();
            }
            catch(Exception) { }
        }
        private void picture_huella_MouseHover(object sender,EventArgs e)
        {

        }
        void Mostrar_Mensaje(string MENSAJE,Color COLOR)
        {
            try
            {
                lbl_MensajeHuella.Text = MENSAJE;
                lbl_MensajeHuella.ForeColor = COLOR;
            }
            catch(Exception) { }
        }
        private void btn_iniciar_captura_Click(object sender,EventArgs e)
        {
            iniciar_captura = true;
            btn_iniciar_captura.Enabled = false;
            Mostrar_Mensaje("»Colocar Dedo «",Color.DarkBlue);
        }
        public void Guardar_Huella_Digital(int id_empleado)
        {
            if(huella_capturada)
            {
                MemoryStream ms = new MemoryStream(template.Bytes);
                Negocio.ClasesCN.LoginsCN.Guardar_huella(ms.ToArray(),1,id_empleado,1);
            }
        }
        #endregion

        #endregion
        #region PROVEEDORES
        void CargarProveedores( )
        {
            bindingSourceProveedores.DataSource = Negocio.ClasesCN.CatalogosCN.Proveedores_Select();
        }

        private void nbi_Proveedores_LinkClicked(object sender,DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Mostrar_Pagina(10);
            txt_nombre_proveedor.ReadOnly = txt_identificacion_proveedor.ReadOnly = txt_departamento_proveedores.ReadOnly=txt_direccion_proveedor.ReadOnly=txt_departamento_proveedores.ReadOnly=txt_telefono_proveedor.ReadOnly=txt_correo_proveedor.ReadOnly=txt_ciudad_proveedores.ReadOnly=txt_pais.ReadOnly=txt_telefono_contacto_proveedor.ReadOnly=txt_nombre_contacti_proveedor.ReadOnly = txt_telefono_contacto_proveedor.ReadOnly = true;
        }

        private void viewProveedores_FocusedRowChanged(object sender,DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if(viewProveedores.RowCount > 0 )
                {
                    string vId =Convert.ToString( viewProveedores.GetFocusedRowCellValue("id")??"");
                    string vNombre = Convert.ToString(viewProveedores.GetFocusedRowCellValue("nombre") ?? "").ToUpper().Trim();
                    string vDireccion = Convert.ToString(viewProveedores.GetFocusedRowCellValue("direccion") ?? "").ToUpper().Trim();
                    string vTelefono = Convert.ToString(viewProveedores.GetFocusedRowCellValue("telefono") ?? "").ToUpper().Trim();
                    string vRuc = Convert.ToString(viewProveedores.GetFocusedRowCellValue("ruc") ?? "").ToUpper().Trim();
                    string vCorreo = Convert.ToString(viewProveedores.GetFocusedRowCellValue("correo") ?? "").ToUpper().Trim();
                    string vDepartamento = Convert.ToString(viewProveedores.GetFocusedRowCellValue("departamento") ?? "").ToUpper().Trim();
                    string vCiudad = Convert.ToString(viewProveedores.GetFocusedRowCellValue("ciudad") ?? "").ToUpper().Trim();
                    string vPais = Convert.ToString(viewProveedores.GetFocusedRowCellValue("pais") ?? "").ToUpper().Trim();
                    string vContacto = Convert.ToString(viewProveedores.GetFocusedRowCellValue("contacto") ?? "").ToUpper().Trim();
                    string vTelefonoContacto = Convert.ToString(viewProveedores.GetFocusedRowCellValue("telefono_contacto") ?? "").ToUpper().Trim();
                    string vCorreoContacto = Convert.ToString(viewProveedores.GetFocusedRowCellValue("correo_contacto") ?? "").ToUpper().Trim();
                    decimal vCredito = Convert.ToDecimal(viewProveedores.GetFocusedRowCellValue("credito_maximo") ?? 0.00);

                    txt_nombre_proveedor.Text = vNombre;
                    txt_direccion_proveedor.Text = vDireccion;
                    txt_telefono_proveedor.Text = vTelefono;
                    txt_identificacion_proveedor.Text = vRuc;
                    txt_correo_proveedor.Text = vCorreo;
                    txt_departamento_proveedores.Text = vDepartamento;
                    txt_ciudad_proveedores.Text = vCiudad;
                    txt_pais.Text = vPais;
                    txt_nombre_contacti_proveedor.Text = vContacto;
                    txt_telefono_contacto_proveedor.Text = vTelefonoContacto;
                    txt_correo_contacto.Text = vCorreoContacto;
                    txt_nombre_proveedor.ReadOnly = txt_identificacion_proveedor.ReadOnly = txt_departamento_proveedores.ReadOnly = txt_direccion_proveedor.ReadOnly = txt_departamento_proveedores.ReadOnly = txt_telefono_proveedor.ReadOnly = txt_correo_proveedor.ReadOnly = txt_ciudad_proveedores.ReadOnly = txt_pais.ReadOnly = txt_telefono_contacto_proveedor.ReadOnly = txt_nombre_contacti_proveedor.ReadOnly = txt_telefono_contacto_proveedor.ReadOnly = true;
                }
            }
            catch(Exception  ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void bbi_nuevo_proveedorr_ItemClick(object sender,DevExpress.XtraBars.ItemClickEventArgs e)
        {

            id_proveedor = 0.ToString();
            txt_nombre_proveedor.ReadOnly = txt_identificacion_proveedor.ReadOnly = txt_departamento_proveedores.ReadOnly = txt_direccion_proveedor.ReadOnly = txt_departamento_proveedores.ReadOnly = txt_telefono_proveedor.ReadOnly = txt_correo_proveedor.ReadOnly = txt_ciudad_proveedores.ReadOnly = txt_pais.ReadOnly = txt_telefono_contacto_proveedor.ReadOnly = txt_nombre_contacti_proveedor.ReadOnly = txt_telefono_contacto_proveedor.ReadOnly = false;
            txt_nombre_proveedor.Text = string.Empty;
            txt_direccion_proveedor.Text = string.Empty;
            txt_telefono_proveedor.Text = string.Empty;
            txt_identificacion_proveedor.Text = string.Empty;
            txt_correo_proveedor.Text = string.Empty;
            txt_departamento_proveedores.Text = string.Empty;
            txt_ciudad_proveedores.Text = string.Empty;
            txt_pais.Text = string.Empty;
            txt_nombre_contacti_proveedor.Text =string.Empty;
            txt_telefono_contacto_proveedor.Text = string.Empty;
            txt_correo_contacto.Text = string.Empty;
            txt_nombre_proveedor.Focus();

        }
        private void bbi_editar_proveedor_ItemClick(object sender,DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                id_proveedor = Convert.ToString(viewProveedores.GetFocusedRowCellValue("id") ?? 0.ToString());
                txt_nombre_proveedor.ReadOnly = txt_identificacion_proveedor.ReadOnly = txt_departamento_proveedores.ReadOnly = txt_direccion_proveedor.ReadOnly = txt_departamento_proveedores.ReadOnly = txt_telefono_proveedor.ReadOnly = txt_correo_proveedor.ReadOnly = txt_ciudad_proveedores.ReadOnly = txt_pais.ReadOnly = txt_telefono_contacto_proveedor.ReadOnly = txt_nombre_contacti_proveedor.ReadOnly = txt_telefono_contacto_proveedor.ReadOnly = false;
            }
            catch(Exception)
            {

                throw;
            }
        }
        private void bbi_guardar_proveedor_ItemClick(object sender,DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {

            
            string vNombre=    txt_nombre_proveedor.Text;
            string vDireccion=    txt_direccion_proveedor.Text;
            string vTelefono=    txt_telefono_proveedor.Text ;
            string vRuc=    txt_identificacion_proveedor.Text;
            string vCorreo=    txt_correo_proveedor.Text  ;
            string vDepartamento=   txt_departamento_proveedores.Text;
             string vCiudad=  txt_ciudad_proveedores.Text;
            string vPais= txt_pais.Text ;
            string vContacto=  txt_nombre_contacti_proveedor.Text ;
            string vTelefonoContacto=  txt_telefono_contacto_proveedor.Text ;
            string vCorreoContacto=  txt_correo_contacto.Text;
                if(!string.IsNullOrEmpty(vNombre.Trim().Replace(" ","")))
                {
                    if(id_proveedor == "0")
                    {
                        //nuevo

                        foreach(var list in Negocio.ClasesCN.CatalogosCN.Proveedores_Select())
                        {
                            if((vNombre == list.nombre.Trim()))
                            {
                                XtraMessageBox.Show("Lo sentimos, este registro ya existe","Proveedores",MessageBoxButtons.OK,MessageBoxIcon.Error);
                                CargarProveedores();
                                viewProveedores.MoveFirst();
                                return;
                            }
                        }

                        int okGuardar = Negocio.ClasesCN.CatalogosCN.Proveedores_Guardar(vNombre, vDireccion, vTelefono, vRuc, vCorreo, vDepartamento, vCiudad, vPais, vContacto, vTelefonoContacto, vCorreoContacto, 0);
                        if(okGuardar > 0)
                        {
                            XtraMessageBox.Show("Registro guardado satisfactoriamente","Proveedores",MessageBoxButtons.OK,MessageBoxIcon.Information);
                            CargarProveedores();
                            viewProveedores.MoveFirst();
                        }
                        else
                        {
                            XtraMessageBox.Show("Lo sentimos, no se pudo guardar los datos, verifique la información","Proveedores",MessageBoxButtons.OK,MessageBoxIcon.Error);
                            CargarProveedores();
                            viewProveedores.MoveFirst();
                        }
                    }
                    else
                    {
                        //actualizar

                        foreach(var list in Negocio.ClasesCN.CatalogosCN.Proveedores_Select().Where(x => x.id != int.Parse(id_proveedor)))
                        {
                            if((vNombre == list.nombre.Trim()))
                            {
                                XtraMessageBox.Show("Lo sentimos, este registro ya existe","Proveedores",MessageBoxButtons.OK,MessageBoxIcon.Error);
                                CargarProveedores();
                                viewProveedores.MoveFirst();
                                return;
                            }
                        }

                        if(XtraMessageBox.Show("¿Desea modificar el registro?","Proveedores",MessageBoxButtons.YesNo,MessageBoxIcon.Question) != DialogResult.Yes) { CargarProveedores(); return; }
                        int okEditar = Negocio.ClasesCN.CatalogosCN.Proveedores_Modificar(int.Parse(id_proveedor), vNombre, vDireccion, vTelefono, vRuc, vCorreo, vDepartamento, vCiudad, vPais, vContacto, vTelefonoContacto, vCorreoContacto, 0, 0);
                        if(okEditar > 0)
                        {
                            XtraMessageBox.Show("Datos modificados satisfactoriamente","Proveedores",MessageBoxButtons.OK,MessageBoxIcon.Information);
                            CargarProveedores();
                            viewProveedores.MoveNext();
                        }
                        else
                        {
                            XtraMessageBox.Show("Lo sentimos, no se pudo modificar los datos, verifique la información","Proveedores",MessageBoxButtons.OK,MessageBoxIcon.Error);
                            CargarProveedores();
                            viewProveedores.MoveNext();
                        }
                    }
                }
                else
                {
                    XtraMessageBox.Show("Lo sentimos, no puede dejar el nombre vacio p credito menor a 0.00","Proveedores",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    CargarProveedores();
                    viewProveedores.MoveFirst();
                }


            }
            catch(Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
        private void viewProveedores_InitNewRow(object sender,InitNewRowEventArgs e)
        {
            viewProveedores.SetRowCellValue(e.RowHandle,"pais","NICARAGUA");
        }

        private void viewProveedores_RowUpdated(object sender,DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            try
            {
                string vId = viewProveedores.GetFocusedRowCellValue("id").ToString();
                string vNombre = Convert.ToString(viewProveedores.GetFocusedRowCellValue("nombre") ?? "").ToUpper().Trim();
                string vDireccion = Convert.ToString(viewProveedores.GetFocusedRowCellValue("direccion") ?? "").ToUpper().Trim();
                string vTelefono = Convert.ToString(viewProveedores.GetFocusedRowCellValue("telefono") ?? "").ToUpper().Trim();
                string vRuc = Convert.ToString(viewProveedores.GetFocusedRowCellValue("ruc") ?? "").ToUpper().Trim();
                string vCorreo = Convert.ToString(viewProveedores.GetFocusedRowCellValue("correo") ?? "").ToUpper().Trim();
                string vDepartamento = Convert.ToString(viewProveedores.GetFocusedRowCellValue("departamento") ?? "").ToUpper().Trim();
                string vCiudad = Convert.ToString(viewProveedores.GetFocusedRowCellValue("ciudad") ?? "").ToUpper().Trim();
                string vPais = Convert.ToString(viewProveedores.GetFocusedRowCellValue("pais") ?? "").ToUpper().Trim();
                string vContacto = Convert.ToString(viewProveedores.GetFocusedRowCellValue("contacto") ?? "").ToUpper().Trim();
                string vTelefonoContacto = Convert.ToString(viewProveedores.GetFocusedRowCellValue("telefono_contacto") ?? "").ToUpper().Trim();
                string vCorreoContacto = Convert.ToString(viewProveedores.GetFocusedRowCellValue("correo_contacto") ?? "").ToUpper().Trim();
                decimal vCredito = Convert.ToDecimal(viewProveedores.GetFocusedRowCellValue("credito_maximo") ?? 0.00);

                if(!string.IsNullOrEmpty(vNombre.Trim().Replace(" ","")))
                {
                    if(vId == "0")
                    {
                        //nuevo

                        foreach(var list in Negocio.ClasesCN.CatalogosCN.Proveedores_Select())
                        {
                            if((vNombre == list.nombre.Trim()))
                            {
                                XtraMessageBox.Show("Lo sentimos, este registro ya existe","Proveedores",MessageBoxButtons.OK,MessageBoxIcon.Error);
                                CargarProveedores();
                                viewProveedores.MoveFirst();
                                return;
                            }
                        }

                        int okGuardar = Negocio.ClasesCN.CatalogosCN.Proveedores_Guardar(vNombre, vDireccion, vTelefono, vRuc, vCorreo, vDepartamento, vCiudad, vPais, vContacto, vTelefonoContacto, vCorreoContacto, vCredito);
                        if(okGuardar > 0)
                        {
                            XtraMessageBox.Show("Registro guardado satisfactoriamente","Proveedores",MessageBoxButtons.OK,MessageBoxIcon.Information);
                            CargarProveedores();
                            viewProveedores.MoveFirst();
                        }
                        else
                        {
                            XtraMessageBox.Show("Lo sentimos, no se pudo guardar los datos, verifique la información","Proveedores",MessageBoxButtons.OK,MessageBoxIcon.Error);
                            CargarProveedores();
                            viewProveedores.MoveFirst();
                        }
                    }
                    else
                    {
                        //actualizar

                        foreach(var list in Negocio.ClasesCN.CatalogosCN.Proveedores_Select().Where(x => x.id != int.Parse(vId)))
                        {
                            if((vNombre == list.nombre.Trim()))
                            {
                                XtraMessageBox.Show("Lo sentimos, este registro ya existe","Proveedores",MessageBoxButtons.OK,MessageBoxIcon.Error);
                                CargarProveedores();
                                viewProveedores.MoveFirst();
                                return;
                            }
                        }

                        if(XtraMessageBox.Show("¿Desea modificar el registro?","Proveedores",MessageBoxButtons.YesNo,MessageBoxIcon.Question) != DialogResult.Yes) { CargarProveedores(); return; }
                        int okEditar = Negocio.ClasesCN.CatalogosCN.Proveedores_Modificar(int.Parse(vId), vNombre, vDireccion, vTelefono, vRuc, vCorreo, vDepartamento, vCiudad, vPais, vContacto, vTelefonoContacto, vCorreoContacto, vCredito, 0);
                        if(okEditar > 0)
                        {
                            XtraMessageBox.Show("Datos modificados satisfactoriamente","Proveedores",MessageBoxButtons.OK,MessageBoxIcon.Information);
                            CargarProveedores();
                            viewProveedores.MoveNext();
                        }
                        else
                        {
                            XtraMessageBox.Show("Lo sentimos, no se pudo modificar los datos, verifique la información","Proveedores",MessageBoxButtons.OK,MessageBoxIcon.Error);
                            CargarProveedores();
                            viewProveedores.MoveNext();
                        }
                    }
                }
                else
                {
                    XtraMessageBox.Show("Lo sentimos, no puede dejar el nombre vacio p credito menor a 0.00","Proveedores",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    CargarProveedores();
                    viewProveedores.MoveFirst();
                }
            }
            catch(Exception)
            {
                CargarProveedores();
            }
        }

        private void viewProveedores_KeyDown(object sender,KeyEventArgs e)
        {
            try
            {
                if(e.KeyCode == Keys.Delete)
                {
                    if(viewProveedores.RowCount > 0)
                    {
                        if(XtraMessageBox.Show("¿Desea eliminar este registro?","Proveedores",MessageBoxButtons.YesNo,MessageBoxIcon.Question) != DialogResult.Yes) return;
                        int eliminar = Negocio.ClasesCN.CatalogosCN.Proveedores_Eliminar(Convert.ToInt32(viewProveedores.GetFocusedRowCellValue("id")), 0);
                        if(eliminar > 0)
                        {
                            XtraMessageBox.Show("Registro eliminado con exito","Proveedores",MessageBoxButtons.OK,MessageBoxIcon.Information);
                            CargarProveedores();
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show("Error :" + ex.Message);
            }
        }
        #endregion
        #region CAJA
        private void nbi_caja_LinkClicked(object sender,DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Mostrar_Pagina(13);
            bindingSourceCaja.DataSource = Negocio.ClasesCN.CajaCN.SALDO_INICIAL_MOSTRAR().ToList();
        }
        private void gridView_cierre_caja_KeyDown(object sender,KeyEventArgs e)
        {
            try
            {
                if(e.KeyCode == Keys.Delete)
                {
                    if(gridView_cierre_caja.RowCount > 0)
                    {
                        int id_cierre =Convert.ToInt32(gridView_cierre_caja.GetFocusedRowCellValue(col_id_cierre).ToString());
                        int estado_cierre = Convert.ToInt32(gridView_cierre_caja.GetFocusedRowCellValue(col_estado_cierre).ToString());
                        if(estado_cierre == 2)
                        {
                            if(XtraMessageBox.Show("Registro a eliminar ya se encuentra cerrado; ¿Desea eliminarlo?","Mensaje del sistema",MessageBoxButtons.YesNo,MessageBoxIcon.Question) != DialogResult.Yes) { bindingSourceCaja.DataSource = Negocio.ClasesCN.CajaCN.SALDO_INICIAL_MOSTRAR().ToList(); return; }
                            int eliminar = Negocio.ClasesCN.CajaCN.SALDO_INICIAL_ELIMINAR(id_cierre,id_empleado);
                            if(eliminar > 0)
                            {
                                XtraMessageBox.Show("Registro eliminado con exito","Cliente",MessageBoxButtons.OK,MessageBoxIcon.Information);
                                bindingSourceCaja.DataSource = Negocio.ClasesCN.CajaCN.SALDO_INICIAL_MOSTRAR().ToList();
                            }
                        }
                        else
                        {
                            if(XtraMessageBox.Show("¿Desea eliminar este registro?","Mensaje del sistema",MessageBoxButtons.YesNo,MessageBoxIcon.Question) != DialogResult.Yes) { bindingSourceCaja.DataSource = Negocio.ClasesCN.CajaCN.SALDO_INICIAL_MOSTRAR().ToList(); return; }
                            int eliminar = Negocio.ClasesCN.CajaCN.SALDO_INICIAL_ELIMINAR(id_cierre, id_empleado);
                            if(eliminar > 0)
                            {
                                XtraMessageBox.Show("Registro eliminado con exito","Cliente",MessageBoxButtons.OK,MessageBoxIcon.Information);
                                bindingSourceCaja.DataSource = Negocio.ClasesCN.CajaCN.SALDO_INICIAL_MOSTRAR().ToList();
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show("Error :" + ex.Message);
            }
        }

        private void gridView_cierre_caja_RowUpdated(object sender,DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            try
            {
                string id_cierre = gridView_cierre_caja.GetFocusedRowCellValue(col_id_cierre).ToString();
                DateTime fecha_ejecucion = Convert.ToDateTime(gridView_cierre_caja.GetFocusedRowCellValue(col_fecha_caja).ToString());
                decimal saldo_inicial= Convert.ToDecimal(gridView_cierre_caja.GetFocusedRowCellValue(col_saldo_inicial).ToString());
                decimal tc =  Negocio.ClasesCN.DatosRequeridosCN.obtener_tipo_cambio_mensual();
                if(id_cierre == "0")
                {
                    //nuevo
                    if(Negocio.ClasesCN.CajaCN.SI_EXISTE_YA_UNA_FECHA_INGRESADA(fecha_ejecucion))
                    {
                        XtraMessageBox.Show("Ya existe una fecha con saldo inicial","Mensaje del sistema",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        bindingSourceCaja.DataSource = Negocio.ClasesCN.CajaCN.SALDO_INICIAL_MOSTRAR().ToList();
                        gridView_cierre_caja.MoveFirst();
                        return;
                    }
                    int okGuardar = Negocio.ClasesCN.CajaCN.SALDO_INICIAL_GUARDAR(fecha_ejecucion,saldo_inicial,id_empleado,tc);
                    if(okGuardar > 0)
                    {
                        XtraMessageBox.Show("Registro guardado satisfactoriamente","Mensaje del sistema",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        bindingSourceCaja.DataSource = Negocio.ClasesCN.CajaCN.SALDO_INICIAL_MOSTRAR().ToList();
                        gridView_cierre_caja.MoveFirst();
                        return;
                    }
                    else
                    {
                        XtraMessageBox.Show("Lo sentimos, no se pudo guardar los datos, verifique la información","Mensaje del sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        bindingSourceCaja.DataSource = Negocio.ClasesCN.CajaCN.SALDO_INICIAL_MOSTRAR().ToList();
                        gridView_cierre_caja.MoveFirst();
                        return;
                    }
                }
                else
                {
                    int estado_cierre = Convert.ToInt32(gridView_cierre_caja.GetFocusedRowCellValue(col_estado_cierre).ToString());
                    int idc = Convert.ToInt32(id_cierre);
                    if(estado_cierre == 2)
                    {
                        XtraMessageBox.Show("Registro a modificar ya se encuentra cerrado; no puede modificarse","Mensaje del sistema",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        bindingSourceCaja.DataSource = Negocio.ClasesCN.CajaCN.SALDO_INICIAL_MOSTRAR().ToList();
                        gridView_cierre_caja.MoveFirst();
                        return;
                    }
                    else
                    {
                        foreach(var r in Negocio.ClasesCN.CajaCN.SALDO_INICIAL_MOSTRAR().Where(o => o.fecha_ejecucion == fecha_ejecucion).ToList())
                        {
                            if(r.id_cierre != idc)
                            {
                                XtraMessageBox.Show("Ya existe una registro son fecha a ingresar; favor verifique","Mensaje del sistema",MessageBoxButtons.OK,MessageBoxIcon.Information);
                                bindingSourceCaja.DataSource = Negocio.ClasesCN.CajaCN.SALDO_INICIAL_MOSTRAR().ToList();
                                gridView_cierre_caja.MoveFirst();
                                return;
                            }
                        }
                        if(XtraMessageBox.Show("¿Desea modificar el registro?","Mensaje del sistema",MessageBoxButtons.YesNo,MessageBoxIcon.Question) != DialogResult.Yes) { bindingSourceCaja.DataSource = Negocio.ClasesCN.CajaCN.SALDO_INICIAL_MOSTRAR().ToList(); return; }
                        int okGuardar = Negocio.ClasesCN.CajaCN.SALDO_INICIAL_EDITAR(idc, fecha_ejecucion, saldo_inicial, id_empleado,tc);
                        if(okGuardar > 0)
                        {
                            XtraMessageBox.Show("Registro actualizado satisfactoriamente","Mensaje del sistema",MessageBoxButtons.OK,MessageBoxIcon.Information);
                            bindingSourceCaja.DataSource = Negocio.ClasesCN.CajaCN.SALDO_INICIAL_MOSTRAR().ToList();
                            gridView_cierre_caja.MoveFirst();
                            return;
                        }
                        else
                        {
                            XtraMessageBox.Show("Lo sentimos, no se pudo guardar los datos, verifique la información","Mensaje del sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
                            bindingSourceCaja.DataSource = Negocio.ClasesCN.CajaCN.SALDO_INICIAL_MOSTRAR().ToList();
                            gridView_cierre_caja.MoveFirst();
                            return;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                bindingSourceCaja.DataSource = Negocio.ClasesCN.CajaCN.SALDO_INICIAL_MOSTRAR().ToList();
                gridView_cierre_caja.MoveFirst();
            }
        }

        #endregion
        #region RADIAL MENU

        void HabilitarDeshabilitarControles(int i)
        {
            if(XtraTabControlCatalogos.SelectedTabPage == tabProductos)
            {
                switch(i)
                {
                    case 1:
                        if(viewProductos.RowCount > 0)
                        {
                            blbiNuevo.Enabled = true;
                            blbiGuardar.Enabled = false;
                            blbiEditar.Enabled = true;
                            blbiCancelar.Enabled = false;

                        }
                        else
                        {
                            blbiNuevo.Enabled = true;
                            blbiGuardar.Enabled = false;
                            blbiEditar.Enabled = false;
                            blbiCancelar.Enabled = false;
                        }
                        break;

                    case 2: //Cuando presionamos el boton nuevo
                        blbiNuevo.Enabled = false;
                        blbiGuardar.Enabled = true;
                        blbiEditar.Enabled = false;
                        blbiCancelar.Enabled = true;
                        
                        break;

                    case 3: // limpiar controles
                        textEditCodigo.Text = string.Empty;
                        textEditCodigo_KeyPress(null,null);
                        textEditDescripcion.Text = string.Empty;
                        lookUpEditCategoria.EditValue = null;
                        lookUpEditMarca.EditValue = null;
                        lookUpEditLinea.EditValue = null;
                        lookUpEditUnidadMedida.EditValue = null;
                        lookUpEditMoneda.EditValue = null;
                        textEditPrecio1.Text = string.Empty;
                        textEditPrecio2.Text = string.Empty;
                        textEditPrecio3.Text = string.Empty;
                        textEditPrecio4.Text = string.Empty;
                        textEditPrecio5.Text = string.Empty;
                        textEditPrecio6.Text = string.Empty;
                        textEditPrecio7.Text = string.Empty;
                        textEditPrecio8.Text = string.Empty;
                        textEditPrecio9.Text = string.Empty;
                        textEditPrecio10.Text = string.Empty;
                        textEditPrecio11.Text = string.Empty;
                        txt_precio_docena_producto.Text = string.Empty;
                        txt_precio_bulto_producto.Text = string.Empty;
                        txt_costo_Producto.Text = string.Empty;
                        textEditImpuesto.Text = string.Empty;
                        textEditDescuento.Text = string.Empty;
                        textEditCosto.Text = string.Empty;
                        textEditUtilidad.Text = string.Empty;
                        if(vTemp == 0) textEditStock.Text = "0";
                        check_es_servicio.ReadOnly = true;
                        check_deshabilitar.ReadOnly = true;
                        //textEditStock.Text = string.Empty;
                        textEditStockMinimo.Text = string.Empty;
                        pictureEditProducto.EditValue = Presentacion.Properties.Resources.default_image_450;
                        break;

                    case 4: //habilitar controles
                        textEditCodigo.Enabled = true;
                        textEditDescripcion.Enabled = true;
                        lookUpEditCategoria.Enabled = true;
                        lookUpEditMarca.Enabled = true;
                        lookUpEditLinea.Enabled = true;
                        lookUpEditUnidadMedida.Enabled = true;
                        lookUpEditMoneda.Enabled = true;
                        textEditPrecio1.Enabled = true;
                        textEditPrecio2.Enabled = true;
                        textEditPrecio3.Enabled = true;
                        textEditPrecio4.Enabled = true;
                        textEditPrecio5.Enabled = true;
                        textEditPrecio6.Enabled = true;
                        textEditPrecio7.Enabled = true;
                        textEditPrecio8.Enabled = true;
                        textEditPrecio9.Enabled = true;
                        textEditPrecio10.Enabled = true;
                        textEditPrecio11.Enabled = true;
                        txt_precio_docena_producto.Enabled = true;
                        txt_precio_bulto_producto.Enabled = true;
                        txt_costo_Producto.Enabled = true;
                        textEditImpuesto.Enabled = true;
                        textEditDescuento.Enabled = true;
                        textEditCosto.Enabled = true;
                        textEditUtilidad.Enabled = false;
                        textEditStockMinimo.Enabled = true;
                        check_es_servicio.ReadOnly = false;
                        check_deshabilitar.ReadOnly = false;
                        //if (vTemp == 0) textEditStock.Enabled = true;
                        pictureEditProducto.ReadOnly = false;
                        break;

                    case 5: //deshabilitar controles
                        textEditCodigo.Enabled = false;
                        textEditDescripcion.Enabled = false;
                        lookUpEditCategoria.Enabled = false;
                        lookUpEditMarca.Enabled = false;
                        lookUpEditLinea.Enabled = false;
                        lookUpEditUnidadMedida.Enabled = false;
                        lookUpEditMoneda.Enabled = false;
                        textEditPrecio1.Enabled = false;
                        textEditPrecio2.Enabled = false;
                        textEditPrecio3.Enabled = false;
                        textEditPrecio4.Enabled = false;
                        textEditPrecio5.Enabled = false;
                        textEditPrecio6.Enabled = false;
                        textEditPrecio7.Enabled = false;
                        textEditPrecio8.Enabled = false;
                        textEditPrecio9.Enabled = false;
                        textEditPrecio10.Enabled = false;
                        textEditPrecio11.Enabled = false;
                        txt_precio_docena_producto.Enabled = false;
                        txt_precio_bulto_producto.Enabled = false;
                        txt_costo_Producto.Enabled = false;
                        textEditImpuesto.Enabled = false;
                        textEditDescuento.Enabled = false;
                        textEditCosto.Enabled = false;
                        textEditUtilidad.Enabled = false;
                        textEditStock.Enabled = false;
                        textEditStockMinimo.Enabled = false;
                        pictureEditProducto.ReadOnly = false;
                        check_es_servicio.ReadOnly = true;
                        check_deshabilitar.ReadOnly = true;
                        //textEditPrecio5.ReadOnly = false;
                        //textEditPrecio6.ReadOnly = false;
                        //textEditPrecio7.ReadOnly = false;
                        //textEditPrecio8.ReadOnly = false;
                        break;
                }
            }
            else if(XtraTabControlCatalogos.SelectedTabPage == tabEmpleado)
            {
                switch(i)
                {
                    case 1:
                        if(viewEmpleado.RowCount > 0)
                        {
                            blbiNuevo.Enabled = true;
                            blbiGuardar.Enabled = false;
                            blbiEditar.Enabled = true;
                            blbiCancelar.Enabled = false;

                        }
                        else
                        {
                            blbiNuevo.Enabled = true;
                            blbiGuardar.Enabled = false;
                            blbiEditar.Enabled = false;
                            blbiCancelar.Enabled = false;
                        }
                        break;

                    case 2: //Cuando presionamos el boton nuevo
                        blbiNuevo.Enabled = false;
                        blbiGuardar.Enabled = true;
                        blbiEditar.Enabled = false;
                        blbiCancelar.Enabled = true;
                        break;

                    case 3: // limpiar controles
                        textEditEmpleadoNombre.Text = string.Empty;
                        textEditEmpleadoCedula.Text = string.Empty;
                        textEditEmpleadoCargo.Text = string.Empty;
                        textEditEmpleadoUsuario.Text = string.Empty;
                        textEditEmpleadoClave.Text = string.Empty;
                        textEditEmpleadoCelular.Text = string.Empty;
                        textEditEmpleadoCorreo.Text = string.Empty;
                        txtCodigoEmpleado.Text = string.Empty;
                        textEditEmpleadoDireccion.Text = string.Empty;
                        pictureEditEmpleadoFoto.EditValue = null;
                        break;

                    case 4: //habilitar controles
                        textEditEmpleadoNombre.Enabled = true;
                        textEditEmpleadoCedula.Enabled = true;
                        textEditEmpleadoCargo.Enabled = true;
                        textEditEmpleadoUsuario.Enabled = true;
                        textEditEmpleadoClave.Enabled = true;
                        textEditEmpleadoCelular.Enabled = true;
                        textEditEmpleadoCorreo.Enabled = true;
                        txtCodigoEmpleado.Enabled = true;
                        textEditEmpleadoDireccion.Enabled = true;
                        lblOjo.Enabled = true;
                        pictureEditEmpleadoFoto.ReadOnly = false;
                        break;

                    case 5: //deshabilitar controles
                        textEditEmpleadoNombre.Enabled = false;
                        textEditEmpleadoCedula.Enabled = false;
                        textEditEmpleadoCargo.Enabled = false;
                        textEditEmpleadoUsuario.Enabled = false;
                        textEditEmpleadoClave.Enabled = false;
                        textEditEmpleadoCelular.Enabled = false;
                        textEditEmpleadoCorreo.Enabled = false;
                        txtCodigoEmpleado.Enabled = false;
                        textEditEmpleadoDireccion.Enabled = false;
                        lblOjo.Enabled = false;
                        pictureEditEmpleadoFoto.ReadOnly = true;
                        guardar_empleado = false;
                        limpiar_controles_huella();
                        break;
                }
            }
        }

        private void blbiNuevo_ItemClick(object sender,DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(XtraTabControlCatalogos.SelectedTabPage == tabProductos)
            {
                vTemp = 0;
                HabilitarDeshabilitarControles(2);
                HabilitarDeshabilitarControles(3);
                HabilitarDeshabilitarControles(4);
                radialMenuProducto.HidePopup();
                textEditCodigo.Focus();
                usuario_nuevo = false;
                bbiEtiquetas.Enabled = false;
                bbi_editar_productos.Enabled = false;
                bbi_Nuevo_Productos.Enabled = false;

           //     layoutControlGroup3.Expanded = true;
            }
            else if(XtraTabControlCatalogos.SelectedTabPage == tabEmpleado)
            {
                usuario_nuevo = true;
                vTemp = 0;
                HabilitarDeshabilitarControles(2);
                HabilitarDeshabilitarControles(3);
                HabilitarDeshabilitarControles(4);
                radialMenuProducto.HidePopup();
                textEditEmpleadoNombre.Focus();
                guardar_empleado = true;
                if(conectado == true)
                {
                    Iniciar_Controles_Huella();
                    btn_iniciar_captura.Enabled = true;
                }
                else
                    btn_iniciar_captura.Enabled = false;
            }
        }

        private void pictureEditProducto_EditValueChanged(object sender,EventArgs e)
        {
            if(pictureEditProducto.EditValue == null) { pictureEditProducto.EditValue = Properties.Resources.default_image_450; }
        }

        private void xfrm_Catalogos_Leave(object sender,EventArgs e)
        {
            if(iniciado)
                PararCaptura();
        }

        private void xfrm_Catalogos_FormClosed(object sender,FormClosedEventArgs e)
        {
            if(iniciado)
                PararCaptura();
        }
        private void bbi_etiqueta_ItemClick(object sender,DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vIdProducto = Convert.ToInt32(viewProductos.GetFocusedRowCellValue("id"));
            BindingSource sor = new BindingSource();
            sor.DataSource = Negocio.ClasesCN.CatalogosCN.Producto_Cargar_Fila(vIdProducto).ToList();
            var report = new Reportes.Inventario.EtiquetaProducto(sor);
            report.ShowPreview();

        }
        private void blbiEditar_ItemClick(object sender,DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(XtraTabControlCatalogos.SelectedTabPage == tabProductos)
            {
                vTemp = 1;
                vIdProducto = Convert.ToInt32(viewProductos.GetFocusedRowCellValue("id"));
                HabilitarDeshabilitarControles(2);
                HabilitarDeshabilitarControles(4);
                radialMenuProducto.HidePopup();
                textEditDescripcion.Focus();
                bbiEtiquetas.Enabled = false;
                bbi_editar_productos.Enabled = false;
                bbi_Nuevo_Productos.Enabled = false;
                //  layoutControlGroup3.Expanded = true;
            }
            else if(XtraTabControlCatalogos.SelectedTabPage == tabEmpleado)
            {
                vTemp = 1;
                vIdEmpleado = Convert.ToInt32(viewEmpleado.GetFocusedRowCellValue("id"));
                HabilitarDeshabilitarControles(2);
                HabilitarDeshabilitarControles(4);
                radialMenuProducto.HidePopup();
                textEditEmpleadoNombre.Focus();
                int th = Convert.ToInt32(viewEmpleado.GetFocusedRowCellValue("tiene_huella"));
                if(th == 1)
                {
                    picture_huella.Image = Presentacion.Properties.Resources.Finger_Huella_Reconocida;
                    Mostrar_Mensaje("Empleado Con Huella",Color.DarkGreen);
                    guardar_empleado = false;
                }
                else
                {
                    guardar_empleado = true;
                    btn_iniciar_captura.Text = "Iniciar Captura";
                    if(conectado)
                    {
                        Mostrar_Mensaje("» ESCÁNER DE HUELLAS ACTIVO «",Color.DarkBlue);
                        picture_huella.Image = Presentacion.Properties.Resources.finger_conectado;
                        Iniciar_Controles_Huella();
                        btn_iniciar_captura.Enabled = true;
                    }
                    else
                    {
                        picture_huella.Image = Presentacion.Properties.Resources.finger_desconectado;
                        Mostrar_Mensaje("ESCÁNER DE HUELLAS NO ENCONTRADO...",Color.DarkRed);
                        btn_iniciar_captura.Enabled = false;
                    }
                }
            }
        }

        private void eXPORTAREXCELToolStripMenuItem_Click(object sender,EventArgs e)
        {
            try
            {
                if(grilla_exportar != null)
                    new Clases.Exportar().Exportar_Grid_A_Excel(grilla_exportar);
            }
            catch(Exception)
            {
                throw;
            }
        }

        private void viewCliente_FocusedRowChanged(object sender,DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {                
                looks_precio.ReadOnly = true;
                id_cliente = Convert.ToString(viewCliente.GetFocusedRowCellValue("id"));
                string vCodigo = Convert.ToString(viewCliente.GetFocusedRowCellValue("codigo") ?? "").ToUpper().Trim();
                string vRuc = Convert.ToString(viewCliente.GetFocusedRowCellValue("ruc") ?? "").ToUpper().Trim();
                string vNombre = Convert.ToString(viewCliente.GetFocusedRowCellValue("nombre") ?? "").ToUpper().Trim();
                string vDepartamento = Convert.ToString(viewCliente.GetFocusedRowCellValue("departamento") ?? "").ToUpper().Trim();
                string vTelefono = Convert.ToString(viewCliente.GetFocusedRowCellValue("telefono") ?? "").ToUpper().Trim();
                string vCelular = Convert.ToString(viewCliente.GetFocusedRowCellValue("celular") ?? "").ToUpper().Trim();
                string vDireccion = Convert.ToString(viewCliente.GetFocusedRowCellValue("direccion") ?? "").ToUpper().Trim();
                string vCorreo = Convert.ToString(viewCliente.GetFocusedRowCellValue("correo") ?? "").ToUpper().Trim();
                string vCodigoEmpleado = Convert.ToString(viewCliente.GetFocusedRowCellValue("codigo") ?? "").ToUpper().Trim();
                int vid_sector = 0;
                try { vid_sector = Convert.ToInt32(viewCliente.GetFocusedRowCellValue("id_sector")); } catch(Exception) { };
                int vPrecio = 1;
                try { vPrecio = Convert.ToInt32(viewCliente.GetFocusedRowCellValue("precio")); } catch(Exception) { vPrecio = 1; }
                string repre1 = Convert.ToString(viewCliente.GetFocusedRowCellValue(col_nombre_representantne) ?? string.Empty);
                string  repre2 = Convert.ToString(viewCliente.GetFocusedRowCellValue(col_nombre_representante2) ?? string.Empty);
                string  repre3 = Convert.ToString(viewCliente.GetFocusedRowCellValue(col_nombre_representante3) ?? string.Empty);
                string  cedula1 = Convert.ToString(viewCliente.GetFocusedRowCellValue(col_cedula_representante_1) ?? string.Empty);
                string  cedula2 = Convert.ToString(viewCliente.GetFocusedRowCellValue(col_cedula_repre2) ?? string.Empty);
                string  cedula3 = Convert.ToString(viewCliente.GetFocusedRowCellValue(col_cedula_repre3) ?? string.Empty);

                var query_cliente = Negocio.ClasesCN.CatalogosCN.Cliente_SelectFila(Convert.ToInt32(id_cliente)).FirstOrDefault();
                int idc = Convert.ToInt32(id_cliente);
                var querydatos = Negocio.ClasesCN.CatalogosCN.Cliente_Cargar().Where(x => x.id == idc).FirstOrDefault();
                var queryventa = Negocio.ClasesCN.VentasCN.Ventas_Select(1).Where(x => x.id_cliente == idc).FirstOrDefault();


                txt_codigo.Text = vCodigo;
                txt_ruc.Text = vRuc;
                txt_nombre.Text = vNombre;
                txt_Departamento.Text = vDepartamento;
                txt_Telefono.Text = vTelefono;
                txt_Celular.Text = vCelular;
                txt_direccion.Text = vDireccion;
                txt_correo.Text = vCorreo;
                looks_precio.EditValue = vPrecio.ToString();
                txt_nombre_repre1.EditValue = repre1;
                txt_nombre_repre2.EditValue = repre2;
                txt_nombre_repre3.EditValue = repre3;
                txt_cedula_repre1.EditValue = cedula1;
                txt_cedula_repre2.EditValue = cedula2;
                txt_cedula_repre3.EditValue = cedula3;
                bbi_guardar.Enabled = false;
                txt_registro.Text = Convert.ToString(querydatos.fecha_registro.ToShortDateString());
                textEdit_ultimaventa.Text = Convert.ToString(queryventa.fecha.ToShortDateString());

                pictureEditCliente_documento.EditValue = query_cliente.imagen_documento;
                pictureEditCliente_documento.ReadOnly = true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                //throw;
            }
        }

        private void bbi_guardar_ItemClick(object sender,DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                // Otencion de datos desde los campos
                string vId = /*id_cliente_editar;*/ id_cliente == 0.ToString()?0.ToString():Convert.ToString(viewCliente.GetFocusedRowCellValue("id"));
                string vCodigo = txt_codigo.Text.Trim();
                string vRuc = txt_ruc.Text.Trim();
                string vNombre =txt_nombre.Text.Trim();
                string vDepartamento = txt_Departamento.Text.Trim();
                string vTelefono = txt_Telefono.Text.Trim();
                string vCelular =txt_Celular.Text.Trim();
                string vDireccion =txt_direccion.Text.Trim();
                string vCorreo = txt_correo.Text.Trim();
                int vid_sector = 0;
                try { vid_sector = Convert.ToInt32(viewCliente.GetFocusedRowCellValue("id_sector")); } catch(Exception) { };
                int vPrecio = 1;
                try { vPrecio = Convert.ToInt16(looks_precio.EditValue); } catch(Exception) { vPrecio = 3; }
                string  repre_1 =txt_nombre_repre1.Text.Trim().ToUpper();
                string  repre_2 =txt_nombre_repre2.Text.Trim().ToUpper();
                string  repre_3 = txt_nombre_repre3.Text.Trim().ToUpper();
                string  cedula_1 = txt_cedula_repre1.Text.Trim().ToUpper();
                string  cedula_2 = txt_cedula_repre2.Text.Trim().ToUpper();
                string  cedula_3 = txt_cedula_repre3.Text.Trim().ToUpper();
                bool esMercado = Convert.ToBoolean(ck_esMercado.EditValue);

                // Obtener imagen de documento
                byte[] vImagen_Cliente_documento;
                MemoryStream ms = new MemoryStream();

                try
                {
                    pictureEditCliente_documento.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                }catch{ vImagen_Cliente_documento = null; }

                vImagen_Cliente_documento = ms.ToArray();
                ms.Close();


                if (!string.IsNullOrEmpty(vNombre.Trim().Replace(" ","")) && looks_precio.EditValue.ToString() != 0.ToString() && !string.IsNullOrEmpty(vCelular.Trim().Replace(" ", "")) && !string.IsNullOrEmpty(vRuc.Trim().Replace(" ", "")))
                {
                    if(vId == "0")
                    {
                        //nuevo

                        foreach(var list in Negocio.ClasesCN.CatalogosCN.Cliente_Cargar())
                        {
                            if((vNombre.ToUpper() == list.nombre.Trim()) || vCodigo == list.codigo)
                            {
                                XtraMessageBox.Show("Lo sentimos, este registro ya existe; O si desea actualizar el registro vuelva relizar el procedimiento correctamente","Clientes",MessageBoxButtons.OK,MessageBoxIcon.Error);
                                if (tabClientes.Text == "Listado de Clientes Publicidad".ToUpper())
                                {
                                    CargarClientes();
                                }
                                else
                                {
                                    CargarClientesMercado();
                                }
                                viewCliente.MoveFirst();
                                return;
                            }
                        }

                        int okGuardar = Negocio.ClasesCN.CatalogosCN.Cliente_Guardar(vCodigo, vRuc, vNombre, vTelefono, vCelular, vDireccion, vCorreo, vid_sector, vPrecio, repre_1, repre_2, repre_3, cedula_1, cedula_2, cedula_3, Clases.UsuarioLogueado.vID_Empleado, vImagen_Cliente_documento, vDepartamento, esMercado);
                        if(okGuardar > 0)
                        {
                            XtraMessageBox.Show("Registro guardado satisfactoriamente","Clientes",MessageBoxButtons.OK,MessageBoxIcon.Information);
                            if(tabClientes.Text == "Listado de Clientes Publicidad".ToUpper())
                            {
                                CargarClientes();
                            }
                            else
                            {
                                CargarClientesMercado();
                            }
                            viewCliente.MoveFirst();
                            editar.Checked = true;
                            looks_precio.ReadOnly = true;
                        }
                        else
                        {
                            XtraMessageBox.Show("Lo sentimos, no se pudo guardar los datos, verifique la información","Clientes",MessageBoxButtons.OK,MessageBoxIcon.Error);
                            if (tabClientes.Text == "Listado de Clientes Publicidad".ToUpper())
                            {
                                CargarClientes();
                            }
                            else
                            {
                                CargarClientesMercado();
                            }
                            viewCliente.MoveFirst();
                        }
                    }
                    else
                    {
                        //actualizar
                        if(vId == 1.ToString() || vId == 4072.ToString())
                        {
                            XtraMessageBox.Show("Lo sentimos, No esta Permitido editar el cliente contado o el Cliente Eventual","Clientes",MessageBoxButtons.OK,MessageBoxIcon.Error);
                            if (tabClientes.Text == "Listado de Clientes Publicidad".ToUpper())
                            {
                                CargarClientes();
                            }
                            else
                            {
                                CargarClientesMercado();
                            }
                            viewCliente.MoveFirst();
                            return;
                        }

                        foreach(var list in Negocio.ClasesCN.CatalogosCN.Cliente_Cargar().Where(x => x.id != int.Parse(vId)))
                        {
                            if((vNombre == list.nombre.Trim()) || vCodigo == list.codigo || vId == list.id.ToString())
                            {
                                XtraMessageBox.Show("Lo sentimos, este registro ya existe","Clientes",MessageBoxButtons.OK,MessageBoxIcon.Error);
                                if (tabClientes.Text == "Listado de Clientes Publicidad".ToUpper())
                                {
                                    CargarClientes();
                                }
                                else
                                {
                                    CargarClientesMercado();
                                }
                                viewCliente.MoveFirst();
                                return;
                            }
                        }

                        int okEditar = Negocio.ClasesCN.CatalogosCN.Cliente_Actualizar(int.Parse(vId), vCodigo, vRuc, vNombre, vTelefono, vCelular, vDireccion, vCorreo, vid_sector, vPrecio, Clases.UsuarioLogueado.vID_Empleado, 0, 0, 0, 0, 0, repre_1, repre_2, repre_3, cedula_1, cedula_2, cedula_3, vImagen_Cliente_documento, vDepartamento, esMercado);
                        if(okEditar > 0)
                        {
                            XtraMessageBox.Show("Datos modificados satisfactoriamente","Clientes",MessageBoxButtons.OK,MessageBoxIcon.Information);
                            if (tabClientes.Text == "Listado de Clientes Publicidad".ToUpper())
                            {
                                CargarClientes();
                            }
                            else
                            {
                                CargarClientesMercado();
                            }
                            viewCliente.MoveNext();
                            editar.Checked = true;
                            looks_precio.ReadOnly = true;
                        }
                        else
                        {
                            XtraMessageBox.Show("Lo sentimos, no se pudo modificar los datos, verifique la información","Clientes",MessageBoxButtons.OK,MessageBoxIcon.Error);
                            if (tabClientes.Text == "Listado de Clientes Publicidad".ToUpper())
                            {
                                CargarClientes();
                            }
                            else
                            {
                                CargarClientesMercado();
                            }
                            viewCliente.MoveNext();
                        }
                    }
                }
                else
                {
                    XtraMessageBox.Show("Lo sentimos, no puede dejar el campo de Empresa, Precio, Celular o RUC vacio, verifique esos campos e intente nuevamente","Mensaje",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    if (txt_Celular.Text == string.Empty)
                        txt_Celular.Focus();
                    if (txt_ruc.Text == string.Empty)
                        txt_ruc.Focus();
                    //CargarClientes();
                    //viewCliente.MoveFirst();
                }
              
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show("Error, Comunicarse con soporte técnico: " +ex, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void bbi_nuevo_cliente_ItemClick(object sender,DevExpress.XtraBars.ItemClickEventArgs e)
        {
                id_cliente = 0.ToString();
                txt_codigo.Text = string.Empty;
                txt_nombre.Text = string.Empty;
                txt_Celular.Text = string.Empty;
                txt_direccion.Text = string.Empty;
                txt_Celular.Text = String.Empty;
                txt_Telefono.Text = string.Empty;
                txt_Departamento.Text = string.Empty;
                txt_ruc.Text = string.Empty;
                txt_correo.Text = string.Empty;
                looks_precio.EditValue = (0).ToString();
                txt_nombre_repre1.EditValue = string.Empty;
                txt_nombre_repre2.EditValue = string.Empty;
                txt_nombre_repre3.EditValue = string.Empty;
                txt_cedula_repre1.EditValue = string.Empty;
                txt_cedula_repre2.EditValue = string.Empty;
                txt_cedula_repre3.EditValue = string.Empty;
                looks_precio.ReadOnly = false;
                editar.Checked = false;
                txt_codigo.ReadOnly = true;
                bbi_nuevo_cliente.Enabled = true;
                bbi_guardar.Enabled = true;
                pictureEditCliente_documento.EditValue = Properties.Resources.default_image_450;
                pictureEditCliente_documento.ReadOnly = false;
                ck_esMercado.EditValue = false;
                txt_nombre.Focus();
        }

        void LimpiarDatosClientes()
        {
            viewCliente.ClearColumnsFilter();
            id_cliente = 0.ToString();
            txt_registro.Text = string.Empty;
            textEdit_ultimaventa.Text = string.Empty;
            txt_codigo.Text = string.Empty;
            txt_nombre.Text = string.Empty;
            txt_Celular.Text = string.Empty;
            txt_direccion.Text = string.Empty;
            txt_Celular.Text = String.Empty;
            txt_Telefono.Text = string.Empty;
            txt_Departamento.Text = string.Empty;
            txt_ruc.Text = string.Empty;
            txt_correo.Text = string.Empty;
            looks_precio.EditValue = (0).ToString();
            txt_nombre_repre1.EditValue = string.Empty;
            txt_nombre_repre2.EditValue = string.Empty;
            txt_nombre_repre3.EditValue = string.Empty;
            txt_cedula_repre1.EditValue = string.Empty;
            txt_cedula_repre2.EditValue = string.Empty;
            txt_cedula_repre3.EditValue = string.Empty;
            pictureEditCliente_documento.EditValue = Properties.Resources.default_image_450;
        }

        private void looks_precio_Click(object sender,EventArgs e)
        {
            if(id_cliente != 0.ToString() && looks_precio.ReadOnly &&  viewCliente.IsDataRow(viewCliente.FocusedRowHandle))
            {
                string vId = id_cliente==0.ToString()?0.ToString():viewCliente.GetFocusedRowCellValue("id").ToString();
                string vCodigo =Convert.ToString(viewCliente.GetFocusedRowCellValue("codigo") ?? "").ToUpper().Trim();
                string vRuc = txt_ruc.Text.Trim();
                string vNombre =txt_nombre.Text.Trim();
                string vTelefono = txt_Telefono.Text.Trim();
                string vDepartamento = txt_Departamento.Text.Trim();
                bool esMercado = Convert.ToBoolean(ck_esMercado.EditValue);
                string vCelular =txt_Celular.Text.Trim();
                string vDireccion =txt_direccion.Text.Trim();
                string vCorreo = txt_correo.Text.Trim();
                int vid_sector = 0;
                try { vid_sector = Convert.ToInt32(viewCliente.GetFocusedRowCellValue("id_sector")); } catch(Exception) { };
                int vPrecio = 1;
                try { vPrecio = Convert.ToInt16(looks_precio.EditValue); } catch(Exception) { vPrecio = 3; }
                string  repre_1 =txt_nombre_repre1.Text.Trim().ToUpper();
                string  repre_2 =txt_nombre_repre2.Text.Trim().ToUpper();
                string  repre_3 = txt_nombre_repre3.Text.Trim().ToUpper();
                string  cedula_1 = txt_cedula_repre1.Text.Trim().ToUpper();
                string  cedula_2 = txt_cedula_repre2.Text.Trim().ToUpper();
                string  cedula_3 = txt_cedula_repre3.Text.Trim().ToUpper();
                if(vId == 1.ToString() || vId == 4072.ToString())
                {
                    XtraMessageBox.Show("Lo sentimos, No esta Permitido editar el cliente contado o el Cliente Eventual","Clientes",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    CargarClientes();
                    return;

                }
               var FAutorizacion= new  xfrm_autorizacion("CAMBIO DE PRECIOS DE CLIENTE"+ vNombre);
                FAutorizacion.numero_permiso = 101;
                FAutorizacion.permiso = "CAMBIO DE PRECIOS DE CLIENTES";
                FAutorizacion.ShowDialog();



                if(FAutorizacion.Autorizado)
                {

                    looks_precio.ReadOnly = false;
                    //if(XtraMessageBox.Show("¿Desea modificar el registro?","Clientes",MessageBoxButtons.YesNo,MessageBoxIcon.Question) != DialogResult.Yes) { CargarClientes(); return; }
                    //int okEditar = Negocio.ClasesCN.CatalogosCN.Cliente_Actualizar(int.Parse(vId), vCodigo, vRuc, vNombre, vTelefono, vCelular, vDireccion, vCorreo, vid_sector, vPrecio, Clases.UsuarioLogueado.vID_Empleado,0,0,0,0,FAutorizacion.Id_autorizador(),repre_1,repre_2,repre_3,cedula_1,cedula_2,cedula_3);
                    //if(okEditar > 0)
                    //{
                    //    XtraMessageBox.Show("Datos modificados satisfactoriamente","Clientes",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    //    CargarClientes();
                    //    viewCliente_FocusedRowChanged(null,null);
                    //    //  viewCliente.MoveNext();
                    //}
                    //else
                    //{
                    //    XtraMessageBox.Show("Lo sentimos, no se pudo modificar los datos, verifique la información","Clientes",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    //    CargarClientes();
                    //    viewCliente_FocusedRowChanged(null,null);
                    //    //viewCliente.MoveNext();
                    //}
                }
                else
                {
                    CargarClientes();
                    looks_precio.ReadOnly = true;
                    XtraMessageBox.Show("La acción de " + FAutorizacion.permiso + " no fue autorizada","Mensaje",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    viewCliente.MoveNext();
                    viewCliente_FocusedRowChanged(null,null);
                }
            }
        }

        string id_cliente_editar = string.Empty;
        private void editar_CheckedChanged(object sender,EventArgs e)
        {
            id_cliente_editar = Convert.ToString(viewCliente.GetFocusedRowCellValue("id"));

            if(editar.Checked== false)
                bbi_guardar.Enabled = true;
            else
                bbi_guardar.Enabled = false;

            txt_codigo.ReadOnly = true;

            txt_nombre.ReadOnly =
            txt_Celular.ReadOnly =
            txt_direccion.ReadOnly = 
            txt_Celular.ReadOnly=
            txt_Telefono.ReadOnly=
            txt_Departamento.ReadOnly =
            txt_ruc.ReadOnly = 
            txt_correo.ReadOnly =
            txt_nombre_repre1.ReadOnly = 
            txt_nombre_repre2.ReadOnly = 
            txt_nombre_repre3.ReadOnly = 
            txt_cedula_repre1.ReadOnly = 
            txt_cedula_repre2.ReadOnly = 
            txt_cedula_repre3.ReadOnly = 
            pictureEditCliente_documento.ReadOnly = 
            ck_esMercado.ReadOnly = editar.Checked;

        }

        private void bbi_refrescar_ItemClick(object sender,DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Mostrar_Pagina(1);
        }

        private void bbi_eliminar_ItemClick(object sender,DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string vId = id_cliente==0.ToString()?0.ToString():viewCliente.GetFocusedRowCellValue("id").ToString();
            if(vId == 0.ToString())
            {
                XtraMessageBox.Show("Debe de haber un cliente a eliminar","Error");
            }
            else
            {
                if(vId == 1.ToString() || vId == 4072.ToString())
                {
                    XtraMessageBox.Show("Lo sentimos, No esta Permitido Eliminar el cliente contado o el Cliente Eventual","Clientes",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    CargarClientes();
                    viewCliente.MoveFirst();
                    return;
                }
                else
                {
                    DialogResult pregunta= new DialogResult();
                    pregunta = XtraMessageBox.Show($"Esta completamente seguro de eliminar el cliente {txt_nombre.EditValue.ToString()}?","Confirmación",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                    if(pregunta == DialogResult.Yes)
                    {
                        int valor =Negocio.ClasesCN.CatalogosCN.Cliente_Eliminar(Convert.ToInt32(vId),Clases.UsuarioLogueado.vID_Empleado);
                        if(valor > 0)
                        {
                            XtraMessageBox.Show("Cliente eliminado exitosamente","Información",MessageBoxButtons.OK,MessageBoxIcon.Information);
                            Mostrar_Pagina(1);
                        }
                    }
                }
            }
        }

        private void bbi_eliminar_empleado_ItemClick(object sender,DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
               vIdEmpleado = Convert.ToInt32(viewEmpleado.GetFocusedRowCellValue("id"));
                if(vIdEmpleado > 0)
                {
                    DialogResult Pregunta = new DialogResult();
                    Pregunta = XtraMessageBox.Show($"¿Esta completamente seguro de eliminar al empleado {textEditEmpleadoNombre.Text.ToUpper()}?","Confirmación",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                    if(Pregunta == DialogResult.Yes)
                    {
                        int Valor = Negocio.ClasesCN.CatalogosCN.Empleado_Eliminar(vIdEmpleado,Clases.UsuarioLogueado.vID_Empleado);
                        if(Valor > 0)

                        {
                            XtraMessageBox.Show("Empleado eliminado exitosamente","Mensaje del sistema",MessageBoxButtons.OK,MessageBoxIcon.Information);
                            Mostrar_Pagina(8);
                        }
                    }
                }
            }
            catch(Exception)
            {
                throw;
            }
        }

        private void bbi_editar_subgrupos_ItemClick(object sender,DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(Convert.ToBoolean(ck_BloquearEdicionSG.EditValue))
            {
                txt_nombre_subgrupo.ReadOnly = txtDescripcion_subgrupo.ReadOnly = look_grupo_de_subgrupo.ReadOnly = lookUpEdit_Moneda_Subgrupos.ReadOnly = txt_codigo_subgrupo.ReadOnly = txt_precio_mayor.ReadOnly = txt_precio_4.ReadOnly = txt_precio_detalle.ReadOnly = txt_precio_Eventual.ReadOnly = txtprecio_5.ReadOnly = txtprecio_6.ReadOnly = txtprecio_7.ReadOnly = txtprecio_8.ReadOnly = txtprecio_9.ReadOnly = txtprecio_10.ReadOnly = txtprecio_11.ReadOnly = txt_costo.ReadOnly = txt_precio_docena.ReadOnly = txt_precio_bulto.ReadOnly = true;
                ck_BloquearEdicionSG.ReadOnly = false;
            }
            else
            {
                txt_nombre_subgrupo.ReadOnly = txtDescripcion_subgrupo.ReadOnly = look_grupo_de_subgrupo.ReadOnly = lookUpEdit_Moneda_Subgrupos.ReadOnly = txt_codigo_subgrupo.ReadOnly = txt_precio_mayor.ReadOnly = txt_precio_4.ReadOnly = txt_precio_detalle.ReadOnly = txt_precio_Eventual.ReadOnly = txtprecio_5.ReadOnly = txtprecio_6.ReadOnly = txtprecio_7.ReadOnly = txtprecio_8.ReadOnly = txtprecio_9.ReadOnly = txtprecio_10.ReadOnly = txtprecio_11.ReadOnly = txt_costo.ReadOnly = ck_BloquearEdicionSG.ReadOnly = txt_precio_docena.ReadOnly = txt_precio_bulto.ReadOnly = false;
            }

            bbi_nuevo_subgrupo.Enabled = false;
            bbi_exportar_subgrupop.Enabled = false;
            bbi_refrescar_subgrupo.Enabled = false;
            txt_nombre_subgrupo.Focus();
            txt_codigo_subgrupo.Enabled = true;
        }

        private void bbi_Cancelar_subgrupo_ItemClick(object sender,DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Mostrar_Pagina(7);
            txt_nombre_subgrupo.ReadOnly = txtDescripcion_subgrupo.ReadOnly = look_grupo_de_subgrupo.ReadOnly = lookUpEdit_Moneda_Subgrupos .ReadOnly = txt_codigo_subgrupo.ReadOnly = txt_precio_mayor.ReadOnly = txt_precio_4.ReadOnly = txt_precio_detalle.ReadOnly = txt_precio_Eventual.ReadOnly = txtprecio_5.ReadOnly = txtprecio_6.ReadOnly = txtprecio_7.ReadOnly = txtprecio_8.ReadOnly = txtprecio_9.ReadOnly = txtprecio_10.ReadOnly = txtprecio_11.ReadOnly = txt_costo.ReadOnly = ck_BloquearEdicionSG.ReadOnly = txt_precio_docena.ReadOnly = txt_precio_bulto.ReadOnly = true;
            bbi_nuevo_subgrupo.Enabled = true;
            bbi_exportar_subgrupop.Enabled = true;
            bbi_refrescar_subgrupo.Enabled = true;
            bbi_editar_subgrupos.Enabled = true;
        }

        private void blbiGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XtraTabControlCatalogos.SelectedTabPage == tabProductos)
            {
                bbi_Nuevo_Productos.Enabled = true;
                bbi_editar_productos.Enabled = true;
                bbiEtiquetas.Enabled = true;
                try
                {
                    textEditCodigo_Leave(null, null);
                    if(ValidarCamposProducto())
                    {
                        string vCodigo = textEditCodigo.Text.Trim();
                        string vDescripcion = textEditDescripcion.Text.Trim();
                        int vIdCategoria = Convert.ToInt32(lookUpEditCategoria.EditValue);
                        int vIdMarca = Convert.ToInt32(lookUpEditMarca.EditValue);
                        int vIdLinea = Convert.ToInt32(lookUpEditLinea.EditValue);
                        int vUnidadMedida = Convert.ToInt32(lookUpEditUnidadMedida.EditValue);
                        decimal vStock = 0.00M;//Convert.ToInt32(textEditStock.Text);
                        decimal vStockMinimo = Convert.ToDecimal(textEditStockMinimo.Text);
                        int vMoneda = Convert.ToInt32(lookUpEditMoneda.EditValue);
                        decimal vPrecio1 = Convert.ToDecimal(textEditPrecio1.Text);
                        decimal vPrecio2 = Convert.ToDecimal(string.IsNullOrEmpty(textEditPrecio2.Text) ? "0.00" : textEditPrecio2.Text);
                        decimal vPrecio3 = Convert.ToDecimal(string.IsNullOrEmpty(textEditPrecio3.Text) ? "0.00" : textEditPrecio3.Text);
                        decimal vPrecio4 = Convert.ToDecimal(string.IsNullOrEmpty(textEditPrecio4.Text) ? "0.00" : textEditPrecio4.Text);
                        decimal vPrecio5 = Convert.ToDecimal(string.IsNullOrEmpty(textEditPrecio5.Text) ? "0.00" : textEditPrecio5.Text);
                        decimal vPrecio6 = Convert.ToDecimal(string.IsNullOrEmpty(textEditPrecio6.Text) ? "0.00" : textEditPrecio6.Text);
                        decimal vPrecio7 = Convert.ToDecimal(string.IsNullOrEmpty(textEditPrecio7.Text) ? "0.00" : textEditPrecio7.Text);
                        decimal vPrecio8 = Convert.ToDecimal(string.IsNullOrEmpty(textEditPrecio8.Text) ? "0.00" : textEditPrecio8.Text);
                        decimal vPrecio9 = Convert.ToDecimal(string.IsNullOrEmpty(textEditPrecio9.Text) ? "0.00" : textEditPrecio9.Text);
                        decimal vPrecio10 = Convert.ToDecimal(string.IsNullOrEmpty(textEditPrecio10.Text) ? "0.00" : textEditPrecio10.Text);
                        decimal vPrecio11 = Convert.ToDecimal(string.IsNullOrEmpty(textEditPrecio11.Text) ? "0.00" : textEditPrecio11.Text);
                        decimal vPrecio12 = Convert.ToDecimal(string.IsNullOrEmpty(txt_precio_docena_producto.Text) ? "0.00" : txt_precio_docena_producto.Text);
                        decimal vPrecio13 = Convert.ToDecimal(string.IsNullOrEmpty(txt_precio_bulto_producto.Text) ? "0.00" : txt_precio_bulto_producto.Text);
                        decimal vDescuento = 0.00M;// Convert.ToDecimal(string.IsNullOrEmpty(textEditDescuento.Text) ? "0.00" : textEditDescuento.Text);
                        decimal vImpuesto = 0.00M;//Convert.ToDecimal(string.IsNullOrEmpty(textEditImpuesto.Text) ? "0.00" : textEditImpuesto.Text);
                        decimal vCosto = Convert.ToDecimal(string.IsNullOrEmpty(txt_costo_Producto.Text) ? "0.00" : txt_costo_Producto.Text);
                        //vCosto = 0.00M;//vCosto>0.00M?vCosto:1;
                        decimal vUtilidad =0.00M;// (vPrecio1 / vCosto) * 100.00M;
                        string vNumeroSerie = "";
                        bool tipo_producto = Convert.ToBoolean(check_es_servicio.Checked);
                        bool habilitado = Convert.ToBoolean(check_deshabilitar.Checked);
                        MemoryStream ms = new MemoryStream();
                        try
                        {
                            pictureEditProducto.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                        }
                        catch { }
                        byte[] vImagen = ms.ToArray();
                        ms.Close();

                        if (vTemp == 0) // Nuevo
                        {
                            int okGuardar = Negocio.ClasesCN.CatalogosCN.Producto_Guardar(vCodigo, vDescripcion, vIdCategoria, vIdMarca, vIdLinea, vUnidadMedida, vMoneda, vCosto, vUtilidad, vPrecio1, vPrecio2, vPrecio3, vPrecio4, vPrecio5, vPrecio6, vPrecio7, vPrecio8, vPrecio9, vPrecio10, vPrecio11, vPrecio12, vPrecio13,vDescuento, vImpuesto, vStock, vStockMinimo, vImagen, vNumeroSerie, tipo_producto, habilitado);
                            if (okGuardar > 0)
                            {
                                XtraMessageBox.Show("Datos guardados correctamente", "Producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CargarProductos();
                                viewProductos.MoveFirst();
                            }
                            else
                            {
                                XtraMessageBox.Show("Lo sentimos, no se pudo guardar los datos, verifique la información e intentelo nuevamente", "Producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CargarProductos();
                                viewProductos.MoveFirst();
                            }
                        }
                        else if (vTemp == 1) // Editar
                        {
                            int okEditar = Negocio.ClasesCN.CatalogosCN.Producto_Actualizar(vIdProducto, vCodigo, vDescripcion, vIdCategoria, vIdMarca, vIdLinea, vUnidadMedida, vMoneda, vCosto, vUtilidad, vPrecio1, vPrecio2, vPrecio3, vPrecio4, vPrecio5, vPrecio6, vPrecio7, vPrecio8, vPrecio9, vPrecio10, vPrecio11, vPrecio12, vPrecio13,vDescuento, vImpuesto, vStockMinimo, vImagen, vNumeroSerie, Clases.UsuarioLogueado.vID_Empleado, tipo_producto, habilitado);
                            if (okEditar > 0)
                            {
                                XtraMessageBox.Show("Datos editados correctamente", "Producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CargarProductos();
                            }
                            else
                            {
                                XtraMessageBox.Show("Lo sentimos, no se pudo editar los datos, verifique la información e intentelo nuevamente", "Producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CargarProductos();
                            }
                        }
                    }
                }
                catch (Exception ex) { CargarProductos();
                    new Clases.ClaseValidacionCampos().Escribir_Error(ex);
                }
            }
            else if (XtraTabControlCatalogos.SelectedTabPage == tabEmpleado)
            {
                try
                {
                    if (ValidarCamposEmpleado())
                    {
                        dxError.ClearErrors(); dxError.Dispose();

                        string vNombre = textEditEmpleadoNombre.Text.ToUpper().Trim();
                        string vCedula = textEditEmpleadoCedula.Text.ToUpper().Trim();
                        string vCargo = textEditEmpleadoCargo.Text.ToUpper().Trim();
                        string vUsuario = textEditEmpleadoUsuario.Text.ToUpper().Trim();
                        string vClave = new ED.E_D().E(textEditEmpleadoClave.Text.Trim());
                        string vCelular = textEditEmpleadoCelular.Text.ToUpper().Trim();
                        string vCorreo = textEditEmpleadoCorreo.Text.ToUpper().Trim();
                        string vCodigo = txtCodigoEmpleado.Text.ToUpper().Trim();
                        string vCodigo_Empleado = txtCodigoEmpleado.Text.Trim();
                        string vDireccion = textEditEmpleadoDireccion.Text.ToUpper().Trim();
                        MemoryStream ms = new MemoryStream();
                        try
                        {
                            pictureEditEmpleadoFoto.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                        }
                        catch { }
                        byte[] vFoto = ms.ToArray();
                        ms.Close();

                        if (vTemp == 0)
                        {
                            foreach(var list in Negocio.ClasesCN.CatalogosCN.Empleado_Cargar())
                            {
                                if(vNombre==list.nombre || vCedula==list.cedula || vUsuario == list.usuario)
                                {
                                    dxError.SetError(textEditEmpleadoNombre, "Ya existe un registro con este nombre");
                                    dxError.SetError(textEditEmpleadoCedula, "Ya existe un registro con esta cédula");
                                    dxError.SetError(textEditEmpleadoUsuario, "Ya existe un registro con este usuario");                                    
                                    return;
                                }
                            }

                            int okGuardar = Negocio.ClasesCN.CatalogosCN.Empleado_Guardar(vNombre, vCodigo_Empleado, vCedula, vCargo, vUsuario, vClave, vCelular, vCorreo, vDireccion, vFoto);
                            if (okGuardar > 0)
                            {
                                Guardar_Huella_Digital(okGuardar);
                                limpiar_controles_huella();
                                guardar_empleado = false;
                                usuario_nuevo = false;
                                dxErrorProvider1.ClearErrors();
                                XtraMessageBox.Show("Datos guardados correctamente", "Empleado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CargarEmpleados();
                                viewEmpleado.MoveFirst();
                            }
                            else
                            {
                                XtraMessageBox.Show("Lo sentimos, no se pudo guardar los datos, verifique la información e intentelo nuevamente", "Empleado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CargarEmpleados();
                            }
                        }
                        else
                        {
                            foreach (var list in Negocio.ClasesCN.CatalogosCN.Empleado_Cargar().Where(x => x.id != vIdEmpleado))
                            {
                                if (vNombre == list.nombre || vCedula == list.cedula || vUsuario == list.usuario)
                                {
                                    dxError.SetError(textEditEmpleadoNombre, "Ya existe un registro con este nombre");
                                    dxError.SetError(textEditEmpleadoCedula, "Ya existe un registro con esta cédula");
                                    dxError.SetError(textEditEmpleadoUsuario, "Ya existe un registro con este usuario");
                                    return;
                                }
                            }

                            int okEditar = Negocio.ClasesCN.CatalogosCN.Empleado_Actualizar(vIdEmpleado, vCodigo_Empleado, vNombre, vCedula, vCargo, vUsuario, vClave, vCelular, vCorreo, vDireccion, vFoto, 0);
                            if (okEditar > 0)
                            {
                                Guardar_Huella_Digital(vIdEmpleado);
                                limpiar_controles_huella();
                                guardar_empleado = false;
                                XtraMessageBox.Show("Datos editados correctamente", "Empleado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CargarEmpleados();
                            }
                            else
                            {
                                XtraMessageBox.Show("Lo sentimos, no se pudo editar los datos, verifique la información e intentelo nuevamente", "Empleado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CargarEmpleados();
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    CargarEmpleados();
                }
            }            
        }

        private void looks_precio_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void XtraTabControlCatalogos_Click(object sender, EventArgs e)
        {

        }

        private void bbi_cambio_subgrupos_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var form = new Catalogos.xfrm_cambio_subgrupos();
                //if (ExistForm(form)) return;
                form.MdiParent = this.MdiParent;
                form.Show();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            CargarProductos();
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CargarProductos();
        }

        private void bbi_activar_desactivar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var form = new Catalogos.xfrm_productos_inactivos();
                //if (ExistForm(form)) return;
                form.MdiParent = this.MdiParent;
                form.Show();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void nbiProductosInhabilitados_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Mostrar_Pagina(15);
        }

        private void nbiLotes_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Mostrar_Pagina(16);
        }

        private void gridViewLotes_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            gridViewLotes.SetRowCellValue(e.RowHandle, "estado", 1);
        }

        private void gridViewLotes_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            try
            {
                string vId = Convert.ToString(gridViewLotes.GetFocusedRowCellValue("id_lote") ?? "0");
                string vLote = Convert.ToString(gridViewLotes.GetFocusedRowCellValue("lote_1")).ToUpper();
                string vEstado = Convert.ToString(gridViewLotes.GetFocusedRowCellValue("estado") ?? "1");

                if(!string.IsNullOrEmpty(vLote.Trim().Replace(" ", "")))
                {
                    if(vId == "0")//NUEVO
                    {
                        foreach(var list in Negocio.ClasesCN.CatalogosCN.CargarLotes())
                        {
                            if(vLote == list.lote_1.ToString() && vEstado == list.estado.ToString())
                            {
                                XtraMessageBox.Show("Lo sentimos, este registro ya existe", "Lotes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                CargarLotes();
                                gridViewLotes.MoveFirst();
                                return;
                            }
                        }
                        if (XtraMessageBox.Show("¿Desea guardar el registro?", "Lotes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) { CargarLotes(); return; }
                        int okGuardar = Negocio.ClasesCN.CatalogosCN.Lote_Guardar(vLote);
                        if(okGuardar > 0)
                        {
                            XtraMessageBox.Show("Registro guardado satisfactoriamente", "Lotes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargarLotes();
                            gridViewLotes.MoveFirst();
                        }
                        else
                        {
                            XtraMessageBox.Show("Lo sentimos, no se pudo guardar los datos, verifique la información", "Lotes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            CargarLotes();
                            gridViewLotes.MoveFirst();
                        }
                    }
                    else
                    {
                        CargarLotes();
                        gridViewLotes.MoveFirst();
                        return;
                    }
                    //else //Actualizar
                    //{
                    //    foreach (var list in Negocio.ClasesCN.CatalogosCN.CargarLotes())
                    //    {
                    //        if (vLote == list.lote_1.ToString() && vEstado == list.estado.ToString())
                    //        {
                    //            XtraMessageBox.Show("Lo sentimos, este registro ya existe", "Lotes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //            CargarLotes();
                    //            gridViewLotes.MoveFirst();
                    //            return;
                    //        }
                    //    }

                    //    if (XtraMessageBox.Show("¿Desea modificar el registro?", "Lotes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) { CargarLotes(); return; }
                    //    int okEditar = Negocio.ClasesCN.CatalogosCN.Lote_Modificar(Convert.ToInt32(vId), vLote, Convert.ToInt32(vEstado));
                    //    if (okEditar > 0)
                    //    {
                    //        XtraMessageBox.Show("Datos modificados satisfactoriamente", "Lotes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //        CargarLotes();
                    //        gridViewLotes.MoveFirst();
                    //    }
                    //    else
                    //    {
                    //        XtraMessageBox.Show("Lo sentimos, no se pudo modificar los datos, verifique la información", "Lotes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //        CargarLotes();
                    //        gridViewLotes.MoveFirst();
                    //    }
                    //}
                }
                else
                {
                    XtraMessageBox.Show("Lo sentimos, no puede dejar el nombre del Lote vacio", "Lotes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CargarLotes();
                    gridViewLotes.MoveFirst();
                }
            }
            catch
            {

            }
        }

        private void txt_costo_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void bbi_cambiarCostos_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var form = new Catalogos.xfrm_cambiar_costos();
                //if (ExistForm(form)) return;
                form.MdiParent = this.MdiParent;
                form.Show();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void nbiClienteMercadeo_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Mostrar_Pagina(17);
        }

        private void gridControl_cierre_caja_Click(object sender, EventArgs e)
        {

        }

        private void blbiCancelar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XtraTabControlCatalogos.SelectedTabPage == tabProductos)
            {
                radialMenuProducto.HidePopup();
                CargarProductos();
                bbiEtiquetas.Enabled = true;
                bbi_editar_productos.Enabled = true;
                bbi_Nuevo_Productos.Enabled = true;
                // layoutControlGroup3.Expanded = false;
            }
            else if (XtraTabControlCatalogos.SelectedTabPage == tabEmpleado)
            {
                radialMenuProducto.HidePopup();
                guardar_empleado = usuario_nuevo = false;
                dxErrorProvider1.ClearErrors();
                CargarEmpleados();
                if (conectado == true && iniciar_captura == true)
                    limpiar_controles_huella();
                if (conectado)
                    btn_iniciar_captura.Enabled = false;
            }
        }
        public void precioEspecial()
        {
            //Valido si el usuario tiene los permisos de ver el precio
            Clases.UsuarioLogueado.precioEspecial(looks_precio, null, id_empleado);
        }
        
        #endregion
        #region LOOK UP EDIT CLICK BUTTON
        private void lookUpEditCategoria_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if (e.Button.Tag.ToString() == "2")
                {
                    int count = Negocio.ClasesCN.CatalogosCN.getCategoria().Count;
                    var form = new xfrm_Catalogos();
                    form.splitContainerControl1.PanelVisibility = SplitPanelVisibility.Panel2;
                    form.Mostrar_Pagina(2);
                    form.ShowDialog();
                    int count_nuevo = Negocio.ClasesCN.CatalogosCN.getCategoria().Count;
                    bindingSourceCategoria.DataSource = Negocio.ClasesCN.CatalogosCN.Categoria_Cargar();
                    if (count != count_nuevo)
                    {
                        int max = Negocio.ClasesCN.CatalogosCN.getCategoria().Max(x => x.id);
                        lookUpEditCategoria.EditValue = max;
                    }
                }
            }
            catch (Exception) { }
        }

        private void lookUpEditMarca_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try { 
            if (e.Button.Tag.ToString() == "2")
            {
                int count = Negocio.ClasesCN.CatalogosCN.getMarca().Count;
                var form = new xfrm_Catalogos();
                form.splitContainerControl1.PanelVisibility = SplitPanelVisibility.Panel2;
                form.Mostrar_Pagina(3);
                form.ShowDialog();
                int count_nuevo = Negocio.ClasesCN.CatalogosCN.getMarca().Count;
                bindingSourceMarca.DataSource = Negocio.ClasesCN.CatalogosCN.Marca_Cargar();
                if (count != count_nuevo)
                {
                    int max = Negocio.ClasesCN.CatalogosCN.getMarca().Max(x => x.id);
                    lookUpEditMarca.EditValue = max;
                }
            }
            }
            catch (Exception) { }
        }

        private void lookUpEditLinea_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try { 
            if (e.Button.Tag.ToString() == "2")
            {
                int count = Negocio.ClasesCN.CatalogosCN.getLinea().Count;
                var form = new xfrm_Catalogos();
                form.splitContainerControl1.PanelVisibility = SplitPanelVisibility.Panel2;
                form.Mostrar_Pagina(7);
                form.ShowDialog();
                int count_nuevo = Negocio.ClasesCN.CatalogosCN.getLinea().Count;
                bindingSourceLinea.DataSource = Negocio.ClasesCN.CatalogosCN.Linea_Cargar();
                if (count != count_nuevo)
                {
                    int max = Negocio.ClasesCN.CatalogosCN.getLinea().Max(x => x.id);
                    lookUpEditLinea.EditValue = max;
                }
            }
            }
            catch (Exception) { }
        }

        private void lookUpEditUnidadMedida_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if (e.Button.Tag.ToString() == "2")
                {
                    int count = Negocio.ClasesCN.CatalogosCN.getUnidadMedida().Count;
                    var form = new xfrm_Catalogos();
                    form.splitContainerControl1.PanelVisibility = SplitPanelVisibility.Panel2;
                    form.Mostrar_Pagina(4);
                    form.ShowDialog();
                    int count_nuevo = Negocio.ClasesCN.CatalogosCN.getUnidadMedida().Count;
                    bindingSourceUnidadMedida.DataSource = Negocio.ClasesCN.CatalogosCN.UnidadMedida_Cargar();
                    if (count != count_nuevo)
                    {
                        int max = Negocio.ClasesCN.CatalogosCN.getUnidadMedida().Max(x => x.id);
                        lookUpEditUnidadMedida.EditValue = max;
                    }
                }
            }
            catch (Exception) { }
        }

        #endregion
    }
}