using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos.ServiceReferenceTC;
using DevExpress.XtraEditors;
using Entidades;

namespace Datos.ClasesCD
{
    public class DatosRequeridosCD
    {
        const string BCN_WEBSERVICE_URL = "https://servicios.bcn.gob.ni/Tc_Servicio/ServicioTC.asmx?WSDL";

        public List<Tuple<DateTime, Decimal>> ObtenerCambioMensual(int Año, int Mes)
        {
            try
            {
                var client = new ServiceReferenceTC.
                           Tipo_Cambio_BCNSoapClient(
               new BasicHttpsBinding(), new EndpointAddress(BCN_WEBSERVICE_URL));

                Task<RecuperaTC_MesResponse> recuperaTCMesAsync = client.RecuperaTC_MesAsync(Año, Mes);
                recuperaTCMesAsync.Wait();

                var xml = recuperaTCMesAsync.Result.Body.RecuperaTC_MesResult;

                return (from tipoCambio in xml.Elements("Tc")
                        orderby (string)tipoCambio.Element("Fecha").Value
                        select new Tuple<DateTime, Decimal>(
                           new DateTime(Int32.Parse(tipoCambio.Element("Ano").Value), Int32.Parse(tipoCambio.Element("Mes").Value), Int32.Parse(tipoCambio.Element("Dia").Value)),
                           Decimal.Parse(tipoCambio.Element("Valor").Value))).ToList();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Error al obtener datos del banco central.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public decimal ObtenerCambioDia(int Año, int Mes, int Dia)
        {
            var client = new ServiceReferenceTC.
                            Tipo_Cambio_BCNSoapClient(
                new BasicHttpsBinding(), new EndpointAddress(BCN_WEBSERVICE_URL));

            Task<double> recuperaTCDiaAsync = client.RecuperaTC_DiaAsync(Año, Mes, Dia);
            recuperaTCDiaAsync.Wait();

            return (decimal)recuperaTCDiaAsync.Result;
        }
        public bool Validar_archivo_tipo_cambio(DateTime fecha)
        {
            bool r = false;
            try
            {
              
                string fecha2 = "";
                using (var db = new Entities())
                {
                    var query = from f in db.TipoCambio where f.fecha_cambio == fecha select new { f.fecha_cambio };
                    foreach (var fe in query)
                    {
                        fecha2 = fe.fecha_cambio.ToString();
                    }
                    if (fecha2 == fecha.ToString())
                        r = false;
                    else
                        r = true;
                }
            }
            catch (Exception ex)
            {
                r = false;
                XtraMessageBox.Show(string.Format("EL archivo no corresponde al formato correcto\nConsulte con Soporte Tecnico\nError:{0}",ex.Message.ToString()), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return r;
        }
        public int AgregaCambioContable(string fecha, decimal monto)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.AgregaTipoCambioContable(fecha, monto);
                }
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(string.Format("Ha ocurrido un error al momento de obtener cuentas contables. \nError {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;

            }
        }  
        public int AgregaCambioMensual(decimal monto)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.AgregaTipoCambioMensual(monto);
                }
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(string.Format("Ha ocurrido un error al momento de obtener cuentas contables. \nError {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
        public int AgregaCambioMensual_compra(decimal monto)
        {
            try
            {
                using(var db = new Entities())
                {
                    return db.AgregaTipoCambioMensual_Compra(monto);
                }
            }
            catch(Exception ex)
            {

                XtraMessageBox.Show(string.Format("Ha ocurrido un error al momento de obtener cuentas contables. \nError {0}",ex.Message),"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return 0;
            }
        }
        public decimal obtener_tipo_cambio_oficial( )
        {
            try
            {
                using(var datos = new Entities())
                {
                    var X =datos.ObtenerTipoCambioDia().FirstOrDefault();
                        return Convert.ToDecimal(X.monto);
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(string.Format("Ha ocurrido un error al momento de obtener el tipo cambio del dia \nError {0}",ex.Message),"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return 0;
            }
        }
        public decimal obtener_tipo_cambio_mensual()
        {
            try
            {
                using (var datos = new Entities())
                {
                    int X = datos.TipoCambioMensual.Where(o=>o.estado==1).Count();
                    if (X > 0)
                    {
                        var y = datos.TipoCambioMensual.Where(o => o.estado == 1).FirstOrDefault();
                        return Convert.ToDecimal(y.monto);
                    }
                    else
                       return 0;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(string.Format("Ha ocurrido un error al momento de obtener el tipo cambio del dia \nError {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
        public decimal obtener_tipo_cambio_mensual_compra( )
        {
            try
            {
                using(var datos = new Entities())
                {
                    int X = datos.Tipo_Cambio_Compra.Where(o=>o.estado==1).Count();
                    if(X > 0)
                    {
                        var y = datos.Tipo_Cambio_Compra.Where(o => o.estado == 1).FirstOrDefault();
                        return Convert.ToDecimal(y.monto);
                    }
                    else
                        return 0;
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(string.Format("Ha ocurrido un error al momento de obtener el tipo cambio del dia \nError {0}",ex.Message),"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return 0;
            }
        }
        public bool Datos_Empresa()
        {
            try
            {
                using (var datos = new Entities())
                {
                   int contador= datos.DatosEmpresa.Where(o=>o.activo== true).Count();
                    if (contador > 1)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(string.Format("Ha ocurrido un error al momento de obtener el tipo cambio del dia \nError {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public decimal Obtner_Tipo_Cambio_Mensual()
        {
            try
            {
                using (var db = new Entities())
                {
                    int contador = db.TipoCambioMensual.Where(o=>o.estado==1).Count();
                    if (contador == 0)
                        return 0;
                    else
                    {
                        var x = db.TipoCambioMensual.Where(o => o.estado == 1).FirstOrDefault();
                        return Convert.ToDecimal(x.monto);
                    }
                }
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(string.Format("Ha ocurrido un error al momento de obtener cuentas contables. \nError {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;

            }
        }

        public decimal Obtner_Tipo_Cambio_Mensual_Compra( )
        {
            try
            {
                using(var db = new Entities())
                {
                    int contador = db.Tipo_Cambio_Compra.Where(o=>o.estado==1).Count();
                    if(contador == 0)
                        return 0;
                    else
                    {
                        var x = db.Tipo_Cambio_Compra.Where(o => o.estado == 1).FirstOrDefault();
                        return Convert.ToDecimal(x.monto);
                    }
                }
            }
            catch(Exception ex)
            {

                XtraMessageBox.Show(string.Format("Ha ocurrido un error al momento de obtener cuentas contables. \nError {0}",ex.Message),"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return 0;

            }
        }




    }
}

