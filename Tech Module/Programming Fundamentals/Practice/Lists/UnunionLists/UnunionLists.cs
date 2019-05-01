using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnunionLists
{
    class UnunionLists
    {
        static void Main(string[] args)
        {
            List<int> primalList = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                List<int> currentList = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
                List<int> numbersForRemoving = new List<int>();
                for (int j = 0; j < currentList.Count; j++)
                {
                    if (!primalList.Contains(currentList[j]))
                    {
                        primalList.Add(currentList[j]);
                    }
                    else
                    {
                        numbersForRemoving.Add(currentList[j]);
                    }
                }
                for (int k = 0; k < numbersForRemoving.Count; k++)
                {
                    while (primalList.Contains(numbersForRemoving[k]))
                    {
                        primalList.Remove(numbersForRemoving[k]);
                    }
                }
                
            }
            primalList.Sort();
            Console.WriteLine(string.Join(" ", primalList));

        }
    }
}
