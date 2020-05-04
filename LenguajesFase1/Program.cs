using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LenguajesFase1
{
    class Expresiones
    {
        public List<string> Operadores = new List<string>();
        public List<string> TokenSets(string Expresion)// Metodo encargado de convertir a tokens los sets
        {
            int contador = 0;
            List<string> expresion = new List<string>();
            try
            {
                for (int i = 0; i < Expresion.Length; i++)
                {
                    if (Expresion[i] == '.' && Expresion[i + 1] == '.')
                    {
                        i++;
                        expresion.Add("<" + ".." + ">");
                    }
                    else if (i < Expresion.Length - 1 && Expresion[i] == '.')
                    {
                        if ((Expresion[i] == '.' && Expresion[i + 1] != '.') || (Expresion[i] != '.' && Expresion[i + 1] == '.'))
                        {
                            int x = Convert.ToInt16("W");
                        }
                    }
                    else if (Expresion[i] == 'C' && Expresion[i + 1] == 'H' && Expresion[i + 2] == 'R')
                    {
                        i = i + 2;
                        expresion.Add("<CHR>");
                        if (Expresion[i + 1] == '(')
                        {
                            i = i + 2;
                            expresion.Add("<(>");
                            string aux = "";
                            while (Expresion[i] != ')')
                            {
                                aux = aux + Expresion[i];
                                i++;

                            }

                            try
                            {
                                var evaluar = Convert.ToInt16(aux);
                                expresion.Add("<N>");

                            }
                            catch { int x = Convert.ToInt16("W"); }
                            if (Expresion[i] == ')')
                                expresion.Add("<)>");
                            else
                            {
                                int x = Convert.ToInt16("W");
                            }
                        }
                    }
                    else if (Convert.ToInt16(Convert.ToByte(Expresion[i])) > 64 && Convert.ToInt16(Convert.ToByte(Expresion[i])) < 91)
                    {
                        contador++;
                        while (Convert.ToInt16(Convert.ToByte(Expresion[i])) > 64 && Convert.ToInt16(Convert.ToByte(Expresion[i])) < 91)
                        {
                            i++;
                        }
                        i--;
                        expresion.Add("<" + "ID" + ">");
                    }
                    else if (Expresion[i] == Convert.ToChar("'"))
                    {
                        expresion.Add("<'>");
                        if (i + 1 != Expresion.Length)
                        {
                            if (Expresion[i + 1] != ' ' || Expresion[i + 1] != Convert.ToChar("'"))
                            {
                                expresion.Add("<" + "C" + ">");
                                i++;
                            }
                            else { int x = Convert.ToInt16("W"); }
                            if (Expresion[i + 1] == Convert.ToChar("'"))
                            {
                                expresion.Add("<'>");
                                i++;
                            }
                            else { int x = Convert.ToInt16("W"); }

                            if (i + 1 < Expresion.Length)
                            {
                                if (Expresion[i + 1] != '.' && Expresion[i + 1] != '+' && Expresion[i + 1] != ' ')
                                {
                                    int x = Convert.ToInt16("W");
                                }
                            }
                        }
                    }
                    else if (Expresion[i] == '+')
                    {
                        expresion.Add("<+>");

                    }
                    else if (Expresion[i] == '=')
                    {
                        expresion.Add("<=>");

                    }
                    else if (Expresion[i] != ' ' && Expresion[i] != Convert.ToChar("\t"))
                    {
                        int x = Convert.ToInt16("W");

                    }

                }
                return expresion;
            }
            catch { return null; }
        }
        public List<string> TokenTokens(string Expresion)// Metodo encargado de convertir a tokens los tokens
        {

            List<string> expresion = new List<string>();
            try
            {
                for (int i = 0; i < Expresion.Length; i++)
                {
                    if (Expresion[i] == 'T' && Expresion[i + 1] == 'O')
                    {
                        if (Expresion[i] == 'T' && Expresion[i + 1] == 'O' && Expresion[i + 2] == 'K' && Expresion[i + 3] == 'E' && Expresion[i + 4] == 'N')
                        {
                            i = i + 4;
                            expresion.Add("<" + "TOKEN" + ">");
                        }
                        else
                        {

                        }
                    }
                    else if (Expresion[i] == Convert.ToChar("'"))
                    {
                        expresion.Add("<'>");
                        if (i + 1 != Expresion.Length)
                        {
                            if (Expresion[i + 1] != ' ' || Expresion[i + 1] != Convert.ToChar("'"))
                            {
                                expresion.Add("<" + "C" + ">");
                                i++;
                            }
                            if (Expresion[i + 1] == Convert.ToChar("'"))
                            {
                                expresion.Add("<'>");
                                i++;
                            }
                            else
                            {
                                int x = Convert.ToInt16("W");
                            }

                        }
                    }
                    else if (Convert.ToInt16(Convert.ToByte(Expresion[i])) > 64 && Convert.ToInt16(Convert.ToByte(Expresion[i])) < 91)
                    {

                        while (Convert.ToInt16(Convert.ToByte(Expresion[i])) > 64 && Convert.ToInt16(Convert.ToByte(Expresion[i])) < 91)
                        {
                            i++;
                        }
                        i--;
                        expresion.Add("<" + "ID" + ">");
                    }
                    else if (Convert.ToInt16(Convert.ToByte(Expresion[i])) > 47 && Convert.ToInt16(Convert.ToByte(Expresion[i])) < 58)
                    {

                        while (Convert.ToInt16(Convert.ToByte(Expresion[i])) > 47 && Convert.ToInt16(Convert.ToByte(Expresion[i])) < 58)
                        {
                            i++;
                        }
                        i--;
                        expresion.Add("<" + "N" + ">");
                    }
                    else if (Expresion[i] == '+')
                    {
                        expresion.Add("<+>");

                    }
                    else if (Expresion[i] == '=')
                    {
                        expresion.Add("<=>");

                    }
                    else if (Expresion[i] == '*')
                    {
                        expresion.Add("<*>");

                    }
                    else if (Expresion[i] == '?')
                    {
                        expresion.Add("<?>");

                    }
                    else if (Expresion[i] == '|')
                    {
                        if (char.IsUpper(Expresion[i + 1]) || Expresion[i + 1] == Convert.ToChar("'") || Expresion[i + 1] == ' ' && Expresion[i + 1] != Convert.ToChar("*") && Expresion[i + 1] != '?' && Expresion[i + 1] != '+')
                        { expresion.Add("<|>"); }
                        else { int x = Convert.ToInt16("W"); }

                    }



                    else if (Expresion[i] == '{')
                    {
                        int evaluar = i;
                        while (Expresion[evaluar] != '}')
                        {
                            evaluar++;
                        }
                        expresion.Add("<{>");

                    }
                    else if (Expresion[i] == '}')
                    {
                        expresion.Add("<}>");
                        int evaluar = i;
                        while (Expresion[evaluar] != '{')
                        {
                            evaluar--;
                        }

                    }
                    else if (Expresion[i] == '(')
                    {
                        int evaluar = i;
                        while (Expresion[evaluar] != ')')
                        {
                            evaluar++;
                        }
                        expresion.Add("<{>");
                        expresion.Add("<(>");

                    }
                    else if (Expresion[i] == ')')
                    {
                        int evaluar = i;
                        while (Expresion[evaluar] != '(')
                        {
                            evaluar--;
                        }
                        expresion.Add("<{>");
                        expresion.Add("<)>");

                    }
                    else if (Expresion[i] != ' ')
                    {
                        int x = Convert.ToInt16("W");
                    }
                }
                int cantidadN = 0;
                foreach (var item in expresion)
                {
                    if (item == "<N>")
                    {
                        cantidadN++;
                    }
                }
                if (cantidadN == 1)
                    return expresion;
                else return null;
            }
            catch
            {
                return null;
            }
        }
        public List<string> TokenActions(string Expresion)
        {
            try
            {
                int contador = 0;
                List<string> expresion = new List<string>();
                for (int i = 0; i < Expresion.Length; i++)
                {
                    if (Convert.ToInt16(Convert.ToByte(Expresion[i])) > 64 && Convert.ToInt16(Convert.ToByte(Expresion[i])) < 91)
                    {
                        contador++;
                        while (Convert.ToInt16(Convert.ToByte(Expresion[i])) > 64 && Convert.ToInt16(Convert.ToByte(Expresion[i])) < 91)
                        {
                            i++;
                        }
                        i--;
                        expresion.Add("<" + "ID" + ">");
                    }
                    else if (Expresion[i] == Convert.ToChar("'"))
                    {
                        expresion.Add("<'>");

                    }
                    else if (Expresion[i] == Convert.ToChar("="))
                    {
                        expresion.Add("<=>");

                    }
                    else if (Convert.ToInt16(Convert.ToByte(Expresion[i])) > 47 && Convert.ToInt16(Convert.ToByte(Expresion[i])) < 58)
                    {

                        while (Convert.ToInt16(Convert.ToByte(Expresion[i])) > 47 && Convert.ToInt16(Convert.ToByte(Expresion[i])) < 58)
                        {
                            i++;
                        }
                        i--;
                        expresion.Add("<" + "N" + ">");
                    }
                    else if (Expresion[i] != ' ')
                    {
                        expresion.Add("<" + "C" + ">");
                    }

                }
                return expresion;
            }
            catch { return null; }
        }// Metodo encargado de convertir a tokens las Actions
        public List<string> TokenError(string Expresion)
        {
            try
            {
                List<string> expresion = new List<string>();
                for (int i = 0; i < Expresion.Length; i++)
                {
                    if (Expresion[i] == 'E' && Expresion[i + 1] == 'R' && Expresion[i + 2] == 'R' && Expresion[i + 3] == 'O' && Expresion[i + 4] == 'R')
                    {
                        i = i + 4;
                        expresion.Add("<" + "ERROR" + ">");
                    }

                    else if (Expresion[i] == Convert.ToChar("="))
                    {
                        expresion.Add("<=>");

                    }
                    else if (Convert.ToInt16(Convert.ToByte(Expresion[i])) > 47 && Convert.ToInt16(Convert.ToByte(Expresion[i])) < 58)
                    {

                        while (Convert.ToInt16(Convert.ToByte(Expresion[i])) > 47 && Convert.ToInt16(Convert.ToByte(Expresion[i])) < 58 && i <= (Expresion.Length - 2))
                        {
                            i++;
                        }

                        expresion.Add("<" + "N" + ">");
                        if (Convert.ToInt16(Convert.ToByte(Expresion[i])) > 47 && Convert.ToInt16(Convert.ToByte(Expresion[i])) < 58)
                        {

                        }
                        else

                        {
                            expresion.Add("<" + "C" + ">");
                        }


                    }
                    else if (Expresion[i] != ' ')
                        expresion.Add("<" + "C" + ">");


                }

                return expresion;
            }
            catch
            {
                return null;
            }
        }// Metodo encargado de convertir a tokens los errores
        public bool analizarActions(string linea)
        {
            bool aux = true;
            try
            {
                for (int i = 0; i < linea.Length - 2; i++)
                {
                    if (Convert.ToInt16(Convert.ToByte(linea[i])) > 64 && Convert.ToInt16(Convert.ToByte(linea[i])) < 91)
                    {
                        aux = true;
                    }
                    else
                    {
                        aux = false;
                        break;
                    }
                }
                if (aux == true)
                {
                    if (linea[linea.Length - 2] == '(' && linea[linea.Length - 1] == ')')
                    {
                        aux = true;
                    }
                    else
                    {
                        aux = false;
                    }
                }

                return aux;
            }
            catch { return false; }
        }//Metodo encargado de verificar que el nombre del metodo actions este correcto
        public string Tokens(string Exp,Dictionary<string,string> Sets)// Metodo encargado de convertir a expresion tokens
        {
            Operadores.Clear();
            Operadores.Add("*");
            Operadores.Add("+");
            Operadores.Add(".");
            Operadores.Add("|");
            Operadores.Add(")");
            Operadores.Add("(");

            bool bandera = false;
            string Expresion = "";
            for (int i = 0; i<Exp.Length;i++)
            {
                if (bandera == true)
                    Expresion += Exp[i];
                if (bandera == false && Exp[i] == '=')
                    bandera = true;
            }
            
          
            
         
       
            string expresion = "";
            try
            {
                for (int i = 0; i < Expresion.Length; i++)
                {
        
                    if (Expresion[i] == Convert.ToChar("'"))
                    {
                        //expresion+=("<'>");
                        if (i + 1 != Expresion.Length)
                        {
                            if (Expresion[i + 1] != ' ' /*|| Expresion[i + 1] *//*!= Convert.ToChar("'")*/)
                            {
                                //expresion += ".";
                                expresion += ("<" + Expresion[i + 1] + ">");
                                i++;
                            }
                            if (Expresion[i + 1] == Convert.ToChar("'"))
                            {
                                //expresion += ".";
                                //expresion += ("<'>");
                                i++;
                                for(int j = i+1;j< Expresion.Length; j++)
                                {
                                    if ( Expresion[j] == Convert.ToChar("'") || (Convert.ToInt16(Convert.ToByte(Expresion[j])) > 64 && Convert.ToInt16(Convert.ToByte(Expresion[j])) < 91))
                                    {
                                        expresion += ".";
                                        j = Expresion.Length;
                                    }
                                    else if (Operadores.Contains(Expresion[j].ToString())|| Expresion[j] == '{') { j = Expresion.Length; }
                                }
                            }
                            else
                            {
                                int x = Convert.ToInt16("W");
                            }

                        }
                    }
                    else if (Convert.ToInt16(Convert.ToByte(Expresion[i])) > 64 && Convert.ToInt16(Convert.ToByte(Expresion[i])) < 91)
                    {
                        string sets = "";
                        while (Convert.ToInt16(Convert.ToByte(Expresion[i])) > 64 && Convert.ToInt16(Convert.ToByte(Expresion[i])) < 91)
                        {
                            sets += Expresion[i];
                            i++;
                        }
                        i--;
                        if (Sets.Keys.Contains(sets))
                        {
                            
                            expresion += ("<" + sets + ">");
                            for (int j = i+1; j < Expresion.Length; j++)
                            {
                                if ( Expresion[j] == Convert.ToChar("(") || Expresion[j] == Convert.ToChar("'") || (Convert.ToInt16(Convert.ToByte(Expresion[j])) > 64 && Convert.ToInt16(Convert.ToByte(Expresion[j])) < 91))
                                {
                                    expresion += ".";
                                    j = Expresion.Length;
                                }
                                else if(Operadores.Contains(Expresion[j].ToString()) || Expresion[j] == '{') { j = Expresion.Length; }
                            }
                        }

                        else
                        { int x = Convert.ToInt16("W"); }
                    }
                    else if(Operadores.Contains(Expresion[i].ToString()))
                    {
                        if (Expresion[i] == '*' || Expresion[i] == '+')
                        {
                            expresion += Expresion[i];
                            for (int j = i + 1; j < Expresion.Length; j++)
                            {
                                if ( Expresion[j] == Convert.ToChar("(") || Expresion[j] == Convert.ToChar("'") || (Convert.ToInt16(Convert.ToByte(Expresion[j])) > 64 && Convert.ToInt16(Convert.ToByte(Expresion[j])) < 91))
                                {
                                    expresion += ".";
                                    j = Expresion.Length;
                                }
                                else if (Operadores.Contains(Expresion[j].ToString()) || Expresion[j] == '{') { j = Expresion.Length; }
                            }
                        }
                        else
                        expresion += Expresion[i];
                    }
                    else if(Expresion[i].ToString() == "{")
                        i = Expresion.Length;
                 
                }
                return expresion;
            }
            catch { return null; }
        }
        public void EscribirFLN(string url, Árbol arbol)
        {
            var Nodos = arbol.FLNEscribir();
            var Unarios = arbol.RetornarOPUnarios();
            var NoUnarios = arbol.RetornarONoPUnarios();
            using (StreamWriter lector = new StreamWriter(url))
            {
                lector.WriteLine("Simbolo   " + "First   " + "Last   " + "Nullable   ");
                foreach (var item in Nodos)
                {
                    string es = "";
                    if ( item.id.Length != 1)
                    {
                        es += "'";
                        for (int i = 1; i < item.id.Length - 1; i++)
                        {
                            es += item.id[i];
                        }
                        es += "'";
                    }
                    else
                    {
                        es += item.id;
                    }
                    
                    lector.WriteLine( es+ " - " + item.First + " - " + item.Last + " - " + item.Nullable.ToString());
                }
            }
        }
        public void EscribirFollows(string url, Árbol arbol)
        {
            var Follows = arbol.RetornarFollows();
            using (StreamWriter lector = new StreamWriter(url))
            {
                lector.WriteLine("Simbolo   " + "Follow   " );
                foreach (var item in Follows)
                {
                    string escribir = item.Key+"  -  ";
                    foreach(var result in item.Value)
                    {
                        escribir += result + ",";
                    }
                    lector.WriteLine(escribir.Trim(','));
                }
            }
        }
        public void EscribirTransiciones(string url, Árbol arbol)
        {
            var Transiciones = arbol.RetornarTransiciones();
            var Terminales = arbol.RetornarTerminales();
            using (StreamWriter lector = new StreamWriter(url))
            {
                string escribir = "  ";
                foreach(var item in Terminales)
                {
                    escribir += item + " - ";
                }
                lector.WriteLine(escribir.TrimEnd('-',' '));
                foreach (var item in Transiciones)
                {
                    string escri = item.Key + "  |  ";
                    foreach (var result in item.Value)
                    {
                        if (result.Length > 0)
                            escri += result;
                        else
                            escri += "X";
                        escri += " - ";
                    }
                    lector.WriteLine(escri.TrimEnd('-',' '));
                }
            }
        }
        public void EscribirFinal(string url, Dictionary<string, string> Sets)
        {
            using (StreamWriter lector = new StreamWriter(url))
            {
                lector.WriteLine("SETS");
                foreach(var item in Sets)
                {
                    lector.WriteLine(item.Key + "|" + item.Value);
                }
            }
        }
    }
    class Program
    {

        static void Main(string[] args)
        {

            foreach (var arg in args)
            {
                try
                {
                string error = "";
                    Dictionary<string, string> Sets = new Dictionary<string, string>();
                    Dictionary<string, string> Actions = new Dictionary<string, string>();
                    Dictionary<string, string> Tokens_Sets = new Dictionary<string, string>();
                    Dictionary<string, string> Tokens = new Dictionary<string, string>();
                    Árbol Comparar = new Árbol();
                    int linea_Archivo = 0;
                    string ExpresionTokens = "";
                    int contadorErrores = 0;
                    int Validacion = 0;
                    bool Error = false;
                    string Error_tipo = "";
                    int Contador = 0;
                    int totalActions = 0;
                    string URL = @"C:\Users\jealb\OneDrive\Escritorio\Proyecto3.txt";
                    int contadorActions = 0;
                    using (StreamReader lector = new StreamReader(arg))
                    {
                        while (lector.Peek() > -1)
                        {
                            string linea = lector.ReadLine().Trim('\t');
                            linea_Archivo++;
                            if (!String.IsNullOrEmpty(linea))
                            {

                                switch (Validacion)
                                {
                                    case 0:
                                        linea = linea.Trim(' ');
                                        if (linea == "SETS")
                                        {
                                            Comparar.crear("(<ID>.<=>.((<'>.<C>.<'>)|(<CHR>.<(>.<N>.<)>)).((<..>|<+>).((<'>.<C>.<'>)|(<CHR>.<(>.<N>.<)>)))*)");// arbol sets
                                            Comparar.CrearArbol();
                                            Validacion++;
                                        }
                                        else if (linea == "TOKENS")
                                        {
                                            Comparar.crear("(<TOKEN>.<N>.<=>(<ID>|<'>.<C>.<'>|<*>|<|>|<+>|<(>|<)>|<{>|<}>*)");//arbol Tokens
                                            Comparar.CrearArbol();
                                            Validacion = 2;
                                        }
                                        else
                                        {
                                            Error_tipo = "La linea de comando 'SETS' o 'TOKENS' no se encuentra definida";
                                            Error = true;
                                        }
                                        break;
                                    case 1:
                                        if (linea.Contains("TOKEN") == false)
                                        {
                                            Expresiones evaluar = new Expresiones();
                                            var comp = evaluar.TokenSets(linea);
                                            if (comp == null)
                                            {
                                                Error_tipo = "Error en la sintaxis de linea";
                                                Error = true;
                                            }
                                            var lineafinal = linea.Replace(" ", "");
                                            var datos = lineafinal.Split('=');
                                            Sets.Add(datos[0], datos[1]);
                                            Contador++;
                                        }
                                        else
                                        {
                                            if (Contador > 0)
                                            {
                                                linea = linea.Trim(' ');
                                                if (linea == "TOKENS")
                                                {

                                                    Comparar.crear("(<TOKEN>.<N>.<=>(<ID>|<'>.<C>.<'>|<*>|<|>|<+>|<(>|<)>|<{>|<}>*)");// arbol tokens
                                                    Comparar.CrearArbol();
                                                    Validacion++;
                                                    Contador = 0;
                                                }
                                                else
                                                {
                                                    Error_tipo = "La linea de comando 'TOKENS' no se encuentra";
                                                    Error = true;
                                                }
                                            }
                                            else
                                            {
                                                Error_tipo = "No venia especificado ningun set";
                                                Error = true;
                                            }
                                        }
                                        break;
                                    case 2:
                                        if (linea.Contains("TOKEN"))
                                        {
                                            Expresiones evaluar = new Expresiones();
                                            var comp = evaluar.TokenTokens(linea.Replace('\t', ' '));
                                            if (comp == null)
                                            {
                                                Error_tipo = "Error en la sintaxis de linea";
                                                Error = true;
                                            }
                                            string ex = evaluar.Tokens(linea, Sets);
                                            var Token = linea.Split('=');
                                            string Tok = "";
                                            int aux = 0;
                                            for(int i = 0; i<linea.Length;i++)
                                            {
                                                if(aux ==0 && linea[i]== '=')
                                                {
                                                aux++;
                                                }
                                                else if(aux >0)
                                            {
                                                Tok += linea[i];
                                            }
                                            }
                                            var Definicion = Token[0].Split(' ');
                                            bool agregar = true;
                                            foreach (var item in Sets)
                                            {
                                            if (Token[1].Contains(item.Key))
                                             {
                                                agregar = false;
                                                break;
                                             }
                                            }
                                            if(agregar == true)
                                            {
                                            string comillas = "";
                                            for (int i = 0; i < Tok.Length; i++)
                                            {
                                                if (Tok[i] == '\'') 
                                                {
                                                    comillas += Tok[i + 1];
                                                    i = i + 2;
                                                }
                                            }
                                            if (comillas.Contains('\''))
                                            {
                                                comillas.Replace("'", "\\"+"'");
                                            }
                                            if (comillas.Contains('"'))
                                            {
                                                comillas.Replace("\"", "\\" + "\"");
                                            }
                                            if(Definicion.Length==2)
                                            Tokens.Add(comillas, Definicion[1]);
                                            else
                                            {
                                                string add = "";
                                                int con = 0;
                                                foreach(var item in Definicion)
                                                {
                                                    if(item.Length>0&&con==0)
                                                    {
                                                        con++;
                                                    }
                                                    else if(item.Length>0&&con>0)
                                                    {
                                                        add = item;
                                                    }
                                                }
                                                Tokens.Add(comillas, add);
                                            }
                                            }
                                            else
                                            {
                                          
                                            Tokens_Sets.Add(Tok, Definicion[1]);
                                            }
                                            if (ex != null)
                                            {
                                                if (Contador == 0)
                                                {
                                                    ExpresionTokens += "(" + (ex) + ")";
                                                }
                                                else
                                                {
                                                    ExpresionTokens += "|" + "(" + (ex) + ")"; ;
                                                }
                                                Contador++;
                                            }
                                            else
                                            {
                                                Error_tipo = "Token no especificado en SETS";
                                                Error = true;
                                            }
                                        }
                                        else
                                        {
                                            if (Contador > 0)
                                            {
                                                linea = linea.Trim(' ');
                                                if (linea == "ACTIONS")
                                                {
                                                    Comparar.crear("(<N>.<=>.<'>.<ID>.<'>)");// arbol actions
                                                    Comparar.CrearArbol();
                                                    Validacion++;
                                                    Contador = 0;
                                                }
                                                else if (linea == "")
                                                { }
                                                else
                                                {
                                                    Error_tipo = "La linea de comando 'ACTIONS' no se encuentra o error al definir token";
                                                    Error = true;
                                                }
                                            }
                                            else
                                            {
                                                Error_tipo = "No venia especificado ningun TOKEN";
                                                Error = true;
                                            }
                                        }
                                        break;
                                    case 3:


                                        if (contadorActions == 0)
                                        {
                                            Expresiones actions = new Expresiones();
                                            if (actions.analizarActions(linea.Trim(' ')) && totalActions == 0 && linea.Trim(' ') == "RESERVADAS()")
                                            {
                                                contadorActions++;
                                            }
                                            else if (totalActions > 0)
                                            {
                                                if (actions.analizarActions(linea.Trim(' ')))
                                                {
                                                    contadorActions++;
                                                    Contador = 0;
                                                }
                                                else if (linea.Contains("ERROR"))
                                                {
                                                    error = linea;
                                                    Comparar.crear("(<ERROR>.<=>.<N>)");
                                                    Comparar.CrearArbol();
                                                    Validacion++;
                                                    Expresiones evaluar = new Expresiones();
                                                    var comp = evaluar.TokenError(linea);
                                                    if (comp == null || comp.Count != 3)
                                                    {
                                                        Error_tipo = "Error en la sintaxis de linea";
                                                        Error = true;
                                                    }
                                                    contadorErrores++;
                                                    Contador++;
                                                }
                                                else if (actions.analizarActions(linea) == false)
                                                {
                                                    Error_tipo = "Action definida incorrectamente ";
                                                    Error = true;
                                                }
                                            }

                                            else
                                            {
                                                Error_tipo = "Action definida incorrectamente o no viene definido un error";
                                                Error = true;
                                            }
                                        }
                                        else if (contadorActions == 1)
                                        {
                                            if (linea.Trim(' ') == "{")
                                            {
                                                contadorActions++;
                                            }
                                            else
                                            {
                                                Error_tipo = "Error en inicio de Action <{>";
                                                Error = true;
                                            }
                                        }
                                        else if (contadorActions == 2)
                                        {
                                            if (linea.Trim(' ') == "}")
                                            {
                                                if (Contador == 0)
                                                {
                                                    Error_tipo = "No venia definido ningun elemento en el Action";
                                                    Error = true;
                                                }
                                                else
                                                {
                                                    totalActions++;

                                                    contadorActions = 0;
                                                }
                                            }
                                            else if (linea == "" || linea == " " || linea == "\t")
                                            {

                                            }
                                            else if (linea.Contains("ERROR") == false)
                                            {
                                                Expresiones evaluar = new Expresiones();
                                                var comp = evaluar.TokenActions(linea);

                                                if (comp == null || comp.Count != 5)
                                                {
                                                    Error_tipo = "Error en la sintaxis de linea";
                                                    Error = true;
                                                }
                                            var accion = linea.Split('=');
                                            Actions.Add(accion[1].Trim('\'',' '), accion[0]);
                                                Contador++;
                                            }

                                            else
                                            {
                                                Error_tipo = "Error en final de Action <}>";
                                                Error = true;
                                            }
                                        }
                                        else
                                        {
                                            if (linea.Contains("ERROR"))
                                            {
                                            error = linea;

                                                contadorErrores++;

                                            }

                                        }


                                        break;
                                    case 4:
                                        if (contadorErrores > 0)
                                        {
                                            error = linea;
                                            Expresiones evaluar = new Expresiones();
                                            var comp = evaluar.TokenError(linea);
                                            if (comp == null || comp.Count != 3)
                                            {
                                                Error_tipo = "Error en la sintaxis de linea";
                                                Error = true;
                                            }
                                            contadorErrores++;
                                            Contador++;
                                        }
                                        else
                                        {
                                            Error_tipo = "se esperaba algun error";
                                            Error = true;
                                        }
                                        break;
                                }
                            }

                            if (Error == true)
                            {
                                break;
                            }

                        }
                        if (totalActions > 0 && contadorErrores == 0 && Error != true)
                        {

                            Error = true;
                            Error_tipo = "No venia ningun error definido";
                            linea_Archivo++;

                        }
                        if (Validacion == 0)
                        {
                            Error = true;
                            Error_tipo = "Archivo en blanco";
                        }
                        if (Error == true)
                        {
                            Console.WriteLine("Error en la linea " + Convert.ToString(linea_Archivo) + " Posible error: " + Error_tipo);
                        }

                        else
                        {
                            Console.WriteLine("Lectura realizada exitosamente");
                            Árbol tablas = new Árbol();
                            tablas.Automata(ExpresionTokens);
                            Expresiones Escritura = new Expresiones();
                            var direccion = arg.Split('.');//ARG
                            Escritura.EscribirFLN(direccion[0] + "FLN." + direccion[1], tablas);
                            Escritura.EscribirFollows(direccion[0] + "Follows." + direccion[1], tablas);
                            Escritura.EscribirTransiciones(direccion[0] + "Transiciones." + direccion[1], tablas);
                            Automata programa = new Automata();
                            var err = error.Split('=');
                            programa.crear(tablas.RetornarTransiciones(), tablas.RetornarFollows(),Sets, tablas.RetornarTerminales(),err[1],Actions,Tokens,Tokens_Sets);
                        }
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------");
                        Console.ReadKey();



                    }
                }
                catch
                {
                    Console.WriteLine("Archvio incorrecto");
                    Console.ReadKey();
                }

            }

        }
    }

}

