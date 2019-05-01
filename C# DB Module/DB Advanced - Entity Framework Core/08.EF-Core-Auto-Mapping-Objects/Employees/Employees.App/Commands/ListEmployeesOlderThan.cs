namespace Employees.App.Commands
{
    using Employees.App.Interfaces;
    using Employees.Services;
    using System;

    internal class ListEmployeesOlderThan : ICommand
    {
        private readonly EmployeeService employeeService;

        public ListEmployeesOlderThan(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        // <age>
        public string Execute(params string[] args)
        {
            if (args.Length != 1)
            {
                throw new InvalidOperationException("Invalid command parameters!");
            }

            int age = int.Parse(args[0]);

            var result = employeeService.ListEmployeesOlderThan(age);

            return result;
        }
    }
}
