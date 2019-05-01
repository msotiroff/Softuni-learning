using System;

namespace _8.Exchange_Variable_Values
{
    class ExchangeVariableValues
    {
        static void Main(string[] args)
        {
            int beforeA = 5;
            int beforeB = 10;
            int afterA = beforeB;
            int afterB = beforeA;

            Console.WriteLine("Before:");
            Console.WriteLine($"a = {beforeA}");
            Console.WriteLine($"b = {beforeB}");
            Console.WriteLine("After:");
            Console.WriteLine($"a = {afterA}");
            Console.WriteLine($"b = {afterB}");

        }
    }
}
