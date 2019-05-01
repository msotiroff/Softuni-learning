namespace P05.ExtractEmail
{
    using System;
    using System.Text.RegularExpressions;

    public class ExtractEmail
    {
        public static void Main(string[] args)
        {
            var pattern = @"\s([A-Za-z0-9][\w-\.]*[A-Za-z0-9]@[A-Za-z]+-*[A-Za-z\.]+\.+[A-Za-z]+[A-Za-z-]*[A-Za-z]+)";

            var regex = new Regex(pattern);

            var text = Console.ReadLine();

            var emails = regex.Matches(text);

            foreach (Match email in emails)
            {
                Console.WriteLine(email.Groups[1].Value.ToString());
            }
        }
    }
}
