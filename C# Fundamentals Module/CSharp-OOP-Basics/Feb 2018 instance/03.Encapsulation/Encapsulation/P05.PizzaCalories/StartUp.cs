namespace P05.PizzaCalories
{
    using DataConstants;
    using Models;
    using System;

    public class StartUp
    {
        public static void Main()
        {
            Pizza pizza = null;

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] args = input.Split();

                if (args[0].Equals("Dough"))
                {
                    try
                    {
                        Dough dough = new Dough(args[1], args[2], int.Parse(args[3]));
                        pizza.Dough = dough;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Environment.Exit(1);
                    }
                }
                else if (args[0].Equals("Topping"))
                {
                    try
                    {
                        Topping topping = new Topping(args[1], int.Parse(args[2]));
                        pizza.AddTopping(topping);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Environment.Exit(1);
                    }
                }
                else if (args[0].Equals("Pizza"))
                {
                    try
                    {
                        pizza = new Pizza(args[1]);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Environment.Exit(1);
                    }
                }
            }

            Console.WriteLine($"{pizza.Name} - {pizza.CalculateCalories():f2} Calories.");
        }
    }
}
