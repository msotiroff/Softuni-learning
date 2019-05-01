using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrickyStrings
{
    class TrickyStrings
    {
        static void Main(string[] args)
        {
            string delimiter = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());
            string result = null;

            for (int i = 1; i <= n; i++)
            {
                string word = Console.ReadLine();
                result += word;
                if (i != n)
                {
                    result += delimiter;
                }
            }
            Console.WriteLine(result);
        }
    }
}
