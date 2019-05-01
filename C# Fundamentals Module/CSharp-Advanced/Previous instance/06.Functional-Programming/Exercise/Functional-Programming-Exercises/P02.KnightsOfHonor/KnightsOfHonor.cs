namespace P02.KnightsOfHonor
{
    using System;

    public class KnightsOfHonor
    {
        public static void Main(string[] args)
        {
            var names = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Action<string> action = a => Console.WriteLine($"Sir {a}");

            foreach (var name in names)
            {
                action(name);
            }
        }
    }
}
