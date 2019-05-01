using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main(string[] args)
    {
        var list = new List<int>();

        var inputCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < inputCount; i++)
        {
            list.Add(int.Parse(Console.ReadLine()));
        }

        var elementsToSwap = Console.ReadLine().Split().Select(int.Parse).ToArray();

        list.SwapElements(elementsToSwap[0], elementsToSwap[1]);

        list.ForEach(e => Console.WriteLine($"{e.GetType().FullName}: {e}"));
    }
}