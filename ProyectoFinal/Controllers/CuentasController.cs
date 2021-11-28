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
            sp_RetornaMonedas_Result MonedaBD = new sp_RetornaMonedas_Result();

            MonedaBD.Id_Moneda = Convert.ToInt32(MonedaBD.Tipo_Cambio); 

            SaldoCuenta = SaldoCuenta / MonedaBD.Tipo_Cambio;

            SaldoCuenta = modeloVista.Saldo;

            try
            {
                cantRegistroAfectado = this.modeloBD.sp_InsertaCuentas(
                    modeloVista.NombreCuenta,
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

            Response.Write("<script language=javascript>alert('" + resultado + "')</script>");
            this.AgregarTipoClienteViewBag();
            this.AgregarTipoCuentaViewBag();
            this.AgregarTipoMonedaViewBag();
            return View();
        }








    }

}