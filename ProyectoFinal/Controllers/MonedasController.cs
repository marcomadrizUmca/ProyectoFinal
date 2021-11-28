using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoFinal.Models;

namespace ProyectoFinal.Controllers
{
    public class MonedasController : Controller
    {
        // Modelo de la base de datos
        bancobdEntities modeloBD = new bancobdEntities();


        // GET: Monedas
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TipoMonedaLista()

        {
            ///Crear variable que contiene los registros obtenidos 
            ///al invocar al procedimiento almancenado sp_RetornaMonedas
            List<sp_RetornaMonedas_Result> modeloVista = new List<sp_RetornaMonedas_Result>();
            ///Asignar a la variable el resultado de "llamar" al procedimiento almanceado
            modeloVista = this.modeloBD.sp_RetornaMonedas("").ToList();
            ///enviar a la vista el modelo
            return View(modeloVista);
        }

        public ActionResult MonedaNuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MonedaNuevo(sp_RetornaMonedas_Result modeloVista)
        {
            ///Variable que registra la cantidad de registro afectados si un procedimiento que ejecuta insert, update o delele
            ///no afecta registros implica que hubo un error
            int cantRegistroAfectado = 0;
            string resultado = "";

            try
            {
                cantRegistroAfectado = this.modeloBD.sp_InsertaMonedas(
                    modeloVista.Nombre,
                    modeloVista.Tipo_Cambio,
                    modeloVista.Codigo

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
            ///ModelState.Clear();
            return View();
        }


        public ActionResult MonedaModifica(int Id_Moneda)
        {

            ///Obtener el resgistro que se desea modificar
            ///utilizando el parámetro del método Id_Moneda
            sp_RetornaMonedas_Result modeloVista = new sp_RetornaMonedas_Result();
            modeloVista = this.modeloBD.sp_RetornaMonedas(Convert.ToString(Id_Moneda)).FirstOrDefault();
            ///enviar el modelo a la vista
            return View(modeloVista);
        }


        [HttpPost]
        public ActionResult MonedaModifica(sp_RetornaMonedas_Result modeloVista)
        {
            ///Variable que registra la cantidad de registro afectados si un procedimiento que ejecuta insert, update o delele
            ///no afecta registros implica que hubo un error
            int cantRegistroAfectado = 0;
            string resultado = "";

            try
            {
                cantRegistroAfectado = this.modeloBD.sp_ModificaMonedas(
                    modeloVista.Id_Moneda,
                    modeloVista.Nombre,
                    modeloVista.Tipo_Cambio,
                    modeloVista.Codigo

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
                    resultado = "Registro Modificado";
                }
                else
                {
                    resultado += "No se pudo Modificar";
                }
            }

            Response.Write("<script language=javascript>alert('" + resultado + "')</script>");
            ///ModelState.Clear();
            return View(modeloVista);
        }


        ///Eliminar 

        public ActionResult MonedaElimina(int Id_Moneda)
        {
            ///Obtener el resgistro que se desea modificar
            ///utilizando el parámetro del método Id_Moneda
            sp_RetornaMonedas_Result modeloVista = new sp_RetornaMonedas_Result();
            modeloVista = this.modeloBD.sp_RetornaMonedas(Convert.ToString(Id_Moneda)).FirstOrDefault();
            ///enviar el modelo a la vista
            return View(modeloVista);
        }


        [HttpPost]
        public ActionResult MonedaElimina(sp_RetornaMonedas_Result modeloVista)
        {
            ///Variable que registra la cantidad de registro afectados si un procedimiento que ejecuta insert, update o delele
            ///no afecta registros implica que hubo un error
            int cantRegistroAfectado = 0;
            string resultado = "";

            try
            {
                cantRegistroAfectado = this.modeloBD.sp_EliminaMonedas(
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
                    resultado = "Registro Eliminado";
                }
                else
                {
                    resultado += "No se pudo Eliminar";
                }
            }

            Response.Write("<script language=javascript>alert('" + resultado + "')</script>");
            ///ModelState.Clear();
            return View(modeloVista);
        }
    }
}