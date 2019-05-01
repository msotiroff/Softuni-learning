namespace P02.LineNumbers
{
    using System.IO;

    public class StartUp
    {
        private const string InputFilePath = "../Resourses/text.txt";
        private const string OutputFilePath = "Output/output-text.txt";

        public static void Main(string[] args)
        {
            using (var reader = new StreamReader(InputFilePath))
            {
                using (var writer = new StreamWriter(OutputFilePath))
                {
                    int lineNumber = 1;
                    string currentLine;

                    while ((currentLine = reader.ReadLine()) != null)
                    {
                        writer.WriteLine($"Line {lineNumber}: {currentLine}");

                        lineNumber++;
                    }
                }
            }
        }
    }
}
