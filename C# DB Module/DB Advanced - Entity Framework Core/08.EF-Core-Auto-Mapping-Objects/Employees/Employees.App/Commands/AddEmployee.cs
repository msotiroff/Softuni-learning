namespace Employees.App.Commands
{
    using Employees.App.Interfaces;
    using Employees.DtoModels;
    using Employees.Services;
    using System;

    public class AddEmployee : ICommand
    {
        private readonly EmployeeService employeeService;

        public AddEmployee(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        // <firstName> <lastName> <salary>
        public string Execute(params string[] args)
        {
            if (args.Length != 3)
            {
                throw new InvalidOperationException("Invalid command parameters!");
            }

            string firstName = args[0];
            string lastName = args[1];
            decimal salary = decimal.Parse(args[2]);

            var employeeDto = new EmployeeDto(firstName, lastName, salary);

            employeeService.AddEmployee(employeeDto);

            return $"Employee {firstName} {lastName} added successfully!";
        }
    }
}
