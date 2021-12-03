using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;

namespace ProyectoFinal.Controllers
{
    public class CorreoController : Controller
    {
        // GET: Correo
        public ActionResult Correo()
        {
            return View();
        }

        [HttpPost]
        public ViewResult Correo(ProyectoFinal.Models.Correo envio)
        {
            MailMessage mail = new MailMessage();
            mail.To.Add(envio.Receptor);
            mail.To.Add("");
            mail.From = new MailAddress(envio.Emisor);
            mail.Subject = envio.Sujeto;
            mail.Subject = ("Gracias por usar nuestros servicios");
            string Cuerpo = envio.Cuerpo;
            mail.Body = Cuerpo;
            mail.Body = ("Su déposito fue exitoso");
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.live.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("", ""); // Correo y contraseña  
            smtp.EnableSsl = true;
            smtp.Send(mail);
            return View("Email", envio);

        }


    }
}