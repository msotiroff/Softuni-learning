namespace P02_DatabaseFirst
{
    using System;
    using System.Linq;
    using P02_DatabaseFirst.Data;
    using Microsoft.EntityFrameworkCore;
    using P02_DatabaseFirst.Data.Models;
    using System.Collections.Generic;
    using System.Globalization;

    public class Startup
    {
        public static void Main(string[] args)
        {
            ///*  Problem 03.Employees Full Information
            //     *  Your first task is to extract all employees and print their first, last and middle name, their job title and salary, 
            //     *  rounded to 2 symbols after the decimal separator, 
            //     *  all of those separated with a space. Order them by employee id. */
            //EmployeesFullInformation();

            ///*  Problem 04.Employees with Salary Over 50 000
            // *   Your task is to extract all employees with salary over 50000.
            // *   Return only the first names of those employees, 
            // *   ordered alphabetically.
            // */
            //EmployeesWithSalaryOver50000();


            ///*  Problem 05. Employees from Research and Development
            // *   Extract all employees from the Research and Development department. Order them by salary (in ascending order), 
            // *   then by first name (in descending order). Print only their first name, last name, 
            // *   department name and salary in the format shown below:
            // *   Gigi Matthew from Research and Development - $40900.00
            // */
            //EmployeesFromResearchAndDevelopment();


            ///*  Problem 06. Adding a New Address and Updating Employee
            // *      Create a new address with text "Vitoshka 15" and TownId 4.
            // *      Set that address to the employee with last name "Nakov".
            // *      Then order by descending all the employees by their Address’ Id, take 10 rows and from them, 
            // *      take the AddressText. Print the results each on a new line
            // */
            //AddingAddressAndUpdatingEmployee();


            ///*  Problem 07. Employees and Projects
            // *      Find the first 30 employees who have projects started in the time period 2001 - 2003 (inclusive).
            // *      Print each employee's first name, last name and manager’s first name and last name
            // *      and each of their projects' name, start date, end date.
            // *      If a project has no end date, print "not finished" instead.
            // */
            //EmployeesAndProjects();


            ///*  Problem 08. Addresses by Town
            // *      Find all addresses, ordered by the number of employees who live there (descending),
            // *      then by town name (ascending), and finally by address text (ascending).
            // *      Take only the first 10 addresses. For each address print it in the format "<AddressText>, <TownName> - <EmployeeCount> employees"
            // */
            //AddressesByTown();


            ///*  Problem 09. Employee 147
            // *      Get the employee with id 147. Print only his/her first name, last name, job title and projects (print only their names).
            // *      The projects should be ordered by name (ascending). Format of the output:
            // *      <Linda Randall - Production Technician>
            // */
            //Employee147();


            ///*  Problem 10. Departments with More Than 5 Employees
            // *      Find all departments with more than 5 employees. Order them by employee count (ascending). 
            // *      For each department, print the department name and the manager’s first and last name on the first row.
            // *      Then print the first name, the last name and the job title of every employee on a new row.
            // *      Then, print 10 dashes before the next department ("----------").
            // *      Order the employees by first name (ascending), then by last name (ascending).
            // *      Format of the output: Engineering – Terri Duffy
            // */
            //DepartmentsWithMoreThanFiveEmployees();


            ///*  Problem 11. Find Latest 10 Projects
            // *      Write a program that prints information about the last 10 started projects.
            // *      Sort them by name lexicographically and print their name, description and start date, each on a new row.
            // */
            //FindLatestTenProjects();


            ///*  Problem 12.Increase Salaries
            // *      Write a program that increase salaries of all employees that are in the Engineering,
            // *      Tool Design, Marketing or Information Services department by 12%. 
            // *      Then print first name, last name and salary (2 symbols after the decimal separator) 
            // *      for those employees whose salary was increased.
            // *      Order them by first name (ascending), then by last name (ascending). 
            // */
            //IncreaseSalaries();


            ///*  Problem 13. Find Employees by First Name Starting With Sa
            // *      Write a program that finds all employees whose first name starts with "Sa".
            // *      Print their first, last name, their job title and salary. 
            // *      Order them by first name, then by last name (ascending).
            // *      Note: You have to solve previous task in order to display proper results.
            // */
            //FindEmployeesByFirstName();


            ///*  Problem 14.	Delete Project by Id
            // *      Let's delete the project with id 2. 
            // *      Then, take 10 projects and print their names on the console, each on a new line. 
            // *      Remember to restore your database after this task.
            // */
            //DeleteProjectById();

        }

        private static void DeleteProjectById()
        {
            using (var db = new SoftUniContext())
            {
                var projectToBeDeleted = db.Projects
                                        .Include(p => p.EmployeesProjects)
                                        .FirstOrDefault(p => p.ProjectId == 2);

                db.Projects.Remove(projectToBeDeleted);
                db.SaveChanges();

                var projects = db.Projects.Take(10).ToList();

                projects.ForEach(p => Console.WriteLine(p.Name));
            }
        }

        private static void FindEmployeesByFirstName()
        {
            using (var db = new SoftUniContext())
            {
                var employees = db.Employees
                                .Where(e => e.FirstName.Substring(0, 2) == "Sa")
                                .OrderBy(e => e.FirstName)
                                .ThenBy(e => e.LastName)
                                .ToList();

                foreach (var employee in employees)
                {
                    Console.WriteLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle} - (${employee.Salary:f2})");
                }
            }
        }

        private static void IncreaseSalaries()
        {
            using (var db = new SoftUniContext())
            {
                string[] neededDepartments = new string[]
                {
                    "Engineering",
                    "Tool Design",
                    "Marketing",
                    "Information Services"
                };

                var employeesToIncreaseSalary = db
                                .Employees
                                .Where(e => neededDepartments.Contains(e.Department.Name))
                                .ToList();

                employeesToIncreaseSalary.ForEach(e => e.Salary *= 1.12m);
                db.SaveChanges();

                foreach (var employee in employeesToIncreaseSalary
                                            .OrderBy(e => e.FirstName)
                                            .ThenBy(e => e.LastName))
                {
                    Console.WriteLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:f2})");
                }
            }
        }

        private static void FindLatestTenProjects()
        {
            using (var db = new SoftUniContext())
            {
                var lastTen = db.Projects
                                .OrderByDescending(p => p.StartDate)
                                .Take(10)
                                .ToList();

                foreach (var project in lastTen.OrderBy(p => p.Name))
                {
                    Console.WriteLine(project.Name);
                    Console.WriteLine(project.Description);
                    Console.WriteLine(project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture));
                }
            }
        }

        private static void DepartmentsWithMoreThanFiveEmployees()
        {
            using (var db = new SoftUniContext())
            {
                var departments = db.Departments
                                    .Include(d => d.Employees)
                                    .Include(d => d.Manager)
                                    .Where(d => d.Employees.Count > 5)
                                    .OrderBy(d => d.Employees.Count)
                                    .ThenBy(d => d.Name)
                                    .ToList();

                foreach (var department in departments)
                {
                    Console.WriteLine($"{department.Name} - {department.Manager.FirstName} {department.Manager.LastName}");

                    foreach (var employee in department.Employees
                        .OrderBy(e => e.FirstName).ThenBy(e => e.LastName))
                    {
                        Console.WriteLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
                    }

                    Console.WriteLine(new string('-', 10));
                }
            }
        }

        private static void Employee147()
        {
            using (var db = new SoftUniContext())
            {
                var employee = db.Employees
                                .Include(e => e.EmployeesProjects).ThenInclude(e => e.Project)
                                .Where(e => e.EmployeeId == 147)
                                .ToList();

                foreach (var emp in employee)
                {
                    Console.WriteLine($"{emp.FirstName} {emp.LastName} - {emp.JobTitle}");

                    foreach (var project in emp.EmployeesProjects.Select(e => e.Project).OrderBy(p => p.Name))
                    {
                        Console.WriteLine(project.Name);
                    }
                }

            }
        }

        private static void AddressesByTown()
        {
            using (var db = new SoftUniContext())
            {
                var addresses = db.Addresses
                                .Include(a => a.Town)
                                .ToList();

                int counter = 0;
                foreach (var address in addresses
                                        .OrderByDescending(a => a.Employees.Count())
                                        .ThenBy(a => a.Town.Name)
                                        .ThenBy(a => a.AddressText))
                {
                    counter++;

                    Console.WriteLine($"{address.AddressText}, {address.Town.Name} - {address.Employees.Count} employees");
                    if (counter == 10)
                    {
                        break;
                    }
                }
            }
        }

        private static void EmployeesAndProjects()
        {
            using (var db = new SoftUniContext())
            {
                var employees = db.Employees
                                .Include(e => e.EmployeesProjects).ThenInclude(e => e.Project)
                                .Include(e => e.Manager)
                                .Where(e => e.EmployeesProjects.Any(ep => ep.Project.StartDate.Year >= 2001 && ep.Project.StartDate.Year <= 2003))
                                .ToList();

                foreach (var employee in employees.Take(30))
                {


                    Console.WriteLine($"{employee.FirstName} {employee.LastName} " +
                        $"- Manager: {employee.Manager.FirstName} {employee.Manager.LastName}");

                    foreach (var project in employee.EmployeesProjects.Select(ep => ep.Project).Distinct())
                    {
                        Console.WriteLine($"--{project.Name} " +
                            $"- {project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)} " +
                            $"- {project.EndDate?.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture) ?? "not finished"}");
                    }
                }
            }
        }

        private static void AddingAddressAndUpdatingEmployee()
        {
            using (var db = new SoftUniContext())
            {
                var address = new Address()
                {
                    AddressText = "Vitoshka 15",
                    TownId = 4
                };

                var employee = db.Employees.SingleOrDefault(e => e.LastName == "Nakov");

                db.Addresses.Add(address);
                employee.Address = address;

                db.SaveChanges();

                var result = db.Employees
                            .Include("Address")
                            .OrderByDescending(e => e.AddressId)
                            .Take(10)
                            .ToList();

                result.ForEach(r => Console.WriteLine(r.Address.AddressText));
            }
        }

        private static void EmployeesFromResearchAndDevelopment()
        {
            using (var db = new SoftUniContext())
            {
                var employees = db.Employees
                        .Where(e => e.Department.Name == "Research and Development")
                        .OrderBy(e => e.Salary)
                        .ThenByDescending(e => e.FirstName)
                        .Select(e => new
                        {
                            e.FirstName,
                            e.LastName,
                            e.Department,
                            e.Salary
                        })
                        .ToList();

                foreach (var emp in employees)
                {
                    Console.WriteLine($"{emp.FirstName} {emp.LastName} from {emp.Department.Name} - ${emp.Salary:f2}");
                }
            }
        }

        private static void EmployeesWithSalaryOver50000()
        {
            using (var db = new SoftUniContext())
            {
                var employees = db.Employees
                                .Select(e => new
                                {
                                    e.FirstName,
                                    e.Salary
                                })
                                .Where(e => e.Salary > 50000)
                                .OrderBy(e => e.FirstName)
                                .ToList();

                employees.ForEach(e => Console.WriteLine(e.FirstName));
            }
        }

        private static void EmployeesFullInformation()
        {
            using (var db = new SoftUniContext())
            {
                var employees = db.Employees
                                .Select(e => new
                                {
                                    e.EmployeeId,
                                    e.FirstName,
                                    e.LastName,
                                    e.MiddleName,
                                    e.JobTitle,
                                    e.Salary
                                })
                                .ToList();

                foreach (var emp in employees.OrderBy(e => e.EmployeeId))
                {
                    Console.WriteLine($"{emp.FirstName} {emp.LastName} {emp.MiddleName} {emp.JobTitle} {emp.Salary:f2}");
                }
            }
        }
    }
}