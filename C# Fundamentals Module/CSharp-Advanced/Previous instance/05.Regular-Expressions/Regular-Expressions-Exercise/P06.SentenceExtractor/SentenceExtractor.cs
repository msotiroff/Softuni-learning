namespace P06.SentenceExtractor
{
    using System;
    using System.Text.RegularExpressions;

    public class SentenceExtractor
    {
        public static void Main(string[] args)
        {
            var keyword = Console.ReadLine();

            var text = Console.ReadLine();

            var pattern = string.Format(@"[\w\s:;,]*\b{0}\b[\w\s:;,]*[\?\!\.]", keyword);

            var sentences = Regex.Matches(text, pattern);

            foreach (Match sentence in sentences)
            {
                Console.WriteLine(sentence.ToString().Trim());
            }
        }
    }
}
