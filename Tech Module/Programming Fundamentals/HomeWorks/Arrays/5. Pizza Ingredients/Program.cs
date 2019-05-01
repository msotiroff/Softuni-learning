using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.Pizza_Ingredients
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] ingredients = Console.ReadLine().Split(' ').ToArray();

            int searchedLength = int.Parse(Console.ReadLine());
            int countOfIngredients = 0;

            List<string> usedIngredients = new List<string>();

            for (int i = 0; i < ingredients.Length; i++)
            {
                int currentIngredientLenght = ingredients[i].Length;

                if (currentIngredientLenght == searchedLength)
                {
                    Console.WriteLine($"Adding {ingredients[i]}.");
                    countOfIngredients++;
                    usedIngredients.Add(ingredients[i]);
                    if (usedIngredients.Count == 10)
                    {
                        break;
                    }
                }
            }


            Console.WriteLine($"Made pizza with total of {countOfIngredients} ingredients.");
            Console.WriteLine($"The ingredients are: {string.Join(", ", usedIngredients)}.");
        }
    }
}
