using System;
using System.Linq;

namespace _2.Manipulate_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ').ToArray();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split(' ').ToArray();

                if (command.Length == 1)
                {
                    if (command[0] == "Reverse")
                    {
                        input = input.Reverse().ToArray();
                    }
                    else if (command[0] == "Distinct")
                    {
                        input = input.Distinct().ToArray();
                    }
                }
                else
                {
                    if (command[0] == "Replace")
                    {
                        int indexToReplace = int.Parse(command[1]);
                        string wordForReplacing = command[2];

                        input[indexToReplace] = wordForReplacing;
                    }
                }
            }

            Console.WriteLine(string.Join(", ", input));
        }
    }
}
