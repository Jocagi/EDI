using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ArbolBinario;

namespace Laboratorio3
{
    public class Cliente
    {
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string nit { get; set; }
        public List<Medicamento> compras = new List<Medicamento>();

        public double totalAPagar()
        {
            double total = 0;
            foreach (var item in compras)
            {
                total += item.precio;
            }
            return total;
        }
        
    }
}