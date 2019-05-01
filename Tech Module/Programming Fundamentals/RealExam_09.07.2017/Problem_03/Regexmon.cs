using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Problem_03
{
    class Regexmon
    {
        static void Main(string[] args)
        {
            string inputLine = Console.ReadLine();

            Regex bojoRegex = new Regex(@"[A-Za-z]+\-[A-Za-z]+");
            Regex didiRegex = new Regex(@"[^\-A-Za-z]+");

            while (true)
            {
                var didiMatch = didiRegex.Match(inputLine);

                if (didiMatch.Success)
                {
                    string matchOfDidi = didiMatch.ToString();
                    int indexOfMatch = inputLine.IndexOf(matchOfDidi);
                    int lastIndexOfCurrentMatch = indexOfMatch + matchOfDidi.Length;

                    Console.WriteLine(matchOfDidi);
                    if (inputLine.Length >= lastIndexOfCurrentMatch)
                    {
                        inputLine = inputLine.Substring(lastIndexOfCurrentMatch);
                    }
                }
                else
                {
                    break;
                }

                var bojoMatch = bojoRegex.Match(inputLine);

                if (bojoMatch.Success)
                {
                    string matchOfBojo = bojoMatch.ToString();
                    int indexOfMatch = inputLine.IndexOf(matchOfBojo);
                    int lastIndexOfCurrentMatch = indexOfMatch + matchOfBojo.Length;

                    Console.WriteLine(matchOfBojo);
                    if (inputLine.Length >= lastIndexOfCurrentMatch)
                    {
                        inputLine = inputLine.Substring(lastIndexOfCurrentMatch);
                    }
                }
                else
                {
                    break;
                }



            }



        }
    }
}
