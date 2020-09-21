using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbolBinario
{
    public class Medicamento
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public int cantidad { get; set; }
        public string descripcion { get; set; }
        public double precio { get; set; }
        public string casaFarmaceutica { get; set; }
        
        public bool enStock()
        {
           if(cantidad > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Constructures
        public Medicamento() { }
        public Medicamento(int id, string nombre, string descrip, string casa, double precio, int cantidad)
        {
            this.id = id;
            this.nombre = nombre;
            this.descripcion = descrip;
            this.precio = precio;
            this.casaFarmaceutica = casa;
            this.cantidad = cantidad;
        }
    }
}
