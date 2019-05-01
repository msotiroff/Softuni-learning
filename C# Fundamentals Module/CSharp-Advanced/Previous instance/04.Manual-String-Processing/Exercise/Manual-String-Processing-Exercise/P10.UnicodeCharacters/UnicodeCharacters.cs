namespace P10.UnicodeCharacters
{
    using System;
    using System.Linq;

    public class UnicodeCharacters
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine().ToCharArray();

            var result = input
                .Select(c => string.Format("\\u{0:x4}", Convert.ToUInt16(c)))
                .ToArray();

            Console.WriteLine(string.Join("", result));
        }
    }
}
