namespace P05.Phonebook
{
    using System;
    using System.Collections.Generic;

    public class Phonebook
    {
        public static void Main(string[] args)
        {
            var phoneBook = new Dictionary<string, string>();

            var inputLine = Console.ReadLine();

            while (inputLine != "search")
            {
                var inputArgs = inputLine.Split('-');
                var currentName = inputArgs[0];
                var number = inputArgs[1];

                phoneBook[currentName] = number;

                inputLine = Console.ReadLine();
            }

            var name = Console.ReadLine();

            while (name != "stop")
            {
                if (phoneBook.ContainsKey(name))
                {
                    Console.WriteLine($"{name} -> {phoneBook[name]}");
                }
                else
                {
                    Console.WriteLine($"Contact {name} does not exist.");
                }

                name = Console.ReadLine();
            }
        }
    }
}
