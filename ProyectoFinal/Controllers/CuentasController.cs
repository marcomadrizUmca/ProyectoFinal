using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoFinal.Models;

namespace ProyectoFinal.Controllers
{
    public class CuentasController : Controller
    {
        // Modelo de la base de datos
        bancobdEntities modeloBD = new bancobdEntities();

        // GET: Cuentas
        public ActionResult Index()
        {
            return View();
        }

        void AgregarTipoClienteViewBag()
        {
            /* List<SelectListItem> vlo_lst_Lista = new List<SelectListItem>();

             foreach (var item in this.modeloBD.sp_RetornaTipo_Clientes("").ToList())
             {
                 vlo_lst_Lista.Add(new SelectListItem() { Text = item.Nombre, Value = item.Id_Tipo_Cliente.ToString() });
             }

             ViewBag.ListaTiposClientes = vlo_lst_Lista;*/

            this.ViewBag.ListaCliente = this.modeloBD.sp_RetornaClientes("id_Cliente").ToList();

        }





        public ActionResult CuentasLista()

        {
            ///Crear variable que contiene los registros obtenidos 
            ///al invocar al procedimiento almancenado sp_RetornaClientes
            List<sp_RetornaCuentas_Result> modeloVista = new List<sp_RetornaCuentas_Result>();
            ///Asignar a la variable el resultado de "llamar" al procedimiento almanceado
            modeloVista = this.modeloBD.sp_RetornaCuentas("").ToList();
            this.ViewBag.ListaCliente();
            ///enviar a la vista el modelo
            return View(modeloVista);

            
        }







    }

}