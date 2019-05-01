namespace P01.OddLines
{
    using System;
    using System.IO;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (var streamReader = new StreamReader("../Resourses/text.txt"))
            {
                var lineCounter = 0;
                string currentLine;
                while ((currentLine = streamReader.ReadLine()) != null)
                {
                    if (lineCounter % 2 != 0)
                    {
                        Console.WriteLine(currentLine);
                    }

                    lineCounter++;
                }
            }
        }
    }
}
