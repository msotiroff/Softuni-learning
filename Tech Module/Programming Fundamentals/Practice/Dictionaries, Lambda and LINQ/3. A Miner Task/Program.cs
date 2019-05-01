using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.A_Miner_Task
{
    class AMinerTask
    {
        static void Main(string[] args)

        {
            Dictionary<string, int> minerTask = new Dictionary<string, int>();

            string inputLine = Console.ReadLine();
            string currentResource = string.Empty;
            

            while (inputLine != "stop")
            {
                int currentQuantity = 0;
                if (int.TryParse(inputLine, out currentQuantity))
                {
                    minerTask[currentResource] += currentQuantity;
                }
                else
                {
                    currentResource = inputLine;
                    if (! minerTask.ContainsKey(currentResource))
                    {
                        minerTask.Add(currentResource, 0);
                    }
                }
                inputLine = Console.ReadLine();
            }

            foreach (var resource in minerTask)
            {
                Console.WriteLine($"{resource.Key} -> {resource.Value}");
            }
        }
    }
}
