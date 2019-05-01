using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.Short_Words_Sorted
{
    class ShortWordsSorted
    {
        static void Main(string[] args)
        {
            // . , : ; ( ) [ ] " ' \ / ! ? (space).
            char[] delimiters = { '.', ',', ':', ';', '(', ')', '[', ']', '"', '\'', '\\', '/', '!', '?', ' ' };

            List<string> words = Console.ReadLine()
                .ToLower()
                .Split(delimiters, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            words = words
                .Where(x => x.Length < 5)
                .OrderBy(x => x)
                .Distinct()
                .ToList();

            Console.WriteLine(string.Join(", ", words));

        }
    }
}
