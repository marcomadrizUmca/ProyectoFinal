using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoFinal.Models;

namespace ProyectoFinal.Controllers
{
    public class LoginController : Controller
    {

        bancobdEntities modeloBD = new bancobdEntities();
        // GET: Login
        public ActionResult Autenticar()
        {
            return View("Autenticar");
        }


        [HttpPost]
        public ActionResult Autenticar(sp)
        {
            return View("Autenticar");
        }
    }
}