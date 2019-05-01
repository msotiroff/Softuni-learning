namespace P15.MelrahShake
{
    using System;

    public class MelrahShake
    {
        public static void Main(string[] args)
        {
            var inputLine = Console.ReadLine();

            var pattern = Console.ReadLine();

            while (pattern.Length > 0)
            {
                var leftBorderMatch = inputLine.IndexOf(pattern);
                var rightBorderMatch = inputLine.LastIndexOf(pattern);

                if (leftBorderMatch != -1 && rightBorderMatch != -1)
                {
                    inputLine = inputLine.Remove(rightBorderMatch, pattern.Length);
                    inputLine = inputLine.Remove(leftBorderMatch, pattern.Length);
                    
                    Console.WriteLine("Shaked it.");

                    int index = pattern.Length / 2;
                    pattern = pattern.Remove(index, 1);
                }
                else
                {
                    Console.WriteLine("No shake.");
                    break;
                }
            }


            if (pattern.Length == 0)
            {
                Console.WriteLine("No shake.");
            }

            Console.WriteLine(inputLine);
        }
    }
}
