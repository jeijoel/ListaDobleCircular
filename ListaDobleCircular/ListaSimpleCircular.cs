using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaDobleCircular
{
    internal class ListaSimpleCircular : Lista
    {
        private Nodo? cola;
        private Nodo? cabeza;
        private int tamano;
        public ListaSimpleCircular()
        {
            this.cola = null;
            this.cabeza = null;
            this.tamano = 0;
        }
        public void Vaciar()
        {
            this.cola = null;
            this.cabeza = null;
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
            while (actual != this.cola)
            {
                if (actual.valor == elemento)
                {
                    return true;
                }
                actual = actual.siguiente;
            }
            return actual.valor == elemento;
        }
        public bool AnadirInicio(int elemento)
        {
            Nodo nuevoNodo = new Nodo(elemento);
            if (this.cabeza == null)
            {
                this.cabeza = nuevoNodo;
                nuevoNodo.siguiente = nuevoNodo;
            } else {
                nuevoNodo.siguiente = this.cabeza.siguiente;
                this.cabeza.siguiente = nuevoNodo;
                this.cabeza = nuevoNodo;
            }
            this.tamano++;
            return true;
        }
        public bool AnadirFinal(int elemento)
        {
            Nodo nuevoNodo = new Nodo(elemento);
            if (this.cola == null)
            {
                this.cola = nuevoNodo;
                nuevoNodo.siguiente = this.cola.siguiente;
            } else {
                nuevoNodo.siguiente = this.cola.siguiente;
                this.cola.siguiente = nuevoNodo;
                this.cola = nuevoNodo;
            }
            this.tamano++;
            return true;
        }
        public bool Anadir(int elemento)
        {
            Nodo nuevoNodo = new Nodo(elemento);
            if (this.cabeza == null)
            {
                this.cabeza = nuevoNodo;
            }
            else
            {
                Nodo actual = this.cabeza;
                while (actual.siguiente != null)
                {
                    actual = actual.siguiente;
                }
                actual.siguiente = nuevoNodo;
            }
            this.tamano++;
            return true;
        }
        public int Borrar(int elemento)
        {
            if ( this.cabeza == null )
            {
                throw new KeyNotFoundException();
            }
            Nodo actual = this.cola.siguiente;
            Nodo anterior = this.cola;
            while (actual != this.cola)
            {
                if (actual.valor == elemento)
                {
                    anterior.siguiente = actual.siguiente;
                    this.tamano--;
                    return elemento;
                }
                anterior = actual;
                actual = actual.siguiente;
            }
            if (actual.valor == elemento)
            {
                if (this.tamano == 1)
                {
                    this.cola = null;
                } else {
                    anterior.siguiente = actual.siguiente;
                    if (actual == this.cola)
                    {
                        this.cola = anterior;
                    }
                }
                this.tamano--;
                return elemento;
            }
            throw new KeyNotFoundException();
        }
        public override string ToString()
        {
            return ToString_aux();
        }
        public string ToString_aux()
        {
            Nodo actual = this.cabeza;
            try
            {
                while (actual != null)
                {
                    string stringLista = "";
                    var rango = Enumerable.Range(0, this.Tamano());
                    foreach (var i in rango)
                    {
                        if (stringLista != "")
                        {
                            stringLista = stringLista + ", " + actual.valor;
                            actual = actual.siguiente;
                        }
                        else
                        {
                            stringLista = stringLista + actual.valor;
                            actual = actual.siguiente;
                        }

                    }
                    return "[" + stringLista + "]";
                }
                return "";
            }
            catch
            {
                return "Error mostrando el contenido de la lista";

            }
        }
    }
}
