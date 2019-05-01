using System;
using System.Linq;

namespace _3.Safe_Manipulation
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputLine = Console.ReadLine().Split(' ').ToArray();

            string[] commands = Console.ReadLine().Split(' ').ToArray();

            while (commands[0] != "END")
            {
                inputLine = ChangeInputSuccessfully(inputLine, commands);

                commands = Console.ReadLine().Split(' ').ToArray();
            }

            Console.WriteLine(string.Join(", ", inputLine));
        }

        public static string[] ChangeInputSuccessfully(string[] inputLine, string[] commands)
        {
            if (commands.Length == 1)
            {
                if (commands[0] == "Distinct")
                {
                        inputLine = inputLine.Distinct().ToArray();
                }
                else if (commands[0] == "Reverse")
                {
                    inputLine = inputLine.Reverse().ToArray();
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
            else if (commands.Length == 3)
            {
                if (commands[0] == "Replace")
                {
                    int indexToReplace = int.Parse(commands[1]);
                    string wordForRemoving = commands[2];

                    if (indexToReplace > inputLine.Length - 1 || indexToReplace < 0)
                    {
                        Console.WriteLine("Invalid input!");
                    }
                    else
                    {
                        inputLine[indexToReplace] = wordForRemoving;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
            else
            {
                Console.WriteLine("Invalid input!");
            }

            return inputLine;
        }
    }
}
