namespace Employees.App.Commands
{
    using System.Linq;

    using Employees.App.Interfaces;
    using Employees.Services;
    using System;

    internal class SetAddress : ICommand
    {
        private readonly EmployeeService employeeService;

        public SetAddress(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        // <employeeId> <address> 
        public string Execute(params string[] args)
        {
            if (args.Length < 2)
            {
                throw new InvalidOperationException("Invalid command parameters!");
            }

            var employeeId = int.Parse(args[0]);
            var employeeAddress = string.Join(" ", args.Skip(1));

            var employeeName = employeeService.SetAddress(employeeId, employeeAddress);

            return $"{employeeName}'s address was set to {employeeAddress}";
        }
    }
}
