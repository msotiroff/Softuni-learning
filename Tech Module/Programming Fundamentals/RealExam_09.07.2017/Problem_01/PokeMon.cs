using System;

namespace Problem_01
{
    class PokeMon
    {
        static void Main(string[] args)
        {
            long pokePower = long.Parse(Console.ReadLine());
            long distance = long.Parse(Console.ReadLine());
            long exhaustionFactor = long.Parse(Console.ReadLine());

            long powerOriginalValue = pokePower;

            int targetCounter = 0;

            decimal neededPercent = 0;

            while (pokePower >= distance)
            {
                pokePower -= distance;
                targetCounter++;
                neededPercent = ((decimal)pokePower / powerOriginalValue) * 100;
                if (neededPercent == 50)
                {
                    if (exhaustionFactor != 0)
                    {
                        pokePower /= exhaustionFactor;
                    }
                }
            }

            Console.WriteLine(pokePower);
            Console.WriteLine(targetCounter);

        }
    }
}
