namespace P05.ConcatenateStrings
{
    using System;
    using System.Text;

    public class ConcatenateStrings
    {
        public static void Main(string[] args)
        {
            var numberOfWords = int.Parse(Console.ReadLine());

            var builder = new StringBuilder();

            for (int i = 0; i < numberOfWords; i++)
            {
                var currentWord = Console.ReadLine();

                builder.Append(currentWord);
                builder.Append(" ");
            }

            var result = builder.ToString().TrimEnd();

            Console.WriteLine(result);
        }
    }
}
