using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook
{
    class Phonebook
    {
        static void Main(string[] args)
        {
            string[] phoneNumbers = Console.ReadLine().Split().ToArray();

            string[] names = Console.ReadLine().Split().ToArray();

            string commands = string.Empty;
            while (commands != "done")
            {
                commands = Console.ReadLine();
                for (int i = 0; i < names.Length; i++)
                {
                    if (commands == names[i])
                    {
                        Console.WriteLine($"{names[i]} -> {phoneNumbers[i]}");
                    }
                }
            }
            

        }
    }
}
