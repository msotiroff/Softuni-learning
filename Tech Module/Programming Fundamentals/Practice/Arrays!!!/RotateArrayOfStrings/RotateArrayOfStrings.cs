using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotateArrayOfStrings
{
    class RotateArrayOfStrings
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(' ').ToArray();

            string[] rotatedWords = new string[words.Length];
            rotatedWords[0] = words[words.Length - 1];

            for (int i = 0; i < words.Length - 1; i++)
            {
                rotatedWords[i + 1] = words[i];
            }

            for (int i = 0; i < rotatedWords.Length; i++)
            {
                Console.Write(rotatedWords[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
