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
using System.IO;

namespace Presentacion.Formularios.Principal
{
    public partial class xfrm_DatosEmpresa : DevExpress.XtraEditors.XtraForm
    {
        public xfrm_DatosEmpresa()
        {
            InitializeComponent();
        }

        private void xfrm_DatosEmpresa_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        void CargarDatos()
        {
            var query = Negocio.ClasesCN.ParametrosCN.DatosEmpresa_Select().FirstOrDefault();
            if (query != null)
            {
                txt_Nombre.Text = query.nombre;
                txt_Eslogan.Text = query.eslogan;
                txt_Ruc.Text = query.cedula_ruc;
                txt_Tributario.Text = query.registro_triburatio;
                txt_Telefono.Text = query.telefono;
                txt_Correo.Text = query.correo;
                txt_SitioWeb.Text = query.sitio_web;
                txt_Direccion.Text = query.direccion;
                txt_Ciudad.Text = query.ciudad;
                txt_Departamento.Text = query.departamento;
                txt_CodigoPostal.Text = query.codigo_postal;
                txt_CorreoAdmin.Text = query.correo_administrador;
                pictureEdit_Logo.EditValue = query.logo;
            }
        }

        private void btnGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string vNombre = txt_Nombre.Text.Trim();
            string vEslogan = txt_Eslogan.Text.Trim();
            string vRuc = txt_Ruc.Text.Trim();
            string vTributario = txt_Tributario.Text.Trim();
            string vTelefono = txt_Telefono.Text.Trim();
            string vCorreo = txt_Correo.Text.Trim();
            string vSitioWeb = txt_SitioWeb.Text.Trim();
            string vDireccion = txt_Direccion.Text.Trim();
            string vCiudad = txt_Ciudad.Text.Trim();
            string vDepartamento = txt_Departamento.Text.Trim();
            string vCodigoPostal = txt_CodigoPostal.Text.Trim();
            string vCorreoAdmin = txt_CorreoAdmin.Text.Trim();
            MemoryStream ms = new MemoryStream();
            try
            {
                pictureEdit_Logo.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            }
            catch { }
            byte[] vLogo = ms.ToArray();
            ms.Close();

            int GuardarOK = Negocio.ClasesCN.ParametrosCN.DatosEmpresa_Guardar(vNombre, vEslogan, vRuc, vTributario, vTelefono, vCorreo, vSitioWeb, vDireccion, vCiudad, vDepartamento, vCodigoPostal, vCorreoAdmin, vLogo, "", "");
            if (GuardarOK > 0) { this.Close(); }
        }
    }
}