using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Word_in_Plural
{
    class WordInPlural
    {
        static void Main(string[] args)
        {
            string inputNoun = Console.ReadLine();

            if (inputNoun.EndsWith("y"))
            {
                inputNoun = inputNoun.Remove(inputNoun.Length - 1, 1);

                inputNoun += "ies";
            }

            // "o" "ch", "s", "sh", "x", "or", "z"
            else if (inputNoun.EndsWith("o") ||
                inputNoun.EndsWith("ch") ||
                inputNoun.EndsWith("s") ||
                inputNoun.EndsWith("sh") ||
                inputNoun.EndsWith("x") ||
                inputNoun.EndsWith("z"))
            {
                inputNoun += "es";
            }
            else
            {
                inputNoun += "s";
            }

            Console.WriteLine(inputNoun);
        }
    }
}
