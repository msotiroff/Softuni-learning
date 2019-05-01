using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main(string[] args)
    {
        var list = new List<double>();

        var inputCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < inputCount; i++)
        {
            list.Add(double.Parse(Console.ReadLine()));
        }

        var element = double.Parse(Console.ReadLine());

        Console.WriteLine(Count(list, element));
    }

    public static int Count<T>(List<T> items, T element) 
        where T : IComparable<T>
    {
        var result = 0;

        foreach (var item in items)
        {
            if (element.CompareTo(item) < 0)
            {
                result++;
            }
        }

        return result;
    }
}
