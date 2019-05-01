namespace Employees.Services
{
    using System;
    using System.Linq;
    using System.Text;

    using Employees.Data;
    using Employees.Models;
    using Employees.DtoModels;

    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using AutoMapper.QueryableExtensions;

    public class EmployeeService
    {
        private readonly EmployeesDbContext db;

        public EmployeeService(EmployeesDbContext db)
        {
            this.db = db;
        }

        public EmployeeDto GetEmployeeById(int employeeId)
        {
            var employee = db
                .Employees
                .Find(employeeId);

            if (employee == null)
            {
                throw new ArgumentException($"Employee with id {employeeId} not found");
            }

            var employeeDto = Mapper.Map<EmployeeDto>(employee);

            return employeeDto;
        }

        public string ListEmployeesOlderThan(int age)
        {
            var employees = db
                .Employees
                .Where(e => e.GetAge() > age)
                .Include(e => e.Manager)
                .OrderByDescending(e => e.Salary)
                .ProjectTo<EmployeeDto>()
                .ToList();

            if (employees.Count == 0)
            {
                throw new ArgumentException($"No employees older than {age}");
            }

            var result = new StringBuilder();


            foreach (var employee in employees)
            {
                string managerLastName = "[no manager]";
                if (employee.Manager != null)
                {
                    managerLastName = employee.Manager.LastName;
                }

                result.AppendLine($"{employee.FirstName} {employee.LastName} - ${employee.Salary:f2} - Manager: {managerLastName}");
            }

            return result.ToString().TrimEnd();
        }

        public ManagerDto GetManagerInfoById(int employeeId)
        {
            var manager = db
                .Employees
                .Include(m => m.SubEmployees)
                .FirstOrDefault(m => m.Id == employeeId);

            if (manager == null)
            {
                throw new ArgumentException($"Employee with id {employeeId} not found");
            }

            var managerDto = Mapper.Map<ManagerDto>(manager);

            return managerDto;
        }

        public string SetAddress(int employeeId, string employeeAddress)
        {
            var employee = db
                .Employees
                .Find(employeeId);

            if (employee == null)
            {
                throw new ArgumentException($"Employee with id {employeeId} not found");
            }

            employee.Address = employeeAddress;
            db.SaveChanges();

            return employee.FirstName + " " + employee.LastName;
        }

        public string SetManager(int employeeId, int managerId)
        {
            var employee = db
                .Employees
                .Find(employeeId);

            if (employee == null)
            {
                throw new ArgumentException($"Employee with id {employeeId} not found");
            }

            var manager = db
                .Employees
                .FirstOrDefault(e => e.Id == managerId);

            if (manager == null)
            {
                throw new InvalidOperationException($"Employee with Id {managerId} not found");
            }

            employee.ManagerId = managerId;
            db.SaveChanges();

            return $"{manager.FirstName} {manager.LastName} setted up as manager of {employee.FirstName} {employee.LastName}";
        }

        public void AddEmployee(EmployeeDto employeeDto)
        {
            var employee = Mapper.Map<Employee>(employeeDto);

            db.Employees.Add(employee);
            db.SaveChanges();
        }

        public string SetBirthday(int employeeId, DateTime birthDay)
        {
            var employee = db
                .Employees
                .Find(employeeId);

            if (employee == null)
            {
                throw new ArgumentException($"Employee with id {employeeId} not found");
            }

            employee.BirthDay = birthDay;
            db.SaveChanges();

            return employee.FirstName + " " + employee.LastName;
        }

        public EmployeePersonalDto GetPersonalInfoById(int employeeId)
        {
            var employee = db
                .Employees
                .Find(employeeId);

            if (employee == null)
            {
                throw new ArgumentException($"Employee with id {employeeId} not found");
            }

            var employeeDto = Mapper.Map<EmployeePersonalDto>(employee);

            return employeeDto;
        }
    }
}
