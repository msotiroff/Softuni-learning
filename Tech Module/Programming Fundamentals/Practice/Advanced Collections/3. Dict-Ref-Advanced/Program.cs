using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Dict_Ref_Advanced
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<int>> dictRef = new Dictionary<string, List<int>>();

            char[] separators = { ' ', '-', '>', ',' };
            string[] input = Console.ReadLine()
                .Split(separators, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            while (input[0] != "end")
            {
                string name = input[0];
                
                for (int i = 1; i < input.Length; i++)
                {
                    int number;
                    if (int.TryParse(input[i], out number))
                    {
                        if (!dictRef.ContainsKey(name))
                        {
                            dictRef[name] = new List<int>();
                        }
                        dictRef[name].Add(number);
                    }
                    else
                    {
                        if (dictRef.ContainsKey(input[1]))
                        {
                            dictRef[name] = new List<int>(dictRef[input[1]]);
                        }
                    }
                }

                input = Console.ReadLine()
                .Split(separators, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            }

            foreach (var kvp in dictRef)
            {
                Console.WriteLine($"{kvp.Key} === {string.Join(", ", kvp.Value)}");
            }
            

        }
    }
}
