using System;

namespace _18.Print_Part_of_ASCII
{
    class PrintPartOfASCII
    {
        static void Main(string[] args)
        {
            int startIndex = int.Parse(Console.ReadLine());
            int finishIndex = int.Parse(Console.ReadLine());

            for (int i = startIndex; i <= finishIndex; i++)
            {
                char currentSymbol = Convert.ToChar(i);
                Console.Write(currentSymbol + " ");
            }

            Console.WriteLine();
        }
    }
}