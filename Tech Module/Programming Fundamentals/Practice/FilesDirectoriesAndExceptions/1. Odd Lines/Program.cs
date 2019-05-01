using System.IO;
using System.Collections.Generic;

namespace _1.Odd_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] fileLines = File.ReadAllLines("input.txt");

            List<string> result = new List<string>();

            for (int i = 1; i < fileLines.Length; i += 2)
            {
                result.Add(fileLines[i]);
            }

            File.AppendAllLines("Output.txt", result);


        }
    }
}
