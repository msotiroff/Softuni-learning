namespace P04.GeneratingBitVectors
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            var vectorLength = int.Parse(Console.ReadLine());

            var vector = new int[vectorLength];

            GenerateVector(vector, 0);
        }

        private static void GenerateVector(int[] vector, int index)
        {
            if (index == vector.Length)
            {
                Console.WriteLine(string.Join(string.Empty, vector));
            }
            else
            {
                for (int bit = 0; bit <= 1; bit++)
                {
                    vector[index] = bit;
                    GenerateVector(vector, index + 1);
                }
            }
            
        }
    }
}
