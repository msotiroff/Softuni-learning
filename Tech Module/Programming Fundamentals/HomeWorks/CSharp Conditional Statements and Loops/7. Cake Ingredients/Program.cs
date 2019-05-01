using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.Cake_Ingredients
{
    class CakeIngredients
    {
        static void Main(string[] args)
        {
            string ingredient = Console.ReadLine();
            int ingredientsCounter = 0;

            while (ingredient != "Bake!")
            {
                Console.WriteLine($"Adding ingredient {ingredient}.");
                ingredientsCounter++;

                ingredient = Console.ReadLine();
            }

            Console.WriteLine($"Preparing cake with {ingredientsCounter} ingredients.");

        }
    }
}
