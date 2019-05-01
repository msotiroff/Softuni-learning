using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraySymmetry
{
    class ArraySymmetry
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                .Split(' ')
                .ToArray();

            string result = "Yes";

            for (int i = 0; i < words.Length / 2; i++)
            {
                if (words[i] != words[words.Length - i - 1])
                {
                    result = "No";
                }
            }

            Console.WriteLine(result);
        }
    }
}

