using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.BPM_Counter
{
    class BPMCounter
    {
        static void Main(string[] args)
        {
            int beatsPerMinute = int.Parse(Console.ReadLine());
            int numberOfBeat = int.Parse(Console.ReadLine());

            int minutes = numberOfBeat / beatsPerMinute;
            double seconds = (double)numberOfBeat / beatsPerMinute * 60 - minutes * 60;

            double bars = (double)numberOfBeat / 4;

            Console.WriteLine($"{Math.Round(bars, 1)} bars - {minutes}m {(int)seconds}s");
        }
    }
}
