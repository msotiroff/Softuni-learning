using System.IO;

namespace _2.Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] fileLines = File.ReadAllLines("../../Input.txt");

            string[] result = new string[fileLines.Length];

            for (int i = 0; i < fileLines.Length; i++)
            {
                result[i] = $"{i + 1}. {fileLines[i]}";
            }

            File.AppendAllLines("../../Output.txt", result);

        }
    }
}
