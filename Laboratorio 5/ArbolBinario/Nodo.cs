using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbolBinario 
{
    public class Nodo
    {
        public List<Medicamento> Llaves { get; private set; }//Valores (Llaves) 
        public List<Nodo> Hijos { get; private set; }//Hijos
        public Nodo Padre { get; set; }

        public Nodo(Medicamento llave)
        {
            Llaves = new List<Medicamento>();
            Llaves.Add(llave);
            Hijos = new List<Nodo>();
            Padre = null;
        }

        public bool compararMedicamentos(Medicamento med1, Medicamento med2)
        {
            return (String.Compare(med1.nombre, med2.nombre) > 0);
        }
        private int compararmedicamentos(Medicamento med1, Medicamento med2)
        {
            return (String.Compare(med1.nombre, med2.nombre));
        }

        public bool tieneLLaves()
        {
            return Llaves.Count > 0;
        }

        public int tieneLlave(string valor)
        {
            for (int i = 0; i < Llaves.Count; i++)
            {
                if (Llaves[i].nombre.Contains(valor))
                {
                    return 1; //Si se encontro la llave
                }
            }
            return -1; //No tiene la llave
        }
        
        public void insertarNodo(Nodo nodo)
        {
            for (int x = 0; x < Hijos.Count; x++)
            {
                if (compararMedicamentos(Hijos[x].Llaves[0], nodo.Llaves[0]))
                {
                    Hijos.Insert(x, nodo);
                    return;
                }
            }

            Hijos.Add(nodo);
            nodo.Padre = this;
        }

        public bool eliminarHijo(Nodo n)
        {
            return Hijos.Remove(n);
        }

        public Nodo eliminarHijo(int posicion)
        {
            Nodo nodo = null;
            if (Hijos.Count > posicion)
            {
                nodo = Hijos[posicion];
                nodo.Padre = null;
                Hijos.RemoveAt(posicion);
            }

            return nodo;
        }

        public Nodo obtenerHijo(int posicion)
        {
            if (posicion < Hijos.Count)
            {
                return Hijos[posicion];
            }
            else
            {
                return null;
            }
        }

        public int posicionHijo(string valor)
        {
            try
            {
                if (Llaves.Count != 0)
                {
                    for (int i = 0; i <= Llaves.Count; i++)
                    {
                        if (Llaves[i].nombre.Contains(valor))
                        {
                            return i; //posicion
                        }
                    }
                    return -1; //no encontrado
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception)
            {
                return -1;
            }
            

        }

        public void Fusionar(Nodo n1)
        {
            int totalLlaves = n1.Llaves.Count;
            int totalHijos = n1.Hijos.Count;

            totalLlaves += this.Llaves.Count;
            totalHijos += this.Hijos.Count;
            
            for (int x = 0; x < n1.Llaves.Count; x++)
            {
                Medicamento valor = n1.Llaves[x];
                this.Push(valor);
            } 

            for (int x = Hijos.Count - 1; x >= 0; x--)
            {
                Nodo e = n1.eliminarHijo(x);
                this.insertarNodo(e);
            }
        }

        public void Fusionar(Nodo n1, Nodo n2)
        {
            int totalLlaves = n1.Llaves.Count;
            int totalHijos = n1.Hijos.Count;

            totalLlaves += n2.Llaves.Count;
            totalHijos += n2.Hijos.Count;

            totalLlaves += this.Llaves.Count;
            totalHijos += this.Hijos.Count;

            if (totalLlaves > 3)
            {
                throw new InvalidOperationException("Total Llaves of all nodes exceeded 3");
            }

            if (totalHijos > 4)
            {
                throw new InvalidOperationException("Total Hijos of all nodes exceeded 4");
            }

            this.Fusionar(n1);
            this.Fusionar(n2);
        }

        public Nodo[] Split()
        {
            if (Llaves.Count != 2)
            {
                throw new InvalidOperationException(string.Format("This node has {0} Llaves, can only split a 2 Llaves node", Llaves.Count));
            }


            //TO DO: Hacer que nodo derecho obtenga todas la llaves a la derecha

            //Nodo derecho
            Nodo newRight = new Nodo(Llaves[1]);

            //inicia en la mitad y recorre valores hasta el final
            for (int x = 2; x < Hijos.Count; x++)
            {
                newRight.Hijos.Add(this.Hijos[x]);
            }


            //Remover valores presentes en nodo derecho
            for (int x = Hijos.Count - 1; x >= 2; x--)
            {
                this.Hijos.RemoveAt(x);
            }

            for (int x = 1; x < Llaves.Count; x++)
            {
                Llaves.RemoveAt(x);
            }

            //retorna vector con nodo izquierdo y derecho
            return new Nodo[] { this, newRight };
        }

        public Medicamento Pop(int posicion)
        {

            if (posicion < Llaves.Count)
            {
                Medicamento valor = Llaves[posicion];
                Llaves.RemoveAt(posicion);

                return valor;
            }

            return null;
        }

        public void Push(Medicamento valor)
        {
            if (Llaves.Count == 0)
            {
                Llaves.Add(valor);
            }
            else
            {
                Llaves.Add(valor);
                Llaves.Sort(compararmedicamentos);
            }
        }

        public Nodo siguienteNodo(string valor)
        {
            int pos = posicionHijo(valor);

            if (pos < Hijos.Count && pos > -1)
            {
                return Hijos[pos];
            }
            else
            {
                return null;
            }
        }
    }
}
 