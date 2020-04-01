using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LenguajesFase1
{
    class Nodo
    {
        
            public string id { get; set; }
            public Nodo Padre { get; set; }
            public Nodo Izquierdo { get; set; }
            public Nodo Derecho { get; set; }
        public string Last = "";
        public string First = "";
        public bool Nullable = false;
        public string simbolo = "";

            //Constructor
             public Nodo(string identificador)
            {
                this.id = identificador;
                this.Izquierdo = null;
                this.Derecho = null;
                this.Padre = null;
            }
        public Nodo()
        { }
            public Nodo(string identificador, Nodo izquierdo, Nodo derecho, Nodo padre)
            {
                this.id = identificador;
                this.Izquierdo = izquierdo;
                this.Derecho = derecho;
                this.Padre = padre;
            }
            public bool EsRaiz()
            {
                if (Padre != null)
                    return false;
                return true;
            }
            public bool ExisteIzquierdo()
            {
                if (Izquierdo != null)
                    return true;
                return false;
            }
            public bool ExisteDerecho()
            {
                if (Derecho != null)
                    return true;
                return false;
            }
            public bool EsHoja()
            {
                if (Derecho == null && Izquierdo == null)
                    return true;
                return false;
            }
    }
}
