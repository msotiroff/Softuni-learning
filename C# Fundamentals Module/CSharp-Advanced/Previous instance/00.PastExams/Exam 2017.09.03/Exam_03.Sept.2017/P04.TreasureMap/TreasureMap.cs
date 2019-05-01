namespace P04.TreasureMap
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public class TreasureMap
    {
        public static void Main(string[] args)
        {
            var builder = new StringBuilder();

            int numberOfInputs = int.Parse(Console.ReadLine());

            var pattern = @"\![^!#]*?\b(?<street>[A-Za-z]{4})\b[^!#]*[^\d](?<number>\d{3})-(?<password>\d{6}|\d{4})(?:[^\d!#][^!#]*)?\#|\#[^!#]*?\b(?<street>[A-Za-z]{4})\b[^!#]*[^\d](?<number>\d{3})-(?<password>\d{6}|\d{4})(?:[^\d!#][^!#]*)?\!";

            var validAddresses = new List<Address>();

            for (int i = 0; i < numberOfInputs; i++)
            {
                var inputLine = Console.ReadLine();

                var allMatches = Regex.Matches(inputLine, pattern);

                foreach (Match match in allMatches)
                {
                    var address = new Address
                    {
                        Street = match.Groups["street"].Value.ToString(),
                        Number = match.Groups["number"].Value.ToString(),
                        Password = match.Groups["password"].Value.ToString()
                    };

                    validAddresses.Add(address);
                }

                var neededInstructionIndex = validAddresses.Count / 2;

                var neededAddress = validAddresses[neededInstructionIndex];

                builder.AppendLine($"Go to str. {neededAddress.Street} {neededAddress.Number}. " +
                    $"Secret pass: {neededAddress.Password}.");

                validAddresses.Clear();
            }

            var result = builder.ToString().TrimEnd();

            Console.WriteLine(result);
        }
    }
}
