namespace P04.ConvertToBaseN
{
    using System;
    using System.Linq;
    using System.Numerics;

    public class ConvertToBaseN
    {
        public static void Main(string[] args)
        {
            var inputLine = Console.ReadLine()
                .Split()
                .Select(BigInteger.Parse)
                .ToArray();

            var toBase = inputLine[0];
            var number = inputLine[1];

            var result = ConvertToBase(toBase, number);

            Console.WriteLine(result);
        }

        private static string ConvertToBase(BigInteger toBase, BigInteger number)
        {
            var result = string.Empty;

            while (number > 0)
            {
                var reminder = number % toBase;
                result = reminder + result;

                number /= toBase;
            }

            return result;
        }
    }
}
