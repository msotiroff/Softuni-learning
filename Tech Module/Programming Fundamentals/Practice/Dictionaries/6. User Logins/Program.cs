using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.User_Logins
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> userList = new Dictionary<string, string>();

            char[] separators = { ' ', '-', '>' };
            string[] input = Console.ReadLine()
                .Split(separators, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            while (input[0] != "login")
            {
                string username = input[0];
                string password = input[1];
                
                userList[username] = password;

                input = Console.ReadLine()
                .Split(separators, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            }

            input = Console.ReadLine()
                .Split(separators, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            int loginFailedCounter = 0;

            while (input[0] != "end")
            {
                string user = input[0];
                string pass = input[1];

                if (userList.ContainsKey(user))
                {
                    if (userList[user] == pass)
                    {
                        Console.WriteLine($"{user}: logged in successfully");
                    }
                    else
                    {
                        Console.WriteLine($"{user}: login failed");
                        loginFailedCounter++;
                    }
                }
                else
                {
                    Console.WriteLine($"{user}: login failed");
                    loginFailedCounter++;
                }

                input = Console.ReadLine()
                .Split(separators, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            }

            Console.WriteLine($"unsuccessful login attempts: {loginFailedCounter}");
        }
    }
}
