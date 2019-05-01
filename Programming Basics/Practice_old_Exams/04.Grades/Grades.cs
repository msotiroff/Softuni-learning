using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Grades
{
    class Grades
    {
        static void Main(string[] args)
        {
            int students = int.Parse(Console.ReadLine());

            double excellent = 0;
            double good = 0;
            double middle = 0;
            double failed = 0;
            double allGrades = 0;

            for (int i = 0; i < students; i++)
            {
                double grade = double.Parse(Console.ReadLine());

                if (grade < 3)
                {
                    failed++;
                }
                else if (grade < 4)
                {
                    middle++;
                }
                else if (grade < 5)
                {
                    good++;
                }
                else if (grade >= 5)
                {
                    excellent++;
                }
                allGrades += grade;
            }

            Console.WriteLine("Top students: {0:f2}%", 1.0 * excellent / students * 100);
            Console.WriteLine("Between 4.00 and 4.99: {0:f2}%", 1.0 * good / students * 100);
            Console.WriteLine("Between 3.00 and 3.99: {0:f2}%", 1.0 * middle / students * 100);
            Console.WriteLine("Fail: {0:f2}%", 1.0 * failed / students * 100);
            Console.WriteLine("Average: {0:f2}", 1.0 * allGrades / students);
        }
    }
}

