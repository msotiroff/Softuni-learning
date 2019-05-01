namespace P02.KnightsOfHonor
{
    using System;

    class StartUp
    {
        static void Main(string[] args)
        {
            Func<string, string[]> split =
                s => s.Split();

            var names = split(Console.ReadLine());

            Action<string> printKnights = a => Console.WriteLine($"Sir {a}");

            foreach (var name in names)
            {
                printKnights(name);
            }
        }
    }
}
