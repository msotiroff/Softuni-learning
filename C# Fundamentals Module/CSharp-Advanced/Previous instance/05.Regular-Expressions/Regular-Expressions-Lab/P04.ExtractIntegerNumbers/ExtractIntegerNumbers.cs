namespace P04.ExtractIntegerNumbers
{
    using System;
    using System.Text.RegularExpressions;

    public class ExtractIntegerNumbers
    {
        public static void Main(string[] args)
        {
            var text = Console.ReadLine();

            var regex = new Regex(@"[0-9]+");

            var numbers = regex.Matches(text);

            foreach (Match number in numbers)
            {
                Console.WriteLine(number);
            }
        }
    }
}
