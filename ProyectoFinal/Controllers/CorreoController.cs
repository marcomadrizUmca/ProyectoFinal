using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using ProyectoFinal.Models;


namespace ProyectoFinal.Controllers
{
    public class CorreoController : Controller
    {
        bancobdEntities modelo = new bancobdEntities();
        // GET: Correo
        public ActionResult Correo()
        {
            return View();
        }

        [HttpPost]
        public ViewResult Correo(sp_RetornaClientes_Result envio)
        {
            string Correo = "";

            Correo = this.modelo.sp_RetornaClientes(Convert.ToString(envio.Cedula)).FirstOrDefault().Correo_Electronico;

               
            MailMessage mail = new MailMessage();
            mail.To.Add(envio.Correo_Electronico);
            mail.To.Add("Correo");
            
            mail.Subject = envio.Nombre;
            mail.Subject = ("Gracias por usar nuestros servicios");
            string Cuerpo = envio.Segundo_Apellido;
            mail.Body = Cuerpo;
            mail.Body = ("Su déposito fue exitoso");
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.live.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("115220613@castrocarazo.ac.cr", "Inder2018."); // Correo y contraseña  
            smtp.EnableSsl = true;
            smtp.Send(mail);
            return View("Email", envio);

        }


    }
}