using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.IO;
using System.Text;

using LaboratorioDiccionarios.Models;

namespace LaboratorioDiccionarios.Controllers
{
    public class HomeController : Controller
    {
        public static string path = System.Web.HttpContext.Current.Server.MapPath("~/Estampas.csv"); //ubicacion del archivo csv de configuracion

        //Todas las calcomanias
        static List<Calcomania> calcomanias = new List<Calcomania>();
        // Diccionario NombreEquipo - ListadoFaltantes
        static Dictionary<string, List<Calcomania>> calcomaniasFaltantes = new Dictionary<string, List<Calcomania>>();
        // Diccionario numeroEstampilla - Disponible
        static Dictionary<int, bool> calcomaniaColeccionada = new Dictionary<int, bool>();

        public ActionResult Index(string id)
        {
            leerArchivo();

            //verificar busqueda
            if (String.IsNullOrEmpty(id)) //no se ha buscado nada
            {
                //mostrar todo
                return View(calcomanias);
            }
            else //se escribio algo en la barra de busqueda
            {
                //Revisar si se estaba buscando un numero de estampilla
                int busqueda;
                bool busquedaEsUnNumeroEntero = int.TryParse(id, out busqueda);

                //Revisar diccionario de equipos
                if (calcomaniasFaltantes.ContainsKey(id))
                {
                    //mostrar lista de estampillas faltantes de ese equipo
                    return View(calcomaniasFaltantes[id]);
                }
                else if (busquedaEsUnNumeroEntero)
                {
                    //Revisar diccionario de numero de estampilla
                    if (calcomaniaColeccionada.ContainsKey(busqueda))
                    {
                        List<Calcomania> resultado = new List<Calcomania> { calcomanias.Find(x => x.numero == busqueda) };
                        return View(resultado);
                    }
                    else
                    {
                        //Default
                        return View(calcomanias);
                    }
                }
                else
                {
                    //Default
                    return View(calcomanias);
                }
            }
        }
        public ActionResult EditarStatus(int id)
        {
            //Cambiar Estado
            calcomanias.Find(x => x.numero == id).coleccionada = !calcomanias.Find(x => x.numero == id).coleccionada;

            modificarArchivo();
            return RedirectToAction("Index");
        }

        private void leerArchivo()
        {
            //Evitar duplicados
            calcomanias.Clear();
            calcomaniasFaltantes.Clear();
            calcomaniaColeccionada.Clear();

            if (!System.IO.File.Exists(path)) //No existe el archivo
            {
                //Crear archivo en blanco
                FileStream file = System.IO.File.Create(path);
                file.Close();
            }

            using (var reader = new StreamReader(path))
            {
                /*
                Formato:

                numero de estampilla, equipo, jugador, obtenido
                14, RealMadrid, Ronaldo, 0
                
                 */
                 
                while (!reader.EndOfStream) //Recorrer archivo hasta el final
                {
                    var line = reader.ReadLine(); //linea actual

                    string[] palabras = line.Split(','); //dividir datos

                    Calcomania tmp = new Calcomania(Convert.ToInt16(palabras[0]), palabras[1], palabras[2], Convert.ToInt16(palabras[3]));

                    calcomanias.Add(tmp);
                }

                //Distribuir valores de lista en ambos diccionarios
                configurardiccionarios();

                reader.Close();
            }
        }
        private void configurardiccionarios()
        {
            //Vaciar contenido de diccionarios
            calcomaniasFaltantes.Clear();
            calcomaniaColeccionada.Clear();

            foreach (var item in calcomanias)
            {
                // Diccionario NombreEquipo - ListadoFaltantes
                //--------------------------------------------
                if (!calcomaniasFaltantes.ContainsKey(item.equipo)) //Si la llave aun no se encuentra en el diccionario
                {
                    //Agregar el equipo
                    calcomaniasFaltantes.Add(item.equipo, ListadoCalcomaniasFaltantes(item.equipo));
                }

                // Diccionario numeroEstampilla - Disponible
                //--------------------------------------------
                //Agregar estado de la calcomania al diccionario
                calcomaniaColeccionada.Add(item.numero, item.coleccionada);
                
            }
        }
        private List<Calcomania> ListadoCalcomaniasFaltantes(string equipo)
        {
            List<Calcomania> tmp = new List<Calcomania>();

            foreach (var item in calcomanias) //Recorrer todas las calcomanias
            {
                if (item.equipo == equipo) //Verificar si es el equipo buscado
                {
                    if (!item.coleccionada) //Verificar si la calcomania falta en el album
                    {
                        tmp.Add(item); //agregar al listado de faltantes para 'equipo'
                    }
                }
            }

            return tmp;
        }
        private void modificarArchivo()
        {
            //Borrar Archivo Existente
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }

            // Create a new file     
            FileStream fs = System.IO.File.Create(path);
            fs.Close();

            //construcctor de strings
            var csv = new StringBuilder();

            for (int i = 0; i < calcomanias.Count; i++)
            {
                var numero = Convert.ToString(calcomanias[i].numero);
                int estadoColeccion;

                switch (calcomanias[i].coleccionada)
                {
                    case true:
                        estadoColeccion = 1;
                        break;
                    case false:
                        estadoColeccion = 0;
                        break;
                    default:
                        estadoColeccion = 0;
                        break;
                }
                
                //Crear nuevas lineas en archivo
                var newLine = string.Format("{0},{1},{2},{3}", numero, calcomanias[i].equipo, calcomanias[i].jugador, estadoColeccion.ToString());
                csv.AppendLine(newLine);
            }

            //Escribir
            System.IO.File.WriteAllText(path, csv.ToString());

        }
    }
}