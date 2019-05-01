namespace P03.StudentsByAge
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StudentsByAge
    {
        public static void Main(string[] args)
        {
            var students = new List<Student>();

            string inputLine;
            while ((inputLine = Console.ReadLine()) != "END")
            {
                var inputArgs = inputLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var firstName = inputArgs.First();
                var lastName = inputArgs.Skip(1).First();
                var age = int.Parse(inputArgs.Last());

                students.Add(new Student(firstName, lastName, age));
            }

            students
                .Where(s => s.Age >= 18 && s.Age <= 24)
                .ToList()
                .ForEach(s => Console.WriteLine($"{s.FirstName} {s.LastName} {s.Age}"));
        }
    }
}
