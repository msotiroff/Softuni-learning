using System;

namespace _15.Integer_to_Hex_and_Binary
{
    class IntegerHexBinary
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            string hexadecimal = Convert.ToString(number, 16).ToUpper();
            string binary = Convert.ToString(number, 2);
            
            Console.WriteLine(hexadecimal);
            Console.WriteLine(binary);
        }
    }
}
