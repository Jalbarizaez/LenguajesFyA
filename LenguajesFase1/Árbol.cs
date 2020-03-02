using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LenguajesFase1
{
    class Árbol
    {
        public ErrorVerificado Comparar(List<string> linea)
        {
            ErrorVerificado errorRetorno = new ErrorVerificado();
            errorRetorno.Error = false;
            errorRetorno.tipo = "";
            List<string> valuar = new List<string>();
            for(int i = 1; i<ex.Count-1;i++)
            {
                valuar.Add(ex[i]);
            }
            int tamaño = linea.Count;
            int recorrer = 0;
            int banderainicio = 0;
            int barrerafinal = 0;
            for(int i = 0; i<valuar.Count; i++)
            {
                if (nounario.Contains(valuar[i]) || unario.Contains(valuar[i])|| recorrer +1> tamaño)
                {
                    if(  st.Contains(valuar[i]))
                    {
                        errorRetorno.Error = true;
                        errorRetorno.tipo = "Se esperaba " + valuar[i];

                    }
                    if (valuar[i] == "*")
                    {

                    }
                    else if (valuar[i] == "+")
                    {

                    }
                    else if (valuar[i] == "|")
                    {
                    }
                    else if (valuar[i] == "(")
                    {
                    }

                }
                else
                {
                    if(valuar[i] != linea[recorrer])
                    {
                        errorRetorno.Error = true;
                        errorRetorno.tipo = "Se esperaba " + valuar[i];
                    }
                    else
                    {
                        recorrer++;
                    }

                }
                
                if (errorRetorno.Error == true)
                    break;

            }







            return errorRetorno;
        }

        public static Nodo Arbol_Final = new Nodo(".");
        static List<string> unario = new List<string>();// operadores unarios
        static List<string> ex = new List<string>(); //Tokens
        public static List<string> st = new List<string>();// Simbolos terminales
        static List<string> nounario = new List<string>();// operadores no unarios
        static Stack<Nodo> S = new Stack<Nodo>();// Pila de arboles
        static Stack<string> T = new Stack<string>();// Tokens llamada
        static Dictionary<string, int> operadores_Precedencia = new Dictionary<string, int>();// precedencias
        public Queue<string> Inorden = new Queue<string>();
        public void in_orden()
        {
            ;
            in_orden(Arbol_Final);

        }
        private void in_orden(Nodo raiz)
        {
                if (/*raiz.EsHoja()*/raiz!=null)
            {
                in_orden(raiz.Izquierdo);


                Inorden.Enqueue(raiz.id);
                
                
                in_orden(raiz.Derecho);
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
                            Nodo temp = new Nodo(T.Pop());//padre
                            var hijo1 = S.Pop();
                            temp.Derecho = hijo1;
                            hijo1.Padre = temp;
                            var hijo2 = S.Pop();
                            hijo2.Padre = temp;
                            temp.Izquierdo = hijo2;
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
                            var hijo1 = S.Pop();
                            aux.Izquierdo = hijo1;
                            hijo1.Padre = aux;
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
                            var hijo1 = S.Pop();
                            temp.Derecho = hijo1;
                            hijo1.Padre = temp;
                            var hijo2 = S.Pop();
                            hijo2.Padre = temp;
                            temp.Izquierdo = hijo2;
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
            auxiliar.Padre = Arbol_Final;
            var hijo = S.Pop();
            hijo.Padre = Arbol_Final;
            Arbol_Final.Izquierdo = hijo;
            Arbol_Final.Derecho = auxiliar;
            in_orden();
        }

    }
   
}
