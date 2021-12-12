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