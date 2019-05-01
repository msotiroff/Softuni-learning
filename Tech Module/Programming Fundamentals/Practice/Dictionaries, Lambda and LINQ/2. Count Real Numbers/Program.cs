using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Count_Real_Numbers
{
    class CountRealNumbers
    {
        static void Main(string[] args)
        {
            List<double> numbers = Console.ReadLine()
                .Split(' ')
                .Select(double.Parse)
                .ToList();
            
            Dictionary<double, int> countedNumbers = new Dictionary<double, int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                double currentNumber = numbers[i];
                if (! countedNumbers.ContainsKey(currentNumber))
                {
                    countedNumbers[currentNumber] = 1;
                }
                else
                {
                    countedNumbers[currentNumber]++;
                }
            }

            countedNumbers = countedNumbers.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            foreach (var item in countedNumbers)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
