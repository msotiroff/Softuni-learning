namespace P09.StudentsEnrolledIn2014or2015
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StudentsEnrolledIn2014or2015
    {
        public static void Main(string[] args)
        {
            var allStudents = new List<Student>();

            string inputLine;
            while ((inputLine = Console.ReadLine()) != "END")
            {
                var inputArgs = inputLine
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var facultyNumber = inputArgs.First();
                var grades = inputArgs.Skip(1).Select(int.Parse).ToArray();

                allStudents.Add(new Student(facultyNumber, grades));
            }

            allStudents
                .Where(s => s.FacultyNumber.EndsWith("14") || s.FacultyNumber.EndsWith("15"))
                .ToList()
                .ForEach(s => Console.WriteLine($"{string.Join(" ", s.Grades)}"));
        }
    }
}
