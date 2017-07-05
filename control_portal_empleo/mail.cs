using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace control_portal_empleo
{
    public class mail
    {//string smtpAddress = "172.15.0.12";
        string smtpAddress = "smtp.office365.com";
        int portNumber = 587;
        bool enableSSL = true;
        string emailFrom = "portalempleos@maipu.cl";
        string password = "M1ip5016";

        public async Task<Boolean> correos(string emailTo, byte[] pdf ,string titulo ,  string mensaje)
        {

        

          
            try
            {
                Attachment data = new Attachment(new MemoryStream(pdf), "pdfplox.pdf", "application/pdf");
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(emailFrom);
                    mail.To.Add(emailTo);
                    mail.Subject = titulo;
                    mail.Body = mensaje;
                    mail.IsBodyHtml = true;
               
                    
                    mail.Attachments.Add(data);
                    ServicePointManager.ServerCertificateValidationCallback =

              delegate(object s

                  , X509Certificate certificate

                  , X509Chain chain

                  , SslPolicyErrors sslPolicyErrors)

              { return true; };
          


                    SmtpClient smtp = new SmtpClient(smtpAddress, portNumber);

                    smtp.Credentials = new NetworkCredential(emailFrom, password);
                    smtp.EnableSsl = enableSSL;
                    try
                    {
                    await    smtp.SendMailAsync(mail);
                    }
                        catch(Exception ex)
                    {
                        return false;
                        }
                    

                }
                return true;
            }
            catch (NotSupportedException)
            { return false; }

        }

        public async Task<Boolean> Correo_Soporte(string emailTo , string nombre ,Int32 anexo, string titulo, string mensaje , byte[] foto)
        {

           
            try
            {
              
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(emailFrom);
                    mail.To.Add("jgutierreza@maipu.cl");
                    if (titulo == null)
                    { titulo = "Problema en Portal De empleos(Respuesta Estandar)"; }
                    mail.Subject = titulo;
                    
                    mail.Body = "<p> Persona que envia el reporte: "+nombre +"</p> <p> Correo electronico:"+emailTo + 
                        "</p> <p> Anexo de Contacto:"+ anexo+"</p> <p> Descripcion del Problema </p>" + mensaje;
                    mail.IsBodyHtml = true;
                    if (foto == null) { }
                    else
                    {
                        Attachment data = new Attachment(new MemoryStream(foto), "reporte.jpg");

                        mail.Attachments.Add(data);
                    }
                    ServicePointManager.ServerCertificateValidationCallback =

              delegate (object s

                  , X509Certificate certificate

                  , X509Chain chain

                  , SslPolicyErrors sslPolicyErrors)

              { return true; };
                    SmtpClient smtp = new SmtpClient(smtpAddress, portNumber);

                    smtp.Credentials = new NetworkCredential(emailFrom, password);
                    smtp.EnableSsl = enableSSL;
                    try
                    {
                      await  smtp.SendMailAsync(mail);
                    }
                    catch (Exception ex)
                    {
                        return false;
                    }


                }
                return true    ;
            }
            catch (NotSupportedException)
            { return false; }

        }

        public async Task<Boolean> Correo_recupera_credenciales(string emailTo  , Int32 rut ,Int32 dig_rut,  Int32 anexo , string nombre)
        {


            try
            {

                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(emailFrom);
                    mail.To.Add("jgutierreza@maipu.cl");
                   
                    mail.Subject = "Solicitud de Recuperacion de Credenciales";

                    mail.Body = "<p> Persona que envia la solicitud: " + nombre + "</p> <p> Correo electronico:" + emailTo +
                        "</p> <p> Anexo de Contacto:" + anexo + "</p> <p> Rut: " + rut+"-"+dig_rut+"</p>";
                    mail.IsBodyHtml = true;
             
             

         
                    SmtpClient smtp = new SmtpClient(smtpAddress, portNumber);

                    smtp.Credentials = new NetworkCredential(emailFrom, password);
                    smtp.EnableSsl = enableSSL;
                    try
                    {
                      await  smtp.SendMailAsync(mail);
                    }
                    catch (Exception ex)
                    {
                        return false;
                    }


                }
                return true;
            }
            catch (NotSupportedException)
            { return false; }

        }

        public async Task<bool> Correo_estados_postulacion(string correo_remitente , string titulo , string mensaje)
        {


            try
            {

                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(emailFrom);
                    mail.To.Add(correo_remitente);

                    mail.Subject = titulo;

                    mail.Body = mensaje;
                    mail.IsBodyHtml = true;




                    SmtpClient smtp = new SmtpClient(smtpAddress, portNumber);

                    smtp.Credentials = new NetworkCredential(emailFrom, password);
                    smtp.EnableSsl = enableSSL;
                    try
                    {
                       await  smtp.SendMailAsync(mail);
                        return false;
                    }
                    catch (Exception ex)
                    {
                        return true;
                    }


                }
              
            }
            catch (NotSupportedException)
            {
                return true;
            }

        }
    }
}