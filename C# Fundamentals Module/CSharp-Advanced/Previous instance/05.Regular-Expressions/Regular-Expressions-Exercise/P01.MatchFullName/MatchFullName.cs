namespace P01.MatchFullName
{
    using System;
    using System.Text.RegularExpressions;

    public class MatchFullName
    {
        public static void Main(string[] args)
        {
            var fullNamePattern = @"\b[A-Z][a-z]+ [A-Z][a-z]+\b";

            var regex = new Regex(fullNamePattern);

            string inputLine;
            while ((inputLine = Console.ReadLine()) != "end")
            {
                if (regex.IsMatch(inputLine))
                {
                    Console.WriteLine(inputLine);
                }
            }
        }
    }
}
