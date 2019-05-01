using System;
using System.Collections.Generic;
using System.Linq;

namespace _4.Fix_Emails
{
    class FixEmails
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> emailDatabase = new Dictionary<string, string>();

            string inputline = Console.ReadLine();
            int counter = 0;
            string currentName = string.Empty;
            string currentMail = string.Empty;

            while (inputline != "stop")
            {
                counter++;
                if (counter % 2 != 0)
                {
                    currentName = inputline;
                }
                else
                {
                    currentMail = inputline;
                    string[] check = currentMail.Split('.').ToArray();
                    if (check[check.Length - 1] != "us" && check[check.Length - 1] != "uk")
                    {
                        emailDatabase[currentName] = currentMail;
                    }
                    else
                    {
                        emailDatabase.Remove(currentName);
                    }
                }
                inputline = Console.ReadLine();
            }

            foreach (var namesEmailsPair in emailDatabase)
            {
                Console.WriteLine($"{namesEmailsPair.Key} -> {namesEmailsPair.Value}");
            }

        }
    }
}
