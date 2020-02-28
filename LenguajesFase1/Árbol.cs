using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LenguajesFase1
{
    class Árbol
    {

        public static Nodo Arbol_Final = new Nodo(".");
        static List<string> unario = new List<string>();// operadores unarios
        static List<string> ex = new List<string>(); //Tokens
        public static List<string> st = new List<string>();// Simbolos terminales
        static List<string> nounario = new List<string>();// operadores no unarios
        static Stack<Nodo> S = new Stack<Nodo>();// Pila de arboles
        static Stack<string> T = new Stack<string>();// Tokens llamada
        static Dictionary<string, int> operadores_Precedencia = new Dictionary<string, int>();// precedencias
        public List<string> Inorden = new List<string>();
        public void in_orden()
        {
            in_orden(Arbol_Final);

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
        public void crear(string expresion)
        {
            ex.Clear();
            operadores_Precedencia.Clear();
            nounario.Clear();
            S.Clear();
            T.Clear();
            st.Clear();
            unario.Clear();
            LlenarDiccionarioPrecedencia();
            Llenar_op();
            Llenar_unario();
            terminales(expresion);
            Crear_expresion(expresion);

        }
        private void Crear_expresion(string expresion)
        {
            for (int i = 0; i < expresion.Length; i++)
            {
                if (expresion[i] == '<')
                {
                    string token = "";
                    while (expresion[i] != '>')
                    {
                        token += expresion[i];
                        i++;
                    }
                    token = token + ">";
                    ex.Add(token);
                }
                else if (expresion[i] == '/')
                {
                    ex.Add(expresion[i].ToString() + expresion[i + 1].ToString());
                    i++;
                }
                else
                    ex.Add(expresion[i].ToString());
            }

        }
        private void terminales(string expresion)
        {
            
            for (int i = 0; i < expresion.Length; i++)
            {
                if (expresion[i] == '<')
                {
                    string token = "";
                    while (expresion[i] != '>')
                    {
                        token += expresion[i];
                        i++;
                    }
                    token = token + ">";
                    if (st.Contains(token) == false)
                        st.Add(token);
            
                }
            }
           
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
        }
        private void Llenar_unario()
        {
            unario.Add("*");
            unario.Add("+");
            unario.Add("?");
        }
        private void Llenar_op()
        {

            nounario.Add(".");
            nounario.Add("|");
            nounario.Add(")");
            nounario.Add("(");
        }
        public void CrearArbol()
        {
            
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
            Nodo auxiliar = new Nodo();
            auxiliar.id = "#";
            Arbol_Final.Izquierdo = S.Pop();
            Arbol_Final.Derecho = auxiliar;
            in_orden();
        }

    }
   
}
