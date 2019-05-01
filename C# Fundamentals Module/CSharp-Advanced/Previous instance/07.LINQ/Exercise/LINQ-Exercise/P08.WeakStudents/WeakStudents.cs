namespace P08.WeakStudents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class WeakStudents
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
                .Where(s => s.Grades.Where(g => g <= 3).Count() >= 2)
                .ToList()
                .ForEach(s => Console.WriteLine($"{s.FirstName} {s.LastName}"));
        }
    }
}
