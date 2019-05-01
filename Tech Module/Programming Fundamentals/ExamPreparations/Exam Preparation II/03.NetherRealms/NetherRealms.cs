using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _03.NetherRealms
{
    class NetherRealms
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, List<double>> allDemons =
                new SortedDictionary<string, List<double>>();

            string[] demonNames = Console.ReadLine()
                .Split(',')
                .Select(x => x.Trim())
                .ToArray();

            Regex getNumber = new Regex(@"-?\d*\.?\d+"); // Alternative:  -*[0-9]\.*[0-9]*         [\+\-]*[0-9.]+[0-9]*

            for (int i = 0; i < demonNames.Length; i++)
            {
                string currentDemonName = demonNames[i];
                int currentDemonHealth = 0;
                double currentDemonDamage = 0;
                
                char[] delimiters = "0123456789*+-/.".ToCharArray();

                for (int j = 0; j < currentDemonName.Length; j++)
                {
                    if (!delimiters.Contains(currentDemonName[j]))
                    {
                        int codeOfLetter = (int)(currentDemonName[j]);
                        currentDemonHealth += codeOfLetter;
                    }
                }

                var matchedNumbers = getNumber.Matches(currentDemonName);

                foreach (Match number in matchedNumbers)
                {
                    double currentNumber = double.Parse(number.Value);
                    currentDemonDamage += currentNumber;
                }

                for (int j = 0; j < currentDemonName.Length; j++)
                {
                    char currentSymbol = currentDemonName[j];
                    if (currentSymbol == '*')
                    {
                        currentDemonDamage *= 2;
                    }
                    else if (currentSymbol == '/')
                    {
                        currentDemonDamage /= 2;
                    }
                }

                if (! allDemons.ContainsKey(currentDemonName))
                {
                    allDemons[currentDemonName] = new List<double>();
                }
                allDemons[currentDemonName].Add(currentDemonHealth);
                allDemons[currentDemonName].Add(currentDemonDamage);
            }

            foreach (var demon in allDemons)
            {
                Console.WriteLine($"{demon.Key} - {demon.Value[0]} health, {demon.Value[1]:f2} damage");
            }
        }
    }
}
