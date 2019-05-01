using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        var totalPrice = 0.0d;

        var capacity = double.Parse(Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Last());

        var itemsCount = int.Parse(Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Last());

        var items = new List<Item>();

        for (int i = 0; i < itemsCount; i++)
        {
            var itemParams = Console.ReadLine().Split(new char[] { ' ', '-', '>' }, StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
            items.Add(new Item(itemParams[0], itemParams[1]));
        }

        items = items
            .OrderByDescending(i => i.Price / i.Weight)
            .ToList();


        foreach (var item in items)
        {
            var coef = Math.Min(1.0, capacity / item.Weight);
            var percent = coef * 100;
            var percentAsString = percent == 100
                ? "100"
                : percent.ToString("f2");

            if (coef > 0 && capacity > 0)
            {
                Console.WriteLine($"Take {percentAsString}% of item with price {item.Price:f2} and weight {item.Weight:f2}");

                totalPrice += coef * item.Price;
                capacity -= coef * item.Weight;
            }
        }

        Console.WriteLine($"Total price: {totalPrice:f2}");
    }
}
