namespace P02.StringLength
{
    using System;

    public class StringLength
    {
        public static void Main(string[] args)
        {
            var text = Console.ReadLine();

            var maxSymbols = Math.Min(20, text.Length);

            var result = text.Substring(0, maxSymbols);

            if (text.Length < 20)
            {
                result += new string('*', 20 - text.Length);
            }

            Console.WriteLine(result);
        }
    }
}
