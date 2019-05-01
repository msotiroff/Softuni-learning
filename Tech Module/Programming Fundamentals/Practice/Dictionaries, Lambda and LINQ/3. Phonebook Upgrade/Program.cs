using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.PhonebookUpgrade
{
    class PhonebookUpgrade
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, string> phoneBookUpgraded =
                new SortedDictionary<string, string>();

            string inputLine = Console.ReadLine();

            while (inputLine != "END")
            {
                string[] tokens = inputLine.Split(' ').ToArray();
                string command = tokens[0];
                string name = string.Empty;
                if (tokens.Length > 1)
                {
                    name = tokens[1];
                }

                if (command == "A")
                {
                    string phoneNumber = tokens[2];
                    phoneBookUpgraded[name] = phoneNumber;
                }
                else if (command == "S")
                {
                    if (phoneBookUpgraded.ContainsKey(name))
                    {
                        Console.WriteLine($"{name} -> {phoneBookUpgraded[name]}");
                    }
                    else
                    {
                        Console.WriteLine($"Contact {name} does not exist.");
                    }
                }
                else if (command == "ListAll")
                {
                    foreach (var item in phoneBookUpgraded)
                    {
                        Console.WriteLine($"{item.Key} -> {item.Value}");
                    }
                }

                inputLine = Console.ReadLine();
            }

        }
    }
}
