using System;

public class StartUp
{
    public static void Main(string[] args)
    {
        var driverName = Console.ReadLine();

        IDriver driver = new Driver(driverName);

        ICar ferrari = new Ferrari(driver);

        Console.WriteLine(ferrari);
    }
}