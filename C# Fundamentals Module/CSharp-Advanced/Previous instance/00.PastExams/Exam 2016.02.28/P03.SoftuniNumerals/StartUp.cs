namespace P03.SoftuniNumerals
{
    using System;
    using System.Numerics;

    class StartUp
    {
        static void Main(string[] args)
        {
            var numerals = new string[] { "aa", "aba", "bcc", "cc", "cdc" };

            var baseFive = string.Empty;

            var inputLine = Console.ReadLine();

            while (inputLine.Length > 0)
            {
                for (int i = 0; i < numerals.Length; i++)
                {
                    if (inputLine.StartsWith(numerals[i]))
                    {
                        baseFive += i;
                        inputLine = inputLine.Substring(numerals[i].Length);
                    }
                }
            }

            Console.WriteLine(ConvertFromBaseToDecimal(baseFive, 5));
        }

        private static string ConvertFromBaseToDecimal(string number, BigInteger fromBase)
        {
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
