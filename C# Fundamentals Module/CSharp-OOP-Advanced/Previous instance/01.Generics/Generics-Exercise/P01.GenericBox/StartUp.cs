using System;

public class StartUp
{
    public static void Main()
    {
        var inputCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < inputCount; i++)
        {
            var input = Console.ReadLine();

            var box = new Box<int>(int.Parse(input));

            Console.WriteLine(box);
        }
    }
}