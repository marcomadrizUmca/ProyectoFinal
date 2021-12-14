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

        public ActionResult CuentasLista()

        {
            ///Crear variable que contiene los registros obtenidos 
            ///al invocar al procedimiento almancenado sp_RetornaClientes
            List<sp_RetornaCuentas_Result> modeloVista = new List<sp_RetornaCuentas_Result>();
            ///Asignar a la variable el resultado de "llamar" al procedimiento almanceado
            modeloVista = this.modeloBD.sp_RetornaCuentas("").ToList();
            ///enviar a la vista el modelo
            return View(modeloVista);
        }

        /// <summary>
        /// Agregar el tipo de clientes al viewbag, para que sean accedidas desde la vista, y es case sensitive
        /// </summary>
        void AgregarTipoClienteViewBag()
        {
            this.ViewBag.ListaCliente = this.modeloBD.sp_RetornaClientes("").ToList();


        }

        void AgregarTipoCuentaViewBag()
        {
            this.ViewBag.ListaTipoCuenta = this.modeloBD.sp_RetornaTipos_Cuentas("").ToList();
        }

        void AgregarTipoMonedaViewBag()
        {
            this.ViewBag.ListaMoneda = this.modeloBD.sp_RetornaMonedas("").ToList();
        }

        public ActionResult CuentaNueva()
        {
            this.AgregarTipoClienteViewBag();
            this.AgregarTipoCuentaViewBag();
            this.AgregarTipoMonedaViewBag();
            return View();
        }
       
         [HttpPost]

        public ActionResult CuentaNueva(sp_RetornaCuentas_Result modeloVista)
        {
            int cantRegistroAfectado = 0;
            string resultado =  "";
            decimal SaldoCuenta = 50000;
            decimal MonedaBd = 0;

            MonedaBd = this.modeloBD.sp_RetornaMonedas(Convert.ToString(modeloVista.Id_Moneda)).FirstOrDefault().Tipo_Cambio;

            SaldoCuenta = SaldoCuenta / MonedaBd;

            modeloVista.Saldo = SaldoCuenta;

            //if (Session["datosUsuario"] != null)
            //{
            //    sp_AutenticarUsuario_Result modelo = (sp_AutenticarUsuario_Result)this.Session["datosUsuario"];


            //    ViewBag.ListaCuenta = this.modeloBD.sp_RetornaCuentasUsuario(modelo.IdCliente).ToList();
            //}

            try
            {
                cantRegistroAfectado = this.modeloBD.sp_InsertaCuentas(
                    modeloVista.Numero_Cuenta,
                    modeloVista.Id_Cliente,
                    modeloVista.Id_Tipo_Cuenta,
                    modeloVista.Id_Moneda,
                    modeloVista.Saldo,
                    modeloVista.Estado 
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

            //if(cantRegistroAfectado > 0)
            //{
            //    resultado = "<p>Su deposito de" + modeloVista.Cedula + "fue genial" + modeloVista.NombreCliente;
                
            //}


            Response.Write("<script language=javascript>alert('" + resultado + "')</script>");
            this.AgregarTipoClienteViewBag();
            this.AgregarTipoCuentaViewBag();
            this.AgregarTipoMonedaViewBag();
            return View();
        }

        public ActionResult CuentaModifica(int Id_Cuenta)
        {
            ///Obtener el resgistro que se desea modificar
            ///utilizando el parámetro del método id_Cuenta

            sp_RetornaCuentas_Result modeloVista = new sp_RetornaCuentas_Result();
            modeloVista = this.modeloBD.sp_RetornaCuentas(Convert.ToString(Id_Cuenta)).FirstOrDefault();
            this.AgregarTipoClienteViewBag();
            this.AgregarTipoCuentaViewBag();
            this.AgregarTipoMonedaViewBag();
            ///enviar el modelo a la vista
            return View(modeloVista);
        }
        
        [HttpPost]
        public ActionResult CuentaModifica(sp_RetornaCuentas_Result modeloVista)
        {
            int cantRegistroAfectado = 0;
            string resultado = "";
            decimal SaldoCuenta = 50000;
            decimal MonedaBd = 0;



            MonedaBd = this.modeloBD.sp_RetornaMonedas(Convert.ToString(modeloVista.Id_Moneda)).FirstOrDefault().Tipo_Cambio;

            SaldoCuenta = SaldoCuenta / MonedaBd;

            modeloVista.Saldo = SaldoCuenta;

            try
            {
                cantRegistroAfectado = this.modeloBD.sp_ModificaCuentas(

                    modeloVista.Id_Cuenta,
                    modeloVista.Numero_Cuenta,
                    modeloVista.Id_Cliente,
                    modeloVista.Id_Tipo_Cuenta,
                    modeloVista.Id_Moneda,
                    modeloVista.Saldo,
                    modeloVista.Estado
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
            this.AgregarTipoCuentaViewBag();
            this.AgregarTipoMonedaViewBag();
            return View(modeloVista);
        }

        public ActionResult CuentaElimina(int Id_Cuenta)
        {
            ///Obtener el resgistro que se desea modificar
            ///utilizando el parámetro del método id_Cuenta

            sp_RetornaCuentas_Result modeloVista = new sp_RetornaCuentas_Result();
            modeloVista = this.modeloBD.sp_RetornaCuentas(Convert.ToString(Id_Cuenta)).FirstOrDefault();
            this.AgregarTipoClienteViewBag();
            this.AgregarTipoCuentaViewBag();
            this.AgregarTipoMonedaViewBag();
            ///enviar el modelo a la vista
            return View(modeloVista);
        }

        [HttpPost]
        public ActionResult CuentaElimina(sp_RetornaCuentas_Result modeloVista)
        {
            int cantRegistroAfectado = 0;
            string resultado = "";

            try
            {
                cantRegistroAfectado = this.modeloBD.sp_EliminaCuentas(

                    modeloVista.Id_Cuenta
                    
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
            this.AgregarTipoCuentaViewBag();
            this.AgregarTipoMonedaViewBag();
            return View(modeloVista);
        }


        [HttpPost]
        public ActionResult RetornaCuentasLista()
        {
            List<sp_RetornaCuentas_Result> listaCuentas =
               this.modeloBD.sp_RetornaCuentas("").ToList();
            return Json(new
            {
                resultado = listaCuentas
            });
        }
    }

}