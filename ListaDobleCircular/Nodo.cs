using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaDobleCircular
{
    internal class Nodo
    {
        internal int valor { get; set; }
        internal Nodo? siguiente { get; set; }
        internal Nodo? anterior { get; set; }

        public Nodo(int valor)
        {
            this.valor = valor;
            this.siguiente = null;
            this.anterior = null;
        }
    }
}
