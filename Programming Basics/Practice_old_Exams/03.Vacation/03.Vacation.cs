using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int mature = int.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            int nights = int.Parse(Console.ReadLine());
            string transsport = Console.ReadLine();
            double hotel = 82.99 * nights;
            double maturePrice = 0;
            double studentPrice = 0;

            if (transsport == "train")
            {
                maturePrice = 24.99;
                studentPrice = 14.99;
                if (mature + students >= 50)
                {
                    maturePrice *= 0.5;
                    studentPrice *= 0.5;
                }
            }
            else if (transsport == "bus")
            {
                maturePrice = 32.5;
                studentPrice = 28.5;
            }
            else if (transsport == "boat")
            {
                maturePrice = 42.99;
                studentPrice = 39.99;
            }
            else if (transsport == "airplane")
            {
                maturePrice = 70;
                studentPrice = 50;
            }
            double cost = (2 * (mature * maturePrice + students * studentPrice) + hotel) * 1.1;
            Console.WriteLine("{0:f2}", cost);
        }
    }
}
