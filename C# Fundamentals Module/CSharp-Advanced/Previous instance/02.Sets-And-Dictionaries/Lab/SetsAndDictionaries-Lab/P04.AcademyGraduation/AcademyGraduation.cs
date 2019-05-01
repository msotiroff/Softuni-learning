namespace P04.AcademyGraduation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class AcademyGraduation
    {
        public static void Main(string[] args)
        {
            var countOfStudents = int.Parse(Console.ReadLine());

            var students = new SortedDictionary<string, double[]>();

            for (int i = 0; i < countOfStudents; i++)
            {
                var studentName = Console.ReadLine();

                var grades = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();

                if (!students.ContainsKey(studentName))
                {
                    students[studentName] = new double[grades.Length];
                }

                students[studentName] = grades;
            }

            foreach (var student in students)
            {
                var studentName = student.Key;
                var studentAvgGrade = student.Value.Average();

                Console.WriteLine($"{studentName} is graduated with {studentAvgGrade}");
            }
        }
    }
}
