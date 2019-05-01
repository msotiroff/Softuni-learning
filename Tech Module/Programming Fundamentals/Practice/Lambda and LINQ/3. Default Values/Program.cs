using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Default_Values
{
    class DefaultValues
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> pairs = new Dictionary<string, string>();

            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] tokens = input
                    .Split(new[] { ' ', '-', '>' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string currentKey = tokens[0];
                string currentValue = tokens[1];

                pairs[currentKey] = currentValue;

                input = Console.ReadLine();
            }

            string defaultValue = Console.ReadLine();

            var replaced = pairs
                .Where(w => w.Value == "null")
                .ToDictionary(w => w.Key, w => defaultValue);

            var notReplaced = pairs
                .Where(w => w.Value != "null")
                .OrderByDescending(w => w.Value.Length)
                .ToDictionary(w => w.Key, w => w.Value);
           
            var result = notReplaced.Concat(replaced).ToDictionary(r => r.Key, r => r.Value);

            foreach (var kvp in result)
            {
                Console.WriteLine($"{kvp.Key} <-> {kvp.Value}");
            }
        }
    }
}
