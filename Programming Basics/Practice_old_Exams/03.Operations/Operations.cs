using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Operations
{
    class Operations
    {
        static void Main(string[] args)
        {
            double num1 = double.Parse(Console.ReadLine());
            double num2 = double.Parse(Console.ReadLine());
            string operation = Console.ReadLine();

            
            if (operation == "/")
            {
                if (num2 == 0)
                {
                    Console.WriteLine($"Cannot divide {num1} by zero");
                }
                else
                {
                    double result = num1 / num2;
                    Console.WriteLine($"{num1} / {num2} = {result:f2}");
                }
            }
            else if (operation == "%")
            {
                if (num2 == 0)
                {
                    Console.WriteLine($"Cannot divide {num1} by zero");
                }
                else
                {
                    double result = num1 % num2;
                    Console.WriteLine($"{num1} % {num2} = {result}");
                }
            }
            else
            {
                double result = 0;
                string numberType = "odd";
                if (operation == "+")
                {
                    result = num1 + num2;
                }
                else if (operation == "-")
                {
                    result = num1 - num2;
                }
                else if (operation == "*")
                {
                    result = num1 * num2;
                }
                if (result % 2 == 0)
                {
                    numberType = "even";
                }
                Console.WriteLine($"{num1} {operation} {num2} = {result} - {numberType}");
            }

        }
    }
}
