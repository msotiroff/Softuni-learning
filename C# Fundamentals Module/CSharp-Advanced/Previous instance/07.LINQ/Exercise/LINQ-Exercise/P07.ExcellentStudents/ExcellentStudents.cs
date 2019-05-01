namespace P07.ExcellentStudents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ExcellentStudents
    {
        public static void Main(string[] args)
        {
            var allStudents = new List<Student>();

            string inputLine;
            while ((inputLine = Console.ReadLine()) != "END")
            {
                var inputParams = inputLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var firstName = inputParams[0];
                var lastName = inputParams[1];
                var grades = inputParams.Skip(2).Select(double.Parse).ToArray();

                var currentStudent = new Student(firstName, lastName, grades);

                allStudents.Add(currentStudent);
            }

            allStudents
                .Where(s => s.Grades.Any(g => g == 6))
                .ToList()
                .ForEach(s => Console.WriteLine($"{s.FirstName} {s.LastName}"));
        }
    }
}
