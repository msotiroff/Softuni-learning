using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegerInsertion
{
    class IntegerInsertion
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            string command = Console.ReadLine();

            while (command != "end")
            {
                int currentNumber = int.Parse(command);
                int copyOfCurrentNumber = currentNumber;
                int currentFirstDigit = 0;
                while (copyOfCurrentNumber > 0)
                {
                    currentFirstDigit = copyOfCurrentNumber % 10;
                    copyOfCurrentNumber /= 10;
                }
                numbers.Insert(currentFirstDigit, currentNumber);
                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
