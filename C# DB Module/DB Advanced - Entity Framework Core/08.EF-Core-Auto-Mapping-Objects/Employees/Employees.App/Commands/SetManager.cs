namespace Employees.App.Commands
{
    using Employees.App.Interfaces;
    using Employees.Services;
    using System;

    internal class SetManager : ICommand
    {
        private readonly EmployeeService employeeService;

        public SetManager(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        // <employeeId> <managerId> => sets the second employee to be a manager of the first employee
        public string Execute(params string[] args)
        {
            if (args.Length != 2)
            {
                throw new InvalidOperationException("Invalid command parameters!");
            }

            int employeeId = int.Parse(args[0]);
            int managerId = int.Parse(args[1]);

            var settedUp = employeeService.SetManager(employeeId, managerId);
            
            return settedUp;
        }
    }
}
