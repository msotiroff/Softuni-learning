namespace P03.CountUppercaseWords
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var delimiters = new char[] { ' ' };

            Func<string, string[]> GetWords =
                s => s.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            
            Action<string[]> PrintPascalCaseWords =
                s => Console.WriteLine(
                        string.Join(
                            Environment.NewLine, 
                            s.Where(w => char.IsUpper(w[0]))));

            var words = GetWords(Console.ReadLine());

            PrintPascalCaseWords(words);
        }
    }
}
