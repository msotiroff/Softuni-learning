using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Calculator
    {
        static void Main(string[] args)
        {
            int firstOperand = int.Parse(Console.ReadLine());
            string theOperator = Console.ReadLine();
            int secondOperand = int.Parse(Console.ReadLine());

            double result = 0;

            switch (theOperator)
            {
                case "+": result = firstOperand + secondOperand;break;
                case "-": result = firstOperand - secondOperand;break;
                case "*": result = firstOperand * secondOperand;break;
                case "/": result = firstOperand / secondOperand; break;
                default:
                    break;
            }
            Console.WriteLine($"{firstOperand} {theOperator} {secondOperand} = {result}");
        }
    }
}
