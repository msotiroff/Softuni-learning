using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppendLists
{
    class AppendLists
    {
        static void Main(string[] args)
        {
            List<string> lists = Console.ReadLine().Split('|').ToList();

            List<string> preResult = new List<string>();


            for (int i = 0; i < lists.Count; i++)
            {
                string currentStringOfNums = lists[i];
                List<string> currentListOfNums = currentStringOfNums.Split().ToList();
                string forAddingInResult = string.Empty;
                foreach (var item in currentListOfNums)
                {
                    forAddingInResult += item + " ";
                }
                preResult.Add(forAddingInResult);
            }

            preResult.Reverse();

            List<string> result = new List<string>();

            foreach (var item in preResult)
            {
                List<string> nums = item.Split(' ').ToList();
                foreach (var num in nums)
                {
                    if (num != "")
                    {
                        result.Add(num);
                    }
                }
            }

            Console.WriteLine(string.Join(" ", result));

        }
    }
}
