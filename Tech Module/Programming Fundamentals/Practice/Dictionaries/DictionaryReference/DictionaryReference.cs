using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryReference
{
    class DictionaryReference
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();

            char[] separator = { '=' };
            List<string> input = Console.ReadLine().Split('=').ToList();

            while (input[0] != "end")
            {
                string currentKey = input[0].Trim();
                string currentValue = input[1].Trim();

                int number = 0;
                if (int.TryParse(currentValue, out number))
                {
                    result[currentKey] = number;
                }
                else
                {
                    if (result.ContainsKey(currentValue))
                    {
                        var valueToAdd = result[currentValue];
                        result[currentKey] = valueToAdd;
                    }
                }

                input = Console.ReadLine().Split('=').ToList();
            }




            foreach (var item in result)
            {
                Console.WriteLine($"{item.Key} === {item.Value}");
            }
        }
    }
}
