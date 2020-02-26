using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LenguajesFase1
{
    class Árbol
    {

        Nodo Arbol_Final = new Nodo();
        static List<string> unario = new List<string>();// operadores unarios
        static Queue<string> ex = new Queue<string>(); //Tokens
        static List<string> st = new List<string>();// Simbolos terminales
        static List<string> nounario = new List<string>();// operadores no unarios
        static Stack<Nodo> S = new Stack<Nodo>();// Pila de arboles
        static Stack<string> T = new Stack<string>();// Tokens llamada
        static Dictionary<string, int> operadores_Precedencia = new Dictionary<string, int>();// precedencias
        public List<string> Inorden = new List<string>();
        public void in_orden()
        {
            in_orden(S.Peek());

        }
        private void in_orden(Nodo hoja)
        {
            if (hoja != null)
            {
                in_orden(hoja.Izquierdo);
                Inorden.Add(hoja.id);
                in_orden(hoja.Derecho);
            }
        }
        public void crear(List<string> terminales)
        {
            operadores_Precedencia.Clear();
            nounario.Clear();
            S.Clear();
            T.Clear();
            st.Clear();
            unario.Clear();
            LlenarDiccionarioPrecedencia();
            Llenar_op();
            Llenar_unario();
            Llenar_st(terminales);
        }
        private void LlenarDiccionarioPrecedencia()
        {
            operadores_Precedencia.Add("*", 3);
            operadores_Precedencia.Add(".", 2);
            operadores_Precedencia.Add("|", 1);
        }
        private void Llenar_st(List<string> llenar)
        {
            foreach (var item in llenar)
            {
                st.Add(item);
            }
        }
        private bool VerificarPrecedencia(string token)
        {
            if (token == "*")
                return false;
            else if (operadores_Precedencia[token] <= operadores_Precedencia[T.Peek()])
            {
                return true;
            }
            return false;
            //if (token == "*")
            //    return false;
            //else if (token == "." && T.Peek() == "*")
            //    return true;
            //else if (token == "|" && (T.Peek() == "*" || T.Peek() == "."))
            //    return  true;
            //else if (token == T.Peek())
            //    return true;
            //return false;
        }
        private void Llenar_unario()
        {
            unario.Add("*");
            unario.Add("+");
            unario.Add("?");
        }
        private void Llenar_op()
        {
            //op.Add("*");
            //op.Add("+");
            //op.Add("?");
            nounario.Add(".");
            nounario.Add("|");
            nounario.Add(")");
            nounario.Add("(");
        }
        public void CrearArbol()
        {
            ex.Enqueue("(");
            ex.Enqueue(" ");
            ex.Enqueue("*");
            ex.Enqueue(".");
            ex.Enqueue("ID");
            ex.Enqueue(".");
            ex.Enqueue(" ");
            //ex.Enqueue("*");
            //ex.Enqueue(".");
            //ex.Enqueue("=");
            //ex.Enqueue(".");
            //ex.Enqueue(" ");
            //ex.Enqueue("*");
            //ex.Enqueue(".");
            //ex.Enqueue("(");
            //ex.Enqueue("V");
            //ex.Enqueue("|");
            //ex.Enqueue("N");
            //ex.Enqueue(")");
            //ex.Enqueue("+");
            //ex.Enqueue(".");
            //ex.Enqueue(" ");
            ex.Enqueue(")");
            foreach (var item in ex)
            {
                if (st.Contains(item))
                {
                    Nodo temporal = new Nodo(item);
                    S.Push(temporal);
                }
                else if (item == "(")
                {
                    T.Push(item);

                }
                else if (item == ")")
                {
                    while (T.Count > 0 && (T.Peek()) != "(")
                    {
                        if (T.Count == 0)
                        {
                            break;
                            //Error
                        }
                        else if (S.Count < 2)
                        {
                            break;
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
                else if (unario.Contains(item)||nounario.Contains(item))
                {
                    if (unario.Contains(item))
                    {
                        Nodo aux = new Nodo(item);
                        if (S.Count < 0)
                        {
                            break;
                            //Error
                        }
                        else
                        {
                            aux.Izquierdo = S.Pop();
                            S.Push(aux);
                        }
                    }
                    else if (T.Count > 0 && T.Peek() != "(" && (VerificarPrecedencia(item)) )
                    {
                        Nodo temp = new Nodo(T.Pop());
                        if (S.Count < 2)
                        {
                            break;
                            //error   
                        }
                        else
                        {
                            temp.Derecho = S.Pop();
                            temp.Izquierdo = S.Pop();
                            S.Push(temp);
                        }
                    }
                     if (unario.Contains(item) == false)
                    {
                        T.Push(item);
                    }
                }
                else
                {
                    break;
                    //Error
                }
               
            }
            Nodo Nodofinal = new Nodo();
            Nodo derecho = new Nodo();
            derecho.id = "#";
            Nodofinal.id = ".";
            Nodofinal.Izquierdo = S.Pop();
            Nodofinal.Derecho = derecho;
            in_orden();

        }

    }
   
}
