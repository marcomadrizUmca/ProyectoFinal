using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoFinal.Models;

namespace ProyectoFinal.Controllers
{

    public class ClientesController : Controller
    {
        // Modelo de la base de datos
        bancobdEntities modeloBD = new bancobdEntities();


        // GET: Clientes
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult ClienteNuevo()
        {
            this.AgregarTipoClienteViewBag();
            ///sp_RetornaClientes_Result objetoCliente = new sp_RetornaClientes_Result();
            return View();
        }


        [HttpPost]
        public ActionResult ClienteNuevo(sp_RetornaClientes_Result modeloVista)
        {
            ///Variable que registra la cantidad de registro afectados si un procedimiento que ejecuta insert, update o delele
            ///no afecta registros implica que hubo un error
            int cantRegistroAfectado = 0;
            string resultado = "";

            try
            {
                cantRegistroAfectado = this.modeloBD.sp_InsertaClientes(
                    modeloVista.Cedula,
                    modeloVista.Genero,
                    modeloVista.Fecha_Nacimiento,
                    modeloVista.Nombre,
                    modeloVista.Primer_Apellido,
                    modeloVista.Segundo_Apellido,
                    modeloVista.Direccion_Fisica,
                    modeloVista.Telefono_Principal,
                    modeloVista.Telefono_Secundario,
                    modeloVista.Correo_Electronico,
                    modeloVista.Tipo_Cliente,
                    modeloVista.Clave_Acceso
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

            Response.Write("<script language=javascript>alert('"+resultado+"')</script>");
            this.AgregarTipoClienteViewBag();
            ///ModelState.Clear();
            return View(modeloVista);
        }



        /// <summary>
        /// Agregar el tipo de clientes al viewbag, para que sean accedidas desde la vista, y es case sensitive
        /// </summary>
        void AgregarTipoClienteViewBag()
        {
           /* List<SelectListItem> vlo_lst_Lista = new List<SelectListItem>();

            foreach (var item in this.modeloBD.sp_RetornaTipo_Clientes("").ToList())
            {
                vlo_lst_Lista.Add(new SelectListItem() { Text = item.Nombre, Value = item.Id_Tipo_Cliente.ToString() });
            }

            ViewBag.ListaTiposClientes = vlo_lst_Lista;*/
            
            
            this.ViewBag.ListaTipoCliente = this.modeloBD.sp_RetornaTipo_Clientes("").ToList();
        }

        public ActionResult ClienteLista()

        {
            ///Crear variable que contiene los registros obtenidos 
            ///al invocar al procedimiento almancenado sp_RetornaClientes
            List<sp_RetornaClientes_Result> modeloVista = new List<sp_RetornaClientes_Result>();
            ///Asignar a la variable el resultado de "llamar" al procedimiento almanceado
            modeloVista = this.modeloBD.sp_RetornaClientes("").ToList();
            ///enviar a la vista el modelo
            return View(modeloVista);
        }

        public ActionResult ClienteModifica (int Id_Cliente)
        {
           

            ///Obtener el resgistro que se desea modificar
            ///utilizando el parámetro del método id_Cliente

            sp_RetornaClientesId_Result modeloVista = new sp_RetornaClientesId_Result();
            modeloVista = this.modeloBD.sp_RetornaClientesId(Id_Cliente).FirstOrDefault();
            this.AgregarTipoClienteViewBag();
            ///enviar el modelo a la vista
            return View(modeloVista);

        }

        [HttpPost]
        public ActionResult ClienteModifica(sp_RetornaClientesId_Result modeloVista)
        {
            ///Variable que registra la cantidad de registro afectados si un procedimiento que ejecuta insert, update o delele
            ///no afecta registros implica que hubo un error
            int cantRegistroAfectado = 0;
            string resultado = "";

            try
            {
                cantRegistroAfectado = this.modeloBD.sp_ModificaClientes(
                    modeloVista.Id_Cliente,
                    modeloVista.Cedula,
                    modeloVista.Genero,
                    modeloVista.Fecha_Nacimiento,
                    modeloVista.Nombre,
                    modeloVista.Primer_Apellido,
                    modeloVista.Segundo_Apellido,
                    modeloVista.Direccion_Fisica,
                    modeloVista.Telefono_Principal,
                    modeloVista.Telefono_Secundario,
                    modeloVista.Correo_Electronico,
                    modeloVista.Tipo_Cliente,
                    modeloVista.Clave_Acceso
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
            this.AgregarTipoClienteViewBag();
            return View(modeloVista);
        }


        public ActionResult ClienteElimina(int Id_Cliente)
        {
            ///Obtener el resgistro que se desea modificar
            ///utilizando el parámetro del método id_Cliente
            sp_RetornaClientesId_Result modeloVista = new sp_RetornaClientesId_Result();
            modeloVista = this.modeloBD.sp_RetornaClientesId(Id_Cliente).FirstOrDefault();
            this.AgregarTipoClienteViewBag();
            ///enviar el modelo a la vista
            return View(modeloVista);
        }

        [HttpPost]
        public ActionResult ClienteElimina(sp_RetornaClientesId_Result modeloVista)
        {
            ///Variable que registra la cantidad de registro afectados si un procedimiento que ejecuta insert, update o delele
            ///no afecta registros implica que hubo un error
            int cantRegistroAfectado = 0;
            string resultado = "";

            try
            {
                cantRegistroAfectado = this.modeloBD.sp_EliminaCliente(
                    modeloVista.Id_Cliente               
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
            this.AgregarTipoClienteViewBag();
            return View(modeloVista);
        }

    }
}