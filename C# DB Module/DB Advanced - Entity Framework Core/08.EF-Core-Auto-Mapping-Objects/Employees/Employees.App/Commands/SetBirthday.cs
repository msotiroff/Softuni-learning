namespace Employees.App.Commands
{
    using System;
    using System.Globalization;

    using Employees.App.Interfaces;
    using Employees.Services;

    internal class SetBirthday : ICommand
    {
        private readonly EmployeeService employeeService;

        public SetBirthday(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        // <employeeId> <"dd-MM-yyyy">
        public string Execute(params string[] args)
        {
            if (args.Length != 2)
            {
                throw new InvalidOperationException("Invalid command parameters!");
            }

            int employeeId = int.Parse(args[0]);
            DateTime date = DateTime.ParseExact(args[1], "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var employeeName = employeeService.SetBirthday(employeeId, date);

            return $"{employeeName}'s birthday was set to {args[1]}";
        }
    }
}
