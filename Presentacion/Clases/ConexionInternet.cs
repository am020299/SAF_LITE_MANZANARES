using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Clases
{
    public class ConexionInternet
    {
        public bool Hay_Internet()
        {
            var AllNetworkInterfaces = NetworkInterface.GetAllNetworkInterfaces();

            foreach (var NetworkInterfaces in AllNetworkInterfaces)
            {
                if (NetworkInterfaces.NetworkInterfaceType == NetworkInterfaceType.Loopback)
                    continue;

                if (NetworkInterfaces.Name.ToLower().Contains("virtual") || NetworkInterfaces.Description.ToLower().Contains("virtual"))
                    continue; //Exclude virtual networks set up by VMWare and others

                if (NetworkInterfaces.Name.ToLower().Contains("fortinet") || NetworkInterfaces.Description.ToLower().Contains("fortinet"))
                    continue; //Exclude virtual networks set up by VMWare and others

                if (NetworkInterfaces.OperationalStatus == OperationalStatus.Up)
                {
                    return true;
                }
            }

            return false;
        }

        public bool valida_conexion_internet()
        {
            try{
                System.Net.IPHostEntry host = System.Net.Dns.GetHostEntry("www.google.com");
                return true;
            }
            catch (Exception ex){
                XtraMessageBox.Show("Error al validar la conexión a internet.\n" + ex.Message,"Información",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return false;
            }
        }
    }
}
