using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecialNumbers
{
    class SpecialNumbers
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
           
            
            for (int i = 1; i <= n; i++)
            {
                int copyOfI = i;
                int sum = 0;
                int num = 1;
                while (copyOfI > 0)
                {
                    num = copyOfI % 10;
                    sum += num;
                    copyOfI /= 10;
                }

                bool isSpecial = false;
                if (sum == 5 || sum == 7 || sum == 11)
                {
                    isSpecial = true;
                }
                Console.WriteLine("{0} -> {1}", i, isSpecial);
            }
        }
    }
}
