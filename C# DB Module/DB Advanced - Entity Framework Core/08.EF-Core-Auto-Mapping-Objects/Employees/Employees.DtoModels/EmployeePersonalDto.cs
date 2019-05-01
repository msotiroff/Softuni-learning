namespace Employees.DtoModels
{
    using System;

    public class EmployeePersonalDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal Salary { get; set; }

        public DateTime? BirthDay { get; set; }

        public string Address { get; set; }
    }
}
