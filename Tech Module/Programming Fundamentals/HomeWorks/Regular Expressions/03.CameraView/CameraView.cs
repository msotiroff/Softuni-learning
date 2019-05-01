using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading.Tasks;

namespace _03.CameraView
{
    class CameraView
    {
        static void Main(string[] args)
        {
            List<string> picsTaken = new List<string>();

            int[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            int skip = numbers[0];
            int take = numbers[1];

            string inputText = Console.ReadLine();

            string pattern = @"\|<(\w{" + skip + @"})(\w{0," + take + @"})";   // \|<(\w{2})(\w{0,15})

            Regex takePictures = new Regex(pattern);

            var matchedPictures = takePictures.Matches(inputText);

            foreach (Match pic in matchedPictures)
            {
                picsTaken.Add(pic.Groups[2].Value.ToString());
            }


            Console.WriteLine(string.Join(", ", picsTaken));
        }
    }
}
