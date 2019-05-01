using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _03.Trainegram
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> allValidTrains = new List<string>();

            string pattern = @"^(\<\[[^A-Za-z0-9]*]\.)(\.\[[A-Za-z0-9]*]\.)*$";

            Regex validateTrain = new Regex(pattern);

            string inputLine = Console.ReadLine();

            while (inputLine != "Traincode!")
            {
                var currentMatch = validateTrain.Match(inputLine);

                if (currentMatch.Success)
                {
                    allValidTrains.Add(inputLine);
                }


                inputLine = Console.ReadLine();
            }


            Console.WriteLine(string.Join(Environment.NewLine, allValidTrains));
        }
    }
}
