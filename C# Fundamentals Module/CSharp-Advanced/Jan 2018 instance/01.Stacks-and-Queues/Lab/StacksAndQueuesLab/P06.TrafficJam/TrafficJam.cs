namespace P06.TrafficJam
{
    using System;
    using System.Collections.Generic;

    class TrafficJam
    {
        static void Main(string[] args)
        {
            var passableCarsCount = int.Parse(Console.ReadLine());

            var allCars = new Queue<string>();
            var carsPassed = 0;

            string inputLine;
            while ((inputLine = Console.ReadLine()) != "end")
            {
                if (inputLine == "green")
                {
                    int countOfCarsPassed = Math.Min(passableCarsCount, allCars.Count);

                    for (int i = 0; i < countOfCarsPassed; i++)
                    {
                        Console.WriteLine($"{allCars.Dequeue()} passed!");
                        carsPassed++;
                    }
                }
                else
                {
                    allCars.Enqueue(inputLine);
                }
            }

            Console.WriteLine($"{carsPassed} cars passed the crossroads.");
        }
    }
}
