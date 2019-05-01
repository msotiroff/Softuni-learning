using System;
using System.Text.RegularExpressions;

namespace _05.OnlyLetters
{
    class OnlyLetters
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            Regex findSequence = new Regex(@"(\d+)([A-Za-z])");

            var matchedSequences = findSequence.Matches(message);

            foreach (Match sequence in matchedSequences)
            {
                message = Regex.Replace(
                    message, 
                    sequence.Groups[1].Value.ToString(), 
                    sequence.Groups[2].Value.ToString()
                             );
            };


            Console.WriteLine(message);
        }
    }
}
