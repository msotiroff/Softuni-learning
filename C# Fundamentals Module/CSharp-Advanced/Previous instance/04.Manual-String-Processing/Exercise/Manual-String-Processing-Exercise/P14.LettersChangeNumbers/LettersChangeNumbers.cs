namespace P14.LettersChangeNumbers
{
    using System;
    using System.Linq;

    public class LettersChangeNumbers
    {
        public static void Main(string[] args)
        {
            var alphabet = "0ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            double sum = 0;

            var inputParams = Console.ReadLine()
                .Split(new char[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in inputParams)
            {
                double currentSum = 0;

                var firstLetter = item.First();
                var firstLetterPosition = alphabet.IndexOf(firstLetter.ToString().ToUpper());

                var lastLetter = item.Last();
                var lastLetterPosition = alphabet.IndexOf(lastLetter.ToString().ToUpper());

                var numberAsString = item.Replace(firstLetter.ToString(), string.Empty);
                numberAsString = numberAsString.Replace(lastLetter.ToString(), string.Empty);

                var number = double.Parse(numberAsString);

                if (char.IsUpper(firstLetter))
                {
                    currentSum += number / firstLetterPosition;
                }
                else
                {
                    currentSum += number * firstLetterPosition;
                }

                if (char.IsUpper(lastLetter))
                {
                    currentSum -= lastLetterPosition;
                }
                else
                {
                    currentSum += lastLetterPosition;
                }

                sum += currentSum;
            }

            Console.WriteLine($"{sum:f2}");
        }
    }
}
