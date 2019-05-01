using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloName_
{
    class HelloName
    {
        static void Main(string[] args)
        {
            PrintHelloName();
        }

        static void PrintHelloName()
        {
            string name = Console.ReadLine();
            string result = "Hello, " + name + "!";
            Console.WriteLine(result);
        }
    }
}
