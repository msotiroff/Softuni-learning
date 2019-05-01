using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariableInHexadecimalFormat
{
    class VariableInHexadecimalFormat
    {
        static void Main(string[] args)
        {
            string hexadecimalString = Console.ReadLine();
            int formated = Convert.ToInt32(hexadecimalString, 16);
            Console.WriteLine(formated);
        }
    }
}
