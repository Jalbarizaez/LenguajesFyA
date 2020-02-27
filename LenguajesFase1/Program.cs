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

    }
    class Program
    {
        static void Main(string[] args)
        {
            //foreach (var arg in args)
            //{


                Árbol Comparar = new Árbol();
            //sets.crear("(< >*.<ID>.< >*.<=>.< >*.((<'>.<C>.<'>)|(<CHR>.<(>.<N>.<)>)).((<..>|<+>).(<'>.<C>.<'>)|(<CHR>.<(>.<N>.<)>))+)");
            //sets.CrearArbol();

            //Árbol tokens = new Árbol();
            //tokens.crear("(< >*.<TOKEN>.< >*.<D>.< >*.<=>.< >*.((<'>.<C>.<'>)|<ID>|<|>|<(>|<)>|<*>|<{>|<}>)+)");
            //tokens.CrearArbol();


                int linea_Archivo = 0;
                int Validacion = 0;
                bool Error = false;
                string Error_tipo = "";
                int Contador = 0;
                string URL =  @"C:\Users\jealb\OneDrive\Escritorio\Prueba.txt";
                using (StreamReader lector = new StreamReader(URL))
                {
                    while (lector.Peek() > -1)
                    {
                        string linea = lector.ReadLine();
                        linea_Archivo++;
                    if (!String.IsNullOrEmpty(linea))
                        {

                            switch (Validacion)
                            {
                                case 0:
                                    if(linea == "SETS")
                                    {
                                        Comparar.crear("(< >*.<ID>.< >*.<=>.< >*.((<'>.<C>.<'>)|(<CHR>.<(>.<N>.<)>)).((<..>|<+>).(<'>.<C>.<'>)|(<CHR>.<(>.<N>.<)>))+)");
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
                                       
                                        Contador++;
                                    }
                                    else
                                    {
                                        if(Contador>0)
                                        {
                                            if (linea =="TOKENS")
                                            {
                                                Comparar.crear("(< >*.<TOKEN>.< >*.<D>.< >*.<=>.< >*.((<'>.<C>.<'>)|<ID>|<|>|<(>|<)>|<*>|<{>|<}>)+)");
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
                                    
                                    Contador++;
                                }
                                else
                                {
                                    if (Contador > 0)
                                    {
                                        if (linea == "ACTIONS")
                                        {
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
                Console.ReadKey();
            }
        }
    }
//}
