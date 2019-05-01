using System;

public class StartUp
{
    public static void Main(string[] args)
    {
        var inputCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < inputCount; i++)
        {
            var box = new Box<int>(int.Parse(Console.ReadLine()));
            Console.WriteLine(box);
        }
    }
}