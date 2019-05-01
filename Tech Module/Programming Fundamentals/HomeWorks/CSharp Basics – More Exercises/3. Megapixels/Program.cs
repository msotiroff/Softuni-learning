using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Megapixels
{
    class Megapixels
    {
        static void Main(string[] args)
        {
            int imageWidth = int.Parse(Console.ReadLine());
            int imageHeight = int.Parse(Console.ReadLine());

            double resolution = (double)imageWidth * imageHeight / 1000000;

            Console.WriteLine($"{imageWidth}x{imageHeight} => {Math.Round(resolution, 1)}MP");
        }
    }
}
