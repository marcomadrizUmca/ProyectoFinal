using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoFinal.Models;

namespace ProyectoFinal.Controllers
{
    public class DepositosController : Controller
    {
        // Modelo de la base de datos
        bancobdEntities modeloBD = new bancobdEntities();
        // GET: Depositos
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DepositoLista()

        {
            ///Crear variable que contiene los registros obtenidos 
            ///al invocar al procedimiento almancenado sp_RetornaClientes
            List<sp_RetornaDepositos_Result> modeloVista = new List<sp_RetornaDepositos_Result>();
            ///Asignar a la variable el resultado de "llamar" al procedimiento almanceado
            modeloVista = this.modeloBD.sp_RetornaDepositos(null).ToList();
            ///enviar a la vista el modelo
            return View(modeloVista);
        }

        /// <summary>
        /// Agregar el tipo de clientes al viewbag, para que sean accedidas desde la vista, y es case sensitive
        /// </summary>
        void AgregarCuentasViewBag()
        {
            this.ViewBag.ListaCuentas = this.modeloBD.sp_RetornaCuentas("").ToList();
        }

        void AgregarTipoMonedaViewBag()
        {
            this.ViewBag.ListaMoneda = this.modeloBD.sp_RetornaMonedas("").ToList();
        }

        public ActionResult DepositoNuevo()
        {
            this.AgregarCuentasViewBag();
            this.AgregarTipoMonedaViewBag();
            return View();
        }

        [HttpPost]
        public ActionResult DepositoNuevo(sp_RetornaDepositos_Result modeloVista)
        {
            int cantRegistroAfectado = 0;
            string resultado = "";

            try
            {
                cantRegistroAfectado = this.modeloBD.sp_Depositos(
                    modeloVista.Monto_Deposito,
                    modeloVista.Id_Cuenta,
                    modeloVista.Id_Moneda
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
            this.AgregarCuentasViewBag();
            this.AgregarTipoMonedaViewBag();
            return View();
        }

            [HttpPost]
        public ActionResult RetornaDepositosLista()
        {
            List<sp_RetornaDepositos_Result> listaDepositos =
               this.modeloBD.sp_RetornaDepositos("").ToList();
            return Json(new
            {
                resultado = listaDepositos
            });
        }

    }
}