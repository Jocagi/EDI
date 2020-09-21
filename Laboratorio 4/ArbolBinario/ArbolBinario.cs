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
            if (raiz != null)
            {

                if (string.Compare(item.nombre, raiz.medicamento.nombre) == 1)
                {

                    if (raiz.derecho != null)
                    {
                        this.Add(item, raiz.derecho);
                    }
                    else
                    {
                        raiz.derecho = new Nodo(item, raiz);
                    }

                }
                else
                {

                    if (raiz.izquierdo != null)
                    {
                        this.Add(item, raiz.izquierdo);
                    }
                    else
                    {
                        raiz.izquierdo = new Nodo(item, raiz);
                    }

                }
            }
        }


        public void crearArbol(List<Medicamento> lista)
        {
            this.Raiz = null;

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
                if (Raiz.medicamento.nombre.Contains(med))
                {
                    return Raiz.indice;
                }
                else
                {
                    int resultado = Buscar(med, new Nodo(Raiz.medicamento, Raiz.izquierdo, Raiz.derecho, null));
                    return resultado;
                }
            }
            else
            {
                return -1;
            }
        }
        private int Buscar(string med, Nodo raiz)
        {

            if (raiz == null)
            {
                return -1;
            }
            else if (raiz.medicamento.nombre.Contains(med))
            {
                return raiz.indice;
            }
            else if (raiz.esHoja())
            {
                return -1;
            }
            else
            {
                if (string.Compare(med, raiz.medicamento.nombre) == 1)
                {
                    return Buscar(med, raiz.derecho);
                }
                else
                {
                    return Buscar(med, raiz.izquierdo);
                }
            }
        }
        
        public List<Medicamento> listaPreorden()
        {
            List < Medicamento > R = new List<Medicamento>();
            Preorden(ref R, Raiz);

            return R;
        }
        private void Preorden(ref List<Medicamento> lista, Nodo raiz)
        {
            if (raiz != null)
            {
                lista.Add(raiz.medicamento);
                Preorden(ref lista, raiz.izquierdo);
                Preorden(ref lista, raiz.derecho);
            }
        }

        public List<Medicamento> listaInorden()
        {
            List<Medicamento> R = new List<Medicamento>();
            Inorden(ref R, Raiz);
            return R;
        }
        private void Inorden(ref List<Medicamento> lista, Nodo raiz)
        {
            if (raiz != null)
            {
                Inorden(ref lista, raiz.izquierdo);
                lista.Add(raiz.medicamento);
                Inorden(ref lista, raiz.derecho);
            }
        }

        public List<Medicamento> listaPostorden()
        {
            List<Medicamento> R = new List<Medicamento>();
            Postorden(ref R, Raiz);
            return R;
        }
        private void Postorden(ref List<Medicamento> lista, Nodo raiz)
        {
            if (raiz != null)
            {
                Postorden(ref lista, raiz.izquierdo);
                Postorden(ref lista, raiz.derecho);
                lista.Add(raiz.medicamento);
            }
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
