using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LenguajesFase1
{
    class Árbol
    {
        List<string> unario = new List<string>();// operadores unarios
        List<string> ex = new List<string>(); //Tokens
        List<string> st = new List<string>();// Simbolos terminales
        List<string> op = new List<string>();// operadores
        Stack<Nodo> S = new Stack<Nodo>();// Pila de arboles
        Stack<string> T = new Stack<string>();// Tokens llamada
        private void CrearArbol()
        {

            foreach(var item in ex)
            {
                if(st.Contains(item))
                {
                    Nodo temporal = new Nodo(item);
                    S.Push(temporal);
                }
                else if(item =="(")
                {
                    T.Push(item);
                }
                else if(item == ")")
                {
                    while (T.Count > 0 && (T.Peek()) != "(")
                    {
                        if (T.Count == 0)
                        {
                            //Error
                        }
                        else if (S.Count < 2)
                        {
                            //Error
                        }
                        else
                        {
                            Nodo temp = new Nodo(T.Pop());
                            temp.Derecho = S.Pop();
                            temp.Izquierdo = S.Pop();
                            S.Push(temp);
                        }
                    }
                    T.Pop();
                }
                else if(op.Contains(item))
                {
                    if(unario.Contains(item))
                    {
                        Nodo aux = new Nodo(item);
                        if(S.Count<0)
                        {
                            //Error
                        }
                        else
                        {
                            aux.Izquierdo = S.Pop();
                            S.Push(aux);
                        }
                    }
                    else if(T.Count >0 && T.Peek() != "(")// agregar condicion de precedencia de token es menor a último op en T
                    {

                    }
                    else if(unario.Contains(item)== false)
                    {
                        T.Push(item);
                    }
                }
                else
                {
                    //Error
                }
            }

        }
    }

}
