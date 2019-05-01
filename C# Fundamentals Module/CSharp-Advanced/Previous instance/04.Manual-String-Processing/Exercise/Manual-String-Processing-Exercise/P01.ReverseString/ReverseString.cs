namespace P01.ReverseString
{
    using System;
    using System.Text;

    public class ReverseString
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var result = new StringBuilder();

            for (int i = input.Length - 1; i >= 0; i--)
            {
                result.Append(input[i]);
            }

            Console.WriteLine(result);
        }
    }
}
