namespace P10.UseYourChainsBuddy
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    public class UseYourChainsBuddy
    {
        public static void Main(string[] args)
        {
            var alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            var builder = new StringBuilder();

            var input = Console.ReadLine();

            var pattern = @"<p>(.+?)<\/p>";

            var extractedText = Regex.Matches(input, pattern);

            foreach (Match currentText in extractedText)
            {
                string stringToAppend = Regex.Replace(currentText.Groups[1].Value.ToString(), @"[^a-z0-9]+", " ");
                stringToAppend = Regex.Replace(stringToAppend, @"\s+", " ");
                
                builder.Append(stringToAppend);
            }

            var decryptedText = builder.ToString();

            var result = new StringBuilder(decryptedText.Length);

            for (int i = 0; i < decryptedText.Length; i++)
            {
                var currentSymbol = decryptedText[i];

                if (char.IsLower(currentSymbol))
                {
                    var newCharIndex = (Array.IndexOf(alphabet, currentSymbol) + 13) % 26;
                    result.Append(alphabet[newCharIndex]);
                }
                else
                {
                    result.Append(currentSymbol);
                }
            }

            Console.WriteLine(result.ToString());
        }
    }
}
