namespace P04.CubicAssault
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        private static readonly long million = 1_000_000;

        static void Main(string[] args)
        {
            var allRegions = new Dictionary<string, Dictionary<string, long>>();

            string inputLine;
            while ((inputLine = Console.ReadLine()) != "Count em all")
            {
                // Input format: {regionName} -> {meteorType} -> {count}
                var inputParams = inputLine.Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);

                var currentRegion = inputParams[0];
                var currentMeteorType = inputParams[1];
                var currentMeteorCount = long.Parse(inputParams[2]);

                if (!allRegions.ContainsKey(currentRegion))
                {
                    allRegions[currentRegion] = new Dictionary<string, long>()
                    {
                        ["Black"] = 0,
                        ["Red"] = 0,
                        ["Green"] = 0
                    };
                }

                allRegions[currentRegion][currentMeteorType] += currentMeteorCount;

                RearrangeMeteors(allRegions, currentRegion);
            }

            var orderedRegions = allRegions
                .OrderByDescending(r => r.Value
                    .Where(m => m.Key.Equals("Black"))
                    .Sum(m => m.Value))
                .ThenBy(r => r.Key.Length)
                .ThenBy(r => r.Key)
                .ToDictionary(x => x.Key, x => x.Value
                    .OrderByDescending(m => m.Value)
                    .ThenBy(m => m.Key)
                    .ToDictionary(y => y.Key, y => y.Value));

            foreach (var region in orderedRegions)
            {
                Console.WriteLine(region.Key);

                foreach (var meteor in region.Value)
                {
                    Console.WriteLine($"-> {meteor.Key} : {meteor.Value}");
                }
            }
        }

        private static void RearrangeMeteors(Dictionary<string, Dictionary<string, long>> allRegions, string currentRegion)
        {
            long greenMetors = allRegions[currentRegion]["Green"];
            if (greenMetors >= million)
            {
                allRegions[currentRegion]["Green"] = greenMetors % million;
                allRegions[currentRegion]["Red"] += greenMetors / million;
            }

            long redMeteors = allRegions[currentRegion]["Red"];
            if (redMeteors >= million)
            {
                allRegions[currentRegion]["Red"] = redMeteors % million;
                allRegions[currentRegion]["Black"] += redMeteors / million;
            }
        }
    }
}
