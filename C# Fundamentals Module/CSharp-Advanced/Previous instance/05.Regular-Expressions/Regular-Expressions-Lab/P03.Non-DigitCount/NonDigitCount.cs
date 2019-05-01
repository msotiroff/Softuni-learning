namespace P03.Non_DigitCount
{
    using System;
    using System.Text.RegularExpressions;

    public class NonDigitCount
    {
        public static void Main(string[] args)
        {
            var text = Console.ReadLine();

            var regex = new Regex(@"[^0-9]");

            var countOfNonDigits = regex.Matches(text).Count;

            Console.WriteLine($"Non-digits: {countOfNonDigits}");
        }
    }
}
