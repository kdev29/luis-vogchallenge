using System.Collections.Generic;
using System.Linq;
using VogCodeChallenge.DataAccess.EF.DBModels;

namespace VogCodeChallenge.DataAccess.EF
{
    public class EmployeeDBContext
    {
        public IEnumerable<EmployeeDB> GetAllEmployeesFromDB()
        {
            yield return new EmployeeDB() { Name = "Luis", LastName = "Olvera", JobTitle = "SW Engineer", DepartmentAddress = "Mexico City", DepartmentName = "IT", MailingAddress = "0014 Mexico City" };
            yield return new EmployeeDB() { Name = "Elon", LastName = "Musk", JobTitle = "CEO", DepartmentAddress = "Washington", DepartmentName = "Sales", MailingAddress = "0014 Mexico City" };
            yield return new EmployeeDB() { Name = "Jeff", LastName = "Bezos", JobTitle = "Founder", DepartmentAddress = "Vancouver", DepartmentName = "Management", MailingAddress = "0014 Mexico City" };
            yield return new EmployeeDB() { Name = "Satya", LastName = "Nadella", JobTitle = "CIO", DepartmentAddress = "New York", DepartmentName = "Management", MailingAddress = "0014 Mexico City" };
        }

        public IEnumerable<EmployeeDB> GetAllEmployeesByDepartment(string department)
        {
            return GetAllEmployeesFromDB().Where(e => e.DepartmentName == department);
        }
    }
}
