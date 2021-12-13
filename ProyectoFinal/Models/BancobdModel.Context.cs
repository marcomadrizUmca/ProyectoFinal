﻿//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoFinal.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class bancobdEntities : DbContext
    {
        public bancobdEntities()
            : base("name=bancobdEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Cuentas> Cuentas { get; set; }
        public DbSet<Depositos> Depositos { get; set; }
        public DbSet<InicioSesion> InicioSesion { get; set; }
        public DbSet<Monedas> Monedas { get; set; }
        public DbSet<Retiros> Retiros { get; set; }
        public DbSet<sysdiagrams> sysdiagrams { get; set; }
        public DbSet<Tipos_Clientes> Tipos_Clientes { get; set; }
        public DbSet<Tipos_Cuentas> Tipos_Cuentas { get; set; }
        public DbSet<TipoUsuario> TipoUsuario { get; set; }
        public DbSet<Transferencias> Transferencias { get; set; }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual ObjectResult<sp_AutenticarUsuario_Result> sp_AutenticarUsuario(string usuario, string clave)
        {
            var usuarioParameter = usuario != null ?
                new ObjectParameter("Usuario", usuario) :
                new ObjectParameter("Usuario", typeof(string));
    
            var claveParameter = clave != null ?
                new ObjectParameter("Clave", clave) :
                new ObjectParameter("Clave", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_AutenticarUsuario_Result>("sp_AutenticarUsuario", usuarioParameter, claveParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_Depositos(Nullable<decimal> montoDeposito, Nullable<int> cuenta, Nullable<int> id_moneda)
        {
            var montoDepositoParameter = montoDeposito.HasValue ?
                new ObjectParameter("montoDeposito", montoDeposito) :
                new ObjectParameter("montoDeposito", typeof(decimal));
    
            var cuentaParameter = cuenta.HasValue ?
                new ObjectParameter("cuenta", cuenta) :
                new ObjectParameter("cuenta", typeof(int));
    
            var id_monedaParameter = id_moneda.HasValue ?
                new ObjectParameter("id_moneda", id_moneda) :
                new ObjectParameter("id_moneda", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_Depositos", montoDepositoParameter, cuentaParameter, id_monedaParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_EliminaCliente(Nullable<int> id_Cliente)
        {
            var id_ClienteParameter = id_Cliente.HasValue ?
                new ObjectParameter("Id_Cliente", id_Cliente) :
                new ObjectParameter("Id_Cliente", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_EliminaCliente", id_ClienteParameter);
        }
    
        public virtual int sp_EliminaCuentas(Nullable<int> id_Cuenta)
        {
            var id_CuentaParameter = id_Cuenta.HasValue ?
                new ObjectParameter("Id_Cuenta", id_Cuenta) :
                new ObjectParameter("Id_Cuenta", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_EliminaCuentas", id_CuentaParameter);
        }
    
        public virtual int sp_EliminaMonedas(Nullable<int> id_Moneda)
        {
            var id_MonedaParameter = id_Moneda.HasValue ?
                new ObjectParameter("Id_Moneda", id_Moneda) :
                new ObjectParameter("Id_Moneda", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_EliminaMonedas", id_MonedaParameter);
        }
    
        public virtual int sp_EliminaTiposClientes(Nullable<int> id_Tipo_Cliente)
        {
            var id_Tipo_ClienteParameter = id_Tipo_Cliente.HasValue ?
                new ObjectParameter("Id_Tipo_Cliente", id_Tipo_Cliente) :
                new ObjectParameter("Id_Tipo_Cliente", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_EliminaTiposClientes", id_Tipo_ClienteParameter);
        }
    
        public virtual int sp_EliminaTiposCuentas(Nullable<int> id_Tipo_Cuenta)
        {
            var id_Tipo_CuentaParameter = id_Tipo_Cuenta.HasValue ?
                new ObjectParameter("Id_Tipo_Cuenta", id_Tipo_Cuenta) :
                new ObjectParameter("Id_Tipo_Cuenta", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_EliminaTiposCuentas", id_Tipo_CuentaParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_InsertaClientes(Nullable<int> cedula, string genero, Nullable<System.DateTime> fecha_Nacimiento, string nombre, string primer_Apellido, string segundo_Apellido, string direccion_Fisica, Nullable<int> telefono_Principal, Nullable<int> telefono_Secundario, string correo_Electronico, Nullable<int> tipo_Cliente, string clave_Acceso)
        {
            var cedulaParameter = cedula.HasValue ?
                new ObjectParameter("Cedula", cedula) :
                new ObjectParameter("Cedula", typeof(int));
    
            var generoParameter = genero != null ?
                new ObjectParameter("Genero", genero) :
                new ObjectParameter("Genero", typeof(string));
    
            var fecha_NacimientoParameter = fecha_Nacimiento.HasValue ?
                new ObjectParameter("Fecha_Nacimiento", fecha_Nacimiento) :
                new ObjectParameter("Fecha_Nacimiento", typeof(System.DateTime));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var primer_ApellidoParameter = primer_Apellido != null ?
                new ObjectParameter("Primer_Apellido", primer_Apellido) :
                new ObjectParameter("Primer_Apellido", typeof(string));
    
            var segundo_ApellidoParameter = segundo_Apellido != null ?
                new ObjectParameter("Segundo_Apellido", segundo_Apellido) :
                new ObjectParameter("Segundo_Apellido", typeof(string));
    
            var direccion_FisicaParameter = direccion_Fisica != null ?
                new ObjectParameter("Direccion_Fisica", direccion_Fisica) :
                new ObjectParameter("Direccion_Fisica", typeof(string));
    
            var telefono_PrincipalParameter = telefono_Principal.HasValue ?
                new ObjectParameter("Telefono_Principal", telefono_Principal) :
                new ObjectParameter("Telefono_Principal", typeof(int));
    
            var telefono_SecundarioParameter = telefono_Secundario.HasValue ?
                new ObjectParameter("Telefono_Secundario", telefono_Secundario) :
                new ObjectParameter("Telefono_Secundario", typeof(int));
    
            var correo_ElectronicoParameter = correo_Electronico != null ?
                new ObjectParameter("Correo_Electronico", correo_Electronico) :
                new ObjectParameter("Correo_Electronico", typeof(string));
    
            var tipo_ClienteParameter = tipo_Cliente.HasValue ?
                new ObjectParameter("Tipo_Cliente", tipo_Cliente) :
                new ObjectParameter("Tipo_Cliente", typeof(int));
    
            var clave_AccesoParameter = clave_Acceso != null ?
                new ObjectParameter("Clave_Acceso", clave_Acceso) :
                new ObjectParameter("Clave_Acceso", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_InsertaClientes", cedulaParameter, generoParameter, fecha_NacimientoParameter, nombreParameter, primer_ApellidoParameter, segundo_ApellidoParameter, direccion_FisicaParameter, telefono_PrincipalParameter, telefono_SecundarioParameter, correo_ElectronicoParameter, tipo_ClienteParameter, clave_AccesoParameter);
        }
    
        public virtual int sp_InsertaCuentas(string numero_Cuenta, Nullable<int> cliente, Nullable<int> tipo_Cuenta, Nullable<int> moneda, Nullable<decimal> saldo, string estado)
        {
            var numero_CuentaParameter = numero_Cuenta != null ?
                new ObjectParameter("Numero_Cuenta", numero_Cuenta) :
                new ObjectParameter("Numero_Cuenta", typeof(string));
    
            var clienteParameter = cliente.HasValue ?
                new ObjectParameter("Cliente", cliente) :
                new ObjectParameter("Cliente", typeof(int));
    
            var tipo_CuentaParameter = tipo_Cuenta.HasValue ?
                new ObjectParameter("Tipo_Cuenta", tipo_Cuenta) :
                new ObjectParameter("Tipo_Cuenta", typeof(int));
    
            var monedaParameter = moneda.HasValue ?
                new ObjectParameter("Moneda", moneda) :
                new ObjectParameter("Moneda", typeof(int));
    
            var saldoParameter = saldo.HasValue ?
                new ObjectParameter("Saldo", saldo) :
                new ObjectParameter("Saldo", typeof(decimal));
    
            var estadoParameter = estado != null ?
                new ObjectParameter("Estado", estado) :
                new ObjectParameter("Estado", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_InsertaCuentas", numero_CuentaParameter, clienteParameter, tipo_CuentaParameter, monedaParameter, saldoParameter, estadoParameter);
        }
    
        public virtual int sp_InsertaDepositos(Nullable<decimal> monto_Deposito, Nullable<int> id_Cuenta, Nullable<int> id_Moneda)
        {
            var monto_DepositoParameter = monto_Deposito.HasValue ?
                new ObjectParameter("Monto_Deposito", monto_Deposito) :
                new ObjectParameter("Monto_Deposito", typeof(decimal));
    
            var id_CuentaParameter = id_Cuenta.HasValue ?
                new ObjectParameter("Id_Cuenta", id_Cuenta) :
                new ObjectParameter("Id_Cuenta", typeof(int));
    
            var id_MonedaParameter = id_Moneda.HasValue ?
                new ObjectParameter("Id_Moneda", id_Moneda) :
                new ObjectParameter("Id_Moneda", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_InsertaDepositos", monto_DepositoParameter, id_CuentaParameter, id_MonedaParameter);
        }
    
        public virtual int sp_InsertaMonedas(string nombre, Nullable<decimal> tipo_Cambio, string codigo)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var tipo_CambioParameter = tipo_Cambio.HasValue ?
                new ObjectParameter("Tipo_Cambio", tipo_Cambio) :
                new ObjectParameter("Tipo_Cambio", typeof(decimal));
    
            var codigoParameter = codigo != null ?
                new ObjectParameter("Codigo", codigo) :
                new ObjectParameter("Codigo", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_InsertaMonedas", nombreParameter, tipo_CambioParameter, codigoParameter);
        }
    
        public virtual int sp_InsertaRetiros(Nullable<int> id_Cuenta, Nullable<decimal> monto_Retiro, Nullable<System.DateTime> fecha, Nullable<int> id_Moneda)
        {
            var id_CuentaParameter = id_Cuenta.HasValue ?
                new ObjectParameter("Id_Cuenta", id_Cuenta) :
                new ObjectParameter("Id_Cuenta", typeof(int));
    
            var monto_RetiroParameter = monto_Retiro.HasValue ?
                new ObjectParameter("Monto_Retiro", monto_Retiro) :
                new ObjectParameter("Monto_Retiro", typeof(decimal));
    
            var fechaParameter = fecha.HasValue ?
                new ObjectParameter("Fecha", fecha) :
                new ObjectParameter("Fecha", typeof(System.DateTime));
    
            var id_MonedaParameter = id_Moneda.HasValue ?
                new ObjectParameter("Id_Moneda", id_Moneda) :
                new ObjectParameter("Id_Moneda", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_InsertaRetiros", id_CuentaParameter, monto_RetiroParameter, fechaParameter, id_MonedaParameter);
        }
    
        public virtual int sp_InsertaTipos_Clientes(string nombre, string descripcion)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("Descripcion", descripcion) :
                new ObjectParameter("Descripcion", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_InsertaTipos_Clientes", nombreParameter, descripcionParameter);
        }
    
        public virtual int sp_InsertaTipos_Cuentas(string nombre, string codigo)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var codigoParameter = codigo != null ?
                new ObjectParameter("Codigo", codigo) :
                new ObjectParameter("Codigo", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_InsertaTipos_Cuentas", nombreParameter, codigoParameter);
        }
    
        public virtual int sp_InsertaTransferencias(Nullable<int> cuenta_Origen, Nullable<int> cuenta_Destino, Nullable<int> id_Moneda, Nullable<decimal> monto_Transferencia)
        {
            var cuenta_OrigenParameter = cuenta_Origen.HasValue ?
                new ObjectParameter("Cuenta_Origen", cuenta_Origen) :
                new ObjectParameter("Cuenta_Origen", typeof(int));
    
            var cuenta_DestinoParameter = cuenta_Destino.HasValue ?
                new ObjectParameter("Cuenta_Destino", cuenta_Destino) :
                new ObjectParameter("Cuenta_Destino", typeof(int));
    
            var id_MonedaParameter = id_Moneda.HasValue ?
                new ObjectParameter("Id_Moneda", id_Moneda) :
                new ObjectParameter("Id_Moneda", typeof(int));
    
            var monto_TransferenciaParameter = monto_Transferencia.HasValue ?
                new ObjectParameter("Monto_Transferencia", monto_Transferencia) :
                new ObjectParameter("Monto_Transferencia", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_InsertaTransferencias", cuenta_OrigenParameter, cuenta_DestinoParameter, id_MonedaParameter, monto_TransferenciaParameter);
        }
    
        public virtual int sp_ModificaClientes(Nullable<int> id_Cliente, Nullable<int> cedula, string genero, Nullable<System.DateTime> fecha_Nacimiento, string nombre, string primer_Apellido, string segundo_Apellido, string direccion_Fisica, Nullable<int> telefono_Principal, Nullable<int> telefono_Secundario, string correo_Electronico, Nullable<int> tipo_Cliente, string clave_Acceso)
        {
            var id_ClienteParameter = id_Cliente.HasValue ?
                new ObjectParameter("id_Cliente", id_Cliente) :
                new ObjectParameter("id_Cliente", typeof(int));
    
            var cedulaParameter = cedula.HasValue ?
                new ObjectParameter("Cedula", cedula) :
                new ObjectParameter("Cedula", typeof(int));
    
            var generoParameter = genero != null ?
                new ObjectParameter("Genero", genero) :
                new ObjectParameter("Genero", typeof(string));
    
            var fecha_NacimientoParameter = fecha_Nacimiento.HasValue ?
                new ObjectParameter("Fecha_Nacimiento", fecha_Nacimiento) :
                new ObjectParameter("Fecha_Nacimiento", typeof(System.DateTime));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var primer_ApellidoParameter = primer_Apellido != null ?
                new ObjectParameter("Primer_Apellido", primer_Apellido) :
                new ObjectParameter("Primer_Apellido", typeof(string));
    
            var segundo_ApellidoParameter = segundo_Apellido != null ?
                new ObjectParameter("Segundo_Apellido", segundo_Apellido) :
                new ObjectParameter("Segundo_Apellido", typeof(string));
    
            var direccion_FisicaParameter = direccion_Fisica != null ?
                new ObjectParameter("Direccion_Fisica", direccion_Fisica) :
                new ObjectParameter("Direccion_Fisica", typeof(string));
    
            var telefono_PrincipalParameter = telefono_Principal.HasValue ?
                new ObjectParameter("Telefono_Principal", telefono_Principal) :
                new ObjectParameter("Telefono_Principal", typeof(int));
    
            var telefono_SecundarioParameter = telefono_Secundario.HasValue ?
                new ObjectParameter("Telefono_Secundario", telefono_Secundario) :
                new ObjectParameter("Telefono_Secundario", typeof(int));
    
            var correo_ElectronicoParameter = correo_Electronico != null ?
                new ObjectParameter("Correo_Electronico", correo_Electronico) :
                new ObjectParameter("Correo_Electronico", typeof(string));
    
            var tipo_ClienteParameter = tipo_Cliente.HasValue ?
                new ObjectParameter("Tipo_Cliente", tipo_Cliente) :
                new ObjectParameter("Tipo_Cliente", typeof(int));
    
            var clave_AccesoParameter = clave_Acceso != null ?
                new ObjectParameter("Clave_Acceso", clave_Acceso) :
                new ObjectParameter("Clave_Acceso", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_ModificaClientes", id_ClienteParameter, cedulaParameter, generoParameter, fecha_NacimientoParameter, nombreParameter, primer_ApellidoParameter, segundo_ApellidoParameter, direccion_FisicaParameter, telefono_PrincipalParameter, telefono_SecundarioParameter, correo_ElectronicoParameter, tipo_ClienteParameter, clave_AccesoParameter);
        }
    
        public virtual int sp_ModificaCuentas(Nullable<int> id_Cuenta, string numero_Cuenta, Nullable<int> cliente, Nullable<int> tipo_Cuenta, Nullable<int> moneda, Nullable<decimal> saldo, string estado)
        {
            var id_CuentaParameter = id_Cuenta.HasValue ?
                new ObjectParameter("Id_Cuenta", id_Cuenta) :
                new ObjectParameter("Id_Cuenta", typeof(int));
    
            var numero_CuentaParameter = numero_Cuenta != null ?
                new ObjectParameter("Numero_Cuenta", numero_Cuenta) :
                new ObjectParameter("Numero_Cuenta", typeof(string));
    
            var clienteParameter = cliente.HasValue ?
                new ObjectParameter("Cliente", cliente) :
                new ObjectParameter("Cliente", typeof(int));
    
            var tipo_CuentaParameter = tipo_Cuenta.HasValue ?
                new ObjectParameter("Tipo_Cuenta", tipo_Cuenta) :
                new ObjectParameter("Tipo_Cuenta", typeof(int));
    
            var monedaParameter = moneda.HasValue ?
                new ObjectParameter("Moneda", moneda) :
                new ObjectParameter("Moneda", typeof(int));
    
            var saldoParameter = saldo.HasValue ?
                new ObjectParameter("Saldo", saldo) :
                new ObjectParameter("Saldo", typeof(decimal));
    
            var estadoParameter = estado != null ?
                new ObjectParameter("Estado", estado) :
                new ObjectParameter("Estado", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_ModificaCuentas", id_CuentaParameter, numero_CuentaParameter, clienteParameter, tipo_CuentaParameter, monedaParameter, saldoParameter, estadoParameter);
        }
    
        public virtual int sp_ModificaMonedas(Nullable<int> id_Moneda, string nombre, Nullable<decimal> tipo_Cambio, string codigo)
        {
            var id_MonedaParameter = id_Moneda.HasValue ?
                new ObjectParameter("Id_Moneda", id_Moneda) :
                new ObjectParameter("Id_Moneda", typeof(int));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var tipo_CambioParameter = tipo_Cambio.HasValue ?
                new ObjectParameter("Tipo_Cambio", tipo_Cambio) :
                new ObjectParameter("Tipo_Cambio", typeof(decimal));
    
            var codigoParameter = codigo != null ?
                new ObjectParameter("Codigo", codigo) :
                new ObjectParameter("Codigo", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_ModificaMonedas", id_MonedaParameter, nombreParameter, tipo_CambioParameter, codigoParameter);
        }
    
        public virtual int sp_ModificaTiposClientes(Nullable<int> id_Tipo_Cliente, string nombre, string descripcion)
        {
            var id_Tipo_ClienteParameter = id_Tipo_Cliente.HasValue ?
                new ObjectParameter("Id_Tipo_Cliente", id_Tipo_Cliente) :
                new ObjectParameter("Id_Tipo_Cliente", typeof(int));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("Descripcion", descripcion) :
                new ObjectParameter("Descripcion", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_ModificaTiposClientes", id_Tipo_ClienteParameter, nombreParameter, descripcionParameter);
        }
    
        public virtual int sp_ModificaTiposCuentas(Nullable<int> id_Tipo_Cuenta, string nombre, string codigo)
        {
            var id_Tipo_CuentaParameter = id_Tipo_Cuenta.HasValue ?
                new ObjectParameter("Id_Tipo_Cuenta", id_Tipo_Cuenta) :
                new ObjectParameter("Id_Tipo_Cuenta", typeof(int));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var codigoParameter = codigo != null ?
                new ObjectParameter("Codigo", codigo) :
                new ObjectParameter("Codigo", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_ModificaTiposCuentas", id_Tipo_CuentaParameter, nombreParameter, codigoParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_Retiro(Nullable<int> cuenta, Nullable<decimal> monto)
        {
            var cuentaParameter = cuenta.HasValue ?
                new ObjectParameter("cuenta", cuenta) :
                new ObjectParameter("cuenta", typeof(int));
    
            var montoParameter = monto.HasValue ?
                new ObjectParameter("monto", monto) :
                new ObjectParameter("monto", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_Retiro", cuentaParameter, montoParameter);
        }
    
        public virtual ObjectResult<sp_RetornaClientes_Result> sp_RetornaClientes(string id_Cliente)
        {
            var id_ClienteParameter = id_Cliente != null ?
                new ObjectParameter("Id_Cliente", id_Cliente) :
                new ObjectParameter("Id_Cliente", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_RetornaClientes_Result>("sp_RetornaClientes", id_ClienteParameter);
        }
    
        public virtual ObjectResult<sp_RetornaClientesId_Result> sp_RetornaClientesId(Nullable<int> id_Cliente)
        {
            var id_ClienteParameter = id_Cliente.HasValue ?
                new ObjectParameter("Id_Cliente", id_Cliente) :
                new ObjectParameter("Id_Cliente", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_RetornaClientesId_Result>("sp_RetornaClientesId", id_ClienteParameter);
        }
    
        public virtual ObjectResult<sp_RetornaCuentas_Result> sp_RetornaCuentas(string id_Cuenta)
        {
            var id_CuentaParameter = id_Cuenta != null ?
                new ObjectParameter("Id_Cuenta", id_Cuenta) :
                new ObjectParameter("Id_Cuenta", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_RetornaCuentas_Result>("sp_RetornaCuentas", id_CuentaParameter);
        }
    
        public virtual ObjectResult<sp_RetornaCuentasUsuario_Result> sp_RetornaCuentasUsuario(Nullable<int> id_cliente)
        {
            var id_clienteParameter = id_cliente.HasValue ?
                new ObjectParameter("id_cliente", id_cliente) :
                new ObjectParameter("id_cliente", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_RetornaCuentasUsuario_Result>("sp_RetornaCuentasUsuario", id_clienteParameter);
        }
    
        public virtual ObjectResult<sp_RetornaDepositos_Result> sp_RetornaDepositos(string id_Deposito)
        {
            var id_DepositoParameter = id_Deposito != null ?
                new ObjectParameter("Id_Deposito", id_Deposito) :
                new ObjectParameter("Id_Deposito", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_RetornaDepositos_Result>("sp_RetornaDepositos", id_DepositoParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> sp_RetornaFechas(string id_Cuenta)
        {
            var id_CuentaParameter = id_Cuenta != null ?
                new ObjectParameter("Id_Cuenta", id_Cuenta) :
                new ObjectParameter("Id_Cuenta", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("sp_RetornaFechas", id_CuentaParameter);
        }
    
        public virtual ObjectResult<sp_RetornaInicioSesion_Result> sp_RetornaInicioSesion(string id_InicioSesion)
        {
            var id_InicioSesionParameter = id_InicioSesion != null ?
                new ObjectParameter("Id_InicioSesion", id_InicioSesion) :
                new ObjectParameter("Id_InicioSesion", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_RetornaInicioSesion_Result>("sp_RetornaInicioSesion", id_InicioSesionParameter);
        }
    
        public virtual ObjectResult<sp_RetornaMonedas_Result> sp_RetornaMonedas(string id_Moneda)
        {
            var id_MonedaParameter = id_Moneda != null ?
                new ObjectParameter("Id_Moneda", id_Moneda) :
                new ObjectParameter("Id_Moneda", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_RetornaMonedas_Result>("sp_RetornaMonedas", id_MonedaParameter);
        }
    
        public virtual ObjectResult<sp_RetornaRetiros_Result> sp_RetornaRetiros(string id_Retiro)
        {
            var id_RetiroParameter = id_Retiro != null ?
                new ObjectParameter("Id_Retiro", id_Retiro) :
                new ObjectParameter("Id_Retiro", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_RetornaRetiros_Result>("sp_RetornaRetiros", id_RetiroParameter);
        }
    
        public virtual ObjectResult<sp_RetornaTipo_Clientes_Result> sp_RetornaTipo_Clientes(string id_Tipo_Cliente)
        {
            var id_Tipo_ClienteParameter = id_Tipo_Cliente != null ?
                new ObjectParameter("Id_Tipo_Cliente", id_Tipo_Cliente) :
                new ObjectParameter("Id_Tipo_Cliente", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_RetornaTipo_Clientes_Result>("sp_RetornaTipo_Clientes", id_Tipo_ClienteParameter);
        }
    
        public virtual ObjectResult<sp_RetornaTipos_Cuentas_Result> sp_RetornaTipos_Cuentas(string id_Tipo_Cuenta)
        {
            var id_Tipo_CuentaParameter = id_Tipo_Cuenta != null ?
                new ObjectParameter("Id_Tipo_Cuenta", id_Tipo_Cuenta) :
                new ObjectParameter("Id_Tipo_Cuenta", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_RetornaTipos_Cuentas_Result>("sp_RetornaTipos_Cuentas", id_Tipo_CuentaParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        public virtual ObjectResult<sp_RetornaTransferencias_Result> sp_RetornaTransferencias(string id_Transferencia)
        {
            var id_TransferenciaParameter = id_Transferencia != null ?
                new ObjectParameter("Id_Transferencia", id_Transferencia) :
                new ObjectParameter("Id_Transferencia", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_RetornaTransferencias_Result>("sp_RetornaTransferencias", id_TransferenciaParameter);
        }
    
        public virtual int SP_Transferencias(Nullable<int> cuenta_Origen, Nullable<int> cuenta_Destino, Nullable<decimal> monto_Transferencia, string detalle)
        {
            var cuenta_OrigenParameter = cuenta_Origen.HasValue ?
                new ObjectParameter("Cuenta_Origen", cuenta_Origen) :
                new ObjectParameter("Cuenta_Origen", typeof(int));
    
            var cuenta_DestinoParameter = cuenta_Destino.HasValue ?
                new ObjectParameter("Cuenta_Destino", cuenta_Destino) :
                new ObjectParameter("Cuenta_Destino", typeof(int));
    
            var monto_TransferenciaParameter = monto_Transferencia.HasValue ?
                new ObjectParameter("Monto_Transferencia", monto_Transferencia) :
                new ObjectParameter("Monto_Transferencia", typeof(decimal));
    
            var detalleParameter = detalle != null ?
                new ObjectParameter("Detalle", detalle) :
                new ObjectParameter("Detalle", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_Transferencias", cuenta_OrigenParameter, cuenta_DestinoParameter, monto_TransferenciaParameter, detalleParameter);
        }
    }
}
