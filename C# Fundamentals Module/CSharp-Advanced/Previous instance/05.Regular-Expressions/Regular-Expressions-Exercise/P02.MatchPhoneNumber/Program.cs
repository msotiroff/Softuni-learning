namespace P02.MatchPhoneNumber
{
    using System;
    using System.Text.RegularExpressions;

    public class Program
    {
        public static void Main(string[] args)
        {
            var phonePattern = @"^\+359([ |-])2\1\d{3}\1\d{4}$";

            var regex = new Regex(phonePattern);

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
