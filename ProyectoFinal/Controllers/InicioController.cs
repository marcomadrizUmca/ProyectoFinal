using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoFinal.Models;

namespace ProyectoFinal.Controllers
{
    public class InicioController : Controller
    {
        // GET: Inicio
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Bienvenida()
        {
            bool sesionIniciada = false;

            ///consultar si key "Logueado" de la sesion posee un valor
            if (this.Session["logueado"] != null)
            {
                sesionIniciada = Convert.ToBoolean(this.Session["logueado"]);
            }

            if (sesionIniciada == true)
            {
                ///recontruir los datos del modelo accediendo la objeto session
                sp_AutenticarUsuario_Result modelo = (sp_AutenticarUsuario_Result)this.Session["datosUsuario"];
                return View(modelo);
            }
            else
            {
                ///Redireccionar al método Index del controlador Login
                return RedirectToAction("Index", "Login");
            }

            
        }

    }
}