using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbolBinario
{
    public class ArbolB
    {
        public Nodo Raiz { get; set; }

        public ArbolB()
        {
            Raiz = null;

        }

        public void crearArbol(List<Medicamento> lista)
        {
            foreach (var item in lista)
            {
                this.Insertar(item);
            }
        }

        public void Insertar(Medicamento valor)
        {
            if (Raiz == null)
            {
                Raiz = new Nodo(valor);
                return;
            }

            //Recorrer arbol

            Nodo actual = Raiz;
            Nodo padre = null;

            while (actual != null)
            {
                //verificar nodo lleno
                if (actual.Llaves.Count == 3)
                {
                    if (padre == null)
                    {
                        Medicamento i = actual.Pop(1); //obtener valor medio
                        Nodo nuevaRaiz = new Nodo(i); //nuevo padre
                        Nodo[] nuevosNodos = actual.Split(); //Dividir nodo
                        nuevaRaiz.insertarNodo(nuevosNodos[0]); //nuevo hijo izquierdo
                        nuevaRaiz.insertarNodo(nuevosNodos[1]); //nuevo hijo derecho
                        Raiz = nuevaRaiz;
                        actual = nuevaRaiz;
                    }
                    else
                    {
                        Medicamento k = actual.Pop(1); //Obtener valor medio
                        
                        //Ingresar valor medio en padre
                        if (k != null)
                        {
                            padre.Push(k);
                        }

                        //Dividir nodo
                        Nodo[] nNodos = actual.Split();
                        
                        padre.insertarNodo(nNodos[1]);

                        int posActual = padre.posicionHijo(valor.nombre);
                        actual = padre.obtenerHijo(posActual);

                    }
                }

                //Verificar nodo siguiente al actual, si se esta en una hoja: insertar. De lo contrario, seguir con el recorrido.
                padre = actual;
                actual = actual.siguienteNodo(valor.nombre); //siguiente nodo
                if (actual == null)
                {
                    padre.Push(valor);
                    break;
                }
            }
        }

        public Medicamento Find(string k)
        {
            Nodo actual = Raiz;

            while (actual != null)
            {
                if (actual.tieneLlave(k) >= 0)
                {
                    foreach (var item in actual.Llaves)
                    {
                        if (item.nombre.Contains(k))
                        {
                            return item;
                        }
                    }
                }
                else
                {
                    int p = actual.posicionHijo(k);
                    actual = actual.obtenerHijo(p);
                }
            }

            return null;
        }

        public void disminuirValor(Medicamento med)
        {
            Nodo actual = Raiz;

            while (actual != null)
            {
                if (actual.tieneLlave(med.nombre) >= 0)
                {
                    foreach (var item in actual.Llaves)
                    {
                        if (item.nombre.Contains(med.nombre))
                        {
                            item.cantidad--;

                            if (item.cantidad <= 0)
                            {
                                this.Eliminar(med.nombre);
                            }
                        }
                    }
                }
                else
                {
                    int p = actual.posicionHijo(med.nombre);
                    actual = actual.obtenerHijo(p);
                }
            }
        }

        public void Eliminar(string k)
        {
            
            Nodo actual = Raiz;
            Nodo papa = null;
            while (actual != null)
            {
                if (actual.Llaves.Count == 1)
                {
                    if (actual != Raiz)
                    {
                        string nombre = actual.Llaves[0].nombre;
                        int posicionHijo = papa.posicionHijo(nombre);

                        bool? caminoDerecho = null;
                        Nodo hermano = null;

                        if (posicionHijo > -1)
                        {
                            if (posicionHijo < 3)
                            {
                                hermano = papa.obtenerHijo(posicionHijo + 1);
                                if (hermano.Llaves.Count > 1)
                                {
                                    caminoDerecho = true;
                                }
                            }

                            if (caminoDerecho == null)
                            {
                                if (posicionHijo > 0)
                                {
                                    hermano = papa.obtenerHijo(posicionHijo - 1);
                                    if (hermano.Llaves.Count > 1)
                                    {
                                        caminoDerecho = false;
                                    }
                                }
                            }

                            if (caminoDerecho != null)
                            {
                                Medicamento tmp;
                                Medicamento tmp2;

                                if (caminoDerecho.Value)
                                {
                                    tmp = papa.Pop(posicionHijo);
                                    tmp2 = hermano.Pop(0);

                                    if (hermano.Hijos.Count > 0)
                                    {
                                        Nodo nod = hermano.eliminarHijo(0);
                                        actual.insertarNodo(nod);
                                    }
                                }
                                else
                                {
                                    tmp = papa.Pop(posicionHijo);
                                    tmp2 = hermano.Pop(hermano.Llaves.Count - 1);

                                    if (hermano.Hijos.Count > 0)
                                    {
                                        Nodo nod = hermano.eliminarHijo(hermano.Hijos.Count - 1);
                                        actual.insertarNodo(nod);
                                    }
                                }

                                papa.Push(tmp2);
                                actual.Push(tmp);
                            }
                            else
                            {
                                Medicamento tmp = null;

                                if (papa.Hijos.Count >= 2)
                                {
                                    if (posicionHijo == 0)
                                    {
                                        tmp = papa.Pop(0);
                                    }
                                    else if (posicionHijo == papa.Hijos.Count)
                                    {
                                        tmp = papa.Pop(papa.Llaves.Count - 1);
                                    }
                                    else//take papa's middle key
                                    {
                                        tmp = papa.Pop(1);
                                    }

                                    if (tmp != null)
                                    {
                                        actual.Push(tmp);
                                        Nodo sib = null;
                                        if (posicionHijo != papa.Hijos.Count)
                                        {
                                            sib = papa.eliminarHijo(posicionHijo + 1);
                                        }
                                        else
                                        {
                                            sib = papa.eliminarHijo(papa.Hijos.Count - 1);
                                        }

                                        actual.Fusionar(sib);
                                    }
                                }
                                else
                                {
                                    actual.Fusionar(papa, hermano);
                                    Raiz = actual;
                                    papa = null;
                                }
                            }
                        }
                    }
                }

                {
                    //Verificar si el nodo actual tiene el valor buscado
                    int rmPos = -1;
                    if ((rmPos = actual.tieneLlave(k)) >= 0) //Si se encontro una llave
                    {
                        //Si es una hoja, simplemente remover la llave
                        if (actual.Hijos.Count == 0)
                        {
                            actual.Pop(rmPos); //Remover valor en la posicion encontrada 
                        }
                        //Si no es hoja, reemplazar con la siguiente llave de mayor valor
                        else
                        {
                            Nodo Siguiente = Min(actual.Hijos[rmPos]);


                            if (Siguiente.Llaves.Count > 1)
                            {
                                Siguiente.Pop(0);
                            }
                            else
                            {
                                Siguiente.Padre.eliminarHijo(Siguiente);
                            }
                        }

                        actual = null;
                    }
                    //Si no se encontro el valor buscado, seguir recorriendo arbol
                    else
                    {
                        int p = actual.posicionHijo(k);
                        papa = actual;
                        actual = actual.obtenerHijo(p);
                    }
                }
            }
        }

        public Nodo Min(Nodo n = null)
        { 
            //Retorna nodo con el valor mas pequeno

            if (n == null)
            {
                n = Raiz;
            }

            Nodo actual = n;
            if (actual != null)
            {
                while (actual.Hijos.Count > 0)
                {
                    //ir a nodo izquierdo
                    actual = actual.Hijos[0];
                }
            }

            return actual;
        }

        public List<Medicamento> Preorden()
        {
            List<Medicamento> resultado = new List<Medicamento>();

            Preorden(this.Raiz, ref resultado);

            return resultado;
        }
        private void Preorden(Nodo nodo, ref List<Medicamento> lista)
        {
            if (nodo != null)
            {
                foreach (var item in nodo.Llaves)
                {
                    lista.Add(item);
                }
                foreach (var item in nodo.Hijos)
                {
                    Preorden(item, ref lista);
                }
            }
        }
    }
}
