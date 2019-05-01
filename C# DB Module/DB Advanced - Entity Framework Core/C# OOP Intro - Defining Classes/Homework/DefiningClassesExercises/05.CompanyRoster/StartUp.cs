using System;
using System.Collections.Generic;
using System.Linq;
class StartUp
{
    static void Main(string[] args)
    {
        int numberOfLines = int.Parse(Console.ReadLine());

        Dictionary<string, List<Employee>> allEmployees = new Dictionary<string, List<Employee>>();

        for (int i = 0; i < numberOfLines; i++)
        {
            string[] inputParams = Console.ReadLine().Split().ToArray();
            string name = inputParams[0];
            decimal salary = decimal.Parse(inputParams[1]);
            string position = inputParams[2];
            string department = inputParams[3];
            string email;
            int age;

            var currentEmployee = new Employee(name, salary, position, department);

            if (inputParams.Length == 5)
            {
                if (int.TryParse(inputParams[4], out age))
                {
                    currentEmployee.Age = age;
                }
                else
                {
                    email = inputParams[4];
                    currentEmployee.Email = email;
                }
            }
            else if (inputParams.Length == 6)
            {
                email = inputParams[4];
                age = int.Parse(inputParams[5]);
                currentEmployee.Email = email;
                currentEmployee.Age = age;
            }

            if (! allEmployees.ContainsKey(department))
            {
                allEmployees[department] = new List<Employee>();
            }

            allEmployees[department].Add(currentEmployee);
        }

        Dictionary<string, decimal> departmentsByAvgSalary = new Dictionary<string, decimal>();

        foreach (var department in allEmployees)
        {
            decimal averageSalary = allEmployees[department.Key].Average(a => a.Salary);
            departmentsByAvgSalary.Add(department.Key, averageSalary);
        }

        string mostPaidDepartment = departmentsByAvgSalary.OrderByDescending(d => d.Value).First().Key;

        foreach (var dep in allEmployees.Where(d => d.Key == mostPaidDepartment))
        {
            Console.WriteLine($"Highest Average Salary: {dep.Key}");
            foreach (var emp in dep.Value.OrderByDescending(e => e.Salary))
            {
                // Print name, salary, email and age
                Console.WriteLine($"{emp.Name} {emp.Salary:f2} {emp.Email} {emp.Age}");
            }
        }
    }
}
