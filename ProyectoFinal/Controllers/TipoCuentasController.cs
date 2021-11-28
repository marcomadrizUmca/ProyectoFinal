using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoFinal.Models;

namespace ProyectoFinal.Controllers
{
    public class TipoCuentasController : Controller
    {
        // Modelo de la base de datos
        bancobdEntities modeloBD = new bancobdEntities();

        // GET: TipoCuentas
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TipoCuentasLista()

        {
            ///Crear variable que contiene los registros obtenidos 
            ///al invocar al procedimiento almancenado sp_RetornaClientes
            List<sp_RetornaTipos_Cuentas_Result> modeloVista = new List<sp_RetornaTipos_Cuentas_Result>();
            ///Asignar a la variable el resultado de "llamar" al procedimiento almanceado
            modeloVista = this.modeloBD.sp_RetornaTipos_Cuentas("").ToList();
            ///enviar a la vista el modelo
            return View(modeloVista);
        }

        public ActionResult TipoCuentaNueva()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TipoCuentaNueva(sp_RetornaTipos_Cuentas_Result modeloVista)
        {
            ///Variable que registra la cantidad de registro afectados si un procedimiento que ejecuta insert, update o delele
            ///no afecta registros implica que hubo un error
            int cantRegistroAfectado = 0;
            string resultado = "";

            try
            {
                cantRegistroAfectado = this.modeloBD.sp_InsertaTipos_Cuentas(
                    modeloVista.Nombre,
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


        public ActionResult TipoCuentaModifica(int Id_Tipo_Cuenta)
        {

            ///Obtener el resgistro que se desea modificar
            ///utilizando el parámetro del método Id_Tipo_Cuenta
            sp_RetornaTipos_Cuentas_Result modeloVista = new sp_RetornaTipos_Cuentas_Result();
            modeloVista = this.modeloBD.sp_RetornaTipos_Cuentas(Convert.ToString(Id_Tipo_Cuenta)).FirstOrDefault();
            ///enviar el modelo a la vista
            return View(modeloVista);
        }


        [HttpPost]
        public ActionResult TipoCuentaModifica(sp_RetornaTipos_Cuentas_Result modeloVista)
        {
            ///Variable que registra la cantidad de registro afectados si un procedimiento que ejecuta insert, update o delele
            ///no afecta registros implica que hubo un error
            int cantRegistroAfectado = 0;
            string resultado = "";

            try
            {
                cantRegistroAfectado = this.modeloBD.sp_ModificaTiposCuentas(
                    modeloVista.Id_Tipo_Cuenta,
                    modeloVista.Nombre,
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

        public ActionResult TipoCuentasElimina(int Id_Tipo_Cuenta)
        {
            ///Obtener el resgistro que se desea modificar
            ///utilizando el parámetro del método id_Cliente
            sp_RetornaTipos_Cuentas_Result modeloVista = new sp_RetornaTipos_Cuentas_Result();
            modeloVista = this.modeloBD.sp_RetornaTipos_Cuentas(Convert.ToString(Id_Tipo_Cuenta)).FirstOrDefault();
            ///enviar el modelo a la vista
            return View(modeloVista);
        }


        [HttpPost]
        public ActionResult TipoCuentasElimina(sp_RetornaTipos_Cuentas_Result modeloVista)
        {
            ///Variable que registra la cantidad de registro afectados si un procedimiento que ejecuta insert, update o delele
            ///no afecta registros implica que hubo un error
            int cantRegistroAfectado = 0;
            string resultado = "";

            try
            {
                cantRegistroAfectado = this.modeloBD.sp_EliminaTiposCuentas(
                    modeloVista.Id_Tipo_Cuenta
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