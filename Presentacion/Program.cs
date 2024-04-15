using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using Presentacion.Formularios.Inventario;
using System.Globalization;
using System.Threading;

namespace Presentacion
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            BonusSkins.Register();
            SkinManager.EnableFormSkins();
            UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");

            

            Application.Run(new Form_de_Inicio());
        }

        public class Form_de_Inicio : ApplicationContext
        {
            public Form_de_Inicio()
            {
                Application.Idle += new EventHandler(Application_Idle);
                //var form =  new  xfrm_grupos_subgrupos();
                Formularios.Login.xfrm_Login form = new Formularios.Login.xfrm_Login();
                //Formularios.Catalogos.xfrm_Historico_clientes form = new Formularios.Catalogos.xfrm_Historico_clientes();
                //Formularios.Inventario.consulta_existencias form = new Formularios.Inventario.consulta_existencias();
                //Formularios.Login.xfrm_Login form = new Formularios.Login.xfrm_Login();    
                //Formularios.CuentasCobrar.xfrm_aplicacion_documentos form= new Formularios.CuentasCobrar.xfrm_aplicacion_documentos  ();
                //var form = new  Formularios.Catalogos.xfrm_Viewer_image();
                form.Show();
            }

            void Application_Idle(object sender, EventArgs e)
            {
                if (Application.OpenForms.Count == 0)
                    Application.Exit();
            }
        }
    }
}
