using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laboratorio1.Models
{
    public class Jugador
    {
        public int JugadorID { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public string Club { get; set; }
        public string Posicion { get; set; }
        public int Salario { get; set; }
    }
}