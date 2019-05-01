using System;
using System.Linq;
using System.Reflection;

public class StartUp
{
    public static void Main(string[] args)
    {
        Type boxType = typeof(Box);
        FieldInfo[] fields = boxType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
        Console.WriteLine(fields.Count());

        var length = double.Parse(Console.ReadLine());
        var width = double.Parse(Console.ReadLine());
        var height = double.Parse(Console.ReadLine());

        var box = new Box(length, width, height);

        Console.WriteLine($"Surface Area - {box.GetSurface():f2}");
        Console.WriteLine($"Lateral Surface Area - {box.GetLiteralSurface():f2}");
        Console.WriteLine($"Volume - {box.GetVolume():f2}");
    }
}
