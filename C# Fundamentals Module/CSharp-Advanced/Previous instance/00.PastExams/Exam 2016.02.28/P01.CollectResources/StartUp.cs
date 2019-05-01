namespace P01.CollectResources
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            // Valid resourses: stone, gold, wood and food
            var validResourses = new string[] { "stone", "gold", "wood", "food" };
            var maxAmount = int.MinValue;

            var resourses = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var collectedResoursesIndexes = new HashSet<int>();

            var collectionPaths = int.Parse(Console.ReadLine());

            for (int i = 0; i < collectionPaths; i++)
            {
                var currentAmount = 0;

                var currentPath = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var currentIndex = currentPath[0];
                var step = currentPath[1];

                while (!collectedResoursesIndexes.Contains(currentIndex))
                {
                    var currentResourseParams = resourses[currentIndex].Split('_');
                    var resourseName = currentResourseParams.First();
                    var resourseAmount = currentResourseParams.Length > 1 
                        ? int.Parse(currentResourseParams.Last()) 
                        : 1;

                    if (validResourses.Contains(resourseName))
                    {
                        currentAmount += resourseAmount;
                        collectedResoursesIndexes.Add(currentIndex);
                    }

                    currentIndex += step;
                    currentIndex %= resourses.Length;
                }

                if (currentAmount > maxAmount)
                {
                    maxAmount = currentAmount;
                }

                collectedResoursesIndexes.Clear();
            }

            Console.WriteLine(maxAmount);
        }
    }
}
