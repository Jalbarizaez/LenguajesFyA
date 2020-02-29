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
        public List<string> TokenSets(string Expresion)
        {
            int contador = 0;
            List<string> expresion = new List<string>();
            for (int i = 0; i < Expresion.Length; i++)
            {
                if (Expresion[i] == '.' && Expresion[i + 1] == '.')
                {
                    i++;
                    expresion.Add("<" + ".." + ">");
                }
                else if (Expresion[i] == 'C' && Expresion[i + 1] == 'H' && Expresion[i + 2] == 'R')
                {
                    i = i + 2;
                    expresion.Add("<CHR>");
                    if (Expresion[i + 1] == '(')
                    {
                        i = i+2;
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
                        catch { }
                        if (Expresion[i] == ')')
                            expresion.Add("<)>");
                    }
                }
                else if (Convert.ToInt16(Convert.ToByte(Expresion[i])) > 64 && Convert.ToInt16(Convert.ToByte(Expresion[i])) <91 )
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
                        if(Expresion[i + 1] == Convert.ToChar("'"))
                        {
                            expresion.Add("<'>");
                            i++;
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
                
            }
            return expresion;
        }
        public List<string> TokenTokens(string Expresion)
        {
            
            List<string> expresion = new List<string>();
            for (int i = 0; i < Expresion.Length; i++)
            {
               if (Expresion[i] == 'T' && Expresion[i + 1] == 'O' && Expresion[i + 2] == 'K' && Expresion[i + 3] == 'E' && Expresion[i + 4] == 'N')
                {
                    i = i+4;
                    expresion.Add("<" + "TOKEN" + ">");
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
                    expresion.Add("<|>");

                }
                else if (Expresion[i] == '{')
                {
                    expresion.Add("<{>");

                }
                else if (Expresion[i] == '}')
                {
                    expresion.Add("<}>");

                }
                else if (Expresion[i] == '(')
                {
                    expresion.Add("<(>");

                }
                else if (Expresion[i] == ')')
                {
                    expresion.Add("<)>");

                }
            }
            return expresion;
        }
        public List<string> TokenActions(string Expresion)
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
               
            }
            return expresion;
        }
        public bool analizarActions (string linea)
        {
            bool aux = true;
            for(int i = 0; i<linea.Length-2; i++)
            {
                if(Convert.ToInt16(Convert.ToByte(linea[i])) > 64 && Convert.ToInt16(Convert.ToByte(linea[i])) < 91)
                {
                    aux = true;
                }
                else
                {
                    aux = false;
                    break;
                }
            }
            if(aux == true)
            {
                if(linea[linea.Length-2] == '('&& linea[linea.Length - 1] == ')')
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
    }
    class Program
    {
        static void Main(string[] args)
        {
            //foreach (var arg in args)
            //{


                Árbol Comparar = new Árbol();
                int linea_Archivo = 0;
                int Validacion = 0;
                bool Error = false;
                string Error_tipo = "";
                int Contador = 0;
                int totalActions = 0;
                string URL =  @"C:\Users\jealb\OneDrive\Escritorio\Prueba.txt";
                int contadorActions = 0;
                using (StreamReader lector = new StreamReader(URL))
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
                                    if(linea == "SETS")
                                    {
                                        Comparar.crear("(<ID>.<=>.((<'>.<C>.<'>)|(<CHR>.<(>.<N>.<)>)).((<..>|<+>).((<'>.<C>.<'>)|(<CHR>.<(>.<N>.<)>)))*)");
                                        Comparar.CrearArbol();
                                        Validacion++;
                                    }
                                    else
                                    {
                                        Error_tipo = "La linea de comando 'SETS' no se encuentra";
                                        Error = true;
                                    }
                                    break;
                                case 1:
                                    if(linea.Contains("TOKEN")==false)
                                    {
                                    Expresiones evaluar = new Expresiones();
                                    var comp = evaluar.TokenSets(linea);
                                    Comparar.in_orden(comp);
                                    Contador++;
                                    }
                                    else
                                    {
                                        if(Contador>0)
                                        {
                                            if (linea =="TOKENS")
                                            {
                                            
                                                Comparar.crear("(<TOKEN>.<N>.<=>(<ID>|<'>.<C>.<'>|<*>|<|>|<+>))");
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
                                    var comp = evaluar.TokenTokens(linea);
                                    Contador++;
                                }
                                else
                                {
                                    if (Contador > 0)
                                    {
                                        if (linea == "ACTIONS")
                                        {
                                            Comparar.crear("(<N>.<=>.<'>.<ID>.<'>)");
                                            Comparar.CrearArbol();
                                            Validacion++;
                                            Contador = 0;
                                        }
                                        else 
                                        {
                                            Error_tipo = "La linea de comando 'ACTIONS' no se encuentra";
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
                                        if (actions.analizarActions(linea)&& totalActions ==0)
                                        {
                                            contadorActions++;
                                        }
                                        else if(totalActions>0)
                                    {
                                        if (actions.analizarActions(linea))
                                        {
                                            contadorActions++;
                                        }
                                        else
                                        {
                                            Comparar.crear("(<N>.<=>.<'>.<ID>.<'>)");
                                            Comparar.CrearArbol();
                                            Validacion++;
                                            Expresiones evaluar = new Expresiones();
                                            //var comp = evaluar.TokenError(linea);
                                            Contador++;
                                        }
                                    }
                                        else
                                        {
                                            Error_tipo = "Action definida incorrectamente";
                                            Error = true;
                                        }
                                    }
                                    else if (contadorActions == 1)
                                    {
                                        if (linea == "{")
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
                                        if (linea == "}")
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
                                        else if (linea.Contains("ERROR") == false)
                                        {
                                            Expresiones evaluar = new Expresiones();
                                            var comp = evaluar.TokenActions(linea);
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
                                        if(linea.Contains("ERROR"))
                                        {

                                        }
                                    }
                                

                                    break;
                               case 4:
                                    break;
                            }
                        }
                        if(Error== true)
                        {
                            break;
                        }
                    }
                }
                if(Error == true)
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
//}
