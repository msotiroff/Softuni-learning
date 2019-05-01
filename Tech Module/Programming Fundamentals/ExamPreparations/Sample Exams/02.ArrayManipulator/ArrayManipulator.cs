using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.ArrayManipulator
{
    class ArrayManipulator
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] commandParameters = command.Split(' ').ToArray();
                string mainCommand = commandParameters[0];

                if (mainCommand == "exchange")
                {
                    int index = int.Parse(commandParameters[1]);
                    
                    if (index >= 0 && index < numbers.Count)
                    {
                        List<int> leftSequence = numbers.Take(index + 1).ToList();
                        List<int> rightSequence = numbers.Skip(index + 1).ToList();

                        numbers = rightSequence.Concat(leftSequence).ToList();
                    }
                    else
                    {
                        Console.WriteLine("Invalid index");
                        command = Console.ReadLine();
                        continue;
                    }
                }
                else if (mainCommand == "max")
                {
                    FindIndexOfMaxNumber(numbers, commandParameters);
                }
                else if (mainCommand == "min")
                {
                    FindIndexOfMinNunmber(numbers, commandParameters);
                }
                else if (mainCommand == "first")
                {
                    int count = int.Parse(commandParameters[1]);
                    if (count > numbers.Count)
                    {
                        Console.WriteLine("Invalid count");
                        command = Console.ReadLine();
                        continue;
                    }

                    PrintFirstConditionalElements(numbers, commandParameters, count);
                }
                else if (mainCommand == "last")
                {
                    int count = int.Parse(commandParameters[1]);
                    if (count > numbers.Count)
                    {
                        Console.WriteLine("Invalid count");
                        command = Console.ReadLine();
                        continue;
                    }

                    PrintLastConditionalElements(numbers, commandParameters, count);
                }


                command = Console.ReadLine();
            }


            Console.WriteLine("[{0}]", string.Join(", ", numbers));
        }

        public static void PrintLastConditionalElements(List<int> numbers, string[] commandParameters, int count)
        {
            string evenOrOdd = commandParameters[2];

            if (evenOrOdd == "even")
            {
                List<int> toPrint = numbers.Where(n => n % 2 == 0).Reverse().Take(count).Reverse().ToList();
                Console.WriteLine("[{0}]", string.Join(", ", toPrint));
            }
            else if (evenOrOdd == "odd")
            {
                List<int> toPrint = numbers.Where(n => n % 2 != 0).Reverse().Take(count).Reverse().ToList();
                Console.WriteLine("[{0}]", string.Join(", ", toPrint));
            }
        }

        public static void PrintFirstConditionalElements(List<int> numbers, string[] commandParameters, int count)
        {
            string evenOrOdd = commandParameters[2];

            if (evenOrOdd == "even")
            {
                List<int> toPrint = numbers.Where(n => n % 2 == 0).Take(count).ToList();
                Console.WriteLine("[{0}]", string.Join(", ", toPrint));
            }
            else if (evenOrOdd == "odd")
            {
                List<int> toPrint = numbers.Where(n => n % 2 != 0).Take(count).ToList();
                Console.WriteLine("[{0}]", string.Join(", ", toPrint));
            }
        }

        public static void FindIndexOfMinNunmber(List<int> numbers, string[] commandParameters)
        {
            string evenOrOdd = commandParameters[1];

            if (evenOrOdd == "odd")
            {
                try
                {
                    int searchedIndex = numbers.LastIndexOf(numbers.Where(n => n % 2 != 0).Min());
                    Console.WriteLine(searchedIndex);
                }
                catch (InvalidOperationException)
                {
                    Console.WriteLine("No matches");
                }
            }
            else if (evenOrOdd == "even")
            {
                try
                {
                    int searchedIndex = numbers.LastIndexOf(numbers.Where(n => n % 2 == 0).Min());
                    Console.WriteLine(searchedIndex);
                }
                catch (InvalidOperationException)
                {
                    Console.WriteLine("No matches");
                }
            }
        }

        public static void FindIndexOfMaxNumber(List<int> numbers, string[] commandParameters)
        {
            string evenOrOdd = commandParameters[1];

            if (evenOrOdd == "odd")
            {
                try
                {
                    int searchedIndex = numbers.LastIndexOf(numbers.Where(n => n % 2 != 0).Max());
                    Console.WriteLine(searchedIndex);
                }
                catch (InvalidOperationException)
                {
                    Console.WriteLine("No matches");
                }

            }
            else if (evenOrOdd == "even")
            {
                try
                {
                    int searchedIndex = numbers.LastIndexOf(numbers.Where(n => n % 2 == 0).Max());
                    Console.WriteLine(searchedIndex);
                }
                catch (InvalidOperationException)
                {
                    Console.WriteLine("No matches");
                }
            }
        }

    }
}
