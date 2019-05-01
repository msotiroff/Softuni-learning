using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountRealNumbers
{
    class CountRealNumbers
    {
        static void Main(string[] args)
        {
            SortedDictionary<double, int> numbersCount = new SortedDictionary<double, int>();

            double[] numbers = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbersCount.ContainsKey(numbers[i]))
                {
                    numbersCount[numbers[i]]++;
                }
                else
                {
                    numbersCount[numbers[i]] = 1;
                }
            }

            foreach (var item in numbersCount)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }

        }
    }
}