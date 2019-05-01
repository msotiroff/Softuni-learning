namespace P04.SortStudents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SortStudents
    {
        public static void Main(string[] args)
        {
            var students = new List<Student>();

            string inputLine;
            while ((inputLine = Console.ReadLine()) != "END")
            {
                var firstName = inputLine.Split().First();
                var lastName = inputLine.Split().Last();

                students.Add(new Student(firstName, lastName));
            }

            students
                .OrderBy(s => s.LastName)
                .ThenByDescending(s => s.FirstName)
                .ToList()
                .ForEach(s => Console.WriteLine($"{s.FirstName} {s.LastName}"));
        }
    }
}
