using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9.Count_the_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputLine = Console.ReadLine();

            int counter = 0;
            bool isNumber = true;
            
            while (isNumber)
            {
                int currentNumber;
                if (! int.TryParse(inputLine, out currentNumber))
                {
                    isNumber = false;
                }
                else
                {
                    counter++;
                    inputLine = Console.ReadLine();
                }
                
            }

            Console.WriteLine(counter);

        }
    }
}
