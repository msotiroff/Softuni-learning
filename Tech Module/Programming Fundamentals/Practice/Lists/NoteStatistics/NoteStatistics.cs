using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteStatistics
{
    class NoteStatistics
    {
        static void Main(string[] args)
        {
            List<double> frequencies = Console.ReadLine()
                                .Split(' ')
                                .Select(double.Parse)
                                .ToList();

            List<string> naturalNotes = new List<string>();
            List<string> sharpNotes = new List<string>();
            List<string> allNotes = new List<string>();
            double naturalSum = 0;
            double sharpsSum = 0;

            for (int i = 0; i < frequencies.Count; i++)
            {
                if (frequencies[i] == 261.63)
                {
                    naturalNotes.Add("C");
                    allNotes.Add("C");
                    naturalSum += frequencies[i];
                }
                else if (frequencies[i] == 293.66)
                {
                    naturalNotes.Add("D");
                    allNotes.Add("D");
                    naturalSum += frequencies[i];
                }
                else if (frequencies[i] == 329.63)
                {
                    naturalNotes.Add("E");
                    allNotes.Add("E");
                    naturalSum += frequencies[i];
                }
                else if (frequencies[i] == 349.23)
                {
                    naturalNotes.Add("F");
                    allNotes.Add("F");
                    naturalSum += frequencies[i];
                }
                else if (frequencies[i] == 392.00)
                {
                    naturalNotes.Add("G");
                    allNotes.Add("G");
                    naturalSum += frequencies[i];
                }
                else if (frequencies[i] == 440.00)
                {
                    naturalNotes.Add("A");
                    allNotes.Add("A");
                    naturalSum += frequencies[i];
                }
                else if (frequencies[i] == 493.88)
                {
                    naturalNotes.Add("B");
                    allNotes.Add("B");
                    naturalSum += frequencies[i];
                }
                else if (frequencies[i] == 277.18)
                {
                    sharpNotes.Add("C#");
                    allNotes.Add("C#");
                    sharpsSum += frequencies[i];
                }
                else if (frequencies[i] == 311.13)
                {
                    sharpNotes.Add("D#");
                    allNotes.Add("D#");
                    sharpsSum += frequencies[i];
                }
                else if (frequencies[i] == 369.99)
                {
                    sharpNotes.Add("F#");
                    allNotes.Add("F#");
                    sharpsSum += frequencies[i];
                }
                else if (frequencies[i] == 415.30)
                {
                    sharpNotes.Add("G#");
                    allNotes.Add("G#");
                    sharpsSum += frequencies[i];
                }
                else if (frequencies[i] == 466.16)
                {
                    sharpNotes.Add("A#");
                    allNotes.Add("A#");
                    sharpsSum += frequencies[i];
                }
            }

            

            Console.WriteLine("Notes: {0}", string.Join(" ", allNotes));
            Console.WriteLine("Naturals: {0}", string.Join(", ", naturalNotes));
            Console.WriteLine("Sharps: {0}", string.Join(", ", sharpNotes));
            Console.WriteLine($"Naturals sum: {naturalSum}");
            Console.WriteLine($"Sharps sum: {sharpsSum}");

          
            //for (int i = 0; i < frequencies.Count; i++)
            //{
            //    Console.Beep((int)frequencies[i], 300);
            //}

        }
    }
}
