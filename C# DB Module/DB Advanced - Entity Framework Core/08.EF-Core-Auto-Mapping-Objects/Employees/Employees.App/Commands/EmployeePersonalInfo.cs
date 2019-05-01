namespace Employees.App.Commands
{
    using System;
    using System.Globalization;

    using Employees.App.Interfaces;
    using Employees.Services;

    class EmployeePersonalInfo : ICommand
    {
        private readonly EmployeeService employeeService;

        public EmployeePersonalInfo(EmployeeService employeeService)
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

            var employee = employeeService.GetPersonalInfoById(employeeId);

            string birthDay = "[No Birthday specified]";

            if (employee.BirthDay != null)
            {
                birthDay = employee.BirthDay.Value.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture);
            }

            string address = employee.Address ?? "[No address specified]";

            string result = $"ID: {employeeId} - {employee.FirstName} {employee.LastName} - " +
                $"${employee.Salary:f2} {Environment.NewLine}Birthday: {birthDay} " +
                $"{Environment.NewLine}Address: {address}";


            return result;
        }
    }
}
