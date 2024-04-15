using DevExpress.XtraEditors;
using Presentacion.Clases;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Clases_Variadas
{
    public class Enviar_Correos
    {
        string vIP_Host = "";
        string vPuerto = string.Empty;

        bool Estado(string ip)
        {
            bool Activo = false;

            Ping ping = new Ping();
            PingReply pingReply = ping.Send(ip);

            if(pingReply.Status == IPStatus.Success)
            {
                Activo = true;
            }

            return Activo;
        }
        void Establecer_Host_Y_Puerto( )
        {
            var Servidor= Negocio.ClasesCN.ParametrosCN.Obtener_Servidor_correos();
            vIP_Host=Servidor.Item1;
            vPuerto=Servidor.Item2;

        }
        public void Enviar_correos(string Destinatarios,DevExpress.XtraReports.UI.XtraReport Reporte,string Asunto,string tipo_documento,string Mensaje)
        {

            System.IO.MemoryStream mem = new System.IO.MemoryStream();
            Reporte.ExportToPdf(mem);

            mem.Seek(0,System.IO.SeekOrigin.Begin);
            Attachment att = new Attachment(mem,tipo_documento+".pdf", "application/pdf");

            MailMessage email = new MailMessage();
            email.Attachments.Add(att);
            string[] destinatario = Destinatarios.Split(',');
            if(Destinatarios.Count()>0)
            {
                foreach(string destinos in destinatario)
                {
                    email.To.Add(destinos);
                }
            }
            email.Bcc.Add("itoquiga@gmail.com");
            email.Bcc.Add("contabilidad@netsoftnic.com");
            email.From = new MailAddress("netsoftnic@netsoftnic.com");

            email.Subject = string.Format(Asunto);
            email.Body = string.Format("{0}",Mensaje);
            string html = "<h1>" + Mensaje + "</h1>" +
                          "<h2>REALIZADO POR:</h2>";// +
                          //"<h3>" + UsuarioLogueado_Manager.vNombreCompleto.ToUpper() + "</h3>" +
                          //"<h3>" + UsuarioLogueado_Manager.vPuestoCargo.ToUpper() + "</h3>";
            AlternateView htmlView =
                AlternateView.CreateAlternateViewFromString(html,
                                 Encoding.UTF8,
                                 MediaTypeNames.Text.Html);
          
            email.IsBodyHtml = true;
            email.Priority = MailPriority.High;
            Establecer_Host_Y_Puerto();
            if(Estado(vIP_Host))
            {

                SmtpClient client = new SmtpClient();
                client.Host = vIP_Host;
                client.Port = Convert.ToInt32(vPuerto);
                client.EnableSsl = false;

                try
                {
                    email.AlternateViews.Add(htmlView);
                    client.Send(email);
                    client.Dispose();

                }
                catch(Exception ex)
                {
                    XtraMessageBox.Show("Lo sentimos, ha ocurrido un error al momento de enviar correos electrónicos" +ex.Message,"Mensaje del sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            else
            {
                XtraMessageBox.Show("Lo sentimos, No se tiene contacto con el servidor de correos","Mensaje del sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        public void Enviar_correo_codigo(string Destinatario,  string Asunto, string Mensaje)
        {
            System.Net.Mail.MailMessage msg = new MailMessage();
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            msg.To.Add(Destinatario);
            msg.Subject = Asunto;
            msg.SubjectEncoding = System.Text.Encoding.UTF8;

            msg.Body = Mensaje;
            msg.SubjectEncoding = System.Text.Encoding.UTF8;
            msg.IsBodyHtml = true;
            msg.From = new System.Net.Mail.MailAddress("asistencias@fantasia.com.ni");

            try
            {
                using (SmtpClient client = new SmtpClient())
                {
                    client.EnableSsl = true;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new System.Net.NetworkCredential("asistencias@fantasia.com.ni", "Complejo=81");
                        //("mppublicidad21@gmail.com", "M.publicidad21");
                    client.Host = "smtp.dreamhost.com";
                    client.Port = 587;
                    client.Timeout = 300000;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;

                    client.Send(msg);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString());
                throw;
            }
          

        }

        public void Enviar_correo_nomina_cerrada(string Destinatario, DevExpress.XtraReports.UI.XtraReport planilla_nomina, DevExpress.XtraReports.UI.XtraReport comprobante_nomina, DevExpress.XtraReports.UI.XtraReport comprobante_social, string Asunto, string tipo_documento_nomina, string tipo_documento_comprobante_n, string tipo_documento_comprobante_s, DevExpress.XtraReports.UI.XtraReport Documento_Informacion, string Mensaje)
        {
            // Primer documento a convertir
            System.IO.MemoryStream mem1 = new System.IO.MemoryStream();
            planilla_nomina.ExportToPdf(mem1);

            // Segundo documento a convertir
            System.IO.MemoryStream mem2 = new System.IO.MemoryStream();
            comprobante_nomina.ExportToPdf(mem2);

            // Tercer documento a convertir
            System.IO.MemoryStream mem3 = new System.IO.MemoryStream();
            comprobante_social.ExportToPdf(mem3);


            // Asignar nombre al primer documento (planilla de la nomina)
            mem1.Seek(0, System.IO.SeekOrigin.Begin);
            Attachment att1 = new Attachment(mem1, tipo_documento_nomina + ".pdf", "application/pdf");

            // Asignar nombre al segundo documento (comprobante nomina)
            mem2.Seek(0, System.IO.SeekOrigin.Begin);
            Attachment att2 = new Attachment(mem2, tipo_documento_comprobante_n + ".pdf", "application/pdf");

            // Asignar nombre al segundo documento (comprobante social)
            mem3.Seek(0, System.IO.SeekOrigin.Begin);
            Attachment att3 = new Attachment(mem3, tipo_documento_comprobante_s + ".pdf", "application/pdf");

            MailMessage email = new MailMessage();
            // Adjuntar primer documento al correo
            email.Attachments.Add(att1);
            // Adjuntar segundo documento al correo
            email.Attachments.Add(att2);
            // Adjuntar tercer documento al correo
            email.Attachments.Add(att3);

            // Agregar destinatario
            email.To.Add(Destinatario);

            // Agregar CCO            
            email.Bcc.Add("fforbes@paseniccis.com");
            email.Bcc.Add("asaenz@pasenic.com");
            email.Bcc.Add("hugarte@pasenic.com");
            email.Bcc.Add("mmorgan@paseniccis.com");

            email.Bcc.Add("itoquiga@gmail.com");
            email.Bcc.Add("acastillo@netsoftnic.com");

            // Agregar enviado por
            email.From = new MailAddress("netsoftnic@netsoftnic.com");
            // Agregar asunto
            email.Subject = string.Format(Asunto);

            // Exportar XtraReport a HTML
            string reportHTML = string.Empty;
            using (System.IO.MemoryStream mem4 = new System.IO.MemoryStream())
            {
                Documento_Informacion.ExportToHtml(mem4);
                mem4.Position = 0;
                using (StreamReader reader = new StreamReader(mem4, Encoding.UTF8))
                {
                    reportHTML = reader.ReadToEnd();
                }
            }
            string html = email.Body = reportHTML;

            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(html, Encoding.UTF8, MediaTypeNames.Text.Html);

            email.IsBodyHtml = true;
            email.Priority = MailPriority.High;
            Establecer_Host_Y_Puerto();
            if (Estado(vIP_Host))
            {

                SmtpClient client = new SmtpClient();
                client.Host = vIP_Host;
                client.Port = Convert.ToInt32(vPuerto);
                client.EnableSsl = false;

                // Uso del cover para pruebas de correos
                //SmtpClient SmtpServer = new SmtpClient("mail.cover.com.ni", 25);

                try
                {
                    email.AlternateViews.Add(htmlView);
                    client.Send(email);
                    client.Dispose();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("Lo sentimos, ha ocurrido un error al momento de enviar correos electrónicos " + ex.Message, "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                XtraMessageBox.Show("Lo sentimos, No se tiene contacto con el servidor de correos", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
