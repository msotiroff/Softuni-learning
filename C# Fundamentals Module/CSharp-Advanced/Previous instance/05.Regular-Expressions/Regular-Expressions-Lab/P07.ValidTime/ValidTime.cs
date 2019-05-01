namespace P07.ValidTime
{
    using System;
    using System.Text.RegularExpressions;

    public class ValidTime
    {
        public static void Main(string[] args)
        {
            var timePattern = @"^(0[0-9]|1[012]):([0-5][0-9]):([0-5][0-9])\s[AP]M$";

            var timeValidator = new Regex(timePattern);

            string inputLine;
            while ((inputLine = Console.ReadLine()) != "END")
            {
                if (timeValidator.IsMatch(inputLine))
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
