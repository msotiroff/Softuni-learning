namespace P04.JediDreams
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    class StartUp
    {
        static void Main(string[] args)
        {
            var staticMethodsPattern = @"static.*?(?<staticMethod>[A-Z][A-Za-z]+)\s*\(.*\)";
            var invokedMethodsPattern = @"(?<invokedMethod>[A-Z][A-Za-z]+)\s*\(";

            var allMethods = new Dictionary<string, List<string>>();
            
            var linesCount = int.Parse(Console.ReadLine());

            var currentStaticMethod = string.Empty;

            for (int i = 0; i < linesCount; i++)
            {
                var currentLine = Console.ReadLine();
                var staticMatch = Regex.Match(currentLine, staticMethodsPattern);
                if (staticMatch.Success)
                {
                    string currMethod = staticMatch.Groups["staticMethod"].Value;
                    currentStaticMethod = currMethod;
                    allMethods.Add(currMethod, new List<string>());
                }
                else
                {
                    var invokedMethodMatches = Regex.Matches(currentLine, invokedMethodsPattern);

                    foreach (Match match in invokedMethodMatches)
                    {
                        if (currentStaticMethod != string.Empty)
                        {
                            allMethods[currentStaticMethod].Add(match.Groups["invokedMethod"].Value);
                        }
                    }
                }
            }

            foreach (var method in allMethods.OrderByDescending(m => m.Value.Count()).ThenBy(m => m.Key))
            {
                var statMethodName = method.Key;
                var invokedMethodsCount = method.Value.Count();
                var invokedMethods = string.Join(", ", method.Value.OrderBy(im => im));

                var methodPrintData = invokedMethodsCount > 0 ? $"{invokedMethodsCount} -> {invokedMethods}" : "None";
                Console.WriteLine($"{statMethodName} -> {methodPrintData}");
            }
        }
    }
}
