using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.Phonebook
{
    class Phonebook
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> phoneBook =
                new Dictionary<string, string>();

            string inputLine = Console.ReadLine();

            while (inputLine != "END")
            {
                string[] tokens = inputLine.Split(' ').ToArray();
                string command = tokens[0];
                string name = tokens[1];

                if (command == "A")
                {
                    string phoneNumber = tokens[2];
                    phoneBook[name] = phoneNumber;
                }
                else if (command == "S")
                {
                    if (phoneBook.ContainsKey(name))
                    {
                        Console.WriteLine($"{name} -> {phoneBook[name]}");
                    }
                    else
                    {
                        Console.WriteLine($"Contact {name} does not exist.");
                    }
                }

                inputLine = Console.ReadLine();
            }

        }
    }
}
