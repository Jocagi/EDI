using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using ArbolBinario;

namespace Laboratorio3.Controllers
{
    public class MedicamentoController : Controller
    {

        public static Cliente cliente = new Cliente();
        

        public static List<Medicamento> medicamentos = new List<Medicamento>();
        public static ArbolBinario<Medicamento> arbolMedicinas = new ArbolBinario<Medicamento>();


        
        // GET: Medicamento
        public ActionResult Index()
        {
            CargarArchivo();
            return View();
        }

        //Cargar archivo
        public void CargarArchivo()
        {
            //id,nombre,descripcion,casa_productora,precio,existencia

            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\user\Desktop\Laboratorio3\Data.txt");

            foreach (string line in lines)
            {
                string[] medicina = SplitString(line, ','); //dividir datos
                Medicamento tmp = new Medicamento(int.Parse(medicina[0]), medicina[1], medicina[2], medicina[3], double.Parse(medicina[4]), int.Parse(medicina[5]));
                medicamentos.Add(tmp); //anadir a arbol binario
            }

            arbolMedicinas.crearArbol(medicamentos);
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


        //Controllers

        public ActionResult CrearPedido() 
        {
            CargarArchivo();
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
                //int busqueda = arbolMedicinas.Buscar(nombre);
                
                //else
                //{
                //    return RedirectToAction("BuscarMedicina");
                //}
            }
            else
            {
                Medicamento encontrado = medicamentos.Find(x => x.nombre.Contains(nombre));

                return View(encontrado);

            }

        }

        public ActionResult agregarPedido(Medicamento received) 
        {
            int id = received.id;
            cliente.compras.Add(received);
            //medicamentos.Find(x => x.id == id).cantidad--;
            if (id <= 0)
            {
        
        arbolMedicinas.crearArbol(medicamentos); //Recalcular Arbol Binario
            }
            return RedirectToAction("BuscarMedicina");
        }
        

        public ActionResult factura()
        {
            return View(cliente.compras);
        }

        public ActionResult reabastecerStock() 
        {
            return View();
        } 
        
        public ActionResult consultarIndice() //TODO
        {
            return View();
        }

        public ActionResult exportarIndice() //Formato JSON
        {
            return View();
        }
    }
}