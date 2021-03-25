using System.Collections.Generic;
using System.Linq;
using VogCodeChallenge.Domain.EmployeeManagement;

namespace VogCodeChallenge.Domain.Services
{
    public class EmployeeManagementService : IEmployeeManagementService
    {
        public IEnumerable<Employee> GetAll()
        {
            return GetTestData();
        }

        public IList<Employee> ListAll()
        {
            return GetTestData().ToList();
        }

        private IEnumerable<Employee> GetTestData()
        {
            yield return new Employee("Luis", "Olvera", "Software Engineer", new Address() { FullAddress = "Mexico City" }, "IT");
            yield return new Employee("Elon", "Musk", "Founder", new Address() { FullAddress = "California" }, "Sales");
            yield return new Employee("Jeff", "Bezos", "CEO", new Address() { FullAddress = "New York" }, "Finance");
            yield return new Employee("Satya", "Nadella", "CIO", new Address() { FullAddress = "Washington" }, "Finance");
        }
    }
}
