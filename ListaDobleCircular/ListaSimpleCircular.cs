﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaDobleCircular
{
    internal class ListaSimpleCircular : Lista
    {
        private Nodo? cola;
        private int tamano;

        public ListaSimpleCircular()
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
                this.cola = nuevoNodo;
            }
            else
            {
                nuevoNodo.siguiente = this.cola.siguiente;
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
                this.cola = nuevoNodo;
            }
            else
            {
                nuevoNodo.siguiente = this.cola.siguiente;
                this.cola.siguiente = nuevoNodo;
                this.cola = nuevoNodo;
            }
            this.tamano++;
            return true;
        }

        // En este caso, Anadir se comporta como AnadirFinal
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
            Nodo anterior = this.cola;
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
                        anterior.siguiente = actual.siguiente;
                        // Si se elimina el nodo cola, actualizar cola
                        if (actual == this.cola)
                        {
                            this.cola = anterior;
                        }
                    }
                    this.tamano--;
                    return elemento;
                }
                anterior = actual;
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
