using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using EstructurasLineales.Models;
using static EstructurasLineales.Models.Listas;

namespace EstructurasLineales.Controllers
{
    public class EmpleadoController : Controller
    {
        public Random rnd = new Random();

        // GET: Empleado
        public ActionResult Index()
        {    
            return View();
        }

        //Busqueda
        public ActionResult Search(string codigo)
        {
            var busqueda = from s in Empleados select s;

            if (!String.IsNullOrEmpty(codigo))
            {
                busqueda = busqueda.Where(s => (s.codigo.ToString().Contains(codigo) || s.nombre.ToString().Contains(codigo) || s.disp.ToString().Equals(codigo) || s.horas.ToString().Equals(codigo) || s.BuscarDisponibilidad(codigo)));
            }

            return View(busqueda.ToList());

        }

        // GET: Empleado/Create
        public ActionResult AddEmployees()
        {
            return View();
        }
        
        // POST: Empleado/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddEmployees(Empleado ingreso)
        {
            
            try
            {
                if (ingreso.nombre != null && ingreso.nombre != "")
                {
                    if (ingreso.codigo == null)
                    {
                        //Valor por defecto del codigo
                        ingreso.codigo = "NULL";
                    }

                    if (ingreso.horaEntrada == 0)
                    {
                        //Si no se ingrearon datos, usar hora del sistema
                        ingreso.horaEntrada = DateTime.Now.Hour;
                        ingreso.minutoEntrada = DateTime.Now.Minute;
                    }

                    ingreso.estaEnOficina = true;
                    ingreso.disp = ingreso.Disponibilidad();
                    ingreso.citas = rnd.Next(1, 5);

                    ingreso.horaSalida = "(No disponible)";

                    Empleados.AddLast(ingreso);
                    Ingresos.Push(ingreso);

                    //return RedirectToAction(nameof(AddEmployees));
                    return RedirectToAction(nameof(Search));
                }
                else
                {
                    return RedirectToAction(nameof(AddEmployees));
                }

            }
            catch
            {
                return View();
            }
        }

        public ActionResult Salida_Regreso()
        {
            return View();
        }

        public ActionResult Salida()
        {
            Empleado index;

            try
            {
                index = Ingresos.Pop();
                Empleados.Find(index).Value.estaEnOficina = false;
                Empleados.Find(index).Value.disp = Empleados.Find(index).Value.Disponibilidad();
                Salidas.Enqueue(index);
            }
            catch (Exception)
            {
                throw;
            }
            return Redirect("/Empleado/Search?=!Oficina");
           // return RedirectToAction(nameof(Search));
        }

        public ActionResult Regreso()
        {
            Empleado index;

            try
            {
                index = Salidas.Dequeue();
                Empleados.Find(index).Value.horas = 3 + 1.5*(Empleados.Find(index).Value.citas);
                Empleados.Find(index).Value.salario = (Empleados.Find(index).Value.horas) * 38;
                Empleados.Find(index).Value.horaSalida = Math.Truncate((Empleados.Find(index).Value.horaEntrada + Empleados.Find(index).Value.horas)).ToString() + ":" + Empleados.Find(index).Value.minutoEntrada.ToString();
                Empleados.Find(index).Value.disp = Empleados.Find(index).Value.Disponibilidad();
            }
            catch (Exception)
            {
                throw;
            }
            return Redirect("/Empleado/Search?=Jornada Terminada");
        }


        // GET: Empleado/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        
    }
}