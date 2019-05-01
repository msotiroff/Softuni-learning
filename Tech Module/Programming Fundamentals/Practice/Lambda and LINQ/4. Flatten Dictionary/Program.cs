using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Flatten_Dictionary
{
    class FlattenDictionary
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, string>> flattenDict =
                new Dictionary<string, Dictionary<string, string>>();

            string inputLine = Console.ReadLine();

            while (inputLine != "end")
            {
                string[] tokens = inputLine.Split(' ').ToArray();

                if (tokens[0] != "flatten")
                {
                    string outKey = tokens[0];
                    string innerKey = tokens[1];
                    string innerValue = tokens[2];

                    if (!flattenDict.ContainsKey(outKey))
                    {
                        flattenDict[outKey] = new Dictionary<string, string>();
                    }
                    flattenDict[outKey][innerKey] = innerValue;
                }
                else
                {
                    string outKey = tokens[1];
                    flattenDict[outKey] = 
                        flattenDict[outKey]
                        .ToDictionary(x => x.Key + x.Value, x => "flattened");
                }
                
                inputLine = Console.ReadLine();
            }

            Dictionary<string, Dictionary<string, string>> orederedDict =
                flattenDict
                .OrderByDescending(x => x.Key.Length)
                .ToDictionary(x => x.Key, x => x.Value);


            foreach (var item in orederedDict)
            {
                Console.WriteLine($"{item.Key}");

                Dictionary<string, string> orderedInnerDict =
                    item.Value
                    .Where(x => x.Value != "flattened")
                    .OrderBy(x => x.Key.Length)
                    .ToDictionary(x => x.Key, x => x.Value);

                Dictionary<string, string> orderedFlattens =
                    item.Value
                    .Where(x => x.Value == "flattened")
                    .ToDictionary(x => x.Key, x => x.Value);

                int counter = 1;
                foreach (var innerItems in orderedInnerDict)
                {
                    Console.WriteLine($"{counter}. {innerItems.Key} - {innerItems.Value}");
                    counter++;
                }
                foreach (var flattenItems in orderedFlattens)
                {
                    Console.WriteLine($"{counter}. {flattenItems.Key}");
                    counter++;
                }
            }

        }
    }
}
