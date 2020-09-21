using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstructurasLineales.Models
{
    //Almacenamiento de datos
    public class Listas
    {
        public static LinkedList<Empleado> Empleados = new LinkedList<Empleado>();
        //Contiene a todos los trabajadores y su información.

        public static Stack<Empleado> Ingresos = new Stack<Empleado>();
        //Lleva el control de los ingresos y asignación de citas para los empleados.

        public static Queue<Empleado> Salidas = new Queue<Empleado>();
        //Lleva el control de cuántas horas han trabajado los empleados.
    }

}
