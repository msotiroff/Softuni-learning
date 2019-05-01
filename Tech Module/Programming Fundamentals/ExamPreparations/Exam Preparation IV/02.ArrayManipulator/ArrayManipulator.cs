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
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            string inputCommand = Console.ReadLine();

            while (inputCommand != "end")
            {
                string[] currentCommand = inputCommand.Split(' ').ToArray();

                if (currentCommand[0] == "exchange")
                {
                    int index = int.Parse(currentCommand[1]);
                    if (index >= 0 && index <= numbers.Count - 1)
                    {
                        List<int> leftPart = numbers.Take(index + 1).ToList();
                        List<int> rightPart = numbers.Skip(index + 1).ToList();

                        numbers = rightPart.Concat(leftPart).ToList();
                    }
                    else
                    {
                        Console.WriteLine("Invalid index");
                        inputCommand = Console.ReadLine();
                        continue;
                    }
                }
                else if (currentCommand[0] == "max")
                {
                    ExecuteMaxCommand(numbers, currentCommand);
                }
                else if (currentCommand[0] == "min")
                {
                    ExecuteMinCommand(numbers, currentCommand);
                }
                else if (currentCommand[0] == "first")
                {
                    int count = int.Parse(currentCommand[1]);
                    if (count > numbers.Count)
                    {
                        Console.WriteLine("Invalid count");
                        inputCommand = Console.ReadLine();
                        continue;
                    }
                    string evenOrOdd = currentCommand[2];

                    if (evenOrOdd == "odd")
                    {
                        List<int> addNumbers = numbers.Where(x => x % 2 != 0).ToList();
                        List<int> numbersToPrint = new List<int>();
                        for (int i = 0; i < Math.Min(count, addNumbers.Count); i++)
                        {
                            numbersToPrint.Add(addNumbers[i]);
                        }
                        Console.WriteLine("[{0}]", string.Join(", ", numbersToPrint));
                    }
                    else if (evenOrOdd == "even")
                    {
                        List<int> addNumbers = numbers.Where(x => x % 2 == 0).ToList();
                        List<int> numbersToPrint = new List<int>();
                        for (int i = 0; i < Math.Min(count, addNumbers.Count); i++)
                        {
                            numbersToPrint.Add(addNumbers[i]);
                        }
                        Console.WriteLine("[{0}]", string.Join(", ", numbersToPrint));
                    }
                }
                else if (currentCommand[0] == "last")
                {
                    int count = int.Parse(currentCommand[1]);
                    if (count > numbers.Count)
                    {
                        Console.WriteLine("Invalid count");
                        inputCommand = Console.ReadLine();
                        continue;
                    }
                    string evenOrOdd = currentCommand[2];

                    if (evenOrOdd == "odd")
                    {
                        List<int> addNumbers = numbers.Where(x => x % 2 != 0).ToList();
                        List<int> numbersToPrint = new List<int>();
                        addNumbers.Reverse();
                        for (int i = 0; i < Math.Min(count, addNumbers.Count); i++)
                        {
                            numbersToPrint.Add(addNumbers[i]);
                        }
                        numbersToPrint.Reverse();
                        Console.WriteLine("[{0}]", string.Join(", ", numbersToPrint));
                    }
                    else if (evenOrOdd == "even")
                    {
                        List<int> addNumbers = numbers.Where(x => x % 2 == 0).ToList();
                        List<int> numbersToPrint = new List<int>();
                        addNumbers.Reverse();
                        for (int i = 0; i < Math.Min(count, addNumbers.Count); i++)
                        {
                            numbersToPrint.Add(addNumbers[i]);
                        }
                        numbersToPrint.Reverse();
                        Console.WriteLine("[{0}]", string.Join(", ", numbersToPrint));
                    }

                }




                inputCommand = Console.ReadLine();
            }

            Console.WriteLine("[{0}]", string.Join(", ", numbers));
        }

        private static void ExecuteMaxCommand(List<int> numbers, string[] currentCommand)
        {
            if (currentCommand[1] == "odd")
            {
                try
                {
                    int greaterOddNumber = numbers.Where(x => x % 2 != 0).Max();
                    int index = numbers.LastIndexOf(greaterOddNumber);
                    Console.WriteLine(index);
                }
                catch (InvalidOperationException)
                {
                    Console.WriteLine("No matches");
                }
            }
            else if (currentCommand[1] == "even")
            {
                try
                {
                    int greaterEvenNumber = numbers.Where(x => x % 2 == 0).Max();
                    int index = numbers.LastIndexOf(greaterEvenNumber);
                    Console.WriteLine(index);
                }
                catch (InvalidOperationException)
                {
                    Console.WriteLine("No matches");
                }
            }
        }

        private static void ExecuteMinCommand(List<int> numbers, string[] currentCommand)
        {
            if (currentCommand[1] == "odd")
            {
                try
                {
                    int smallestOddNumber = numbers.Where(x => x % 2 != 0).Min();
                    int index = numbers.LastIndexOf(smallestOddNumber);
                    Console.WriteLine(index);
                }
                catch (InvalidOperationException)
                {
                    Console.WriteLine("No matches");
                }
            }
            else if (currentCommand[1] == "even")
            {
                try
                {
                    int smallerEvenNumber = numbers.Where(x => x % 2 == 0).Min();
                    int index = numbers.LastIndexOf(smallerEvenNumber);
                    Console.WriteLine(index);
                }
                catch (InvalidOperationException)
                {
                    Console.WriteLine("No matches");
                }
            }
        }
    }
}
