using System.Collections.Generic;

namespace VogCodeChallenge.Domain.EmployeeManagement
{
    public class Department
    {
        public string Name { get; set; }
        public Address Address { get; set; }
        public IEnumerable<Employee> Employees { get; set; }

        public Department(string name, Address address)
        {
            Name = name;
            Address = address;
            Employees = new List<Employee>();
        }
    }
}
