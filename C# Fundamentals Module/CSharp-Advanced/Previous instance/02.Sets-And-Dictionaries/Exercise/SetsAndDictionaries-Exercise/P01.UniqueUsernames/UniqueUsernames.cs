namespace P01.UniqueUsernames
{
    using System;
    using System.Collections.Generic;

    public class UniqueUsernames
    {
        public static void Main(string[] args)
        {
            var names = new HashSet<string>();

            var linesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < linesCount; i++)
            {
                var currentName = Console.ReadLine();

                names.Add(currentName);
            }

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
