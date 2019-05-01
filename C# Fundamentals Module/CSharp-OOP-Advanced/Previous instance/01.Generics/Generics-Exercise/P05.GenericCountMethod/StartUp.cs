using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main(string[] args)
    {
        var inputCount = int.Parse(Console.ReadLine());

        var listOfElements = new List<double>();
        
        for (int i = 0; i < inputCount; i++)
        {
            listOfElements.Add(double.Parse(Console.ReadLine()));
        }

        var boxOfElements = new Box<double>(listOfElements);

        Console.WriteLine(boxOfElements
                .CountOfGreaterElements(double.Parse(Console.ReadLine())));
    }
}