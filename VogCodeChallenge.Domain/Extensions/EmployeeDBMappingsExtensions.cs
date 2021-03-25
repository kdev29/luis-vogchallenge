using VogCodeChallenge.DataAccess.EF.DBModels;
using VogCodeChallenge.Domain.EmployeeManagement;

namespace VogCodeChallenge.Domain.Extensions
{
    public static class EmployeeDBMappingsExtensions
    {
        public static Employee ToDomainObject(this EmployeeDB employeeDB)
        {
            return new Employee(employeeDB.Name, employeeDB.LastName, employeeDB.JobTitle, new Address() { FullAddress = employeeDB.MailingAddress }, employeeDB.DepartmentName) 
            {
                Department = new Department(employeeDB.DepartmentName, new Address() { FullAddress = employeeDB.DepartmentAddress }),
            };
        }
    }
}
