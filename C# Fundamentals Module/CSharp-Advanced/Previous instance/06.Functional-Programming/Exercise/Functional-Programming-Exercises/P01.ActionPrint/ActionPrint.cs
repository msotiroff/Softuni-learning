namespace P01.ActionPrint
{
    using System;

    public class ActionPrint
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Action<string> action = a => Console.WriteLine(a);

            foreach (var item in input)
            {
                action(item);
            }
        }
    }
}