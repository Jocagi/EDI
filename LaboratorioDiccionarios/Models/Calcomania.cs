using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaboratorioDiccionarios.Models
{
    public class Calcomania
    {
        public int numero { get; set; }
        public string jugador { get; set; }
        public string equipo { get; set; }
        public bool coleccionada { get; set; }

        public Calcomania()
        {
            numero = 0;
            jugador = " ";
            equipo = " ";
            coleccionada = true;
        }
        public Calcomania( int n, string team, string player, int colected)
        {
            numero = n;
            equipo = team;
            jugador = player;
            coleccionada = estaColeccionada(colected);
        }
        public Calcomania(int n, string team, string player)
        {
            numero = n;
            equipo = team;
            jugador = player;
            coleccionada = false;
        }

        private bool estaColeccionada(int n)
        {
            switch (n)
            {
                case 0:
                    return false;
                case 1:
                    return true;
                default:
                    return false;
            }
        }

        public bool estaColeccionada()
        {
            return coleccionada;
        }

        public string obtenerEquipo()
        {
            return equipo;
        }   
    }
}