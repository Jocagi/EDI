using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbolBinario
{
    public class Nodo
    {
        //Propiedades
        public Medicamento medicamento { get; set; }
        public int indice { get; set; }

        public Nodo padre { get; set; }
        public Nodo izquierdo { get; set; }
        public Nodo derecho { get; set; }

        //Constructor 
        public Nodo()
        {

        }
        public Nodo(Medicamento Medicamento) {
            this.medicamento = Medicamento;
        }
        public Nodo(Medicamento Medicamento, Nodo Izquierdo, Nodo Derecho, Nodo Padre)
        {
            this.medicamento = Medicamento;
            this.izquierdo = Izquierdo;
            this.derecho = Derecho;
            this.padre = Padre;
        }

        //Metodos
        public bool esRaiz()
        {
            if (padre != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool esHoja()
        {
            if ((derecho == null) && (derecho == null))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool existeIzquierdo()
        {
            if (izquierdo != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool existeDerecho()
        {
            if (derecho != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool tieneMedicamento()
        {
            if (medicamento != null)
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
