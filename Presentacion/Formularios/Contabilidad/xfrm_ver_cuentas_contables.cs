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
using Presentacion.Clases;

namespace Presentacion.Formularios.Contabilidad
{
    public partial class xfrm_ver_cuentas_contables:DevExpress.XtraEditors.XtraForm
    {
        public xfrm_ver_cuentas_contables( )
        {
            InitializeComponent();
        }
        List<Entidades.ParametrosCuentasContables> Parametros= Negocio.ClasesCN.ContabilidadCN.GetParametrosCuentas();
        Dictionary<string,string> Clasificaciones= new Dictionary<string, string>();
        Dictionary<string,string> Naturalezas= new Dictionary<string, string>();
        int id_cuenta=0;
        int[] id_cuentas;
        List<int> Lista_cuentas_modificar = new List<int>();
        private void bbi_menu_ItemClick(object sender,DevExpress.XtraBars.ItemClickEventArgs e)
        {
            radial_menu.ShowPopup(Control.MousePosition);
        }

        private void Cargar_cuentas_contables( )
        {
            try
            {
                binding_vercuentas.DataSource= Negocio.ClasesCN.ContabilidadCN.Cuentas_Select().Select(X =>
                new
                {
                    agrupacion = Convert.ToBoolean(X.agrupacion??0),
                    deslizamiento = Convert.ToBoolean(X.deslizamiento??0),
                    X.clasificacion,
                    X.estado,
                    X.numero_cuenta,
                    X.nombre_cuenta,
                    X.nivel,
                    X.naturaleza,
                    X.id,
                    X.fecha_registro
                }).OrderBy(T=>T.numero_cuenta).ToList();
                grid_Cuentas.DataSource=binding_vercuentas;
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show($"Lo sentimos ha ocurrido el siguiente error.{Environment.NewLine}Error:{ex.Message}.","Mensaje del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void xfrm_ver_cuentas_contables_Load(object sender,EventArgs e)
        {
            Cargar_cuentas_contables();
            txt_nivel.Properties.MaxValue=Parametros.Max(X => X.nivel);
            txt_nivel.Properties.MinValue=1;
            Clasificaciones.Clear();
            Naturalezas.Clear();
            Clasificaciones.Add("A","ACTIVO");
            Clasificaciones.Add("P","PASIVO");
            Clasificaciones.Add("C","CAPITAL");
            Clasificaciones.Add("R","RESULTADO");
            Naturalezas.Add("A","ACREEDORA");
            Naturalezas.Add("D","DEUDORA");
            txt_clasficacion.Properties.Items.AddRange(Clasificaciones.Values.ToList());
            txt_naturaleza.Properties.Items.AddRange(Naturalezas.Values.ToList());
            txt_clasficacion.Properties.DropDownRows=Clasificaciones.Count;
            txt_naturaleza.Properties.DropDownRows=Naturalezas.Count;



        }
        private void txt_nivel_EditValueChanged(object sender,EventArgs e)
        {
            try
            {
                if(Convert.ToInt32(txt_nivel.EditValue??0)>=txt_nivel.Properties.MinValue && Convert.ToInt32(txt_nivel.EditValue??0)<=txt_nivel.Properties.MaxValue)
                {
                    txt_numero_cuenta.Properties.MaxLength=Parametros.Where(P => P.nivel<=Convert.ToInt32(txt_nivel.EditValue??0)).Sum(X => X.digitos);
                    if(txt_numero_cuenta.Text.Length>txt_numero_cuenta.Properties.MaxLength)
                    {
                        // txt_numero_cuenta.Select(txt_numero_cuenta.Properties.MaxLength,txt_numero_cuenta.Text.Length);
                        txt_numero_cuenta.Text = txt_numero_cuenta.Text.Remove(txt_numero_cuenta.Properties.MaxLength);

                    }
                }
                else
                {
                    txt_numero_cuenta.Properties.MaxLength=20;
                }
            }
            catch(Exception ex)
            {

                XtraMessageBox.Show($"Lo sentimos ha ocurrido el siguiente error.{Environment.NewLine}Error:{ex.Message}.","Mensaje del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }



        private void gview_Cuentas_FocusedRowChanged(object sender,DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if(gview_Cuentas.GetSelectedRows().Count()==1)
                {
                    if(!gview_Cuentas.IsFilterRow(gview_Cuentas.FocusedRowHandle))
                    {
                        blb_guardar_cuenta.Tag=1;
                        blb_crear_cuenta.Enabled=true;
                        blb_guardar_cuenta.Enabled=false;
                        lbl_modificar.Enabled=true;
                        id_cuenta=Convert.ToInt32(gview_Cuentas.GetFocusedRowCellValue(col_id_cuenta));
                        string numero_cuebta=gview_Cuentas.GetFocusedRowCellValue(col_numero_cuenta).ToString();
                        string nombre_cuenta=gview_Cuentas.GetFocusedRowCellValue(col_nombre_cuenta).ToString();
                        int nivel=Convert.ToInt32(gview_Cuentas.GetFocusedRowCellValue(col_Nivel));
                        string naturaleza=gview_Cuentas.GetFocusedRowCellValue(col_naturaleza).ToString();
                        string  clasificacion= gview_Cuentas.GetFocusedRowCellValue(col_clasificacion).ToString();
                        bool deslizamiento= Convert.ToBoolean(gview_Cuentas.GetFocusedRowCellValue(col_deslizamiento));
                        bool agrupacion=  Convert.ToBoolean(gview_Cuentas.GetFocusedRowCellValue(col_agrupacion));
                        lbl_modificar.Enabled=!Negocio.ClasesCN.ContabilidadCN.Tiene_Movimientos(id_cuenta);
                        txt_nivel.EditValue=nivel;
                        txt_nombre_cuenta.EditValue=nombre_cuenta;
                        txt_numero_cuenta.EditValue=numero_cuebta;
                        check_agrupacion.EditValue=agrupacion;
                        check_deslizamiento.EditValue=deslizamiento;
                        txt_clasficacion.Text=Clasificaciones.ContainsKey(clasificacion) ? Clasificaciones[clasificacion] : string.Empty;
                        txt_naturaleza.Text=Naturalezas.ContainsKey(naturaleza) ? Naturalezas[naturaleza] : string.Empty;
                    }
                }



                
            }
            catch(Exception ex)
            {

                XtraMessageBox.Show($"Lo sentimos ha ocurrido el siguiente error.{Environment.NewLine}Error:{ex.Message}.","Mensaje del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void lbl_modificar_ItemClick(object sender,DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if(Lista_cuentas_modificar.Count()==1)
                {
                    blb_crear_cuenta.Enabled=false;
                    lbl_exportar.Enabled=false;
                    blb_guardar_cuenta.Enabled=true;
                    blb_guardar_cuenta.Caption="Guardar Cambios";
                    blb_guardar_cuenta.Tag=2;
                    bbi_cancelar.Visibility=DevExpress.XtraBars.BarItemVisibility.Always;
                    lbl_modificar.Enabled=false;
                    radial_menu.HidePopup();
                    txt_clasficacion.ReadOnly=true;
                    txt_naturaleza.ReadOnly=true;
                    txt_nivel.ReadOnly=true;
                    txt_nombre_cuenta.ReadOnly=false;
                    txt_numero_cuenta.ReadOnly=true;
                    check_agrupacion.ReadOnly=false;
                    check_deslizamiento.ReadOnly=false;
                    txt_nombre_cuenta.Focus();
                }
                else if(Lista_cuentas_modificar.Count()>1)
                    {
                    blb_crear_cuenta.Enabled=false;
                    lbl_exportar.Enabled=false;
                    blb_guardar_cuenta.Enabled=true;
                    blb_guardar_cuenta.Caption="Guardar Cambios";
                    blb_guardar_cuenta.Tag=3;
                    bbi_cancelar.Visibility=DevExpress.XtraBars.BarItemVisibility.Always;
                    lbl_modificar.Enabled=false;
                    radial_menu.HidePopup();
                    txt_clasficacion.ReadOnly=true;
                    txt_naturaleza.ReadOnly=true;
                    txt_nivel.ReadOnly=true;
                    txt_nombre_cuenta.ReadOnly=true;
                    txt_numero_cuenta.ReadOnly=true;
                    check_agrupacion.ReadOnly=false;
                    check_deslizamiento.ReadOnly=false;
                    txt_nombre_cuenta.Focus();
                }
            }
            catch(Exception ex)
            {

                XtraMessageBox.Show($"Lo sentimos ha ocurrido el siguiente error.{Environment.NewLine}Error:{ex.Message}.","Mensaje del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void bbi_cancelar_ItemClick(object sender,DevExpress.XtraBars.ItemClickEventArgs e)
        {
            blb_crear_cuenta.Enabled=true;
            lbl_exportar.Enabled=true;
            blb_guardar_cuenta.Enabled=false;
            blb_guardar_cuenta.Caption="Guardar";
            bbi_cancelar.Visibility=DevExpress.XtraBars.BarItemVisibility.Never;
            lbl_modificar.Enabled=true;
            radial_menu.HidePopup();
            txt_clasficacion.ReadOnly=true;
            txt_naturaleza.ReadOnly=true;
            txt_nivel.ReadOnly=true;
            txt_nombre_cuenta.ReadOnly=true;
            txt_numero_cuenta.ReadOnly=true;
            check_agrupacion.ReadOnly=true;
            check_deslizamiento.ReadOnly=true;
        }

        private void blb_guardar_cuenta_ItemClick(object sender,DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MyMessageBox.MessageFont = new Font(Clases.MyMessageBox.MessageFont.FontFamily,22);
            //Tag=1 Crear
            //Tag=2 Modificar
            //Tag=3 Modificar Agrupacion o Deslizamiento a Muchas Cuentas
            try
            {
                if((int) blb_guardar_cuenta.Tag==1)
                {
                    if(string.IsNullOrEmpty(txt_clasficacion.Text))
                    {
                        dxErrorProvider1.SetError(txt_clasficacion,"Campo obligatorio");
                        return;
                    }
                    else if(string.IsNullOrEmpty(txt_naturaleza.Text))
                    {
                        dxErrorProvider1.SetError(txt_naturaleza,"Campo obligatorio");
                        return;
                    }
                    else if(string.IsNullOrEmpty(txt_numero_cuenta.Text))
                    {
                        dxErrorProvider1.SetError(txt_numero_cuenta,"Campo obligatorio");
                        return;
                    }
                    else if(string.IsNullOrEmpty(txt_nombre_cuenta.Text))
                    {
                        dxErrorProvider1.SetError(txt_nombre_cuenta,"Campo obligatorio");
                        return;
                    }
                    else if(string.IsNullOrEmpty(txt_nivel.Text))
                    {
                        dxErrorProvider1.SetError(txt_nombre_cuenta,"Campo obligatorio");
                        return;
                    }
                    else
                    {
                        DialogResult Preg=MyMessageBox.Show($"¿Esta Seguro que desea Guardar esta Cuenta?","Confirmacion",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                        if(Preg==DialogResult.Yes)
                        {
                            int ModificacionOk=Negocio.ClasesCN.ContabilidadCN.Cuenta_Insert(txt_numero_cuenta.Text.Trim(),txt_nombre_cuenta.Text,txt_naturaleza.Text.ElementAt(0).ToString(),txt_clasficacion.Text.ElementAt(0).ToString(),check_agrupacion.Checked,check_deslizamiento.Checked,Convert.ToInt32(txt_nivel.EditValue),Presentacion.Clases.UsuarioLogueado.vID_Empleado);
                            if(ModificacionOk>0)
                            {
                                MessageBox.Show($"Se ha guardado la cuenta exitosamete","Mensaje del sistema",MessageBoxButtons.OK,MessageBoxIcon.Information);
                                Cargar_cuentas_contables();
                                txt_nombre_cuenta.ReadOnly=true;
                                txt_numero_cuenta.ReadOnly=true;
                                check_agrupacion.ReadOnly=true;
                                check_deslizamiento.ReadOnly=true;

                                blb_guardar_cuenta.Tag=1;
                                blb_crear_cuenta.Enabled=true;
                                blb_guardar_cuenta.Enabled=false;
                                lbl_modificar.Enabled=!Negocio.ClasesCN.ContabilidadCN.Tiene_Movimientos(id_cuenta);


                                lbl_exportar.Enabled=true;
                                blb_guardar_cuenta.Caption="Guardar";
                                bbi_cancelar.Visibility=DevExpress.XtraBars.BarItemVisibility.Never;


                            }
                            else
                            {
                                MessageBox.Show($"No se ha podido guardar cuenta Contable","Mensaje del sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
                                Cargar_cuentas_contables();
                                txt_nombre_cuenta.ReadOnly=true;
                                txt_numero_cuenta.ReadOnly=true;
                                check_agrupacion.ReadOnly=true;
                                check_deslizamiento.ReadOnly=true;

                                blb_guardar_cuenta.Tag=1;
                                blb_crear_cuenta.Enabled=true;
                                blb_guardar_cuenta.Enabled=false;
                                lbl_modificar.Enabled=!Negocio.ClasesCN.ContabilidadCN.Tiene_Movimientos(id_cuenta);

                                lbl_exportar.Enabled=true;
                                blb_guardar_cuenta.Caption="Guardar";
                                bbi_cancelar.Visibility=DevExpress.XtraBars.BarItemVisibility.Never;
                            }


                        }
                    }

                }
                else if((int) blb_guardar_cuenta.Tag==2)
                {

                    if(string.IsNullOrEmpty(txt_clasficacion.Text))
                    {
                        dxErrorProvider1.SetError(txt_clasficacion,"Campo obligatorio");
                        return;
                    }
                    else if(string.IsNullOrEmpty(txt_naturaleza.Text))
                    {
                        dxErrorProvider1.SetError(txt_naturaleza,"Campo obligatorio");
                        return;
                    }
                    else if(string.IsNullOrEmpty(txt_numero_cuenta.Text))
                    {
                        dxErrorProvider1.SetError(txt_numero_cuenta,"Campo obligatorio");
                        return;
                    }
                    else if(string.IsNullOrEmpty(txt_nombre_cuenta.Text))
                    {
                        dxErrorProvider1.SetError(txt_nombre_cuenta,"Campo obligatorio");
                        return;
                    }
                    else if(string.IsNullOrEmpty(txt_nivel.Text))
                    {
                        dxErrorProvider1.SetError(txt_nombre_cuenta,"Campo obligatorio");
                        return;
                    }
                    else
                    {
                        DialogResult Preg=MyMessageBox.Show($"¿Esta Seguro de Realizar modificaciones?","Confirmacion",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                        if(Preg==DialogResult.Yes)
                        {
                            int ModificacionOk=Negocio.ClasesCN.ContabilidadCN.Cuenta_Modificar(id_cuenta,txt_numero_cuenta.Text.Trim(),txt_nombre_cuenta.Text,check_agrupacion.Checked,check_deslizamiento.Checked,Convert.ToInt32(txt_nivel.EditValue),Presentacion.Clases.UsuarioLogueado.vID_Empleado);
                            if(ModificacionOk>0)
                            {
                                MyMessageBox.Show($"Se ha modificado la cuenta exitosamete","Mensaje del sistema",MessageBoxButtons.OK,MessageBoxIcon.Information);
                                Cargar_cuentas_contables();
                                txt_nombre_cuenta.ReadOnly=true;
                                check_agrupacion.ReadOnly=true;
                                check_deslizamiento.ReadOnly=true;

                                blb_guardar_cuenta.Tag=1;
                                blb_crear_cuenta.Enabled=true;
                                blb_guardar_cuenta.Enabled=false;
                                lbl_modificar.Enabled=!Negocio.ClasesCN.ContabilidadCN.Tiene_Movimientos(id_cuenta);


                                lbl_exportar.Enabled=true;
                                blb_guardar_cuenta.Caption="Guardar";
                                bbi_cancelar.Visibility=DevExpress.XtraBars.BarItemVisibility.Never;


                            }
                            else
                            {
                                MyMessageBox.Show($"No se ha podido modificar cuenta Contable","Mensaje del sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
                                Cargar_cuentas_contables();
                                txt_nombre_cuenta.ReadOnly=true;
                                check_agrupacion.ReadOnly=true;
                                check_deslizamiento.ReadOnly=true;

                                blb_guardar_cuenta.Tag=1;
                                blb_crear_cuenta.Enabled=true;
                                blb_guardar_cuenta.Enabled=false;
                                lbl_modificar.Enabled=!Negocio.ClasesCN.ContabilidadCN.Tiene_Movimientos(id_cuenta);

                                lbl_exportar.Enabled=true;
                                blb_guardar_cuenta.Caption="Guardar";
                                bbi_cancelar.Visibility=DevExpress.XtraBars.BarItemVisibility.Never;
                            }


                        }
                    }
                }
                else if((int) blb_guardar_cuenta.Tag==3 && Lista_cuentas_modificar.Count()>1)
                {
                    txt_clasficacion.SelectedIndex=-1;
                    txt_nombre_cuenta.Text=String.Empty;
                    txt_numero_cuenta.Text=string.Empty;
                    txt_nivel.EditValue=1;
                    txt_naturaleza.SelectedIndex=-1;
                    DialogResult Preg=MyMessageBox.Show($"¿Esta Seguro de Realizar modificaciones?","Confirmacion",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                    if(Preg==DialogResult.Yes)
                    {
                        var Resultados= Negocio.ClasesCN.ContabilidadCN.CuentasModificarAgrupacion_Deslizamiento(Lista_cuentas_modificar,check_agrupacion.Checked,check_deslizamiento.Checked,UsuarioLogueado.vID_Empleado);
                        if(Resultados.Item1!=null && Resultados.Item2!=null)
                        {
                            if(Resultados.Item1.Count()>0 && Resultados.Item1.Count()==Lista_cuentas_modificar.Count())
                            {
                                MyMessageBox.Show($"Se han Modificado {Resultados.Item1.Count()} Cuentas de manera Exitosa","Mensaje del sistema",MessageBoxButtons.OK,MessageBoxIcon.Information);
                                Cargar_cuentas_contables();
                                txt_nombre_cuenta.ReadOnly=true;
                                check_agrupacion.ReadOnly=true;
                                check_deslizamiento.ReadOnly=true;

                                blb_guardar_cuenta.Tag=1;
                                blb_crear_cuenta.Enabled=true;
                                blb_guardar_cuenta.Enabled=false;
                                lbl_modificar.Enabled=!Negocio.ClasesCN.ContabilidadCN.Tiene_Movimientos(id_cuenta);


                                lbl_exportar.Enabled=true;
                                blb_guardar_cuenta.Caption="Guardar";
                                bbi_cancelar.Visibility=DevExpress.XtraBars.BarItemVisibility.Never;

                            }
                            else
                            {
                                MyMessageBox.Show($"Se han Modificado {Resultados.Item1.Count()} Cuentas de manera Exitosa{Environment.NewLine}No se puedieron modificar {Resultados.Item2.Count()} cuentas por que ya tienen movimientos registrados","Mensaje del sistema",MessageBoxButtons.OK,MessageBoxIcon.Information);
                                Cargar_cuentas_contables();
                                txt_nombre_cuenta.ReadOnly=true;
                                check_agrupacion.ReadOnly=true;
                                check_deslizamiento.ReadOnly=true;

                                blb_guardar_cuenta.Tag=1;
                                blb_crear_cuenta.Enabled=true;
                                blb_guardar_cuenta.Enabled=false;
                                lbl_modificar.Enabled=!Negocio.ClasesCN.ContabilidadCN.Tiene_Movimientos(id_cuenta);

                                lbl_exportar.Enabled=true;
                                blb_guardar_cuenta.Caption="Guardar";
                                bbi_cancelar.Visibility=DevExpress.XtraBars.BarItemVisibility.Never;

                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {

                XtraMessageBox.Show($"Lo sentimos ha ocurrido el siguiente error.{Environment.NewLine}Error:{ex.Message}.","Mensaje del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void gview_Cuentas_SelectionChanged(object sender,DevExpress.Data.SelectionChangedEventArgs e)
        {
            Lista_cuentas_modificar.Clear();
            if(gview_Cuentas.GetSelectedRows().Count()>1)
            {
                txt_clasficacion.SelectedIndex=-1;
                txt_nombre_cuenta.Text=String.Empty;
                txt_numero_cuenta.Text=string.Empty;
                txt_nivel.EditValue=1;
                txt_naturaleza.SelectedIndex=-1;
                blb_guardar_cuenta.Tag=3;
                blb_crear_cuenta.Enabled=true;
                blb_guardar_cuenta.Enabled=false;
                lbl_modificar.Enabled=true;
                id_cuentas= new int[gview_Cuentas.GetSelectedRows().Count()];
                var CUENTAS=gview_Cuentas.GetSelectedRows();
                foreach(var i in CUENTAS)
                {
                    Lista_cuentas_modificar.Add(Convert.ToInt32(gview_Cuentas.GetRowCellValue(i,col_id_cuenta)));
                }

            }
            else if(gview_Cuentas.GetSelectedRows().Count()==1)
            {
                blb_guardar_cuenta.Tag=2;
                blb_crear_cuenta.Enabled=true;
                blb_guardar_cuenta.Enabled=false;
                var CUENTAS=gview_Cuentas.GetSelectedRows();
                foreach(var i in CUENTAS)
                {
                    Lista_cuentas_modificar.Add(Convert.ToInt32(gview_Cuentas.GetRowCellValue(i,col_id_cuenta)));
                }
            }
        }

        private void blb_crear_cuenta_ItemClick(object sender,DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                bbi_cancelar.Visibility= DevExpress.XtraBars.BarItemVisibility.Always;
                lbl_modificar.Enabled=false;
                lbl_exportar.Enabled=false;
                blb_guardar_cuenta.Enabled=true;
                txt_nombre_cuenta.ReadOnly=txt_numero_cuenta.ReadOnly=txt_clasficacion.ReadOnly=txt_naturaleza.ReadOnly=txt_nivel.ReadOnly=check_agrupacion.ReadOnly=check_deslizamiento.ReadOnly=false;
                txt_numero_cuenta.Focus();
                blb_guardar_cuenta.Tag=1;
                radial_menu.HidePopup();
                txt_clasficacion.SelectedIndex=-1;
                txt_naturaleza.SelectedIndex=1;
                txt_nombre_cuenta.Text=string.Empty;
                txt_numero_cuenta.EditValue=string.Empty;
                txt_nivel.EditValue=1;
                check_agrupacion.Checked=false;
                check_deslizamiento.Checked=false;


            }
            catch(Exception ex)
            {

                XtraMessageBox.Show($"Lo sentimos ha ocurrido el siguiente error.{Environment.NewLine}Error:{ex.Message}.","Mensaje del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
       
        private void Cuenta(string Cuenta_Validar)
        {
            if(!Negocio.ClasesCN.ContabilidadCN.Cuenta_Validar(Cuenta_Validar))
            {
                DialogResult Preg= MyMessageBox.Show($"El numero de cuenta {Cuenta_Validar} no Existe en el Catalogo{Environment.NewLine}¿Desea agregarla?","Mensaje del sistema",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if(Preg==DialogResult.Yes)
                {
                    txt_nombre_cuenta.Focus();
                    txt_nivel.ReadOnly=true;
                }
                else
                {
                    txt_numero_cuenta.EditValue=string.Empty;
                    txt_numero_cuenta.Focus();
                    return;
                }
            }
            else
            {
                var Cta= Negocio.ClasesCN.ContabilidadCN.Cuenta(Cuenta_Validar);
                txt_nombre_cuenta.EditValue=Cta.nombre_cuenta??string.Empty;
                //txt_nivel.EditValue=Cta.nivel??1;
                txt_naturaleza.Text=Naturalezas.ContainsKey(Cta.naturaleza) ? Naturalezas[Cta.naturaleza] : string.Empty;
                txt_clasficacion.Text=Clasificaciones.ContainsKey(Cta.clasificacion) ? Clasificaciones[Cta.clasificacion] : string.Empty;
                check_agrupacion.Checked=Convert.ToBoolean(Cta.agrupacion??0);
                check_deslizamiento.Checked=Convert.ToBoolean(Cta.deslizamiento??0);


            }
        }
        private void txt_numero_cuenta_EditValueChanged(object sender,EventArgs e)
        {
            try
            {
                string Cuenta_Validar=string.Empty;
                if (txt_numero_cuenta.EditValue==string.Empty)
                {
                    txt_clasficacion.SelectedIndex=-1;
                    txt_naturaleza.SelectedIndex=1;
                    txt_nombre_cuenta.Text=string.Empty;
                    txt_numero_cuenta.EditValue=string.Empty;
                   // txt_nivel.EditValue=1;
                    check_agrupacion.Checked=false;
                    check_deslizamiento.Checked=false;

                }
                
               else if(Convert.ToInt64(txt_numero_cuenta.EditValue==string.Empty?0:txt_numero_cuenta.EditValue)>=1000)
                {
                    
                    int nivel=Convert.ToInt32(txt_nivel.EditValue??0);
                    List<int>DigitosNivel=new List<int>();
                    
                    foreach(var item in Parametros)
                    {
                        DigitosNivel.Add(item.digitos);
                    }

                    if(txt_numero_cuenta.Text.Length==DigitosNivel[0])
                    {
                        Cuenta_Validar=txt_numero_cuenta.Text.Trim();
                        Cuenta(Cuenta_Validar);
                        
                    }
                    else if(txt_numero_cuenta.Text.Length==DigitosNivel[1]+DigitosNivel[0])
                    {
                        Cuenta_Validar=txt_numero_cuenta.Text.Trim();
                        Cuenta(Cuenta_Validar);

                    }
                    else if(txt_numero_cuenta.Text.Length==DigitosNivel[2]+DigitosNivel[1]+DigitosNivel[0])
                    {
                        Cuenta_Validar=txt_numero_cuenta.Text.Trim();
                        Cuenta(Cuenta_Validar);

                    }
                    else if(txt_numero_cuenta.Text.Length==DigitosNivel[3]+DigitosNivel[2]+DigitosNivel[1]+DigitosNivel[0])
                    {
                        Cuenta_Validar=txt_numero_cuenta.Text.Trim();
                        Cuenta(Cuenta_Validar);

                    }
                    else if(txt_numero_cuenta.Text.Length==DigitosNivel[4]+DigitosNivel[3]+DigitosNivel[2]+DigitosNivel[1]+DigitosNivel[0])
                    {
                        Cuenta_Validar=txt_numero_cuenta.Text.Trim();
                        Cuenta(Cuenta_Validar);

                    }

                }
            }
            catch(Exception ex)
            {

                XtraMessageBox.Show($"Lo sentimos ha ocurrido el siguiente error.{Environment.NewLine}Error:{ex.Message}.","Mensaje del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }

        private void xfrm_ver_cuentas_contables_Activated(object sender,EventArgs e)
        {
            xfrm_ver_cuentas_contables_Load(null,null);
        }

        private void lbl_exportar_ItemClick(object sender,DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                new Presentacion.Clases.Exportar().Exportar_Grid_A_Excel(grid_Cuentas);
            }
            catch(Exception ex)
            {

                XtraMessageBox.Show($"Lo sentimos ha ocurrido el siguiente error.{Environment.NewLine}Error:{ex.Message}.","Mensaje del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}