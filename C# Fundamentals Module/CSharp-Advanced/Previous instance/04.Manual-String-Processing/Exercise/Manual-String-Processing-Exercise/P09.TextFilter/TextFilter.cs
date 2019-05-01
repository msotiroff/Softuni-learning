namespace P09.TextFilter
{
    using System;

    public class TextFilter
    {
        public static void Main(string[] args)
        {
            var banWords = Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

            var text = Console.ReadLine();

            foreach (var banWord in banWords)
            {
                text = text.Replace(banWord, new string('*', banWord.Length));
            }

            Console.WriteLine(text);
        }
    }
}