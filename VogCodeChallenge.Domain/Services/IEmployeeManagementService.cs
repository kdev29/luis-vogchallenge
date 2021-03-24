using System.Collections.Generic;
using VogCodeChallenge.Domain.EmployeeManagement;

namespace VogCodeChallenge.Domain.Services
{
    public interface IEmployeeManagementService
    {
        IEnumerable<Employee> GetAll();
        IList<Employee> ListAll();
    }
}
