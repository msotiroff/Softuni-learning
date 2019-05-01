using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        var inputLine = Console.ReadLine().Split();

        var allTrafficLights = new List<TrafficLight>();

        foreach (var light in inputLine)
        {
            allTrafficLights.Add(new TrafficLight(light));
        }

        var timesToChangeLight = int.Parse(Console.ReadLine());

        for (int i = 0; i < timesToChangeLight; i++)
        {
            allTrafficLights.ForEach(tl => tl.ChangeSignal());
            Console.WriteLine(string.Join(" ", allTrafficLights));
        }
    }
}
