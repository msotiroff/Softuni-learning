using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerabytesToBits
{
    class TerabytesToBits
    {
        static void Main(string[] args)
        {
            double teraBytes = double.Parse(Console.ReadLine());
            double bits = teraBytes * 1024 * 1024 * 1024 * 1024 * 8;
            Console.WriteLine(bits);
        }
    }
}
