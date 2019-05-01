namespace Employees.DtoModels
{
    using System.Collections.Generic;

    public class ManagerDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int SubEmployeesCount
        {
            get
            {
                return this.SubEmployees.Count;
            }
        }

        public ICollection<EmployeeDto> SubEmployees { get; set; } = new List<EmployeeDto>();
    }
}
