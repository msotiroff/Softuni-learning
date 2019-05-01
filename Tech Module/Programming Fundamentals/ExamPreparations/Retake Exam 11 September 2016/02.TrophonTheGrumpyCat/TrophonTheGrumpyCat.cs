using System;
using System.Linq;

namespace _02.TrophonTheGrumpyCat
{
    class TrophonTheGrumpyCat
    {
        static void Main(string[] args)
        {
            long[] items = Console.ReadLine()
                .Split(' ')
                .Select(long.Parse)
                .ToArray();

            int entryIndex = int.Parse(Console.ReadLine());
            string typeOfItemsToBreak = Console.ReadLine();         // cheap, expensive
            string typeOfPriceRate = Console.ReadLine();            // positive, negative, all

            long leftSum = 0;
            long rightSum = 0;


            if (typeOfItemsToBreak == "cheap")
            {
                if (typeOfPriceRate == "positive")
                {
                    leftSum = items.Take(entryIndex).Where(x => x < items[entryIndex]).Where(x => x > 0).Sum();
                    rightSum = items.Skip(entryIndex + 1).Where(x => x < items[entryIndex]).Where(x => x > 0).Sum();
                }
                else if (typeOfPriceRate == "negative")
                {
                    leftSum = items.Take(entryIndex).Where(x => x < items[entryIndex]).Where(x => x < 0).Sum();
                    rightSum = items.Skip(entryIndex + 1).Where(x => x < items[entryIndex]).Where(x => x < 0).Sum();
                }
                else if (typeOfPriceRate == "all")
                {
                    leftSum = items.Take(entryIndex).Where(x => x < items[entryIndex]).Sum();
                    rightSum = items.Skip(entryIndex + 1).Where(x => x < items[entryIndex]).Sum();
                }
            }
            else if (typeOfItemsToBreak == "expensive")
            {
                if (typeOfPriceRate == "positive")
                {
                    leftSum = items.Take(entryIndex).Where(x => x >= items[entryIndex]).Where(x => x > 0).Sum();
                    rightSum = items.Skip(entryIndex + 1).Where(x => x >= items[entryIndex]).Where(x => x > 0).Sum();
                }
                else if (typeOfPriceRate == "negative")
                {
                    leftSum = items.Take(entryIndex).Where(x => x >= items[entryIndex]).Where(x => x < 0).Sum();
                    rightSum = items.Skip(entryIndex + 1).Where(x => x >= items[entryIndex]).Where(x => x < 0).Sum();

                }
                else if (typeOfPriceRate == "all")
                {

                    leftSum = items.Take(entryIndex).Where(x => x >= items[entryIndex]).Sum();

                    rightSum = items.Skip(entryIndex + 1).Where(x => x >= items[entryIndex]).Sum();

                }
            }

            if (leftSum >= rightSum)
            {
                Console.WriteLine($"Left - {leftSum}");
            }
            else
            {
                Console.WriteLine($"Right - {rightSum}");
            }

        }
    }
}
