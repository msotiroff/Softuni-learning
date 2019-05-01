namespace P02.CryptoMaster
{
    using System;
    using System.Linq;

    public class CryptoMaster
    {
        public static void Main(string[] args)
        {
            var longestSequenceCount = 0;

            var sequence = Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();


            for (int step = 1; step < sequence.Count; step++)
            {
                for (int startIndex = 0; startIndex < sequence.Count; startIndex++)
                {
                    var currentMaxSeqCount = 1;

                    var currentElementIndex = startIndex;
                    var nextElementIndex = (currentElementIndex + step) % sequence.Count;

                    while (sequence[nextElementIndex] > sequence[currentElementIndex])
                    {
                        currentMaxSeqCount++;

                        var indexOfSmallerElement = currentElementIndex;

                        currentElementIndex = nextElementIndex;
                        nextElementIndex = (currentElementIndex + step) % sequence.Count;
                    }

                    if (longestSequenceCount < currentMaxSeqCount)
                    {
                        longestSequenceCount = currentMaxSeqCount;
                    }
                }
            }

            Console.WriteLine(longestSequenceCount);
        }
    }
}
