using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altitude
{
    class Altitude
    {
        static void Main(string[] args)
        {
            string[] commands = Console.ReadLine().Split(' ').ToArray();

            double temporaryAltitude = double.Parse(commands[0]);
            
            for (int i = 1; i < commands.Length; i++)
            {
                if (i % 2 != 0)
                {
                    if (commands[i] == "up")
                    {
                        temporaryAltitude += double.Parse(commands[i + 1]);
                    }
                    else if (commands[i] == "down")
                    {
                        temporaryAltitude -= double.Parse(commands[i + 1]);
                        if (temporaryAltitude <= 0)
                        {
                            Console.WriteLine("crashed");
                            return;
                        }
                    }
                }
            }

            Console.WriteLine($"got through safely. current altitude: {temporaryAltitude}m");

        }
    }
}
