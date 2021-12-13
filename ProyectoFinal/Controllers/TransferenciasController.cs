using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoFinal.Models;

namespace ProyectoFinal.Controllers
{
    public class TransferenciasController : Controller
    {
        // Modelo de la base de datos
        bancobdEntities modeloBD = new bancobdEntities();
        // GET: Transferencias
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TransferenciasLista()

        {
            ///Crear variable que contiene los registros obtenidos 
            ///al invocar al procedimiento almancenado sp_RetornaTransferencias
            List<sp_RetornaTransferencias_Result> modeloVista = new List<sp_RetornaTransferencias_Result>();
            ///Asignar a la variable el resultado de "llamar" al procedimiento almanceado
            modeloVista = this.modeloBD.sp_RetornaTransferencias("").ToList();
            ///enviar a la vista el modelo
            return View(modeloVista);
        }

        void AgregarCuentaViewBag()
        {
            this.ViewBag.ListaCuenta = this.modeloBD.sp_RetornaCuentas("").ToList();
        }


        public ActionResult InsertaTransferencias()
        {

            this.AgregarCuentaViewBag();
            return View();
        }

        [HttpPost]

        public ActionResult InsertaTransferencias(sp_RetornaTransferencias_Result modeloVista)
        {

            int cantRegistroAfectado = 0;
            string resultado = "";

            //if (Session["datosUsuario"] != null)
            //{
            //    sp_AutenticarUsuario_Result modelo = (sp_AutenticarUsuario_Result)this.Session["datosUsuario"];

            //    this.ViewBag.CuentasViewBag = this.modeloBD.sp_RetornaCuentasUsuario(modelo.IdCliente).ToList();
            //}

            try
            {
                cantRegistroAfectado = this.modeloBD.SP_Transferencias(
                    modeloVista.Cuenta_Origen,
                    modeloVista.Cuenta_Destino,
                    modeloVista.Monto_Transferencia,
                    modeloVista.Detalle
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
                    resultado += "No se pudo realizar la transferencia";
                }
            }

            Response.Write("<script language=javascript>alert('" + resultado + "')</script>");
            this.AgregarCuentaViewBag();     
            //this.ViewBag.CuentasViewBag();
            return View();
        }


        /// <summary>
        /// Trae los datos a mostrar para el KendoUI
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult RetornaTransferenciasLista()
        {
            List<sp_RetornaTransferencias_Result> listaTransferencias =
               this.modeloBD.sp_RetornaTransferencias("").ToList();
            return Json(new
            {
                resultado = listaTransferencias
            });
        }


    }
}