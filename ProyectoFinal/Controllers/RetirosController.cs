using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoFinal.Models;

namespace ProyectoFinal.Controllers
{
    public class RetirosController : Controller
    {
        // Modelo de la base de datos
        bancobdEntities modeloBD = new bancobdEntities();
        // GET: Retiros
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RetirosLista()

        {
            ///Crear variable que contiene los registros obtenidos 
            ///al invocar al procedimiento almancenado sp_RetornaRetiros
            List<sp_RetornaRetiros_Result> modeloVista = new List<sp_RetornaRetiros_Result>();
            ///Asignar a la variable el resultado de "llamar" al procedimiento almanceado
            modeloVista = this.modeloBD.sp_RetornaRetiros("").ToList();
            ///enviar a la vista el modelo
            return View(modeloVista);
        }

        void AgregarCuentaViewBag()
        {
            this.ViewBag.ListaCuenta = this.modeloBD.sp_RetornaCuentas("").ToList();
        }

        void AgregarTipoMonedaViewBag()
        {
            this.ViewBag.ListaMoneda = this.modeloBD.sp_RetornaMonedas("").ToList();
        }

        void AgregarSaldoViewBag()
        {
            this.ViewBag.MuestraSaldo = this.modeloBD.sp_RetornaCuentas("").ToList();
        }
        public ActionResult InsertaRetiro()
        {

            this.AgregarCuentaViewBag();
            this.AgregarSaldoViewBag();
            this.AgregarTipoMonedaViewBag();

            return View();
        }

        [HttpPost]

        public ActionResult InsertaRetiro(sp_RetornaRetiros_Result modeloVista)
        {

            int cantRegistroAfectado = 0;
            string resultado = "";
            
          

            try
            {
                cantRegistroAfectado = this.modeloBD.sp_Retiro(
                    modeloVista.Id_Cuenta,
                    modeloVista.Monto_Retiro
                    );
            }

            catch (Exception error)
            {
                resultado = "Ocurrió un error: " + error.Message;
            }
            finally
            {
                if (cantRegistroAfectado > 0)
                {
                    resultado = "Registro insertado";
                }
                else
                {
                    resultado += "No se pudo insertar";
                }
            }

            Response.Write("<script language=javascript>alert('" + resultado + "')</script>");
            this.AgregarCuentaViewBag();
            this.AgregarSaldoViewBag();
            return View();
        }

        [HttpPost]
        public ActionResult RetornaRetirosLista()
        {
            List<sp_RetornaRetiros_Result> listaRetiros =
               this.modeloBD.sp_RetornaRetiros("").ToList();
            return Json(new
            {
                resultado = listaRetiros
            });
        }

    }
}