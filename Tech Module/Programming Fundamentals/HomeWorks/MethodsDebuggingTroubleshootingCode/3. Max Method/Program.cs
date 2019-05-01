using System;

namespace _3.Max_Method
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            int bigger = GetMax(num1, num2);
            int biggest = GetMax(bigger, num3);

            Console.WriteLine(biggest);
        }
        public static int GetMax(int a, int b)
        {
            if (a > b)
            {
                return a;
            }
            else
            {
                return b;
            }
        }
    }
}
