using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CypherRoulette
{
    class CypherRoulette
    {
        static void Main(string[] args)
        {
            // Задачата не е решена!!!

            int n = int.Parse(Console.ReadLine());
            string cypherString = "";
            string currString = "";
            string prevString = "";

            int spinCounter = 0;
            for (int i = 1; i <= n; i++)
            {
                currString = Console.ReadLine();
                
                if (prevString == currString)
                {
                    cypherString = string.Empty;
                }
                if (currString == "spin")
                {
                    spinCounter++;
                    i--;
                }
                if (spinCounter % 2 != 0)
                {
                    cypherString = cypherString + currString;
                }
                else
                {
                    prevString += currString;
                    cypherString = prevString + cypherString;
                }


            }
            Console.WriteLine(cypherString);
        }
    }
}

