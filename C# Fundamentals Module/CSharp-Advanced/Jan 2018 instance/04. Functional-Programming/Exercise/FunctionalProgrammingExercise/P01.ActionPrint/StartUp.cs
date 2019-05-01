namespace P01.ActionPrint
{
    using System;

    class StartUp
    {
        static void Main(string[] args)
        {
            Action<string> PrintSequenceOnNewLines =
                s => Console.WriteLine(s.Replace(" ", Environment.NewLine));

            PrintSequenceOnNewLines(Console.ReadLine());
        }
    }
}
