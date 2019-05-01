using System;
using System.Collections.Generic;
using System.Linq;

namespace _4.SearchNumber
{
    class SearchNumber
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            int[] commandNumbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int takeТhusМuch = commandNumbers[0];
            int deleteТhusМuch = commandNumbers[1];
            int searchedNumber = commandNumbers[2];

            List<int> result = numbers.Take(takeТhusМuch).ToList();
            result.RemoveRange(0, deleteТhusМuch);

            if (result.Contains(searchedNumber))
            {
                Console.WriteLine("YES!");
            }
            else
            {
                Console.WriteLine("NO!");
            }


        }
    }
}
