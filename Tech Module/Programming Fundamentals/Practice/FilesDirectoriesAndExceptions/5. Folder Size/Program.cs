using System.IO;

namespace _5.Folder_Size
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] files = Directory.GetFiles("TestFolder");

            double sum = 0;

            foreach (var file in files)
            {
                FileInfo info = new FileInfo(file);
                sum += info.Length;
            }

            double sumInMB = sum / 1024 / 1024;

            File.WriteAllText("Output.txt", sumInMB.ToString());
        }
    }
}
