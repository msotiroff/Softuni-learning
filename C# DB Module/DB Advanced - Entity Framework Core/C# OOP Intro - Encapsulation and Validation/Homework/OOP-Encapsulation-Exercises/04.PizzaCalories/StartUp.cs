using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class StartUp
{
    static void Main(string[] args)
    {
        string inputLine;
        Pizza currPizza = null;

        while ((inputLine = Console.ReadLine()) != "END")
        {
            string[] inputParams = inputLine.Split().ToArray();

            string command = inputParams[0];
            
            if (command == "Pizza")
            {
                try
                {
                    currPizza = new Pizza(inputParams[1]);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }
            else if (command == "Dough")
            {
                try
                {
                    Dough currDough = new Dough(inputParams[1], inputParams[2], int.Parse(inputParams[3]));
                    currPizza.Dough = currDough;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }
            else if (command == "Topping")
            {
                try
                {
                    Topping currTopping = new Topping(inputParams[1], int.Parse(inputParams[2]));
                    currPizza.AddTopping(currTopping);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }
        }

        Console.WriteLine($"{currPizza.Name} - {currPizza.CalculateCalories():f2} Calories.");
    }
}
