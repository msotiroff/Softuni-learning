using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2.Filter_Extensions
{
    class Program
    {
        static void Main(string[] args)
        {
            string currentExtension = Console.ReadLine();

            string[] fileNames = Directory.GetFiles("input");

            List<string> fileNameAsString = new List<string>();

            foreach (var fileName in fileNames)
            {
                if (fileName.Split('.').Last() == currentExtension)
                {
                    fileNameAsString.Add(fileName);
                }
            }

            List<string> newList = new List<string>();

            for (int i = 0; i < fileNameAsString.Count; i++)
            {
               newList.Add(fileNameAsString[i].Substring(6).ToString());
            }

            Console.WriteLine(string.Join(Environment.NewLine, newList));
        }
    }
}

