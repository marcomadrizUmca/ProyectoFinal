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
        public ActionResult Index()
        {
            return View();
        }


        //Método post del login(cuando se da click en el botón submit)
        [HttpPost]
        public ActionResult VerificaLogin(sp_AutenticarUsuario_Result modeloVista)
        {  
            ///Buscar el usuario tomando en cuena el correo electrónico y la contraseña suministrada
            sp_AutenticarUsuario_Result usuarioBuscar = this.modeloBD.sp_AutenticarUsuario(modeloVista.usuario, modeloVista.clave).FirstOrDefault();

            ///Si la consulta retorna null, indica que no la consulta (usuario y contraseña) no retornó valor, es decir la combinación (and)
            if (usuarioBuscar == null)
            {
                ///Permanecer en index del controlador login
                this.ModelState.AddModelError("", "Usuario o contraseña inválidos. Por favor verifique");
                return View("Index");
            }
            else
            {
                ///Establece los datos de sesion para que cuando el layout consulte por dicho dayos no re-direccione a loguin
                this.Session.Add("logueado", true);
                ///Agregamos todo el modelo del usuario
                this.Session.Add("datosUsuario", usuarioBuscar);
                ///redireccionar al método index del controlador Home
                return RedirectToAction("Bienvenida", "Inicio");
            }
 
        }
        /// <summary>
        /// Cierra la sesión y establece los valores de las variables 
        /// de sesión en nulo
        /// </summary>
        /// <returns></returns>
        public ActionResult CerrarSesion()
        {
            ///Establecer los datos de sesion para que cuando el layout
            ///consulte por dichos datos re-direccione a login
            this.Session.Add("logueado", null);
            ///"limpiar" todo el modelo del usuario
            this.Session.Add("datosUsuario", null);
            ///redireccionar al método index del controlador Login
            return RedirectToAction("Index", "Login");
        }


    }
}