//-------------------------
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using System;
using System.Windows.Forms;
//--------------------------------


namespace Proyecto_Lite.Formularios.Splash
{
    public partial class xfrm_SplashScreen_1 : SplashScreen
    {

        //int vIntervaloSplash = 3000;
        public xfrm_SplashScreen_1()
        {
            InitializeComponent();
            //VerificarConexion();

        }
        private void VerificarConexion()
        {
            try
            {
                //if (Negocio.ClasesCN.LoginsCN.HayConexion())
                //{
                //    timer_Splash.Interval = vIntervaloSplash;
                //    timer_Splash.Start();
                //    // this.Dispose();
                //    // this.Close();
                //    xfrm_Login Principal = new xfrm_Login();
                //    Principal.Show();
                //}
                //else
                //{
                //    XtraMessageBox.Show("No hay comunicación con la base de datos...\n\nComuníquese con el Administrador del Sistema.", "SAFNISA LITE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    timer_Splash.Stop();
                //    this.Dispose();
                //    this.Close();
                //    Environment.Exit(-1);
                //}
            }
            catch (ObjectDisposedException ex)
            {
                XtraMessageBox.Show("Error al intentar verificar la conexión..." + "\n\n" + ex.Message + "\n\n" + ex.Source + "\n\n" + ex.TargetSite + "\n\n" + ex.Data + "\n\n" + ex.GetType(), "Inicio de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void timer_Splash_Tick(object sender, EventArgs e)
        {
           
        }

        private void xfrm_SplashScreen_1_Load(object sender, EventArgs e)
        {
            
        }
    }
}