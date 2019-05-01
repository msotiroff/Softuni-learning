namespace Employees.App.Commands
{
    using Employees.App.Interfaces;
    using Employees.Services;
    using System;

    public class EmployeeInfo : ICommand
    {
        private readonly EmployeeService employeeService;

        public EmployeeInfo(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        // <employeeId>
        public string Execute(params string[] args)
        {
            if (args.Length != 1)
            {
                throw new InvalidOperationException("Invalid command parameters!");
            }

            int employeeId = int.Parse(args[0]);

            var employee = employeeService.GetEmployeeById(employeeId);

            return $"ID: {employeeId} - {employee.FirstName} {employee.LastName} -  ${employee.Salary:f2}";
        }
    }
}
