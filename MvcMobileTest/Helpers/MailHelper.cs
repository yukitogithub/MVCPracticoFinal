using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Configuration;

namespace Practico.MvcMobile.Helpers
{
    public static class MailHelper
    {
        //DONE: este metodo lo podes meter en un helper, ya que te puede ser utiles en mucho lugares
        // y trata de no hardcodear los valores. 
        //DONE: Los podrias ponner en el web.config y luego recuperarlo usando  System.Configuration.ConfigurationManager.AppSettings["ClientSecret"]. En este caso podrian estar SMTP, CREDENTIALS y PORT
        /// <summary>
        /// Método que envía por correo electrónico la clave de acceso del usuario
        /// </summary>
        /// <param name="email"></param>
        /// <param name="clave"></param>
        /// <returns>true: si envió correctamente. false: si hubo algún error</returns>
        public static Boolean SendMail(string email, string clave, string nombre, string apellido)
        {
            try
            {

                //Configuración del Mensaje
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(ConfigurationManager.AppSettings["SMTP"]);

                //Especificamos el correo desde el que se enviará el Email y el nombre de la persona que lo envía
                mail.From = new MailAddress(ConfigurationManager.AppSettings["Credential-User"], ConfigurationManager.AppSettings["Credential-Name"], System.Text.Encoding.UTF8);

                //Aquí ponemos el asunto del correo
                mail.Subject = ("Registro en Informatorio Evaluation System");

                mail.Body = "Bienvenido " + nombre + "! Tu clave de registro es: " + clave + ". Recordá que tu nombre de usuario es tu correo. Nombre de usuario: " + email;

                //Poner en true si queremos mandar un cuerpo de mensaje en formato html
                mail.IsBodyHtml = false;

                //Especificamos a quien enviaremos el Email, no es necesario que sea Gmail, puede ser cualquier otro proveedor
                mail.To.Add(email);

                mail.Bcc.Add(ConfigurationManager.AppSettings["Credential-User"]);

                //Si queremos enviar archivos adjuntos tenemos que especificar la ruta en donde se encuentran
                //mail.Attachments.Add(new Attachment(@"C:\Documentos\carta.docx"));

                //Configuracion del SMTP
                SmtpServer.Port = Convert.ToInt32(ConfigurationManager.AppSettings["Port"]); //Puerto que utiliza Gmail para sus servicios

                //Especificamos las credenciales con las que enviaremos el mail
                SmtpServer.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["Credential-User"], ConfigurationManager.AppSettings["Credential-Password"]);
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}