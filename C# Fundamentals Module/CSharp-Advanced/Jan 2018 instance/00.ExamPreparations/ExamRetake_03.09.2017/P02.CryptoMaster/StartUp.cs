namespace P02.CryptoMaster
{
    using System;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            var sequence = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var maxLength = 1;
            var sequenceLength = sequence.Length;

            for (int index = 0; index < sequenceLength; index++)
            {
                for (int step = 1; step < sequenceLength; step++)
                {
                    var startIndex = index;
                    var currentIndex = (index + step) % sequenceLength;
                    var currentMaxLength = 1;

                    while (sequence[startIndex] < sequence[currentIndex])
                    {
                        currentMaxLength++;
                        startIndex = currentIndex;
                        currentIndex += step;
                        currentIndex %= sequenceLength;

                        if (currentIndex == index)
                        {
                            break;
                        }
                    }

                    if (maxLength < currentMaxLength)
                    {
                        maxLength = currentMaxLength;
                    }
                }
            }

            Console.WriteLine(maxLength);
        }
    }
}
