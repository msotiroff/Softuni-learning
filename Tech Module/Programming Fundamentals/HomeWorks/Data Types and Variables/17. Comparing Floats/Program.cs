using System;

namespace _17.Comparing_Floats
{
    class ComparingFloats
    {
        static void Main(string[] args)
        {
            double firstNumber = double.Parse(Console.ReadLine());
            double secondNumber = double.Parse(Console.ReadLine());
            double difference = Math.Abs(firstNumber - secondNumber);
            double eps = 0.000001;

            if (difference >= eps)
            {
                Console.WriteLine("False");
            }
            else
            {
                Console.WriteLine("True");
            }
        }
    }
}
