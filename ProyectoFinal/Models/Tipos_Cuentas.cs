//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Tipos_Cuentas
    {
        public Tipos_Cuentas()
        {
            this.Cuentas = new HashSet<Cuentas>();
        }
    
        public int Id_Tipo_Cuenta { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
    
        public virtual ICollection<Cuentas> Cuentas { get; set; }
    }
}
