using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.KarateStrings
{
    class KarateStrings
    {
        static void Main(string[] args)
        {
            var inputLine = Console.ReadLine().ToCharArray().Select(x => x.ToString()).ToList();
            var digits = "0123456789".ToCharArray().Select(x => x.ToString()).ToList();

            string result = string.Empty; ;

            int punchStrenght = 0;

            for (int i = 1; i < inputLine.Count; i++)
            {
                string previousSymbol = inputLine[i - 1];
                string currentSymbol = inputLine[i];

                if (digits.Contains(currentSymbol) && previousSymbol == ">")
                {
                    punchStrenght += int.Parse(currentSymbol.ToString());
                    try
                    {
                        while (inputLine[i] != ">" && punchStrenght > 0 && i < inputLine.Count)
                        {
                            inputLine.RemoveAt(i);
                            punchStrenght--;
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine();
                    }
                }
            }

            foreach (var symbol in inputLine)
            {
                result += symbol;
            }

            Console.WriteLine(result);


        }
    }
}
