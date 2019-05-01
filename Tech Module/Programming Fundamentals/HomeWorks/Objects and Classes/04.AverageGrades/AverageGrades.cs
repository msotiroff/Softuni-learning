using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.AverageGrades
{
    class AverageGrades
    {
        static void Main(string[] args)
        {
            int numberOfStudents = int.Parse(Console.ReadLine());

            List<Student> allStudents = new List<Student>();

            for (int i = 0; i < numberOfStudents; i++)
            {
                string[] currentStudentProps = Console.ReadLine().Split(' ');

                string currStudentName = currentStudentProps[0];
                List<double> currStudentGrades = new List<double>();

                for (int j = 1; j < currentStudentProps.Length; j++)
                {
                    double currentGrade = double.Parse(currentStudentProps[j]);
                    currStudentGrades.Add(currentGrade);
                }

                Student currentStudent = new Student()
                {
                    Name = currStudentName,
                    Grades = new List<double>(),
                    AverageGrade = 0
                };

                currentStudent.Grades.AddRange(currStudentGrades);
                currentStudent.AverageGrade = currentStudent.Grades.Average();

                allStudents.Add(currentStudent);
            }


            foreach (var student in allStudents
                .Where(st => st.AverageGrade >= 5.00)
                .OrderBy(st => st.Name)
                .ThenByDescending(st => st.AverageGrade))
            {
                Console.WriteLine($"{student.Name} -> {student.AverageGrade:f2}");
            }

        }
    }
}
