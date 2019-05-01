using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCII_String
{
    class ASCII_String
    {
        static void Main(string[] args)
        {
            // Uploaded to GitHub

            int n = int.Parse(Console.ReadLine());
            string word = null;

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                char asc = Convert.ToChar(num);
                word += asc;
            }
            Console.WriteLine(word);
        }
    }
}
