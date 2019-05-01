using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.ChangeList
{
    class ChangeList
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            string inputLine = Console.ReadLine();

            while (inputLine != "Odd" && inputLine != "Even")
            {
                string[] inputParameters = inputLine.Split(' ').ToArray();
                string command = inputParameters[0];
                if (command == "Delete")
                {
                    int numberToDelete = int.Parse(inputParameters[1]);
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        if (numbers[i] == numberToDelete)
                        {
                            //numbers.Remove(numbersToDelete);
                            numbers.RemoveAt(i);
                            i--;
                        }
                    }

                }
                else if (command == "Insert")
                {
                    int element = int.Parse(inputParameters[1]);
                    int index = int.Parse(inputParameters[2]);

                    numbers.Insert(index, element);
                }
                

                inputLine = Console.ReadLine();
                
            }

            if (inputLine == "Odd")
            {
                numbers = numbers.Where(x => x % 2 != 0).ToList();
                Console.WriteLine(string.Join(" ", numbers));
            }
            else if (inputLine == "Even")
            {
                numbers = numbers.Where(x => x % 2 == 0).ToList();
                Console.WriteLine(string.Join(" ", numbers));
            }
        }
    }
}
