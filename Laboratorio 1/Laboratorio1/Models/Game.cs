using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laboratorio1.Models
{
    public class Game
    {
        //Caracteristicas del juego
        public string nombre { get; set; }
        public int id { get; set; }
        public int puntuacion { get; set; }
        public string categoria { get; set; }
        public string estudio { get; set; }
        public int año { get; set; }
        public string imagen { get; set; }
    }
}