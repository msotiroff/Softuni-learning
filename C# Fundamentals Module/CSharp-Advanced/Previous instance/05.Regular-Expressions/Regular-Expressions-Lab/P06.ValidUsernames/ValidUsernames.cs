namespace P06.ValidUsernames
{
    using System;
    using System.Text.RegularExpressions;

    public class ValidUsernames
    {
        public static void Main(string[] args)
        {
            var pattern = @"^[\w\-]{3,16}$";

            var regex = new Regex(pattern);

            string inputLine;
            while ((inputLine = Console.ReadLine()) != "END")
            {
                if (regex.IsMatch(inputLine))
                {
                    Console.WriteLine("valid");
                }
                else
                {
                    Console.WriteLine("invalid");
                }
            }
        }
    }
}
