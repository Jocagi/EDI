using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;

namespace Laboratorio1.Models
{
    public static class Procesos
    {
        //Procesos de la aplicación
        public static string resultadoTiempo { get; set; }
        public static string resultadoPID { get; set; }
        public static string resultadoMemoria { get; set; }

        //Métodos
        private static long kbInicio;
        private static long kbFinal;
        private static TimeSpan start;
        private static TimeSpan stop;

        public static void Inicio()
        {
            kbInicio = GC.GetTotalMemory(true) / 1024;
            start = new TimeSpan(DateTime.Now.Ticks);
        }

        public static void Final()
        {
            //Obtener Process ID
            Process currentProcess = Process.GetCurrentProcess();
            resultadoPID = "PID: " + currentProcess.Id.ToString();
            //Obtener memoria
            kbFinal = GC.GetTotalMemory(false) / 1024;
            resultadoMemoria = "La memoria ocupada por el programa es de: " + (kbFinal - kbInicio).ToString() + "kb";
            //Obtener tiempo
            stop = new TimeSpan(DateTime.Now.Ticks);
            resultadoTiempo = "Esto toma: " + (stop.TotalMilliseconds - start.TotalMilliseconds) + " segundos.";
        }

        public static void Vaciar()
        {
            resultadoTiempo = null;
            resultadoPID = null;
            resultadoMemoria = null;
            kbInicio = 0;
            kbFinal = 0;
            start = TimeSpan.Zero;
            stop = TimeSpan.Zero;
        }
}
}