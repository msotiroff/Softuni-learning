using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixedPhones
{
    class MixedPhones
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, long> phoneBook = 
                new SortedDictionary<string, long>();

            string[] input = Console.ReadLine().Split(':').ToArray();

            while (input[0] != "Over")
            {
                string firstElement = input[0].Trim();
                string lastElement = input[input.Length - 1].Trim();

                long phoneNumber;
                if (long.TryParse(lastElement, out phoneNumber))
                {
                    phoneBook[firstElement] = phoneNumber;
                }
                else if (long.TryParse(firstElement, out phoneNumber))
                {
                    phoneBook[lastElement] = phoneNumber;
                }

                input = Console.ReadLine().Split(':').ToArray();
            }

            foreach (var kvp in phoneBook)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
