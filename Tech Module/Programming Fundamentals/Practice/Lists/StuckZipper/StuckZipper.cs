using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StuckZipper
{
    class StuckZipper
    {
        static void Main(string[] args)
        {
            List<int> firstNumbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            List<int> secondNumbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            int minFirstNumber = Math.Abs(firstNumbers.Min());
            int minSecondNumber = Math.Abs(secondNumbers.Min());

            int minAbsoluteNumber = Math.Min(minFirstNumber, minSecondNumber);

            int digitCounter = 0;
            while (minAbsoluteNumber > 0)
            {
                minAbsoluteNumber /= 10;
                digitCounter++;
            }

            for (int i = 0; i < firstNumbers.Count; i++)
            {
                int currentDigitCounter = 0;
                int copyOfNumber = firstNumbers[i];
                while (copyOfNumber > 0)
                {
                    copyOfNumber /= 10;
                    currentDigitCounter++;
                }
                if (currentDigitCounter > digitCounter)
                {
                    firstNumbers.RemoveAt(i);
                    i = -1;
                }
            }
            for (int i = 0; i < secondNumbers.Count; i++)
            {
                int currentDigitCounter = 0;
                int copyOfNumber = secondNumbers[i];
                while (copyOfNumber > 0)
                {
                    copyOfNumber /= 10;
                    currentDigitCounter++;
                }
                if (currentDigitCounter > digitCounter)
                {
                    secondNumbers.RemoveAt(i);
                    i = -1;
                }
            }

          
            if (firstNumbers.Count <= secondNumbers.Count)
            {
                int indexAdditive = 1;
                for (int i = 0; i < firstNumbers.Count; i++)
                {
                    secondNumbers.Insert(i + indexAdditive, firstNumbers[i]);
                    indexAdditive++;
                }
                Console.WriteLine(string.Join(" ", secondNumbers));
            }
            else
            {
                int indexAdditive = 0;
                for (int i = 0; i < secondNumbers.Count; i++)
                {
                    firstNumbers.Insert(i + indexAdditive, secondNumbers[i]);
                    indexAdditive++;
                }
                Console.WriteLine(string.Join(" ", firstNumbers));
            }
            
        }
    }
}
