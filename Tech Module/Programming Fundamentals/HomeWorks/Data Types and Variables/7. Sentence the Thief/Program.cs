using System;

namespace _7.Sentence_the_Thief
{
    class SentenceTheThief
    {
        static void Main(string[] args)
        {
            string numeralType = Console.ReadLine();
            int numberOfInputs = int.Parse(Console.ReadLine());
            long maxIdNumber = long.MinValue;

            maxIdNumber = GetMaxIdNumber(numeralType, numberOfInputs, maxIdNumber);

            long sentence = 1;

            if (maxIdNumber < sbyte.MinValue)
            {
                sentence = (maxIdNumber / -128) + 1;
            }
            else if (maxIdNumber > sbyte.MaxValue)
            {
                sentence = (maxIdNumber / 127) + 1;
            }

            if (sentence > 1)
            {
                Console.WriteLine($"Prisoner with id {maxIdNumber} is sentenced to {sentence} years");
            }
            else
            {
                Console.WriteLine($"Prisoner with id {maxIdNumber} is sentenced to {sentence} year");
            }
        }

        public static long GetMaxIdNumber(string numeralType, int numberOfInputs, long maxIdNumber)
        {
            for (int i = 0; i < numberOfInputs; i++)
            {
                long currentID = long.Parse(Console.ReadLine());
                if (numeralType == "sbyte")
                {
                    if (currentID <= sbyte.MaxValue)
                    {
                        if (currentID > maxIdNumber)
                        {
                            maxIdNumber = currentID;
                        }
                    }
                }
                else if (numeralType == "int")
                {
                    if (currentID <= int.MaxValue)
                    {
                        if (currentID > maxIdNumber)
                        {
                            maxIdNumber = currentID;
                        }
                    }
                }
                else if (numeralType == "long")
                {
                    if (currentID <= long.MaxValue)
                    {
                        if (currentID > maxIdNumber)
                        {
                            maxIdNumber = currentID;
                        }
                    }
                }
            }

            return maxIdNumber;
        }
    }
}
