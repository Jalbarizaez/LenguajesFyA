using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LenguajesFase1
{
    class Automata
    {
        public static string error = "";
        public static Dictionary<string, string> Token = new Dictionary<string, string>();
        public static Dictionary<string, string> Token_Sets = new Dictionary<string, string>();
        public static Dictionary<string, string> Sets = new Dictionary<string, string>();
        public static Dictionary<int, string> Estados_Abreviados = new Dictionary<int,string>();
        public static Dictionary<string, string> Actions = new Dictionary<string, string>();
        public static Dictionary<string, List<string>> Transiciones = new Dictionary<string, List<string>>();
        public static List<int> Cantidad_Transiciones = new List<int>();
        public static List<int> Estados_Aceptacion = new List<int>();
        public static List<string> Terminales = new List<string>();
        public static void EscribirNuevaSolucion()
        {

            using (var writer = new StreamWriter(@"C:\Users\jealb\OneDrive\Escritorio\Compilar\Compilar\Program.cs"))
            {
                writer.WriteLine("using System;");
                writer.WriteLine("using System.Collections.Generic;");
                writer.WriteLine("using System.Linq;");
                writer.WriteLine("using System.Text;");
                writer.WriteLine("using System.Threading.Tasks;");
                writer.WriteLine("namespace Compilar");
                writer.WriteLine("{");
                writer.WriteLine("      class program");
                writer.WriteLine("      {");
                writer.WriteLine("          public static string cadena = \"\";");
                writer.WriteLine("          public static List<int> Estados_Aceptacion = new List<int>();");
                writer.WriteLine("          public static Dictionary<string, string> Actions = new Dictionary<string, string>();");
                writer.WriteLine("          public static Dictionary<string, string> Token = new Dictionary<string, string>();");
                writer.WriteLine("          public static Dictionary<string, string> Token_Sets = new Dictionary<string, string>();");
                writer.WriteLine("          static void Main(string[] args)");
                writer.WriteLine("          {");
                writer.WriteLine("              Console.WriteLine(\"Ingrese la cadena \");");
                
                writer.WriteLine("              cadena = Console.ReadLine();");
                writer.WriteLine("              Console.WriteLine(\"-------------------------------------------------\");");
                writer.WriteLine("              LlenarListaAceptados();");
                writer.WriteLine("              LlenarActions();");
                writer.WriteLine("              LlenarTokens();");
                writer.WriteLine("              LlenarTokens_Sets();");
                writer.WriteLine("              bool resultado = EvaluarCadena(cadena);");
                writer.WriteLine("              if (resultado == true)");
                writer.WriteLine("              {");

                writer.WriteLine("                Console.WriteLine(\"Correcto\");");
                writer.WriteLine("              }");
                writer.WriteLine("              else");
                writer.WriteLine("              {");
                writer.WriteLine("                  Console.WriteLine(\"Incorrecto\");");
                writer.WriteLine($"                  Console.WriteLine(\"Error \" + \"{error}\");");
                writer.WriteLine("               }");
 
                 writer.WriteLine("              Console.ReadKey();");
                writer.WriteLine("          }");

                writer.WriteLine("");

                writer.WriteLine("          public static bool  EvaluarCadena(string cadena)");
                writer.WriteLine("          {");
                writer.WriteLine("          List<string> evaluar = new List<string>();");
                writer.WriteLine("              bool Resultado = false;");
                writer.WriteLine("              var vectorPalabras = cadena.Split(' ');");
                writer.WriteLine("              for(int i=0; i< vectorPalabras.Length; i++)");
                writer.WriteLine("              {");
                
                writer.WriteLine("                  var temp= vectorPalabras[i];");
                writer.WriteLine("                  if (temp.Length != 0)");
                writer.WriteLine("                  Resultado = true;");
                writer.WriteLine("                  var estado_temporal = 0;");
                writer.WriteLine("                  {");
                writer.WriteLine("                  for(int j=0; j < temp.Length; j++) ");
                writer.WriteLine("                  {");
                writer.WriteLine("                      switch(estado_temporal)");
                writer.WriteLine("                      {");
                
                var lenght = Transiciones.Values.First().Count;
                for (int i = 0; i < Transiciones.Keys.Count; i++)
                {
                    int Contador = 0;
                    writer.WriteLine($"                         case {i}:");
                    for (int j = 0; j < Terminales.Count ; j++)
                    {
                        
                        if (VerificarSiSeHace(i, j) == true)
                        {
                            
                            if (Sets.Keys.Contains(Terminales[j].Substring(1, Terminales[j].Length-2)))
                            {

                             
                                if (Contador == 0)
                                { Contador++; writer.WriteLine($"                                          if({DevolverLineaIf(Terminales[j].Substring(1, Terminales[j].Length - 2))}) //{Terminales[j].Substring(1, Terminales[j].Length - 2)}"); }
                                else { writer.WriteLine($"                                          else if({DevolverLineaIf(Terminales[j].Substring(1, Terminales[j].Length - 2))}) //{Terminales[j].Substring(1, Terminales[j].Length - 2)}"); }
                                writer.WriteLine("                                           {");
                                writer.WriteLine($"                                              estado_temporal = {DefinirEstado(i, Terminales[j].Substring(1, Terminales[j].Length - 2), j)};");
                                writer.WriteLine($"                                              evaluar.Add(\"{Terminales[j].Substring(1, Terminales[j].Length - 2)}\");");
                                writer.WriteLine("                                           }");
                            }
                            else
                            {
                                if (Contador == 0)
                                {   if (Terminales[j].Substring(1, Terminales[j].Length - 2).Contains( "\'"))
                                    { Contador++; writer.WriteLine($"                                           if (temp[j] == \'{'\\'+Terminales[j].Substring(1, Terminales[j].Length - 2)}\') ");
                                       
                                    }
                                    else
                                    { Contador++; writer.WriteLine($"                                           if (temp[j] == \'{Terminales[j].Substring(1, Terminales[j].Length - 2)}\') ");

                                    }
                                }
                                else
                                {
                                    if (Terminales[j].Substring(1, Terminales[j].Length - 2).Contains("\'"))
                                        writer.WriteLine($"                                          else if (temp[j] == \'{'\\'+Terminales[j].Substring(1, Terminales[j].Length - 2)}\') ");
                                    else
                                        writer.WriteLine($"                                          else if (temp[j] == \'{Terminales[j].Substring(1, Terminales[j].Length - 2)}\') ");
                                }
                                writer.WriteLine("                                           {");
                                writer.WriteLine($"                                              estado_temporal = {DefinirEstado(i, Terminales[j].Substring(1, Terminales[j].Length - 2), j)};");
                                Contador++; writer.WriteLine($"                                           evaluar.Add(temp[j].ToString());");
                                writer.WriteLine("                                           }");
                            }


                            //writer.WriteLine("                                           else");
                            //writer.WriteLine("                                           {   Resultado = false; i = temp.Length;   }");
                        }
                        //writer.WriteLine("                                           else");
                        //writer.WriteLine("                                           {   Resultado = false; i = temp.Length;   }");
                    }
                    if (Contador > 0)
                    {
                        writer.WriteLine("                                           else");
                        writer.WriteLine("                                           {   Resultado = false; j = temp.Length;   }");
                    }
                    writer.WriteLine($"                             break;");
                }
                writer.WriteLine("                      }");
                writer.WriteLine("                  }");
                writer.WriteLine(""); 
                writer.WriteLine("                  if(ComprobarEstado(estado_temporal) == false|| Resultado == false)");
                writer.WriteLine("                  {");
                writer.WriteLine("                      Console.WriteLine(\"Error al analizar \" + temp);");
                writer.WriteLine("                      Resultado = false;");
                writer.WriteLine("                      break;");
                writer.WriteLine("                  }");
                writer.WriteLine("                  else");
                writer.WriteLine("                  {");
                writer.WriteLine("                      if(Actions.Keys.Contains(temp))");
                writer.WriteLine("                      {");
                writer.WriteLine("                          Console.WriteLine(temp + \" \" + Actions[temp]);");
                writer.WriteLine("                      }");
                writer.WriteLine("                      else if(Token.Keys.Contains(temp))");
                writer.WriteLine("                      {");
                writer.WriteLine("                          Console.WriteLine(temp + \" \" + Token[temp]);");
                writer.WriteLine("                      }");
                writer.WriteLine("                      else if(Analizar_Sets(evaluar) == true)");
                writer.WriteLine("                      {");
                writer.WriteLine("                          string set = Dev_Sets(evaluar);");
                writer.WriteLine("                          Console.WriteLine(temp + \" \"+ Token_Sets[set]);");
                writer.WriteLine("                      }");

                writer.WriteLine("                  }");
                writer.WriteLine("                      evaluar.Clear();");
                writer.WriteLine("                 }");
                writer.WriteLine("              }");
                writer.WriteLine("              return Resultado;");
                writer.WriteLine("          }");
                writer.WriteLine("");
                writer.WriteLine("          public static bool Analizar_Sets(List<string> Sets)");//Primer Metodo
                writer.WriteLine("          {");
                writer.WriteLine("              bool verificar = false;");
                writer.WriteLine("              foreach (var item in Token_Sets)");
                writer.WriteLine("              {");

                writer.WriteLine("                  int contarOK = 0;");
                writer.WriteLine("                  foreach (var set in Sets)");
                writer.WriteLine("                  {");
                writer.WriteLine("                      if (item.Key.Contains(set))");
                writer.WriteLine("                      {");
                writer.WriteLine("                          contarOK++;");
                writer.WriteLine("                      }");
                writer.WriteLine("                  }");
                writer.WriteLine("                  if (contarOK == Sets.Count)");
                writer.WriteLine("                  {");
                writer.WriteLine("                      verificar = true;");
                writer.WriteLine("                      break;");
                writer.WriteLine("                  }");
                writer.WriteLine("              }");
                writer.WriteLine("              return verificar;");
                writer.WriteLine("          }");
                writer.WriteLine("          public static string Dev_Sets(List<string> Sets)");//Segundo Metodo
                writer.WriteLine("          {");
                writer.WriteLine("              string verificar = \"\";");
                writer.WriteLine("              foreach (var item in Token_Sets)");
                writer.WriteLine("              {");

                writer.WriteLine("                  int contarOK = 0;");
                writer.WriteLine("                  foreach (var set in Sets)");
                writer.WriteLine("                  {");
                writer.WriteLine("                      if (item.Key.Contains(set))");
                writer.WriteLine("                      {");
                writer.WriteLine("                          contarOK++;");
                writer.WriteLine("                      }");
                writer.WriteLine("                  }");
                writer.WriteLine("                  if (contarOK == Sets.Count)");
                writer.WriteLine("                  {");
                writer.WriteLine("                      verificar = item.Key;");
                writer.WriteLine("                      break;");
                writer.WriteLine("                  }");
                writer.WriteLine("              }");
                writer.WriteLine("              return verificar;");
                writer.WriteLine("          }");
                writer.WriteLine("          public static void LlenarListaAceptados()");
                writer.WriteLine("          {");
                for (int i = 0; i < Estados_Aceptacion.Count; i++)
                {
                    writer.WriteLine($"                 Estados_Aceptacion.Add({Estados_Aceptacion[i]});");
                }
                writer.WriteLine("          }");
                writer.WriteLine("          public static void LlenarActions()");
                writer.WriteLine("          {");
                foreach(var item in Actions)
                {
                    writer.WriteLine($"                 Actions.Add(\"{item.Key}\",\"{item.Value}\");");
                }
                writer.WriteLine("          }");
                writer.WriteLine("          public static void LlenarTokens()");
                writer.WriteLine("          {");
                foreach (var item in Token)
                {
                    writer.WriteLine($"                 Token.Add(\"{item.Key}\",\"{item.Value}\");");
                }
                writer.WriteLine("          }");
                writer.WriteLine("          public static void LlenarTokens_Sets()");
                writer.WriteLine("          {");
                foreach (var item in Token_Sets)
                {
                    string escribir="";
                    string ayuda = item.Key;
                    for (int i = 0; i <ayuda.Length;i++)
                    {
                        if(ayuda[i]=='\'')
                        {
                            i++;
                            if(ayuda[i] == '\'' )
                            {
                                escribir += "\\" + "'";
                            }
                            else if(ayuda[i] == '"')
                            {
                                escribir += "\\" + "\"";

                            }
                            else
                            {
                                escribir += ayuda[i];
                            }
                            i++;
                        }
                        else
                        {
                            escribir += ayuda[i];
                        }
                    }
                    writer.WriteLine($"                 Token_Sets.Add(\"{escribir}\",\"{item.Value}\");");
                }
                writer.WriteLine("          }");
                writer.WriteLine("          public static bool ComprobarEstado(int estado)");
                writer.WriteLine("          {");
                writer.WriteLine("              if(Estados_Aceptacion.Contains(estado))");
                writer.WriteLine("              {");
                writer.WriteLine("                 return true;");
                writer.WriteLine("              }");
                writer.WriteLine("              return false;");
                writer.WriteLine("          }");
                writer.WriteLine("      }");
                writer.WriteLine("}");
                writer.Close();
            }
        }
        public static string DevolverLineaIf(string keySet)
        {
            var respuesta = Sets[keySet];
            var condicion = string.Empty;
            var bandera_comilla = false;
            for (int i = 0; i < respuesta.Length; i++)
            {
                if (respuesta[i] == '\'' && bandera_comilla == false)
                {
                    if (i + 3 < respuesta.Length)
                    {
                        condicion += $"Convert.ToByte(temp[j]) >= {Convert.ToByte(respuesta[i + 1])} ";
                        i += 2;
                        bandera_comilla = true;
                    }
                    else
                    {
                        condicion += $"Convert.ToByte(temp[j]) == {Convert.ToByte(respuesta[i + 1])}";
                        i += 2;
                    }
                }
                else if (respuesta[i] == '\'' && bandera_comilla == true)
                {
                    condicion += $"Convert.ToByte(temp[j])<= {Convert.ToByte(respuesta[i + 1])}";
                    i += 2;
                    bandera_comilla = false;
                }
                else if (respuesta[i] == '.')
                {
                    condicion += " && ";
                    i++;
                }
                else if (respuesta[i] == '+')
                {
                    condicion += " || ";
                }
                else if (respuesta[i] == 'C' && bandera_comilla == false)
                {
                    string aux = "";
                    i = i + 4;
                    bool ciclo = true;
                    while (ciclo)
                    {
                        if (respuesta[i] != ')')
                        { aux += respuesta[i];
                        i++; }
                        else
                            ciclo = false;
                    }
                    if(i+aux.Length< respuesta.Length)
                    {
                        bandera_comilla = true;
                        condicion += $"Convert.ToByte(temp[j]) >= {aux} ";
                       
                    }
                    else
                    {
                        condicion += $"Convert.ToByte(temp[j]) == {aux} ";
                       
                    }
                    //REVISAR CHR(N)
                }
                else if (respuesta[i] == 'C' && bandera_comilla == true)
                {
                    string aux = "";
                    i = i + 4;
                    bool ciclo = true;
                    while (ciclo)
                    {
                        if (respuesta[i] != ')')
                        {
                            aux += respuesta[i];
                            i++;
                        }
                        else
                            ciclo = false;
                    }
                    bandera_comilla = false;
                    condicion += $"Convert.ToByte(temp[j]) <= {aux} ";
                    
                }
            }
            return condicion;
        }
        public static int DefinirEstado(int estadoEmisor, string transicion, int posicion_transicion)
        {
            var lista_Estado_Temporal = Estados_Abreviados[estadoEmisor];
            var lista_transiciones = new List<string>();
            var nuevo_Estado = "";
            foreach (var item in Transiciones.Keys)
            {
                if (lista_Estado_Temporal.SequenceEqual(item))
                {
                    lista_transiciones = Transiciones[item];
                    break;
                }
            }
            nuevo_Estado = lista_transiciones[posicion_transicion];
            var resultado = 0;
            foreach (var item in Estados_Abreviados.Keys)
            {
                if (nuevo_Estado ==(Estados_Abreviados[item]))
                {
                    resultado = item;
                    break;
                }
            }
            return resultado;
        }
        public static void LlenarDiccionarioAbreviado(Dictionary<string, List<string>> Transiciones)
        {
        
            var numero_Estado = 0;
            foreach (var item in Transiciones.Keys)
            {
                Estados_Abreviados.Add(numero_Estado, item);
                numero_Estado++;
            }
        }
        public static void LlenarContadorTransiciones()
        {
            foreach (var item in Transiciones.Keys)
            {
                var contador = 0;
                var Lista_Transiciones = Transiciones[item];
                for (int i = 0; i < Lista_Transiciones.Count ; i++)
                {
                    var temp = Lista_Transiciones[i];
                    if (temp.Length != 0)
                    {
                        contador++;
                    }
                }
                Cantidad_Transiciones.Add(contador);
            }
        }
        public static bool VerificarSiSeHace(int estado, int comprobador)
        {
            var respuesta = true;
            var Estado = Estados_Abreviados[estado];
            var ConjuntoListas = Transiciones[Estado];
            var lista_A_analizar = ConjuntoListas[comprobador];
            if (lista_A_analizar.Length== 0)
            {
                respuesta = false;
            }
            return respuesta;
        }

        public static void LlenarListaAceptados(Dictionary<string, List<string>> Transiciones, Dictionary<string, List<string>> Follows)
        {
            var ultimo = Follows.Last();
            foreach (var item in Estados_Abreviados.Keys)
            {
                if (Estados_Abreviados[item].Contains(ultimo.Key))
                {
                    Estados_Aceptacion.Add(item);
                }
            }
        }
            public void crear(Dictionary<string, List<string>> Transiciones_, Dictionary<string, List<string>> Follows, Dictionary<string, string> Sets_, List<string> Terminales_,string error_, Dictionary<string, string> Actions_, Dictionary<string, string>Token_, Dictionary<string, string>Tokens_Sets_)
        {
            Token = Token_;
            Token_Sets = Tokens_Sets_;
            Actions = Actions_;
            error = error_;
            Sets = Sets_;
            Transiciones = Transiciones_;
            Terminales = Terminales_;
            LlenarDiccionarioAbreviado(Transiciones_);
            LlenarContadorTransiciones();
            LlenarListaAceptados(Transiciones_,Follows);
            EscribirNuevaSolucion();

        }
    }
}
