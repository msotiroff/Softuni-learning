using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringRepeater
{
    class StringRepeater
    {
        static void Main()
        {
            string word = Console.ReadLine();
            int count = int.Parse(Console.ReadLine());

            string repeatedStr = RepeatedString(word, count);
            Console.WriteLine(repeatedStr);
        }

        static string RepeatedString(string word, int count)
        {
          
            string result = string.Empty;
            for (int i = 0; i < count; i++)
            {
                result += word;
            }
            return result;
        }
    }
}
