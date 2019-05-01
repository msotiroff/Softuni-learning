namespace P01.ArrangeNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            var allNumbers = new List<string>();

            var digitsAsWords = new string[]
            {
                "zero",
                "one",
                "two",
                "three",
                "four",
                "five",
                "six",
                "seven",
                "eight",
                "nine"
            };

            var numbers = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

            Console.WriteLine(
                string.Join(", ", numbers
                    .OrderBy(s => string.Join(string.Empty, s.
                        Select(c => digitsAsWords[int.Parse(c.ToString())])))));
        }
    }
}
