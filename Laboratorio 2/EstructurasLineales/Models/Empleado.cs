using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstructurasLineales.Models
{
    public class Empleado
    {
        public string nombre { get; set; }
        public string codigo { get; set; }
        public double horas { get; set; }
        public bool estaEnOficina { get; set; }
        public string disp { get; set; }
        public double salario { get; set; }

        public int horaEntrada { get; set; }
        public int minutoEntrada { get; set; }

        public string horaSalida { get; set; }

        public int citas { get; set; }

        //Funciones
        public string Disponibilidad()
        {
            if (estaEnOficina)
            {
                return "Si";
            }
            else if (horaSalida != "(No disponible)")
            {
                return "Jornada Terminada";
            }
            else
            {
                return "No";
            }
        }
        public bool BuscarDisponibilidad(string Busqueda)
        {
            if ((Busqueda == "oficina" || Busqueda == "Oficina") && estaEnOficina == true)
            {
                return true;
            }
            else if ((Busqueda == "!oficina" || Busqueda == "!Oficina") && estaEnOficina == false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
