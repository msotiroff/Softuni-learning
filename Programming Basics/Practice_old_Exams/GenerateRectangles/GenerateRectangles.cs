using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateRectangles
{
    class GenerateRectangles
    {
        static void Main(string[] args)
        {
            // 13. Генериране на правоъгълници

            // По дадено число n и минимална площ m да се генерират всички правоъгълници с цели координати в интервала[-n…n] с площ поне m. 
            // Генерираните правоъгълници да се отпечатат в следния формат:
            // (left, top) (right, bottom) -> area
            // Правоъгълниците се задават чрез горния си ляв и долния си десен ъгъл. В сила са следните неравенства:
            // -n ≤ left < right ≤ n
            // - n ≤ top < bottom ≤ n


            int n = int.Parse(Console.ReadLine());
            int minArea = int.Parse(Console.ReadLine());

            int positiveN = Math.Abs(n);
            int negativeN = positiveN * (-1);
            if ((2 * n) * (2 * n) < minArea)
            {
                Console.WriteLine("No");
                return;
            }
            for (int left = negativeN; left <= positiveN; left++)
            {
                for (int right = left + 1; right <= positiveN; right++)
                {
                    for (int top = negativeN; top <= positiveN; top++)
                    {
                        for (int bottom = top + 1; bottom <= positiveN; bottom++)
                        {
                            int currentSideA = Math.Abs(left - right);
                            int currentSideB = Math.Abs(top - bottom);
                            int currentRectangleArea = currentSideA * currentSideB;
                            if (currentRectangleArea >= minArea)
                            {
                                Console.WriteLine($"({left}, {top}) ({right}, {bottom}) -> {currentRectangleArea}");
                            }
                        }
                    }
                }
            }
            

        }
    }
}

