using System;
using System.Linq;

namespace _2.Placeholders
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (input != "end")
            {
               string[] inputParameters = input
                .Split(new[] { '-', '>' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

                string text = inputParameters[0].TrimEnd();

                string[] variables = inputParameters[1]
                    .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                for (int i = 0; i < variables.Length; i++)
                {
                    string currentPlaceHolder = "{" + i.ToString() + "}";
                    text = text.Replace(currentPlaceHolder, variables[i]).ToString();
                }

                Console.WriteLine(text);

                input = Console.ReadLine();
            }

            
        }
    }
}
