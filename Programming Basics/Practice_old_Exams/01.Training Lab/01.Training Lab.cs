using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Training_Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            double w = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());

            int seat = (int)(h * 100 - 100) / 70;
            int rows = (int)(w * 100 / 120);

            int result = seat * rows - 3;

            Console.WriteLine(result);
        }
    }
}
