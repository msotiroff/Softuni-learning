using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.SoftUniCamp
{
    class Program
    {
        static void Main(string[] args)
        {
            int groups = int.Parse(Console.ReadLine());
            int car = 0;
            int van = 0;
            int smallBus = 0;
            int bigBus = 0;
            int train = 0;
            int allTourists = 0;

            for (int i = 0; i < groups; i++)
            {
                int tourists = int.Parse(Console.ReadLine());
                if (tourists <= 5)
                {
                    car += tourists;
                }
                else if (tourists > 5 && tourists <= 12)
                {
                    van += tourists;
                }
                else if (tourists > 12 && tourists <= 25)
                {
                    smallBus += tourists;
                }
                else if (tourists > 25 && tourists <= 40)
                {
                    bigBus += tourists;
                }
                else if (tourists > 40)
                {
                    train += tourists;
                }
                allTourists += tourists;
            }
            Console.WriteLine("{0:f2}%", (double)car / allTourists * 100);
            Console.WriteLine("{0:f2}%", (double)van / allTourists * 100);
            Console.WriteLine("{0:f2}%", (double)smallBus / allTourists * 100);
            Console.WriteLine("{0:f2}%", (double)bigBus / allTourists * 100);
            Console.WriteLine("{0:f2}%", (double)train / allTourists * 100);

        }
    }
}
