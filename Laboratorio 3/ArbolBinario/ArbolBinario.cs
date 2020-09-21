using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbolBinario
{
    public class ArbolBinario<T> : ICollection<T>, IEnumerable<T>
    {

        public Nodo Raiz { get; set; }
        
        public bool esVacio { get { return Raiz == null; } }


        //intefaz
        public void Add(Medicamento item)
        {
            //Verificar la cantidad de medicamentos en existencia antes de ingresar al arbol
            if (item.enStock())
            {
                if (Raiz != null)
                {
                    this.Add(item, Raiz);
                }
                else
                {
                    Raiz = new Nodo(item);
                }
            }
            
        }
        private void Add(Medicamento item, Nodo raiz)
        {
            if (Raiz != null)
            {

                if (string.Compare(item.nombre, raiz.medicamento.nombre) == 1)
                {
                    if (raiz.izquierdo != null)
                    {
                        this.Add(item, raiz.izquierdo);
                    }
                    else
                    {
                        raiz.izquierdo = new Nodo(item);
                    }
                }
                else
                {
                    if (raiz.derecho != null)
                    {
                        this.Add(item, raiz.derecho);
                    }
                    else
                    {
                        raiz.derecho = new Nodo(item);
                    }
                }
            }
        }


        public void crearArbol(List<Medicamento> lista)
        {
            foreach (var item in lista)
            {
                this.Add(item);
            }
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }


        public int Buscar(string med)
        {
            if (Raiz != null)
            {
                if (Raiz.medicamento.nombre == med)
                {
                    return Raiz.indice;
                }
                else
                {
                    return Buscar(med, Raiz);
                }
            }
            else
            {
                return -1;
            }
        }
        private int Buscar(string med, Nodo raiz)
        {
            if (raiz.esHoja())
            {
                return -1;
            }
            else if (string.Compare(med, raiz.medicamento.nombre) == 1)
            {
                if (!raiz.existeDerecho())
                {
                    return raiz.indice;
                }
                else
                {
                    return Buscar(med, raiz.derecho);
                }
            }
            else
            {
                if (!raiz.existeIzquierdo())
                {
                    return raiz.indice;
                }
                else
                {
                    return Buscar(med, raiz.izquierdo);
                }
            }
        }

        //public bool compararIndice(Nodo nuevoNodo, int indice)
        //{
        //    if (nuevoNodo.indice == indice)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}


        private void ImprimirPre(Nodo reco)
        {
            if (reco != null)
            {
                Console.Write(reco.medicamento + " ");
                ImprimirPre(reco.izquierdo);
                ImprimirPre(reco.derecho);
            }
        }

        public void ImprimirPre()
        {
            ImprimirPre(Raiz);
            Console.WriteLine();
        }

        private void ImprimirEntre(Nodo reco)
        {
            if (reco != null)
            {
                ImprimirEntre(reco.izquierdo);
                Console.Write(reco.medicamento + " ");
                ImprimirEntre(reco.derecho);
            }
        }

        public void ImprimirEntre()
        {
            ImprimirEntre(Raiz);
            Console.WriteLine();
        }


        private void ImprimirPost(Nodo reco)
        {
            if (reco != null)
            {
                ImprimirPost(reco.izquierdo);
                ImprimirPost(reco.derecho);
                Console.Write(reco.medicamento + " ");
            }
        }


        public void ImprimirPost()
        {
            ImprimirPost(Raiz);
            Console.WriteLine();
        }





        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void Add(T item)
        {
            throw new NotImplementedException();
        }
    }
}
