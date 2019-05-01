namespace P06.CountSubstringOccurrences
{
    using System;

    public class CountSubstringOccurrences
    {
        public static void Main(string[] args)
        {
            var text = Console.ReadLine().ToLower();
            var searchedWord = Console.ReadLine().ToLower();

            int count = 0;

            while (text.Contains(searchedWord))
            {
                var index = text.IndexOf(searchedWord);
                if (index != -1)
                {
                    count++;
                    text = text.Substring(index + 1);
                }
            }

            Console.WriteLine(count);
        }
    }
}
