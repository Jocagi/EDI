using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Laboratorio1.Models;
using System.Diagnostics;

namespace Laboratorio1.Controllers
{
    public class GameController : Controller
    {

        //Lista de juegos

        public static List<Game> lista = new List<Game>
            {
                new Game { id = 1, nombre = "Super Meat Boy", año = 2010, categoria = "Arcade", estudio = "Team Meat", puntuacion = 3, imagen = "https://s.pacn.ws/1500/pk/super-meat-boy-460363.12.jpg?obbk2g" },
                new Game { id = 3, nombre = "Super Mario Bros", año = 1985, categoria = "Plataformas", estudio = "Nintendo", puntuacion = 5, imagen = "https://is3-ssl.mzstatic.com/image/thumb/Purple118/v4/2a/f3/38/2af338d9-bb2d-e2ca-7a2d-e71d68d21072/AppIcon-1x_U007emarketing-85-220-5.png/246x0w.jpg" },
                new Game { id = 2, nombre = "The Legend of Zelda", año = 1985, categoria = "Puzzle", estudio = "Nintendo", puntuacion = 4, imagen = "https://i11a.3djuegos.com/juegos/9205/zelda_wii_u/fotos/ficha/zelda_wii_u-3424276.jpg" },
                new Game { id = 5, nombre = "Pac-Man", año = 1980, categoria = "Arcade", estudio = "Bandai Namco", puntuacion = 4, imagen = "https://is4-ssl.mzstatic.com/image/thumb/Purple124/v4/4c/79/28/4c792862-13e5-dd4e-f7e6-e0d2105ef3d1/AppIcon-0-1x_U007emarketing-0-0-GLES2_U002c0-512MB-sRGB-0-0-0-85-220-0-0-0-7.png/246x0w.jpg" }
            };

        // GET: Game
        public ActionResult Index()
        {
            return View();
        }
        //Busqueda
        public ActionResult Buscador(string ID)
        {
            Procesos.Inicio();

            var busqueda = from s in lista select s;

            if (!String.IsNullOrEmpty(ID))
            {
                busqueda = busqueda.Where(s => s.id.ToString().Contains(ID));
            }

            Procesos.Final();

            return View(busqueda.ToList());

        }
        //Editar 
        public ActionResult Editar(int id)
        {
            Procesos.Inicio();

            var std = lista.Where(s => s.id == id).FirstOrDefault();
            
            return View(std);
        }
        [HttpPost]
        public ActionResult Editar(Game std)
        {

            Game k = null;
            foreach (var item in lista)
            {
                if (std.id == item.id)
                {
                    k = item;
                    break;
                }
            }
            lista.Add(std);
            lista.Remove(k);

            Procesos.Final();
            
            return RedirectToAction("Buscador");
        }

        //Pagina Juego
        public ActionResult MostrarJuego(int id)
        {
            Procesos.Inicio();

            Game mostrar = null;
            foreach (Game juego in lista)
            {
                if (juego.id == id)
                {
                    mostrar = juego;
                }
            }
            Procesos.Final();

            if (mostrar == null)
            {
                return Redirect("~/Views/Shared/Error.cshtml");
            }
            else
            {
                return View(mostrar);
            }
        }
        //Ordenar
        public ActionResult Ordenar1()
        {
            Procesos.Inicio();
            List<Game> SortedList = lista.OrderBy(o => o.id).ToList();
            Procesos.Final();

            return View(SortedList);
        }

        public ActionResult Ordenar2()
        {
            Procesos.Inicio();

            int i, j, min_idx;

            // One by one move boundary of unsorted subarray 
            for (i = 0; i < 3 - 1; i++)
            {
                // Find the minimum element in unsorted array 
                min_idx = i;
                for (j = i + 1; j < lista.ToArray()[0].id; j++)
                    if (lista.ToArray()[j].id < lista.ToArray()[min_idx].id)
                        min_idx = j;
            }

            Procesos.Final();

            return View();
        }

        //public string IngresaUsuario(string nombreUsuario)
        //{
        //    //URL/Controlador/metodo=nomre del parametro
        //    //http://localhost:50813/Game/IngresaUsuario?nombreUsuario=Jose
            
        //    return "El nombre enviado es: " + nombreUsuario;
        //}
    }
}