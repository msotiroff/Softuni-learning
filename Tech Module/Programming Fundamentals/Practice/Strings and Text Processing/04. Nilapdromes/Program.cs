using System;

namespace _4.Nilapdromes
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputLine = Console.ReadLine();

            while (inputLine != "end")
            {
                string currentBorder = string.Empty;
                string currentCore = string.Empty;

                string tempBorder = string.Empty;
                for (int i = 0; i < inputLine.Length / 2; i++)
                {
                    tempBorder += inputLine[i];
                    bool symetrical = inputLine.EndsWith(tempBorder);
                    if (symetrical)
                    {
                        currentBorder = tempBorder;
                    }
                }
                if (currentBorder.Length > 0)
                {
                    int coreZeroIndex = currentBorder.Length;
                    int coreLenght = inputLine.Length - 2 * currentBorder.Length;
                    if (coreLenght > 0)
                    {
                        currentCore = inputLine.Substring(coreZeroIndex, coreLenght).ToString();
                        Console.WriteLine($"{currentCore}{currentBorder}{currentCore}");
                    }
                    else
                    {
                        inputLine = Console.ReadLine();
                        continue;
                    }
                }

                inputLine = Console.ReadLine();
            }


        }
    }
}
