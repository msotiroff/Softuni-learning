using System;

public class StartUp
{
    public static void Main(string[] args)
    {
        var phone = new SmartPhone();

        var numbers = Console.ReadLine().Split();
        var websites = Console.ReadLine().Split();

        foreach (var number in numbers)
        {
            Console.WriteLine(phone.Call(number));
        }

        foreach (var website in websites)
        {
            Console.WriteLine(phone.Browse(website));
        }
    }
}