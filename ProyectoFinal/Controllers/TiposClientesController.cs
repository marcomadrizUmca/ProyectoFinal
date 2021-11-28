using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoFinal.Models;

namespace ProyectoFinal.Controllers
{
    public class TiposClientesController : Controller
    {
        // Modelo de la base de datos
        bancobdEntities modeloBD = new bancobdEntities();

        // GET: TiposClientes
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult TipoClienteLista()

        {
            ///Crear variable que contiene los registros obtenidos 
            ///al invocar al procedimiento almancenado sp_RetornaClientes
            List<sp_RetornaTipo_Clientes_Result> modeloVista = new List<sp_RetornaTipo_Clientes_Result>();
            ///Asignar a la variable el resultado de "llamar" al procedimiento almanceado
            modeloVista = this.modeloBD.sp_RetornaTipo_Clientes("").ToList();
            ///enviar a la vista el modelo
            return View(modeloVista);
        }

        public ActionResult TipoClienteNuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TipoClienteNuevo(sp_RetornaTipo_Clientes_Result modeloVista)
        {
            ///Variable que registra la cantidad de registro afectados si un procedimiento que ejecuta insert, update o delele
            ///no afecta registros implica que hubo un error
            int cantRegistroAfectado = 0;
            string resultado = "";

            try
            {
                cantRegistroAfectado = this.modeloBD.sp_InsertaTipos_Clientes(
                    modeloVista.Nombre,
                    modeloVista.Descripcion

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


        public ActionResult TipoClienteModifica(int Id_Tipo_Cliente)
        {

            ///Obtener el resgistro que se desea modificar
            ///utilizando el parámetro del método id_Cliente
            sp_RetornaTipo_Clientes_Result modeloVista = new sp_RetornaTipo_Clientes_Result();
            modeloVista = this.modeloBD.sp_RetornaTipo_Clientes(Convert.ToString(Id_Tipo_Cliente)).FirstOrDefault();
            ///enviar el modelo a la vista
            return View(modeloVista);
        }


        [HttpPost]
        public ActionResult TipoClienteModifica(sp_RetornaTipo_Clientes_Result modeloVista)
        {
            ///Variable que registra la cantidad de registro afectados si un procedimiento que ejecuta insert, update o delele
            ///no afecta registros implica que hubo un error
            int cantRegistroAfectado = 0;
            string resultado = "";

            try
            {
                cantRegistroAfectado = this.modeloBD.sp_ModificaTiposClientes(
                    modeloVista.Id_Tipo_Cliente,
                    modeloVista.Nombre,
                    modeloVista.Descripcion

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

        public ActionResult TipoClienteElimina(int Id_Tipo_Cliente)
        {
            ///Obtener el resgistro que se desea modificar
            ///utilizando el parámetro del método id_Cliente
            sp_RetornaTipo_Clientes_Result modeloVista = new sp_RetornaTipo_Clientes_Result();
            modeloVista = this.modeloBD.sp_RetornaTipo_Clientes(Convert.ToString(Id_Tipo_Cliente)).FirstOrDefault();
            ///enviar el modelo a la vista
            return View(modeloVista);
        }


        [HttpPost]
        public ActionResult TipoClienteElimina(sp_RetornaTipo_Clientes_Result modeloVista)
        {
            ///Variable que registra la cantidad de registro afectados si un procedimiento que ejecuta insert, update o delele
            ///no afecta registros implica que hubo un error
            int cantRegistroAfectado = 0;
            string resultado = "";

            try
            {
                cantRegistroAfectado = this.modeloBD.sp_EliminaTiposClientes(
                    modeloVista.Id_Tipo_Cliente     
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