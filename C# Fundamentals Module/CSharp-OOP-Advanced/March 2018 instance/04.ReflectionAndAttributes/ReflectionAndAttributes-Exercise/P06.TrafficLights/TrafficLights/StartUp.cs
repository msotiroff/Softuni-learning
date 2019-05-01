namespace TrafficLights
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TrafficLights.Models;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var inputLights = Console.ReadLine().Split().ToList();

            var trafficLights = new List<TrafficLight>();

            inputLights
                .ForEach(x => trafficLights.Add(new TrafficLight(x)));

            var lightsChangesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < lightsChangesCount; i++)
            {
                trafficLights
                    .ForEach(tl => tl.ChangeSignal());

                Console.WriteLine(string.Join(" ", trafficLights));
            }
        }
    }
}
