namespace P05.ConvertToBase10
{
    using System;
    using System.Linq;
    using System.Numerics;

    public class ConvertToBase10
    {
        public static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(BigInteger.Parse)
                .ToArray();

            var fromBase = numbers[0];
            var numberToConvert = numbers[1];

            var result = ConvertFromBaseToDecimal(numberToConvert, fromBase);

            Console.WriteLine(result);
        }

        // Converts the given number with given base to base 10, returns the result as string !
        private static string ConvertFromBaseToDecimal(BigInteger numberToConvert, BigInteger fromBase)
        {
            string number = numberToConvert.ToString();
            BigInteger n = 1;
            BigInteger r = 0;

            for (int i = number.Length - 1; i >= 0; --i)
            {
                r += n * (number[i] - '0');
                n *= fromBase;
            }

            return r.ToString();
        }
    }
}
