using System;
using System.Collections.Generic;
using System.Linq;

namespace _4.JSON_parse
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string[] inputParameters = input
                .Split(new[] { '{', '}' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            List<string> eachStudentInfo = new List<string>();

            List<Student> allStudents = new List<Student>();

            GetInfoAboutStudents(inputParameters, eachStudentInfo, allStudents);

            PrintOutput(allStudents);
        }

        public static void PrintOutput(List<Student> allStudents)
        {
            foreach (var student in allStudents)
            {
                var grades = student.Grades;
                string currentStudentGrades = "None";
                if (grades.Count > 0)
                {
                    currentStudentGrades = string.Join(", ", student.Grades);
                }
                Console.WriteLine($"{student.Name} : {student.Age} -> {currentStudentGrades}");
            }
        }

        public static void GetInfoAboutStudents(string[] inputParameters, List<string> eachStudentInfo, List<Student> allStudents)
        {
            for (int i = 1; i < inputParameters.Length; i += 2)
            {
                eachStudentInfo.Add(inputParameters[i]);
            }

            for (int i = 0; i < eachStudentInfo.Count; i++)
            {
                string[] currentStudentInfo = eachStudentInfo[i]
                    .Split(new[] { '"', ':', '[', ']', ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string name = currentStudentInfo[1];
                int age = int.Parse(currentStudentInfo[3]);
                List<int> grades = new List<int>();
                for (int j = 5; j < currentStudentInfo.Length; j++)
                {
                    int currGrade = int.Parse(currentStudentInfo[j]);
                    grades.Add(currGrade);
                }

                Student currentStudent = new Student
                {
                    Name = name,
                    Age = age,
                    Grades = grades
                };
                allStudents.Add(currentStudent);
            }
        }
    }
}
