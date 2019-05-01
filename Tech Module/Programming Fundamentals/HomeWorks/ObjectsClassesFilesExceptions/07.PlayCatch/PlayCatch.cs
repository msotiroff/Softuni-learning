using System;
using System.Linq;

namespace _07.PlayCatch
{
    class PlayCatch
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int exeptionCounter = 0;

            while (true)
            {
                try
                {
                    string[] commands = Console.ReadLine().Split(' ');

                    string command = commands[0];

                    if (command == "Replace")
                    {
                        int index = int.Parse(commands[1]);
                        int element = int.Parse(commands[2]);

                        numbers[index] = element;
                    }
                    else if (command == "Print")
                    {
                        int startIndex = int.Parse(commands[1]);
                        int endIndex = int.Parse(commands[2]);

                        string result = string.Empty;

                        for (int i = startIndex; i <= endIndex; i++)
                        {
                            result += numbers[i] + ", ";
                        }

                        result = result.Substring(0, result.Length - 2);

                        Console.WriteLine(result);
                    }
                    else if (command == "Show")
                    {
                        int index = int.Parse(commands[1]);
                        Console.WriteLine(numbers[index]);
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    exeptionCounter++;
                    Console.WriteLine("The index does not exist!");
                }
                catch (FormatException)
                {
                    exeptionCounter++;
                    Console.WriteLine("The variable is not in the correct format!");
                }

                if (exeptionCounter == 3)
                {
                    break;
                }
            }

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
