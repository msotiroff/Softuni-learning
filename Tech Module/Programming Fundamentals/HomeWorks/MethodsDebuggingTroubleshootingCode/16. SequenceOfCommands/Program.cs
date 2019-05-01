using System;
using System.Collections.Generic;
using System.Linq;

namespace _16.SequenceOfCommands
{
    class Program
    {
        public static void Main()
        {
            int sizeOfArray = int.Parse(Console.ReadLine());

            List<int> numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            string command = Console.ReadLine();

            while (command != "stop")
            {
                if (command == "lshift")
                {
                    int firstElement = numbers[0];
                    numbers.RemoveAt(0);
                    numbers.Add(firstElement);
                }
                else if (command == "rshift")
                {
                    int lastElement = numbers.Last();
                    numbers.RemoveAt(numbers.Count - 1);
                    numbers.Insert(0, lastElement);
                }
                else
                {
                    TransformNumberInCollection(numbers, command);
                }

                Console.WriteLine(string.Join(" ", numbers));

                command = Console.ReadLine();
            }
            
        }

        public static void TransformNumberInCollection(List<int> numbers, string command)
        {
            string[] commandParameters = command.Split(' ').ToArray();
            string action = commandParameters[0];
            int indexToChange = int.Parse(commandParameters[1]) - 1;
            int value = int.Parse(commandParameters[2]);

            if (action == "add")
            {
                numbers[indexToChange] += value;
            }
            else if (action == "subtract")
            {
                numbers[indexToChange] -= value;
            }
            else if (action == "multiply")
            {
                numbers[indexToChange] *= value;
            }
        }
    }
}

