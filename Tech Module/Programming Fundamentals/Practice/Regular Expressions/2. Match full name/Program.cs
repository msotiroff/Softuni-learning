using System;
using System.Text.RegularExpressions;

namespace _2.Match_full_name
{
    class Program
    {
        static void Main(string[] args)
        {
            string patern = @"[\s][A-Z][a-z]+\s[A-Z][a-z]+[,|\s]";
            Regex search = new Regex(patern);

            string text = "ivan ivanov, Ivan ivanov, ivan Ivanov, IVan Ivanov, Ivan IvAnov, Ivan Ivanov ";

            var result = search.Match(text);

            Console.WriteLine(result.Value.Trim());
        }
    }
}
