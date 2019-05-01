namespace P07.SumBigNumbers
{
    using System;
    using System.Linq;

    public class SumBigNumbers
    {
        public static void Main(string[] args)
        {
            var firstAddend = Console.ReadLine()
                .ToCharArray()
                .ToList();

            while (firstAddend[0] == '0')
            {
                firstAddend.RemoveAt(0);
            }

            firstAddend.Reverse();

            var secondAddend = Console.ReadLine()
                .ToCharArray()
                .ToList();

            while (secondAddend[0] == '0')
            {
                secondAddend.RemoveAt(0);
            }

            secondAddend.Reverse();

            var difference = Math.Abs(firstAddend.Count - secondAddend.Count);

            if (difference != 0)
            {
                if (firstAddend.Count > secondAddend.Count)
                {
                    secondAddend.AddRange((new string('0', difference).ToCharArray()));
                }
                else
                {
                    firstAddend.AddRange((new string('0', difference).ToCharArray()));
                }
            }

            var result = string.Empty;

            var reminder = 0;

            for (int i = 0; i < firstAddend.Count; i++)
            {
                var currentSum = reminder;

                currentSum += int.Parse(firstAddend[i].ToString()) + int.Parse(secondAddend[i].ToString());

                if (currentSum > 9)
                {
                    reminder = 1;
                    result += (currentSum % 10).ToString();
                }
                else
                {
                    result += currentSum.ToString();
                    reminder = 0;
                }
            }

            if (reminder != 0)
            {
                result += reminder.ToString();
            }

            var finalResult = string.Join("", result.ToCharArray().Reverse());

            Console.WriteLine(finalResult);
        }
    }
}
