using System;
using System.Collections.Generic;
using System.Linq;

class StartUp
{
    static void Main(string[] args)
    {
        var employees = new List<Employee>();

        var lineCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < lineCount; i++)
        {
            var personArgs = Console.ReadLine().Split();

            var name = personArgs[0];
            var salary = decimal.Parse(personArgs[1]);
            var position = personArgs[2];
            var department = personArgs[3];
            string email;
            int age;

            Employee employee = null;

            if (personArgs.Length == 5)
            {
                if (int.TryParse(personArgs[4], out age))
                {
                    employee = new Employee(name, salary, position, department, age);
                }
                else
                {
                    email = personArgs[4];
                    employee = new Employee(name, salary, position, department, email);
                }
            }
            else if (personArgs.Length == 6)
            {
                email = personArgs[4];
                age = int.Parse(personArgs[5]);

                employee = new Employee(name, salary, position, department, email, age);
            }
            else
            {
                employee = new Employee(name, salary, position, department);
            }

            employees.Add(employee);
        }

        var highestSalaryDepartment = employees
            .GroupBy(e => e.Department)
            .OrderByDescending(d => d.Sum(e => e.Salary))
                .First()
            .OrderByDescending(e => e.Salary)
            .ToList();

        Console.WriteLine($"Highest Average Salary: {highestSalaryDepartment.FirstOrDefault()?.Department}");
        highestSalaryDepartment.ForEach(e => Console.WriteLine(e));
    }
}