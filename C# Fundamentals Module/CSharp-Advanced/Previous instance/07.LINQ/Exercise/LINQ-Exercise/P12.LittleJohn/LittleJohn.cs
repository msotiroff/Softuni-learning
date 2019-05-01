namespace P12.LittleJohn
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class LittleJohn
    {
        public static void Main(string[] args)
        {
            var allArrows = new Dictionary<string, int>
            {
                ["Small"] = 0,
                ["Medium"] = 0,
                ["Large"] = 0
            };
            
            const string pattern = @"(?<tail>\>{1,3})\-{5}(?<tip>\>{1,2})";

            var regex = new Regex(pattern);

            for (int i = 0; i < 4; i++)
            {
                var inputLine = Console.ReadLine();

                var arrows = regex.Matches(inputLine);

                foreach (Match arrow in arrows)
                {
                    var tipLength = arrow.Groups["tip"].Value.ToString().Length;
                    var tailLength = arrow.Groups["tail"].Value.ToString().Length;

                    if (tipLength == 2 && tailLength == 3)
                    {
                        allArrows["Large"]++;
                    }
                    else if (tipLength >= 1 && tailLength >= 2)
                    {
                        allArrows["Medium"]++;
                    }
                    else if (tipLength == 1 && tailLength == 1)
                    {
                        allArrows["Small"]++;
                    }
                }
            }

            var concatenatedNumbers = int.Parse($"{allArrows["Small"]}{allArrows["Medium"]}{allArrows["Large"]}");

            var binary = Convert.ToString(concatenatedNumbers, 2);
            var reversedBinary = string.Join("", binary.ToCharArray().Reverse());

            var resultBinary = string.Concat(binary, reversedBinary);

            var result = Convert.ToInt32(resultBinary, 2);

            Console.WriteLine(result);
        }
    }
}
