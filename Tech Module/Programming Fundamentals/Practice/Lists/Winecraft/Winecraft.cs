using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winecraft
{
    class Winecraft
    {
        static void Main(string[] args)
        {
            List<int> grapes = Console.ReadLine()
                        .Split(' ')
                        .Select(int.Parse)
                        .ToList();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < grapes.Count; i++)
            {
                if (i > 0 && i < grapes.Count - 1)
                {
                    if (GetLargerNumber(i - 1, i, i + 1))
                    {

                    }
                }
                
            }

        }

        static bool GetLargerNumber (int previous, int current, int next)
        {
            bool result = false;
            if (current > previous && current > next)
            {
                result = true;
            }

            return result;
        }
    }
}
