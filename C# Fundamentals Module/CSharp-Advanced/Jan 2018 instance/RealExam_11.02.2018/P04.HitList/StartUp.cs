namespace P04.HitList
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            var people = new Dictionary<string, Dictionary<string, string>>();

            var targetInfoIndex = int.Parse(Console.ReadLine());

            string inputLine;
            while ((inputLine = Console.ReadLine()) != "end transmissions")
            {
                var personParams = inputLine.Split('=').ToArray();
                var name = personParams[0];
                var dataKVPairs = personParams[1].Split(';').ToArray();

                if (!people.ContainsKey(name))
                {
                    people[name] = new Dictionary<string, string>();
                }

                foreach (var kvp in dataKVPairs)
                {
                    var currentInfo = kvp.Split(':').ToArray();
                    var currentKey = currentInfo.First();
                    var currentValue = currentInfo.Last();

                    people[name][currentKey] = currentValue;
                }
            }

            var personToKill = string.Join(" ", Console.ReadLine()
                        .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Skip(1)
                        .ToArray());

            // Print info:
            var person = people.First(p => p.Key == personToKill);

            Console.WriteLine($"Info on {person.Key}:");

            foreach (var kvp in person.Value.OrderBy(k => k.Key))
            {
                Console.WriteLine($"---{kvp.Key}: {kvp.Value}");
            }

            var personIndex = person.Value.Keys.Sum(k => k.Length) + person.Value.Values.Sum(v => v.Length);

            Console.WriteLine($"Info index: {personIndex}");

            Console.WriteLine(personIndex >= targetInfoIndex 
                ? "Proceed" 
                : $"Need {targetInfoIndex - personIndex} more info.");
        }
    }
}
