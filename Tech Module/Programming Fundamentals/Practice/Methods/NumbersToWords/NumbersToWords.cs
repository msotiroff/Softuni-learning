using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbersToWords
{
    class NumbersToWords
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int numberToPrint = int.Parse(Console.ReadLine());
                LetterizeNumber(numberToPrint);
            }
        }

        public static void LetterizeNumber(int number)
        {
            if (number > 999)
            {
                Console.WriteLine("too large");
            }
            else if (number < -999)
            {
                Console.WriteLine("too small");
            }
            else
            {
                string numberAsString = Math.Abs(number).ToString();
                if (numberAsString.Length == 3)
                {
                    if (number < 0)
                    {
                        Console.Write("minus ");
                    }
                    switch (numberAsString[0])
                    {
                        case '1': Console.Write("one-"); break;
                        case '2': Console.Write("two-"); break;
                        case '3': Console.Write("three-"); break;
                        case '4': Console.Write("four-"); break;
                        case '5': Console.Write("five-"); break;
                        case '6': Console.Write("six-"); break;
                        case '7': Console.Write("seven-"); break;
                        case '8': Console.Write("eight-"); break;
                        case '9': Console.Write("nine-"); break;
                    }
                    Console.Write("hundred");

                    if (numberAsString[2] == '0')
                    {
                        switch (numberAsString[1])
                        {
                            case '1': Console.Write(" and ten"); break;
                            case '2': Console.Write(" and twenty"); break;
                            case '3': Console.Write(" and thirty"); break;
                            case '4': Console.Write(" and forty"); break;
                            case '5': Console.Write(" and fifty"); break;
                            case '6': Console.Write(" and sixty"); break;
                            case '7': Console.Write(" and seventy"); break;
                            case '8': Console.Write(" and eighty"); break;
                            case '9': Console.Write(" and ninety"); break;
                            default: break;
                        }
                    }
                    else
                    {
                        if (numberAsString[1] == '1')
                        {
                            switch (numberAsString[2])
                            {
                                case '1': Console.Write(" and eleven"); break;
                                case '2': Console.Write(" and twelve"); break;
                                case '3': Console.Write(" and thirteen"); break;
                                case '4': Console.Write(" and fourteen"); break;
                                case '5': Console.Write(" and fifteen"); break;
                                case '6': Console.Write(" and sixteen"); break;
                                case '7': Console.Write(" and seventeen"); break;
                                case '8': Console.Write(" and eighteen"); break;
                                case '9': Console.Write(" and nineteen"); break;
                                default:
                                    break;
                            }
                        }
                        else
                        {
                            switch (numberAsString[1])
                            {
                                case '0': Console.Write(" and"); break;
                                case '2': Console.Write(" and twenty"); break;
                                case '3': Console.Write(" and thirty"); break;
                                case '4': Console.Write(" and forty"); break;
                                case '5': Console.Write(" and fifty"); break;
                                case '6': Console.Write(" and sixty"); break;
                                case '7': Console.Write(" and seventy"); break;
                                case '8': Console.Write(" and eighty"); break;
                                case '9': Console.Write(" and ninety"); break;
                                default: break;
                            }
                            switch (numberAsString[2])
                            {
                                case '1': Console.Write(" one"); break;
                                case '2': Console.Write(" two"); break;
                                case '3': Console.Write(" three"); break;
                                case '4': Console.Write(" four"); break;
                                case '5': Console.Write(" five"); break;
                                case '6': Console.Write(" six"); break;
                                case '7': Console.Write(" seven"); break;
                                case '8': Console.Write(" eight"); break;
                                case '9': Console.Write(" nine"); break;
                                default:
                                    break;
                            }
                        }

                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
