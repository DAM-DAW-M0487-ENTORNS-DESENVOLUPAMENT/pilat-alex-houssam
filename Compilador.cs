using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilaT
{
    public class Compilador :Stack<char>
    {
        public Compilador()
        {
        }
        bool valid = false;
        public bool Validar(string expressio)
        {
            foreach (char c in expressio)
            {
                if (c == Convert.ToChar("(") || c == Convert.ToChar("[") || c == Convert.ToChar("{"))
                {
                    this.Push(c);
                }
                else if (c == Convert.ToChar(")") || c == Convert.ToChar("]") || c == Convert.ToChar("}"))
                {
                    if (this.Count == 0)
                    {
                        valid = false;
                        throw new ArgumentException("Error en la expresion");
                    }
                    char temp = this.Pop();
                    if (c == Convert.ToChar(")") && temp != Convert.ToChar("("))
                    {
                        valid = false;
                        throw new ArgumentException("Error en la expresion");
                    }
                    if (c == Convert.ToChar("]") && temp != Convert.ToChar("["))
                    {
                        valid = false;
                        throw new ArgumentException("Error en la expresion");
                    }
                    if (c == Convert.ToChar("}") && temp != Convert.ToChar("{"))
                    {
                        valid = false;
                        throw new ArgumentException("Error en la expresion");
                    }
                }
            }
            return valid;
        }
    }
}
