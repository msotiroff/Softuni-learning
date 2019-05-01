using System;

namespace _6.Catch_the_Thief
{
    class CatchTheThief
    {
        static void Main(string[] args)
        {
            string numeralType = Console.ReadLine();
            int numberOfInputs = int.Parse(Console.ReadLine());
            long maxIdNumber = long.MinValue;

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

            Console.WriteLine(maxIdNumber);
        }
    }
}
