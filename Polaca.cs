using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilaT
{
    internal class Polaca
    {
        public static bool EsNotacionPolaca(string entrada)
        {
            if (entrada == null)
                return false;

            Stack<string> pila = new Stack<string>();
            string[] tokens = entrada.Split(' ');

            foreach (string token in tokens)
            {
                if (EsOperador(token))
                {
                    // Se necesitan al menos dos operandos en la pila para un operador
                    if (pila.Count < 2)
                        return false;

                    // Realizamos la operación ficticia y dejamos un resultado en la pila
                    pila.Pop();
                    pila.Pop();
                    pila.Push("resultado"); // Simula un resultado
                }
                else
                {
                    // Si es un operando, lo añadimos a la pila
                    pila.Push(token);
                }
            }

            // Al final, debe quedar exactamente un elemento en la pila
            return pila.Count == 1;
        }
        

        private static bool EsOperador(string token)
        {
            return token == "+" || token == "-" || token == "*" || token == "/";
        }
    }
}
