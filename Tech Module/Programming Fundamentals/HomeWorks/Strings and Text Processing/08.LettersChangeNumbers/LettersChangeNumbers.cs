using System;
using System.Linq;

namespace _08.LettersChangeNumbers
{
    class LettersChangeNumbers
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .ToArray();

            string alphabet = "0ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            double finalResult = 0;

            for (int i = 0; i < input.Length; i++)
            {
                string currentString = input[i];

                char startLetter = currentString.First();
                char endLetter = currentString.Last();
                currentString = currentString.Substring(1, currentString.Length - 2);
                double numberToProcess = double.Parse(currentString);

                if (char.IsUpper(startLetter))
                {
                    numberToProcess /= alphabet.IndexOf(startLetter);
                }
                else
                {
                    numberToProcess *= alphabet.IndexOf(startLetter.ToString().ToUpper());
                }

                if (char.IsUpper(endLetter))
                {
                    numberToProcess -= alphabet.IndexOf(endLetter);
                }
                else
                {
                    numberToProcess += alphabet.IndexOf(endLetter.ToString().ToUpper());
                }


                finalResult += numberToProcess;
            }


            Console.WriteLine($"{finalResult:f2}");
        }
    }
}
