using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PILA;

namespace PilaT
{
    internal class Compilador
    {
        public Compilador()
        {

        }
        public bool Validar(string expressio)
        {
            Pila<char> llista = new Pila<char>();
            char valor;
            bool resultat = true;
            
            for(int i = 0; i < expressio.Length; i++) /// Passem per tot el string
            {
                if (expressio[i] == '(' || expressio[i] == '[' || expressio[i] == '{') //Si és una de les següents figures es guarda a la pila.
                {
                    llista.Push(expressio[i]);
                }
                else if (expressio[i] == ')') // Si no comprovem que sigui una de tancament
                {
                    if (llista.IsEmpty) // si és una i a mes esta vuida la pila vol dir que esta mal
                    {
                        resultat = false;
                    }
                    else if(llista.Pop() != '(') { resultat = false; } // però si no esta buida mirarem que sigui la seva contrapart la que és a la pila si no està malament l'ordre.
                }
                else if (expressio[i] == ']')
                {
                    if (llista.IsEmpty)
                    {
                        resultat = false;
                    }
                    else if (llista.Pop() != '[') { resultat = false; }
                }
                else if (expressio[i] == '}')
                {
                    if (llista.IsEmpty)
                    {
                        resultat = false;
                    }
                    else if (llista.Pop() != '{') { resultat = false; }
                }
            }
            if(!llista.IsEmpty) { resultat = false; } // si al acabar encara queda alguna cosa en la pila vol dir que esta malament.
            return resultat;
        }
    }
}
