namespace P04.JediDreams
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    class StartUp
    {
        static void Main(string[] args)
        {
            var allStaticMethods = new Dictionary<string, List<string>>();

            var staticMethodsPattern = @"static.*?([A-Z][A-Za-z]*)\s*\(";

            var extensionMethodsPattern = @"([A-Z][A-Za-z]*)\s*\(";
            
            var linesCount = int.Parse(Console.ReadLine());

            var lastStaticMethod = string.Empty;

            for (int i = 0; i < linesCount; i++)
            {
                var currentLine = Console.ReadLine();

                var currentStaticMethodMatch = Regex.Match(currentLine, staticMethodsPattern);

                if (currentStaticMethodMatch.Success)
                {
                    var currStaticMethod = currentStaticMethodMatch.Groups[1].Value;

                    lastStaticMethod = currStaticMethod;
                    allStaticMethods.Add(lastStaticMethod, new List<string>());
                }
                else
                {
                    var currentExtensionMethodsMatches = Regex.Matches(currentLine, extensionMethodsPattern);

                    if (currentExtensionMethodsMatches.Count > 0 && lastStaticMethod != string.Empty)
                    {
                        foreach (Match match in currentExtensionMethodsMatches)
                        {
                            var currentExtensionMethod = match.Groups[1].Value;
                            allStaticMethods[lastStaticMethod].Add(currentExtensionMethod);
                        }
                    }
                }
            }

            foreach (var statMethod in allStaticMethods
                .OrderByDescending(sm => sm.Value.Count)
                .ThenBy(sm => sm.Key))
            {
                if (statMethod.Value.Any())
                {
                    Console.WriteLine("{0} -> {1} -> {2}",
                        statMethod.Key,
                        statMethod.Value.Count,
                        string.Join(", ", statMethod.Value.OrderBy(em => em))
                        );
                }
                else
                {
                    Console.WriteLine($"{statMethod.Key} -> None");
                }
            }
        }
    }
}
