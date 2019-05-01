namespace Employees.Models
{
    using System;
    using System.Collections.Generic;

    public class Employee
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal Salary { get; set; }

        public DateTime? BirthDay { get; set; }

        public string Address { get; set; }

        public int? ManagerId { get; set; }
        public Employee Manager { get; set; }

        public ICollection<Employee> SubEmployees { get; set; } = new List<Employee>();

        public int GetAge()
        {
            DateTime currentDate = DateTime.Now;
            DateTime birthDate = this.BirthDay.Value;

            int age = (currentDate.Year - birthDate.Year);

            if (currentDate.Month < birthDate.Month || (currentDate.Month == birthDate.Month && currentDate.Day < birthDate.Day))
            {
                age--;
            }

            return age;
        }
    }
}
