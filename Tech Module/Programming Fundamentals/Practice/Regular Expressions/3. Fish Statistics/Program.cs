using System;
using System.Text.RegularExpressions;

namespace _3.Fish_Statistics
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputLine = Console.ReadLine();

            string pattern = @"([>]*)<*(\(+)(['|x|-])>";

            Regex fishes = new Regex(pattern);

            var matchedFishes = fishes.Matches(inputLine);

            if (matchedFishes.Count > 0)
            {
                int fishCounter = 0;

                foreach (Match fish in matchedFishes)
                {
                    fishCounter++;
                    int tailLenght = fish.Groups[1].Value.Length;
                    int bodyLenght = fish.Groups[2].Value.Length;

                    Console.WriteLine($"Fish {fishCounter}: {fish.Value}");
                    PrintTailDetails(tailLenght);
                    PrintBodyDetails(bodyLenght);
                    PrintStatus(fish);
                }
            }
            else
            {
                Console.WriteLine("No fish found.");
            }
        }




        public static void PrintStatus(Match fish)
        {
            string status = "Awake";
            if (fish.Groups[3].Value.ToString() == "-")
            {
                status = "Asleep";
            }
            else if (fish.Groups[3].Value.ToString() == "x")
            {
                status = "Dead";
            }
            Console.WriteLine($"Status: {status}");
        }

        public static void PrintBodyDetails(int bodyLenght)
        {
            Console.Write("Body type: ");
            if (bodyLenght <= 5)
            {
                Console.WriteLine($"Short ({bodyLenght * 2} cm)");
            }
            else if (bodyLenght <= 10)
            {
                Console.WriteLine($"Medium ({bodyLenght * 2} cm)");
            }
            else if (bodyLenght > 10)
            {
                Console.WriteLine($"Long ({bodyLenght * 2} cm)");
            }
        }

        public static void PrintTailDetails(int tailLenght)
        {
            Console.Write("Tail type: ");
            if (tailLenght < 1)
            {
                Console.WriteLine("None");
            }
            else if (tailLenght == 1)
            {
                Console.WriteLine("Short (2 cm)");
            }
            else if (tailLenght <= 5)
            {
                Console.WriteLine($"Medium ({tailLenght * 2} cm)");
            }
            else if (tailLenght > 5)
            {
                Console.WriteLine($"Long ({tailLenght * 2} cm)");
            }
        }
    }
}
