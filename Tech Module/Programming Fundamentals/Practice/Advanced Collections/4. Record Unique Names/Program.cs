using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Record_Unique_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> uniqueNames = new HashSet<string>();

            int numberOfInputs = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfInputs; i++)
            {
                string input = Console.ReadLine();

                uniqueNames.Add(input);
            }

            foreach (var names in uniqueNames)
            {
                Console.WriteLine(names);
            }
        }
    }
}
