namespace P09.ListOfPredicates
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var dividers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Distinct()
                .ToArray();

            Predicate<int>[] predicates = dividers.Select(d => (Predicate<int>)(num => num % d == 0)).ToArray();

            var numbers = new List<int>();

            for (int i = 1; i <= n; i++)
            {
                bool isDivisable = true;

                foreach (var predicate in predicates)
                {
                    if (!predicate(i))
                    {
                        isDivisable = false;
                        break;
                    }
                }

                if (isDivisable)
                {
                    numbers.Add(i);
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
