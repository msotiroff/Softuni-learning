namespace PizzaCalories
{
    using Models;
    using System;
    using static DataConstants.Constants;
    using PizzaCalories.DataConstants;

    class StartUp
    {
        static void Main()
        {
            string input = Console.ReadLine();
            while (!input.Equals("END"))
            {
                string[] args = input.Split();

                if (args[0].Equals("Dough"))
                {
                    try
                    {
                        Dough dough = new Dough(args[1], args[2], int.Parse(args[3]));
                        Console.WriteLine($"{dough.CalculateCalories():F2}");
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
                        Console.WriteLine($"{topping.CalculateCalories():F2}");
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
                        Pizza pizza = new Pizza(args[1]);
                        var numberOfTopics = int.Parse(args[2]);
                        if (numberOfTopics > PizzaToppingsMaxCount)
                        {
                            Console.WriteLine(string.Format(Messages.InvalidToppingsCount, PizzaToppingsMaxCount));
                            Environment.Exit(1);
                        }
                        input = Console.ReadLine();
                        args = input.Split();
                        Dough dough = new Dough(args[1], args[2], int.Parse(args[3]));
                        pizza.Dough = dough;

                        for (int i = 0; i < numberOfTopics; i++)
                        {
                            args = Console.ReadLine().Split();
                            var currTopping = new Topping(args[1], int.Parse(args[2]));
                            pizza.AddTopping(currTopping);
                        }

                        Console.WriteLine($"{pizza.Name} - {pizza.CalculateCalories():F2} Calories.");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Environment.Exit(1);
                    }
                }

                input = Console.ReadLine();
            }
        }
    }
}
