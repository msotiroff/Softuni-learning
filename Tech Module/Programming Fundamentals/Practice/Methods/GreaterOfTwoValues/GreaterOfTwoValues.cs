using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreaterOfTwoValues
{
    class GreaterOfTwoValues
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();

            if (type == "int")
            {
                int firstNumber = int.Parse(Console.ReadLine());
                int secondNumber = int.Parse(Console.ReadLine());

                int greater = GetMaxValue(firstNumber, secondNumber);
                Console.WriteLine(greater);
            }
            else if (type == "char")
            {
                char firstChar = char.Parse(Console.ReadLine());
                char secondChar = char.Parse(Console.ReadLine());

                char greater = GetMaxValue(firstChar, secondChar);
                Console.WriteLine(greater);
            }
            else if (type == "string")
            {
                string firstString = Console.ReadLine();
                string secondString = Console.ReadLine();

                string greater = GetMaxValue(firstString, secondString);
                Console.WriteLine(greater);
            }

        }

        static int GetMaxValue(int firstNumber, int secondNumber)
        {
            if (firstNumber > secondNumber)
            {
                return firstNumber;
            }
            else
            {
                return secondNumber;
            }
        }

        static char GetMaxValue(char firstChar, char secondChar)
        {
            if (firstChar > secondChar)
            {
                return firstChar;
            }
            else
            {
                return secondChar;
            }
        }

        static string GetMaxValue(string firstStr, string secondStr)
        {
            if (firstStr.CompareTo(secondStr) >= 0)
            {
                return firstStr;
            }
            else
            {
                return secondStr;
            }
        }
    }
}
