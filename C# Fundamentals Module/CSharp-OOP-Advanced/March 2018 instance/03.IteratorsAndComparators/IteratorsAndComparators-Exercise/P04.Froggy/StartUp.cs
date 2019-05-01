using System;
using System.Linq;

public class StartUp
{
    public static void Main(string[] args)
    {
        var stones = Console.ReadLine()
            .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        var lake = new Lake<int>(stones);

        Console.WriteLine(string.Join(", ", lake));
    }
}