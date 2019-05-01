using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Numbers
{
    class Numbers
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            double avg = numbers.Average();
            int counter = 0;

            foreach (var number in numbers.Where(n => n > avg).OrderByDescending(n => n))
            {
                counter++;
                Console.Write(number + " ");
                if (counter == 5)
                {
                    break;
                }
            }

            if (counter == 0)
            {
                Console.WriteLine("No");
            }
            
        }
    }
}
