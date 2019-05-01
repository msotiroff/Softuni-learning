using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitsWithWords
{
    class DigitsWithWords
    {
        static void Main(string[] args)
        {
            string digit = Console.ReadLine().ToLower();

            switch (digit)
            {
                case "zero": Console.WriteLine(0); break;
                case "one": Console.WriteLine(1); break;
                case "two": Console.WriteLine(2); break;
                case "three": Console.WriteLine(3);break;
                case "four": Console.WriteLine(4);break;
                case "five": Console.WriteLine(5);break;
                case "six": Console.WriteLine(6);break;
                case "seven": Console.WriteLine(7);break;
                case "eight": Console.WriteLine(8);break;
                case "nine": Console.WriteLine(9);break;
                default:
                    Console.WriteLine("Error occured! You have to enter a valid digit name!");
                    break;
            }
        }
    }
}
