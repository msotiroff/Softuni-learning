using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Short_Words_Sorted
{
    class Short_Words_Sorted
    {
        static void Main(string[] args)
        {
            char[] delimiters = { '.', ',', ':', ';', '(', ')', '[', ']', '"', '\'', '\\', '/', '!', '?', ' ' };

            List<string> words = Console.ReadLine()
                .ToLower()
                .Split(delimiters, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var sortedWords = words.Where(w => w.Length < 5)
                .OrderBy(w => w)
                .Distinct()
                .ToList();

            Console.WriteLine(string.Join(", ", sortedWords));
        }
    }
}
