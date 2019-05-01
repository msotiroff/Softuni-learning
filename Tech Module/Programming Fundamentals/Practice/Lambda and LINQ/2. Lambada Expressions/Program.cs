using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Lambada_Expressions
{
    public class LambadaExpressions
    {
        public static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, string>> lambadaDataBase =
                new Dictionary<string, Dictionary<string, string>>();

            string inputLine = Console.ReadLine();

            while (inputLine != "lambada")
            {
                if (inputLine == "dance")
                {
                    lambadaDataBase = lambadaDataBase
                        .ToDictionary(x => x.Key, x => x.Value.ToDictionary(inner => inner.Key, inner => inner.Key + "." + inner.Value));
                }
                else
                {
                    string[] tokens = inputLine
                        .Split(new[] { ' ', '=', '>', '.' }, StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

                    string outKey = tokens[0];
                    string innerKey = tokens[1];
                    string innerValue = tokens[2];

                    if (! lambadaDataBase.ContainsKey(outKey))
                    {
                        lambadaDataBase[outKey] = new Dictionary<string, string>();
                    }
                    lambadaDataBase[outKey][innerKey] = innerValue;
                }


                inputLine = Console.ReadLine();
            }

            foreach (var kvp in lambadaDataBase)
            {
                Console.Write($"{kvp.Key} => ");
                foreach (var item in kvp.Value)
                {
                    Console.WriteLine($"{item.Key}.{item.Value}");
                }
            }
        }
    }
}
