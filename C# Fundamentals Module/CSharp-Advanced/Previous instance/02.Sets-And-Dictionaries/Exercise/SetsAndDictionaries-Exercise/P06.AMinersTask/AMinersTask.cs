namespace P06.AMinersTask
{
    using System;
    using System.Collections.Generic;

    public class AMinersTask
    {
        public static void Main(string[] args)
        {
            var minerResourses = new Dictionary<string, long>();

            var resourse = Console.ReadLine();

            while (resourse != "stop")
            {
                long amount = long.Parse(Console.ReadLine());

                if (!minerResourses.ContainsKey(resourse))
                {
                    minerResourses[resourse] = 0;
                }

                minerResourses[resourse] += amount;

                resourse = Console.ReadLine();
            }

            foreach (var currResourse in minerResourses)
            {
                Console.WriteLine($"{currResourse.Key} -> {currResourse.Value}");
            }
        }
    }
}
