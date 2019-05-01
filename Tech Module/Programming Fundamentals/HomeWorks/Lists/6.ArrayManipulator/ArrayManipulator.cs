using System;
using System.Collections.Generic;
using System.Linq;

namespace _6.ArrayManipulator
{
    class ArrayManipulator
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            string command = Console.ReadLine();

            while (command != "print")
            {
                string[] commandParameters = command.Split(' ').ToArray();
                if (commandParameters[0] == "add")
                {
                    int index = int.Parse(commandParameters[1]);
                    int element = int.Parse(commandParameters[2]);

                    numbers.Insert(index, element);
                }
                else if (commandParameters[0] == "addMany")
                {
                    int index = int.Parse(commandParameters[1]);
                    List<int> numbersToAdd = commandParameters
                        .Skip(2)
                        .Take(commandParameters.Length - 2)
                        .Select(int.Parse)
                        .ToList();

                        numbers.InsertRange(index, numbersToAdd);
                }
                else if (commandParameters[0] == "contains")
                {
                    int elementToFind = int.Parse(commandParameters[1]);
                    int neededIndex = numbers.IndexOf(elementToFind);
                    Console.WriteLine(neededIndex);
                }
                else if (commandParameters[0] == "remove")
                {
                    int indexToRemove = int.Parse(commandParameters[1]);
                    numbers.RemoveAt(indexToRemove);
                }
                else if (commandParameters[0] == "shift")
                {
                    int numbersToShift = int.Parse(commandParameters[1]) % numbers.Count;

                    for (int i = 0; i < numbersToShift; i++)
                    {
                        numbers.Add(numbers[0]);
                        numbers.RemoveAt(0);
                    }

                }
                else if (commandParameters[0] == "sumPairs")
                {
                    List<int> summedNumbers = new List<int>();

                    for (int i = 0; i < numbers.Count - 1; i += 2)
                    {
                        int currentSummedNumber = numbers[i] + numbers[i + 1];
                        summedNumbers.Add(currentSummedNumber);
                    }
                    if (numbers.Count % 2 != 0)
                    {
                        summedNumbers.Add(numbers[numbers.Count - 1]);
                    }

                    numbers = summedNumbers.ToList();
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"[{string.Join(", ", numbers)}]");
        }
    }
}
