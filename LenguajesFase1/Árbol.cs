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
        private  Dictionary<string, string> Simbolos = new Dictionary<string, string>();//Tabla de ID-Simbolos
        private static Dictionary<string, List<string>> Follows = new Dictionary<string, List<string>>();//Tabla de follows 
        private static Dictionary<string, List<string>> Transiciones = new Dictionary<string, List<string>>();//Tabla de transiciones Estados-Transiciones
        public static Nodo Arbol_Final = new Nodo(".");// Arbol Final
        private static List<string> unario = new List<string>();// operadores unarios
        private static List<string> ex = new List<string>(); //Tokens
        private static List<string> st = new List<string>();// Simbolos terminales
        private static List<string> nounario = new List<string>();// operadores no unarios
        private static Stack<Nodo> S = new Stack<Nodo>();// Pila de arboles
        private static Stack<string> T = new Stack<string>();// Tokens llamada
        private static Dictionary<string, int> operadores_Precedencia = new Dictionary<string, int>();// precedencias
        public List<Nodo> Postorden = new List<Nodo>();

        public List<string> RetornarOPUnarios()
        {
            return unario;
        }
        public List<string> RetornarONoPUnarios()
        {
            return nounario;
        }
        public List<Nodo> post_orden()
        {
            Postorden.Clear();
            post_orden(Arbol_Final);
            return Postorden;
        }
        private void post_orden(Nodo hoja)
        {
            if (hoja != null)
            {
                post_orden(hoja.Izquierdo);
                post_orden(hoja.Derecho);
                if (st.Contains(hoja.id) || hoja.id == "#")
                { Postorden.Add(hoja); }

            }
        }
        public List<Nodo> FLNEscribir()
        {
            Postorden.Clear();
            FLNEscribir(Arbol_Final);
            return Postorden;
        }
        private void FLNEscribir(Nodo hoja)
        {
            if (hoja != null)
            {
                FLNEscribir(hoja.Izquierdo);
                FLNEscribir(hoja.Derecho);

                 Postorden.Add(hoja); 

            }
        }
        private int contadorSimbolos;
        public Dictionary<string,List< string>> RetornarFollows()
        {
            return Follows;
        }
        public Dictionary<string, List<string>> RetornarTransiciones()
        {
            return Transiciones;
        }
        public List<string> RetornarTerminales()
        {
            return st;
        }
        private void FirstLastNullableFollows(Nodo hoja)
        {
            if (hoja != null)
            {
                FirstLastNullableFollows(hoja.Izquierdo);
                FirstLastNullableFollows(hoja.Derecho);
                if(unario.Contains(hoja.id))
                {
                    string Lc1 = hoja.Izquierdo.Last;
                    string Fc1 = hoja.Izquierdo.First;
                    var Lc1_ = Lc1.Split(',');
                    var Fc1_ = Fc1.Split(',');
                    switch (hoja.id)
                    {
                        case "+":
                            hoja.First = hoja.Izquierdo.First;
                            hoja.Last = hoja.Izquierdo.Last;                
                            foreach (var item in Lc1_)
                            {
                                var lista = Follows[item];
                                foreach (var f in Fc1_)
                                {
                                    if (!lista.Contains(f))
                                        lista.Add(f);
                                }
                                Follows[item] = lista;
                            }
                            break;

                        case "*":
                            hoja.Nullable = true;
                            hoja.First = hoja.Izquierdo.First;
                            hoja.Last = hoja.Izquierdo.Last;
                            foreach (var item in Lc1_)
                            {
                                var lista = Follows[item];
                                foreach (var f in Fc1_)
                                {
                                    if (!lista.Contains(f))
                                        lista.Add(f);
                                }
                                Follows[item] = lista;
                            }
                            break;
                    }
                }
                else if(nounario.Contains(hoja.id))
                {
                    switch (hoja.id)
                    {
                        case ".":
                            if (hoja.Izquierdo.Nullable == true)
                                hoja.First += hoja.Izquierdo.First +","+ hoja.Derecho.First;
                            else
                                hoja.First += hoja.Izquierdo.First;

                            if (hoja.Derecho.Nullable == true)
                                hoja.Last += hoja.Izquierdo.Last+ "," + hoja.Derecho.Last;
                            else
                                hoja.Last += hoja.Derecho.First;
                            if(hoja.Izquierdo.Nullable == true && hoja.Derecho.Nullable == true)
                            {
                                hoja.Nullable = true;
                            }
                            string Lc1 = hoja.Izquierdo.Last;
                            string Fc2 = hoja.Derecho.First;
                            var Lc1_ = Lc1.Split(',');
                            var Fc2_ = Fc2.Split(',');
                            foreach(var item in Lc1_)
                            {
                                var lista = Follows[item];
                                foreach(var f in Fc2_)
                                {
                                    if (!lista.Contains(f))
                                        lista.Add(f);
                                }
                                Follows[item] = lista;
                            }
                            break;
                            
                        case "|":
                            hoja.First += hoja.Izquierdo.First + "," + hoja.Derecho.First;
                            hoja.Last += hoja.Izquierdo.Last + "," + hoja.Derecho.Last;
                            if (hoja.Izquierdo.Nullable == true || hoja.Derecho.Nullable == true)
                            {
                                hoja.Nullable = true;
                            }
                            break;

                    }
                }
                else if(st.Contains(hoja.id)|| hoja.id=="#")
                {
                    hoja.simbolo = contadorSimbolos.ToString();
                    hoja.First = hoja.simbolo;
                    hoja.Last = hoja.simbolo;
                    contadorSimbolos++;
                    Simbolos.Add(hoja.simbolo, hoja.id.Trim('<', '>'));
                    Follows.Add(hoja.simbolo, new List<string>());
                }


            }
        }
        private List<string> Analizador (string estado)
        {
            List<string> followsTransiciones = new List<string>();
            var evaluar = estado.Split(',');
            var Nodos = post_orden();
            foreach (var item in st)
            {
                string transi = "";
                List<string> follows = new List<string>();
                
                foreach(var hoja in Nodos)
                {
                 
                        if (hoja.id == item && evaluar.Contains(hoja.simbolo))
                        {
                            var Foll = Follows[hoja.simbolo];
                            foreach (var simbolo in Foll)
                            {
                                if (!follows.Contains(simbolo))
                                    follows.Add(simbolo);
                            }
                        }
                    
                 
                }
                foreach (var x in follows)
                {
                    transi += x + ",";
                }
                transi = transi.Trim(',');
                var ordenar = transi.Split(',').ToList();
                ordenar.Sort();
                string aux = "";
                foreach (var x in ordenar)
                {
                    aux += x + ",";
                }
                aux = aux.Trim(',');
                followsTransiciones.Add(aux);

            }
            return followsTransiciones;
        }
        private void Transicion ()
        {

            var S0= Arbol_Final.First;
            Queue<string> EstadosAnalizar = new Queue<string>();
            EstadosAnalizar.Enqueue(S0);
            while(EstadosAnalizar.Count>0)
            {
                string estado = EstadosAnalizar.Dequeue();
                var Trans = Analizador(estado);
                Transiciones.Add(estado, Trans);
                foreach(var item in Trans)
                {
                    if (Transiciones.ContainsKey(item)== false &&item != "" && EstadosAnalizar.Contains(item) == false)
                        EstadosAnalizar.Enqueue(item);
                }
            }
        }
        public void Automata(string expresion)
        {
            crear("(" + expresion + ")");
            contadorSimbolos = 1;
            CrearArbol();
            FirstLastNullableFollows(Arbol_Final);
            Transicion();
        }

    //    var estadoInicial = arbol.Postorden[arbol.Postorden.Count - 1];
    //    Dictionary<string, List<int>> estados = new Dictionary<string, List<int>>();
    //    List<List<int>> estadosNuevos = new List<List<int>>();
    //    List<List<int>> estadosValidos = new List<List<int>>();
    //    estadosNuevos.Add(estadoInicial.first);
    //        List<int> prueba = new List<int>();
    //    Dictionary<string, int> validos = new Dictionary<string, int>();
    //    List<int> estadosTemporales = new List<int>();
    //    int contadorEstados = 0;
       
    //        while (estadosNuevos.Count > 0)//tabla 3
    //        {
    //            try
    //            {
    //                string estadoTemp = "";
    //    estadosNuevos[0].Sort();
    //                foreach(var x in estadosNuevos[0])
    //                {
    //                    estadoTemp += x+",";
    //                }
    //validos.Add(estadoTemp, contadorEstados);

    //                foreach (var y in Terminal)
    //                {

    //                    estadosTemporales = new List<int>();
    //                    foreach (var x in estadosNuevos[0])
    //                    {
    //                        if (SimbolosTerminales[x - 1].valor == y)
    //                        {
    //                            foreach (var z in SimbolosTerminales[x - 1].follow)
    //                            {
    //                                if (!estadosTemporales.Contains(z))
    //                                {
    //                                    estadosTemporales.Add(z);
    //                                }
    //                            }
    //                        }
    //                    }
    //                    estados.Add(y, estadosTemporales);
    //                    if (!estadosValidos.Contains(estadosTemporales))
    //                    {
    //                        estadosNuevos.Add(estadosTemporales);
    //                        estadosValidos.Add(estadosTemporales);

    //                    }

    //                }

    //                bool valido = false;
    //                foreach (var x in estados)
    //                {
                        
    //                    if (estadosNuevos[0].Count > 0)
    //                    {
                            
    //                        Console.Write("Estado " + contadorEstados + "     ");
    //                        foreach (var z in estadosNuevos[0])
    //                        {
    //                            Console.Write(z + "   ");
    //                        }
    //                        Console.WriteLine();
                          
    //                        if (x.Key.Length == 3)
    //                        {
    //                            Console.WriteLine("     "+x.Key[1]);
    //                        }
    //                        else
    //                        {
    //                            Console.WriteLine("     "+x.Key);
    //                        }
    //                        Console.ForegroundColor = ConsoleColor.White;
    //                        if (x.Value.Count>0)
    //                        {
    //                            foreach (var z in x.Value)
    //                            {
    //                                Console.Write("  " + z);
    //                            }
    //                        }
    //                        else
    //                        {
    //                            Console.WriteLine("----");
    //                        }
    //                        Console.WriteLine();
    //                        valido = true;
    //                    }
                        
    //                }

    //                estados = new Dictionary<string, List<int>>();
    //                estadosNuevos.Remove(estadosNuevos[0]);
    //                if (valido)
    //                {
    //                    contadorEstados++;
    //                }
                    
    //            }
    //            catch
    //            {
    //                estadosNuevos.Remove(estadosNuevos[0]);
    //            }
    //        }


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

                    if (token == "<")
                    { token = token + expresion[i] + ">"; }
                    else {  token = token + ">"; }
                    ex.Add(token);
                }
                //else if (expresion[i] == '/')
                //{
                //    ex.Add(expresion[i].ToString() + expresion[i + 1].ToString());
                //    i++;
                //}
                else if(expresion[i] != '>')
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
                    if (token == "<")
                    { token = token + expresion[i] + ">"; }
                    else { token = token + ">"; }
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
        //private void Llenar_st(List<string> llenar)
        //{
        //    foreach (var item in llenar)
        //    {
        //        st.Add(item);
        //    }
        //}
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
        //Metodos para que al ingresar la expresion como string genere los tokens para el arbol de expresiones
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
          
        }// Metodo de creacion del arbol 

    }
   
}
