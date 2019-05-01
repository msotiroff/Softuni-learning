using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3.JSON_stringify
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string inputLine = Console.ReadLine();

            List<Student> allStudents = new List<Student>();

            while (inputLine != "stringify")
            {
                string[] inputParameters = inputLine
                    .Split(new[] { ' ', ':', '-', '>', ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                
                Student currentStudent = new Student
                {
                    Name = inputParameters[0],
                    Age = int.Parse(inputParameters[1]),
                    Grades = new List<int>()
                };
                for (int i = 2; i < inputParameters.Length; i++)
                {
                    int currentGrade = int.Parse(inputParameters[i]);
                    currentStudent.Grades.Add(currentGrade);
                }
                allStudents.Add(currentStudent);

                inputLine = Console.ReadLine();
            }
            
            StringBuilder buildResult = new StringBuilder();
            buildResult.Append("[");

            foreach (var student in allStudents)
            {
                // {name:"Pesho",age:25,grades:[6, 6, 5]}
                string currentStudentInfo = $"{{name:\"{student.Name}\",age:{student.Age},grades:[{string.Join(", ", student.Grades)}]}},";
                buildResult.Append(currentStudentInfo);
            }
            buildResult.Remove(buildResult.Length - 1, 1);
            buildResult.Append("]");

            string result = buildResult.ToString();

            Console.WriteLine(result);
        }
    }
}
