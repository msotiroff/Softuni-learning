namespace Employees.App.Commands
{
    using Employees.App.Interfaces;
    using Employees.Services;
    using System;

    internal class ManagerInfo : ICommand
    {
        private readonly EmployeeService employeeService;

        public ManagerInfo(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        // <EmployeeId>
        public string Execute(params string[] args)
        {
            if (args.Length != 1)
            {
                throw new InvalidOperationException("Invalid command parameters!");
            }

            int employeeId = int.Parse(args[0]);

            var managerDto = employeeService.GetManagerInfoById(employeeId);

            var result = $"{managerDto.FirstName} {managerDto.LastName} | Employees: {managerDto.SubEmployeesCount}";

            foreach (var subEmpl in managerDto.SubEmployees)
            {
                result += $"{Environment.NewLine}    - {subEmpl.FirstName} {subEmpl.LastName} - ${subEmpl.Salary:f2}";
            }

            return result;
        }
    }
}
