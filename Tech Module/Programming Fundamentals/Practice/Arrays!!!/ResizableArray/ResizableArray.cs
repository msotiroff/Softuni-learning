using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResizableArray
{
    class ResizableArray
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();

            string[] command = Console.ReadLine().Split(' ').ToArray();

            while (command[0] != "end")
            {                
                    if (command[0] == "push")
                    {
                        int currentNumber = int.Parse(command[1]);
                        numbers.Add(currentNumber);
                    }
                    else if (command[0] == "pop")
                    {
                        numbers.RemoveAt(numbers.Count - 1);
                    }
                    else if (command[0] == "removeAt")
                    {
                        int currentNumber = int.Parse(command[1]);
                        numbers.RemoveAt(currentNumber);
                    }
                    else if (command[0] == "clear")
                    {
                        numbers.Clear();
                    }
                command = Console.ReadLine().Split().ToArray();
            }

            bool isEmpty = true;

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] != 0)
                {
                    isEmpty = false;
                }
            }
            if (isEmpty == true)
            {
                Console.WriteLine("empty array");
            }
            else
            {
                foreach (var item in numbers)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
