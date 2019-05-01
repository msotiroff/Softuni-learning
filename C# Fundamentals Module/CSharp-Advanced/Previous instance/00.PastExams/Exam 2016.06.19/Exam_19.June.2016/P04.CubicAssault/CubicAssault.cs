namespace P04.CubicAssault
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class CubicAssault
    {
        private static readonly int milion = 1_000_000;

        public static void Main(string[] args)
        {
            var allRegions = new Dictionary<string, Dictionary<string, long>>();

            string inputLine;
            while ((inputLine = Console.ReadLine()) != "Count em all")
            {
                // Input format: {regionName} -> {meteorType} -> {count}

                var inputParams = Regex.Split(inputLine, @"\s\-\>\s");

                var regionName = inputParams[0];
                var meteorType = inputParams[1];
                var meteorsCount = long.Parse(inputParams[2]);

                if (!allRegions.ContainsKey(regionName))
                {
                    allRegions[regionName] = new Dictionary<string, long>()
                    {
                        ["Black"] = 0,
                        ["Red"] = 0,
                        ["Green"] = 0
                    };
                }

                allRegions[regionName][meteorType] += meteorsCount;

                if (allRegions[regionName]["Green"] >= milion)
                {
                    TransferGreenToRed(allRegions, regionName, allRegions[regionName]["Green"]);
                }

                if (allRegions[regionName]["Red"] >= milion)
                {
                    TransferRedToBlack(allRegions, regionName, allRegions[regionName]["Red"]);
                }
            }

            var orderedData = allRegions
                .OrderByDescending(r => r.Value["Black"])
                .ThenBy(r => r.Key.Length)
                .ThenBy(r => r.Key)
                .ToDictionary(x => x.Key, x => x.Value
                    .OrderByDescending(m => m.Value)
                    .ThenBy(m => m.Key)
                    .ToDictionary(y => y.Key, y => y.Value));

            foreach (var region in orderedData)
            {
                Console.WriteLine(region.Key);

                foreach (var meteor in region.Value)
                {
                    Console.WriteLine($"-> {meteor.Key} : {meteor.Value}");
                }
            }
        }

        private static void TransferGreenToRed(Dictionary<string, Dictionary<string, long>> allRegions, string regionName, long meteorsCount)
        {
            var greenCount = meteorsCount % milion;
            var redCount = meteorsCount / milion;

            allRegions[regionName]["Red"] += redCount;
            allRegions[regionName]["Green"] = greenCount;
        }

        private static void TransferRedToBlack(Dictionary<string, Dictionary<string, long>> allRegions, string regionName, long meteorsCount)
        {
            var redCount = meteorsCount % milion;
            var blackCount = meteorsCount / milion;

            allRegions[regionName]["Black"] += blackCount;
            allRegions[regionName]["Red"] = redCount;
        }
    }
}
