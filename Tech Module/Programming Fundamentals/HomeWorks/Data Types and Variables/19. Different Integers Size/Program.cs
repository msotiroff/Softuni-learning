using System;
using System.Collections.Generic;

namespace _19.Different_Integers_Size
{
    class DifferentIntegersSize
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            long number;
            if (long.TryParse(input, out number))
            {
                List<string> storingTypes = new List<string>();

                FillListOfDataTypes(number, storingTypes);

                if (storingTypes.Count > 0)
                {
                    Console.WriteLine($"{number} can fit in:");
                    foreach (var dataType in storingTypes)
                    {
                        Console.WriteLine($"* {dataType}");
                    }
                }
            }
            else
            {
                Console.WriteLine($"{input} can't fit in any type");
            }
        }

        public static void FillListOfDataTypes(long number, List<string> storingTypes)
        {
            if (number < 0)
            {
                if (number >= sbyte.MinValue)
                {
                    storingTypes.Add("sbyte");
                }
                if (number >= short.MinValue)
                {
                    storingTypes.Add("short");
                }
                if (number >= int.MinValue)
                {
                    storingTypes.Add("int");
                }
                if (number >= long.MinValue)
                {
                    storingTypes.Add("long");
                }
            }
            else
            {
                if (number <= byte.MaxValue)
                {
                    if (number <= sbyte.MaxValue)
                    {
                        storingTypes.Add("sbyte");
                    }
                    storingTypes.Add("byte");
                }
                if (number <= ushort.MaxValue)
                {
                    if (number <= short.MaxValue)
                    {
                        storingTypes.Add("short");
                    }
                    storingTypes.Add("ushort");
                }
                if (number <= uint.MaxValue)
                {
                    if (number <= int.MaxValue)
                    {
                        storingTypes.Add("int");
                    }
                    storingTypes.Add("uint");
                }
                if (number <= long.MaxValue)
                {
                    storingTypes.Add("long");
                }
            }
        }
    }
}
