using System;
using System.Text.RegularExpressions;

namespace _08.Mines
{
    class Mines
    {
        static void Main(string[] args)
        {
            string inputLine = Console.ReadLine();

            Regex findMine = new Regex(@"[^<>]*(?<Tag><(?<Bomb>.{2})>)");


            var matchedBombs = findMine.Matches(inputLine);

            foreach (Match currentBomb in matchedBombs)
            {
                int firstCharASCII = Convert.ToInt32(currentBomb.Groups["Bomb"].Value.ToString()[0]);
                int secondCharASCII = Convert.ToInt32(currentBomb.Groups["Bomb"].Value.ToString()[1]);

                int bombSum = Math.Abs(firstCharASCII - secondCharASCII);

                string detonation = @".{0," + bombSum + @"}<.{2}>.{0," + bombSum + @"}";
                Regex bombPower = new Regex(detonation);
                string toReplace = bombPower.Match(inputLine).ToString();

                inputLine = inputLine.Replace(toReplace, new string('_', toReplace.Length));
              
            }
            
            Console.WriteLine(inputLine);
        }
    }
}
