using System;

namespace _5.VariableInHexFormat
{
    class VariableInHexFormat
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int number = Convert.ToInt32(input, 16);

            Console.WriteLine(number);
        }
    }
}
