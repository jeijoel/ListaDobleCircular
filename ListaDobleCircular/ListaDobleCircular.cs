using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaDobleCircular
{
    internal class ListaDobleCircular : Lista
    {
        private Nodo? cola;
        private int tamano;

        public ListaDobleCircular()
        {
            this.cola = null;
            this.tamano = 0;
        }

        public void Vaciar()
        {
            this.cola = null;
            this.tamano = 0;
        }

        public bool RevisarVacio()
        {
            return this.tamano == 0;
        }

        public int Tamano()
        {
            return this.tamano;
        }

        public bool Contiene(int elemento)
        {
            if (this.cola == null)
            {
                return false;
            }
            Nodo actual = this.cola.siguiente;
            do
            {
                if (actual.valor == elemento)
                {
                    return true;
                }
                actual = actual.siguiente;
            } while (actual != this.cola.siguiente);
            return false;
        }

        // Inserta al inicio: se inserta después de cola (la cabeza es cola.siguiente)
        public bool AnadirInicio(int elemento)
        {
            Nodo nuevoNodo = new Nodo(elemento);
            if (this.cola == null)
            {
                nuevoNodo.siguiente = nuevoNodo;
                nuevoNodo.anterior = nuevoNodo;
                this.cola = nuevoNodo;
            }
            else
            {
                Nodo cabeza = this.cola.siguiente;
                nuevoNodo.siguiente = cabeza;
                nuevoNodo.anterior = this.cola;
                cabeza.anterior = nuevoNodo;
                this.cola.siguiente = nuevoNodo;
            }
            this.tamano++;
            return true;
        }

        // Inserta al final: se inserta después de cola y se actualiza cola
        public bool AnadirFinal(int elemento)
        {
            Nodo nuevoNodo = new Nodo(elemento);
            if (this.cola == null)
            {
                nuevoNodo.siguiente = nuevoNodo;
                nuevoNodo.anterior = nuevoNodo;
                this.cola = nuevoNodo;
            }
            else
            {
                Nodo cabeza = this.cola.siguiente;
                nuevoNodo.siguiente = cabeza;
                nuevoNodo.anterior = this.cola;
                cabeza.anterior = nuevoNodo;
                this.cola.siguiente = nuevoNodo;
                this.cola = nuevoNodo;
            }
            this.tamano++;
            return true;
        }

        public bool Anadir(int elemento)
        {
            return AnadirFinal(elemento);
        }

        public int Borrar(int elemento)
        {
            if (this.cola == null)
            {
                throw new KeyNotFoundException("La lista está vacía.");
            }
            Nodo actual = this.cola.siguiente;
            do
            {
                if (actual.valor == elemento)
                {
                    // Caso: lista con un solo nodo
                    if (actual == this.cola && actual == this.cola.siguiente)
                    {
                        this.cola = null;
                    }
                    else
                    {
                        actual.anterior.siguiente = actual.siguiente;
                        actual.siguiente.anterior = actual.anterior;
                        // Si se elimina el nodo cola, actualizar cola
                        if (actual == this.cola)
                        {
                            this.cola = actual.anterior;
                        }
                    }
                    this.tamano--;
                    return elemento;
                }
                actual = actual.siguiente;
            } while (actual != this.cola.siguiente);
            throw new KeyNotFoundException("Elemento no encontrado.");
        }

        public override string ToString()
        {
            if (this.cola == null)
            {
                return "[]";
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            Nodo actual = this.cola.siguiente;
            do
            {
                sb.Append(actual.valor);
                actual = actual.siguiente;
                if (actual != this.cola.siguiente)
                {
                    sb.Append(", ");
                }
            } while (actual != this.cola.siguiente);
            sb.Append("]");
            return sb.ToString();
        }
    }
}
