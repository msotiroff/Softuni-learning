using System;
using System.Linq;

namespace _03.Wormhole
{
    class Wormhole
    {
        static void Main(string[] args)
        {
            int[] inputSequence = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int stepCounter = 0;

            for (int i = 0; i < inputSequence.Length; i++)
            {
                stepCounter++;

                int currentValue = inputSequence[i];

                if (currentValue != 0)
                {
                    inputSequence[i] = 0;
                    i = currentValue - 1;
                    stepCounter--;
                }
            }

            Console.WriteLine(stepCounter);
        }
    }
}
