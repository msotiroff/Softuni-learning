using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notifications
{
    class Notifications
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string result = Console.ReadLine().ToLower();
                if (result == "success")
                {
                    string operation = Console.ReadLine();
                    string message = Console.ReadLine();
                    string forPrint = ShowSuccess(operation, message);
                    Console.WriteLine(forPrint);
                }
                else if (result == "error")
                {
                    string operation = Console.ReadLine();
                    int code = int.Parse(Console.ReadLine());
                    string forPrint = ShowError(operation, code);
                    Console.WriteLine(forPrint);
                }
                else
                {
                    continue;
                }
                
            }
        }

        static string ShowSuccess(string operation, string message)
        {
            string success = "Successfully executed " + operation + ".\n" + 
                             "==============================\n" + 
                             "Message: " + message + ".";
            return success;
        }

        static string ShowError(string operation, int code)
        {
            string reason = string.Empty;
            if (code > 0)
            {
                reason = "Invalid Client Data";
            }
            else
            {
                reason = "Internal System Failure";
            }
            string error = "Error: Failed to execute " + operation + ".\n" +
                           "==============================\n" +
                           "Error Code: " + code + ".\n" +
                           "Reason: " + reason + ".";

            return error;
        }
    }
}
