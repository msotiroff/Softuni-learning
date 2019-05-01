using System;

namespace _5.Sentence_Split
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string inputText = Console.ReadLine();

            string delimiter = Console.ReadLine();

            string[] splittedText = inputText.Split(new string[] { delimiter }, StringSplitOptions.None);

            string innerText = string.Join(", ", splittedText);
            string result = "[" + innerText + "]";

            Console.WriteLine(result);
        }
    }
}
