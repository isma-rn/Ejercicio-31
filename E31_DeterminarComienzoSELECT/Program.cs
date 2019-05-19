using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace E31_DeterminarComienzoSELECT
{
    class Program
    {
        static void Main(string[] args)
        {
            bool salir = false;
            string opcion;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Ingrese la cadena:");
                string cadena = Console.ReadLine();

                if (cadena.Length>0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("La cadena es \"{0}\"", cadena);
                    Console.WriteLine("(Método 1): Y {0} empieza con SELECT o select", VerificarComienzoConSelect(cadena) ? "si" : "no");
                    Console.WriteLine("(Método 2): Y {0} empieza con SELECT o select", VerificarComienzoConSelect_2(cadena) ? "si" : "no");
                    Console.WriteLine("(Método 3): Y {0} empieza con SELECT o select", VerificarComienzoConSelect_3(cadena) ? "si" : "no");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Cadena vacía");
                }

                do
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("n : nuevo, s : salir");
                    opcion = Console.ReadLine();

                    if (opcion.Equals("s"))
                    {
                        salir = true;
                        break;
                    }
                    else if (!opcion.Equals("n"))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("No se reconoce opción...");
                    }
                    else
                        break;
                } while (true);

            } while (!salir);            
        }
        public static bool VerificarComienzoConSelect(string cadena)
        {
            cadena = cadena.TrimStart();
            bool enMinuscula = true, enMayuscula = true;

            if(cadena.Length >= palabraMinus.Length)
            {
                char[] letras = cadena.ToCharArray();
                int limite = cadena.Length == palabraMinus.Length? palabraMinus.Length : palabraMinus.Length+1;

                for (int i = 0; i < limite; i++)
                {
                    if (i != palabraMinus.Length)
                    {
                        if (palabraMinus[i] != letras[i])
                            enMinuscula = false;
                        if (palabraMayus[i] != letras[i])
                            enMayuscula = false;
                    }
                    else if (letras[i] != ' ')
                        return false;
                }

                if (enMinuscula || enMayuscula)
                    return true;                    
            }
            return false;
        }

        public static char[] palabraMinus = new char[] { 's', 'e', 'l', 'e', 'c', 't' };
        public static char[] palabraMayus = new char[] { 'S', 'E', 'L', 'E', 'C', 'T' };

        public static bool VerificarComienzoConSelect_2(string cadena)
        {
            cadena = cadena.TrimStart();
            Regex patron = new Regex("^select ?|^SELECT ?");
            return patron.IsMatch(cadena);
        }
        public static bool VerificarComienzoConSelect_3(string cadena)
        {
            cadena = cadena.TrimStart();
            if (cadena.Equals("SELECT") || cadena.Equals("select")  || cadena.StartsWith("select ") || cadena.StartsWith("SELECT "))
                return true;
            return false;
        }
    }
}
