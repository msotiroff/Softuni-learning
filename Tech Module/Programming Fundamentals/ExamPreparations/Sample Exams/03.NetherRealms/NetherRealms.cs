using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03.NetherRealms
{
    class NetherRealms
    {
        static void Main(string[] args)
        {
            //                Name      [0]-Health, [1]-Damage
            SortedDictionary<string, List<double>> allDemons =
                new SortedDictionary<string, List<double>>();

            string[] demonNames = Console.ReadLine()
                .Split(',')
                .Select(d => d.Trim())
                .ToArray();
            var aritmethicSymbols = "0123456789.*/-+".ToCharArray();

            Regex getNumbers = new Regex(@"[\+\-]?\d+\.?\d*");

            for (int i = 0; i < demonNames.Length; i++)
            {
                string currentDemonName = demonNames[i];
                int currDemonHealth = 0;
                double currDemonDamage = 0;

                currDemonHealth = GetDemonHealt(aritmethicSymbols, currentDemonName, currDemonHealth);

                currDemonDamage = GetDemonDamage(getNumbers, currentDemonName, currDemonDamage);

                if (! allDemons.ContainsKey(currentDemonName))
                {
                    allDemons[currentDemonName] = new List<double>();
                    allDemons[currentDemonName].Add(0);
                    allDemons[currentDemonName].Add(0);

                }
                allDemons[currentDemonName][0] = 1.0 * currDemonHealth;
                allDemons[currentDemonName][1] = currDemonDamage;
            }

            foreach (var demon in allDemons)
            {
                Console.WriteLine($"{demon.Key} - {demon.Value[0]} health, {demon.Value[1]:f2} damage");
            }

        }

        public static double GetDemonDamage(Regex getNumbers, string currentDemonName, double currDemonDamage)
        {
            var mathedNumbers = getNumbers.Matches(currentDemonName);

            foreach (Match number in mathedNumbers)
            {
                currDemonDamage += double.Parse(number.Value.ToString());
            }
            for (int j = 0; j < currentDemonName.Length; j++)
            {
                if (currentDemonName[j] == '/')
                {
                    currDemonDamage /= 2;
                }
                else if (currentDemonName[j] == '*')
                {
                    currDemonDamage *= 2;
                }
            }

            return currDemonDamage;
        }

        public static int GetDemonHealt(char[] aritmethicSymbols, string currentDemonName, int currDemonHealth)
        {
            for (int j = 0; j < currentDemonName.Length; j++)
            {
                if (!aritmethicSymbols.Contains(currentDemonName[j]))
                {
                    currDemonHealth += Convert.ToInt32(currentDemonName[j]);
                }
            }

            return currDemonHealth;
        }
    }
}
