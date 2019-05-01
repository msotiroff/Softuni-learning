using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.Filter_Base
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> emloyeePosition = new Dictionary<string, string>();
            Dictionary<string, double> emloyeeSalary = new Dictionary<string, double>();
            Dictionary<string, int> emloyeeAge = new Dictionary<string, int>();


            char[] separators = { ' ', '-', '>' };
            string[] input = Console.ReadLine()
                .Split(separators, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            while (input[0] != "filter" && input[1] != "base")
            {
                string name = input[0];
                string data = input[1];

                int age;
                double salary;
                string position = data;

                if (int.TryParse(data, out age))
                {
                    emloyeeAge[name] = age;
                }
                else if (double.TryParse(data, out salary))
                {
                    emloyeeSalary[name] = salary;
                }
                else
                {
                    emloyeePosition[name] = position;
                }

                input = Console.ReadLine()
                .Split(separators, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            }

            string command = Console.ReadLine();

            if (command == "Position")
            {
                foreach (var kvp in emloyeePosition)
                {
                    Console.WriteLine($"Name: {kvp.Key}");
                    Console.WriteLine($"Position: {kvp.Value}");
                    Console.WriteLine(new string('=', 20));
                }
            }
            else if (command == "Age")
            {
                foreach (var kvp in emloyeeAge)
                {
                    Console.WriteLine($"Name: {kvp.Key}");
                    Console.WriteLine($"Age: {kvp.Value}");
                    Console.WriteLine(new string('=', 20));
                }
            }
            else if (command == "Salary")
            {
                foreach (var kvp in emloyeeSalary)
                {
                    Console.WriteLine($"Name: {kvp.Key}");
                    Console.WriteLine($"Salary: {kvp.Value:f2}");
                    Console.WriteLine(new string('=', 20));
                }
            }

        }
    }
}
