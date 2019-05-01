using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Shoot_List_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            //Until you receive the command "stop", you will either receive an integer,
            //or the command bang on every line.
            //If you receive an integer, place it at the front of the list. 
            //If, however, you receive the command bang, remove the first element whose value is
            //smaller than the average of the elements of the list, print "shot {element}"
            //and then decrement every element in the list by 1.
            //If you receive "bang" and there are no elements left in the list,
            //print "nobody left to shoot! last one was {lastRemovedInt}" and end the program. 
            //When you finally do receive the command "end", 
            //either print "survivors: {elements, separated by space}" if there are any,
            //or "you shot them all. last one standing was {lastRemovedInt}".

            //Note: for this exercise, you are not allowed to use LINQ
            //for the actual algorithms (parsing the input with LINQ is okay). 

            string input = Console.ReadLine();

            List<int> numbers = new List<int>();
            int lastRemovedInt = 0;

            while (input != "stop")
            {
                int parsedNumber = 0;
                if (int.TryParse(input, out parsedNumber))
                {
                    numbers.Insert(0, parsedNumber);
                }
                else
                {
                    if (input == "bang")
                    {
                        if (numbers.Count == 0)
                        {
                            Console.WriteLine($"nobody left to shoot! last one was {lastRemovedInt}");
                            return;
                        }
                        double currentAverage = numbers.Average();
                        for (int i = 0; i < numbers.Count; i++)
                        {
                            if (numbers[i] <= currentAverage)
                            {
                                Console.WriteLine($"shot {numbers[i]}");
                                lastRemovedInt = numbers[i];
                                numbers.RemoveAt(i);
                                for (int j = 0; j < numbers.Count; j++)
                                {
                                    numbers[j]--;
                                }
                                break;
                            }
                        }
                    }
                }
                input = Console.ReadLine();
            }
            if (numbers.Count == 0)
            {
                Console.WriteLine($"you shot them all. last one was {lastRemovedInt}");
            }
            else
            {
                Console.WriteLine($"survivors: {string.Join(" ", numbers)}");

            }
        }
    }
}
