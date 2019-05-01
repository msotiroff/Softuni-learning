using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Average_Student_Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> studentGradeBase = new Dictionary<string, List<double>>();

            int numberOfInputs = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfInputs; i++)
            {
                string[] input = Console.ReadLine()
                .Split(' ')
                .ToArray();

                string name = input[0];
                double currentGrade = double.Parse(input[1]);

                if (!studentGradeBase.ContainsKey(name))
                {
                    studentGradeBase[name] = new List<double>();
                }
                studentGradeBase[name].Add(currentGrade);
            }

            PrintResult(studentGradeBase);
        }

        public static void PrintResult(Dictionary<string, List<double>> studentGradeBase)
        {
            foreach (var kvp in studentGradeBase)
            {
                string name = kvp.Key;
                double average = kvp.Value.Average();

                Console.Write("{0} -> ", name);
                foreach (var grades in kvp.Value)
                {
                    Console.Write("{0:f2} ", grades);
                }
                Console.WriteLine($"(avg: {average:f2})");
            }
        }
    }
}
