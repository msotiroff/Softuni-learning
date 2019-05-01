using System;
using System.Linq;
using System.Reflection;

public class StartUp
{
    static void Main(string[] args)
    {
        Type boxType = typeof(Box);
        FieldInfo[] fields = boxType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
        Console.WriteLine(fields.Count());


        var currentBox = new Box(double.Parse(Console.ReadLine()),
                                    double.Parse(Console.ReadLine()),
                                    double.Parse(Console.ReadLine()));

        Console.WriteLine($"Surface Area - {currentBox.GetSurface():f2}");
        Console.WriteLine($"Lateral Surface Area - {currentBox.GetLateralSurfaceArea():f2}");
        Console.WriteLine($"Volume - {currentBox.GetVolume():f2}");
    }
}

