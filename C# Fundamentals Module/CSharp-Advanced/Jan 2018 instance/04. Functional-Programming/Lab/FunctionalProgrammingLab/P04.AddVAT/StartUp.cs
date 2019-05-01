namespace P04.AddVAT
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            Action<List<double>> printWithVat =
                n => n.ForEach(x => 
                    Console.WriteLine(string.Join(Environment.NewLine, $"{x:f2}")));

            var numbers = Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Select(n => n * 1.2)
                .ToList();

            printWithVat(numbers);
        }
    }
}
