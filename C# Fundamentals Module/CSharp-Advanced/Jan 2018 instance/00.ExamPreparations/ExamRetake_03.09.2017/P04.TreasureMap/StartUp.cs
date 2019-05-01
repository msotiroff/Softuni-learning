namespace P04.TreasureMap
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    class StartUp
    {
        static void Main(string[] args)
        {
            var pattern = @"\#[^\#\!]*?\b(?<street>[A-Za-z]{4})\b[^\#\!]*[^\d](?<number>\d{3})\-(?<password>\d{6}|\d{4})(?:[^\d\!\#][^\!\#]*)?\!|\![^\#\!]*?\b(?<street>[A-Za-z]{4})\b[^\#\!]*[^\d](?<number>\d{3})\-(?<password>\d{6}|\d{4})(?:[^\d\!\#][^\!\#]*)?\#";

            var regex = new Regex(pattern);

            var linesCount = int.Parse(Console.ReadLine());

            var validAddresses = new List<Match>();

            for (int i = 0; i < linesCount; i++)
            {
                var inputLine = Console.ReadLine();

                var addresses = regex.Matches(inputLine);

                foreach (Match match in addresses)
                {
                    validAddresses.Add(match);
                }

                var neededIndex = addresses.Count / 2;

                var currentStreet = addresses[neededIndex].Groups["street"].Value;
                var currntNumber = addresses[neededIndex].Groups["number"].Value;
                var currentPassword = addresses[neededIndex].Groups["password"].Value;

                Console.WriteLine($"Go to str. {currentStreet} {currntNumber}. Secret pass: {currentPassword}.");

                validAddresses.Clear();
            }
        }
    }
}
