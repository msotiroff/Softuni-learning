using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main(string[] args)
    {
        var items = new List<Box<int>>();

        var inputCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < inputCount; i++)
        {
            items.Add(new Box<int>(int.Parse(Console.ReadLine())));
        }

        var indexes = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        items = Swap(items, indexes[0], indexes[1]);

        items
            .ForEach(b => Console.WriteLine(b));
    }

    private static List<T> Swap<T> (List<T> collection, int first, int second)
    {
        var firstElement = collection[first];
        collection[first] = collection[second];
        collection[second] = firstElement;

        return collection;
    }
}
