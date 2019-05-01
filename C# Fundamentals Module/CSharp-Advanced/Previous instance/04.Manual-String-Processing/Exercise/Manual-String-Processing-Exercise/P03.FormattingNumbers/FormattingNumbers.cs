namespace P03.FormattingNumbers
{
    using System;

    public class FormattingNumbers
    {
        public static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(new char[] {' ', '\t', '\n'}, StringSplitOptions.RemoveEmptyEntries);

            var a = int.Parse(numbers[0]);
            var b = double.Parse(numbers[1]);
            var c = double.Parse(numbers[2]);

            var aInHex = a.ToString("X");
            var aInBinary = PadBinary(Convert.ToString(a, 2));

            Console.WriteLine("|{0, -10}|{1}|{2, 10:f2}|{3, -10:f3}|",
                                aInHex, aInBinary, b, c);
        }

        private static string PadBinary(string binaryNumber)
        {
            string result = string.Empty;

            var difference = Math.Abs(binaryNumber.Length - 10);

            if (binaryNumber.Length > 10)
            {
                result = binaryNumber.Substring(0, 10);
            }
            else
            {
                result = $"{new string('0', difference)}{binaryNumber}";
            }

            return result;
        }
    }
}
