namespace P03.CryptoBlockchain
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    class StartUp
    {
        static void Main(string[] args)
        {
            var result = new StringBuilder();

            var linesCount = int.Parse(Console.ReadLine());

            var wholeText = new StringBuilder();

            for (int i = 0; i < linesCount; i++)
            {
                wholeText.Append(Console.ReadLine());
            }

            var text = wholeText.ToString();

            var pattern = @"[\[\{](?<block>.*?)[\]\}]";

            var regex = new Regex(pattern);

            var matches = regex.Matches(text);

            foreach (Match match in matches)
            {
                var startSymbol = match.Value.First();
                var lastSymbol = match.Value.Last();

                var block = match.Groups["block"].Value;
                var blockLength = match.Length;

                if ((startSymbol.Equals('{') && lastSymbol.Equals('}'))
                    || (startSymbol.Equals('[') && lastSymbol.Equals(']')))
                {
                    var digits = Regex.Match(block, @"\d+");
                    if (digits.Success)
                    {
                        var allDigits = digits.Value;
                        if (allDigits.Length % 3 == 0)
                        {
                            var numbersAsStr = Regex.Matches(allDigits, @"\d{3}");

                            foreach (Match number in numbersAsStr)
                            {
                                var currentNumber = int.Parse(number.Value) - blockLength;

                                result.Append((char)currentNumber);
                            }
                        }
                    }
                }
            }

            Console.WriteLine(result);
        }
    }
}
