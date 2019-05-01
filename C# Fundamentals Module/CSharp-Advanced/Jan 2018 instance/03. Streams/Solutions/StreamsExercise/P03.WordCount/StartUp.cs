namespace P03.WordCount
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class StartUp
    {
        private const string TextFilePath = "../Resourses/text.txt";
        private const string WordsFilePath = "../Resourses/words.txt";
        private const string OutputFilePath = "Output/results.txt";
        private const string wordsPattern = "[A-Za-z']+";

        public static void Main(string[] args)
        {
            var wordsToCount = new HashSet<string>();

            var wordsByCount = new Dictionary<string, int>();

            using (var reader = new StreamReader(WordsFilePath))
            {
                string currentWord;
                while ((currentWord = reader.ReadLine()) != null)
                {
                    wordsToCount.Add(currentWord.ToLower());
                }
            }

            using (var streamReader = new StreamReader(TextFilePath))
            {
                string currentLine;
                while ((currentLine = streamReader.ReadLine()) != null)
                {
                    var matches = Regex.Matches(currentLine, wordsPattern);

                    foreach (Match match in matches)
                    {
                        string currentWord = match.Value.ToLower();

                        if (wordsToCount.Contains(currentWord))
                        {
                            if (!wordsByCount.ContainsKey(currentWord))
                            {
                                wordsByCount[currentWord] = 0;
                            }
                            wordsByCount[currentWord]++;
                        }
                    }
                }
            }

            using (var streamWriter = new StreamWriter(OutputFilePath))
            {
                foreach (var word in wordsByCount.OrderByDescending(w => w.Value))
                {
                    streamWriter.WriteLine($"{word.Key} - {word.Value}");
                }
            }
        }
    }
}
