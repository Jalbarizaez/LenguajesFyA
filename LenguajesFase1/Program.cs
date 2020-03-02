using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LenguajesFase1
{
    class Expresiones
    {
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
                    else if (i < Expresion.Length - 1&& Expresion[i] == '.')
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
                    { if (Expresion[i] == 'T' && Expresion[i + 1] == 'O' && Expresion[i + 2] == 'K' && Expresion[i + 3] == 'E' && Expresion[i + 4] == 'N')
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
                    else if (Expresion[i] == '|')
                    {
                        if (char.IsUpper(Expresion[i+1]) || Expresion[i+1] == Convert.ToChar("'") || Expresion[i+1] == ' ')
                        { expresion.Add("<|>"); }
                        else { int x = Convert.ToInt16("W"); }

                    }
                    else if (Expresion[i] == '{')
                    {
                        int evaluar = i;
                        while(Expresion[evaluar]!= '}')
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
                foreach(var item in expresion)
                {
                    if(item == "<N>")
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
                    else if(Expresion[i] != ' ')
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
    }
    class Program
    {
        static void Main(string[] args)
        {

            foreach (var arg in args)
            {



                Árbol Comparar = new Árbol();
                    int linea_Archivo = 0;
                    int contadorErrores = 0;
                    int Validacion = 0;
                    bool Error = false;
                    string Error_tipo = "";
                    int Contador = 0;
                    int totalActions = 0;
                    string URL = @"C:\Users\jealb\OneDrive\Escritorio\Prueba1.txt";
                    int contadorActions = 0;
                    using (StreamReader lector = new StreamReader(@arg))
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
                                            var comp = evaluar.TokenTokens(linea.Replace('\t',' '));
                                        if (comp == null )
                                        {
                                            Error_tipo = "Error en la sintaxis de linea";
                                            Error = true;
                                        }
                                        Contador++;
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
                                                else if(linea =="")
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
                                            if (actions.analizarActions(linea.Trim(' ')) && totalActions == 0&& linea.Trim(' ') =="RESERVADAS()")
                                            {
                                                contadorActions++;
                                            }
                                            else if (totalActions > 0)
                                            {
                                                if (actions.analizarActions(linea))
                                                {
                                                    contadorActions++;
                                                }
                                                else if (linea.Contains("ERROR"))
                                                {
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
                                        else if(actions.analizarActions(linea) == false)
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
                                        else if (linea == ""|| linea == " "|| linea == "\t")
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
                                                contadorErrores++;

                                            }

                                        }


                                        break;
                                    case 4:
                                        if (contadorErrores > 0)
                                        {
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
                        if (totalActions > 0 && contadorErrores == 0&& Error != true)
                        {

                            Error = true;
                            Error_tipo = "No venia ningun error definido";
                            linea_Archivo++;

                        }
                        if (Error == true)
                        {
                            Console.WriteLine("Error en la linea " + Convert.ToString(linea_Archivo) + " Posible error: " + Error_tipo);
                        }

                        else
                        {
                            Console.WriteLine("Lectura realizada exitosamente");
                        }
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------");
                        Console.ReadKey();



                    }
                }
            
    }

    }
}
