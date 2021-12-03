using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoFinal.Models
{
    public class Correo
    {
        public string Emisor
        {
            get;
            set;
        }
        public string Receptor
        {
            get;
            set;
        }
        public string Sujeto
        {
            get;
            set;
        }
        public string Cuerpo
        {
            get;
            set;
        }
    }
}