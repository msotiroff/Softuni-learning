using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.Calories_Counter
{
    class CaloriesCounter
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int cheese = 0;
            int tomatoSauce = 0;
            int salami = 0;
            int pepper = 0;

            for (int i = 0; i < n; i++)
            {
                string currentIngredient = Console.ReadLine().ToLower();
                if (currentIngredient == "cheese")
                {
                    cheese++;
                }
                else if (currentIngredient == "tomato sauce")
                {
                    tomatoSauce++;
                }
                else if (currentIngredient == "salami")
                {
                    salami++;
                }
                else if (currentIngredient == "pepper")
                {
                    pepper++;
                }
            }

            int totalCals = cheese * 500 + tomatoSauce * 150 + pepper * 50 + salami * 600;

            Console.WriteLine($"Total calories: {totalCals}");
        }
    }
}
