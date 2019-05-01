﻿namespace P02.StudentsByFirsAandLastName
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StudentsByFirsAndLastName
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
                .Where(s => string.Compare(s.FirstName, s.LastName) < 0)
                .ToList()
                .ForEach(s => Console.WriteLine($"{s.FirstName} {s.LastName}"));
        }
    }
}