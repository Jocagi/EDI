using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Newtonsoft.Json;

using System.IO;
using ArbolBinario;

namespace Laboratorio3.Controllers
{
    public class MedicamentoController : Controller
    {
      
        //string nombreArchivo = @"C:\Users\user\Desktop\Laboratorio3\Data.txt";

        public static string nombreArchivo = @"C:\Users\user\Desktop\MOCK_DATA (4).csv";
        public static string rutaJSON = @"C:\Users\user\Desktop\";

        private static int count = 0;
        private static string n = "recorrido";
        

        public static List<Medicamento> recorrido = new List<Medicamento>();


        public static Cliente cliente = new Cliente();
        
        public static List<Medicamento> medicamentos = new List<Medicamento>();
        public static ArbolBinario<Medicamento> arbolMedicinas = new ArbolBinario<Medicamento>();

        
        // GET: Medicamento
        public ActionResult Index()
        {
            CargarArchivo(nombreArchivo);
            return View();
        }
        [HttpPost]
        public ActionResult Index(string Path)
        {
            CargarArchivo(Path);
            return RedirectToAction("CrearPedido");
        }

        //Cargar archivo
        public void CargarArchivo(string Archivo)
        {
            if (!String.IsNullOrEmpty(Archivo))
            {
                nombreArchivo = Archivo;
            }
            
            using (var reader = new StreamReader(nombreArchivo))
            {
                int count = 0;

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();

                    if (count > 0)
                    {
                        string[] medicina = SplitString(line, ','); //dividir datos
                        Medicamento tmp = new Medicamento(int.Parse(medicina[0]), medicina[1], medicina[2], medicina[3], double.Parse(medicina[4]), int.Parse(medicina[5]));
                        medicamentos.Add(tmp); //anadir a arbol binario
                    }

                    count++;
                }

                arbolMedicinas.crearArbol(medicamentos);
            } 
        }

        string[] SplitString(string texto, char separador)
        {
            string[] Resultado = new string[6];
            int count = 0;
            int indiceVector = -1;
            string palabra = "";
            bool caracterEspecial = false;

            for (int i = 0; i < texto.Length; i++)
            {
                if (texto.Substring(count, 1) != separador.ToString()) //comparar cadaletra con el separador
                {
                    if (texto.Substring(count, 1) == '\u0022'.ToString())
                    {
                        caracterEspecial = !caracterEspecial; //cambiar el estado de un " encontrado
                    }
                    else if (texto.Substring(count, 1) == '$'.ToString())
                    {
                        //hacer nada
                    }
                    else
                    {
                        palabra += texto.Substring(count, 1);
                    }
                    count++;
                }
                else if (texto.Substring(count, 1) == separador.ToString() && caracterEspecial == true)
                {
                    palabra += texto.Substring(count, 1);
                    count++;
                }
                else
                {
                    if (indiceVector < 6)
                    {
                        indiceVector++;
                        Resultado[indiceVector] = palabra;
                        palabra = "";
                        count++;
                    }
                }
            }

            string[] algo = texto.Split(',');
            Resultado[5] = algo[algo.Length - 1];
            return Resultado;

        }

        //Buscar Medicamento

        Medicamento buscarEnLista(int index)
        {
            foreach (var item in medicamentos)
            {
                if (item.id == index)
                {
                    return item;
                }
            }

            return new Medicamento(0,"No existe en inventario","","",0,0);
        }
        
        //Controllers
        public ActionResult Error()
        {
            return View();
        }


        public ActionResult CrearPedido() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult CrearPedido(string nombre, string direccion, string nit) 
        {
            cliente.nombre = nombre;
            cliente.direccion = direccion;
            cliente.nit = nit;

            return RedirectToAction("BuscarMedicina");
        }


        public ActionResult BuscarMedicina(string nombre) 
        {
            //Buscar en arbol
           
            if (String.IsNullOrEmpty(nombre))
            {
                return View();   
            }
            else
            {
                //Medicamento encontrado = medicamentos.Find(x => x.nombre.Contains(nombre));
                //Medicamento encontrado = medicamentos.Find(x => x.id == arbolMedicinas.Buscar(nombre));

                Medicamento encontrado = buscarEnLista(arbolMedicinas.Buscar(nombre)); // YA FUNCIONA :)
                return View(encontrado);
            }
        }

        public ActionResult agregarPedido(Medicamento received) 
        {
            int id = received.id;
            cliente.compras.Add(received); //Anadir a lista de compras

            medicamentos.Find(x => x.id == id).cantidad--; //Dismiuir cantidad
            
            arbolMedicinas.crearArbol(medicamentos); //Recalcular Arbol Binario
            
            return RedirectToAction("BuscarMedicina");
        }
        

        public ActionResult factura()
        {
            return View(cliente.compras);
        }

        public ActionResult reabastecerStock(string nombre)
        {
            if (String.IsNullOrEmpty(nombre))
            {
                return View();
            }
            else
            {
                Medicamento encontrado = medicamentos.Find(x => x.nombre.Contains(nombre));
                return View(encontrado);
            }
        }
        public ActionResult reabastecer(Medicamento received)
        {
            Random rnd = new Random();

            int id = received.id;
            
            medicamentos.Find(x => x.id == id).cantidad = rnd.Next(1,16); //Dismiuir cantidad

            arbolMedicinas.crearArbol(medicamentos); //Recalcular Arbol Binario

            return RedirectToAction("reabastecerStock");
        }

        public ActionResult recorridos() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult recorridos(string Path)
        {
            if (!String.IsNullOrEmpty(Path))
            {
                rutaJSON = Path;
            }
            return RedirectToAction("recorridos2");
        }

        public ActionResult recorridos2()
        {
            return View();
        }

        public ActionResult preorden()
        {
            recorrido = new List<Medicamento>();
            recorrido = arbolMedicinas.listaPreorden();
            return RedirectToAction("exportarJSON");
        }
        public ActionResult inorden()
        {
            recorrido = new List<Medicamento>();
            recorrido = arbolMedicinas.listaInorden();
            return RedirectToAction("exportarJSON");
        }
        public ActionResult postorden()
        {
            recorrido = new List<Medicamento>();
            recorrido = arbolMedicinas.listaPostorden();
            return RedirectToAction("exportarJSON");
        }

        public ActionResult exportarJSON() //Formato JSON
        {
            //string json = JsonConvert.SerializeObject(recorrido.ToArray());
            //System.IO.File.WriteAllText(rutaJSON + archivoJSON, json);

            count++;
            string archivoJSON = n + count.ToString() + ".txt";

            FileInfo info = new FileInfo(rutaJSON + archivoJSON);
            
                using (StreamWriter file = info.CreateText())
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, recorrido);
                }

            return View();

            //return RedirectToAction("recorridos");

            //return File(archivoJSON, "text/plain");
        }
    }
}